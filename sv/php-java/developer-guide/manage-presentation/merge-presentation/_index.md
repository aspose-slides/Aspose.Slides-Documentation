---
title: Effektiv sammanslagning av presentationer i PHP
linktitle: Sammanslå presentationer
type: docs
weight: 40
url: /sv/php-java/merge-presentation/
keywords:
- sammanslå PowerPoint
- sammanslå presentationer
- sammanslå bilder
- sammanslå PPT
- sammanslå PPTX
- sammanslå ODP
- kombinera PowerPoint
- kombinera presentationer
- kombinera bilder
- kombinera PPT
- kombinera PPTX
- kombinera ODP
- PHP
- Aspose.Slides
description: "Lär dig hur du slår ihop PowerPoint- och OpenDocument-presentationer i PHP genom att klona bilder, styra masters och layouter, ändra storlek på bildinnehållet, bevara sektioner samt hantera skyddade eller stora filer."
---
## **Översikt**

Aspose.Slides för PHP via Java slår ihop presentationer genom att klona bilder från en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) till en annan. Huvudoperationen är [SlideCollection::addClone()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/), som kan bevara källbildens formatering eller fästa den klonade bilden till ett master‑ eller layout i destinationspresentationen.

Den här artikeln täcker de vanligaste sammanslagningsarbetsflödena:

- slå ihop alla bilder samtidigt som deras källformatering bevaras;
- slå ihop valda bilder;
- tillämpa ett master från destinationspresentationen;
- tillämpa en specifik layout från destinationspresentationen;
- normalisera olika bildstorlekar innan sammanslagning;
- lägga till klonade bilder i en sektion;
- slå ihop flera presentationer i ett komplett arbetsflöde;
- hantera masters, resurser, anteckningar, kommentarer, media, teckensnitt, lösenord, stora filer och multitrådningsaspekter.

## **Hur bildkloning påverkar masters och layouter**

En bild ärver mycket av sitt utseende från sin layout och master. Av den anledningen bestämmer den kloningsöversättning du väljer hur den sammanslagna bilden integreras i destinationspresentationen.

Använd [SlideCollection::addClone()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) på ett av följande sätt:

- `addClone(sourceSlide)` — bevarar källbildens layout och formatering. Vid behov kan källmastern klonas automatiskt in i destinationspresentationen. Aspose.Slides spårar automatiskt klonade masters så att upprepade bilder som använder samma källmaster inte får den master klonad flera gånger.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — fäster den klonade bilden till ett specifikt destinations-[MasterSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/). Aspose.Slides söker efter en matchande layout under den mastern baserat på layouttyp eller namn.
- `addClone(sourceSlide, destinationLayout)` — fäster den klonade bilden direkt till en specifik destinations-[LayoutSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/).

Mastern eller layouten som skickas till en `addClone`‑översättning måste tillhöra **destinations**‑presentationen, inte källpresentationen.

## **Slå ihop hela presentationer och bevara källformatering**

Den enklaste sammanslagningen kopierar varje bild från källpresentationen till destinationspresentationen. Detta är ett lämpligt val när de importerade bilderna ska behålla sitt ursprungliga tema, master och layoutrelationer.

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

Den resulterande presentationen kan innehålla flera masters när käll- och destinationspresentationerna använder olika designer. Detta är förväntat när källformatering avsiktligt bevaras.

## **Slå ihop valda bilder**

Du behöver inte klona varje bild. Följande exempel importerar endast utvalda bildindex från källpresentationen.

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

Validera bildindex innan kloning när de kommer från användarinmatning eller extern konfiguration.

## **Slå ihop bilder med en destinationsmaster**

Använd [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/)‑översättningen när importerade bilder ska följa en master som redan tillhör destinationspresentationen.

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

Aspose.Slides väljer en lämplig layout under den angivna mastern genom att matcha källlayoutens typ eller namn. Om ingen lämplig layout finns och `allowCloneMissingLayout` är `true` klonas källayouten så att bilden kan läggas till. Om den är `false` kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxeditexception/).

Använd `false` när du vill att sammanslagningen ska misslyckas istället för att införa en extra layout i destinationsmastern.

## **Slå ihop bilder med en specifik destinationslayout**

Använd [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/)‑översättningen när du exakt vet vilken destinationslayout de importerade bilderna ska använda.

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

Att tillämpa en destinationslayout ändrar den ärvda layoutrelationen; den omdesignar inte källbildens innehåll. Om käll‑ och destinationslayouter har olika platshållarstrukturer, inspektera resultatet för att bekräfta att den ärvda formateringen och platsinnehållsbeteendet är lämpligt.

## **Slå ihop presentationer med olika bildstorlekar**

Presentationer med olika bilddimensioner kan slås ihop, men att klona en bild till en presentation med en annan bildstorlek omdesignar inte automatiskt innehållet för den nya duken. Former kan därför visas förskjutna, skalerade oväntat eller utanför den synliga bildytan.

Ett praktiskt tillvägagångssätt är att ändra storleken på källpresentationen innan kloning. Metoden [SlideSize::setSize()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesize/setsize/) kan skala befintligt innehåll samtidigt som bilddimensionerna ändras. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesizescaletype/) skalar innehållet så att det passar inom den begärda storleken.

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

Storleksändring ändrar källpresentationens objekt i minnet. Om du behöver den ursprungliga källpresentationen oförändrad för andra operationer, öppna en separat instans för sammanslagningen.

## **Slå ihop bilder i en presentationssektion**

Den grundläggande bildkloningsslingan återuppbygger inte källpresentationens sektionshierarki. Om sektioner är viktiga i resultatet, skapa eller välj sektioner i destinationspresentationen och klona bilder till dem explicit med [addClone(Slide, Section)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/).

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

De klonade bilderna läggs till i den angivna destinationssektionen. För att bevara flera källsektioner, enumerera [Presentation::getSections](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSections), hämta varje källsektons aktuella bilder med [Section::getSlidesListOfSection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Section/#getSlidesListOfSection), återcreate sektionerna i destinationen och klona varje returnerad bild till dess motsvarande destinationssektion. Se [Manage Slide Sections](/slides/sv/php-java/slide-section/) för ett komplett exempel på sektionenumerering, inklusive tomma sektioner och strukturella förändringar.

## **Sammanslå flera presentationer på ett säkert sätt**

Följande end-to-end‑exempel använder den första presentationen som destination, normaliserar bildstorleken för varje ytterligare källa, håller varje källa öppen endast medan den kopieras, och sparar den slutliga filen en gång.

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

Detta är en användbar baslinje för att bevara källformateringen av importerade bilder. Om ditt resultat måste använda ett enda destinations‑tema, ersätt det enkla `addClone($slide)`‑anropet med den lämpliga destination‑master‑ eller destination‑layout‑översättningen som visas tidigare.

## **Praktiska överväganden**

### **Masters, layouter och formateringsnoggrannhet**

Standardkloning av bilder kan automatiskt ta in en nödvändig källmaster i destinationspresentationen. Aspose.Slides håller ett internt register för automatiskt klonade masters för att undvika att samma master klonas flera gånger. Manuellt klonade masters spåras inte i det registret, så undvik förkloning av masters om du inte behöver explicit kontroll över master‑strukturen.

Anta inte att två masters eller layouter med samma namn är visuellt identiska. Om en företagsmall måste styra det slutliga utseendet, välj en destinationsmaster eller layout explicit och verifiera resultatet efter sammanslagning.

### **Anteckningar och kommentarer**

Talarnoteringar och bildkommentarer är knutna till bildens innehåll och kopieras när en bild klonas. Aspose.Slides erbjuder också dedikerade API:er för [presentation notes](/slides/sv/php-java/presentation-notes/) och [presentation comments](/slides/sv/php-java/presentation-comments/).

Om formatering av notessidan är viktig, verifiera den sammanslagna presentationen eftersom notes‑masters är objekt på presentationsnivå och kan skilja sig mellan källfiler. För granskningsarbetsflöden, verifiera även kommentarförfattare och trådade kommentarer efter att ha kombinerat filer från olika författare eller mallar.

### **Bilder, ljud, video, OLE‑objekt och externa länkar**

Bilder kan referera till resurser på presentationsnivå såsom bilder, inbäddat ljud, inbäddad video och OLE‑data. Klona själva bilden istället för att bara kopiera dess synliga former så att Aspose.Slides kan upprätthålla bildens relationer till dess resurser.

Inbäddade och länkade resurser bör behandlas olika. En länkad ljud‑, video‑, OLE‑objekt‑ eller hyperlänk förblir beroende av sin externa måldestination; kloning av en bild omvandlar inte en extern länk till inbäddat innehåll. Testa sökvägar och URL:er för länkade resurser i den miljö där den sammanslagna presentationen kommer att öppnas.

Aspose.Slides spårar uttryckligen automatiskt klonade masters, men detta bör inte betraktas som en generell garanti för att identiska binära resurser från orelaterade källpresentationer alltid kommer att dedupliceras. Om filstorlek på resultatet är viktig, inspektera det sammanslagna paketet och mät resultatet istället för att förlita sig på implicit deduplicering.

### **Inbäddade teckensnitt och teckensnittstillgänglighet**

Teckensnitt hanteras på presentationsnivå. Om typografi måste förbli konsekvent mellan maskiner, anta inte att kloning av bilder ensam garanterar att varje nödvändigt teckensnitt finns tillgängligt i destinationsmiljön. Du kan inspektera inbäddade teckensnitt med [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/getembeddedfonts/) och hantera inbäddning explicit enligt [Embed Fonts in Presentations](/slides/sv/php-java/embedded-font/).

Verifiera också att du har tillstånd att bädda in de teckensnitt som används i källfilerna. Teckensnittslicenser kan begränsa inbäddning.

### **Lösenordsskyddade presentationer**

En lösenordsskyddad källa måste öppnas framgångsrikt innan dess bilder kan klonas. Ange lösenordet via [LoadOptions::setPassword()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Arbeta med den avkrypterade presentationen.
} finally {
    $source->dispose();
}
```

Att öppna en krypterad källa applicerar inte automatiskt samma skydd på destinationspresentationen. Konfigurera utgångsskydd separat när det krävs.

### **Stora presentationer och minnesanvändning**

Stora presentationer som innehåller högupplösta bilder, ljud, video eller andra stora binära objekt kan förbruka betydande minne. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) ger kontroll över BLOB‑hantering och temporära filer. Se [Open Presentations](/slides/sv/php-java/open-presentation/#open-large-presentations) för ett exempel på stora filer i PHP via Java.

För stora filer, föredra att ladda från filsökvägar när det är möjligt, disponera varje källpresentation så snart den har slagits ihop, och undvik att upprepade gånger spara mellansteg om inte arbetsflödet kräver kontrollpunkter.

### **Trådsäkerhet**

Ladda inte, ändra, spara eller klona [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑instanser i flera trådar. Dessa operationer stöds inte för flerdelat användning i PHP via Java. Om du behöver parallella sammanslagningsjobb, kör dem i separata entrådade processer, där varje process använder sina egna presentationsinstanser, och följ [Aspose.Slides multithreading guidance](/slides/sv/php-java/multithreading/).

## **FAQ**

**Hur behåller jag varje källpresentations ursprungliga design?**

Använd [SlideCollection::addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) utan att ange en destinations‑master eller layout. Aspose.Slides kan automatiskt klona källmastern när den behövs av den importerade bilden.

**Hur får jag importerade bilder att använda destinations‑temat?**

Använd den översättning som accepterar en destinations‑master. Skicka en master från destinationspresentationen, inte från källan. Aspose.Slides kommer att försöka map varje källbild till en lämplig layout under den mastern.

**När bör jag använda en specifik destinationslayout istället för en destinationsmaster?**

Använd en specifik layout när varje importerad bild ska använda en känd layout. Använd en master när du vill att Aspose.Slides ska välja bland masterns layouter baserat på källlayoutens typ eller namn.

**Kan presentationer med olika bildstorlekar slås ihop?**

Ja, men bildinnehållet omdesignas inte automatiskt för destinationsdimensionerna. Ändra storleken på källpresentationen först när du behöver förutsägbar placering, exempelvis med [SlideSize::setSize()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesize/setsize/) och [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesizescaletype/).

**Kan jag slå ihop PPT, PPTX och ODP‑presentationer till en fil?**

Ja. Ladda varje källpresentation, klona de nödvändiga bilderna till en destination och spara destinationen i ett stödd utdataformat. Eftersom presentationsformaten inte stödjer exakt samma funktionsuppsättning, verifiera komplext innehåll efter korsformatssammanslagningar. Se [Supported File Formats](/slides/sv/php-java/supported-file-formats/).

**Bevaras källsektioner automatiskt?**

Inte av en grundläggande slinga som bara klonar bilder. Återskapa de nödvändiga sektionerna i destinationen och använd sektion‑översättningen av [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) när sektionens struktur måste bevaras.

**Bevaras talarnoteringar och kommentarer?**

De kopieras med den klonade bilden. För arbetsflöden som beror på notes‑master‑styling, kommentar‑författare eller trådad granskningsdata, verifiera det sammanslagna resultatet eftersom dessa scenarier involverar både presentations‑ och bildnivåns strukturer.

**Vad händer med ljud, video, OLE‑objekt och hyperlänkar?**

Inbäddat innehåll medförs som en del av den klonade bildens resursrelationer. Externa länkar förblir externa, så deras mål‑filer eller URL‑er måste fortfarande vara tillgängliga efter sammanslagningen.

**Är inbäddade teckensnitt från varje källa garanterade att finnas i den sammanslagna presentationen?**

Förlita dig inte enbart på bildkloning för teckensnittsdistribution. Inspektera destinationens inbäddade teckensnitt och hantera explicit teckensnittsinbäddning eller extern teckensnittstillgänglighet när typografi är viktig.

**Hur slår jag ihop en lösenordsskyddad fil?**

Öppna den med rätt [LoadOptions::setPassword()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/setpassword/), och klona dess bilder som vanligt. Utgångsskydd konfigureras separat.

**Hur bör jag hantera mycket stora presentationer?**

Använd BLOB‑hantering när stora binära objekt dominerar minnesanvändningen, föredra fil‑sökvägs‑laddning för mycket stora filer, disponera källpresentationer omedelbart, och spara det slutliga resultatet endast när det behövs.

**Kan jag slå ihop bilder från flera trådar?**

Laddning, sparande eller kloning av presentationer i flera trådar stöds inte i PHP via Java. För parallellt arbete, använd separata entrådade processer och håll presentations‑instanser isolerade i varje process.