---
title: Open Presentaties op Android
linktitle: Open Presentatie
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
- binair object
- Android
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint‑ en OpenDocument‑presentaties op Android kunt openen, openingswachtwoorden kunt opgeven, het laden van bronnen kunt beheersen en het geheugengebruik kunt verminderen met Aspose.Slides voor Android via Java."
---
## **Inleiding**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/nl/androidjava/) kan PowerPoint‑ en OpenDocument‑presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kunt u de structuur onderzoeken, dia’s bewerken, bronnen beheren en deze opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan worden aangepast via de class LoadOptions. U kunt bijvoorbeeld een openingswachtwoord opgeven, grote binaire objecten buiten het Java‑heapgeheugen houden, externe bronnen beheersen of ingebedde binaire gegevens weglaten.

## **Presentaties openen**

Om een bestaande presentatie te openen, geeft u het bestandspad door aan de constructor van Presentation. Maak de presentatie vrij (dispose) na gebruik zodat bestands‑handles, tijdelijke gegevens en andere bronnen onmiddellijk worden vrijgegeven.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Wachtwoordbeveiligde presentaties openen**

Een openingswachtwoord versleutelt de inhoud van de presentatie. Om de volledige presentatie te laden, geeft u het correcte wachtwoord door aan LoadOptions.setPassword en levert u de opties aan de Presentation‑constructor. Het laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

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

Voor wachtwoorddetectie, validatie en versleutelingsworkflows, zie [Wachtwoord‑beveiligde presentaties](/slides/nl/androidjava/password-protected-presentation/). Als een versleutelde presentatie opzettelijk is opgeslagen met publieke documenteigenschappen, kunnen die eigenschappen worden gelezen zonder wachtwoord; zie [Beheer presentatie‑eigenschappen](/slides/nl/androidjava/presentation-properties/).

## **Grote presentaties openen**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) retourneert opties die bepalen hoe Aspose.Slides binaire grote objecten (BLOB’s) zoals afbeeldingen, audio en video verwerkt. U kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑gegevens die in het geheugen worden bewaard beperken.

De volgende Java‑code toont het laden van een grote presentatie (bijvoorbeeld 2 GB):

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

Met PresentationLockingBehavior.KeepLocked blijft het bronbestand vergrendeld tot de presentatie‑instantie wordt vrijgegeven. Verplaats, overschrijf of verwijder het bronbestand niet zolang die instantie leeft.

Aspose.Slides kan de inhoud van een invoerstroom kopiëren tijdens het laden. Voor grote presentaties is een bestandspad doorgaans efficiënter dan een stroom. Zie [BLOB‑beheer](/slides/nl/androidjava/manage-blob/) voor extra opslag‑ en geheugemanagementopties.

{{% /alert %}}

## **Externe bronnen beheren**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) accepteert een [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iresourceloadingcallback/) implementatie. De callback kan vervangende gegevens leveren, een bron omleiden, de standaardloader gebruiken of de bron overslaan. Dit is nuttig wanneer presentaties externe afbeeldingen bevatten die moeten worden opgelost volgens toepassingsspecifieke beveiligings‑ of opslagregels.

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

Stel LoadOptions.setDeleteEmbeddedBinaryObjects in op `true` om deze binaire gegevens tijdens het laden te verwijderen. Sla de geladen presentatie op om het opgeschoonde resultaat te behouden.

Deze optie vermindert de blootstelling aan ongewenste ingebedde payloads, maar is geen volledig systeem voor malware‑detectie of inhouds‑sanitization.

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

**Hoe kan ik zien dat een bestand corrupt is en niet geopend kan worden?**

Aspose.Slides geeft een parse‑ of format‑exception tijdens het laden. Handhaaf die fout afzonderlijk van een onjuist‑wachtwoord‑fout zodat de applicatie de oorzaak nauwkeurig kan rapporteren.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds worden geladen, maar weergave en export kunnen lettertypen vervangen. U kunt [lettertype‑substitutie configureren](/slides/nl/androidjava/font-substitution/) of [aangepaste lettertypen leveren](/slides/nl/androidjava/custom-font/) om de uitvoer voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio en video worden beschikbaar via het presentatiemodel. Externe bronnen worden opgelost volgens het geconfigureerde resource‑loading‑gedrag en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.