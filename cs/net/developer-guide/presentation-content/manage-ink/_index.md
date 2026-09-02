---
title: Správa objektů ink v prezentaci v .NET
linktitle: Správa ink
type: docs
weight: 95
url: /cs/net/manage-ink/
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
- IInkOptions
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte objekty ink v PowerPointu, upravujte stopy a vlastnosti štětců a řiďte vzhled ink při exportu do PDF, HTML, SVG, TIFF a obrázků s Aspose.Slides pro .NET."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která vám umožňuje kreslit volné tahy. Ink lze použít k zvýraznění dalších objektů, zobrazení spojení a procesů a upoutání pozornosti na konkrétní položky na snímku.

Prostor názvů [Aspose.Slides.Ink](https://reference.aspose.com/slides/cs/net/aspose.slides.ink/) obsahuje třídy a rozhraní potřebné pro práci s objekty ink. Například rozhraní [IInk](https://reference.aspose.com/slides/cs/net/aspose.slides.ink/iink/) představuje objekt ink na snímku.

## **Rozdíly mezi běžnými objekty a objekty ink**

Objekty na snímku PowerPointu jsou typicky reprezentovány objekty tvaru. V nejjednodušší formě je tvar kontejner, který definiuje oblast samotného objektu (jeho rám) spolu s vlastnostmi, jako je velikost kontejneru, tvar a pozadí. Další informace naleznete v [Shape Layout Format](https://docs.aspose.com/slides/cs/net/shape-manipulations/#access-layout-formats-for-shape).

Nicméně když PowerPoint zpracovává objekt ink, ignoruje všechny vlastnosti rámu objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními vlastnostmi [IShape.Width](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/width/) a [IShape.Height](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink stopy**

Ink stopa je základní prvek používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopa ukládá sekvenci propojených bodů.

Nejjednodušší forma kódování určuje souřadnice X a Y každého vzorkového bodu. Když jsou všechny propojené body vykresleny, vytvoří obrázek jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Štětec se používá k vykreslení čar, které spojují body ink stopy. Štětec má vlastní barvu a velikost, reprezentované vlastnostmi [IInkBrush.Color](https://reference.aspose.com/slides/cs/net/aspose.slides.ink/iinkbrush/color/) a [IInkBrush.Size](https://reference.aspose.com/slides/cs/net/aspose.slides.ink/iinkbrush/size/).

### **Nastavení barvy štětce Ink**

Tento C# kód ukazuje, jak nastavit barvu štětce ink:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Nastavení velikosti štětce Ink**

Tento C# kód ukazuje, jak nastavit velikost štětce ink:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

Obecně se šířka a výška štětce neshodují, takže PowerPoint nezobrazuje velikost štětce (odpovídající sekce dat je šedá). Když se šířka a výška štětce shodují, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku objektu ink a podíváme se na důležité rozměry:

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rám) nezohledňuje velikost štětců – vždy předpokládá, že tloušťka čáry je nulová (viz předchozí obrázek).

Proto je při určení viditelné oblasti celého objektu ink nutné brát v úvahu velikost štětce jeho stop. Zde byl cílový objekt (stopa ručně psaného textu) přepočítán na velikost kontejneru (rám). Když se mění velikost kontejneru, velikost štětce zůstává konstantní, a naopak.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint používá podobné chování pro textové objekty:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrola vzhledu ink při exportu a vykreslování**

Aspose.Slides poskytuje rozhraní [IInkOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/iinkoptions/) pro kontrolu, jak objekty ink vypadají v exportovaném nebo vykresleném výstupu. Můžete použít jeho vlastnosti k úplnému skrytí ink nebo ke změně způsobu, jakým jsou interpretovány operace masky štětce ink.

Možnosti ink jsou dostupné prostřednictvím možností exportu nebo vykreslování pro několik typů výstupu:

| Výstup | Vlastnost ink možností |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Slide image | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/cs/net/aspose.slides.export/renderingoptions/inkoptions/) |

Stejné dvě nastavení jsou k dispozici prostřednictvím těchto vlastností:

- [`HideInk`](https://reference.aspose.com/slides/cs/net/aspose.slides.export/iinkoptions/hideink/) určuje, zda jsou objekty ink zahrnuty do výstupu. Výchozí hodnota je `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/cs/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) určuje, zda je operace masky interpretována jako neprůhlednost při vykreslování štětce ink. Výchozí hodnota je `true`; nastavením na `false` použijete operaci ROP.

### **Skrytí objektů ink ve výstupu PDF**

Ve výchozím nastavení jsou objekty ink během exportu viditelné. Nastavte [IInkOptions.HideInk](https://reference.aspose.com/slides/cs/net/aspose.slides.export/iinkoptions/hideink/) na `true`, pokud potřebujete čistý výstup bez ručně psaných poznámek nebo jiného obsahu ink.

Následující C# příklad exportuje prezentaci do PDF a skryje všechny objekty ink:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Skrytí objektů ink při vykreslování snímku jako obrázku**

Pro skrytí objektů ink při vykreslování snímků jako bitmapových obrázků nakonfigurujte [RenderingOptions.InkOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/renderingoptions/inkoptions/) a předajte možnosti vykreslování metodě [ISlide.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/).

Následující C# příklad vykreslí první snímek jako PNG obrázek bez objektů ink:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Řízení vykreslování masky ink**

Vlastnost [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) řídí, jak jsou operace masky interpretovány při vykreslování štětců ink. Výchozí hodnota je `true`, což používá neprůhlednost. Nastavením na `false` použijete operaci ROP.

Následující C# příklad exportuje snímek do SVG a používá vykreslování založené na ROP pro operace masky ink:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

Stejné nastavení lze použít prostřednictvím [TiffOptions.InkOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/inkoptions/) při exportu prezentace nebo vykreslování snímku do TIFF.

### **Zvolte, zda skrýt nebo zachovat ink**

Použijte [IInkOptions.HideInk](https://reference.aspose.com/slides/cs/net/aspose.slides.export/iinkoptions/hideink/) nastavené na `true`, pokud má být exportovaný soubor čistou verzí anotované prezentace, například konečná kopie určená k distribuci bez revizních značek.

Nechte [IInkOptions.HideInk](https://reference.aspose.com/slides/cs/net/aspose.slides.export/iinkoptions/hideink/) na výchozí hodnotě `false`, pokud jsou ink anotace součástí zamýšleného obsahu, například revizní komentáře, ručně psané poznámky, zvýraznění nebo kresby, které mají zůstat viditelné ve výstupu. To umožní aplikacím generovat samostatné revizní a finální výstupy ze stejné prezentace bez úpravy zdrojových objektů ink.

## **Často kladené otázky**

**Mohu změnit barvu nebo velikost existujícího ink tahu?**

Ano. Získáte stopu z [IInk.Traces](https://reference.aspose.com/slides/cs/net/aspose.slides.ink/iink/traces/), poté změníte její [IInkTrace.Brush](https://reference.aspose.com/slides/cs/net/aspose.slides.ink/iinktrace/brush/). Můžete nastavit barvu štětce pomocí [IInkBrush.Color](https://reference.aspose.com/slides/cs/net/aspose.slides.ink/iinkbrush/color/) a velikost pomocí [IInkBrush.Size](https://reference.aspose.com/slides/cs/net/aspose.slides.ink/iinkbrush/size/).

**Změní skrytí ink zdrojovou prezentaci?**

Ne. [IInkOptions.HideInk](https://reference.aspose.com/slides/cs/net/aspose.slides.export/iinkoptions/hideink/) ovlivňuje pouze vykreslený nebo exportovaný výsledek; neodstraňuje ani nemodifikuje objekty ink ve zdrojové prezentaci.

**Které exportní formáty podporují možnosti ink?**

Můžete konfigurovat možnosti ink pro PDF, HTML, SVG, TIFF a bitmapové obrázky snímků prostřednictvím odpovídajících možností exportu nebo vykreslování uvedených výše.

**Další čtení**

* Pro čtení o tvarech obecně navštivte sekci [PowerPoint Shapes](https://docs.aspose.com/slides/cs/net/powerpoint-shapes/).
* Pro více informací o efektivních hodnotách viz [Shape Effective Properties](https://docs.aspose.com/slides/cs/net/shape-effective-properties/#get-effective-font-height-value).
* Pro podrobnosti o exportu PDF viz [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/cs/net/convert-powerpoint-to-pdf/).
* Pro podrobnosti o exportu HTML viz [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/cs/net/convert-powerpoint-to-html/).
* Pro podrobnosti o exportu SVG viz [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/cs/net/render-a-slide-as-an-svg-image/).
* Pro podrobnosti o exportu TIFF viz [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/cs/net/convert-powerpoint-to-tiff/).
* Pro podrobnosti o vykreslování snímku na obrázek viz [Convert Presentation Slides to Images](https://docs.aspose.com/slides/cs/net/convert-slide/).