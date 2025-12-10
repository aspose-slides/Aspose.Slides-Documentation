---
title: Erstelle einen Präsentationsbetrachter in Java
linktitle: Präsentationsbetrachter
type: docs
weight: 50
url: /de/java/presentation-viewer/
keywords:
- Präsentation anzeigen
- Präsentationsbetrachter
- Präsentationsbetrachter erstellen
- PPT anzeigen
- PPTX anzeigen
- ODP anzeigen
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen Sie einen benutzerdefinierten Präsentationsbetrachter in Java mit Aspose.Slides. Zeigen Sie PowerPoint- und OpenDocument-Dateien einfach ohne Microsoft PowerPoint an."
---

Aspose.Slides für Java wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können beispielsweise durch Öffnen der Präsentationen in Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch die Folien als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder einen eigenen Präsentationsbetrachter erstellen. In solchen Fällen ermöglicht Aspose.Slides den Export einer einzelnen Folie als Bild. Dieser Artikel beschreibt, wie das funktioniert.

## **Ein SVG‑Bild aus einer Folie erzeugen**

Um ein SVG‑Bild aus einer Präsentationsfolie mit Aspose.Slides zu erzeugen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.  
1. Holen Sie die Folienreferenz über ihren Index.  
1. Öffnen Sie einen Dateistream.  
1. Speichern Sie die Folie als SVG‑Bild in den Dateistream.  
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **Ein SVG mit benutzerdefinierter Shape‑ID erzeugen**

Aspose.Slides kann verwendet werden, um ein [SVG](https://docs.fileformat.com/page-description-language/svg/) aus einer Folie mit einer benutzerdefinierten Shape‑ID zu erzeugen. Verwenden Sie dazu die `setId`‑Methode von [ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` kann verwendet werden, um die Shape‑ID festzulegen.  
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```


## **Ein Folien‑Thumbnail‑Bild erstellen**

Aspose.Slides unterstützt Sie beim Erzeugen von Thumbnail‑Bildern von Folien. Um ein Thumbnail einer Folie mit Aspose.Slides zu erzeugen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.  
1. Holen Sie die Folienreferenz über ihren Index.  
1. Ermitteln Sie das Thumbnail‑Bild der referenzierten Folie in einem definierten Maßstab.  
1. Speichern Sie das Thumbnail‑Bild in einem beliebigen gewünschten Bildformat.  
```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Ein Folien‑Thumbnail mit benutzerdefinierten Abmessungen erstellen**

Um ein Folien‑Thumbnail‑Bild mit benutzerdefinierten Abmessungen zu erstellen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.  
1. Holen Sie die Folienreferenz über ihren Index.  
1. Ermitteln Sie das Thumbnail‑Bild der referenzierten Folie mit den definierten Abmessungen.  
1. Speichern Sie das Thumbnail‑Bild in einem beliebigen gewünschten Bildformat.  
```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Ein Folien‑Thumbnail mit Sprecher‑Notizen erstellen**

Um das Thumbnail einer Folie mit Sprecher‑Notizen mithilfe von Aspose.Slides zu erzeugen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) Klasse.  
1. Verwenden Sie die `RenderingOptions.setSlidesLayoutOptions`‑Methode, um die Position der Sprecher‑Notizen festzulegen.  
1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.  
1. Holen Sie die Folienreferenz über ihren Index.  
1. Ermitteln Sie das Thumbnail‑Bild der referenzierten Folie mit den Rendering‑Optionen.  
1. Speichern Sie das Thumbnail‑Bild in einem beliebigen gewünschten Bildformat.  
```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **Live‑Beispiel**

Sie können die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) ausprobieren, um zu sehen, was Sie mit der Aspose.Slides‑API umsetzen können:

![Online PowerPoint-Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kann ich einen Präsentations‑Viewer in eine Webanwendung einbetten?**

Ja. Sie können Aspose.Slides serverseitig verwenden, um Folien als Bilder oder HTML zu rendern und im Browser anzuzeigen. Navigations‑ und Zoom‑Funktionen können mit JavaScript für ein interaktives Erlebnis implementiert werden.

**Was ist der beste Weg, Folien in einem benutzerdefinierten Viewer anzuzeigen?**

Der empfohlene Ansatz ist, jede Folie als Bild (z. B. PNG oder SVG) zu rendern oder sie mit Aspose.Slides in HTML zu konvertieren und das Ergebnis dann in einer Bildbox (für Desktop) oder einem HTML‑Container (für Web) anzuzeigen.

**Wie gehe ich mit großen Präsentationen mit vielen Folien um?**

Bei umfangreichen Decks sollten Sie Lazy‑Loading oder das Rendern von Folien bei Bedarf in Betracht ziehen. Das bedeutet, den Inhalt einer Folie nur zu erzeugen, wenn der Benutzer zu ihr navigiert, wodurch Speicher‑ und Ladezeiten reduziert werden.