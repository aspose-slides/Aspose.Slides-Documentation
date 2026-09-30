---
title: PowerPoint táblák sorainak és oszlopainak kezelése Python segítségével
linktitle: Sorok és oszlopok
type: docs
weight: 20
url: /hu/python-java/manage-rows-and-columns/
keywords:
- tábla sor
- tábla oszlop
- első sor
- tábla fejléc
- sor klónozása
- oszlop klónozása
- sor másolása
- oszlop másolása
- sor eltávolítása
- oszlop eltávolítása
- sor szövegformázás
- oszlop szövegformázás
- tábla stílus
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Táblák sorainak és oszlopainak kezelése PowerPointban az Aspose.Slides for Python via Java segítségével, valamint a prezentációs szerkesztés és adatfrissítések felgyorsítása."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java lehetővé teszi a táblázat struktúrájának és formázásának kezelését PowerPoint‑prezentációkban a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) osztályon keresztül. Megjelölhet egy fejléces sort, másolhat vagy eltávolíthat sorokat és oszlopokat, és alkalmazhat szövegformázást egy teljes sorra vagy oszlopra.

Ez a cikk elmagyarázza ezeket a műveleteket Python példákkal. Bemutatja, hogyan lehet lekérni egy táblázat stíluselőbeállítását, hogy újra felhasználhassa. A táblázat sor‑ és oszlophatárai nulláról indulnak.

## **Sormagasság szabályozása**

Használja a [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) metódust a sor minimummagasságának beállításához pontban. Ez egy alsó határ, nem rögzített magasság. A [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) visszaadja a tényleges magasságot. A sorhoz a [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows) segítségével férhet hozzá.

A példa betölti a [row-height-input.pptx](row-height-input.pptx) fájlt, amelyben a táblázat az első dia első alakja. Az első sor 70 pontnál kezdődik. A cellák 18 pontos Arial szöveget, sortörést, valamint 6 pontos felső és alsó margót használnak; a második oszlopban a hosszabb szöveg több sorra törik. A példa a minimumot 100 pontra növeli, majd 20 pontra csökkenti, minden változtatás után kiírja a tényleges magasságot, és elmenti mindkét eredményt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A megadott prezentációval a minimum növelése helyet ad a sornak. A csökkentés eltávolítja ezt a felesleges helyet, de a tényleges magasság 20 pontnál nagyobb marad, mivel a szövegnek és a cellamargóknak több helyre van szükségük. A minimum önmagában csökkentése nem képes a sort a tartalom által igényelt tér alá kényszeríteni.

Több tényező befolyásolja a tényleges magasságot:

- **Szöveg és betűméret:** a hosszabb szöveg, expliciten megadott sortörések vagy nagyobb betűméret több függőleges helyet igényelhet.
- **Sortörés és oszlopszélesség:** sortöréssel a [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) használatával csökkentve az oszlopszélességet több sor keletkezhet. Szélesebb oszlop csökkentheti a függőleges helyigényt.
- **Cellamargók:** a [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) és a [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) függőleges helyet ad hozzá. A [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) és a [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) csökkenti a szövegnek rendelkezésre álló szélességet, és további sortörést okozhat.

Egy összevonás nélküli táblázat esetén az a cella, amelyik a legtöbb függőleges helyet igényli, meghatározza az egész sor tartalom által vezérelt alsó határát. A sor rövidebbé tételéhez esetleg a szöveget kell rövidíteni, a betűméretet vagy a margókat csökkenteni, vagy egy oszlopot szélesíteni kell.

Az alábbi képek ugyanazt a táblázatot mutatják azonos méretben. A szemléltetett eredményekben a tényleges magasságok 70, 100 és 55,2 pont volt: az utolsó sor magasabb maradt a 20 pontos minimumánál. A pontos szövegméretek változhatnak a környezetben elérhető betűtípusok szerint. Töltse le a mentett eredményeket: [increased minimum](row-height-increased.pptx) és [decreased minimum](row-height-decreased.pptx).

| Eredeti: minimum 70 pt, tényleges 70 pt | Növelt: minimum 100 pt, tényleges 100 pt | Csökkentett: minimum 20 pt, tényleges 55.2 pt |
| --- | --- | --- |
| ![Eredeti táblázat 70 pontos első sorral.](row-height-before.png) | ![Táblázat a első sor minimum 100 pontra növelése után.](row-height-increased.png) | ![Táblázat a első sor minimum 20 pontra csökkentése után; a sortöréses szöveg a sort a minimumnál magasabbra tartja.](row-height-decreased.png) |

## **Állítsa be az első sort fejlécként**

Használja a [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow) metódust az első sor fejléceként való megjelöléséhez. Megjelenése a táblára alkalmazott táblastílustól függ.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztállyal.  
2. Hozza el az első diát.  
3. Hozza el a dián az első alakzatként tárolt táblázatot.  
4. Engedélyezze a fejlécre formázást az első sorban.  
5. Mentse el a módosított prezentációt.

A példához `table.pptx` szükséges, amelyben a táblázat az első dián az első alakzat. Engedélyezi a fejlécre formázást az első sorban, és elmenti a `First_row_header.pptx` fájlt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klónozzon táblázat sort vagy oszlopot**

Klónozzon sorokat vagy oszlopokat a tartalmuk és formázásuk újrafelhasználásához. Másolatot fűzhet a táblázat végéhez, vagy beszúrhatja egy adott pozícióba.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztállyal.  
2. Hozza el az első diát.  
3. Definiálja az oszlopszélességeket és sormagasságokat.  
4. Adjon hozzá egy táblázatot a [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) metódussal.  
5. Klónozza a szükséges sorokat.  
6. Klónozza a szükséges oszlopokat.  
7. Mentse el a módosított prezentációt.

A példához `Test.pptx` szükséges, amelyen legalább egy dia van. Létrehoz egy táblázatot három oszloppal és öt sorral, a méreteket pontban megadva. Az első sort és oszlopot másolatként hozzáfűzi, majd a második sort és oszlopot a 3-as indexen (a negyedik pozíció) beszúrja. Az eredményül kapott táblázat hét sort és öt oszlopot tartalmaz. A `False` argumentum letiltja a klónozást a szomszédos összevont sorokra vagy oszlopokra; ez a táblázat nem tartalmaz összevont cellákat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
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

Távolítson el sorokat vagy oszlopokat, amelyek már nem szükségesek a táblázatban. Egy elem eltávolítása eltolja a mögötte következő sorok vagy oszlopok indexeit.

1. Hozzon létre egy prezentációt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztállyal.  
2. Hozza el az első diát.  
3. Definiálja az oszlopszélességeket és sormagasságokat.  
4. Adjon hozzá egy táblázatot a [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) metódussal.  
5. Távolítsa el a második sort és a második oszlopot.  
6. Mentse el a módosított prezentációt.

Ez a példa egy három‑háromas táblázatot hoz létre, és eltávolítja az 1‑es indexű sort és oszlopot, így egy kétszer‑két méretű táblázat marad a `TestTable_out.pptx` fájlban. A méretek pontban vannak megadva. A `False` argumentum letiltja a szomszédos összevont sorok vagy oszlopok eltávolítását; ez a táblázat nem tartalmaz összevont cellákat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Szövegformázás beállítása a táblázat sor szintjén**

Alkalmazzon szövegformázást egy teljes sorra, hogy a cellák egységesek legyenek. Beállíthat betűtulajdonságokat, bekezdésformázást és szövegirányt anélkül, hogy minden cellát egyenként formázna.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztállyal.  
2. Hozza el a táblázatot az első dián.  
3. Használja a [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) metódust az első sorra.  
4. Használja a [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) és a [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) metódusokat az első sorra.  
5. Használja a [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) metódust a második sorra.  
6. Mentse el a módosított prezentációt.

A példához `table.pptx` szükséges, amelyben a táblázat az első dián az első alakzat, és legalább két sor van. Az első sorra 25 pontos szöveget, jobb oldali igazítást és 20 pontos jobb bekezdésmargót alkalmaz, majd a második sorra függőleges szöveget állít be.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

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

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Szövegformázás beállítása a táblázat oszlop szintjén**

Alkalmazzon szövegformázást egy teljes oszlopra, hogy a cellák egységesek legyenek. Beállíthat betűtulajdonságokat, bekezdésformázást és szövegirányt anélkül, hogy minden cellát egyenként formázna.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztállyal.  
2. Hozza el a táblázatot az első dián.  
3. Használja a [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) metódust az első oszlopra.  
4. Használja a [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) és a [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) metódusokat az első oszlopra.  
5. Használja a [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) metódust a második oszlopra.  
6. Mentse el a módosított prezentációt.

A példához `table.pptx` szükséges, amelyben a táblázat az első dián az első alakzat, és legalább két oszlop van. Az első oszlopra 25 pontos szöveget, jobb oldali igazítást és 20 pontos jobb bekezdésmargót alkalmaz, majd a második oszlopra függőleges szöveget állít be.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

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

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Táblázat stílusjellemzőinek lekérése**

Használja a [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) metódust egy táblázatra alkalmazott előbeállított stílus lekéréséhez és egy másik táblázaton való újrafelhasználásához. Ez az előbeállítást azonosítja az egyedi cellaformázási felülírások helyett.

A példa létrehoz egy táblázatot, alkalmazza a [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1) előbeállítást, és visszaolvassa azt. Kiírja a `DarkStyle1`‑nek megfelelő egészértéket, majd elmenti a táblázatot a `table.pptx` fájlba.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/elrendezés/mester téma beállításait, és továbbra is felülírhatja a kitöltéseket, a szegélyeket és a szövegszíneket a téma felett.

**Rendezhetem a táblázat sorait, mint az Excelben?**

Nem, az Aspose.Slides táblázatok nem rendelkeznek beépített rendezéssel vagy szűrőkkel. Rendezze először az adatokat a memóriában, majd töltse újra a táblázat sorait ebben a sorrendben.

**Lehet színezett (csíkos) oszlopaim, miközben egyes cellákra egyedi színeket tartok?**

Igen. Kapcsolja be a csíkos oszlopokat, majd felülírja a konkrét cellákat helyi formázással; a cellaszintű formázás felülbírálja a táblastílust.