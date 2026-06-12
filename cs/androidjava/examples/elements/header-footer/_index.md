---
title: Záhlaví a zápatí
type: docs
weight: 220
url: /cs/androidjava/examples/elements/header-footer/
keywords:
- ukázka kódu
- záhlaví
- zápatí
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Ovládejte záhlaví a zápatí snímků pomocí Aspose.Slides pro Android: přidejte data, čísla snímků a vlastní text v PPT, PPTX a ODP s Java ukázkami."
---
Tento článek ukazuje, jak přidat zápatí a aktualizovat zástupce data a času pomocí **Aspose.Slides for Android via Java**.

## **Přidat zápatí**

Přidejte text do oblasti zápatí snímku a zajistěte, aby byl viditelný.

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

## **Aktualizovat datum a čas**

Upravte zástupce data a času na snímku.

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