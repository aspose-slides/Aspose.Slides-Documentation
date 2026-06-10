---
title: "Prezentációk megnyitása JavaScript-ben"
linktitle: "Prezentáció megnyitása"
type: docs
weight: 20
url: /hu/nodejs-java/open-presentation/
keywords:
- "PowerPoint megnyitása"
- "OpenDocument megnyitása"
- "prezentáció megnyitása"
- "PPTX megnyitása"
- "PPT megnyitása"
- "ODP megnyitása"
- "prezentáció betöltése"
- "PPTX betöltése"
- "PPT betöltése"
- "ODP betöltése"
- "védett prezentáció"
- "nagy prezentáció"
- "külső erőforrás"
- "bináris objektum"
- Node.js
- JavaScript
- Aspose.Slides
description: "Nyisson PowerPoint (.pptx, .ppt) és OpenDocument (.odp) prezentációkat könnyedén az Aspose.Slides for Node.js Java segítségével - gyors, megbízható, teljes körű funkciókkal."
---
## **Bevezetés**

A PowerPoint-prezentációk készítése mellett az Aspose.Slides lehetővé teszi létező prezentációk megnyitását is. A prezentáció betöltése után lekérdezheti a rá vonatkozó információkat, szerkesztheti a dia tartalmát, új diákat adhat hozzá, eltávolíthat meglévőket, és még sok mást tehet.

## **Prezentációk megnyitása**

Egy létező prezentáció megnyitásához hozza létre a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály egy példányát, és adja meg a fájl elérési útját a konstruktorának.

Az alábbi JavaScript példa bemutatja, hogyan nyithat meg egy prezentációt, és hogyan kérdezheti le a diák számát:

```js
// Példányosítsa a Presentation osztályt és adjon meg egy fájl elérési utat a konstruktorának.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Írassa ki a prezentáció összes diája számát.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Jelszóval védett prezentációk megnyitása**

Ha jelszóval védett prezentációt kell megnyitnia, adja meg a jelszót a [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/) osztály [setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword) metódusán keresztül a dekódoláshoz és betöltéshez. Az alábbi JavaScript kód mutatja be ezt a műveletet:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Műveleteket végez a feloldott prezentáción.
} finally {
    presentation.dispose();
}
```

## **Nagy prezentációk megnyitása**

Aspose.Slides opciókat biztosít – különösen a [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/) osztályban található [getBlobManagementOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) metódust – hogy segítsen nagy prezentációk betöltésében.

Az alábbi JavaScript kód demonstrálja egy nagy (például 2 GB) prezentáció betöltését:

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Válassza a KeepLocked viselkedést – a prezentáció fájl a Presentation példány élettartama alatt zárolva marad
// a Presentation példányra, de nem szükséges memóriába betölteni vagy ideiglenes fájlba másolni.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // A nagy prezentáció betöltődött és használható, miközben a memóriahasználat alacsony marad.
    
    // Módosítsa a prezentációt.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Mentse a prezentációt egy másik fájlba. A memóriahasználat alacsony marad a művelet során.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Ne tegye ezt! I/O kivétel keletkezik, mert a fájl zárolva van, amíg a presentation objektumot el nem engedi.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Itt már rendben van ezt megtenni. A forrásfájlt már nem zárolja a presentation objektum.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
A folyamatos stream-ekkel kapcsolatos bizonyos korlátozások megkerülésére az Aspose.Slides másolhatja a stream tartalmát. Egy nagy prezentáció streamből történő betöltése a prezentáció másolását eredményezi, és lassíthatja a betöltést. Ezért, ha nagy prezentációt kell betölni, erősen ajánljuk, hogy a prezentáció fájl elérési útját használja a stream helyett.

Ha nagy objektumokat (videó, hang, nagy felbontású képek stb.) tartalmazó prezentációt hoz létre, a [BLOB management](/slides/hu/nodejs-java/manage-blob/) segítségével csökkentheti a memóriahasználatot.
{{%/alert %}}

## **Külső erőforrások kezelése**

Aspose.Slides biztosítja az [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iresourceloadingcallback/) interfészt, amely lehetővé teszi a külső erőforrások kezelését. Az alábbi JavaScript kód bemutatja, hogyan használja az `IResourceLoadingCallback` interfészt:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Töltsön be egy helyettesítő képet.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Állítson be egy helyettesítő URL-t.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Hagyja ki az összes többi képet.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **Prezentációk betöltése beágyazott bináris objektumok nélkül**

Egy PowerPoint-prezentáció a következő típusú beágyazott bináris objektumokat tartalmazhat:

- VBA projekt (elérhető a [Presentation.getVbaProject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getVbaProject) segítségével);
- OLE objektum beágyazott adatai (elérhető a [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) segítségével);
- ActiveX vezérlő bináris adatai (elérhető a [Control.getActiveXControlBinary](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/control/#getActiveXControlBinary) segítségével).

A [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) metódus használatával betölthet egy prezentációt anélkül, hogy bármilyen beágyazott bináris objektumot tartalmazna.

Ez a metódus hasznos a potenciálisan rosszindulatú bináris tartalom eltávolításához. Az alábbi JavaScript kód bemutatja, hogyan töltsön be egy prezentációt beágyazott bináris tartalom nélkül:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Műveleteket végez a prezentáción.
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Hogyan tudom megállapítani, hogy egy fájl megsérült és nem nyitható meg?**

Betöltéskor egy elemzési/formátum-ellenőrzési kivételt kap. Az ilyen hibák gyakran egy érvénytelen ZIP struktúrát vagy sérült PowerPoint rekordokat említenek.

**Mi történik, ha a megnyitáskor hiányoznak a szükséges betűtípusok?**

A fájl megnyílik, de később a [rendering/export](/slides/hu/nodejs-java/convert-presentation/) helyettesítheti a betűtípusokat. [Configure font substitutions](/slides/hu/nodejs-java/font-substitution/) vagy [add the required fonts](/slides/hu/nodejs-java/custom-font/) a futási környezethez.

**Mi a helyzet a beágyazott média (videó/hang) megnyitásakor?**

Elérhetők lesznek a prezentáció erőforrásaként. Ha a médiát külső útvonalakon keresztül hivatkozzák, győződjön meg róla, hogy ezek az útvonalak elérhetők a környezetben; ellenkező esetben a [rendering/export](/slides/hu/nodejs-java/convert-presentation/) kihagyhatja a médiát.