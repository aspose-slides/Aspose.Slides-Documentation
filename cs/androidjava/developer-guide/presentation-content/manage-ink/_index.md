---
title: Spravovat objekty ink v prezentaci na Androidu
linktitle: Spravovat ink
type: docs
weight: 95
url: /cs/androidjava/manage-ink/
keywords:
- ink
- objekt ink
- stopa ink
- spravovat ink
- kreslit ink
- kreslení
- export ink
- renderování ink
- skrýt ink
- IInkOptions
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Spravovat objekty ink v PowerPointu, upravovat stopy a vlastnosti štětců a řídit vzhled ink během exportu do PDF, HTML, SVG, TIFF a obrázků s Aspose.Slides pro Android."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která vám umožňuje kreslit volné tahy. Ink lze použít k zvýraznění dalších objektů, zobrazení spojení a procesů a upoutání pozornosti na konkrétní položky na snímku.

Aspose.Slides poskytuje typy potřebné pro práci s objekty ink. Například rozhraní [IInk](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iink/) představuje objekt ink na snímku.

## **Rozdíly mezi běžnými objekty a objekty ink**

Objekty na snímku PowerPointu jsou typicky reprezentovány objekty tvaru. V své nejjednodušší podobě je tvar kontejner, který určuje oblast samotného objektu (jeho rámec) spolu s vlastnostmi jako velikost kontejneru, tvar a pozadí. Další informace najdete v [Formát rozvržení tvaru](https://docs.aspose.com/slides/cs/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Nicméně když PowerPoint zpracovává objekt ink, ignoruje všechny vlastnosti rámce objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními metodami [IShape.getWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getWidth--) a [IShape.getHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Stopy ink**

Stopa ink je základní prvek používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopa ukládá sekvenci propojených bodů.

Nejjednodušší forma kódování udává souřadnice X a Y každého vzorkovacího bodu. Když jsou všechny propojené body vykresleny, vytvoří obrázek podobný tomuto:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Štětec se používá k vykreslení čar, které spojují body stopy ink. Štětec má vlastní barvu a velikost, reprezentované metodami [IInkBrush.getColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkbrush/#getColor--) a [IInkBrush.getSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkbrush/#getSize--) .

### **Nastavit barvu štětce ink**

Tento kód v jazyce Java ukazuje, jak nastavit barvu štětce ink:

```java
import android.graphics.Color;
import com.aspose.slides.*;

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

### **Nastavit velikost štětce ink**

Tento kód v jazyce Java ukazuje, jak nastavit velikost štětce ink:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Obecně šířka a výška štětce neodpovídají, takže PowerPoint nezobrazuje velikost štětce (odpovídající část dat je šedá). Když šířka a výška štětce odpovídají, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku objektu ink a podíváme se na důležité rozměry:

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rámec) nebere v úvahu velikost štětců — vždy předpokládá, že tloušťka čáry je nula (viz předchozí obrázek).

Proto je při určování viditelné oblasti celého objektu ink třeba zohlednit velikost štětce jeho stop. Zde byl cílový objekt (stopa ručně psaného textu) přeškálován na velikost kontejneru (rámce). Když se velikost kontejneru změní, velikost štětce zůstane konstantní a naopak.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint používá podobné chování pro textové objekty:

![ink_powerpoint6](ink_powerpoint6.png)

## **Řízení vzhledu ink během exportu a renderování**

Aspose.Slides poskytuje rozhraní [IInkOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkoptions/) k řízení toho, jak objekty ink vypadají v exportovaném nebo renderovaném výstupu. Pomocí jeho vlastností můžete ink zcela skrýt nebo změnit způsob, jakým jsou interpretovány operace masky štětce ink.

Možnosti ink jsou k dispozici prostřednictvím možností exportu nebo renderování pro několik typů výstupů:

| Výstup | Vlastnost ink možností |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

Následující metody rozhraní [IInkOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkoptions/) zpřístupňují stejná dvě nastavení:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) určuje, zda jsou objekty ink zahrnuty ve výstupu. Jeho výchozí hodnota je `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) určuje, zda je operace masky interpretována jako neprůhlednost při renderování štětce ink. Jeho výchozí hodnota je `true`; zavolejte [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) s `false` a použijte operaci ROP místo ní.

### **Skrýt objekty ink ve výstupu PDF**

Ve výchozím nastavení zůstávají objekty ink během exportu viditelné. Pro vytvoření čistého výstupu bez ručně psaných anotací nebo jiného obsahu ink zavolejte [IInkOptions.setHideInk](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) s `true`.

Následující příklad v jazyce Java exportuje prezentaci do PDF a současně skryje všechny objekty ink:

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

### **Skrýt objekty ink při renderování snímku jako obrázku**

Pro skrytí objektů ink při renderování snímků jako bitmapových obrázků nakonfigurujte [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) a předejte možnosti renderování metodě [ISlide.getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Následující příklad v jazyce Java vykreslí první snímek jako PNG obrázek bez objektů ink:

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

Nastavení [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) řídí, jak jsou operace masky interpretovány při renderování štětců ink. Výchozí hodnota je `true`, což používá neprůhlednost. Pro použití operace ROP místo toho zavolejte [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) s `false`.

Následující příklad v jazyce Java exportuje snímek do SVG a používá renderování založené na ROP pro operace masky ink:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

Stejné nastavení lze použít prostřednictvím [TiffOptions.getInkOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) při exportu prezentace nebo renderování snímku do TIFF.

### **Zvolte, zda skrýt nebo zachovat ink**

Když potřebujete čistou verzi anotované prezentace pro distribuci bez revizních značek, zavolejte [IInkOptions.setHideInk](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) s `true` během exportu.

Ponechte [IInkOptions.getHideInk](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) na výchozí hodnotě `false`, pokud jsou ink anotace součástí zamýšleného obsahu, například revizní komentáře, ručně psané poznámky, zvýraznění nebo kresby, které mají zůstat ve výsledném exportu viditelné. To umožňuje aplikacím generovat samostatné revizní a finální výstupy ze stejné prezentace bez úpravy zdrojových objektů ink.

## **Často kladené otázky**

**Mohu změnit barvu nebo velikost existujícího tahu ink?**

Ano. Získejte stopu pomocí [IInk.getTraces](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iink/#getTraces--) a potom změňte její [IInkTrace.getBrush](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinktrace/#getBrush--). Zavolejte [IInkBrush.setColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) nebo [IInkBrush.setSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) pro změnu štětce.

**Změní skrytí ink zdrojovou prezentaci?**

Ne. Volání [IInkOptions.setHideInk](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) ovlivňuje jen renderovaný nebo exportovaný výsledek; neodstraňuje ani nemění objekty ink ve zdrojové prezentaci.

**Které exportní formáty podporují ink možnosti?**

Možnosti ink můžete nakonfigurovat pro PDF, HTML, SVG, TIFF a bitmapové obrázky snímků prostřednictvím odpovídajících možností exportu nebo renderování uvedených výše.

**Další čtení**

* Pro obecné informace o tvarech viz sekce [Tvary PowerPoint](https://docs.aspose.com/slides/cs/androidjava/powerpoint-shapes/).
* Pro podrobnosti o efektivních hodnotách viz [Efektivní vlastnosti tvaru](https://docs.aspose.com/slides/cs/androidjava/shape-effective-properties/#get-effective-font-height-value).
* Pro podrobnosti o exportu do PDF viz [Převod PPT a PPTX do PDF](https://docs.aspose.com/slides/cs/androidjava/convert-powerpoint-to-pdf/).
* Pro podrobnosti o exportu do HTML viz [Převod prezentací PowerPoint do HTML](https://docs.aspose.com/slides/cs/androidjava/convert-powerpoint-to-html/).
* Pro podrobnosti o exportu do SVG viz [Renderování snímků prezentace jako SVG obrázky](https://docs.aspose.com/slides/cs/androidjava/render-a-slide-as-an-svg-image/).
* Pro podrobnosti o exportu do TIFF viz [Převod prezentací PowerPoint do TIFF](https://docs.aspose.com/slides/cs/androidjava/convert-powerpoint-to-tiff/).
* Pro podrobnosti o renderování snímků na obrázek viz [Převod snímků prezentace na obrázky](https://docs.aspose.com/slides/cs/androidjava/convert-slide/).