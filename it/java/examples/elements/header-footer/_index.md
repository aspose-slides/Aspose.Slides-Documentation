---
title: Intestazione e piè di pagina
type: docs
weight: 220
url: /it/java/examples/elements/header-footer/
keywords:
- esempio di codice
- intestazione
- piè di pagina
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Controlla intestazioni e piè di pagina delle diapositive con Aspose.Slides per Java: aggiungi date, numeri di diapositiva e testo personalizzato in PPT, PPTX e ODP con esempi Java."
---
Questo articolo dimostra come aggiungere piè di pagina e aggiornare i segnaposti di data e ora utilizzando **Aspose.Slides for Java**.

## **Aggiungi un piè di pagina**

Aggiungi testo all'area del piè di pagina di una diapositiva e rendilo visibile.

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

## **Aggiorna data e ora**

Modifica il segnaposto di data e ora su una diapositiva.

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