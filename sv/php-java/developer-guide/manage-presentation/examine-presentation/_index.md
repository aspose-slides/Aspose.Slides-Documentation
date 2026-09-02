---
title: Hämta och uppdatera presentationsinformation i PHP
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/php-java/examine-presentation/
keywords:
- presentationsformat
- presentationsegenskaper
- dokumentegenskaper
- hämta egenskaper
- läsa egenskaper
- ändra egenskaper
- modifiera egenskaper
- uppdatera egenskaper
- granska PPTX
- granska PPT
- granska ODP
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Utforska bilder, struktur och metadata i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP för snabbare insikter och smartare innehållsgranskningar."
---
## **Översikt**

Aspose.Slides kan identifiera ett presentationsformat och läsa dokumentmetadata utan att skapa ett komplett presentationsobjektmodell. Detta är användbart när du behöver klassificera filer, bygga ett inventarium eller inspektera egenskaper innan du beslutar om du ska ladda och bearbeta presentationsinnehållet.

Denna artikel demonstrerar lättviktig inspektion via [PresentationFactory](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/) och [PresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/), samt riktade uppdateringar via [DocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/).

## **Kontrollera presentationsformat**

Använd [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/) för att inspektera en fil utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) instans. Metoden [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#getLoadFormat) rapporterar det upptäckta formatet, såsom PPTX, PPT eller ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Bygg ett lättviktigt presentationsinventarium**

När du bearbetar många presentationsfiler kan du behöva ett kompakt inventarium för validering, indexering eller ett dokumenthanteringssystem. I detta scenario, använd [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/) för att erhålla ett [PresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/) objekt, och anropa sedan [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#readDocumentProperties) för att läsa dokumentmetadata. Detta tillvägagångssätt skapar inte en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) instans eller kräver att du traverserar den kompletta presentationsobjektmodellen.

De utökade egenskaper som exponeras av [DocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/) tillhandahåller följande inventarievärden:

| Metod | Inventarievärde |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getSlides) | Totalt antal bilder. |
| [getHiddenSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Antal dolda bilder. |
| [getNotes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getNotes) | Antal bilder som innehåller anteckningar. |
| [getParagraphs](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getParagraphs) | Totalt antal stycken, om tillgängligt. |
| [getWords](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getWords) | Totalt antal ord. |
| [getMultimediaClips](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Totalt antal ljud- och videoklipp. |

Följande exempel läser dessa värden utan att skapa ett [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) objekt och skriver ut ett kompakt inventarium. Det kombinerar även [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getHeadingPairs) med [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getTitlesOfParts) för att visa innehållsgrupper såsom typsnitt, teman och bildspelstitlar.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Varje [HeadingPair](https://reference.aspose.com/slides/sv/php-java/aspose.slides/headingpair/) tillhandahåller ett gruppnamn och antalet objekt i den gruppen. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getTitlesOfParts) returnerar en platt, ordnad array, så konsumera antalet på varandra följande titlar som anges av varje rubrikpar.

### **Lagrad metadata och formatbegränsningar**

Inventarieegenskaperna som returneras av [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#readDocumentProperties) återspeglar metadata som finns i källdokumentet. Aspose.Slides laddar inte och traverserar presentationsobjektmodellen för att omräkna dessa värden för detta anrop. Saknade egenskaper representeras av standardvärden, och lagrade värden kan vara föråldrade om programmet som senast sparade filen inte uppdaterade dess dokumentegenskaper.

- **PPTX:** Formatet tillhandahåller utökade dokumentegenskaper för bild, anteckning, dold bild, stycke, ord och multimediaantal, samt rubrikpar och deltitlar. Tillgänglighet beror på vilka egenskaper som skrevs av dokumentproducenten.
- **PPT:** Det binära formatet kan lagra motsvarande dokument‑sammanfattningsegenskaper. Om en egenskap saknas eller inte uppdaterades av dokumentproducenten, returnerar Aspose.Slides dess lagrade eller standardvärde i stället för att beräkna det från bilderna.
- **ODP:** OpenDocument-metadata tillhandahåller allmänna dokumentstatistik, såsom sid‑, stycke‑ och ordantal, men dessa värden motsvarar inte varje PowerPoint‑specifik utökad egenskap. Metadata för dolda bilder, anteckningsbilder, multimedia, rubrikpar och deltitlar kan vara otillgänglig, och inventarieegenskaperna kan returnera standardvärden. Behandla inte ett nollvärde eller en tom array som ett auktoritativt bevis på att motsvarande innehåll saknas.

Använd det lättviktiga metadata‑tillvägagångssättet för inventarier och preliminära kontroller. Ladda presentationen och inspektera dess levande objektmodell när resultatet måste återspegla förändringar i minnet eller när du behöver verifiera det faktiska presentationsinnehållet.

## **Uppdatera presentationsegenskaper**

Egenskaperna som returneras av [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#readDocumentProperties) kan också ändras utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) instans. Tillämpa ändringarna med [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) och skriv sedan den bundna presentationen med [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Följande bild visar de ursprungliga dokumentegenskaperna.

![Ursprungliga dokumentegenskaper för PowerPoint-presentationen](input_properties.png)

Följande exempel ändrar titeln och senast sparade tid och skriver resultatet till en ny fil:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

Följande bild visar de ändrade dokumentegenskaperna.

![Ändrade dokumentegenskaper för PowerPoint-presentationen](output_properties.png)

## **Användbara länkar**

För relaterade säkerhetskontroller och skyddsinställningar, se följande artiklar:

- [Lösenordsskydda presentationer](/slides/sv/php-java/password-protected-presentation/)
- [Skrivskydda presentationer](/slides/sv/php-java/write-protected-presentation/)

## **Vanliga frågor**

**Hur kan jag kontrollera om typsnitt är inbäddade och vilka de är?**

Ladda presentationen och använd [Presentation::getFontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getFontsManager). Anropa [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) för att hämta de inbäddade typsnitten och [FontsManager::getFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/#getFonts) för att hämta de typsnitt som används av presentationen. Jämför de två resultaten för att hitta typsnitt som krävs för renderingen men som inte är inbäddade.

**Hur kan jag snabbt avgöra om filen har dolda bilder och hur många?**

När lagrad dokumentmetadata är tillräcklig, läs [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getHiddenSlides) via [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationfactory/) och [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Detta är lämpligt för ett lättviktigt inventarium. Om presentationen har modifierats i minnet kan den lagrade metadata saknas eller vara föråldrad, eller så behöver du verifiera levande värden, iterera genom [Presentation::getSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSlides) och inspektera varje bilds [Slide::getHidden](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getHidden) metod istället.

**Kan jag upptäcka om anpassad bildstorlek och orientering används, och om de skiljer sig från standardinställningarna?**

Ja. Ladda presentationen och anropa [Presentation::getSlideSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSlideSize). Använd [SlideSize::getType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesize/#getSize) och [SlideSize::getOrientation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesize/#getOrientation) för att jämföra de aktuella inställningarna med den förväntade förinställningen och dimensionerna.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Hitta varje [Chart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/) och anropa [ChartData::getDataSourceType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/#getDataSourceType). För en extern arbetsbok, anropa [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). Datakälltyp och sökväg identifierar en extern referens, men att verifiera om målet är tillgängligt kräver en separat resurstillgångskontroll.

**Hur kan jag bedöma 'tunga' bilder som kan sakta ner renderingen eller PDF‑export?**

Det finns ingen enskild komplexitetsegenskap. Traversera [Presentation::getSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSlides) och varje bilds [BaseSlide::getShapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/#getShapes) samling. Använd antalet former och förekomsten av stora bilder, effekter, animationer eller multimedia som screening‑signaler, och mät en representativ rendering eller export innan du behandlar en bild som en bekräftad prestandaflaska.