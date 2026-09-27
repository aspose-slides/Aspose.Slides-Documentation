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
description: "Készítsen bemutatókat Java-ban az Aspose.Slides használatával – állítson elő PPT, PPTX és ODP fájlokat, élvezze az OpenDocument támogatást, és mentse őket programozottan a megbízható eredmények érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhat létre bemutatót az Aspose.Slides-ban, hogyan adhat hozzá szöveges alakzatot az első diájához, és hogyan mentheti az eredményt PPTX fájlként. Egy meglévő bemutató megnyitásához és egy másik formátumba mentéséhez lásd [Open Presentations](/slides/hu/java/open-presentation/) és [Save Presentations](/slides/hu/java/save-presentation/). A végén található rövid FAQ (Gyakran Ismételt Kérdések) a formátumokra, sablonokra, dia méretezésre, mértékegységekre, memóriahasználatra, szálkezelésre, licencelésre, digitális aláírásokra és VBA támogatásra vonatkozó gyakori kérdéseket tárgyalja.

Mielőtt elkezdené, adja hozzá az Aspose.Slides for Java-t a projektjéhez az Aspose Maven tárolójából. A Maven beállításhoz és a Linuxhoz szükséges további információkért lásd [Installation](/slides/hu/java/installation/).

## **Bemutató létrehozása**

PowerPoint fájl létrehozása a semmiből az Aspose.Slides for Java-ban egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztály példányával kezdődik. A konstruktor egy üres bemutatót biztosít egyetlen diával, amely készen áll alakzatokra, szövegre, diagramokra vagy bármilyen egyéb tartalomra, amelyre az alkalmazásának szüksége van. Miután módosítja azt a diát, vagy újakat ad hozzá, elmentheti az eredményt PPTX, régi PPT vagy OpenDocument formátumokba.

A bemutató létrehozásához és egy szöveges alakzat hozzáadásához az első diához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból. Egy új bemutató már tartalmaz egy üres diát.
2. Szerezze meg azt a diát a 0 indexével a [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) által visszaadott gyűjteményből.
3. Adjon hozzá egy `Cloud` típusú [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alakzatot az [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) metódussal, és állítsa be a szövegét a [setText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#setText-java.lang.String-) metódussal.
4. Mentse a bemutatót PPTX fájlként a [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódussal.

Az alábbi példa egy teljes program. A [Installation](/slides/hu/java/installation/) Maven projektben mentse el *src/main/java/HelloSlides.java* néven, és futtassa a `mvn compile exec:java` parancsot.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Hozzon létre egy bemutatót. Már tartalmaz egy üres diát.
        Presentation presentation = new Presentation();
        try {
            // Az első diát kapjuk meg.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Adjunk hozzá egy felhő alakzatot, és tegyük bele a szöveget.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Mentse a bemutatót PPTX fájlként.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

A felhő bal felső sarkának koordinátái 20 pont a bal szélétől és 20 pont a felső szélétől a dián, az alakzat szélessége 200 pont, magassága 80 pont. A program *new_presentation.pptx*-t ment egy diával, amely a felhőt és a szövegét tartalmazza. Licenc nélkül az Aspose.Slides minden mentett diára egy értékelési vízjelet helyez, lásd [Licensing](/slides/hu/java/licensing/).

Az eredmény:

![Az új bemutató](new_presentation.png)

## **GYIK**

### Milyen formátumokba menthetem az új bemutatót?

Menthet [PPTX, PPT, and ODP](/slides/hu/java/save-presentation/) formátumokba, és exportálhat [PDF](/slides/hu/java/convert-powerpoint-to-pdf/), [XPS](/slides/hu/java/convert-powerpoint-to-xps/), [HTML](/slides/hu/java/convert-powerpoint-to-html/), [SVG](/slides/hu/java/render-a-slide-as-an-svg-image/) és [images](/slides/hu/java/convert-powerpoint-to-png/) formátumokba, többek között.

### Kezdhetek egy sablonból (POTX/POTM), és menthetem szabályos PPTX-ként?

Igen. Töltse be a sablont, és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [are supported](/slides/hu/java/supported-file-formats/).

### Hogyan szabályozhatom a dia méretét/méretarányát a bemutató létrehozásakor?

Állítsa be a [slide size](/slides/hu/java/slide-size/) (beleértve az előre definiált 4:3 és 16:9 beállításokat vagy egyedi méreteket), és válassza ki, hogyan méreteződjön a tartalom.

### Milyen mértékegységben vannak megadva a méretek és koordináták?

Pontban: 1 hüvelyk = 72 egység.

### Hogyan kezeljem a nagyon nagy bemutatókat (sok médiafájl) a memóriahasználat csökkentése érdekében?

Használja a [BLOB management strategies](/slides/hu/java/manage-blob/), korlátozza a memóriában tárolást ideiglenes fájlok használatával, és részesítse előnyben a fájl alapú munkafolyamatokat a kizárólag memóriában lévő adatfolyamok helyett.

### Létrehozhatok/menthetek bemutatókat párhuzamosan?

Nem működtethet egyetlen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) példányt több [multiple threads](/slides/hu/java/multithreading/) szálról. Futtasson külön, elszigetelt példányokat szálanként vagy folyamatként.

### Hogyan távolíthatom el a próba vízjelet és a korlátozásokat?

[Apply a license](/slides/hu/java/licensing/) egyszer a folyamatban. A licenc XML‑nek módosítatlanul kell maradnia, és a licenc beállítást szinkronizálni kell, ha több szál is részt vesz.

### Digitálisan aláírhatom a létrehozott PPTX‑et?

Igen. A [Digital signatures](/slides/hu/java/digital-signature-in-powerpoint/) (hozzáadás és ellenőrzés) támogatott a bemutatókhoz.

### Támogatottak a makrók (VBA) a létrehozott bemutatókban?

Igen. Készíthet/szerkeszthet [VBA projects](/slides/hu/java/presentation-via-vba/) és menthet makró‑engedélyezett fájlokat, például PPTM/PPSM formátumban.