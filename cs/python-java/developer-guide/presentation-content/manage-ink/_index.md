---
title: Spravovat objekty ink v PowerPointu v Pythonu přes Java
linktitle: Spravovat Ink
type: docs
weight: 95
url: /cs/python-java/manage-ink/
keywords:
- ink
- objekt ink
- stopa ink
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
- Java
- Aspose.Slides
description: "Spravujte objekty ink v PowerPointu, upravujte stopy a vlastnosti štětců a řiďte vzhled ink při exportu do PDF, HTML, SVG, TIFF a obrázků s Aspose.Slides pro Python přes Java."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která vám umožňuje kreslit volné tahy. Ink lze použít k zvýraznění dalších objektů, zobrazení spojení a procesů a upoutání pozornosti na konkrétní položky na snímku.

Aspose.Slides poskytuje typy potřebné pro práci s objekty ink. Například třída [Ink](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ink/) představuje objekt ink na snímku.

## **Rozdíly mezi běžnými objekty a objekty ink**

Objekty na snímku PowerPointu jsou typicky reprezentovány objekty tvaru (shape). V nejjednodušší podobě je tvar kontejner, který určuje oblast samotného objektu (jeho rámec) spolu s vlastnostmi, jako je velikost kontejneru, tvar a pozadí. Další informace naleznete v [Formát rozvržení tvaru](/slides/cs/python-java/shape-manipulations/#access-layout-formats-for-shape).

Nicméně když PowerPoint pracuje s objektem ink, ignoruje všechny vlastnosti rámce objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními metodami [Shape.getWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getWidth) a [Shape.getHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Stopy ink**

Stopa ink je základní prvek používaný k zaznamenání dráhy pera, když uživatel píše digitální ink. Stopa ukládá sekvenci spojených bodů.

Nejjednodušší forma kódování určuje souřadnice X a Y každého vzorkového bodu. Po vykreslení všech spojených bodů vznikne obrázek jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Štětec se používá k kreslení čar, které spojují body stopy ink. Štětec má vlastní barvu a velikost, které jsou reprezentovány metodami [InkBrush.getColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkbrush/#getColor) a [InkBrush.getSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkbrush/#getSize).

### **Nastavení barvy štětce ink**

Tento Python kód ukazuje, jak nastavit barvu štětce ink:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Nastavení velikosti štětce ink**

Tento Python kód ukazuje, jak nastavit velikost štětce ink:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

Obecně šířka a výška štětce neodpovídají, takže PowerPoint nezobrazuje velikost štětce (příslušná sekce dat je šedá). Když šířka a výška štětce odpovídají, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku objektu ink a podíváme se na důležité rozměry:

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rámec) nezohledňuje velikost štětců – vždy předpokládá nulovou tloušťku čáry (viz předchozí obrázek).

Proto je při určení viditelné oblasti celého objektu ink nutné vzít v úvahu velikost štětce jeho stop. Zde byl cílový objekt (stopa rukou psaného textu) přepočítán na velikost kontejneru (rámce). Když se velikost kontejneru změní, velikost štětce zůstává konstantní a naopak.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint používá podobné chování pro textové objekty:

![ink_powerpoint6](ink_powerpoint6.png)

## **Řízení vzhledu ink při exportu a vykreslování**

Aspose.Slides poskytuje třídu [InkOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkoptions/), která umožňuje řídit, jak se objekty ink zobrazují v exportovaném nebo vykresleném výstupu. Můžete použít její vlastnosti k úplnému skrytí ink nebo ke změně interpretace operací masky štětce ink.

Ink options jsou k dispozici prostřednictvím možností exportu nebo vykreslování pro několik typů výstupů:

| Výstup | Vlastnost Ink options |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/renderingoptions/#getInkOptions) |

Následující metody [InkOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkoptions/) odhalují stejné dva nastavení:

- [getHideInk](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkoptions/#getHideInk) určuje, zda jsou objekty ink zahrnuty ve výstupu. Jeho výchozí hodnota je `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) určuje, zda je operace masky interpretována jako průhlednost při vykreslování štětce ink. Jeho výchozí hodnota je `True`; zavolejte [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) s `False` pro použití operace ROP místo toho.

### **Skrytí objektů ink v PDF výstupu**

Ve výchozím nastavení zůstávají objekty ink při exportu viditelné. Pro vytvoření čistého výstupu bez ručně psaných anotací nebo jiného obsahu ink zavolejte [InkOptions.setHideInk](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkoptions/#setHideInk) s `True`.

Následující Python příklad exportuje prezentaci do PDF a skryje všechny objekty ink:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Skrytí objektů ink při vykreslování snímku jako obrázku**

Pro skrytí objektů ink při vykreslování snímků jako bitmapových obrázků nakonfigurujte [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/renderingoptions/#getInkOptions) a předávejte možnosti vykreslování metodě [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage).

Následující Python příklad vykreslí první snímek jako PNG obrázek bez objektů ink:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Řízení vykreslování masky ink**

Nastavení [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) řídí, jak jsou operace masky interpretovány při vykreslování štětců ink. Výchozí hodnota je `True`, což používá průhlednost. Pro použití operace ROP místo toho zavolejte [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) s `False`.

Následující Python příklad exportuje snímek do SVG a používá vykreslování založené na ROP pro operace masky ink:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

Stejné nastavení lze aplikovat pomocí [TiffOptions.getInkOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/#getInkOptions) při exportu prezentace nebo vykreslování snímku do TIFF.

### **Zvolte, zda skrýt nebo zachovat ink**

Když potřebujete čistou verzi anotované prezentace pro šíření bez kontrolních značek, zavolejte [InkOptions.setHideInk](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkoptions/#setHideInk) s `True` během exportu.

Nechte [InkOptions.getHideInk](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkoptions/#getHideInk) na jeho výchozí hodnotě `False`, pokud jsou anotace ink součástí zamýšleného obsahu, například recenzní komentáře, ručně psané poznámky, zvýraznění nebo kresby, které by měly zůstat ve výsledném exportu viditelné. To umožňuje aplikacím generovat samostatné recenzní a finální výstupy ze stejné prezentace bez úpravy původních objektů ink.

## **Časté otázky**

**Mohu změnit barvu nebo velikost existujícího tahu ink?**

Ano. Získejte stopu pomocí [Ink.getTraces](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ink/#getTraces) a poté změňte její [InkTrace.getBrush](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inktrace/#getBrush). Zavolejte [InkBrush.setColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkbrush/#setColor) nebo [InkBrush.setSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkbrush/#setSize) pro změnu štětce.

**Změní skrytí inku zdrojovou prezentaci?**

Ne. Zavolání [InkOptions.setHideInk](https://reference.aspose.com/slides/cs/python-java/aspose.slides/inkoptions/#setHideInk) ovlivní pouze vykreslený nebo exportovaný výsledek; neodstraní ani nezmění objekty ink ve zdrojové prezentaci.

**Které formáty exportu podporují nastavení ink?**

Nastavení ink můžete konfigurovat pro PDF, HTML, SVG, TIFF a bitmapové obrázky snímků pomocí odpovídajících možností exportu nebo vykreslování uvedených výše.

**Další čtení**

* Pro čtení o tvarech obecně se podívejte na sekci [PowerPoint Shapes](/slides/cs/python-java/powerpoint-shapes/).
* Pro více informací o efektivních hodnotách viz [Efektivní vlastnosti tvaru](/slides/cs/python-java/shape-effective-properties/#get-effective-font-height-value).
* Pro podrobnosti o exportu PDF viz [Převod PPT a PPTX do PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/).
* Pro podrobnosti o exportu HTML viz [Převod prezentací PowerPoint do HTML](/slides/cs/python-java/convert-powerpoint-to-html/).
* Pro podrobnosti o exportu SVG viz [Vykreslení snímků prezentace jako SVG obrázky](/slides/cs/python-java/render-a-slide-as-an-svg-image/).
* Pro podrobnosti o exportu TIFF viz [Převod prezentací PowerPoint do TIFF](/slides/cs/python-java/convert-powerpoint-to-tiff/).
* Pro podrobnosti o vykreslování snímků na obrázky viz [Převod snímků prezentace na obrázky](/slides/cs/python-java/convert-slide/).