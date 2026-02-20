---
title: Kopf- und Fußzeile
type: docs
weight: 220
url: /de/php-java/examples/elements/header-footer/
keywords:
- Kopf- und Fußzeile
- Kopf- und Fußzeile hinzufügen
- Kopf- und Fußzeile aktualisieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Steuern Sie Kopf- und Fußzeilen in PHP mit Aspose.Slides: Datum/Uhrzeit, Folienzahlen und Fußzeilentext hinzufügen oder bearbeiten, Platzhalter in PPT, PPTX und ODP ein- oder ausblenden."
---
Zeigt, wie man Fußzeilen hinzufügt und Platzhalter für Datum und Uhrzeit mit **Aspose.Slides for PHP via Java** aktualisiert.

## **Fußzeile hinzufügen**

Fügen Sie Text zum Fußzeilenbereich einer Folie hinzu und machen Sie ihn sichtbar.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Datum und Uhrzeit aktualisieren**

Ändern Sie den Platzhalter für Datum und Uhrzeit auf einer Folie.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```