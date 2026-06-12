---
title: Beheer SmartArt‑afbeeldingen in presentaties met JavaScript
linktitle: SmartArt‑afbeeldingen
type: docs
weight: 20
url: /nl/nodejs-java/manage-smartart-shape/
keywords:
- SmartArt‑object
- SmartArt‑grafiek
- SmartArt‑stijl
- SmartArt‑kleur
- SmartArt maken
- SmartArt toevoegen
- SmartArt bewerken
- SmartArt wijzigen
- SmartArt benaderen
- SmartArt‑lay-outtype
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatiseer het aanmaken, bewerken en stylen van PowerPoint SmartArt in JavaScript met Aspose.Slides, met beknopte code‑voorbeelden en prestatiegerichte richtlijnen."
---
## **Overzicht**

Aspose.Slides stelt u in staat om SmartArt‑afbeeldingen programmatic te maken en te beheren in PowerPoint‑presentaties. Dit artikel legt uit hoe u een SmartArt‑vorm aan een dia toevoegt, bestaande SmartArt‑vormen benadert, SmartArt vindt op basis van een specifiek lay-outtype, en het uiterlijk bijwerkt door de SmartArt‑stijl of kleurstijl te wijzigen.

De voorbeelden tonen hoe u met SmartArt‑vormen werkt via de vormverzameling van de presentatiedia, controleert of een vorm SmartArt is en vervolgens de eigenschappen wijzigt of inspecteert.

## **SmartArt‑vorm maken**
Aspose.Slides voor Node.js via Java biedt een API om SmartArt‑vormen te maken. Volg de onderstaande stappen om een SmartArt‑vorm aan een dia toe te voegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
2. Verkrijg de referentie van een dia door gebruik te maken van de Index.
3. [Voeg een SmartArt‑vorm toe](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) door de [LayoutType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArtLayoutType) in te stellen.
4. Sla de aangepaste presentatie op als een PPTX‑bestand.

```javascript
// Instantie van Presentation Class
var pres = new aspose.slides.Presentation();
try {
    // Verkrijg eerste slide
    var slide = pres.getSlides().get_Item(0);
    // Voeg Smart Art Shape toe
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Presentatie opslaan
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figuur: SmartArt‑vorm toegevoegd aan de dia**|

## **SmartArt‑vorm benaderen in dia**
De onderstaande code wordt gebruikt om de toegevoegde SmartArt‑vormen in de presentatiedia te benaderen. In de voorbeeldcode doorlopen we elke vorm in de dia en controleren we of het een [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt)‑vorm is. Is de vorm van het type SmartArt, dan casten we deze naar een [**SmartArt**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt)‑instantie.

```javascript
// Laad de gewenste presentatie
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Doorloop elke vorm binnen de eerste slide
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Controleer of de vorm van het type SmartArt is
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Cast de vorm naar SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑vorm benaderen met specifiek lay-outtype**
De volgende voorbeeldcode helpt om de [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt)‑vorm met een specifiek LayoutType te benaderen. Merk op dat u het LayoutType van de SmartArt niet kunt wijzigen, aangezien het alleen‑lezen is en alleen wordt ingesteld wanneer de [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt)‑vorm wordt toegevoegd.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse en laad de presentatie met SmartArt‑vorm.
2. Verkrijg de referentie van de eerste dia via de Index.
3. Doorloop elke vorm binnen de eerste dia.
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) is en cast de geselecteerde vorm naar SmartArt als het SmartArt is.
5. Controleer de SmartArt‑vorm met het specifieke LayoutType en voer daarna de nodige handelingen uit.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Doorloop elke vorm binnen de eerste dia
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Controleer of de vorm van het type SmartArt is
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Cast de vorm naar SmartArtEx
            var smart = shape;
            // Controle van SmartArt‑lay-out
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt‑vormstijl wijzigen**
In dit voorbeeld leren we de snelle stijl van een willekeurige SmartArt‑vorm te wijzigen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse en laad de presentatie met SmartArt‑vorm.
2. Verkrijg de referentie van de eerste dia via de Index.
3. Doorloop elke vorm binnen de eerste dia.
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) is en cast de geselecteerde vorm naar SmartArt indien het SmartArt is.
5. Zoek de SmartArt‑vorm met een specifieke stijl.
6. Stel de nieuwe stijl in voor de SmartArt‑vorm.
7. Sla de presentatie op.

```javascript
// Instantie van Presentation‑klasse
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Haal eerste dia op
    var slide = pres.getSlides().get_Item(0);
    // Doorloop elke vorm binnen de eerste dia
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Controleer of de vorm van het type SmartArt is
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Cast de vorm naar SmartArtEx
            var smart = shape;
            // Controle van SmartArt‑stijl
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Wijzigen van SmartArt‑stijl
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Presentatie opslaan
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figuur: SmartArt‑vorm met gewijzigde stijl**|

## **SmartArt‑vormkleurstijl wijzigen**
In dit voorbeeld leren we de kleurstijl van een willekeurige SmartArt‑vorm te wijzigen. In de volgende voorbeeldcode benaderen we de SmartArt‑vorm met een specifieke kleurstijl en passen we de stijl aan.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse en laad de presentatie met SmartArt‑vorm.
2. Verkrijg de referentie van de eerste dia via de Index.
3. Doorloop elke vorm binnen de eerste dia.
4. Controleer of de vorm van het type [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SmartArt) is en cast de geselecteerde vorm naar SmartArt indien het SmartArt is.
5. Zoek de SmartArt‑vorm met een specifieke kleurstijl.
6. Stel de nieuwe kleurstijl in voor de SmartArt‑vorm.
7. Sla de presentatie op.

```javascript
// Instantie van Presentation‑klasse
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Haal eerste dia op
    var slide = pres.getSlides().get_Item(0);
    // Doorloop elke vorm binnen de eerste dia
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Controleer of de vorm van het type SmartArt is
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Cast de vorm naar SmartArtEx
            var smart = shape;
            // Controle van SmartArt‑kleurtype
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Wijzigen van SmartArt‑kleurtype
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Presentatie opslaan
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figuur: SmartArt‑vorm met gewijzigde kleurstijl**|

## **FAQ**

**Kan ik SmartArt animeren als één object?**

Ja. SmartArt is een vorm, dus u kunt via de animaties‑API [standaardanimaties](/slides/nl/nodejs-java/powerpoint-animation/) toepassen (invoeren, verlaten, nadruk, bewegingspaden) net als bij andere vormen.

**Hoe kan ik een specifieke SmartArt op een dia vinden als ik de interne ID niet ken?**

Stel de Alternatieve Tekst (AltText) in en gebruik deze om te zoeken naar de vorm—dit is een aanbevolen manier om de gewenste vorm te vinden.

**Kan ik SmartArt groeperen met andere vormen?**

Ja. U kunt SmartArt groeperen met andere vormen (afbeeldingen, tabellen, enz.) en vervolgens de groep [behandelen](/slides/nl/nodejs-java/group/).

**Hoe krijg ik een afbeelding van een specifieke SmartArt (bijv. voor een preview of rapport)?**

Exporteer een miniatuur/afbeelding van de vorm; de bibliotheek kan [individuele vormen renderen](/slides/nl/nodejs-java/create-shape-thumbnails/) naar rasterbestanden (PNG/JPG/TIFF).

**Blijft het uiterlijk van SmartArt behouden bij het converteren van de gehele presentatie naar PDF?**

Ja. De renderengine streeft naar hoge getrouwheid voor [PDF-export](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/), met diverse kwaliteits- en compatibiliteitsopties.