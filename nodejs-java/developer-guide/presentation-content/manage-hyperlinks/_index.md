---
title: Manage Hyperlinks
type: docs
weight: 20
url: /nodejs-java/manage-hyperlinks/
keywords: "PowerPoint Hyperlink, text hyperlink, slide hyperlink, shape hyperlink, image hyperlink, video hyperlink, Java"
description: "How to add hyperlink to a PowerPoint Presentation in Javascript"
---

A hyperlink is a reference to an object or data or a place in something. These are common hyperlinks in PowerPoint Presentations:

* Links to websites inside texts, shapes, or media
* Links to slides

Aspose.Slides for Node.js via Java allows you to perform many tasks involving hyperlinks in presentations.

{{% alert color="primary" %}} 

You may want to check out Aspose simple, [free online PowerPoint editor.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Adding URL Hyperlinks**

### **Adding URL Hyperlinks to Texts**

This Javascript code shows you how to add a website hyperlink to a text:

```javascript
    var presentation = new  aspose.slides.Presentation();
    try {
        var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
        shape1.addTextFrame("Aspose: File Format APIs");
        var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        portionFormat.setHyperlinkClick(new  aspose.slides.Hyperlink("https://www.aspose.com/"));
        portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
        portionFormat.setFontHeight(32);
        presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
```

### **Adding URL Hyperlinks to Shapes or Frames**

This sample code in Java shows you how to add a website hyperlink to a shape:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
        shape.setHyperlinkClick(new  aspose.slides.Hyperlink("https://www.aspose.com/"));
        shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
        pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

### **Adding URL Hyperlinks to Media**

Aspose.Slides allows you to add hyperlinks to images, audio, and video files. 

This sample code shows you how to add a hyperlink to an **image**:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        // Adds image to presentation
        var picture;
        var image = aspose.slides.Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(picture);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        // Creates picture frame on slide 1 based on previously added image
        var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
        pictureFrame.setHyperlinkClick(new  aspose.slides.Hyperlink("https://www.aspose.com/"));
        pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
        pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (e) {console.log(e);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

This sample code shows you how to add a hyperlink to an **audio file**:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var audio = pres.getAudios().addAudio(java.callStaticMethodSync("java.nio.file.Files", "readAllBytes", java.callStaticMethodSync("java.nio.file.Paths", "get", "audio.mp3")));
        var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
        audioFrame.setHyperlinkClick(new  aspose.slides.Hyperlink("https://www.aspose.com/"));
        audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
        pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (e) {console.log(e);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

This sample code shows you how to add a hyperlink to a **video**:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var video = pres.getVideos().addVideo(java.callStaticMethodSync("java.nio.file.Files", "readAllBytes", java.callStaticMethodSync("java.nio.file.Paths", "get", "video.avi")));
        var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
        videoFrame.setHyperlinkClick(new  aspose.slides.Hyperlink("https://www.aspose.com/"));
        videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
        pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (e) {console.log(e);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

{{%  alert  title="Tip"  color="primary"  %}} 

You may want to see *[Manage OLE](/slides/nodejs-java/manage-ole/)*.

{{% /alert %}}

## **Using Hyperlinks to Create Table of Contents**

Since hyperlinks allow you to add references to objects or places, you can use them to create a table of contents. 

This sample code shows you how to create a table of contents with hyperlinks:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var firstSlide = pres.getSlides().get_Item(0);
        var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
        var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
        contentTable.getFillFormat().setFillType(aspose.slides.FillType.NoFill);
        contentTable.getLineFormat().getFillFormat().setFillType(aspose.slides.FillType.NoFill);
        contentTable.getTextFrame().getParagraphs().clear();
        var paragraph = new  aspose.slides.Paragraph();
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        paragraph.setText("Title of slide 2 .......... ");
        var linkPortion = new  aspose.slides.Portion();
        linkPortion.setText("Page 2");
        linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
        paragraph.getPortions().add(linkPortion);
        contentTable.getTextFrame().getParagraphs().add(paragraph);
        pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Formatting Hyperlinks**

### **Color**

With the [ColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) property in the [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IHyperlink) interface, you can set the color for hyperlinks and also get the color information from hyperlinks. The feature was first introduced in PowerPoint 2019, so changes involving the property do not apply to older PowerPoint versions.

This sample code demonstrates an operation where hyperlinks with different colors got added to the same slide:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
        shape1.addTextFrame("This is a sample of colored hyperlink.");
        var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        portionFormat.setHyperlinkClick(new  aspose.slides.Hyperlink("https://www.aspose.com/"));
        portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
        portionFormat.getFillFormat().setFillType(aspose.slides.FillType.Solid);
        portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
        var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
        shape2.addTextFrame("This is a sample of usual hyperlink.");
        shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new  aspose.slides.Hyperlink("https://www.aspose.com/"));
        pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Removing Hyperlinks in Presentations**

### **Removing Hyperlinks from Texts**

This Javascript code shows you how to remove the hyperlink from a text in a presentation slide:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var slide = pres.getSlides().get_Item(0);
        slide.getShapes().forEach(function(shape) {
            var autoShape = shape;
            if (autoShape != null) {
                autoShape.getTextFrame().getParagraphs().forEach(function(paragraph) {
                    paragraph.getPortions().forEach(function(portion) {
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
                    });
                });
            }
        });
        pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

### **Removing Hyperlinks from Shapes or Frames**

This Javascript code shows you how to remove the hyperlink from a shape in a presentation slide:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var slide = pres.getSlides().get_Item(0);
        slide.getShapes().forEach(function(shape) {
            shape.getHyperlinkManager().removeHyperlinkClick();
        });
        pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Mutable Hyperlink**

The [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) class is mutable. With this class, you can change the values for these properties:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IHyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

The code snippet shows you how to add a hyperlink to a slide and edit its tooltip later:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
        shape1.addTextFrame("Aspose: File Format APIs");
        var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        portionFormat.setHyperlinkClick(new  aspose.slides.Hyperlink("https://www.aspose.com/"));
        portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
        portionFormat.setFontHeight(32);
        pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Supported Properties in IHyperlinkQueries**

You can access [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IHyperlinkQueries) from a presentation, slide, or text for which the hyperlink is defined.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IPresentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ITextFrame#getHyperlinkQueries--)

The [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IHyperlinkQueries) class supports these methods and properties:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

