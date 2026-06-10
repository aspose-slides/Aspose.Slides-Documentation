---
title: Képkeretek hozzáadása prezentációkhoz Pythonban
linktitle: Képkeret
type: docs
weight: 10
url: /hu/python-net/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- kép hozzáadása
- kép létrehozása
- kép kinyerése
- raszteres kép
- vektorgrafikus kép
- kép vágása
- kivágott terület
- StretchOff tulajdonság
- képkeret formázása
- képkeret tulajdonságok
- relatív méretezés
- képeffektus
- képarány
- kép átlátszóság
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Képkeretek hozzáadása PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for Python via .NET segítségével. Egyszerűsítse munkafolyamatát és javítsa a diák tervezését."
---
## **Bevezetés**

A képkeretek az Aspose.Slides for Python-ban lehetővé teszik raszteres és vektorgrafikus képek elhelyezését és kezelését natív diaképként. Képeket tölthet be fájlokból vagy adatfolyamokból, pontos koordinátákkal helyezheti el és méretezheti őket, alkalmazhat forgást, beállíthat átlátszóságot, és vezérelheti a Z-sorrendet más alakzatokkal együtt. Az API támogatja a vágást, az arányok megtartását, a szegélyek és hatások beállítását, valamint a kép cseréjét a layout újraépítése nélkül. Mivel a képkeretek úgy viselkednek, mint a normál alakzatok, animációkat, hiperhivatkozásokat és alternatív szöveget is hozzáadhat, így egyszerűen építhet vizuálisan gazdag, akadálymentes prezentációkat.

## **Képkeretek létrehozása**

Ez a rész bemutatja, hogyan illesszünk be egy képet egy diára egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) létrehozásával az Aspose.Slides for Python segítségével. Megtanulja, hogyan töltse be a képet, helyezze pontosan a diához, és szabályozza a méretét és formázását.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen egy diát a indexe alapján.
3. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot a kép prezentáció [ImageCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imagecollection/)-ba való hozzáadásával. Ez a kép lesz az alakzat kitöltése.
4. Adja meg a keret szélességét és magasságát.
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) objektumot a megadott mérettel az [add_picture_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_picture_frame/) metódus segítségével.
6. Mentse a prezentációt PPTX fájlként.

Az alábbi Python‑kód bemutatja, hogyan hozzunk létre egy képkeretet:

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt egy PPTX fájl reprezentálásához.
with slides.Presentation() as presentation:
    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adja hozzá a képet a prezentációhoz.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Adjon hozzá egy képkeretet a kép méretének megfelelően.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Mentse a prezentációt PPTX formátumban.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

A képkeretekkel gyorsan hozhat létre prezentációs diákot képekből. Ha a képkereteket az Aspose.Slides mentési beállításaival kombinálja, szabályozhatja a I/O műveleteket a képek egyik formátumból a másikba konvertálásához. Érdemes megtekinteni ezeket az oldalakat: konvertálás [kép JPG‑re](https://products.aspose.com/slides/hu/python-net/conversion/image-to-jpg/); konvertálás [JPG‑ról képre](https://products.aspose.com/slides/hu/python-net/conversion/jpg-to-image/); konvertálás [JPG‑ról PNG‑ra](https://products.aspose.com/slides/hu/python-net/conversion/jpg-to-png/); konvertálás [PNG‑ról JPG‑re](https://products.aspose.com/slides/hu/python-net/conversion/png-to-jpg/); konvertálás [PNG‑ról SVG‑re](https://products.aspose.com/slides/hu/python-net/conversion/png-to-svg/); konvertálás [SVG‑ról PNG‑re](https://products.aspose.com/slides/hu/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Képkeretek létrehozása relatív méretezéssel**

Ez a rész bemutatja, hogyan helyezzen el egy képet fix mérettel, majd alkalmazzon százalékos méretezést külön a szélességre és a magasságra. Mivel a százalékok eltérhetnek, az arányok megváltozhatnak. A méretezés az eredeti képméretekre vonatkozik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen egy diát a indexe alapján.
3. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot a kép prezentáció [ImageCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imagecollection/)-ba való hozzáadásával.
4. Adjon hozzá egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) objektumot a diára.
5. Állítsa be a képkeret relatív szélességét és magasságát.
6. Mentse a prezentációt PPTX fájlként.

Az alábbi Python‑kód bemutatja, hogyan hozzunk létre egy képkeretet relatív méretezéssel:

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt egy PPTX fájl reprezentálásához.
with slides.Presentation() as presentation:
    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adja hozzá a képet a prezentáció képgyűjteményéhez.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Adjon hozzá egy képkeretet a diához.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Állítsa be a relatív méretezés szélességét és magasságát.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Mentse a prezentációt.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Raszteres képek kinyerése képkeretekből**

Kinyerhet raszteres képeket [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) objektumokból, és mentheti őket PNG, JPG és egyéb formátumokban. Az alábbi kódpélda bemutatja, hogyan nyerjen ki egy képet a „sample.pptx” dokumentumból, és mentse PNG formátumban.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **SVG‑képek kinyerése képkeretekből**

Amikor egy prezentáció SVG‑grafikát tartalmaz, amely [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) alakzatba van ágyazva, az Aspose.Slides for Python via .NET lehetővé teszi az eredeti vektorkép teljes hűségű visszanyerését. A dia alakzatgyűjteményének bejárásával azonosíthatja az egyes [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) objektumokat, ellenőrizheti, hogy a mögöttes [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) SVG‑t tartalmaz‑e, majd elmentheti azt lemezre vagy adatfolyamba natív SVG formátumban.

Az alábbi kódpélda bemutatja, hogyan nyerjen ki egy SVG‑képet egy képkeretből:

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

## **Kép átlátszóságának lekérdezése**

Az Aspose.Slides lehetővé teszi, hogy visszanyerje egy képre alkalmazott átlátszósági effektust. Ez a Python‑kód bemutatja a műveletet:

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
Az összes képre vonatkozó effektus megtalálható a [aspose.slides.effects](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/) modulban.
{{% /alert %}}

## **Képkeret formázása**

Az Aspose.Slides számos formázási lehetőséget biztosít, amelyeket egy képkerethez alkalmazhat. Ezekkel a beállításokkal a képkeretet a konkrét követelményeknek megfelelően alakíthatja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen egy diát a indexe alapján.
3. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot a kép prezentáció [ImageCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imagecollection/)-ba való hozzáadásával. Ez a kép lesz az alakzat kitöltése.
4. Adja meg a keret szélességét és magasságát.
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) objektumot a megadott mérettel a dia [add_picture_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_picture_frame/) metódusával.
6. Állítsa be a képkeret vonalszínét.
7. Állítsa be a képkeret vonalvastagságát.
8. Forgassa a képkeretet pozitív (óra‑járás) vagy negatív (óramutatóval ellentétes) értékkel.
9. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi Python‑kód bemutatja a képkeret formázási folyamatát:

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

        # Adjon hozzá egy képkeretet a kép méretének megfelelően.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Alkalmazzon formázást a képkeretre.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Mentse a prezentációt PPTX formátumban.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tipp" color="primary" %}}

Az Aspose egy ingyenes [Collage Maker](https://products.aspose.app/slides/hu/collage) szolgáltatást fejlesztett ki. Ha JPG/JPEG vagy PNG képeket szeretne egyesíteni, vagy [fotórácsokat](https://products.aspose.app/slides/hu/collage/photo-grid) szeretne létrehozni, használhatja ezt a szolgáltatást.
{{% /alert %}}

## **Képek hozzáadása hivatkozásként**

A prezentációs fájlok méretének csökkentése érdekében a képeket vagy videókat hivatkozásokon keresztül adhatja hozzá ahelyett, hogy közvetlenül beágyazná őket. Az alábbi Python‑kód megmutatja, hogyan illesszen be egy képet és egy videót egy helyőrzőbe:

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

Ebben a részben megtanulja, hogyan vághatja le egy kép látható területét egy képkereten belül anélkül, hogy módosítaná a forrásfájlt. Megtanulja a vágási margók alapvető módszerét is, hogy tiszta, fókuszált kompozíciót hozzon létre közvetlenül a dián.

Az alábbi Python‑kód megmutatja, hogyan vágjon le egy képet egy dián:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adja hozzá a képet a prezentáció képgyűjteményéhez.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Adjon hozzá egy képkeretet a diához.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Vágja le a képet (százalékos értékek).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Mentse az eredményt.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Kivágott képrészletek törlése**

Ha egy keretben lévő kép kivágott részeit szeretné törölni, használja a [delete_picture_cropped_areas](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) metódust. Ez a metódus visszaadja a kivágott képet, vagy az eredeti képet, ha nincs szükség vágásra.

Az alábbi Python‑kód demonstrálja a műveletet:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Szerezze meg a PictureFrame-et az első diáról.
    picture_frame = slides.shape[0]

    # Szerezze meg a PictureFrame-et az első diáról.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Mentse az eredményt.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="MEGJEGYZÉS" color="warning" %}}

A [delete_picture_cropped_areas](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) metódus a kivágott képet a prezentáció képgyűjteményébe helyezi. Ha a képet csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) használja, ez csökkentheti a prezentáció méretét; egyébként a végleges prezentációban lévő képek száma megnőhet.

Vágás közben a metódus a WMF/EMF metafájlokat raszteres PNG képpé konvertálja.
{{% /alert %}}

## **Képek tömörítése**

A [PictureFillFormat.compress_image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/compress_image/) metódussal tömörítheti a prezentációban lévő képet.
Ez a metódus a kép méretét csökkenti az alakzat mérete és a megadott felbontás alapján, és lehetőséget ad a kivágott részek törlésére is.

A képméret és felbontás beállítása hasonló a PowerPoint **Kép formátum → Képek tömörítése → Felbontás** funkciójához.

Az alábbi Python‑példák bemutatják, hogyan tömörítsen egy képet egy prezentációban célfelbontás megadásával, és opcionálisan a kivágott részek eltávolításával:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Tömörítsük a képet 150 DPI (web felbontás) célfelbontással, és távolítsuk el a kivágott részeket.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Ellenőrizze a tömörítés eredményét.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Vagy egy egyedi DPI‑érték közvetlen megadásával:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Tömörítse a képet 150 DPI-re (web felbontás), a kivágott területek eltávolításával.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="MEGJEGYZÉS" color="warning" %}}

A metódus a képet alacsonyabb felbontásra konvertálja az alakzat mérete és a megadott DPI alapján. A kivágott területek is törölhetők a fájlméret optimalizálása érdekében.
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem kerül alkalmazásra. Emellett a JPEG minősége a felbontás függvényében megmarad vagy enyhén csökken, ahogy a PowerPoint kezeli a nagy felbontású JPEG‑eket.
{{% /alert %}}

## **Arányok zárolása**

Ha azt szeretné, hogy egy képet tartalmazó alakzat megtartsa az arányait a kép méretének módosítása után is, állítsa a [aspect_ratio_locked](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) tulajdonságot **True**‑ra.

Az alábbi Python‑kód megmutatja, hogyan zárolja egy alakzat arányait:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Zárolja az arányt átméretezéskor.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="MEGJEGYZÉS" color="warning" %}}

Ez a *Lock Aspect Ratio* beállítás csak az alakzat arányait őrzi meg, nem a benne lévő kép arányait.
{{% /alert %}}

## **Nyújtási eltolás tulajdonságok használata**

A [PictureFillFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/) osztály `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` és `stretch_offset_bottom` tulajdonságainak használatával definiálhat egy kitöltő téglalapot.

Ha egy képhez nyújtás van megadva, a forrástéglalap méreteződik, hogy illeszkedjen a kitöltő téglalaphoz. A kitöltő téglalap minden oldalát egy százalékos eltolás határozza meg a alakzat körülhatároló dobozának megfelelő oldalától. A pozitív százalék belső eltolást, a negatív százalék pedig külső kinyúlást jelent.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen egy hivatkozást egy diára az indexe alapján.
3. Adj hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet.
4. Állítsa be az alakzat kitöltésének típusát.
5. Állítsa be az alakzat képkitöltési módját.
6. Töltsön be egy képet.
7. Rendelje hozzá a képet az alakzat kitöltéséhez.
8. Adja meg a kép eltolásait az alakzat körülhatároló dobozának megfelelő oldalaitól.
9. Mentse a prezentációt PPTX fájlként.

Az alábbi Python‑kód bemutatja, hogyan használja a nyújtási eltolás tulajdonságait:

```py
import aspose.slides as slides

# Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel.
with slides.Presentation() as presentation:
    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy téglalap AutoShape-et.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Beállítja az alakzat kitöltési típusát.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Beállítja az alakzat képkitöltési módját.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Betölti a képet és hozzáadja a prezentációhoz.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Hozzárendeli a képet az alakzat kitöltéséhez.
    shape.fill_format.picture_fill_format.picture.image = image

    # Megadja a képek eltolásait az alakzat körülhatároló dobozának megfelelő oldalaitól.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tipp" color="primary" %}}

Az Aspose ingyenes konvertereket kínál – [JPEG‑ról PowerPoint‑ra](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG‑ról PowerPoint‑ra](https://products.aspose.app/slides/hu/import/png-to-ppt) – amelyekkel gyorsan hozhat létre prezentációkat képekből.
{{% /alert %}}

## **GYIK**

**Hogyan tudom megtudni, mely képformátumok támogatottak a PictureFrame‑hez?**

Az Aspose.Slides támogatja mind a raszteres képeket (PNG, JPEG, BMP, GIF stb.), mind a vektorgrafikus képeket (például SVG) a [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/)‑hez rendelt képobjektumon keresztül. A támogatott formátumok listája általában megegyezik a dia‑ és képkonvertáló motor képességeivel.

**Hogyan befolyásolja a sok nagy kép hozzáadása a PPTX méretét és teljesítményét?**

A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek hivatkozásként való hozzáadása segít a prezentáció méretének csökkentésében, de a külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetővé teszi a képek hivatkozásként való hozzáadását a fájlméret csökkentése érdekében.

**Hogyan zárolhatom meg egy képobjektust a véletlen mozgatástól/méretezéstől?**

Használjon [shape locks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/picture_frame_lock/) opciókat egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) esetén (például a mozgatás vagy méretezés letiltása). A zárolási mechanizmust a formákra vonatkozó külön [védelem cikk](/slides/hu/python-net/applying-protection-to-presentation/) ismerteti, és különböző alakzattípusokra, köztük a [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/), is vonatkozik.

**Megmarad-e az SVG vektorgrafika hűsége a prezentáció PDF‑re/képekre exportálásakor?**

Az Aspose.Slides lehetővé teszi az SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/)‑ből eredeti vektorként. PDF‑re vagy [raszteres formátumokra](/slides/hu/python-net/convert-powerpoint-to-png/) történő exportáláskor az eredmény rasterizálódhat az exportbeállításoktól függően; a tény, hogy az eredeti SVG vektor, a kinyerési viselkedésből is megállapítható.