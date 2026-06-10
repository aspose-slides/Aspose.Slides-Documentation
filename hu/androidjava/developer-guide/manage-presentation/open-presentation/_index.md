---
title: Prezentációk megnyitása Androidon
linktitle: Prezentáció megnyitása
type: docs
weight: 20
url: /hu/androidjava/open-presentation/
keywords:
- PowerPoint megnyitása
- OpenDocument megnyitása
- prezentáció megnyitása
- PPTX megnyitása
- PPT megnyitása
- ODP megnyitása
- prezentáció betöltése
- PPTX betöltése
- PPT betöltése
- ODP betöltése
- védett prezentáció
- nagy prezentáció
- külső erőforrás
- bináris objektum
- Android
- Java
- Aspose.Slides
description: "PowerPoint (.pptx, .ppt) és OpenDocument (.odp) prezentációkat könnyedén nyithat meg az Aspose.Slides for Android Java segítségével - gyors, megbízható, teljes funkcionalitással."
---
## **Bevezetés**

A PowerPoint‑prezentációk alapból történő létrehozása mellett az Aspose.Slides lehetővé teszi meglévő prezentációk megnyitását is. A prezentáció betöltése után lekérdezhet információkat róla, szerkesztheti a diák tartalmát, új diákot adhat hozzá, meglévőket törölhet, és még sok minden mást végezhet.

## **Prezentációk megnyitása**

Egy meglévő prezentáció megnyitásához hozza létre a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály egy példányát, és adja át a konstruktorának a fájl útvonalát.

Az alábbi Java‑példa bemutatja, hogyan nyithat meg egy prezentációt és hogyan kérdezheti le a diák számát:

```java
// Példányosítsa a Presentation osztályt, és adja meg a fájl útvonalát a konstruktorának.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Írassa ki a prezentáció diáinak teljes számát.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Jelszóval védett prezentációk megnyitása**

Amikor jelszóval védett prezentációt kell megnyitnia, adja meg a jelszót a [LoadOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/) osztály [setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) metódusán keresztül, hogy azt visszafejtse és betöltse. Az alábbi Java‑kód ezt a műveletet mutatja be:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Műveleteket hajtson végre a visszafejtett prezentáción.
} finally {
    presentation.dispose();
}
```

## **Nagy prezentációk megnyitása**

Az Aspose.Slides olyan beállításokat kínál – különösen a [LoadOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/) osztály [getBlobManagementOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) metódusát – amelyek segítenek nagy méretű prezentációk betöltésében.

Az alábbi Java‑kód bemutatja egy nagy (például 2 GB) prezentáció betöltését:

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Válassza a KeepLocked viselkedést — a prezentáció fájl a
// Presentation példányig, de nem szükséges betölteni a memóriába vagy ideiglenes fájlba másolni.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // A nagy prezentáció betöltődött és használható, miközben a memóriahasználat alacsony marad.

    // Módosítások végrehajtása a prezentáción.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Mentse a prezentációt egy másik fájlba. A memóriahasználat ebben a műveletben alacsony marad.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Ne tegye ezt! I/O kivétel keletkezik, mert a fájl zárolva van, amíg a presentation objektum nincs felszabadítva.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Itt már rendben van. A forrásfájl már nincs zárolva a presentation objektum által.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
A streamek használatakor felmerülő bizonyos korlátok megkerülése érdekében az Aspose.Slides a stream tartalmát másolhatja. Egy nagy prezentáció streamekből történő betöltése esetén a prezentáció másolódik, ami lassíthatja a betöltést. Ezért nagy prezentáció betöltésekor erősen javasoljuk, hogy a prezentáció fájlútvonalát használja a stream helyett.

Amikor olyan prezentációt hoz létre, amely nagy objektumokat (videó, hang, nagy felbontású képek stb.) tartalmaz, a [BLOB kezelés](/slides/hu/androidjava/manage-blob/) segítségével csökkentheti a memóriahasználatot.
{{%/alert %}}

## **Külső erőforrások vezérlése**

Az Aspose.Slides biztosítja az [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iresourceloadingcallback/) interfészt, amely lehetővé teszi a külső erőforrások kezelését. Az alábbi Java‑kód mutatja, hogyan használja az `IResourceLoadingCallback` interfészt:

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
                // Töltsön be egy helyettesítő képet.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Használjon bármilyen módszert a bájtok lekéréséhez
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Állítson be egy helyettesítő URL-t.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Hagyja figyelmen kívül a többi képet.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Beágyazott bináris objektumok nélküli prezentációk betöltése**

Egy PowerPoint‑prezentáció a következő típusú beágyazott bináris objektumokat tartalmazhatja:

- VBA projekt (elérhető a [IPresentation.getVbaProject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) segítségével);
- OLE objektum beágyazott adatai (elérhető a [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) segítségével);
- ActiveX vezérlő bináris adatai (elérhető a [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) segítségével).

Az [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) metódus használatával betölthet egy prezentációt anélkül, hogy bármilyen beágyazott bináris objektumot tartalmazna.

Ez a metódus hasznos a potenciálisan rosszindulatú bináris tartalom eltávolításához. Az alábbi Java‑kód bemutatja, hogyan tölthet be egy prezentációt beágyazott bináris tartalom nélkül:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Műveleteket hajtson végre a prezentáción.
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Hogyan deríthetem ki, hogy egy fájl sérült és nem nyitható meg?**

A betöltés során elemzési/fájlformátum‑ellenőrzési kivétel keletkezik. Az ilyen hibák gyakran egy érvénytelen ZIP‑szerkezetre vagy sérült PowerPoint‑rekordokra hivatkoznak.

**Mi történik, ha a megnyitáskor hiányoznak a szükséges betűtípusok?**

A fájl megnyílik, de a későbbi [renderelés/exportálás](/slides/hu/androidjava/convert-presentation/) helyettesítheti a betűtípusokat. [Betűtípus‑helyettesítések beállítása](/slides/hu/androidjava/font-substitution/) vagy a [szükséges betűtípusok hozzáadása](/slides/hu/androidjava/custom-font/) a futási környezethez ajánlott.

**Mi a helyzet a beágyazott médiával (videó/hang), amikor megnyitjuk a prezentációt?**

Médiák a prezentáció erőforrásaiként válnak elérhetővé. Ha a média külső útvonalakra hivatkozik, győződjön meg róla, hogy ezek az útvonalak elérhetők a környezetben; ellenkező esetben a [renderelés/exportálás](/slides/hu/androidjava/convert-presentation/) kihagyhatja a médiát.