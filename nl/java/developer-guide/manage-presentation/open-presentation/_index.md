---
title: Open presentaties in Java
linktitle: Open presentatie
type: docs
weight: 20
url: /nl/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Open PowerPoint (.pptx, .ppt) en OpenDocument (.odp) presentaties moeiteloos met Aspose.Slides voor Java: snel, betrouwbaar en volledig uitgerust."
---
## **Introductie**

Naast het maken van PowerPoint‑presentaties vanaf nul, maakt Aspose.Slides het ook mogelijk om bestaande presentaties te openen. Nadat een presentatie is geladen, kun je informatie erover ophalen, de inhoud van dia's bewerken, nieuwe dia's toevoegen, bestaande dia's verwijderen en meer.

## **Presentaties openen**

Om een bestaande presentatie te openen, maak je een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse en geef je het bestandspad door aan de constructor.

Het volgende Java‑voorbeeld laat zien hoe je een presentatie opent en het aantal dia's opvraagt:

```java
// Instantieer de Presentation‑klasse en geef een bestandspad door aan de constructor.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Print het totale aantal dia's in de presentatie.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Wachtwoordbeveiligde presentaties openen**

Wanneer je een wachtwoordbeveiligde presentatie moet openen, geef je het wachtwoord door aan de [setPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)‑methode van de [LoadOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/)‑klasse om deze te ontsleutelen en te laden. De volgende Java‑code demonstreert deze bewerking:

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

## **Grote presentaties openen**

Aspose.Slides biedt opties—met name de [getBlobManagementOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--)‑methode in de [LoadOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/)‑klasse om je te helpen grote presentaties te laden.

De volgende Java‑code toont het laden van een grote presentatie (bijvoorbeeld 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Kies het KeepLocked‑gedrag — het presentatiebestand blijft vergrendeld gedurende de levensduur van
// de Presentation‑instantie, maar hoeft niet in het geheugen te worden geladen of naar een tijdelijk bestand gekopieerd.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // De grote presentatie is geladen en kan worden gebruikt, terwijl het geheugenverbruik laag blijft.

    // Breng wijzigingen aan in de presentatie.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Sla de presentatie op naar een ander bestand. Het geheugenverbruik blijft laag tijdens deze bewerking.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Doe dit niet! Er wordt een I/O‑exceptie gegooid omdat het bestand vergrendeld blijft tot het presentatiedobject wordt vrijgegeven.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Het is hier wel oké. Het bronbestand is niet langer vergrendeld door het presentatiedobject.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Om bepaalde beperkingen bij het werken met streams te omzeilen, kan Aspose.Slides de inhoud van een stream kopiëren. Het laden van een grote presentatie vanuit een stream zorgt ervoor dat de presentatie wordt gekopieerd, wat het laden kan vertragen. Daarom raden we sterk aan om, wanneer je een grote presentatie moet laden, het bestandspad van de presentatie te gebruiken in plaats van een stream.

Bij het maken van een presentatie die grote objecten bevat (video, audio, afbeeldingen met hoge resolutie, enz.), kun je [BLOB management](/slides/nl/java/manage-blob/) gebruiken om het geheugenverbruik te verminderen.
{{%/alert %}} 

## **Externe bronnen beheren**

Aspose.Slides biedt de [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iresourceloadingcallback/) interface die je in staat stelt externe bronnen te beheren. De volgende Java‑code laat zien hoe je de `IResourceLoadingCallback`‑interface gebruikt:

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
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
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

- VBA‑project (toegankelijk via [IPresentation.getVbaProject](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getVbaProject--));
- Embedded OLE‑objectgegevens (toegankelijk via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Binaire gegevens van ActiveX‑besturingselement (toegankelijk via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Met behulp van de [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)‑methode kun je een presentatie laden zonder enige ingebedde binaire objecten.

Deze methode is nuttig om potentieel kwaadaardige binaire inhoud te verwijderen. De volgende Java‑code demonstreert hoe je een presentatie laadt zonder enige ingebedde binaire inhoud:

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

**Hoe kan ik zien dat een bestand beschadigd is en niet geopend kan worden?**

Je krijgt tijdens het laden een parsing-/formaatvalidatie-exceptie. Dergelijke fouten vermelden vaak een ongeldige ZIP-structuur of beschadigde PowerPoint-records.

**Wat gebeurt er als de vereiste lettertypen ontbreken bij het openen?**

Het bestand wordt geopend, maar later kan [rendering/export](/slides/nl/java/convert-presentation/) lettertypen vervangen. [Configure font substitutions](/slides/nl/java/font-substitution/) of [add the required fonts](/slides/nl/java/custom-font/) aan de runtime-omgeving.

**Hoe zit het met ingebedde media (video/audio) bij het openen?**

Ze worden beschikbaar als presentatieresources. Als media via externe paden worden aangesproken, zorg er dan voor dat die paden toegankelijk zijn in je omgeving; anders kan [rendering/export](/slides/nl/java/convert-presentation/) de media weglaten.