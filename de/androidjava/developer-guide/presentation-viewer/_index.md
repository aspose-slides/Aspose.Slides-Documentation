---
title: Präsentationsviewer
type: docs
weight: 50
url: /androidjava/presentation-viewer/
keywords: "PowerPoint PPT Viewer"
description: "PowerPoint PPT Viewer in Java"
---

{{% alert color="primary" %}} 

Aspose.Slides für Android über Java wird verwendet, um Präsentationsdateien zu erstellen, die Folien enthalten. Diese Folien können durch Öffnen von Präsentationen mit Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch Folien auch als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder ihren eigenen Präsentationsviewer erstellen. In solchen Fällen ermöglicht es Aspose.Slides für Android über Java, eine einzelne Folie als Bild zu exportieren. Dieser Artikel beschreibt, wie das geht.

{{% /alert %}} 

## **Live-Beispiel**
Sie können die kostenlose [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) App ausprobieren, um zu sehen, was Sie mit der Aspose.Slides API umsetzen können:

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **SVG-Bild aus Folie generieren**
Um ein SVG-Bild aus einer gewünschten Folie mit Aspose.Slides für Android über Java zu generieren, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
- Erhalten Sie den Verweis auf die gewünschte Folie, indem Sie ihre ID oder ihren Index verwenden.
- Holen Sie das SVG-Bild in einem Speicherstream.
- Speichern Sie den Speicherstream in einer Datei.

```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("CreateSlidesSVGImage.pptx");
try {
    // Greifen Sie auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Erstellen Sie ein Speicherstream-Objekt
    FileOutputStream svgStream = new FileOutputStream("Aspose_out.svg");

    // Generieren Sie das SVG-Bild der Folie und speichern Sie es im Speicherstream
    sld.writeAsSvg(svgStream);

    svgStream.close();
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **SVG mit benutzerdefinierten Shape-IDs generieren**
Aspose.Slides für Android über Java kann verwendet werden, um [SVG](https://docs.fileformat.com/page-description-language/svg/) von Folien mit benutzerdefinierten Shape-IDs zu generieren. Dazu verwenden Sie die ID-Eigenschaft von [ISvgShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgShape), die die benutzerdefinierte ID von Formen im generierten SVG darstellt. Der CustomSvgShapeFormattingController kann verwendet werden, um die Shape-ID festzulegen.

```java
Presentation pres = new Presentation("pptxFileName.pptx");
try {
    FileOutputStream stream = new FileOutputStream("Aspose_out.svg");
    try {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

        pres.getSlides().get_Item(0).writeAsSvg(stream, svgOptions);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    pres.dispose();
}
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }
    
    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Vorschaubilder von Folien erstellen**
Aspose.Slides für Android über Java hilft Ihnen, Vorschaubilder von Folien zu generieren. Um das Vorschaubild einer gewünschten Folie mit Aspose.Slides für Android über Java zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Holen Sie sich den Verweis auf eine gewünschte Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie sich das Vorschaubild der referenzierten Folie in einem bestimmten Maßstab.
1. Speichern Sie das Vorschaubild in einem gewünschten Bildformat.

```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("ThumbnailFromSlide.pptx");
try {
    // Greifen Sie auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Erstellen Sie ein Fullscale-Bild
    IImage slideImage = sld.getImage(1f, 1f);

    // Speichern Sie das Bild auf der Festplatte im JPEG-Format
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **Vorschaubild mit benutzerdefinierten Abmessungen erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Holen Sie sich den Verweis auf eine gewünschte Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie sich das Vorschaubild der referenzierten Folie in einem bestimmten Maßstab.
1. Speichern Sie das Vorschaubild in einem gewünschten Bildformat.

```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Greifen Sie auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Benutzerdefinierte Dimension
    int desiredX = 1200;
    int desiredY = 800;

    // Erhalten Sie den skalierten Wert von X und Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;
    
    // Erstellen Sie ein Fullscale-Bild
    IImage slideImage = sld.getImage(ScaleX, ScaleY);

    // Speichern Sie das Bild auf der Festplatte im JPEG-Format
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **Vorschaubild aus Folien im Notizfolienansicht erstellen**
Um das Vorschaubild einer gewünschten Folie in der Notizfolienansicht mit Aspose.Slides für Android über Java zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Holen Sie sich den Verweis auf eine gewünschte Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie sich das Vorschaubild der referenzierten Folie in einem bestimmten Maßstab in der Notizfolienansicht.
1. Speichern Sie das Vorschaubild in einem gewünschten Bildformat.

Der folgende Codeausschnitt erzeugt ein Vorschaubild der ersten Folie einer Präsentation in der Notizfolienansicht.

```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Greifen Sie auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Benutzerdefinierte Dimension
    int desiredX = 1200;
    int desiredY = 800;

    // Erhalten Sie den skalierten Wert von X und Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    RenderingOptions opts = new RenderingOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);
    
    // Erstellen Sie ein Fullscale-Bild
    IImage slideImage = sld.getImage(opts, ScaleX, ScaleY);

    // Speichern Sie das Bild auf der Festplatte im JPEG-Format
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```