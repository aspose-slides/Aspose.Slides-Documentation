---
title: Presentaties maken in JavaScript
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/nodejs-java/create-presentation/
keywords:
- presentatie maken
- nieuwe presentatie
- PPT maken
- nieuwe PPT
- PPTX maken
- nieuwe PPTX
- ODP maken
- nieuwe ODP
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak presentaties met Aspose.Slides—produceer PPT-, PPTX- en ODP-bestanden, profiteer van OpenDocument-ondersteuning en sla ze programmeermatig op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel laat zien hoe u een presentatie maakt in Aspose.Slides, een tekstvak toevoegt aan de eerste dia en het resultaat opslaat als bestand.

Voordat u begint, installeert u het `aspose.slides.via.java`‑pakket via npm, samen met de JDK, Python en C++‑build‑tools die het nodig heeft. Zie [Installation](/slides/nl/nodejs-java/installation/).

## **Een PowerPoint‑presentatie maken**

Om een presentatie te maken en een tekstvak op de eerste dia te plaatsen, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse. Een nieuwe presentatie bevat al één lege dia.
1. Haal die dia op uit de [slide collection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getslides/) via zijn index, 0.
1. Voeg een rechthoek toe met de [addAutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/addautoshape/)‑methode en stel de tekst in met [setText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/settext/).
1. Sla de presentatie op als een PPTX‑bestand met de [save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/save/)‑methode.
1. Vrijwaar de presentatie met de [dispose](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/dispose/)‑methode en beëindig het proces.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides draait in een Java virtual machine die Node.js draaiende houdt, dus beëindig het proces expliciet.
process.exit(0);
```

De linkerbovenhoek van de rechthoek bevindt zich 50 points van de linkerrand en 50 points van de bovenkant van de dia, en de rechthoek is 400 points breed en 100 points hoog. Sla de code op als *hello.js* in uw projectmap en voer `node hello.js` uit: dit slaat *hello.pptx* op, met één dia die die rechthoek en de bijbehorende tekst bevat, in de huidige map.

Aspose.Slides draait in een Java‑virtual machine die het `java`‑pakket start binnen het Node.js‑proces. Die virtual machine voorkomt dat Node.js vanzelf afsluit nadat het script is voltooid, zodat het voorbeeld eindigt met `process.exit(0)`.

Zonder licentie voegt Aspose.Slides ook een evaluatiewatermerk toe aan elke dia die wordt opgeslagen; zie [Licensing](/slides/nl/nodejs-java/licensing/).

## **FAQ**

### In welke formaten kan ik een nieuwe presentatie opslaan?

U kunt opslaan als [PPTX, PPT en ODP](/slides/nl/nodejs-java/save-presentation/), en exporteren naar [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/nl/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/nl/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/nl/nodejs-java/render-a-slide-as-an-svg-image/) en [images](/slides/nl/nodejs-java/convert-powerpoint-to-png/), onder andere.

### Kan ik beginnen met een sjabloon (POTX/POTM) en opslaan als een reguliere PPTX?

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en vergelijkbare formaten [are supported](/slides/nl/nodejs-java/supported-file-formats/).

### Hoe kan ik de dia‑grootte/beeldverhouding regelen bij het maken van een presentatie?

Stel de [slide size](/slides/nl/nodejs-java/slide-size/) in (inclusief presets zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud moet schalen.

### In welke eenheden worden afmetingen en coördinaten gemeten?

In points: 1 inch equals 72 units.

### Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugenverbruik te verminderen?

Gebruik [BLOB management strategies](/slides/nl/nodejs-java/manage-blob/), beperk de in‑memory opslag door tijdelijke bestanden te gebruiken, en geef de voorkeur aan bestand‑gebaseerde werkstromen boven puur in‑memory streams.

### Kan ik presentaties tegelijk maken/opslaan?

U kunt niet werken op dezelfde [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie vanuit [multiple threads](/slides/nl/nodejs-java/multithreading/). Start afzonderlijke, geïsoleerde instanties per thread of proces.

### Hoe verwijder ik het proef‑watermerk en de beperkingen?

[Apply a license](/slides/nl/nodejs-java/licensing/) één keer per proces. De licentie‑XML moet ongewijzigd blijven, en de licentie‑instelling moet gesynchroniseerd worden als meerdere threads betrokken zijn.

### Kan ik de PPTX die ik maak digitaal ondertekenen?

Ja. [Digital signatures](/slides/nl/nodejs-java/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

### Worden macro's (VBA) ondersteund in gemaakte presentaties?

Ja. U kunt [create/edit VBA projects](/slides/nl/nodejs-java/presentation-via-vba/) en macro‑ingeschakelde bestanden zoals PPTM/PPSM opslaan.