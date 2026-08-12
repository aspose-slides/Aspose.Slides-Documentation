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
description: "Szöveg keresése, kiemelése és cseréje PowerPoint prezentációkban, miközben minden egyezést gyűjt az Aspose.Slides for PHP via Java használatával."
---
## **Áttekintés**

Aspose.Slides for PHP via Java képes keresni, kiemelni és helyettesíteni a szöveget egy egyedi szövegkeretben vagy egy teljes prezentációban. Minden művelet képes értesíteni az alkalmazást minden egyezésről egy eredmény‑callbacken keresztül. Ez lehetővé teszi a prezentáció frissítését, miközben egy audit‑nyomot épít, amely tartalmazza a megtalált szöveget, annak kontextusát, pozícióját, a szövegkeretet és a dia számát.

Ezek a képességek hasznosak felülvizsgálat, érzékeny adatok eltávolítása, terminológiai ellenőrzések, sablon tisztítás és automatizált jelentéskészítési munkafolyamatok esetén.

Az alábbi első példákban egy „sample.pptx” nevű fájlt használunk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **A keresési hatókör kiválasztása**

Használja a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) módszereit, hogy a műveletet egy szövegkeretre korlátozza. Használja a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) módszereket, hogy a prezentáció összes releváns szövegét feldolgozza.

| Művelet | Egy szövegkeret | Teljes prezentáció |
|---|---|---|
| Literális szöveg kiemelése | [TextFrame::highlightText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#highlightText) |
| Reguláris kifejezés találatainak kiemelése | [TextFrame::highlightRegex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#highlightRegex) |
| Literális szöveg cseréje | [TextFrame::replaceText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#replaceText) |
| Reguláris kifejezés találatainak cseréje | [TextFrame::replaceRegex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#replaceRegex) |

## **Szövegillesztés beállítása**

A literális szövegműveletekhez használja a [TextSearchOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textsearchoptions/)‑t a találatok szabályozásához:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) korlátozza a találatokat teljes szavakra.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) vezérli, hogy a karakterek kis‑ és nagybetűje egyezzen‑e.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) bevonja a diavázlatokat a prezentáció‑szintű keresésbe, cserébe és kiemelésbe.

A reguláris kifejezéseken alapuló műveletek egy Java `Pattern`‑t használnak, így a nagybetű‑érzékenység és a szóhatárok a kifejezésben és annak flagjeiben vannak definiálva.

## **Találatinformációk összegyűjtése callback‑kel**

Adja át egy Java proxy callback‑et egy kiemelési vagy csere metódusnak, hogy minden egyezésről értesítést kapjon. A callback metódus megkapja a kapcsolódó szövegkeretet, a forrás‑szöveget, a megtalált szöveget és a pozíciót.

A callback nem kap közvetlenül diaszámot. Az alábbi megvalósítás a szülő diából származtatja azt, és kezeli a diavázlatokban található szöveget is. Az eredmény‑tömb `null`‑t használ, ha a szöveg egy másik dia‑típussal van összekapcsolva.

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
        $parentSlide = $textFrame->getSlide();
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

Használjon proxyt ezt a PHP objektumhoz, mielőtt átadná egy műveletnek:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

A csere műveleteknél a `foundText` az eredeti megtalált szöveget tartalmazza, így a callback pontosan rögzítheti, mely kifejezéseket cserélték.

## **Szöveg kiemelése**

Használja a [TextFrame::highlightText] metódust a literális szöveg egyezések kiemeléséhez egy szövegkeretben. Adja át a [TextSearchOptions]‑t a keresés vezérléséhez.

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

    // Kiemeli a "try" minden előfordulását a szövegkeretben.
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

    // Kiemeli csak a teljes "to" szót.
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

A [TextFrame::highlightRegex] metódus kiemeli a reguláris kifejezéssel megtalált szöveg egyezéseket egy szövegkeretben.

Az alábbi kód minden, legalább hét karaktert tartalmazó szót kiemel:

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

## **Szöveg kiemelése a teljes prezentációban**

Használja a [Presentation::highlightText] és a [Presentation::highlightRegex] metódusokat a prezentáció összes releváns szövegkeretének kereséséhez. Az alábbi példa egy literális kifejezést és minden e‑mail címet emel ki:

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

Használja a [TextFrame::replaceText] metódust literális szöveghez, és a [TextFrame::replaceRegex] metódust mintára alapozott cseréhez. Ezek a metódusok a megtalált szöveget frissítik a meglévő szövegkereten belül, megőrizve a környező rész formázását, ahelyett, hogy a szövegkeretet egy egyszerű karakterláncból újraépítenék.

Az alábbi példa egységesíti egy helyesírási változatot, majd helyettesíti a verziócímkéket:

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

Ha egy találat különböző formázású részeket fed le, ellenőrizze a kimenetet, hogy melyik formázás legyen alkalmazva a csere szövegre.

## **Szöveg cseréje a teljes prezentációban**

Használja a [Presentation::replaceText] és a [Presentation::replaceRegex] metódusokat azonos műveletek alkalmazásához a teljes prezentációban. Ez hasznos sablon tisztításához, terminológia frissítéséhez és érzékeny adatok eltávolításához.

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

## **Találatok csoportosítása jelentéshez**

Mivel minden eredmény tárolja a dia számát és a szövegkeretet, az alkalmazások csoportosíthatják a találatokat audit, jelentés vagy felülvizsgálati munkafolyamatok céljából. Az alábbi példa először dia, majd szövegkeret szerint csoportosítja a gyűjtött eredményeket:

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

## **GYIK**

**Hogyan kereshetek csak egy szövegdobozban a teljes prezentáció helyett?**

Szerezze meg a alakzat szövegkeretét, és hívja meg a [TextFrame::highlightText], [TextFrame::highlightRegex], [TextFrame::replaceText] vagy [TextFrame::replaceRegex] metódusokat azon a szövegkereten. A prezentáció‑szintű metódusok az összes releváns szövegkeretet dolgozzák fel.

**Hogyan egyeztessek teljes szavakat a helyes nagybetűhasználattal?**

Állítsa a [TextSearchOptions::setWholeWordsOnly] és a [TextSearchOptions::setCaseSensitive] értékét `true`‑ra, és adja át ezeket a lehetőségeket egy literális szöveg kiemelés vagy csere metódusnak. Reguláris kifejezéseknél határozza meg a szóhatárokat és a nagybetűérzékenységet a Java `Pattern`‑ben.

**Tartalmazhatja a keresés és csere a diavázlatok szövegét is?**

Igen. Állítsa a [TextSearchOptions::setIncludeNotes] értékét `true`‑ra, amikor prezentáció‑szintű literális szöveg műveletet használ.

**Hogyan hozhatok létre jelentést anélkül, hogy újra átnézném a prezentációt?**

Adjon át egy Java proxy callback‑et a kiemelési vagy csere műveletnek. A callback a művelet futása közben minden találatot megkap, így az alkalmazás eltárolhatja a forrás‑szöveget, a megtalált szöveget, a pozíciót, a szövegkeretet és a származtatott diaszámot későbbi csoportosításhoz vagy exportáláshoz.

**Megőrzi-e a szöveg cseréje a formázását?**

A [TextFrame::replaceText] és a [TextFrame::replaceRegex] a meglévő szövegkereten belül módosítják a megtalált szöveget, és megőrzik a környező rész formázását. Ha egy találat különböző formázású részeket fed le, ellenőrizze az eredményt, hogy a csere a kívánt stílust alkalmazza.