---
title: Präsentationsansicht
type: docs
weight: 50
url: /de/java/presentation-viewer/
keywords: "PowerPoint PPT Viewer"
description: "PowerPoint PPT Viewer in Java"
---

{{% alert color="primary" %}} 

Aspose.Slides für Java wird verwendet, um Präsentationsdateien zu erstellen, die Folien enthalten. Diese Folien können angezeigt werden, indem Präsentationen mit Microsoft PowerPoint geöffnet werden. Aber manchmal müssen Entwickler Folien möglicherweise auch als Bilder in ihrem bevorzugten Bildbetrachter ansehen oder ihren eigenen Präsentationsbetrachter erstellen. In solchen Fällen ermöglicht es Aspose.Slides für Java, eine einzelne Folie als Bild zu exportieren. Dieser Artikel beschreibt, wie dies gemacht wird.

{{% /alert %}} 

## **Live-Beispiel**
Sie können die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) ausprobieren, um zu sehen, was Sie mit der Aspose.Slides API umsetzen können:

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **SVG-Bild aus Folie erstellen**
Um mit Aspose.Slides für Java ein SVG-Bild aus einer gewünschten Folie zu generieren, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Erhalten Sie die Referenz der gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
- Holen Sie das SVG-Bild in einem Speicherstream.
- Speichern Sie den Speicherstream in einer Datei.

```java
// Instanziieren Sie eine Präsentationsklasse, die die Präsentationsdatei darstellt
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

## **SVG mit benutzerdefinierten Form-IDs erstellen**
Aspose.Slides für Java kann verwendet werden, um [SVG](https://docs.fileformat.com/page-description-language/svg/) aus Folien mit benutzerdefinierten Form-IDs zu generieren. Hierfür verwenden Sie die ID-Eigenschaft von [ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgShape), die die benutzerdefinierte ID von Formen im generierten SVG darstellt. Der CustomSvgShapeFormattingController kann verwendet werden, um die Form-ID festzulegen.

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

## **Thumbnail-Bild aus Folien erstellen**
Aspose.Slides für Java hilft Ihnen, Thumbnail-Bilder der Folien zu generieren. Um das Thumbnail einer gewünschten Folie mit Aspose.Slides für Java zu erstellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie das Thumbnail-Bild der referenzierten Folie in einem bestimmten Maßstab.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

```java
// Instanziieren Sie eine Präsentationsklasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("ThumbnailFromSlide.pptx");
try {
    // Greifen Sie auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Erstellen Sie ein Vollbildbild
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

## **Thumbnail mit benutzerd definierten Abmessungen erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie das Thumbnail-Bild der referenzierten Folie in einem bestimmten Maßstab.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

```java
// Instanziieren Sie eine Präsentationsklasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Greifen Sie auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Benutzerdefinierte Dimension
    int desiredX = 1200;
    int desiredY = 800;

    // Berechnen Sie den skalierenden Wert von X und Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;
    
    // Erstellen Sie ein Vollbildbild
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

## **Thumbnail aus Folie im Ansichtsmodus für Notizen erstellen**
Um das Thumbnail einer gewünschten Folie im Notizenansichtsmodus mit Aspose.Slides für Java zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie das Thumbnail-Bild der referenzierten Folie in einem bestimmten Maßstab im Notizenansichtsmodus.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

Der folgende Code erzeugt ein Thumbnail der ersten Folie einer Präsentation im Notizenansichtsmodus.

```java
// Instanziieren Sie eine Präsentationsklasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Greifen Sie auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Benutzerdefinierte Dimension
    int desiredX = 1200;
    int desiredY = 800;

    // Berechnen Sie den skalierenden Wert von X und Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    RenderingOptions opts = new RenderingOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);
    
    // Erstellen Sie ein Vollbildbild
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