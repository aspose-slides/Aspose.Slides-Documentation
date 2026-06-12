---
title: Otevření prezentací v C++
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/cpp/open-presentation/
keywords:
- otevřít PowerPoint
- otevřít OpenDocument
- otevřít prezentaci
- otevřít PPTX
- otevřít PPT
- otevřít ODP
- načíst prezentaci
- načíst PPTX
- načíst PPT
- načíst ODP
- chráněná prezentace
- velká prezentace
- externí zdroj
- binární objekt
- C++
- Aspose.Slides
description: "Jednoduše otevřete prezentace PowerPoint (.pptx, .ppt) a OpenDocument (.odp) pomocí Aspose.Slides pro C++ - rychlé, spolehlivé a plně vybavené."
---
## **Úvod**

Kromě vytváření prezentací PowerPoint od nuly umožňuje Aspose.Slides také otevírat existující prezentace. Po načtení prezentace můžete získat o ní informace, upravovat obsah snímků, přidávat nové snímky, odstraňovat existující a další.

## **Otevření prezentací**

Pro otevření existující prezentace vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a předávejte cestu k souboru do jejího konstruktoru.

Následující příklad v C++ ukazuje, jak otevřít prezentaci a získat její počet snímků:

```cpp
// Vytvořte instanci třídy Presentation a předávejte cestu k souboru jejímu konstruktoru.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Vytiskněte celkový počet snímků v prezentaci.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Otevření prezentací chráněných heslem**

Když potřebujete otevřít prezentaci chráněnou heslem, předávejte heslo metodě [set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/) třídy [LoadOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/), která ji dešifruje a načte. Následující kód v C++ demonstruje tuto operaci:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Proveďte operace na dešifrované prezentaci.

presentation->Dispose();
```

## **Otevření velkých prezentací**

Aspose.Slides poskytuje možnosti—zejména metodu [get_BlobManagementOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) ve třídě [LoadOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/)—které vám pomohou načíst velké prezentace.

Následující kód v C++ ukazuje načtení velké prezentace (například 2 GB):

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Zvolte chování KeepLocked — soubor prezentace zůstane zamčený po celou dobu
// instance Presentation, ale není nutné jej načítat do paměti ani kopírovat do dočasného souboru.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// Velká prezentace byla načtena a může být použita, přičemž spotřeba paměti zůstává nízká.

// Proveďte změny v prezentaci.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Uložte prezentaci do jiného souboru. Spotřeba paměti zůstává během této operace nízká.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Nedělejte to! Bude vyhozena výjimka I/O, protože soubor je zamčený, dokud není objekt prezentace uvolněn.
File::Delete(filePath);

presentation->Dispose();

// Je v pořádku to provést zde. Zdrojový soubor již není zamčený objektem prezentace.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Aby se obešly některé omezení při práci s proudy, může Aspose.Slides zkopírovat obsah proudu. Načtení velké prezentace z proudu způsobí zkopírování prezentace a může zpomalit načítání. Proto, když potřebujete načíst velkou prezentaci, důrazně doporučujeme použít cestu k souboru prezentace místo proudu.

Při vytváření prezentace, která obsahuje velké objekty (video, audio, obrázky vysokého rozlišení atd.), můžete použít [BLOB management](/slides/cs/cpp/manage-blob/) ke snížení spotřeby paměti.
{{%/alert %}}

## **Řízení externích zdrojů**

Aspose.Slides poskytuje rozhraní [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iresourceloadingcallback/), které vám umožňuje spravovat externí zdroje. Následující kód v C++ ukazuje, jak použít rozhraní `IResourceLoadingCallback`:

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
                // Načíst náhradní obrázek.
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
            // Nastavit náhradní URL.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Přeskočit všechny ostatní obrázky.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **Načtení prezentací bez vložených binárních objektů**

Prezentace PowerPoint může obsahovat následující typy vložených binárních objektů:

- Projekt VBA (přístupný přes [IPresentation::get_VbaProject](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_vbaproject/));
- Vložená data OLE objektu (přístupná přes [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- Binární data ActiveX ovládacího prvku (přístupná přes [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Pomocí metody [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) můžete načíst prezentaci bez jakýchkoli vložených binárních objektů.

Tato metoda je užitečná pro odstranění potenciálně škodlivého binárního obsahu. Následující kód v C++ ukazuje, jak načíst prezentaci bez jakéhokoli vloženého binárního obsahu:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Perform operations on the presentation.

presentation->Dispose();
```

## **Často kladené otázky**

**Jak poznám, že soubor je poškozený a nelze jej otevřít?**

Během načítání získáte výjimku při parsování/validaci formátu. Tyto chyby často uvádějí neplatnou strukturu ZIP nebo poškozené záznamy PowerPointu.

**Co se stane, pokud při otevření chybí požadované fonty?**

Soubor se otevře, ale při následném [renderování/exportu](/slides/cs/cpp/convert-presentation/) mohou být fonty nahrazeny. [Nastavte náhrady fontů](/slides/cs/cpp/font-substitution/) nebo [přidejte požadované fonty](/slides/cs/cpp/custom-font/) do runtime prostředí.

**Co se stane s vloženými médii (video/audio) při otevření?**

Stanou se dostupnými jako zdroje prezentace. Pokud jsou média odkazována externími cestami, ujistěte se, že jsou tyto cesty přístupné ve vašem prostředí; jinak může [renderování/export](/slides/cs/cpp/convert-presentation/) média vynechat.