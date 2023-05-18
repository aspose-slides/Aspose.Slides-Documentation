---
title: Aspose.Slides for .NET 23.5 Release Notes
type: docs
weight: 40
url: /net/aspose-slides-for-net-23-5-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [ Aspose.Slides for .NET 23.5](https://www.nuget.org/packages/Aspose.Slides.NET/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|**Related Documentation**|
| :- | :- | :- | :- |
|SLIDESNET-43703|Retrieving Effect/Enhancements/After animation settings|Feature|<https://docs.aspose.com/slides/net/shape-animation/>
|SLIDESNET-43310|Changing color of leader lines in Pie charts|Feature|<https://docs.aspose.com/slides/net/powerpoint-charts/>
|SLIDESNET-43975|Change in behavior when aspect ratio lock is set for PictureFrame|Bug|<https://docs.aspose.com/slides/net/picture-frame/>
|SLIDESNET-43948|PPTX to PNG: Math equations inconsistent in output PNG|Bug|<https://docs.aspose.com/slides/net/convert-slide/#converting-slides-to-bitmap-and-saving-the-images-in-png>
|SLIDESNET-43940|Setting a default language does not work for slide notes|Bug|<https://docs.aspose.com/slides/net/presentation-localization/>
|SLIDESNET-43907|The value of "Hide During Show" option from AudioFrame is wrong|Bug|<https://docs.aspose.com/slides/net/audio-frame/#change-audio-play-options>
|SLIDESNET-43898|Loading PPTX files throws PptxReadException|Bug|<https://docs.aspose.com/slides/net/open-presentation/>
|SLIDESNET-43865|Problem with trignometric and calculus equations in PPTX to PNG conversion|Bug|<https://docs.aspose.com/slides/net/convert-slide/#converting-slides-to-bitmap-and-saving-the-images-in-png>
|SLIDESNET-43863|Overlap of content on PPTX to PNG conversion|Bug|<https://docs.aspose.com/slides/net/convert-slide/#converting-slides-to-bitmap-and-saving-the-images-in-png>
|SLIDESNET-43851|Text is not displayed when adding SVG image to a presentation|Bug|<https://docs.aspose.com/slides/net/image/#adding-svg-to-presentations>
|SLIDESNET-43850|Hyperlinks do not work when converting PPTX to PDF|Bug|< https://docs.aspose.com/slides/net/conversion-to-pdf/>
|SLIDESNET-43849|Hyperlink does not work when converting PPTX to PDF|Bug|<https://docs.aspose.com/slides/net/conversion-to-pdf/>
|SLIDESNET-43841|FormatException is thrown when adding SVG image to group shape|Bug|<https://docs.aspose.com/slides/net/image/#converting-svg-to-a-set-of-shapes>
|SLIDESNET-43768|PPTX to PNG: Text Shadows on group items not rendered correctly|Bug|<https://docs.aspose.com/slides/net/convert-slide/#converting-slides-to-bitmap-and-saving-the-images-in-png>
|SLIDESNET-43557|A chart is not rendered correctly when converting PPTX to PDF|Bug|<https://docs.aspose.com/slides/net/powerpoint-charts>
|SLIDESNET-43478|Axis labels are displayed incorrectly for Bar chart when converting - improve SLIDESNET-43308 (PDF export)SLIDESNET-43308|Bug|<https://docs.aspose.com/slides/net/powerpoint-charts>
|SLIDESNET-43305|Multi-type (combo) charts are displayed differently when converting PPTX to PDF|Bug|<https://docs.aspose.com/slides/net/powerpoint-charts/>
|SLIDESNET-43164|EffectiveData is lost for Portion object if a change is made to the previous one|Bug|<https://docs.aspose.com/slides/net/shape-effective-properties/>

## Public API Changes ##

## AfterAnimationType enum, Effect.AfterAnimationType and Effect.AfterAnimationColor has been added ##

A new AfterAnimationType enum has been added. It represents the after animation type of an animation effect and can be used with Effect.AfterAnimationType and Effect.AfterAnimationColor:

``` csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Get the first effect of the first slide.
    IEffect firstSlideEffect = presentation.Slides[0].Timeline.MainSequence[0];
    
    // Change the effect After animation to "Hide on Next Mouse Click"
    firstSlideEffect.AfterAnimationType = AfterAnimationType.HideOnNextClick;
}
```

Example how to use Effect.AfterAnimationColor combined with AfterAnimationType 

``` csharp 
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Get the first effect of the first slide.
    IEffect firstSlideEffect = presentation.Slides[0].Timeline.MainSequence[0];

    // Change the effect After animation type to "Color"
    firstSlideEffect.AfterAnimationType = AfterAnimationType.Color;

    // Set the effect After animation color.
    firstSlideEffect.AfterAnimationColor.Color = Color.Blue;
}
```

## DataLabelCollection.LeaderLinesFormat has been added, DataLabelCollection.LeaderLinesColor declared as obsollete ##

To allow format the chart's leader lines a new property LeaderLinesFormat has been added to DataLabelCollection. This is how it can be formatted:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    IChart chart = (IChart) pres.Slides[0].Shapes[0];
    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabelCollection labels = series[0].Labels;
        ///
    labels.LeaderLinesFormat.Line.FillFormat.FillType = FillType.Solid;
    labels.LeaderLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 255, 0, 0);
}
```

DataLabelCollection.LeaderLinesColor declared as obsollete and will be removed after release of version 23.8.

## LowCode.ForEach for shape, paragraph and portion now support include notes ##

LowCode.ForEach for shape, paragraph and portion now suppor overrides to include notes. That is represented as a boolean flag that indicates whether NotesSlides should be included in processing.

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    ForEach.Portion(pres, true, (portion, para, slide, index) =>
    {
        System.Console.WriteLine($"{portion.Text}, index: {index}");
    });
} 
```