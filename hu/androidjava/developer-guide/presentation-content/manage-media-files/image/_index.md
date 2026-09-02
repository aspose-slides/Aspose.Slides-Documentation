---
title: "Optimalizálja a képek kezelését prezentációkban Androidon"
linktitle: "Képek kezelése"
type: docs
weight: 10
url: /hu/androidjava/image/
keywords:
- "kép hozzáadása"
- "kép beszúrása"
- "kép cseréje"
- "képgyűjtemény"
- "képkocka"
- "kapcsolt kép"
- "háttér"
- "PNG hozzáadása"
- "JPG hozzáadása"
- "SVG hozzáadása"
- "SVG alakzatokká"
- "külső SVG erőforrások"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Ismerje meg, hogyan adhat hozzá, újrahasználhat, kapcsolhat, cserélhet és kezelhet raszteres és SVG képeket PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android via Java segítségével."
---
## **Bevezetés**

Aspose.Slides for Android via Java többféle módot biztosít a képek kezelésére, és mindegyik más célra szolgál. Egy képet tárolhat a prezentációban, megjelenítheti egy képkockában, háttérként használhatja a dián, külső képhez kapcsolódhat, helyettesítheti a megosztott kép erőforrást, vagy SVG tartalmat alakíthat át szerkeszthető alakzatokká.

Ez a cikk a kép erőforrásokra és azok használatára a prezentáción belül összpontosít. A képkivágásra, átlátszóságra, effektusokra, nyújtásra és egyéb formázásokra, amelyeket egyedi képkockára alkalmaznak, lásd [Picture Frame](/slides/hu/androidjava/picture-frame/).

## **Értse meg a képmodellt**

A következő API-konceptusok szorosan kapcsolódnak, de nem cserélhetők fel:

- A [presentation image collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagecollection/) a prezentáció által használt kép erőforrásokat tárolja. Használja a [ImageCollection.addImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imagecollection/) metódust képadatok hozzáadásához, és kap egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) erőforrást.
- A [picture frame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) egy alakzat, amely képet jelenít meg egy dián, elrendezésen vagy mesteren. Használja az [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/) metódust egy kép erőforrás elhelyezéséhez a dián.
- A dia háttér képet használ a dia kitöltésének részeként, nem alakzatként. Ezért nem viselkedik úgy, mint egy képkocka.
- A [IPPImage.replaceImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) kicserél egy kép erőforrást. Ha több prezentációelem használja azt, mindegyik a helyettesítést használja.
- Az SVG alakzatokká konvertálása szerkeszthető diák alakzatait hozza létre. A konverzió után a tartalom már nem egyetlen képernyő erőforrásként van kezelve.

Egy tipikus munkafolyamat ezért a következő: adjunk kép adatot a képgyűjteményhez, kapjunk egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/), majd használjuk azt az erőforrást egy vagy több képkockában vagy kitöltésben.

## **Beágyazott kép hozzáadása**

Egy helyi kép beszúrásához töltse be a fájlt, adja hozzá a képgyűjteményhez, majd hozzon létre egy képkockát, amely a visszakapott `IPPImage`-t használja.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az így hozzáadott kép be van ágyazva a prezentációba, így a létrehozott fájl nem függ attól, hogy az eredeti kép fájl elérhető marad-e.

### **Kép hozzáadása a webről**

Ha egy kép HTTP vagy HTTPS protokollon keresztül érhető el, töltse le a bájtokat, adja hozzá a prezentáció képgyűjteményéhez, és használja a visszakapott kép erőforrást ugyanúgy, mint egy helyi kép esetén.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hosszú ideig futó alkalmazásokban használja újra az HTTP-klienst vagy egy a programnak megfelelő kapcsolatkezelési stratégiát ahelyett, hogy újra és újra szükségtelen hálózati infrastruktúrát hozna létre. Emellett ellenőrizze a távoli URL-eket, a válaszméreteket és a tartalomtípusokat, ha a forrás nem megbízható.

## **Képek újrafelhasználása diákon át**

Ha ugyanaz a kép több alkalommal is szükséges, adja hozzá a prezentációhoz egyszer, és használja újra a visszakapott [IPPImage] erőforrást további képkockák létrehozásakor. Ez elkerüli a forrásadatok többszöri betöltését, és egyértelművé teszi a megosztott kép erőforrás és felhasználásai közti kapcsolatot.

A sok dián automatikusan megjelenő grafikák esetén, például egy vállalati logó, fontolja meg a képkocka elhelyezését egy [slide master](/slides/hu/androidjava/slide-master/) vagy elrendezésen, ahelyett, hogy minden diához külön alakzatot adna hozzá.

## **Kép használata dia háttérként**

A háttérkép a dia kitöltéséhez van hozzárendelve; nem képkocka alakzatként kerül hozzáadásra. Ez akkor hasznos, ha a képnek a dia hátterét kell lefednie, és nem szeretnénk a szokásos diaobjektumként manipulálni.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

További háttérbeállításokért, beleértve a mester és elrendezés háttereket, lásd [Presentation Background](/slides/hu/androidjava/presentation-background/).

## **Beágyazott és kapcsolt képek**

A beágyazott és a kapcsolt képek különböző hordozhatósági és fájlméret-mérlegelt előnyökkel rendelkeznek:

- **Beágyazott kép:** a képadat a prezentáción belül tárolódik. A prezentáció önálló, de a fájlméret tartalmazza a kép adatot.
- **Kapcsolt kép:** a prezentáció egy elérési utat vagy URL-t tárol egy külső képhez. Ez csökkentheti a prezentáció méretét, de a külső erőforrásnak elérhetőnek kell maradnia, amikor a prezentációt megnyitják vagy renderelik.

Egy kapcsolt képet úgy hozhatunk létre, hogy a külső útvonalat vagy URL-t a [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidespicture/) segítségével rendeli hozzá, ahelyett, hogy beágyazná a kép adatokat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Csak akkor használjon kapcsolt képeket, ha a telepítési környezet megbízhatóan hozzáfér a külső erőforráshoz. Olyan prezentációk esetén, amelyeknek offline kell működniük vagy rendszerek között mozognak, a beágyazott képek általában biztonságosabbak.

## **Működés SVG képekkel**

Az SVG egy vektorfájl formátum, ezért hasznos lehet ikonok, diagramok és egyéb grafika számára, amelynek méretezésekor nem veszik el a részletek, mint a raszteres képek esetén. Az Aspose.Slides támogatja az SVG-t képernyő erőforrásként és szerkeszthető dia alakzatok forrásaként egyaránt.

### **SVG hozzáadása képként**

Hozzon létre egy [SvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgimage/)-t, adja hozzá a képgyűjteményhez, és helyezze a létrejött kép erőforrást egy képkockába.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Külső erőforrásokkal rendelkező SVG fájlok**

Egy SVG hivatkozhat külső képekre, stíluslapokra vagy betűtípusokra. Ilyen esetekben a [SvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgimage/) olyan konstruktorokat biztosít, amelyek elfogadnak egy [IExternalResourceResolver](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iexternalresourceresolver/) és egy alap URI-t. A feloldó képes egy relatív URI-t egy engedélyezett abszolút URI-ra leképezni, és visszaadni egy streamet a kért erőforráshoz.

A feloldó a külső erőforrásokat elérhetővé teszi, amíg az Aspose.Slides feldolgozza az SVG-t, de nem írja át az SVG-t önálló dokumentummá. Ha az SVG-nek hordozhatónak kell maradnia, ágyazzuk be a szükséges erőforrásokat magába az SVG-be, például `data:` URI-k használatával a kapcsolt képekhez.

Amikor SVG fájlok megbízhatatlan forrásból származnak, korlátozni kell a sémákat, fájl helyeket és host-okat, amelyeket a feloldó elérhet. A hálózati feloldók esetén időkorlátokat, válaszméret korlátokat és tartalomvalidálást is alkalmazni kell.

### **SVG konvertálása szerkeszthető alakzatokká**

Aspose.Slides képes egy SVG-t átalakítani szerkeszthető dia alakzatok csoportjává, hasonlóan a megfelelő PowerPoint parancshoz.

![PowerPoint Popup Menu](img_01_01.png)

Használja a [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/) túlterhelést, amely egy [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) objektumot fogad a konvertáláshoz.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az SVG-alkalmazás alakzat-konvertálást használja, ha az egyes vektor elemeket PowerPoint alakzatként kell szerkeszteni. Ha az SVG-t csak meg kell jeleníteni, képként tartani egyszerűbb és elkerüli a sok különálló alakzat létrehozását.

## **Létező kép erőforrás cseréje**

Használja a [IPPImage.replaceImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) metódust, ha egy meglévő kép erőforrást szeretne lecserélni. Ez különösen hasznos megosztott grafikák, például logók esetén.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha több képkocka, háttér, mester vagy elrendezés használja ugyanazt a kép erőforrást, ennek cseréje frissíti mindegyik felhasználását. Ha csak egy képkockát kell módosítani, akkor rendeljünk hozzá egy másik képet ahhoz a képkockához ahelyett, hogy a megosztott erőforrást cserélnénk.

`replaceImage` további túlterheléseket is biztosít, amelyek egy bájttömböt vagy egy másik [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumot fogadnak.

## **Gyakorlati képkezelési irányelvek**

### **A prezentáció méretének szabályozása**

A nagy raszteres képek miatt a prezentáció feleslegesen nagy lehet. Használjon forrás képeket, amelyek dimenziói megfelelőek a tervezett megjelenítési mérethez, annyi esetben újrahasználjon megosztott kép erőforrásokat, és kerüljük el ugyanazon teljes felbontású grafika többszöri beágyazását.

Raszteres képek esetén, amelyeket már képkockába helyezett, az [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/) csökkentheti a kép adatot a kiválasztott felbontás és vágási beállítások szerint. Ez képkocka-feldolgozás, nem a képgyűjtemény kezelése, ezért lásd [Picture Frame](/slides/hu/androidjava/picture-frame/) a kapcsolódó formázási műveletekhez.

### **Válasszon beágyazott és kapcsolt tartalom között**

A beágyazás hordozhatóvá teszi a prezentációt, mivel minden szükséges kép adat a fájlban van. A kapcsolás csökkentheti a fájlméretet, de külső függőséget hoz be. Csak akkor használjon linkeket, ha ez a függőség elfogadható és stabil.

### **Megosztott márka újrahasználata**

Ismétlődő logók, vízjelek vagy díszítő grafikák esetén használjon egy kép erőforrást és újrahasználja. Ha a grafika a prezentáció dizájnjához tartozik a dia tartalma helyett, helyezze el egy mesterre vagy elrendezésre, hogy a megfelelő diák örökölhessék.

### **SVG erőforrások hordozhatóságának megőrzése**

Egy önálló SVG könnyebben mozgatható és konzisztensen renderelhető, mint egy olyan SVG, amely külső fájlokra vagy hálózati erőforrásokra támaszkodik. Amikor lehetséges, ágyazza be a szükséges erőforrásokat a SVG importálása előtt. Az SVG-t alakzatokká konvertálja csak akkor, ha az egyes vektor elemeket szerkeszteni kell.

### **Használja a modern keresztplatformos kép API-t**

Új Android via Java kódhoz használja az Aspose.Slides [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) és [Images](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/images/) API-kat a régi, a `android.graphics.Bitmap`-en alapuló nyilvános API helyett. Lásd a [Modern API](/slides/hu/androidjava/modern-api/) migrációs útmutatót.

WMF és EMF speciális megfontolást igényel. Amikor ezeket a formátumokat egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) segítségével adjuk át, az [ImageCollection.addImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imagecollection/) a metafájl tartalmát raszteres PNG-re konvertálja, mielőtt beilleszti. Ha a metafájl adat megőrzése fontos, használjon áramlatazonos [ImageCollection.addImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imagecollection/) túlterhelést. Az EMF tartalom generálása táblázatokból vagy más termékekből egy külön integrációs munkafolyamat, amely kívül esik a cikk hatókörén.

## **GYIK**

**Mi a különbség a képgyűjtemény és a képkocka között?**

A képgyűjtemény újrahasználható kép erőforrásokat tárol. A képkocka egy dián elhelyezett alakzat, amely egy ilyen erőforrást jelenít meg, és képspecifikus formázási lehetőségeket (például vágást és effektusokat) biztosít.

**Mi a legjobb módja a logó mindenhol való cseréjének?**

Ha a logó már megosztott egy kép erőforrásként, cserélje azt a [IPPImage.replaceImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) segítségével. A prezentáció-szintű márka esetén a logó elhelyezése egy mesterre vagy elrendezésre szintén csökkentheti a duplikált diatartalmat.

**Miért tűnik el egy kapcsolt kép egy másik számítógépen?**

Egy kapcsolt kép a külső fájlt vagy URL-től függ. Ha azt a másik számítógépről nem lehet elérni, a kapcsolt kép nem lesz elérhető. Beágyazza a képet, ha a prezentációnak önállónak kell lennie.

**Szerkeszthető PowerPoint alakzatként beilleszthető az SVG?**

Igen. Konvertálja az SVG-t a [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/) használatával; az eredményül kapott csoport szerkeszthető dia alakzatokat tartalmaz, nem egy SVG képet.

**Hogyan tarthatom kisebbnek a sok képet tartalmazó prezentációkat?**

Használjon megosztott kép erőforrásokat, kerülje a fölöslegesen nagy raszteres forrásokat, tömörítse a megfelelő raszteres képeket amikor szükséges, helyezze a ismétlődő márkát mesterekre vagy elrendezésekre, és csak akkor használjon kapcsolt képeket, ha a külső függőség elfogadható.