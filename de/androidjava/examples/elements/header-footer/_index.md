---
title: Kopfzeile und Fußzeile
type: docs
weight: 220
url: /de/androidjava/examples/elements/header-footer/
keywords:
- Codebeispiel
- Kopfzeile
- Fußzeile
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Steuern Sie Folienkopf- und -fußzeilen mit Aspose.Slides für Android: Fügen Sie Datumsangaben, Foliennummern und benutzerdefinierten Text in PPT, PPTX und ODP mithilfe von Java-Beispielen hinzu."
---
Dieser Artikel zeigt, wie man Fußzeilen hinzufügt und Platzhalter für Datum und Uhrzeit mit **Aspose.Slides for Android via Java** aktualisiert.

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

Ändern Sie den Platzhalter für Datum und Uhrzeit auf einer Folie.

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