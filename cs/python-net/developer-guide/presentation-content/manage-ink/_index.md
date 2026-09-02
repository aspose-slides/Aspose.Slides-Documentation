---
title: Spravovat ink objekty prezentace v Pythonu
linktitle: Spravovat Ink
type: docs
weight: 95
url: /cs/python-net/manage-ink/
keywords:
- ink
- ink objekt
- ink stopa
- spravovat ink
- kreslit ink
- kreslení
- export ink
- vykreslování ink
- skrýt ink
- InkOptions
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Spravovat ink objekty PowerPoint, upravovat stopy a vlastnosti štětců a řídit vzhled ink během exportu PDF, HTML, SVG, TIFF a obrázků s Aspose.Slides pro Python prostřednictvím .NET."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která vám umožňuje kreslit volné tahy. Ink lze použít k zvýraznění ostatních objektů, zobrazení spojení a procesů a upoutání pozornosti na konkrétní položky na snímku.

Namespace [aspose.slides.ink](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ink/) obsahuje třídy potřebné pro práci s ink objekty. Například třída [Ink](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ink/ink/) představuje ink objekt na snímku.

## **Rozdíly mezi běžnými objekty a ink objekty**

Objekty na snímku PowerPointu jsou typicky reprezentovány objekty tvaru. V nejjednodušší podobě je tvar kontejner, který určuje oblast samotného objektu (její rám) spolu s vlastnostmi, jako je velikost kontejneru, tvar a pozadí. Další informace naleznete v [Shape Layout Format](https://docs.aspose.com/slides/cs/python-net/shape-manipulations/#access-layout-formats-for-shape).

Nicméně když PowerPoint pracuje s ink objektem, ignoruje všechny vlastnosti rámu objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními vlastnostmi [Ink.width](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ink/ink/width/) a [Ink.height](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ink/ink/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink stopy**

Ink stopa je základní prvek používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopa ukládá sekvenci spojených bodů.

Nejjednodušší forma kódování určuje souřadnice X a Y každého vzorkovacího bodu. Když jsou všechny spojené body vykresleny, vznikne obrázek jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Štětec se používá k nakreslení čar, které spojují body ink stopy. Jeho vlastnosti [InkBrush.color](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ink/inkbrush/color/) a [InkBrush.size](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ink/inkbrush/size/) řídí barvu a velikost.

### **Nastavení barvy ink štětce**

Tento Python kód ukazuje, jak nastavit barvu ink štětce:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Nastavení velikosti ink štětce**

Tento Python kód ukazuje, jak nastavit velikost ink štětce:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Obecně šířka a výška štětce nesedí, takže PowerPoint nezobrazuje velikost štětce (odpovídající část dat je šedá). Když šířka a výška štětce odpovídají, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku ink objektu a podíváme se na důležité rozměry:

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rám) nebere v úvahu velikost štětců – vždy předpokládá, že tloušťka čáry je nula (viz předchozí obrázek).

Proto je pro určení viditelné oblasti celého ink objektu nutné zohlednit velikost štětce jeho stop. Zde byl cílový objekt (stopa ručně psaného textu) přepočítán na velikost kontejneru (rámu). Když se velikost kontejneru změní, velikost štětce zůstane konstantní a naopak.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint používá podobné chování pro textové objekty:

![ink_powerpoint6](ink_powerpoint6.png)

## **Řízení vzhledu Ink během exportu a vykreslování**

Aspose.Slides poskytuje třídu [InkOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/inkoptions/) pro řízení toho, jak se ink objekty zobrazují v exportovaném nebo vykresleném výstupu. Pomocí jejích vlastností můžete ink úplně skrýt nebo změnit způsob, jakým jsou interpretovány operace masky ink štětce.

Možnosti ink jsou k dispozici prostřednictvím možností exportu nebo vykreslování pro několik výstupních typů:

| Výstup | Vlastnost Ink možností |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Slide image | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/renderingoptions/ink_options/) |

Stejné dvě nastavení jsou dostupná prostřednictvím těchto vlastností:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/inkoptions/hide_ink/) určuje, zda jsou ink objekty zahrnuty do výstupu. Výchozí hodnota je `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) určuje, zda je masková operace interpretována jako neprůhlednost při vykreslování ink štětce. Výchozí hodnota je `True`; nastavením na `False` použijete operaci ROP.

### **Skrytí Ink objektů ve výstupu PDF**

Ve výchozím nastavení jsou ink objekty během exportu viditelné. Nastavte [InkOptions.hide_ink](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/inkoptions/hide_ink/) na `True`, pokud potřebujete čistý výstup bez ručně psaných poznámek nebo jiného ink obsahu.

Následující Python příklad exportuje prezentaci do PDF a skryje všechny ink objekty:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Skrytí Ink objektů při vykreslování snímku jako obrázku**

Pro skrytí ink objektů při vykreslování snímků jako bitmapových obrázků nakonfigurujte [RenderingOptions.ink_options](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/renderingoptions/ink_options/) a předávejte vykreslovací možnosti metodě [Slide.get_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/).

Následující Python příklad vykreslí první snímek jako PNG obrázek bez ink objektů:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Řízení vykreslování masky Ink**

Vlastnost [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) řídí, jak jsou maskové operace interpretovány při vykreslování ink štětců. Výchozí hodnota je `True`, což používá neprůhlednost. Nastavením na `False` použijete operaci ROP.

Následující Python příklad exportuje snímek do SVG a použije vykreslování založené na ROP pro operace masky ink:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Stejné nastavení lze použít prostřednictvím [TiffOptions.ink_options](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/ink_options/) při exportu prezentace nebo vykreslování snímku do TIFF.

### **Zvolte, zda skrýt nebo zachovat Ink**

Nastavte [InkOptions.hide_ink](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/inkoptions/hide_ink/) na `True`, když má být exportovaný soubor čistou verzí anotované prezentace, například finální kopií určenou k distribuci bez revizních značek.

Nechte [InkOptions.hide_ink](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/inkoptions/hide_ink/) na výchozí hodnotě `False`, když jsou ink anotace součástí zamýšleného obsahu, např. revizní komentáře, ručně psané poznámky, zvýraznění nebo kresby, které mají zůstat ve výsledném exportu viditelné. To umožňuje aplikacím generovat samostatné revizní a finální výstupy ze stejné prezentace bez úpravy původních ink objektů.

## **Často kladené otázky**

**Mohu změnit barvu nebo velikost existujícího ink tahu?**

Ano. Získejte stopu z [Ink.traces](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ink/ink/traces/), pak změňte její [InkTrace.brush](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ink/inktrace/brush/). Můžete nastavit [InkBrush.color](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ink/inkbrush/color/) a [InkBrush.size](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ink/inkbrush/size/) štětce.

**Změní skrytí inku zdrojovou prezentaci?**

Ne. [InkOptions.hide_ink](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/inkoptions/hide_ink/) ovlivňuje pouze vykreslený nebo exportovaný výsledek; neodstraňuje ani nemodifikuje ink objekty ve zdrojové prezentaci.

**Které exportní formáty podporují možnosti ink?**

Možnosti ink můžete konfigurovat pro PDF, HTML, SVG, TIFF a bitmapové obrázky snímků prostřednictvím odpovídajících možností exportu nebo vykreslování uvedených výše.

**Další čtení**

* Pro obecné informace o tvarech viz sekce [PowerPoint Shapes](https://docs.aspose.com/slides/cs/python-net/powerpoint-shapes/).
* Pro podrobnosti o efektivních hodnotách viz [Shape Effective Properties](https://docs.aspose.com/slides/cs/python-net/shape-effective-properties/#get-effective-font-height-value).
* Pro podrobnosti o exportu do PDF viz [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/cs/python-net/convert-powerpoint-to-pdf/).
* Pro podrobnosti o exportu do HTML viz [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/cs/python-net/convert-powerpoint-to-html/).
* Pro podrobnosti o exportu do SVG viz [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/cs/python-net/render-a-slide-as-an-svg-image/).
* Pro podrobnosti o exportu do TIFF viz [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/cs/python-net/convert-powerpoint-to-tiff/).
* Pro podrobnosti o vykreslování snímků do obrázků viz [Convert Presentation Slides to Images](https://docs.aspose.com/slides/cs/python-net/convert-slide/).