---
title: "Prezentációs táblázatok kezelése Pythonban"
linktitle: "Táblázat kezelése"
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
- táblázat stílus
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Táblázatok létrehozása és szerkesztése PowerPoint és OpenDocument diákban az Aspose.Slides for Python via .NET segítségével. Fedezzen fel egyszerű kódrészleteket, amelyek egyszerűsítik a táblázat munkafolyamatait."
---
## **Bevezetés**

A PowerPointban a táblázat hatékony módja az információ bemutatásának. Az információ, amely cellák (sorok és oszlopok) rácsában van elrendezve, egyértelmű és könnyen érthető.

Az Aspose.Slides a [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) osztályt, a [Cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/) osztályt és egyéb kapcsolódó típusokat biztosít, amelyek segítenek táblázatokat létrehozni, frissíteni és kezelni bármely prezentációban.

## **Táblázatok létrehozása a nulláról**

Ez a szakasz bemutatja, hogyan lehet egy táblázatot a semmiből létrehozni az Aspose.Slides-ben egy táblázat alakzat hozzáadásával egy diára, a sorok és oszlopok meghatározásával, valamint a pontos méretek beállításával. Emellett látni fogja, hogyan lehet cellákat szöveggel feltölteni, igazítást és szegélyeket módosítani, valamint a táblázat megjelenését testreszabni.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen egy hivatkozást egy diára a sorszám alapján.
3. Határozzon meg egy oszlopszélesség tömböt.
4. Határozzon meg egy sormagasság tömböt.
5. Adjon hozzá egy [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) elemet a diához.
6. Iteráljon minden egyes [Cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/) elemen, és formázza a felső, alsó, jobb és bal szegélyeit.
7. Egyesítse a táblázat első sorának első két celláját.
8. Érje el egy [Cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/) [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét.
9. Adjon szöveget a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemhez.
10. Mentse a módosított prezentációt.

A következő Python példa bemutatja, hogyan hozható létre egy táblázat egy prezentációban:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

    # A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
    with slides.Presentation() as presentation:
        # Az első dia elérése.
        slide = presentation.slides[0]

        # Oszlopszélességek és sormagasságok definiálása.
        column_widths = [50, 50, 50]
        row_heights = [50, 30, 30, 30, 30]

        # Egy táblázat alakzat hozzáadása a diához.
        table = slide.shapes.add_table(100, 50, column_widths, row_heights)

        # A cella szegélyformázás beállítása minden cellához.
        for row in table.rows:
            for cell in row:
                cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
                cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
                cell.cell_format.border_top.width = 5

                cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
                cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
                cell.cell_format.border_bottom.width = 5

                cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
                cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
                cell.cell_format.border_left.width = 5

                cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
                cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
                cell.cell_format.border_right.width = 5
        
        # Cellák egyesítése (0. sor, 0. oszlop) és (1. sor, 1. oszlop) között.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        # Szöveg hozzáadása az egyesített cellához.
        table.rows[0][0].text_frame.text = "Merged Cells"

        # Prezentáció mentése a lemezre.
        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Számozás a szabványos táblázatokban**

Egy szabványos táblázatban a cellák számozása egyértelmű és nullától kezdődik. A táblázat első celláját (0, 0) indexezi (oszlop 0, sor 0).

Például egy 4 oszlopos és 4 soros táblázatban a cellákat a következőképpen számozzák:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

A következő Python példa bemutatja, hogyan hivatkozhat a cellákra ezzel a nullától induló számozással:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Meglévő táblázat elérése**

Ez a szakasz elmagyarázza, hogyan lehet megtalálni és dolgozni egy meglévő táblázattal egy prezentációban az Aspose.Slides használatával. Megtanulja, hogyan találja meg a táblázatot egy dián, hogyan érje el a sorait, oszlopait és celláit, valamint hogyan frissítse a tartalmat vagy a formázást.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen egy hivatkozást arra a diára, amely a táblázatot tartalmazza, a sorszám alapján.
3. Iteráljon az összes [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) objektumon, amíg meg nem találja a táblázatot.
4. Használja a [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) objektumot a táblázattal való munkához.
5. Mentse a módosított prezentációt.

{{% alert color="info" %}}
Ha a dián több táblázat is van, jobb, ha a szükséges táblázatot az `alternative_text` tulajdonsága alapján keresi.
{{% /alert %}}

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Példányosítsa a Presentation osztályt PPTX fájl betöltéséhez.
with slides.Presentation("sample.pptx") as presentation:
    # Az első dia elérése.
    slide = presentation.slides[0]

    table = None

    # Iteráljon a formákon, és hivatkozzon az első megtalált táblázatra.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Állítsa be az első sor első cellájának szövegét.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Mentse a módosított prezentációt lemezre.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg igazítása a táblázatokban**

Ez a szakasz bemutatja, hogyan lehet a szöveg igazítását a táblázat celláiban az Aspose.Slides segítségével szabályozni. Megtanulja beállítani a cellák vízszintes és függőleges igazítását, hogy a tartalma világos és egységes maradjon.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen egy hivatkozást egy diára a sorszám alapján.
3. Adjon hozzá egy [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) objektumot a diához.
4. Érjen el egy [Cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/) objektumot a táblázatból.
5. Igazítsa a szöveget függőlegesen.
6. Mentse a módosított prezentációt.

A következő Python példa bemutatja, hogyan igazítható a szöveg egy táblázatban:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Hozzon létre egy példányt a Presentation osztályból.
with slides.Presentation() as presentation:
    # Az első dia elérése.
    slide = presentation.slides[0]

    # Oszlopszélességek és sormagasságok definiálása.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Táblázat alakzat hozzáadása a diához.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # A szöveg központosítása és a függőleges tájolás beállítása.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Prezentáció mentése a lemezre.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Szövegformázás beállítása táblázatszinten**

Ez a szakasz bemutatja, hogyan alkalmazható szövegformázás táblázatszinten az Aspose.Slides-ben, hogy minden cella egységes, összhangban lévő stílust örököljön. Megtanulja globálisan beállítani a betűméreteket, igazításokat és margókat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzen egy hivatkozást egy diára a sorszám alapján.
3. Adjon hozzá egy [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) elemet a diához.
4. Állítsa be a szöveg betűméretét (betűmagasságot).
5. Állítsa be a bekezdés igazítását és margóit.
6. Állítsa be a függőleges szöveg irányát.
7. Mentse a módosított prezentációt.

A következő Python példa bemutatja, hogyan alkalmazhatja a kívánt formázási beállításokat a táblázat szövegére:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Létrehoz egy példányt a Presentation osztályból
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Beállítja a betűméretet az összes táblázat cellához.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Beállítja a jobbra igazított szöveget és a jobb margót az összes táblázat cellához.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Beállítja a függőleges szöveg tájolását az összes táblázat cellához.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Beépített táblázatstílusok alkalmazása**

Az Aspose.Slides lehetővé teszi a táblázatok formázását előre definiált stílusok használatával közvetlenül a kódban. A példa bemutatja egy táblázat létrehozását, egy beépített stílus alkalmazását és az eredmény mentését – hatékony mód a következetes, professzionális formázás biztosításához.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **A táblázatok képarányának zárolása**

Az alakzat képaránya a méretei aránya. Az Aspose.Slides biztosítja az `aspect_ratio_locked` tulajdonságot, amely lehetővé teszi a képarány zárolását táblázatok és egyéb alakzatok esetén.

A következő Python példa bemutatja, hogyan lehet a táblázat képarányát zárolni:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt egy egész táblázatra és a celláiban lévő szövegre?**

Igen. A táblázat rendelkezik egy [right_to_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/right_to_left/) tulajdonsággal, és a bekezdéseknek is van egy [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/right_to_left/) tulajdonsága. Mindkettő használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók áthelyezhessék vagy átméretezhessék a táblázatot a végleges fájlban?**

Használja a [shape locks](/slides/hu/python-net/applying-protection-to-presentation/) funkciót a mozgatás, átméretezés, kijelölés stb. letiltásához. Ezek a zárolások a táblázatokra is vonatkoznak.

**Támogatott-e egy kép beillesztése a cella háttérként?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/) kitöltést egy cellához; a kép a kiválasztott mód szerint (nyújtás vagy csempe) lefedi a cella területét.