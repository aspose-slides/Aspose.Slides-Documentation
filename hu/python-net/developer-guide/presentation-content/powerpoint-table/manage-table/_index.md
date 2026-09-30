---
title: Prezentációs táblázatok kezelése Pythonban
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/python-net/manage-table/
keywords:
- táblázat hozzáadása
- táblázat létrehozása
- táblázat elérése
- képarány
- szöveg igazítása
- szövegformázás
- táblázat stílusa
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Hozzon létre és szerkesszen táblázatokat PowerPoint és OpenDocument diákként az Aspose.Slides for Python segítségével .NET-en keresztül. Fedezzen fel egyszerű kódrészleteket, amelyek leegyszerűsítik a táblázatkezelési folyamatokat."
---
## **Bevezetés**

A PowerPoint táblázatai sorokba és oszlopokba szervezik az információkat, megkönnyítve ezzel az olvasást és az értékek összehasonlítását.

Az Aspose.Slides a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) és [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) osztályokat valamint egyéb típusokat biztosít, amelyekkel táblázatokat hozhat létre, frissíthet és kezelhet a prezentációkban.

## **Táblázat létrehozása nulláról**

Hozzon létre egy táblázatot a pozíciójának, az oszlopszélességeknek és a sormagasságoknak a megadásával. A diára való felhelyezés után formázhatja a cellahatárokat, egyesítheti a cellákat, és szöveget illeszthet be.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát a diára annak indexe alapján.
3. Határozzon meg egy pontban megadott oszlopszélességek listáját.
4. Határozzon meg egy pontban megadott sormagasságok listáját.
5. Adjon a diához egy [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) objektumot az [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) metódus segítségével.
6. Iteráljon végig minden [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) objektumon, hogy alkalmazza a formázást a felső, alsó, jobb és bal határokra.
7. Egyesítse a táblázat első sorának első két celláját.
8. A merge‑elt cellához a [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) tulajdonságon keresztül férhet hozzá.
9. Állítsa be a szöveget a merge‑elt cellában.
10. Mentse el a módosított prezentációt.

Az alábbi példa egy három oszlopos és öt soros táblázatot hoz létre a (100, 50) pontban. Piros határokat alkalmaz 5 pont szélességgel, egyesíti az első sor első két celláját, és a végeredményt `table.pptx`‑ként menti.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cellaindexek nulláról indulnak és (oszlop, sor) sorrendet használnak. Az első cella indexe (0, 0). Pythonban a cellához a `table.rows[row_index][column_index]` szintaxissal férhet hozzá; ebben a kifejezésben a sorindex jön először.

Például a 4 oszlopból és 4 sorból álló táblázat cellái a következőképpen vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a példa létrehozza a fent ábrázolt 4 × 4-es táblázatot, 70 pontos oszlopszélességekkel és sormagasságokkal, valamint 5 pont szélességű piros cellahatárokkal. A koordináták a cellaindexeket szemléltetik; a példa üresen hagyja a cellákat, és a táblázatot `StandardTables_out.pptx`‑ként menti.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Meglévő táblázat elérése**

A táblázatok a diák alakzatgyűjteményében tárolódnak. Iteráljon végig az alakzatokon a táblázat megtalálásához, majd a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) osztály segítségével olvassa vagy frissítse annak celláit.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztály segítségével.
2. Szerezzen referenciát az adott indexű diára, amely a táblázatot tartalmazza.
3. Iteráljon végig a [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) objektumokon, és álljon le, amikor táblázatot talál. Ha a dián több táblázat is van, használja az [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) tulajdonságot a szükséges azonosításához.
4. Frissítse a célcellában lévő szöveget.
5. Mentse el a módosított prezentációt.

Az alábbi példa megnyitja a `UpdateExistingTable.pptx` fájlt, és megtalálja az első táblázatot az első dián. A 0. oszlop, 1. sor celláját `New`‑re állítja, majd a végeredményt `table1_out.pptx`‑ként menti. A bemenetnek legalább egy diát kell tartalmaznia, és azon a dián az első táblázatnak legalább egy oszloppal és két sorral kell rendelkeznie.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

A meglévő táblázat egy sorának átméretezéséhez és annak megértéséhez, hogy miért haladhatja meg a tényleges magasság a kért minimumot, lásd a [Sor magasságának vezérlése](/slides/hu/python-net/manage-rows-and-columns/#control-row-height).

## **Az a cella megtalálása, amelyik a szövegkeretet birtokolja**

Amikor általános szövegfeldolgozó kód egy [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) objektumot kap egy táblázatból, akkor a [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) tulajdonságot használja a tulajdonos [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) lekéréséhez. Egy táblázatcellából származó szövegkeret esetén a [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) be van állítva, míg a [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) értéke `None`, még akkor is, ha maga a táblázat egy alakzat.

A cella koordinátái a csak olvasható [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) és [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) tulajdonságokon keresztül érhetők el. A [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) is csak olvasható: navigációt biztosít a tulajdonos felé, de nem módosítja a tulajdonjogot. Mindig ellenőrizze, hogy a visszaadott cella nem `None`‑e, mielőtt használja.

Egy teljes példáért, amely azonosítja a táblázat‑cellákat és alakzat‑tulajdonosokat, beleértve a SmartArt‑csomópontokhoz tartozó alakzatokat, lásd a [Szöveg keresése és cseréje](/slides/hu/python-net/search-and-replace-text/).

## **Szöveg igazítása táblázatban**

Az egyes táblázatcellák függőleges rögzítését és szövegirányát szabályozhatja. Az ebben a szakaszban szereplő példa a szöveget a első cellában középre helyezi, és 270 fokkal elforgatja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát a diára annak indexe alapján.
3. Adj egy [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) objektumot a diára.
4. Szerezzen hozzáférést egy [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) objektumhoz a táblázatból.
5. Szerezze meg az első [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) objektumot, és állítsa be a szövegét és színét.
6. Állítsa be a cella [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) és [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) értékeit.
7. Mentse el a módosított prezentációt.

Ez a példa egy 4 × 4-es táblázatot hoz létre, 120 pontos oszlopszélességekkel és 100 pontos sormagasságokkal. Formázza a (0, 0) cellában lévő szöveget, értékeket ad a első sor többi cellájához, és a végeredményt `Vertical_Align_Text_out.pptx`‑ként menti.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Szövegformázás beállítása a táblázat szintjén**

Használja a [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) metódust, hogy szövegformázást alkalmazzon a táblázat összes cellájára. A túlterhelései tartomány-, bekezdés- és szövegkeret-formázást is elfogadják, így ezeket a tulajdonságokat anélkül állíthatja be, hogy egyes cellákon iterálna.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztály segítségével.
2. Szerezzen referenciát a diára annak indexe alapján.
3. Szerezzen hozzáférést egy [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) objektumhoz a diáról.
4. Állítsa be a [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) értéket a szöveghez.
5. Állítsa be az [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) és a [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) értékeket.
6. Állítsa be a [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) értékét.
7. Mentse el a módosított prezentációt.

Az alábbi példa megnyitja a `table.pptx` fájlt, amelynek legalább egy diát kell tartalmaznia, és azon a dián a táblázatnak az első alakzatnak kell lennie. A betűméretet 25 pontra állítja, a bekezdéseket jobbra igazítja 20 pont jobb margóval, és a szöveget függőlegessé teszi. A formázott prezentációt `result.pptx`‑ként menti.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Táblázat stílus tulajdonságainak lekérése**

Használja a [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) metódust egy táblázat előre beállított stílusának olvasásához vagy hozzárendeléséhez. Ez a példa a [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) értéket alkalmaz egy táblázatra, kiírja az előre beállított nevét, majd ugyanazt a beállítást a második táblázatra is alkalmazza. Mindkét táblázat a `table-style.pptx`‑ben lesz mentve.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Táblázat méretarányának zárolása**

A táblázat képaránya a szélességének és magasságának arányát jelenti. Használja az [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) tulajdonságot a képarány zárolásához egy táblázatnál.

Ez a példa megnyitja a `pres.pptx` fájlt, amelynek legalább egy diát kell tartalmaznia, és azon a dián a táblázatnak az első alakzatnak kell lennie. Kiírja a jelenlegi zárolási állapotot, engedélyezi a képarány zárolását, majd kiírja a frissített állapotot (`True`), és a végeredményt `pres-out.pptx`‑ként menti.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt az egész táblázat és a celláiban lévő szöveg számára?**

Igen. A táblázat rendelkezik egy [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) tulajdonsággal, a bekezdések pedig a [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/) tulajdonsággal. Mindkettő használata biztosítja a helyes RTL sorrendet és a cellákon belüli megjelenítést.

**Hogyan akadályozhatom meg, hogy a felhasználók mozgassák vagy átméretezzék a táblázatot a végleges fájlban?**

Használja a [shape locks](/slides/hu/python-net/applying-protection-to-presentation/) funkciót a mozgás, átméretezés, kijelölés stb. letiltásához. Ezek a zárolások a táblázatokra is érvényesek.

**Támogatott-e egy kép beillesztése egy cellába háttérként?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) formátumot a cellához; a kép a kiválasztott mód (nyújtás vagy csempézés) szerint lefedi a cellaterületet.