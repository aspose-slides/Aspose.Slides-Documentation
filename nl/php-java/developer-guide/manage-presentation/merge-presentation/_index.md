---
title: Presentaties efficiënt samenvoegen in PHP
linktitle: Presentaties samenvoegen
type: docs
weight: 40
url: /nl/php-java/merge-presentation/
keywords:
- PowerPoint samenvoegen
- presentaties samenvoegen
- dia's samenvoegen
- PPT samenvoegen
- PPTX samenvoegen
- ODP samenvoegen
- PowerPoint combineren
- presentaties combineren
- dia's combineren
- PPT combineren
- PPTX combineren
- ODP combineren
- PHP
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties in PHP kunt samenvoegen door dia's te klonen, masters en lay-outs te beheren, dia-inhoud te schalen, secties te behouden en beveiligde of grote bestanden te verwerken."
---
## **Overzicht**

Aspose.Slides for PHP via Java voegt presentaties samen door dia's te klonen van één [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) naar een andere. De hoofdoperatie is [SlideCollection::addClone()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/), die de opmaak van de bron‑dia kan behouden of de gekloonde dia kan koppelen aan een master of lay‑out in de doel‑presentatie.

Dit artikel behandelt de meest voorkomende samenvoeg‑werkstromen:

- alle dia's samenvoegen met behoud van hun bron‑opmaak;
- geselecteerde dia's samenvoegen;
- een master van de doel‑presentatie toepassen;
- een specifieke lay‑out van de doel‑presentatie toepassen;
- verschillende dia‑groottes normaliseren vóór het samenvoegen;
- gekloonde dia's aan een sectie toevoegen;
- meerdere presentaties in één end‑to‑end‑workflow samenvoegen;
- omgaan met masters, resources, notities, opmerkingen, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑aspecten.

## **Hoe Dia‑Klonen Masters en Lay‑outs Beïnvloedt**

Een dia erft een groot deel van zijn uiterlijk van zijn lay‑out en master. Om die reden bepaalt de overload van het klonen die je kiest hoe de samengevoegde dia in de doel‑presentatie wordt geïntegreerd.

Gebruik [SlideCollection::addClone()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) op een van de volgende manieren:

- `addClone(sourceSlide)` — behoudt de lay‑out en opmaak van de bron‑dia. Indien nodig kan de bron‑master automatisch in de doel‑presentatie worden gekloond. Aspose.Slides houdt automatisch gekloonde masters bij zodat herhaalde dia's die dezelfde bron‑master gebruiken die master niet meerdere keren klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — koppelt de gekloonde dia aan een specifieke doel‑[MasterSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/). Aspose.Slides zoekt onder die master naar een overeenkomstige lay‑out op type of naam.
- `addClone(sourceSlide, destinationLayout)` — koppelt de gekloonde dia rechtstreeks aan een specifieke doel‑[LayoutSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/).

De master of lay‑out die aan een `addClone`‑overload wordt doorgegeven, moet tot de **doel‑**presentatie behoren, niet tot de bron‑presentatie.

## **Gehele Presentaties Samenvoegen en Bron‑Opmaak Behouden**

De simpelste samenvoeging kopieert elke dia van de bron‑presentatie naar de doel‑presentatie. Dit is de juiste keuze wanneer de geïmporteerde dia's hun oorspronkelijke thema, master en lay‑outrelaties moeten behouden.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

De resulterende presentatie kan meerdere masters bevatten wanneer bron‑ en doel‑presentatie verschillende designs gebruiken. Dit is te verwachten wanneer bron‑opmaak bewust wordt behouden.

## **Geselecteerde Dia's Samenvoegen**

Je hoeft niet elke dia te klonen. Het onderstaande voorbeeld importeert alleen geselecteerde dia‑indexen uit de bron‑presentatie.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Valideer dia‑indexen vóór het klonen wanneer ze afkomstig zijn van gebruikersinvoer of externe configuratie.

## **Dia's Samenvoegen met een Doel‑Master**

Gebruik de overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) wanneer geïmporteerde dia's een master moeten volgen die al tot de doel‑presentatie behoort.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides selecteert een passende lay‑out onder de opgegeven master door het type of de naam van de bron‑lay‑out te vergelijken. Als er geen geschikte lay‑out bestaat en `allowCloneMissingLayout` is `true`, wordt de bron‑lay‑out gekloond zodat de dia kan worden toegevoegd. Als deze `false` is, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxeditexception/) gegooid.

Gebruik `false` wanneer je wilt dat de samenvoeging faalt in plaats van een extra lay‑out aan de doel‑master toe te voegen.

## **Dia's Samenvoegen met een Specifieke Doel‑Lay‑out**

Gebruik de overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) wanneer je precies weet welke doel‑lay‑out de geïmporteerde dia's moeten gebruiken.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Het toepassen van een doel‑lay‑out wijzigt de geërfde lay‑outrelatie; het ontwerpt de inhoud van de bron‑dia niet opnieuw. Als bron‑ en doel‑lay‑outs verschillende placeholder‑structuren hebben, inspecteer dan het resultaat om te bevestigen dat de overgenomen opmaak en placeholder‑gedrag passend zijn.

## **Presentaties Met Verschillende Dia‑Grootten Samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar een dia klonen naar een presentatie met een andere dia‑grootte herontwerpt de inhoud niet automatisch voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied terechtkomen.

Een praktische aanpak is om de bron‑presentatie eerst te schalen. De methode [SlideSize::setSize()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesize/setsize/) kan bestaande inhoud schalen terwijl de dia‑afmetingen worden aangepast. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesizescaletype/) schaalt de inhoud zodat deze in de gevraagde grootte past.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Schalen wijzigt het bron‑presentatieobject in het geheugen. Als je de originele bron‑presentatie ongewijzigd wilt houden voor andere bewerkingen, open dan een aparte instantie voor de samenvoeging.

## **Dia's Samenvoegen in een Presentatie‑Sectie**

De basale dia‑klonlus recreateert niet de sectiehiera­chie van de bron‑presentatie. Als secties van belang zijn in de output, creëer of selecteer dan secties in de doel‑presentatie en kloon dia's expliciet naar hen met [addClone(Slide, Section)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

De gekloonde dia's worden toegevoegd aan de opgegeven doel‑sectie. Om meerdere bron‑secties te behouden, doorloop [Presentation::getSections](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSections), haal de huidige dia's van elke bron‑sectie op met [Section::getSlidesListOfSection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Section/#getSlidesListOfSection), recreëer de secties in de doel‑presentatie en kloon elke opgehaalde dia naar de corresponderende doel‑sectie. Zie [Manage Slide Sections](/slides/nl/php-java/slide-section/) voor een compleet voorbeeld van sectie‑enumeratie, inclusief lege secties en structurele wijzigingen.

## **Meerdere Presentaties Veilig Samenvoegen**

Het volgende end‑to‑end‑voorbeeld gebruikt de eerste presentatie als doel, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen geopend zolang deze wordt gekopieerd, en slaat het eind‑bestand één keer op.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

Dit vormt een nuttige basis voor het behouden van de bron‑opmaak van geïmporteerde dia's. Als je output een enkel doel‑thema moet gebruiken, vervang dan de eenvoudige `addClone($slide)`‑aanroep door de eerder getoonde overload die een doel‑master of doel‑lay‑out accepteert.

## **Praktische Overwegingen**

### **Masters, Lay‑outs en Opmaak‑Fideliteit**

Standaard dia‑klonen kan een benodigde bron‑master automatisch naar de doel‑presentatie brengen. Aspose.Slides houdt een intern register bij van automatisch gekloonde masters om te voorkomen dat dezelfde master herhaaldelijk wordt geklond. Handmatig gekloonde masters worden niet bijgehouden door dat register, dus vermijd het vooraf klonen van masters tenzij je expliciete controle over de master‑structuur nodig hebt.

Ga er niet van uit dat twee masters of lay‑outs met dezelfde naam visueel gelijk zijn. Als een bedrijfs‑template het uiteindelijke uiterlijk moet bepalen, kies dan expliciet een doel‑master of -lay‑out en controleer het resultaat na het samenvoegen.

### **Notities en Opmerkingen**

Sprekersnotities en dia‑commentaren zijn gekoppeld aan de dia‑inhoud en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt ook specifieke API's voor [presentation notes](/slides/nl/php-java/presentation-notes/) en [presentation comments](/slides/nl/php-java/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat notitie‑masters presentatieniveau‑objecten zijn en kunnen verschillen tussen bron‑bestanden. Voor review‑werkstromen, controleer ook de auteurs van opmerkingen en geneste discussies nadat bestanden van verschillende auteurs of templates zijn gecombineerd.

### **Afbeeldingen, Audio, Video, OLE‑objecten en Externe Links**

Dia's kunnen verwijzen naar presentatieniveau‑resources zoals afbeeldingen, ingebedde audio, ingebedde video en OLE‑gegevens. Kloon de hele dia in plaats van alleen de zichtbare vormen zodat Aspose.Slides de relaties van de dia naar zijn resources kan behouden.

Ingebedde en gelinkte resources moeten verschillend worden behandeld. Een gelinkte audio, video, OLE‑object of hyperlink blijft afhankelijk van zijn externe doel; het klonen van een dia maakt een externe link niet tot ingebedde inhoud. Test gelinkte‑resource‑paden en URL's in de omgeving waarin de samengevoegde presentatie wordt geopend.

Aspose.Slides houdt automatisch gekloonde masters bij, maar dit moet niet worden gezien als een algemene garantie dat identieke binaire resources uit niet‑gerelateerde bron‑presentaties altijd worden gede‑dupliseerd. Als de bestandsgrootte van belang is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingebedde Lettertypen en Beschikbaarheid van Lettertypen**

Lettertypen worden op presentatieniveau beheerd. Als typografie consistent moet blijven over verschillende machines, ga er niet van uit dat alleen dia‑klonen garandeert dat elk nodig lettertype beschikbaar is in de doel‑omgeving. Je kunt ingebedde lettertypen bekijken met [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getembeddedfonts/) en expliciet beheren zoals beschreven in [Embed Fonts in Presentations](/slides/nl/php-java/embedded-font/).

Controleer ook dat je toestemming hebt om de lettertypen die in de bron‑bestanden worden gebruikt, in te sluiten. Licenties kunnen het insluiten van lettertypen beperken.

### **Wachtwoord‑Beschermde Presentaties**

Een wachtwoord‑beschermde bron moet succesvol worden geopend voordat de dia's kunnen worden gekloond. Geef het wachtwoord door via [LoadOptions::setPassword()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Werk met de gedecodeerde presentatie.
} finally {
    $source->dispose();
}
```

Het openen van een versleutelde bron past de bescherming niet automatisch toe op de doel‑presentatie. Configureer de output‑bescherming afzonderlijk wanneer dit vereist is.

### **Grote Presentaties en Geheugengebruik**

Grote presentaties met hoge resolutie‑afbeeldingen, audio, video of andere grote binaire objecten kunnen veel geheugen verbruiken. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) biedt controle over BLOB‑afhandeling en tijdelijk‑bestandgebruik. Zie [Open Presentations](/slides/nl/php-java/open-presentation/#open-large-presentations) voor een PHP‑via‑Java‑voorbeeld met grote bestanden.

Voor grote bestanden, laad bij voorkeur via bestandspaden, verwijder elke bron‑presentatie zodra deze is samengevoegd, en vermijd herhaaldelijk opslaan van tussentijdse resultaten tenzij de workflow checkpoints vereist.

### **Thread‑Veiligheid**

Laad, wijzig, sla op of kloon geen [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instanties in meerdere threads. Deze bewerkingen worden niet ondersteund voor multithreaded gebruik in PHP via Java. Als je parallelle samenvoeg‑taken nodig hebt, voer ze dan uit in afzonderlijke single‑threaded processen, elk met eigen presentatie‑instanties, en volg de [Aspose.Slides multithreading guidance](/slides/nl/php-java/multithreading/).

## **FAQ**

**Hoe behoud ik het oorspronkelijke ontwerp van elke bron‑presentatie?**

Gebruik [SlideCollection::addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) zonder een doel‑master of -lay‑out op te geven. Aspose.Slides kan de bron‑master automatisch klonen wanneer deze door de geïmporteerde dia nodig is.

**Hoe zorg ik dat geïmporteerde dia's het doel‑thema gebruiken?**

Gebruik de overload die een doel‑master accepteert. Geef een master uit de doel‑presentatie op, niet uit de bron. Aspose.Slides zal proberen elke bron‑dia toe te wijzen aan een geschikte lay‑out onder die master.

**Wanneer moet ik een specifieke doel‑lay‑out gebruiken in plaats van een doel‑master?**

Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer je wilt dat Aspose.Slides kiest tussen de lay‑outs van die master op basis van het type of de naam van de bron‑lay‑out.

**Kunnen presentaties met verschillende dia‑groottes worden samengevoegd?**

Ja, maar de inhoud van de dia wordt niet automatisch herontworpen voor de doel‑afmetingen. Schaal de bron‑presentatie eerst wanneer je voorspelbare plaatsing nodig hebt, bijvoorbeeld met [SlideSize::setSize()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesize/setsize/) en [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesizescaletype/).

**Kan ik PPT, PPTX en ODP presentaties in één bestand samenvoegen?**

Ja. Laad elke bron‑presentatie, kloon de benodigde dia's naar één doel‑presentatie en sla de doel‑presentatie op in een ondersteund output‑formaat. Omdat presentaties verschillende featuresets hebben, controleer complexe inhoud na cross‑format samenvoegingen. Zie [Supported File Formats](/slides/nl/php-java/supported-file-formats/).

**Worden bron‑secties automatisch behouden?**

Niet door een eenvoudige lus die alleen dia's kloont. Creëer de benodigde secties in de doel‑presentatie en gebruik de sectie‑overload van [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) wanneer de sectiestructuur behouden moet blijven.

**Worden sprekersnotities en opmerkingen behouden?**

Ze worden gekopieerd met de gekloonde dia. Voor workflows die afhankelijk zijn van notitie‑master‑styling, opmerking‑auteurs of geneste review‑data, controleer het samengevoegde resultaat omdat deze scenario's zowel presentatieniveau‑structuren als dia‑niveau‑inhoud betreffen.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingebedde content wordt meegenomen als onderdeel van de resource‑relaties van de gekloonde dia. Externe links blijven extern, dus hun doelbestanden of URL’s moeten nog steeds beschikbaar zijn na het samenvoegen.

**Zijn ingebedde lettertypen van elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**

Vertrouw niet alleen op dia‑klonen voor lettertype‑distributie. Inspecteer de ingebedde lettertypen van de doel‑presentatie en beheer het insluiten of de beschikbaarheid van externe lettertypen expliciet wanneer typografie belangrijk is.

**Hoe merge ik een wachtwoord‑beschermd bestand?**

Open het met het juiste [LoadOptions::setPassword()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/setpassword/), kloon daarna de dia's normaal. De output‑bescherming wordt apart geconfigureerd.

**Hoe ga ik om met zeer grote presentaties?**

Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugen belasten, laad bij voorkeur via bestandspaden voor zeer grote bestanden, verwijder bron‑presentaties direct na gebruik en sla het eindresultaat alleen op wanneer dat nodig is.

**Kan ik dia's uit meerdere threads samenvoegen?**

Het laden, opslaan of klonen van presentaties in meerdere threads wordt niet ondersteund in PHP via Java. Voor parallelle taken, gebruik afzonderlijke single‑threaded processen en houd presentatie‑instanties geïsoleerd binnen elk proces.