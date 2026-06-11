---
title: Masterbild
type: docs
weight: 30
url: /sv/androidjava/examples/elements/master-slide/
keywords:
- kodexempel
- masterbild
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Utforska Aspose.Slides för Android masterbildsexempel: skapa, redigera och formge masters, platshållare och teman i PPT, PPTX och ODP med tydlig Java‑kod."
---
Masterbilder utgör den översta nivån i bildens arvshierarki i PowerPoint. En **master slide** definierar gemensamma designelement såsom bakgrunder, logotyper och textformatering. **Layout slides** ärver från master slides, och **normal slides** ärver från layout slides.

Denna artikel visar hur man skapar, modifierar och hanterar master slides med Aspose.Slides för Android via Java.

## **Lägg till en master slide**

Detta exempel visar hur man skapar en ny master slide genom att klona standarden. Den lägger sedan till en företagsnamnsbanner på alla bilder via layoutärvning.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Klona den förvalda masterbilden.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Lägg till en banner med företagsnamn högst upp på masterbilden.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Tilldela den nya masterbilden till en layout‑bild.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Tilldela layout‑bilden till den första bilden i presentationen.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Master slides ger ett sätt att tillämpa konsekvent varumärkesprofil eller delade designelement på alla bilder. Alla ändringar som görs i mastern kommer automatiskt att återspeglas i beroende layout- och normalbilder.

> 💡 **Note 2:** Alla former eller formatering som läggs till i en master slide ärvs av layout slides och i sin tur av alla normal slides som använder dessa layouter.
> Bilden nedan illustrerar hur en textruta tillagd på en master slide automatiskt renderas på den slutgiltiga bilden.

![Exempel på masterarv](master-slide-banner.png)

## **Åtkomst till en master slide**

Du kan komma åt master slides med hjälp av presentationens master-samling. Så här hämtar du dem och arbetar med dem:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Ändra bakgrundstypen.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort en master slide**

Master slides kan tas bort antingen efter index eller efter referens.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Ta bort en masterbild efter index.
        presentation.getMasters().removeAt(0);

        // Ta bort en masterbild efter referens.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort oanvända master slides**

Vissa presentationer innehåller master slides som inte används. Att ta bort dessa bilder kan hjälpa till att minska filstorleken.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Ta bort alla oanvända masterbilder (även de som är markerade som Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```