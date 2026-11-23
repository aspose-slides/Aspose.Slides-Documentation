---
title: Prezentáció szövegének formázása PHP-ban
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
- betűtípus tulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegkeret
- sorköz
- automatikus illesztés tulajdonság
- szövegkeret horgony
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java segítségével. Testreszabhatja a betűket, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhat szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java használatával. Kitér a háttérszínekre, átlátszóságra, karakterközre, betűtípus‑tulajdonságokra, forgatásra, bekezdésközökre, automatikus illesztés viselkedésére, szöveg‑horgonyzásra, tabulátorokra és nyelvi beállításokra.

Kivéve, ha másként szerepel, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzat egy szövegdoboz, és az első bekezdés tartalmazza az alább látható szöveget. A dia‑ és alakzatszámok nulláról indulnak. A félkövér részleteket kiemelő példák hatékony formázást alkalmaznak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

A szó szerinti vagy reguláris kifejezéssel egyező szövegrészek kereséséhez és kiemeléséhez lásd a [Search and Replace Text](/slides/hu/php-java/search-and-replace-text/) oldalt.

## **Szöveg háttérszínének beállítása**

Használja a [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) metódust egy bekezdés alapértelmezett kiemelési színének beállításához, vagy a [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) metódust egyedi szövegrészekhez.

Az alábbi példa egy világosszürke kiemelést állít be az első bekezdés alapértelmezettként. Az egyes részeken megadott explicit kiemelési színek felülbírálják ezt az alapértelmezést:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Állítsa be a kiemelés színét az egész bekezdésre.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűtípusú szövegrészek** számára:

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

Használja a [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) metódust a bekezdés igazításához egy szövegkeretben. Az érték lehet középre, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet azt mutatja, hogyan igazítható a bekezdés **középre**:

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

Használja a [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) metódust a különböző betűméretű szövegrészek függőleges igazításához egy soron belül. Ez a beállítás az egész bekezdésre vonatkozik, és a soron belüli igazítást szabályozza.

Az alábbi önálló példa négy felcímzett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pont méretben, eltérő betűigazítással. Arial‑t használ, letiltja az automatikus illesztést és a sortörést, és a szövegkereteket elég nagyra állítja egyetlen sorhoz.

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

![A baseline, felső, középső és alsó betűigazítás összehasonlítása vegyes betűméretekkel](font_alignment.png)

A betűigazítás a betűmetrikákon alapul, így az egyes betűk látható szélei nem feltétlenül esnek egybe pontosan. A példa tartalmaz egy nagybetűt és egy alulfutó karaktert is, hogy megmutassa a baseline és az alsó igazítás közti különbséget. A betűk elérhetősége, helyettesítése, a használt karakterek és a betűméretek különbsége befolyásolja az eredményt. A keret méretei, margók, sorköz, sortörés és automatikus illesztés is hat a megjelenésre; a módok összehasonlításakor használjon azonos betűket és elrendezési beállításokat.

Ez a beállítás különbözik a [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment)‑tól, amely a vízszintes bekezdés‑igazítást szabályozza, valamint a [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType)‑tól, amely a szövegtömb függőleges pozícióját állítja be az alakzaton belül. A felső és alsó indexálást a [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) segítségével egyes részeket a baseline‑tól eltolva lehet elérni, a bekezdés sorainak betűigazítása helyett.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszóságát a [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) színének alfa‑komponense vezérli. Az alábbi példákban az `alpha = 50` egy ARGB alfa‑csatorna érték a 0‑255 tartományban, nem átlátszósági százalék.

Az alábbi kódrészlet azt mutatja, hogyan alkalmazható átlátszóság a **teljes bekezdésre**:

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

    // Állítsa be a szöveg kitöltőszínét egy átlátszó színre.
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

A következő kódrészlet azt mutatja, hogyan alkalmazható átlátszóság **félkövér betűtípusú szövegrészekre**:

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

## **Karakterköz beállítása a szövegben**

Használja a [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) metódust a karakterek közti térköz növelésére vagy csökkentésére egy szövegdobozban. A példák 3 pont térközt adnak hozzá; negatív értékek szorítják a szöveget.

Az alábbi PHP kód azt mutatja, hogyan növelhető a karakterköz a **teljes bekezdésben**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Megjegyzés: Negatív értékek használata a karakterköz összenyomásához.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Bővíti a karakterközt.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet azt mutatja, hogyan növelhető a karakterköz **félkövér betűtípusú szövegrészekben**:

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
            // Megjegyzés: Negatív értékek használata a karakterköz összenyomásához.
            $portion->getPortionFormat()->setSpacing(3); // Bővíti a karakterközt.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása adott betűtípusokhoz**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPointban megjelenő szöveg. Ez előfordulhat, ha a PowerPoint figyelmen kívül hagyja egyes betűtípusok kerning adatait, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt, és a PowerPoint beállításaiban a kerning be van kapcsolva.

Az ilyen esetekben a renderelt kimenet PowerPoint‑hoz közeli eléréséhez letilthatja a kerninget azon szövegrészeknél, amelyek az érintett betűtípust használják. Állítsa a [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) értékét a tényleges betűméretnél nagyobbra. Ez a példa a "presentation.pptx" fájlt igényli, amelynek első alakzata első diáján egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be a Roboto‑t használó részekhez. Ez letiltja a kerninget azoknál a részeknél, amelyek betűmérete 100 pont alatt van:

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

Az alsó küszöb alatti egyező szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez igazításában azoknál a betűtípusoknál, amelyekre ez a PowerPoint‑specifikus viselkedés hat.

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságok beállíthatók bekezdés szintjén a [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) segítségével, vagy egyes részeknél a [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) segítségével.

Az alábbi példa az első bekezdés alapértelmezett betűtípusát 12 pont Times New Roman‑ra állítja félkövér, dőlt és pontozott aláhúzással. Az egyes részeken megadott explicit formázás felülbírálja az alapértelmezéseket:

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

![A bekezdés betűtípus‑tulajdonságai](font_properties_for_paragraph.png)

Az alábbi példa 13 pont Times New Roman‑t, dőlt formázást és pontozott aláhúzást alkalmaz azoknál a résznél, amelyek hatékony formázása félkövér:

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

![A szövegrészek betűtípus‑tulajdonságai](font_properties_for_text_portions.png)

## **Szövegmagasság normalizálásának vezérlése**

Használja a [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) metódust sablon‑tipográfia újratermeléséhez vagy a karaktermagasság‑különbségek vizsgálatához. PowerPointban a normalizálás függőlegesen nyújtja vagy összenyomja az egyes karaktereket, hogy egységes látható magasságot kapjanak a szövegrészben. Nem garantálja, hogy a különböző betűk magassága egyenlő lesz.

Állítsa a tulajdonságot [NullableBool::True vagy False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) értékre a normalizálás kifejezett engedélyezéséhez vagy tiltásához. A `NullableBool::NotDefined` helyi beállítást hagy üresen, így a rész örökli az értéket, például a bekezdés [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)‑ból. Ez nem azt jelenti, hogy `False`. Használja a [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective)‑t, és olvassa ki a `getNormaliseHeight` értéket a visszaadott hatékony formázási adatokból a feloldott Boolean érték meghatározásához.

Az alábbi önálló példa **Arial** telepítését igényli. Két szövegbloport hoz létre, amelyek ugyanazokat a nagybetűket, kisbetűket, alulfutó karaktereket és ékezetes betűket tartalmazzák 54 pontban. Mindkét bekezdés alapértelmezés szerint engedélyezi a normalizálást. A felső rész kifejezetten letiltja; az alsó rész örökli. A keretméretek, a margók és a bekezdésközök azonosak, a sortörés és az automatikus illesztés le van tiltva a konzisztens összehasonlítás érdekében. A példa kiírja a `False: false` és a `NotDefined: true` értékeket, majd elmenti a "text_height_normalization.pptx" fájlt.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az alábbi összehasonlítás a mentett prezentációból exportálva látható. A felső sorban a normalizálás le van tiltva (`False`); az alsó sorban örökli a bekapcsolt beállítást (`NotDefined` → `True`). A helyes megjelenés előállításához tartsa telepítve az Arial‑t.

![Arial 54‑pontos szöveg normalizálással letiltva felül és örökölve bekapcsolva alul](text_height_normalization.png)

A normalizálás a karaktermagasságot változtatja anélkül, hogy a [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight) értékét módosítaná, amely a betűméretet pontban adja meg. A bekezdés [setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) a sorközöket szabályozza, míg a szövegkeret [setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) a szöveg vagy annak tartóerejének méretezését. Ezek a beállítások különböző célokat szolgálnak, és önállóan befolyásolhatják a teljes elrendezést. A bekezdés‑formázás és öröklődés részleteiért lásd a [Manage Paragraph](/slides/hu/php-java/manage-paragraph/) oldalt.

## **Áthúzás alkalmazása és eltávolítása**

Használja a [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) metódust egy szövegrészen, hogy megjelenítsen javításokat, törölt kifejezéseket vagy korábbi árakat a szöveg törlése nélkül. Állítsa a [TextStrikethroughType::Single vagy Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) értékre egy vagy két vonal megjelenítéséhez a szöveg felett.

Az áthúzás eltávolításához adja meg a [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None) értéket. Ez kifejezetten letiltja a hatást, még akkor is, ha a környező formázás áthúzást tartalmaz. Ezzel szemben a [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) a helyi beállítást üresen hagyja, így a rész örökölheti a formázást, például a bekezdéstől. Nem garantálja, hogy az áthúzás eltávolításra kerül. Használja a [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective)‑t a végső formázás, beleértve az örökölt értékek olvasását.

Az alábbi önálló példa három ár‑összehasonlítást hoz létre. Minden bekezdés külön részt tartalmaz a címke, a korábbi ár és a jelenlegi ár számára, így csak a korábbi ár érintett. Az első sorban alkalmaz és eltávolít áthúzást; a többi sorban egy‑ és dupla áthúzás marad. Ennek a beállításnak a módosítása megőrzi a szöveget és egyéb formázását, köztük a félkövér korábbi árat.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // Alkalmazzon áthúzást, majd kifejezetten távolítsa el azt az első előző árból.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény felülről lefelé: nincs áthúzás, egy‑vonalas áthúzás és dupla áthúzás.

![Korábbi árak áthúzás nélküli, egy‑vonalas áthúzással és dupla áthúzással](strikethrough.png)

## **Szöveg forgatása**

Használja a [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) metódust egy előre definiált szövegorientáció beállításához egy alakzaton belül.

Az alábbi kódrészlet a szövegorientációt a [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokot fordítottan** (balra) forgatja a szöveget:

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

![A szöveg forgatása](text_rotation.png)

## **Számjegyek egymás mellé helyezése függőleges szövegben**

Kétjegyű szám függőleges japán címkében való egyben tartásához helyezze a két számjegyet egy szövegrészbe, és hívja meg a [BasePortionFormat::setKumimoji](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKumimoji) metódust ezen a részen. A példa a [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical) és a 40 pontos MS Gothic betűtípust használ mindkét címkéhez. Csak a [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) értéke különbözik a numerikus részben.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 120;

    foreach ([NullableBool::True, NullableBool::False] as $kumimoji) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 48, 120, 420);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $frame = $label->addTextFrame("");
        $frame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::EastAsianVertical);

        $paragraph = $frame->getParagraphs()->get_Item(0);
        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $font = new FontData("MS Gothic");
        $format->setLatinFont($font);
        $format->setEastAsianFont($font);
        $format->setFontHeight(40);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($black);

        $digits = new Portion("12");
        $digits->getPortionFormat()->setKumimoji($kumimoji);

        $portions = $paragraph->getPortions();
        $portions->clear();
        $portions->add(new Portion("令和"));
        $portions->add($digits);
        $portions->add(new Portion("年"));

        $x += 240;
    }
    $presentation->save("vertical_date.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPointban a bal címke (`True`) függőlegesen álló és egymás melletti számjegyeket mutat a 和 és 年 karakterek között. A jobb címke (`False`) esetén a páros 90 fokkal jobbra van forgatva. A környező japán karakterek mindkét címkén állólagosak maradnak.

![PowerPoint összehasonlítás függőleges dátumcímkékről, ahol a bal oldalon álló számjegyek, a jobb oldalon pedig forgatott számjegyek vannak.](vertical_date.png)

## **Egyéni forgatás beállítása szövegkeretekhez**

Használja a [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) metódust egy egyéni forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)-hez.

Az alábbi kódrészlet 3 fokkal jobbra (óra járásával megegyező irányban) forgatja a szövegkeretet az alakzaton belül:

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

![Az egyéni szövegforgatás](custom_text_rotation.png)

## **Bekezdések sorközének beállítása**

Az Aspose.Slides a [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), a [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) és a [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) metódusokkal szabályozza a bekezdésközöket. Ezek a tulajdonságok a következő módon használhatók:

* Pozitív értékkel a sorköz a sormagasság százalékában adható meg.
* Negatív értékkel a sorköz pontokban adható meg.

Az alábbi példa a első bekezdés sorközét a sormagasság 200 %-ára (dupla sorköz) állítja:

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

![A bekezdés sorköze](line_spacing.png)

## **Sortörés szabályainak vezérlése**

A bekezdés sortörési szabályai szűk szövegdobozok és kevert latin‑kelet-ázsiai szöveges prezentációk esetén hasznosak. Az alábbi módszerek a [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) osztályhoz tartoznak, így egy teljes bekezdésre vonatkoznak:

- A [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) a latin sortörési szabályokat vezérli. Kevert szöveg esetén ennek módosítása megváltoztathatja a közelben lévő kelet-ázsiai szöveg és írásjelek sortörését is.
- A [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) a kelet-ázsiai sortörési szabályokat szabályozza, beleértve a sor elején és végén megengedett karaktereket.

E szabályok nem helyettesítik a [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) beállítást, amely a szövegkereten belüli automatikus sortörést engedélyezi. A szabályok befolyásolják a megjelenést, amikor sortörés történik; nem helyeznek be sortörés‑karaktert. Egy explicit sortörés új sort hoz létre a bekezdésben, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy szűk szövegdobozt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési opciót explicit módon beállítja, majd a "line_breaking.pptx" fájlt menti. A szabályok kipróbálásához változtassa meg a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24 pont Arial és SimSun betűtípust használ, 160 pont széles kerettel és nulla vízszintes szövegkeret‑margóval. A [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) metódus a [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) értékkel van hívva, hogy a szöveg mérete és a keret dimenziói rögzítve maradjanak.

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

## **Függőleges írásjelek engedélyezése**

A [ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) lehetővé teszi, hogy a jogosult írásjelek a sor jobb szélén túlnyúljanak a következő sor helyett. Az egész bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa 100 pont széles szövegkeretben engedélyezi a függőleges írásjeleket, majd a "hanging_punctuation.pptx" fájlt menti. 24 pont Arial és nulla vízszintes szövegkeret‑margó esetén a végső pont a "sentence" szó után marad, és a jobb szövegszél fölé nyúlik. Állítsa a tulajdonságot [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ebben az esetben a pont külön sorba kerül. A sortörés be van kapcsolva, az automatikus illesztés le van tiltva, hogy a rendelkezésre álló szélesség rögzített maradjon.

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

Nem minden írásjel függetlenül függőleges. A fent leírt [betű- és elrendezési feltételek](#control-line-breaking) szintén érvényesek erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltüntetheti a látható különbséget.

## **Automatikus illesztés típusának beállítása szövegkeretekhez**

A [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) meghatározza, hogyan viselkedjen a szöveg, ha meghaladja a tárolójának határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, kilógjon, vagy a forma automatikusan átméreteződjön. Az alábbi példa a formát úgy állítja be, hogy a szöveghez igazodva méretezze át a alakzatot, és a "autofit_type.pptx" fájlt menti.

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

Az automatikus sortörés utáni sorok számolásához és a szöveg vagy forma szélesség változásának megtekintéséhez lásd a [Count Rendered Lines](/slides/hu/php-java/manage-paragraph/) oldalt. A sorok száma önmagában nem jelzi, hogy a szöveg kilóg-e a tárolóból.

## **Szövegkeretek horgonypontjának beállítása**

A [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) meghatározza, hogyan helyezkedjen el függőlegesen a szöveg egy alakzaton belül, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alakzat alján horgonyozza, majd a "text_anchor.pptx" fájlt menti.

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

Használja a [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) és a [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) metódusokat a tabulátorok beállításához egy bekezdésben. Az alábbi példa az alapértelmezett tabulátor‑lépést 100 pontra állítja, és egy bal‑igazított tabulátort ad hozzá 30 pontra. Ezek a beállítások a tabulátor‑karaktereket tartalmazó szövegre hatnak.

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

Az Aspose.Slides a [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) metódussal lehetővé teszi egy szövegrész helyesírási nyelvének beállítását. A helyesírási nyelv határozza meg, hogy a PowerPoint milyen nyelven végez helyesírás‑ és nyelvtan‑ellenőrzést.

Az alábbi példa a "presentation.pptx" fájlt igényli, amelynek első diáján első alakzata egy szövegdoboz, és legalább egy bekezdést tartalmaz. A első bekezdés tartalmát "1。"‑re cseréli, a betűtípust SimSun‑ra állítja, és a Simplified Chinese (`zh-CN`) helyesírási nyelvet rendeli hozzá. Az eredményt a "proofing_language.pptx" fájlba menti:

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

### **Nyelvi metaadatok másolása**

Többnyelvű szöveg sablonból való másolásakor meg kell őrizni mind a [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId), mind a [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) értékét. Az alábbi önálló példa egy forrás‑részt hoz létre, amelynek nyelve az amerikai angol, alternatív nyelve a francia, és ezeket a szöveget és az azonosítókat egy új prezentáció egy részébe másolja.

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // Ha a forrásnak nincs alternatív nyelve, a null törli a cél értékét.
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ha forrásnál nincs alternatív nyelv, hagyja ki a `"fr-FR"` hozzárendelését. Ebben az esetben az alternatív azonosító `null`, és ugyanaz a másolási utasítás megőrzi a hiányát alapértelmezett érték bevezetése nélkül, még akkor is, ha a cél már rendelkezett alternatív nyelvvel.

Ezek az azonosítók nyelvi metaadatként tárolódnak. Az ő megőrzésük nem határozza meg, hogy a PowerPoint melyik szótárat használja a helyesírás‑ vagy nyelvtani ellenőrzéshez.

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metódust a szöveg alapértelmezett nyelvének meghatározásához, amikor prezentációt betölt vagy létrehoz. Az alábbi példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelv az amerikai angol, hozzáad egy szövegdobozt, és az első szövegrész nyelvének kiírása `en-US` lesz.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Új téglalap alakzat hozzáadása szöveggel.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Az első szövegrész nyelvének ellenőrzése.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás prezentáció‑szintű alkalmazásához használja a [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle) metódust.

Az alábbi példa 14 pont félkövér betűtípust állít be az új prezentáció felső‑szintű bekezdéseihez, majd a "default_text_style.pptx" fájlba menti. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak egy konkrétabb formázás felül nem írja őket.

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

## **Szöveg kinyerése all‑caps hatással**

PowerPointban az **All Caps** betűhatás alkalmazása a szövegre azt eredményezi, hogy a diához nagybetűkben jelenik meg a szöveg, még akkor is, ha eredetileg kisbetűkkel lett beírása. Amikor az Aspose.Slides segítségével ilyen szövegrészt kérdezi le, a könyvtár pontosan úgy adja vissza a szöveget, ahogy be lett írva. A megjelenített szöveghez való igazításhoz ellenőrizze a [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) értékét, és ha az `All`, akkor konvertálja a visszakapott karakterláncot nagybetűsre.

Ez a példa a "sample2.pptx" fájlt igényli, amelynek első diáján első alakzata egy szövegdoboz. Az első bekezdés első része a "Hello, Aspose!" szöveget tartalmazza, amelyre az All Caps hatás alkalmazva van, az alábbiak szerint.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet azt mutatja, hogyan nyerhető ki a szöveg az **All Caps** hatással:

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

**Hogyan módosítható egy táblázat szövege egy dián?**

Egy dián lévő táblázat szövegének módosításához használja a [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) osztályt. Járja be a cellákat, és minden cellát frissítsön a [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) és a bekezdés‑formázás a [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) segítségével.

**Hogyan alkalmazható színátmenet szövegre egy PowerPoint dián?**

A színátmenetes szöveg alkalmazásához használja a [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) metódust. Állítsa a [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) értékét [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)‑ra, és konfigurálja a gradient‑állomásokat, irányt és átlátszóságot.