---
title: Prezentációs táblázatok kezelése Pythonban
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/python-java/manage-table/
keywords:
- tábla hozzáadása
- tábla létrehozása
- tábla elérése
- képarány
- szöveg igazítása
- szövegformázás
- tábla stílusa
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Hozzon létre és szerkesszen táblázatokat PowerPoint diákként az Aspose.Slides for Python via Java segítségével. Fedezzen fel egyszerű kódrészleteket, hogy egyszerűsítse a táblázat munkafolyamatait."
---
## **Bevezetés**

A PowerPoint táblázatai sorokba és oszlopokba rendezik az információt, megkönnyítve ezzel az értékek olvasását és összehasonlítását.

Az Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) és a [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) osztályokat, valamint egyéb típusokat, amelyek lehetővé teszik táblázatok létrehozását, frissítését és kezelését prezentációkban.

## **Táblázat létrehozása az elejétől**

Hozzon létre egy táblázatot a pozíció, az oszlopszélességek és a sormagasságok megadásával. A diára való felvétel után formázhatja a cellahatárokat, egyesítheti a cellákat és szöveget szúrhat be.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát a diára a indexe alapján.
3. Határozzon meg egy oszlopszélesség-listát pontban.
4. Határozzon meg egy sormagasság-listát pontban.
5. Adjon hozzá egy [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) objektumot a diára a [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) metódus segítségével.
6. Iteráljon végig minden [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) elem felett, hogy formázza a felső, alsó, jobb és bal határokat.
7. Egyesítse a táblázat első sorának első két celláját.
8. A összeolvadt cellához férjen hozzá a [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) metódusával.
9. Állítsa be a szöveget az összeolvadt cellában.
10. Mentse a módosított prezentációt.

Az alábbi példa három oszlopú és öt soros táblázatot hoz létre (100, 50) pont helyen. Piros határokat alkalmaz 5 pont szélességgel, egyesíti az első sor első két celláját, és a végeredményt `table.pptx`‑ként menti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cellaindexek nullától indulnak, és a (oszlop, sor) sorrendet használják. Az első cella indexe (0, 0).

Például egy 4 oszlopú és 4 soros táblázat cellái így vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a példa létrehozza a fent ábrázolt 4 × 4-es táblázatot, oszlopszélességekkel és sormagasságokkal 70 pontban, valamint piros cellahatárokkal 5 pont szélességgel. A koordináták a cellaindexeket szemléltetik; a példa üresen hagyja a cellákat, és a táblát `StandardTables_out.pptx`‑ként menti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Létező táblázat elérése**

A táblázatok egy dia alakzat-gyűjteményében tárolódnak. Iteráljon végig az alakzatokon, hogy megtalálja a táblázatot, majd használja a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) osztályt a cellák olvasásához vagy frissítéséhez.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztály segítségével.
2. Szerezzen referenciát a táblázatot tartalmazó diára a indexe alapján.
3. Iteráljon a [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) objektumok között, és álljon le, amikor táblázatot talál. Ha a dián több táblázat is van, használja a [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) metódust a szükséges azonosításához.
4. Frissítse a célcella szövegét.
5. Mentse a módosított prezentációt.

Az alábbi példa megnyitja a `UpdateExistingTable.pptx`‑t, és megtalálja az első táblázatot az első dián. A 0. oszlop, 1. sor celláját a `New` értékre állítja, majd a végeredményt `table1_out.pptx`‑ként menti. A bemenetnek legalább egy diát kell tartalmaznia, és az első táblázatnak az adott dián legalább egy oszloppal és két sorral kell rendelkeznie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A meglévő táblázat sorának átméretezéséhez és annak megértéséhez, hogy miért léphet túl a tényleges magassága a kért minimumon, lásd a [Control Row Height](/slides/hu/python-java/manage-rows-and-columns/#control-row-height) című oldalt.

## **A szövegkeretet tulajdonló cella megtalálása**

Amikor egy általános szövegfeldolgozó kód egy [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) objektumot kap a táblázattól, használja a [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) metódust a tulajdonos [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) lekéréséhez. Egy táblázat‑cella szövegkeret esetén a [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) visszaadja a tulajdonost, míg a [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) `None` értéket ad, annak ellenére, hogy maga a táblázat is egy alakzat.

A cellakoordináták a csak‑olvasásra szánt [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) és [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) metódusokon keresztül érhetők el. A [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) szintén csak‑olvasási navigációt biztosít: visszaadja a tulajdonost, de nem változtatja meg a tulajdonjogot. Mindig ellenőrizze a visszakapott cellát `None` érték ellen, mielőtt felhasználná.

Egy teljes példáért, amely azonosítja a táblázat‑cella és alakzat tulajdonosokat, beleértve a SmartArt csomópontokhoz kapcsolódó alakzatokat, lásd a [Search and Replace Text](/slides/hu/python-java/search-and-replace-text/) című oldalt.

## **Szöveg igazítása egy táblázatban**

Egyes táblázatcélák függőleges rögzítését és szövegirányát vezérelheti. Ebben a szakaszban a példa középre helyezi a szöveget az első cellában, és 270 fokkal elforgatja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát a diára a indexe alapján.
3. Adj hozzá egy [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) objektumot a diára.
4. Szerezzen hozzá egy [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) objektumot a táblázatból.
5. Szerezze meg az első [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) elemet, és állítsa be a szövegét és színét.
6. Állítsa be a cella függőleges rögzítését és a szövegirányt a [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) és a [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType) segítségével.
7. Mentse a módosított prezentációt.

Ez a példa egy 4 × 4-es táblázatot hoz létre 120 pontos oszlopszélességekkel és 100 pontos sormagasságokkal. Formázza a (0, 0) cella szövegét, értékeket ad a első sor maradék celláihoz, és a végeredményt `Vertical_Align_Text_out.pptx`‑ként menti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Szövegformázás beállítása táblázatszinten**

Használja a [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) metódust a szövegformázás alkalmazásához a táblázat minden cellájára. A túlterhelései a részlet, bekezdés és szövegkeret formázását is elfogadják, így ezek a tulajdonságok egyenkénti cellaiteráció nélkül állíthatók be.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztály segítségével.
2. Szerezzen referenciát a diára a indexe alapján.
3. Szerezzen hozzá egy [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) objektumot a diáról.
4. Állítsa be a betűméretet a [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) használatával a szöveghez.
5. Állítsa be a bekezdés igazítását és a jobb margót a [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) és a [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) segítségével.
6. Állítsa be a szöveg irányát a [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) használatával.
7. Mentse a módosított prezentációt.

Az alábbi példa megnyitja a `table.pptx`‑t, amelynek legalább egy diát kell tartalmaznia, ahol a táblázat az első alakzat. A betűméretet 25 pontra állítja, a bekezdéseket jobbra igazítja 20 pontos jobb margóval, és függőleges irányúra állítja a szöveget. A formázott prezentáció `result.pptx`‑ként kerül mentésre.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Táblázat stílus tulajdonságainak lekérése**

Használja a [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) metódust egy táblázat előre definiált stílusának beolvasásához, és a [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) metódust a hozzárendeléshez. Ez a példa a [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) stílust alkalmaz egy táblázatra, kiírja a beállított értéket, majd ugyanazt a stílust a másik táblázatra is alkalmazza. Mindkét táblázat `table-style.pptx`‑ben kerül mentésre.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Táblázat képarányának zárolása**

Egy táblázat képaránya a szélesség és magasság aránya. Használja a [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) metódust ennek az aránynak a zárolásához.

Az alábbi példa megnyitja a `pres.pptx`‑t, amelynek legalább egy diát kell tartalmaznia, ahol a táblázat az első alakzat. Kiírja a jelenlegi zárolási állapotot, engedélyezi a képarány zárolását, kiírja a frissített állapotot (`True`), majd a végeredményt `pres-out.pptx`‑ként menti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt egy teljes táblázat és a celláiban lévő szöveg számára?**

Igen. A táblázat rendelkezik egy [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) metódussal, a bekezdéseknek pedig [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft) metódusa van. Mindkettő használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók a végleges fájlban mozgassák vagy átméretezzék a táblázatot?**

Használja a [shape locks](/slides/hu/python-java/applying-protection-to-presentation/) lehetőséget a mozgatás, átméretezés, kijelölés stb. letiltására. Ezek a zárolások a táblázatokra is érvényesek.

**Támogatott-e egy kép beillesztése egy cellába háttérként?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) kitöltést a cellához; a kép a választott mód (nyújtás vagy mozaik) szerint lefedi a cellaterületet.