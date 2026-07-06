---
title: Textabschnittsgrenzen aus Präsentationen in PHP abrufen
linktitle: Abschnittsgrenzen
type: docs
weight: 47
url: /de/php-java/portion-bounds/
keywords:
- Grenzen des Textabschnitts
- Textabschnitt
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textabschnittsgrenzen in PowerPoint-Präsentationen mit Aspose.Slides für PHP über Java abrufen."
---
## **Übersicht**

Ein Textabschnitt stellt ein bestimmtes Fragment von Text innerhalb eines Absatzes dar und ermöglicht es Ihnen, mit diesem Fragment unabhängig vom umgebenden Inhalt zu arbeiten. In Aspose.Slides können Abschnitte verwendet werden, wenn Sie die Grenzen eines Textfragmentes abrufen, die Formatierung nur für einen Teil eines Absatzes anwenden oder das Textverhalten auf einer detaillierteren Ebene steuern müssen.

Dieser Artikel zeigt, wie man das Begrenzungsrechteck eines Abschnitts mit [Portion::getRect](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/getrect/) ermittelt. Er zeigt außerdem, wie man die Koordinaten des Beginns eines Abschnitts mit [Portion::getCoordinates](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/getcoordinates/) erhält. Darüber hinaus werden gängige Szenarien im Zusammenhang mit Abschnitten hervorgehoben, z. B. das Anwenden eines Hyperlinks auf ein einzelnes Textfragment, das Verständnis der Auflösung von Formatierungen über Abschnitt, Absatz, Textfeld und Theme‑Vererbung sowie der Umgang mit Fällen, in denen eine angegebene Schriftart nicht verfügbar ist.

## **Grenzrechteck eines Textabschnitts abrufen**

Verwenden Sie [Portion::getRect](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/getrect/), um das Begrenzungsrechteck eines Textabschnitts zu erhalten:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Koordinaten eines Textabschnitts abrufen**

Verwenden Sie [Portion::getCoordinates](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/getcoordinates/), um die Koordinaten des Beginns eines Textabschnitts zu erhalten:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Kann ich einem einzelnen Teil des Textes innerhalb eines Absatzes einen Hyperlink zuweisen?**

Ja, Sie können [einen Hyperlink zuweisen](/slides/de/php-java/manage-hyperlinks/) zu einem einzelnen Abschnitt; nur dieses Fragment wird anklickbar sein, nicht der gesamte Absatz.

**Wie funktioniert die Vererbung von Stilen: Was überschreibt ein Abschnitt und was wird von einem Absatz oder Textfeld übernommen?**

Eigenschaften auf Abschnittsebene haben die höchste Priorität. Wenn eine Eigenschaft nicht im [Portion](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/) festgelegt ist, übernimmt Aspose.Slides sie vom [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/). Ist sie dort ebenfalls nicht gesetzt, verwendet Aspose.Slides den Stil des [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) oder des [theme](https://reference.aspose.com/slides/de/php-java/aspose.slides/theme/).

**Was passiert, wenn die für einen Abschnitt angegebene Schriftart auf dem Zielsystem oder Server fehlt?**

[Regeln für die Schriftartenersetzung](/slides/de/php-java/font-selection-sequence/) werden angewendet. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für präzise Positionierung wichtig ist.

**Kann ich die Textfülltransparenz oder einen Farbverlauf für einen einzelnen Abschnitt unabhängig vom Rest des Absatzes festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf [Portion](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/)-Ebene können von benachbarten Fragmenten abweichen.