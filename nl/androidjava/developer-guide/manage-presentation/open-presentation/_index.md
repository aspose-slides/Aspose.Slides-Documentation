---
title: Presentaties openen op Android
linktitle: Presentatie openen
type: docs
weight: 20
url: /nl/androidjava/open-presentation/
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
- binaire object
- Android
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint‑ en OpenDocument‑presentaties kunt openen op Android, openings‑wachtwoorden kunt opgeven, het laden van resources kunt beheren en het geheugenverbruik kunt verminderen met Aspose.Slides voor Android via Java."
---
## **Inleiding**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/nl/androidjava/) kan PowerPoint- en OpenDocument‑presentaties laden vanaf bestanden en streams. Nadat een presentatie is geladen, kun je de structuur inspecteren, dia's bewerken, resources beheren en deze opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan worden aangepast via de LoadOptions‑klasse. Je kunt bijvoorbeeld een openings‑wachtwoord opgeven, grote binaire objecten buiten het Java‑heapgeheugen houden, externe resources beheren of ingebedde binaire gegevens weglaten.

## **Presentaties openen**

Na het laden van een bestand of stream kun je het oorspronkelijke presentatieformaat bepalen om te kiezen hoe je applicatie het verwerkt.

Om een bestaande presentatie te openen, geef je het bestandspad door aan de Presentation‑constructor. Maak de presentatie schoon (dispose) na gebruik zodat bestands‑handles, tijdelijke gegevens en andere resources direct worden vrijgegeven.

Het volgende Java‑voorbeeld toont hoe je een presentatie opent en het aantal dia's ophaalt:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Wachtwoord‑beveiligde presentaties openen**

Een openings‑wachtwoord versleutelt de inhoud van de presentatie. Om de volledige presentatie te laden, geef je het juiste wachtwoord door aan LoadOptions.setPassword en lever je de opties aan de Presentation‑constructor. Laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Voor wachtwoorddetectie, -validatie en versleutelings‑workflows, zie [Password-Protect Presentations](/slides/nl/androidjava/password-protected-presentation/). Als een versleutelde presentatie opzettelijk is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen worden gelezen zonder wachtwoord; zie [Manage Presentation Properties](/slides/nl/androidjava/presentation-properties/).

## **Grote presentaties openen**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) retourneert opties die bepalen hoe Aspose.Slides omgaat met binaire grote objecten (BLOB's) zoals afbeeldingen, audio en video. Je kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑gegevens die in het geheugen wordt bewaard beperken.

De volgende Java‑code demonstreert het laden van een grote presentatie (bijvoorbeeld 2 GB):

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Met PresentationLockingBehavior.KeepLocked blijft het bronbestand vergrendeld totdat de presentatie‑instantie wordt opgeschoond. Verplaats, overschrijf of verwijder het bronbestand niet zolang die instantie actief is.

Aspose.Slides kan de inhoud van een invoer‑stream kopiëren tijdens het laden. Voor grote presentaties is een bestandspad doorgaans efficiënter dan een stream. Zie [Manage BLOBs](/slides/nl/androidjava/manage-blob/) voor extra opslag‑ en geheugen‑beheeropties.
{{% /alert %}}

## **Externe resources beheren**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) accepteert een IResourceLoadingCallback‑implementatie. De callback kan vervangende gegevens leveren, een resource omleiden, de standaardloader gebruiken of de resource overslaan. Dit is nuttig wanneer presentaties externe afbeeldingen bevatten die volgens toepassingsspecifieke beveiligings‑ of opslagregels moeten worden opgelost.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Presentaties laden zonder ingebedde binaire objecten**

Een presentatie kan ingebedde binaire gegevens bevatten die een applicatie niet nodig heeft of niet wil behouden. Voorbeelden zijn:

- VBA‑projecten, beschikbaar via IPresentation.getVbaProject;
- ingebedde OLE‑gegevens, beschikbaar via IOleEmbeddedDataInfo.getEmbeddedFileData;
- ActiveX‑controlegegevens, beschikbaar via IControl.getActiveXControlBinary.

Stel LoadOptions.setDeleteEmbeddedBinaryObjects in op `true` om deze binaire gegevens bij het laden te verwijderen. Sla de geladen presentatie op om het gesanitiseerde resultaat te behouden.

Deze optie vermindert de blootstelling aan ongewenste ingebedde payloads, maar is geen volledige malware‑detectie‑ of inhoud‑sanitiseringsoplossing.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Hoe kan ik zien dat een bestand beschadigd is en niet geopend kan worden?**

Aspose.Slides gooit tijdens het laden een parse‑ of format‑exception. Verwerk die fout apart van een fout bij een onjuist wachtwoord, zodat de applicatie de oorzaak nauwkeurig kan melden.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds worden geladen, maar weergave en export kunnen lettertypen vervangen. Je kunt lettertype‑vervanging configureren of aangepaste lettertypen leveren om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio en video worden beschikbaar via het presentatie‑objectmodel. Externe resources worden opgelost volgens het geconfigureerde resource‑laadgedrag en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.