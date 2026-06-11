---
title: Öppna presentationer i C++
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/cpp/open-presentation/
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
- C++
- Aspose.Slides
description: "Öppna PowerPoint (.pptx, .ppt) och OpenDocument (.odp) presentationer enkelt med Aspose.Slides för C++ – snabbt, pålitligt och fullt utrustat."
---
## **Introduction**

Utöver att skapa PowerPoint-presentationer från grunden låter Aspose.Slides dig också öppna befintliga presentationer. Efter att ha laddat en presentation kan du hämta information om den, redigera bildinnehåll, lägga till nya bilder, ta bort befintliga och mer.

## **Open Presentations**

## **Öppna presentationer**

För att öppna en befintlig presentation, skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) och skicka filvägen till dess konstruktor.

Följande C++-exempel visar hur du öppnar en presentation och får antalet bilder:

```cpp
// Instansiera Presentation-klassen och skicka en filväg till dess konstruktor.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Skriv ut det totala antalet bilder i presentationen.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Open Password-Protected Presentations**

## **Öppna lösenordsskyddade presentationer**

När du behöver öppna en lösenordsskyddad presentation, skicka lösenordet via metoden [set_Password](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_password/) i klassen [LoadOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/) för att dekryptera och ladda den. Följande C++-kod visar denna operation:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Utför operationer på den dekrypterade presentationen.

presentation->Dispose();
```

## **Open Large Presentations**

## **Öppna stora presentationer**

Aspose.Slides tillhandahåller alternativ—speciellt metoden [get_BlobManagementOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) i klassen [LoadOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/)—för att hjälpa dig att ladda stora presentationer.

Följande C++-kod demonstrerar hur man laddar en stor presentation (till exempel 2 GB):

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Välj KeepLocked‑beteendet — presentationsfilen förblir låst under hela livstiden av
// Presentation‑instansen, men den behöver inte laddas in i minnet eller kopieras till en temporär fil.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// Den stora presentationen har laddats och kan användas, medan minnesförbrukningen förblir låg.

// Gör ändringar i presentationen.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Spara presentationen till en annan fil. Minnesförbrukningen förblir låg under denna operation.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Gör inte detta! Ett I/O‑undantag kommer att kastas eftersom filen är låst tills presentationsobjektet har frigjorts.
File::Delete(filePath);

presentation->Dispose();

// Det är okej att göra det här. Källfilen är inte längre låst av presentationsobjektet.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
För att kringgå vissa begränsningar när du arbetar med strömmar kan Aspose.Slides kopiera en ströms innehåll. Att ladda en stor presentation från en ström gör att presentationen kopieras och kan sakta ned inläsningen. Därför rekommenderar vi starkt att du använder filvägen till presentationen istället för en ström när du behöver ladda en stor presentation.

När du skapar en presentation som innehåller stora objekt (video, ljud, högupplösta bilder etc.) kan du använda [BLOB management](/slides/sv/cpp/manage-blob/) för att minska minnesförbrukningen.
{{%/alert %}}

## **Control External Resources**

## **Styr externa resurser**

Aspose.Slides tillhandahåller gränssnittet [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iresourceloadingcallback/) som låter dig hantera externa resurser. Följande C++-kod visar hur du använder gränssnittet `IResourceLoadingCallback`:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Läs in en ersättningsbild.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Ange en ersättnings‑URL.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Hoppa över alla andra bilder.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **Load Presentations without Embedded Binary Objects**

## **Ladda presentationer utan inbäddade binära objekt**

En PowerPoint-presentation kan innehålla följande typer av inbäddade binära objekt:

- VBA‑projekt (åtkomligt via [IPresentation::get_VbaProject](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_vbaproject/));
- OLE‑objekt inbäddad data (åtkomligt via [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- ActiveX‑kontroll binär data (åtkomligt via [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Genom att använda metoden [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) kan du ladda en presentation utan några inbäddade binära objekt.

Denna metod är användbar för att ta bort potentiellt skadligt binärt innehåll. Följande C++-kod demonstrerar hur du laddar en presentation utan någon inbäddad binär data:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Utför operationer på presentationen.

presentation->Dispose();
```

## **FAQ**

**How can I tell that a file is corrupted and can’t be opened?**

**Hur kan jag avgöra att en fil är korrupt och inte kan öppnas?**

Du får ett parse‑/formatvalideringsundantag under inläsning. Sådana fel nämner ofta en ogiltig ZIP‑struktur eller trasiga PowerPoint‑poster.

**What happens if required fonts are missing when opening?**

**Vad händer om nödvändiga teckensnitt saknas vid öppning?**

Filen öppnas, men senare [rendering/export](/slides/sv/cpp/convert-presentation/) kan ersätta teckensnitt. [Configure font substitutions](/slides/sv/cpp/font-substitution/) eller [add the required fonts](/slides/sv/cpp/custom-font/) till körmiljön.

**What about embedded media (video/audio) when opening?**

**Vad händer med inbäddade media (video/ljud) vid öppning?**

De blir tillgängliga som presentationsresurser. Om media refereras via externa sökvägar, se till att dessa sökvägar är åtkomliga i din miljö; annars kan [rendering/export](/slides/sv/cpp/convert-presentation/) utelämna media.