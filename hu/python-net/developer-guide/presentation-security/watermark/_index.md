---
title: Vízjelek hozzáadása prezentációkhoz Pythonban
linktitle: Vízjel
type: docs
weight: 40
url: /hu/python-net/watermark/
keywords:
- vízjel
- szöveges vízjel
- képes vízjel
- vízjel hozzáadása
- vízjel módosítása
- vízjel eltávolítása
- vízjel törlése
- vízjel hozzáadása PPT-hez
- vízjel hozzáadása PPTX-hez
- vízjel hozzáadása ODP-hez
- vízjel eltávolítása PPT-ből
- vízjel eltávolítása PPTX-ből
- vízjel eltávolítása ODP-ből
- vízjel törlése PPT-ből
- vízjel törlése PPTX-ből
- vízjel törlése ODP-ből
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg, hogyan kezelhet szöveges és képes vízjeleket PowerPoint és OpenDocument prezentációkban Python nyelven, hogy jelölje a tervezetet, bizalmas információkat, szerzői jogot és egyebet."
---
## **Bevezetés**

**A vízjel** egy prezentációban egy szöveges vagy képes pecsét, amelyet egy dián vagy az összes dián használunk. Általában a vízjelet arra használják, hogy jelezze, hogy a prezentáció tervezet (pl. „Draft” vízjel), hogy bizalmas információkat tartalmaz (pl. „Confidential” vízjel), hogy melyik céghez tartozik (pl. „Company Name” vízjel), hogy azonosítsa a prezentáció szerzőjét stb. A vízjel segít megelőzni a szerzői jogok megsértését azzal, hogy jelzi, hogy a prezentációt nem szabad másolni. A vízjeleket mind a PowerPoint, mind az OpenOffice prezentációs formátumokban használják. Az Aspose.Slides segítségével vízjelet adhat hozzá a PowerPoint PPT, PPTX és OpenOffice ODP fájlformátumokhoz.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/python-net/) különböző módokon engedélyezi a vízjelek létrehozását PowerPoint vagy OpenOffice dokumentumokban, valamint azok tervezésének és viselkedésének módosítását. A közös vonás, hogy szöveges vízjelek hozzáadásához a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) osztályt kell használni, képes vízjelek hozzáadásához pedig a [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) osztályt, vagy a vízjel alakzat kitöltését képpel. A `PictureFrame` megvalósítja a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) osztályt, így használhatók a forma objektum összes rugalmas beállítása. Mivel a `TextFrame` nem alakzat, be van csomagolva egy [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) objektumba.

Két módon alkalmazható a vízjel: egyetlen diára vagy az összes prezentációs diára. A Dia Mester (Slide Master) arra szolgál, hogy a vízjelet minden diára alkalmazza — a vízjelet a Slide Masterhez adják, ott teljesen megtervezik, és minden diára alkalmazzák, anélkül, hogy befolyásolná a vízjel egyedi diákon történő módosításának engedélyét.

A vízjelet általában úgy tekintik, hogy más felhasználók számára nem szerkeszthető. Annak megakadályozására, hogy a vízjelet (pontosabban a vízjel szülő alakzatát) szerkesszék, az Aspose.Slides alakzatzárolási funkciót biztosít. Egy adott alakzat lezárható egy normál dián vagy a Slide Masteren. Ha a vízjel alakzat a Slide Masteren le van zárva, akkor minden prezentációs dián le lesz zárva.

A vízjelhez megadhat egy nevet, így a jövőben, ha törölni szeretné, név alapján megtalálhatja a diák alakzatai között.

A vízjelet bármilyen módon megtervezheti; azonban általában vannak közös jellemzők, mint a középre igazítás, forgatás, előre helyezés stb. Az alábbi példákban megvizsgáljuk, hogyan használhatók ezek.

## **Szöveges vízjel**

### **Szöveges vízjel hozzáadása diára**

A szöveges vízjel PPT, PPTX vagy ODP fájlokhoz való hozzáadásához először egy alakzatot kell a diára helyezni, majd szövegkeretet ehhez az alakzathoz adni. A szövegkeret a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) osztály által van képviselve. Ez a típus nem örököl a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) osztályból, amely széles körű tulajdonságokkal rendelkezik a vízjel rugalmas pozícionálásához. Ezért a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektum egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) objektumba van becsomagolva. A vízjel szövegének az alakzathoz adásához használja a [add_text_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/add_text_frame/#str) metódust az alábbiak szerint.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Lásd még" %}} 
- [A TextFrame osztály használata](/slides/hu/python-net/text-formatting/)
{{% /alert %}}

### **Szöveges vízjel hozzáadása prezentációhoz**

Ha a teljes prezentációhoz (azaz egyszerre minden diához) szeretne szöveges vízjelet hozzáadni, adja hozzá a [MasterSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/)-hez. A logika ugyanaz, mint egyetlen diára történő vízjel hozzáadásakor — hozzon létre egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) objektumot, majd a [add_text_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/add_text_frame/#str) metódussal adja hozzá a vízjelet.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Lásd még" %}} 
- [A Slide Master használata](/slides/hu/python-net/slide-master/)
{{% /alert %}}

### **A vízjel alakzat átlátszóságának beállítása**

Alapértelmezés szerint a téglalap alakzat kitöltési és vonalszínekkel van formázva. A következő kódsorok átlátszóvá teszik az alakzatot.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **A szöveges vízjel betűtípusának beállítása**

Az alábbiak szerint módosíthatja a szöveges vízjel betűtípusát.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **A vízjel szövegszínének beállítása**

A vízjel szövegszínének beállításához használja ezt a kódot:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Szöveges vízjel középre igazítása**

A vízjelet középre helyezheti a dián, ehhez a következőt teheti:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

![A szöveges vízjel](text_watermark.png)

## **Képes vízjel**

### **Képes vízjel hozzáadása prezentációhoz**

A képes vízjel egy prezentációs diára való hozzáadásához a következőket teheti:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Vízjel zárolása a szerkesztéstől**

Ha szükséges megakadályozni, hogy a vízjelet szerkesszék, használja a [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/auto_shape_lock/) tulajdonságot az alakzaton. Ezzel a tulajdonsággal megvédheti az alakzatot a kiválasztástól, átméretezéstől, áthelyezéstől, más elemekkel való csoportosítástól, a szöveg szerkesztésétől és még sok mást:

```py
# Zárolja a vízjel alakzat módosítását
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Vízjel előre hozása**

Az Aspose.Slides-ben az alakzatok Z-sorrendje a [ShapeCollection.reorder](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) metódussal állítható be. Ehhez a metódust a prezentáció diák listájáról kell hívni, és átadni a forma referenciáját valamint a kívánt sorrendszámot. Így lehet egy alakzatot előre hozni vagy hátra küldeni a dián. Ez a funkció különösen hasznos, ha a vízjelet a prezentáció előterébe szeretné helyezni:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **A vízjel forgatásának beállítása**

Itt egy kódrészlet, amely bemutatja, hogyan állítható be a vízjel forgása úgy, hogy a dia átlójában helyezkedjen el:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Vízjel nevének beállítása**

Az Aspose.Slides lehetővé teszi, hogy egy alakzat nevét állítsa be. A forma név használatával a későbbiekben módosíthatja vagy törölheti azt. A vízjel alakzat nevét a [AutoShape.name](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/name/) tulajdonsághoz rendelje:

```py
watermark_shape.name = "watermark"
```

## **Vízjel eltávolítása**

A vízjel alakzat eltávolításához használja a [AutoShape.name](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/name/) metódusát a diák alakzatai között való megtalálásához. Ezután adja át a vízjel alakzatot a [ShapeCollection.remove](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/remove/#ishape) metódusnak:

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Élő példa**

Érdemes megnézni az **Aspose.Slides ingyenes** [Vízjel hozzáadása](https://products.aspose.app/slides/hu/watermark) és [Vízjel eltávolítása](https://products.aspose.app/slides/hu/watermark/remove-watermark) online eszközöket.

![Online eszközök a vízjelek hozzáadásához és eltávolításához](online_tools.png)

## **GYIK**

**Mi a vízjel, és miért kell használni?**

A vízjel egy szöveges vagy képes átfedés, amely a diákra kerül, és segít megvédeni a szellemi tulajdont, növelni a márka felismerhetőségét vagy megakadályozni a prezentációk illetéktelen használatát.

**Hozzáadhatok-e vízjelet minden diához egy prezentációban?**

Igen, az Aspose.Slides lehetővé teszi, hogy minden diára vízjelet adjunk. A diákon végig iterálva egyenként alkalmazhatja a vízjel beállításait.

**Hogyan állíthatom be a vízjel átlátszóságát?**

A vízjel átlátszóságát a forma kitöltési beállításainak ([FillFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/)) módosításával tudja szabályozni. Ez biztosítja, hogy a vízjel finom legyen és ne vonja el a figyelmet a dia tartalmáról.

**Milyen képformátumokat támogat a vízjel?**

Az Aspose.Slides különféle képformátumokat támogat, például PNG, JPEG, GIF, BMP, SVG és továbbiakat.

**Testreszabhatom-e a szöveges vízjel betűtípusát és stílusát?**

Igen, tetszőleges betűtípust, méretet és stílust választhat, hogy illeszkedjen a prezentáció tervezéséhez és megtartsa a márka konzisztenciáját.

**Hogyan változtathatom meg a vízjel pozícióját vagy tájolását?**

A vízjel pozícióját és tájolását a [shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) koordinátáinak, méretének és forgatási tulajdonságainak módosításával állíthatja be.