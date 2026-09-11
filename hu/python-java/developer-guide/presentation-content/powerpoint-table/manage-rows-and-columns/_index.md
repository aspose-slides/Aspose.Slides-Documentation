---
title: PowerPoint táblázatok sorainak és oszlopainak kezelése Pythonban
linktitle: Sorok és oszlopok
type: docs
weight: 20
url: /hu/python-java/manage-rows-and-columns/
keywords:
- táblázat sor
- táblázat oszlop
- első sor
- táblázat fejléc
- sor klónozása
- oszlop klónozása
- sor másolása
- oszlop másolása
- sor eltávolítása
- oszlop eltávolítása
- sor szövegformázás
- oszlop szövegformázás
- táblázat stílus
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Kezelje a PowerPoint táblázatok sorait és oszlopait az Aspose.Slides for Python via Java használatával, és gyorsítsa fel a prezentáció szerkesztését és az adatok frissítését."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy kezelje egy táblázat sorait és oszlopait egy PowerPoint előadásban, a [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) osztályt és számos egyéb típust biztosít.

## **Az első sor beállítása fejlécnek**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be az előadást.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Hozzon létre egy [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) referenciát, és állítsa `None` értékre.
4. Iteráljon végig az összes [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) objektumon, hogy megtalálja a megfelelő táblázatot.
5. Állítsa be a táblázat első sorát fejlécnek.

Ez a Python kód megmutatja, hogyan állítható be egy táblázat első sora fejlécnek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Táblázat sor vagy oszlop klónozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be az előadást.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Határozzon meg egy oszlopszélességek listáját.
4. Határozzon meg egy sormagasságok listáját.
5. Adjon hozzá egy [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) objektumot a diára a [addTable](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addTable) metódussal.
6. Klónozza a táblázat sort.
7. Klónozza a táblázat oszlopot.
8. Mentse a módosított előadást.

Ez a Python kód megmutatja, hogyan klónozható egy PowerPoint táblázat sorát vagy oszlopát:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sor vagy oszlop eltávolítása a táblázatból**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Határozzon meg egy oszlopszélességek listáját.
4. Határozzon meg egy sormagasságok listáját.
5. Adjon hozzá egy [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) objektumot a diára a [addTable](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addTable) metódussal.
6. Távolítsa el a táblázat sort.
7. Távolítsa el a táblázat oszlopot.
8. Mentse a módosított előadást.

Ez a Python kód megmutatja, hogyan távolítható el egy sor vagy oszlop egy táblázatból:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Szövegformázás beállítása a táblázat sor szintjén**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be az előadást.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Érje el a megfelelő [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) objektumot a diáról.
4. Állítsa be az első sor celláinak betűméretét a [setFontHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setFontHeight) használatával.
5. Állítsa be az első sor celláinak szövegigazítását és jobb margóját a [setAlignment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setAlignment) és a [setMarginRight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setMarginRight) használatával.
6. Állítsa be a második sor celláinak függőleges szöveg típusát a [setTextVerticalType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setTextVerticalType) használatával.
7. Mentse a módosított előadást.

Ez a Python kód bemutatja a műveletet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Szövegformázás beállítása a táblázat oszlop szintjén**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be az előadást.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Érje el a megfelelő [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) objektumot a diáról.
4. Állítsa be az első oszlop celláinak betűméretét a [setFontHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setFontHeight) használatával.
5. Állítsa be az első oszlop celláinak szövegigazítását és jobb margóját a [setAlignment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setAlignment) és a [setMarginRight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setMarginRight) használatával.
6. Állítsa be a második oszlop celláinak függőleges szöveg típusát a [setTextVerticalType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setTextVerticalType) használatával.
7. Mentse a módosított előadást.

Ez a Python kód bemutatja a műveletet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Táblázat stílus tulajdonságainak lekérése**

Aspose.Slides lehetővé teszi, hogy lekérdezze egy táblázat stílus tulajdonságait, hogy ezeket a részleteket felhasználhassa egy másik táblázathoz vagy máshol. Ez a Python kód megmutatja, hogyan lehet lekérni a stílus tulajdonságokat egy táblázat előre beállított stílusából:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/elrendezés/mester téma beállításait, és továbbra is felülírhatja a kitöltéseket, a szegélyeket és a szövegszíneket ezen a témán.

**Rendezhetem a táblázat sorait Excelhez hasonlóan?**

Nem, az Aspose.Slides táblázatoknak nincs beépített rendezése vagy szűrője. Először rendezze az adatokat a memóriában, majd töltse újra a táblázat sorait ebben a sorrendben.

**Lehetnek sávos (csíkozott) oszlopok, miközben egyéni színeket tartok meg konkrét cellákon?**

Igen. Kapcsolja be a sávos oszlopokat, majd felülírja a konkrét cellákat helyi formázással; a cellaszintű formázás előbbre él a táblázat stílusával.