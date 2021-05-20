---
title: Render Presentation with Fallback Font
type: docs
weight: 30
url: /net/render-presentation-with-fallback-font/
---

The following example includes these steps:

1. We [create fallback font rules collection](/slides/net/create-fallback-fonts-collection/).
1. [Remove()](https://apireference.aspose.com/net/slides/aspose.slides/fontfallbackrule/methods/remove) a fallback font rule and [AddFallBackFonts()](https://apireference.aspose.com/net/slides/aspose.slides/fontfallbackrule/methods/addfallbackfonts) to another rule.
1. Set rules collection to [FontsManager.FontFallBackRulesCollection](https://apireference.aspose.com/net/slides/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) property.
1. With [Presentation.Save()](https://apireference.aspose.com/net/slides/aspose.slides.presentation/save/methods/4) method we can save presentation in the same format, or save it in another one. After fallback font rules collection is set to FontsManager, these rules are applied during any operations over the presentation: save, render, convert, etc.

```c#

// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

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

using (Presentation pres = new Presentation(dataDir + "input.pptx"))
{
	//Assigning a prepared rules list for using
	pres.FontsManager.FontFallBackRulesCollection = rulesList;

	// Rendering of thumbnail with using of initialized rules collection and saving to PNG
	pres.Slides[0].GetThumbnail(1f, 1f).Save(dataDir + "Slide_0.png", ImageFormat.Png);
}
```


{{% alert color="primary" %}} 
Read more about [Save and Convertion in Presentation](/slides/net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}