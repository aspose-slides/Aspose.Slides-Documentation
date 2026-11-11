---
title: Rendera presentationsbilder som SVG‑bilder i JavaScript
linktitle: Bild till SVG
type: docs
weight: 50
url: /sv/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint till SVG
- presentation till SVG
- bild till SVG
- PPT till SVG
- PPTX till SVG
- SVG‑exportalternativ
- interaktiv SVG
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportera PowerPoint‑bilder som SVG‑bilder i JavaScript och kontrollera typsnitt, text, bilder, ID‑n och händelser med Aspose.Slides."
---
## **Översikt**

SVG är ett skalbart XML‑baserat bildformat som fungerar bra för webbpublicering, bildspelsvisare, tillgänglighetsarbetsflöden och automatiserad efterbehandling. Aspose.Slides for Node.js via Java exporterar varje bild till en separat SVG‑fil och låter dig styra hur text, teckensnitt, bilder och SVG‑element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) när den exporterade SVG:n måste vara kompakt, förutsägbar i olika webbläsare eller klar för interaktiv användning.

## **Exportera en bild som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), välj en bild och skriv den till en ström med [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Följande exempel exporterar varje bild i en presentation som en separat SVG‑fil.

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

Filnamnet använder [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) snarare än loopindexet. Du kan också exportera en enskild form med [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG‑utdata**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) styr SVG‑renderingen. För textramar inkluderar [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) textramen i renderingsområdet, och [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) bestämmer om ramrotationen appliceras. Ställ in [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) till `true` när text måste renderas utan ligaturer.

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

## **Styr beskärning av linjeändar vid pilspetsar**

SVG 1.1 har ingen marker‑inset‑inställning för att ange var en linje ska sluta under en pilspets. Som standard förkortar Aspose.Slides den exporterade linjen så att dess streck inte sticker ut genom markören. Anropa [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) med `true` för att rita strecket hela vägen till linjens ursprungliga slutpunkt. Denna inställning påverkar endast SVG‑utdata. Linjen behåller sin position och längd på bilden.

Exemplet ritar triangulära och diamant‑pilspetsar på linjer 2 och 10 punkter breda. Det exporterar samma bild två gånger, med endast beskärningsalternativet ändrat.

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

Jämförelsen visar den triangulära pilspetsen på 10‑punktslinjen. Med beskärning aktiverad är spetsen skarp. Med beskärning inaktiverad sticker strecket ut genom de snedställda sidorna av markören och lämnar en platt ände.

![Förstorad 10‑punkts triangel med en vass spets när beskärning är aktiverad och en platt ände när beskärning är inaktiverad](line-end-cropping.png)

I de andra linjerna i exemplet är det utskjutande strecket mindre synligt på 2‑punkts‑triangeln. Den fyllda diamanten täcker streckets ände vid båda bredderna.

## **Styr text och typsnitt**

När du exporterar bilder till SVG kan du kontrollera om text förblir som text eller konverteras till vektorgrafik, samt hur externa typsnitt inkluderas eller refereras. Följande alternativ hjälper dig att balansera visuell konsistens, textval och typsnittsberoenden i den exporterade SVG:n.

### **Vektorisera all text**

Ställ in [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) till `true` för att skriva all bildtext som vektorgrafik. Detta eliminerar typsnittsberoenden och gör det visuella resultatet mer konsekvent i olika webbläsare, men texten blir inte längre valbar eller sökbar som SVG‑text.

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

### **Välj hur externa typsnitt hanteras**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)‑värde för typsnitt som laddas externt. Välj `AddLinksToFontFiles` för att referera separata fontfiler, `Embed` för att inkludera fontdata i SVG:n, eller `Vectorize` för att rendera endast text som använder externa typsnitt som grafik. Verifiera fontlicenser innan du bäddar in typsnitt.

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

## **Minska storleken på inbäddade bilder**

Använd [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) för att reducera upplösningen på inbäddade bilder, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) för att utelämna beskurna källområden, och [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) för att styra JPEG‑kodningskvaliteten. Dessa inställningar minskar filstorleken på bekostnad av bildkvalitet eller bibehållen bilddata.

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

## **Styr rasteriseringsupplösning för metafil**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) sätter den lägre gränsen för upplösning när metafilers rasteriseras under SVG‑export. Använd den för att balansera detaljrikedom och filstorlek när en EMF‑ eller WMF‑bild rasteriseras. Den definierar inte en global DPI för SVG:n eller tvingar varje objekt på bilden att bli en rasterbild.

Ladda ner [metafile-rasterization.pptx](metafile-rasterization.pptx), som innehåller en EMF‑bild med tätt placerade diagonala linjer. Följande exempel exporterar dess första bild i tre rasteriseringsupplösningar via [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Alla andra exportinställningar förblir identiska så att resultaten kan jämföras.

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

I utdata blir EMF‑bilden en inbäddad PNG i varje SVG. Följande mått gäller för den medföljande presentationen; de är inte en generell formel för att konvertera DPI till pixelmått.

| Metafil rasteriserings‑DPI | Inbäddade PNG‑dimensioner | SVG‑filstorlek (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Jämförelsen nedan visar samma område av den inbäddade rasterbilderna i samma förstorade visningsstorlek. De diagonala linjerna visar synlig pixling vid 72 DPI och mjukare kanter vid högre upplösningar, medan SVG‑filen blir större. Att öka värdet förbättrar inte nödvändigtvis varje detalj eller förändrar varje exporterad bild.

![Förstorad diagonal linjedetalj vid 72, 150 och 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) styr bildupplösningsreduktion och kan maskera effekten av att ändra metafilens rasteriseringsupplösning. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) styr JPEG‑kodningskvalitet, inte rasteriseringsupplösning för metafil.

## **Tilldela stabila ID:n till former och text**

Skicka en formateringscontroller till [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) för att sätta [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) för varje SVG‑form. En controller som även hanterar textspänn kan sätta [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/)‑värden på text‑`tspan`‑element.

Följande controller använder [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), som är stabilt under formens livstid, och en återanvändbar räknare för dess textspänn. Detta gör de genererade ID:n lämpliga för efterbehandling av en oförändrad presentation.

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

## **Lägg till SVG‑händelsehanterare**

I en formateringscontroller, anropa [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) med ett [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/)‑värde för att lägga till en JavaScript‑händelsehanterare till en exporterad form. Tilldela controllern med [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) och definiera JavaScript‑funktionen i sidan eller SVG‑dokumentet som hostar resultatet.

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

Värdsidan kan definiera JavaScript‑funktionen som refereras av hanteraren. Att tilldela ID:n och händelsehanterare möjliggör bildvisare, tillgänglighetsförbättringar och andra interaktiva SVG‑arbetsflöden.

## **Vanliga frågor**

**När bör jag använda [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) istället för [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Använd [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) när all text måste vara oberoende av typsnitt. Använd [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) när endast text som använder externa typsnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade fontfiler när målmiljön kan leverera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektoriserad text alla har olika kvalitet‑ och storleksavvägningar.

**Kan jag ändra exporterade SVG‑element efter export?**

Ja. Tilldela ID:n via en formateringscontroller och välj sedan motsvarande SVG‑element i ditt efterbearbetningsverktyg eller browserskript.