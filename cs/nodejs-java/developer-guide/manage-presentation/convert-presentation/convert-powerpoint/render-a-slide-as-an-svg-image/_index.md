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
description: "Exportujte snímky PowerPoint jako SVG obrázky v JavaScriptu a ovládejte písma, text, obrázky, ID a události pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se dobře hodí pro webové publikování, prohlížeče snímků, workflow přístupnosti a automatické post-processing. Aspose.Slides pro Node.js přes Java exportuje každý snímek do samostatného souboru SVG a umožňuje řídit, jak jsou zapisovány text, písma, obrázky a prvky SVG.

Použijte [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) když exportované SVG musí být kompaktní, předvídatelné napříč prohlížeči nebo připravené pro interaktivní použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), vyberte snímek a zapište jej do proudu pomocí [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Následující příklad exportuje každý snímek v prezentaci jako samostatný soubor SVG.

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

Název souboru používá [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/), pokud prohlížeč snímků nebo webová stránka potřebuje jen tento tvar.

## **Nastavit výstup SVG**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) zahrnuje textový rámec do oblasti vykreslování a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) určuje, zda se uplatní otáčení rámce. Nastavte [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `true`, když text musí být vykreslen bez ligatur.

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

## **Řídit text a písma**

Při exportu snímků do SVG můžete řídit, zda text zůstane jako text nebo bude převeden na vektorovou grafiku, a jak jsou zahrnuta nebo odkazována externí písma. Následující možnosti vám pomohou vyvážit vizuální konzistenci, výběr textu a závislosti na písmu v exportovaném SVG.

### **Vektorizovat celý text**

Nastavte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) na `true`, aby byl veškerý text snímku zapisován jako vektorová grafika. Tím se odstraní závislosti na písmu a výsledek bude vizuálně konzistentnější napříč prohlížeči, avšak text již nebude možné vybrat ani vyhledat jako SVG text.

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

### **Zvolte, jak zacházet s externími písmy**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) pro písma načítaná externě. Zvolte `AddLinksToFontFiles` pro odkazování na samostatné soubory písem, `Embed` pro zahrnutí dat písma do SVG, nebo `Vectorize` pro vykreslení jen textu, který používá externí písma, jako grafiku. Před vložením písem ověřte licencování písem.

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

Použijte [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) ke snížení rozlišení vložených obrázků, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) k vynechání oříznutých částí zdrojových obrázků a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) ke kontrole kvality JPEG kódování. Tato nastavení snižují velikost souboru na úkor kvality obrazu nebo zachování dat obrázku.

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

## **Řídit rozlišení rasterizace metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) nastavuje dolní limit rozlišení pro rasterizaci metafile během exportu SVG. Použijte jej k vyvážení detailů a velikosti souboru, když je rasterizován obraz EMF nebo WMF. Nedefinuje globální DPI pro SVG ani nevede k tomu, aby se každý objekt na snímku stal rastrovým obrázkem.

Stáhněte [metafile-rasterization.pptx](metafile-rasterization.pptx), který obsahuje EMF obrázek s těsně umístěnými úhlopříčnými čarami. Následující příklad exportuje první snímek při třech rozlišeních rasterizace pomocí [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Všechna ostatní nastavení exportu zůstávají identická, aby bylo možné výsledky porovnat.

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

Ve výstupu se EMF stal jedním vloženým PNG v každém SVG. Následující měření jsou pro dodanou prezentaci; nejedná se o obecný vzorec pro převod DPI na rozměry v pixelech.

| DPI rasterizace metafile | Rozměry vloženého PNG | Velikost souboru SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Srovnání níže ukazuje stejnou oblast vloženého rastrového obrazu při stejném zvětšeném zobrazovacím rozměru. Úhlopříčné čáry vykazují viditelnou pixelaci při 72 DPI a hladší hrany při vyšších rozlišeních, zatímco velikost SVG souboru roste. Zvýšení hodnoty nemusí nutně vylepšit každý detail ani změnit každý exportovaný obrázek.

![Zvětšený detail úhlopříčkové čáry při 72, 150 a 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) řídí snížení rozlišení obrázku a může maskovat vliv změny rozlišení rasterizace metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) řídí kvalitu kódování JPEG, nikoli rozlišení rasterizace metafile.

## **Přiřadit stabilní ID tvarům a textu**

Předávejte formátovací kontroler metodě [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/), aby nastavil [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) pro každý SVG tvar. Kontroler, který také zpracovává textové úseky, může nastavit hodnoty [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) u textových elementů `tspan`.

Následující kontroler používá [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové úseky. To činí generovaná ID vhodnými pro post-processing nezměněné prezentace.

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

## **Přidat SVG obslužné rutiny událostí**

V rámci formátovacího kontroleru zavolejte [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) s hodnotou [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/), abyste přidali JavaScriptový obslužný rutin události k exportovanému tvaru. Přiřaďte kontroler pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) a definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostuje.

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

Hostitelská stránka může definovat JavaScriptovou funkci odkazovanou obslužným rutinem. Přiřazování ID a obslužných rutin událostí umožňuje prohlížeče snímků, vylepšení přístupnosti a další interaktivní SVG workflow.

## **Často kladené otázky**

**Kdy mám použít [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Použijte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/), když celý text musí být nezávislý na písmu. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/), když má být pouze text používající externí písma převeden na grafiku.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, mazáním oříznutých částí obrázků a volbou odkazovaných souborů písem, pokud cílové prostředí může takové soubory poskytovat. Otestujte výsledek, protože nižší rozlišení obrazu, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravovat exportované SVG elementy?**

Ano. Přiřaďte ID pomocí formátovacího kontroleru a poté vyberte odpovídající SVG elementy ve vašem nástroji pro post-processing nebo v skriptu prohlížeče.