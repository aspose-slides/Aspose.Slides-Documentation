---
title: Presentaties openen in C++
linktitle: Presentatie openen
type: docs
weight: 20
url: /nl/cpp/open-presentation/
keywords:
- PowerPoint openen
- OpenDocument openen
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
- C++
- Aspose.Slides
description: "Open PowerPoint (.pptx, .ppt) en OpenDocument (.odp) presentaties moeiteloos met Aspose.Slides voor C++ - snel, betrouwbaar, volledig uitgerust."
---
## **Inleiding**

Naast het vanaf nul maken van PowerPoint‑presentaties biedt Aspose.Slides ook de mogelijkheid om bestaande presentaties te openen. Nadat u een presentatie hebt geladen, kunt u er informatie over opvragen, de inhoud van dia's bewerken, nieuwe dia's toevoegen, bestaande dia's verwijderen en meer.

## **Presentaties openen**

Om een bestaande presentatie te openen, maakt u een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse en geeft u het bestandspad door aan de constructor.

Het volgende C++‑voorbeeld toont hoe u een presentatie opent en het aantal dia's ophaalt:

```cpp
// Maak een instantie van de Presentation‑klasse en geef een bestandspad door aan de constructor.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Print het totale aantal dia's in de presentatie.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Wachtwoord‑beveiligde presentaties openen**

Wanneer u een wachtwoord‑beveiligde presentatie moet openen, geeft u het wachtwoord door aan de [set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/)‑methode van de [LoadOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/)‑klasse om deze te ontsleutelen en te laden. Het volgende C++‑codefragment demonstreert deze bewerking:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Voer bewerkingen uit op de gedecrypteerde presentatie.

presentation->Dispose();
```

## **Grote presentaties openen**

Aspose.Slides biedt opties—met name de [get_BlobManagementOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/)‑methode in de [LoadOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/)‑klasse—om u te helpen grote presentaties te laden.

Het volgende C++‑codefragment toont het laden van een grote presentatie (bijvoorbeeld 2 GB):

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Kies het KeepLocked gedrag — het presentiebestand blijft vergrendeld gedurende de levensduur van
// de Presentation‑instantie, maar het hoeft niet in het geheugen geladen te worden of gekopieerd naar een tijdelijk bestand.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// De grote presentatie is geladen en kan worden gebruikt, terwijl het geheugenverbruik laag blijft.

// Breng wijzigingen aan in de presentatie.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Sla de presentatie op in een ander bestand. Het geheugenverbruik blijft laag tijdens deze bewerking.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Doe dit niet! Er wordt een I/O‑exception gegooid omdat het bestand vergrendeld blijft totdat het presentatiedobject wordt vrijgegeven.
File::Delete(filePath);

presentation->Dispose();

// Het is hier wel toegestaan. Het bronbestand is niet langer vergrendeld door het presentatiedobject.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Om bepaalde beperkingen bij het werken met streams te omzeilen, kan Aspose.Slides de inhoud van een stream kopiëren. Het laden van een grote presentatie vanuit een stream zorgt ervoor dat de presentatie wordt gekopieerd, wat het laden kan vertragen. Daarom raden we sterk aan om bij het laden van een grote presentatie het pad naar het presentatie‑bestand te gebruiken in plaats van een stream.

Bij het maken van een presentatie die grote objecten bevat (video, audio, afbeeldingen met hoge resolutie, enz.) kunt u [BLOB management](/slides/nl/cpp/manage-blob/) gebruiken om het geheugenverbruik te verminderen.
{{%/alert %}}

## **Externe bronnen beheren**

Aspose.Slides levert de [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iresourceloadingcallback/)‑interface waarmee u externe bronnen kunt beheren. Het volgende C++‑codefragment laat zien hoe u de `IResourceLoadingCallback`‑interface gebruikt:

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
                // Laad een vervangende afbeelding.
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
            // Stel een vervangende URL in.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Sla alle andere afbeeldingen over.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **Presentaties laden zonder ingebedde binaire objecten**

A PowerPoint‑presentatie kan de volgende typen ingebedde binaire objecten bevatten:

- VBA‑project (toegankelijk via [IPresentation::get_VbaProject](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_vbaproject/));
- OLE‑object ingebedde gegevens (toegankelijk via [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- ActiveX‑besturingselement binaire gegevens (toegankelijk via [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Met de [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/)‑methode kunt u een presentatie laden zonder enige ingebedde binaire objecten.

Deze methode is handig om potentieel kwaadaardige binaire inhoud te verwijderen. Het volgende C++‑codefragment demonstreert hoe u een presentatie laadt zonder enige ingebedde binaire inhoud:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Voer bewerkingen uit op de presentatie.

presentation->Dispose();
```

## **FAQ**

**Hoe kan ik zien dat een bestand beschadigd is en niet kan worden geopend?**

U krijgt tijdens het laden een parse‑/formatvalidatie‑exception. Dergelijke fouten vermelden vaak een ongeldige ZIP‑structuur of beschadigde PowerPoint‑records.

**Wat gebeurt er als vereiste lettertypen ontbreken bij het openen?**

Het bestand wordt geopend, maar later kan bij [rendering/export](/slides/nl/cpp/convert-presentation/) een vervanging van lettertypen plaatsvinden. [Configureer lettertype‑vervangingen](/slides/nl/cpp/font-substitution/) of [voeg de vereiste lettertypen toe](/slides/nl/cpp/custom-font/) aan de runtime‑omgeving.

**Wat gebeurt er met ingebedde media (video/audio) bij het openen?**

Ze worden beschikbaar als presentatieresources. Als media via externe paden worden gerefereerd, zorg er dan voor dat die paden toegankelijk zijn in uw omgeving; anders kan bij [rendering/export](/slides/nl/cpp/convert-presentation/) de media worden weggelaten.