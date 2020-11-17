---
title: Create Fallback Fonts Collection
type: docs
weight: 20
url: /net/create-fallback-fonts-collection/
---

Instances of [FontFallBackRule](https://apireference.aspose.com/net/slides/aspose.slides/FontFallBackRule) class can be organized into [FontFallBackRulesCollection](https://apireference.aspose.com/net/slides/aspose.slides/fontfallbackrulescollection), that implements [IFontFallBackRulesCollection](https://apireference.aspose.com/net/slides/aspose.slides/ifontfallbackrulescollection) interface. It is possible to add or remove rules from the collection.

Then this collection may be assigned to [FontFallBackRulesCollection ](https://apireference.aspose.com/net/slides/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)property of the [FontsManager](https://apireference.aspose.com/net/slides/aspose.slides/fontsmanager) class. FontsManager controls fonts across the presentation. Read more [About FontsManager and FontsLoader](/slides/net/about-fontsmanager-and-fontsloader/).

Each [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)has a [FontsManager ](https://apireference.aspose.com/net/slides/aspose.slides/presentation/properties/fontsmanager)property with its own instance of the FontsManager class.

Here is an examples how to create fallback fonts rules collection and assign in into the FontsManager of a certain presentation:  



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Text-FallBackRulesCollection-FallBackRulesCollection.cs" >}}



After FontsManager is initialised with fallback fonts collection, the fallback fonts are applied during presentation rendering.

{{% alert color="primary" %}} 
Read more how to [Render Presentation with Fallback Font](/slides/net/render-presentation-with-fallback-font/).
{{% /alert %}}