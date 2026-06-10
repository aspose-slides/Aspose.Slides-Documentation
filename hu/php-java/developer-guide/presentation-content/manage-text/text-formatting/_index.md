---
title: "Prezentáció szövegének formázása PHP-ben"
linktitle: "Szövegformázás"
type: docs
weight: 50
url: /hu/php-java/text-formatting/
keywords:
- szöveg kiemelése
- reguláris kifejezés
- bekezdés igazítása
- szöveg stílusa
- szöveg háttér
- szöveg átlátszósága
- karakterköz
- betűtípus tulajdonságok
- betűtípus család
- szöveg forgatása
- forgatási szög
- szövegdoboz
- sorköz
- automatikus illeszkedés tulajdonság
- szövegdoboz horgony
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Formázza és stilizálja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java használatával. Testreszabhatja a betűtípusok, színek, igazítás és egyéb elemek beállításait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java segítségével. Tárgyalja a kiemelést, háttérszíneket, átlátszóságot, karakterközöket, betűtípus‑tulajdonságokat, forgatást, bekezdésközöket, automatikus méretezést, szöveg‑horgonyozást, tabulátorállásokat és nyelvi beállításokat.

Az alábbi példákban a „sample.pptx” nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **Szöveg kiemelése**

Használja a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)`::highlightText` metódust, ha egy szövegrétegen belül egy adott mintának megfelelő szöveget kell kiemelni. A metódus kiemelés‑színt alkalmaz a megfelelő szövegrészekre, és a [TextHighlightingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/texthighlightingoptions/)‑al szabályozható a keresés módja, például csak teljes szavak egyezése esetén.

Az alábbi kódrészlet kiemeli a **„try”** összes előfordulását, majd csak a teljes **„to”** szót.

```php
$presentation = new Presentation("sample.pptx");
try {
    // Kérje le az első alakzatot az első diáról.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // Emelje ki a "try" szót az alakzatban.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // Emelje ki a "to" szót az alakzatban.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A kiemelt szöveg](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

A [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/)`::highlightRegex` metódus kiemeli a reguláris kifejezéssel megtalált szövegegyezéseket.

Az alábbi kódrészlet kiemeli az összes olyan szót, amely **legalább hét karaktert** tartalmaz:

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Emelje ki a hét vagy annál több karaktert tartalmazó összes szót.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A reguláris kifejezéssel kiemelt szöveg](highlighted_text_using_regex.png)

## **Szöveg háttérszínének beállítása**

Használja a [ParagraphFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/) alapértelmezett portion formátumát a bekezdés alapértelmezett kiemelési színének beállításához, vagy a [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/)‑t egyedi szövegrészekhez.

Az alábbi kódrészlet a **teljes bekezdés** háttérszínét állítja be:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Állítsa be a kiemelés színét a teljes bekezdéshez.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet **félkövér betűvel** írt szövegrészek háttérszínét állítja be:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Állítsa be a kiemelés színét a szövegrészhez.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja a [ParagraphFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/)`::setAlignment` metódust a szövegdobozban lévő bekezdés igazításához. Az érték lehet középre, balra, jobbra, sorkizárva stb.

Az alábbi kódrészlet a bekezdést **középre** igazítja:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Állítsa be a bekezdés igazítását középre.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az igazított bekezdés](aligned_paragraph.png)

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszósága a [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/) kitöltési formátumának alfa komponensén keresztül szabályozható. Az alábbi példákban az `alpha = 50` egy 0‑255 skálájú ARGB alfa‑csatorna érték, nem átlátszósági százalék.

Az alábbi kódrészlet a **teljes bekezdés** átlátszóságát állítja be:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Állítsa be a szöveg kitöltőszínét egy átlátszó színre.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

Az alábbi kódrészlet **félkövér betűvel** írt szövegrészek átlátszóságát állítja be:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Állítsa be a szövegrész átlátszóságát.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karakterköz beállítása a szöveghez**

Használja a [BasePortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/)`::setSpacing` metódust a karakterek közti távolság növelésére vagy csökkentésére egy szövegdobozban.

Az alábbi PHP‑kód a **teljes bekezdés** karakterközét növeli:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Megjegyzés: Negatív értékekkel csökkentheti a karakterközt.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Bővíti a karakterközöt.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet **félkövér betűvel** írt szövegrészek karakterközét növeli:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Megjegyzés: Negatív értékekkel csökkentheti a karakterközt.
            $portion->getPortionFormat()->setSpacing(3); // Bővíti a karakterközöt.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása adott betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg valamivel szorosabbnak tűnhet, mint a PowerPointban megjelenő. Ez akkor fordulhat elő, ha a PowerPoint figyelmen kívül hagyja a kerning adatokat egyes betűtípusoknál, még ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban be van kapcsolva a kerning.

Az ilyen esetekben a kerning letiltásával a szövegrészekre, amelyek az érintett betűtípust használják, a kimenet közelebb kerülhet a PowerPoint megjelenéséhez. Állítsa a [BasePortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` metódust egy a tényleges betűméretnél jóval nagyobb értékre:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ez a beállítás megakadályozza a kerning alkalmazását a megfelelő szövegrészekre, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez igazításában az érintett betűtípusoknál.

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságok beállíthatók a bekezdés szintjén a [ParagraphFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/) alapértelmezett portion formátumán keresztül, vagy egyedi részeknél a [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/)‑on keresztül.

Az alábbi kód a teljes bekezdés betűtípusát és szövegstílusát állítja be: alkalmazza a betűméretet, félkövér, dőlt, pontozott aláhúzást és a Times New Roman betűtípust minden részre a bekezdésben.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // Állítsa be a bekezdés betűtulajdonságait.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A bekezdés betűtípus‑tulajdonságai](font_properties_for_paragraph.png)

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz **félkövér betűvel** írt szövegrészekre:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Állítsa be a szövegrész betűtulajdonságait.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A szövegrészek betűtípus‑tulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatása**

Használja a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` metódust, hogy előre definiált szöveg‑orientációt állítson be egy alakzatban.

Az alábbi kódrészlet a szöveg‑orientációt `Vertical270`‑re állítja, ami **90 fokkal** óramutató járásával ellentétesen forgatja a szöveget:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Egyedi forgatás szövegdobozokhoz**

Használja a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/)`::setRotationAngle` metódust, hogy egyedi forgatási szöget állítson be egy [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) számára.

Az alábbi kódrészlet a szövegdobozt 3 fokkal forgatja az óramutató járásával megegyező irányban az alakzaton belül:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az egyedi szöveg‑forgatás](custom_text_rotation.png)

## **Bekezdések sorközének beállítása**

Az Aspose.Slides a [ParagraphFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`, `ParagraphFormat::setSpaceBefore` és `ParagraphFormat::setSpaceWithin` metódusokkal szabályozza a bekezdés sorközét. Ezeket a következőképpen használhatja:

* Pozitív értékkel a sorköz a sormagasság százalékában adható meg.
* Negatív értékkel a sorköz pontban adható meg.

Az alábbi kódrészlet a bekezdésen belüli sorköz megadását mutatja be:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A bekezdés sorköze](line_spacing.png)

## **Automatikus illeszkedés típusának beállítása szövegdobozokhoz**

A [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/)`::setAutofitType` metódus határozza meg, hogyan viselkedik a szöveg, ha meghaladja a tárolója határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, túlfolyjon vagy automatikusan átméretezze a alakzatot.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Szövegdobozok horgonyának beállítása**

A [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/)`::setAnchoringType` metódus határozza meg, hogyan helyezkedik el a szöveg függőlegesen egy alakzatban, például a tetején, közepén vagy alján.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Szöveg tabulációjának beállítása**

Használja a [ParagraphFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` metódust és a tabulátor‑gyűjteményét a bekezdés tabulátor‑állásainak konfigurálásához.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A bekezdés tabulátorai](paragraph_tabs.png)

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a [BasePortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/)`::setLanguageId` metódusával teszi lehetővé a szövegrész helyesírási nyelvének beállítását. A helyesírási nyelv határozza meg a PowerPointban alkalmazott helyesírás‑ és nyelvhelyességi ellenőrzést.

Az alábbi kódrészlet egy szövegrész helyesírási nyelvét állítja be:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Állítsa be a helyesírási nyelv azonosítóját.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` metódust, hogy meghatározza a prezentáció betöltése vagy létrehozása során létrehozott szöveg alapértelmezett nyelvét.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Új téglalap alakzat hozzáadása szöveggel.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Ellenőrizze az első szövegrész nyelvét.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás prezentációszinten történő alkalmazásához használja a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) alapértelmezett szövegstílusát.

Az alábbi kódrészlet azt mutatja, hogyan állíthat be egy alapértelmezett félkövér betűt 14 pt mérettel az összes dián egy új prezentációban.

```php
$presentation = new Presentation();
try {
    // Szerezze meg a legfelső szintű bekezdésformátumot.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Szöveg kinyerése Caps‑All hatással**

PowerPointban a **All Caps** betűhatás alkalmazása a szöveget nagybetűvel jeleníti meg a dián, még ha azt eredetileg kisbetűvel írták is. Amikor ilyen szövegrészt kér le az Aspose.Slides, a könyvtár pontosan úgy adja vissza, ahogy beírták. A megjelenő szöveghez való igazításhoz ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textcaptype/) értékét, és ha az `All`, akkor konvertálja a visszakapott karakterláncot nagybetűssé.

Tegyük fel, hogy a sample2.pptx első diáján a következő szövegdoboz található.

![A Caps‑All hatás](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerhető ki a **All Caps** hatással rendelkező szöveg:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

Kimenet:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **GYIK**

**Hogyan módosítsunk szöveget egy dián lévő táblázatban?**

A táblázatban lévő szöveg módosításához használja a [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/table/)‑t. Iterálja végig a cellákat, és frissítse minden cellát a [Cell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cell/) szövegdobozának és bekezdésformátumának segítségével a [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) bekezdésformátumán keresztül.

**Hogyan alkalmazzunk fokozatos színt a szövegre PowerPoint dián?**

A fokozatos szín alkalmazásához használja a [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/) kitöltési formátumát. Állítsa a [FillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) kitöltés típusát a [FillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) `Gradient`‑re, és konfigurálja a gradient‑állomásokat, irányt és átlátszóságot.