---
title: Prezentáció szövegének formázása PHP-ben
linktitle: Szöveg formázása
type: docs
weight: 50
url: /hu/php-java/text-formatting/
keywords:
- bekezdés igazítása
- szöveg stílusa
- szöveg háttér
- szöveg átlátszóság
- karakterköz
- betűtípus tulajdonságok
- betűtípus család
- szöveg forgatása
- forgatási szög
- szövegkeret
- sorköz
- automatikus illesztés tulajdonság
- szövegkeret rögzítése
- szöveg tabulációja
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java használatával. Testreszabhatja a betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet szöveget formázni PowerPoint és OpenDocument előadásban az Aspose.Slides for PHP via Java segítségével. Kiterjed a háttérszínekre, átlátszóságra, karakterközökre, betűtípus‑tulajdonságokra, forgatásra, bekezdésközökre, automatikus illesztés viselkedésére, szöveg rögzítésére, tabulátorhelyekre és nyelvi beállításokra.

Ha nincs másként jelölve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dia első alakzatán egy szövegdoboz található, és az első bekezdése tartalmazza az alább látható szöveget. Mind a dia, mind az alakzat indexe nullától indul. A félkövér részeket kiválasztó példák hatékony formázást alkalmaznak, beleértve az örökölt félkövér formázást:

![Sample text](sample_text.png)

A szövegrészletek vagy reguláris kifejezések kereséséhez és kiemeléséhez lásd a [Search and Replace Text](/slides/hu/php-java/search-and-replace-text/) oldalt.

## **Szöveg háttérszínének beállítása**

Használd a [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy a [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#getHighlightColor) metódust az egyes szövegrészekhez.

Az alábbi példa világosszürke kiemelést állít be az első bekezdés alapértelmezettként. Az egyes részeken megadott explicit kiemelési színek felülbírálják ezt az alapértelmezést:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Állítsa be az egész bekezdés kiemelési színét.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The gray paragraph](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűkkel** rendelkező **szövegrészek** számára:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Állítsa be a szövegrész kiemelési színét.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The gray text portions](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használd a [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setAlignment) metódust a bekezdés igazításának beállításához egy szövegkeretben. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

Az alábbi kódrészlet megmutatja, hogyan igazítható a bekezdés **középre**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

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

![The aligned paragraph](aligned_paragraph.png)

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszósága a [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#getFillFormat) színének alfa komponensén keresztül szabályozható. Az alábbi példákban a `alpha = 50` egy ARGB alfa‑csatorna érték a 0–255 tartományban, nem átlátszósági százalék.

Az alábbi kódrészlet megmutatja, hogyan alkalmazz átlátszóságot a **teljes bekezdés**re:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Állítsa be a szöveg kitöltőszínét átlácszó színre.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The transparent paragraph](transparent_paragraph.png)

Az alábbi kódrészlet megmutatja, hogyan alkalmazz átlátszóságot **félkövér betűkkel** rendelkező **szövegrészek**re:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

![The transparent text portions](transparent_text_portions.png)

## **Karakterköz beállítása a szöveghez**

Használd a [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setSpacing) metódust a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; negatív érték szorosabb szöveget eredményez.

Az alábbi PHP kód megmutatja, hogyan növelhető a karakterköz **az egész bekezdésben**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Megjegyzés: A negatív értékekkel a karakterköz összenyomható.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // A karakterköz növelése.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Az alábbi kódrészlet megmutatja, hogyan növelhető a karakterköz **félkövér betűkkel** rendelkező **szövegrészek**ben:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Megjegyzés: A karakterköz összenyomásához negatív értékeket kell használni.
            $portion->getPortionFormat()->setSpacing(3); // A karakterköz növelése.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által megjelenített szöveg valamivel szorosabb lehet, mint a PowerPointban megjelenő szöveg. Ennek oka lehet, hogy a PowerPoint figyelmen kívül hagyja a kerning adatokat bizonyos betűtípusoknál, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban a kerning engedélyezve van.

Az ilyen esetekben a kerning letiltásával a szövegrészeknél, amelyek az érintett betűtípust használják, a kimenet közelebb hozható a PowerPoint megjelenítéséhez. Állítsd a [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) értékét a tényleges betűméretnél nagyobbra. Ez a példa a "presentation.pptx"-t igényli, amelynek első diáján az első alakzat egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be a Roboto-t használó részekhez. Ez letiltja a kerninget a 100 pont alatti betűmérettel rendelkező megfelelõ részeknél:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A küszöb alatti egyező szöveg esetében ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides megjelenítésének a PowerPoint vizuális kimenetéhez való igazításában az érintett betűtípusoknál.

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságok beállíthatók a bekezdés szintjén a [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) segítségével, vagy egyes részekre a [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/) segítségével.

Az alábbi példa beállítja az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-ra, félkövér, dőlt és pontozott aláhúzással. Az egyes részeken megadott explicit formázás felülbírálja ezeket az alapértelmezéseket:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

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

![The font properties for the paragraph](font_properties_for_paragraph.png)

Az alábbi példa 13 pontos Times New Roman, dőlt formázás és pontozott aláhúzás alkalmazását mutatja azokra a részekre, amelyek hatékony formázása félkövér:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Szöveg forgatása**

Használd a [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setTextVerticalType) metódust a szöveg előre definiált orientációjának beállításához egy alakzatban.

Az alábbi kódrészlet a szöveg orientációját a [TextVerticalType::Vertical270](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal óramutató járásával ellentétesen** forgatja a szöveget:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

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

![The text rotation](text_rotation.png)

## **Egyéni forgatás beállítása szövegkeretekhez**

Használd a [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setRotationAngle) metódust egy egyéni forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) számára.

Az alábbi kódrészlet a szövegkeretet 3 fokkal forgatja az alakzaton belül az óramutató járásával megegyező irányba:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![The custom text rotation](custom_text_rotation.png)

## **Bekezdés sorközének beállítása**

Az Aspose.Slides a [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setSpaceBefore) és [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setSpaceWithin) metódusokkal szabályozza a bekezdésközöket. Ezeket a tulajdonságokat a következőképpen használhatod:

* Pozitív érték: a sorköz a sormagasság százalékában legyen megadva.
* Negatív érték: a sorköz pontokban legyen megadva.

Az alábbi példa a első bekezdés sorközét a sormagasság **200%-ára** (dupla sorköz) állítja:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![The line spacing within the paragraph](line_spacing.png)

## **Sorok törésének szabályozása**

A bekezdés sorbontási szabályok szűk szövegdobozokban és kevert latin‑kelet-ázsiai szövegeket tartalmazó előadásokban hasznosak. Az alábbi módszerek a [ParagraphFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/) részei, ezért egy teljes bekezdésre vonatkoznak:

- [setLatinLineBreak](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) szabályozza a latin sorbontási szabályokat. Vegyes szöveg esetén ennek módosítása a kelet‑ázsiai szöveg és írásjelek megtörését is befolyásolhatja.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) szabályozza a kelet‑ázsiai sorbontási szabályokat, beleértve a sor elején és végén lévő karakterek korlátozását.

Ezek a szabályok nem helyettesítik a [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setWrapText) metódust, amely automatikus sortörést engedélyez egy szövegkereten belül. A szabályok a sortöréskor a elrendezést befolyásolják; nem illesztenek be sortörés karaktert. Egy explicit sortörés új sort hoz létre a bekezdésben a rendelkezésre álló szélességtől függetlenül.

Az alábbi önálló példa egy szűk szövegdobozt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sorbontási opciót explicit módon beállítja, és a "line_breaking.pptx"-t menti. A szabályok kipróbálásához módosítsd a megfelelő értéket, miközben a másik beállítást változatlanul hagyod. A példa 24 pontos Arial és SimSun betűket, 160 pontos keretszélességet és 0 vízszintes szövegkeret‑margót használ. A [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setAutofitType) metódus a [TextAutofitType::None](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textautofittype/) értékkel van hívva, hogy a szöveg mérete és a keret dimenziói rögzítve maradjanak:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Függőleges írásjelek kezelése**

A [ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) lehetővé teszi, hogy a jogosult írásjelek a szövegsor jobb szélén túlnyúljanak ahelyett, hogy a következő sorba kerülnek. Ez a beállítás az egész bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa bekapcsolja a függőleges írásjeleket egy 100 pont széles szövegkeretben, és a "hanging_punctuation.pptx"-t menti. 24 pontos Arial és 0 vízszintes szövegkeret‑margó esetén a végző pont a "sentence" szó után marad, és túlnyúlik a jobb szövegszélen. Állítsd a tulajdonságot a [NullableBool::False](https://reference.aspose.com/slides/hu/php-java/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ebben az esetben a pont külön sorba kerül. A sortörés engedélyezett, az automatikus illesztés letiltott, hogy a rendelkezésre álló szélesség rögzítve legyen.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nem minden írásjel függhet. A látható eredmény a betűtípus elérhetőségétől és az elrendezéstől függ: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés beállításainak módosítása eltüntetheti a látható különbséget.

## **Szövegkeretek automatikus illesztés típusának beállítása**

A [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setAutofitType) határozza meg, hogy a szöveg hogyan viselkedik, ha túllépi a tárolója határait. Ezzel szabályozhatod, hogy a szöveg zsugorodjon, túlcsorduljon vagy a forma automatikusan átméreteződjön. Az alábbi példa úgy konfigurálja a formát, hogy a szöveghez illeszkedjen, és a "autofit_type.pptx" fájlba menti az eredményt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

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

A sorok számolásához automatikus sortörés után, illetve a szöveg vagy a forma szélességének hatása megtekintéséhez lásd a [Count Rendered Lines](/slides/hu/php-java/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg túlcsordul‑e a tárolójából.

## **Szövegkeretek rögzítésének beállítása**

A [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setAnchoringType) határozza meg, hogy a szöveg függőlegesen hol helyezkedjen el egy formában, például felül, középen vagy alul. Az alábbi példa a szöveget az első alakzat aljára rögzíti, és a "text_anchor.pptx" fájlba menti az eredményt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

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

## **Szöveg tabulációjának beállítása**

Használd a [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) és a [ParagraphFormat::getTabs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/#getTabs) metódusokat a bekezdés tabulátorhelyeinek konfigurálásához. Az alábbi példa az alapértelmezett tabulátortávolságot 100 pontra állítja, és egy balra igazított tabulátort helyez el 30 pontnál. Ezek a beállítások a tabulátor karaktert tartalmazó szövegre hatnak.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

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

![The paragraph tabs](paragraph_tabs.png)

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setLanguageId) metódussal lehetővé teszi a helyesírási nyelv beállítását egy szövegrészhez. A helyesírási nyelv határozza meg, hogy a PowerPoint milyen nyelvet használ a helyesírás‑ és nyelvtani ellenőrzéshez.

Az alábbi példa a "presentation.pptx" fájlt igényli, amelynek első diáján az első alakzat egy szövegdoboz, és legalább egy bekezdést tartalmaz. Az első bekezdés tartalmát "1。"‑re cseréli, a betűtípust SimSun-ra állítja, és a Simplified Chinese (`zh-CN`) helyesírási nyelvet rendeli hozzá. Az eredményt "proofing_language.pptx"-ként menti:

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

    // Állítsa be a helyesírási nyelv azonosítóját.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Használd a [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metódust az alapértelmezett nyelv meghatározásához a betöltés vagy létrehozás során létrehozott szövegre. Az alábbi példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelvként az amerikai angolt (`en-US`) állítja be, hozzáad egy szövegdobozt, és az első szövegrész nyelvét `en-US`‑nek nyomtatja.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Adjunk hozzá egy új téglalap alakzatot szöveggel.
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

Az alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén használd a [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDefaultTextStyle) metódust.

Az alábbi példa egy 14 pontos félkövér betűtípust állít be az új prezentáció felső szintű bekezdéseihez, majd a "default_text_style.pptx" fájlba menti. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak nincs specifikusabb formázás, amely felülírja őket.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // A legfelső szintű bekezdésformátum lekérése.
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

## **Szöveg kinyerése az „All Caps” hatással**

PowerPointban az **All Caps** betűhatás alkalmazásával a szöveg nagybetűsnek jelenik meg a dián, még akkor is, ha eredetileg kisbetűkkel lett beírva. Amikor az Aspose.Slides-lel ilyen szövegrészt kérdezünk le, a könyvtár pontosan úgy adja vissza a szöveget, ahogy be lett gépelve. A megjelenített szöveghez való igazításhoz ellenőrizd a [TextCapType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textcaptype/) értékét, és ha `All`, akkor a visszakapott karakterláncot alakítsd nagybetűssé.

Ez a példa a "sample2.pptx" fájlt igényli, amelynek első diáján az első alakzat egy szövegdoboz. Az első bekezdés első része tartalmazza a „Hello, Aspose!” szöveget, amelyre az All Caps hatás alkalmazva van, ahogy az alább látható.

![The All Caps effect](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan nyerhető ki a szöveg az **All Caps** hatással:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

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

**Hogyan módosíthatok szöveget egy táblázatban egy dián?**

A szöveg módosításához egy táblázatban egy dián használd a [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/table/) osztályt. Iterálj a cellákon, és frissítsd őket a [Cell::getTextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cell/#getTextFrame) segítségével, valamint a bekezdés formázását a [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/#getParagraphFormat) segítségével.

**Hogyan tudok színátmenetes színt alkalmazni szövegre egy PowerPoint dián?**

A színátmenetes szín alkalmazásához használd a [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#getFillFormat) metódust. Állítsd a [FillFormat::setFillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/#setFillType) értékét a [FillType::Gradient](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filltype/) típusra, és konfiguráld a gradient‑állomásokat, irányt és átlátszóságot.