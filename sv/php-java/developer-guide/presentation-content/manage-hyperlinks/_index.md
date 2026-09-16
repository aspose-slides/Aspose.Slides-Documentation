---
title: Hantera presentationshyperlänkar i PHP
linktitle: Hantera hyperlänkar
type: docs
weight: 20
url: /sv/php-java/manage-hyperlinks/
keywords:
- lägg till URL
- lägg till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- texthyperlänk
- bildhyperlänk
- formhyperlänk
- bildhyperlänk
- videohyperlänk
- muterbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lägg till, formatera, uppdatera och ta bort hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java, med PHP‑exempel."
---
## **Introduktion**

En hyperlänk ansluter presentationsinnehåll till en webbplats eller en plats inom presentationen. I PowerPoint används hyperlänkar vanligtvis för två ändamål:

* Öppna en webbplats från text, en form eller en mediaram.
* Navigera till en annan bild, till exempel från en innehållsförteckning.

Aspose.Slides for PHP via Java låter dig lägga till dessa länkar, kontrollera deras utseende och ljud, uppdatera deras egenskaper och ta bort dem. Exemplen nedan visar hur du arbetar med hyperlänkar på enskilda element och hur du får åtkomst till hyperlänkar på presentations-, bild- eller textram-nivå. De förutsätter att PHP/Java Bridge och Aspose.Slides PHP‑wrapper är initierade. API‑medlemmar utan en PHP‑referenssidlänk pekar på den underliggande Java‑API:n.

{{% alert color="info" title="Note" %}}
Du kan även redigera presentationer med den [kostnadsfria onlineredigeraren för Aspose PowerPoint](https://products.aspose.app/slides/sv/editor).
{{% /alert %}} 

## **Lägg till URL‑hyperlänkar**

Du kan tilldela en webbplats‑URL till text, en form eller en mediaram. Det element du tilldelar hyperlänken bestämmer klickområdet: en textdel länkar den markerade texten, medan en form eller ram länkar bildobjektet.

### **Lägg till URL‑hyperlänkar till text**

För att länka text till en webbplats, skicka en [Hyperlink](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/) till textdelens [setHyperlinkClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/sethyperlinkclick/)‑metod, som visas nedan. Endast den delen av texten blir klickbar.

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

### **Lägg till URL‑hyperlänkar till former och mediaramar**

För att göra en form eller ram klickbar, anropa dess [setHyperlinkClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/sethyperlinkclick/)‑metod. Hyperlänken tillhör själva objektet snarare än en textdel i det.

Samma tillvägagångssätt gäller för bild-, audio‑ och videoramar: tilldela hyperlänken till ramen och anropa [setTooltip](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/settooltip/) om så behövs.

Följande exempel gör en rektangel klickbar:

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

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Interna hyperlänkar låter läsare hoppa från en innehållsförteckning till en specifik bild. Följande exempel använder [setInternalHyperlinkClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) för att länka texten ”Page 2” på den första bilden till den andra bilden.

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

## **Formatera hyperlänkar**

### **Färg**

Metoden [setColorSource](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/setcolorsource/) för [Hyperlink](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/) bestämmer om en hyperlänk använder presentationens hyperlänksfärg eller textdelens formatering. För att tillämpa en anpassad textfärg, välj [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkcolorsource/) och ange delens fyllnadsfärg. Denna funktion introducerades i PowerPoint 2019; äldre versioner använder inte den här inställningen.

Följande exempel lägger till två text‑hyperlänkar på samma bild. Den första använder röd textfyllning, medan den andra behåller standard‑hyperlänksfärgen.

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

### **Ljud**

En hyperlänk kan spela ett ljud när den aktiveras eller stoppa ett ljud som redan spelas. Använd följande metoder för att konfigurera dessa beteenden:

- [Hyperlink::setSound](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/setsound/) specificerar ljudet som är kopplat till hyperlänken.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/setstopsoundonclick/) styr om aktiveringen av hyperlänken stoppar föregående ljud.

#### **Lägg till ett hyperlänksljud**

Följande exempel laddar `sampleaudio.wav` och kopplar det till en knapp på den första bilden. När knappen klickas spelas ljudet och navigerar till nästa bild. En andra form på samma bild stoppar det föregående ljudet när den klickas, utan att utföra någon navigering.

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

#### **Extrahera ett hyperlänksljud**

Följande exempel öppnar presentationen som skapades ovan och läser den första formens hyperlänks‑audio till minnet via [getSound](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/getsound/) och [getBinaryData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audio/getbinarydata/).

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

### **Verktygstips och interaktionsinställningar**

Du kan anropa följande [Hyperlink](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/)‑metoder efter att du har tilldelat en hyperlänk till text eller en form:

- [setTooltip](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/settooltip/) anger den text som en tittare kan se som ett tips för länken.
- [setTargetFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/settargetframe/) specificerar mål‑ramen inom ett föräldra‑HTML‑ramset, när tillämpligt.
- [setHistory](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/sethistory/) styr om aktiveringen av länken lägger till dess destination i listan över visade hyperlänkar.
- [setHighlightClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/sethighlightclick/) styr om hyperlänken markeras när den klickas.

## **Ta bort hyperlänkar från presentationer**

Använd [getAnyHyperlinks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) för att samla hyperlänksbehållare, inklusive länkar på textdelar, innan du ändrar dem. Följande exempel tar bort båda aktiveringstyperna från den första bilden. För att bara ta bort en typ, anropa endast [removeHyperlinkClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) eller [removeHyperlinkMouseOver](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); att ta bort en klickåtgärd tar inte bort motsvarande mus‑över‑åtgärd.

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

För ovillkorlig borttagning tar [removeAllHyperlinks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) bort båda aktiveringstyperna i den valda omfattningen i ett anrop. För selektiv rensning och täckning av masters, layouter och anteckningar, se [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Bygg ett komplett hyperlänksinventarium**

Innan du distribuerar en presentation bör du inventera dess interaktiva åtgärder samt dess webb‑länkar. [getAnyHyperlinks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) returnerar [IHyperlinkContainer](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ihyperlinkcontainer/)‑objekt, inte en platt lista med URL‑strängar. Inspektera både [getHyperlinkClick](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) och [getHyperlinkMouseOver](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) på varje behållare. De är oberoende: samma behållare kan exponera båda åtgärderna, så en komplett rapport kan behöva upp till två rader per behållare.

Att bara skanna hyperlänkar på formnivå kan missa länkar som är fästa på textdelar. Fråga istället den lämpliga omfattningen och behåll de returnerade behållarna så att du senare kan uppdatera eller ta bort deras åtgärder.

### **Fråga presentation‑, bild‑ och textram‑omfattningar**

Klassen [HyperlinkQueries](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/) är tillgänglig via [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) och [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/gethyperlinkqueries/). Varje omfattning stödjer samma frågor:

- [getHyperlinkClicks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) returnerar behållare med en klickåtgärd.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) returnerar behållare med en mus‑över‑åtgärd.
- [getAnyHyperlinks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) returnerar behållare med antingen eller båda åtgärderna.

Följande exempel skapar `hyperlink-audit-input.pptx` med en extern klicklänk, en fil‑mus‑över‑länk, intern bildnavigering, en text‑mus‑över‑länk och en makro‑åtgärd. Det utför ingen av dessa åtgärder. Samma tre frågor fungerar i varje omfattning; räknarna beskriver behållare, inte totala åtgärder. Textram‑omfattningen utesluter den omgivande formens egna länkar.

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

I detta exempel rapporterar presentation‑ och bildfrågor tre klickbehållare, två mus‑över‑behållare och tre behållare med antingen åtgärd. Textram‑frågan rapporterar en behållare i varje kategori.

### **Klassificera åtgärder och destinationer**

Använd [Hyperlink::getActionType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/getactiontype/) för att tolka en åtgärd innan destinationen tolkas. Värdena i [HyperlinkActionType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkactiontype/) omfattar mer än webbnavigering:

| Värden | Betydelse för auditering |
| --- | --- |
| `Hyperlink` | Extern hyperlänk; inspektera URL och dess schema. |
| `JumpSpecificSlide` | Intern navigering till en specifik bild. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Inbyggd bildspelsnavigering, löst i bildspelskontext. |
| `JumpEndShow`, `StartCustomSlideShow` | Avsluta aktuellt bildspel eller starta ett anpassat bildspel. |
| `StartMacro` | Exekvera ett makro. |
| `StartProgram` | Starta ett program. |
| `OpenFile`, `OpenPresentation` | Öppna en fil eller en annan presentation; granska separat från webbadresser. |
| `StartStopMedia` | Påbörja eller stoppa mediaplayback. |
| `NoAction`, `Unknown` | Ingen navigeringsåtgärd, eller en okänd åtgärd som kräver granskning. |

Läs externa destinationer via [getExternalUrl](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/getexternalurl/) och specifika interna destinationer via [getTargetSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/gettargetslide/). Interna åtgärder och inbyggda kommandon kan sakna extern URL; en tom URL betyder inte att behållaren saknar åtgärd. Bevara värdet från [getExternalUrlOriginal](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) när det skiljer sig från den normaliserade URL:en, och inkludera verktygstipset från [getTooltip](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlink/gettooltip/) när det finns.

### **Rapportera, sanera och verifiera hyperlänkar**

Följande PHP‑exempel läser en befintlig presentation (använd filen som skapades ovan), skriver `hyperlink-audit.json`, tillämpar en policy, sparar `hyperlink-sanitized.pptx` och öppnar den igen för att kontrollera båda aktiveringstyperna. Det samlar behållare innan de ändras och använder referenslikhet för att undvika att bearbeta samma behållare två gånger. Presentationsfrågor täcker vanliga bilder; för ett paket‑omfattande inventarium frågar den också explicit masters, layouter, anteckningar samt antecknings‑ och utdelnings‑masters när de finns.

Rapporten registrerar ett ett‑baserat bildindex och [getSlideId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseslide/#getSlideId--) där det finns. [ISlideComponent::getSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidecomponent/#getSlide--) levererar den ägande bilden för stödda behållare. Masters, layouter och anteckningar har inget vanligt bildindex och identifieras av sin omfattning. Form‑behållare och text‑del‑formateringsbehållare märks separat; andra behållartyper behåller sitt kör‑tids‑typnamn. Varje behållare får ett rapport‑lokalt ID så att dess två åtgärder kan korreleras. Rapporten lagrar åtgärdstyper som de heltalskonstanter som definieras av PHP‑enumerationen.

Denna avsiktligt restriktiva applikationspolicy tillåter endast absoluta HTTPS‑URL:er och giltiga interna bildmål. Den avvisar makron, program, fil‑åtgärder, andra bildspels‑åtgärder, okända åtgärder och andra URL‑scheman. Dessa avslag är policybeslut, inte ett säkerhetsbeslut från Aspose.Slides. HTTPS ensam etablerar inte förtroende: lägg till värd‑tillåtelistor och andra kontroller för din applikation. Både original‑ och normaliserade externa URL:er kontrolleras. Exemplet audit‑erar metadata utan att följa länkar eller köra åtgärder.

För åtgärd, stödjer behållarens [getHyperlinkManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) [setExternalHyperlinkClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) och [removeHyperlinkMouseOver](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Här ersätts förbjudna externa klicklänkar med en fast HTTPS‑landningssida; andra förbjudna klick‑ och mus‑över‑åtgärder tas bort oberoende. Sätt `$replaceExternalClicks` till `false` för att ta bort alla policy‑överträdelser istället. Välj en applikationsägd ersättningssida innan distribution.

Rapportens export‑flagga använder en konservativ PDF‑granskningspolicy: flagga mus‑över‑åtgärder och allt annat än en extern länk eller ett specifikt bildhopp som potentiellt icke‑stödd. Det är en granskningshint, inte ett kapabilitetstest eller en garanti för att omärkada länkar överlever export. Stödda [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/) och [HTML](/slides/sv/php-java/convert-powerpoint-to-html/)‑exporter kan bevara hyperlänkar, beroende på åtgärden, exportalternativ och visare. Raster‑[bilder](/slides/sv/php-java/convert-powerpoint-to-png/) och [video](/slides/sv/php-java/convert-powerpoint-to-video/) kan inte bevara interaktiva hyperlänkar; flagga varje åtgärd vid granskning för dessa utdata.

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

Med den input som skapats ovan innehåller rapporten fem åtgärdsrader. Fil‑mus‑över‑länken och makro‑klicken tas bort, medan HTTPS‑länkarna och den interna bildnavigeringen kvarstår. Verifieringen skriver ut noll förbjudna åtgärder. En input som innehåller en förbjuden extern klick‑URL övar även på ersättningsgrenen. En behållare med en tillåten klick‑ och en förbjuden mus‑över‑åtgärd behåller sin klick‑åtgärd.

Denna selektiva rensning skiljer sig från [removeAllHyperlinks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), som tar bort båda aktiveringstyperna i den valda omfattningen oavsett policy. Verifieringen här kontrollerar bara hyperlänks‑åtgärder; den tar inte bort inbäddade VBA‑projekt, OLE‑objekt eller annat aktivt innehåll, och den validerar inte en exporterad PDF‑ eller HTML‑fil.

## **FAQ**

**Hur kan jag länka till ett avsnitt eller dess första bild?**

Avsnitt i PowerPoint grupperar bilder, men en intern hyperlänk pekar på en enskild bild. För att skapa navigering till ett avsnitt, länka till den första bilden i det avsnittet.

**Kan jag fästa en hyperlänk på master‑bildens element så att den fungerar på alla bilder?**

Ja. Element på master‑bilder och layouter stödjer hyperlänkar. Länkar på dessa element är tillgängliga under bildspelsvisning på bilder som använder motsvarande master eller layout.

**Kommer hyperlänkar att bevaras vid export till PDF, HTML, bilder eller video?**

Stödda PDF‑ och HTML‑exporter kan bevara hyperlänkar; raster‑bilder och video kan det inte. Se export‑aspekterna i [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).