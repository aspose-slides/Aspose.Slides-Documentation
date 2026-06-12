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
- miniatuur vernieuwen
- opslagvoortgang
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe u presentaties kunt opslaan in .NET met Aspose.Slides—exporteren naar PowerPoint of OpenDocument terwijl lay-outs, lettertypen en effecten behouden blijven."
---
## **Overzicht**

[Open Presentations in C#](/slides/nl/net/open-presentation/) beschrijft hoe je de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse gebruikt om een presentatie te openen. Dit artikel legt uit hoe je presentaties maakt en opslaat. De [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse bevat de inhoud van een presentatie. Of je nu een presentatie vanaf nul maakt of een bestaande wijzigt, je wilt deze opslaan als je klaar bent. Met Aspose.Slides voor .NET kun je opslaan naar een **bestand** of **stream**. Dit artikel beschrijft de verschillende manieren om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op naar een bestand door de `Save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse aan te roepen. Geef de bestandsnaam en het opslagformaat door aan de methode. Het onderstaande voorbeeld laat zien hoe je een presentatie opslaat met Aspose.Slides.

```cs
// Instantieer de Presentation-klasse die een presentatiebestand representeert.
using (Presentation presentation = new Presentation())
{
    // Voer hier wat werk uit...
    // Sla de presentatie op naar een bestand.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Presentaties opslaan naar streams**

Je kunt een presentatie opslaan naar een stream door een output‑stream door te geven aan de `Save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse. Een presentatie kan naar veel verschillende stream‑typen worden geschreven. In het onderstaande voorbeeld maken we een nieuwe presentatie en slaan we deze op naar een bestands‑stream.

```cs
// Instantieer de Presentation-klasse die een presentatiebestand representeert.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Sla de presentatie op naar de stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

Aspose.Slides laat je de initiële weergave instellen die PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend via de [ViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/)‑klasse. Stel de [LastView](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/lastview/)‑eigenschap in op een waarde uit de [ViewType](https://reference.aspose.com/slides/nl/net/aspose.slides/viewtype/)‑enumeratie.

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Presentaties opslaan in het strikte Office Open XML‑formaat**

Aspose.Slides laat je een presentatie opslaan in het strikte Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pptxoptions/)‑klasse en stel de `Conformance`‑eigenschap in bij het opslaan. Als je `Conformance.Iso29500_2008_Strict` zet, wordt het uitvoerbestand opgeslagen in het strikte Office Open XML‑formaat.

Het onderstaande voorbeeld maakt een presentatie en slaat deze op in het strikte Office Open XML‑formaat.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instantieer de Presentation-klasse die een presentatiebestand representeert.
using (Presentation presentation = new Presentation())
{
    // Sla de presentatie op in het Strikte Office Open XML-formaat.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een Office Open XML‑bestand is een ZIP‑archief dat een limiet van 4 GB (2^32 bytes) oplegt aan de gedecomprimeerde grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en tevens een limiet van 65 535 (2^16‑1) bestanden. ZIP64‑formatextensies verhogen deze limieten tot 2^64.

De [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ipptxoptions/zip64mode/)‑eigenschap laat je kiezen wanneer ZIP64‑formatextensies gebruikt moeten worden bij het opslaan van een Office Open XML‑bestand.

Deze eigenschap biedt de volgende modi:

- `IfNecessary` gebruikt ZIP64‑formatextensies alleen als de presentatie de bovenstaande beperkingen overschrijdt. Dit is de standaardmodus.
- `Never` gebruikt nooit ZIP64‑formatextensies.
- `Always` gebruikt altijd ZIP64‑formatextensies.

De volgende code toont hoe je een presentatie opslaat als PPTX met ZIP64‑formatextensies ingeschakeld:

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
Als je opslaat met `Zip64Mode.Never`, wordt een [PptxException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxexception/) gegooid wanneer de presentatie niet in ZIP32‑formaat kan worden opgeslagen.
{{% /alert %}}

## **Presentaties opslaan zonder de miniatuur te vernieuwen**

De [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ipptxoptions/refreshthumbnail/)‑eigenschap regelt de generatie van miniaturen bij het opslaan van een presentatie naar PPTX:

- Als deze op `true` staat, wordt de miniatuur tijdens het opslaan vernieuwd. Dit is de standaard.
- Als deze op `false` staat, blijft de huidige miniatuur behouden. Als de presentatie geen miniatuur heeft, wordt er geen gegenereerd.

In de onderstaande code wordt de presentatie opgeslagen naar PPTX zonder de miniatuur te vernieuwen.

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
Deze optie helpt de tijd te verkorten die nodig is om een presentatie op te slaan in PPTX‑formaat.
{{% /alert %}}

## **Opslagvoortgang bijwerken in percentages**

De [IProgressCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/iprogresscallback/)‑interface wordt gebruikt via de `ProgressCallback`‑eigenschap die wordt blootgesteld door de [ISaveOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/isaveoptions/)‑interface en de abstracte [SaveOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveoptions/)‑klasse. Wijs een implementatie van [IProgressCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/iprogresscallback/) toe aan `ProgressCallback` om voortgangs‑updates tijdens het opslaan in percentages te ontvangen.

De volgende code‑fragmenten laten zien hoe je `IProgressCallback` gebruikt.

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
        // Gebruik hier de voortgangspercentagewaarde.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose heeft een [gratis PowerPoint Splitter‑app](https://products.aspose.app/slides/nl/splitter) ontwikkeld met behulp van zijn eigen API. De app laat je een presentatie splitsen in meerdere bestanden door geselecteerde dia's op te slaan als nieuwe PPTX‑ of PPT‑bestanden.
{{% /alert %}}

## **FAQ**

**Wordt \"fast save\" (incrementaal opslaan) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Opslaan maakt telkens het volledige doelbestand; incrementeel \"fast save\" wordt niet ondersteund.

**Is het thread‑safe om dezelfde Presentation‑instantie vanuit meerdere threads op te slaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie [is niet thread‑safe](/slides/nl/net/multithreading/); sla deze op vanuit één thread.

**Wat gebeurt er met hyperlinks en extern gekoppelde bestanden bij het opslaan?**

[Hyperlinks](/slides/nl/net/manage-hyperlinks/) blijven behouden. Extern gekoppelde bestanden (bijv. video’s via relatieve paden) worden niet automatisch gekopieerd – zorg ervoor dat de refererende paden toegankelijk blijven.

**Kan ik document‑metadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [documenteigenschappen](/slides/nl/net/presentation-properties/) worden ondersteund en bij het opslaan in het bestand weggeschreven.