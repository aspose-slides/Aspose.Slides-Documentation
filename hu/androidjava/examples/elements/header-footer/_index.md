---
title: Fejléc és lábléc
type: docs
weight: 220
url: /hu/androidjava/examples/elements/header-footer/
keywords:
- kódpélda
- fejléc
- lábléc
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Szabályozza a diafejléceket és -lábléceket az Aspose.Slides for Android segítségével: adjon hozzá dátumokat, dia számokat és egyéni szöveget PPT, PPTX és ODP formátumokban Java példákkal."
---
Ez a cikk bemutatja, hogyan lehet láblécet hozzáadni, illetve frissíteni a dátum- és időhelyőrzőket a **Aspose.Slides for Android via Java** használatával.

## **Lábléc hozzáadása**

Adjon szöveget a dia lábléc területéhez, és tegye láthatóvá.

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

## **Dátum és idő frissítése**

Módosítsa a dia dátum- és időhelyőrzőjét.

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