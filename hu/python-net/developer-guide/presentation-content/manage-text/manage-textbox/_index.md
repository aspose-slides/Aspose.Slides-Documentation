---
title: Szövegdobozok kezelése prezentációkban Python segítségével
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
- szöveg oszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Az Aspose.Slides for Python .NET-en keresztül megkönnyíti a szövegdobozok létrehozását, szerkesztését és klónozását PowerPoint és OpenDocument fájlokban, ezáltal javítva a prezentációk automatizálását."
---
## **Bevezetés**

A diákon a szövegek általában szövegdobozokban vagy alakzatokban vannak. Ezért, ha szöveget szeretne hozzáadni a diára, először egy szövegdobozt kell létrehozni, majd szöveget helyezni a dobozba. Az Aspose.Slides for Python biztosítja a [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) osztályt, amely lehetővé teszi szöveget tartalmazó alakzat hozzáadását.

{{% alert title="Info" color="info" %}}
Az Aspose.Slides emellett a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) osztályt is biztosítja. Azonban nem minden alakzat képes szöveget tartalmazni.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Ezért, ha egy olyan alakzattal dolgozik, amelyhez szöveget szeretne hozzáadni, érdemes ellenőrizni és megerősíteni, hogy az [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) osztályon keresztül lett átkonvertálva. Csak ekkor lesz lehetősége a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) használatára, amely az [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) egy tulajdonsága. Lásd a [Update Text](/slides/hu/python-net/manage-textbox/#update-text) szekciót ezen az oldalon.
{{% /alert %}}

## **Szövegdobozok létrehozása a diákon**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást az első diára.  
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet `ShapeType.RECTANGLE` típussal a kívánt helyen a dián.  
4. Állítsa be a szöveget az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) tulajdonságában.  
5. Mentse a bemutatót PPTX fájlként.

Az alábbi Python példa megvalósítja ezeket a lépéseket:

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt.
with slides.Presentation() as presentation:

    # Lekéri a prezentáció első diáját.
    slide = presentation.slides[0]

    # Hozzáad egy RECTANGLE típusú AutoShape-et.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # A prezentációt lemezre menti.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Ellenőrizze, hogy az alakzat szövegdoboz-e**

Az Aspose.Slides biztosítja az [is_text_box](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/is_text_box/) tulajdonságot a [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) osztályon, amely lehetővé teszi meghatározni, hogy egy alakzat szövegdoboz-e.

![Text box and shape](istextbox.png)

Ez a Python példa bemutatja, hogyan ellenőrizhető, hogy egy alakzat szövegdobozként lett-e létrehozva:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Felhívjuk a figyelmet, hogy ha egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/) osztály segítségével ad hozzá, az alakzat `is_text_box` tulajdonsága `False` értéket ad vissza. Azonban, ha szöveget ad hozzá – akár az `add_text_frame` metódussal, akár a `text` tulajdonság beállításával – a `is_text_box` `True` értéket ad.

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

## **Oszlopok hozzáadása a szövegdobozokhoz**

Az Aspose.Slides a [column_count](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/column_count/) és a [column_spacing](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/column_spacing/) tulajdonságokat biztosítja a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/) osztályban, hogy oszlopokat adhasson a szövegdobozokhoz. Megadhatja az oszlopok számát, és beállíthatja az oszlopok közti távolságot (pontban).

Az alábbi Python kód bemutatja ezt a műveletet:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Lekéri a prezentáció első diáját.
	slide = presentation.slides[0]

	# Hozzáad egy RECTANGLE típusú AutoShape-et.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Hozzáad egy TextFrame-et a téglalaphoz.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Lekéri a TextFrame szövegformázását.
	format = shape.text_frame.text_frame_format

	# Meghatározza az oszlopok számát a TextFrame-ben.
	format.column_count = 3

	# Meghatározza az oszlopok közti távolságot.
	format.column_spacing = 10

	# A prezentációt menti.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg frissítése**

Az Aspose.Slides lehetővé teszi a szöveg frissítését egyetlen szövegdobozban vagy az egész bemutatóban.

Az alábbi Python példa bemutatja, hogyan frissítheti az összes szöveget egy bemutatóban:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # A módosított prezentáció mentése.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Szövegdobozok hozzáadása hiperhivatkozással**

Beszúrhat egy hivatkozást egy szövegdobozba. Amikor a szövegdobozra kattintanak, a hivatkozás megnyílik.

Egy hiperhivatkozást tartalmazó szövegdoboz hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást az első diára.  
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet `ShapeType.RECTANGLE` típussal a kívánt helyen a dián.  
4. Állítsa be a szöveget az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) tulajdonságában.  
5. Szerezzen hivatkozást a [HyperlinkManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkmanager/) objektumra.  
6. Használja a `hyperlink_manager` tulajdonságot egy külső kattintási hiperhivatkozás beállításához.  
7. Mentse a bemutatót PPTX fájlként.

Ez a Python példa megmutatja, hogyan adjon hozzá egy hiperhivatkozással rendelkező szövegdobozt egy diához:

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt.
with slides.Presentation() as presentation:

    # Lekéri a prezentáció első diáját.
    slide = presentation.slides[0]

    # Hozzáad egy RECTANGLE típusú AutoShape-et.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Szöveget ad a kerethez.
    text_portion.text = "Aspose.Slides"

    # Beállít egy hiperhivatkozást a rész szövegéhez.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # A prezentációt PPTX fájlként menti.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Mi a különbség a szövegdoboz és a szöveghelyőrző között, amikor mester diákon dolgozik?**

A [placeholder](/slides/hu/python-net/manage-placeholder/) a [master](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/) stílusát/pozícióját örökli, és a [layoutok](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/) során felülírható, míg egy hagyományos szövegdoboz egy önálló objektum egy adott dián, és nem változik, amikor a layoutot cseréli.

**Hogyan végezhetek tömeges szövegcserét a teljes bemutatóban anélkül, hogy a diagramok, táblázatok és SmartArt szövegét módosítanám?**

Korlátozza az iterációt azokra az auto-shape-ekre, amelyeknek van szövegkeretük, és hagyja ki a beágyazott objektumokat ([charts](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartart/)) úgy, hogy azok gyűjteményeit külön járja be, vagy kihagyja ezeket az objektumtípusokat.