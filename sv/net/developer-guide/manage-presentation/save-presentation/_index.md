---
title: Spara presentationer i .NET
linktitle: Spara presentation
type: docs
weight: 80
url: /sv/net/save-presentation/
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
- Strict Office Open XML-format
- Zip64-läge
- uppdatera miniatyr
- sparningsförlopp
- .NET
- C#
- Aspose.Slides
description: "Spara PowerPoint- och OpenDocument-presentationer till filer eller strömmar i C# med Aspose.Slides för .NET, och konfigurera PPTX-utmatning samt rapportering av sparningsförlopp."
---
## **Översikt**

Efter att du har skapat en presentation eller [öppna en befintlig](/slides/sv/net/open-presentation/), använd [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) metoden för att skriva resultatet. Aspose.Slides för .NET kan spara en presentation till en fil eller en ström i PowerPoint, OpenDocument, PDF och andra format. Följande avsnitt täcker de standardlagringsoperationer som finns och de alternativ som är tillgängliga för PPTX-utmatning.

## **Spara presentationer till filer**

För att spara en presentation till en fil, skicka utdata-sökvägen och ett [SaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/) värde till [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) metoden. Formatvärdet bestämmer vilken typ av fil som Aspose.Slides skapar.

Följande exempel skapar en presentation och sparar den som en PPTX‑fil:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Spara presentationer i deras ursprungliga format**

För exempel på fil‑ och strömdetektering, beteendet för nyss skapade presentationer och skillnaden mellan källa‑ och utskriftsformat, se [Bestäm originalpresentationens format](/slides/sv/net/detect-presentation-source-format/).

I en batch‑behandlingsapplikation kan indataformatet vara okänt i förväg. Efter att en fil har laddats, läs dess ursprungliga format från egenskapen [IPresentation.SourceFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/sourceformat/). Skicka det resulterande [SourceFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/sourceformat/) värdet till [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/tosaveformat/) för att erhålla motsvarande [SaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/) värde, och använd sedan [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) för att skriva den modifierade presentationen.

Följande kompletta exempel behandlar varje fil i en inmatningskatalog, uppdaterar dess titel och sparar den till en utmatningskatalog i det format den laddades från:

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

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/tosaveformat/) mappar PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP och PowerPoint XML till deras motsvarande presentations‑spara‑format. Det mappar endast presentations‑källformat; det är inte avsett att välja exportformat såsom PDF, HTML, TIFF eller bilder. Att skicka ett icke‑stödd eller ogiltigt [SourceFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/sourceformat/) värde resulterar i ett [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

Legacy‑filerna PPT, PPS och POT använder samma binära behållare. När en sådan presentation laddas från en ström utan filändelse kan en PPS‑ eller POT‑fil därför identifieras som PPT. Om bevarande av dessa äldre undertyper krävs, behåll det ursprungliga filnamnet eller formatmetadata separat och använd dem när du väljer utdatafilnamn och format.

## **Spara presentationer till strömmar**

För att skriva en presentation utan att förlita dig på en slutlig filsökväg, skicka en skrivbar [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) och ett [SaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/) värde till [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) metoden. Detta tillvägagångssätt är användbart när utdata måste returneras från en webbtjänst, lagras i en databas eller bearbetas i minnet.

Följande exempel sparar en ny presentation till en filström:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Spara presentationer med en fördefinierad vytyp**

Du kan ange den vy som PowerPoint initialt öppnar en sparad presentation i. Ställ in egenskapen [ViewProperties.LastView](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/lastview/) till ett [ViewType](https://reference.aspose.com/slides/sv/net/aspose.slides/viewtype/) värde innan sparning.

Följande exempel konfigurerar Slide Master‑vyn som den initiala vyn:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Spara presentationer i det strikta Office Open XML-formatet**

För att skapa en PPTX‑fil som följer den Strikta profilen av Office Open XML, skapa en [PptxOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pptxoptions/) instans och sätt dess [Conformance](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pptxoptions/conformance/) egenskap till `Conformance.Iso29500_2008_Strict`. Skicka sedan alternativen till [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) metoden.

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

## **Spara presentationer i Office Open XML-format i Zip64‑läge**

Ett standard‑ZIP‑arkiv begränsar den komprimerade och okomprimerade storleken för varje post, den totala arkivstorleken och antalet poster. Eftersom en PPTX‑fil är ett ZIP‑arkiv kan en mycket stor presentation överskrida dessa begränsningar. Zip64‑tillägg höjer de tillämpliga storleks‑ och post‑räkningsgränserna.

Använd egenskapen [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pptxoptions/zip64mode/) för att kontrollera om Aspose.Slides skriver Zip64‑tillägg:

- `IfNecessary` använder Zip64 endast när presentationen överskrider standard ZIP‑gränser. Detta är standardläget.
- `Never` inaktiverar Zip64‑tillägg.
- `Always` skriver alltid Zip64‑tillägg.

Följande exempel aktiverar alltid Zip64‑tillägg för utmatningspresentationen:

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

{{% alert color="warning" title="Warning" %}}
Om `Zip64Mode` är satt till `Never` och presentationen inte får plats inom standard ZIP‑gränser, kastar sparoperationen ett [PptxException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Spara presentationer i Office Open XML-format med komprimeringsnivåer**

För PPTX‑utmatning kan du balansera sparhastighet mot filstorlek genom att sätta egenskapen [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pptxoptions/compressionlevel/). Enumet [CompressionLevel](https://reference.aspose.com/slides/sv/net/aspose.slides.export/compressionlevel/) tillhandahåller följande värden:

- `None` lagrar data utan kompression.
- `Level1` ger den snabbaste kompressionen och den största komprimerade utdata.
- `Level2` till `Level5` föredrar gradvis mindre utdata framför sparhastigheten.
- `Level6` balanserar sparhastighet och filstorlek. Detta är standardnivån.
- `Level7` och `Level8` föredrar ännu mer mindre utdata framför sparhastigheten.
- `Level9` ger den starkaste kompressionen och kräver mest bearbetningstid.

Följande exempel sparar en presentation utan kompression:

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

Följande exempel använder den maximala komprimeringsnivån:

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

## **Spara presentationer utan att uppdatera miniatyren**

När en presentation sparas som PPTX styr egenskapen [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pptxoptions/refreshthumbnail/) dess dokumentminiatyr:

- `true` återskapar miniatyren under sparoperationen. Detta är standardvärdet.
- `false` bevarar den befintliga miniatyren. Om presentationen saknar miniatyr genererar Aspose.Slides ingen.

Följande exempel sparar en presentation utan att uppdatera dess miniatyr:

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

{{% alert color="info" title="Note" %}}
Att inaktivera miniatyruppdatering kan minska den tid som krävs för att spara en PPTX‑fil.
{{% /alert %}}

## **Spara förloppsuppdateringar i procent**

För att övervaka en sparoperation, implementera gränssnittet [IProgressCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/iprogresscallback/) och tilldela implementationen till egenskapen [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/sv/net/aspose.slides.export/isaveoptions/progresscallback/). Aspose.Slides anropar sedan [IProgressCallback.Reporting](https://reference.aspose.com/slides/sv/net/aspose.slides/iprogresscallback/reporting/) metoden med förloppsvärden under exporten.

Följande exempel rapporterar förloppet för en PDF‑export till konsolen:

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

{{% alert color="info" title="Note" %}}
Aspose erbjuder en gratis [PowerPoint Splitter](https://products.aspose.app/slides/sv/splitter) byggd med Aspose.Slides‑API:et. Den sparar valda bildspel från en presentation som separata PPT‑ eller PPTX‑filer.
{{% /alert %}}

## **Vanliga frågor**

**Stöder Aspose.Slides inkrementell eller “snabb sparning”?**

Nej. Varje sparoperation skriver en komplett utdatafil snarare än att bara uppdatera de ändrade delarna.

**Kan flera trådar spara samma Presentation‑instans?**

Nej. En [Presentation]‑instans [är inte trådsäker](/slides/sv/net/multithreading/). Accessa och spara varje instans från endast en tråd åt gången.

**Vad händer med hyperlänkar och externt länkade filer när jag sparar en presentation?**

[Hyperlänkar](/slides/sv/net/manage-hyperlinks/) förblir i presentationen. Aspose.Slides kopierar inte externt länkade filer, så den sparade presentationen måste fortfarande kunna komma åt deras platser.

**Kan jag spara dokumentmetadata såsom författare, titel, företag och skapelsedatum?**

Ja. Ställ in lämpliga [dokumentegenskaper](/slides/sv/net/presentation-properties/) innan du sparar, och Aspose.Slides skriver dem till utdatafilen.