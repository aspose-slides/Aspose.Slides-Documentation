---
title: Sidhuvud och sidfot
type: docs
weight: 220
url: /sv/androidjava/examples/elements/header-footer/
keywords:
- kodexempel
- sidhuvud
- sidfot
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Kontrollera bilders sidhuvuden och sidfötter med Aspose.Slides för Android: lägg till datum, bildnummer och anpassad text i PPT, PPTX och ODP med Java-exempel."
---
Den här artikeln visar hur du lägger till sidfötter och uppdaterar datum- och tidsplatshållare med **Aspose.Slides for Android via Java**.

## **Lägg till en sidfot**

Lägg till text i sidfotområdet på en bild och gör den synlig.

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

## **Uppdatera datum och tid**

Ändra datum- och tidsplatshållaren på en bild.

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