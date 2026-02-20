---
title: Hyperlink
type: docs
weight: 130
url: /de/php-java/examples/elements/hyperlink/
keywords:
- Hyperlink
- Hyperlink hinzufügen
- Hyperlink abrufen
- Hyperlink entfernen
- Hyperlink aktualisieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Hyperlinks in PHP mit Aspose.Slides hinzufügen, bearbeiten und entfernen: Linktext, Formen, Folien, URLs und E-Mail; Ziele und Aktionen für PPT, PPTX und ODP festlegen."
---
Demonstriert das Hinzufügen, Zugreifen, Entfernen und Aktualisieren von Hyperlinks in Formen mit **Aspose.Slides for PHP via Java**.

## **Hyperlink hinzufügen**

Erstellen Sie eine Rechteckform mit einem Hyperlink, der auf eine externe Website verweist.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Hyperlink abrufen**

Lesen Sie Hyperlink-Informationen aus dem Textteil einer Form.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, die erste Form enthält den Hyperlink.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Hyperlink entfernen**

Entfernen Sie den Hyperlink aus dem Text einer Form.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, die erste Form enthält den Hyperlink.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Hyperlink aktualisieren**

Ändern Sie das Ziel eines bestehenden Hyperlinks. Verwenden Sie `HyperlinkManager`, um Text, der bereits einen Hyperlink enthält, zu modifizieren, was das sichere Aktualisieren von Hyperlinks in PowerPoint nachahmt.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, die erste Form enthält den Hyperlink.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Das Ändern eines Hyperlinks im bestehenden Text sollte über
        // HyperlinkManager erfolgen, anstatt die Eigenschaft direkt zu setzen.
        // Dies ahmt nach, wie PowerPoint Hyperlinks sicher aktualisiert.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```