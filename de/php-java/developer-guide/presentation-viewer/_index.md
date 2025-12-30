---
title: Erstellen Sie einen Präsentationsbetrachter in PHP
linktitle: Präsentationsbetrachter
type: docs
weight: 50
url: /de/php-java/presentation-viewer/
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
- PHP
- Aspose.Slides
description: "Erstellen Sie einen benutzerdefinierten Präsentationsbetrachter mit Aspose.Slides für PHP über Java. Zeigen Sie PowerPoint- und OpenDocument-Dateien einfach ohne Microsoft PowerPoint an."
---

Aspose.Slides für PHP über Java wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können beispielsweise durch Öffnen der Präsentationen in Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch Folien als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder einen eigenen Präsentationsbetrachter erstellen. In solchen Fällen ermöglicht Aspose.Slides den Export einer einzelnen Folie als Bild. Dieser Artikel beschreibt, wie das funktioniert.

## **Ein SVG‑Bild aus einer Folie erzeugen**

Um ein SVG‑Bild aus einer Präsentationsfolie mit Aspose.Slides zu erzeugen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse.  
1. Rufen Sie die Folienreferenz über ihren Index ab.  
1. Öffnen Sie einen Dateistream.  
1. Speichern Sie die Folie als SVG‑Bild in den Dateistream.  
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```


## **Ein SVG mit einer benutzerdefinierten Shape‑ID erzeugen**

Aspose.Slides kann verwendet werden, um ein [SVG](https://docs.fileformat.com/page-description-language/svg/) aus einer Folie mit einer benutzerdefinierten Shape‑ID zu erzeugen. Verwenden Sie dazu die Methode `setId` von [SvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` kann verwendet werden, um die Shape‑ID festzulegen.  
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```

```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```


## **Ein Folien‑Thumbnail‑Bild erstellen**

Aspose.Slides hilft Ihnen, Thumbnail‑Bilder von Folien zu erzeugen. Um ein Thumbnail einer Folie mit Aspose.Slides zu erzeugen, befolgen Sie bitte die nachstehenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse.  
1. Rufen Sie die Folienreferenz über ihren Index ab.  
1. Rufen Sie das Thumbnail‑Bild der referenzierten Folie in einem definierten Maßstab ab.  
1. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.  
```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **Ein Folien‑Thumbnail mit benutzerdefinierten Abmessungen erstellen**

Um ein Folien‑Thumbnail‑Bild mit benutzerdefinierten Abmessungen zu erstellen, befolgen Sie bitte die nachstehenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse.  
1. Rufen Sie die Folienreferenz über ihren Index ab.  
1. Rufen Sie das Thumbnail‑Bild der referenzierten Folie mit den definierten Abmessungen ab.  
1. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.  
```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **Ein Folien‑Thumbnail mit Moderationsnotizen erstellen**

Um das Thumbnail einer Folie mit Moderationsnotizen mithilfe von Aspose.Slides zu erzeugen, befolgen Sie bitte die nachstehenden Schritte:

1. Erstellen Sie eine Instanz der [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/)-Klasse.  
1. Verwenden Sie die Methode `RenderingOptions.setSlidesLayoutOptions`, um die Position der Moderationsnotizen festzulegen.  
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse.  
1. Rufen Sie die Folienreferenz über ihren Index ab.  
1. Rufen Sie das Thumbnail‑Bild der referenzierten Folie mit den Rendering‑Optionen ab.  
1. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.  
```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```


## **Live‑Beispiel**

Sie können die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) testen, um zu sehen, was Sie mit der Aspose.Slides‑API umsetzen können:

![Online‑PowerPoint‑Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kann ich einen Präsentationsbetrachter in eine Webanwendung einbetten?**

Ja. Sie können Aspose.Slides auf der Serverseite verwenden, um Folien als Bilder oder HTML zu rendern und im Browser anzuzeigen. Navigations‑ und Zoom‑Funktionen können mit JavaScript für ein interaktives Erlebnis implementiert werden.

**Was ist der beste Weg, Folien in einem eigenen Betrachter anzuzeigen?**

Der empfohlene Ansatz ist, jede Folie als Bild (z. B. PNG oder SVG) zu rendern oder mit Aspose.Slides in HTML zu konvertieren und die Ausgabe dann in einem Bildfeld (für Desktop) oder einem HTML‑Container (für das Web) anzuzeigen.

**Wie gehe ich mit großen Präsentationen mit vielen Folien um?**

Bei großen Präsentationen sollten Sie Lazy‑Loading oder das Rendern von Folien bei Bedarf in Betracht ziehen. Das bedeutet, den Inhalt einer Folie erst zu erzeugen, wenn der Benutzer zu ihr navigiert, wodurch Speicher‑ und Ladezeit reduziert werden.