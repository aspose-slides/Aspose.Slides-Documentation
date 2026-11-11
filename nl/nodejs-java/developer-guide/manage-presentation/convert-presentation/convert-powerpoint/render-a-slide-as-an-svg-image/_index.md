---
title: Presentatieslides renderen als SVG-afbeeldingen in JavaScript
linktitle: Dia naar SVG
type: docs
weight: 50
url: /nl/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- dia naar SVG
- PPT naar SVG
- PPTX naar SVG
- SVG-exportopties
- interactieve SVG
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in JavaScript en beheer lettertypen, tekst, afbeeldingen, ID's en events met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar XML-gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, diaweergaven, toegankelijkheidsworkflows en geautomatiseerde nabewerking. Aspose.Slides voor Node.js via Java exporteert elke dia naar een afzonderlijk SVG-bestand en stelt u in staat te bepalen hoe tekst, lettertypen, afbeeldingen en SVG-elementen worden geschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) wanneer de geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactief gebruik.

## **Een dia exporteren als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), selecteer een dia en schrijf deze naar een stream met [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Het onderstaande voorbeeld exporteert elke dia in een presentatie als een afzonderlijk SVG-bestand.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

De bestandsnaam gebruikt [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) in plaats van de lusindex. U kunt ook een individuele vorm exporteren met [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) wanneer een diaweergave of webpagina alleen die vorm nodig heeft.

## **SVG-uitvoer configureren**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) regelt de SVG-rendering. Voor tekstkaders omvat [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) het tekstkader in het weergavegebied, en [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) bepaalt of de rotatie van het kader wordt toegepast. Stel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) in op `true` wanneer tekst zonder ligaturen moet worden gerenderd.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Lijneinde bijsnijden bij pijlpuntjes**

SVG 1.1 heeft geen marker-inset-instelling om te specificeren waar een lijn moet stoppen onder een pijlpunt. Standaard verkort Aspose.Slides de geëxporteerde lijn zodat de lijnbreedte niet door de marker heen steekt. Roep [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) aan met `true` om de lijnbreedte helemaal tot het oorspronkelijke eindpunt van de lijn te tekenen. Deze instelling heeft alleen invloed op de SVG-output. De lijn behoudt zijn positie en lengte op de dia.

Het voorbeeld tekent driehoek- en ruit-pijlpuntjes op lijnen van respectievelijk 2 en 10 punten breed. Het exporteert dezelfde dia twee keer, waarbij alleen de bijsnijd-optie wordt gewijzigd.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    let y = 40;

    for (const style of [slides.LineArrowheadStyle.Triangle, slides.LineArrowheadStyle.Diamond]) {
        for (const width of [2, 10]) {
            const line = slide.getShapes().addAutoShape(slides.ShapeType.Line, 40, y, 200, 0);
            const format = line.getLineFormat();
            format.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
            format.getFillFormat().getSolidFillColor().setColor(lineColor);
            format.setWidth(width);
            format.setEndArrowheadStyle(java.newByte(style));
            y += 50;
        }
    }

    const options = new slides.SVGOptions();
    options.setDisableLineEndCropping(false);
    const cropped = java.newInstanceSync("java.io.FileOutputStream", "cropped.svg");
    try {
        slide.writeAsSvg(cropped, options);
    } finally {
        cropped.close();
    }

    options.setDisableLineEndCropping(true);
    const uncropped = java.newInstanceSync("java.io.FileOutputStream", "uncropped.svg");
    try {
        slide.writeAsSvg(uncropped, options);
    } finally {
        uncropped.close();
    }
} finally {
    presentation.dispose();
}
```

De vergelijking toont de driehoekige pijlpunt op de 10-punt-lijn. Met bijsnijden ingeschakeld is de punt scherp. Met bijsnijden uitgeschakeld steekt de lijnbreedte door de schuine zijden van de marker en blijft er een platte uiteinde.

![Vergrote driehoek van 10 punten met een scherpe top wanneer bijsnijden is ingeschakeld en een platte onderkant wanneer bijsnijden is uitgeschakeld](line-end-cropping.png)

In de andere lijnen uit het voorbeeld is de uitstekende lijnbreedte minder zichtbaar op de 2-punt-driehoek. De gevulde ruit bedekt het uiteinde van de lijnbreedte bij beide breedtes.

## **Tekst en lettertypen regelen**

Bij het exporteren van dia's naar SVG kunt u bepalen of tekst als tekst blijft of wordt omgezet naar vector-graphics, en hoe externe lettertypen worden opgenomen of gerefereerd. De volgende opties helpen u de visuele consistentie, tekste selecteerbaarheid en lettertype-afhankelijkheden in de geëxporteerde SVG in balans te brengen.

### **Alle tekst vectoriseren**

Stel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) in op `true` om alle diatekst als vector-graphics te schrijven. Dit elimineert lettertype-afhankelijkheden en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG-tekst.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **Kiezen hoe externe lettertypen worden afgehandeld**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om afzonderlijke lettertypebestanden te refereren, `Embed` om lettertype-data in de SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als graphics te renderen. Controleer de licentie van het lettertype voordat u lettertypen embedt.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Ingesloten afbeeldingsgrootte verkleinen**

Gebruik [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) om bijgesneden brongebieden weg te laten, en [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) om de JPEG-codeerkwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van de beeldfidelity of bewaarde afbeeldingsdata.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Resolutie van metabestand‑rasterisatie regelen**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) stelt de ondergrens van de resolutie in voor het rasteren van metabestanden tijdens SVG-export. Gebruik dit om detail en bestandsgrootte in balans te houden wanneer een EMF- of WMF-afbeelding wordt gerasterd. Het definieert geen globale DPI voor de SVG en dwingt niet elk object op de dia om een rasterafbeelding te worden.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), dat een EMF-afbeelding bevat met nauw opeengepakte diagonale lijnen. Het onderstaande voorbeeld exporteert de eerste dia ervan met drie rasterisatie-resoluties via [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Alle andere exportinstellingen blijven identiek zodat de resultaten kunnen worden vergeleken.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

In de output is de EMF één ingesloten PNG geworden in elke SVG. De onderstaande metingen gelden voor de meegeleverde presentatie; ze vormen geen algemene formule voor het omrekenen van DPI naar pixelafmetingen.

| Metabestand rasterisatie DPI | Ingesloten PNG-afmetingen | SVG‑bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De vergelijking hieronder toont hetzelfde gebied van de ingesloten rasterafbeelding op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen zichtbare pixelatie bij 72 DPI en gladdere randen bij hogere resoluties, terwijl het SVG‑bestand groter wordt. Het verhogen van de waarde verbetert niet per definitie elk detail of wijzigt elke geëxporteerde afbeelding.

![Vergrote diagonale lijndetail bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) regelt de reductie van de beeldresolutie en kan het effect van het wijzigen van de metafile‑rasterisatie‑resolutie maskeren. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) regelt de JPEG-codeerkwaliteit, niet de metafile‑rasterisatie‑resolutie.

## **Stabiele ID's toewijzen aan vormen en tekst**

Geef een formatteringscontroller door aan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) om [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) voor elke SVG‑vorm in te stellen. Een controller die tevens tekst-spans afhandelt, kan waarden voor [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) op tekst-`tspan`-elementen instellen.

De onderstaande controller gebruikt [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), die stabiel is gedurende de levensduur van de vorm, en een herhaalbare teller voor zijn tekst-spans. Dit maakt de gegenereerde ID's geschikt voor post-processing van een onveranderde presentatie.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **SVG‑eventhandlers toevoegen**

In een formatteringscontroller roept u [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) aan met een [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/)‑waarde om een JavaScript‑eventhandler toe te voegen aan een geëxporteerde vorm. Wijs de controller toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) en definieer de JavaScript-functie in de pagina of het SVG-document dat het resultaat host.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

De host-pagina kan de door de handler gerefererde JavaScript-functie definiëren. Het toewijzen van ID's en event-handlers maakt dia-viewers, toegankelijkheidsverbeteringen en andere interactieve SVG-workflows mogelijk.

## **FAQ**

**Wanneer moet ik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Gebruik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar graphics.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeelding-gebieden, en het kiezen van gekoppelde lettertypebestanden wanneer de doelomgeving ze kan serveren. Test het resultaat omdat een lagere afbeeldingsresolutie, lagere JPEG-kwaliteit en gevectoriseerde tekst elk verschillende kwaliteits- en grootte-afwegingen hebben.

**Kan ik geëxporteerde SVG-elementen na export aanpassen?**

Ja. Wijs ID's toe via een formatteringscontroller en selecteer vervolgens de overeenkomstige SVG-elementen in uw post-processing-tool of browserscript.