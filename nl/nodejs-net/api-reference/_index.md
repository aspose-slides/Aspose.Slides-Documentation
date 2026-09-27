---
title: API-referentie
type: docs
weight: 50
url: /nl/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET wordt gedocumenteerd door de Aspose.Slides for .NET API-referentie. Bekijk hoe .NET-klassen- en ledennamen overeenkomen met JavaScript."
---
## **Overzicht**

Aspose.Slides for Node.js via .NET heeft geen eigen API‑referentie. Het pakket maakt de klassen van Aspose.Slides for .NET beschikbaar in JavaScript onder dezelfde namen, met camelCase‑leden, zodat de [Aspose.Slides for .NET API‑referentie](https://reference.aspose.com/slides/nl/net/) haar klassen, leden en enumeraties documenteert.

## **Koppel .NET-namen aan JavaScript**

Om een lid te gebruiken dat u in de .NET‑API‑referentie vindt, past u de volgende regels toe:

- **Klassen en enumeraties behouden hun .NET‑namen**, net als enumeratiewaarden: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Importeer ze uit het pakket: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Eigenschappen en methoden beginnen met een kleine letter.** `Presentation.Slides` wordt `presentation.slides`, en `ShapeCollection.AddAutoShape` wordt `shapes.addAutoShape`. Eigenschappen blijven eigenschappen: u leest en wijzigt ze zonder haakjes.
- **Collectie‑items worden gelezen met `get(index)`**, en het aantal items met `count`: `presentation.slides.get(0)` in plaats van `presentation.Slides[0]`.
- **Sommige overloads krijgen aparte namen.** Bijvoorbeeld, de overload `Slide.GetImage(Size)` is `slide.getImageWithImageSize({ width, height })`. Andere delen één methode met optionele trailing‑argumenten: `presentation.save(path, format, options, slides)` dekt verschillende `Presentation.Save`‑overloads, en `new Presentation(null, buffer)` opent een presentatie vanuit een `Buffer`. Elke klasse is één bestand onder de `lib`‑map van het pakket (bijvoorbeeld `node_modules/aspose.slides.via.net/lib/Slide.js`), waar u de exacte namen kunt opzoeken.
- **Maak presentaties vrij met `dispose`** wanneer u klaar bent; JavaScript kent geen `using`‑statement.

Het pakket wikkelt niet elk .NET‑lid in. Als een lid uit de .NET‑API‑referentie ontbreekt in het klasse‑bestand, is het niet beschikbaar in JavaScript.

## **Voorbeeld**

Het onderstaande script gebruikt de bovenstaande regels. Elke commentaarregel toont de .NET‑aanroep waarop de volgende regel is gebaseerd. Het voegt een rechthoek met tekst toe aan de eerste dia, rendert de dia als een PNG‑afbeelding van 960 × 540 pixels en slaat de presentatie op als PDF. Voer het uit vanuit een projectmap waarin het pakket is geïnstalleerd zoals beschreven in [Installatie](/slides/nl/nodejs-net/installation/).

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Het script schrijft `slide.png` en `slide.pdf` naar de huidige map. Beide tonen de rechthoek met zijn tekst. Zonder licentie tonen ze ook een evaluatiewatermerk; zie [Licentie](/slides/nl/nodejs-net/licensing/).

Voor details over de gebruikte leden, zie [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/text/) en [Slide.GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage/) in de Aspose.Slides for .NET API‑referentie.