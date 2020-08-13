---
title: Aspose.Slides for Java 15.10.0 Release Notes
type: docs
weight: 100
url: /java/aspose-slides-for-java-15-10-0-release-notes/
---

## **Minor Changes**
Minor Changes

SLIDESNET-36651 - Animating chart series API
## **Other improments and changes**
Other improments and changes

Bug Fixes

SLIDESJAVA-35117 - Portion font changed on inserting portion

SLIDESJAVA-35114 - Incorrect TiffNotes generated from pptx

SLIDESJAVA-35112 - Shape Height gets changed in generated thumbnail

SLIDESJAVA-35110 - Generated tiff is blurred and image is missing

SLIDESJAVA-35096 - PptxReadException on ppt load in Solaris

SLIDESJAVA-35092 - Empty column is missing in generated PDF

SLIDESJAVA-35091 - Diagram missing on ppt to pdf

SLIDESJAVA-35090 - Incorrect text on ppt to html

SLIDESJAVA-35089 - Video frame picture set is in background with text No Image in foreground

SLIDESJAVA-35085 - Chart label font color changed on saving pptx

SLIDESJAVA-35074 - Image is improperly rendered in generated thumbnail

SLIDESJAVA-35065 - Image improperly rendered in generated thumbnail

SLIDESJAVA-35055 - Background missing in generated HTML

SLIDESJAVA-35050 - MP4 video not getting played in presentation when viewed in PowerPoint

SLIDESJAVA-35042 - Bullets are lost in generated html file

SLIDESJAVA-35036 - Images are improperly rendered on thumbnails

SLIDESJAVA-35026 - Numeric chart labels with + symbol corrupt presentation

SLIDESJAVA-35022 - Layouts are distorted

SLIDESJAVA-34997 - Text is getting cut for text frame in generated thumbnail

SLIDESJAVA-34446 - PptUnsupportedFormatException is thrown on exporting ODP to PDF

SLIDESJAVA-34330 - Aspose.Slides failed to load chart series fill if it is Automatic fill color

SLIDESJAVA-34114 - The bullet is improperly rendered in generated slide thumbnail

SLIDESJAVA-17014 - Resizing of embedded charts in PPT causes zooming problem
## **Public API Changes**
``` java

 Public API Changes

New VideoPlayerHtmlController added to support export od media files to HTML

Presentation pres = new Presentation("example.pptx");


try


{


final String path = "path";


final String fileName = "video.html";


final String baseUri = "http://www.example.com/";


VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);


HtmlOptions htmlOptions = new HtmlOptions(controller);


SVGOptions svgOptions = new SVGOptions(controller);


htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));


htmlOptions.setSlideImageFormat(SlideImageFormat.svg(svgOptions));


pres.save(path + fileName, SaveFormat.Html, htmlOptions);


} finally {


if(pres \!= null) pres.dispose();

Chart series animation API has been added

Presentation pres = new Presentation(inFileName);


try{


ISlide slide = pres.getSlides().get_Item(0);


IShapeCollection shapes = slide.getShapes();


IChart chart = (IChart) shapes.get_Item(0);


slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,


EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMajorGroupingType.BySeries, 0,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMajorGroupingType.BySeries, 1,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMajorGroupingType.BySeries, 2,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMajorGroupingType.BySeries, 3,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


pres.save(outFileName, SaveFormat.Pptx);


}finally{


if(pres \!= null) pres.dispose();


}

Presentation pres = new Presentation(inFileName);


try


{


ISlide slide = pres.getSlides().get_Item(0);


IShapeCollection shapes = slide.getShapes();


IChart chart = (IChart) shapes.get_Item(0);


slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,


EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMajorGroupingType.ByCategory, 0,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMajorGroupingType.ByCategory, 1,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMajorGroupingType.ByCategory, 2,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMajorGroupingType.ByCategory, 3,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


pres.save(outFileName, SaveFormat.Pptx);


} finally {


if(pres \!= null) pres.dispose();


}

Presentation pres = new Presentation(inFileName);


try


{


ISlide slide = pres.getSlides().get_Item(0);


IShapeCollection shapes = slide.getShapes();


IChart chart = (IChart) shapes.get_Item(0);


slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,


EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInSeries, 0, 0,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInSeries, 0, 1,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInSeries, 0, 2,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInSeries, 0, 3,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInSeries, 1, 0,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInSeries, 1, 1,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInSeries, 1, 2,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInSeries, 1, 3,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInSeries, 2, 0,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInSeries, 2, 1,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInSeries, 2, 2,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInSeries, 2, 3,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


pres.save(outFileName, SaveFormat.Pptx);


} finally {


if(pres \!= null) pres.dispose();


}

Presentation pres = new Presentation(inFileName);


try


{


ISlide slide = pres.getSlides().get_Item(0);


IShapeCollection shapes = slide.getShapes();


IChart chart = (IChart) shapes.get_Item(0);


slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,


EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInCategory, 0, 0,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInCategory, 0, 1,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInCategory, 0, 2,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInCategory, 0, 3,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInCategory, 1, 0,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInCategory, 1, 1,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInCategory, 1, 2,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInCategory, 1, 3,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInCategory, 2, 0,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInCategory, 2, 1,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInCategory, 2, 2,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,


EffectChartMinorGroupingType.ByElementInCategory, 2, 3,


EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);


pres.save(outFileName, SaveFormat.Pptx);


} finally {


if(pres \!= null) pres.dispose();


}

```
