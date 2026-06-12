---
title: "Animeer PowerPoint-tekst in JavaScript"
linktitle: "Geanimeerde tekst"
type: docs
weight: 60
url: /nl/nodejs-java/animated-text/
keywords:
- geanimeerde tekst
- tekstanimatie
- geanimeerde alinea
- alinea-animatie
- animatie-effect
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak dynamische geanimeerde tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js, met gemakkelijk te volgen, geoptimaliseerde codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u werkt met geanimeerde tekst in Aspose.Slides door animatie‑effecten toe te passen op individuele alinea’s en de al reeds toegewezen effecten aan alinea’s in een tekstvak op te halen. Het richt zich op de API‑methoden die worden gebruikt om animatie op alinea‑niveau toe te voegen en bestaande animatie‑effecten van alinea’s in een presentatie te inspecteren.

## **Animatie‑effecten toevoegen aan alinea’s**

We hebben de [**addEffect()**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) methode toegevoegd aan de [**Sequence**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Sequence) en [**Sequence**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Sequence) klassen. Deze methode stelt u in staat animatie‑effecten toe te voegen aan één alinea. Deze voorbeeldcode laat zien hoe u een animatie‑effect toevoegt aan één alinea:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // selecteer alinea om effect toe te voegen
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // voeg Fly animatie-effect toe aan geselecteerde alinea
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Animatie‑effecten ophalen in alinea’s**

U kunt besluiten de animatie‑effecten die aan een alinea zijn toegevoegd te achterhalen — bijvoorbeeld in één scenario wilt u de animatie‑effecten in een alinea ophalen omdat u die wilt toepassen op een andere alinea of vorm. Aspose.Slides for Node.js via Java stelt u in staat alle animatie‑effecten op te halen die zijn toegepast op alinea’s die zich in een tekstvak (vorm) bevinden. Deze voorbeeldcode laat zien hoe u de animatie‑effecten in een alinea kunt ophalen:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**Hoe verschillen tekstananimaties van dia‑overgangen, en kunnen ze gecombineerd worden?**

Tekstananimaties regelen het gedrag van een object in de tijd op een dia, terwijl [overgangen](/slides/nl/nodejs-java/slide-transition/) bepalen hoe dia’s veranderen. Ze zijn onafhankelijk van elkaar en kunnen samen worden gebruikt; de afspeelvolgorde wordt bepaald door de animatietijdlijn en de overgangsinstellingen.

**Worden tekstananimaties behouden bij het exporteren naar PDF of afbeeldingen?**

Nee. PDF‑bestanden en raster‑afbeeldingen zijn statisch, dus u ziet slechts één toestand van de dia zonder beweging. Om de beweging te behouden, exporteer naar [video](/slides/nl/nodejs-java/convert-powerpoint-to-video/) of [HTML](/slides/nl/nodejs-java/export-to-html5/).

**Werken tekstananimaties in lay‑outs en de dia‑master?**

Effecten die op layout‑/master‑objecten worden toegepast, worden geërfd door dia’s, maar hun timing en interactie met animaties op dia‑niveau hangen af van de uiteindelijke volgorde op de dia.