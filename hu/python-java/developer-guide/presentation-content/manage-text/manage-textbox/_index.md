---
title: Szövegdobozok kezelése prezentációkban Pythonon keresztül Java-val
linktitle: Szövegdoboz kezelése
type: docs
weight: 20
url: /hu/python-java/manage-textbox/
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
- Java
- Aspose.Slides
description: "Szövegdobozok létrehozása, azonosítása, formázása és frissítése PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java használatával."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java esetén a dia szövegét a formákhoz tartozó szövegkeretek tárolják. Az [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) osztály a leggyakoribb szöveget tartalmazó alakzatot képviseli, és a szövegét a [AutoShape.getTextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/#getTextFrame) metóduson keresztül teszi elérhetővé.

{{% alert color="info" title="Note" %}}
Minden automatikus alakzat a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) osztályból örököl, de nem minden alakzat automatikus alakzat, vagy támogat szövegkeretet. Létező bemutató feldolgozásakor ellenőrizze, hogy az alakzat egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) példány-e, mielőtt hozzáférne a szövegéhez.
{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

A szövegdoboz létrehozásához adjon egy automatikus alakzatot a diára, szúrjon be szöveget a szövegkeretébe, majd mentse a bemutatót. A következő példa egy téglalap alakú szövegdobozt hoz létre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addAutoShape) metódusnak átadott koordinátákat és méreteket pontban mérik. Az [AutoShape.addTextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/#addTextFrame) inicializálja a szövegkeretet a megadott szöveggel.

## **Szövegdoboz alakzat ellenőrzése**

Használja az [AutoShape.isTextBox](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/#isTextBox) metódust annak meghatározásához, hogy egy automatikus alakzat szövegdobozként kezelhető-e. Ez akkor hasznos, amikor a bemutató mind szöveget tartalmazó, mind kizárólag grafikus automatikus alakzatokat tartalmaz.

![Egy szövegdoboz és egy alakzat](istextbox.png)

A következő példa minden automatikus alakzatot vizsgál meg egy bemutatóban:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Az újonnan hozzáadott automatikus alakzat csak akkor tekinthető szövegdoboznak, ha nem üres szöveget tartalmaz. A szöveget megadhatja az [AutoShape.addTextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/#addTextFrame) vagy a [TextFrame.setText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#setText) segítségével. Üres karakterlánc hozzáadása vagy hozzárendelése azt eredményezi, hogy az [AutoShape.isTextBox](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/#isTextBox) `False` értéket ad vissza:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

Az első két hívás `True`-t; az utolsó két hívás `False`-t ír ki.

## **A szövegkeretet birtokló alakzat megtalálása**

A generikus szövegfeldolgozó kód kaphat egy [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) objektumot anélkül, hogy tudná, melyik bemutatóobjektum tartalmazza. Használja a csak olvasható [TextFrame.getParentShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getParentShape) metódust, hogy visszalépjen a tulajdonos [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) objektumra.

Ha a szövegkeret egy automatikus alakzat vagy egy másik szöveget tartalmazó alakzat tulajdonsága, akkor a [TextFrame.getParentShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getParentShape) visszaadja a tulajdonost, míg a [TextFrame.getParentCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getParentCell) `None` értéket ad. Az érték elérése előtt ellenőrizze a visszakapott értéket. A alakzat és táblacell tulajdonosok azonosításához, beleértve a SmartArt csomópontokhoz kapcsolódó alakzatokat, lásd a [Search and Replace Text](/slides/hu/python-java/search-and-replace-text/) oldalt.

## **Oszlopok hozzáadása egy szövegdobozhoz**

A [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setColumnCount) metódus oszlopokra osztja a szövegkeretet, míg a [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setColumnSpacing) pontban állítja be az oszlopok közötti távolságot. Mindkét beállítás a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) része, és egy meglévő szövegdoboz szövegkeretén keresztül módosítható. A szöveg az ugyanazon alakzaton belül áramlik az oszlopok között; nem folytatódik egy másik alakzatra.

A következő példa egy háromoszlopos szövegdobozt hoz létre 10 pont távolsággal az oszlopok között, elmenti a bemutatót, majd visszaolvassa a tárolt beállításokat a kimeneti fájlból:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Szöveg kinyerése az egyes oszlopokból**

Használja a [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#splitTextByColumns) metódust a meglévő szövegkeret egyes vizuális oszlopainak szövegének lekéréséhez. A metódus minden oszlophoz egy karakterláncot ad vissza, oszlop-alapú olvasási sorrendben. Egy egyoszlopos szövegkeret egyetlen elemmel rendelkező tömböt eredményez, míg egy üres oszlop egy üres karakterláncként jelenik meg. A karakterláncok csak egyszerű szöveget tartalmaznak; a részlet szintű formázás nem kerül megőrzésre.

Ez akkor hasznos, ha:

- Olyan szöveget kell kinyerni, amely megőrzi oszlop-alapú olvasási sorrendjét.
- Többoszlopos diák tartalmát indexelni vagy összehasonlítani kell.
- Minden oszlopot külön fájlba, adatbázismezőbe vagy más célba exportálni kell.
- Meg kell vizsgálni, hogyan oszlik újra a szöveg a oszlopszám módosítása után a [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setColumnCount), a távolság módosítása a [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setColumnSpacing), a betűtípus, vagy a szövegkeret mérete változtatásával.

A metódus a jelenlegi [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) keretében elosztott szöveget jelenti; nem folyik automatikusan szöveg áramlás különálló alakzatok vagy szövegdobozok között. Az oszlop eloszlása függhet a rendelkezésre álló betűtípusoktól és egyéb szöveg-elrendezési beállításoktól, ezért győződjön meg arról, hogy a szükséges betűtípusok elérhetők, ha a konzisztens eredmények fontosak.

A következő példa betölt egy bemutatót, megtalálja az első többoszlopos automatikus alakzatot szövegkerettel, kiolvassa a beállított oszlopszámot, és minden oszlop szövegét külön fájlba írja. Azok az alakzatok, amelyek nem biztosítanak szövegkeretet, kihagyásra kerülnek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Szöveg frissítése**

A szöveg frissítéséhez egy teljes bemutatóban, járja végig a diákat és alakzatokat, válassza ki az automatikus alakzatokat, majd szerkessze azok szövegrétegeit. A részlet szintjén való munka lehetővé teszi a szöveg és a karakterformázás együttes módosítását.

A következő példa minden `years` előfordulást `months`-ra cserél az automatikus alakzat szövegében, és minden érintett réteget félkövérre állít:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ez a bejárás csak az automatikus alakzatok szövegét frissíti. A táblákban, diagramokban, SmartArt-ban vagy csoportosított alakzatokban tárolt szöveg módosításához ezen objektumok saját gyűjteményeinek bejárása szükséges.

## **Szövegdoboz hozzáadása hiperhivatkozással**

Egy hiperhivatkozás hozzárendelhető egy adott szövegrészhez, így csak az a szöveg lesz kattintható hivatkozás. Használja a [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) metódust a rész és egy külső URL összekapcsolásához.

A következő példa linkelt szöveget hoz létre és elmenti egy bemutatóba:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Mi a különbség egy szövegdoboz és egy szöveghelyőrző között egy mester vagy elrendezési dián?**

Egy [placeholder](/slides/hu/python-java/manage-placeholder/) örökölheti a pozícióját és formázását egy [master slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masterslide/) vagy [layout slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/) objektumtól. Egy normál szövegdoboz független alakzat a diáron, ahol létre lett hozva, és a layout változásakor nem kap placeholder viselkedést.

**Hogyan cserélhetem le a szöveget anélkül, hogy a diagramok, táblák vagy SmartArt szövegét módosítanám?**

Korlátozza a bejárást azokra az alakzatokra, amelyek a [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) példányai, ahogy az a Szöveg frissítése példában is látható. A diagramok, táblák és SmartArt saját objektummodelljeikben tárolják a szöveget, ezért azok a ciklus által nem módosulnak.