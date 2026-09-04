---
title: Presentaties openen in .NET
linktitle: Presentatie openen
type: docs
weight: 20
url: /nl/net/open-presentation/
keywords:
- PowerPoint openen
- presentatie openen
- PPTX openen
- PPT openen
- ODP openen
- presentatie laden
- PPTX laden
- PPT laden
- ODP laden
- beveiligde presentatie
- grote presentatie
- externe resource
- binaire object
- .NET
- C#
- Aspose.Slides
description: "Leer hoe je PowerPoint- en OpenDocument-presentaties kunt openen in C#, een openingswachtwoord kunt opgeven, het laden van resources kunt beheersen en het geheugenverbruik kunt verminderen met Aspose.Slides voor .NET."
---
## **Inleiding**

[Aspose.Slides for .NET](https://products.aspose.com/slides/nl/net/) kan PowerPoint- en OpenDocument‑presentaties laden vanaf bestanden en streams. Nadat een presentatie is geladen, kun je de structuur inspecteren, dia’s bewerken, resources beheren en opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan worden aangepast via de klasse [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/). Je kunt bijvoorbeeld een openings‑wachtwoord opgeven, grote binaire objecten buiten het beheerde geheugen houden, externe resources controleren of ingebedde binaire gegevens weglaten.

## **Presentaties Openen**

Om een bestaande presentatie te openen, geef je het bestandspad door aan de constructor van [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/). Maak de presentatie na gebruik vrij zodat bestands‑handles, tijdelijke gegevens en andere resources snel worden vrijgegeven.

Het volgende C#‑voorbeeld toont hoe je een presentatie opent en het aantal dia’s opvraagt:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Presentaties Openen met Wachtwoord**

Een openings‑wachtwoord versleutelt de inhoud van de presentatie. Om de volledige presentatie te laden, ken je het juiste wachtwoord toe aan [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/) en geef je de opties door aan de constructor van [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/). Laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Voor wachtwoorddetectie, validatie en encryptieworkflows, zie [Password‑Protect Presentations](/slides/nl/net/password-protected-presentation/). Als een versleutelde presentatie bewust is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen zonder wachtwoord worden gelezen; zie [Manage Presentation Properties](/slides/nl/net/presentation-properties/).

## **Grote Presentaties Openen**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/blobmanagementoptions/) bepaalt hoe Aspose.Slides omgaat met grote binaire objecten zoals afbeeldingen, audio en video. Je kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑gegevens die in het geheugen worden bewaard beperken.

De volgende C#‑code laat zien hoe je een grote presentatie (bijv. 2 GB) laadt:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Met `PresentationLockingBehavior.KeepLocked` blijft het bronbestand vergrendeld totdat het `Presentation`‑object wordt vrijgegeven. Verplaats, overschrijf of verwijder het bronbestand niet zolang dat object nog bestaat.

Aspose.Slides kan de inhoud van een invoer‑stream kopiëren tijdens het laden. Voor grote presentaties is een bestandspad doorgaans efficiënter dan een stream. Zie [Manage BLOBs](/slides/nl/net/manage-blob/) voor extra opslag‑ en geheugen‑beheeropties.
{{% /alert %}}

## **Externe Resources Beheren**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/resourceloadingcallback/) accepteert een implementatie van [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/iresourceloadingcallback/). De callback kan vervangende gegevens leveren, een resource omleiden, de standaardloader gebruiken of de resource overslaan. Dit is handig wanneer presentaties externe afbeeldingen bevatten die volgens toepassingsspecifieke beveiligings‑ of opslagregels moeten worden resolved.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Presentaties Laden zonder Ingebedde Binaire Objecten**

Een presentatie kan ingebedde binaire gegevens bevatten die een applicatie niet nodig heeft of niet wil behouden. Voorbeelden zijn:

- VBA‑projecten, toegankelijk via [IPresentation.VbaProject](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/vbaproject/);
- ingebedde OLE‑gegevens, toegankelijk via [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- ActiveX‑controlegegevens, toegankelijk via [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/nl/net/aspose.slides/icontrol/activexcontrolbinary/).

Stel [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) in op `true` om deze binaire gegevens bij het laden te verwijderen. Sla de geladen presentatie vervolgens op om het opgeschoonde resultaat te behouden.

Deze optie vermindert de blootstelling aan ongewenste ingebedde payloads, maar vormt geen volledige malware‑detectie‑ of content‑sanitiseringsoplossing.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Hoe kan ik bepalen dat een bestand corrupt is en niet geopend kan worden?**

Aspose.Slides gooit een parse‑ of format‑exception tijdens het laden. Verwerk die fout apart van een onjuist‑wachtwoord‑fout zodat de applicatie de oorzaak nauwkeurig kan melden.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds worden geladen, maar weergave en export kunnen lettertypen substitueren. Je kunt [lettertype‑substitutie configureren](/slides/nl/net/font-substitution/) of [aangepaste lettertypen aanbieden](/slides/nl/net/custom-font/) om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio en video worden beschikbaar via het presentatiemodel. Externe resources worden resolved volgens het geconfigureerde resource‑loading‑gedrag en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.