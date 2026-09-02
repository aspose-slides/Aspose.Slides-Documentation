---
title: Vykreslete snímky prezentace jako SVG obrázky v Javě
linktitle: Snímek do SVG
type: docs
weight: 50
url: /cs/java/render-a-slide-as-an-svg-image/
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
- Java
- Aspose.Slides
description: "Exportujte snímky PowerPointu jako SVG obrázky v Javě a pomocí Aspose.Slides ovládejte písma, text, obrázky, ID a události."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který dobře funguje pro publikování na webu, prohlížeče snímků, workflow přístupnosti a automatické následné zpracování. Aspose.Slides exportuje každý snímek do zvláštního souboru SVG a umožňuje vám řídit, jak jsou zapisovány text, písma, obrázky a SVG prvky.

Použijte [SVGOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/) když exportované SVG musí být kompaktní, předvídatelné napříč prohlížeči nebo připravené pro interaktivní použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), vyberte snímek a zapište jej do proudu pomocí [ISlide.writeAsSvg](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Následující příklad exportuje každý snímek v prezentaci jako samostatný soubor SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

Název souboru používá [ISlide.getSlideNumber](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#getSlideNumber--) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [IShape.writeAsSvg](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-), když prohlížeč snímků nebo webová stránka potřebuje jen ten tvar.

## **Nastavit výstup SVG**

[SVGOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) zahrnuje textový rámec do oblasti vykreslování a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) určuje, zda se použije otáčení rámce. Nastavte [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) na `true`, když musí být text vykreslen bez ligatur.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Ovládání textu a písem**

### **Vectorize All Text**

Nastavte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) na `true`, aby byl veškerý text snímku zapsán jako vektorová grafika. Tím se odstraní závislost na písmu a vizuální výsledek je konzistentnější napříč prohlížeči, avšak text již není možné vybrat ani vyhledávat jako SVG text.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Choose How External Fonts Are Handled**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgexternalfontshandling/) pro písma načtená externě. Zvolte `AddLinksToFontFiles` pro odkazování na samostatné soubory písem, `Embed` pro zahrnutí dat písma do SVG, nebo `Vectorize` pro vykreslení pouze textu používajícího externí písma jako grafiky. Před vložením písem ověřte licencování písem.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Zmenšit velikost vložených obrázků**

Použijte [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) ke snížení rozlišení vložených obrázků, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) k vynechání oříznutých oblastí zdroje a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) k řízení kvality kódování JPEG. Tato nastavení zmenšují velikost souboru na úkor věrnosti obrazu nebo zachování dat obrázku.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Přiřadit stabilní ID tvarům a textu**

Použijte [ISvgShapeFormattingController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgshapeformattingcontroller/) k nastavení [ISvgShape.setId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) pro každý SVG tvar. Pro nastavení hodnot [ISvgTSpan.setId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) i u textových `tspan` prvků implementujte [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Přiřaďte kterýkoli z kontrolerů pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Následující kontroler používá [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové spany. To činí generovaná ID vhodnými pro následné zpracování nezměněné prezentace.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Přidat SVG událostní obslužné rutiny**

V [ISvgShapeFormattingController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgshapeformattingcontroller/) zavolejte [ISvgShape.setEventHandler](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) s hodnotou [SvgEvent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgevent/) pro přidání JavaScriptového obslužného rutiny události k exportovanému tvaru. Přiřaďte kontroler pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) a definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostí.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

Hostitelská stránka může definovat JavaScriptovou funkci, na kterou odkazuje obslužná rutina. Přiřazování ID a událostních obslužných rutin umožňuje prohlížečům snímků, vylepšení přístupnosti a další interaktivní SVG workflowy.

## **FAQ**

**Kdy bych měl použít [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgexternalfontshandling/)?**

Použijte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-), když musí být celý text nezávislý na písmu. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgexternalfontshandling/), když by měl být pouze text používající externí písma převeden na grafiku.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, mazáním oříznutých oblastí obrázků a výběrem odkazovaných souborů písem, pokud cílové prostředí může tyto soubory poskytovat. Otestujte výsledek, protože nižší rozlišení obrazu, nižší kvalita JPEG a vektorový text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravovat exportované SVG elementy?**

Ano. Přiřaďte ID pomocí formátovacího kontroleru a poté vyberte odpovídající SVG elementy ve vašem nástroji pro následné zpracování nebo v prohlížečovém skriptu.