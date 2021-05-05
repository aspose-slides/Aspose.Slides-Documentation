---
title: Manage Hyperlinks
type: docs
weight: 70
url: /java/manage-hyperlinks/
---

{{% alert color="primary" %}} 

Aspose.Slides for Java allows developers to manage the hyperlinks in a presentation on the presentation, slide and text frame level. This topic discusses clearing the hyperlinks associated with a presentation on the presentation level. The [IHyperlinkQueries](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlinkQueries) class helps to manage hyperlinks in a presentation.

{{% /alert %}} 

## **Add Hyperlink in Presentation**
To add a hyperlink in a presentation on the presentation level:

1. Create an instance of the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class and access the desired presentation.
1. Add an AutoShape of Rectangle type using [**addAutoShape**](https://apireference.aspose.com/java/slides/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)** **method exposed by Shapes object.
1. Add hyperlink.
1. Save the presentation as a [PPTX ](https://wiki.fileformat.com/presentation/pptx/)file.

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkClick().setTooltip( "More than 70% Fortune 100 companies trust Aspose APIs");
    shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(32);

    pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remove Hyperlink from Presentation**
To remove hyperlinks from a presentation on the presentation level:

1. Create an instance of the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class and access the desired presentation.
1. Remove the hyperlinks in the presentation on the presentation level by accessing [IPresentation.getHyperlinkQueries()](https://apireference.aspose.com/java/slides/com.aspose.slides/IPresentation#getHyperlinkQueries--) and calling the [removeAllHyperlinks()](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--) method.
1. Apply a slide transition effect on a slide.
1. Write the modified presentation as a [PPTX](https://wiki.fileformat.com/presentation/pptx/) file.

```java
//Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation("PresentationWithHyperlinks.pptx");
try {
    //Removing the Hyperlinks from presentation
    pres.getHyperlinkQueries().removeAllHyperlinks();
    
    //Writing the presentation as a PPTX file
    pres.save("TestSaved.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Hyperlink Color**
New methods [**getColorSource**](https://apireference.aspose.com/java/slides/com.aspose.slides/Hyperlink#getColorSource--) and [**setColorSource**](https://apireference.aspose.com/java/slides/com.aspose.slides/Hyperlink#setColorSource-int-) have been added to [**IHyperlink**](https://apireference.aspose.com/java/slides/com.aspose.slides/Hyperlink) interface and [**Hyperlink**](https://apireference.aspose.com/java/slides/com.aspose.slides/Hyperlink) class.

It allows to get or set the source of hyperlink color, which could be obtained either from slide/presentation styles or corresponding PortionFormat properties. This is a new feature of PowerPoint 2019 and any changes made to this property will take effect only in PowerPoint 2019 or higher versions.

The code snippet below shows a sample of adding two hyperlinks with different colors to the same slide:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(FillType.Solid);
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);

    IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mutable Hyperlink**
Hyperlink class changed to be mutable. Now it is possible to change values of the following properties which were read-only before:

- [IHyperlink.setTargetFrame(String value)](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

The code snippet below shows adding a hyperlink to the slide and editing its tooltip later:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);

    pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supported Methods in IHyperlinkQueries**
The [IHyperlinkQueries](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlinkQueries) class can be accessed from the presentation, slide and text frame that the hyperlink is defined for.

- [IPresentation.getHyperlinkQueries()](https://apireference.aspose.com/java/slides/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://apireference.aspose.com/java/slides/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://apireference.aspose.com/java/slides/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

The [IHyperlinkQueries](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlinkQueries) class supports the following methods and properties.

- [IHyperlinkQueries.getHyperlinkClicks()](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://apireference.aspose.com/java/slides/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)


