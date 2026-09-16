---
title: Správa hypertextových odkazů v prezentacích v PHP
linktitle: Správa hypertextových odkazů
type: docs
weight: 20
url: /cs/php-java/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- textový hypertextový odkaz
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- mutovatelný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Přidávejte, formátujte, aktualizujte a odstraňujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java, s využitím příkladů v PHP."
---
## **Úvod**

Hyperlink spojuje obsah prezentace s webovou stránkou nebo umístěním v rámci prezentace. V PowerPointu hypertextové odkazy běžně slouží ke dvěma účelům:

* Otevřít webovou stránku z textu, tvaru nebo média.
* Přechod na jiný snímek, například z obsahu.

Aspose.Slides for PHP via Java vám umožňuje tyto odkazy přidávat, řídit jejich vzhled a zvuk, aktualizovat jejich vlastnosti a odstraňovat je. Níže uvedené příklady ukazují, jak pracovat s hypertextovými odkazy na jednotlivých prvcích a jak získat přístup k hypertextovým odkazům na úrovni prezentace, snímku nebo textového rámečku. Předpokládají, že je inicializován PHP/Java Bridge a obal Aspose.Slides pro PHP. Členové API bez odkazu na stránku reference PHP odkazují na podkladové Java API.

{{% alert color="info" title="Poznámka" %}}
Můžete také upravovat prezentace pomocí [bezplatného online editoru Aspose PowerPoint](https://products.aspose.app/slides/cs/editor).
{{% /alert %}} 

## **Přidat URL hypertextové odkazy**

Můžete přiřadit URL webové stránky k textu, tvaru nebo média. Prvek, ke kterému hypertextový odkaz přiřadíte, určuje klikací oblast: část textu odkazuje vybraný text, zatímco tvar nebo rámeček odkazuje objekt snímku.

### **Přidat URL odkazy do textu**

Pro propojení textu s webovou stránkou předáte objekt [Hyperlink](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/) metodě [setHyperlinkClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/sethyperlinkclick/) textové části, jak je ukázáno níže. Pouze tato část textu se stane klikací.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Přidat URL odkazy do tvarů a rámečků médií**

Pro učinění tvaru nebo rámečku klikacím zavolejte jeho metodu [setHyperlinkClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/sethyperlinkclick/). Hypertextový odkaz patří samotnému objektu, nikoli textové části v něm.

Stejný postup platí pro rámečky obrázku, zvuku a videa: přiřaďte hypertextový odkaz k rámečku a v případě potřeby zavolejte [setTooltip](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/settooltip/).

Následující příklad učiní obdélník klikacím:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Použít hypertextové odkazy k vytvoření obsahu**

Interní hypertextové odkazy umožňují čtenářům přejít z obsahu na konkrétní snímek. Následující příklad používá [setInternalHyperlinkClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) k propojení textu „Stránka 2“ na prvním snímku s druhým snímkem.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Formátovat hypertextové odkazy**

### **Barva**

Metoda [setColorSource](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/setcolorsource/) třídy [Hyperlink](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/) určuje, zda hypertextový odkaz používá barvu hypertextu prezentace nebo formátování textové části. Pro nastavení vlastní barvy textu vyberte [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkcolorsource/) a nastavte výplňovou barvu části. Tato funkce byla zavedena v PowerPointu 2019; starší verze toto nastavení nepoužívají.

Následující příklad přidává dva textové hypertextové odkazy na stejný snímek. První používá červenou výplň textu, zatímco druhý zachovává výchozí barvu odkazu.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **Zvuk**

Hypertextový odkaz může při aktivaci přehrát zvuk nebo zastavit již přehrávaný zvuk. K nastavení těchto chování použijte následující metody:

- [Hyperlink::setSound](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/setsound/) určuje zvuk přidružený k hypertextovému odkazu.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/setstopsoundonclick/) řídí, zda aktivace odkazu zastaví předchozí zvuk.

#### **Přidat zvuk k hypertextovému odkazu**

Následující příklad načte `sampleaudio.wav` a přiřadí jej tlačítku na prvním snímku. Kliknutím na tlačítko se zvuk přehraje a přejde na další snímek. Druhý tvar na tomto snímku zastaví předchozí zvuk po kliknutí, aniž by provedl akci navigace.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **Extrahovat zvuk z hypertextového odkazu**

Následující příklad otevře výše vytvořenou prezentaci a načte zvuk hypertextového odkazu prvního tvaru do paměti pomocí [getSound](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/getsound/) a [getBinaryData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audio/getbinarydata/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Nápověda (Tooltip) a nastavení interakce**

Můžete volat následující metody třídy [Hyperlink](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/) po přiřazení hypertextového odkazu k textu nebo tvaru:

- [setTooltip](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/settooltip/) nastaví text, který může prohlížeč zobrazit jako nápovědu k odkazu.
- [setTargetFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/settargetframe/) určuje cílový rámec v rodičovském HTML frameset, pokud je to relevantní.
- [setHistory](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/sethistory/) řídí, zda aktivace odkazu přidá jeho cíl do seznamu zobrazených odkazů.
- [setHighlightClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/sethighlightclick/) řídí, zda je hypertextový odkaz zvýrazněn po kliknutí.

## **Odstranit hypertextové odkazy z prezentací**

Použijte [getAnyHyperlinks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) k shromáždění kontejnerů hypertextových odkazů, včetně odkazů na textové části, před jejich úpravou. Následující příklad odstraňuje oba typy aktivace z prvního snímku. Pro odstranění pouze jednoho typu zavolejte pouze [removeHyperlinkClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) nebo [removeHyperlinkMouseOver](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); odstranění akce kliknutí neodstraňuje její protějšek při najetí myší.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Pro nepodmíněné odstranění [removeAllHyperlinks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) odstraňuje oba typy aktivace ve vybraném rozsahu jedním voláním. Pro selektivní úklid a pokrytí masterů, rozvržení a poznámek viz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Vytvořit kompletní inventář hypertextových odkazů**

Před distribuováním prezentace vytvořte inventář jejích interaktivních akcí i webových odkazů. [getAnyHyperlinks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) vrací objekty [IHyperlinkContainer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkcontainer/), nikoli plochý seznam řetězců URL. Prozkoumejte na každém kontejneru jak [getHyperlinkClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) tak [getHyperlinkMouseOver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--). Jsou nezávislé: stejný kontejner může exponovat obě akce, takže kompletní zpráva potřebuje až dva řádky na kontejner.

Skenování pouze hypertextových odkazů na úrovni tvarů může přehlédnout odkazy připojené k textovým částem. Místo toho dotazujte příslušný rozsah a uchovávejte vrácené kontejnery, abyste je později mohli aktualizovat nebo odstranit jejich akce.

### **Dotazovat na rozsahy prezentace, snímku a textového rámečku**

Třída [HyperlinkQueries](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/) je dostupná přes [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) a [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/gethyperlinkqueries/). Každý rozsah podporuje stejné dotazy:

- [getHyperlinkClicks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) vrací kontejnery s akcí kliknutí.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) vrací kontejnery s akcí najetí myší.
- [getAnyHyperlinks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) vrací kontejnery s jednou nebo oběma akcemi.

Následující příklad vytvoří `hyperlink-audit-input.pptx` s externím odkazem na kliknutí, odkazem na soubor při najetí myší, interní navigací mezi snímky, odkazem v textu při najetí myší a makro akcí. Nevykonává žádnou z těchto akcí. Stejné tři dotazy fungují v každém rozsahu; počty popisují kontejnery, ne součet akcí. Rozsah textového rámečku vylučuje vlastní odkazy obklopujícího tvaru.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pro tento příklad dotazy na prezentaci a snímky každé uvádějí tři kontejnery kliknutí, dva kontejnery při najetí myší a tři kontejnery s libovolnou akcí. Dotaz na textový rámeček uvádí po jednom kontejneru v každé kategorii.

### **Klasifikovat akce a cíle**

Použijte [Hyperlink::getActionType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/getactiontype/) k interpretaci akce před interpretací jejího cíle. Hodnoty [HyperlinkActionType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkactiontype/) zahrnují více než jen webovou navigaci:

| Hodnoty | Význam pro audit |
| --- | --- |
| `Hyperlink` | Externí hypertextový odkaz; prověřte URL a jeho schéma. |
| `JumpSpecificSlide` | Interní navigace na konkrétní snímek. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Vestavěná navigace prezentace, řešená v kontextu prezentace. |
| `JumpEndShow`, `StartCustomSlideShow` | Ukončí aktuální prezentaci nebo spustí vlastní prezentaci. |
| `StartMacro` | Spustí makro. |
| `StartProgram` | Spustí program. |
| `OpenFile`, `OpenPresentation` | Otevře soubor nebo jinou prezentaci; posuzujte odděleně od webových URL. |
| `StartStopMedia` | Spustí nebo zastaví přehrávání médií. |
| `NoAction`, `Unknown` | Žádná navigační akce, nebo neznámá akce vyžadující revizi. |

Externí cíle čtěte z [getExternalUrl](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/getexternalurl/) a specifické interní cíle z [getTargetSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/gettargetslide/). Interní akce a vestavěné příkazy mohou nemít externí URL; prázdná URL neznamená, že kontejner nemá akci. Zachovejte hodnotu vrácenou [getExternalUrlOriginal](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) pokud se liší od normalizované URL, a zahrňte nápovědu vrácenou [getTooltip](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlink/gettooltip/) pokud je k dispozici.

### **Zpráva, sanitizace a ověření hypertextových odkazů**

Následující PHP příklad načte existující prezentaci (použijte soubor vytvořený výše), zapíše `hyperlink-audit.json`, aplikuje politiku, uloží `hyperlink-sanitized.pptx` a znovu jej otevře pro kontrolu obou typů aktivace. Před úpravou shromažďuje kontejnery a používá referenční rovnost, aby se vyhnul dvojímu zpracování stejného kontejneru. Dotazy na prezentaci pokrývají běžné snímky; pro inventář na úrovni balíčku také explicitně dotazuje mastery, rozvržení, poznámky a mistry poznámek a podkladů, pokud jsou přítomny.

Zpráva zaznamenává číslování snímků od jedničky a [getSlideId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/#getSlideId--) kde je k dispozici. [ISlideComponent::getSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecomponent/#getSlide--) poskytuje vlastní snímek pro podporované kontejnery. Mastery, rozvržení a poznámky nemají běžný index snímku a jsou identifikovány podle jejich rozsahu. Kontejnery tvarů a kontejnery formátování textových částí jsou označeny odděleně; ostatní typy kontejnerů si zachovávají název typu za běhu. Každý kontejner dostane lokální ID zprávy, aby bylo možné korelovat jeho dvě akce. Zpráva ukládá typy akcí jako celá čísla definovaná v PHP výčtu.

Tato úmyslně restriktivní aplikační politika povoluje jen absolutní HTTPS URL a platné interní cíle snímků. Odmítá makra, programy, souborové akce, jiné akce prezentace, neznámé akce a jiné schémata URL. Tato odmítnutí jsou rozhodnutí politiky, nikoliv bezpečnostní verdikt Aspose.Slides. Pouze HTTPS nezaručuje důvěru: přidejte seznamy povolených hostitelů a další kontroly pro vaši aplikaci. Kontrolují se jak originální, tak normalizované externí URL. Příklad kontroluje metadata, aniž by sledoval odkazy nebo spouštěl akce.

Pro opravu podporuje kontejner [getHyperlinkManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager) metody [setExternalHyperlinkClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Zde jsou zakázané externí odkazy na kliknutí nahrazeny pevnou HTTPS vstupní stránkou; ostatní zakázané kliknutí a zakázané akce při najetí jsou odstraněny nezávisle. Nastavte `$replaceExternalClicks` na `false` pro odstranění všech porušení politiky. Vyberte stránku nahrazení vlastněnou aplikací před nasazením.

Exportní příznak zprávy používá konzervativní politiku revize PDF: označuje akce při najetí myší a vše kromě externího odkazu nebo konkrétního skoku na snímek jako potenciálně nepodporované. Jedná se o návod k revizi, ne test schopností ani záruku, že neoznačené odkazy přežijí export. Podporované exporty [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/php-java/convert-powerpoint-to-html/) mohou zachovat hypertextové odkazy, v závislosti na akci, možnostech exportu a prohlížeči. Rasterové [obrázky](/slides/cs/php-java/convert-powerpoint-to-png/) a [video](/slides/cs/php-java/convert-powerpoint-to-video/) nemohou zachovat interaktivní odkazy; označte každou akci při auditu pro tyto výstupy.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

S vstupem vytvořeným výše zpráva obsahuje pět řádků akcí. Odkaz na soubor při najetí myší a kliknutí na makro jsou odstraněny, zatímco HTTPS odkazy a interní navigace mezi snímky zůstávají. Ověření vypíše nula zakázaných akcí. Vstup obsahující zakázaný externí odkaz na kliknutí také vyzkouší větev nahrazení. Kontejner s povoleným kliknutím a zakázaným najetím myší si zachová akci kliknutí.

Tento selektivní úklid se liší od [removeAllHyperlinks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), který odstraňuje oba typy aktivace v celém vybraném rozsahu bez ohledu na politiku. Ověření zde kontroluje jen akce hypertextových odkazů; neodstraňuje vložené projekty VBA, OLE objekty ani jiný aktivní obsah a nevaliduje exportovaný PDF nebo HTML soubor.

## **Často kladené otázky**

**Jak mohu propojit sekci nebo její první snímek?**

Oddíly v PowerPointu seskupují snímky, ale interní hypertextový odkaz cílí na konkrétní snímek. Pro vytvoření navigace k oddílu odkažte na první snímek tohoto oddílu.

**Mohu přiřadit hypertextový odkaz k prvkům master snímku, aby fungoval na všech snímcích?**

Ano. Prvky master snímku a rozvržení podporují hypertextové odkazy. Odkazy na těchto prvcích jsou dostupné během prezentace na snímcích, které používají odpovídající master nebo rozvržení.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

Podporované exporty do PDF a HTML mohou zachovat hypertextové odkazy; rastrové obrázky a video nemohou. Viz úvahy o exportu v [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).