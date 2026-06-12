---
title: Presentaties openen op Android
linktitle: Presentatie openen
type: docs
weight: 20
url: /nl/androidjava/open-presentation/
keywords:
- PowerPoint openen
- OpenDocument openen
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
- Android
- Java
- Aspose.Slides
description: "Open PowerPoint (.pptx, .ppt) en OpenDocument (.odp) presentaties moeiteloos met Aspose.Slides voor Android via Java — snel, betrouwbaar, volledig uitgerust."
---
## **Inleiding**

Naast het helemaal opnieuw maken van PowerPoint‑presentaties, laat Aspose.Slides u ook bestaande presentaties openen. Nadat u een presentatie geladen hebt, kunt u informatie erover ophalen, de inhoud van dia's bewerken, nieuwe dia's toevoegen, bestaande dia's verwijderen en meer.

## **Open presentaties**

Om een bestaande presentatie te openen, maakt u een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse en geeft u het bestandspad door aan de constructor.

Het volgende Java‑voorbeeld laat zien hoe u een presentatie opent en het aantal dia's opvraagt:

```java
// Instantieer de Presentation-klasse en geef een bestandspad door aan de constructor.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Print het totale aantal dia's in de presentatie.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Openen van met wachtwoord beveiligde presentaties**

Wanneer u een met wachtwoord beveiligde presentatie moet openen, geeft u het wachtwoord door aan de [setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)‑methode van de [LoadOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/)‑klasse om deze te ontsleutelen en te laden. Het volgende Java‑codefragment toont deze bewerking:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Voer bewerkingen uit op de gedecodeerde presentatie.
} finally {
    presentation.dispose();
}
```

## **Openen van grote presentaties**

Aspose.Slides biedt opties—met name de [getBlobManagementOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--)‑methode in de [LoadOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/)‑klasse—om u te helpen grote presentaties te laden.

Het volgende Java‑codefragment toont het laden van een grote presentatie (bijvoorbeeld 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Kies het KeepLocked-gedrag—het presentiebestand blijft vergrendeld gedurende de levensduur van
// de Presentation-instantie, maar hoeft niet in het geheugen te worden geladen of naar een tijdelijk bestand gekopieerd.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // De grote presentatie is geladen en kan worden gebruikt, terwijl het geheugenverbruik laag blijft.

    // Breng wijzigingen aan in de presentatie.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Sla de presentatie op in een ander bestand. Het geheugenverbruik blijft laag tijdens deze bewerking.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Doe dit niet! Er wordt een I/O‑exception gegooid omdat het bestand vergrendeld blijft tot het presentatiedobject wordt vrijgegeven.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Het is hier OK om het te doen. Het bronbestand is niet langer vergrendeld door het presentatiedobject.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Om bepaalde beperkingen bij het werken met streams te omzeilen, kan Aspose.Slides de inhoud van een stream kopiëren. Het laden van een grote presentatie vanuit een stream zorgt ervoor dat de presentatie gekopieerd wordt, wat het laden kan vertragen. Daarom raden we ten zeerste aan om, wanneer u een grote presentatie moet laden, het bestandspad van de presentatie te gebruiken in plaats van een stream.

Bij het maken van een presentatie die grote objecten bevat (video, audio, afbeeldingen met hoge resolutie, enz.), kunt u [BLOB management](/slides/nl/androidjava/manage-blob/) gebruiken om het geheugenverbruik te verminderen.
{{%/alert %}}

## **Beheer van externe bronnen**

Aspose.Slides biedt de [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iresourceloadingcallback/)‑interface waarmee u externe bronnen kunt beheren. Het volgende Java‑codefragment laat zien hoe u de `IResourceLoadingCallback`‑interface gebruikt:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Laad een vervangende afbeelding.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Gebruik een willekeurige methode om de bytes te verkrijgen
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Stel een vervangende URL in.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Sla alle andere afbeeldingen over.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Presentaties laden zonder ingebedde binaire objecten**

Een PowerPoint‑presentatie kan de volgende typen ingebedde binaire objecten bevatten:

- VBA‑project (toegankelijk via [IPresentation.getVbaProject](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- OLE‑object ingebedde data (toegankelijk via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX‑besturings‑element binaire data (toegankelijk via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Met de [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)‑methode kunt u een presentatie laden zonder enige ingebedde binaire objecten.

Deze methode is nuttig om potentieel kwaadaardige binaire inhoud te verwijderen. Het volgende Java‑codefragment laat zien hoe u een presentatie laadt zonder enige ingebedde binaire inhoud:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Voer bewerkingen uit op de presentatie.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Hoe kan ik zien dat een bestand corrupt is en niet geopend kan worden?**

U krijgt tijdens het laden een parse‑/formaatvalidatie‑exceptie. Dergelijke fouten vermelden vaak een ongeldige ZIP‑structuur of beschadigde PowerPoint‑records.

**Wat gebeurt er als vereiste lettertypen ontbreken bij het openen?**

Het bestand wordt geopend, maar later kan bij [renderen/exporteren](/slides/nl/androidjava/convert-presentation/) een substitutie van lettertypen plaatsvinden. [Configureer lettertype‑substituties](/slides/nl/androidjava/font-substitution/) of [voeg de vereiste lettertypen toe](/slides/nl/androidjava/custom-font/) aan de runtime‑omgeving.

**Hoe zit het met ingebedde media (video/audio) bij het openen?**

Ze worden beschikbaar als presentatieresources. Als media via externe paden worden gerefereerd, zorg er dan voor dat die paden toegankelijk zijn in uw omgeving; anders kan bij [renderen/exporteren](/slides/nl/androidjava/convert-presentation/) de media worden weggelaten.