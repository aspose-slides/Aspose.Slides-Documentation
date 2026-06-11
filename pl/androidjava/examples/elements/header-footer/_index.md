---
title: Nagłówek i stopka
type: docs
weight: 220
url: /pl/androidjava/examples/elements/header-footer/
keywords:
- przykład kodu
- nagłówek
- stopka
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Kontroluj nagłówki i stopki slajdów za pomocą Aspose.Slides for Android: dodawaj daty, numery slajdów i własny tekst w formatach PPT, PPTX i ODP przy użyciu przykładów w języku Java."
---
Ten artykuł przedstawia, jak dodać stopki i zaktualizować znaczniki daty i godziny przy użyciu **Aspose.Slides for Android via Java**.

## **Dodaj stopkę**

Dodaj tekst do obszaru stopki slajdu i spraw, aby był widoczny.

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

Zmień znacznik daty i godziny na slajdzie.

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