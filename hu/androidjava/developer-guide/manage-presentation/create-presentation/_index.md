---
title: Prezentációk létrehozása Androidon
linktitle: Prezentáció létrehozása
type: docs
weight: 10
url: /hu/androidjava/create-presentation/
keywords:
- prezentáció létrehozása
- új prezentáció
- PPT létrehozása
- új PPT
- PPTX létrehozása
- új PPTX
- ODP létrehozása
- új ODP
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Prezentációk létrehozása Java nyelven az Aspose.Slides for Android segítségével—PPT, PPTX és ODP fájlok előállítása, az OpenDocument támogatás kihasználása, és a programozott mentés megbízható eredményekért."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhat létre prezentációt az Aspose.Slides for Android segítségével Java nyelven, hogyan adhat szövegdobozt az első diára, és hogyan mentheti az eredményt fájlként az alkalmazás tárolójába. Egy meglévő prezentáció megnyitásához vagy más formátumban való mentéséhez lásd a [Open Presentation](/slides/hu/androidjava/open-presentation/) és a [Save Presentation](/slides/hu/androidjava/save-presentation/) oldalakat. A végén egy rövid GYIK szerepel, amely a formátumokkal, sablonokkal, diaméretezéssel, egységekkel, memóriahasználattal, szálkezeléssel, licenceléssel, digitális aláírásokkal és a VBA támogatással kapcsolatos gyakori kérdéseket tárgyalja.

Mielőtt elkezdené, adja az Aspose.Slides-et az Android projektjéhez az Aspose Maven tárolójából. Lásd a [Telepítés](/slides/hu/androidjava/install-aspose-slides-for-android-via-java/).

## **PowerPoint Prezentáció Létrehozása**

PowerPoint prezentáció létrehozásához és szövegdoboz elhelyezéséhez az első dián, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból. Egy új prezentáció már tartalmaz egy üres diát.
2. Szerezze meg azt a diát a [slide collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/) gyűjteményből indexével, 0.
3. Tegyen hozzá egy téglalapot a [addAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) módszerrel a [shape collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/) segítségével, és állítsa be szövegét a [text frame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) segítségével a [setText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) módszerrel.
4. Mentse a prezentációt PPTX fájlként a [save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) módszerrel, a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/) formátumban.

A kód egy `Activity`-ben fut, például annak `onCreate` metódusában. A fájlt a [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) metódus által visszaadott könyvtárba menti: az alkalmazás privát tárolójába, amelybe engedélykérés nélkül írhat.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A téglalap bal felső sarka 50 ponttal van a dia bal szélétől és 50 ponttal a felső szélétől; a téglalap szélessége 400 pont, magassága 100 pont. A mentett fájl egy diát tartalmaz, amely a téglalapot és a szövegét is tartalmazza. Licenc nélkül az Aspose.Slides minden mentett diára egy értékelő vízjelet helyez; lásd a [Licensing](/slides/hu/androidjava/licensing/) oldalt.

A fájl megtekintéséhez nyissa meg az Android Studio [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) eszközét, és keresse meg a *hello.pptx* fájlt a *data/data/* alatt, az alkalmazás *files* mappájában. Egy valódi alkalmazásban a prezentációkat egy háttérszálon dolgozza fel, hogy a felhasználói felület válaszkész maradjon.

## **GYIK**

### Milyen formátumokba menthetem az új prezentációt?

Menthet [PPTX, PPT és ODP](/slides/hu/androidjava/save-presentation/) formátumokba, valamint exportálhat [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/hu/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/hu/androidjava/convert-powerpoint-to-html/), [SVG](/slides/hu/androidjava/render-a-slide-as-an-svg-image/) és [képek](/slides/hu/androidjava/convert-powerpoint-to-png/) formátumokba, többek között.

### Kezdhetek sablonból (POTX/POTM), és menthetem szabályos PPTX-ként?

Igen. Töltsük be a sablont, és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatott](/slides/hu/androidjava/supported-file-formats/).

### Hogyan szabályozhatom a diák méretét/méretarányát prezentáció létrehozásakor?

Állítsa be a [slide size](/slides/hu/androidjava/slide-size/) (beleértve az 4:3 és 16:9 előbeállításokat vagy egyedi méreteket), és válassza ki, hogyan méreteződjön a tartalom.

### Milyen egységben mérik a méreteket és a koordinátákat?

Pontban: 1 hüvelyk 72 egységnek felel meg.

### Hogyan kezeljek nagyon nagy prezentációkat (sok médiafájllal) a memóriahasználat csökkentése érdekében?

Használjon [BLOB management strategies](/slides/hu/androidjava/manage-blob/) stratégiákat, korlátozza a memóriában tárolt adatot ideiglenes fájlok használatával, és részesítse előnyben a fájl-alapú munkafolyamatokat a kizárólag memóriában lévő adatfolyamok helyett.

### Létrehozhatok/menthetek prezentációkat párhuzamosan?

Nem lehet ugyanazon a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányon [multiple threads](/slides/hu/androidjava/multithreading/) párhuzamosan dolgozni. Futtasson külön, izolált példányokat szálanként vagy folyamatanként.

### Hogyan távolíthatom el a próba vízjelet és a korlátozásokat?

[Apply a license](/slides/hu/androidjava/licensing/) egyszer egy folyamatban. A licenc XML-nek változatlanul kell maradnia, és a licenc beállítást szinkronizálni kell, ha több szál is érintett.

### Alá tudom-e digitálisan aláírni a létrehozott PPTX-et?

Igen. A [Digital signatures](/slides/hu/androidjava/digital-signature-in-powerpoint/) (hozzáadás és ellenőrzés) támogatott a prezentációkhoz.

### Támogatottak a makrók (VBA) a létrehozott prezentációkban?

Igen. [create/edit VBA projects](/slides/hu/androidjava/presentation-via-vba/) és menthet makróval ellátott fájlokat, mint a PPTM/PPSM.