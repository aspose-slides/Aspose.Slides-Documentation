---
title: Öppna presentationer på Android
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/androidjava/open-presentation/
keywords:
- öppna PowerPoint
- öppna presentation
- öppna PPTX
- öppna PPT
- öppna ODP
- ladda presentation
- ladda PPTX
- ladda PPT
- ladda ODP
- skyddad presentation
- stor presentation
- extern resurs
- binärt objekt
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du öppnar PowerPoint- och OpenDocument-presentationer på Android, anger öppningslösenord, styr resurshantering och minskar minnesanvändning med Aspose.Slides för Android via Java."
---
## **Introduktion**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/sv/androidjava/) kan läsa PowerPoint- och OpenDocument‑presentationer från filer och strömmar. När en presentation har lästs kan du undersöka dess struktur, redigera bilder, hantera resurser och spara den i originalformatet eller ett annat stödd format.

Inläsningsbeteendet kan anpassas via klassen [LoadOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/). Du kan till exempel ange ett öppningslösenord, hålla stora binära objekt utanför Java‑heap‑minnet, styra externa resurser eller utelämna inbäddade binära data.

## **Öppna presentationer**

Efter att en fil eller ström har lästs kan du [bestämma dess ursprungliga presentationsformat](/slides/sv/androidjava/detect-presentation-source-format/) för att välja hur din applikation ska behandla den.

För att öppna en befintlig presentation, skicka dess filsökväg till konstruktorn för [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/). Avsluta presentationen när du är klar så att filhandtag, temporära data och andra resurser frigörs omedelbart.

Följande Java‑exempel visar hur du öppnar en presentation och får antalet bilder:

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

Ett öppningslösenord krypterar presentationsinnehållet. För att läsa in hela presentationen, skicka rätt lösenord till [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) och ange alternativet till [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-konstruktorn. Inläsning misslyckas när lösenordet saknas eller är felaktigt.

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

För lösenordsdetektering, validering och krypteringsarbetsflöden, se [Password-Protect Presentations](/slides/sv/androidjava/password-protected-presentation/). Om en krypterad presentation avsiktligt sparats med offentliga dokumentegenskaper kan dessa läsas utan lösenord; se [Manage Presentation Properties](/slides/sv/androidjava/presentation-properties/).

## **Öppna stora presentationer**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) returnerar alternativ som styr hur Aspose.Slides hanterar stora binära objekt som bilder, ljud och video. Du kan hålla källfilen låst, tillåta temporära filer och begränsa mängden BLOB‑data som behålls i minnet.

Följande Java‑kod demonstrerar inläsning av en stor presentation (t.ex. 2 GB):

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
Med [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked) förblir källfilen låst tills presentation‑instansen avslutas. Flytta, skriv över eller radera inte källfilen medan instansen är aktiv.

Aspose.Slides kan kopiera innehållet i en indataström under inläsning. För stora presentationer är en filsökväg därför i allmänhet mer effektiv än en ström. Se [Manage BLOBs](/slides/sv/androidjava/manage-blob/) för ytterligare lagrings‑ och minneshanteringsalternativ.
{{% /alert %}}

## **Styr externa resurser**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) accepterar en implementation av [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iresourceloadingcallback/). Återanropet kan tillhandahålla ersättningsdata, omdirigera en resurs, använda standardladdaren eller hoppa över resursen. Detta är användbart när presentationer innehåller externa bilder som måste lösas enligt applikationsspecifika säkerhets‑ eller lagringsregler.

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

## **Läs in presentationer utan inbäddade binära objekt**

En presentation kan innehålla inbäddade binära data som en applikation varken behöver eller vill behålla. Exempel inkluderar:

- VBA‑projekt, tillgängliga via [IPresentation.getVbaProject](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- inbäddad OLE‑data, tillgänglig via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- ActiveX‑kontrolldata, tillgängliga via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Ange [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) till `true` för att ta bort dessa binära data under inläsning. Spara den inlästa presentationen för att bevara det sanerade resultatet.

Detta alternativ minskar exponeringen för oönskade inbäddade payloads, men det är ingen komplett malware‑detekterings‑ eller innehållssaneringslösning.

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

**Hur kan jag avgöra att en fil är korrupt och inte kan öppnas?**

Aspose.Slides kastar ett pars‑ eller format‑undantag under inläsning. Hantera detta fel separat från ett fel för felaktigt lösenord så att applikationen kan rapportera orsaken korrekt.

**Vad händer om nödvändiga teckensnitt saknas?**

Presentation kan fortfarande läsas, men rendering och export kan ersätta teckensnitt. Du kan [konfigurera teckensnittsersättning](/slides/sv/androidjava/font-substitution/) eller [tillhandahålla egna teckensnitt](/slides/sv/androidjava/custom-font/) för att göra utdata mer förutsägbar.

**Laddas inbäddade media när en presentation läses in?**

Inbäddat ljud och video blir tillgängligt via presentationsobjektmodellen. Externa resurser löses enligt den konfigurerade resurshanteringen och kan vara otillgängliga om deras platser inte kan nås.