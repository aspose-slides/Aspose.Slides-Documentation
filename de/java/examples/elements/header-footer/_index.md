---
title: Kopf- und Fußzeile
type: docs
weight: 220
url: /de/java/examples/elements/header-footer/
keywords:
- Codebeispiel
- Kopfzeile
- Fußzeile
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Steuern Sie Folien-Kopf- und Fußzeilen mit Aspose.Slides für Java: Fügen Sie Daten, Folienzahlen und benutzerdefinierten Text in PPT-, PPTX- und ODP-Dateien mit Java-Beispielen hinzu."
---
Dieser Artikel zeigt, wie Fußzeilen hinzugefügt und Datums‑ und Zeitplatzhalter mithilfe von **Aspose.Slides for Java** aktualisiert werden.

## **Fußzeile hinzufügen**

Fügen Sie Text zum Fußzeilenbereich einer Folie hinzu und machen Sie ihn sichtbar.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **Datum und Uhrzeit aktualisieren**

Ändern Sie den Datums‑ und Zeitplatzhalter auf einer Folie.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```