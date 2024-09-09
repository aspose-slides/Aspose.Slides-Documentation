---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 15.10.0
type: docs
weight: 180
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/) or [removed](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for Java 15.10.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **Chart series animation API has been added to ISequence**
The new 2 methods have been added to com.aspose.slides.ISequence interface.

```javascript
```

These methods are intended to support the chart's elements animations:

by series
by categories
by series elements
by categories elements

The two new enums EffectChartMajorGroupingType and EffectChartMinorGroupingType related to the chart's elements animation were introduced.

To add a series animation to the chart the following code may be used:

```javascript
    var pres = new  com.aspose.slides.Presentation(inFileName);
    try {
        var slide = pres.getSlides().get_Item(0);
        var shapes = slide.getShapes();
        var chart = shapes.get_Item(0);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectType.Fade, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMajorGroupingType.BySeries, 0, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMajorGroupingType.BySeries, 1, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMajorGroupingType.BySeries, 2, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMajorGroupingType.BySeries, 3, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        pres.save(outFileName, com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

Categories animation:

```javascript
    var pres = new  com.aspose.slides.Presentation(inFileName);
    try {
        var slide = pres.getSlides().get_Item(0);
        var shapes = slide.getShapes();
        var chart = shapes.get_Item(0);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectType.Fade, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMajorGroupingType.ByCategory, 0, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMajorGroupingType.ByCategory, 1, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMajorGroupingType.ByCategory, 2, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMajorGroupingType.ByCategory, 3, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        pres.save(outFileName, com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

Series elements animation:

```javascript
    var pres = new  com.aspose.slides.Presentation(inFileName);
    try {
        var slide = pres.getSlides().get_Item(0);
        var shapes = slide.getShapes();
        var chart = shapes.get_Item(0);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectType.Fade, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 0, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 1, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 2, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 3, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 0, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 1, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 2, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 3, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 0, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 1, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 2, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 3, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        pres.save(outFileName, com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

Categories elements animation:

```javascript
    var pres = new  com.aspose.slides.Presentation(inFileName);
    try {
        var slide = pres.getSlides().get_Item(0);
        var shapes = slide.getShapes();
        var chart = shapes.get_Item(0);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectType.Fade, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 0, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 1, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 2, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 3, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 0, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 1, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 2, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 3, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 0, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 1, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 2, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        slide.getTimeline().getMainSequence().addEffect(chart, com.aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 3, com.aspose.slides.EffectType.Appear, com.aspose.slides.EffectSubtype.None, com.aspose.slides.EffectTriggerType.AfterPrevious);
        pres.save(outFileName, com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
#### **New com.aspose.slides.VideoPlayerHtmlController added to support export od media files to HTML**
The new public class com.aspose.slides.VideoPlayerHtmlController has been added. Using the instance of this class user can export video and audio files into HTML.

VideoPlayerHtmlController contructors accepts the following parameters:

path: The path where video and audio files will be generated
fileName: The name of the HTML file
baseUri: The base URI which will be used to generate links

Usage example:

```javascript
    var pres = new  com.aspose.slides.Presentation("example.pptx");
    try {
        final var path = "path";
        final var fileName = "video.html";
        final var baseUri = "http://www.example.com/";
        var controller = new  com.aspose.slides.VideoPlayerHtmlController(path, fileName, baseUri);
        var htmlOptions = new  com.aspose.slides.HtmlOptions(controller);
        var svgOptions = new  com.aspose.slides.SVGOptions(controller);
        htmlOptions.setHtmlFormatter(com.aspose.slides.HtmlFormatter.createCustomFormatter(controller));
        htmlOptions.setSlideImageFormat(com.aspose.slides.SlideImageFormat.svg(svgOptions));
        pres.save(path + fileName, com.aspose.slides.SaveFormat.Html, htmlOptions);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
