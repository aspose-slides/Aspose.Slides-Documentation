---
title: "Přidání rámečků obrázků do prezentací v Pythonu"
linktitle: "Rámeček obrázku"
type: docs
weight: 10
url: /cs/python-net/picture-frame/
keywords:
- "rámeček obrázku"
- "přidat rámeček obrázku"
- "vytvořit rámeček obrázku"
- "přidat obrázek"
- "vytvořit obrázek"
- "extrahovat obrázek"
- "rastrový obrázek"
- "vektorový obrázek"
- "oříznout obrázek"
- "oříznutá oblast"
- "vlastnost StretchOff"
- "formátování rámečku obrázku"
- "vlastnosti rámečku obrázku"
- "relativní měřítko"
- "efekt obrázku"
- "poměr stran"
- "průhlednost obrázku"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Python"
- "Aspose.Slides"
description: "Přidejte rámečky obrázků do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET. Zefektivněte svůj pracovní postup a vylepšete návrhy snímků."
---
## **Úvod**

Rámečky obrázků v Aspose.Slides pro Python vám umožňují umisťovat a spravovat rastrové i vektorové obrázky jako nativní tvary snímků. Můžete vkládat obrázky ze souborů nebo streamů, umisťovat je a měnit jejich velikost pomocí přesných souřadnic, aplikovat otáčení, nastavit průhlednost a ovládat pořadí Z spolu s ostatními tvary. API také podporuje ořezávání, zachování poměru stran, nastavení okrajů a efektů a nahrazení podkladového obrázku bez přestavby rozvržení. Protože rámečky obrázků se chovají jako běžné tvary, můžete přidávat animace, hypertextové odkazy a alternativní text, což usnadňuje vytvářet vizuálně bohaté a přístupné prezentace.

## **Vytvoření rámečků obrázků**

V této sekci je ukázáno, jak vložit obrázek do snímku vytvořením [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) pomocí Aspose.Slides pro Python. Naučíte se, jak načíst obrázek, přesně jej umístit na snímek a ovládat jeho velikost a formátování.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte snímek podle jeho indexu.
3. Vytvořte [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) přidáním obrázku do [ImageCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/) prezentace. Tento obrázek bude použit k vyplnění tvaru.
4. Zadejte šířku a výšku rámce.
5. Vytvořte [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) s touto velikostí pomocí metody [add_picture_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Uložte prezentaci jako soubor PPTX.

Následující Python kód ukazuje, jak vytvořit rámeček obrázku:

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte obrázek do prezentace.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Přidejte rámeček obrázku s rozměry odpovídajícími obrázku.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Uložte prezentaci jako PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Rámečky obrázků vám umožňují rychle vytvářet snímky prezentace z obrázků. Když kombinujete rámečky obrázků s možnostmi ukládání Aspose.Slides, můžete řídit operace I/O pro konverzi obrázků z jednoho formátu do druhého. Můžete se podívat na tyto stránky: převod [image to JPG](https://products.aspose.com/slides/cs/python-net/conversion/image-to-jpg/); převod [JPG to image](https://products.aspose.com/slides/cs/python-net/conversion/jpg-to-image/); převod [JPG to PNG](https://products.aspose.com/slides/cs/python-net/conversion/jpg-to-png/); převod [PNG to JPG](https://products.aspose.com/slides/cs/python-net/conversion/png-to-jpg/); převod [PNG to SVG](https://products.aspose.com/slides/cs/python-net/conversion/png-to-svg/); převod [SVG to PNG](https://products.aspose.com/slides/cs/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Vytvoření rámečků obrázků s relativním měřítkem**

V této sekci je ukázáno umístění obrázku s pevnou velikostí a poté aplikace škálování založeného na procentech nezávisle na šířce i výšce. Protože procenta se mohou lišit, může se změnit poměr stran. Škálování se provádí relativně k původním rozměrům obrázku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte snímek podle jeho indexu.
3. Vytvořte [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) přidáním obrázku do [ImageCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/) prezentace.
4. Přidejte [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) na snímek.
5. Nastavte relativní šířku a výšku rámečku obrázku.
6. Uložte prezentaci jako soubor PPTX.

Následující Python kód ukazuje, jak vytvořit rámeček obrázku s relativním škálováním:

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte obrázek do kolekce obrázků prezentace.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Přidejte rámeček obrázku na snímek.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Nastavte relativní měřítko šířky a výšky.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Uložte prezentaci.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Extrahování rastrových obrázků z rámečků obrázků**

Můžete extrahovat rastrové obrázky z objektů [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) a uložit je ve formátech PNG, JPG a dalších. Níže uvedený příklad kódu ukazuje, jak extrahovat obrázek z dokumentu "sample.pptx" a uložit jej ve formátu PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Extrahování SVG obrázků z rámečků obrázků**

Když prezentace obsahuje SVG grafiku umístěnou uvnitř tvarů [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/), Aspose.Slides pro Python přes .NET vám umožňuje získat původní vektorové obrázky v plné věrnosti. Procházením kolekce tvarů snímku můžete identifikovat každý [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/), zkontrolovat, zda podkladový [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) obsahuje SVG obsah, a poté uložit tento obrázek na disk nebo do proudu v jeho nativním SVG formátu.

Následující ukázkový kód demonstruje, jak extrahovat SVG obrázek z rámečku obrázku:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Získání průhlednosti obrázku**

Aspose.Slides vám umožňuje získat efekt průhlednosti aplikovaný na obrázek. Tento Python kód demonstruje operaci:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
Všechny efekty aplikované na obrázky lze najít v [aspose.slides.effects](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Formátování rámečku obrázku**

Aspose.Slides poskytuje mnoho možností formátování, které můžete použít na rámeček obrázku. S těmito možnostmi můžete upravit rámeček obrázku tak, aby splňoval konkrétní požadavky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte snímek podle jeho indexu.
3. Vytvořte [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) přidáním obrázku do [ImageCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/) prezentace. Tento obrázek bude použit k vyplnění tvaru.
4. Zadejte šířku a výšku rámce.
5. Vytvořte [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) s touto velikostí pomocí metody [add_picture_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Nastavte barvu čáry rámečku obrázku.
7. Nastavte šířku čáry rámečku obrázku.
8. Otočte rámeček obrázku zadáním kladné (po směru hodinových ručiček) nebo záporné (proti směru hodinových ručiček) hodnoty.
9. Uložte upravenou prezentaci jako soubor PPTX.

Následující Python kód demonstruje proces formátování rámečku obrázku:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte obrázek do kolekce obrázků prezentace.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Přidejte rámeček obrázku s rozměry odpovídajícími obrázku.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Aplikujte formátování na rámeček obrázku.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Uložte prezentaci jako PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose vyvinulo zdarma [Collage Maker](https://products.aspose.app/slides/cs/collage). Pokud potřebujete [sloučit JPG/JPEG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG obrázky, nebo [vytvořit fotografické mřížky](https://products.aspose.app/slides/cs/collage/photo-grid), můžete tento servis použít.
{{% /alert %}}

## **Přidání obrázků jako odkazů**

Aby byly soubory prezentací malé, můžete přidávat obrázky nebo videa pomocí odkazů místo vkládání souborů přímo do prezentací. Následující Python kód ukazuje, jak vložit obrázek a video do zástupného symbolu:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ořezávání obrázků**

V této sekci se naučíte oříznout viditelnou oblast obrázku v rámečku obrázku bez změny zdrojového souboru. Také se seznámíte se základní metodou aplikace ořezových okrajů pro vytvoření čisté, soustředěné kompozice přímo na snímku.

Následující Python kód ukazuje, jak oříznout obrázek na snímku:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Přidejte obrázek do kolekce obrázků prezentace.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Přidejte rámeček obrázku na snímek.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Ořízněte obrázek (hodnoty v procentech).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Uložte výsledek.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranění oříznutých oblastí obrázků**

Pokud chcete odstranit oříznuté oblasti obrázku v rámci, použijte metodu [delete_picture_cropped_areas](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Tato metoda vrací oříznutý obrázek, nebo původní obrázek, pokud ořezání není potřeba.

Následující Python kód demonstruje operaci:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Získejte PictureFrame z prvního snímku.
    picture_frame = slides.shape[0]

    # Získejte PictureFrame z prvního snímku.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Uložte výsledek.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Metoda [delete_picture_cropped_areas](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) přidává oříznutý obrázek do kolekce obrázků prezentace. Pokud je obrázek použit pouze v zpracovaném [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/), může to snížit velikost prezentace; v opačném případě se může počet obrázků v výsledné prezentaci zvýšit.

Během ořezávání tato metoda převádí WMF/EMF metafily na rastrový PNG obrázek.
{{% /alert %}}

## **Komprese obrázků**

Můžete komprimovat obrázek v prezentaci pomocí metody [PictureFillFormat.compress_image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/compress_image/).
Tato metoda komprimuje obrázek snížením jeho velikosti na základě velikosti tvaru a zadaného rozlišení, s možností odstranit oříznuté oblasti.

Upravuje velikost a rozlišení obrázku podobně jako funkce PowerPointu **Picture Format -> Compress Pictures -> Resolution**.

Následující příklady v Pythonu demonstrují, jak komprimovat obrázek v prezentaci zadáním cílového rozlišení a volitelně odstraněním oříznutých oblastí:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Komprimujte obrázek s cílovým rozlišením 150 DPI (webové rozlišení) a odstraňte oříznuté oblasti.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Zkontrolujte výsledek komprese.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Nebo přímo použitím vlastního DPI hodnoty:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Komprimujte obrázek na 150 DPI (webové rozlišení) a odstraňte oříznuté oblasti.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Metoda převádí obrázek na nižší rozlišení na základě velikosti tvaru a zadaného DPI. Oříznuté oblasti lze také odstranit pro optimalizaci velikosti souboru.
Pokud je obrázek metafile (WMF/EMF) nebo SVG, komprese se neaplikuje. Kvalita JPEG je zachována nebo mírně snížena na základě rozlišení, obdobně jako PowerPoint pracuje s vysoce rozlišenými JPEGy.
{{% /alert %}}

## **Uzamčení poměru stran**

Pokud chcete, aby tvar obsahující obrázek zachoval poměr stran po změně rozměrů obrázku, nastavte vlastnost [aspect_ratio_locked](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) na `True`.

Následující Python kód ukazuje, jak uzamknout poměr stran tvaru:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Zamkněte poměr stran při změně velikosti.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Toto nastavení *Lock Aspect Ratio* zachovává pouze poměr stran tvaru, nikoli poměr stran obrázku uvnitř něj.
{{% /alert %}}

## **Použití vlastností Stretch Offset**

Pomocí vlastností `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` a `stretch_offset_bottom` třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillformat/) můžete definovat výplňový obdélník.

Když je pro obrázek zadáno roztažení, zdrojový obdélník je měřítkem upraven tak, aby pasoval do výplňového obdélníku. Každý okraj výplňového obdélníku je definován procentuálním posunem od odpovídajícího okraje ohraničujícího rámečku tvaru. Kladné procento určuje útlum (inset), záporné procento pak vystoupení (outset).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte pravoúhlý [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/).
4. Nastavte typ výplně tvaru.
5. Nastavte režim výplně obrázkem tvaru.
6. Načtěte obrázek.
7. Přiřaďte obrázek k výplni tvaru.
8. Zadejte posuny obrázku od odpovídajících okrajů ohraničujícího rámečku tvaru.
9. Uložte prezentaci jako soubor PPTX.

Následující Python kód demonstruje, jak použít vlastnosti Stretch Offset:

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte obdélníkový AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Nastavte typ výplně tvaru.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Nastavte režim výplně obrázkem tvaru.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Načtěte obrázek a přidejte jej do prezentace.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Přiřaďte obrázek k výplni tvaru.
    shape.fill_format.picture_fill_format.picture.image = image

    # Zadejte posuny obrázku od odpovídajících okrajů ohraničujícího rámečku tvaru.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Uložte soubor PPTX na disk.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose poskytuje zdarma konvertory — [JPEG do PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt) — které vám umožní rychle vytvářet prezentace z obrázků.
{{% /alert %}}

## **Časté otázky**

**Jak zjistím, které formáty obrázků jsou podporovány pro PictureFrame?**

Aspose.Slides podporuje jak rastrové obrázky (PNG, JPEG, BMP, GIF atd.), tak vektorové obrázky (například SVG) prostřednictvím objektu obrázku, který je přiřazen k [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/). Seznam podporovaných formátů se obecně překrývá s možnostmi enginu pro snímky a konverzi obrázků.

**Jaký vliv bude mít přidání desítek velkých obrázků na velikost a výkon PPTX?**

Vkládání velkých obrázků zvyšuje velikost souboru a využití paměti; propojování obrázků pomáhá udržet velikost prezentace nízkou, ale vyžaduje, aby externí soubory zůstaly dostupné. Aspose.Slides poskytuje možnost přidávat obrázky jako odkazy pro snížení velikosti souboru.

**Jak mohu uzamknout objekt obrázku před náhodným přesunem/změnou velikosti?**

Použijte [shape locks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/picture_frame_lock/) pro [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) (například zakázání přesunu nebo změny velikosti). Mechanismus zamykání je popsán pro tvary v samostatném [článku o ochraně](/slides/cs/python-net/applying-protection-to-presentation/) a je podporován pro různé typy tvarů, včetně [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/).

**Zůstává věrnost vektorů SVG zachována při exportu prezentace do PDF/obrázků?**

Aspose.Slides umožňuje extrahovat SVG z [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) jako původní vektor. Při [exportu do PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/) nebo [rasterových formátů](/slides/cs/python-net/convert-powerpoint-to-png/) může být výsledek rasterizován v závislosti na nastavení exportu; fakt, že původní SVG je uložen jako vektor, je potvrzen chováním extrakce.