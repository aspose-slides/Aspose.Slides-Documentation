---
title: Převod snímků prezentace na obrázky v Pythonu
linktitle: Snímek na obrázek
type: docs
weight: 41
url: /cs/python-net/convert-slide/
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
description: "Převod snímků z prezentací PPT, PPTX a ODP na PNG, JPEG, GIF, TIFF, EMF a další formáty obrázků v Pythonu pomocí Aspose.Slides."
---
## **Úvod**

Aspose.Slides for Python via .NET může vykreslovat jednotlivé snímky z prezentací PowerPoint a OpenDocument jako PNG, JPEG, GIF, TIFF a další formáty obrázků.

Pro převod snímku na obrázek postupujte následovně:

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Vyberte snímek, který chcete vykreslit.
3. V případě potřeby nakonfigurujte vykreslování pomocí třídy [RenderingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/renderingoptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/).
4. Zavolejte metodu [Slide.get_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/). Vrátí objekt [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/).
5. Zavolejte metodu [IImage.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/save/) a určete výstupní formát pomocí hodnoty [ImageFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imageformat/).

## **Převod snímku na PNG obrázek**

Nejjednodušší převod používá výchozí nastavení vykreslování. Výsledný objekt [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) lze zpracovat v paměti nebo uložit do souboru.

Následující příklad v Pythonu vykreslí první snímek a uloží jej jako PNG obrázek:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Převod snímků na obrázky s vlastními rozměry**

Použijte přetížení [Slide.get_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/#asposepydrawingsize), které přijímá hodnotu [Size](https://reference.aspose.com/slides/cs/python-net/aspose.pydrawing/size/) pro vykreslení snímku s přesnými rozměry v pixelech.

Následující příklad vytvoří JPEG obrázek o rozměrech 1820 × 1040:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Ve výchozím nastavení obrázky snímků neobsahují poznámky ani komentáře. Přiřaďte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notescommentslayoutingoptions/) do vlastnosti [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) pro určení, kde se mají poznámky a komentáře zobrazit.

Následující příklad umístí zkrácené poznámky pod snímek a komentáře napravo:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
Pro převod snímku na obrázek nenastavujte vlastnost [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) na [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notespositions/). Poznámky mohou obsahovat více textu, než je kapacita pevně daného obrázku. Místo toho použijte [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Převod snímků na obrázky pomocí TIFF možností**

Třída [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/) umožňuje řídit velikost, rozlišení a další vlastnosti vykresleného TIFF obrázku.

Následující příklad vykreslí první snímek jako TIFF obrázek o rozměrech 2160 × 2880 při 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Převod všech snímků na obrázky**

Procházejte kolekci snímků a převádějte celou prezentaci na sérii obrázků. Skryté snímky jsou zahrnuty, pokud je explicitně nevynecháte.

Následující příklad vykreslí každý snímek jako JPEG obrázek se horizontálními a vertikálními měřítky 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Vytvoření výstupu ve formátu Enhanced Metafile**

Enhanced Metafile (EMF) je užitečný, pokud je třeba vyměňovat vektorovou grafiku s Microsoft Office nebo jinými aplikacemi Windows, které podporují Windows metafily. Na rozdíl od obrázku založeného na pixelech může EMF zachovat vektorové kreslicí operace, které se škálují bez ztráty ostrosti. EMF však slouží hlavně jako formát kompatibility pro aplikace s podporou Windows metafile, nikoli jako univerzální výměnný formát. Navíc složitý obsah snímků, jako jsou bitmapové obrázky a některé efekty, může být uložen jako rasterizované prvky uvnitř kontejneru vektorového metafile.

### **Export snímku do EMF**

Metoda [Slide.write_as_emf](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/write_as_emf/) zapisuje [Slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/) do cílového streamu ve formátu EMF. Následující příklad načte prezentaci, vybere první snímek a zapíše jej do EMF souborového streamu:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

Volající vlastní stream předaný metodě [Slide.write_as_emf](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/write_as_emf/) a musí jej uzavřít. Aspose.Slides zapisuje na aktuální pozici streamu a nechává stream otevřený.

### **Převod SVG obrázku na EMF a jeho přidání do prezentace**

Použijte [SvgImage.write_as_emf](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/write_as_emf/) pro převod SVG obsahu na EMF. Výsledná data lze přidat do prezentace pomocí [ImageCollection.add_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/add_image/) a umístit na snímek pomocí [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_picture_frame/).

Následující příklad vytvoří [SvgImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/) ze SVG značkování, převádí jej na EMF v paměti, vloží metafile na první snímek a uloží prezentaci:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/cs/python-net/aspose.slides/svgimage/write_as_emf/) nepřebírá vlastnictví cílového streamu. Po zápisu je pozice streamu na konci vytvořených dat. Zavolejte `getvalue` pro získání kompletního bufferu bez ohledu na aktuální pozici streamu, jak je ukázáno výše. Stream ponechte otevřený, dokud nejsou data přečtena, a poté jej uzavřete.

Generování EMF je k dispozici na operačních systémech podporovaných Aspose.Slides for Python via .NET, ale vykreslování může na různých platformách lišit, pokud chybí fonty nebo nativní grafické závislosti. Nainstalujte fonty použité ve zdrojovém obsahu nebo nakonfigurujte vhodné náhrady, dodržujte [platform requirements](/slides/cs/python-net/system-requirements/) pro Aspose.Slides a ověřte výsledek v cílové aplikaci spotřebovávající EMF. Aplikace na Linuxu a macOS často mají omezenou nebo nekonzistentní podporu pro zobrazování a úpravu Windows metafile.

## **Renderování barevných emoji**

{{% alert title="Note" color="info" %}}
Pro správné vykreslení barevných emoji při převodu snímků prezentace na obrázky musí být fonty emoji použité v prezentaci nainstalovány a dostupné v systému, který provádí převod. Například pokud prezentace používá **Segoe UI Emoji** a tento font chybí, mohou se emoji v výstupních obrázcích zobrazovat monochromaticky.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides renderování snímků s animacemi?**

Ne. Metoda [Slide.get_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/) vykresluje statický obrázek snímku a neexportuje animace.

**Lze exportovat skryté snímky jako obrázky?**

Ano. Skryté snímky lze vykreslit jako běžné snímky. Zahrňte je do smyčky zpracování, jak je ukázáno v příkladu výše.

**Zachovají se stíny a další efekty v obrázcích snímků?**

Ano. Aspose.Slides vykresluje stíny, průhlednost a další podporované grafické efekty v obrázcích snímků.