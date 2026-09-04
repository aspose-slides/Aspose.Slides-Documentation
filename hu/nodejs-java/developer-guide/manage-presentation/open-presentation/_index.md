---
title: Prezentációk megnyitása JavaScriptben
linktitle: Prezentáció megnyitása
type: docs
weight: 20
url: /hu/nodejs-java/open-presentation/
keywords:
- PowerPoint megnyitása
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat JavaScriptben, adhat meg nyitó jelszavakat, szabályozhatja az erőforrások betöltését, és csökkentheti a memóriahasználatot az Aspose.Slides for Node.js via Java segítségével."
---
## **Bevezetés**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/hu/nodejs-java/) képes PowerPoint és OpenDocument prezentációkat betölteni fájlokból és adatfolyamokból. A prezentáció betöltése után ellenőrizheted a felépítését, szerkesztheted a diákat, kezelheted az erőforrásokat, és mentheted az eredeti vagy egy másik támogatott formátumban.

A betöltési viselkedés testreszabható a [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/) osztály segítségével. Például megadhatsz egy nyitó jelszót, a nagy bináris objektumokat a Node.js memórián kívül tarthatod, szabályozhatod a külső erőforrásokat, vagy elhagyhatod a beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Egy meglévő prezentáció megnyitásához add át a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) konstruktorának. A prezentáció használata után használd a Dispose metódust, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

Az alábbi JavaScript példa bemutatja, hogyan nyithatsz meg egy prezentációt, és hogyan kérheted le a diák számát:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Jelszóval védett prezentációk megnyitása**

A nyitó jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez add át a helyes jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword) metódusnak, és add meg az opciókat a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) konstruktorának. A betöltés sikertelen, ha a jelszó hiányzik vagy helytelen.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

A jelszóészlelés, ellenőrzés és titkosítási munkafolyamatokhoz lásd a [Jelszóval védett prezentációk](/slides/hu/nodejs-java/password-protected-presentation/) oldalt. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentettek, azok a jelszó nélkül is olvashatók; lásd a [Prezentációtulajdonságok kezelése](/slides/hu/nodejs-java/presentation-properties/) oldalt.

## **Nagy prezentációk megnyitása**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) visszaad opciókat, amelyek szabályozzák, hogyan kezeli az Aspose.Slides a bináris nagy objektumokat, mint például képek, hang és videó. A forrásfájlt lezárhatod, engedélyezheted az ideiglenes fájlokat, és korlátozhatod a memóriában megtartott BLOB adatok mennyiségét.

Az alábbi JavaScript kód bemutatja egy nagy prezentáció betöltését (például 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Megjegyzés" %}}
A [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) használatával a forrásfájl zárolva marad, amíg a prezentáció példányát el nem pusztítják. Ne mozgass, ne írj felül, vagy ne törölj forrásfájlt, amíg az példány él.

Az Aspose.Slides a betöltés során másolhatja egy bemeneti adatfolyam tartalmát. Nagy prezentációk esetén a fájl útvonala általában hatékonyabb, mint egy adatfolyam. További tárolási és memória-kezelési lehetőségekért lásd a [BLOB-ok kezelése](/slides/hu/nodejs-java/manage-blob/) oldalt.
{{% /alert %}}

## **Külső erőforrások kezelése**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) elfogad egy [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iresourceloadingcallback/) implementációt. A visszahívás biztosíthat helyettesítő adatot, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja az erőforrást. Ez akkor hasznos, ha a prezentációk külső képeket tartalmaznak, amelyeket az alkalmazás-specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Prezentációk betöltése beágyazott bináris objektumok nélkül**

Egy prezentáció tartalmazhat beágyazott bináris adatot, amelyre egy alkalmazásnak nincs szüksége, vagy nem akarja megtartani. Példák:

- VBA projektek, a [Presentation.getVbaProject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getVbaProject) segítségével érhetők el;
- beágyazott OLE adatok, a [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) segítségével érhetők el;
- ActiveX vezérlő adatok, a [Control.getActiveXControlBinary](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/control/#getActiveXControlBinary) segítségével érhetők el.

A [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) beállításával `true` értékre eltávolíthatod ezeket a bináris adatokat a betöltés során. A betöltött prezentáció mentésével a tisztított eredmény megmarad.

Ez az opció csökkenti a nem kívánt beágyazott terhelések kitettségét, de nem tekinthető teljes kártevő-felderítő vagy tartalomszűrő rendszernek.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Hogyan tudom megállapítani, hogy egy fájl sérült és nem nyitható meg?**

Az Aspose.Slides betöltés közben parsing vagy formátum kivételt dob. Kezeld ezt a hibát külön a helytelen jelszó hibától, hogy az alkalmazás pontosan jelenteni tudja az okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A prezentáció még betölthető, de a megjelenítés és export betűtípus helyettesítést végezhet. A kimenetet jobban megjósolhatóvá teheted a [betűtípus-helyettesítés konfigurálása](/slides/hu/nodejs-java/font-substitution/) vagy a [egyéni betűtípusok biztosítása](/slides/hu/nodejs-java/custom-font/) segítségével.

**A prezentáció betöltése betölti-e a benne lévő beágyazott médiát is?**

A beágyazott hang és videó a prezentáció objektummodelljén keresztül elérhetővé válik. A külső erőforrások a beállított erőforrásbetöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem érhetők el, ha azok helyei nem hozzáférhetők.