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

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Text-RenderingWithFallBackFont-RenderingWithFallBackFont.cs" >}}


{{% alert color="primary" %}} 
Read more about [Save and Convertion in Presentation](/slides/net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}