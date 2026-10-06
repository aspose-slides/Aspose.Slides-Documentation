---
title: Jegyzetoldal Méretének és Tájolásának Módosítása Androidon
linktitle: Jegyzetoldal Mérete
type: docs
weight: 10
url: /hu/androidjava/notes-size/
keywords:
- jegyzetoldal mérete
- jegyzet tájolás
- vízszintes jegyzetek
- álló jegyzetek
- szórólap mérete
- PowerPoint
- prezentáció
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Olvassa el és módosítsa a jegyzetoldal méreteit az Aspose.Slides for Android Java használatával, váltsa át a tájolást, ellenőrizze a mentett méreteket, és exportálja a jegyzeteket vagy szórólapokat PDF-be és képekbe."
---
## **Áttekintés**

Használja a [Presentation.getNotesSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getNotesSize--) a prezentáció jegyzetoldal beállításainak eléréséhez. Ez visszaad egy [INotesSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/inotessize/) objektumot, amelynek a [setSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) metódusa beállítja az oldal méreteit. Bár a beállítási objektumot magát nem lehet lecserélni, új méreteket rendelhet hozzá ezzel a metódussal.

A szélesség és magasság **pontban** van megadva, 72 pont hüvelykenként. Például a 900 × 600 pont 12,5 × 8⅓ hüvelyknek felel meg. Ezek a beállítások a teljes prezentációra vonatkoznak, nem egyetlen dián lévő jegyzetre.

| Beállítás | Cél |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Szabályozza a jegyzetoldal méreteit és azokat a méreteket, amelyeket a szórólap exportálásához használ. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Szabályozza a normál prezentációs diák méreteit az [ISlideSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidesize/) segítségével. |

Az egyik beállítás módosítása nem változtatja meg automatikusan a másikat. A jegyzetoldal tájolásának módosítása sem forgatja el a normál diákat. Lásd a [Dia Mérete](/slides/hu/androidjava/slide-size/) oldalt a normál diák átméretezéséhez.

Az alábbi példák egy meglévő `sample.pptx` fájlt használnak. Az export példákhoz használjon olyan prezentációt, amelyen legalább egy dia tartalmaz előadói jegyzetet. Minden példa önállóan futtatható.

## **Olvassa el a Jegyzetoldal Méretét és Tájolását**

Olvassa el a szélességet és magasságot, és hasonlítsa össze őket a tájolás meghatározásához: a szélesebb oldal tájképet, a magasabb oldal állóképet jelent, az azonos méret négyzetes oldalt jelent. Ez a példa a valós méreteket pontban írja ki, anélkül, hogy egy szabványos papírméretet feltételezne.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Váltás Tájképre a Papírméret Módosítása Nélkül**

A tájolás megváltoztatásához cserélje fel a meglévő szélességet és magasságot. Így megmarad mindkét oldal hossza, beleértve az egyedi papírméretét is. Az alábbi feltétel megakadályozza, hogy egy már tájképű oldal visszaváltson állóképre, és a négyzetes oldal változatlan maradjon.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Álló tájoláshoz használja ugyanazt a hozzárendelést, amikor `size.getWidth() > size.getHeight()`. Ne cserélje le az A4 vagy Letter méreteket, hacsak nem szeretné megváltoztatni a papírméretet is.

## **Egy Egyéni Jegyzetoldal Méretének Beállítása és Ellenőrzése**

Rendelje hozzá mindkét méretet egyszerre, majd használja a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust a prezentáció mentéséhez. Ez a példa egy 900 × 600 pont tájkép oldalt állít be, PPTX‑ként menti, majd újra megnyitja a mentett fájlt a mentett értékek ellenőrzéséhez. Az összehasonlítás 0,01 pont tűréshatárt enged meg a lebegőpontos értékeknél; nem ez garantálja a pontosságot minden fájlformátum esetén.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

A várt eredmény `900.0 x 600.0 points` és `Size preserved: true`. Egy újonnan megnyitott prezentáció ellenőrzése a mentett fájlt ellenőrzi, nem csak a memóriában lévő beállításokat.

## **Jegyzetek és Szórólapok Exportálása**

Az oldalméretek meghatározzák a jegyzetek vagy szórólapok elrendezéséhez rendelkezésre álló területet. Ezek önmagukban nem aktiválják az elrendezéseket: konfigurálni kell az exportálási beállításokat is. A normál diák exportálása továbbra is a dia méreteket használja.

### **Export Jegyzetek PDF‑be és PNG‑be**

Rendelje hozzá a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notescommentslayoutingoptions/) a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) metódushoz, hogy a jegyzetek bekerüljenek a PDF‑be. Ez a példa az első, jegyzetekkel ellátott diát PNG‑be rendereli a [Slide.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) és a [RenderingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/renderingoptions/) segítségével.

A [BottomTruncated](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notespositions/) mód a jegyzeteket egy oldalon tartja; a nem beleférő jegyzetek levághatók. A PDF 900 × 600 pont oldalakat használ. Az alább használt 1 × 1 képméretnél a PNG 900 × 600 képpont. A pontok leírják az oldal geometriai méretét; a képpontok a raszteres kimenetet, amelynek mérete a renderelési skálától is függ.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Hosszú jegyzetek PDF‑exportjához a [BottomFull](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notespositions/) több oldalt is engedélyez, ha szükséges. Ne használja ezt a módot az előző egyetlen dia képet előállító hívással, mert az azt nem támogatja. Átméretezés után ellenőrizze a kimenetet a levágott jegyzetek és a meglévő notes‑master objektumok elhelyezkedése miatt; az oldalméretek önmagukban nem garantálják, hogy minden tartalom elfér. Tekintse meg a [Convert PowerPoint to PDF with Notes](/slides/hu/androidjava/convert-powerpoint-to-pdf-with-notes/) oldalt a jegyzetek exportálásáról szóló további információkért.

### **Szórólapok Exportálása PDF‑be**

Használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/handoutlayoutingoptions/) lehetőséget több dia bélyegkép egy oldalra való elhelyezéséhez. A következő példa 900 × 600 pont oldalt állít be, és a [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/handouttype/) segítségével legfeljebb négy diát rendez el egy oldalon. A horizontális előbeállítás a dia sorrendjét szabályozza; az oldal tájolása a szélességből és magasságból ered.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Az oldalméret módosítása megváltoztatja a szórólap rács rendelkezésre álló területét anélkül, hogy a forrásdiák mérete megváltozna. Szórólap képekhez használja a [Presentation.getImages](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) metódust a szórólap elrendezéssel, ahelyett, hogy egyedi dia képmódszert hívna. Az Aspose.Slides esetében a prezentáció‑szintű szórólap renderelés a jegyzetoldal méreteit használja, míg az egyedi dia kép hívás nem hoz létre szórólap oldalt. Tekintse meg a [Handout Mode](/slides/hu/androidjava/convert-powerpoint-in-handout-mode/) oldalt a elrendezési lehetőségekért.

## **Oldalméret Megjelenítőkben, Exportálásban és Nyomtatásban**

Tartsa meg a tárolt prezentációméretet, az exportált oldalméretet és a nyomtatott papírméretet különállóan:

- **Presentation viewers:** A megjelenítő megjelenítheti vagy nyomtathatja a jegyzeteket saját elrendezési szabályai szerint. Ha egy másik alkalmazás menti a fájlt, nyissa meg újra, és ellenőrizze újra a méreteket; az alkalmazás formátumkonverziója normalizálhatja azokat.
- **Export formats:** A fenti jegyzet‑ és szórólap‑PDF példák a beállított oldalméreteket használják. Raszteres képek egész számú képpontmérettel és renderelési skálával rendelkeznek, ezért a tört pontértékek kerekíthetők a képkimenetben. A normál diák exportálása nem alkalmazza a jegyzetoldal méretét.
- **Printer drivers:** A papírválasztás, az automatikus forgatás és a méretezés‑oldalra illesztés beállításai megváltoztathatják a fizikai kimenetet anélkül, hogy a prezentációban vagy a PDF‑ben tárolt méreteket módosítanák. Egy adott papírméret esetén egyeztesse a nyomtató beállításait, és ellenőrizze a nyomtatási előnézetet.

## **GYIK**

**Beállíthatom a jegyzetek méretét csak egy diára?**

A jegyzetoldal mérete a teljes prezentáció szintjén van beállítva. Az egyes diák eltérő jegyzettartalommal rendelkezhetnek, de ez a tulajdonság nem biztosít külön oldalméretet minden diához.

**Miért nem változtatta meg a jegyzetek tájolásának módosítása a diáimat?**

A jegyzetoldalak és a normál diák méretei függetlenek egymástól. Ha a diák méretét szeretné módosítani, használja a normál dia‑méret beállításait.

**Miért különbözik a mentett vagy nyomtatott eredmény mérete?**

Először nyissa meg újra a mentett prezentációt, és hasonlítsa össze a jegyzetek méreteit. Ha azok megváltoztak, ellenőrizze, hogy egy másik alkalmazás mentése vagy konvertálása megváltoztatta‑e az oldalméretet. Ha nem, vizsgálja meg az export‑elrendezést, a képméret skálát, a megjelenítő beállításait, és a nyomtató papírválasztását.