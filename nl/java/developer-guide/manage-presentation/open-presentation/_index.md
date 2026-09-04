---
title: Open presentaties in Java
linktitle: Open presentatie
type: docs
weight: 20
url: /nl/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument‑presentaties in Java kunt openen, openingswachtwoorden kunt opgeven, het laden van resources kunt beheren en het geheugenverbruik kunt verminderen met Aspose.Slides voor Java."
---
## **Inleiding**

[Aspose.Slides for Java](https://products.aspose.com/slides/nl/java/) kan PowerPoint‑ en OpenDocument‑presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kunt u de structuur inspecteren, dia's bewerken, bronnen beheren en deze opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan worden aangepast via de [LoadOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/)‑klasse. U kunt bijvoorbeeld een openingswachtwoord opgeven, grote binaire objecten buiten het Java‑heap‑geheugen houden, externe bronnen beheren of ingesloten binaire gegevens weglaten.

## **Open presentaties**

Om een bestaande presentatie te openen, geeft u het bestandspad door aan de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑constructor. Maak de presentatie vrij nadat u deze hebt gebruikt, zodat bestands‑handles, tijdelijke gegevens en andere bronnen onmiddellijk worden vrijgegeven.

De volgende Java‑voorbeeld laat zien hoe u een presentatie opent en het aantal dia's opvraagt:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Openen van wachtwoordbeveiligde presentaties**

Een openingswachtwoord versleutelt de inhoud van de presentatie. Om de volledige presentatie te laden, geeft u het juiste wachtwoord door aan [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) en voorziet u de opties van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑constructor. Het laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

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

Voor wachtwoorddetectie, -validatie en encryptieworkflows, zie [Wachtwoordbeveiligde presentaties](/slides/nl/java/password-protected-presentation/). Als een versleutelde presentatie bewust is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen zonder wachtwoord worden gelezen; zie [Presentatie‑eigenschappen beheren](/slides/nl/java/presentation-properties/).

## **Grote presentaties openen**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) retourneert opties die bepalen hoe Aspose.Slides binair grote objecten (BLOB‑s) zoals afbeeldingen, audio en video verwerkt. U kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑gegevens die in het geheugen wordt bewaard beperken.

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

{{% alert color="info" title="Opmerking" %}}
Met [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) blijft het bronbestand vergrendeld totdat de presentatie‑instantie wordt vrijgegeven. Verplaats, overschrijf of verwijder het bronbestand niet terwijl die instantie nog bestaat.

Aspose.Slides kan de inhoud van een invoerstroom kopiëren tijdens het laden. Voor grote presentaties is een bestandspad daarom over het algemeen efficiënter dan een stream. Zie [BLOB’s beheren](/slides/nl/java/manage-blob/) voor extra opslag‑ en geheugen‑beheermogelijkheden.
{{% /alert %}}

## **Externe bronnen beheren**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) accepteert een implementatie van [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iresourceloadingcallback/). De callback kan vervangende gegevens leveren, een bron omleiden, de standaardloader gebruiken of de bron overslaan. Dit is nuttig wanneer presentaties externe afbeeldingen bevatten die moeten worden opgezocht volgens toepassingsspecifieke beveiligings‑ of opslagregels.

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

## **Presentaties laden zonder ingesloten binaire objecten**

Een presentatie kan ingesloten binaire gegevens bevatten die een applicatie niet nodig heeft of niet wil behouden. Voorbeelden zijn:

- VBA‑projecten, beschikbaar via [IPresentation.getVbaProject](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getVbaProject--);
- ingesloten OLE‑gegevens, beschikbaar via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- ActiveX‑controlegegevens, beschikbaar via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Stel [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) in op `true` om deze binaire gegevens bij het laden te verwijderen. Sla de geladen presentatie op om het gesaniteerde resultaat te behouden.

Deze optie vermindert de blootstelling aan ongewenste ingesloten payloads, maar het is geen volledige malware‑detectie‑ of inhoud‑sanitiseringsmodule.

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

Aspose.Slides werpt tijdens het laden een parse‑ of formaat‑exception. Verwerk die fout apart van een foutmelding voor een onjuist wachtwoord, zodat de applicatie de oorzaak nauwkeurig kan rapporteren.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds worden geladen, maar weergave en export kunnen lettertypen substitueren. U kunt [lettertype‑substitutie configureren](/slides/nl/java/font-substitution/) of [aangepaste lettertypen bieden](/slides/nl/java/custom-font/) om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingesloten media?**

Ingesloten audio en video worden beschikbaar via het presentatie‑objectmodel. Externe bronnen worden opgezocht volgens het geconfigureerde gedrag voor resource‑laden en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.