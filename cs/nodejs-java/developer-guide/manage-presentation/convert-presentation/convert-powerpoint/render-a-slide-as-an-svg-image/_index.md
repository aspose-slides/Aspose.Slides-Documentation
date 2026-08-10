---
title: Vykreslit snímky prezentace jako SVG obrázky v JavaScriptu
linktitle: Snímek do SVG
type: docs
weight: 50
url: /cs/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentace do SVG
- snímek do SVG
- PPT do SVG
- PPTX do SVG
- Možnosti exportu SVG
- interaktivní SVG
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportujte snímky PowerPointu jako SVG obrázky v JavaScriptu a pomocí Aspose.Slides ovládejte písma, text, obrázky, ID a události."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se dobře hodí pro webové publikování, prohlížeče snímků, workflow přístupnosti a automatické následné zpracování. Aspose.Slides pro Node.js přes Java exportuje každý snímek do samostatného souboru SVG a umožňuje řídit, jak jsou zapisovány text, písma, obrázky a SVG prvky.

Použijte [SVGOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/) pokud exportované SVG musí být kompaktní, předvídatelné napříč prohlížeči nebo připravené pro interaktivní použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/), vyberte snímek a zapište jej do proudu pomocí [Slide.writeAsSvg](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/writeassvg/). Následující příklad exportuje každý snímek v prezentaci jako samostatný soubor SVG.

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

Název souboru používá [Slide.getSlideNumber](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/getslidenumber/) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [Shape.writeAsSvg](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/writeassvg/), pokud prohlížeč snímků nebo webová stránka potřebuje jen tento tvar.

## **Konfigurovat výstup SVG**

[SVGOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/setuseframesize/) zahrnuje textový rámec do vykreslovací oblasti a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) určuje, zda se aplikuje rotace rámce. Nastavte [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `true`, když text musí být vykreslen bez ligatur.

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

## **Ovládání textu a písem**

### **Vektorizovat celý text**

Nastavte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) na `true`, aby byl celý text snímku zapsán jako vektorová grafika. Tím se odstraní závislosti na písem a výsledek bude vizuálně konzistentnější napříč prohlížeči, ale text již nebude možné vybírat ani prohledávat jako SVG text.

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

### **Zvolte, jak zacházet s externími fonty**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgexternalfontshandling/) pro písma načítaná externě. Zvolte `AddLinksToFontFiles` pro odkaz na samostatné soubory písem, `Embed` pro zahrnutí dat písma do SVG, nebo `Vectorize` pro vykreslení pouze textu používajícího externí písma jako grafiku. Před vložením písem ověřte licencování písem.

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

## **Snížit velikost vložených obrázků**

Použijte [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) ke snížení rozlišení vložených obrázků, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) k vynechání oříznutých zdrojových oblastí a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/setjpegquality/) ke kontrole kvality JPEG kódování. Tato nastavení snižují velikost souboru na úkor kvality obrazu nebo zachování dat obrázku.

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

## **Přiřadit stabilní ID tvarům a textu**

Předávejte řadič formátování do [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/), aby bylo nastaveno [SvgShape.setId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgshape/setid/) pro každý SVG tvar. Řadič, který také zpracovává textové úseky, může nastavit hodnoty [SvgTSpan.setId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgtspan/setid/) na elementy textu `tspan`.

Následující řadič používá [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové úseky. To činí generovaná ID vhodná pro následné zpracování nezměněné prezentace.

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

## **Přidat SVG událostní zpracovatele**

V řadiči formátování zavolejte [SvgShape.setEventHandler](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgshape/seteventhandler/) s hodnotou [SvgEvent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgevent/), abyste přidali JavaScriptový událostní zpracovatel k exportovanému tvaru. Přiřaďte řadič pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) a definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostí.

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

Hostitelská stránka může definovat JavaScriptovou funkci odkazovanou zpracovatelem. Přiřazování ID a událostních zpracovatelů umožňuje prohlížeče snímků, vylepšení přístupnosti a další interaktivní SVG workflowy.

## **Často kladené otázky**

**Kdy bych měl použít [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) namísto [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Použijte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/setvectorizetext/), když veškerý text musí být nezávislý na písmě. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgexternalfontshandling/), když by měl být převáděn na grafiku pouze text, který používá externí písma.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraňováním oříznutých oblastí obrázků a výběrem odkazovaných souborů písem, pokud cílové prostředí může tyto soubory poskytovat. Otestujte výsledek, protože nižší rozlišení obrazu, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravovat exportované SVG elementy?**

Ano. Přiřaďte ID pomocí řadiče formátování a poté vyberte odpovídající SVG elementy ve vašem nástroji pro následné zpracování nebo skriptu v prohlížeči.