---
title: "Prezentációk megnyitása JavaScriptben"
linktitle: "Prezentáció megnyitása"
type: docs
weight: 20
url: /hu/nodejs-java/open-presentation/
keywords:
- "PowerPoint megnyitása"
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
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Tanulja meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat JavaScriptben, adhat meg nyitó jelszavakat, szabályozhatja az erőforrások betöltését, és csökkentheti a memóriahasználatot az Aspose.Slides for Node.js via Java segítségével."
---
## **Bevezetés**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/hu/nodejs-java/) betöltheti a PowerPoint és OpenDocument prezentációkat fájlokból és adatfolyamokból. Miután a prezentáció betöltődött, ellenőrizheti annak felépítését, szerkesztheti a diákot, kezelheti az erőforrásokat, és elmentheti az eredeti vagy egy másik támogatott formátumban.

A betöltési viselkedés testreszabható a [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/) osztály segítségével. Például megadhat egy nyitó jelszót, nagy bináris objektumokat tarthat a Node.js memória kívül, szabályozhatja a külső erőforrásokat, vagy kihagyhat beágyazott bináris adatokat.

## **Megnyitott prezentációk**

Fájl vagy adatfolyam betöltése után [meghatározhatja az eredeti prezentáció formátumát](/slides/hu/nodejs-java/detect-presentation-source-format/), hogy kiválassza, hogyan dolgozza fel az alkalmazás.

Egy meglévő prezentáció megnyitásához adja át a fájl elérési útját a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) konstruktorának. Használat után szabadítsa fel a prezentációt, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

Az alábbi JavaScript példa bemutatja, hogyan nyisson meg egy prezentációt és szerezze meg a diák számát:

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

A nyitó jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez adja át a helyes jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword) metódusnak, és adja meg a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) konstruktorának. A betöltés sikertelen, ha a jelszó hiányzik vagy helytelen.

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

A jelszó felismerésével, ellenőrzésével és titkosítási folyamatokkal kapcsolatban lásd a [Password-Protect Presentations](/slides/hu/nodejs-java/password-protected-presentation/) oldalt. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentettek, ezek a tulajdonságok jelszó nélkül is olvashatók; lásd a [Manage Presentation Properties](/slides/hu/nodejs-java/presentation-properties/) részt.

## **Nagy prezentációk megnyitása**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) visszaadja azokat a beállításokat, amelyek szabályozzák, hogyan kezeli az Aspose.Slides a bináris nagy objektumokat, például képeket, hangot és videót. A forrásfájlt lezárhatja, engedélyezhet ideiglenes fájlokat, és korlátozhatja a memóriában megtartott BLOB adat mennyiségét.

Az alábbi JavaScript kód bemutatja egy nagy prezentáció (például 2 GB) betöltését:

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

{{% alert color="info" title="Note" %}}
A [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) használatával a forrásfájl zárolva marad, amíg a prezentáció példányát fel nem szabadítják. Ne mozgassa, írja felül vagy törölje a forrásfájlt, amíg ez a példány él.

Az Aspose.Slides betöltéskor másolhatja egy bemeneti adatfolyam tartalmát. Nagy prezentációk esetén a fájl elérési útja általában hatékonyabb, mint egy adatfolyam. Lásd a [Manage BLOBs](/slides/hu/nodejs-java/manage-blob/) oldalt további tárolási és memória‑kezelési lehetőségekért.
{{% /alert %}}

## **Külső erőforrások kezelése**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) egy [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iresourceloadingcallback/) megvalósítást fogad el. A visszahívás biztosíthat helyettesítő adatot, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja az erőforrást. Ez akkor hasznos, ha a prezentációk külső képeket tartalmaznak, amelyeket az alkalmazás‑specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

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

Egy prezentáció tartalmazhat beágyazott bináris adatot, amelyre az alkalmazásnak nincs szüksége, vagy amelyet nem kíván megtartani. Példák:

- VBA projektek, elérhetők a [Presentation.getVbaProject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getVbaProject) segítségével;
- beágyazott OLE adatok, elérhetők a [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) segítségével;
- ActiveX vezérlő adatok, elérhetők a [Control.getActiveXControlBinary](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/control/#getActiveXControlBinary) segítségével.

Állítsa a [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) értékét `true`‑ra, hogy betöltés közben eltávolítsa ezt a bináris adatot. Mentse a betöltött prezentációt a tisztított eredmény megőrzéséhez.

Ez a beállítás csökkenti a nem kívánt beágyazott terheknek való kitettséget, de nem egy teljes rosszindulatú szoftver‑detektáló vagy tartalom‑szűrő rendszer.

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

**Hogyan tudom, hogy egy fájl sérült és nem nyitható meg?**

Az Aspose.Slides betöltés közben parsing vagy formátum kivételt dob. Kezelje ezt a hibát külön a helytelen jelszó hibától, hogy az alkalmazás pontosan jelenteni tudja az okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A prezentáció még betölthető, de a renderelés és exportálás helyettesítő betűtípusokat használhat. A [betűtípus‑helyettesítés konfigurálása](/slides/hu/nodejs-java/font-substitution/) vagy a [egyedi betűtípusok biztosítása](/slides/hu/nodejs-java/custom-font/) segítségével a kimenet előrejelezhetőbbé tehető.

**Betölt egy prezentációt, betölti-e a beágyazott médiaelemeket is?**

A beágyazott hang és videó a prezentáció objektummodelljén keresztül elérhetővé válik. A külső erőforrások a konfigurált erőforrásbetöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem érhetők el, ha a helyeikhez nem férnek hozzá.