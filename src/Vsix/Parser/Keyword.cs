﻿using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;
using System.Collections.Generic;
using System.Linq;
using System;

namespace EditorConfig
{
    class Keyword
    {
        private static List<Keyword> _dic = new List<Keyword>
        {
            // Standard properties
            {new Keyword("root", true, Resources.Text.KeywordRoot, KnownMonikers.Property, "true")},
            {new Keyword("charset", true, Resources.Text.KeywordCharset, KnownMonikers.Property, "latin1", "utf-8", "utf-8-bom", "utf-16be", "utf-16le", "utf-8-bom")},
            {new Keyword("end_of_line", true, Resources.Text.KeywordEndOfLine, KnownMonikers.Property, "lf", "crlf", "cr") },
            {new Keyword("indent_style", true, Resources.Text.KeywordIndentStyle, KnownMonikers.Property, "tab", "space")},
            {new Keyword("indent_size", true, Resources.Text.KeywordIndentSize, KnownMonikers.Property, "tab") },
            {new Keyword("tab_width", true, Resources.Text.KeywordTabWidth, KnownMonikers.Property) },
            {new Keyword("trim_trailing_whitespace", false, Resources.Text.KeywordTrimTrailingWhitespace, KnownMonikers.Property, "true", "false")},
            {new Keyword("insert_final_newline", false, Resources.Text.KeywordInsertFinalNewline, KnownMonikers.Property, "true", "false")},

            // C# code analysis
            {new Keyword("csharp_style_conditional_delegate_call", true, "Prefer conditional delegate calls.", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_expression_bodied_accessors", true, "Prefer expression-bodied members.", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_expression_bodied_constructors", true, "Prefer expression-bodied members", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_expression_bodied_indexers", true, "Prefer expression-bodied members", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_expression_bodied_methods", true, "Prefer expression-bodied members.", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_expression_bodied_operators", true, "Prefer expression-bodied members.", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_expression_bodied_properties", true, "Prefer expression-bodied members", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_inlined_variable_declaration", true, "Prefer to inline variable declaration.", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_pattern_matching_over_as_with_null_check", true, "Prefer pattern matching.", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_pattern_matching_over_is_with_cast_check", true, "Prefer pattern matching.", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_throw_expression", true, "Prefer throw expressions", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_var_elsewhere", true, "Prefer var elsewhere.", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_var_for_built_in_types", true, "Prefer var for built-in types.", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_var_for_locals", true, "Prefer var for locals.", KnownMonikers.CSFileNode, "true", "false")},
            {new Keyword("csharp_style_var_when_type_is_apparent", true, "Prefer var when type is apparent.", KnownMonikers.CSFileNode, "true", "false")},

            // .NET style analysis
            {new Keyword("dotnet_style_coalesce_expression", true, "Prefer null coalescing operator (??).", KnownMonikers.DotNET, "true", "false")},
            {new Keyword("dotnet_style_collection_initializer", true, "Prefer collection intiailizers.", KnownMonikers.DotNET, "true", "false")},
            {new Keyword("dotnet_style_null_propagation", true, "Prefer null propagation (?.).", KnownMonikers.DotNET, "true", "false")},
            {new Keyword("dotnet_style_object_initializer", true, "Prefer object initializers.", KnownMonikers.DotNET, "true", "false")},
            {new Keyword("dotnet_style_predefined_type_for_locals_parameters_members", true, "Prefer language types (e.g. int, string, float).", KnownMonikers.DotNET, "true", "false")},
            {new Keyword("dotnet_style_predefined_type_for_member_access", true, "Prefer language types (e.g. int, string, float).", KnownMonikers.DotNET, "true", "false")},
            {new Keyword("dotnet_style_qualification_for_event", true, "Prefer this for events.", KnownMonikers.DotNET, "true", "false")},
            {new Keyword("dotnet_style_qualification_for_field", true, "Prefer this for fields.", KnownMonikers.DotNET, "true", "false")},
            {new Keyword("dotnet_style_qualification_for_method", true, "Prefer this for methods.", KnownMonikers.DotNET, "true", "false")},
            {new Keyword("dotnet_style_qualification_for_property", true, "Prefer this for properties.", KnownMonikers.DotNET, "true", "false")},
        };

        private Keyword(string name, bool isSupported, string description, ImageMoniker moniker, params string[] values)
        {
            Name = name;
            Description = description;
            Values = values;
            Moniker = moniker;
            IsSupported = isSupported;

            if (name.StartsWith("dotnet"))
                Tag = "dotnet";
            else if (name.StartsWith("csharp"))
                Tag = "csharp";
            else
                Tag = "standard";
        }

        public static IEnumerable<Keyword> AllItems
        {
            get { return _dic; }
        }

        public static Keyword GetCompletionItem(string name)
        {
            return _dic.SingleOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Values { get; set; }
        public bool IsSupported { get; set; }
        public ImageMoniker Moniker { get; set; }
        public string Tag { get; set; }
    }
}
