---
title: Jegyzetoldal méretének és tájolásának módosítása Java-ban
linktitle: Jegyzetoldal mérete
type: docs
weight: 10
url: /hu/java/notes-size/
keywords:
- jegyzetoldal mérete
- jegyzet tájolás
- fekvő jegyzetek
- álló jegyzetek
- kiosztás mérete
- PowerPoint
- bemutató
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Olvassa és módosítsa a jegyzetoldal méreteit az Aspose.Slides for Java-ban, cserélje a tájolást, ellenőrizze a mentett méreteket, és exportálja a jegyzeteket vagy kiosztásokat PDF-be és képekbe."
---
## **Áttekintés**

Használja a [Presentation.getNotesSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getNotesSize--) metódust a bemutató jegyzetoldal-beállításainak eléréséhez. Ez egy [INotesSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/inotessize/) objektumot ad vissza, amelynek a [setSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) metódusa beállítja az oldal méreteit. Bár a beállítási objektumot magát nem lehet lecserélni, új méreteket a metódus segítségével lehet megadni.

A szélességet és a magasságot **pontban** adják meg, 1 hüvelyk 72 pontot tartalmaz. Például a 900 × 600 pont 12,5 × 8 ⅓ hüvelyknek felel meg. Ezek a beállítások a teljes bemutatóra vonatkoznak, nem egyetlen dia jegyzeteire.

| Beállítás | Cél |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getNotesSize--) | A jegyzetoldal méreteit és a kiosztási exporthoz használt oldal méreteket szabályozza. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlideSize--) | A szokásos bemutatódiák méreteit szabályozza az [ISlideSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidesize/). |

Az egyik beállítás módosítása nem változtatja meg automatikusan a másikat. A jegyzetoldal tájolásának módosítása sem forgatja el a szokásos diákat. Lásd a [Slide Size](/slides/hu/java/slide-size/) útmutatót a szokásos diák átméretezéséhez.

Az alábbi példák egy meglévő `sample.pptx` fájlt használnak. Az exportpéldákhoz olyan bemutatót használjon, amely legalább egy dia hangjegyzeteit tartalmazza. Minden példát külön-külön is futtathat.

## **A jegyzetoldal méretének és tájolásának olvasása**

Olvassa ki a szélességet és a magasságot, és hasonlítsa össze őket a tájolás meghatározásához: a szélesebb oldal tájolású, a magasabb oldal álló, az egyenlő méretek négyzetes oldalt jelölnek. Ez a példa a tényleges méreteket pontban írja ki, anélkül, hogy szabványos papírméretet feltételezne.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
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

## **Tájolás váltása fekvőre a papírméret megváltoztatása nélkül**

A tájolás csak megváltoztatásához cserélje fel a meglévő szélességet és magasságot. Ez megőrzi mindkét oldal hosszát, beleértve az egyedi papírméretét is. Az alábbi feltétel megakadályozza, hogy egy már fekvő oldal vissza legyen állítva állóra, és egy négyzetes oldalt változatlanul hagy.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Álló tájoláshoz használja ugyanazt a hozzárendelést, amikor `size.getWidth() > size.getHeight()`. Ne helyettesítse az A4 vagy Letter méreteket, hacsak nem kívánja a papírméretet is módosítani.

## **Egyéni jegyzetoldal méretének beállítása és ellenőrzése**

Adja meg mindkét dimenziót egyszerre, majd a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódussal mentse a bemutatót. Ez a példa egy 900 × 600 pont méretű fekvő oldalt állít be, PPTX formátumban menti, majd újra megnyitja a mentett fájlt a megőrzött értékek ellenőrzéséhez. Az összehasonlítás 0,01 pont toleranciát enged meg a lebegőpontos értékeknél; ez nem garantálja a pontosságot minden fájlformátum esetén.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
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

A várt eredmény `900.0 x 600.0 points` és `Size preserved: true`. Egy újonnan megnyitott bemutató ellenőrzése a mentett fájlt validálja, nem csak a memóriában lévő beállításokat.

## **Jegyzetek és kiosztások exportálása**

Az oldal méretei határozzák meg a jegyzetek vagy kiosztások elrendezéséhez rendelkezésre álló területet. Maguk nem aktiválják ezeket az elrendezéseket: a exportbeállításokat is konfigurálni kell. A szabványos diaexportálás továbbra is a dia méreteit használja.

### **Jegyzetek exportálása PDF-be és PNG-be**

Rendelje hozzá a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notescommentslayoutingoptions/) objektumot a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) metódushoz, hogy a jegyzetek szerepeljenek a PDF-ben. Ez a példa a jegyzetekkel ellátott első diát PNG-be is rendereli a [Slide.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) és a [RenderingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/renderingoptions/) segítségével.

A [BottomTruncated](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notespositions/) mód a jegyzeteket egy oldalon tartja; a nem elférő jegyzetek levágásra kerülhetnek. A PDF 900 × 600 pont méretű oldalakat használ. Az alább alkalmazott 1 × 1 képméretezésnél a PNG 900 × 600 pixel. A pontok az oldal geometriáját, a pixelek a raszteres kimenetet írják le, melynek méretei a renderelési skálától is függenek.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
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

Hosszú jegyzetek PDF-exportálásához a [BottomFull](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notespositions/) mód további oldalakat biztosít szükség szerint. Ne használja ezt a módot a fent említett egy diás képhívással, amely nem támogatja. Átméretezés után ellenőrizze a kimenetet a levágott jegyzetek és a meglévő notes-master objektumok elhelyezése miatt; az oldalméretek csak módosítása nem garantálja, hogy az összes tartalom elfér. További információért a jegyzetek exportjáról lásd a [Convert PowerPoint to PDF with Notes](/slides/hu/java/convert-powerpoint-to-pdf-with-notes/) oldalt.

### **Kiosztások exportálása PDF-be**

Használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handoutlayoutingoptions/) objektumot több dia bélyegkép egy oldalon való elhelyezéséhez. A következő példa egy 900 × 600 pont méretű oldalt állít be, és a [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handouttype/) segítségével legfeljebb négy diát rendez el egy oldalon. A vízszintes előre beállítás a diák sorrendjét szabályozza; az oldal tájolása a szélességből és magasságból ered.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
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

Az oldalméret módosítása a kiosztási rács rendelkezésre álló területét változtatja meg a forrásdiák méreteinek módosítása nélkül. Kiosztási képekhez használja a [Presentation.getImages](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) metódust a kiosztási elrendezéssel, ahelyett, hogy egyes diák képmetódusát hívná. Az Aspose.Slides esetén a bemutató-szintű kiosztási renderelés a jegyzetoldal méreteit használja, míg az egyes diák képhívása nem hoz létre kiosztási oldalt. A elrendezési lehetőségekhez lásd a [Handout Mode](/slides/hu/java/convert-powerpoint-in-handout-mode/) oldalt.

## **Az oldal mérete nézőkben, exportálásban és nyomtatásban**

Tartsa elkülönítve a tárolt bemutató méretét, az exportált oldal méretét és a nyomtatott papírméretet:

- **Presentation viewers:** Egy megjelenítő saját elrendezési szabályai szerint tudja megjeleníteni vagy nyomtatni a jegyzeteket. Ha egy másik alkalmazás menti a fájlt, nyissa meg újra, és ellenőrizze a méreteket; az alkalmazás formátumkonverziója normalizálhatja azokat.
- **Export formats:** A fenti jegyzet- és kiosztás-PDF példák a beállított oldalméreteket használják. A raszteres képek egész pixelméreteket és renderelési skálát használnak, így a tört pontértékek a képkimenetben kerekíthetők. A szabványos diák exportálása nem alkalmazza a jegyzetoldal méretét.
- **Printer drivers:** A papír kiválasztása, az automatikus forgatás és a méretezés a lapra beállítások megváltoztathatják a fizikai kimenetet anélkül, hogy módosítanák a bemutatóban vagy a PDF-ben tárolt méreteket. Egy adott papírméret esetén egyeztesse a nyomtató beállításait, és ellenőrizze a nyomtatási előnézetet.

## **GYIK**

**Be tudom állítani a jegyzetek méretét csak egy diára?**

A jegyzetoldal mérete a teljes bemutatóra vonatkozó beállítás. Az egyes diák eltérő jegyzet tartalommal rendelkezhetnek, de ez a tulajdonság nem biztosít külön oldalméretet minden egyes diára.

**Miért nem változtatta meg a jegyzetek tájolásának módosítása a diáim tájolását?**

A jegyzetoldalak és a szokásos diák méretei függetlenek egymástól. Használja a szabványos dia méret beállításait, ha magukat a diákat szeretné átméretezni.

**Miért tér el a mentett vagy nyomtatott eredmény mérete?**

Először nyissa meg újra a mentett bemutatót, és hasonlítsa össze a jegyzet méreteit. Ha azok megváltoztak, ellenőrizze, hogy egy másik alkalmazásban történő mentés vagy konvertálás módosította-e az oldalbeállításokat. Ha nem, ellenőrizze az exportelési elrendezést, a képméretezést, a megjelenítő beállításait és a nyomtató papírválasztását.