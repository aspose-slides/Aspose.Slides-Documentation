---
title: Efficiënt presentaties samenvoegen in PHP
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
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties kunt samenvoegen in PHP door dia's te klonen, masters en lay-outs te beheren, dia-inhoud te schalen, secties te behouden en beschermde of grote bestanden af te handelen."
---
## **Overzicht**

Aspose.Slides voor PHP via Java voegt presentaties samen door dia's te klonen van één [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) naar een andere. De hoofdoperatie is [SlideCollection::addClone()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/), die de opmaak van de bron‑dia kan behouden of de gekloonde dia kan koppelen aan een master of lay‑out in de doelpresentatie.

Dit artikel behandelt de meest voorkomende samenvoegworkflows:

- alle dia's samenvoegen met behoud van de bronopmaak;
- geselecteerde dia's samenvoegen;
- een master uit de doelpresentatie toepassen;
- een specifieke lay‑out uit de doelpresentatie toepassen;
- verschillende diaformaten normaliseren vóór het samenvoegen;
- gekloonde dia's toevoegen aan een sectie;
- meerdere presentaties samenvoegen in één end‑to‑end workflow;
- masters, bronnen, notities, opmerkingen, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑aspecten afhandelen.

## **Hoe Dia‑klonen Masters en Lay‑outs Beïnvloedt**

Een dia erft een groot deel van zijn uiterlijk van zijn lay‑out en master. Om die reden bepaalt de overload voor klonen die u kiest hoe de samengevoegde dia wordt geïntegreerd in de doelpresentatie.

Gebruik [SlideCollection::addClone()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) op een van de volgende manieren:

- `addClone(sourceSlide)` — behoudt de lay‑out en opmaak van de bron‑dia. Indien nodig kan de bron‑master automatisch in de doelpresentatie worden gekloond. Aspose.Slides houdt bij welke masters automatisch zijn gekloond zodat herhaalde dia's die dezelfde bron‑master gebruiken die master niet herhaaldelijk klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — koppel de gekloonde dia aan een specifieke doel-[MasterSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/). Aspose.Slides zoekt een overeenkomende lay‑out onder die master op basis van lay‑outtype of naam.
- `addClone(sourceSlide, destinationLayout)` — koppel de gekloonde dia rechtstreeks aan een specifieke doel-[LayoutSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/).

De master of lay‑out die aan een `addClone`‑overload wordt doorgegeven, moet tot de **doel**‑presentatie behoren, niet tot de bron‑presentatie.

## **Volledige Presentaties Samenvoegen en Bronopmaak Behouden**

De eenvoudigste samenvoeging kopieert elke dia van de bron‑presentatie naar de doel‑presentatie. Dit is de juiste keuze wanneer de geïmporteerde dia's hun oorspronkelijke thema, master en lay‑outrelaties moeten behouden.

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

De resulterende presentatie kan meerdere masters bevatten wanneer de bron en het doel verschillende ontwerpen gebruiken. Dit is te verwachten wanneer de bronopmaak opzettelijk wordt behouden.

## **Geselecteerde Dia's Samenvoegen**

U hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen geselecteerde dia‑indexen uit de bron‑presentatie.

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

Valideer dia‑indexen vóór het klonen wanneer deze afkomstig zijn van gebruikersinvoer of externe configuratie.

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

Aspose.Slides selecteert een geschikte lay‑out onder de opgegeven master door het type of de naam van de bron‑lay‑out te vergelijken. Als er geen passende lay‑out bestaat en `allowCloneMissingLayout` is `true`, wordt de bron‑lay‑out gekloond zodat de dia kan worden toegevoegd. Is deze `false`, dan wordt een [PptxEditException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxeditexception/) gegooid.

Gebruik `false` wanneer u wilt dat de samenvoeging faalt in plaats van een extra lay‑out toe te voegen aan de doel‑master.

## **Dia's Samenvoegen met een Specifieke Doel‑Lay‑out**

Gebruik de overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) wanneer u precies weet welke doel‑lay‑out de geïmporteerde dia's moeten gebruiken.

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

Het toepassen van een doel‑lay‑out wijzigt de geërfde lay‑outrelatie; het herziet de inhoud van de bron‑dia niet. Als de bron‑ en doel‑lay‑outs verschillende placeholder‑structuren hebben, inspecteer dan het resultaat om te bevestigen dat de geërfde opmaak en placeholder‑gedrag passend zijn.

## **Presentaties Met Verschillende Dia‑groottes Samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar het klonen van een dia naar een presentatie met een andere dia‑grootte herontwerpt de inhoud niet automatisch voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied verschijnen.

Een praktische aanpak is het aanpassen van de grootte van de bron‑presentatie vóór het klonen. De methode [SlideSize::setSize()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesize/setsize/) kan bestaande inhoud schalen terwijl de dia‑afmetingen worden gewijzigd. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesizescaletype/) schaalt inhoud zodat deze binnen de gevraagde grootte past.

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

Het aanpassen van de grootte wijzigt het bron‑presentatie‑object in het geheugen. Als u de originele bron‑presentatie ongewijzigd wilt houden voor andere bewerkingen, open dan een aparte instantie voor de samenvoeging.

## **Dia's Samenvoegen in een Presentatie‑Sectie**

De basis‑dia‑klonlus reproduiceert de sectie‑hiërarchie van de bron‑presentatie niet. Als secties belangrijk zijn in de uitvoer, maak of selecteer dan secties in de doel‑presentatie en kloon dia's expliciet naar deze secties met [addClone(Slide, Section)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/).

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

De gekloonde dia's worden toegevoegd aan de opgegeven doel‑sectie. Om meerdere bron‑secties te behouden, maak die secties opnieuw aan in de doel‑presentatie en koppel elke bron‑dia aan de overeenkomstige doel‑sectie.

## **Meerdere Presentaties Veilig Samenvoegen**

Het volgende end‑to‑end voorbeeld gebruikt de eerste presentatie als doel, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen open zolang deze wordt gekopieerd, en slaat het uiteindelijke bestand één keer op.

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

Dit vormt een nuttige basis voor het behouden van de bronopmaak van geïmporteerde dia's. Als uw uitvoer één enkel doel‑thema moet gebruiken, vervang dan de eenvoudige `addClone($slide)`‑aanroep door de eerder getoonde overload voor doel‑master of doel‑lay‑out.

## **Praktische Overwegingen**

### **Masters, Lay‑outs en Opmaakkwaliteit**

Standaard dia‑klonen kan automatisch een benodigde bron‑master in de doel‑presentatie brengen. Aspose.Slides houdt een interne register bij voor automatisch gekloonde masters om te voorkomen dat dezelfde master herhaaldelijk wordt gekloond. Handmatig gekloonde masters worden niet in dat register bijgehouden, dus vermijd vooraf klonen van masters tenzij u expliciete controle over de master‑structuur nodig heeft.

Ga er niet van uit dat twee masters of lay‑outs met dezelfde naam visueel gelijk zijn. Als een bedrijfs­template het uiteindelijke uiterlijk moet bepalen, kies dan expliciet een doel‑master of -lay‑out en verifieer het resultaat na het samenvoegen.

### **Notities en Opmerkingen**

Sprekers‑notities en dia‑commentaren zijn gekoppeld aan de dia‑inhoud en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt ook speciale API’s voor [presentation notes](https://docs.aspose.com/slides/nl/php-java/presentation-notes/) en [presentation comments](https://docs.aspose.com/slides/nl/php-java/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat note‑masters presentatie‑niveau objecten zijn en kunnen verschillen tussen bronbestanden. Voor review‑workflows controleer ook de auteurs van opmerkingen en geneste commentaren na het combineren van bestanden van verschillende auteurs of templates.

### **Afbeeldingen, Audio, Video, OLE‑objecten en Externe Links**

Dia’s kunnen verwijzen naar presentatie‑niveau bronnen zoals afbeeldingen, ingesloten audio, ingesloten video en OLE‑data. Kloon de dia zelf i.p.v. alleen de zichtbare vormen te kopiëren zodat Aspose.Slides de relaties van de dia met zijn bronnen kan behouden.

Ingesloten en gekoppelde bronnen moeten anders behandeld worden. Een gekoppelde audio, video, OLE‑object of hyperlink blijft afhankelijk van het externe doel; het klonen van een dia maakt van een externe link geen ingesloten inhoud. Test de paden en URL‑s van gekoppelde bronnen in de omgeving waarin de samengevoegde presentatie wordt geopend.

Aspose.Slides houdt expliciet bij welke masters automatisch zijn gekloond, maar dit moet niet worden gezien als een algemene garantie dat identieke binaire bronnen uit niet‑gerelateerde bron‑presentaties altijd worden gededupliceerd. Als de bestandsgrootte van de uitvoer belangrijk is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingesloten Lettertypen en Beschikbaarheid van Lettertypen**

Lettertypen worden op presentatie‑niveau beheerd. Als typografie consistent moet blijven over verschillende machines, ga er dan niet van uit dat alleen het klonen van dia’s garandeert dat elk benodigd lettertype beschikbaar is in de doelomgeving. U kunt ingesloten lettertypen inspecteren met [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getembeddedfonts/) en het insluiten expliciet beheren zoals beschreven in [Embed Fonts in Presentations](https://docs.aspose.com/slides/nl/php-java/embedded-font/).

Controleer ook of u toestemming heeft om de lettertypen die door de bronbestanden worden gebruikt in te sluiten. Lettertype‑licenties kunnen het insluiten beperken.

### **Wachtwoord‑beveiligde Presentaties**

Een wachtwoord‑beveiligde bron moet succesvol worden geopend voordat de dia’s gekloond kunnen worden. Geef het wachtwoord door via [LoadOptions::setPassword()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Werk met de ontcijferde presentatie.
} finally {
    $source->dispose();
}
```

Het openen van een versleutelde bron past de dezelfde bescherming niet automatisch toe op de doel‑presentatie. Configureer de uitvoerbeveiliging separaat wanneer dat vereist is.

### **Grote Presentaties en Geheugengebruik**

Grote presentaties met hoge‑resolutie afbeeldingen, audio, video of andere grote binaire objecten kunnen veel geheugen verbruiken. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) biedt controle over BLOB‑verwerking en gebruik van tijdelijke bestanden. Zie [Open Presentations](https://docs.aspose.com/slides/nl/php-java/open-presentation/#open-large-presentations) voor een PHP‑via‑Java voorbeeld met grote bestanden.

Voor grote bestanden heeft het de voorkeur om te laden vanaf bestandspaden wanneer mogelijk, elke bron‑presentatie direct na het samenvoegen vrij te geven, en herhaaldelijk opslaan van tussenresultaten te vermijden tenzij de workflow checkpoints vereist.

### **Thread Safety**

Laad, wijzig, sla op of kloon geen [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instanties in meerdere threads. Deze bewerkingen worden niet ondersteund voor multithreaded gebruik in PHP via Java. Als u parallelle samenvoeg‑taken nodig hebt, voer ze uit in afzonderlijke single‑threaded processen, waarbij elk proces zijn eigen presentatie‑instanties gebruikt, en volg de [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/nl/php-java/multithreading/).

## **FAQ**

**Hoe behoud ik het oorspronkelijke ontwerp van elke bron‑presentatie?**  
Gebruik [`addClone(sourceSlide)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) zonder een doel‑master of -lay‑out op te geven. Aspose.Slides kan de benodigde bron‑master automatisch klonen wanneer de geïmporteerde dia dit vereist.

**Hoe laat ik geïmporteerde dia’s het doel‑thema gebruiken?**  
Gebruik de overload die een doel‑master accepteert. Geef een master uit de doel‑presentatie op, niet uit de bron. Aspose.Slides probeert elke bron‑dia aan een passende lay‑out onder die master te koppelen.

**Wanneer moet ik een specifieke doel‑lay‑out gebruiken in plaats van een doel‑master?**  
Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer u wilt dat Aspose.Slides een lay‑out kiest op basis van het type of de naam van de bron‑lay‑out.

**Kunnen presentaties met verschillende dia‑groottes worden samengevoegd?**  
Ja, maar de inhoud van de dia wordt niet automatisch herontworpen voor de bestemmingsafmetingen. Pas eerst de bron‑presentatie aan in grootte wanneer u voorspelbare plaatsing nodig heeft, bijvoorbeeld met [SlideSize::setSize()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesize/setsize/) en [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesizescaletype/).

**Kan ik PPT, PPTX en ODP presentaties tot één bestand combineren?**  
Ja. Laad elke bron‑presentatie, kloon de benodigde dia’s naar één doel‑presentatie en sla de doel‑presentatie op in een ondersteund uitvoerformaat. Omdat presentatie‑formaten niet exact dezelfde functionaliteit bieden, controleer complexe inhoud na cross‑format samenvoegingen. Zie [Supported File Formats](https://docs.aspose.com/slides/nl/php-java/supported-file-formats/).

**Worden bron‑secties automatisch behouden?**  
Niet door een eenvoudige lus die alleen dia’s kloont. Maak de benodigde secties in de doel‑presentatie opnieuw aan en gebruik de sectie‑overload van [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) wanneer de sectiestructuur moet worden behouden.

**Worden sprekernotities en opmerkingen behouden?**  
Ja, ze worden meegekopieerd met de gekloonde dia. Controleer bij workflows die afhankelijk zijn van note‑master styling, commentauteurs of geneste review‑data het samengevoegde resultaat, omdat deze scenario’s zowel presentatie‑niveau als dia‑niveau structuren omvatten.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**  
Ingesloten content wordt meegenomen als onderdeel van de gekloonde dia‑resource‑relaties. Externe links blijven extern, dus de doel‑bestanden of URL’s moeten nog steeds beschikbaar zijn na de samenvoeging.

**Zijn ingesloten lettertypen van elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**  
Vertrouw niet uitsluitend op dia‑klonen voor lettertype‑distributie. Inspecteer de ingesloten lettertypen van de doel‑presentatie en beheer het insluiten of de beschikbaarheid van externe lettertypen expliciet wanneer typografie belangrijk is.

**Hoe voeg ik een wachtwoord‑beveiligd bestand samen?**  
Open het met het juiste [LoadOptions::setPassword()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/setpassword/), kloon daarna de dia’s normaal. De bescherming van de uitvoer wordt apart geconfigureerd.

**Hoe ga ik om met zeer grote presentaties?**  
Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugen belasten, laad grote bestanden bij voorkeur via bestandspaden, maak bron‑presentaties direct na samenvoegen vrij en sla het eindresultaat pas op wanneer dat nodig is.

**Kan ik dia’s vanuit meerdere threads samenvoegen?**  
Het laden, opslaan of kloont van presentaties in meerdere threads wordt niet ondersteund in PHP via Java. Voor parallelle taken gebruik u afzonderlijke single‑threaded processen en houd u de presentatie‑instanties gescheiden binnen elk proces.