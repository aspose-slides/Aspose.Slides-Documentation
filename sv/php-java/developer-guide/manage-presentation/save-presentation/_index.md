---
title: Spara presentationer i PHP
linktitle: Spara presentation
type: docs
weight: 80
url: /sv/php-java/save-presentation/
keywords:
- spara PowerPoint
- spara OpenDocument
- spara presentation
- spara bild
- spara PPT
- spara PPTX
- spara ODP
- presentation till fil
- presentation till ström
- fördefinierad vytyp
- Strikt Office Open XML-format
- Zip64-läge
- uppdatera miniatyr
- sparförlopp
- PHP
- Aspose.Slides
description: "Upptäck hur du sparar presentationer med Aspose.Slides för PHP via Java — exportera till PowerPoint eller OpenDocument samtidigt som layouter, typsnitt och effekter bevaras."
---
## **Översikt**

[Öppna presentationer i PHP](/slides/sv/php-java/open-presentation/) beskrev hur man använder klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) för att öppna en presentation. Denna artikel förklarar hur man skapar och sparar presentationer. Klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) innehåller en presentations innehåll. Oavsett om du skapar en presentation från grunden eller ändrar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för PHP kan du spara till en **fil** eller **ström**. Denna artikel förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa klassens `save`‑metod på [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/). Skicka filnamnet och sparformatet till metoden. Följande exempel visar hur du sparar en presentation med Aspose.Slides.

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Gör något arbete här...

    // Spara presentationen till en fil.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till enström genom att skicka en utmatningsström till klassens `save`‑metod på [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/). En presentation kan skrivas till många typer av strömmar. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Spara presentationen till strömmen.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Spara presentationer med en fördefinierad vystypsinställning**

Aspose.Slides låter dig ange den initiala vyn som PowerPoint använder när den genererade presentationen öppnas via klassen [ViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/). Använd metoden [setLastView](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/#setLastView) med ett värde från uppräkningen [ViewType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewtype/).

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Spara presentationer i strikt Office Open XML-format**

Aspose.Slides låter dig spara en presentation i det Strikta Office Open XML-formatet. Använd klassen [PptxOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxoptions/) och sätt dess egenskap *conformance* när du sparar. Om du sätter [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/sv/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) sparas utdatafilen i Strikt Office Open XML-format.

Exemplet nedan skapar en presentation och sparar den i Strikt Office Open XML-format.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Spara presentationen i det Strikta Office Open XML-formatet.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Spara presentationer i Office Open XML-format i Zip64-läge**

En Office Open XML‑fil är ett ZIP‑arkiv som har begränsningar på 4 GB (2^32 byte) för den okomprimerade storleken på någon fil, den komprimerade storleken på någon fil och den totala storleken på arkivet, samt en begränsning på 65 535 (2^16‑1) filer. ZIP64‑formatutökningar höjer dessa gränser till 2^64.

Metoden [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxoptions/#setZip64Mode) låter dig välja när ZIP64‑formatutökningar ska användas vid sparande av en Office Open XML‑fil.

Denna metod kan användas med följande lägen:

- [IfNecessary](https://reference.aspose.com/slides/sv/php-java/aspose.slides/zip64mode/#IfNecessary) använder ZIP64‑formatutökningar endast om presentationen överskrider begränsningarna ovan. Detta är standardläget.
- [Never](https://reference.aspose.com/slides/sv/php-java/aspose.slides/zip64mode/#Never) använder aldrig ZIP64‑formatutökningar.
- [Always](https://reference.aspose.com/slides/sv/php-java/aspose.slides/zip64mode/#Always) använder alltid ZIP64‑formatutökningar.

Följande kod demonstrerar hur du sparar en presentation som en PPTX‑fil med ZIP64‑formatutökningar aktiverade:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
När du sparar med [Zip64Mode.Never](https://reference.aspose.com/slides/sv/php-java/aspose.slides/zip64mode/#Never) kastas ett [PptxException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxexception/) om presentationen inte kan sparas i ZIP32‑format.
{{% /alert %}}

## **Spara presentationer i Office Open XML-format med komprimeringsnivåer**

När du arbetar med stora presentationer kan du justera komprimeringsnivån för att balansera filstorlek och bearbetningstid. Beroende på dina krav kan du föredra snabbare bearbetning eller mindre utdatafiler.

Aspose.Slides tillhandahåller metoden [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxoptions/#setCompressionLevel) som låter dig ange komprimeringsnivån som används när du sparar en presentation i Office Open XML-format.

Följande komprimeringsnivåer finns tillgängliga:

- [**None**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#None): Ingen komprimering tillämpas. Filer lagras som de är.
- [**Level1**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level1): Snabbast komprimering med lägst komprimeringsgrad.
- [**Level2**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level2): Snabbare komprimering med något bättre komprimeringsgrad än **Level1**.
- [**Level3**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level3): Ger bättre komprimering än **Level2** med måttlig inverkan på bearbetningstid.
- [**Level4**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level4): Ger bättre komprimering än **Level3**.
- [**Level5**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level5): Ger förbättrad komprimering jämfört med **Level4** med extra bearbetningstid.
- [**Level6**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level6): Standardkomprimering som erbjuder en bra balans mellan hastighet och filstorlek. Detta är *standardkomprimeringsnivån*.
- [**Level7**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level7): Ger bättre komprimering än **Level6** men med långsammare bearbetning.
- [**Level8**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level8): Ger bättre komprimering än **Level7**.
- [**Level9**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level9): Maximal komprimering. Producerar minsta filstorlek på bekostnad av längst bearbetningstid.

Följande exempel demonstrerar hur du sparar en presentation som en PPTX‑fil *utan komprimering*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Detta exempel visar hur du sparar en presentation som en PPTX‑fil med *maximal komprimering*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Spara presentationer utan att uppdatera miniatyren**

Metoden [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) styr miniatyrgenerering när en presentation sparas till PPTX:

- Om den är `true` uppdateras miniatyren under sparandet. Detta är standardvärdet.
- Om den är `false` bevaras den befintliga miniatyren. Om presentationen inte har någon miniatyr genereras ingen.

I koden nedan sparas presentationen till PPTX utan att miniatyren uppdateras.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Detta alternativ hjälper till att minska den tid som krävs för att spara en presentation i PPTX‑format.
{{% /alert %}}

## **Spara förloppsuppdateringar i procent**

Rapportering av sparförlopp konfigureras via metoden [setProgressCallback](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveoptions/#setProgressCallback) på [SaveOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveoptions/) och dess subklasser. Tillhandahåll en Java‑proxy som implementerar gränssnittet [IProgressCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprogresscallback/); under export får återuppringningen periodiska procentuella uppdateringar.

Följande kodsnuttar visar hur du använder `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Använd procentandelen för framsteg här.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose har utvecklat en [gratis PowerPoint Splitter‑app](https://products.aspose.app/slides/sv/splitter) med sitt eget API. Appen låter dig dela en presentation i flera filer genom att spara valda bildspel som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **FAQ**

**Stöds “snabb sparning” (inkrementell sparning) så att endast ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell “snabb sparning” stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑instans [är inte trådsäker](/slides/sv/php-java/multithreading/); spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparning?**

[Hyperlänkar](/slides/sv/php-java/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt – se till att de refererade sökvägarna förblir tillgängliga.

**Kan jag ange/spara dokumentmetadata (författare, titel, företag, datum)?**

Ja. Standard [dokumentegenskaper](/slides/sv/php-java/presentation-properties/) stöds och kommer att skrivas till filen vid sparning.