---
title: Prezentáció szövegformázása PHP-ben
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/php-java/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karakterköz
- betűtulajdonságok
- betűtípuscsalád
- szöveg forgatás
- forgatási szög
- szövegkeret
- sorköz
- automatikus illeszkedés tulajdonság
- szövegkeret rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Formázza és formálja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java segítségével. Testreszabhatja a betűket, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet szöveget formázni PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java használatával. Témakörök: háttérszínek, átlátszóság, karakterköz, betűtulajdonságok, forgatás, bekezdésköz, automatikus illeszkedés viselkedése, szöveg rögzítése, tabulátorok és nyelvi beállítások.

Az alábbi példákban a „sample.pptx” nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezések kereséséhez és kiemeléséhez lásd a [Keresés és csere szöveg](/slides/hu/php-java/search-and-replace-text/) oldalt.

## **Szöveg háttérszínének beállítása**

Használja a [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy a [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#getHighlightColor) metódust az egyes szövegrészekhez.

Az alábbi kódrészlet azt mutatja, hogyan állítható be a háttérszín a **teljes bekezdés** számára:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Állítsa be a kiemelés színét a teljes bekezdéshez.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

A következő kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűtípusú szövegrészek** esetén:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Állítsa be a kiemelés színét a szövegrészhez.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
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

Használja a [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setAlignment) metódust a bekezdés igazításához egy szövegkeretben. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

Az alábbi kódrészlet azt mutatja, hogyan igazítható a bekezdés **középre**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

A szöveg átlátszósága a [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#getFillFormat) által kapott szín alfa komponensén keresztül szabályozható. Az alábbi példákban az `alpha = 50` egy 0–255 skálájú ARGB alfa-csatorna érték, nem pedig átlátszósági százalék.

Az alábbi kódrészlet a **teljes bekezdés** átlátszóságát állítja be:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Állítsa be a szöveg kitöltő színét egy átlátszó színre.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

A következő kódrészlet a **félkövér betűtípusú szövegrészek** átlátszóságát állítja be:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Állítsa be a szövegrész átlátszóságát.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karakterköz beállítása szöveghez**

Használja a [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setSpacing) metódust a karakterek közti térköz növelésére vagy szűkítésére egy szövegdobozban.

Az alábbi PHP kód azt mutatja, hogyan növelhető a karakterköz a **teljes bekezdés** esetén:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Megjegyzés: A karakterköz szorosításához használjon negatív értékeket.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Növelje a karakterközöt.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

A következő kódrészlet a **félkövér betűtípusú szövegrészek** karakterközének növelését mutatja be:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Megjegyzés: A karakterköz szorosításához használjon negatív értékeket.
            $portion->getPortionFormat()->setSpacing(3); // Növelje a karakterközöt.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása egyedi betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPointban megjelenő szöveg. Ennek oka, hogy a PowerPoint bizonyos betűtípusoknál figyelmen kívül hagyja a kerning adatokat, még akkor is, ha a betűtípus tartalmazza a kerning információkat és a PowerPoint beállításaiban a kerning engedélyezve van.

Az ilyen esetekben a betűtípust használó szövegrészeknél letilthatja a kerninget. Állítsa a [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) értékét a tényleges betűmérettől lényegesen nagyobbra:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

Ez a beállítás megakadályozza a kerning alkalmazását a megfelelő szövegrészekre, és segíthet az Aspose.Slides megjelenítését közelebb hozni a PowerPoint vizuális kimenetéhez a PowerPoint-specifikus viselkedést mutató betűtípusok esetén.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) vagy az egyes részeknél a [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/) segítségével.

Az alábbi kód a teljes bekezdés betűtípusát és szövegstílusát állítja be: betűméret, félkövér, dőlt, pontozott aláhúzás és a Times New Roman betűtípus alkalmazása minden részre a bekezdésben.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Állítsa be a bekezdés betűtulajdonságait.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A bekezdés betűtulajdonságai](font_properties_for_paragraph.png)

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz **félkövér betűtípusú szövegrészek** esetén:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Állítsa be a szövegrész betűtulajdonságait.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A szövegrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatásának beállítása**

Használja a [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setTextVerticalType) metódust egy előre definiált szövegorientáció beállításához egy alakzatban.

Az alábbi kódrészlet a szövegorientációt `Vertical270`-re állítja, ami a szöveget **90 fokkal óramutató járásával ellentétesen** forgatja:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Egyedi forgatás beállítása szövegkeretekhez**

Használja a [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setRotationAngle) metódust egy egyedi forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) számára.

Az alábbi kódrészlet a szövegkeretet 3 fokkal óramutató járásával megegyező irányban forgatja az alakzatban:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Az egyedi szöveg forgatás](custom_text_rotation.png)

## **Bekezdések sorközének beállítása**

Az Aspose.Slides a [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setSpaceBefore) és [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setSpaceWithin) metódusokkal szabályozza a bekezdésközöket. Ezeket a tulajdonságokat a következő módon használják:

* Pozitív érték esetén a sorköz a sor magasságának százalékában kerül megadásra.
* Negatív érték esetén a sorköz pontban kerül megadásra.

Az alábbi kódrészlet a bekezdés sorközének megadását mutatja be:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A sorköz a bekezdésben](line_spacing.png)

## **Autofit típus beállítása szövegkeretekhez**

A [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setAutofitType) meghatározza, hogyan viselkedjen a szöveg, ha túllépi a tároló határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, túlcsorduljon vagy automatikusan átméretezze az alakzatot.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A sorok számolásához automatikus sortörés után és a szöveg vagy alakzatszélesség változásának megtekintéséhez lásd a [Renderelt sorok számlálása](/slides/hu/php-java/manage-paragraph/) oldalt. A sorok száma önmagában nem jelzi, hogy a szöveg túllépi-e a tárolót.

## **Szövegkeret rögzítési pontjának beállítása**

A [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setAnchoringType) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzatban, például a tetején, közepén vagy alján.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tabulátorok beállítása szöveghez**

Használja a [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) és a [ParagraphFormat::getTabs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#getTabs) metódusokat a tabulátorok konfigurálásához egy bekezdésben.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

## **Javító nyelv beállítása**

Az Aspose.Slides biztosítja a [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId) metódust, amely lehetővé teszi a javító nyelv beállítását egy szövegrészhez. A javító nyelv határozza meg, hogy a PowerPoint milyen nyelvet használ a helyesírás- és nyelvtani ellenőrzéshez.

Az alábbi kódrészlet a javító nyelv beállítását mutatja egy szövegrészhez:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Állítsa be a javító nyelv azonosítóját.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metódust a prezentáció betöltése vagy létrehozása közben létrehozott szöveg alapértelmezett nyelvének meghatározásához.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjon hozzá egy új négyszög alakzatot szöveggel.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Ellenőrizze az első rész nyelvét.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén használja a [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDefaultTextStyle) metódust.

Az alábbi kódrészlet egy alapértelmezett félkövér betűtípust 14 pt mérettel állít be minden szöveghez az összes dián egy új prezentációban.

```php
$presentation = new Presentation();
try {
    // A felső szintű bekezdésformátum lekérése.
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

## **Szöveg kinyerése all-caps hatással**

PowerPointban az **All Caps** betűhatás alkalmazása azt eredményezi, hogy a szöveg nagybetűvel jelenik meg a dián, még akkor is, ha eredetileg kisbetűvel lett beírva. Amikor ilyen szövegrészt kér le az Aspose.Slides, a könyvtár a beírt szöveget pontosan visszaadja. A megjelenített szöveghez való illesztéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textcaptype/) értékét, és ha az `All`, akkor konvertálja a visszakapott karakterláncot nagybetűssé.

Tegyük fel, hogy a sample2.pptx első diáján a következő szövegdoboz található.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet mutatja, hogyan lehet kinyerni a **All Caps** hatással rendelkező szöveget:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
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

**Hogyan módosítható a szöveg egy táblázatban egy dián?**

A táblázatban lévő szöveg módosításához használja a [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/table/) osztályt. Iterate-áljon a cellákon, és frissítse az egyes cellákat a [Cell::getTextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cell/#getTextFrame) segítségével, valamint a bekezdésformázást a [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getParagraphFormat) metódussal.

**Hogyan alkalmazható színátmenet a szövegre egy PowerPoint dián?**

A színátmenet alkalmazásához használja a [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#getFillFormat) metódust. Állítsa a [FillFormat::setFillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/#setFillType) értékét a [FillType::Gradient](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) módra, és konfigurálja a gradient állomásokat, irányt és átlátszóságot.