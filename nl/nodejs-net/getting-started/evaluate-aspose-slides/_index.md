---
title: Evalueer Aspose.Slides
type: docs
weight: 120
url: /nl/nodejs-net/evaluate-aspose-slides/
keywords:
- evalueer Aspose.Slides
- evaluatieversie
- evaluatiewatermerk
- beperkingen van de proefversie
- tijdelijke licentie
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Wat de evaluatieversie van Aspose.Slides voor Node.js via .NET beperkt, met een script dat beide beperkingen laat zien en hoe u ze met een licentie kunt verwijderen."
---
## **Overzicht**

De evaluatieversie van Aspose.Slides voor Node.js via .NET is hetzelfde npm‑pakket als de gelicentieerde versie. Zonder licentie draait het in evaluatiemodus: elke functie werkt, maar opgeslagen presentaties en de meeste exports bevatten een watermerk, en tekst die uw code terugleest wordt afgekapt. Dit artikel beschrijft beide beperkingen en laat zien hoe u ze kunt verwijderen.

## **Evaluatiebeperkingen**

**Een evaluatiewatermerk op elke dia.** Wanneer u een presentatie opslaat zonder licentie, voegt Aspose.Slides een tekstvak toe in het midden van elke dia van het opgeslagen bestand. Het tekstvak is vergrendeld en bevat de tekst "Evaluation only." gevolgd door een productregel en een copyright‑regel. Het watermerk wordt in het opgeslagen bestand geplaatst, niet in de presentatie in het geheugen, en het openen van een presentatie voegt er geen toe. Een bestand dat al in evaluatiemodus is opgeslagen, bevat echter al het tekstvak, dus bij het opnieuw openen en opslaan wordt er een tweede watermerk aan elke dia toegevoegd.

Hetzelfde watermerk wordt getekend op de uitvoer wanneer u exporteert naar PDF, XPS of HTML, of dia's rendert als afbeeldingen. Als u een presentatie rendert die al in evaluatiemodus is opgeslagen, toont de afbeelding zowel het opgeslagen watermerk als het gerenderde.

**Afgekorte tekst wanneer uw code deze leest.** Tekst die uw code leest via de `text`‑eigenschap van een tekstframe, alinea of deel wordt afgekapt tot de eerste vijf tekens, gevolgd door de melding "... text has been truncated due to evaluation version limitation." Tekst van vijf tekens of minder wordt volledig geretourneerd. Dit geldt voor elke dia, en zelfs voor tekst die uw code zojuist heeft toegewezen. Markdown‑ en HTML5‑exports worden op dezelfde manier afgekapt.

De tekst die uw code schrijft, wordt volledig opgeslagen: PPTX‑bestanden, PDF‑pagina's en dia‑afbeeldingen bevatten de volledige tekst.

## **Bekijk de beperkingen in een script**

Het volgende script toont beide beperkingen. Het gaat er vanuit dat u het pakket hebt geïnstalleerd zoals beschreven in [Installatie](/slides/nl/nodejs-net/installation/) en dat u het uitvoert vanuit de projectmap. Het voegt een rechthoek met een zin toe aan de eerste dia, leest de zin terug, slaat de presentatie op als `evaluation.pptx`, en opent vervolgens het bestand opnieuw om de vormen op de dia te tellen.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Zonder licentie worden alleen de eerste vijf tekens geretourneerd.
    console.log("Text read back:", rectangle.textFrame.text);

    // Opslaan voegt het evaluatiewatermerk toe aan elke dia van het bestand.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // De dia bevat nu de rechthoek en het watermerk‑tekstvak.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Zonder licentie geeft het script het volgende weer:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

De tweede vorm is het watermerk‑tekstvak. Open `evaluation.pptx` om de volledige zin in de rechthoek en het watermerk in het midden van de dia te zien.

## **Verwijder de beperkingen**

Om beide beperkingen te verwijderen, past u een licentie toe voordat u een `Presentation`‑object maakt. [Licentiëring](/slides/nl/nodejs-net/licensing/) laat zien hoe u een licentiebestand toepast.

{{% alert color="success" title="Tip" %}}
Om Aspose.Slides te testen zonder de evaluatiebeperkingen voordat u koopt, vraag een gratis **30‑daagse tijdelijke licentie** aan. Zie [Hoe krijg ik een tijdelijke licentie?](https://purchase.aspose.com/temporary-license) voor meer details.
{{% /alert %}}

## **FAQ**

**Beperkt de evaluatiemodus het aantal dia's?**  
Nee. Presentaties worden aangemaakt, geopend en opgeslagen met al hun dia's. Het watermerk en de afkap‑functionaliteit gelden voor elke dia.

**Waarom tonen mijn geëxporteerde dia‑afbeeldingen het watermerk twee keer?**  
De presentatie was opgeslagen in evaluatiemodus voordat u deze renderde, dus bevat ze al een watermerk‑tekstvak, en renderen zonder licentie tekent er nog een bovenop.

**Kan ik controleren of mijn code de juiste tekst produceert in evaluatiemodus?**  
Ja. Open het opgeslagen bestand of de geëxporteerde PDF: ze bevatten de volledige tekst. Alleen de tekst die uw code terugleest, en Markdown‑ of HTML5‑output, wordt afgekapt.