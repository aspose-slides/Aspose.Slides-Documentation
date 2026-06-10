---
title: Haladó szövegkinyerés prezentációkból PHP-ben
linktitle: Szöveg kinyerése
type: docs
weight: 90
url: /hu/php-java/extract-text-from-presentation/
keywords:
- szöveg kinyerése
- szöveg kinyerése diáról
- szöveg kinyerése prezentációból
- szöveg kinyerése PowerPointból
- szöveg kinyerése OpenDocumentből
- szöveg kinyerése PPT-ből
- szöveg kinyerése PPTX-ből
- szöveg kinyerése ODP-ből
- szöveg lekérése
- szöveg lekérése diáról
- szöveg lekérése prezentációból
- szöveg lekérése PowerPointból
- szöveg lekérése OpenDocumentből
- szöveg lekérése PPT-ből
- szöveg lekérése PPTX-ből
- szöveg lekérése ODP-ből
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Gyorsan nyerjen ki szöveget PowerPoint és OpenDocument prezentációkból az Aspose.Slides for PHP via Java használatával. Kövesse egyszerű, lépésről-lépésre útmutatónkat, hogy időt takarítson meg."
---
## **Áttekintés**

A prezentációkból szöveg kinyerése gyakori, mégis alapvető feladat a diatartalommal dolgozó fejlesztők számára. Akár Microsoft PowerPoint fájlokkal (PPT vagy PPTX formátumban), akár OpenDocument prezentációkkal (ODP) dolgozol, a szöveges adatok elérése és lekérése kritikus lehet elemzés, automatizálás, indexelés vagy tartalomátvitel céljából.

Ez a cikk átfogó útmutatót nyújt arról, hogyan lehet hatékonyan kinyerni a szöveget különböző prezentációformátumokból, beleértve a PPT, PPTX és ODP formátumokat, az Aspose.Slides for PHP via Java használatával. Megtanulod, hogyan iterálj rendszerszerűen a prezentációelemek között, hogy pontosan a szükséges szövegtartalmat kapd meg.

## **Szöveg kinyerése egy diáról**

Az Aspose.Slides for PHP via Java a [SlideUtil](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideutil/) osztályt biztosítja. Ez az osztály több túlterhelt statikus metódust kínál a prezentáció vagy dia teljes szövegének kinyerésére. Egy diáról való szövegkivonáshoz használd a [getAllTextBoxes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideutil/#getAllTextBoxes) metódust. Ez a metódus egy [BaseSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/) típusú objektumot vesz paraméterként. A futtatás során a metódus bejárja az egész diát szöveg után, és egy [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) típusú objektumok tömbjét adja vissza, megtartva a szövegformázást.

Az alábbi kódrészlet kinyeri a prezentáció első diájának összes szövegét:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Szöveg kinyerése egy prezentációból**

A prezentáció teljes szövegének beolvasásához használd a [SlideUtil](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideutil/) osztály által biztosított [getAllTextFrames](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideutil/#getAllTextFrames) statikus metódust. Két paramétert fogad:

1. Először egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) objektumot, amely egy PowerPoint vagy OpenDocument prezentációt reprezentál, amelyből a szöveget ki kell vonni.
1. Másodszor egy `boolean` értéket, amely jelzi, hogy a mesterdiák is bekerüljenek-e a szöveg beolvasásakor.

A metódus egy [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) típusú objektumok tömbjét adja vissza, beleértve a szövegformázási információkat is. Az alábbi kód beolvassa a szöveget és a formázási részleteket a prezentációból, beleértve a mesterdiákat.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Kategorizált és gyors szövegkinyerés**

A [PresentationFactory](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationfactory/) osztály szintén biztosít metódusokat a prezentációk teljes szövegtartalmának kinyerésére:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

A [TextExtractionArrangingMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textextractionarrangingmode/) enum argumentum határozza meg a szövegkinyerés eredményének rendezési módját, és az alábbi értékek közül választható:
- `Unarranged` – A nyers szöveg a dia helyzetét figyelembe véve nélkül.
- `Arranged` – A szöveg a dián látható sorrendben van elrendezve.

Az `Unarranged` módot akkor érdemes használni, amikor a sebesség kritikus; ez gyorsabb, mint a `Arranged` mód.

A [PresentationText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentationtext/) a prezentációból kinyert nyers szöveget képviseli. A `getSlidesText` metódusa egy objektumtömböt ad vissza, ahol minden objektum a megfelelő dia szövegét tartalmazza. Minden visszaadott objektumnak a következő metódusai vannak:

- `getText` – A dia alakzatain belüli szöveg.
- `getMasterText` – A mesterdia alakzatain belüli szöveg, amely ehhez a diához kapcsolódik.
- `getLayoutText` – A layoutdia alakzatain belüli szöveg, amely ehhez a diához kapcsolódik.
- `getNotesText` – A jegyzetdia alakzatain belüli szöveg, amely ehhez a diához kapcsolódik.
- `getCommentsText` – A diával kapcsolatos megjegyzésekben lévő szöveg.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **GYIK**

**Milyen gyorsan dolgozza fel az Aspose.Slides a nagy prezentációkat szövegkinyerés közben?**

Az Aspose.Slides magas teljesítményre van optimalizálva, és akár [nagy prezentációkat]( /slides/hu/php-java/open-presentation/) is képes feldolgozni, ami alkalmas valós idejű vagy kötegelt feldolgozási forgatókönyvekre.

**Képes-e az Aspose.Slides szöveget kinyerni a táblázatokból és diagramokból a prezentációkban?**

Igen. Az Aspose.Slides képes szöveget kinyerni számos diában lévő elemből, beleértve a táblázatokat és a diagramokhoz kapcsolódó objektumokat, így hozzáférhetsz és elemezheted a szöveges tartalmat a gyakori prezentációs struktúrákban.

**Szükségem van speciális Aspose.Slides licencre a szövegkinyeréshez?**

A szöveget a Aspose.Slides ingyenes próbaverziójával is kinyerheted, bár ez [bizonyos korlátozásokkal]( /slides/hu/php-java/licensing/) jár, például csak korlátozott számú dia feldolgozásával. Korlátlan használathoz és nagyobb prezentációk kezeléséhez a teljes licenc megvásárlása ajánlott.