---
title: Create Fallback Fonts Collection
type: docs
weight: 20
url: /net/create-fallback-fonts-collection/
keywords: "Fallback fonts collection, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Fallback fonts collection in PowerPoint in C# or .NET"
---

Instances of [FontFallBackRule](https://apireference.aspose.com/net/slides/aspose.slides/FontFallBackRule) class can be organized into [FontFallBackRulesCollection](https://apireference.aspose.com/net/slides/aspose.slides/fontfallbackrulescollection), that implements [IFontFallBackRulesCollection](https://apireference.aspose.com/net/slides/aspose.slides/ifontfallbackrulescollection) interface. It is possible to add or remove rules from the collection.

Then this collection may be assigned to [FontFallBackRulesCollection ](https://apireference.aspose.com/net/slides/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)property of the [FontsManager](https://apireference.aspose.com/net/slides/aspose.slides/fontsmanager) class. FontsManager controls fonts across the presentation. Read more [About FontsManager and FontsLoader](/slides/net/about-fontsmanager-and-fontsloader/).

Each [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)has a [FontsManager ](https://apireference.aspose.com/net/slides/aspose.slides/presentation/properties/fontsmanager)property with its own instance of the FontsManager class.

Here is an examples how to create fallback fonts rules collection and assign in into the FontsManager of a certain presentation:  

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

After FontsManager is initialised with fallback fonts collection, the fallback fonts are applied during presentation rendering.

{{% alert color="primary" %}} 
Read more how to [Render Presentation with Fallback Font](/slides/net/render-presentation-with-fallback-font/).
{{% /alert %}}

