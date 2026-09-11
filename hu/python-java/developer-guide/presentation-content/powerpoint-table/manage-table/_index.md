---
title: PowerPoint táblázatok kezelése Pythonban
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/python-java/manage-table/
keywords:
- táblázat hozzáadása
- táblázat létrehozása
- táblázat elérése
- méretarány
- szöveg igazítása
- szöveg formázása
- táblázat stílusa
- PowerPoint
- bemutató
- Python
- Aspose.Slides
description: "Hozzon létre és szerkesszen táblázatokat PowerPoint diákon az Aspose.Slides for Python via Java segítségével. Fedezzen fel egyszerű kódpéldákat a táblázati munkafolyamatok egyszerűsítéséhez."
---
## **Bevezetés**

A PowerPoint táblázat hatékony módja az információ megjelenítésének. Az információ egy cellákból álló rácsban (sorokba és oszlopokba rendezve) egyszerű és könnyen érthető.

Az Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) osztályt, a [Cell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cell/) osztályt és egyéb típusokat, amelyek lehetővé teszik táblázatok létrehozását, frissítését és kezelését különféle bemutatókban.

## **Táblázat létrehozása nulláról**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást egy dia indexe alapján.  
3. Határozzon meg egy oszlopszélességek listáját.  
4. Határozzon meg egy sormagasságok listáját.  
5. Adjon hozzá egy [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) objektumot a diára az [addTable](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addTable) metódussal.  
6. Iteráljon végig minden [Cell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cell/) objektumon, hogy formázást alkalmazzon a felső, alsó, jobb és bal szegélyekre.  
7. Olvassza össze a táblázat első sorának első két celláját.  
8. Szerezzen hozzáférést egy [Cell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/)-hez.  
9. Adjon szöveget a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/)-hez.  
10. Mentse el a módosított bemutatót.

Ez a Python kód bemutatja, hogyan hozhat létre egy táblázatot egy bemutatóban:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
presentation = Presentation()
try:

    # Eléri az első diát
    slide = presentation.getSlides().get_Item(0)

    # Meghatározza az oszlopok szélességét és a sorok magasságát
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Táblázat alakzatot ad hozzá a diához
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Beállítja minden cella keretformátumát
    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    # Összevonja az 1. sor 1. és 2. celláját
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Szöveget ad a összevont cellához
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Elmenti a bemutatót a lemezre
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cellák számozása egyszerű és nullától indul. Az első cella indexe 0,0 (oszlop 0, sor 0).

Például egy 4 oszlopos és 4 soros táblázat cellái így vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a Python kód bemutatja, hogyan hozhat létre egy táblázatot a szabványos cellaszámozással:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
presentation = Presentation()
try:

    # Eléri az első diát
    slide = presentation.getSlides().get_Item(0)

    # Meghatározza az oszlopok szélességét és a sorok magasságát
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Táblázat alakzatot ad hozzá a diához
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Beállítja minden cella keretformátumát
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)

    # Elmenti a bemutatót a lemezre
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Meglévő táblázat elérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást a táblázatot tartalmazó diára az indexe alapján.  
3. Inicializáljon egy változót egy [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) objektumhoz, és állítsa `None`‑ra.  
4. Iteráljon végig az összes [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) objektumon, amíg meg nem találja a táblázatot.  

   Ha úgy gondolja, hogy a feldolgozott dia egyetlen táblázatot tartalmaz, egyszerűen ellenőrizheti az összes benne lévő alakzatot. Ha egy alakzatot táblázatként azonosít, azt [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) objektumként használhatja. Ha azonban a dia több táblázatot tartalmaz, akkor célszerűbb a szükséges táblázatot a [getAlternativeText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getAlternativeText) metódusával keresni.  
5. Használja a [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) objektumot a táblázat kezeléséhez. Az alábbi példában a második sor első oszlopának szövegét frissítjük.  
6. Mentse el a módosított bemutatót.

Ez a Python kód bemutatja, hogyan érheti el és dolgozhat egy meglévő táblázattal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Eléri az első diát
    slide = presentation.getSlides().get_Item(0)

    # Inicializálja a táblázat hivatkozást.
    table = None

    # Iterál a shape-eken és beállítja a megtalált táblázatra mutató hivatkozást
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Beállítja a szöveget a második sor első oszlopához
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Elmenti a módosított bemutatót a lemezre
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Keresse meg a szövegkeretet tartalmazó cellát**

Amikor általános szövegfeldolgozó kód egy [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/)‑et kap egy táblázatból, használja a [TextFrame.getParentCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getParentCell) metódust a tulajdonos [Cell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cell/) lekéréséhez. Egy táblázat‑cellához tartozó szövegkeret esetén a [TextFrame.getParentCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getParentCell) visszaadja a tulajdonost, a [TextFrame.getParentShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getParentShape) pedig `None`‑t ad, még akkor is, ha a táblázat maga egy shape.

A cellakoordináták elérhetők a csak‑olvasású [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cell/#getFirstColumnIndex) és [Cell.getFirstRowIndex](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cell/#getFirstRowIndex) metódusokon keresztül. A [TextFrame.getParentCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getParentCell) szintén csak‑olvasású navigációt biztosít: visszaadja a tulajdonost, de nem változtatja meg a tulajdonjogot. Mindig ellenőrizze, hogy a visszakapott cella nem `None`‑e, mielőtt felhasználná.

A teljes példáért, amely azonosítja a táblázat‑cellák és shape‑ok tulajdonosait, beleértve a SmartArt csomópontokhoz kapcsolódó shape‑okat, lásd a [Search and Replace Text](/slides/hu/python-java/search-and-replace-text/) oldalt.

## **Szöveg igazítása a táblázatban**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást egy dia indexe alapján.  
3. Adjon hozzá egy [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) objektumot a diára.  
4. Szerezzen hozzáférést a táblázat [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) objektumához.  
5. Szerezze meg a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) objektum [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) részét.  
6. Igazítsa a szöveget függőlegesen.  
7. Mentse el a módosított bemutatót.

Ez a Python kód bemutatja, hogyan igazíthatja a szöveget egy táblázatban:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Létrehozza a Presentation osztály egy példányát
presentation = Presentation()
try:

    # Lekéri az első diát
    slide = presentation.getSlides().get_Item(0)

    # Meghatározza az oszlopok szélességét és a sorok magasságát
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Hozzáadja a táblázat alakzatot a diához
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Eléri a szövegkeretet
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Eléri a szövegkeret első bekezdését.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Eléri a bekezdés első részletét.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Függőlegesen igazítja a szöveget
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Elmenti a bemutatót a lemezre
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Szöveg formázásának beállítása táblázatszinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást egy dia indexe alapján.  
3. Szerezzen hozzáférést a dián lévő [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) objektumhoz.  
4. Állítsa be a szöveg betűmagasságát a [setFontHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setFontHeight) metódussal.  
5. Állítsa be az igazítást és a jobb margót a [setAlignment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setAlignment) és a [setMarginRight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setMarginRight) metódusokkal.  
6. Állítsa be a függőleges szöveg típust a [setTextVerticalType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setTextVerticalType) metódussal.  
7. Mentse el a módosított bemutatót.

Ez a Python kód bemutatja, hogyan alkalmazhatja a kívánt formázási beállításokat a táblázat szövegére:

```python
import jpype
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Létrehozza a Presentation osztály egy példányát
presentation = Presentation("simpletable.pptx")
try:

    # Tegyük fel, hogy az első dián az első shape egy táblázat
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Beállítja a táblázat celláinak betűmagasságát
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Beállítja a táblázat celláinak szövegigazítását és jobb margóját egy hívásban
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Beállítja a táblázat celláinak függőleges szöveg típusát
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Táblázat stílus tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi egy táblázat stílus tulajdonságainak lekérését, hogy ezeket a részleteket más táblázathoz vagy más helyen felhasználhassa. Ez a Python kód bemutatja, hogyan lehet lekérni a stílus tulajdonságokat egy táblázat előre beállított stílusából:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # változtatja az alapértelmezett stílus előbeállítás témáját

    # Lekéri a táblázat stílus előbeállítását
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Alkalmazza a lekért stílus előbeállítást egy másik táblázatra
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Táblázat méretarányának rögzítése**

A geometriai alakzat méretarányát a különböző dimenziók méreteinek aránya határozza meg. Az Aspose.Slides biztosítja a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) metódust, amely lehetővé teszi a méretarány beállításának rögzítését táblázatok és egyéb alakzatok esetén.

Ez a Python kód bemutatja, hogyan rögzítheti a méretarányt egy táblázat esetén:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # invertálja
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **GYIK**

**Engedélyezhetek jobbról balra (RTL) olvasási irányt egy teljes táblázat és celláinak szövege számára?**

Igen. A táblázat rendelkezik egy [setRightToLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/#setRightToLeft) metódussal, a bekezdések pedig a [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setRightToLeft) metódussal. Mindkettő használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók a végleges fájlban mozgatni vagy átméretezni tudják a táblázatot?**

Használjon [shape locks](/slides/hu/python-java/applying-protection-to-presentation/) beállításokat a mozgatás, átméretezés, kijelölés stb. letiltásához. Ezek a zárolások a táblázatokra is érvényesek.

**Támogatott-e egy kép beillesztése egy cellába háttérként?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/) kitöltést egy cellához; a kép a választott mód szerint (nyújtás vagy mozaik) lefedi a cella területét.