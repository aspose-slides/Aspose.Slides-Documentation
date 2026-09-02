---
title: Správa objektů ink v PowerPointu v JavaScriptu
linktitle: Správa Ink
type: docs
weight: 95
url: /cs/nodejs-java/manage-ink/
keywords:
- ink
- objekt ink
- stopa ink
- správa ink
- kreslení ink
- kreslení
- export ink
- renderování ink
- skrytí ink
- InkOptions
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte objekty ink v PowerPointu, upravujte stopy a vlastnosti štětců a ovládejte vzhled ink během exportu do PDF, HTML, SVG, TIFF a obrázků s Aspose.Slides pro Node.js pomocí Java."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která vám umožňuje kreslit volné tahy. Ink lze použít k zvýraznění dalších objektů, zobrazení spojení a procesů a upoutání pozornosti na konkrétní položky na snímku.

Aspose.Slides poskytuje typy potřebné pro práci s objekty ink. Například třída [Ink](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ink/) představuje objekt ink na snímku.

## **Rozdíly mezi běžnými objekty a objekty ink**

Objekty na snímku PowerPointu jsou typicky reprezentovány objekty tvaru. V nejjednodušší formě je tvar kontejner, který definuje oblast samotného objektu (jeho rámec) spolu s vlastnostmi, jako je velikost, tvar a pozadí kontejneru. Další informace najdete v [Shape Layout Format](https://docs.aspose.com/slides/cs/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Nicméně, když PowerPoint pracuje s objektem ink, ignoruje všechny vlastnosti rámce objektu (kontejneru) kromě jeho velikosti. Velikost oblastí kontejneru je určena standardními metodami [Shape.getWidth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getWidth--) a [Shape.getHeight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink stopy**

Ink stopa je základní prvek používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopu ukládá sekvenci propojených bodů.

Nejjednodušší forma kódování určuje souřadnice X a Y každého vzorkovacího bodu. Když jsou všechny propojené body vykresleny, vytvoří obrázek jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Štětec se používá k vykreslování čar, které spojují body ink stopy. Štětec má vlastní barvu a velikost, reprezentované metodami [InkBrush.getColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkbrush/#getColor--) a [InkBrush.getSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkbrush/#getSize--) .

### **Nastavení barvy ink štětce**

This JavaScript code shows how to set the color of an ink brush:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Nastavení velikosti ink štětce**

This JavaScript code shows how to set the size of an ink brush:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Obecně šířka a výška štětce neodpovídají, takže PowerPoint nezobrazuje velikost štětce (příslušná část dat je šedá). Když se šířka a výška štětce shodují, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku objektu ink a podíváme se na důležité rozměry:

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rámec) nebere v úvahu velikost štětců – vždy předpokládá, že tloušťka čáry je nula (viz předchozí obrázek).

Proto, aby bylo možné určit viditelnou oblast celého objektu ink, je třeba zohlednit velikost štětce jeho stop. Zde byl cílový objekt (stopa ručně psaného textu) přizpůsoben velikosti kontejneru (rámce). Když se změní velikost kontejneru, velikost štětce zůstává konstantní a naopak.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint používá podobné chování pro textové objekty:

![ink_powerpoint6](ink_powerpoint6.png)

## **Řízení vzhledu ink při exportu a vykreslování**

Aspose.Slides poskytuje třídu [InkOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkoptions/), která umožňuje ovládat, jak se objekty ink zobrazují v exportovaném nebo vykresleném výstupu. Její vlastnosti můžete použít k úplnému skrytí ink nebo ke změně interpretace operací masky štětce ink.

Možnosti ink jsou k dispozici prostřednictvím možností exportu nebo vykreslování pro několik typů výstupu:

| Výstup | Vlastnost InkOptions |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

Následující metody [InkOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkoptions/) odhalují stejné dvě nastavení:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkoptions/#getHideInk--) určuje, zda jsou objekty ink zahrnuty do výstupu. Výchozí hodnota je `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) určuje, zda je operace masky interpretována jako průhlednost při vykreslování štětce ink. Výchozí hodnota je `true`; zavolejte [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) s `false` pro použití operace ROP místo toho.

### **Skrytí objektů ink v PDF výstupu**

Ve výchozím nastavení jsou objekty ink během exportu viditelné. Pro vytvoření čistého výstupu bez ručně psaných anotací nebo jiného ink obsahu zavolejte [InkOptions.setHideInk](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) s `true`.

Následující příklad JavaScriptu exportuje prezentaci do PDF a přitom skryje všechny objekty ink:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Skrytí objektů ink při vykreslování snímku jako obrázku**

Pro skrytí objektů ink při vykreslování snímků jako bitmapových obrázků nakonfigurujte [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) a předložte možnosti vykreslování metodě [Slide.getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-).

Následující příklad JavaScriptu vykreslí první snímek jako PNG obrázek bez objektů ink:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Řízení vykreslování ink masky**

Nastavení [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) řídí, jak jsou operace masky interpretovány při vykreslování štětců ink. Výchozí hodnota je `true`, což používá průhlednost. Pro použití operace ROP místo toho zavolejte [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) s `false`.

Následující příklad JavaScriptu exportuje snímek do SVG a používá vykreslování založené na ROP pro operace ink masky:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

Stejné nastavení lze použít prostřednictvím [TiffOptions.getInkOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) když exportujete prezentaci nebo vykreslujete snímek do TIFF.

### **Zvolte, zda skrýt nebo zachovat ink**

Když potřebujete čistou verzi anotované prezentace k distribuci bez recenzních značek, zavolejte během exportu [InkOptions.setHideInk](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) s `true`.

Ponechte [InkOptions.getHideInk](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkoptions/#getHideInk--) na výchozí hodnotě `false`, když jsou ink anotace součástí zamýšleného obsahu, například recenzní komentáře, ručně psané poznámky, zvýraznění nebo kresby, které mají zůstat ve výsledném exportu viditelné. To umožňuje aplikacím vytvořit samostatné recenzní a finální výstupy ze stejné prezentace bez úpravy zdrojových objektů ink.

## **Často kladené otázky**

**Mohu změnit barvu nebo velikost existujícího ink tahu?**

Ano. Získejte stopu pomocí [Ink.getTraces](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ink/#getTraces--) a poté změňte její [InkTrace.getBrush](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inktrace/#getBrush--). Zavolejte [InkBrush.setColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) nebo [InkBrush.setSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) a změňte štětec.

**Mění skrytí ink zdrojovou prezentaci?**

Ne. Zavolání [InkOptions.setHideInk](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) ovlivní pouze výsledný vykreslený nebo exportovaný výstup; neodstraní ani neupraví objekty ink ve zdrojové prezentaci.

**Které exportní formáty podporují možnosti ink?**

Můžete nastavit možnosti ink pro PDF, HTML, SVG, TIFF a bitmapové obrázky snímků prostřednictvím odpovídajících možností exportu nebo vykreslování uvedených výše.

**Další čtení**

* Pro obecné informace o tvarech viz sekce [PowerPoint Shapes](https://docs.aspose.com/slides/cs/nodejs-java/powerpoint-shapes/).
* Pro více informací o efektivních hodnotách viz [Shape Effective Properties](https://docs.aspose.com/slides/cs/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
* Pro podrobnosti o exportu PDF viz [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/cs/nodejs-java/convert-powerpoint-to-pdf/).
* Pro podrobnosti o exportu HTML viz [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/cs/nodejs-java/convert-powerpoint-to-html/).
* Pro podrobnosti o exportu SVG viz [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/cs/nodejs-java/render-a-slide-as-an-svg-image/).
* Pro podrobnosti o exportu TIFF viz [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/cs/nodejs-java/convert-powerpoint-to-tiff/).
* Pro podrobnosti o vykreslování snímku do obrázku viz [Convert Presentation Slides to Images](https://docs.aspose.com/slides/cs/nodejs-java/convert-slide/).