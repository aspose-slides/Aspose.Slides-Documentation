---
title: Vylepšete zpracování obrazu pomocí Moderního API v Pythonu
linktitle: Moderní API
type: docs
weight: 237
url: /cs/python-java/modern-api/
keywords:
- moderní API
- kreslení
- miniatura snímku
- snímek na obrázek
- miniatura tvaru
- tvar na obrázek
- miniatura prezentace
- prezentace na obrázky
- přidat obrázek
- přidat fotografii
- Python
- Java
- Aspose.Slides
description: "Modernizujte zpracování obrazu v Pythonu přes Java: renderujte snímky a tvary, přidávejte obrázky a migrujte zastaralá volání pro zpracování obrazu na Moderní API Aspose.Slides."
---
## **Úvod**

Aspose.Slides for Python via Java přistupuje k Java knihovně přes JPype. Jeho staré API pro zpracování obrazu používalo [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) z `java.awt`.

Java knihovna tuto sadu obrazových API od verze 24.4 označila za zastaralou. Moderní API používá [IImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/) pro načítání, vykreslování a ukládání obrázků. Používejte jej v novém Python kódu i při migraci existujících pracovních postupů pro zpracování obrazu.

{{% alert color="info" title="Note" %}}
Staré názvy metod níže slouží jen jako reference pro migraci. V aktuálních verzích již nejsou k dispozici. Spustitelné příklady používají Moderní API.
{{% /alert %}}

## **Moderní API**

Hlavní typy pro zpracování obrazu jsou:

- [IImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/) — představuje rastrový nebo vektorový obrázek.
- [ImageFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imageformat/) — poskytuje konstanty formátu souboru obrázku.
- [Images](https://reference.aspose.com/slides/cs/python-java/aspose.slides/images/) — vytváří obrázky, například pomocí [Images.fromFile](https://reference.aspose.com/slides/cs/python-java/aspose.slides/images/#fromFile).

Použijte [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) nebo [Shape.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage) k vykreslení jednoho snímku nebo tvaru. Použijte [Presentation.getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages) s možnostmi vykreslení k vykreslení více snímků. Přetížení bez argumentů vrací kolekci obrázků prezentace.

Načtěte obrázek pomocí [Images.fromFile](https://reference.aspose.com/slides/cs/python-java/aspose.slides/images/#fromFile), přidejte jej pomocí [ImageCollection.addImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/#addImage) nebo aktualizujte existující obrázek prezentace pomocí [PPImage.replaceImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#replaceImage). Obě operace s kolekcí obrázků přijímají [IImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/).

Uvolněte každý načtený nebo vykreslený obrázek voláním jeho metody `dispose` v bloku `finally`. Uvolněte prezentaci pomocí [Presentation.dispose](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#dispose).

### **Připravte prostředí Pythonu**

Nainstalujte balíčky podle instrukcí v [Installation](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM, poté importuje API po spuštění JVM. Příklady nechávají JVM běžet, aby mohl být znovu použit. Viz [Limitations and API Differences](/slides/cs/python-java/limitations-and-api-differences/#import-the-library) pro pokyny k notebooku a životnímu cyklu JVM.

Příklady, které otevírají `pres.pptx`, vyžadují prezentaci v pracovním adresáři. Příklady, které načítají `image.png`, vyžadují existující soubor obrázku.

### **Načtěte obrázek a vykreslete snímek**

Tento příklad přidá obrázek na první snímek a uloží snímek jako JPEG obrázek. [IImage.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/#save) zapíše vykreslený obrázek ve zvoleném formátu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Nahrazení starého kódu moderním API**

Nahraďte volání starých miniatur metodami, které vrací [IImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/), a poté výsledek uložte pomocí [IImage.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/#save). Tím se odstraní potřeba předávat vykreslené obrázky do [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Vykreslete snímek ve specifikované velikosti**

Nahraďte staré volání `slide.getThumbnail(image_size)` metodou [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) se stejnou velikostí obrázku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Získání miniatury snímku**

Nahraďte staré volání `slide.getThumbnail()` metodou [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) bez argumentů.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Získání miniatury tvaru**

Nahraďte staré volání `shape.getThumbnail()` metodou [Shape.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage). Před přístupem zkontrolujte, že snímek obsahuje tvar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Získání miniatury prezentace**

Nahraďte staré volání `presentation.getThumbnails(options, image_size)` metodou [Presentation.getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages). Pro konfiguraci vykreslení použijte [RenderingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/renderingoptions/).

Iterujte přímo přes vrácené pole pomocí Python funkce `enumerate`. Uvolněte každý vrácený obrázek v bloku `finally`, aby selhání ukládání nenechalo zbývající obrázky neukončené.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Přidání obrázku do prezentace**

Nahraďte načítání pomocí [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) metodou [Images.fromFile](https://reference.aspose.com/slides/cs/python-java/aspose.slides/images/#fromFile), poté předávejte vzniklý obrázek metodě [ImageCollection.addImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/#addImage). Přidejte obrázek na snímek a uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zastaralé metody a jejich náhrada v moderním API**

Tabulky používají notaci volání v Pythonu. Názvy ve sloupci *Zastaralé volání* označují odebraná API; použijte odkazované náhradní metody. Moderní metody pro vykreslování obrázků vracejí objekty [IImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/) místo Java buffered images.

### **Prezentace**

| Zastaralé volání | Moderní náhrada |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages) s `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages) s `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages) s `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages) s `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages) s `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages) s `options, image_size` |

Zde `slides` je Java `int[]` jednojmenných čísel snímků; vytvořte jej pomocí `jpype.JArray(jpype.JInt)([1, 3])` pro výběr snímků 1 a 3. `image_size` je [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Tvar**

| Zastaralé volání | Moderní náhrada |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage) bez argumentů |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage) s `bounds, scale_x, scale_y` |

### **Snímek**

| Zastaralé volání | Moderní náhrada |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) bez argumentů |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) s `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) s `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) s `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) s `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) s `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) s `image_size` |
| `slide.renderToGraphics(options, graphics)` | Přímá náhrada neexistuje; renderujte do obrázku místo toho |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | Přímá náhrada neexistuje; renderujte do obrázku místo toho |
| `slide.renderToGraphics(options, graphics, image_size)` | Přímá náhrada neexistuje; renderujte do obrázku místo toho |

Zde `options` je [RenderingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/renderingoptions/), a `tiff_options` je [TiffOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/).

### **Výstup**

| Zastaralé volání | Moderní náhrada |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/cs/python-java/aspose.slides/output/#add) s `path, image`, kde `image` je [IImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Zastaralé volání | Moderní náhrada |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/#addImage) s [IImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/) |

### **PPImage**

| Zastaralé volání | Moderní náhrada |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#getImage) |

Pro nahrazení obsahu existujícího obrázku v prezentaci použijte [PPImage.replaceImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#replaceImage) s [IImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Zastaralé volání | Moderní náhrada |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/cs/python-java/aspose.slides/patternformat/#getTile) s `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/cs/python-java/aspose.slides/patternformat/#getTile) s `background, foreground` |

Argumenty barvy zůstávají Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html) objekty.

### **PatternFormatEffectiveData**

Pro efektivní data vzoru vrácená Java API přes JPype zachovává náhradní metoda název `getTileIImage`.

| Zastaralé volání | Moderní náhrada |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, vrací [IImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/) |

## **Podpora API pro Graphics2D**

Zastaralá přetížení `renderToGraphics` kreslila do kontextu volajícího [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html). Moderní API nemá přímou náhradu, která by kreslila do tohoto kontextu.

Použijte [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) k vykreslení snímku nebo [Presentation.getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages) k vykreslení několika snímků a poté uložte vrácené obrázky pomocí [IImage.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/#save). Aplikace, které kombinovaly vykreslování snímků s vlastním Java kreslením, budou muset upravit krok skládání.

## **Časté dotazy**

**Proč bylo staré Java image API nahrazeno?**

Moderní API přesouvá načítání, vykreslování a ukládání obrázků do [IImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/iimage/). Tím se poskytuje jednotná abstrakce obrazu místo vystavení Java buffered images nebo Java grafického kontextu.

**Potřebuji stále Java a JPype?**

Ano. Aspose.Slides for Python via Java stále běží na JVM. Moderní API mění jen volání pro zpracování obrazu, ne požadavky na runtime. Viz [System Requirements](/slides/cs/python-java/system-requirements/).

**Jak v Pythonu uvolňuji obrázky?**

Volajte `dispose` na každý obrázek, který načtete nebo vykreslíte, v bloku `finally`. Pokud vykreslujete několik snímků, uvolněte každý obrázek v vráceném poli. Prezentaci uvolněte samostatně pomocí [Presentation.dispose](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#dispose).

**Zaručuje přechod na Moderní API rychlejší generování miniatur?**

Žádné zlepšení výkonu není garantováno. Náhrady podporují možnosti vykreslení, škálování a velikosti obrázku; výkon měřte na svých prezentacích a nastaveních výstupu.

**Proč getter obrázku někdy vrací kolekci?**

[Presentation.getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages) bez argumentů vrací vestavěné obrázky prezentace. Jeho přetížení s možnostmi vykreslení vrací vykreslené obrázky snímků.