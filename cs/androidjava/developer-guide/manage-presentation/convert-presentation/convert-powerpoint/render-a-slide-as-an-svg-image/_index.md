---
title: Vykreslit snímky prezentace jako SVG obrázky na Androidu
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
- Možnosti exportu SVG
- interaktivní SVG
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Exportujte snímky PowerPointu jako SVG obrázky na Androidu a ovládejte písma, text, obrázky, ID a události pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který dobře funguje pro webové publikování, prohlížeče snímků, workflow přístupnosti a automatické následné zpracování. Aspose.Slides for Android via Java exportuje každý snímek do samostatného souboru SVG a umožňuje vám řídit, jak jsou zapisovány text, písma, obrázky a SVG prvky.

Použijte [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) když musí být exportovaný SVG kompaktní, předvídatelný napříč prohlížeči nebo připravený pro interaktivní použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), vyberte snímek a zapíšete jej do proudu pomocí [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Následující příklad exportuje každý snímek v prezentaci do samostatného souboru SVG.

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

The filename uses [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) když prohlížeč snímků nebo webová stránka potřebuje pouze ten tvar.

## **Konfigurovat výstup SVG**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) zahrnuje textový rámec do vykreslovací oblasti a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) určuje, zda se použije rotace rámce. Nastavte [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) na `true`, když text musí být vykreslen bez ligatur.

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

Při exportu snímků do SVG můžete řídit, zda text zůstane jako text nebo bude převeden na vektorovou grafiku, a jak jsou zahrnuta nebo odkazována externí písma. Následující možnosti vám pomohou vyvážit vizuální konzistenci, výběr textu a závislosti na písmách v exportovaném SVG.

### **Vektorizovat celý text**

Nastavte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) na `true`, aby byl veškerý text snímku zapisován jako vektorová grafika. Tím se eliminují závislosti na písmenech a výsledek je vizuálně konzistentnější napříč prohlížeči, ale text již nebude možné vybrat ani vyhledávat jako SVG text.

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

### **Zvolte, jak jsou externí písma zpracovávána**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) pro písma, která jsou načítána externě. Zvolte [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) pro odkazování na samostatné soubory písem, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) pro zahrnutí dat písem do SVG, nebo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) pro vykreslení pouze textu používajícího externí písma jako grafiku. Před začleněním písem ověřte licencování písem.

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

Použijte [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) aby se snížilo rozlišení vložených obrázků, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) k vynechání oříznutých oblastí zdrojových obrázků a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) k řízení kvality JPEG kódování. Tato nastavení snižují velikost souboru na úkor věrnosti obrazu nebo zachování dat obrázků.

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

## **Řízení rozlišení rasterizace metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) nastavuje dolní limit rozlišení pro rasterizaci metafile během exportu SVG. Použijte jej k vyvážení detailu a velikosti souboru, když je EMF nebo WMF obrázek rasterizován. Nedefinuje globální DPI pro SVG ani nenutí každý objekt na snímku stát se rastrovým obrázkem.

Stáhněte [metafile-rasterization.pptx](metafile-rasterization.pptx), který obsahuje EMF obrázek s těsně spojenými úhlopříčnými čarami. Následující příklad exportuje jeho první snímek ve třech rozlišeních rasterizace pomocí [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Všechna ostatní nastavení exportu zůstávají identická, aby bylo možné výsledky porovnat.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

Ve výstupu se EMF změnil na jeden vložený PNG v každém SVG. Následující měření jsou pro dodanou prezentaci; nejsou obecnou formulí pro převod DPI na rozměry v pixelech.

| Rasterizace metafile DPI | Rozměry vloženého PNG | Velikost souboru SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Srovnání níže ukazuje stejnou oblast vloženého rastrového obrázku při stejném zvětšeném zobrazení. Úhlopříčné čáry vykazují viditelnou pixelaci při 72 DPI a hladší hrany při vyšších rozlišeních, zatímco velikost souboru SVG roste. Zvýšení hodnoty nutně nezlepší každý detail ani nezmění každý exportovaný obrázek.

![Zvětšený detail úhlopříčných čar při 72, 150 a 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) řídí snižování rozlišení obrázku a může maskovat vliv změny rozlišení rasterizace metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) řídí kvalitu JPEG kódování, nikoli rozlišení rasterizace metafile.

## **Přiřadit stabilní ID tvarům a textu**

Použijte [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) abyste nastavili [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) pro každý SVG tvar. Pro nastavení hodnot [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) u textových elementů `tspan` také implementujte [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Přiřaďte kterýkoli z kontrolerů pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Následující kontroler používá [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové spany. To činí generovaná ID vhodná pro následné zpracování nezměněné prezentace.

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

## **Přidat SVG obslužné rutiny událostí**

V [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) zavolejte [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) s hodnotou [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) , abyste přidali JavaScriptový obslužný kód události k exportovanému tvaru. Přiřaďte kontroler pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) a definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostí.

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

Hostitelská stránka může definovat JavaScriptovou funkci odkazovanou obslužným kódem. Přiřazování ID a obslužných rutin událostí umožňuje prohlížečům snímků, vylepšení přístupnosti a další interaktivní SVG workflow.

## **Často kladené otázky**

**Kdy mám použít [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Použijte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-), když musí být celý text nezávislý na písmenech. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/), když by měl být převeden jen text využívající externí písma na grafiku.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním oříznutých oblastí obrázků a výběrem odkazovaných souborů písem, pokud cílové prostředí může tyto soubory poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravovat exportované SVG elementy?**

Ano. Přiřaďte ID pomocí formátovacího kontroleru a poté vyberte odpovídající SVG elementy ve vašem nástroji pro následné zpracování nebo v prohlížečovém skriptu.