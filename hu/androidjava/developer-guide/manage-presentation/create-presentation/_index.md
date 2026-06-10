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
description: "Prezentációk létrehozása Java nyelven az Aspose.Slides for Android segítségével - PPT, PPTX és ODP fájlok készítése, az OpenDocument támogatás kihasználása, és programozott mentés megbízható eredményekért."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre egy bemutatót az Aspose.Slides-ban, hogyan adhatunk egyszerű tartalmat egy diára, és hogyan menthetjük az eredményt fájlként. Továbbá megmutatja, hogyan hozhatunk létre és menthetünk egy új bemutatót, hogyan nyithatunk meg egy meglévő, támogatott formátumú bemutatót, és hogyan menthetjük egy másik formátumba.

## **PowerPoint bemutató létrehozása**
Egyszerű egyenes vonal hozzáadásához a bemutató kiválasztott diájához, kövesse az alábbi lépéseket:

1. Hozzon létre egy Presentation osztály példányt.
2. Szerezze meg egy dia referenciaját az Index használatával.
3. Egy Line típusú AutoShape-et adjon hozzá az addAutoShape metódussal, amely a Shapes objektum részét képezi.
4. Írja a módosított bemutatót PPTX fájlként.

Az alábbi példában egy vonalat adtunk hozzá a bemutató első diájához.

```java
// Hozzon létre egy Presentation objektumot, amely egy bemutatófájlt képvisel
Presentation pres = new Presentation();
try {
    // Szerezze meg az első diát
    ISlide slide = pres.getSlides().get_Item(0);

    // Adjon hozzá egy vonal típusú autoalakzatot
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Milyen formátumokba menthetem el az új bemutatót?**

Menthet [PPTX, PPT, és ODP](/slides/hu/androidjava/save-presentation/), és exportálhat [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/hu/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/hu/androidjava/convert-powerpoint-to-html/), [SVG](/slides/hu/androidjava/convert-powerpoint-to-png/), valamint [images](/slides/hu/androidjava/convert-powerpoint-to-png/) formátumba, többek között.

**Kezdhetek sablonból (POTX/POTM) és menthetem szabályos PPTX-ként?**

Igen. Töltse be a sablont, és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/androidjava/supported-file-formats/).

**Hogyan szabályozhatom a dia méretét/méretarányát a bemutató létrehozásakor?**

Állítsa be a [slide size](/slides/hu/androidjava/slide-size/) (beleértve a 4:3, 16:9 előre beállított méreteket vagy egyedi méreteket), és válassza ki, hogyan skálázódjon a tartalom.

**Milyen egységekben mérik a méreteket és koordinátákat?**

Pontokban: 1 hüvelyk 72 egységnek felel meg.

**Hogyan kezelem a nagyon nagy bemutatókat (sok médiafájllal) a memóriahasználat csökkentése érdekében?**

Használjon [BLOB management strategies](/slides/hu/androidjava/manage-blob/), korlátozza a memóriában tárolt adatot ideiglenes fájlok használatával, és részesítse előnyben a fájlalapú munkafolyamatokat a kizárólag memóriában lévő adatfolyamok helyett.

**Létrehozhatok/menthetek bemutatókat párhuzamosan?**

Nem működik ugyanazon [Presentation](/slides/hu/androidjava/presentation/) példányon több [multiple threads](/slides/hu/androidjava/multithreading/) egyidejűleg. Indítson külön, elszigetelt példányokat szálanként vagy folyamanként.

**Hogyan távolíthatom el a próbaverzió vízjelet és korlátozásokat?**

[Apply a license](/slides/hu/androidjava/licensing/) egyszer egy folyamatban. A licenc XML-nek változatlanul kell maradnia, és a licenc beállítást szinkronizálni kell, ha több szál vesz részt.

**Aláírhatom digitálisan a létrehozott PPTX-et?**

Igen. A [Digital signatures](/slides/hu/androidjava/digital-signature-in-powerpoint/) (hozzáadás és ellenőrzés) támogatott a bemutatókhoz.

**Támogatottak-e a makrók (VBA) a létrehozott bemutatókban?**

Igen. [create/edit VBA projects](/slides/hu/androidjava/presentation-via-vba/) és makrókkal rendelkező fájlok, például PPTM/PPSM, mentése lehetséges.