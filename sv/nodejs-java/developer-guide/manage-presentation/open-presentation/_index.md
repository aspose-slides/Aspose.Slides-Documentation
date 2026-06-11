---
title: Öppna presentationer i JavaScript
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/nodejs-java/open-presentation/
keywords:
- öppna PowerPoint
- öppna OpenDocument
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
description: "Öppna PowerPoint (.pptx, .ppt) och OpenDocument (.odp) presentationer enkelt med Aspose.Slides för Node.js via Java—snabbt, pålitligt och fullt utrustat."
---
## **Introduktion**

Förutom att skapa PowerPoint-presentationer från grunden låter Aspose.Slides dig också öppna befintliga presentationer. Efter att ha laddat en presentation kan du hämta information om den, redigera bildinnehåll, lägga till nya bilder, ta bort befintliga och mer.

## **Öppna presentationer**

För att öppna en befintlig presentation, skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och skicka filens sökväg till dess konstruktor.

Följande JavaScript‑exempel visar hur man öppnar en presentation och får antalet bilder:

```js
// Skapa en instans av Presentation-klassen och skicka en filsökväg till dess konstruktor.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Skriv ut det totala antalet bilder i presentationen.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Öppna lösenordsskyddade presentationer**

När du behöver öppna en lösenordsskyddad presentation, skicka lösenordet via metoden [setPassword](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setPassword) i klassen [LoadOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/) för att dekryptera och ladda den. Följande JavaScript‑kod demonstrerar denna operation:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Utför operationer på den dekrypterade presentationen.
} finally {
    presentation.dispose();
}
```

## **Öppna stora presentationer**

Aspose.Slides tillhandahåller alternativ—särskilt metoden [getBlobManagementOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) i klassen [LoadOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/)—för att hjälpa dig ladda stora presentationer.

Följande JavaScript‑kod demonstrerar hur man laddar en stor presentation (till exempel 2 GB):

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Välj KeepLocked‑beteendet—presentationsfilen förblir låst under hela livslängden för
// Presentation‑instansen, men den behöver inte laddas in i minnet eller kopieras till en tillfällig fil.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // Den stora presentationen har laddats och kan användas, medan minnesanvändningen förblir låg.
    
    // Gör ändringar i presentationen.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Spara presentationen till en annan fil. Minnesanvändningen förblir låg under denna operation.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Gör inte detta! Ett I/O‑undantag kommer att kastas eftersom filen är låst tills presentationsobjektet har avyttrats.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Det är OK att göra det här. Källfilen är inte längre låst av presentationsobjektet.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
För att kringgå vissa begränsningar när du arbetar med strömmar kan Aspose.Slides kopiera en ströms innehåll. Att ladda en stor presentation från en ström gör att presentationen kopieras och kan sakta ner inläsningen. Därför rekommenderar vi starkt att du använder presentationsfilens sökväg istället för en ström när du behöver ladda en stor presentation.

När du skapar en presentation som innehåller stora objekt (video, ljud, högupplösta bilder osv.) kan du använda [BLOB management](/slides/sv/nodejs-java/manage-blob/) för att minska minnesförbrukningen.
{{%/alert %}}

## **Styr externa resurser**

Aspose.Slides tillhandahåller gränssnittet [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iresourceloadingcallback/) som låter dig hantera externa resurser. Följande JavaScript‑kod visar hur man använder `IResourceLoadingCallback`‑gränssnittet:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Ladda en ersättningsbild.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Ange en ersättnings-URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Hoppa över alla andra bilder.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **Ladda presentationer utan inbäddade binära objekt**

En PowerPoint-presentation kan innehålla följande typer av inbäddade binära objekt:

- VBA‑projekt (åtkomligt via [Presentation.getVbaProject](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getVbaProject));
- OLE‑objekt inbäddad data (åtkomligt via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- ActiveX‑kontroll binär data (åtkomligt via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

Genom att använda metoden [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) kan du ladda en presentation utan några inbäddade binära objekt.

Denna metod är användbar för att ta bort potentiellt skadligt binärt innehåll. Följande JavaScript‑kod demonstrerar hur man laddar en presentation utan inbäddat binärt innehåll:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Utför operationer på presentationen.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Hur kan jag avgöra att en fil är korrupt och inte kan öppnas?**

Du får ett parsning-/formatvalideringsundantag under inläsning. Sådana fel nämner ofta en ogiltig ZIP‑struktur eller trasiga PowerPoint‑poster.

**Vad händer om nödvändiga teckensnitt saknas vid öppning?**

Filen öppnas, men senare [rendering/export](/slides/sv/nodejs-java/convert-presentation/) kan ersätta teckensnitten. [Configure font substitutions](/slides/sv/nodejs-java/font-substitution/) eller [add the required fonts](/slides/sv/nodejs-java/custom-font/) till körmiljön.

**Vad händer med inbäddade media (video/ljud) vid öppning?**

De blir tillgängliga som presentationsresurser. Om media refereras via externa sökvägar, se till att dessa sökvägar är tillgängliga i din miljö; annars kan [rendering/export](/slides/sv/nodejs-java/convert-presentation/) utelämna media.