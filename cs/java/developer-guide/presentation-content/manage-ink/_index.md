---
title: Správa inkových objektů prezentace v Javě
linktitle: Správa ink
type: docs
weight: 95
url: /cs/java/manage-ink/
keywords:
- ink
- inkový objekt
- inková stopa
- správa ink
- kreslení ink
- kreslení
- export ink
- renderování ink
- skrytí ink
- IInkOptions
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Spravujte inkové objekty PowerPointu, upravujte stopy a vlastnosti štětců a řiďte vzhled ink během exportu do PDF, HTML, SVG, TIFF a obrázků pomocí Aspose.Slides pro Javu."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která umožňuje kreslit volně tvarované tahy. Ink lze použít k zvýraznění jiných objektů, zobrazení spojení a procesů a upoutání pozornosti na konkrétní položky na snímku.

Aspose.Slides poskytuje typy potřebné k práci s objekty ink. Například rozhraní [IInk](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iink/) představuje objekt ink na snímku.

## **Rozdíly mezi běžnými objekty a objekty ink**

Objekty na snímku PowerPointu jsou typicky reprezentovány objekty tvaru. V nejjednodušší podobě je tvar kontejner, který definuje oblast samotného objektu (jeho rámec) spolu s vlastnostmi, jako je velikost kontejneru, tvar a pozadí. Další informace najdete v [Shape Layout Format](https://docs.aspose.com/slides/cs/java/shape-manipulations/#access-layout-formats-for-shape).

Nicméně když PowerPoint zpracovává objekt ink, ignoruje všechny vlastnosti rámce objektu (kontejneru) s výjimkou jeho velikosti. Velikost oblasti kontejneru je určena standardními metodami [IShape.getWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getWidth--) a [IShape.getHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getHeight--):

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkové stopy**

Inková stopa je základní prvek používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopa ukládá sekvenci spojených bodů.

Nejjednodušší forma kódování určuje souřadnice X a Y každého vzorkového bodu. Když jsou všechny spojené body vykresleny, vytvoří obrázek jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Štětec se používá k vykreslení čar, které spojují body inkové stopy. Štětec má vlastní barvu a velikost, reprezentované metodami [IInkBrush.getColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkbrush/#getColor--) a [IInkBrush.getSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkbrush/#getSize--).

### **Nastavení barvy štětce Ink**

Tento Java kód ukazuje, jak nastavit barvu štětce ink:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Nastavení velikosti štětce Ink**

Tento Java kód ukazuje, jak nastavit velikost štětce ink:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Obecně šířka a výška štětce neodpovídají, takže PowerPoint nezobrazuje velikost štětce (odpovídající sekce dat je šedá). Když se šířka a výška štětce shodují, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku inkového objektu a podíváme se na důležité rozměry:

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rámec) nebere v úvahu velikost štětců – vždy předpokládá, že tloušťka čáry je nulová (viz předchozí obrázek).

Proto je pro určení viditelné oblasti celého inkového objektu třeba zohlednit velikost štětce jeho stop. Zde byl cílový objekt (stopa ručně psaného textu) škálován na velikost kontejneru (rámce). Když se velikost kontejneru změní, velikost štětce zůstane konstantní a naopak.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint používá podobné chování pro textové objekty:

![ink_powerpoint6](ink_powerpoint6.png)

## **Řízení vzhledu ink při exportu a renderování**

Aspose.Slides poskytuje rozhraní [IInkOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkoptions/) k řízení toho, jak se inkové objekty zobrazují v exportovaném nebo renderovaném výstupu. Jeho vlastnosti můžete použít k úplnému skrytí ink nebo ke změně interpretace operací masky štětce ink.

Ink možnosti jsou k dispozici prostřednictvím exportních nebo renderovacích možností pro několik typů výstupu:

| Výstup | Vlastnost ink možností |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

Následující metody [IInkOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkoptions/) odhalují stejné dva nastavení:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkoptions/#getHideInk--) určuje, zda jsou objekty ink zahrnuty ve výstupu. Jeho výchozí hodnota je `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) určuje, zda je masková operace interpretována jako opacity při renderování štětce ink. Jeho výchozí hodnota je `true`; zavolejte [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) s `false` pro použití ROP operace místo toho.

### **Skrytí objektů ink ve výstupu PDF**

Ve výchozím nastavení zůstávají inkové objekty při exportu viditelné. Pro vytvoření čistého výstupu bez ručně psaných poznámek nebo jiného inkového obsahu zavolejte [IInkOptions.setHideInk](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) s `true`.

Následující Java příklad exportuje prezentaci do PDF při skrytí všech inkových objektů:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Skrytí objektů ink při renderování snímku jako obrázku**

Pro skrytí inkových objektů při renderování snímků jako bitmapových obrázků nakonfigurujte [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/renderingoptions/#getInkOptions--) a předávejte renderovací možnosti do [ISlide.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Následující Java příklad vykresluje první snímek jako PNG obrázek bez inkových objektů:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Řízení renderování masky ink**

Nastavení [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) řídí, jak jsou maskové operace interpretovány při renderování inkových štětců. Výchozí hodnota je `true`, což používá opacity. Pro použití ROP operace místo toho zavolejte [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) s `false`.

Následující Java příklad exportuje snímek do SVG a používá renderování založené na ROP pro operace masky ink:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

Stejné nastavení lze použít přes [TiffOptions.getInkOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/#getInkOptions--) při exportu prezentace nebo renderování snímku do TIFF.

### **Zvolte, zda skrýt nebo zachovat ink**

Když potřebujete čistou verzi anotované prezentace k distribuci bez recenzních značek, zavolejte během exportu [IInkOptions.setHideInk](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) s `true`.

Nechte [IInkOptions.getHideInk](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkoptions/#getHideInk--) na jeho výchozí hodnotě `false`, když jsou inkové anotace součástí zamýšleného obsahu, například recenzní komentáře, ručně psané poznámky, zvýraznění nebo kresby, které mají zůstat viditelné ve výstupu. To umožňuje aplikacím generovat samostatné recenzní a finální výstupy ze stejné prezentace bez úpravy zdrojových inkových objektů.

## **FAQ**

**Mohu změnit barvu nebo velikost existujícího tahu ink?**

Ano. Získejte stopu pomocí [IInk.getTraces](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iink/#getTraces--), poté změňte její [IInkTrace.getBrush](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinktrace/#getBrush--). Zavolejte [IInkBrush.setColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) nebo [IInkBrush.setSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) pro změnu štětce.

**Mění skrytí ink zdrojovou prezentaci?**

Ne. Volání [IInkOptions.setHideInk](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) ovlivňuje pouze renderovaný nebo exportovaný výsledek; neodstraňuje ani nemodifikuje inkové objekty ve zdrojové prezentaci.

**Které exportní formáty podporují možnosti ink?**

Možnosti ink můžete konfigurovat pro PDF, HTML, SVG, TIFF a bitmapové snímky přes odpovídající exportní nebo renderovací možnosti uvedené výše.

**Další informace**

* Pro čtení o tvarech obecně, viz sekci [PowerPoint Shapes](https://docs.aspose.com/slides/cs/java/powerpoint-shapes/).
* Pro více informací o efektivních hodnotách, viz [Shape Effective Properties](https://docs.aspose.com/slides/cs/java/shape-effective-properties/#get-effective-font-height-value).
* Pro podrobnosti o exportu do PDF, viz [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/cs/java/convert-powerpoint-to-pdf/).
* Pro podrobnosti o exportu do HTML, viz [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/cs/java/convert-powerpoint-to-html/).
* Pro podrobnosti o exportu do SVG, viz [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/cs/java/render-a-slide-as-an-svg-image/).
* Pro podrobnosti o exportu do TIFF, viz [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/cs/java/convert-powerpoint-to-tiff/).
* Pro podrobnosti o renderování snímku do obrázku, viz [Convert Presentation Slides to Images](https://docs.aspose.com/slides/cs/java/convert-slide/).