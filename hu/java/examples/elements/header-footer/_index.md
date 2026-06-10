---
title: Fejléc és lábléc
type: docs
weight: 220
url: /hu/java/examples/elements/header-footer/
keywords:
- kódpélda
- fejléc
- lábléc
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Java segítségével vezérelheted a diák fejlécét és láblécét: dátumok, diaszámok és egyedi szöveg hozzáadása PPT, PPTX és ODP formátumokban Java példákkal."
---
Ez a cikk bemutatja, hogyan adhat hozzá láblécet, és frissítheti a dátum‑ és időhelyettesítőket az **Aspose.Slides for Java** használatával.

## **Lábléc hozzáadása**

Adj szöveget a dia lábléc területére, és tedd láthatóvá.

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

Módosítsd a dián lévő dátum‑ és időhelyettesítőt.

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