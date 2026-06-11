---
title: Öppna presentationer på Android
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/androidjava/open-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Öppna PowerPoint (.pptx, .ppt) och OpenDocument (.odp) presentationer enkelt med Aspose.Slides för Android via Java — snabbt, pålitligt, fullt utrustat."
---
## **Introduktion**

Förutom att skapa PowerPoint-presentationer från grunden låter Aspose.Slides dig också öppna befintliga presentationer. Efter att ha laddat en presentation kan du hämta information om den, redigera bildinnehåll, lägga till nya bilder, ta bort befintliga och mer.

## **Öppna presentationer**

För att öppna en befintlig presentation, skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) och skicka filens sökväg till dess konstruktor.

Följande Java‑exempel visar hur du öppnar en presentation och får antalet bilder:

```java
// Skapa en instans av Presentation-klassen och skicka en filsökväg till dess konstruktor.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Skriv ut det totala antalet bilder i presentationen.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Öppna lösenordsskyddade presentationer**

När du behöver öppna en lösenordsskyddad presentation, skicka lösenordet via metoden [setPassword](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) i klassen [LoadOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/) för att dekryptera och ladda den. Följande Java‑kod demonstrerar denna operation:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Utför operationer på den dekrypterade presentationen.
} finally {
    presentation.dispose();
}
```

## **Öppna stora presentationer**

Aspose.Slides erbjuder alternativ—speciellt metoden [getBlobManagementOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) i klassen [LoadOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/)—för att hjälpa dig att ladda stora presentationer.

Följande Java‑kod demonstrerar hur man laddar en stor presentation (till exempel 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Välj KeepLocked-beteendet—presentationsfilen kommer att förbli låst under
// Presentation‑instansen, men den behöver inte laddas in i minnet eller kopieras till en temporär fil.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Den stora presentationen har laddats och kan användas, medan minnesförbrukningen förblir låg.

    // Gör ändringar i presentationen.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Spara presentationen till en annan fil. Minnesförbrukningen förblir låg under denna operation.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Gör inte så här! Ett I/O‑undantag kommer att kastas eftersom filen är låst tills presentationsobjektet har frigjorts.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Det är okej att göra det här. Källfilen är inte längre låst av presentationsobjektet.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
För att kringgå vissa begränsningar när man arbetar med strömmar kan Aspose.Slides kopiera en ströms innehåll. Att ladda en stor presentation från en ström orsakar att presentationen kopieras och kan göra laddningen långsammare. Därför rekommenderar vi starkt att använda presentationsfilens sökväg istället för en ström när du behöver ladda en stor presentation.

När du skapar en presentation som innehåller stora objekt (video, ljud, högupplösta bilder etc.) kan du använda [BLOB management](/slides/sv/androidjava/manage-blob/) för att minska minnesförbrukningen.
{{%/alert %}}

## **Hantera externa resurser**

Aspose.Slides tillhandahåller gränssnittet [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iresourceloadingcallback/) som låter dig hantera externa resurser. Följande Java‑kod visar hur du använder gränssnittet `IResourceLoadingCallback`:

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
                // Läs in en ersättningsbild.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Använd vilken metod som helst för att hämta byte
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Ange en ersättnings‑URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Hoppa över alla andra bilder.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Ladda presentationer utan inbäddade binära objekt**

En PowerPoint-presentation kan innehålla följande typer av inbäddade binära objekt:
- VBA‑projekt (tillgängligt via [IPresentation.getVbaProject](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- Inbäddad data för OLE‑objekt (tillgängligt via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Binär data för ActiveX‑kontroll (tillgängligt via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Genom att använda metoden [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) kan du ladda en presentation utan några inbäddade binära objekt.

Denna metod är användbar för att ta bort potentiellt skadligt binärt innehåll. Följande Java‑kod demonstrerar hur du laddar en presentation utan någon inbäddad binär data:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Utför operationer på presentationen.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Hur kan jag avgöra att en fil är korrupt och inte kan öppnas?**

Du får ett parsning-/formatvalideringsundantag vid inläsning. Sådana fel nämner ofta en ogiltig ZIP‑struktur eller trasiga PowerPoint‑poster.

**Vad händer om nödvändiga teckensnitt saknas vid öppning?**

Filen öppnas, men senare [rendering/export](/slides/sv/androidjava/convert-presentation/) kan ersätta teckensnitt. [Configure font substitutions](/slides/sv/androidjava/font-substitution/) eller [add the required fonts](/slides/sv/androidjava/custom-font/) till körmiljön.

**Vad händer med inbäddade media (video/ljud) vid öppning?**

De blir tillgängliga som presentationsresurser. Om media refereras via externa sökvägar, säkerställ att dessa är åtkomliga i din miljö; annars kan [rendering/export](/slides/sv/androidjava/convert-presentation/) utelämna media.