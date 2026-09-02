---
title: "Správa objektů ink v PowerPointu v PHP"
linktitle: "Spravovat ink"
type: docs
weight: 95
url: /cs/php-java/manage-ink/
keywords:
- ink
- ink objekt
- ink stopa
- správa ink
- kreslení ink
- kreslení
- export ink
- renderování ink
- skrýt ink
- InkOptions
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte objekty ink v PowerPointu, upravujte stopy a vlastnosti štětců a řiďte vzhled ink během exportu do PDF, HTML, SVG, TIFF a obrázků s Aspose.Slides pro PHP prostřednictvím Javy."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která umožňuje kreslit volně tvarované tahy. Ink lze použít k zvýraznění dalších objektů, zobrazení spojení a procesů a přitáhnout pozornost k určitým položkám na snímku.

Aspose.Slides poskytuje typy potřebné pro práci s objekty ink. Například třída [Ink](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ink/) představuje objekt ink na snímku.

## **Rozdíly mezi běžnými objekty a objekty ink**

Objekty na snímku PowerPointu jsou typicky reprezentovány objekty [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/). V nejjednodušší podobě je shape kontejner, který určuje oblast samotného objektu (jeho rámec) spolu s vlastnostmi, jako je velikost kontejneru, tvar a pozadí. Další informace naleznete v [Shape Layout Format](https://docs.aspose.com/slides/cs/php-java/shape-manipulations/#access-layout-formats-for-shape).

Nicméně když PowerPoint pracuje s objektem ink, ignoruje všechny vlastnosti rámce objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními metodami [Shape.getWidth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getWidth) a [Shape.getHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink Stopy**

Ink stopa je základní prvek používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopa ukládá sekvenci spojených bodů.

Nejjednodušší forma kódování určuje souřadnice X a Y každého vzorkovacího bodu. Po vykreslení všech spojených bodů vznikne obraz jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Štětec se používá k vykreslování čar, které spojují body ink stopy. Štětec má vlastní barvu a velikost, reprezentované metodami [InkBrush.getColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/inkbrush/#getColor) a [InkBrush.getSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/inkbrush/#getSize).

### **Nastavit barvu štětce ink**

Tento PHP kód ukazuje, jak nastavit barvu štětce ink:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Nastavit velikost štětce ink**

Tento PHP kód ukazuje, jak nastavit velikost štětce ink:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

Obecně šířka a výška štětce neodpovídají, takže PowerPoint nezobrazuje velikost štětce (příslušná část dat je šedá). Když šířka a výška štětce odpovídají, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku objektu ink a podíváme se na důležité rozměry:

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rámec) nebere v úvahu velikost štětců – vždy předpokládá, že tloušťka čáry je nula (viz předchozí obrázek).

Proto je třeba při určení viditelné oblasti celého objektu ink zohlednit velikost štětce jeho stop. Zde byl cílový objekt (stopa ručně psaného textu) přizpůsoben velikosti kontejneru (rámce). Když se velikost kontejneru změní, velikost štětce zůstane konstantní a naopak.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint používá podobné chování pro textové objekty:

![ink_powerpoint6](ink_powerpoint6.png)

## **Řízení vzhledu ink během exportu a renderování**

Aspose.Slides poskytuje třídu [InkOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/inkoptions/), která umožňuje řídit, jak objekty ink vypadají v exportovaném nebo renderovaném výstupu. Můžete použít její vlastnosti k úplnému skrytí ink nebo ke změně interpretace operací masky štětce ink.

Možnosti ink jsou k dispozici prostřednictvím exportních nebo renderovacích možností pro několik typů výstupu:

| Výstup | Vlastnost InkOptions |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/renderingoptions/#getInkOptions) |

Následující metody [InkOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/inkoptions/) zveřejňují stejná dvě nastavení:

- [InkOptions.getHideInk] určuje, zda jsou objekty ink zahrnuty do výstupu. Jeho výchozí hodnota je `false`.
- [InkOptions.getInterpretMaskOpAsOpacity] určuje, zda je operace masky interpretována jako neprůhlednost při renderování štětce ink. Jeho výchozí hodnota je `true`; zavolejte [InkOptions.setInterpretMaskOpAsOpacity] s `false` pro použití operace ROP místo toho.

### **Skrýt objekty ink v PDF výstupu**

Ve výchozím nastavení zůstávají objekty ink během exportu viditelné. Pro vytvoření čistého výstupu bez ručně psaných anotací nebo jiného obsahu ink zavolejte [InkOptions.setHideInk] s `true`.

Následující PHP příklad exportuje prezentaci do PDF při skrytí všech objektů ink:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Skrýt objekty ink při renderování snímku jako obrázku**

Pro skrytí objektů ink při renderování snímků jako bitmapových obrázků nakonfigurujte [RenderingOptions.getInkOptions] a předávejte renderovací možnosti metodě [Slide.getImage].

Následující PHP příklad renderuje první snímek jako PNG obrázek bez objektů ink:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Řídit renderování masky ink**

Nastavení [InkOptions.getInterpretMaskOpAsOpacity] řídí, jak jsou operace masky interpretovány při renderování štětců ink. Výchozí hodnota je `true`, což používá neprůhlednost. Pro použití operace ROP místo toho zavolejte [InkOptions.setInterpretMaskOpAsOpacity] s `false`.

Následující PHP příklad exportuje snímek do SVG a používá renderování založené na ROP pro operace masky ink:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Stejné nastavení lze použít prostřednictvím [TiffOptions.getInkOptions] při exportu prezentace nebo renderování snímku do TIFF.

### **Zvolte, zda skrýt nebo zachovat ink**

Když potřebujete čistou verzi anotované prezentace pro distribuci bez recenzních značek, zavolejte [InkOptions.setHideInk] s `true` během exportu.

Ponechte [InkOptions.getHideInk] na výchozí hodnotě `false`, pokud jsou ink anotace součástí zamýšleného obsahu, například recenzní komentáře, ručně psané poznámky, zvýraznění nebo kresby, které mají zůstat v exportovaném výsledku viditelné. To umožňuje aplikacím generovat samostatné recenzní a finální výstupy ze stejné prezentace, aniž by se upravovaly zdrojové objekty ink.

## **Často kladené otázky**

**Mohu změnit barvu nebo velikost existujícího ink tahu?**

Ano. Získejte stopu pomocí [Ink.getTraces](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ink/#getTraces), poté změňte její [InkTrace.getBrush](https://reference.aspose.com/slides/cs/php-java/aspose.slides/inktrace/#getBrush). Zavolejte [InkBrush.setColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/inkbrush/#setColor) nebo [InkBrush.setSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/inkbrush/#setSize) k změně štětce.

**Mění skrytí ink původní prezentaci?**

Ne. Volání [InkOptions.setHideInk](https://reference.aspose.com/slides/cs/php-java/aspose.slides/inkoptions/#setHideInk) ovlivňuje pouze renderovaný nebo exportovaný výsledek; neodstraňuje ani nemodifikuje objekty ink v původní prezentaci.

**Které exportní formáty podporují ink možnosti?**

Můžete konfigurovat ink možnosti pro PDF, HTML, SVG, TIFF a bitmapové obrázky snímků prostřednictvím odpovídajících exportních nebo renderovacích možností uvedených výše.

**Další čtení**

* Pro čtení o tvarech obecně, viz sekci [PowerPoint Shapes](https://docs.aspose.com/slides/cs/php-java/powerpoint-shapes/).
* Pro podrobnosti o efektivních hodnotách, viz [Shape Effective Properties](https://docs.aspose.com/slides/cs/php-java/shape-effective-properties/#get-effective-font-height-value).
* Pro podrobnosti o exportu PDF, viz [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/cs/php-java/convert-powerpoint-to-pdf/).
* Pro podrobnosti o exportu HTML, viz [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/cs/php-java/convert-powerpoint-to-html/).
* Pro podrobnosti o exportu SVG, viz [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/cs/php-java/render-a-slide-as-an-svg-image/).
* Pro podrobnosti o exportu TIFF, viz [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/cs/php-java/convert-powerpoint-to-tiff/).
* Pro podrobnosti o renderování snímku do obrázku, viz [Convert Presentation Slides to Images](https://docs.aspose.com/slides/cs/php-java/convert-slide/).