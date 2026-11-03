using System;
using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(Seed("control"));
        var slide = presentation.Slides[0];

        // The seed presentation contains one control with a known Value property.
        var controls = slide.Controls;
        var control = controls[0];
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");

        VerifyCase02(presentation);
    }
}
