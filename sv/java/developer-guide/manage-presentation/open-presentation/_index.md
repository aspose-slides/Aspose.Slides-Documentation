---
title: Öppna presentationer i Java
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Öppna PowerPoint (.pptx, .ppt) och OpenDocument (.odp) presentationer enkelt med Aspose.Slides för Java—snabbt, pålitligt, fullt utrustat."
---
## **Introduktion**

Förutom att skapa PowerPoint-presentationer från grunden låter Aspose.Slides dig också öppna befintliga presentationer. Efter att ha laddat en presentation kan du hämta information om den, redigera bildinnehåll, lägga till nya bilder, ta bort befintliga och mer.

## **Öppna presentationer**

För att öppna en befintlig presentation, skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑klassen och skicka filvägen till dess konstruktor.

Följande Java‑exempel visar hur man öppnar en presentation och får dess bildantal:

```java
// Instansiera Presentation-klassen och skicka en filsökväg till dess konstruktor.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Skriv ut det totala antalet bilder i presentationen.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Öppna lösenordsskyddade presentationer**

När du behöver öppna en lösenordsskyddad presentation, skicka lösenordet via [setPassword](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)‑metoden på [LoadOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/)-klassen för att dekryptera och ladda den. Följande Java‑kod demonstrerar denna operation:

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

Aspose.Slides erbjuder alternativ – särskilt [getBlobManagementOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--)‑metoden i [LoadOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/)-klassen – för att hjälpa dig att ladda stora presentationer.

Följande Java‑kod demonstrerar hur man laddar en stor presentation (t.ex. 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Välj KeepLocked‑beteendet—presentationsfilen förblir låst under
// presentationens livstid, men den behöver inte laddas in i minnet eller kopieras till en temporär fil.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Den stora presentationen har laddats och kan användas, samtidigt som minnesförbrukningen förblir låg.

    // Gör ändringar i presentationen.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Spara presentationen till en annan fil. Minnesförbrukningen förblir låg under denna operation.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Gör inte så här! Ett I/O‑undantag kastas eftersom filen är låst tills presentationsobjektet har frigjorts.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Det är OK att göra det här. Källfilen är inte längre låst av presentationsobjektet.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
För att kringgå vissa begränsningar vid arbete med strömmar kan Aspose.Slides kopiera en ströms innehåll. Att ladda en stor presentation från en ström gör att presentationen kopieras och kan sakta ner inläsningen. Därför rekommenderar vi starkt att du använder presentationsfilens sökväg snarare än en ström när du ska ladda stora presentationer.

När du skapar en presentation som innehåller stora objekt (video, ljud, högupplösta bilder osv.) kan du använda [BLOB‑hantering](/slides/sv/java/manage-blob/) för att minska minnesförbrukningen.
{{%/alert %}} 

## **Kontrollera externa resurser**

Aspose.Slides tillhandahåller gränssnittet [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iresourceloadingcallback/) som låter dig hantera externa resurser. Följande Java‑kod visar hur du använder `IResourceLoadingCallback`‑gränssnittet:

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
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Ange en ersättnings-URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Hoppa över alla andra bilder.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Ladda presentationer utan inbäddade binära objekt**

En PowerPoint‑presentation kan innehålla följande typer av inbäddade binära objekt:

- VBA‑projekt (åtkomligt via [IPresentation.getVbaProject](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentation/#getVbaProject--));
- OLE‑objektets inbäddade data (åtkomligt via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- AktivX‑kontrollens binära data (åtkomligt via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Genom att använda [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)‑metoden kan du ladda en presentation utan några inbäddade binära objekt.

Denna metod är användbar för att ta bort potentiellt skadligt binärt innehåll. Följande Java‑kod demonstrerar hur man laddar en presentation utan inbäddat binärt innehåll:

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

Du får ett parse‑/formatvalideringsundantag under inläsning. Sådana fel nämner ofta en ogiltig ZIP‑struktur eller trasiga PowerPoint‑poster.

**Vad händer om nödvändiga teckensnitt saknas vid öppning?**

Filen öppnas, men senare [rendering/export](/slides/sv/java/convert-presentation/) kan ersätta teckensnitt. [Konfigurera teckensnittsubstitution](/slides/sv/java/font-substitution/) eller [lägg till de nödvändiga teckensnitten](/slides/sv/java/custom-font/) i körmiljön.

**Vad händer med inbäddade media (video/ljud) vid öppning?**

De blir tillgängliga som presentationsresurser. Om media refereras via externa sökvägar, säkerställ att dessa sökvägar är åtkomliga i din miljö; annars kan [rendering/export](/slides/sv/java/convert-presentation/) utelämna media.