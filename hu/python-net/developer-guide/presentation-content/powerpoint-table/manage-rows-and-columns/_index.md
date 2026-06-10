---
title: Sorok és oszlopok kezelése PowerPoint táblákban Python használatával
linktitle: Sorok és oszlopok
type: docs
weight: 20
url: /hu/python-net/manage-rows-and-columns/
keywords:
- táblasor
- táblazatoszlop
- első sor
- tábla fejléce
- sor klónozása
- oszlop klónozása
- sor másolása
- oszlop másolása
- sor eltávolítása
- oszlop eltávolítása
- sor szövegformázása
- oszlop szövegformázása
- tábla stílus
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Táblák sorainak és oszlopainak kezelése PowerPointban és OpenDocumentben az Aspose.Slides for Python (.NET) segítségével, a prezentációk szerkesztésének és adatfrissítéseknek a felgyorsítása érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a táblázatsorok és -oszlopok PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python használatával. Megtanulja, hogyan adhasson hozzá, szúrjon be, klónozzon és töröljön sorokat vagy oszlopokat, hogyan jelölje meg az első sort fejlécként, hogyan állítsa be a méreteket és az elrendezést, valamint hogyan alkalmazzon szöveg- és stílusformázást sor- vagy oszlop szinten. Minden feladatot egy kompakt, önálló kódrészlet mutat be a [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) API alapján, így gyorsan megtalálhatja a táblát egy dián, és átalakíthatja annak szerkezetét a tervezésének megfelelően.

## **Az első sor beállítása fejlécként**

Jelölje meg a táblázat első sorát fejlécként, hogy egyértelműen megkülönböztesse az oszlopcímeket az adatoktól. Az Aspose.Slides for Python esetén egyszerűen engedélyezze a táblázat *First Row* (Első sor) beállítását, hogy alkalmazza a kiválasztott táblastílus által definiált fejlécformázást.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból, és töltse be a prezentációt.  
1. Hozzáférés a diára index alapján.  
1. Iteráljon végig az összes [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) objektumon, hogy megtalálja a megfelelő táblát.  
1. Állítsa be a táblázat első sorát fejlécként.

Ez a Python kód bemutatja, hogyan állítható be egy táblázat első sorát fejlécként:

```python
import aspose.slides as slides

# Példányosítja a Presentation osztályt.
with slides.Presentation("table.pptx") as presentation:
    # Elérhető az első dia.
    slide = presentation.slides[0]

    # Iterálja a alakzatok között, és szerezze meg a táblázatra való hivatkozást.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Állítsa be a tábla első sorát fejlécként.
    table.first_row = True
    
    # Mentse a prezentációt a lemezen.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Táblázatsor vagy -oszlop klónozása**

Klónozzon bármely táblázatsort vagy -oszlopot, és szúrja be a másolatot a kívánt pozícióba a táblában. A másolat megőrzi a cellák tartalmát, formázását és méreteit, így gyorsan és egységesen bővítheti az elrendezést.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból, és töltse be a prezentációt.  
1. Hozzáférés a diára index alapján.  
1. Definiáljon egy tömböt az oszlopszélességekhez.  
1. Definiáljon egy tömböt a sormagasságokhoz.  
1. Adjon hozzá egy [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) elemet a diára a `add_table(x, y, column_widths, row_heights)` metódussal.  
1. Klónozzon egy táblázatsort.  
1. Klónozzon egy táblázatoszlopot.  
1. Mentse el a módosított prezentációt.

Ez a Python kód bemutatja, hogyan klónozható egy PowerPoint táblázat sor és oszlop:

```python
 import aspose.slides as slides

# Példányosítja a Presentation osztályt.
with slides.Presentation() as presentation:
    # Eléri az első diát.
    slide = presentation.slides[0]

    # Definiálja az oszlopszélességeket és a sormagasságokat.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Hozzáad egy táblát a diára.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Szöveget ad hozzá az 1. sor, 1. oszlop cellájához.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Szöveget ad hozzá a 2. sor, 1. oszlop cellájához.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Klónozza az 1. sort a táblázat végén.
    table.rows.add_clone(table.rows[0], False)

    # Szöveget ad hozzá az 1. sor, 2. oszlop cellájához.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Szöveget ad hozzá a 2. sor, 2. oszlop cellájához.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Klónozza a 2. sort a táblázat 4. soraként.
    table.rows.insert_clone(3,table.rows[1], False)

    # Klónozza az első oszlopot a végén.
    table.columns.add_clone(table.columns[0], False)

    # Klónozza a második oszlopot a 3. indexen (a 4. pozícióban).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Mentse a prezentációt a lemezen.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sor vagy oszlop eltávolítása a táblázatból**

Egyszerűsítse a táblázatot egy sor vagy oszlop index szerinti eltávolításával az Aspose.Slides for Python segítségével – a layout automatikusan újraigazítódik, miközben megőrzi a maradék cellák formázását. Hasznos adatrácsok egyszerűsítéséhez vagy helyőrzők törléséhez a tábla újbóli felépítése nélkül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból, és töltse be a prezentációt.  
1. Hozzáférés a diára index alapján.  
1. Definiáljon egy tömböt az oszlopszélességekhez.  
1. Definiáljon egy tömböt a sormagasságokhoz.  
1. Adjon hozzá egy ITable elemet a diára a `add_table(x, y, column_widths, row_heights)` metódussal.  
1. Távolítsa el a táblázat sorát.  
1. Távolítsa el a táblázat oszlopát.  
1. Mentse el a módosított prezentációt.

Az alábbi Python kód mutatja, hogyan távolítható el egy sor és egy oszlop a táblázatból:

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

Alkalmazzon egységes szövegstílust egy teljes táblázatsoron egy lépésben. Az Aspose.Slides for Python segítségével egyszerre beállíthatja a betűcsaládot, méretet, vastagságot, színt és igazítást minden cellára a sorban, így a fejlécek vagy adatcsoportok egységesek maradnak.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból, és töltse be a prezentációt.  
1. Hozzáférés a diára index alapján.  
1. Hozzáférés a megfelelő [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) objektumhoz a dián.  
1. Állítsa be a betűmagasságot az első sor celláiban.  
1. Állítsa be az igazítást és a jobb margót az első sor celláiban.  
1. Állítsa be a szöveg függőleges típusát a második sor celláiban.  
1. Mentse el a módosított prezentációt.

Ez a Python kód demonstrálja a műveletet.

```python
import aspose.slides as slides

# Létrehozza a Presentation osztály egy példányát.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Beállítja a betűmagasságot az első sor celláihoz.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Beállítja az első sor celláinak szövegigazítását és jobb margóját.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Beállítja a második sor celláinak függőleges szöveg típusát.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Elmenti a prezentációt a lemezre.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Szövegformázás beállítása a táblázatoszlop szintjén**

Alkalmazzon egységes szövegstílust egy teljes táblázatoszlopon egyszerre. Az Aspose.Slides for Python segítségével beállíthatja a betűcsaládot, méretet, vastagságot, színt és igazítást minden cellára egy oszlopban, hogy egységes függőleges sávok jöjjenek létre a fejlécek vagy adatok számára.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból, és töltse be a prezentációt.  
1. Hozzáférés a diára index alapján.  
1. Hozzáférés a megfelelő [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) objektumhoz a dián.  
1. Állítsa be a betűmagasságot az első oszlop celláiban.  
1. Állítsa be az igazítást és a jobb margót az első oszlop celláiban.  
1. Állítsa be a szöveg függőleges típusát a második oszlop celláiban.  
1. Mentse el a módosított prezentációt.

Az alábbi Python kód demonstrálja a műveletet:

```python
import aspose.slides as slides

# Létrehozza a Presentation osztály egy példányát.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Beállítja az első oszlop celláinak betűmagasságát.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Beállítja az első oszlop celláinak szövegigazítását és jobb margóját.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Beállítja a második oszlop celláinak függőleges szöveg típusát.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Elmenti a prezentációt a lemezre.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Táblázatstílus tulajdonságok lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy táblázat stílusának tulajdonságait, amelyeket később újra felhasználhat egy másik táblázathoz vagy máshová. Az alábbi Python kód mutatja, hogyan kérhető le egy előre definiált táblastílus tulajdonságai:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/elrendezés/mester téma beállításait, és továbbra is felülírhatja a kitöltést, vonalakat és szövegszíneket ezen téma felett.

**Rendezhetem a táblázatsorokat úgy, mint Excelben?**

Nem, az Aspose.Slides táblázatok nem rendelkeznek beépített rendezési vagy szűrési funkcióval. Először rendezd a data memóriában, majd töltsd fel a táblázatsorokat a kívánt sorrendben.

**Lehet csíkozott (csíkozott) oszlopokat használni, miközben egyedi színeket tartok meg bizonyos cellákban?**

Igen. Kapcsold be a csíkozott oszlopokat, majd a helyi formázással felülírd a specifikus cellákat; a cellaszintű formázás előnyben részesül a táblastílushoz képest.