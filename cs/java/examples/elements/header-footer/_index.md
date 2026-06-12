---
title: Záhlaví a zápatí
type: docs
weight: 220
url: /cs/java/examples/elements/header-footer/
keywords:
- příklad kódu
- záhlaví
- zápatí
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Ovládejte záhlaví a zápatí snímků pomocí Aspose.Slides pro Java: přidejte data, čísla snímků a vlastní text v PPT, PPTX a ODP pomocí příkladů v Javě."
---
Tento článek ukazuje, jak přidat zápatí a aktualizovat zástupce data a času pomocí **Aspose.Slides for Java**.

## **Přidat zápatí**

Přidejte text do oblasti zápatí snímku a zobrazte jej.

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