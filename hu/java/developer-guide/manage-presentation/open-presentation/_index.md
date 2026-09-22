---
title: "PowerPoint és OpenDocument bemutatók megnyitása Java-ban"
linktitle: "Bemutató megnyitása"
type: docs
weight: 20
url: /hu/java/open-presentation/
keywords:
- "PowerPoint megnyitása"
- "bemutató megnyitása"
- "PPTX megnyitása"
- "PPT megnyitása"
- "ODP megnyitása"
- "bemutató betöltése"
- "PPTX betöltése"
- "PPT betöltése"
- "ODP betöltése"
- "védett bemutató"
- "nagy bemutató"
- "külső erőforrás"
- "bináris objektum"
- "Java"
- "Aspose.Slides"
description: "Tanulja meg, hogyan nyithat meg PowerPoint és OpenDocument bemutatókat Java-ban, adjon meg nyitási jelszavakat, szabályozza az erőforrás betöltését, és csökkentse a memóriahasználatot az Aspose.Slides for Java segítségével."
---
## **Bevezetés**

[Aspose.Slides for Java](https://products.aspose.com/slides/hu/java/) képes PowerPoint és OpenDocument bemutatókat betölteni fájlokból és adatfolyamokból. Miután egy bemutatót betöltöttünk, megvizsgálhatjuk a szerkezetét, szerkeszthetjük a diait, kezelhetjük az erőforrásokat, és menthetjük az eredeti vagy egy másik támogatott formátumban.

A betöltés viselkedését a [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/) osztály segítségével testre szabható. Például megadhat egy nyitási jelszót, nagy bináris objektumokat tarthat a Java heap memórián kívül, szabályozhatja a külső erőforrásokat, vagy kihagyhat beágyazott bináris adatokat.

## **Bemutatók megnyitása**

Fájl vagy adatfolyam betöltése után [meghatározhatja annak eredeti bemutatóformátumát](/slides/hu/java/detect-presentation-source-format/), hogy kiválassza, hogyan dolgozza fel az alkalmazás.

Egy meglévő bemutató megnyitásához adja át a fájl elérési útját a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) konstruktorának. A bemutató használata után szabadítsa fel, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

Az alábbi Java példa bemutatja, hogyan nyisson meg egy bemutatót és hogyan kapja meg a diáinek számát:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Jelszóval védett bemutatók megnyitása**

A nyitási jelszó titkosítja a bemutató tartalmát. A teljes bemutató betöltéséhez adja át a helyes jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) metódusnak, és adja át a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) konstruktorának. A betöltés akkor sikertelen, ha a jelszó hiányzik vagy helytelen.

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

Jelszódetektáláshoz, validáláshoz és titkosítási folyamatokhoz lásd a [Password-Protect Presentations](/slides/hu/java/password-protected-presentation/) oldalt. Ha egy titkosított bemutatót szándékosan mentettek nyilvános dokumentum tulajdonságokkal, azok a jelszó nélkül is olvashatók; lásd a [Manage Presentation Properties](/slides/hu/java/presentation-properties/) oldalt.

## **Nagy bemutatók megnyitása**

A [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) visszaadja azokat a beállításokat, amelyek szabályozzák, hogy az Aspose.Slides hogyan kezeli a nagyméretű bináris objektumokat, például képeket, hangot és videót. A forrásfájlt zárolhatja, engedélyezhet ideiglenes fájlokat, és korlátozhatja a memóriában megtartott BLOB adatok mennyiségét.

Az alábbi Java kód bemutatja egy nagy bemutató (például 2 GB) betöltését:

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
A [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) használatával a forrásfájl zárolva marad, amíg a bemutató példány ki nem lesz adva. Ne mozgassa, írja felül vagy törölje a forrásfájlt, amíg az példány él.

Az Aspose.Slides a betöltés során másolhatja a bemeneti adatfolyam tartalmát. Nagy bemutatók esetén ezért általában a fájl elérési útja hatékonyabb, mint az adatfolyam. További tárolási és memória‑kezelési lehetőségekért tekintse meg a [Manage BLOBs](/slides/hu/java/manage-blob/) oldalt.
{{% /alert %}}

## **Külső erőforrások kezelése**

A [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) elfogad egy [IResourceLoadingCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iresourceloadingcallback/) megvalósítást. A visszahívás helyettesítő adatot szolgáltathat, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja az erőforrást. Ez akkor hasznos, ha a bemutatók külső képeket tartalmaznak, amelyeket az alkalmazás‑specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

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

## **Bemutatók betöltése beágyazott bináris objektumok nélkül**

A bemutató tartalmazhat beágyazott bináris adatokat, amelyeket az alkalmazás nem igényel vagy nem akar megőrizni. Példák:

- VBA projektek, a [IPresentation.getVbaProject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getVbaProject--) segítségével érhetők el;
- beágyazott OLE adatok, a [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) segítségével érhetők el;
- ActiveX vezérlő adatok, a [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) segítségével érhetők el.

Állítsa a [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) értékét `true`‑ra, hogy a betöltés során eltávolítsa ezeket a bináris adatokat. Mentse el a betöltött bemutatót, hogy a tisztított eredményt megőrizze.

Ez a beállítás csökkenti a nem kívánt beágyazott terhek kitettségét, de nem egy teljes rosszindulatú szoftver‑detektálási vagy tartalom‑tisztítási rendszer.

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

Az Aspose.Slides betöltés közben parse vagy formátum kivételt dob. Kezelje ezt a hibát külön a helytelen jelszó hibától, hogy az alkalmazás pontosan jelenteni tudja az okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A bemutató továbbra is betölthető, de a megjelenítés és az export helyettesítheti a betűtípusokat. A [betűtípus helyettesítésének beállítása](/slides/hu/java/font-substitution/) vagy a [egyedi betűtípusok biztosítása](/slides/hu/java/custom-font/) segítségével előrejelezhetőbbé teheti a kimenetet.

**A bemutató betöltése során beágyazott média is betöltődik?**

A beágyazott hang és videó elérhetővé válik a bemutató objektummodelljén keresztül. A külső erőforrások a konfigurált erőforrásbetöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem érhetők el, ha a helyeik nem hozzáférhetők.