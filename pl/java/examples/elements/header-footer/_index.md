---
title: Nagłówek Stopka
type: docs
weight: 220
url: /pl/java/examples/elements/header-footer/
keywords:
- przykład kodu
- nagłówek
- stopka
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Steruj nagłówkami i stopkami slajdów za pomocą Aspose.Slides for Java: dodawaj daty, numery slajdów i własny tekst w formatach PPT, PPTX i ODP przy użyciu przykładów w Javie."
---
Ten artykuł pokazuje, jak dodać stopki i zaktualizować znaczniki daty i czasu przy użyciu **Aspose.Slides for Java**.

## **Dodaj stopkę**

Dodaj tekst do obszaru stopki na slajdzie i spraw, aby był widoczny.

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

## **Zaktualizuj datę i godzinę**

Zmodyfikuj znacznik daty i czasu na slajdzie.

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