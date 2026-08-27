---
title: Szövegdobozok kezelése prezentációkban Python-nal
linktitle: Szövegdoboz kezelése
type: docs
weight: 20
url: /hu/python-net/manage-textbox/
keywords:
- szövegdoboz
- szövegkeret
- szöveg hozzáadása
- szöveg frissítése
- szövegdoboz létrehozása
- szövegdoboz ellenőrzése
- szövegoszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Az Aspose.Slides for Python .NET-en keresztül megkönnyíti a szövegdobozok létrehozását, szerkesztését és klónozását PowerPoint és OpenDocument fájlokban, ezáltal javítva a prezentáció automatizálását."
---
## **Bevezetés**

A diákon lévő szövegek általában szövegdobozokban vagy alakzatokban vannak. Ezért egy szöveg hozzáadásához a diára először szövegdobozt kell létrehozni, majd szöveget kell elhelyezni a szövegdobozban. Az Aspose.Slides for Python a [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) osztályt biztosítja, amely lehetővé teszi olyan alakzat hozzáadását, amely szöveget tartalmaz.

{{% alert title="Info" color="info" %}}
Az Aspose.Slides emellett a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) osztályt is biztosítja. Azonban nem minden alakzat képes szöveget tárolni.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Ezért, ha egy olyan alakzattal dolgozunk, amelyhez szöveget szeretnénk hozzáadni, érdemes ellenőrizni és megerősíteni, hogy az [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) osztályon keresztül lett-e átalakítva. csak ekkor lehet a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-mel dolgozni, amely az [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) egy tulajdonsága. Lásd a [Update Text](/slides/hu/python-net/manage-textbox/#update-text) szakaszt ezen az oldalon.
{{% /alert %}}

## **Szövegdobozok létrehozása a diákon**

Egy szövegdoboz létrehozásához egy dián:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást az első diára.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet `ShapeType.RECTANGLE` típusúval a kívánt pozícióban a dián.
4. Állítsa be a szöveget az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) tulajdonságában.
5. Mentse a prezentációt PPTX fájlként.

A következő Python példa megvalósítja ezeket a lépéseket:

```py
import aspose.slides as slides

# A Presentation osztály példányosítása.
with slides.Presentation() as presentation:

    # Az első diát kapja a prezentációból.
    slide = presentation.slides[0]

    # RECTANGLE típusú AutoShape hozzáadása.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # A prezentáció mentése lemezre.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Ellenőrzés, hogy egy alakzat szövegdoboz-e**

Az Aspose.Slides a [is_text_box](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/is_text_box/) tulajdonságot biztosítja az [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) osztályban, amely lehetővé teszi annak meghatározását, hogy egy alakzat szövegdoboz-e.

![Text box and shape](istextbox.png)

Ez a Python példa megmutatja, hogyan ellenőrizhető, hogy egy alakzat szövegdobozként jött-e létre:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Vegye figyelembe, hogy ha egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/) osztállyal ad hozzá, az alakzat `is_text_box` tulajdonsága `False` értéket ad vissza. Azonban ha szöveget ad hozzá – akár az `add_text_frame` metódussal, akár a `text` tulajdonság beállításával – a `is_text_box` `True` értéket ad vissza.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box hamis
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box igaz

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box hamis
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box igaz

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box hamis
    shape3.add_text_frame("")
    # shape3.is_text_box hamis

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box hamis
    shape4.text_frame.text = ""
    # shape4.is_text_box hamis
```

## **Az alakzat megtalálása, amely a szövegdobozt birtokolja**

Általános szövegfeldolgozó kódban előfordulhat, hogy egy [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumot kapunk anélkül, hogy tudnánk, mely prezentációs objektum tartalmazza. Használja a [TextFrame.parent_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_shape/) tulajdonságot a tulajdonos [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) visszakereséséhez.

Egy szövegdoboz esetén, amely egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) vagy más szöveget tartalmazó alakzat része, a [TextFrame.parent_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_shape/) be van állítva, míg a [TextFrame.parent_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_cell/) `None`. Mindkét tulajdonság csak olvasható navigációs tulajdonság, ezért azok olvasása nem módosítja a tulajdonjogot. Mindig ellenőrizze, hogy a visszaadott érték nem `None`‑e, mielőtt hozzáférne az alakzathoz.

Egy teljes példáért, amely az alakzat- és táblacella-tulajdonosokat azonosítja, beleértve a SmartArt csomópontokkal kapcsolatos alakzatokat is, lásd a [Search and Replace Text](/slides/hu/python-net/search-and-replace-text/) oldalt.

## **Oszlopok hozzáadása a szövegdobozokhoz**

Az Aspose.Slides a [column_count](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/column_count/) és a [column_spacing](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/column_spacing/) tulajdonságokat biztosítja a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/) osztályon, hogy oszlopokat adhasson a szövegdobozokhoz. Megadhatja az oszlopok számát, valamint beállíthatja az oszlopok közötti távolságot (pontban).

A következő Python kód bemutatja ezt a műveletet:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Az első diát kapja a prezentációból.
	slide = presentation.slides[0]

	# RECTANGLE típusú AutoShape hozzáadása.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# TextFrame hozzáadása a téglalaphoz.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# A TextFrame szövegformátumának lekérése.
	format = shape.text_frame.text_frame_format

	# Az oszlopok számának megadása a TextFrame-ben.
	format.column_count = 3

	# Az oszlopok közötti távolság megadása.
	format.column_spacing = 10

	# A prezentáció mentése.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg frissítése**

Az Aspose.Slides lehetővé teszi, hogy egyetlen szövegdoboz vagy egy teljes prezentáció szövegét frissítse.

A következő Python példa bemutatja, hogyan frissíthető az összes szöveg egy prezentációban:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # A módosított prezentáció mentése.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Szövegdobozok hozzáadása hiperhivatkozásokkal**

Beszúrhat egy hivatkozást egy szövegdobozba. Amikor a szövegdobozra kattintanak, a hivatkozás megnyílik.

Egy hiperhivatkozást tartalmazó szövegdoboz hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást az első diára.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet `ShapeType.RECTANGLE` típusúval a kívánt pozícióban a dián.
4. Állítsa be a szöveget az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) tulajdonságában.
5. Szerezzen hivatkozást a [HyperlinkManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkmanager/) osztályra.
6. Használja a `hyperlink_manager` tulajdonságot egy külső kattintási hiperhivatkozás beállításához.
7. Mentse a prezentációt PPTX fájlként.

Ez a Python példa megmutatja, hogyan adhat hiperhivatkozással rendelkező szövegdobozt egy diához:

```py
import aspose.slides as slides

# A Presentation osztály példányosítása.
with slides.Presentation() as presentation:

    # Az első diát kapja a prezentációból.
    slide = presentation.slides[0]

    # RECTANGLE típusú AutoShape hozzáadása.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Szöveg hozzáadása a kerethez.
    text_portion.text = "Aspose.Slides"

    # Hiperhivatkozás beállítása a rész szövegéhez.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # A prezentáció mentése PPTX fájlként.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Mi a különbség a szövegdoboz és a szöveghelyőrző között, amikor mester diákkal dolgozunk?**

A [placeholder](/slides/hu/python-net/manage-placeholder/) örökli a stílust/pozíciót a [master](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/) diától, és felülírható a [layouts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/) diákon, míg egy szokásos szövegdoboz egy független objektum egy adott dián, és nem változik, ha elrendezést váltunk.

**Hogyan lehet tömeges szövegcsere végrehajtani a prezentációban anélkül, hogy a diagramok, táblázatok és SmartArt szövegéhez nyúlna?**

Korlátozza az iterációt azokra az auto-shape‑ekre, amelyeknek van szövegdobozuk, és zárja ki a beágyazott objektumokat ([charts](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartart/)) úgy, hogy külön gyűjteményeken iterál vagy kihagyja ezeket az objektumtípusokat.