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
description: "Leer hoe u PowerPoint- en OpenDocument‑presentaties in C# kunt openen, openingswachtwoorden kunt opgeven, het laden van resources kunt beheersen en het geheugengebruik kunt verminderen met Aspose.Slides voor .NET."
---
## **Inleiding**

[Aspose.Slides for .NET](https://products.aspose.com/slides/nl/net/) kan PowerPoint- en OpenDocument‑presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kunt u de structuur inspecteren, dia’s bewerken, resources beheren en deze opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan aangepast worden via de [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/)‑klasse. U kunt bijvoorbeeld een openingswachtwoord opgeven, grote binaire objecten buiten het beheerde geheugen houden, externe resources controleren of ingebedde binaire gegevens weglaten.

## **Presentaties openen**

Na het laden van een bestand of stream kunt u [determine its original presentation format](/slides/nl/net/detect-presentation-source-format/) om te kiezen hoe uw applicatie het verwerkt.

Om een bestaande presentatie te openen, geeft u het bestandspad door aan de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑constructor. Maak de presentatie vrij na gebruik zodat bestands‑handles, tijdelijke gegevens en andere resources tijdig worden vrijgegeven.

Het volgende C#‑voorbeeld toont hoe u een presentatie opent en het aantal dia’s opvraagt:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Wachtwoord‑beveiligde presentaties openen**

Een openingswachtwoord versleutelt de inhoud van de presentatie. Om de volledige presentatie te laden, wijst u het juiste wachtwoord toe aan [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/) en geeft u de opties door aan de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑constructor. Het laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Voor wachtwoorddetectie, validatie en versleutelingsprocessen, zie [Password‑Protect Presentations](/slides/nl/net/password-protected-presentation/). Als een versleutelde presentatie bewust is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen gelezen worden zonder wachtwoord; zie [Manage Presentation Properties](/slides/nl/net/presentation-properties/).

## **Grote presentaties openen**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/blobmanagementoptions/) bepaalt hoe Aspose.Slides omgaat met binaire grote objecten zoals afbeeldingen, audio en video. U kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑gegevens die in het geheugen wordt bewaard beperken.

De volgende C#‑code laat zien hoe u een grote presentatie laadt (bijvoorbeeld 2 GB):

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
Met `PresentationLockingBehavior.KeepLocked` blijft het bronbestand vergrendeld totdat het `Presentation`‑object wordt vrijgegeven. Verplaats, overschrijf of verwijder het bronbestand niet zolang dat object bestaat.

Aspose.Slides kan de inhoud van een invoerstroom kopiëren tijdens het laden. Voor grote presentaties is een bestandspad doorgaans efficiënter dan een stream. Zie [Manage BLOBs](/slides/nl/net/manage-blob/) voor extra opslag‑ en geheugenbeheeropties.
{{% /alert %}}

## **Externe resources beheersen**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/resourceloadingcallback/) accepteert een [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/iresourceloadingcallback/)‑implementatie. De callback kan vervangende data leveren, een resource omleiden, de standaardlader gebruiken of de resource overslaan. Dit is nuttig wanneer presentaties externe afbeeldingen bevatten die moeten worden opgelost volgens toepassingsspecifieke beveiligings‑ of opslagregels.

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

## **Presentaties laden zonder ingebedde binaire objecten**

Een presentatie kan ingebedde binaire gegevens bevatten die een applicatie niet nodig heeft of niet wil behouden. Voorbeelden zijn:

- VBA‑projecten, beschikbaar via [IPresentation.VbaProject](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/vbaproject/);
- ingebedde OLE‑data, beschikbaar via [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- ActiveX‑controlegegevens, beschikbaar via [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/nl/net/aspose.slides/icontrol/activexcontrolbinary/).

Stel [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) in op `true` om deze binaire gegevens bij het laden te verwijderen. Sla de geladen presentatie op om het opgeschoonde resultaat te behouden.

Deze optie vermindert de blootstelling aan ongewenste ingebedde payloads, maar is geen compleet systeem voor malware‑detectie of inhouds‑sanitisatie.

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

## **Veelgestelde vragen**

**Hoe kan ik bepalen dat een bestand corrupt is en niet geopend kan worden?**

Aspose.Slides gooit een parse‑ of format‑exception tijdens het laden. Verwerk die fout apart van een onjuist‑wachtwoord‑fout zodat de applicatie de oorzaak nauwkeurig kan rapporteren.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds geladen worden, maar weergave en export kunnen lettertypen vervangen. U kunt [configure font substitution](/slides/nl/net/font-substitution/) of [provide custom fonts](/slides/nl/net/custom-font/) om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio en video worden beschikbaar via het presentatie‑objectmodel. Externe resources worden opgelost volgens het geconfigureerde resource‑laadgedrag en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.