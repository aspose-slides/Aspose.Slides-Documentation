---
title: Masterbild
type: docs
weight: 30
url: /sv/nodejs-java/examples/elements/master-slide/
keywords:
- kodexempel
- masterbild
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Utforska Aspose.Slides för Node.js masterbildsexempel: skapa, redigera och formatera masterbilder, platshållare och teman i PPT, PPTX och ODP med tydlig kod."
---
Masterbilder utgör den översta nivån i bildarnas arvshierarki i PowerPoint. En **masterbild** definierar gemensamma designelement såsom bakgrunder, logotyper och textformatering. **Layoutbilder** ärver från masterbilder, och **normala bilder** ärver från layoutbilder.

Den här artikeln visar hur du skapar, modifierar och hanterar masterbilder med Aspose.Slides för Node.js via Java.

## **Lägg till en masterbild**

Detta exempel visar hur du skapar en ny masterbild genom att klona standardmasterbilden. Den lägger sedan till en företagsnamnsbanner på alla bilder via layoutärvning.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Klona standard-masterbilden.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Lägg till en banner med företagsnamn högst upp på masterbilden.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Tilldela den nya masterbilden till en layoutbild.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Tilldela layoutbilden till den första bilden i presentationen.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Obs 1:** Masterbilder ger ett sätt att applicera enhetlig varumärkesprofil eller delade designelement på alla bilder. Alla ändringar som görs i mastern kommer automatiskt att återspeglas i beroende layout- och normala bilder.

> 💡 **Obs 2:** Alla former eller formateringar som läggs till i en masterbild ärvs av layoutbilder och i sin tur av alla normala bilder som använder dessa layouter.  
> Bilden nedan illustrerar hur en textruta som läggs till på en masterbild automatiskt renderas på den slutliga bilden.

![Exempel på masterarv](master-slide-banner.png)

## **Åtkomst till en masterbild**

Du kan komma åt masterbilder via presentationens master‑samling. Så här hämtar och arbetar du med dem:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Ändra bakgrundstypen.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort en masterbild**

Masterbilder kan tas bort antingen efter index eller efter referens.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Ta bort en masterbild efter index.
        presentation.getMasters().removeAt(0);

        // Ta bort en masterbild efter referens.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort oanvända masterbilder**

Vissa presentationer innehåller masterbilder som inte används. Att ta bort dessa bilder kan hjälpa till att minska filstorleken.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Ta bort alla oanvända masterbilder (även de som är markerade som Preserve).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```