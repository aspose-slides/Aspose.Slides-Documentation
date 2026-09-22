---
title: Prezentációk megnyitása Androidon
linktitle: Prezentáció megnyitása
type: docs
weight: 20
url: /hu/androidjava/open-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat Androidon, adjon meg nyitó jelszavakat, szabályozza az erőforrások betöltését, és csökkentse a memóriahasználatot az Aspose.Slides for Android via Java segítségével."
---
## **Bevezetés**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/hu/androidjava/) képes betölteni PowerPoint és OpenDocument prezentációkat fájlokból és adatfolyamból. A prezentáció betöltése után ellenőrizheti a szerkezetét, szerkesztheti a diákot, kezelheti az erőforrásokat, és mentheti az eredeti vagy egy másik támogatott formátumban.

A betöltési viselkedés testreszabható a [LoadOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/) osztályon keresztül. Például megadhat egy nyitó jelszót, tartsa a nagy bináris objektumokat a Java halom memórián kívül, szabályozhatja a külső erőforrásokat, vagy kihagyhatja a beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Fájl vagy adatfolyam betöltése után [meghatározhatja az eredeti prezentáció formátumát](/slides/hu/androidjava/detect-presentation-source-format/) a további feldolgozási mód kiválasztásához.

Egy meglévő prezentáció megnyitásához adja át a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) konstruktorának. A prezentációt használat után szabadítsa fel, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások időben felszabaduljanak.

A következő Java példa bemutatja, hogyan lehet megnyitni egy prezentációt és lekérni a diák számát:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Jelszóval védett prezentációk megnyitása**

A nyitó jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez adja át a helyes jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) metódusnak, és adja meg a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) konstruktorának. A betöltés sikertelen, ha a jelszó hiányzik vagy helytelen.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

A jelszó észleléséhez, validálásához és titkosítási munkafolyamatokhoz lásd a [Password-Protect Presentations](/slides/hu/androidjava/password-protected-presentation/) cikket. Ha egy titkosított prezentációt szándékosan a nyilvános dokumentumtulajdonságokkal mentették, ezek a tulajdonságok jelszó nélkül is olvashatók; lásd a [Manage Presentation Properties](/slides/hu/androidjava/presentation-properties/) cikket.

## **Nagy prezentációk megnyitása**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) visszaadja azokat a beállításokat, amelyek szabályozzák, hogyan kezeli az Aspose.Slides a bináris nagy objektumokat, mint például a képek, audio és videó. Lehet a forrásfájlt zárolt állapotban tartani, engedélyezni az ideiglenes fájlokat, és korlátozni a memóriában megtartott BLOB adatok mennyiségét.

A következő Java kód bemutatja egy nagy prezentáció (például 2 GB) betöltését:

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
A [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked) használatával a forrásfájl zárolva marad, amíg a prezentáció példány nem szabadul fel. Ne mozgassa, írja felül vagy törölje a forrásfájlt, amíg az a példány él.

Az Aspose.Slides a betöltés során másolhatja a bemeneti adatfolyam tartalmát. Nagy prezentációk esetén a fájl útvonal általában hatékonyabb, mint egy adatfolyam. További tárolási és memória‑kezelési lehetőségekért lásd a [Manage BLOBs](/slides/hu/androidjava/manage-blob/) oldalt.
{{% /alert %}}

## **Külső erőforrások vezérlése**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) egy [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iresourceloadingcallback/) implementációt fogad el. A visszahívás képes helyettesítő adatot biztosítani, egy erőforrást átirányítani, az alapértelmezett betöltőt használni, vagy kihagyni az erőforrást. Ez akkor hasznos, ha a prezentációk külső képeket tartalmaznak, amelyeket az alkalmazás‑specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Prezentációk betöltése beágyazott bináris objektumok nélkül**

Egy prezentáció tartalmazhat beágyazott bináris adatokat, amelyekre egy alkalmazásnak nincs szüksége vagy nem kívánja megtartani őket.

- VBA projektek, amelyek a [IPresentation.getVbaProject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) segítségével érhetők el;
- beágyazott OLE adatok, amelyek a [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) segítségével érhetők el;
- ActiveX vezérlő adatok, amelyek a [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) segítségével érhetők el.

Állítsa a [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) értékét `true`‑ra a betöltés során ezeknek a bináris adatoknak az eltávolításához. Mentse el a betöltött prezentációt a tisztított eredmény megőrzéséhez.

Ez a beállítás csökkenti a nem kívánt beágyazott terhek kitettségét, de nem egy teljes rosszindulatú szoftver‑detektáló vagy tartalom‑tisztító rendszer.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Hogyan tudhatom meg, hogy egy fájl megsérült és nem nyitható meg?**

Az Aspose.Slides betöltés közben parsing vagy formátum kivételt dob. Kezelje ezt a hibát külön a helytelen jelszó hibától, hogy az alkalmazás pontosan jelentse a okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A prezentáció továbbra is betölthető, de a megjelenítés és export esetleg betűtípus helyettesítést alkalmaz. Beállíthatja a [configure font substitution](/slides/hu/androidjava/font-substitution/) konfigurálását vagy [provide custom fonts](/slides/hu/androidjava/custom-font/) biztosíthatja, hogy az eredmény kiszámíthatóbb legyen.

**Betölti a prezentáció a beágyazott médiát is?**

A beágyazott audio és videó elérhetővé válik a prezentáció objektummodelljén keresztül. A külső erőforrások a beállított erőforrásbetöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem érhetők el, ha a helyeik nem hozzáférhetők.