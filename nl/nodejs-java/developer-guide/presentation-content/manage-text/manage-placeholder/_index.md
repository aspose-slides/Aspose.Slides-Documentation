---
title: Beheer presentatie‑placeholders in JavaScript
linktitle: Placeholders beheren
type: docs
weight: 10
url: /nl/nodejs-java/manage-placeholder/
keywords:
- plaatshouder
- tekst‑plaatshouder
- afbeelding‑plaatshouder
- grafiek‑plaatshouder
- prompt‑tekst
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer moeiteloos placeholders in Aspose.Slides voor Node.js via Java: vervang tekst, pas prompts aan & stel afbeeldings‑transparantie in PowerPoint en OpenDocument in."
---
## **Overzicht**

Aspose.Slides stelt u in staat om placeholders in presentaties programmatisch te beheren. Dit artikel legt uit hoe u placeholders op dia’s kunt vinden en hun tekst kunt wijzigen, aangepaste prompt‑tekst kunt instellen voor placeholder‑lay‑outs, en de transparantie van een afbeelding die als achtergrond van een placeholder wordt gebruikt kunt aanpassen. Het bevat tevens een korte FAQ die het verschil tussen basis‑placeholders en lokale shapes verduidelijkt, uitlegt hoe placeholder‑wijzigingen via lay‑outs of masters kunnen worden toegepast, en verwijst naar het beheer van header‑ en footer‑placeholders.

## **Tekst in placeholder wijzigen**

Met [Aspose.Slides for Node.js via Java](/slides/nl/nodejs-java/) kunt u placeholders op dia’s in presentaties vinden en wijzigen. Aspose.Slides stelt u in staat om veranderingen in de tekst van een placeholder aan te brengen.

**Voorwaarde**: U hebt een presentatie nodig die een placeholder bevat. Zo’n presentatie kunt u maken met de standaard Microsoft PowerPoint‑applicatie.

1. Maak een instantie van de [`Presentation`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse en geef de presentatie als argument door.
2. Haal een dia‑referentie op via de index.
3. Itereer over de shapes om de placeholder te vinden.
4. Cast de placeholder‑shape naar een [`AutoShape`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape) en wijzig de tekst via het [`TextFrame`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrame) dat bij de [`AutoShape`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape) hoort.
5. Sla de gewijzigde presentatie op.

Deze JavaScript‑code toont hoe u de tekst in een placeholder wijzigt:

```javascript
// Instantieert een Presentation‑klasse
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Toegang tot de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Itereert door de shapes om de placeholder te vinden
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Wijzigt de tekst in elke placeholder
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Slaat de presentatie op schijf
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Prompt‑tekst in placeholder instellen**

Standaard‑ en vooraf gebouwde lay‑outs bevatten placeholder‑prompt‑teksten zoals ***Click to add a title*** of ***Click to add a subtitle***. Met Aspose.Slides kunt u uw eigen prompt‑teksten in placeholder‑lay‑outs invoegen.

Deze JavaScript‑code laat zien hoe u de prompt‑tekst in een placeholder instelt:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Itereren door de dia
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint toont "Click to add title"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Voegt ondertitel toe
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Transparantie van placeholder‑afbeelding instellen**

Aspose.Slides stelt u in staat de transparantie van de achtergrondafbeelding in een tekst‑placeholder in te stellen. Door de transparantie van de afbeelding in zo’n frame aan te passen, kunt u de tekst of de afbeelding laten opvallen (afhankelijk van de kleuren van de tekst en de afbeelding).

Deze JavaScript‑code laat zien hoe u de transparantie van een afbeelding‑achtergrond (binnen een shape) instelt:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **FAQ**

**Wat is een basis‑placeholder en hoe verschilt deze van een lokale shape op een dia?**

Een basis‑placeholder is de oorspronkelijke shape op een lay‑out of master waarvan de shape van de dia erft — type, positie en sommige opmaak komen hier vandaan. Een lokale shape is onafhankelijk; als er geen basis‑placeholder aanwezig is, is er geen overerving.

**Hoe kan ik alle titels of bijschriften in een presentatie bijwerken zonder over elke dia te itereren?**

Bewerk de bijbehorende placeholder op de lay‑out of de master. Dia’s die op die lay‑outs/master zijn gebaseerd, zullen de wijziging automatisch overnemen.

**Hoe beheer ik de standaard header/footer‑placeholders — datum & tijd, dia­nummer en footer‑tekst?**

Gebruik de HeaderFooter‑managers op het juiste niveau (normale dia’s, lay‑outs, master, notities/hand‑outs) om die placeholders in of uit te schakelen en hun inhoud in te stellen.