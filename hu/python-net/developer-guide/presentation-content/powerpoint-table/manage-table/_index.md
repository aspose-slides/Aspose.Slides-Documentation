---
title: Prezentációs táblák kezelése Pythonban
linktitle: Tábla kezelése
type: docs
weight: 10
url: /hu/python-net/manage-table/
keywords:
- tábla hozzáadása
- tábla létrehozása
- tábla elérése
- képarány
- szöveg igazítása
- szövegformázás
- tábla stílus
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Hozzon létre és szerkesszen táblákat PowerPoint és OpenDocument diákon az Aspose.Slides for Python .NET használatával. Fedezzen fel egyszerű kódrészleteket, hogy optimalizálja a tábla munkafolyamatait."
---
## **Bevezetés**

A táblázat a PowerPointban hatékony módja az információk bemutatásának. A cellák (sorok és oszlopok) rácsában elrendezett adatok egyértelműek és könnyen érthetőek.

Az Aspose.Slides a [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) osztályt, a [Cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/) osztályt és további kapcsolódó típusokat biztosít, amelyek segítenek táblák létrehozásában, frissítésében és kezelésében bármely prezentációban.

## **Táblák létrehozása a semmiből**

Ez a szakasz bemutatja, hogyan hozhatunk létre táblát a semmiből az Aspose.Slides segítségével úgy, hogy táblázat alakzatot adunk a diára, meghatározzuk a sorok és oszlopok számát, valamint a pontos méreteket. Megmutatjuk, hogyan töltsük fel a cellákat szöveggel, hogyan állítsuk be a igazítást és a szegélyeket, valamint hogyan testre szabjuk a tábla megjelenését.

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzünk hivatkozást egy diára a indexe alapján.
3. Definiáljunk egy oszlopszélesség‑tömböt.
4. Definiáljunk egy sormagasság‑tömböt.
5. Adjunk egy [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) objektumot a diához.
6. Iteráljunk végig minden egyes [Cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/) elemen, és formázzuk a felső, alsó, jobb és bal szegélyét.
7. Egyesítsük az első két sor és az első két oszlop celláit egyetlen cellává.
8. Érjük el a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)‑et egy [Cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/)‑ben.
9. Adjunk szöveget a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)‑hez.
10. Mentsük el a módosított prezentációt.

Az alábbi Python példa bemutatja, hogyan hozhatunk létre egy táblát egy prezentációban:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:
    # Nyissa meg az első diát.
    slide = presentation.slides[0]

    # Határozza meg az oszlopszélességeket és a sormagasságokat.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Adjon hozzá egy táblázat alakzatot a diához.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Állítsa be az egyes cellák szegélyformátumát.
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
        
    # Egyesítse a cellákat (0. sor, 0. oszlop) és (1. sor, 1. oszlop) között.
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Adjon szöveget az egyesített cellához.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Mentse a prezentációt a lemezre.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Számozás szabványos táblákban**

Egy szabványos táblában a cellák számozása egyszerű és nulla‑alapú. Az első cella a (0, 0) indexszel rendelkezik (oszlop 0, sor 0).

Például egy 4 oszlopos és 4 soros táblában a cellák a következőképpen számozottak:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Az alábbi Python példa bemutatja, hogyan hivatkozhatunk cellákra ezzel a nulla‑alapú számozással:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Nyissa meg az első diát.
    slide = presentation.slides[0]

    # Adjon hozzá egy táblázatot 4 oszloppal és 4 sorral.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Létező tábla elérése**

Ez a szakasz elmagyarázza, hogyan keressünk és dolgozzunk egy már létező táblával a prezentációban az Aspose.Slides segítségével. Megtanulja, hogyan találja meg a táblát a dián, hogyan érje el a sorait, oszlopait és celláit, valamint hogyan frissítse a tartalmat vagy a formázást.

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzünk hivatkozást a táblát tartalmazó diára a indexe alapján.
3. Iteráljunk végig az összes [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) objektumon, amíg meg nem találjuk a táblát.
4. Használjuk a [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) objektumot a tábla kezeléséhez.
5. Mentsük el a módosított prezentációt.

{{% alert color="info" title="Note" %}}

Ha a dia több táblát tartalmaz, érdemes a keresett táblát a `alternative_text` tulajdonsága alapján megtalálni.

{{% /alert %}}

Az alábbi Python példa bemutatja, hogyan érhetjük el és dolgozhatunk egy már létező táblával:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Példányosítsa a Presentation osztályt egy PPTX fájl betöltéséhez.
with slides.Presentation("sample.pptx") as presentation:
    # Nyissa meg az első diát.
    slide = presentation.slides[0]

    table = None

    # Iteráljon végig az alakzatokon, és hivatkozzon az első megtalált táblára.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Állítsa be az első sor első cellájának szövegét.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Mentse el a módosított prezentációt a lemezre.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **A szövegkeretet tartalmazó cella megtalálása**

Amikor egy általános szöveggelisztoló kód egy [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumot kap egy táblából, használja a [TextFrame.parent_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_cell/) tulajdonságot a tulajdonos [Cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/) lekéréséhez. Egy táblacellához tartozó szövegkeret esetén a [TextFrame.parent_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_cell/) be van állítva, míg a [TextFrame.parent_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_shape/) `None`, bár maga a tábla alakzatként jelenik meg.

A cella koordinátái a csak‑olvasásra szánt [Cell.first_column_index](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/first_column_index/) és [Cell.first_row_index](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/first_row_index/) tulajdonságokban érhetők el. A [TextFrame.parent_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_cell/) szintén csak‑olvasású: navigációt biztosít a tulajdonos felé, de nem módosítja a tulajdonjogot. Mindig ellenőrizze, hogy a visszaadott cella nem `None`‑e, mielőtt használná.

A teljes példáért, amely azonosítja a táblacellát és a forma tulajdonosát, beleértve a SmartArt‑csomópontokhoz kapcsolódó alakzatokat, lásd a [Search and Replace Text](/slides/hu/python-net/search-and-replace-text/) oldalt.

## **Szöveg igazítása a táblákban**

Ez a szakasz bemutatja, hogyan szabályozhatjuk a szöveg elhelyezkedését a táblacellákban az Aspose.Slides segítségével. Megtanulja, hogyan rögzítse a szöveget függőlegesen egy cellában, és hogyan változtassa meg a szöveg írásirányát.

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzünk hivatkozást a diára a indexe alapján.
3. Adjunk egy [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) objektumot a diához.
4. Szerezzünk egy [Cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/) objektumot a táblából.
5. Igazítsuk középre a szöveget függőlegesen a cellában, és állítsuk be a szöveg írásirányát.
6. Mentsük el a módosított prezentációt.

Az alábbi Python példa bemutatja, hogyan igazítható a szöveg egy táblában:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Hozzon létre egy példányt a Presentation osztályból.
with slides.Presentation() as presentation:
    # Nyissa meg az első diát.
    slide = presentation.slides[0]

    # Határozza meg az oszlopszélességeket és a sormagasságokat.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Adjon hozzá egy táblázat alakzatot a diához.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Igazítsa középre a szöveget, és állítsa be a függőleges irányt.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Mentse el a prezentációt a lemezre.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Szövegformázás beállítása táblaszinten**

Ez a szakasz azt mutatja be, hogyan alkalmazhatunk szövegformázást a tábla szintjén az Aspose.Slides‑ben, hogy minden cella egységes, következetes stílust örököljön. Megtanulja, hogyan állítsuk be a betűméretet, az igazítást és a margókat globálisan.

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezzünk hivatkozást a diára a indexe alapján.
3. Adjunk egy [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) objektumot a diához.
4. Állítsuk be a betűméretet (betűmagasságot) a szöveghez.
5. Állítsuk be a bekezdés igazítását és a margókat.
6. Állítsuk be a függőleges szövegorientációt.
7. Mentsük el a módosított prezentációt.

Az alábbi Python példa bemutatja, hogyan alkalmazhatja a kívánt formázási beállításokat egy táblázat szövegére:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Létrehoz egy példányt a Presentation osztályból
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Állítsa be a betűméretet az összes táblacellában.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Állítsa be a jobbra igazított szöveget és a jobb margót az összes táblacellában.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Állítsa be a függőleges szövegorientációt az összes táblacellában.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Beépített táblastílusok alkalmazása**

Az Aspose.Slides lehetővé teszi, hogy a táblákat előre definiált stílusokkal formázzuk közvetlenül a kódban. A példa bemutatja egy tábla létrehozását, egy beépített stílus alkalmazását, majd az eredmény mentését – ez egy hatékony módja a konzisztens, professzionális formázás biztosításának.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Táblák képarányának zárolása**

A forma képaránya a méretei arányát jelenti. Az Aspose.Slides biztosítja az `aspect_ratio_locked` tulajdonságot, amellyel zárolható a képarány táblák és egyéb alakzatok esetén.

Az alábbi Python példa bemutatja, hogyan zárolható a képarány egy táblán:

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

**Engedélyezhetem a jobb‑balra (RTL) olvasási irányt egy teljes táblán és a celláinak szövegén?**

Igen. A tábla rendelkezik egy [right_to_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/right_to_left/) tulajdonsággal, és a bekezdéseknek is van egy [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/right_to_left/) beállítása. Mindkettő használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók mozgatni vagy átméretezni tudják a táblát a végleges fájlban?**

Használja a [shape locks](/slides/hu/python-net/applying-protection-to-presentation/) funkciót a mozgatás, átméretezés, kiválasztás stb. letiltásához. Ezek a zárak a táblákra is érvényesek.

**Támogatott-e egy kép beillesztése a cellába háttérként?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/) formátumot a cellához; a kép a cellaterületet a választott mód szerint (nyújtás vagy ismétlés) lefedi.