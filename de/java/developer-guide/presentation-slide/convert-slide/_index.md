---
title: Präsentationsfolien in Java in Bilder konvertieren
linktitle: Folie zu Bild
type: docs
weight: 35
url: /de/java/convert-slide/
keywords:
- Folie konvertieren
- Folie exportieren
- Folie zu Bild
- Folie als Bild speichern
- Folie zu EMF
- Folie zu PNG
- Folie zu JPEG
- Folie zu Bitmap
- Folie zu TIFF
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Konvertieren Sie Folien aus PPT-, PPTX- und ODP-Präsentationen in PNG, JPEG, GIF, TIFF, EMF und andere Bildformate in Java mit Aspose.Slides."
---
## **Einleitung**

Aspose.Slides for Java kann einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen als PNG, JPEG, GIF, TIFF und andere Bildformate rendern.

Um eine Folie in ein Bild zu konvertieren, gehen Sie wie folgt vor:

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) .
2. Wählen Sie die Folie aus, die Sie rendern möchten.
3. Falls erforderlich, konfigurieren Sie das Rendering mit der Klasse [RenderingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/renderingoptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/) .
4. Rufen Sie die Methode [ISlide.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#getImage--) auf. Sie gibt ein [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/)‑Objekt zurück.
5. Rufen Sie die Methode [IImage.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/#save-java.lang.String-int-) auf und geben Sie das Ausgabeformat mit einem [ImageFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/imageformat/)‑Wert an.

## **Eine Folie in ein PNG‑Bild konvertieren**

Die einfachste Konvertierung verwendet die Standard‑Rendering‑Einstellungen. Das resultierende [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/)‑Objekt kann im Speicher verarbeitet oder in eine Datei gespeichert werden.

Das folgende Java‑Beispiel rendert die erste Folie und speichert sie als PNG‑Bild:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Folien in Bilder mit benutzerdefinierten Größen konvertieren**

Verwenden Sie die Überladung von [ISlide.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), die einen [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html)‑Wert akzeptiert, um eine Folie mit genauen Pixelabmessungen zu rendern.

Das folgende Beispiel erstellt ein JPEG‑Bild mit 1820 × 1040 Pixeln:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Standardmäßig enthalten Folienbilder keine Notizen oder Kommentare. Übergeben Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/notescommentslayoutingoptions/)‑Objekt an die Methode [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-), um zu steuern, wo Notizen und Kommentare erscheinen.

Das folgende Beispiel platziert abgeschnittene Notizen unterhalb der Folie und Kommentare rechts davon:

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Für die Folie‑zu‑Bild‑Konvertierung übergeben Sie nicht [BottomFull](https://reference.aspose.com/slides/de/java/com.aspose.slides/notespositions/) an die Methode [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/de/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Notizen können mehr Text enthalten, als die feste Bildgröße aufnehmen kann. Verwenden Sie stattdessen [BottomTruncated](https://reference.aspose.com/slides/de/java/com.aspose.slides/notespositions/).
{{% /alert %}}

## **Folien in Bilder mit TIFF‑Optionen konvertieren**

Die Klasse [TiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/) ermöglicht die Steuerung von Größe, Auflösung und anderen Eigenschaften des gerenderten TIFF‑Bildes.

Das folgende Beispiel rendert die erste Folie als 2160 × 2880 TIFF‑Bild mit 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
TIFF‑Unterstützung ist in Java‑Versionen vor JDK 9 nicht garantiert.
{{% /alert %}}

## **Alle Folien in Bilder konvertieren**

Iterieren Sie über die Folien‑Collection, um die gesamte Präsentation in eine Reihe von Bildern zu konvertieren. Ausgeblendete Folien werden einbezogen, sofern Sie sie nicht ausdrücklich überspringen.

Das folgende Beispiel rendert jede Folie als JPEG‑Bild mit horizontalen und vertikalen Skalierungsfaktoren von 2:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Enhanced Metafile‑Ausgabe erstellen**

Enhanced Metafile (EMF) ist nützlich, wenn vektorbasierte Grafiken mit Microsoft Office oder anderen Windows‑Anwendungen ausgetauscht werden müssen, die Windows‑Metadateien unterstützen. Im Gegensatz zu einem Pixel‑Bild kann ein EMF Vektor‑Zeichenvorgänge beibehalten, die sich skalieren lassen, ohne dass die Schärfe verloren geht. EMF ist jedoch primär ein Kompatibilitätsformat für Anwendungen mit Windows‑Metadatei‑Unterstützung und kein universelles Austauschformat. Darüber hinaus können komplexe Folieninhalte, wie Bitmap‑Bilder und einige Effekte, als gerasterte Elemente innerhalb des Vektor‑Metadatei‑Containers gespeichert werden.

### **Eine Folie nach EMF exportieren**

Die Methode [ISlide.writeAsEmf](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) schreibt ein [ISlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/) in einen Ziel‑Stream im EMF‑Format. Das folgende Beispiel lädt eine Präsentation, wählt die erste Folie aus und schreibt sie in einen EMF‑Dateistream:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Der Aufrufer besitzt den an [ISlide.writeAsEmf](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) übergebenen Stream und ist für das Schließen verantwortlich, wie oben gezeigt.

### **Ein SVG‑Bild in EMF konvertieren und einer Präsentation hinzufügen**

Verwenden Sie [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-), um SVG‑Inhalte in EMF zu konvertieren. Die resultierenden Bytes können über [IImageCollection.addImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) zur Präsentation hinzugefügt und mit [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) auf einer Folie platziert werden.

Das folgende Beispiel erstellt ein [SvgImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgimage/) aus SVG‑Markup, konvertiert es in ein EMF im Speicher, fügt die Metadatei auf der ersten Folie ein und speichert die Präsentation:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) übernimmt den Ziel‑Stream nicht. Ein [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) speichert alle erzeugten Daten im Speicher, sodass vor dem Aufruf von `toByteArray` kein Positions‑Reset erforderlich ist. Das zurückgegebene Byte‑Array bleibt nach dem Schließen des Streams gültig.

Die EMF‑Erstellung ist auf den von der gewählten Aspose.Slides for Java‑ und JDK‑Konfiguration unterstützten Betriebssystemen verfügbar, jedoch kann das Rendering plattformabhängig variieren, wenn Schriftarten oder Grafik‑Abhängigkeiten fehlen. Installieren Sie die für den Quellinhalt verwendeten Schriftarten oder konfigurieren Sie geeignete Ersatz‑Schriftarten, folgen Sie den [platform requirements](/slides/de/java/system-requirements/) für Aspose.Slides for Java und prüfen Sie das Ergebnis in der Ziel‑Anwendung, die EMF verarbeitet. Linux‑ und macOS‑Anwendungen unterstützen Windows‑Metadateien häufig nur eingeschränkt oder inkonsistent.

## **Farb‑Emoji‑Rendering**

{{% alert title="Note" color="info" %}}
Um Farb‑Emojis beim Konvertieren von Präsentationsfolien in Bilder korrekt zu rendern, müssen die in der Präsentation verwendeten Emoji‑Schriftarten auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Beispielsweise kann es vorkommen, dass Emojis monochrom erscheinen, wenn die Präsentation **Segoe UI Emoji** verwendet und diese Schriftart fehlt.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein. Die Methode [ISlide.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#getImage--) rendert ein statisches Bild der Folie und exportiert keine Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja. Ausgeblendete Folien können wie reguläre Folien gerendert werden. Binden Sie sie in die Verarbeitungsschleife ein, wie im obigen Beispiel gezeigt.

**Werden Schatten und andere Effekte in Folienbildern erhalten?**

Ja. Aspose.Slides rendert Schatten, Transparenz und andere unterstützte grafische Effekte in Folienbildern.