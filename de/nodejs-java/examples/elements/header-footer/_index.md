---
title: Kopfzeile Fußzeile
type: docs
weight: 220
url: /de/nodejs-java/examples/elements/header-footer/
keywords:
- Codebeispiel
- Kopfzeile
- Fußzeile
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Steuern Sie Folien-Kopf- und Fußzeilen mit Aspose.Slides für Node.js: Fügen Sie Datumsangaben, Folienzahlen und benutzerdefinierten Text in PPT, PPTX und ODP mit JavaScript-Beispielen hinzu."
---
In diesem Artikel wird gezeigt, wie man Fußzeilen hinzufügt und Platzhalter für Datum und Uhrzeit mit **Aspose.Slides for Node.js via Java** aktualisiert.

## **Fußzeile hinzufügen**

Fügen Sie Text zum Fußzeilenbereich einer Folie hinzu und machen Sie ihn sichtbar.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Datum und Uhrzeit aktualisieren**

Ändern Sie den Platzhalter für Datum und Uhrzeit auf einer Folie.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```