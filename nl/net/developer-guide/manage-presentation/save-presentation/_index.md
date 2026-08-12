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
- Strict Office Open XML-formaat
- Zip64-modus
- miniatuur vernieuwen
- voortgang opslaan
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe u presentaties in .NET kunt opslaan met Aspose.Slides—exporteren naar PowerPoint of OpenDocument met behoud van lay-outs, lettertypen en effecten."
---
## **Overzicht**

[Open Presentaties in C#](/slides/nl/net/open-presentation/) beschrijft hoe je de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse kunt gebruiken om een presentatie te openen. Dit artikel legt uit hoe je presentaties kunt maken en opslaan. De [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse bevat de inhoud van een presentatie. Of je nu een presentatie vanaf nul maakt of een bestaande bewerkt, je wilt deze opslaan zodra je klaar bent. Met Aspose.Slides voor .NET kun je opslaan naar een **bestand** of **stream**. Dit artikel legt de verschillende manieren uit om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op naar een bestand door de `Save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse aan te roepen. Geef de bestandsnaam en het opslagformaat door aan de methode. Het volgende voorbeeld laat zien hoe je een presentatie opslaat met Aspose.Slides.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Doe hier wat werk...

    // Sla de presentatie op naar een bestand.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Presentaties opslaan naar streams**

Je kunt een presentatie opslaan naar een stream door een output‑stream door te geven aan de `Save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse. Een presentatie kan naar veel verschillende stream‑typen worden geschreven. In het voorbeeld hieronder maken we een nieuwe presentatie en slaan we deze op naar een bestands‑stream.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Sla de presentatie op naar de stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Presentaties opslaan met een vooraf gedefinieerde weergavetype**

Aspose.Slides stelt je in staat het oorspronkelijke weergave‑type in te stellen dat PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend via de [ViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/) klasse. Stel de eigenschap [LastView](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/lastview/) in op een waarde uit de enumeratie [ViewType](https://reference.aspose.com/slides/nl/net/aspose.slides/viewtype/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Presentaties opslaan in het Strict Office Open XML‑formaat**

Aspose.Slides laat je een presentatie opslaan in het Strict Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pptxoptions/) klasse en stel bij het opslaan de eigenschap `Conformance` in. Als je `Conformance.Iso29500_2008_Strict` instelt, wordt het uitvoerbestand opgeslagen in het Strict Office Open XML‑formaat.

Het voorbeeld hieronder creëert een presentatie en slaat deze op in het Strict Office Open XML‑formaat.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Sla de presentatie op in het Strict Office Open XML-formaat.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een Office Open XML‑bestand is een ZIP‑archief dat limieten van 4 GB (2^32 bytes) oplegt aan de ongecomprimeerde grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en tevens een limiet van 65 535 (2^16‑1) bestanden. ZIP64‑formatextensies verhogen deze limieten naar 2^64.

De eigenschap [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ipptxoptions/zip64mode/) laat je kiezen wanneer ZIP64‑formatextensies worden gebruikt bij het opslaan van een Office Open XML‑bestand.

Deze eigenschap biedt de volgende modi:

- `IfNecessary` gebruikt ZIP64‑formatextensies alleen als de presentatie de bovenstaande beperkingen overschrijdt. Dit is de standaardmodus.
- `Never` gebruikt nooit ZIP64‑formatextensies.
- `Always` gebruikt altijd ZIP64‑formatextensies.

De volgende code laat zien hoe je een presentatie opslaat als een PPTX‑bestand met ZIP64‑formatextensies ingeschakeld:

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
Wanneer je opslaat met `Zip64Mode.Never`, wordt een [PptxException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxexception/) gegooid als de presentatie niet in ZIP32‑formaat kan worden opgeslagen.
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Wanneer je met grote presentaties werkt, kun je het compressieniveau aanpassen om een balans te vinden tussen bestandsgrootte en verwerkingstijd. Afhankelijk van je eisen kun je kiezen voor snellere verwerking of kleinere uitvoerbestanden.

Aspose.Slides biedt de eigenschap [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ipptxoptions/compressionlevel/), waarmee je het compressieniveau kunt opgeven dat wordt gebruikt bij het opslaan van een presentatie in Office Open XML‑formaat.

De volgende compressieniveaus zijn beschikbaar:

- **None**: Er wordt geen compressie toegepast. Bestanden worden onveranderd opgeslagen.
- **Level1:** De snelste compressie met de laagste compressieverhouding.
- **Level2:** Snellere compressie met een iets betere compressieverhouding dan **Level1**.
- **Level3:** Biedt betere compressie dan **Level2** met een matige impact op de verwerkingstijd.
- **Level4:** Biedt betere compressie dan **Level3**.
- **Level5:** Biedt verbeterde compressie ten opzichte van **Level4** met extra verwerkingstijd.
- **Level6:** Standaardcompressie die een goede balans biedt tussen verwerkingssnelheid en bestandsgrootte. Dit is het *standaardcompressieniveau*.
- **Level7:** Biedt betere compressie dan **Level6** met tragere verwerking.
- **Level8:** Biedt betere compressie dan **Level7**.
- **Level9:** Maximale compressie. Produceert de kleinste bestandsgrootte ten koste van de langste verwerkingstijd.

Het volgende voorbeeld laat zien hoe je een presentatie opslaat als een PPTX‑bestand *zonder compressie*:

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

Dit voorbeeld toont hoe je een presentatie opslaat als een PPTX‑bestand met *maximale compressie*:

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

## **Presentaties opslaan zonder de miniatuur te vernieuwen**

De eigenschap [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) regelt het genereren van een miniatuur bij het opslaan van een presentatie naar PPTX:

- Als deze op `true` staat, wordt de miniatuur tijdens het opslaan ververst. Dit is de standaardwaarde.
- Als deze op `false` staat, wordt de huidige miniatuur behouden. Als de presentatie geen miniatuur heeft, wordt er geen gegenereerd.

In de code hieronder wordt de presentatie opgeslagen naar PPTX zonder de miniatuur te vernieuwen.

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
Deze optie helpt de tijd die nodig is om een presentatie in PPTX‑formaat op te slaan te verkorten.
{{% /alert %}}

## **Opslaan voortgangsupdates in percentage**

De interface [IProgressCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/iprogresscallback/) wordt gebruikt via de eigenschap `ProgressCallback` die wordt blootgesteld door de interface [ISaveOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/isaveoptions/) en de abstracte klasse [SaveOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveoptions/). Wijs een implementatie van [IProgressCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/iprogresscallback/) toe aan `ProgressCallback` om voortgangsupdates van het opslaan als percentage te ontvangen.

De volgende code‑fragmenten laten zien hoe je `IProgressCallback` gebruikt.

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
        // Gebruik hier de voortgangspercentagewaarde.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose heeft een [gratis PowerPoint‑Splitter‑app](https://products.aspose.app/slides/nl/splitter) ontwikkeld met behulp van haar eigen API. De app laat je een presentatie opsplitsen in meerdere bestanden door geselecteerde dia’s op te slaan als nieuwe PPTX‑ of PPT‑bestanden.
{{% /alert %}}

## **FAQ**

**Is “fast save” (incremental save) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Opslaan maakt iedere keer een volledig doelbestand; incrementeel “fast save” wordt niet ondersteund.

**Is het thread‑safe om dezelfde Presentation‑instantie vanaf meerdere threads op te slaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie [is niet thread‑safe](/slides/nl/net/multithreading/); sla deze op vanuit één enkele thread.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden bij het opslaan?**

[Hyperlinks](/slides/nl/net/manage-hyperlinks/) blijven behouden. Extern gelinkte bestanden (bijv. video’s via relatieve paden) worden niet automatisch gekopieerd — zorg ervoor dat de verwezen paden toegankelijk blijven.

**Kan ik documentmetadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [documenteigenschappen](/slides/nl/net/presentation-properties/) worden ondersteund en bij het opslaan in het bestand geschreven.