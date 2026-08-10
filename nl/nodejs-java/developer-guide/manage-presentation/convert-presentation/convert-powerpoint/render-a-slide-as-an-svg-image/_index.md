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

SVG is een schaalbaar, op XML gebaseerd imageformaat dat goed werkt voor webpublicatie, diaviewers, toegankelijkheidsworkflows en geautomatiseerde nabewerking. Aspose.Slides voor Node.js via Java exporteert elke dia naar een afzonderlijk SVG‑bestand en stelt u in staat te bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/) wanneer de geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactief gebruik.

## **Export een dia als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/), selecteer een dia en schrijf deze naar een stream met [Slide.writeAsSvg](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/writeassvg/). Het onderstaande voorbeeld exporteert elke dia in een presentatie als een afzonderlijk SVG‑bestand.

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

De bestandsnaam gebruikt [Slide.getSlideNumber](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/getslidenumber/) in plaats van de lus‑index. U kunt ook een individuele vorm exporteren met [Shape.writeAsSvg](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/writeassvg/) wanneer een diaviewer of webpagina slechts die vorm nodig heeft.

## **Configureer SVG‑uitvoer**

[SVGOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/) beheert de SVG‑rendering. Voor tekstkaders zorgt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/setuseframesize/) ervoor dat het tekstkader wordt meegenomen in het rendergebied, en [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) bepaalt of de rotatie van het kader wordt toegepast. Stel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) in op `true` wanneer tekst zonder ligaturen moet worden gerenderd.

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

## **Beheer tekst en lettertypen**

### **Vectoriseer alle tekst**

Stel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) in op `true` om alle dia‑tekst als vectorafbeeldingen te schrijven. Dit elimineert afhankelijkheden van lettertypen en zorgt voor een consistenter visueel resultaat over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

### **Kies hoe externe lettertypen worden afgehandeld**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgexternalfontshandling/)-waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om naar afzonderlijke font‑bestanden te verwijzen, `Embed` om lettertype‑data in de SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als grafieken te renderen. Controleer de licentie van het lettertype voordat u het insluit.

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

Gebruik [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) om bijgesneden brongebieden weg te laten, en [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/setjpegquality/) om de JPEG‑compressiekwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van beeldkwaliteit of behouden afbeeldingsdata.

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

## **Ken stabiele ID’s toe aan vormen en tekst**

Geef een formatteringscontroller door aan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) om [SvgShape.setId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgshape/setid/) in te stellen voor elke SVG‑vorm. Een controller die ook tekst‑spans verwerkt kan waarden voor [SvgTSpan.setId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgtspan/setid/) toewijzen aan tekst‑`tspan`‑elementen.

De onderstaande controller gebruikt [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), dat gedurende de levensduur van de vorm stabiel is, en een herhaalbare teller voor de bijbehorende tekst‑spans. Hiermee zijn de gegenereerde ID’s geschikt voor post‑processing van een ongewijzigde presentatie.

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

## **Voeg SVG‑eventhandlers toe**

Roep in een formatteringscontroller [SvgShape.setEventHandler](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgshape/seteventhandler/) aan met een [SvgEvent](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgevent/)-waarde om een JavaScript‑eventhandler toe te voegen aan een geëxporteerde vorm. Koppel de controller met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) en definieer de JavaScript‑functie in de pagina of het SVG‑document dat het resultaat host.

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

De host‑pagina kan de door de handler gerefereerde JavaScript‑functie definiëren. Het toewijzen van ID’s en eventhandlers maakt interactieve SVG‑workflows mogelijk in diaviewers, toegankelijkheidsverbeteringen en andere scenario’s.

## **FAQ**

**Wanneer moet ik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Gebruik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar grafieken.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden beeldgebieden, en het kiezen van gelinkte font‑bestanden wanneer de doel‑omgeving ze kan leveren. Test het resultaat omdat een lagere afbeeldingsresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst elk een andere afweging tussen kwaliteit en grootte opleveren.

**Kan ik geëxporteerde SVG‑elementen na export aanpassen?**

Ja. Ken ID’s toe via een formatteringscontroller, selecteer daarna de overeenkomstige SVG‑elementen in uw post‑processing‑tool of browserscript.