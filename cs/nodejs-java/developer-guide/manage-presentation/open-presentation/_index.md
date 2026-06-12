---
title: Otevření prezentací v JavaScriptu
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Otevřete prezentace PowerPoint (.pptx, .ppt) a OpenDocument (.odp) snadno pomocí Aspose.Slides pro Node.js prostřednictvím Java—rychlé, spolehlivé, plně vybavené."
---
## **Úvod**

Kromě vytváření prezentací PowerPoint od nuly vám Aspose.Slides také umožňuje otevírat existující prezentace. Po načtení prezentace můžete získat informace o ní, upravovat obsah snímků, přidávat nové snímky, odstraňovat existující a další.

## **Otevření prezentací**

Chcete‑li otevřít existující prezentaci, vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a do jejího konstruktoru předáte cestu k souboru.

Následující příklad v JavaScriptu ukazuje, jak otevřít prezentaci a získat počet snímků:

```js
// Vytvořte instanci třídy Presentation a předávejte cestu k souboru do jejího konstruktoru.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Vytiskněte celkový počet snímků v prezentaci.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Otevření prezentací chráněných heslem**

Když potřebujete otevřít prezentaci chráněnou heslem, předáte heslo metodě [setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setPassword) třídy [LoadOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/), která ji dešifruje a načte. Následující kód v JavaScriptu demonstruje tuto operaci:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Proveďte operace na dešifrované prezentaci.
} finally {
    presentation.dispose();
}
```

## **Otevření velkých prezentací**

Aspose.Slides poskytuje možnosti – zejména metodu [getBlobManagementOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) ve třídě [LoadOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/) – které vám pomohou načíst velké prezentace.

Následující kód v JavaScriptu ukazuje načtení velké prezentace (například 2 GB):

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Vyberte chování KeepLocked—soubor prezentace bude uzamčen po dobu
// životnosti instance Presentation, ale není nutné jej načítat do paměti ani kopírovat do dočasného souboru.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // Velká prezentace byla načtena a může být použita, přičemž spotřeba paměti zůstává nízká.
    
    // Proveďte změny v prezentaci.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Uložte prezentaci do jiného souboru. Spotřeba paměti zůstává nízká během této operace.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Nedělejte to! Bude vyhozena výjimka I/O, protože soubor je uzamčen, dokud není objekt prezentace uvolněn.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Je v pořádku to provést zde. Zdrojový soubor již není uzamčen objektem prezentace.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
Aby se obešel s určitými omezeními při práci se streamy, může Aspose.Slides zkopírovat obsah streamu. Načtení velké prezentace ze streamu způsobí kopírování prezentace a může zpomalit načítání. Proto, když potřebujete načíst velkou prezentaci, důrazně doporučujeme použít cestu k souboru prezentace místo streamu.

Při tvorbě prezentace, která obsahuje velké objekty (video, audio, obrázky vysokého rozlišení atd.), můžete použít [BLOB management](/slides/cs/nodejs-java/manage-blob/) ke snížení spotřeby paměti.
{{%/alert %}}

## **Řízení externích zdrojů**

Aspose.Slides poskytuje rozhraní [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iresourceloadingcallback/), které vám umožňuje spravovat externí zdroje. Následující kód v JavaScriptu ukazuje, jak použít rozhraní `IResourceLoadingCallback`:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Načíst náhradní obrázek.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Nastavit náhradní URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Přeskočit všechny ostatní obrázky.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **Načtení prezentací bez vložených binárních objektů**

Prezentace PowerPoint může obsahovat následující typy vložených binárních objektů:

- VBA projekt (přístupný přes [Presentation.getVbaProject](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getVbaProject));
- vložená data OLE objektu (přístupná přes [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- binární data ActiveX ovládacího prvku (přístupná přes [Control.getActiveXControlBinary](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

Pomocí metody [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) můžete načíst prezentaci bez jakýchkoli vložených binárních objektů.

Tato metoda je užitečná pro odstranění potenciálně škodlivého binárního obsahu. Následující kód v JavaScriptu ukazuje, jak načíst prezentaci bez jakéhokoli vloženého binárního obsahu:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Proveďte operace na prezentaci.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jak zjistím, že je soubor poškozený a nelze jej otevřít?**

Během načítání obdržíte výjimku při parsování/validaci formátu. Takové chyby často uvádějí neplatnou strukturu ZIP nebo poškozené záznamy PowerPointu.

**Co se stane, pokud při otevírání chybí požadované fonty?**

Soubor se otevře, ale později může při [renderování/exportu](/slides/cs/nodejs-java/convert-presentation/) dojít k náhradě fontů. [Nastavte náhrady fontů](/slides/cs/nodejs-java/font-substitution/) nebo [přidejte požadované fonty](/slides/cs/nodejs-java/custom-font/) do runtime prostředí.

**Co se stane s vloženými médii (video/audio) při otevírání?**

Stanou se dostupnými jako zdroje prezentace. Pokud jsou média odkazována externími cestami, ujistěte se, že jsou v prostředí přístupné; jinak může při [renderování/exportu](/slides/cs/nodejs-java/convert-presentation/) dojít k jejich vynechání.