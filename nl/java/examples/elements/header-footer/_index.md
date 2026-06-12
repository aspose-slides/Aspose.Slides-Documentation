---
title: Koptekst en voettekst
type: docs
weight: 220
url: /nl/java/examples/elements/header-footer/
keywords:
- codevoorbeeld
- koptekst
- voettekst
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer dia-koppen en voetteksten met Aspose.Slides for Java: voeg datums, dia-nummers en aangepaste tekst toe in PPT, PPTX en ODP met Java-voorbeelden."
---
Dit artikel laat zien hoe u voetteksten kunt toevoegen en datum‑ en tijdsplaceholders kunt bijwerken met **Aspose.Slides for Java**.

## **Voettekst toevoegen**

Voeg tekst toe aan het voettekstgebied van een dia en maak deze zichtbaar.

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

## **Datum en tijd bijwerken**

Pas de datum‑ en tijdsplaceholder op een dia aan.

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