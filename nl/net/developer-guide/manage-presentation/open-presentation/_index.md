---
title: Open Presentaties in .NET
linktitle: Open Presentatie
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
- externe bron
- binair object
- .NET
- C#
- Aspose.Slides
description: "Open PowerPoint (.pptx, .ppt) en OpenDocument (.odp) presentaties moeiteloos met Aspose.Slides voor .NET—snel, betrouwbaar, volledig uitgerust."
---
## **Inleiding**

Naast het maken van PowerPoint‑presentaties vanaf nul, stelt Aspose.Slides u ook in staat bestaande presentaties te openen. Nadat u een presentatie hebt geladen, kunt u er informatie over opvragen, de inhoud van dia's bewerken, nieuwe dia's toevoegen, bestaande dia's verwijderen en meer.

## **Presentaties openen**

Om een bestaande presentatie te openen, instantieer de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse en geef het bestandspad door aan de constructor.

Het volgende C#‑voorbeeld laat zien hoe u een presentatie opent en het aantal dia's opvraagt:

```cs
// Maak een instantie van de Presentation‑klasse en geef een bestandspad door aan de constructor.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Print het totale aantal dia's in de presentatie.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **Wachtwoord‑beveiligde presentaties openen**

Wanneer u een wachtwoord‑beveiligde presentatie moet openen, geef dan het wachtwoord door via de [Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/) eigenschap van de [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/) klasse om deze te ontsleutelen en te laden. De volgende C#‑code demonstreert deze bewerking:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Voer bewerkingen uit op de gedecrypteerde presentatie.
}
```

## **Grote presentaties openen**

Aspose.Slides biedt opties—met name de [BlobManagementOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/blobmanagementoptions/) eigenschap in de [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/) klasse—om u te helpen grote presentaties te laden.

De volgende C#‑code toont het laden van een grote presentatie (bijvoorbeeld 2 GB):

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Kies het KeepLocked‑gedrag – het presentiebestand blijft vergrendeld gedurende de levensduur van 
        // de Presentation‑instantie, maar hoeft niet in het geheugen geladen te worden of gekopieerd naar een tijdelijk bestand.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // De grote presentatie is geladen en kan gebruikt worden, terwijl het geheugenverbruik laag blijft.

    // Breng wijzigingen aan in de presentatie.
    presentation.Slides[0].Name = "Large presentation";

    // Sla de presentatie op naar een ander bestand. Het geheugenverbruik blijft laag tijdens deze bewerking.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Doe dit niet! Er wordt een I/O‑exceptie gegooid omdat het bestand vergrendeld blijft tot het presentatie‑object wordt vrijgegeven.
    File.Delete(filePath);
}

// Het is hier wel toegestaan. Het bronbestand is niet meer vergrendeld door het presentatie‑object.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Om bepaalde beperkingen bij het werken met streams te omzeilen, kan Aspose.Slides de inhoud van een stream kopiëren. Het laden van een grote presentatie vanuit een stream veroorzaakt dat de presentatie gekopieerd wordt en kan het laden vertragen. Daarom raden wij sterk aan om bij het laden van een grote presentatie het pad naar het presentatiebestand te gebruiken in plaats van een stream.

Wanneer u een presentatie maakt die grote objecten bevat (video, audio, afbeeldingen met hoge resolutie, enz.), kunt u [BLOB management](/slides/nl/net/manage-blob/) gebruiken om het geheugenverbruik te verminderen.
{{%/alert %}}

## **Externe bronnen beheren**

Aspose.Slides biedt de [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/iresourceloadingcallback/) interface waarmee u externe bronnen kunt beheren. De volgende C#‑code laat zien hoe u de `IResourceLoadingCallback`‑interface gebruikt:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Laad een vervangende afbeelding.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Stel een vervangende URL in.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Sla alle andere afbeeldingen over.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Presentaties laden zonder ingebedde binaire objecten**

Een PowerPoint‑presentatie kan de volgende soorten ingebedde binaire objecten bevatten:

- VBA‑project (benaderbaar via [IPresentation.VbaProject](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/vbaproject/));
- OLE‑object ingebedde gegevens (benaderbaar via [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- ActiveX‑besturingselement binaire gegevens (benaderbaar via [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/nl/net/aspose.slides/icontrol/activexcontrolbinary/)).

Met behulp van de [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) eigenschap kunt u een presentatie laden zonder enige ingebedde binaire objecten.

Deze eigenschap is nuttig om mogelijk kwaadaardige binaire inhoud te verwijderen. De volgende C#‑code laat zien hoe u een presentatie laadt zonder enige ingebedde binaire inhoud:

```cs
LoadOptions loadOptions = new LoadOptions()
{
    DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Voer bewerkingen uit op de presentatie.
}
```

## **FAQ**

**Hoe kan ik zien dat een bestand corrupt is en niet geopend kan worden?**

U krijgt een parsing‑/formatvalidatie‑exception tijdens het laden. Dergelijke fouten vermelden vaak een ongeldige ZIP‑structuur of beschadigde PowerPoint‑records.

**Wat gebeurt er als vereiste lettertypen ontbreken bij het openen?**

Het bestand wordt geopend, maar later kan [rendering/export](/slides/nl/net/convert-presentation/) lettertypen vervangen. [Configureer lettertype‑substituties](/slides/nl/net/font-substitution/) of [voeg de vereiste lettertypen toe](/slides/nl/net/custom-font/) aan de runtime‑omgeving.

**Wat gebeurt er met ingebedde media (video/audio) bij het openen?**

Ze worden beschikbaar als presentatieressources. Als media via externe paden worden verwezen, zorg dan dat die paden toegankelijk zijn in uw omgeving; anders kan [rendering/export](/slides/nl/net/convert-presentation/) de media weglaten.