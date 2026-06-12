---
title: Otevření prezentací na Androidu
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/androidjava/open-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Snadno otevřete prezentace PowerPoint (.pptx, .ppt) a OpenDocument (.odp) pomocí Aspose.Slides pro Android v Javě - rychlé, spolehlivé, plně vybavené."
---
## **Úvod**

Kromě vytváření prezentací PowerPoint od nuly vám Aspose.Slides také umožňuje otevírat existující prezentace. Po načtení prezentace můžete získat informace o ní, upravovat obsah snímků, přidávat nové snímky, odstraňovat existující a další.

## **Otevření prezentací**

Chcete-li otevřít existující prezentaci, vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) a do jejího konstruktoru předáte cestu k souboru.

Následující ukázka v jazyce Java ukazuje, jak otevřít prezentaci a zjistit počet jejích snímků:

```java
// Vytvořte instanci třídy Presentation a předejte cestu k souboru do jejího konstruktoru.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Vytiskněte celkový počet snímků v prezentaci.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Otevření prezentací chráněných heslem**

Pokud potřebujete otevřít prezentaci chráněnou heslem, předávejte heslo metodě [setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) třídy [LoadOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/), aby se dešifrovala a načetla. Následující kód v jazyce Java demonstruje tuto operaci:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Proveďte operace na dešifrované prezentaci.
} finally {
    presentation.dispose();
}
```

## **Otevření velkých prezentací**

Aspose.Slides poskytuje možnosti – zejména metodu [getBlobManagementOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) ve třídě [LoadOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/), které vám pomohou načíst velké prezentace.

Následující kód v jazyce Java ukazuje načtení velké prezentace (například 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Zvolte chování KeepLocked — soubor prezentace zůstane zamčený po dobu životnosti
// instance Presentation, ale není nutné jej načítat do paměti ani kopírovat do dočasného souboru.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Velká prezentace byla načtena a může být použita, přičemž spotřeba paměti zůstává nízká.

    // Proveďte změny v prezentaci.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Uložte prezentaci do jiného souboru. Spotřeba paměti během této operace zůstává nízká.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Nedělejte to! Bude vyhozena výjimka I/O, protože soubor je zamčený, dokud není uvolněn objekt prezentace.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Je v pořádku to provést zde. Zdrojový soubor již není zamčený objektem prezentace.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Aby se obešli některé omezení při práci se streamy, Aspose.Slides může kopírovat obsah streamu. Načtení velké prezentace ze streamu způsobí, že se prezentace zkopíruje, což může zpomalit načítání. Proto, pokud potřebujete načíst velkou prezentaci, rozhodně doporučujeme použít cestu k souboru prezentace místo streamu.

Při vytváření prezentace, která obsahuje velké objekty (video, audio, obrázky v vysokém rozlišení atd.), můžete použít [BLOB management](/slides/cs/androidjava/manage-blob/), abyste snížili spotřebu paměti.
{{%/alert %}}

## **Řízení externích zdrojů**

Aspose.Slides poskytuje rozhraní [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iresourceloadingcallback/), které vám umožňuje spravovat externí zdroje. Následující kód v jazyce Java ukazuje, jak použít rozhraní `IResourceLoadingCallback`:

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
                // Načtěte náhradní obrázek.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Použijte libovolnou metodu k získání bajtů
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Nastavte náhradní URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Přeskočit všechny ostatní obrázky.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Načtení prezentací bez vložených binárních objektů**

Prezentace PowerPoint může obsahovat následující typy vložených binárních objektů:

- VBA projekt (přístupný přes [IPresentation.getVbaProject](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- Vložená data OLE objektu (přístupná přes [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Binární data ovládacího prvku ActiveX (přístupná přes [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Při použití metody [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) můžete načíst prezentaci bez jakýchkoli vložených binárních objektů.

Tato metoda je užitečná pro odstranění potenciálně škodlivého binárního obsahu. Následující kód v jazyce Java demonstruje, jak načíst prezentaci bez jakéhokoli vloženého binárního obsahu:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Proveďte operace na prezentaci.
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Jak mohu zjistit, že je soubor poškozený a nelze jej otevřít?**

Během načítání obdržíte výjimku při parsování/validaci formátu. Takové chyby často uvádějí neplatnou strukturu ZIP nebo poškozené záznamy PowerPointu.

**Co se stane, pokud při otevírání chybí požadované fonty?**

Soubor se otevře, ale později může [vykreslování/export](/slides/cs/androidjava/convert-presentation/) nahradit fonty. [Nastavte substituce fontů](/slides/cs/androidjava/font-substitution/) nebo [přidejte požadované fonty](/slides/cs/androidjava/custom-font/) do běhového prostředí.

**Co se stane s vloženými médii (video/audio) při otevírání?**

Stanou se dostupnými jako zdroje prezentace. Pokud jsou média odkazována pomocí externích cest, ujistěte se, že jsou tyto cesty ve vašem prostředí přístupné; v opačném případě může [vykreslování/export](/slides/cs/androidjava/convert-presentation/) média vynechat.