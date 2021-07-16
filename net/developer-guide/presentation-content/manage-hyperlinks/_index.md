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

```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```



## **Remove Hyperlink from Presentation**
To remove hyperlinks from a presentation on the presentation level:

1. Create an instance of the Presentation class and access the desired presentation.
1. Remove the hyperlinks in the presentation on the presentation level by accessing [IPresentation.HyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/ipresentation/properties/hyperlinkqueries) and calling the [RemoveAllHyperlinks()](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks) method.
1. Apply a slide transition effect on a slide.
1. Write the modified presentation as a [PPTX](https://wiki.fileformat.com/presentation/pptx/) file.

```c#
// Instantiate Presentation class that represents a presentation file
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Apply circle type transition on slide 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Set the transition time of 3 seconds
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Apply comb type transition on slide 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Set the transition time of 5 seconds
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Apply zoom type transition on slide 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Set the transition time of 7 seconds
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Write the presentation to disk
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```



## **Set Hyperlink Color**
A new property [ColorSource](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/colorsource) has been added to [IHyperlink](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink) interface and Hyperlink class.

It allows to get or set the source of hyperlink color, which could be obtained either from slide/presentation styles or corresponding PortionFormat properties. This is a new feature of PowerPoint 2019 and any changes made to this property will take affect only in PowerPoint 2019 or higher versions.

The code snippet below shows a sample of adding two hyperlinks with different colors to the same slide:

```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```




## **Mutable Hyperlink**
[Hyperlink](https://apireference.aspose.com/net/slides/aspose.slides/hyperlink) class changed to be mutable. Now it is possible to change values of the following properties which were read-only before:

- [IHyperlink.TargetFrame](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/highlightclick)
- [IHyperlink.StopSoundOnClick](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/stopsoundonclick)

The code snippet below shows adding a hyperlink to the slide and editing its tooltip later:

```c#
using (Presentation presentation = new Presentation())
{
    
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.AddTextFrame("Aspose: File Format APIs");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```




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

