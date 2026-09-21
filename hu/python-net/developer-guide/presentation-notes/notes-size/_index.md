---
title: Jegyzetoldal méretének és tájolásának módosítása Pythonban
linktitle: Jegyzetoldal mérete
type: docs
weight: 10
url: /hu/python-net/notes-size/
keywords:
- jegyzetoldal mérete
- jegyzet tájolás
- fekvő jegyzetek
- álló jegyzetek
- kézbesítő mérete
- PowerPoint
- bemutató
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Olvassa el és módosítsa a jegyzetoldal méreteit az Aspose.Slides for Python (via .NET) segítségével, váltson tájolást, ellenőrizze a mentett méreteket, és exportálja a jegyzeteket vagy kézbesítőket PDF-be és képekbe."
---
## **Áttekintés**

Használja a [Presentation.notes_size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/notes_size/) metódust a bemutató jegyzetoldal beállításainak eléréséhez. Ez egy [NotesSize](https://reference.aspose.com/slides/hu/python-net/aspose.slides/notessize/) objektumot ad vissza, amelynek a [size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/notessize/size/) tulajdonsága írható. Bár maguk a beállítási objektum csak olvasható, a méret tulajdonságához új méreteket rendelhet.

A szélesség és magasság **pontban** van megadva, 72 pont hüvelykenként. Például a 900 × 600 pont 12,5 × 8⅓ hüvelyknek felel meg. Ezek a beállítások a bemutatóra vonatkoznak, nem egy adott dia jegyzeteire.

| Beállítás | Cél |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/notes_size/) | A jegyzetoldal méreteit és a kézbesítő exporthoz használt oldalméreteket irányítja. |
| [Presentation.slide_size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/slide_size/) | A szabályos bemutatódiák méreteit a [SlideSize](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidesize/) segítségével irányítja. |

Az egyik beállítás módosítása nem változtatja meg automatikusan a másikat. A jegyzetoldal tájolásának módosítása sem forgatja el a szabályos diát. Lásd a [Slide Size](/slides/hu/python-net/slide-size/) oldalt a szabályos diák átméretezéséhez.

## **A jegyzetoldal méretének és tájolásának olvasása**

Olvassa ki a szélességet és magasságot, és hasonlítsa össze őket a tájolás meghatározásához: a szélesebb oldal fekvő, a magasabb álló, és az egyenlő méretek négyzetes oldalt jelentenek. Ez a példa a tényleges méreteket pontban írja ki, anélkül, hogy egy szabványos papírméretet feltételezne.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Átváltás fekvőre a papírméret módosítása nélkül**

A tájolás csak módosításához cserélje fel a meglévő szélességet és magasságot. Ez megőrzi mindkét oldal hosszát, beleértve az egyedi papírméretét is. Az alábbi feltétel megakadályozza, hogy egy már fekvő oldal visszaváltson állóra, és a négyzetes oldal változatlan marad.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Álló tájolás esetén ugyanazt a hozzárendelést használja, amikor `size.width > size.height`. Ne cserélje ki A4 vagy Letter méreteket, hacsak nem kívánja a papírméretet is módosítani.

## **Egyéni jegyzetoldal méret beállítása és ellenőrzése**

Mindkét dimenziót egyszerre rendelje hozzá, majd a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) módszerrel mentse a bemutatót. Ez a példa 900 × 600 pontos fekvő oldalt állít be, PPTX‑ként menti, majd újra megnyitja a mentett fájlt a tárolt értékek ellenőrzéséhez. Az összehasonlítás 0,01 pont toleranciát enged meg a lebegőpontos értékeknél; ez nem garancia a pontosságra minden fájlformátumnál.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

A várt eredmény `900 x 600 points` és `Size preserved: True`. Egy újonnan megnyitott bemutató ellenőrzése a mentett fájlt bizonyítja, nem csak a memóriában lévő beállításokat.

## **Jegyzetek és kézbesítők exportálása**

Az oldalméretek határozzák meg a jegyzetek vagy kézbesítők elrendezéséhez rendelkezésre álló területet. Ezek önmagukban nem aktiválják az elrendezéseket: a exportálási beállításokat is konfigurálni kell. A szabályos dia exportálás továbbra is a dia méreteit használja.

### **Jegyzetek exportálása PDF‑be és PNG‑be**

A [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/notescommentslayoutingoptions/) hozzárendelésével a [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) lehetővé teszi a jegyzetek belefoglalását a PDF‑be. Ez a példa az első, jegyzetekkel rendelkező diát PNG‑ként is megjeleníti a [Slide.get_image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/get_image/) és a [RenderingOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/renderingoptions/) segítségével.

A [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/notespositions/) mód a jegyzeteket egy oldalon tartja; a nem férő bejegyzések levágásra kerülnek. A PDF 900 × 600 pontos oldalakat használ. Az alább használt 1 × 1 képmérettel a PNG 900 × 600 pixel lesz. A pontok az oldal geometriai méreteit írják le; a pixelek a raszteres kimenetet, amelynek mérete a renderelési skálától is függ.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

Hosszú jegyzetek PDF‑exportálásához a [BOTTOM_FULL](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/notespositions/) mód további oldalakat engedélyez, ha szükséges. Ne használja ezt a módot a fenti egyedi dia képkéréssel, amely nem támogatja. Átméretezés után ellenőrizze a kimenetet a levágott jegyzetek és a meglévő notes-master objektumok elhelyezkedése szempontjából; csak az oldalméretek módosítása nem garantálja, hogy minden tartalom elfér. További információért a jegyzetek exportjáról lásd a [Convert PowerPoint to PDF with Notes](/slides/hu/python-net/convert-powerpoint-to-pdf-with-notes/) oldalt.

### **Kézbesítők exportálása PDF‑be**

Használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/handoutlayoutingoptions/) lehetőséget több dia bélyegkép egy oldalon való elhelyezéséhez. A következő példa 900 × 600 pontos oldalt állít be, és a [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/handouttype/) segítségével legfeljebb négy diát helyez el oldalanként. A vízszintes előre beállítás a dia sorrendjét irányítja; az oldal tájolása a szélességéből és magasságából származik.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Az oldalméret módosítása a kézbesítő rácsának elérhető területét változtatja meg, anélkül, hogy a forrásdiák méretei változnának. Kézbesítő képekhez használja a [Presentation.get_images](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/get_images/) metódust a kézbesítő elrendezéssel, nem egy adott dia képmódszerével. Az Aspose.Slides-ban a bemutató‑szintű kézbesítő renderelés a jegyzetoldal méreteit használja, míg az egyedi dia képkérése nem hoz létre kézbesítő oldalt. Az elrendezési lehetőségekért lásd a [Handout Mode](/slides/hu/python-net/convert-powerpoint-in-handout-mode/) oldalt.

## **Oldalméret a nézőkben, exportálásban és nyomtatásban**

Tartsa elkülönítve a tárolt bemutató méretét, az exportált oldalméretet és a nyomtatott papírméretet:

- **Presentation viewers:** A néző képes megjeleníteni vagy nyomtatni a jegyzeteket saját elrendezési szabályai szerint. Ha egy másik alkalmazás menti a fájlt, nyissa meg újra és ellenőrizze a méreteket; az alkalmazás formátumkonverziója normalizálhatja azokat.
- **Export formats:** A fenti jegyzet‑ és kézbesítő‑PDF példák a beállított oldalméreteket használják. A raszter képek egész számú pixelméreteket és renderelési skálát használnak, ezért a tört pont értékek kerekíthetők a képkimenetben. A szabályos diák exportálása nem alkalmazza a jegyzetoldal méretét.
- **Printer drivers:** A papír választás, az automatikus forgatás és a méretezés beállításai megváltoztathatják a fizikai eredményt anélkül, hogy a bemutatóban vagy a PDF‑ben tárolt méreteket módosítanák. Egy adott papírméret esetén állítsa be a nyomtató beállításait, és ellenőrizze a nyomtatási előnézetet.

## **GYIK**

**Be tudom állítani a jegyzetek méretét csak egy diára?**  
A jegyzetoldal mérete a teljes bemutató szintű beállítás. Az egyes diák különböző jegyzettartalommal rendelkezhetnek, de ez a tulajdonság nem biztosít külön oldalméretet minden diára.

**Miért nem változtatta meg a jegyzetek tájolásának módosítása a diáimat?**  
A jegyzetoldalak és a szabályos diák méretei függetlenek egymástól. A diák átméretezéséhez használja a szabályos dia méret beállításait.

**Miért különbözik a mentett vagy nyomtatott eredmény mérete?**  
Először nyissa meg újra a mentett bemutatót és hasonlítsa össze a jegyzetek méreteit. Ha azok megváltoztak, ellenőrizze, hogy egy másik alkalmazásban a fájl mentése vagy konvertálása megváltoztatta‑e az oldalbeállításokat. Ha nem, ellenőrizze az export elrendezését, a képméret skálát, a néző beállításait és a nyomtató papírválasztását.