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
- uppdatera miniatyrbild
- sparningsframsteg
- PHP
- Aspose.Slides
description: "Upptäck hur du sparar presentationer med Aspose.Slides för PHP via Java — exportera till PowerPoint eller OpenDocument samtidigt som du behåller layouter, teckensnitt och effekter."
---
## **Översikt**

[Öppna presentationer i PHP](/slides/sv/php-java/open-presentation/) beskriver hur du använder klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) för att öppna en presentation. Denna artikel förklarar hur du skapar och sparar presentationer. Klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) innehåller en presentations innehåll. Oavsett om du skapar en presentation från början eller ändrar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för PHP kan du spara till en **fil** eller **ström**. Denna artikel förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa klassens [Presentation] `save`‑metod. Skicka filnamnet och sparformatet till metoden. Följande exempel visar hur du sparar en presentation med Aspose.Slides.

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Utför något arbete här...

    // Spara presentationen till en fil.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till en ström genom att skicka en utskriftsström till klassens [Presentation] `save`‑metod. En presentation kan skrivas till många olika strömtyper. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

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

## **Spara presentationer med en fördefinierad vytyp**

Aspose.Slides låter dig ställa in den initiala vyn som PowerPoint använder när den genererade presentationen öppnas via klassen [ViewProperties]. Använd metoden [setLastView] med ett värde från uppräkningen [ViewType].

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

Aspose.Slides låter dig spara en presentation i det strikta Office Open XML-formatet. Använd klassen [PptxOptions] och ange dess conformance‑egenskap vid sparande. Om du anger [Conformance.Iso29500_2008_Strict] sparas utdatafilen i det strikta Office Open XML-formatet.

Exemplet nedan skapar en presentation och sparar den i det strikta Office Open XML-formatet.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Spara presentationen i det strikta Office Open XML-formatet.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Spara presentationer i Office Open XML-format i Zip64-läge**

En Office Open XML-fil är ett ZIP-arkiv som har begränsningar på 4 GB (2^32 byte) för den okomprimerade storleken på varje fil, den komprimerade storleken på varje fil och den totala storleken på arkivet, samt begränsar arkivet till 65 535 (2^16‑1) filer. ZIP64-formatutökningar höjer dessa begränsningar till 2^64.

Metoden [PptxOptions.setZip64Mode] låter dig välja när ZIP64-formatutökningar ska användas vid sparande av en Office Open XML-fil.

Denna metod kan användas med följande lägen:

- [IfNecessary] använder ZIP64-formatutökningar endast om presentationen överskrider begränsningarna ovan. Detta är standardläget.
- [Never] använder aldrig ZIP64-formatutökningar.
- [Always] använder alltid ZIP64-formatutökningar.

Följande kod visar hur du sparar en presentation som PPTX med ZIP64-formatutökningar aktiverade:

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
När du sparar med [Zip64Mode.Never](https://reference.aspose.com/slides/sv/php-java/aspose.slides/zip64mode/#Never) kastas ett [PptxException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxexception/) om presentationen inte kan sparas i ZIP32-format.
{{% /alert %}}

## **Spara presentationer utan att uppdatera miniatyren**

Metoden [PptxOptions.setRefreshThumbnail] styr genereringen av miniatyrbilder när en presentation sparas till PPTX:

- Om den sätts till `true` uppdateras miniatyren under sparandet. Detta är standard.
- Om den sätts till `false` bevaras den nuvarande miniatyren. Om presentationen saknar miniatyrbild genereras ingen.

I koden nedan sparas presentationen till PPTX utan att uppdatera dess miniatyrbild.

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
Detta alternativ hjälper till att minska den tid som krävs för att spara en presentation i PPTX-format.
{{% /alert %}}

## **Spara framstegsuppdateringar i procent**

Rapportering av sparningsframsteg konfigureras via metoden [setProgressCallback] på [SaveOptions] och dess underklasser. Tillhandahåll en Java‑proxy som implementerar gränssnittet [IProgressCallback]; under export får återuppringningen periodiska procentuella uppdateringar.

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
Aspose har utvecklat en [gratis PowerPoint Splitter‑app](https://products.aspose.app/slides/sv/splitter) med sitt eget API. Appen låter dig dela en presentation i flera filer genom att spara valda bilder som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **Vanliga frågor**

**Stöds "snabb sparning" (inkrementell sparning) så att bara ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell "snabb sparning" stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation]‑instans [är inte trådsäker](/slides/sv/php-java/multithreading/); spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparning?**

[Hyperlinks](/slides/sv/php-java/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt – se till att de refererade sökvägarna förblir tillgängliga.

**Kan jag ange/spara dokumentmetadata (författare, titel, företag, datum)?**

Ja. Standard [document properties](/slides/sv/php-java/presentation-properties/) stöds och kommer att skrivas till filen vid sparning.