---
title: PowerPoint táblázatok sorainak és oszlopainak kezelése Python segítségével
linktitle: Sorok és oszlopok
type: docs
weight: 20
url: /hu/python-net/manage-rows-and-columns/
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
description: "Kezeletet a táblázat sorait és oszlopait PowerPointban az Aspose.Slides for Python via .NET segítségével, és gyorsítsa fel a prezentáció szerkesztését és az adatok frissítését."
---
## **Bevezetés**

Az Aspose.Slides for Python via .NET lehetővé teszi, hogy a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) osztályon keresztül kezelje a táblázat szerkezetét és formázását a PowerPoint‑prezentációkban. Kijelölhet egy fejlécsort, klónozhat vagy eltávolíthat sorokat és oszlopokat, valamint szövegformázást alkalmazhat egy teljes sorra vagy oszlopra.

Ez a cikk bemutatja ezeket a műveleteket Python‑példákkal. Ezen felül megmutatja, hogyan lehet lekérni egy táblázat stílus‑presetjét, hogy újra felhasználhassa azt. A táblázatsor‑ és oszlopszámok nullától kezdődnek.

## **Sor magasságának szabályozása**

Használja a [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) tulajdonságot egy sor minimális magasságának beállításához pontban. Ez egy alsó határ, nem rögzített magasság. A [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) a tényleges magasságot adja vissza, és csak olvasható. A sorhoz a [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/) segítségével férhet hozzá.

A példa betölti a [row-height-input.pptx](row-height-input.pptx) fájlt, amelyben az első dián az első alakzat egy táblázat. Az első sor 70 pontnál kezdődik. A cellák 18 pontos Arial szöveget, sortörést és 6 pontos felső és alsó margót használnak; a második oszlopban a hosszabb szöveg több sorra törik. A példa a minimális értéket 100 pontra növeli, majd 20 pontra csökkenti, minden változtatás után kiírja a tényleges magasságot, és elmenti mindkét eredményt.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

A mellékelt prezentációval a minimum növelése helyet ad a sornak. A csökkentés eltávolítja ezt a plusz helyet, de a tényleges magasság továbbra is nagyobb lesz, mint 20 pont, mivel a szöveg és a cellamargók több helyet igényelnek. A minimum magának csökkentése önmagában nem kényszerítheti a sort a tartalom által igényelt hely alá.

A tényleges magasságot több tényező befolyásolja:

- **Szöveg és betűméret:** hosszabb szöveg, explicite sortörések vagy nagyobb betűméret több függőleges helyet igényelhet.
- **Sortörés és oszlopszélesség:** sortörés engedélyezése esetén egy keskenyebb [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) több sort eredményezhet. Egy szélesebb oszlop csökkentheti a függőleges helyigényt.
- **Cellamargók:** a [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) és a [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) függőleges helyet ad. A [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) és a [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) pedig csökkenti a szöveg számára rendelkezésre álló szélességet, és további sortörést okozhat.

Ezen az egyesített cellákat nem tartalmazó táblázatnál a legmagasabb függőleges helyet igénylő cella határozza meg a sor alsó, tartalom‑vezérelt limitjét. A sor lerövidítéséhez gyakran szükséges a szöveget lerövidíteni, csökkenteni a betűméretet vagy a margókat, vagy egy oszlopot szélesíteni.

Az alábbi képek ugyanazt a táblázatot mutatják azonos méretben. Ebben a futtatásban a tényleges magasságok 70, 100 és 55,2 pont voltak: az utolsó sor továbbra is magasabb maradt, mint a 20‑pontos minimum. A pontos szövegmérések változhatnak a környezetben elérhető betűkészletektől függően. Töltse le a mentett eredményeket: [increased minimum](row-height-increased.pptx) és [decreased minimum](row-height-decreased.pptx).

| Eredeti: minimum 70 pt, tényleges 70 pt | Növelt: minimum 100 pt, tényleges 100 pt | Csökkentett: minimum 20 pt, tényleges 55.2 pt |
| --- | --- | --- |
| ![Eredeti táblázat 70 pontos első sorral.](row-height-before.png) | ![Táblázat a első sor minimum 100 pontra növelése után.](row-height-increased.png) | ![Táblázat a első sor minimum 20 pontra csökkentése után; a sortörés a sor magasságát a minimum fölött tartja.](row-height-decreased.png) |

## **Az első sor beállítása fejlécnek**

Használja a [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) tulajdonságot az első sor fejlécformázásához. Megjelenése a táblázatra alkalmazott táblázat‑stílustól függ.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztállyal.
2. Hozza el az első diát.
3. Szerezze meg a dián az első alakzatként tárolt táblázatot.
4. Engedélyezze a fejlécformázást az első sorra.
5. Mentse el a módosított prezentációt.

A példa a `table.pptx` fájlt igényli, amelyben az első dián az első alakzat egy táblázat. Engedélyezi az első sor fejlécformázását, majd elmenti a `First_row_header.pptx` fájlt.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Táblázatsor vagy -oszlop klónozása**

Klónozza a sorokat vagy oszlopokat, hogy újra felhasználja azok tartalmát és formázását. A másolatot hozzáfűzheti a táblázat végéhez, vagy egy adott pozícióba beillesztheti.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztállyal.
2. Hozza el az első diát.
3. Definiálja az oszlopszélességeket és sormagasságokat.
4. Adjon hozzá egy táblázatot a [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) metódussal.
5. Klónozza a szükséges sorokat.
6. Klónozza a szükséges oszlopokat.
7. Mentse el a módosított prezentációt.

A példa a `Test.pptx` fájlt igényli, amely legalább egy diát tartalmaz. Létrehoz egy három oszlopos és öt soros táblázatot, a méreteket pontban adja meg. Az első sort és oszlopot hozzáfűzi, majd a második sort és oszlopot a 3‑as indexnél (a negyedik pozíció) beszúrja. Az eredmény egy hét soros és öt oszlopos táblázat. A `False` argumentum letiltja a klónozást a szomszédos egyesített sorokba vagy oszlopokba; ez a táblázat nem tartalmaz egyesített cellákat.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sor vagy oszlop eltávolítása a táblázatból**

Távolítsa el a már nem szükséges sorokat vagy oszlopokat. Egy elem eltávolítása eltolja az azt követő sorok vagy oszlopok indexeit.

1. Hozzon létre egy prezentációt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztállyal.
2. Hozza el az első diát.
3. Definiálja az oszlopszélességeket és sormagasságokat.
4. Adjon hozzá egy táblázatot a [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) metódussal.
5. Távolítsa el a második sort és a második oszlopot.
6. Mentse el a módosított prezentációt.

Ez a példa egy három‑háromas táblázatot hoz létre, majd az 1‑es indexű sort és oszlopot eltávolítja, így egy két‑két-es táblázat marad a `TestTable_out.pptx` fájlban. A méretek pontokban vannak megadva. A `False` argumentum letiltja a szomszédos egyesített sorok vagy oszlopok eltávolítását; ez a táblázat nem tartalmaz egyesített cellákat.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Szövegformázás beállítása a táblázatsor szintjén**

Alkalmazzon szövegformázást egy egész sorra, hogy a cellák konzisztens megjelenést kapjanak. Beállíthat betűtulajdonságokat, bekezdésformázást és szöve irányát anélkül, hogy minden egyes cellát külön kellene formázni.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztállyal.
2. Hozza el a táblázatot az első dián.
3. Állítsa be a [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) értékét az első sorra.
4. Állítsa be az [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) és a [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) értékét az első sorra.
5. Állítsa be a [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) értékét a második sorra.
6. Mentse el a módosított prezentációt.

A példa a `table.pptx` fájlt igényli, amelyben az első dián az első alakzat egy táblázat, és legalább két sor található benne. 25 pontos szöveget, jobbra igazítást és 20 pontos jobb bekezdésmargót alkalmaz az első sorra, majd a második sorra függőleges szöveget állít be.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Szövegformázás beállítása a táblázatoszlop szintjén**

Alkalmazzon szövegformázást egy egész oszlopra, hogy a cellák konzisztens megjelenést kapjanak. Beállíthat betűtulajdonságokat, bekezdésformázást és szöve irányát anélkül, hogy minden egyes cellát külön kellene formázni.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztállyal.
2. Hozza el a táblázatot az első dián.
3. Állítsa be a [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) értékét az első oszlopra.
4. Állítsa be az [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) és a [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) értékét az első oszlopra.
5. Állítsa be a [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) értékét a második oszlopra.
6. Mentse el a módosított prezentációt.

A példa a `table.pptx` fájlt igényli, amelyben az első dián az első alakzat egy táblázat, és legalább két oszlop szerepel benne. 25 pontos szöveget, jobbra igazítást és 20 pontos jobb bekezdésmargót alkalmaz az első oszlopra, majd a második oszlopra függőleges szöveget állít be.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Táblázat‑stílus tulajdonságainak lekérése**

Használja a [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) tulajdonságot egy táblázatra alkalmazott preset lekérdezéséhez, hogy azt egy másik táblázaton is felhasználhassa. Ez a presetet azonosítja, nem pedig az egyedi cellaformázási felülbírálásokat.

A példa létrehoz egy táblázatot, alkalmazza a [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) presetet, majd visszaolvassa azt. Kiírja a `True` értéket, ha a visszakapott preset megegyezik a beállítottal, és menti a táblázatot a `table.pptx` fájlba.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Alkalmazhatok PowerPoint‑témákat/stílusokat egy már létező táblázatra?**

Igen. A táblázat örökli a dia/kiosztás/mester téma beállításait, és továbbra is felülírhatja a kitöltéseket, szegélyeket és szövegszíneket a téma felett.

**Rendezhetem a táblázatsorokat úgy, mint Excelben?**

Nem, az Aspose.Slides táblázatoknak nincs beépített rendezési vagy szűrési funkciója. Rendezze először az adatokat a memóriában, majd töltse fel a táblázatsorokat a kívánt sorrendben.

**Lehet csíkos (striped) oszlopokat használni, miközben egyes cellákhoz egyedi színeket tartok meg?**

Igen. Kapcsolja be a csíkos oszlopokat, majd helyi formázással felülírja a kívánt cellákat; a cellaszintű formázás elsőbbséget élvez a táblázat‑stílussal szemben.