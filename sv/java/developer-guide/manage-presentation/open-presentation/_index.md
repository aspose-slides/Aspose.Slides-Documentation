---
title: Öppna presentationer i Java
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/java/open-presentation/
keywords:
- öppna PowerPoint
- öppna presentation
- öppna PPTX
- öppna PPT
- öppna ODP
- läs in presentation
- läs in PPTX
- läs in PPT
- läs in ODP
- skyddad presentation
- stor presentation
- extern resurs
- binärt objekt
- Java
- Aspose.Slides
description: "Lär dig hur du öppnar PowerPoint- och OpenDocument-presentationer i Java, anger öppningslösenord, styr resurshämtning och minskar minnesanvändning med Aspose.Slides för Java."
---
## **Introduktion**

[Aspose.Slides for Java](https://products.aspose.com/slides/sv/java/) kan läsa in PowerPoint- och OpenDocument-presentationer från filer och strömmar. Efter att en presentation har lästs in kan du inspektera dess struktur, redigera bilder, hantera resurser och spara den i originalformatet eller ett annat stödd format.

Inläsningsbeteendet kan anpassas via klassen [LoadOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/). Till exempel kan du ange ett öppningslösenord, hålla stora binära objekt utanför Java-heapminnet, kontrollera externa resurser eller utesluta inbäddade binära data.

## **Öppna presentationer**

Efter att ha läst in en fil eller ström kan du [fastställa dess ursprungliga presentationsformat](/slides/sv/java/detect-presentation-source-format/) för att välja hur din applikation behandlar den.

För att öppna en befintlig presentation, skicka dess filsökväg till konstruktorn för [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/). Disposera presentationen efter användning så att filhandtag, temporära data och andra resurser frigörs omedelbart.

Följande Java‑exempel visar hur man öppnar en presentation och får antalet bilder:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Öppna lösenordsskyddade presentationer**

Ett öppningslösenord krypterar presentationsinnehållet. För att läsa in hela presentationen, skicka det korrekta lösenordet till [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) och ange alternativen till [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) konstruktorn. Inläsning misslyckas när lösenordet saknas eller är felaktigt.

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

För lösenordsdetektering, validering och krypteringsarbetsflöden, se [Password-Protect Presentations](/slides/sv/java/password-protected-presentation/). Om en krypterad presentation medvetet sparats med offentliga dokumentegenskaper, kan dessa egenskaper läsas utan lösenord; se [Manage Presentation Properties](/slides/sv/java/presentation-properties/).

## **Öppna stora presentationer**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) returnerar alternativ som styr hur Aspose.Slides hanterar stora binära objekt som bilder, ljud och video. Du kan hålla källfilen låst, tillåta temporära filer och begränsa mängden BLOB‑data som behålls i minnet.

Följande Java‑kod visar hur man läser in en stor presentation (t.ex. 2 GB):

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
Med [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) förblir källfilen låst tills presentation‑instansen har disposeras. Flytta, skriv över eller ta inte bort källfilen medan den instansen är aktiv.

Aspose.Slides kan kopiera innehållet i en inmatningsström under inläsning. För stora presentationer är en filsökväg därför vanligtvis mer effektiv än en ström. Se [Manage BLOBs](/slides/sv/java/manage-blob/) för ytterligare alternativ för lagring och minneshantering.
{{% /alert %}}

## **Kontrollera externa resurser**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) accepterar en implementation av [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iresourceloadingcallback/). Återanropet kan tillhandahålla ersättningsdata, omdirigera en resurs, använda standardladdaren eller hoppa över resursen. Detta är användbart när presentationer innehåller externa bilder som måste lösas enligt applikationsspecifika säkerhets- eller lagringsregler.

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

## **Ladda presentationer utan inbäddade binära objekt**

En presentation kan innehålla inbäddade binära data som en applikation inte behöver eller inte vill behålla. Exempel inkluderar:

- VBA‑projekt, tillgängliga via [IPresentation.getVbaProject](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentation/#getVbaProject--);
- inbäddad OLE‑data, tillgänglig via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- ActiveX‑kontrolldata, tillgänglig via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Ställ in [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) till `true` för att ta bort dessa binära data under inläsning. Spara den inlästa presentationen för att bevara det sanerade resultatet.

Detta alternativ minskar exponeringen för oönskade inbäddade payloads, men det är inte ett komplett system för malware‑detektering eller innehållssanitering.

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

**Hur kan jag avgöra att en fil är skadad och inte kan öppnas?**

Aspose.Slides kastar ett parsnings‑ eller format‑undantag under inläsning. Hantera det felet separat från ett felaktigt lösenordfel så att applikationen kan rapportera orsaken korrekt.

**Vad händer om nödvändiga typsnitt saknas?**

Presentationen kan fortfarande läsas in, men rendering och export kan ersätta typsnitt. Du kan [configure font substitution](/slides/sv/java/font-substitution/) eller [provide custom fonts](/slides/sv/java/custom-font/) för att göra utdata mer förutsägbar.

**Läser inläsning av en presentation även inbäddade media?**

Inbäddat ljud och video blir tillgängliga via presentationsobjektmodellen. Externa resurser löses upp enligt den konfigurerade resursläsningsbeteendet och kan vara otillgängliga om deras platser inte kan nås.