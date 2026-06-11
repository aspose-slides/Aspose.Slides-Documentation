---
title: Öppna presentationer i .NET
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/net/open-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Öppna PowerPoint (.pptx, .ppt) och OpenDocument (.odp) presentationer enkelt med Aspose.Slides för .NET—snabb, pålitlig, fullt utrustad."
---
## **Introduktion**

Förutom att skapa PowerPoint‑presentationer från grunden låter Aspose.Slides dig också öppna befintliga presentationer. Efter att ha laddat en presentation kan du hämta information om den, redigera bildinnehåll, lägga till nya bilder, ta bort befintliga och mer.

## **Öppna presentationer**

För att öppna en befintlig presentation, skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och skicka filvägen till dess konstruktor.

Följande C#‑exempel visar hur du öppnar en presentation och får antalet bilder:

```cs
// Skapa en instans av Presentation-klassen och skicka en filsökväg till dess konstruktor.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Skriv ut det totala antalet bilder i presentationen.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **Öppna lösenordsskyddade presentationer**

När du behöver öppna en lösenordsskyddad presentation, skicka lösenordet via [Password](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/password/)‑egenskapen i [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/)‑klassen för att dekryptera och ladda den. Följande C#‑kod demonstrerar denna operation:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Utför operationer på den dekrypterade presentationen.
}
```

## **Öppna stora presentationer**

Aspose.Slides erbjuder alternativ — särskilt [BlobManagementOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/blobmanagementoptions/)‑egenskapen i [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/)‑klassen — för att hjälpa dig att ladda stora presentationer.

Följande C#‑kod demonstrerar hur du laddar en stor presentation (till exempel 2 GB):

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Välj KeepLocked‑beteendet — presentationsfilen förblir låst under hela
        // Presentation‑instansen, men den behöver inte laddas in i minnet eller kopieras till en temporär fil.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Den stora presentationen har lästs in och kan användas, medan minnesförbrukningen förblir låg.

    // Gör ändringar i presentationen.
    presentation.Slides[0].Name = "Large presentation";

    // Spara presentationen till en annan fil. Minnesförbrukningen förblir låg under denna operation.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Gör inte så här! Ett I/O‑undantag kastas eftersom filen är låst tills presentationsobjektet har frigjorts.
    File.Delete(filePath);
}

// Det är okej att göra det här. Källfilen är inte längre låst av presentationsobjektet.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
För att kringgå vissa begränsningar när du arbetar med strömmar kan Aspose.Slides kopiera en ströms innehåll. Att ladda en stor presentation från en ström gör att presentationen kopieras och kan sakta ner inläsningen. Därför rekommenderar vi starkt att du använder presentationsfilens sökväg istället för en ström när du behöver ladda en stor presentation.

När du skapar en presentation som innehåller stora objekt (video, audio, högupplösta bilder osv.) kan du använda [BLOB management](/slides/sv/net/manage-blob/) för att minska minnesförbrukningen.
{{%/alert %}}

## **Hantera externa resurser**

Aspose.Slides tillhandahåller gränssnittet [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/iresourceloadingcallback/) som låter dig hantera externa resurser. Följande C#‑kod visar hur du använder `IResourceLoadingCallback`‑gränssnittet:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Läs in en ersättningsbild.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Ange en ersättnings‑URL.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Hoppa över alla andra bilder.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Ladda presentationer utan inbäddade binära objekt**

En PowerPoint‑presentation kan innehålla följande typer av inbäddade binära objekt:

- VBA‑projekt (tillgängligt via [IPresentation.VbaProject](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/vbaproject/));
- Inbäddad OLE‑objektdata (tillgänglig via [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/sv/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- Binär data för ActiveX‑kontroll (tillgänglig via [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/sv/net/aspose.slides/icontrol/activexcontrolbinary/)).

Genom att använda egenskapen [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) kan du ladda en presentation utan några inbäddade binära objekt.

Denna egenskap är användbar för att ta bort potentiellt skadligt binärt innehåll. Följande C#‑kod demonstrerar hur du laddar en presentation utan någon inbäddad binär data:

```cs
LoadOptions loadOptions = new LoadOptions()
{
    DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Utför operationer på presentationen.
}
```

## **FAQ**

**Hur kan jag avgöra att en fil är korrupt och inte kan öppnas?**

Du får ett parserings‑/formatvalideringsundantag under inläsningen. Sådana fel nämner ofta en ogiltig ZIP‑struktur eller trasiga PowerPoint‑poster.

**Vad händer om nödvändiga typsnitt saknas vid öppning?**

Filen öppnas, men senare [rendering/export](/slides/sv/net/convert-presentation/) kan ersätta typsnitt. [Konfigurera typsnittsersättningar](/slides/sv/net/font-substitution/) eller [lägg till de nödvändiga typsnitten](/slides/sv/net/custom-font/) i runtime‑miljön.

**Vad händer med inbäddade media (video/audio) vid öppning?**

De blir tillgängliga som presentationsresurser. Om media refereras via externa sökvägar, se till att dessa sökvägar är åtkomliga i din miljö; annars kan [rendering/export](/slides/sv/net/convert-presentation/) utelämna media.