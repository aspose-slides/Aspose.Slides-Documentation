---
title: Masterbild
type: docs
weight: 30
url: /sv/java/examples/elements/master-slide/
keywords:
- kodexempel
- masterbild
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Utforska Aspose.Slides för Java masterbildsexempel: skapa, redigera och formatera masterbilder, platshållare och teman i PPT, PPTX och ODP med tydlig Java‑kod."
---
Masterbilder bildar den översta nivån i bildens arvshierarki i PowerPoint. En **masterbild** definierar gemensamma designelement såsom bakgrunder, logotyper och textformatering. **Layoutbilder** ärver från masterbilder, och **vanliga bilder** ärver från layoutbilder.

Denna artikel visar hur man skapar, ändrar och hanterar masterbilder med Aspose.Slides för Java.

## **Lägg till en masterbild**

Detta exempel visar hur man skapar en ny masterbild genom att klona standardbilden. Den lägger sedan till en företagsnamnsbanner på alla bilder via layoutarv.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Klona standard‑masterbilden.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Lägg till en banner med företagsnamn högst upp på masterbilden.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Tilldela den nya masterbilden till en layoutbild.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Tilldela layoutbilden till den första bilden i presentationen.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Masterbilder ger ett sätt att applicera konsekvent varumärkesprofil eller delade designelement på alla bilder. Alla ändringar som görs i masterbilden kommer automatiskt att återspeglas i beroende layout- och vanliga bilder.  
> 
> 💡 **Note 2:** Alla former eller formateringar som läggs till i en masterbild ärvts av layoutbilder och i sin tur av alla vanliga bilder som använder dessa layouter. Bilden nedan illustrerar hur en textruta som lagts till i en masterbild automatiskt renderas på den slutliga bilden.

![Master Inheritance Example](master-slide-banner.png)

## **Åtkomst till en masterbild**

Du kan få åtkomst till masterbilder med hjälp av presentationens masterkollektion. Så här hämtar du dem och arbetar med dem:

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

## **Ta bort en masterbild**

Masterbilder kan tas bort antingen via index eller via referens.

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

## **Ta bort oanvända masterbilder**

Vissa presentationer innehåller masterbilder som inte används. Att ta bort dessa bilder kan hjälpa till att minska filstorleken.

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