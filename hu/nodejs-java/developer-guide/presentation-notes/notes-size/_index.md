---
title: Jegyzetoldal méretének és tájolásának módosítása JavaScriptben
linktitle: Jegyzetoldal mérete
type: docs
weight: 10
url: /hu/nodejs-java/notes-size/
keywords:
- jegyzetoldal mérete
- jegyzet tájolása
- fekvő jegyzetek
- álló jegyzetek
- kiosztott anyag mérete
- PowerPoint
- prezentáció
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Olvassa és módosítsa a jegyzetoldal méreteit az Aspose.Slides for Node.js-ben Java segítségével, változtassa meg a tájolást, ellenőrizze a mentett méreteket, és exportálja a jegyzeteket vagy a kiosztott anyagokat PDF-be és képekbe."
---
## **Áttekintés**

Használja a [Presentation.getNotesSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getnotessize/) metódust a prezentáció jegyzetoldal-beállításainak eléréséhez. Ez egy [NotesSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notessize/) objektumot ad vissza, amelynek a [setSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notessize/setsize/) metódusa állítja be az oldal méreteit. Bár a beállítási objektumot magát nem lehet kicserélni, új méreteket adhatunk meg ezzel a metódussal.

A szélességet és magasságot **pontban** adjuk meg, ami 72 pont hüvelykenként. Például a 900 × 600 pont 12,5 × 8⅓ hüvelyknek felel meg. Ezek a beállítások a teljes prezentációra vonatkoznak, nem egy adott dia jegyzeteire.

| Beállítás | Cél |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getnotessize/) | A jegyzetoldal méreteit és a kiosztott anyag exportálásához használt oldalméreteket szabályozza. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getslidesize/) | A szokásos prezentációs diák méreteit szabályozza a [SlideSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesize/) segítségével. |

Az egyik beállítás módosítása nem változtatja automatikusan a másikat. A jegyzetoldal tájolásának megváltoztatása sem forgatja el a szokásos diákot. Lásd a [Slide Size](/slides/hu/nodejs-java/slide-size/) oldalt a szabványos diák átméretezéséhez.

Az alábbi példák egy meglévő `sample.pptx` fájlt használnak. Az export példákhoz használjon egy olyan prezentációt, amelynek legalább egy diáján szerepelnek előadói jegyzetek. Minden példát önállóan is futtathat.

## **A jegyzetoldal méretének és tájolásának beolvasása**

Olvassa be a szélességet és a magasságot, majd hasonlítsa össze őket a tájolás meghatározásához: a szélesebb oldal fekvő, a magasabb álló, az azonos méretű négyzetes oldal. Ez a példa a tényleges méreteket pontban írja ki, anélkül, hogy egy szabványos papírméretet feltételezne.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Tájolás váltása fekvőre a papírméret módosítása nélkül**

A tájolás megváltoztatásához egyszerűen cserélje fel a meglévő szélességet és magasságot. Így mindkét oldal hossza megmarad, beleértve az egyedi papírméretét is. Az alábbi feltétel megakadályozza, hogy már fekvő oldalt újra állóvá alakítsunk, és érintetlenül hagyja a négyzetes oldalakat.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Álló tájoláshoz használja ugyanazt a hozzárendelést, amikor `size.getWidth() > size.getHeight()`. Ne cserélje ki A4 vagy Letter méretekkel, hacsak nem akarja a papírméretet is módosítani.

## **Egyéni jegyzetoldal méretének beállítása és ellenőrzése**

Állítsa be mindkét méretet egyszerre, majd a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/save/) metódussal írja ki a prezentációt. Ez a példa egy 900 × 600 pontos fekvő oldalt állít be, PPTX‑ként menti, majd újra megnyitja a mentett fájlt a mentett értékek ellenőrzéséhez. Az összehasonlítás 0,01 pont toleranciát engedélyez lebegőpontos értékek esetén; ez nem garantál pontosságot minden fájlformátumban.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

A várt eredmény `900 x 600 points` és `Size preserved: true`. Az újonnan megnyitott prezentáció ellenőrzése a mentett fájlt vizsgálja, nem csak a memóriában lévő beállításokat.

## **Jegyzetek és kiosztott anyag exportálása**

Az oldalméretek határozzák meg a jegyzetek vagy kiosztott anyag elrendezésének rendelkezésre álló területét. Ezek önmagukban nem engedélyezik az elrendezést: a exportálási beállításokat is konfigurálni kell. A szokásos dia exportálás továbbra is a dia méreteit használja.

### **Jegyzetek exportálása PDF‑be és PNG‑be**

A [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notescommentslayoutingoptions/) objektumot adja a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) metódusnak, hogy a jegyzetek bekerüljenek a PDF‑be. Ez a példa az első, jegyzetekkel ellátott diát PNG‑ként is rendereli a [Slide.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getImage) és a [RenderingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/) használatával.

A [BottomTruncated](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notespositions/) mód a jegyzeteket egy oldalon tartja; a nem illeszkedő részek levágásra kerülnek. A PDF 900 × 600 pontos oldalakat használ. Az alább látható 1 × 1 képméretezésnél a PNG is 900 × 600 képpont. A pontok az oldalgeometriát írják le; a képpontok a raszteres kimenetet, melynek mérete a renderelési skálától is függ.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Hosszú jegyzetek PDF‑exportjához a [BottomFull](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notespositions/) mód további oldalakat ad hozzá szükség szerint. Ne használja ezt a módot a fentebb látható egyetlen dia képpel történő hívással, amely nem támogatja. Az átméretezés után ellenőrizze a kimenetet a levágott jegyzetek és a meglévő notes‑master objektumok elhelyezkedése miatt; csak az oldalméretek módosítása önmagában nem garantálja, hogy minden tartalom elfér. További információkért lásd a [Convert PowerPoint to PDF with Notes](/slides/hu/nodejs-java/convert-powerpoint-to-pdf-with-notes/) oldalt.

### **Kiosztott anyag exportálása PDF‑be**

Használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/handoutlayoutingoptions/) objektumot több dia bélyegképeinek egy oldalra helyezéséhez. Az alábbi példa 900 × 600 pontos oldalt állít be, és a [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/handouttype/) segítségével legfeljebb négy diát helyez el oldalanként. A vízszintes előbeállítás a diák sorrendjét szabályozza; az oldal tájolása a szélességéből és magasságából származik.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Az oldalméret módosítása a kiosztott anyag rácsának rendelkezésre álló területét változtatja meg anélkül, hogy a forrásdiák mérete megváltozna. Kiosztott képekhez használja a [Presentation.getImages](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getimages/) metódust a kiosztott elrendezéssel, ne pedig egy adott dia képmetódusát. Az Aspose.Slides‑ben a prezentáció‑szintű kiosztott renderelés a jegyzetoldal méreteit veszi alapul, míg az egyedi dia képmetódus nem hozza létre a kiosztott oldalt. Lásd a [Handout Mode](/slides/hu/nodejs-java/convert-powerpoint-in-handout-mode/) oldalt a elrendezési lehetőségekért.

## **Oldalméret nézőkben, exportálásban és nyomtatásban**

Tartsa elkülönítve a tárolt prezentáció méretét, az exportált oldalméretet és a nyomtatott papírméretet:

- **Prezentációs nézők:** Egy néző megjelenítheti vagy kinyomtathatja a jegyzeteket saját elrendezési szabályai szerint. Ha egy másik alkalmazás menti a fájlt, nyissa meg újra, és ellenőrizze a méreteket; az adott alkalmazás formátumkonverziója normalizálhatja azokat.
- **Export formátumok:** A fenti jegyzet‑ és kiosztott PDF‑példák a konfigurált oldalméreteket használják. A raszteres képek egész számú képpontméreteket és egy renderelési skálát alkalmaznak, így a tört pontértékek kerekítve jelenhetnek meg a képkimenetben. A szokásos diák exportálása nem alkalmazza a jegyzetoldal méretét.
- **Nyomtatóillesztők:** A papírkiválasztás, az automatikus forgatás és a mérethelyes beállítás megváltoztathatja a fizikai kimenetet anélkül, hogy a prezentációban vagy a PDF‑ben tárolt méreteket módosítaná. Egy adott papírméret esetén egyeztesse a nyomtató beállításait, és ellenőrizze a nyomtatási előnézetet.

## **GYIK**

**Beállíthatom a jegyzetek méretét csak egy diára?**

A jegyzetoldal mérete a teljes prezentáció szintjén van beállítva. Az egyes diák különböző jegyzettartalmat tartalmazhatnak, de ez a tulajdonság nem biztosít külön oldalméretet minden diához.

**Miért nem változtak a diáim, amikor a jegyzetek tájolását módosítottam?**

A jegyzetoldalak és a szokásos diák méretei függetlenek egymástól. Használja a szokásos dia méretbeállításokat, ha a diák méretét szeretné módosítani.

**Miért tér el a mentett vagy kinyomtatott eredmény mérete?**

Először nyissa meg újra a mentett prezentációt, és hasonlítsa össze a jegyzetek méreteit. Ha azok megváltoztak, ellenőrizze, hogy egy másik alkalmazás mentése vagy átalakítása változtatta-e meg az oldalbeállításokat. Ha nem, nézze meg az exportálási elrendezést, a képméretezést, a néző beállításait és a nyomtató papírkiválasztását.