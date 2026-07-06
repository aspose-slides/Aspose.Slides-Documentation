---
title: Képkockák hozzáadása prezentációkhoz Pythonban
linktitle: Képkocka
type: docs
weight: 10
url: /hu/python-net/picture-frame/
keywords:
- képkocka
- képkocka hozzáadása
- képkocka létrehozása
- kép hozzáadása
- kép létrehozása
- kép kinyerése
- raszteres kép
- vektorkép
- kép vágása
- vágott terület
- StretchOff tulajdonság
- képkocka formázása
- képkocka tulajdonságok
- relatív méretezés
- kép effektus
- oldalarány
- kép átlátszóság
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Képkockák hozzáadása PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for Python via .NET segítségével. Egyszerűsítse a munkafolyamatot és javítsa a diaterveket."
---
## **Bevezetés**

Aspose.Slides for Python-ban a képkockák lehetővé teszik raszteres és vektorgrafikus képek elhelyezését és kezelését natív dia alakzatokként. Beszúrhat képeket fájlokból vagy adatfolyamokból, pontos koordinátákkal pozicionálhatja és méretezheti őket, alkalmazhat forgást, beállíthatja az átlátszóságot, és szabályozhatja a z-sorrendet más alakzatokkal együtt. Az API támogatja a vágást, az oldalarányok megőrzését, keretek és effektusok beállítását, valamint az alapkép cseréjét a elrendezés újjáépítése nélkül. Mivel a képkockák szabályos alakzatokként viselkednek, animációkat, hiperhivatkozásokat és alternatív szöveget is hozzáadhat, így egyszerűen építhet vizuálisan gazdag, akadálymentes bemutatókat.

## **Képkockák létrehozása**

Ez a rész bemutatja, hogyan szúrhat be egy képet a diára egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) létrehozásával az Aspose.Slides for Python segítségével. Megtanulja, hogyan töltse be a képet, helyezze pontosan a diára, és szabályozza annak méretét és formázását.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen meg egy diát az indexe alapján.
3. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot a kép prezentáció [ImageCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imagecollection/) gyűjteményéhez adásával. Ez a kép lesz a alakzat kitöltéséhez használt.
4. Adja meg a képkocka szélességét és magasságát.
5. Hozzon létre egy ilyen méretű [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) objektumot az [add_picture_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_picture_frame/) metódus használatával.
6. Mentse a prezentációt PPTX fájlként.

Az alábbi Python kód bemutatja, hogyan hozhat létre egy képkockát:

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt egy PPTX fájl reprezentálásához.
with slides.Presentation() as presentation:
    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adja hozzá a képet a prezentációhoz.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Adjon hozzá egy képkockát, amely a kép méretével egyezik.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Mentse a prezentációt PPTX formátumban.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
A képkockák lehetővé teszik, hogy gyorsan képekből készítsen bemutató diákat. Ha a képkockákat az Aspose.Slides mentési beállításaival kombinálja, szabályozhatja a I/O műveleteket a képek formátumok közötti konvertálásához. Érdemes megnézni ezeket az oldalakat: konvertáljon [képet JPG-re](https://products.aspose.com/slides/hu/python-net/conversion/image-to-jpg/); konvertáljon [JPG-t képre](https://products.aspose.com/slides/hu/python-net/conversion/jpg-to-image/); konvertáljon [JPG-t PNG-re](https://products.aspose.com/slides/hu/python-net/conversion/jpg-to-png/); konvertáljon [PNG-t JPG-re](https://products.aspose.com/slides/hu/python-net/conversion/png-to-jpg/); konvertáljon [PNG-t SVG-re](https://products.aspose.com/slides/hu/python-net/conversion/png-to-svg/); konvertáljon [SVG-t PNG-re](https://products.aspose.com/slides/hu/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Képkockák létrehozása relatív méretezéssel**

Ez a rész bemutatja, hogyan helyezzen el egy képet rögzített méretben, majd alkalmazzon százalékos skálázást függetlenül a szélességre és magasságra. Mivel a százalékok eltérhetnek, az oldalarány megváltozhat. A skálázás az eredeti képméretekhez képest történik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen meg egy diát az indexe alapján.
3. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot a kép prezentáció [ImageCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imagecollection/) gyűjteményéhez adásával.
4. Adjon hozzá egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) objektumot a diához.
5. Állítsa be a képkocka relatív szélességét és magasságát.
6. Mentse a prezentációt PPTX fájlként.

Az alábbi Python kód bemutatja, hogyan hozhat létre egy képkockát relatív méretezéssel:

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt a PPTX fájl reprezentálásához.
with slides.Presentation() as presentation:
    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adja hozzá a képet a prezentáció képgyűjteményéhez.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Adjon hozzá egy képkockát a diához.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Állítsa be a relatív méretezés szélességét és magasságát.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Mentse a prezentációt.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Raszteres képek kinyerése képkockákból**

Kinyerhet raszteres képeket [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) objektumokból, és elmentheti őket PNG, JPG és más formátumokban. Az alábbi kódrészlet bemutatja, hogyan nyerjen ki egy képet a „sample.pptx” dokumentumból, és mentse PNG formátumban.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **SVG képek kinyerése képkockákból**

Amikor egy prezentáció SVG grafikát tartalmaz, amely [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) alakzatban van elhelyezve, az Aspose.Slides for Python via .NET lehetővé teszi az eredeti vektorkép teljes hitelességével történő lekérdezését. A dia alakzatgyűjteményének bejárásával azonosíthatja minden [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) elemet, ellenőrizheti, hogy a hozzákapcsolt [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) SVG tartalmat tartalmaz-e, majd elmentheti azt lemezre vagy adatfolyamra natív SVG formátumban.

Az alábbi kódrészlet bemutatja, hogyan nyerjen ki egy SVG képet egy képkockából:

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

## **Kép átlátszóságának lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy képre alkalmazott átlátszósági effektet. Ez a Python kód demonstrálja a műveletet:

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
Minden képekre alkalmazott effektus megtalálható a [aspose.slides.effects](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/) névtérben.
{{% /alert %}}

## **Kép fényerősségének és kontrasztjának lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy képre alkalmazott fényerő és kontraszt effektet. A [Luminance](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/luminance/) osztály képviseli ezt a képátalakító effektet.

Ez a Python kód bemutatja, hogyan szerezze meg egy képkocka fényerő és kontraszt beállításait:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **Képkocka formázása**

Az Aspose.Slides számos formázási lehetőséget kínál, amelyeket egy képkockára alkalmazhat. Ezekkel a beállításokkal a képkockát testre szabhatja a specifikus igényeknek megfelelően.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen meg egy diát az indexe alapján.
3. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot a kép prezentáció [ImageCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imagecollection/) gyűjteményéhez adásával. Ez a kép lesz a alakzat kitöltéséhez használt.
4. Adja meg a képkocka szélességét és magasságát.
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) objektumot a slide [add_picture_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_picture_frame/) metódusával.
6. Állítsa be a képkocka vonalszínét.
7. Állítsa be a képkocka vonalvastagságát.
8. Forgassa a képkockát pozitív (óra járásával megegyező) vagy negatív (óramutatóval ellentétes) érték megadásával.
9. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi Python kód demonstrálja a képkocka formázási folyamatát:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítsa a Presentation osztályt egy PPTX fájl reprezentálásához.
with slides.Presentation() as presentation:
    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adja hozzá a képet a prezentáció képgyűjteményéhez.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Adjon hozzá egy képkockát, amely a kép méretével egyezik.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Alkalmazzon formázást a képkockára.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Mentse a prezentációt PPTX formátumban.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Az Aspose kifejlesztett egy ingyenes [Collage Maker](https://products.aspose.app/slides/hu/collage) alkalmazást. Ha JPG/JPEG vagy PNG képeket szeretne egyesíteni, vagy [fotó rácsokat](https://products.aspose.app/slides/hu/collage/photo-grid) szeretne létrehozni, használhatja ezt a szolgáltatást.
{{% /alert %}}

## **Képek hozzáadása hivatkozásként**

A prezentációk fájlméretének csökkentése érdekében képeket vagy videókat hivatkozásokként adhat hozzá ahelyett, hogy közvetlenül beágyazná őket. Az alábbi Python kód bemutatja, hogyan illesszen be egy képet és egy videót egy helyőrzőbe:

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

## **Képek vágása**

Ebben a részben megtanulja, hogyan vágja le egy kép látható területét egy képkockán belül a forrásfájl módosítása nélkül. Emellett megismerkedik a vágási margók alkalmazásának alapvető módszerével, amely tiszta, fókuszált kompozíciót eredményez közvetlenül a dián.

Az alábbi Python kód bemutatja, hogyan vágjon le egy képet egy dián:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adja hozzá a képet a prezentáció képgyűjteményéhez.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Adjon hozzá egy képkockát a diához.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Vágja le a képet (százalékos értékek).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Mentse az eredményt.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **A képek vágott területeinek törlése**

Ha egy kép vágott területeit szeretné törölni egy keretben, használja a [delete_picture_cropped_areas](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) metódust. Ez a metódus visszaadja a vágott képet, vagy az eredeti képet, ha nincs szükség vágásra.

Az alábbi Python kód demonstrálja a műveletet:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Szerezze be a PictureFrame-et az első diáról.
    picture_frame = slides.shape[0]

    # Szerezze be a PictureFrame-et az első diáról.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Mentse az eredményt.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
A [delete_picture_cropped_areas](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) metódus a vágott képet hozzáadja a prezentáció képgyűjteményéhez. Ha a képet csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) használja, ez csökkentheti a prezentáció méretét; egyébként a végső prezentációban lévő képek száma növekedhet.

A vágás során a metódus WMF/EMF metafájlokat raszteres PNG képpé konvertál.
{{% /alert %}}

## **Képek tömörítése**

A [PictureFillFormat.compress_image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/compress_image/) metódussal tömöríthet egy képet a prezentációban. Ez a metódus a kép méretét a forma mérete és a megadott felbontás alapján csökkenti, a vágott területek törlésének lehetőségével.

A PowerPoint **Képformátum → Képek tömörítése → Felbontás** funkciójához hasonlóan állítja be a kép méretét és felbontását.

Az alábbi Python példák bemutatják, hogyan tömörítsen egy képet a prezentációban egy célfelbontás megadásával, illetve opcionálisan a vágott területek eltávolításával:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Tömörítse a képet 150 DPI (webfelbontás) célfelbontással, és távolítsa el a vágott területeket.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Ellenőrizze a tömörítés eredményét.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Vagy közvetlenül egy egyéni DPI érték használatával:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Tömörítse a képet 150 DPI (web felbontásra), a vágott területek eltávolításával.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
A metódus a képet alacsonyabb felbontásra konvertálja a forma mérete és a megadott DPI alapján. A vágott részek is törölhetők a fájlméret optimalizálása érdekében.
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem lesz alkalmazva. Emellett a JPEG minősége a felbontásnak megfelelően megmarad vagy enyhén csökken, hasonlóan ahhoz, ahogy a PowerPoint kezeli a nagy felbontású JPEG-eket.
{{% /alert %}}

## **Az oldalarány lezárása**

Ha azt szeretné, hogy egy képet tartalmazó alakzat megőrizze az oldalarányát a kép méretének módosítása után, állítsa a [aspect_ratio_locked](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) tulajdonságot `True` értékre.

Az alábbi Python kód bemutatja, hogyan zárolja egy forma oldalarányát:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Zárja le az oldalarányt átméretezéskor.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Ez a *Lock Aspect Ratio* beállítás csak a forma oldalarányát őrzi meg, nem pedig a benne lévő kép oldalarányát.
{{% /alert %}}

## **Nyújtás eltolási tulajdonságok használata**

A [PictureFillFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/) osztály `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` és `stretch_offset_bottom` tulajdonságainak használatával meghatározhatja a kitöltő téglalapot.

Ha nyújtás van megadva egy képre, a forrástéglalap a kitöltő téglalaphoz lesz átméretezve. A kitöltő téglalap minden élét a forma határoló dobozának megfelelő élétől százalékos eltolás határozza meg. A pozitív százalékos érték beszúrást, a negatív érték kitágulást jelent.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diához az indexe alapján.
3. Adjon hozzá egy téglalap alakzatú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet.
4. Állítsa be az alakzat kitöltéstípusát.
5. Állítsa be az alakzat képkitöltési módját.
6. Töltsön be egy képet.
7. Rendelje hozzá a képet az alakzat kitöltéséhez.
8. Adjon meg képeltolásokat az alakzat határoló dobozának megfelelő éleihez képest.
9. Mentse a prezentációt PPTX fájlként.

Az alábbi Python kód demonstrálja a Stretch Offset tulajdonságok használatát:

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy PPTX fájlt reprezentál.
with slides.Presentation() as presentation:
    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adjon hozzá egy téglalap AutoShape-et.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Állítsa be az alakzat kitöltési típusát.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Állítsa be az alakzat képkitöltési módját.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Töltse be a képet és adja hozzá a prezentációhoz.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Rendelje hozzá a képet az alakzat kitöltéséhez.
    shape.fill_format.picture_fill_format.picture.image = image

    # Adjon meg képeltolásokat az alakzat határoló dobozának megfelelő éleihez.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Mentse a PPTX fájlt lemezre.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Az Aspose ingyenes konvertereket biztosít — [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) — amelyekkel gyorsan készíthet prezentációkat képekből.
{{% /alert %}}

## **GYIK**

**Hogyan tudhatom meg, mely képformátumok támogatottak a PictureFrame számára?**

Az Aspose.Slides támogatja mind a raszteres (PNG, JPEG, BMP, GIF stb.), mind a vektorgrafikus (például SVG) képeket a [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) objektumhoz rendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedésben van a dia- és képkonverziós motor képességeivel.

**Hogyan befolyásolja a több tucat nagy méretű kép hozzáadása a PPTX méretét és teljesítményét?**

Nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek hivatkozásként való hozzáadása segít csökkenteni a prezentáció méretét, de az külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetővé teszi a képek hivatkozásként való hozzáadását a fájlméret csökkentése érdekében.

**Hogyan zárhatok le egy kép objektumot a véletlen áthelyezés/átméretezés ellen?**

Használja a [shape locks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/picture_frame_lock/) funkciót egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) esetén (például a mozgatás vagy átméretezés letiltása). A zárolási mechanizmus a formákra vonatkozó külön [védelemről szóló cikkben](/slides/hu/python-net/applying-protection-to-presentation/) van leírva, és számos alakzattípusra, így a [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/)-re is alkalmazható.

**Megmarad-e az SVG vektorfidelitás exportáláskor PDF/ képek formátumba?**

Az Aspose.Slides lehetővé teszi egy SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/)-ből eredeti vektorként. PDF-re ([exportálás PDF-be](/slides/hu/python-net/convert-powerpoint-to-pdf/)) vagy raszteres formátumokba ([exportálás PNG-be](/slides/hu/python-net/convert-powerpoint-to-png/)) történő exportáláskor az eredmény a beállításoktól függően rasterizálódhat; a SVG eredeti vektorként tárolása a kinyerési viselkedésben bizonyítható.