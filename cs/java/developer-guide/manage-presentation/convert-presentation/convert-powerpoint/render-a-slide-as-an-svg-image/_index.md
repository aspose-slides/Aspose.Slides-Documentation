---
title: Vykreslit snímky prezentace jako SVG obrázky v Javě
linktitle: Snímek do SVG
type: docs
weight: 50
url: /cs/java/render-a-slide-as-an-svg-image/
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
- Java
- Aspose.Slides
description: "Exportujte snímky PowerPointu jako SVG obrázky v Javě a ovládejte písma, text, obrázky, ID a události pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se dobře hodí pro webové publikování, prohlížeče snímků, pracovní postupy přístupnosti a automatizované následné zpracování. Aspose.Slides exportuje každý snímek do samostatného souboru SVG a umožňuje řídit, jak jsou zapisovány text, písma, obrázky a prvky SVG.

Použijte [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) když exportovaný SVG musí být kompaktní, předvíditelný napříč prohlížeči nebo připravený pro interaktivní použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), vyberte snímek a zapište jej do proudu pomocí [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Následující příklad exportuje každý snímek v prezentaci jako samostatný soubor SVG.

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

Název souboru používá [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) pokud prohlížeč snímků nebo webová stránka potřebuje jen tento tvar.

## **Konfigurovat výstup SVG**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) zahrnuje textový rámec do oblasti vykreslování a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) určuje, zda se použije rotace rámce. Nastavte [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) na `true`, když musí být text vykreslen bez ligatur.

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

## **Ovládání ořezávání konců čar u šipek**

SVG 1.1 nemá nastavení vkládání značky, které by určovalo, kde má čára končit pod šipkou. Ve výchozím nastavení Aspose.Slides zkracuje exportovanou čáru, aby její tah nevyčníval přes značku. Zavolejte [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) s `true`, aby se tah kreslil až k původnímu koncovému bodu čáry. Toto nastavení ovlivňuje pouze výstup SVG. Čára si zachovává svou pozici a délku na snímku.

Příklad kreslí trojúhelníkové a diamantové šipky na čáry o šířce 2 a 10 bodů. Exportuje stejný snímek dvakrát, přičemž mění jen volbu ořezávání.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

Porovnání ukazuje trojúhelníkovou šipku na čáře o šířce 10 bodů. Při povoleném ořezávání je hrot ostrý. Při zakázaném ořezávání tah vyčnívá přes šikmé strany značky a zanechává plochý konec.

![Zvětšený 10‑bodový trojúhelník s ostrým hrotem při povoleném ořezávání a plochým koncem při zakázaném ořezávání](line-end-cropping.png)

U ostatních čar v příkladu je vyčnívající tah méně viditelný na 2‑bodovém trojúhelníku. Vyplněný diamant zakrývá konec tahu u obou šířek.

## **Ovládání textu a písem**

Při exportu snímků do SVG můžete řídit, zda text zůstane jako text nebo se převede na vektorovou grafiku, a jak jsou zahrnuty nebo odkazovány externí písma. Následující možnosti vám pomohou vyvážit vizuální konzistenci, výběr textu a závislosti na písmu v exportovaném SVG.

### **Vektorizovat celý text**

Nastavte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) na `true`, aby se celý text snímku zapisoval jako vektorová grafika. Tím se odstraní závislosti na písmu a výsledek je vizuálně konzistentnější napříč prohlížeči, ale text již není možné vybrat ani prohledávat jako SVG text.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) pro písma načítaná externě. Zvolte `AddLinksToFontFiles` pro odkazování na samostatné soubory písem, `Embed` pro zahrnutí dat písem do SVG, nebo `Vectorize` pro vykreslení pouze textu, který používá externí písma, jako grafiky. Před vložením písem ověřte licencování písem.

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

Použijte [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) ke snížení rozlišení vložených obrázků, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) k vynechání oříznutých částí zdroje a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) ke kontrole kvality JPEG kódování. Tato nastavení snižují velikost souboru na úkor věrnosti obrazu nebo zachovaných dat obrázku.

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) nastavuje dolní limit rozlišení při rasterizaci metafile během exportu SVG. Použijte jej k vyvážení detailu a velikosti souboru, když je rasterizován obraz EMF nebo WMF. Nenastavuje globální DPI pro SVG ani nenutí každý objekt na snímku stát se rastrovým obrázkem.

Stáhněte si [metafile-rasterization.pptx](metafile-rasterization.pptx), který obsahuje EMF obrázek s těsně umístěnými úhlopříčnými čarami. Následující příklad exportuje jeho první snímek ve třech rozlišeních rasterizace pomocí [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Všechna ostatní nastavení exportu zůstávají stejná, aby bylo možné výsledky porovnat.

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

Ve výstupu se EMF změnilo na jeden vložený PNG v každém SVG. Následující měření jsou pro dodanou prezentaci; nejsou obecnou formulí pro převod DPI na rozměry v pixelech.

| Rasterizace metafile DPI | Rozměry vloženého PNG | Velikost souboru SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Níže uvedené srovnání ukazuje stejnou oblast vloženého rastru při stejném zvětšeném zobrazení. Úhlopříčné čáry ukazují viditelnou pixelaci při 72 DPI a hladší hrany při vyšších rozlišeních, zatímco soubor SVG roste. Zvýšení hodnoty nutně neznamená zlepšení každého detailu ani změnu každého exportovaného obrázku.

![Zvětšený detail úhlopříčných čar při 72, 150 a 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) řídí snížení rozlišení obrázku a může maskovat vliv změny rozlišení rasterizace metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) řídí kvalitu JPEG kódování, nikoli rozlišení rasterizace metafile.

## **Přiřazení stabilních ID tvarům a textu**

Použijte [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) pro nastavení [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) pro každý SVG tvar. Pro nastavení hodnot [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) u textových prvků `tspan` rovněž implementujte [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Přiřaďte jeden z kontrolérů pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Následující kontrolér používá [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové úseky. To činí generovaná ID vhodná pro následné zpracování nezměněné prezentace.

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

## **Přidání obslužných funkcí událostí SVG**

V [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) zavolejte [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) s hodnotou [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) , abyste přidali JavaScriptový obslužný kód události k exportovanému tvaru. Přiřaďte kontrolér pomocí [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) a definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostí.

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

Hostitelská stránka může definovat JavaScriptovou funkci odkazovanou obslužným kódem. Přiřazování ID a obslužných kódů událostí umožňuje prohlížeče snímků, vylepšení přístupnosti a další interaktivní pracovní postupy SVG.

## **FAQ**

**Kdy bych měl použít [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

Použijte [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-), když musí být celý text nezávislý na písmu. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/), když by měl být převeden na grafiku pouze text, který používá externí písma.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním oříznutých oblastí obrázků a volbou odkazovaných souborů písem, pokud je cílové prostředí může poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravovat exportované SVG elementy?**

Ano. Přiřaďte ID pomocí kontroléru formátování a poté vyberte odpovídající SVG elementy ve svém nástroji pro následné zpracování nebo v prohlížečovém skriptu.