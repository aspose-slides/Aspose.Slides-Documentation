---
title: Bemutatók létrehozása Java-ban
linktitle: Bemutató létrehozása
type: docs
weight: 10
url: /hu/java/create-presentation/
keywords:
- bemutató létrehozása
- új bemutató
- PPT létrehozása
- új PPT
- PPTX létrehozása
- új PPTX
- ODP létrehozása
- új ODP
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Készítsen bemutatókat Java-ban az Aspose.Slides segítségével - állítson elő PPT, PPTX és ODP fájlokat, élvezze az OpenDocument támogatást, és mentse őket programozottan a megbízható eredményekért."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre egy bemutatót az Aspose.Slides-ban, hogyan adhatunk egyszerű tartalmat egy diára, és hogyan menthetjük el az eredményt fájlként. Emellett ismerteti, hogyan hozhatunk létre és menthetünk egy új bemutatót, hogyan nyithatunk meg egy meglévő, támogatott formátumú bemutatót, és hogyan menthetjük át egy másik formátumba. Továbbá a cikk egy rövid GYIK-ot tartalmaz a formátumokra, sablonokra, dia méretezésre, egységekre, memóriahasználatra, szálkezelésre, licencelésre, digitális aláírásokra és VBA támogatásra vonatkozó gyakori kérdésekkel.

## **Bemutató létrehozása**

A PowerPoint-fájl üresen való létrehozása az Aspose.Slides for Java-ban olyan egyszerű, mint a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály példányosítása. A konstruktor automatikusan egy üres előadást ad egyetlen diával, így azonnal rendelkezünk egy vászonnal formák, szöveg, diagramok vagy egyéb, az alkalmazásunk által igényelt tartalom elhelyezéséhez. Miután módosítjuk azt a diát – vagy újakat adunk hozzá – az eredményt elmenthetjük PPTX, régi PPT vagy akár OpenDocument formátumban is. Az alábbi rövid kódrészlet szemlélteti ezt a munkafolyamatot egy egyszerű alakzat első diára való hozzáadásával.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezze be a dia hivatkozását az indexe alapján.
1. Adjunk hozzá egy `Cloud` típusú [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumot az `addAutoShape` metódussal, amely a `Shapes` gyűjtemény része.
1. Adjunk szöveget az automatikus alakzathoz.
1. Mentse el a módosított bemutatót PPTX fájlként.

Az alábbi példában egy felhő alakzat kerül hozzáadásra a bemutató első diájához.

```java
// Példányosítsa a Presentation osztályt, amely egy bemutatófájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Cloud típusú automatikus alakzatot.
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // Mentse a bemutatót PPTX fájlként.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az új bemutató](new_presentation.png)

## **GYIK**

**Milyen formátumokba menthetem el az új bemutatót?**

Elmenthet a [PPTX, PPT és ODP](/slides/hu/java/save-presentation/) formátumokba, valamint exportálhat [PDF](/slides/hu/java/convert-powerpoint-to-pdf/), [XPS](/slides/hu/java/convert-powerpoint-to-xps/), [HTML](/slides/hu/java/convert-powerpoint-to-html/), [SVG](/slides/hu/java/convert-powerpoint-to-png/) és [képek](/slides/hu/java/convert-powerpoint-to-png/) formátumokba, többek között.

**Kiindulhatok sablonból (POTX/POTM), és menthetem regu­lá­ris PPTX‑ként?**

Igen. Töltse be a sablont, és mentse el a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/java/supported-file-formats/).

**Hogyan szabályozhatom a dia méretét/méretarányát bemutató létrehozásakor?**

Állítsa be a [slide size](/slides/hu/java/slide-size/)‑t (beleértve az előre definiált 4:3 és 16:9 arányokat vagy egyéni méreteket), és válassza ki, hogyan skálázódjon a tartalom.

**Milyen egységben mérik a méreteket és a koordinátákat?**

Pontban: 1 hüvelyk = 72 egység.

**Hogyan kezeljem a nagyon nagy bemutatókat (számos médiafájllal) a memóriahasználat csökkentése érdekében?**

Használjon [BLOB management strategies](/slides/hu/java/manage-blob/)‑t, korlátozza a memóriában tárolt adatot átmeneti fájlokkal, és részesítse előnyben a fájl‑alapú munkafolyamatokat a kizárólag memóriában történő adatfolyamok helyett.

**Létrehozhatok vagy menthetek bemutatókat párhuzamosan?**

Nem működtethet ugyanazon [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt több [thread](/slides/hu/java/multithreading/)‑ből. Futtasson külön, elszigetelt példányokat szálanként vagy folyamatként.

**Hogyan távolíthatom el a próbaverzió vízjelet és korlátozásait?**

[Apply a license](/slides/hu/java/licensing/) egyszer a folyamatban. A licenc XML‑nek módosítatlanul kell maradnia, és a licenc beállítást szinkronizálni kell, ha több szál is használja.

**Digitálisan aláírhatom a létrehozott PPTX‑et?**

Igen. A [Digital signatures](/slides/hu/java/digital-signature-in-powerpoint/) (létrehozás és ellenőrzés) támogatott a bemutatókhoz.

**Támogatottak a makrók (VBA) a létrehozott bemutatókban?**

Igen. [Create/edit VBA projects](/slides/hu/java/presentation-via-vba/)‑t végezhet, és menthet makró‑engedélyezett fájlokat, például PPTM/PPSM.