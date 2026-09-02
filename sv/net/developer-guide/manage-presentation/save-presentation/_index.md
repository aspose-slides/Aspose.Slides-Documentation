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
- spara framsteg
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur du sparar presentationer i .NET med Aspose.Slides – exportera till PowerPoint eller OpenDocument samtidigt som du behåller layouter, typsnitt och effekter."
---
## **Översikt**

[Öppna presentationer i C#](/slides/sv/net/open-presentation/) beskrev hur du använder [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)-klassen för att öppna en presentation. Den här artikeln förklarar hur du skapar och sparar presentationer. [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)-klassen innehåller en presentations innehåll. Oavsett om du skapar en presentation från början eller modifierar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för .NET kan du spara till en **fil** eller **ström**. Den här artikeln förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)-klassens `Save`-metod. Skicka filnamnet och sparaformatet till metoden. Följande exempel visar hur du sparar en presentation med Aspose.Slides.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Utför något arbete här...

    // Spara presentationen till en fil.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till en ström genom att skicka en utdataström till [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)-klassens `Save`-metod. En presentation kan skrivas till många strömtyper. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides låter dig ange den initiala vyn som PowerPoint använder när den genererade presentationen öppnas via [ViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/)-klassen. Ställ in [LastView](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/lastview/)-egenskapen till ett värde från [ViewType](https://reference.aspose.com/slides/sv/net/aspose.slides/viewtype/)-enumerationen.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Spara presentationer i det strikt Office Open XML-formatet**

Aspose.Slides låter dig spara en presentation i det strikt Office Open XML-formatet. Använd [PptxOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pptxoptions/)-klassen och sätt dess *conformance*-egenskap när du sparar. Om du sätter `Conformance.Iso29500_2008_Strict` sparas utfilen i det strikt Office Open XML-formatet.

Exemplet nedan skapar en presentation och sparar den i det strikt Office Open XML-formatet.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Spara presentationen i det Strikt Office Open XML-formatet.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Spara presentationer i Office Open XML-format i Zip64-läge**

En Office Open XML-fil är ett ZIP‑arkiv som har en gräns på 4 GB (2^32 byte) för den okomprimerade storleken på någon fil, den komprimerade storleken på någon fil och den totala arkivstorleken, samt en gräns på 65 535 (2^16 − 1) filer. ZIP64‑formatutökningar höjer dessa gränser till 2^64.

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipptxoptions/zip64mode/)-egenskapen låter dig välja när du vill använda ZIP64‑formatutökningar när du sparar en Office Open XML‑fil.

Denna egenskap erbjuder följande lägen:

- `IfNecessary` använder ZIP64‑formatutökningar endast om presentationen överskrider begränsningarna ovan. Detta är standardläget.
- `Never` använder aldrig ZIP64‑formatutökningar.
- `Always` använder alltid ZIP64‑formatutökningar.

Följande kod demonstrerar hur du sparar en presentation som en PPTX‑fil med ZIP64‑formatutökningar aktiverade:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
När du sparar med `Zip64Mode.Never` kastas ett [PptxException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxexception/) om presentationen inte kan sparas i ZIP32‑format.
{{% /alert %}}

## **Spara presentationer i Office Open XML-format med komprimeringsnivåer**

När du arbetar med stora presentationer kan du justera komprimeringsnivån för att balansera filstorlek och behandlingstid. Beroende på dina krav kan du föredra snabbare bearbetning eller mindre utdatafiler.

Aspose.Slides tillhandahåller [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipptxoptions/compressionlevel/)-egenskapen, som låter dig ange vilken komprimeringsnivå som ska användas när du sparar en presentation i Office Open XML-format.

Följande komprimeringsnivåer finns tillgängliga:

- **None**: Ingen komprimering tillämpas. Filer lagras som de är.
- **Level1**: Den snabbaste komprimeringen med lägst komprimeringsförhållande.
- **Level2**: Snabbare komprimering med något bättre komprimeringsförhållande än **Level1**.
- **Level3**: Ger bättre komprimering än **Level2** med måttlig inverkan på behandlingstiden.
- **Level4**: Ger bättre komprimering än **Level3**.
- **Level5**: Ger förbättrad komprimering jämfört med **Level4** med extra behandlingstid.
- **Level6**: Standardkomprimering som erbjuder en bra balans mellan bearbetningshastighet och filstorlek. Detta är *standardkomprimeringsnivån*.
- **Level7**: Ger bättre komprimering än **Level6** men med långsammare bearbetning.
- **Level8**: Ger bättre komprimering än **Level7**.
- **Level9**: Maximalkomprimering. Producerar den minsta filstorleken men med längst bearbetningstid.

Följande exempel demonstrerar hur du sparar en presentation som en PPTX‑fil *utan komprimering*:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Detta exempel visar hur du sparar en presentation som en PPTX‑fil med *maximal komprimering*:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Spara presentationer utan att uppdatera miniatyren**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipptxoptions/refreshthumbnail/)-egenskapen styr miniatyrgenerering när en presentation sparas till PPTX:

- Om värdet är `true` uppdateras miniatyren under sparandet. Detta är standard.
- Om värdet är `false` bevaras den nuvarande miniatyren. Om presentationen saknar miniatyr genereras ingen.

I koden nedan sparas presentationen till PPTX utan att uppdatera dess miniatyr.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Spara framstegsuppdateringar i procent**

[IProgressCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/iprogresscallback/)-gränssnittet används via `ProgressCallback`‑egenskapen som exponeras av [ISaveOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/isaveoptions/)-gränssnittet och den abstrakta [SaveOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveoptions/)-klassen. Tilldela en [IProgressCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/iprogresscallback/)-implementation till `ProgressCallback` för att få sparningsframstegsuppdateringar i procent.

Följande kodsnuttar visar hur du använder `IProgressCallback`.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Använd värdet för framstegsprocenten här.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose har utvecklat en [fri PowerPoint Splitter‑app](https://products.aspose.app/slides/sv/splitter) med sitt eget API. Appen låter dig dela en presentation i flera filer genom att spara valda bilder som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **Vanliga frågor**

**Stöds ”snabbsparning” (inkrementell sparning) så att bara ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell ”snabbsparning” stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans är [är inte trådsäker](/slides/sv/net/multithreading/); spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparning?**

[Hyperlänkar](/slides/sv/net/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt — se till att de refererade sökvägarna förblir åtkomliga.

**Kan jag ange/spara dokumentmetadata (Författare, Titel, Företag, Datum)?**

Ja. Standard [dokumentegenskaper](/slides/sv/net/presentation-properties/) stöds och kommer att skrivas till filen vid sparning.