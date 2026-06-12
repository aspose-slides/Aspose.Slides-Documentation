---
title: Otevřít prezentace v .NET
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/net/open-presentation/
keywords:
- otevřít PowerPoint
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
- .NET
- C#
- Aspose.Slides
description: "Jednoduše otevřete prezentace PowerPoint (.pptx, .ppt) a OpenDocument (.odp) pomocí Aspose.Slides pro .NET — rychlé, spolehlivé, plně vybavené."
---
## **Úvod**

Kromě vytváření prezentací PowerPoint od nuly umožňuje Aspose.Slides také otevřít existující prezentace. Po načtení prezentace můžete získat informace o ní, upravit obsah snímků, přidat nové snímky, odebrat existující a další.

## **Otevření prezentací**

Chcete‑li otevřít existující prezentaci, vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a jako argument předávejte cestu k souboru.

Následující příklad v C# ukazuje, jak otevřít prezentaci a zjistit počet jejích snímků:

```cs
// Vytvořte instanci třídy Presentation a předejte konstruktoru cestu k souboru.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Vytiskněte celkový počet snímků v prezentaci.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **Otevření prezentací chráněných heslem**

Když potřebujete otevřít prezentaci chráněnou heslem, zadejte heslo pomocí vlastnosti [Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/) třídy [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/) pro dešifrování a načtení. Následující kód v C# demonstruje tuto operaci:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Proveďte operace na dešifrované prezentaci.
}
```

## **Otevření velkých prezentací**

Aspose.Slides poskytuje možnosti – zejména vlastnost [BlobManagementOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/blobmanagementoptions/) ve třídě [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/) – které vám pomohou načíst velké prezentace.

Následující kód v C# ukazuje načítání velké prezentace (například 2 GB):

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Vyberte chování KeepLocked — soubor prezentace zůstane uzamčen po celou dobu 
        // instance Presentation, ale není nutné jej načítat do paměti ani kopírovat do dočasného souboru.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Velká prezentace byla načtena a může být používána, přičemž spotřeba paměti zůstává nízká.

    // Proveďte změny v prezentaci.
    presentation.Slides[0].Name = "Large presentation";

    // Uložte prezentaci do jiného souboru. Spotřeba paměti během této operace zůstává nízká.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Nedělejte to! Bude vyvolána výjimka I/O, protože soubor je uzamčen, dokud není objekt prezentace uvolněn.
    File.Delete(filePath);
}

// Je v pořádku to udělat zde. Zdrojový soubor již není uzamčen objektem prezentace.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}

Aby se obešlo některé omezení při práci se streamy, Aspose.Slides může zkopírovat obsah streamu. Načítání velké prezentace ze streamu způsobí kopírování prezentace a může zpomalit načítání. Proto, když potřebujete načíst velkou prezentaci, důrazně doporučujeme použít cestu k souboru prezentace místo streamu.

Při vytváření prezentace, která obsahuje velké objekty (video, audio, obrázky vysokého rozlišení apod.), můžete použít [BLOB management](/slides/cs/net/manage-blob/) ke snížení spotřeby paměti.

{{%/alert %}}

## **Řízení externích zdrojů**

Aspose.Slides poskytuje rozhraní [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/net/aspose.slides/iresourceloadingcallback/), které vám umožňuje spravovat externí zdroje. Následující kód v C# ukazuje, jak použít rozhraní `IResourceLoadingCallback`:

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
                // Načtěte náhradní obrázek.
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
            // Nastavte náhradní URL.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Přeskočte všechny ostatní obrázky.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Načítání prezentací bez vložených binárních objektů**

Prezentace PowerPoint může obsahovat následující typy vložených binárních objektů:

- projekt VBA (přístupný přes [IPresentation.VbaProject](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/vbaproject/));
- data vloženého OLE objektu (přístupná přes [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- binární data ovládacího prvku ActiveX (přístupná přes [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/cs/net/aspose.slides/icontrol/activexcontrolbinary/)).

Pomocí vlastnosti [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) můžete načíst prezentaci bez jakýchkoli vložených binárních objektů.

Tato vlastnost je užitečná pro odstranění potenciálně škodlivého binárního obsahu. Následující kód v C# ukazuje, jak načíst prezentaci bez vloženého binárního obsahu:

```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Proveďte operace s prezentací.
}
```

## **Často kladené dotazy**

**Jak mohu zjistit, že je soubor poškozený a nelze jej otevřít?**

Během načítání dostanete výjimku při parsování/validaci formátu. Takové chyby často uvádějí neplatnou strukturu ZIP nebo poškozené záznamy PowerPointu.

**Co se stane, pokud při otevírání chybí požadovaná písma?**

Soubor se otevře, ale později může [rendering/export](/slides/cs/net/convert-presentation/) nahradit písma. [Configure font substitutions](/slides/cs/net/font-substitution/) nebo [add the required fonts](/slides/cs/net/custom-font/) přidejte do runtime prostředí.

**Co se stane s vloženými médii (video/audio) při otevírání?**

Stávají se dostupnými jako zdroje prezentace. Pokud jsou média odkazována externími cestami, zajistěte, aby tyto cesty byly ve vašem prostředí přístupné; v opačném případě může [rendering/export](/slides/cs/net/convert-presentation/) média vynechat.