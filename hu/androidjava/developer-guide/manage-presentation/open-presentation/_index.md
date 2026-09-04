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
description: "Ismerje meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat Androidon, adhat meg nyitó jelszavakat, szabályozhatja az erőforrás betöltését, és csökkentheti a memóriahasználatot az Aspose.Slides for Android via Java segítségével."
---
## **Bevezetés**

Aspose.Slides for Android via Java betöltheti a PowerPoint és OpenDocument bemutatókat fájlokból és adatfolyamokból. A bemutató betöltése után ellenőrizheti a szerkezetét, szerkesztheti a diákot, kezelheti az erőforrásokat, és elmentheti az eredeti vagy egy másik támogatott formátumban.

A betöltési viselkedés testre szabható a LoadOptions osztály segítségével. Például megadhat egy nyitó jelszót, a nagy bináris objektumokat a Java heap memórián kívül tarthatja, szabályozhatja a külső erőforrásokat, vagy kihagyhatja a beágyazott bináris adatokat.

## **Meglévő bemutatók megnyitása**

Egy meglévő bemutató megnyitásához adja át a fájl elérési útját a Presentation konstruktorának. A bemutató használata után szabadítsa fel, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

Az alábbi Java példa bemutatja, hogyan nyithat meg egy bemutatót és hogyan kérdezheti le a dia számát:

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

A nyitó jelszó titkosítja a bemutató tartalmát. A teljes bemutató betöltéséhez adja át a helyes jelszót a LoadOptions.setPassword metódusnak, és adja meg a beállításokat a Presentation konstruktorának. A betöltés hibát jelez, ha a jelszó hiányzik vagy helytelen.

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

A jelszófelismeréssel, érvényesítéssel és titkosítási folyamatokkal kapcsolatban lásd a Jelszóval védett bemutatók oldalt. Ha egy titkosított bemutató tudatosan publikus dokumentumtulajdonságokkal lett mentve, ezek a tulajdonságok jelszó nélkül is olvashatók; lásd a Bemutató tulajdonságok kezelése oldalt.

## **Nagy bemutatók megnyitása**

A LoadOptions.getBlobManagementOptions visszaadja azokat a beállításokat, amelyek szabályozzák, hogyan kezeli az Aspose.Slides a nagy bináris objektumokat, például képeket, hangot és videót. A forrásfájlt lezárhatja, engedélyezheti az ideiglenes fájlokat, és korlátozhatja a memóriában megtartott BLOB adatok mennyiségét.

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
A PresentationLockingBehavior.KeepLocked használatával a forrásfájl zárolt marad, amíg a Presentation példány el nem kerül felszabadításra. Ne mozgassa, írja felül vagy törölje a forrásfájlt, amíg az példány él.

Aspose.Slides a betöltés közben másolhatja egy bemeneti adatfolyam tartalmát. Nagy bemutatók esetén a fájl elérési útja általában hatékonyabb, mint egy adatfolyam. Lásd a BLOB-ok kezelése oldalt a további tárolási és memória-kezelési lehetőségekért.
{{% /alert %}}

## **Külső erőforrások szabályozása**

A LoadOptions.setResourceLoadingCallback egy IResourceLoadingCallback megvalósítást fogad el. A visszahívás biztosíthat helyettesítő adatot, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja az erőforrást. Ez akkor hasznos, ha a bemutatók külső képeket tartalmaznak, amelyeket az alkalmazás-specifikus biztonsági vagy tárolási szabályoknak megfelelően kell feloldani.

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

## **Beágyazott bináris objektumok nélküli bemutatók betöltése**

A bemutató tartalmazhat beágyazott bináris adatokat, amelyekre egy alkalmazásnak nincs szüksége, vagy amelyeket nem kíván megtartani. Példák:

- VBA projektek, az IPresentation.getVbaProject metóduson keresztül érhetők el;
- beágyazott OLE adatok, az IOleEmbeddedDataInfo.getEmbeddedFileData metóduson keresztül;
- ActiveX vezérlő adatok, az IControl.getActiveXControlBinary metóduson keresztül.

Állítsa a LoadOptions.setDeleteEmbeddedBinaryObjects értékét `true`-ra, hogy betöltéskor eltávolítsa ezeket a bináris adatokat. Mentse el a betöltött bemutatót a tisztított eredmény megőrzéséhez.

Ez a beállítás csökkenti a nem kívánt beágyazott terhek kitettségét, de nem egy teljes rosszindulatú szoftver-felderítő vagy tartalom‑tisztító rendszer.

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

Az Aspose.Slides betöltés közben elemzési vagy formátumhibát dob. Kezelje ezt a hibát külön a helytelen jelszó hibától, hogy az alkalmazás pontosan jelenteni tudja a okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A bemutató továbbra is betölthető, de a megjelenítés és az export esetleg helyettesítheti a betűtípusokat. Beállíthatja a betűtípus helyettesítést, vagy megadhat egyedi betűtípusokat, hogy az eredmény előre láthatóbb legyen.

**Betölt egy bemutató a beágyazott médiáját is?**

A beágyazott hang és videó a bemutató objektummodelljén keresztül lesz elérhető. A külső erőforrásokat a beállított erőforrás‑betöltési viselkedés szerint oldják fel, és előfordulhat, hogy nem elérhetők, ha azok helyeihez nem fér hozzá.