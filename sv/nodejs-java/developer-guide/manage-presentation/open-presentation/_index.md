---
title: Öppna presentationer i JavaScript
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du öppnar PowerPoint- och OpenDocument-presentationer i JavaScript, anger öppningslösenord, styr resurshämtning och minskar minnesanvändning med Aspose.Slides för Node.js via Java."
---
## **Introduktion**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/sv/nodejs-java/) kan läsa PowerPoint- och OpenDocument-presentationer från filer och strömmar. När en presentation har lästs in kan du undersöka dess struktur, redigera bilder, hantera resurser och spara den i originalformatet eller ett annat stödt format.

Inläsningsbeteendet kan anpassas via klassen [LoadOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/). Till exempel kan du ange ett öppningslösenord, hålla stora binära objekt utanför Node.js-minnet, kontrollera externa resurser eller utesluta inbäddade binära data.

## **Öppna presentationer**

För att öppna en befintlig presentation, skicka dess filsökväg till [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)-konstruktorn. Disposera presentationen efter användning så att filhandtag, temporära data och andra resurser frigörs snabbt.

Följande JavaScript‑exempel visar hur du öppnar en presentation och får antalet bilder:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Öppna lösenordsskyddade presentationer**

Ett öppningslösenord krypterar presentationsinnehållet. För att läsa in hela presentationen, skicka rätt lösenord till [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setPassword) och tillhandahåll alternativen till [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)-konstruktorn. Inläsningen misslyckas när lösenordet saknas eller är felaktigt.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

För lösenorddetektering, validering och krypteringsarbetsflöden, se [Password‑Protect Presentations](/slides/sv/nodejs-java/password-protected-presentation/). Om en krypterad presentation avsiktligt sparats med offentliga dokumentegenskaper, kan dessa egenskaper läsas utan lösenord; se [Manage Presentation Properties](/slides/sv/nodejs-java/presentation-properties/).

## **Öppna stora presentationer**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) returnerar alternativ som styr hur Aspose.Slides hanterar stora binära objekt såsom bilder, ljud och video. Du kan behålla källfilen låst, tillåta temporära filer och begränsa mängden BLOB‑data som behålls i minnet.

Följande JavaScript‑kod demonstrerar inläsning av en stor presentation (till exempel 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Med [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) förblir källfilen låst tills presentation‑instansen disponeras. Flytta, skriv över eller radera inte källfilen medan den instansen är aktiv.

Aspose.Slides kan kopiera innehållet i en inmatningsström under inläsning. För stora presentationer är en filsökväg därför generellt mer effektiv än en ström. Se [Manage BLOBs](/slides/sv/nodejs-java/manage-blob/) för ytterligare lagrings- och minneshanteringsalternativ.
{{% /alert %}}

## **Kontrollera externa resurser**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepterar en [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iresourceloadingcallback/)-implementation. Återanropet kan tillhandahålla ersättningsdata, omdirigera en resurs, använda standardladdaren eller hoppa över resursen. Detta är användbart när presentationer innehåller externa bilder som måste lösas upp enligt programspecifika säkerhets- eller lagringsregler.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Läs in presentationer utan inbäddade binära objekt**

En presentation kan innehålla inbäddade binära data som en applikation inte behöver eller inte vill behålla. Exempel inkluderar:

- VBA‑projekt, tillgängliga via [Presentation.getVbaProject](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getVbaProject);
- inbäddad OLE‑data, tillgänglig via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX‑kontrolldata, tillgänglig via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Ställ in [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) till `true` för att ta bort dessa binära data vid inläsning. Spara den inlästa presentationen för att behålla det sanerade resultatet.

Detta alternativ minskar exponeringen för oönskade inbäddade belastningar, men det är inte ett fullständigt system för skadlig‑programdetektering eller innehållssanering.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Hur kan jag avgöra att en fil är korrupt och inte kan öppnas?**

Aspose.Slides kastar ett pars‑ eller formatfel under inläsning. Hantera detta fel separat från ett felaktigt lösenord så att applikationen kan rapportera orsaken korrekt.

**Vad händer om nödvändiga teckensnitt saknas?**

Presentationen kan fortfarande läsas in, men rendering och export kan ersätta teckensnitt. Du kan konfigurera teckensnittsersättning eller tillhandahålla egna teckensnitt för att göra utdata mer förutsägbar.

**Läser inläsning av en presentation även inbäddad media?**

Inbäddat ljud och video blir tillgängliga via presentationsobjektmodellen. Externa resurser löses upp enligt den konfigurerade resursladdningsbeteendet och kan vara otillgängliga om deras platser inte kan nås.