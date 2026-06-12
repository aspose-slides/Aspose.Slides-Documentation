---
title: Masterdia
type: docs
weight: 30
url: /nl/nodejs-java/examples/elements/master-slide/
keywords:
- codevoorbeeld
- masterdia
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Node.js masterdia-voorbeelden: maak, bewerk en style masterdia's, placeholders en thema's in PPT, PPTX en ODP met duidelijke code."
---
Master slides vormen het bovenste niveau van de slide‑erfenishierarchie in PowerPoint. Een **master slide** definieert gemeenschappelijke ontwerpelementen zoals achtergronden, logo's en tekstopmaak. **Layout slides** erven van master slides, en **normale slides** erven van layout slides.

Dit artikel toont hoe je master slides kunt maken, wijzigen en beheren met Aspose.Slides for Node.js via Java.

## **Een master slide toevoegen**

Dit voorbeeld laat zien hoe je een nieuwe master slide maakt door de standaard te klonen. Vervolgens voegt het een bedrijfsnaam‑banner toe aan alle slides via layout‑erfenis.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Kloon de standaard masterdia.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Voeg een banner met bedrijfsnaam toe aan de bovenkant van de masterdia.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Wijs de nieuwe masterdia toe aan een layoutdia.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Wijs de layoutdia toe aan de eerste dia in de presentatie.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Opmerking 1:** Master slides bieden een manier om consistente branding of gedeelde ontwerpelementen toe te passen op alle slides. Elke wijziging die op de master wordt aangebracht, wordt automatisch weerspiegeld in de afhankelijke layout‑ en normale slides.

> 💡 **Opmerking 2:** Alle vormen of opmaak die aan een master slide worden toegevoegd, worden geërfd door layout slides en, op hun beurt, door alle normale slides die die layouts gebruiken.  
> De afbeelding hieronder toont hoe een tekstvak dat aan een master slide is toegevoegd automatisch wordt weergegeven op de uiteindelijke slide.

![Voorbeeld van master‑erfenis](master-slide-banner.png)

## **Toegang tot een master slide**

U kunt master slides benaderen via de presentatie‑master‑collectie. Hieronder ziet u hoe u ze kunt ophalen en ermee kunt werken:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Wijzig het achtergrondtype.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Een master slide verwijderen**

Master slides kunnen worden verwijderd op index of via een verwijzing.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Verwijder een masterdia op index.
        presentation.getMasters().removeAt(0);

        // Verwijder een masterdia op referentie.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Niet‑gebruikte master slides verwijderen**

Sommige presentaties bevatten master slides die niet worden gebruikt. Het verwijderen van deze slides kan helpen de bestandsgrootte te verkleinen.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Verwijder alle ongebruikte masterdia's (ook die gemarkeerd als Preserve).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```