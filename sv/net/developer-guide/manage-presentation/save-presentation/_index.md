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
- Strikt Office Open XML-format
- Zip64-läge
- uppdatera miniatyr
- sparande framsteg
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur du sparar presentationer i .NET med Aspose.Slides — exportera till PowerPoint eller OpenDocument samtidigt som du behåller layouter, teckensnitt och effekter."
---
## **Översikt**

[Open Presentations in C#](/slides/sv/net/open-presentation/) beskrev hur du använder klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) för att öppna en presentation. Denna artikel förklarar hur du skapar och sparar presentationer. Klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) innehåller en presentations innehåll. Oavsett om du skapar en presentation från början eller modifierar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för .NET kan du spara till en **fil** eller **ström**. Denna artikel förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa klassens [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) `Save`-metod. Skicka filnamnet och sparformatet till metoden. Följande exempel visar hur du sparar en presentation med Aspose.Slides.

```cs
// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Utför något arbete här...

    // Spara presentationen till en fil.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till en ström genom att skicka en utskriftsström till klassens [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) `Save`-metod. En presentation kan skrivas till många strömtyper. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

```cs
// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Spara presentationen till strömmen.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Spara presentationer med en fördefinierad vytyp**

Aspose.Slides låter dig ange den initiala vyn som PowerPoint använder när den genererade presentationen öppnas via klassen [ViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/). Ställ in egenskapen [LastView](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/lastview/) till ett värde från uppräkningen [ViewType](https://reference.aspose.com/slides/sv/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Spara presentationer i det strikt Office Open XML-formatet**

Aspose.Slides låter dig spara en presentation i det strikt Office Open XML-formatet. Använd klassen [PptxOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pptxoptions/) och sätt dess conformance‑egenskap när du sparar. Om du sätter `Conformance.Iso29500_2008_Strict` sparas utdatafilen i det strikt Office Open XML-formatet.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Spara presentationen i det Strikta Office Open XML-formatet.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Spara presentationer i Office Open XML-format i Zip64-läge**

En Office Open XML‑fil är ett ZIP‑arkiv som har gränser på 4 GB (2^32 byte) för den okomprimerade storleken på någon fil, den komprimerade storleken på någon fil och den totala storleken på arkivet, samt en gräns på 65 535 (2^16‑1) filer. ZIP64‑formatutökningar höjer dessa gränser till 2^64.

Egenskapen [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipptxoptions/zip64mode/) låter dig välja när ZIP64‑formatutökningar ska användas vid sparning av en Office Open XML‑fil.

Denna egenskap erbjuder följande lägen:

- `IfNecessary` använder ZIP64‑formatutökningar endast om presentationen överskrider ovanstående begränsningar. Detta är standardläget.
- `Never` använder aldrig ZIP64‑formatutökningar.
- `Always` använder alltid ZIP64‑formatutökningar.

Följande kod demonstrerar hur du sparar en presentation som en PPTX‑fil med ZIP64‑formatutökningar aktiverade:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="OBS" color="warning" %}}
När du sparar med `Zip64Mode.Never` kastas ett [PptxException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxexception/) om presentationen inte kan sparas i ZIP32‑format.
{{% /alert %}}

## **Spara presentationer i Office Open XML-format med komprimeringsnivåer**

När du arbetar med stora presentationer kan du justera komprimeringsnivån för att balansera filstorlek och bearbetningstid. Beroende på dina krav kan du föredra snabbare bearbetning eller mindre utdatafiler.

Aspose.Slides tillhandahåller egenskapen [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipptxoptions/compressionlevel/) som låter dig specificera vilken komprimeringsnivå som ska användas när en presentation sparas i Office Open XML‑format.

Följande komprimeringsnivåer är tillgängliga:

- **None**: Ingen kompression tillämpas. Filer lagras som de är.
- **Level1**: Den snabbaste kompressionen med den lägsta komprimeringsgraden.
- **Level2**: Snabbare kompression med något bättre komprimeringsgrad än **Level1**.
- **Level3**: Ger bättre kompression än **Level2** med måttlig påverkan på bearbetningstiden.
- **Level4**: Ger bättre kompression än **Level3**.
- **Level5**: Ger förbättrad kompression jämfört med **Level4** med extra bearbetningstid.
- **Level6**: Standardkompression som ger en bra balans mellan bearbetningshastighet och filstorlek. Detta är *standardkomprimeringsnivån*.
- **Level7**: Ger bättre kompression än **Level6** men med långsammare bearbetning.
- **Level8**: Ger bättre kompression än **Level7**.
- **Level9**: Maximal kompression. Ger den minsta filstorleken men kräver längst bearbetningstid.

Följande exempel demonstrerar hur du sparar en presentation som en PPTX‑fil *utan kompression*:

```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Detta exempel visar hur du sparar en presentation som en PPTX‑fil med *maximal kompression*:

```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Spara presentationer utan att uppdatera miniatyren**

Egenskapen [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) styr miniatyrgenerering när en presentation sparas till PPTX:

- Om den är satt till `true` uppdateras miniatyren vid sparning. Detta är standard.
- Om den är satt till `false` bevaras den befintliga miniatyren. Om presentationen saknar miniatyr genereras ingen.

I koden nedan sparas presentationen till PPTX utan att uppdatera dess miniatyr.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Detta alternativ hjälper till att minska den tid som krävs för att spara en presentation i PPTX‑format.
{{% /alert %}}

## **Spara förloppsuppdateringar i procent**

Gränssnittet [IProgressCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/iprogresscallback/) används via egenskapen `ProgressCallback` som exponeras av gränssnittet [ISaveOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/isaveoptions/) och den abstrakta klassen [SaveOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveoptions/). Tilldela en [IProgressCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/iprogresscallback/)-implementation till `ProgressCallback` för att få sparförloppsuppdateringar som procent.

Följande kodsnuttar visar hur du använder `IProgressCallback`.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Använd värdet för framsteg i procent här.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose har utvecklat en [gratis PowerPoint Splitter‑app](https://products.aspose.app/slides/sv/splitter) med sitt eget API. Appen låter dig dela en presentation i flera filer genom att spara markerade bilder som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **Vanliga frågor**

**Stöds "snabb sparning" (inkrementell sparning) så att bara ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell "snabb sparning" stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans [är inte trådsäker](/slides/sv/net/multithreading/); spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparning?**

[Hyperlinks](/slides/sv/net/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt – se till att de refererade sökvägarna förblir tillgängliga.

**Kan jag ange/spara dokumentmetadata (Författare, Titel, Företag, Datum)?**

Ja. Standard [document properties](/slides/sv/net/presentation-properties/) stöds och skrivs till filen vid sparning.