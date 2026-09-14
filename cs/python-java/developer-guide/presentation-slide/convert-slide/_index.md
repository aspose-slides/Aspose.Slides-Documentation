---
title: Převod snímků prezentace na obrázky v Pythonu
linktitle: Snímek na obrázek
type: docs
weight: 35
url: /cs/python-java/convert-slide/
keywords:
- převést snímek
- exportovat snímek
- snímek na obrázek
- uložit snímek jako obrázek
- snímek na EMF
- snímek na PNG
- snímek na JPEG
- snímek na bitmapu
- snímek na TIFF
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Převádějte snímky z prezentací PPT, PPTX a ODP do formátů PNG, JPEG, GIF, TIFF, EMF a dalších obrazových formátů v Pythonu s Aspose.Slides."
---
## **Úvod**

Aspose.Slides for Python via Java může vykreslovat jednotlivé snímky z prezentací PowerPoint a OpenDocument jako PNG, JPEG, GIF, TIFF a další formáty obrázků.

Chcete-li převést snímek na obrázek, postupujte podle následujících kroků:

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Vyberte snímek, který chcete vykreslit.
3. V případě potřeby nakonfigurujte vykreslování pomocí třídy [RenderingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/renderingoptions/) nebo třídy [TiffOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/).
4. Zavolejte metodu [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage). Vrací objekt obrázku.
5. Uložte obrázek a zadejte výstupní formát pomocí hodnoty [ImageFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imageformat/).

## **Převod snímku na PNG obrázek**

Nejjednodušší převod používá výchozí nastavení vykreslování. Výsledný objekt obrázku lze zpracovat v paměti nebo uložit do souboru.

Následující příklad v Pythonu vykreslí první snímek a uloží jej jako PNG obrázek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Převod snímků na obrázky s vlastními rozměry**

Použijte přetížení metody [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage), které přijímá hodnotu [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) pro vykreslení snímku s přesnými rozměry v pixelech.

Následující příklad vytvoří JPEG obrázek o rozměrech 1820 × 1040:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Ve výchozím nastavení obrázky snímků neobsahují poznámky ani komentáře. Předávejte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/) metodě [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions), abyste určili, kde se mají poznámky a komentáře zobrazit.

Následující příklad umístí zkrácené poznámky pod snímek a komentáře vpravo od něj:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Pro převod snímků na obrázky nepředávejte [BottomFull](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notespositions/#BottomFull) metodě [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Poznámky mohou obsahovat více textu, než je možné zobrazit ve fixním rozměru obrázku. Použijte místo toho [BottomTruncated](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notespositions/#BottomTruncated).
{{% /alert %}}

## **Převod snímků na obrázky pomocí TIFF možností**

Třída [TiffOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/) vám umožňuje řídit velikost, rozlišení a další vlastnosti vykresleného TIFF obrázku.

Následující příklad vykreslí první snímek jako TIFF obrázek o rozměrech 2160 × 2880 při 300 DPI:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Podpora TIFF není zaručena ve verzích Javy starších než JDK 9.
{{% /alert %}}

## **Převod všech snímků na obrázky**

Procházejte kolekci snímků a převádějte celou prezentaci na sérii obrázků. Skryté snímky jsou zahrnuty, pokud je výslovně nevynecháte.

Následující příklad vykreslí každý snímek jako JPEG obrázek se horizontálním a vertikálním měřítkem 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Vytvoření výstupu Enhanced Metafile**

Enhanced Metafile (EMF) je užitečný, když je potřeba vyměňovat vektorovou grafiku s Microsoft Office nebo jinými aplikacemi Windows, které podporují Windows metafily. Na rozdíl od obrázku založeného na pixelech může EMF zachovat vektorové kreslící operace, které se škálují bez ztráty ostrosti. Avšak EMF je především formát kompatibility pro aplikace s podporou Windows metafilů, nikoli univerzální výměnný formát. Navíc složitý obsah snímku, jako jsou bitmapové obrázky a některé efekty, může být uložen jako rasterizované prvky uvnitř kontejneru vektorového metafilu.

### **Export snímku do EMF**

Metoda [Slide.writeAsEmf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/) zapíše [Slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/) do cílového proudu ve formátu EMF. Následující příklad načte prezentaci, vybere první snímek a zapíše jej do EMF souborového proudu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

Volající vlastní proud předaný metodě [Slide.writeAsEmf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/) a je zodpovědný za jeho uzavření, jak je uvedeno výše.

### **Převod SVG obrázku do EMF a přidání do prezentace**

Použijte [SvgImage.writeAsEmf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/) k převodu SVG obsahu do EMF. Výsledné bajty lze přidat do prezentace pomocí [ImageCollection.addImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/#addImage) a umístit na snímek pomocí [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addPictureFrame).

Následující příklad vytvoří [SvgImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/) ze SVG značkování, převede jej na EMF v paměti, vloží metafil na první snímek a uloží prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/svgimage/) nepřebírá vlastnictví cílového proudu. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) ukládá všechna vygenerovaná data do paměti, takže není potřeba před voláním [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--) resetovat pozici. Vrácený pole bajtů zůstává platné i po uzavření proudu.

Generování EMF je k dispozici na operačních systémech podporovaných vybranou verzí Aspose.Slides for Python via Java a konfigurací JDK, ale vykreslování se může lišit mezi platformami, pokud nejsou dostupné fonty nebo grafické závislosti. Nainstalujte fonty použité ve zdrojovém obsahu nebo nakonfigurujte vhodné náhrady, řiďte se [platform requirements](/slides/cs/python-java/system-requirements/) pro Aspose.Slides for Python via Java a ověřte výsledek v cílové aplikaci používající EMF. Aplikace na Linuxu a macOS často mají omezenou nebo nekonzistentní podporu pro zobrazování a úpravu Windows metafilů.

## **Vykreslování barevných Emoji**

{{% alert title="Note" color="info" %}}
Pro správné vykreslení barevných emoji při převodu snímků prezentace na obrázky je nutné, aby byly fonty emoji použité v prezentaci nainstalovány a dostupné na systému provádějícím převod. Například pokud prezentace používá **Segoe UI Emoji** a tento font chybí, mohou se emoji v výstupních obrázcích zobrazovat v černobílém provedení.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne. Metoda [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) vykreslí statický obrázek snímku a neexportuje animace.

**Lze skryté snímky exportovat jako obrázky?**

Ano. Skryté snímky lze vykreslit stejně jako běžné snímky. Zahrňte je do smyčky zpracování, jak je ukázáno v příkladu výše.

**Jsou stíny a další efekty zachovány v obrázcích snímků?**

Ano. Aspose.Slides vykresluje stíny, průhlednost a další podporované grafické efekty v obrázcích snímků.