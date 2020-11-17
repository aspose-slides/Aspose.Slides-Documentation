---
title: Manage Hyperlinks
type: docs
weight: 70
url: /net/manage-hyperlinks/
---


## **Add Hyperlink in Presentation**
To add a hyperlink in a presentation on the presentation level:

1. Create an instance of the Presentation class and access the desired presentation.
1. Add an AutoShape of Rectangle type using [AddAutoShape](https://apireference.aspose.com/net/slides/aspose.slides/shapecollection/methods/addautoshape) method exposed by Shapes object.
1. Add hyperlink.
1. Save the presentation as a PPTX file.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Slides-Hyperlinks-AddHyperlink-AddHyperlink.cs" >}}

## **Remove Hyperlink from Presentation**
To remove hyperlinks from a presentation on the presentation level:

1. Create an instance of the Presentation class and access the desired presentation.
1. Remove the hyperlinks in the presentation on the presentation level by accessing [IPresentation.HyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/ipresentation/properties/hyperlinkqueries) and calling the [RemoveAllHyperlinks()](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks) method.
1. Apply a slide transition effect on a slide.
1. Write the modified presentation as a [PPTX](https://wiki.fileformat.com/presentation/pptx/) file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Transitions-BetterSlideTransitions-BetterSlideTransitions.cs" >}}

## **Set Hyperlink Color**
A new property [ColorSource](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/colorsource) has been added to [IHyperlink](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink) interface and Hyperlink class.

It allows to get or set the source of hyperlink color, which could be obtained either from slide/presentation styles or corresponding PortionFormat properties. This is a new feature of PowerPoint 2019 and any changes made to this property will take affect only in PowerPoint 2019 or higher versions.

The code snippet below shows a sample of adding two hyperlinks with different colors to the same slide:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Slides-Hyperlinks-SetHyperLinkColor-SetHyperLinkColor.cs" >}}


## **Mutable Hyperlink**
[Hyperlink](https://apireference.aspose.com/net/slides/aspose.slides/hyperlink) class changed to be mutable. Now it is possible to change values of the following properties which were read-only before:

- [IHyperlink.TargetFrame](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/highlightclick)
- [IHyperlink.StopSoundOnClick](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/stopsoundonclick)

The code snippet below shows adding a hyperlink to the slide and editing its tooltip later:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Slides-Hyperlinks-MutableHyperlink-MutableHyperlink.cs" >}}


## **Supported Properties in IHyperlinkQueries**
The IHyperlinkQueries class can be accessed from the presentation, slide and text frame that the hyperlink is defined for.

- [IPresentation.HyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/itextframe/properties/hyperlinkqueries)

The IHyperlinkQueries class supports the following methods and properties.

- [IHyperlinkQueries.GetHyperlinkClicks();](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

