---
title: Előadások megnyitása Java-ban
linktitle: Előadás megnyitása
type: docs
weight: 20
url: /hu/java/open-presentation/
keywords:
- PowerPoint megnyitása
- OpenDocument megnyitása
- előadás megnyitása
- PPTX megnyitása
- PPT megnyitása
- ODP megnyitása
- előadás betöltése
- PPTX betöltése
- PPT betöltése
- ODP betöltése
- védett előadás
- nagy előadás
- külső erőforrás
- bináris objektum
- Java
- Aspose.Slides
description: "Nyissa meg könnyedén a PowerPoint (.pptx, .ppt) és OpenDocument (.odp) előadásokat az Aspose.Slides for Java segítségével – gyors, megbízható, teljes körű."
---
## **Bevezetés**

A PowerPoint előadások nulláról való létrehozása mellett az Aspose.Slides lehetővé teszi meglévő előadások megnyitását is. Egy előadás betöltése után információkat kérhet le róla, szerkesztheti a dia tartalmát, új diákat adhat hozzá, eltávolíthatja a meglévőket, és még sok minden mást.

## **Előadások megnyitása**

Egy meglévő előadás megnyitásához hozza létre a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály egy példányát, és adja meg a fájl útvonalát a konstruktorának.

Az alábbi Java példa bemutatja, hogyan nyithat meg egy előadást, és hogyan kérheti le a diák számát:

```java
// Hozza létre a Presentation osztályt, és adja meg a fájl útvonalát a konstruktorában.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Írja ki a prezentációban lévő diák teljes számát.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Jelszóval védett előadások megnyitása**

Ha jelszóval védett előadást kell megnyitnia, adja meg a jelszót a [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/) osztály [setPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) metódusán keresztül a feloldáshoz és betöltéshez. Az alábbi Java kód bemutatja ezt a műveletet:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Végrehajtja a műveleteket a feloldott prezentáción.
} finally {
    presentation.dispose();
}
```

## **Nagy előadások megnyitása**

Az Aspose.Slides lehetőségeket kínál – különösen a [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/) osztály [getBlobManagementOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) metódusát – hogy segítsen nagy előadások betöltésében.

Az alábbi Java kód bemutatja egy nagy előadás (például 2 GB) betöltését:

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Válassza a KeepLocked viselkedést – a prezentáció fájl a teljes élettartamra zárolva marad
// a Presentation példányra, de nem kell betölteni a memóriába vagy ideiglenes fájlba másolni.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // A nagy prezentáció betöltődött és használható, miközben a memóriahasználat alacsony marad.

    // Módosítsa a prezentációt.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Mentse a prezentációt egy másik fájlba. A memóriahasználat alacsonyan marad a művelet során.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Ne tegye ezt! I/O kivétel keletkezik, mivel a fájl zárolva van egészen addig, amíg a presentation objektumot el nem engedi.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Rendben van itt megtenni. A forrásfájl már nem zárolt a presentation objektum által.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Az adatfolyamokkal való munka során felmerülő korlátozások megkerülése érdekében az Aspose.Slides másolhatja a folyamat tartalmát. A nagy előadás adatfolyamból történő betöltése azt eredményezi, hogy az előadás másolódik, ami lassíthatja a betöltést. Ezért, ha nagy előadást kell betölteni, határozottan javasoljuk, hogy a folyamat helyett az előadás fájl útvonalát használja.

Amikor olyan előadást hoz létre, amely nagy objektumokat (videó, hang, nagy felbontású képek stb.) tartalmaz, a memóriafogyasztás csökkentése érdekében használhatja a [BLOB management](/slides/hu/java/manage-blob/) funkciót.
{{%/alert %}}

## **Külső erőforrások kezelése**

Az Aspose.Slides biztosítja az [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iresourceloadingcallback/) interfészt, amely lehetővé teszi a külső erőforrások kezelését. Az alábbi Java kód bemutatja, hogyan használhatja az `IResourceLoadingCallback` interfészt:

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
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
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
        // Hagyjon ki minden más képet.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Előadások betöltése beágyazott bináris objektumok nélkül**

Egy PowerPoint előadás a következő típusú beágyazott bináris objektumokat tartalmazhat:

- VBA projekt (elérhető az [IPresentation.getVbaProject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getVbaProject--)‑on keresztül);
- OLE objektum beágyazott adatok (elérhető az [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--)‑on keresztül);
- ActiveX vezérlő bináris adatok (elérhető az [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)‑on keresztül).

Az [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) metódus használatával betölthet egy előadást beágyazott bináris objektumok nélkül.

Ez a metódus hasznos a potenciálisan rosszindulatú bináris tartalom eltávolításához. Az alábbi Java kód bemutatja, hogyan tölthet be egy előadást beágyazott bináris tartalom nélkül:

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

**Hogyan tudom megállapítani, hogy a fájl sérült és nem nyitható meg?**

A betöltés során egy elemzési/formátum-ellenőrzési kivételt kap. Az ilyen hibák gyakran egy érvénytelen ZIP struktúrát vagy hibás PowerPoint rekordokat említenek.

**Mi történik, ha a megnyitáskor hiányoznak a szükséges betűkészletek?**

A fájl megnyílik, de a későbbi [renderelés/export](/slides/hu/java/convert-presentation/) helyettesítheti a betűkészleteket. [Betűkészlet‑helyettesítések beállítása](/slides/hu/java/font-substitution/) vagy [a szükséges betűkészletek hozzáadása](/slides/hu/java/custom-font/) a futásidejű környezetben.

**Mi van a beágyazott médiával (videó/hang) a megnyitáskor?**

Előadási erőforrásként válnak elérhetővé. Ha a médiát külső útvonalon hivatkozzák, győződjön meg arról, hogy ezek az útvonalak elérhetők a környezetében; különben a [renderelés/export](/slides/hu/java/convert-presentation/) kihagyhatja a médiát.