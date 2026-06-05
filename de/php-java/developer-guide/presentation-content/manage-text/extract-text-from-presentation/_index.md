---
title: "Erweiterte Textextraktion aus Präsentationen in PHP"
linktitle: "Text extrahieren"
type: docs
weight: 90
url: /de/php-java/extract-text-from-presentation/
keywords:
  - "Text extrahieren"
  - "Text aus Folie extrahieren"
  - "Text aus Präsentation extrahieren"
  - "Text aus PowerPoint extrahieren"
  - "Text aus OpenDocument extrahieren"
  - "Text aus PPT extrahieren"
  - "Text aus PPTX extrahieren"
  - "Text aus ODP extrahieren"
  - "Text abrufen"
  - "Text aus Folie abrufen"
  - "Text aus Präsentation abrufen"
  - "Text aus PowerPoint abrufen"
  - "Text aus OpenDocument abrufen"
  - "Text aus PPT abrufen"
  - "Text aus PPTX abrufen"
  - "Text aus ODP abrufen"
  - "PowerPoint"
  - "OpenDocument"
  - "Präsentation"
  - "PHP"
  - "Aspose.Slides"
description: "Extrahieren Sie schnell Text aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java. Befolgen Sie unsere einfache, schrittweise Anleitung, um Zeit zu sparen."
---
## **Übersicht**

Text aus Präsentationen zu extrahieren ist eine häufige, aber wesentliche Aufgabe für Entwickler, die mit Folieninhalten arbeiten. Egal, ob Sie mit Microsoft PowerPoint‑Dateien im PPT‑ oder PPTX‑Format oder mit OpenDocument‑Präsentationen (ODP) arbeiten, der Zugriff auf und das Abrufen von Textdaten kann für Analysen, Automatisierung, Indexierung oder die Migration von Inhalten entscheidend sein.

Dieser Artikel bietet eine umfassende Anleitung, wie Sie Text effizient aus verschiedenen Präsentationsformaten, einschließlich PPT, PPTX und ODP, mit Aspose.Slides for PHP via Java extrahieren können. Sie lernen, wie Sie systematisch durch die Elemente einer Präsentation iterieren, um den benötigten Textinhalt genau zu erhalten.

## **Text aus einer Folie extrahieren**

Aspose.Slides for PHP via Java bietet die [SlideUtil](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideutil/)‑Klasse. Diese Klasse stellt mehrere überladene statische Methoden zum Extrahieren des gesamten Textes aus einer Präsentation oder Folie bereit. Um Text aus einer Folie einer Präsentation zu extrahieren, verwenden Sie die [getAllTextBoxes](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideutil/#getAllTextBoxes)‑Methode. Diese Methode akzeptiert ein Objekt vom Typ [BaseSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/) als Parameter. Beim Aufruf durchsucht die Methode die gesamte Folie nach Text und gibt ein Array von Objekten des Typs [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) zurück, wobei sämtliche Textformatierungen erhalten bleiben.

Der folgende Codeausschnitt extrahiert den gesamten Text aus der ersten Folie der Präsentation:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Text aus einer Präsentation extrahieren**

Um Text aus der gesamten Präsentation zu scannen, verwenden Sie die statische Methode [getAllTextFrames](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideutil/#getAllTextFrames), die von der [SlideUtil](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideutil/)‑Klasse bereitgestellt wird. Sie akzeptiert zwei Parameter:

1. Zunächst ein [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Objekt, das eine PowerPoint‑ oder OpenDocument‑Präsentation darstellt, aus der Text extrahiert werden soll.
2. Zweitens ein `boolean`‑Wert, der angibt, ob die Master‑Folien in die Texterfassung einbezogen werden sollen.

Die Methode gibt ein Array von Objekten des Typs [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) zurück, das Informationen zur Textformatierung enthält. Der nachstehende Code scannt Text‑ und Formatierungsdetails aus einer Präsentation, einschließlich der Master‑Folien.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Kategorisierte und schnelle Textextraktion**

Die [PresentationFactory](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/)‑Klasse bietet ebenfalls Methoden zum Extrahieren des gesamten Textes aus Präsentationen:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

Der Enum‑Parameter [TextExtractionArrangingMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/textextractionarrangingmode/) gibt den Modus für die Anordnung des Extraktionsergebnisses an und kann auf folgende Werte gesetzt werden:
- `Unarranged` – Der Rohtext ohne Berücksichtigung seiner Position auf der Folie.
- `Arranged` – Der Text wird in derselben Reihenfolge angeordnet, wie er auf der Folie erscheint.

Der Modus **Unarranged** kann verwendet werden, wenn Geschwindigkeit entscheidend ist; er ist schneller als der Modus **Arranged**.

[PresentationText](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationtext/) stellt den rohen aus der Präsentation extrahierten Text dar. Seine Methode `getSlidesText` liefert ein Array von Objekten, wobei jedes Objekt den Text der entsprechenden Folie repräsentiert. Jedes zurückgegebene Objekt bietet die folgenden Methoden:

- `getText` – Der Text innerhalb der Formen der Folie.
- `getMasterText` – Der Text innerhalb der Formen der Master‑Folie, die dieser Folie zugeordnet ist.
- `getLayoutText` – Der Text innerhalb der Formen der Layout‑Folie, die dieser Folie zugeordnet ist.
- `getNotesText` – Der Text innerhalb der Formen der Notizfolie, die dieser Folie zugeordnet ist.
- `getCommentsText` – Der Text innerhalb der Kommentare, die dieser Folie zugeordnet sind.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **FAQ**

**Wie schnell verarbeitet Aspose.Slides große Präsentationen beim Textextrahieren?**

Aspose.Slides ist für hohe Leistung optimiert und kann sogar [große Präsentationen](/slides/de/php-java/open-presentation/) verarbeiten, sodass es für Echtzeit‑ oder Batch‑Szenarien geeignet ist.

**Kann Aspose.Slides Text aus Tabellen und Diagrammen innerhalb von Präsentationen extrahieren?**

Ja. Aspose.Slides kann Text aus vielen Folienelementen, einschließlich Tabellen und diagrammspezifischen Objekten, extrahieren, sodass Sie textbasierte Inhalte in gängigen Präsentationsstrukturen analysieren können.

**Benötige ich eine spezielle Aspose.Slides‑Lizenz, um Text aus Präsent