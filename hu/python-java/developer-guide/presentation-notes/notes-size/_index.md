---
title: Jegyzetoldal Méretének és Tájolásának Módosítása Pythonban Java-n keresztül
linktitle: Jegyzetoldal Mérete
type: docs
weight: 10
url: /hu/python-java/notes-size/
keywords:
- jegyzetoldal mérete
- jegyzet tájolás
- fekvő jegyzetek
- álló jegyzetek
- kézikönyv méret
- PowerPoint
- bemutató
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Olvassa el és módosítsa a jegyzetoldal méreteit az Aspose.Slides for Python via Java könyvtárban, váltsa a tájolást, ellenőrizze a mentett méreteket, és exportálja a jegyzeteket vagy kézikönyveket PDF-re és képekre."
---
## **Áttekintés**

Használja a [Presentation.getNotesSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getNotesSize) metódust a bemutató jegyzetoldal-beállításainak eléréséhez. Ez egy [NotesSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notessize/) objektumot ad vissza, amelynek a [setSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notessize/#setSize) metódusa állítja be az oldal méreteit. Bár a beállítási objektumot magát nem lehet lecserélni, új méreteket rendelhet hozzá ezzel a metódussal.

A szélességet és magasságot **pontban** adjuk meg, 1 hüvelyk = 72 pont. Például a 900 × 600 pont 12,5 × 8⅓ hüvelyknek felel meg. Ezek a beállítások a teljes bemutatóra vonatkoznak, nem pedig egyetlen dia jegyzeteire.

| Beállítás | Cél |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getNotesSize) | A jegyzetoldal méreteit és a kézikönyv exportáláshoz használt oldalméreteket szabályozza. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlideSize) | A szokásos bemutatódiák méreteit a [SlideSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesize/) segítségével szabályozza. |

Az egyik beállítás módosítása nem változtatja meg automatikusan a másikat. A jegyzetoldal tájolásának módosítása nem forgatja el a szokásos diákot sem. Lásd a [Dia Méret](/slides/hu/python-java/slide-size/) oldalt a szokásos diák átméretezéséhez.

Az alábbi példák egy meglévő `sample.pptx` fájlt használnak. Az export példákhoz olyan bemutatót kell használni, amely legalább egy diához tartozó előadói jegyzetet tartalmaz. Minden példát önállóan futtathat.

## **Olvassa el a Jegyzetoldal Méretét és Tájolását**

Olvassa ki a szélességet és magasságot, és hasonlítsa össze őket a tájolás meghatározásához: a szélesebb oldal fekvő (landscape), a magasabb oldal álló (portrait), és az egyenlő méretek négyzetes oldalt jelentenek. Ez a példa a tényleges méreteket pontban írja ki, anélkül, hogy standard papírméretet feltételezne.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Váltás Fekvőre A Papírméret Módosítása Nélkül**

A tájolás módosításához cserélje fel a meglévő szélességet és magasságot. Ez megőrzi mindkét oldal hosszát, beleértve az egyedi papírméret hosszait is. Az alábbi feltétel megakadályozza, hogy egy már fekvő oldal visszaálljon állóba, és a négyzetes oldalt változatlanul hagyja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Álló tájolás esetén ugyanazt a hozzárendelést használja, ha a `size.getWidth() > size.getHeight()`. Ne cserélje le A4 vagy Letter méreteket, hacsak nem akarja módosítani a papírméretet is.

## **Egyéni Jegyzetoldal Méret Beállítása és Ellenőrzése**

Mindkét méretet egyszerre állítsa be, majd használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a bemutató mentéséhez. Ez a példa egy 900 × 600 pontos fekvő oldalt állít be, PPTX-ként menti, majd újra megnyitja a mentett fájlt a megőrzött értékek ellenőrzéséhez. Az összehasonlítás 0,01 pontnyi toleranciát enged meg lebegőpontos értékeknél; ez nem garancia minden fájlformátum pontosságára.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

A várt eredmény `900.0 x 600.0 points` és `Size preserved: True`. Egy újonnan megnyitott bemutató ellenőrzése a mentett fájlt igazolja, nem csak a memóriában lévő beállításokat.

## **Jegyzetek és Kézikönyvek Exportálása**

Az oldalméretek határozzák meg a jegyzetek vagy kézikönyv elrendezések számára rendelkezésre álló területet. Ezek önmagukban nem aktiválják az elrendezéseket: az export beállításait is konfigurálni kell. A szokásos diaexportálás továbbra is a dia méreteit használja.

### **Jegyzetek Exportálása PDF-be és PNG-be**

Rendelje hozzá a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/) objektumot a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) metódushoz, hogy a jegyzetek megtaláljanak a PDF-ben. Ez a példa az első, jegyzetekkel ellátott diát PNG-re is rendereli a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) és a [RenderingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/renderingoptions/) használatával.

A [BottomTruncated](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/) mód a jegyzeteket egy oldalon tartja; a nem férő jegyzetek levágásra kerülnek. A PDF 900 × 600 pontos oldalakat használ. Az alább alkalmazott 1 × 1 képméretezésnél a PNG 900 × 600 pixel. A pontok az oldalgeometriát írják le; a pixelek a raszteres kimenetet, amelyek mérete a renderelési mérettől is függ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Hosszú jegyzetek PDF-exportálásához a [BottomFull](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/) mód szükség szerint további oldalakat engedélyez. Ne használja ezt a módot a fenti egy-diás kép hívásával, amely nem támogatja. Átméretezés után ellenőrizze a kimenetet a levágott jegyzetek és a meglévő notes-master objektumok elhelyezkedése miatt; csak az oldalméretek módosítása nem garantálja, hogy minden tartalom elfér. További információért a jegyzetek exportjáról lásd a [PowerPoint PDF Átalakítása Jegyzetekkel](/slides/hu/python-java/convert-powerpoint-to-pdf-with-notes/) oldalt.

### **Kézikönyvek Exportálása PDF-be**

Használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/handoutlayoutingoptions/) objektumot több diakép egy oldalon való megjelenítéséhez. A következő példa egy 900 × 600 pontos oldalt állít be, és a [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/hu/python-java/aspose.slides/handouttype/) segítségével maximum négy diát helyez el oldalanként. A vízszintes előbeállítás a diák sorrendjét szabályozza; az oldal tájolása a szélesség és magasság alapján kerül meghatározásra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Az oldalméret módosítása megváltoztatja a kézikönyv rács számára rendelkezésre álló területet anélkül, hogy a forrásdiák méreteit változtatná. Kézikönyv képekhez használja a [Presentation.getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) módszert a kézikönyv elrendezéssel, nem pedig egyedi dia képmetódust. Az Aspose.Slides-ban a bemutató-szintű kézikönyv renderelés a jegyzetoldal méreteit használja, míg az egyedi dia kép hívás nem hoz létre kézikönyv oldalt. A [Kézikönyv Mód](/slides/hu/python-java/convert-powerpoint-in-handout-mode/) oldalon talál elrendezési lehetőségeket.

## **Oldalméret Nézőkben, Exportálásban és Nyomtatásban**

Tartsa külön a tárolt bemutató méretét, az exportált oldalméretet és a nyomtatott papírméretet:

- **Presentation viewers:** A néző megjelenítheti vagy nyomtathatja a jegyzeteket saját elrendezési szabályai szerint. Ha egy másik alkalmazás menti a fájlt, nyissa meg újra és ellenőrizze a méreteket; az adott alkalmazás formátumkonverziója normalizálhatja azokat.
- **Export formats:** A fenti jegyzet- és kézikönyv PDF-példák a beállított oldalméreteket használják. Raszteres képek egész pixelméreteket és egy renderelési mérettel dolgoznak, így a tört pontértékek a képkimenetben kerekíthetők. A szokásos diák exportálása nem alkalmazza a jegyzetoldal méretét.
- **Printer drivers:** A papírválasztás, az automatikus forgatás és a méretezés a lapra beállítások megváltoztathatják a fizikai kimenetet anélkül, hogy a bemutatóban vagy PDF-ben tárolt méreteket módosítanák. Egy adott papírméret esetén egyeztesse a nyomtató beállításait és ellenőrizze a nyomtatási előnézetet.

## **GYIK**

**Beállíthatom-e a jegyzet méretét csak egy diához?**

A jegyzetoldal mérete a bemutató szintű beállítás. Az egyes diák különböző jegyzet tartalommal rendelkezhetnek, de ez a tulajdonság nem biztosít külön oldalméretet minden diához.

**Miért nem változtatták meg a diák a jegyzet tájolásának módosítása során?**

A jegyzetoldalak és a szokásos diák független méretekkel rendelkeznek. Használja a szokásos dia méret beállításait, ha magukat a diák méretét szeretné módosítani.

**Miért különbözik a mentett vagy nyomtatott eredmény mérete?**

Először nyissa meg újra a mentett bemutatót, és hasonlítsa össze a jegyzet méreteket. Ha azok megváltoztak, ellenőrizze, hogy egy másik alkalmazásban történt-e a fájl mentése vagy konvertálása során az oldalbeállítások változása. Ha nem, vizsgálja meg az export elrendezést, a képméretezést, a néző beállításait és a nyomtató papírválasztását.