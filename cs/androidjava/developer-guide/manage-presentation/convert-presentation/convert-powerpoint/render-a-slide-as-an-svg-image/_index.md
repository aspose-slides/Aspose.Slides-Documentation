---
title: Vykreslit snímky prezentace jako obrázky SVG na Androidu
linktitle: Snímek na SVG
type: docs
weight: 50
url: /cs/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint na SVG
- prezentace na SVG
- snímek na SVG
- PPT na SVG
- PPTX na SVG
- možnosti exportu SVG
- interaktivní SVG
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Exportujte snímky PowerPointu jako obrázky SVG na Androidu a pomocí Aspose.Slides řiďte písma, text, obrázky, ID a události."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se dobře hodí pro webové publikování, prohlížeče snímků, workflow přístupnosti a automatické post-processing. Aspose.Slides for Android via Java exportuje každou snímek do samostatného souboru SVG a umožňuje vám řídit, jak jsou zapisovány text, písma, obrázky a prvky SVG.  
Použijte [SVGOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/) , když exportované SVG musí být kompaktní, předvídatelné napříč prohlížeči nebo připravené pro interaktivní použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/), vyberte snímek a zapište jej do proudu pomocí [ISlide.writeAsSvg](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Následující příklad exportuje každý snímek v prezentaci do samostatného souboru SVG.

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

Název souboru používá [ISlide.getSlideNumber](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getSlideNumber--) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [IShape.writeAsSvg](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-), pokud prohlížeč snímků nebo webová stránka potřebuje jen tento tvar.

## **Konfigurovat výstup SVG**

[SVGOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/) řídí vykreslování SVG. Pro textové rámy [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) zahrnuje textový rám do oblasti vykreslování a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) určuje, zda se má aplikovat rotace rámu. Nastavte [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) na `true`, když musí být text vykreslen bez ligatur.

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

## **Řízení textu a písem**

### **Vektorizovat celý text**

Nastavte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) na `true`, aby byl celý text snímku zapisován jako vektorová grafika. Tím se odstraní závislosti na písmech a výsledek bude vizuálně konzistentnější napříč prohlížeči, avšak text již nebude možné v SVG vybrat ani vyhledávat.

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

### **Zvolte, jak jsou zpracovávána externí písma**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgexternalfontshandling/) pro písma načítaná externě. Zvolte [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgexternalfontshandling/) pro odkazování na samostatné soubory písem, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgexternalfontshandling/) pro vložení dat písem do SVG, nebo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgexternalfontshandling/) pro vykreslení pouze textu používajícího externí písma jako grafiky. Před vložením písem ověřte licencování písem.

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

## **Snížit velikost vložených obrázků**

Použijte [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) ke snížení rozlišení vložených obrázků, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) k vynechání oříznutých oblastí zdroje a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) ke kontrole kvality JPEG kódování. Tato nastavení zmenšují velikost souboru na úkor věrnosti obrazu nebo zachovaných dat obrázku.

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

Použijte [ISvgShapeFormattingController](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) k nastavení [ISvgShape.setId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) pro každý tvar SVG. Pro nastavení hodnot [ISvgTSpan.setId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) na elementech textu `tspan` rovněž implementujte [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Přidělte jeden z těchto kontrolerů pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Následující kontroler používá [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), který je stabilní po celou dobu existence tvaru, a opakovatelný čítač pro jeho textové spany. To činí generovaná ID vhodná pro post-processing nezměněné prezentace.

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

## **Přidat SVG událostní obslužné funkce**

V [ISvgShapeFormattingController](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) zavolejte [ISvgShape.setEventHandler](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) s hodnotou [SvgEvent](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgevent/) pro přidání JavaScriptového obslužného funkce události k exportovanému tvaru. Přidělte kontroler pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) a definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostuje.

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

Hostitelská stránka může definovat JavaScriptovou funkci odkazovanou obslužným prvkem. Přiřazování ID a obslužných funkcí událostí umožňuje prohlížeče snímků, vylepšení přístupnosti a další interaktivní SVG workflow.

## **Často kladené otázky**

**Kdy bych měl použít [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Použijte [SVGOptions.setVectorizeText], když musí být celý text nezávislý na písmech. Použijte [SvgExternalFontsHandling.Vectorize], když by měl být převáděn na grafiku pouze text, který používá externí písma.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním oříznutých oblastí obrázků a výběrem odkazovaných souborů písem, pokud cílové prostředí může tyto soubory poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravit exportované SVG elementy?**

Ano. Přidělte ID pomocí kontroleru formátování a poté vyberte odpovídající SVG elementy ve vašem post-processing nástroji nebo skriptu v prohlížeči.