---
title: Prezentáció szöveg formázása PHP-ben
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
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegkeret
- sortávolság
- automatikus méretezés tulajdonság
- szövegkeret rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Formázza és stilizálja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java segítségével. Testreszabhatja a betűket, színeket, igazításokat és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet formázni a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java használatával. A háttérszíneket, átlátszóságot, karakterközöket, betűtulajdonságokat, forgatást, bekezdésközöket, automatikus méretezési viselkedést, szöveg rögzítését, tabulátor pozíciókat és nyelvi beállításokat tárgyalja.

Ha nincs eltérően megadva, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzat egy szövegdoboz, és az első bekezdés tartalmazza az alább látható szöveget. Mind a dia, mind az alakzat indexelése nullától indul. A félkövér részeket kiválasztó példák hatékony formázást használnak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

A szöveges vagy reguláris kifejezés egyezések megtalálásához és kiemeléséhez lásd a [Keresés és csere szöveg](/slides/hu/php-java/search-and-replace-text/) oldalt.

## **Állítsa be a szöveg háttérszínét**

Használja a [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) a bekezdés alapértelmezett kiemelési színének beállításához, vagy használja a [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) az egyedi szövegrészekhez.

Az alábbi példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részeken megadott kiemelési színek felülírják ezt az alapértelmezést:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Állítsa be az egész bekezdés kiemelés színét.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűtípussal rendelkező szövegrészek** számára:

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
            // Állítsa be a szövegrész kiemelés színét.
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

Használja a [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) a bekezdés igazításának beállításához egy szövegkeretben. Az érték lehet középre, balra, jobbra, sorkizárt stb.

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

![Az igazított bekezdés](aligned_paragraph.png)

## **Betűk igazítása soron belül**

Használja a [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) a soron belül különböző betűméretű szövegrészek függőleges igazításához. Ez a beállítás az egész bekezdésre vonatkozik, és a sorokon belüli igazítást szabályozza.

Az alábbi önálló példa négy feliratos szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontban, különböző betűigazítással. Arial betűtípust használ, letiltja az automatikus méretezést és a sortörést, és a szövegkereteket elég nagyra állítja egy sorhoz.

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![Baseline, Top, Center és Bottom betűigazítás vegyes betűméretekkel](font_alignment.png)

Az betűigazítás a betűmetrikákat használja, ezért az egyes betűk látható szélei nem feltétlenül esnek pontosan egybe. A példa tartalmaz egy nagybetűt és egy lejjebb nyúló betűt, hogy megmutassa a baseline és bottom igazítás közti különbséget. A betűtípusok elérhetősége és helyettesítése, a használt karakterek és a betűméretek közti különbség befolyásolja az eredményt. A keret méretei, margók, sortávolság, sortörés és automatikus méretezés is hat a elrendezésre; az összehasonlításkor használja ugyanazokat a betűtípusokat és elrendezési beállításokat.

Ez a beállítás különbözik a [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment), amely a horizontális bekezdésigazítást szabályozza, és a [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType), amely a szövegtömböt függőlegesen helyezi el az alakzatban. A felső és alsó index formázás a [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) segítségével az egyes részeket a baseline-hoz képest eltolja, ahelyett, hogy a bekezdés sorainak betűigazítását állítaná be.

## **Átlátszóság beállítása a szöveghez**

A szöveg átlátszóságát a [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) által használt szín alfa komponensével szabályozzák. Az alábbi példákban az `alpha = 50` egy ARGB alfa csatorna érték a 0–255 skálán, nem pedig átlátszósági százalék.

Az alábbi kódrészlet megmutatja, hogyan alkalmazzon átlátszóságot a **teljes bekezdésre**:

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

    // Állítsa be a szöveg kitöltés színét átlátszó színre.
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

Az alábbi kódrészlet megmutatja, hogyan alkalmazzon átlátszóságot **félkövér betűtípussal rendelkező szövegrészek** számára:

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

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karakterköz beállítása a szöveghez**

Használja a [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) a karakterek közötti távolság növeléséhez vagy csökkentéséhez egy szövegdobozban. A példák 3 ponttal növelik a távolságot; a negatív értékek összesűrítik a szöveget.

Az alábbi PHP kód megmutatja, hogyan növelhető a karakterköz a **teljes bekezdésben**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Megjegyzés: Negatív értékek használata a karakterköz összesűrítéséhez.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Kiterjeszti a karakterközt.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet megmutatja, hogyan növelhető a karakterköz **félkövér betűtípussal rendelkező szövegrészekben**:

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
            // Megjegyzés: Negatív értékek használata a karakterköz összesűrítéséhez.
            $portion->getPortionFormat()->setSpacing(3); // Kiterjeszti a karakterközt.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása specifikus betűtípusokhoz**

Néhány esetben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPoint-ban megjelenített szöveg. Ez akkor fordulhat elő, ha a PowerPoint bizonyos betűtípusok esetén figyelmen kívül hagyja a kerning adatokat, még ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban a kerning engedélyezve is van.

Az ilyen esetekben a renderelt kimenet PowerPoint-hoz való közelebb hozása érdekében letilthatja a kerninget azokban a szövegrészekben, amelyek a szóban forgó betűtípust használják. Állítsa be a [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) értékét a tényleges betűméretnél nagyobbra. Ez a példa a "presentation.pptx" fájlt igényli, amelynek az első diáján az első alakzat egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűtípusokat, és 100 pontos küszöböt állít be azoknál a részeknél, amelyek a Roboto-t használják. Ez letiltja a kerninget azoknál a részeknél, amelyek betűmérete 100 pont alatt van:

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

A küszöb alatti egyező szövegnél ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelését a PowerPoint vizuális kimenetéhez igazítani azon betűtípusok esetén, amelyekre ez a PowerPoint-specifikus viselkedés hatással van.

## **Szöveg betű tulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) vagy egyedi részekre a [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) segítségével.

Az alábbi példa az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-ra állítja félkövér, dőlt és pontozott aláhúzással. Az egyes részeken megadott formázás felülírja ezeket az alapértelmezéseket.

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

![A bekezdés betűtulajdonságai](font_properties_for_paragraph.png)

Az alábbi példa 13 pontos Times New Roman, dőlt formázás és pontozott aláhúzás alkalmazását mutatja be azokban a részekben, amelyek hatékony formázása félkövér:

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

![A szövegrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatás beállítása**

Használja a [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) egy forma belsejében definiált szövegorientáció beállításához.

Az alábbi kódrészlet a szövegorientációt a formában a [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal balra** forgatja a szöveget:

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

![A szöveg forgatás](text_rotation.png)

## **Egyedi forgatás beállítása szövegkeretekhez**

Használja a [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) egyedi forgásszög beállításához egy [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) számára.

Az alábbi kódrészlet a szövegkeretet 3 fokkal óramutató járásával megegyező irányban forgatja a formában:

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

![Az egyedi szöveg forgatás](custom_text_rotation.png)

## **Bekezdés sortávolság beállítása**

Az Aspose.Slides a [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), a [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) és a [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) metódusokkal biztosítja a bekezdésköz szabályozását. Ezeket a tulajdonságokat a következőképpen használják:

* Pozitív értéket használjon a sortávolság sormagasság százalékában való megadásához.
* Negatív értéket használjon a sortávolság pontokban való megadásához.

Az alábbi példa az első bekezdésen belüli távolságot a sormagasság 200%-ára (dupla sortávolság) állítja:

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

![A sortávolság a bekezdésen belül](line_spacing.png)

## **Sortörés szabályozása**

A bekezdés sortörési szabályai szűk szövegdobozokban és latin és kelet-ázsiai szöveget keverő prezentációkban hasznosak. A következő metódusok a [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) részei, ezért egy teljes bekezdésre érvényesek:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) szabályozza a latin sortörési szabályokat. Vegyes szövegben a módosítása megváltoztathatja, hogy a szomszédos kelet-ázsiai szöveg és írásjelek hol törnek.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) szabályozza a kelet-ázsiai sortörési szabályokat, beleértve a sor elején és végén állhat karakterek korlátozását.

Ezek a szabályok nem helyettesítik a [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) funkciót, amely automatikus sortörést engedélyez egy szövegkereten belül. A layoutot befolyásolják, amikor sortörés történik; nem szúrnak be sortörés karaktereket. Egy explicit sortörés új sort hoz létre a bekezdésen belül függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy szűk szövegdobozt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési opciót explicit módon beállítja, és elmenti a "line_breaking.pptx" fájlt. A szabályok kipróbálásához módosítsa a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial és SimSun betűtípust használ 160 pontos keretszélességgel és nulla vízszintes szövegkeret margóval. A [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) a [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) értékkel van meghívva, hogy a szöveg mérete és a keret méretei rögzítve maradjanak.

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

## **Függő központozás szabályozása**

A [ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) lehetővé teszi, hogy a megfelelő központozási jelek a szövegsor jobb szélén túlra nyúljanak ahelyett, hogy a következő sorba kerülnek. Az egész bekezdésre vonatkozik, és különbözik a függő behúzástól.

Az alábbi önálló példa 100 pontos széles szövegkeretben engedélyezi a függő központozást és elmenti a "hanging_punctuation.pptx" fájlt. 24 pontos Arial és nulla vízszintes szövegkeret margó esetén az utolsó pont a "mondat" után marad, és a jobb szövegél túlra nyúlik. Állítsa a tulajdonságot [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) értékre az összehasonlításhoz: ezekkel a beállításokkal a pont külön sorba kerül. A sortörés engedélyezett, az automatikus méretezés letiltott, hogy a rendelkezésre álló szélesség fix maradjon.

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

Nem minden központozási jel függő lehet. A [fenti betűtípus- és elrendezési feltételek](#control-line-breaking) szintén érvényesek erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus méretezés beállításainak módosítása eltüntetheti a látható különbséget.

## **Autofit típus beállítása szövegkeretekhez**

A [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) meghatározza, hogyan viselkedik a szöveg, ha túllépi a tároló határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, túlcsorduljon vagy automatikusan átméretezze a formát. Az alábbi példa a formát úgy állítja be, hogy a szöveghez igazodva méretezze át, és elmenti az eredményt a "autofit_type.pptx" fájlba.

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

A sorok számolásához automatikus sortörés után, és a szöveg vagy forma szélességének változásának megtekintéséhez lásd a [Count Rendered Lines](/slides/hu/php-java/manage-paragraph/) cikket. A sorok száma önmagában nem mutatja, hogy a szöveg túltölti-e a tárolót.

## **Szövegkeretek rögzítésének beállítása**

A [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) meghatározza, hogyan helyezkedik el függőlegesen a szöveg egy alakzatban, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alakzat aljához rögzíti, és elmenti az eredményt a "text_anchor.pptx" fájlba.

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

## **Szöveg tabuláció beállítása**

Használja a [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) és [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) metódusokat a bekezdés tabulátor pozícióinak beállításához. Az alábbi példa az alapértelmezett tabulátor távolságot 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tab karaktert tartalmazó szöveget érintik.

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

![A bekezdés tabulátorai](paragraph_tabs.png)

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) segítségével lehetővé teszi, hogy egy szövegrész helyesírási nyelvét beállítsa. A helyesírási nyelv határozza meg a PowerPointban a helyesírási és nyelvtani ellenőrzés nyelvét.

Az alábbi példa a "presentation.pptx" fájlt igényli, amelynek az első diáján az első alakzat egy szövegdoboz, és legalább egy bekezdés van. Lecseréli az első bekezdés tartalmát "1。"‑re, a betűtípust SimSun‑ra állítja, és a Simplified Chinese (`zh-CN`) helyesírási nyelvet rendeli hozzá. Elmenti az eredményt a "proofing_language.pptx" fájlba:

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

Használja a [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) a betöltés vagy a prezentáció létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelv az amerikai angol, hozzáad egy szövegdobozt, és az első szövegrésznek kiírja a `en-US` értéket.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Adj hozzá egy új téglalap alakzatot szöveggel.
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

Az alapértelmezett szövegformázás prezentáció szintű alkalmazásához használja a [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Az alábbi példa 14 pontos félkövér betűtípust állít be alapértelmezettként az új prezentáció felső szintű bekezdéseihez, és elmenti a "default_text_style.pptx" fájlba. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak nem felülírja őket konkrétabb formázás.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **Szöveg kinyerése All-Caps hatással**

A PowerPointban a **All Caps** betűhatás alkalmazása a szöveget nagybetűs formában jeleníti meg a dián, még ha eredetileg kisbetűvel írták is. Amikor ilyen szövegrészt kér le az Aspose.Slides, a könyvtár pontosan úgy adja vissza a szöveget, ahogyan beírta. A megjelenített szöveghez való illesztéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) értékét, és alakítsa a visszakapott karakterláncot nagybetűssé, ha az érték `All`.

Ez a példa a "sample2.pptx" fájlt igényli, amelynek az első diáján az első alakzat egy szövegdoboz. Az első bekezdés első része tartalmazza a "Hello, Aspose!" szöveget All Caps hatással, ahogy alább látható.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan nyerhető ki a **All Caps** hatással alkalmazott szöveg:

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

**Hogyan módosíthatok szöveget egy táblázatban a dián?**

A táblázat szövegének módosításához a dián használja a [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Iteráljon a cellákon, és frissítse az egyes cellákat a [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) segítségével, valamint a bekezdés formázását a [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) használatával.

**Hogyan alkalmazhatok színátmenetet a szövegre egy PowerPoint dián?**

A szöveg színátmenetes színéhez használja a [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). Állítsa be a [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) értékét [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) értékre, és konfigurálja a gradient állomásokat, irányt és átlátszóságot.