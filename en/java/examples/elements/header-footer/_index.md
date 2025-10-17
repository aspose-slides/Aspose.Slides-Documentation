---
title: Header Footer
type: docs
weight: 220
url: /java/examples/elements/elements/headerfooter/
keywords:
- code example
- header
- footer
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Control slide headers and footers with Aspose.Slides for Java: add dates, slide numbers, and custom text in PPT, PPTX, and ODP with Java examples."
---

This article demonstrates how to add footers and update date and time placeholders using **Aspose.Slides for Java**.

## **Add a Footer**

Add text to the footer area of a slide and make it visible.

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

## **Update Date and Time**

Modify the date and time placeholder on a slide.

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
