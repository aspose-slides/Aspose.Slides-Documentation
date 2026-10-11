---
title: Jegyzetoldal méretének és tájolásának módosítása PHP-ben
linktitle: Jegyzetoldal mérete
type: docs
weight: 10
url: /hu/php-java/notes-size/
keywords:
- jegyzetoldal mérete
- jegyzet tájolás
- fekvő jegyzetek
- álló jegyzetek
- kézbesítő mérete
- PowerPoint
- prezentáció
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Olvassa és módosítsa a jegyzetoldal méreteit az Aspose.Slides for PHP Java-on keresztül, cserélje a tájolást, ellenőrizze a mentett méreteket, és exportálja a jegyzeteket vagy kézbesítőket PDF-be és képekbe."
---
## **Áttekintés**

Használja a [Presentation::getNotesSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getnotessize/) függvényt a prezentáció jegyzetoldal beállításainak eléréséhez. Egy [NotesSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notessize/) objektumot ad vissza, amelynek a [setSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notessize/setsize/) metódusa állítja be az oldal méreteit. Bár a beállítási objektumot magát nem lehet lecserélni, új méreteket a metóduson keresztül adhat meg.

Szélességet és magasságot **pont**-ban adják meg, 72 pont hüvelykenként. Például a 900 × 600 pont 12,5 × 8⅓ hüvelyknek felel meg. Ezek a beállítások a teljes prezentációra vonatkoznak, nem egyetlen dia jegyzeteire.

| Beállítás | Cél |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getnotessize/) | A jegyzetoldal méreteit és a kézbesítő exporthoz használt oldal méreteket szabályozza. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getslidesize/) | A szabványos prezentációs diák méreteit szabályozza a [SlideSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesize/). |

Az egyik beállítás módosítása nem változtatja meg automatikusan a másikat. A jegyzetoldal tájolásának megváltoztatása szintén nem forgatja el a szabványos diákat. Lásd a [Slide Size](/slides/hu/php-java/slide-size/) oldalt a szabványos diák átméretezéséhez.

Az alábbi példák egy meglévő `sample.pptx` fájlt használnak. Az export példákhoz olyan prezentációra van szükség, amely legalább egy diához tartalmaz előadói jegyzeteket. Minden példát önállóan futtathat a PHP/Java Bridge és az Aspose.Slides PHP wrapper betöltése után. A Java által visszaadott numerikus értékeket a `java_values` segítségével PHP‑értékekké konvertálják, mielőtt összehasonlítanák vagy számolnák.

## **Olvassa be a jegyzetoldal méretét és tájolását**

Húzza ki a szélességet és a magasságot, és hasonlítsa össze őket a tájolás meghatározásához: a szélesebb oldal fekvő, a magasabb oldal álló, az azonos méretek négyzet alakú oldalt jelölnek. Ez a példa a tényleges méreteket pontban írja ki, anélkül, hogy standard papírméretet feltételezne.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Váltás fekvő módra a papírméret módosítása nélkül**

A tájolás módosításához csak cserélje fel a meglévő szélességet és magasságot. Ez megőrzi az oldalak hosszát, beleértve az egyedi papírméretét is. Az alábbi feltétel megakadályozza, hogy egy már fekvő oldal visszaálljon álló módra, és egy négyzet alakú oldalt változatlanul hagy.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Álló tájolás esetén használja ugyanazt a hozzárendelést, amikor `java_values($size->getWidth()) > java_values($size->getHeight())`. Ne helyettesítse A4 vagy Letter méretekkel, hacsak nem szeretné a papírméretet is módosítani.

## **Egyéni jegyzetoldal méretének beállítása és ellenőrzése**

Rendelje hozzá mindkét dimenziót egyszerre, majd a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/save/) segítségével írja ki a prezentációt. Ez a példa egy 900 × 600 pont méretű fekvő oldalt állít be, PPTX‑ként menti, majd újra megnyitja a mentett fájlt a megőrzött értékek ellenőrzéséhez. Az összehasonlítás 0,01 pont toleranciát enged meg a lebegőpontos értékeknél; ez nem garantálja a pontosságot minden fájlformátum esetén.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

A várt eredmény `900 x 600 points` és `Size preserved: true`. Egy újonnan megnyitott prezentáció ellenőrzése a mentett fájlt verifikálja, nem csak a memóriában lévő beállításokat.

## **Exportálás jegyzetekkel és kézbesítőkkel**

Az oldal méretei határozzák meg a jegyzetek vagy kézbesítők elrendezésének elérhető területét. Magukban nem aktiválják ezeket az elrendezéseket: az exportálási beállításokat is konfigurálni kell. A szabványos dia exportálás továbbra is a dia méreteit használja.

### **Jegyzetek exportálása PDF‑be és PNG‑be**

Rendelje hozzá a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notescommentslayoutingoptions/) objektumot a [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) metódushoz, hogy a PDF tartalmazza a jegyzeteket. Ez a példa az első, jegyzetekkel rendelkező diát PNG‑ként is rendereli a [Slide::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getImage) és a [RenderingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/renderingoptions/) használatával.

A [BottomTruncated](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notespositions/) mód a jegyzeteket egy oldalra helyezi; a nem elférő jegyzeteket levágja. A PDF 900 × 600 pont méretű oldalakat használ. Az alább használt 1 × 1 képmérettel a PNG 900 × 600 pixel lesz. A pontok az oldal geometriáját írják le; a pixelek a raszteres kimenetet, amelynek mérete a renderelési mérettől is függ.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Hosszú jegyzetek PDF exportálásához a [BottomFull](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notespositions/) mód további oldalakat engedélyez, ha szükséges. Ne használja ezt a módot a fentebb felhasznált egyetlen dia képhívásával, amely nem támogatja. Átméretezés után ellenőrizze a kimenetet a levágott jegyzetek és a meglévő notes‑master objektumok elhelyezkedése szempontjából; a csak oldalméretek módosítását nem szabad garanciaként kezelni, hogy minden tartalom elfér. További információért a jegyzetek exportjáról lásd a [Convert PowerPoint to PDF with Notes](/slides/hu/php-java/convert-powerpoint-to-pdf-with-notes/) oldalt.

### **Kézbesítők exportálása PDF‑be**

Egy oldalon több dia bélyegképének elrendezéséhez használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/handoutlayoutingoptions/) objektumot. A következő példa 900 × 600 pont méretű oldalt állít be, és a [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/hu/php-java/aspose.slides/handouttype/) segítségével legfeljebb négy diát rendez el oldalanként. A horizontális előbeállítás szabályozza a diák sorrendjét; az oldal tájolása a szélességéből és magasságából származik.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Az oldal méretének módosítása változtatja a kézbesítő rácsának elérhető területét anélkül, hogy a forrásdiák méreteit megváltoztatná. Kézbesítő képekhez használja a [Presentation::getImages](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getimages/) metódust a kézbesítő elrendezéssel, ahelyett, hogy egyedi dia képmódszert hívna. Az Aspose.Slides-ben a prezentáció‑szintű kézbesítő renderelés a jegyzetoldal méreteit használja, míg az egyedi dia képhívás nem hoz létre kézbesítő oldalt. A [Handout Mode](/slides/hu/php-java/convert-powerpoint-in-handout-mode/) oldalon tekinthet meg elrendezési lehetőségeket.

## **Oldalméret a megjelenítőkben, exportáláskor és nyomtatáskor**

Tartsa külön a tárolt prezentáció méretét, az exportált oldal méretét és a nyomtatott papír méretét:

- **Presentation viewers:** A megjelenítő saját elrendezési szabályai szerint jelenítheti meg vagy nyomtathatja a jegyzeteket. Ha egy másik alkalmazás menti a fájlt, nyissa meg újra, és ellenőrizze újra a méreteket; az alkalmazás formátumkonverziója normalizálhatja őket.
- **Export formats:** A fenti jegyzet- és kézbesítő PDF példák a beállított oldalméreteket használják. A raszteres képek egész pixeles méreteket és renderelési skálát alkalmaznak, ezért a tört pont értékek kerekíthetők a képkimenetben. A szabványos diák exportálása nem alkalmazza a jegyzetoldal méretét.
- **Printer drivers:** A papírválasztás, az automatikus forgatás és a mérethelyhez illesztés beállításai megváltoztathatják a fizikai kimenetet anélkül, hogy a prezentációban vagy PDF‑ben tárolt méreteket módosítanák. Egy adott papírméret esetén egyeztesse a nyomtató beállításait, és ellenőrizze a nyomtatási előnézetet.

## **GYIK**

**Beállíthatom a jegyzet méretét csak egy diához?**

A jegyzetoldal mérete a teljes prezentáció szintű beállítás. Az egyes diák különböző jegyzettartalommal rendelkezhetnek, de ez a tulajdonság nem biztosít külön oldalméretet minden diára.

**Miért nem változott a diák tájolása, amikor a jegyzet tájolását módosítottam?**

A jegyzetoldalak és a szabványos diák méretei függetlenek egymástól. Ha a diák méretét szeretné módosítani, a szabványos dia méret beállításait használja.

**Miért más méretű a mentett vagy nyomtatott eredmény?**

Először nyissa meg újra a mentett prezentációt, és hasonlítsa össze a jegyzet méreteit. Ha azok megváltoztak, ellenőrizze, hogy egy másik alkalmazásban történő mentés vagy konvertálás megváltoztatta-e az oldalbeállításokat. Ha nem, vizsgálja meg az export elrendezését, a kép skáláját, a megjelenítő beállításait és a nyomtató papírválasztását.