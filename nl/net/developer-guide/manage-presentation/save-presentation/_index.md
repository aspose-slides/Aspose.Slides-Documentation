---
title: Presentaties opslaan in .NET
linktitle: Presentatie opslaan
type: docs
weight: 80
url: /nl/net/save-presentation/
keywords:
- PowerPoint opslaan
- OpenDocument opslaan
- presentatie opslaan
- dia opslaan
- PPT opslaan
- PPTX opslaan
- ODP opslaan
- presentatie naar bestand
- presentatie naar stream
- voorgedefinieerd weergavetype
- Strikt Office Open XML-formaat
- Zip64-modus
- thumbnail verversen
- opslaan voortgang
- .NET
- C#
- Aspose.Slides
description: "PowerPoint- en OpenDocument-presentaties opslaan naar bestanden of streams in C# met Aspose.Slides voor .NET, en PPTX-output en voortgangsrapportage configureren."
---
## **Overzicht**

Na het maken van een presentatie of [open een bestaande](/slides/nl/net/open-presentation/), gebruik je de [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) methode om het resultaat weg te schrijven. Aspose.Slides for .NET kan een presentatie opslaan naar een bestand of stream in PowerPoint-, OpenDocument-, PDF- en andere formaten. De volgende secties behandelen de standaard opslaan‑bewerkingen en de beschikbare opties voor PPTX‑uitvoer.

## **Presentaties opslaan naar bestanden**

Om een presentatie op te slaan naar een bestand, geef je het uitvoerpad en een [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/) waarde door aan de [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) methode. De formaatwaarde bepaalt het type bestand dat Aspose.Slides maakt.

Het volgende voorbeeld maakt een presentatie en slaat deze op als een PPTX‑bestand:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Presentaties opslaan in hun oorspronkelijke formaat**

Voor voorbeelden van bestand- en streamdetectie, het gedrag van nieuw gemaakte presentaties, en het onderscheid tussen bron- en uitvoerformaten, zie [Determine the Original Presentation Format](/slides/nl/net/detect-presentation-source-format/).

In een batch‑verwerkingstoepassing is het invoerformaat mogelijk niet vooraf bekend. Na het laden van een bestand lees je het oorspronkelijke formaat uit de [IPresentation.SourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/sourceformat/) eigenschap. Geef de resulterende [SourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/sourceformat/) waarde door aan [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/tosaveformat/) om de corresponderende [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/) waarde te verkrijgen, en gebruik vervolgens [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) om de gewijzigde presentatie weg te schrijven.

Het volgende volledige voorbeeld verwerkt elk bestand in een invoermap, werkt de titel bij, en slaat het op naar een uitvoermap in het formaat waarin het geladen is:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/tosaveformat/) kaart PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP en PowerPoint‑XML naar hun overeenkomstige opslaan‑formaten voor presentaties. Het mappt alleen bronformaten van presentaties; het is niet bedoeld om exportformaten zoals PDF, HTML, TIFF of afbeeldingen te selecteren. Het doorgeven van een niet‑ondersteunde of ongeldige [SourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/sourceformat/) waarde resulteert in een [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

Legacy PPT-, PPS- en POT‑bestanden gebruiken dezelfde binaire container. Wanneer zo’n presentatie uit een stream zonder bestandsextensie wordt geladen, kan een PPS‑ of POT‑bestand daardoor worden geïdentificeerd als PPT. Als het behouden van deze legacy‑subtypes vereist is, bewaar dan de oorspronkelijke bestandsnaam of formaat‑metadata apart en gebruik deze bij het kiezen van de uitvoer‑bestandsnaam en -formaat.

## **Presentaties opslaan naar streams**

Om een presentatie weg te schrijven zonder een definitief bestandspad, geef je een schrijfbare [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) en een [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/) waarde door aan de [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) methode. Deze aanpak is nuttig wanneer de uitvoer moet worden geretourneerd vanuit een webservice, opgeslagen in een database, of in het geheugen verwerkt.

Het volgende voorbeeld slaat een nieuwe presentatie op naar een bestands‑stream:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

Je kunt de weergave specificeren waarin PowerPoint een opgeslagen presentatie standaard opent. Stel de [ViewProperties.LastView](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/lastview/) eigenschap in op een [ViewType](https://reference.aspose.com/slides/nl/net/aspose.slides/viewtype/) waarde vóór het opslaan.

Het volgende voorbeeld stelt Slide Master‑weergave in als de initiële weergave:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Presentaties opslaan in het strikte Office Open XML‑formaat**

Om een PPTX‑bestand te maken dat voldoet aan het Strict‑profiel van Office Open XML, maak je een [PptxOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pptxoptions/) instantie aan en stel je de [Conformance](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pptxoptions/conformance/) eigenschap in op `Conformance.Iso29500_2008_Strict`. Vervolgens geef je de opties door aan de [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) methode.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een standaard ZIP‑archief beperkt de gecomprimeerde en ongecomprimeerde grootte van elk item, de totale archiefgrootte en het aantal items. Omdat een PPTX‑bestand een ZIP‑archief is, kan een zeer grote presentatie die limieten overschrijden. ZIP64‑extensies verhogen de toepasselijke grootte‑ en item‑teller‑limieten.

Gebruik de [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pptxoptions/zip64mode/) eigenschap om te bepalen of Aspose.Slides ZIP64‑extensies schrijft:

- `IfNecessary` gebruikt ZIP64 alleen wanneer de presentatie de standaard ZIP‑limieten overschrijdt. Dit is de standaardmodus.
- `Never` schakelt ZIP64‑extensies uit.
- `Always` schrijft altijd ZIP64‑extensies.

Het volgende voorbeeld schakelt ZIP64‑extensies altijd in voor de uitvoerpresentatie:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Waarschuwing" %}}
Als `Zip64Mode` is ingesteld op `Never` en de presentatie niet binnen de standaard ZIP‑limieten past, werpt de opslaan‑operatie een [PptxException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Voor PPTX‑output kun je de opslaan‑snelheid afwegen tegen de bestandsgrootte door de [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pptxoptions/compressionlevel/) eigenschap in te stellen. De [CompressionLevel](https://reference.aspose.com/slides/nl/net/aspose.slides.export/compressionlevel/) enumeratie biedt de volgende waarden:

- `None` slaat gegevens op zonder compressie.
- `Level1` biedt de snelste compressie en de grootste gecomprimeerde output.
- `Level2` tot en met `Level5` geven geleidelijk de voorkeur aan een kleinere output boven opslaan‑snelheid.
- `Level6` balanceert opslaan‑snelheid en bestandsgrootte. Dit is het standaardniveau.
- `Level7` en `Level8` geven nog meer de voorkeur aan een kleinere output boven opslaan‑snelheid.
- `Level9` biedt de sterkste compressie en vereist de meeste verwerkingstijd.

Het volgende voorbeeld slaat een presentatie op zonder compressie:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

Het volgende voorbeeld gebruikt het maximale compressieniveau:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Presentaties opslaan zonder de thumbnail te vernieuwen**

Wanneer een presentatie wordt opgeslagen als PPTX, bepaalt de [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pptxoptions/refreshthumbnail/) eigenschap zijn document‑thumbnail:

- `true` genereert de thumbnail opnieuw tijdens de opslaan‑operatie. Dit is de standaardwaarde.
- `false` behoudt de bestaande thumbnail. Als de presentatie geen thumbnail heeft, genereert Aspose.Slides er geen.

Het volgende voorbeeld slaat een presentatie op zonder de thumbnail te vernieuwen:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Opmerking" %}}
Het uitschakelen van thumbnail‑verversing kan de tijd die nodig is om een PPTX‑bestand op te slaan, verkorten.
{{% /alert %}}

## **Opslaan‑voortgangsupdates in percentage**

Om een opslaan‑operatie te monitoren, implementeer je de [IProgressCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/iprogresscallback/) interface en wijs je de implementatie toe aan de [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/nl/net/aspose.slides.export/isaveoptions/progresscallback/) eigenschap. Aspose.Slides roept vervolgens de [IProgressCallback.Reporting](https://reference.aspose.com/slides/nl/net/aspose.slides/iprogresscallback/reporting/) methode aan met voortgangswaarden tijdens de export.

Het volgende voorbeeld rapporteert de voortgang van een PDF‑export naar de console:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Opmerking" %}}
Aspose biedt een gratis [PowerPoint Splitter](https://products.aspose.app/slides/nl/splitter) aan, gebouwd met de Aspose.Slides‑API. Het slaat geselecteerde dia's uit een presentatie op als afzonderlijke PPT‑ of PPTX‑bestanden.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides incrementeel of “fast save”?**

Nee. Elke opslaan‑operatie schrijft een volledig output‑bestand weg in plaats van alleen de gewijzigde delen bij te werken.

**Kunnen meerdere threads dezelfde Presentation‑instantie opslaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) instantie [is niet thread-safe](/slides/nl/net/multithreading/). Toegang en opslaan van elke instantie mag slechts door één thread tegelijk gebeuren.

**Wat gebeurt er met hyperlinks en extern gekoppelde bestanden wanneer ik een presentatie opsla?**

[Hyperlinks](/slides/nl/net/manage-hyperlinks/) blijven in de presentatie. Aspose.Slides kopieert geen extern gekoppelde bestanden, waardoor de opgeslagen presentatie nog steeds toegang moet hebben tot hun locaties.

**Kan ik documentmetadata zoals auteur, titel, bedrijf en aanmaakdatum opslaan?**

Ja. Stel de juiste [document properties](/slides/nl/net/presentation-properties/) in vóór het opslaan, en Aspose.Slides schrijft ze naar het output‑bestand.