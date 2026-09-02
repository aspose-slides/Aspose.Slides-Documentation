---
title: Szöveg keresése és cseréje PowerPoint prezentációkban PHP-ben
linktitle: Szöveg keresése és cseréje
type: docs
weight: 55
url: /hu/php-java/search-and-replace-text/
keywords:
- szöveg keresése
- szöveg kiemelése
- szöveg cseréje
- reguláris kifejezés
- eredmény visszahívás
- szövegkeret
- audit jelentés
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Keresés, kiemelés és szöveg cseréje PowerPoint prezentációkban, miközben minden egyezést rögzít az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java képes keresni, kiemelni és helyettesíteni a szöveget egyetlen szövegkeretben vagy az egész bemutatóban. Minden művelet értesítheti az alkalmazást minden egyezésről egy eredmény‑visszahíváson keresztül. Ez lehetővé teszi a bemutató frissítését és egyúttal egy auditnyomvonal létrehozását, amely tartalmazza a talált szöveget, annak környezetét, pozícióját, szövegkeretét és a dia számát.

Ezek a képességek hasznosak felülvizsgálathoz, sötétításhoz, terminológiai ellenőrzésekhez, sablon tisztításhoz és automatizált jelentéskészítési munkafolyamatokhoz.

Az alábbi első példákban a "sample.pptx" nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **A keresési hatókör kiválasztása**

Használja a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) metódusait egy művelet egy szövegkeretre korlátozásához. Használja a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) metódusait a bemutatóban minden vonatkozó szöveg feldolgozásához.

| Művelet | Egy szövegkeret | Teljes bemutató |
|---|---|---|
| Szó szerinti szöveg kiemelése | [TextFrame::highlightText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#highlightText) |
| Reguláris kifejezésnek megfelelő egyezések kiemelése | [TextFrame::highlightRegex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#highlightRegex) |
| Szó szerinti szöveg cseréje | [TextFrame::replaceText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#replaceText) |
| Reguláris kifejezés egyezéseinek cseréje | [TextFrame::replaceRegex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#replaceRegex) |

## **A szövegillesztés beállítása**

Szó szerinti szöveg műveleteknél a [TextSearchOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textsearchoptions/) segítségével szabályozhatja az egyezést:

- A [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) csak teljes szavakra korlátozza az egyezéseket.
- A [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) szabályozza, hogy a karakterek esetérzékenysége kötelező-e.
- A [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) a diá jegyzeteket is belefoglalja a bemutató szintű keresésbe, csere‑ és kiemelési műveletekbe.

A reguláris kifejezésekkel végzett műveletek Java `Pattern`‑t használnak, ezért az olyan egyezési szabályok, mint az esetérzékenység és a szóhatárok, a kifejezés és annak jelzői által vannak meghatározva.

## **A szövegkeret tulajdonosának azonosítása**

Az általános szövegfeldolgozó munkafolyamatok gyakran kapnak egy [TextFrame]‑et a szöveg keresése, cseréje, ellenőrzése vagy exportálása során. Használja a [TextFrame::getParentShape] és a [TextFrame::getParentCell] metódusokat annak meghatározására, hogy melyik bemutatóobjektum birtokolja a szövegkeretet.

A várt értékek a tulajdonostól függenek:

| Szövegkeret tulajdonosa | `getParentShape` | `getParentCell` |
|---|---|---|
| Egy AutoShape vagy egy másik szöveget tartalmazó alakzat | A tulajdonos [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) | `null` |
| Egy táblázatcell | `null` | A tulajdonos [Cell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cell/) |

Mindkét metódus csak olvasási navigációt biztosít. Meghívásuk nem mozgatja a szövegkeretet, és nem változtatja meg a tulajdonost. Az általános kódnak `java_is_null`‑al kell ellenőriznie mindkét értéket, és kezelnie kell azt az esetet, amikor egyik tulajdonos sem érhető el.

Az alábbi példa a [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideutil/#getAllTextFrames)‑t használja a bemutató szövegkereteinek bejárásához. Alakzatok esetén jelentést készít az alakzat nevéről, a Java futásidejű típusáról és a tartalmazó diáról. Táblázatcellák esetén a nullától induló oszlop- és sorkoordinátákat, valamint a tartalmazó diát jelzi.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

SmartArt tartalom esetén járja be az alakzatokat a [SmartArtNode::getShapes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartnode/#getShapes)‑ban, és érje el minden [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartartshape/#getTextFrame)‑et. A szövegkeret az [TextFrame::getParentShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParentShape) segítségével visszakövethető a kapcsolódó alakzatra, míg a [TextFrame::getParentCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParentCell) `null`‑t ad vissza. Ezért a példában a alakzat ágazat szintén kezeli a SmartArt csomópontok szövegét.

## **Egyezésinformációk gyűjtése visszahívással**

Adjon át egy Java proxy visszahívást egy kiemelés vagy csere metódusnak, hogy minden egyezésről értesítést kapjon. A visszahívás a kapcsolódó szövegkeretet, a forrásszöveget, a megtalált szöveget és az egyezés pozícióját kapja.

A visszahívás nem kap közvetlenül diá számot. Az alábbi megvalósítás a szülő diához kapcsolja, és kezeli a diá jegyzetekben talált szöveget is. Az eredmény tömb `null`‑t használ, ha a szöveg egy másik diatípushoz tartozik.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

Hozzon létre egy proxy-t ehhez a PHP objektumhoz, mielőtt átadná egy műveletnek:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Csere műveleteknél a `foundText` tartalmazza az eredeti megtalált szöveget, így a visszahívás pontosan rögzítheti, mely kifejezéseket cserélték.

## **Szöveg kiemelése**

Használja a [TextFrame::highlightText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#highlightText) metódust a szó szerinti szöveg egyezéseinek kiemeléséhez egy szövegkeretben. Adja át a [TextSearchOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textsearchoptions/)‑t a keresés szabályozásához.

Az alábbi kódrészlet kiemeli a **"try"** karakterek minden előfordulását, majd csak a teljes **"to"** szót emeli ki.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // Emelje ki a "try" szó minden előfordulását a szövegkeretben.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // Emelje ki csak a teljes "to" szót.
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Az eredmény:

![A kiemelt szöveg](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

A [TextFrame::highlightRegex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#highlightRegex) metódus kiemeli a szövegkeretben egy reguláris kifejezés által megtalált egyezéseket.

Az alábbi kód kiemeli a hét vagy több karaktert tartalmazó összes szót:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Az eredmény:

![A reguláris kifejezéssel kiemelt szöveg](highlighted_text_using_regex.png)

## **Szöveg kiemelése a teljes bemutatóban**

Használja a [Presentation::highlightText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#highlightText) és a [Presentation::highlightRegex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#highlightRegex) metódusokat a bemutató összes alkalmazható szövegkeretének kereséséhez. Az alábbi példa kiemeli egy szó szerinti kifejezést és minden e‑mail címet:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Szöveg cseréje egy szövegkeretben**

Használja a [TextFrame::replaceText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#replaceText)‑t szó szerinti szöveghez, és a [TextFrame::replaceRegex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#replaceRegex)‑t minta alapú cserehez. Ezek a metódusok a meglévő szövegkereten belül frissítik a megtalált szöveget, megőrizve a környező rész formázását, ahelyett, hogy egy egyszerű karakterláncból újjáépítenék a keretet.

Az alábbi példa egységesíti egy helyesírási variánst, majd cseréli a verziócímkéket:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Ha egy egyezés különböző formázású részeket foglal magába, ellenőrizze a kimenetet, hogy melyik formázás legyen alkalmazva a cserélt szövegre.

## **Szöveg cseréje a teljes bemutatóban**

Használja a [Presentation::replaceText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#replaceText) és a [Presentation::replaceRegex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#replaceRegex) metódusokat a bemutató egészére történő azonos műveletekhez. Ez hasznos sablon tisztításhoz, terminológiai frissítésekhez és sötétítéshez.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Egyezések csoportosítása jelentéshez**

Mivel minden eredmény tárolja a diá számát és a szövegkeretet, az alkalmazások csoportosíthatják az egyezéseket audit, jelentés vagy felülvizsgálati munkafolyamatok céljából. Az alábbi példa először diánként, majd szövegkeretenként csoportosítja a gyűjtött eredményeket:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **FAQ**

**Hogyan kereshetek csak egy szövegdobozban a teljes bemutató helyett?**

Szerezze meg az alakzat szövegkeretét, és hívja meg a [TextFrame::highlightText], [TextFrame::highlightRegex], [TextFrame::replaceText] vagy a [TextFrame::replaceRegex] metódusokat azon a szövegkereten. A bemutató‑szintű metódusok helyette az összes alkalmazható szövegkeretet dolgozzák fel.

**Hogyan egyeztessek teljes szavakat a megfelelő nagybetűkkel?**

Állítsa a [TextSearchOptions::setWholeWordsOnly] és a [TextSearchOptions::setCaseSensitive] értékét `true`‑ra, és adja át a beállításokat egy szó szerinti szöveg kiemelés vagy csere metódusnak. Reguláris kifejezéseknél határozza meg a szóhatárokat és az esetérzékenységet a Java `Pattern`‑ben.

**A keresés és csere magában foglalhatja a diá jegyzetek szövegét is?**

Igen. Állítsa a [TextSearchOptions::setIncludeNotes] értékét `true`‑ra, amikor bemutató‑szintű szó szerinti szöveg műveletet használ.

**Hogyan készítsek jelentést anélkül, hogy a bemutatót másodszor átnézném?**

Adjon át egy Java proxy visszahívást a kiemelés vagy csere művelethez. A visszahívás a művelet futása közben minden egyezést megkap, így az alkalmazás elmentheti a forrásszöveget, a megtalált szöveget, a pozíciót, a szövegkeretet és a származtatott diá számot későbbi csoportosításhoz vagy exportáláshoz.

**Megőrzi-e a szöveg csere a formázását?**

A [TextFrame::replaceText] és a [TextFrame::replaceRegex] a meglévő szövegkereten belül módosítják a megtalált szöveget, és megtartják a környező rész formázását. Ha egy egyezés különböző formázású részeket ölel fel, ellenőrizze a eredményt, hogy a csere a kívánt stílust használja.