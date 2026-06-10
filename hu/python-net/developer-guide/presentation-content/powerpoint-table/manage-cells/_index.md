---
title: "Python segítségével táblázatcellák kezelése prezentációkban"
linktitle: "Cellák kezelése"
type: docs
weight: 30
url: /hu/python-net/manage-cells/
keywords:
  - táblázatcella
  - cellák egyesítése
  - szegély eltávolítása
  - cella felosztása
  - kép a cellában
  - háttérszín
  - PowerPoint
  - OpenDocument
  - prezentáció
  - Python
  - Aspose.Slides
description: "Könnyedén kezelheti a táblázatcellákat PowerPoint és OpenDocument formátumokban az Aspose.Slides for Python (a .NET-en keresztül) segítségével. Gyorsan elsajátíthatja a cellák elérését, módosítását és stílusozását a zökkenőmentes dia-automatizálás érdekében."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy hozzáférjen és módosítsa a táblázatcellákat a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan azonosítsa az egyesített táblázatcellákat, hogyan távolítsa el a cellahatárokat, hogyan kezelje a cellaszámozást egyesítés vagy felosztás után, hogyan változtassa meg egy cella háttérszínét, és hogyan szúrjon be képet egy táblázatcellába. A példák azt mutatják, hogyan hozhat létre vagy nyithat meg egy prezentációt, hogyan szerezhet be egy táblázatot egy diáról, hogyan frissítheti a cella formázását a cellatulajdonságok segítségével, és hogyan mentheti a módosított prezentációt PPTX‑fájlként.

## **Egyesített táblázatcellák azonosítása**

A táblázatok gyakran tartalmaznak egyesített cellákat a fejléchez vagy a kapcsolódó adatok csoportosításához. Ebben a részben megmutatjuk, hogyan határozhatja meg, hogy egy adott cella egy egyesített régióhoz tartozik‑e, és hogyan hivatkozhat a mester (bal‑felső) cellára, hogy egységesen olvassa vagy formázza a teljes blokkot.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezze meg a táblázatot az első diáról.
1. Járja be a táblázat sorait és oszlopait az egyesített cellák kereséséhez.
1. Írjon ki egy üzenetet, amikor egyesített cellákat talál.

Az alábbi Python‑kód azonosítja az egyesített táblázatcellákat egy prezentációban:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Feltételezve, hogy az első dia első alakja egy táblázat.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Táblázatcella szegélyek eltávolítása**

Néha a táblázat szegélyei elvonják a figyelmet a tartalomról vagy vizuális zsúfoltságot okoznak. Ez a rész bemutatja, hogyan távolíthatja el a szegélyeket a kiválasztott cellákról — vagy egy cella egyes oldalairól — hogy tisztább elrendezést és a diák tervezésével jobban összhangban lévő megjelenést érjen el.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezze meg a diát indexe alapján.
1. Határozzon meg egy tömböt az oszlopszélességekkel.
1. Határozzon meg egy tömböt a sormagasságokkal.
1. Adjon hozzá egy táblázatot a diához a [add_table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_table/) metódussal.
1. Járjon végig minden cellán, és távolítsa el a felső, alsó, bal és jobb szegélyeket.
1. Mentse a módosított prezentációt PPTX‑fájlként.

Az alábbi Python‑kód megmutatja, hogyan távolítható el a szegély a táblázatcellákról:

```python
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel.
with slides.Presentation() as presentation:
    # Eléri az első diát.
    slide = presentation.slides[0]

    # Oszlopok szélességének és sorok magasságának meghatározása.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Táblázat alakzat hozzáadása a diára.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Minden cella szegélyfeltöltésének törlése.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # PPTX fájl mentése a lemezre.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Számozás egyesített cellákban**

Ha két cellapárt egyesít — például (1, 1) × (2, 1) és (1, 2) × (2, 2) — a kapott táblázat a táblázat eredeti számozását megtartja az egyesítés nélkül is. Az alábbi Python‑kód ezt a viselkedést demonstrálja:

```python
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel.
with slides.Presentation() as presentation:
    # Eléri az első diát.
    slide = presentation.slides[0]

    # Oszlopok szélességének és sorok magasságának meghatározása.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Táblázat alakzat hozzáadása a diára.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Cellák (1,1) és (2,1) egyesítése.
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Cellák (1, 2) és (2, 2) egyesítése.
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Cellák indexeinek kiíratása.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # PPTX fájl mentése a lemezre.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Kimenet:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Számozás felosztott cellákban**

Az előző példában, amikor a táblázatcellákat egyesítették, a többi cella számozása nem változott. Ezúttal egy szabályos táblázatot hozunk létre (egyesített cellák nélkül), majd felosztjuk a (1, 1) cellát, hogy egy speciális táblázatot kapjunk. Figyelje meg ennek a táblázatnak a számozását — elsőre szokatlanul tűnhet. Ez azonban a Microsoft PowerPoint cellaszámozási módja, és az Aspose.Slides ugyanígy működik.

Az alábbi Python‑kód demonstrálja ezt a viselkedést:

```python
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel.
with slides.Presentation() as presentation:
    # Eléri az első diát.
    slide = presentation.slides[0]

    # Oszlopok szélességének és sorok magasságának meghatározása.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Táblázat alakzat hozzáadása a diára.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # (1, 1) cella felosztása.
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Cellák indexeinek kiíratása.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # PPTX fájl mentése a lemezre.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Kimenet:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Táblázatcella háttérszínének módosítása**

Az alábbi Python‑példa bemutatja, hogyan változtatható meg egy táblázatcella háttérszíne:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Új táblázat létrehozása.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Cellának háttérszín beállítása.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Képek beszúrása táblázatcellákba**

Ez a rész bemutatja, hogyan szúrjon be képet egy táblázatcellába az Aspose.Slides‑ben. Tartalmazza a képkitöltés alkalmazását a célcella számára, valamint a megjelenítési beállítások (nyújtás vagy csempézés) konfigurálását.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát a diára indexe alapján.
1. Határozzon meg egy tömböt az oszlopszélességekkel.
1. Határozzon meg egy tömböt a sormagasságokkal.
1. Adjon hozzá egy táblázatot a diához a [add_table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_table/) metódussal.
1. Töltse be a képet egy fájlból.
1. Adja hozzá a képet a prezentáció képeihez, hogy egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot kapjon.
1. Állítsa be a táblázatcella [FillType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) értékét `PICTURE`‑re.
1. Alkalmazza a képet a táblázatcella kitöltésére, és válasszon kitöltési módot (például `STRETCH`).
1. Mentse a prezentációt PPTX‑fájlként.

Az alábbi Python‑kód megmutatja, hogyan helyezzen el képet egy táblázatcella belsejében táblázat létrehozásakor:

```python
import aspose.slides as slides

# Példányosít egy Presentation objektumot.
with slides.Presentation() as presentation:
    # Eléri az első diát.
    slide = presentation.slides[0]

    # Definiálja az oszlopszélességeket és a sormagasságokat.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Táblázat alakzat hozzáadása a diához.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Betölti a képet és hozzáadja a prezentációhoz egy PPImage lekérése érdekében.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Alkalmazza a képet az első táblázatcellára.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # A prezentáció mentése a lemezre.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Beállíthatok különböző vonalvastagságot és -stílust a cella egyes oldalaihoz?**

Igen. A [top](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cellformat/border_right/) szegélyeknek külön‑külön tulajdonságai vannak, ezért minden oldal vastagsága és stílusa eltérhet. Ez logikusan következik a cikkben bemutatott per‑side szegélyvezérlésből.

**Mi történik a képpel, ha a oszlop/sor méretét megváltoztatom a kép háttérként való beállítása után?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillmode/) (stretch/tile) beállításától függ. Nyújtás esetén a kép alkalmazkodik az új cellához; csempézés esetén a csempéket újraszámolják. A cikk említi a képek megjelenítési módjait a cellában.

**Hozzá tudok-e rendelni hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/python-net/manage-hyperlinks/) a cella szövegkeretén belüli szövegrész (portion) szintjén vagy a teljes táblázat/shape szintjén állítható be. Gyakorlatban a hivatkozást egy részhez vagy a cella teljes szövegéhez rendelhetjük.

**Beállíthatok‑e különböző betűtípusokat egyetlen cellában?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) (futamok) független formázását — betűcsalád, stílus, méret és szín tekintetében.