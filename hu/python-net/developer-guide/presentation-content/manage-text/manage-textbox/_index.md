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
description: "Szövegdobozok létrehozása, azonosítása, formázása és frissítése PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával."
---
## **Bevezetés**

Az Aspose.Slides for Python via .NET esetén a dia szövegét olyan szövegkeretekben tárolják, amelyek alakzatokhoz tartoznak. A [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) osztály a leggyakoribb szöveget tartalmazó alakzatot képviseli, és a szövegét a [AutoShape.text_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/text_frame/) tulajdonságon keresztül teszi elérhetővé.

{{% alert color="info" title="Note" %}}
Minden automatikus alakzat a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) osztályból származik, de nem minden alakzat automatikus alakzat, vagy támogatja a szövegkeretet. Egy meglévő bemutató feldolgozásakor használja az `isinstance(shape, slides.AutoShape)` metódust a alakzat típusának ellenőrzésére, mielőtt hozzáférne a szövegéhez.
{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

Egy szövegdoboz létrehozásához adjon egy automatikus alakzatot a diára, szöveget adjon a szövegkeretéhez, majd mentse a prezentációt. A következő példa egy téglalap alakú szövegdobozt hoz létre:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

A [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_auto_shape/) metódusnak átadott koordinátákat és méreteket pontokban mérik. Az [AutoShape.add_text_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/add_text_frame/) a megadott szöveggel inicializálja a szövegkeretet.

## **Szövegdoboz alakzat ellenőrzése**

Használja az [AutoShape.is_text_box](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/is_text_box/) tulajdonságot annak meghatározására, hogy egy automatikus alakzat szövegdobozként van-e kezelve. Ez akkor hasznos, ha egy prezentáció szöveget tartalmazó és kizárólag grafikus automatikus alakzatokat is tartalmaz.

![Szövegdoboz és egy alakzat](istextbox.png)

A következő példa minden automatikus alakzatot megvizsgál egy prezentációban:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Az újonnan hozzáadott automatikus alakzat csak akkor tekinthető szövegdoboznak, ha nem üres szöveget tartalmaz. A szöveget megadhatja az [AutoShape.add_text_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/add_text_frame/) vagy a [TextFrame.text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/text/) segítségével. Üres karakterlánc hozzáadása vagy hozzárendelése esetén az [is_text_box](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/is_text_box/) `False` értéken marad:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

Az első két hívás `True`‑t, az utolsó két `False`‑t ír ki.

## **A szövegkeretet birtokló alakzat megtalálása**

Az általános szövegfeldolgozó kód kaphat egy [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumot anélkül, hogy tudná, melyik prezentációs objektum tartalmazza. Használja csak-olvasható [TextFrame.parent_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_shape/) tulajdonságát, hogy visszanyerje a tulajdonos [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) alakzatot.

Ha egy szövegkeret egy automatikus alakzat vagy egy másik szöveget tartalmazó alakzat tulajdonában van, a [parent_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_shape/) a tulajdonost tartalmazza, és a [TextFrame.parent_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_cell/) `None`. Ellenőrizze a visszaadott értéket, mielőtt hozzáférne. A shape és a táblacella tulajdonosok, köztük a SmartArt csomópontokhoz kapcsolódó alakzatok azonosításához lásd a [Search and Replace Text](/slides/hu/python-net/search-and-replace-text/) oldalt.

## **Oszlopok hozzáadása egy szövegdobozhoz**

A [TextFrameFormat.column_count](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/column_count/) tulajdonság oszlopokra osztja a szövegkeretet, míg a [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/column_spacing/) pontokban állítja be az oszlopok közötti távolságot. Mindkét beállítás a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/) része, és egy meglévő szövegdoboz szövegkeretén keresztül módosítható. A szöveg az ugyanazon alakzaton belül oszlopok között újraíródik; nem folytatódik egy másik alakzatba.

A következő példa egy három oszlopos szövegdobozt hoz létre, 10 pontos oszloptávolsággal, elmenti a prezentációt, és visszaolvassa a tárolt beállításokat a kimeneti fájlból:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Szöveg kinyerése egyedi oszlopokból**

Használja a [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/split_text_by_columns/) metódust, hogy lekérdezze egy meglévő szövegkeretben minden vizuális oszlophoz rendelt szöveget. A metódus minden oszlophoz egy karakterláncot ad vissza, oszlop‑alapú olvasási sorrendben. Egy egyoszlopos szövegkeret egy elemet tartalmazó listát eredményez, és egy üres oszlop üres karakterláncként jelenik meg. A karakterláncok csak egyszerű szöveget tartalmaznak; a részlet szintű formázás nem marad meg.

Ez akkor hasznos, ha:
- Szöveg kinyerése miközben megőrzi az oszlop‑alapú olvasási sorrendet.
- Többoszlopos diák tartalmának indexelése vagy összehasonlítása.
- Minden oszlop exportálása külön fájlba, adatbázismezőbe vagy más célhelyre.
- Vizsgálja meg, hogyan oszlik újra a szöveg a [TextFrameFormat.column_count](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/column_count/), a [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/column_spacing/), a betűtípus vagy a szövegkeret mérete megváltoztatása után.

A metódus a jelenlegi [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) keretében elosztott szöveget adja vissza; nem áramoltatja automatikusan a szöveget különálló alakzatok vagy szövegdobozok között. Az oszlopelrendezés függhet a rendelkezésre álló betűtípusoktól és egyéb szöveg‑elrendezési beállításoktól, ezért ügyeljen arra, hogy a szükséges betűtípusok elérhetők legyenek, ha konzisztens eredményekre van szükség.

A következő példa betölt egy prezentációt, megkeresi az első többoszlopos automatikus alakzatot szövegkerettel, kiolvassa a konfigurált oszlopszámot, és minden oszlop szövegét külön fájlba írja. Azok az alakzatok, amelyek nem biztosítanak szövegkeretet, ki lesznek hagyva.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Szöveg frissítése**

A szöveg frissítéséhez egy teljes prezentációban, járja végig a diákat és az alakzatokat, válassza ki az automatikus alakzatokat, majd szerkessze azok szövegrészeit. Részlet szinten dolgozva módosíthatja a szöveget és a karakterformázást is.

A következő példa minden `years` előfordulást `months`‑ra cserél az automatikus alakzat szövegében, és minden érintett részt félkövérre állít:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Ez az útvonal csak az automatikus alakzatok szövegét frissíti. A táblákban, diagramokban, SmartArt‑ban vagy csoportosított alakzatokban tárolt szöveg frissítéséhez ezen objektumok saját gyűjteményeinek bejárása szükséges.

## **Szövegdoboz hozzáadása hiperhivatkozással**

A hiperhivatkozás egy adott szövegrészhez rendelhető, így csak az a szöveg lesz kattintható link. Használja a [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) metódust, hogy a részt egy külső URL‑hez kapcsolja.

A következő példa hivatkozásos szöveget hoz létre, és elmenti egy prezentációba:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Mi a különbség egy szövegdoboz és egy szöveghelykitöltő között egy mester‑ vagy elrendezés‑dián?**

Egy [placeholder](/slides/hu/python-net/manage-placeholder/) örökölheti a pozícióját és formázását egy [master slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/) vagy [layout slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/) objektumtól. Egy normál szövegdoboz egy önálló alakzat a dián, ahol létre lett hozva, és nem kap placeholder viselkedést, amikor az elrendezés megváltozik.

**Hogyan cserélhetem le a szöveget anélkül, hogy a diagramok, táblák vagy SmartArt szövegét módosítanám?**

Korlátozza a bejárást az [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) példányokra, ahogy az a Szöveg frissítése példában szerepel. A diagramok, táblák és SmartArt saját objektummodelljükben tárolják a szöveget, ezért az a ciklus nem módosítja őket.