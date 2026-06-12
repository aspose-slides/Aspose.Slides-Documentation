---
title: Otevření prezentací v Javě
linktitle: Otevření prezentace
type: docs
weight: 20
url: /cs/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Jednoduše otevřete prezentace PowerPoint (.pptx, .ppt) a OpenDocument (.odp) pomocí Aspose.Slides pro Java - rychlé, spolehlivé, plně vybavené."
---
## **Úvod**

Kromě vytváření prezentací PowerPoint od nuly vám Aspose.Slides také umožňuje otevřít existující prezentace. Po načtení prezentace můžete získat informace o ní, upravit obsah snímků, přidat nové snímky, odebrat stávající a další.

## **Otevření prezentací**

Chcete-li otevřít existující prezentaci, vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a předávejte cestu k souboru do jejího konstruktoru.

Následující příklad v Javě ukazuje, jak otevřít prezentaci a získat počet snímků:

```java
// Vytvořte instanci třídy Presentation a předávejte cestu k souboru do jejího konstruktoru.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Vytiskněte celkový počet snímků v prezentaci.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Otevření chráněných prezentací heslem**

Když potřebujete otevřít prezentaci chráněnou heslem, předávejte heslo metodě [setPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) třídy [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/), aby se dešifrovala a načetla. Následující kód v Javě demonstruje tuto operaci:

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

Aspose.Slides poskytuje možnosti – zejména metodu [getBlobManagementOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) třídy [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/), které vám pomohou načíst velké prezentace.

Následující kód v Javě ukazuje načtení velké prezentace (například 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Vyberte chování KeepLocked — soubor prezentace bude uzamčen po celou dobu
// životnosti instance Presentation, ale není nutné jej načítat do paměti ani kopírovat do dočasného souboru.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Velká prezentace byla načtena a může být použita, přičemž spotřeba paměti zůstává nízká.

    // Proveďte změny v prezentaci.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Uložte prezentaci do jiného souboru. Spotřeba paměti zůstává nízká během této operace.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Nedělejte to! Bude vyhozena výjimka I/O, protože soubor je uzamčen, dokud není objekt prezentace uvolněn.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Je v pořádku provést to zde. Zdrojový soubor již není uzamčen objektem prezentace.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}

Aby se obešly určité omezení při práci se streamy, může Aspose.Slides kopírovat obsah streamu. Načtení velké prezentace ze streamu způsobí, že se prezentace zkopíruje, což může zpomalit načítání. Proto, pokud potřebujete načíst velkou prezentaci, důrazně doporučujeme použít cestu k souboru prezentace místo streamu.

Při vytváření prezentace, která obsahuje velké objekty (video, audio, obrázky v vysokém rozlišení atd.), můžete použít [BLOB management](/slides/cs/java/manage-blob/), abyste snížili spotřebu paměti.

{{%/alert %}}

## **Řízení externích zdrojů**

Aspose.Slides poskytuje rozhraní [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iresourceloadingcallback/), které vám umožňuje spravovat externí zdroje. Následující kód v Javě ukazuje, jak použít rozhraní `IResourceLoadingCallback`:

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
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
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

- VBA projekt (přístupný přes [IPresentation.getVbaProject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getVbaProject--));
- Data vloženého OLE objektu (přístupná přes [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Binární data ovládacího prvku ActiveX (přístupná přes [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Pomocí metody [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) můžete načíst prezentaci bez jakýchkoli vložených binárních objektů.

Tato metoda je užitečná pro odstranění potenciálně škodlivého binárního obsahu. Následující kód v Javě ukazuje, jak načíst prezentaci bez jakéhokoli vloženého binárního obsahu:

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

**Jak zjistit, že je soubor poškozený a nelze jej otevřít?**

Během načítání dostanete výjimku při parsování/validaci formátu. Takové chyby často uvádějí neplatnou strukturu ZIP nebo poškozené záznamy PowerPointu.

**Co se stane, pokud při otevírání chybí požadovaná písma?**

Soubor se otevře, ale při následném [renderování/exportu](/slides/cs/java/convert-presentation/) může dojít k náhradě písem. [Konfigurujte náhrady písem](/slides/cs/java/font-substitution/) nebo [přidejte požadovaná písma](/slides/cs/java/custom-font/) do běhového prostředí.

**Co se děje s vloženými médii (video/audio) při otevírání?**

Stanou se dostupnými jako zdroje prezentace. Pokud jsou média odkazována přes externí cesty, ujistěte se, že jsou v vašem prostředí přístupné; jinak může [renderování/export](/slides/cs/java/convert-presentation/) média vynechat.