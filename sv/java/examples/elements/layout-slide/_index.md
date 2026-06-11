---
title: Layoutbild
type: docs
weight: 20
url: /sv/java/examples/elements/layout-slide/
keywords:
- kodexempel
- layoutbild
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Behärska layoutbilder i Aspose.Slides för Java: välj, tillämpa och anpassa bildlayouter, platshållare och master med Java-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man arbetar med **Layout Slides** i Aspose.Slides för Java. En layout‑bild definierar designen och formateringen som ärvs av vanliga bilder. Du kan lägga till, komma åt, klona och ta bort layout‑bilder samt rensa upp oanvända för att minska presentationens storlek.

## **Lägg till en layout‑bild**

Du kan skapa en anpassad layout‑bild för att definiera återanvändbar formatering. Till exempel kan du lägga till en textruta som visas på alla bilder som använder den här layouten.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Skapa en layoutbild med en tom layouttyp och ett anpassat namn.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Lägg till en textruta på layoutbilden.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Lägg till två bilder med denna layout; båda kommer att ärva texten från layouten.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Layout‑bilder fungerar som mallar för enskilda bilder. Du kan definiera vanliga element en gång och återanvända dem i många bilder.

> 💡 **Note 2:** När du lägger till former eller text i en layout‑bild kommer alla bilder som bygger på den layouten automatiskt att visa detta gemensamma innehåll. Skärmbilden nedan visar två bilder, var och en som ärver en textruta från samma layout‑bild.
> ![Bildspel som ärver layoutinnehåll](layout-slide-result.png)

## **Åtkomst till en layout‑bild**

Layout‑bilder kan nås via index eller via layout‑typ (t.ex. `Blank`, `Title`, `SectionHeader` osv.).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Åtkomst till en layoutbild via index.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Åtkomst till en layoutbild via typ.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort en layout‑bild**

Du kan ta bort en specifik layout‑bild om den inte längre behövs.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Hämta en layoutbild efter typ och ta bort den.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort oanvända layout‑bilder**

För att minska presentationens storlek kan du vilja ta bort layout‑bilder som inte används av några vanliga bilder.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Tar automatiskt bort alla layoutbilder som inte refereras av någon bild.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Klona en layout‑bild**

Du kan duplicera en layout‑bild med hjälp av metoden `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Hämta en befintlig layoutbild efter typ.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Klona layoutbilden till slutet av layoutbildsamlingen.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** Layout‑bilder är kraftfulla verktyg för att hantera enhetlig formatering över bilder. Aspose.Slides ger full kontroll över att skapa, hantera och optimera layout‑bilder.