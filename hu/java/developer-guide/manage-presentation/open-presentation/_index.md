---
title: Prezentációk megnyitása Java-ban
linktitle: Prezentáció megnyitása
type: docs
weight: 20
url: /hu/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat Java-ban, adhat meg nyitó jelszavakat, szabályozhatja az erőforrások betöltését, és csökkentheti a memóriahasználatot az Aspose.Slides for Java segítségével."
---
## **Bevezetés**

[Aspose.Slides for Java](https://products.aspose.com/slides/hu/java/) képes PowerPoint és OpenDocument prezentációkat betölteni fájlokból és adatfolyamokból. Miután egy prezentáció betöltésre került, ellenőrizheted a felépítését, szerkesztheted a diákat, kezelheted az erőforrásokat, és mentheted az eredeti vagy egy másik támogatott formátumban.

A betöltési viselkedés testreszabható a [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/) osztály segítségével. Például megadhatsz egy nyitó jelszót, a nagy bináris objektumokat a Java halom memóriáján kívül tarthatod, szabályozhatod a külső erőforrásokat, vagy kihagyhatod a beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Egy meglévő prezentáció megnyitásához add át a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) konstruktorának. Használat után szabadítsd fel a prezentációt, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

Az alábbi Java példa bemutatja, hogyan nyithatsz meg egy prezentációt és szerezheted meg a diák számát:

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

A nyitó jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez add át a helyes jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) metódusnak, és add meg a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) konstruktorának. A betöltés sikertelen, ha a jelszó hiányzik vagy helytelen.

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

A jelszófelismeréssel, -ellenőrzéssel és titkosítási munkafolyamatokkal kapcsolatban lásd a [Password-Protect Presentations](/slides/hu/java/password-protected-presentation/) oldalt. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentették, ezek a tulajdonságok jelszó nélkül is olvashatók; lásd a [Manage Presentation Properties](/slides/hu/java/presentation-properties/) oldalt.

## **Nagy prezentációk megnyitása**

A [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) visszaadja azokat a beállításokat, amelyek szabályozzák, hogyan kezeli az Aspose.Slides a bináris nagy objektumokat, például képeket, hangot és videót. A forrásfájlt lezárhatod, engedélyezheted az ideiglenes fájlokat, és korlátozhatod a memóriában megtartott BLOB adatok mennyiségét.

Az alábbi Java kód bemutatja egy nagy prezentáció betöltését (például 2 GB):

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

{{% alert color="info" title="Megjegyzés" %}}
A [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) használatával a forrásfájl zárolva marad, amíg a prezentáció példány ki nem kerül állapotba (dispose). Ne mozgass, ne írj felül, és ne töröld a forrásfájlt, amíg ez a példány él.

Az Aspose.Slides betöltés közben másolhatja egy bemeneti adatfolyam tartalmát. Nagy prezentációk esetén a fájl útvonala általában hatékonyabb, mint egy adatfolyam. További tárolási és memória-kezelési lehetőségekért lásd a [Manage BLOBs](/slides/hu/java/manage-blob/) oldalt.
{{% /alert %}}

## **Külső erőforrások vezérlése**

A [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) egy [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iresourceloadingcallback/) implementációt fogad el. A visszahívás biztosíthat helyettesítő adatot, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja az erőforrást. Ez akkor hasznos, ha a prezentációk külső képeket tartalmaznak, amelyeket az alkalmazás-specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

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

Egy prezentáció tartalmazhat beágyazott bináris adatokat, amelyeket az alkalmazás nem igényel vagy nem akar megőrizni. Példák:

- VBA projektek, amelyek elérhetők a [IPresentation.getVbaProject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getVbaProject--) segítségével;
- beágyazott OLE adatok, amelyek elérhetők a [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) segítségével;
- ActiveX vezérlő adatok, amelyek elérhetők a [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) segítségével.

Állítsd a [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) értékét `true`-ra, hogy a betöltés során eltávolítsd ezeket a bináris adatokat. Mentsd el a betöltött prezentációt, hogy megőrizd a tisztított eredményt.

Ez a beállítás csökkenti a nem kívánt beágyazott terhek kitettségét, de nem jelent teljes víruskereső vagy tartalomszűrő rendszert.

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

**Hogyan tudom megállapítani, hogy egy fájl sérült és nem nyitható meg?**

Az Aspose.Slides a betöltés során elemzési vagy formátumkivételt dob. Kezeld ezt a hibát külön a helytelen jelszó hibától, hogy az alkalmazás pontosan jelenteni tudja a okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A prezentáció továbbra is betölthető, de a megjelenítés és exportálás esetén a rendszer helyettesítő betűtípusokat használhat. A kimenet előrejelezhetőségének javításához a [betűtípus-helyettesítés konfigurálása](/slides/hu/java/font-substitution/) vagy az [egyedi betűtípusok biztosítása](/slides/hu/java/custom-font/) lehetőségeket veheted igénybe.

**Betölti-e a prezentáció a beágyazott médiát is?**

A beágyazott hang és videó a prezentáció objektummodelljén keresztül lesz elérhető. A külső erőforrások a konfigurált erőforrásbetöltési viselkedés alapján kerülnek feloldásra, és előfordulhat, hogy nem elérhetők, ha azok helyei nem hozzáférhetők.