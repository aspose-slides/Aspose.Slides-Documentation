---
title: Render Presentations with Fallback Fonts in .NET
linktitle: Render Presentations
type: docs
weight: 30
url: /net/render-presentation-with-fallback-font/
keywords:
- fallback font
- render PowerPoint
- render presentation
- render slide
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Render presentations with fallback fonts in Aspose.Slides for .NET – keep text consistent across PPT, PPTX and ODP with step-by-step C# code samples."
---

## **Overview**

Aspose.Slides allows you to render presentations using fallback font rules. This article shows how to create a fallback font rules collection, modify its rules by removing or adding fallback fonts, and assign the collection to the `FontsManager.FontFallBackRulesCollection` property.

Once the fallback font rules collection is assigned to the presentation's `FontsManager`, the rules are applied during operations such as saving, rendering, and converting the presentation. The example demonstrates how to use the configured rules when rendering a slide thumbnail and saving it as a PNG image.

## **Render a Slide Using Fallback Font Rules**

The following example includes these steps:

1. We [create fallback font rules collection](/slides/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) a fallback font rule and [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) to another rule.
1. Set rules collection to [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) property.
1. With [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) method we can save presentation in the same format, or save it in another one. After fallback font rules collection is set to FontsManager, these rules are applied during any operations over the presentation: save, render, convert, etc.

```c#
// Create new instance of a rules collection
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Trying to remove FallBack font "Tahoma" from loaded rules
	fallBackRule.Remove("Tahoma");

	//And to update of rules for specified range
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

//Also we can remove any existing rules from list
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Assigning a prepared rules list for using
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Rendering of thumbnail with using of initialized rules collection and saving to PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


{{% alert color="primary" %}} 
Read more about [Save and Convertion in Presentation](/slides/net/convert-powerpoint-to-png/).
{{% /alert %}}
