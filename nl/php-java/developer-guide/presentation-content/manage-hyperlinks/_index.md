---
title: Beheer presentatie-hyperlinks in PHP
linktitle: Beheer hyperlinks
type: docs
weight: 20
url: /nl/php-java/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- tekst-hyperlink
- dia-hyperlink
- vorm-hyperlink
- afbeelding-hyperlink
- video-hyperlink
- aanpasbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Hyperlinks toevoegen, opmaken, bijwerken en verwijderen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP via Java, met PHP-voorbeelden."
---
## **Inleiding**

Een hyperlink verbindt presentatietekst met een website of een locatie binnen de presentatie. In PowerPoint worden hyperlinks meestal voor twee doeleinden gebruikt:

* Een website openen vanuit tekst, een vorm of een mediaframe.
* Navigeren naar een andere dia, bijvoorbeeld vanuit een inhoudsopgave.

Aspose.Slides for PHP via Java stelt u in staat deze koppelingen toe te voegen, hun uiterlijk en geluid te beheren, hun eigenschappen bij te werken en ze te verwijderen. De onderstaande voorbeelden tonen hoe u met hyperlinks werkt op individuele elementen en hoe u hyperlinks benadert op presentatie-, dia- of tekstframe‑niveau. Er wordt aangenomen dat de PHP/Java Bridge en de Aspose.Slides PHP‑wrapper zijn geïnitialiseerd. API‑leden zonder een PHP‑referentie‑pagina linken naar de onderliggende Java‑API.

{{% alert color="info" title="Note" %}}
U kunt presentaties ook bewerken met de [gratis online Aspose PowerPoint‑editor](https://products.aspose.app/slides/nl/editor).
{{% /alert %}} 

## **URL‑hyperlinks toevoegen**

U kunt een website‑URL toewijzen aan tekst, een vorm of een mediaframe. Het element waaraan u de hyperlink toewijdt bepaalt het klikbare gebied: een tekstdelen koppelt de geselecteerde tekst, terwijl een vorm of frame het dia‑object koppelt.

### **URL‑hyperlinks aan tekst toevoegen**

Om tekst aan een website te koppelen, geeft u een [Hyperlink](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/) door aan de [setHyperlinkClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/sethyperlinkclick/)‑methode van de tekstdelen, zoals hieronder weergegeven. Alleen dat tekstdeel wordt klikbaar.

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

### **URL‑hyperlinks aan vormen en mediaframes toevoegen**

Om een vorm of frame klikbaar te maken, roept u de [setHyperlinkClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/sethyperlinkclick/)‑methode aan. De hyperlink hoort bij het object zelf en niet bij een tekstdelen daarin.

Dezelfde werkwijze geldt voor afbeelding‑, audio‑ en video‑frames: ken de hyperlink toe aan het frame en roep indien nodig [setTooltip](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/settooltip/) aan.

Het volgende voorbeeld maakt een rechthoek klikbaar:

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

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Interne hyperlinks laten lezers springen van een inhoudsopgave naar een specifieke dia. Het volgende voorbeeld gebruikt [setInternalHyperlinkClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) om de tekst “Page 2” op de eerste dia te koppelen aan de tweede dia.

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

## **Hyperlinks opmaken**

### **Kleur**

De [setColorSource](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/setcolorsource/)‑methode van [Hyperlink](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/) bepaalt of een hyperlink de hyperlink‑kleur van de presentatie of de opmaak van het tekstdelen gebruikt. Om een aangepaste tekstkleur toe te passen, selecteert u [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkcolorsource/) en stelt u de vulkleur van het tekstdelen in. Deze functie werd geïntroduceerd in PowerPoint 2019; oudere versies passen deze instelling niet toe.

Het volgende voorbeeld voegt twee tekst‑hyperlinks toe aan dezelfde dia. De eerste gebruikt een rode vulkleur, terwijl de tweede de standaard hyperlink‑kleur behoudt.

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
### **Geluid**

Een hyperlink kan een geluid afspelen wanneer geactiveerd, of een geluid stoppen dat al afspeelt. Gebruik de volgende methoden om dit gedrag te configureren:

- [Hyperlink::setSound](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/setsound/) specificeert het audio‑bestand dat aan de hyperlink is gekoppeld.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/setstopsoundonclick/) bepaalt of het activeren van de hyperlink het vorige geluid stopt.

#### **Een hyperlink‑geluid toevoegen**

Het volgende voorbeeld laadt `sampleaudio.wav` en koppelt het aan een knop op de eerste dia. Wanneer op de knop wordt geklikt, wordt het geluid afgespeeld en wordt naar de volgende dia genavigeerd. Een tweede vorm op die dia stopt het vorige geluid bij een klik, zonder een navigatie‑actie uit te voeren.

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

#### **Een hyperlink‑geluid extraheren**

Het volgende voorbeeld opent de hierboven gemaakte presentatie en leest het audio‑bestand van de hyperlink van de eerste vorm in het geheugen via [getSound](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/getsound/) en [getBinaryData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audio/getbinarydata/).

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

### **Tooltip‑ en interactie‑instellingen**

U kunt de volgende [Hyperlink](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/)‑methoden aanroepen nadat u een hyperlink aan tekst of een vorm hebt toegewezen:

- [setTooltip](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/settooltip/) stelt de tekst in die een kijker als hint voor de link kan weergeven.
- [setTargetFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/settargetframe/) geeft het doelframe op binnen een bovenliggend HTML‑frameset, indien van toepassing.
- [setHistory](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/sethistory/) bepaalt of het activeren van de link de bestemming toevoegt aan de lijst met bekeken hyperlinks.
- [setHighlightClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/sethighlightclick/) bepaalt of de hyperlink wordt gemarkeerd bij een klik.

## **Hyperlinks uit presentaties verwijderen**

Gebruik [getAnyHyperlinks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) om hyperlink‑containers, inclusief tekst‑deel‑koppelingen, te verzamelen voordat ze worden gewijzigd. Het volgende voorbeeld verwijdert beide activerings­typen van de eerste dia. Om slechts één type te verwijderen, roep alleen [removeHyperlinkClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) of [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) aan; het verwijderen van een klik‑actie verwijdert niet de bijbehorende muis‑over‑actie.

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

Voor onvoorwaardelijke verwijdering verwijdert [removeAllHyperlinks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) beide activerings­typen in de gekozen reikwijdte met één oproep. Voor selectieve opschoning en dekking van masters, lay-outs en notities, zie [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Een volledige hyperlink‑inventaris opbouwen**

Voordat u een presentatie verspreidt, maakt u een inventarisatie van de interactieve acties en de web‑koppelingen. [getAnyHyperlinks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) retourneert [IHyperlinkContainer](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkcontainer/)‑objecten, niet een eenvoudige lijst van URL‑strings. Inspecteer zowel [getHyperlinkClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) als [getHyperlinkMouseOver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) op elke container. Ze zijn onafhankelijk: dezelfde container kan beide acties bevatten, dus een volledige rapportage heeft tot twee rijen per container nodig.

Alleen hyperlinks op vorm‑niveau scannen kan koppelingen missen die aan tekstdelen zijn gekoppeld. Vraag in plaats daarvan de juiste reikwijdte op en bewaar de geretourneerde containers zodat u later hun acties kunt bijwerken of verwijderen.

### **Presentatie‑, dia‑ en tekst‑frame‑reikwijdtes queryen**

De klasse [HyperlinkQueries](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/) is beschikbaar via [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), en [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/gethyperlinkqueries/). Elke reikwijdte ondersteunt dezelfde queries:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) retourneert containers met een klik‑actie.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) retourneert containers met een muis‑over‑actie.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) retourneert containers met één of beide acties.

Het volgende voorbeeld maakt `hyperlink-audit-input.pptx` aan met een externe klik‑koppeling, een bestand‑muistoets‑koppeling, interne dia‑navigatie, een tekst‑muistoets‑koppeling en een macro‑actie. Het voert geen van deze acties uit. Dezelfde drie queries werken op elke reikwijdte; de aantallen beschrijven containers, niet het aantal acties. De tekst‑frame‑reikwijdte sluit de eigen koppelingen van de omsluitende vorm uit.

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

Voor dit voorbeeld rapporteren presentatie‑ en dia‑queries elk drie klik‑containers, twee muis‑over‑containers en drie containers met één van beide acties. De tekst‑frame‑query rapporteert één container in elke categorie.

### **Acties en bestemmingen classificeren**

Gebruik [Hyperlink::getActionType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/getactiontype/) om een actie te interpreteren vóór het interpreteren van de bestemming. De waarden van [HyperlinkActionType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkactiontype/) omvatten meer dan alleen web‑navigatie:

| Waarden | Betekenis voor een audit |
| --- | --- |
| `Hyperlink` | Externe hyperlink; controleer de URL en het schema. |
| `JumpSpecificSlide` | Interne navigatie naar een specifieke dia. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ingebouwde diavoorstelling‑navigatie, opgelost in de diavoorlees‑context. |
| `JumpEndShow`, `StartCustomSlideShow` | Huidige show beëindigen of een aangepaste show starten. |
| `StartMacro` | Een macro uitvoeren. |
| `StartProgram` | Een programma starten. |
| `OpenFile`, `OpenPresentation` | Een bestand of een andere presentatie openen; afzonderlijk beoordelen van web‑URL's. |
| `StartStopMedia` | Media‑afspelen starten of stoppen. |
| `NoAction`, `Unknown` | Geen navigatie‑actie, of een niet‑herkende actie die beoordeling vereist. |

Lees externe bestemmingen uit via [getExternalUrl](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/getexternalurl/) en specifieke interne bestemmingen via [getTargetSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/gettargetslide/). Interne acties en ingebouwde commando's kunnen geen externe URL hebben; een lege URL betekent niet dat de container geen actie heeft. Bewaar de waarde die wordt geretourneerd door [getExternalUrlOriginal](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) wanneer die afwijkt van de genormaliseerde URL, en neem de tooltip op die wordt geretourneerd door [getTooltip](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlink/gettooltip/) indien beschikbaar.

### **Hyperlinks rapporteren, saneren en verifiëren**

Het volgende PHP‑voorbeeld leest een bestaande presentatie (gebruik het hierboven gemaakte bestand), schrijft `hyperlink-audit.json`, past een beleid toe, slaat `hyperlink-sanitized.pptx` op en opent het opnieuw om beide activerings‑typen opnieuw te controleren. Het verzamelt containers voordat ze worden gewijzigd en gebruikt referentie‑gelijkheid om te voorkomen dat dezelfde container twee keer wordt verwerkt. Presentatie‑queries bestrijken gewone dia's; voor een pakket‑brede inventarisatie queryt het ook expliciet masters, lay-outs, notities en de notitie‑ en handout‑masters wanneer aanwezig.

Dit bewust strenge toepassingsbeleid staat alleen absolute HTTPS‑URL's en geldige interne dia‑doelen toe. Het wijst macro's, programma's, bestand‑acties, andere diavoorstelling‑acties, onbekende acties en andere URL‑schema's af. Deze afwijzingen zijn beleidsbeslissingen, geen veiligheidsbeoordeling van Aspose.Slides. Alleen HTTPS biedt geen vertrouwen: voeg host‑allow‑lists en andere controles toe voor uw toepassing. Zowel originele als genormaliseerde externe URL's worden gecontroleerd. Het voorbeeld controleert metadata zonder de links te volgen of acties uit te voeren.

Voor correctie ondersteunt de [getHyperlinkManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) van de container [setExternalHyperlinkClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) en [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Hier worden verboden externe klik‑koppelingen vervangen door een vaste HTTPS‑landingspagina; andere verboden klikken en verboden muis‑over‑acties worden onafhankelijk verwijderd. Stel `$replaceExternalClicks` in op `false` om alle beleids­schendingen te verwijderen. Kies een vervangingspagina die eigendom is van de applicatie vóór implementatie.

De export‑vlag van het rapport gebruikt een conservatief PDF‑review‑beleid: markeer muis‑over‑acties en alles behalve een externe koppeling of een specifieke dia‑sprong als mogelijk niet‑ondersteund. Het is een beoordelingstip, geen capaciteits‑test of garantie dat niet‑gemarkeerde koppelingen de export overleven. Ondersteunde [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/)‑ en [HTML](/slides/nl/php-java/convert-powerpoint-to-html/)‑exports kunnen hyperlinks behouden, afhankelijk van de actie, exportopties en viewer. Raster‑[images](/slides/nl/php-java/convert-powerpoint-to-png/) en [video](/slides/nl/php-java/convert-powerpoint-to-video/) kunnen geen interactieve hyperlinks behouden; markeer elke actie bij het auditen voor die output.

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

Met de hierboven gemaakte invoer bevat het rapport vijf actierijen. De bestand‑muistoets‑koppeling en de macro‑klik worden verwijderd, terwijl de HTTPS‑koppelingen en interne dia‑navigatie behouden blijven. De verificatie geeft nul verboden acties weer. Een invoer die een verboden externe klik‑URL bevat, test ook de vervangings‑tak. Een container met een toegestane klik en een verboden muis‑over behoudt zijn klik‑actie.

Deze selectieve opschoning verschilt van [removeAllHyperlinks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), die beide activerings­typen verwijdert in de geselecteerde reikwijdte, ongeacht het beleid. De verificatie hier controleert alleen hyperlink‑acties; het verwijdert geen ingebedde VBA‑projecten, OLE‑objecten of andere actieve inhoud, en het valideert geen geëxporteerd PDF‑ of HTML‑bestand.

## **FAQ**

**Hoe kan ik naar een sectie of de eerste dia daarvan linken?**

Secties in PowerPoint groeperen dia's, maar een interne hyperlink richt zich op een individuele dia. Om navigatie naar een sectie te maken, linkt u naar de eerste dia van die sectie.

**Kan ik een hyperlink aan elementen van de master‑dia koppelen zodat deze op alle dia's werkt?**

Ja. Master‑dia‑ en lay‑outelementen ondersteunen hyperlinks. Koppelingen op deze elementen zijn beschikbaar tijdens de diavoorstelling op dia's die de betreffende master of lay‑out gebruiken.

**Worden hyperlinks behouden bij export naar PDF, HTML, afbeeldingen of video?**

Ondersteunde PDF‑ en HTML‑exports kunnen hyperlinks behouden; raster‑afbeeldingen en video kunnen dat niet. Zie de exportoverwegingen in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).