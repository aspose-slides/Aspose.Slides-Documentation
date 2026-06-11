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
- sparningsframsteg
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur du sparar presentationer i .NET med Aspose.Slides—exportera till PowerPoint eller OpenDocument samtidigt som du behåller layouter, typsnitt och effekter."
---
## **Översikt**

[Öppna presentationer i C#](/slides/sv/net/open-presentation/) beskriver hur man använder klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) för att öppna en presentation. Denna artikel förklarar hur man skapar och sparar presentationer. Klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) innehåller en presentations innehåll. Oavsett om du skapar en presentation från början eller modifierar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för .NET kan du spara till en **fil** eller **ström**. Denna artikel förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa `Save`‑metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/). Skicka filnamnet och sparaformatet till metoden. Följande exempel visar hur man sparar en presentation med Aspose.Slides.

```cs
// Skapa ett Presentation-objekt som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Gör lite arbete här...

    // Spara presentationen till en fil.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till en ström genom att skicka en utström till `Save`‑metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/). En presentation kan skrivas till många strömmar. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

```cs
// Skapa en Presentation-klass som representerar en presentationsfil.
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

## **Spara presentationer i det strikta Office Open XML-formatet**

Aspose.Slides låter dig spara en presentation i det strikta Office Open XML-formatet. Använd klassen [PptxOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pptxoptions/) och ange dess konformitetsegenskap när du sparar. Om du sätter `Conformance.Iso29500_2008_Strict` sparas utdatafilen i det strikta Office Open XML-formatet.

Exemplet nedan skapar en presentation och sparar den i det strikta Office Open XML-formatet.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Spara presentationen i det strikta Office Open XML-formatet.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Spara presentationer i Office Open XML-format i Zip64‑läge**

En Office Open XML‑fil är ett ZIP‑arkiv som har en begränsning på 4 GB (2^32 byte) för den okomprimerade storleken på någon fil, den komprimerade storleken på någon fil och den totala storleken på arkivet, samt begränsar arkivet till 65 535 (2^16‑1) filer. ZIP64‑formatutökningar höjer dessa begränsningar till 2^64.

Egenskapen [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipptxoptions/zip64mode/) låter dig välja när ZIP64‑formatutökningar ska användas vid sparande av en Office Open XML‑fil.

Denna egenskap tillhandahåller följande lägen:

- `IfNecessary` använder ZIP64‑formatutökningar endast om presentationen överskrider begränsningarna ovan. Detta är standardläget.
- `Never` använder aldrig ZIP64‑formatutökningar.
- `Always` använder alltid ZIP64‑formatutökningar.

Följande kod visar hur man sparar en presentation som PPTX med ZIP64‑formatutökningar aktiverade:

```cs
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

## **Spara presentationer utan att uppdatera miniatyrbilden**

Egenskapen [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) styr miniatyrgenerering när en presentation sparas till PPTX:

- Om den är satt till `true` uppdateras miniatyren vid sparande. Detta är standard.
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

## **Spara framstegsuppdateringar i procent**

Gränssnittet [IProgressCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/iprogresscallback/) används via egenskapen `ProgressCallback` som exponeras av gränssnittet [ISaveOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/isaveoptions/) och den abstrakta klassen [SaveOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveoptions/). Tilldela en implementation av [IProgressCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/iprogresscallback/) till `ProgressCallback` för att få sparningsframstegsuppdateringar i procent.

Följande kodsnuttar visar hur man använder `IProgressCallback`.

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
        // Använd procentsatsen för framsteg här.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose har utvecklat en [gratis PowerPoint‑delningsapp](https://products.aspose.app/slides/sv/splitter) med sitt eget API. Appen låter dig dela upp en presentation i flera filer genom att spara valda bilder som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **Vanliga frågor**

**Stöds "snabb sparning" (inkrementell sparning) så att endast ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell ”snabb sparning” stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans [är inte trådsäker](/slides/sv/net/multithreading/); spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparning?**

[Hyperlänkar](/slides/sv/net/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt — se till att de refererade sökvägarna förblir åtkomliga.

**Kan jag ange/spara dokumentmetadata (Author, Title, Company, Date)?**

Ja. Standard [dokumentegenskaper](/slides/sv/net/presentation-properties/) stöds och kommer att skrivas till filen vid sparning.