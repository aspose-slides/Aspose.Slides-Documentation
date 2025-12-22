---
title: Erstelle einen Präsentations-Viewer auf Android
linktitle: Präsentations-Viewer
type: docs
weight: 50
url: /de/androidjava/presentation-viewer/
keywords:
- Präsentation anzeigen
- Präsentations-Viewer
- Präsentations-Viewer erstellen
- PPT anzeigen
- PPTX anzeigen
- ODP anzeigen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen Sie einen benutzerdefinierten Präsentations-Viewer in Java mit Aspose.Slides für Android. Zeigen Sie PowerPoint- und OpenDocument-Dateien problemlos ohne Microsoft PowerPoint an."
---

Aspose.Slides für Android via Java wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können beispielsweise durch Öffnen der Präsentationen in Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch Folien als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder einen eigenen Präsentationsviewer erstellen. In solchen Fällen ermöglicht Aspose.Slides den Export einer einzelnen Folie als Bild. Dieser Artikel beschreibt, wie das funktioniert.

## **Ein SVG-Bild aus einer Folie generieren**

Um ein SVG-Bild aus einer Präsentationsfolie mit Aspose.Slides zu erzeugen, befolgen Sie bitte die nachstehenden Schritte:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.  
1. Holen Sie die Folienreferenz über deren Index.  
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


## **Ein SVG mit benutzerdefinierter Shape-ID generieren**

Aspose.Slides kann verwendet werden, um ein [SVG](https://docs.fileformat.com/page-description-language/svg/) aus einer Folie mit einer benutzerdefinierten Shape‑ID zu erzeugen. Verwenden Sie dazu die Methode `setId` von [ISvgShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` kann verwendet werden, um die Shape‑ID festzulegen.  
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


## **Ein Folien-Miniaturbild erstellen**

Aspose.Slides unterstützt Sie beim Erzeugen von Miniaturbildern von Folien. Um ein Miniaturbild einer Folie mit Aspose.Slides zu erzeugen, befolgen Sie bitte die nachstehenden Schritte:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.  
1. Holen Sie die Folienreferenz über deren Index.  
1. Erhalten Sie das Miniaturbild der referenzierten Folie in einem definierten Maßstab.  
1. Speichern Sie das Miniaturbild in einem beliebigen gewünschten Bildformat.  
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


## **Ein Folien-Miniaturbild mit benutzerdefinierten Abmessungen erstellen**

Um ein Folien‑Miniaturbild mit benutzerdefinierten Abmessungen zu erstellen, befolgen Sie bitte die nachstehenden Schritte:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.  
1. Holen Sie die Folienreferenz über deren Index.  
1. Erhalten Sie das Miniaturbild der referenzierten Folie mit den definierten Abmessungen.  
1. Speichern Sie das Miniaturbild in einem beliebigen gewünschten Bildformat.  
```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Ein Folien-Miniaturbild mit Sprecher-Notizen erstellen**

Um das Miniaturbild einer Folie mit Sprecher-Notizen mithilfe von Aspose.Slides zu erzeugen, befolgen Sie bitte die nachstehenden Schritte:

1. Erstellen Sie eine Instanz der [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) Klasse.  
1. Verwenden Sie die Methode `RenderingOptions.setSlidesLayoutOptions`, um die Position der Sprecher-Notizen festzulegen.  
1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.  
1. Holen Sie die Folienreferenz über deren Index.  
1. Erhalten Sie das Miniaturbild der referenzierten Folie mit den Rendering-Optionen.  
1. Speichern Sie das Miniaturbild in einem beliebigen gewünschten Bildformat.  
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


## **Live-Beispiel**

Sie können die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) ausprobieren, um zu sehen, was Sie mit der Aspose.Slides-API umsetzen können:

![Online-PowerPoint-Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kann ich einen Präsentations-Viewer in eine Webanwendung einbetten?**

Ja. Sie können Aspose.Slides serverseitig verwenden, um Folien als Bilder oder HTML zu rendern und sie im Browser anzuzeigen. Navigations- und Zoom-Funktionen können mit JavaScript für ein interaktives Erlebnis implementiert werden.

**Was ist der beste Weg, Folien in einem benutzerdefinierten Viewer anzuzeigen?**

Der empfohlene Ansatz besteht darin, jede Folie als Bild (z. B. PNG oder SVG) zu rendern oder mithilfe von Aspose.Slides in HTML zu konvertieren und die Ausgabe dann in einer Bild-Box (für Desktop) oder einem HTML-Container (für das Web) darzustellen.

**Wie gehe ich mit großen Präsentationen mit vielen Folien um?**

Bei großen Decks sollten Sie Lazy-Loading oder das Rendern von Folien bei Bedarf in Betracht ziehen. Das bedeutet, den Inhalt einer Folie nur zu erzeugen, wenn der Benutzer zu ihr navigiert, wodurch Speicher- und Ladezeit reduziert werden.