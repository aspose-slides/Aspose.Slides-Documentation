---
title: Presentatiedia's renderen als SVG-afbeeldingen in JavaScript
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
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in JavaScript en beheer lettertypen, tekst, afbeeldingen, ID's en gebeurtenissen met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar XML‑gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, slide‑viewers, toegankelijkheidsworkflows en geautomatiseerde nabewerking. Aspose.Slides voor Node.js via Java exporteert elke dia naar een apart SVG‑bestand en laat u bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden geschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) wanneer het geëxporteerde SVG compact, voorspelbaar in verschillende browsers, of klaar voor interactief gebruik moet zijn.

## **Export een dia als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), selecteer een dia en schrijf deze naar een stream met [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Het volgende voorbeeld exporteert elke dia in een presentatie naar een apart SVG‑bestand.

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

De bestandsnaam gebruikt [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) in plaats van de loop‑index. U kunt ook een afzonderlijke vorm exporteren met [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) wanneer een slide‑viewer of webpagina alleen die vorm nodig heeft.

## **Configureer SVG‑output**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) regelt de SVG‑rendering. Voor tekstkaders zorgt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) ervoor dat het tekstkader wordt meegenomen in het rendergebied, en [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) bepaalt of de rotatie van het kader wordt toegepast. Stel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) in op `true` wanneer tekst moet worden gerenderd zonder ligaturen.

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

## **Controleer tekst en lettertypen**

Bij het exporteren van dia's naar SVG kunt u bepalen of tekst als tekst behouden blijft of wordt geconverteerd naar vectorafbeeldingen, en hoe externe lettertypen worden opgenomen of verwezen. De volgende opties helpen u de visuele consistentie, tekstselectie en lettertype‑afhankelijkheden in het geëxporteerde SVG in balans te brengen.

### **Vectoriseer alle tekst**

Stel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) in op `true` om alle diatekst als vectorafbeeldingen te schrijven. Dit verwijdert lettertype‑afhankelijkheden en maakt het visuele resultaat consistenter in verschillende browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

### **Kies hoe externe lettertypen worden behandeld**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om afzonderlijke lettertypebestanden te refereren, `Embed` om lettertypegegevens in het SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als graphics te renderen. Controleer de licentie van het lettertype voordat u lettertypen insluit.

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

## **Verminder de grootte van ingesloten afbeeldingen**

Gebruik [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) om bijgesneden brongebieden weg te laten, en [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) om de JPEG‑codeerkwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van beeldfidelity of bewaarde afbeeldingsgegevens.

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

## **Controleer de rasterisatie‑resolutie van metabestanden**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) stelt de ondergrens voor de resolutie bij het rasteriseren van metafiles tijdens SVG‑export in. Gebruik deze instelling om detail en bestandsgrootte in balans te brengen wanneer een EMF‑ of WMF‑afbeelding wordt gerasterd. Het definieert geen globale DPI voor het SVG en dwingt niet elk object op de dia om een rasterafbeelding te worden.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), dat een EMF‑afbeelding bevat met dicht opeengepakte diagonale lijnen. Het volgende voorbeeld exporteert de eerste dia in drie rasterisatie‑resoluties via [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Alle andere exportinstellingen blijven gelijk zodat de resultaten kunnen worden vergeleken.

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

In de uitvoer is de EMF omgezet naar één ingesloten PNG in elk SVG. De volgende metingen gelden voor de meegeleverde presentatie; ze vormen geen algemene formule voor het omrekenen van DPI naar pixelafmetingen.

| Metafile rasterisatie DPI | Ingesloten PNG‑afmetingen | SVG‑bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De onderstaande vergelijking toont hetzelfde gebied van de ingesloten rasterafbeelding op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen zichtbare pixelatie bij 72 DPI en zachtere randen bij hogere resoluties, terwijl het SVG‑bestand groeit. Het verhogen van de waarde verbetert niet noodzakelijk elk detail of verandert elke geëxporteerde afbeelding.

![Uitvergrote diagonale‑lijndetails bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) beheert de vermindering van beeldresolutie en kan het effect van het wijzigen van de rasterisatie‑resolutie van metafiles maskeren. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) regelt de JPEG‑codeerkwaliteit, niet de rasterisatie‑resolutie van metafiles.

## **Wijs stabiele ID's toe aan vormen en tekst**

Geef een opmaakcontroller door aan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) om [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) voor elke SVG‑vorm in te stellen. Een controller die ook tekst‑spans verwerkt, kan [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) waarden op tekst‑`tspan`‑elementen instellen.

De volgende controller gebruikt [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), die gedurende de levensduur van de vorm stabiel is, en een herhaalbare teller voor de tekst‑spans. Dit maakt de gegenereerde ID's geschikt voor nabewerking van een onveranderde presentatie.

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

## **Voeg SVG‑event‑handlers toe**

In een opmaakcontroller, roep [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) aan met een [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) waarde om een JavaScript‑event‑handler aan een geëxporteerde vorm toe te voegen. Wijs de controller toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) en definieer de JavaScript‑functie in de pagina of SVG‑document dat het resultaat host.

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

De host‑pagina kan de door de handler gerefereerde JavaScript‑functie definiëren. Het toewijzen van ID's en event‑handlers maakt slide‑viewers, toegankelijkheidsverbeteringen en andere interactieve SVG‑workflows mogelijk.

## **FAQ**

**Wanneer moet ik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Gebruik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt naar graphics moet worden geconverteerd.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden beeldgebieden en het kiezen van gelinkte lettertypebestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat een lagere beeldresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst elk verschillende kwaliteits‑ en grootte‑afwegingen hebben.

**Kan ik geëxporteerde SVG‑elementen na export wijzigen?**

Ja. Wijs ID's toe via een opmaakcontroller en selecteer vervolgens de overeenkomende SVG‑elementen in uw nabewerkings‑tool of browserscript.