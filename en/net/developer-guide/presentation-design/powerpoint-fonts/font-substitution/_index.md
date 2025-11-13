---
title: Configure Font Substitution in Presentations in .NET
linktitle: Font Substitution
type: docs
weight: 70
url: /net/font-substitution/
keywords:
- font
- substitute font
- font substitution
- replace font
- font replacement
- substitution rule
- replacement rule
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Enable optimal font substitution in Aspose.Slides for .NET when converting PowerPoint & OpenDocument presentations to other file formats."
---

## **Getting Font Substitution**

To allow you find out the presentation fonts that are substituted during a presentation rendering process, Aspose.Slides provides the [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) method from the [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) interface.

The C# code shows you how to get all the font substitutions that are performed when a presentation is rendered:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **Setting Font Substitution Rules**

Aspose.Slides allows you to set rules for fonts that determines what must be done in certain conditions (for example, when a font cannot be accessed) this way:

1. Load the relevant presentation.
2. Load the font that will be replaced.
3. Load the new font.
4. Add a rule for the replacement.
5. Add the rule to the presentation font replacement rule collection.
6. Generate the slide image to observe the effect.

This C# code demonstrates the font substitution process:

```c#
// Loads a presentation
Presentation presentation = new Presentation("Fonts.pptx");

// Loads the source font that will be replaced
IFontData sourceFont = new FontData("SomeRareFont");

// Loads the new font
IFontData destFont = new FontData("Arial");

// Adds a font rule for font replacement
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Adds the rule to font substitute rules collection
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Adds the font rule collection to the rule list
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Saves the image to disk in the JPEG format
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

You may want to see [**Font Replacement**](/slides/net/font-replacement/). 

{{% /alert %}}

## **FAQ**

**What is the difference between font replacement and font substitution?**

[Replacement](/slides/net/font-replacement/) is a forced override of one font with another across the entire presentation. Substitution is a rule that triggers under a specific condition, for example when the original font is unavailable, and then a designated fallback font is used.

**When exactly are substitution rules applied?**

The rules participate in the standard [font selection](/slides/net/font-selection-sequence/) sequence that is evaluated during loading, rendering, and conversion; if the chosen font is unavailable, replacement or substitution is applied.

**What is the default behavior if neither replacement nor substitution is configured and the font is missing on the system?**

The library will try to pick the closest available system font, similar to how PowerPoint would behave.

**Can I attach custom external fonts at runtime to avoid substitution?**

Yes. You can [add external fonts](/slides/net/custom-font/) at runtime so the library considers them for selection and rendering, including for subsequent conversions.

**Does Aspose distribute any fonts with the library?**

No. Aspose does not distribute paid or free fonts; you add and use fonts at your own discretion and responsibility.

**Are there differences in substitution behavior on Windows, Linux, and macOS?**

Yes. Font discovery starts from the operating system’s font directories. The set of default available fonts and the search paths differ across platforms, which affects availability and the need for substitution.

**How should I prepare the environment to minimize unexpected substitution during batch conversions?**

Synchronize the font set across machines or containers, [add the external fonts](/slides/net/custom-font/) required for the output documents, and [embed fonts](/slides/net/embedded-font/) in presentations when possible so the chosen fonts are available during rendering.
