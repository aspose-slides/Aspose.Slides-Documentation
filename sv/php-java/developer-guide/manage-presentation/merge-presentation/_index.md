---
title: Effektivt slå samman presentationer i PHP
linktitle: Slå samman presentationer
type: docs
weight: 40
url: /sv/php-java/merge-presentation/
keywords:
- slå samman PowerPoint
- slå samman presentationer
- slå samman bilder
- slå samman PPT
- slå samman PPTX
- slå samman ODP
- kombinera PowerPoint
- kombinera presentationer
- kombinera bilder
- kombinera PPT
- kombinera PPTX
- kombinera ODP
- PHP
- Aspose.Slides
description: "Lär dig hur du slår samman PowerPoint- och OpenDocument-presentationer i PHP genom att klona bilder, styra masters och layouter, ändra storlek på bildinnehåll, bevara avsnitt och hantera skyddade eller stora filer."
---
## **Översikt**

Aspose.Slides för PHP via Java sammanslår presentationer genom att klona bilder från en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) till en annan. Huvudoperationen är [SlideCollection::addClone()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/), som kan bevara källbildens formatering eller bifoga den klonade bilden till ett master‑ eller layoutobjekt i mål‑presentationen.

Den här artikeln täcker de vanligaste sammanslagningsarbetsflödena:

- sammanslå alla bilder medan källformateringen bevaras;
- sammanslå valda bilder;
- tillämpa ett master från mål‑presentationen;
- tillämpa en specifik layout från mål‑presentationen;
- normalisera olika bildstorlekar innan sammanslagning;
- lägga till klonade bilder i ett avsnitt;
- sammanslå flera presentationer i ett end‑to‑end‑arbetsflöde;
- hantera masters, resurser, anteckningar, kommentarer, media, typsnitt, lösenord, stora filer och multitrådningsaspekter.

## **Hur bildkloning påverkar masters och layouter**

En bild ärver mycket av sitt utseende från sin layout och master. Av den anledningen bestämmer den overload av kloning du väljer hur den sammanslagna bilden integreras i mål‑presentationen.

Använd [SlideCollection::addClone()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) på ett av följande sätt:

- `addClone(sourceSlide)` — bevara källbildens layout och formatering. Vid behov kan käll‑mastern klonas automatiskt in i mål‑presentationen. Aspose.Slides spårar automatiskt klonade masters så att upprepade bilder som använder samma käll‑master inte orsakar att samma master klonas flera gånger.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — bifoga den klonade bilden till ett specifikt mål‑[MasterSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/). Aspose.Slides söker efter en matchande layout under den mastern baserat på layouttyp eller namn.
- `addClone(sourceSlide, destinationLayout)` — bifoga den klonade bilden direkt till en specifik mål‑[LayoutSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/).

Den master eller layout som skickas till ett `addClone`‑overload måste tillhöra **mål**‑presentationen, inte käll‑presentationen.

## **Sammanslå hela presentationer och bevara källformatering**

Den enklaste sammanslagningen kopierar varje bild från käll‑presentationen till mål‑presentationen. Detta är det lämpliga valet när de importerade bilderna ska behålla sitt ursprungliga tema, master och layoutrelationer.

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

Den resulterande presentationen kan innehålla flera masters när käll‑ och mål‑presentationen använder olika designer. Detta är förväntat när källformatering avsiktligt bevaras.

## **Sammanslå valda bilder**

Du behöver inte klona varje bild. Följande exempel importerar endast utvalda bildindex från käll‑presentationen.

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

## **Sammanslå bilder med ett mål‑master**

Använd overloaden [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) när importerade bilder ska följa ett master som redan finns i mål‑presentationen.

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

Aspose.Slides väljer en lämplig layout under den specificerade mastern genom att matcha käll‑layoutens typ eller namn. Om ingen lämplig layout finns och `allowCloneMissingLayout` är `true` klonas käll‑layouten så att bilden kan läggas till. Om den är `false` kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxeditexception/).

Använd `false` när du vill att sammanslagningen ska misslyckas i stället för att introducera en extra layout i mål‑mastern.

## **Sammanslå bilder med en specifik mål‑layout**

Använd overloaden [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) när du exakt vet vilken mål‑layout de importerade bilderna ska använda.

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

Att tillämpa en mål‑layout ändrar den ärvda layoutrelationen; den omdesignar inte innehållet i käll‑bilden. Om käll‑ och mål‑layouter har olika platshållarstrukturer, inspektera resultatet för att bekräfta att den ärvda formateringen och platshållarbeteendet är lämpliga.

## **Sammanslå presentationer med olika bildstorlekar**

Presentationer med olika bilddimensioner kan slås samman, men att klona en bild till en presentation med annan bildstorlek omformar inte automatiskt dess innehåll för den nya duken. Former kan därför visas förskjutna, skalade oväntat eller utanför den synliga bildytan.

En praktisk metod är att ändra storlek på käll‑presentationen innan kloning. Metoden [SlideSize::setSize()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesize/setsize/) kan skala befintligt innehåll samtidigt som bilddimensionerna ändras. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesizescaletype/) skalar innehållet så att det passar inom den begärda storleken.

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

Att ändra storlek förändrar käll‑presentationens objekt i minnet. Om du behöver den ursprungliga käll‑presentationen oförändrad för andra operationer, öppna en separat instans för sammanslagningen.

## **Sammanslå bilder till ett presentationsavsnitt**

Den grundläggande bildkloningsloopen återskapar inte käll‑presentationens avsnittshierarki. Om avsnitt är viktiga i resultatet, skapa eller välj avsnitt i mål‑presentationen och klona bilder till dem explicit med [addClone(Slide, Section)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/).

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

De klonade bilderna läggs till i det specificerade mål‑avsnittet. För att bevara flera käll‑avsnitt, återskapa dessa avsnitt i målet och mappa varje käll‑bild till motsvarande mål‑avsnitt.

## **Sammanslå flera presentationer på ett säkert sätt**

Följande end‑to‑end‑exempel använder den första presentationen som mål, normaliserar bildstorleken för varje ytterligare källa, håller varje källa öppen endast medan den kopieras, och sparar den slutliga filen en gång.

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

Detta är en användbar baslinje för att bevara källformateringen för importerade bilder. Om ditt resultat måste använda ett enhetligt mål‑tema, ersätt det enkla anropet `addClone($slide)` med den lämpliga mål‑master‑ eller mål‑layout‑overload som visas tidigare.

## **Praktiska överväganden**

### **Masters, layouter och formateringsfidelitet**

Standardkloning av bilder kan automatiskt föra in ett behövt käll‑master i mål‑presentationen. Aspose.Slides håller ett internt register för automatiskt klonade masters för att undvika att samma master klonas upprepade gånger. Manuellt klonade masters spåras inte av det registret, så undvik förkloning av masters om du inte behöver explicit kontroll över master‑strukturen.

Anta inte att två masters eller layouter med samma namn är visuellt ekvivalenta. Om en företagsmall måste styra det slutliga utseendet, välj ett mål‑master eller layout explicit och verifiera resultatet efter sammanslagning.

### **Anteckningar och kommentarer**

Talarnoteringar och bildkommentarer är associerade med bildinnehåll och kopieras när en bild klonas. Aspose.Slides erbjuder även dedikerade API:er för [presentation notes](https://docs.aspose.com/slides/sv/php-java/presentation-notes/) och [presentation comments](https://docs.aspose.com/slides/sv/php-java/presentation-comments/).

Om formatering av notes‑sidan är viktig, verifiera den sammanslagna presentationen eftersom notes‑masters är objekt på presentationsnivå och kan skilja sig mellan källfiler. För granskningsarbetsflöden, verifiera även kommentar‑författare och trådade kommentarer efter att filer från olika författare eller mallar kombinerats.

### **Bilder, ljud, video, OLE‑objekt och externa länkar**

Bilder kan referera till resurser på presentationsnivå såsom bilder, inbäddat ljud, inbäddad video och OLE‑data. Klona själva bilden snarare än att bara kopiera dess synliga former så att Aspose.Slides kan bevara bildens relationer till resurserna.

Inbäddade och länkade resurser bör behandlas olika. En länkad ljud‑, video‑, OLE‑objekt‑ eller hyperlänk förblir beroende av sin externa målfil; att klona en bild gör inte en extern länk till inbäddat innehåll. Testa länkressurspadar och URL:er i den miljö där den sammanslagna presentationen kommer att öppnas.

Aspose.Slides spårar automatiskt klonade masters, men detta bör inte betraktas som en generell garanti för att identiska binära resurser från orelaterade källpresentationer alltid dedupliceras. Om utfilens storlek är viktig, inspektera det sammanslagna paketet och mät resultatet i stället för att förlita dig på implicit deduplicering.

### **Inbäddade typsnitt och typsnittstillgänglighet**

Typsnitt hanteras på presentationsnivå. Om typografi måste vara konsekvent över maskiner, anta inte att kloning av bilder ensam garanterar att alla nödvändiga typsnitt finns tillgängliga i mål‑miljön. Du kan inspektera inbäddade typsnitt med [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/getembeddedfonts/) och hantera inbäddning explicit enligt [Embed Fonts in Presentations](https://docs.aspose.com/slides/sv/php-java/embedded-font/).

Verifiera också att du har rätt att inbädda de typsnitt som används i källfilerna. Typsnittslicenser kan begränsa inbäddning.

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

Att öppna en krypterad källa applicerar inte automatiskt samma skydd på mål‑presentationen. Konfigurera utdata‑skydd separat när det krävs.

### **Stora presentationer och minnesanvändning**

Stora presentationer med högupplösta bilder, ljud, video eller andra stora binära objekt kan förbruka betydande minne. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) ger kontroll över BLOB‑hantering och temporär‑filanvändning. Se [Open Presentations](https://docs.aspose.com/slides/sv/php-java/open-presentation/#open-large-presentations) för ett PHP‑via‑Java‑exempel med stora filer.

För stora filer, föredra inläsning från filsökvägar när det är möjligt, disponera varje käll‑presentation så snart den har slutfört sammanslagningen, och undvik att spara mellanresultat upprepade gånger om arbetsflödet inte kräver kontrollpunkter.

### **Trådsäkerhet**

Ladda inte, modifiera inte, spara inte eller klona inte [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑instanser i flera trådar. Dessa operationer stöds inte för multitrådad användning i PHP via Java. Om du behöver parallella sammanslagningsjobb, kör dem i separata enkeltrådade processer, där varje process använder sina egna presentationsinstanser, och följ [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/sv/php-java/multithreading/).

## **FAQ**

**Hur behåller jag varje käll‑presentations ursprungliga design?**

Använd [`addClone(sourceSlide)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) utan att ange ett mål‑master eller layout. Aspose.Slides kan automatiskt klona käll‑mastern när den behövs av den importerade bilden.

**Hur får jag att importerade bilder använder mål‑temat?**

Använd overloaden som accepterar ett mål‑master. Ange ett master från mål‑presentationen, inte från käll‑presentationen. Aspose.Slides försöker mappa varje käll‑bild till en lämplig layout under det mastern.

**När ska jag använda en specifik mål‑layout i stället för ett mål‑master?**

Använd en specifik layout när varje importerad bild ska använda en känd layout. Använd ett master när du vill att Aspose.Slides ska välja bland masterns layouter baserat på käll‑layoutens typ eller namn.

**Kan presentationer med olika bildstorlekar slås samman?**

Ja, men bildinnehållet redesignas inte automatiskt för mål‑dimensionerna. Ändra storlek på käll‑presentationen först när du behöver förutsägbara placeringar, till exempel med [SlideSize::setSize()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesize/setsize/) och [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesizescaletype/).

**Kan jag sammanslå PPT, PPTX och ODP‑presentationer till en fil?**

Ja. Läs in varje käll‑presentation, klona de önskade bilderna till en destination och spara destinationen i ett stödd format. Eftersom presentationsformaten inte stödjer exakt samma funktionsuppsättning, verifiera komplext innehåll efter kors‑format‑sammanslagningar. Se [Supported File Formats](https://docs.aspose.com/slides/sv/php-java/supported-file-formats/).

**Behålls käll‑avsnitt automatiskt?**

Nej, inte med en grundläggande loop som bara klonar bilder. Återskapa de nödvändiga avsnitten i destinationen och använd avsnitts‑overloaden av [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) när avsnittsstruktur måste bevaras.

**Behålls talarnoteringar och kommentarer?**

De kopieras med den klonade bilden. För arbetsflöden som beror på notes‑master‑stil, kommentar‑författare eller trådade granskningsdata, verifiera det sammanslagna resultatet eftersom dessa scenarier involverar både presentations‑ och bildnivå‑strukturer.

**Vad händer med ljud, video, OLE‑objekt och hyperlänkar?**

Inbäddat innehåll transporteras som en del av den klonade bildens resursrelationer. Externa länkar förblir externa, så deras mål‑filer eller URL:er måste fortfarande vara tillgängliga efter sammanslagningen.

**Är inbäddade typsnitt från varje källa garanterade att finnas i den sammanslagna presentationen?**

Lita inte på enbart bildkloning för teckensnittsdistribution. Inspektera destinationens inbäddade typsnitt och hantera typsnittsinbäddning eller extern typsnittstillgänglighet explicit när typografi är viktig.

**Hur slår jag ihop en lösenordsskyddad fil?**

Öppna den med rätt [LoadOptions::setPassword()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/setpassword/), klona sedan dess bilder som vanligt. Utdata‑skydd konfigureras separat.

**Hur hanterar jag mycket stora presentationer?**

Använd BLOB‑hantering när stora binära objekt dominerar minnesanvändningen, föredra inläsning från filsökvägar för mycket stora filer, disponera käll‑presentationer snabbt och spara det slutliga resultatet endast när det behövs.

**Kan jag klona bilder från flera trådar?**

Att ladda, spara eller klona [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑instanser i flera trådar stöds inte i PHP via Java. För parallellt arbete, använd separata enkeltrådade processer och håll presentationsinstanser isolerade inom varje process.