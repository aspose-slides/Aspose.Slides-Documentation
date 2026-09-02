---
title: Prezentációk képkezelésének optimalizálása Java-val
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/java/image/
keywords:
- kép hozzáadása
- kép beszúrása
- kép cseréje
- képtár
- képkeret
- hivatkozott kép
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- SVG alakzatokká
- külső SVG erőforrások
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, újrahasznosíthat, hivatkozhat, cserélhet és kezelhet raszter‑ és SVG‑képeket PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java használatával."
---
## **Bevezetés**

Az Aspose.Slides for Java többféle módot kínál a képekkel való munka során, amelyek mind különböző célt szolgálnak. Egy képet tárolhat a prezentációban, megjeleníthet egy képkeretben, használhatja dia háttérként, hivatkozhat külső képre, cserélhet megosztott kép erőforrást, vagy SVG tartalmat konvertálhat szerkeszthető formákká.  
Ez a cikk a kép erőforrásokra és azok prezentáción belüli felhasználására összpontosít. A képkereteknél alkalmazott vágásra, átlátszóságra, effektusokra, nyújtásra és egyéb formázásokra lásd a [Picture Frame](/slides/hu/java/picture-frame/) oldalt.

## **Ismerje meg a képmodellt**

A következő API koncepciók szorosan kapcsolódnak egymáshoz, de nem cserélhetők fel:

- A [presentation image collection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagecollection/) képtárát tárolja a prezentáció által használt kép erőforrásokat. Használja az [ImageCollection.addImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imagecollection/) metódust a kép adatának hozzáadásához, és kap egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) erőforrást.  
- A [picture frame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) egy alakzat, amely képet jelenít meg egy diáon, elrendezésen vagy mesteroldalon. Használja az [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/) metódust a kép erőforrás diára helyezéséhez.  
- A dia háttér képét a dia kitöltésének részeként használja, nem alakzatként, így nem viselkedik úgy, mint egy képkeret.  
- Az [IPPImage.replaceImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) kicseréli egy kép erőforrását. Ha több prezentációs elem használja azt az erőforrást, mindegyik a cserét fogja használni.  
- Az SVG alakzatokra konvertálása szerkeszthető diá alakzatokat hoz létre. Konverzió után a tartalom már nem egy képernyett erőforrásként van kezelve.

Egy tipikus munkafolyamat tehát: a kép adatot a képtárba adja, megkap egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) objektumot, majd ezt az erőforrást használja egy vagy több képkeretben vagy kitöltésben.

## **Beágyazott kép hozzáadása**

Egy helyi kép beillesztéséhez töltse be a fájlt, adja hozzá a képtárhoz, és hozzon létre egy képkeretet, amely a visszakapott `IPPImage`-t használja.

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

Az így hozzáadott kép a prezentációba van beágyazva, így a keletkezett fájl nem függ attól, hogy az eredeti kép fájl elérhető marad‑e.

### **Kép hozzáadása a webről**

Ha egy kép HTTP vagy HTTPS protokollon keresztül érhető el, töltse le a bájtjait, adja hozzá a prezentáció képtárához, és használja a visszakapott kép erőforrást ugyanúgy, mint egy helyi képet.

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

Hosszú ideig futó alkalmazásokban használja újra a megfelelő HTTP klienst vagy kapcsolatkezelési stratégiát ahelyett, hogy folyamatosan szükségtelen hálózati infrastruktúrát hozna létre. Emellett ellenőrizze a távoli URL‑eket, a válaszméreteket és a tartalomtípusokat, ha a forrás nem megbízható.

## **Képek újrafelhasználása diákon át**

Ha ugyanaz a kép többször szükséges, adja hozzá egyszer a prezentációhoz, és a további képkeretek létrehozásakor használja a visszakapott [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) objektumot. Ez elkerüli a forrásadatok többszöri betöltését, és egyértelművé teszi a megosztott kép erőforrás és felhasználásai közti kapcsolatot.  
Az olyan grafikák esetében, amelyeknek automatikusan meg kell jelenniük sok dián, például egy vállalati logó, érdemes a képkeretet egy [slide master](/slides/hu/java/slide-master/) vagy elrendezésre helyezni, ahelyett, hogy minden diához hozzáadna egy ekvivalens alakzatot.

## **Kép használata dia háttérként**

A háttérkép a dia kitöltéséhez van rendelve; nem képkeret alakzatként kerül hozzáadásra. Ez hasznos, ha a képnek a dia hátterét kell lefednie, és nem kell normál dia objektumként manipulálni.

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

További háttér lehetőségekért, beleértve a mester és elrendezés háttereket, lásd a [Presentation Background](/slides/hu/java/presentation-background/) oldalt.

## **Beágyazott képek és hivatkozott képek**

Beágyazott és hivatkozott képek különböző hordozhatósági és fájlméretbeli kompromisszumokkal járnak:

- **Beágyazott kép:** a kép adat a prezentáción belül tárolódik. A prezentáció önmagában tartalmazza, de a fájlméret magában foglalja a kép adatot.  
- **Hivatkozott kép:** a prezentáció egy útvonalat vagy URL‑t tárol egy külső képhez. Ez csökkentheti a prezentáció méretét, de a külső erőforrásnak elérhetőnek kell maradnia a prezentáció megnyitásakor vagy renderelésekor.

Egy hivatkozott képet úgy hozhatunk létre, hogy a külső útvonalat vagy URL‑t a [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidespicture/) metódussal rendeljük hozzá, ahelyett, hogy beágyaznánk a kép adatot.

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

Használjon hivatkozott képeket csak akkor, ha a telepítési környezet megbízhatóan hozzáfér a külső erőforráshoz. Az offline vagy rendszerek közötti áthelyezést igénylő prezentációk esetén a beágyazott képek általában biztonságosabbak.

## **SVG képek kezelése**

Az SVG egy vektoros formátum, ezért hasznos lehet ikonok, diagramok és egyéb grafikák esetében, amelyeknek a raszteres képekhez képest részletveszteség nélkül kell skálázódniuk. Az Aspose.Slides támogatja az SVG‑t képernyet erőforrásként és szerkeszthető diá alakzatok forrásaként egyaránt.

### **SVG hozzáadása képként**

Hozzon létre egy [SvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgimage/) objektumot, adja hozzá a képtárhoz, és helyezze a keletkezett kép erőforrást egy képkeretbe.

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

Az SVG hivatkozhat külső képekre, stíluslapokra vagy betűtípusokra. Ezekben az esetekben a [SvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgimage/) olyan konstruktorokat biztosít, amelyek elfogadnak egy [IExternalResourceResolver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iexternalresourceresolver/) és egy alap‑URI‑t. A resolver képes egy relatív URI‑t egy engedélyezett abszolút URI‑ra leképezni, és visszaad egy streamet a kért erőforráshoz.  
A resolver elérhetővé teszi a külső erőforrásokat, amíg az Aspose.Slides feldolgozza az SVG‑t, de nem írja át az SVG‑t önálló dokumentummá. Ha az SVG‑nek hordozhatónak kell maradnia, ágyazza be a szükséges erőforrásokat az SVG‑be, például `data:` URI‑k használatával a hivatkozott képekhez.  
Ha az SVG fájlok megbízhatatlan forrásból származnak, korlátozza a séma, fájlhely és hoszt hozzáféréseket, amelyeket a resolver elérhet. A hálózati resolvernek időkorlátokat, válaszméret korlátokat és tartalom validációt is alkalmaznia kell.

### **SVG konvertálása szerkeszthető alakzatokká**

Az Aspose.Slides képes egy SVG‑t egy szerkeszthető diá alakzatcsoporttá konvertálni, hasonlóan a megfelelő PowerPoint parancshoz.

![PowerPoint Popup Menu](img_01_01.png)

Használja az [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/) túlterhelést, amely egy [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) objektumot fogad a konverzió végrehajtásához.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Használja az SVG‑alakzat konverziót, ha az egyedi vektor elemeket PowerPoint alakzatokként kell szerkeszteni. Ha az SVG csak megjelenítésre van szükség, képként tartani egyszerűbb, és elkerüli sok különálló alakzat létrehozását.

## **Létező kép erőforrás cseréje**

Használja az [IPPImage.replaceImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) metódust, ha egy létező kép erőforrást szeretne cserélni. Ez különösen hasznos megosztott grafikák, például logók esetén.

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

Ha több képkeret, háttér, mester vagy elrendezés használja ugyanazt a kép erőforrást, a forrás cseréje frissíti mindegyik használatot. Ha csak egy képkeretnek kell változnia, akkor rendeljön másik képet ahhoz a kerethez a megosztott erőforrás cseréje helyett.  
`replaceImage` további túlterheléseket is biztosít, amelyek bájt tömböt vagy egy másik [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) objektumot fogadnak.

## **Gyakorlati képkezelési útmutató**

### **A prezentáció méretének szabályozása**

A nagy raszteres képek a prezentáció méretét indokolatlanul megnövelhetik. Használjon forrásképeket, amelyek mérete megfelel a tervezett megjelenítési méretnek, újrahasználja a megosztott kép erőforrásokat ahol lehet, és kerülje a ugyanazon nagyfelbontású grafika többszörös beágyazását.  
A már képkeretbe elhelyezett raszteres képek esetén az [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/) a kiválasztott felbontás és vágási beállítások szerint csökkentheti a kép adatot. Ez képkeret feldolgozás, nem képtár kezelés, ezért a kapcsolódó formázási műveletekért lásd a [Picture Frame](/slides/hu/java/picture-frame/) oldalt.

### **Beágyazott és hivatkozott tartalom választása**

A beágyazás hordozhatóvá teszi a prezentációt, mivel minden szükséges kép adat a fájllal együtt kerül. A hivatkozás csökkentheti a fájlméretet, de külső függőséget vezet be. Használjon hivatkozásokat csak akkor, ha ez a függőség elfogadható és stabil.

### **Megosztott arculat újrafelhasználása**

Ismétlődő logók, vízjelek vagy dekoratív grafikák esetén használjon egy kép erőforrást és használja újra. Ha a grafika a prezentáció tervezéséhez tartozik, nem a diához, helyezze el egy mesterre vagy elrendezésre, hogy a megfelelő diák örökölhessék.

### **SVG erőforrások hordozhatóságának megőrzése**

Az önálló SVG könnyebben mozgatható és konzisztensen renderelhető, mint egy külső fájlokra vagy hálózati erőforrásokra támaszkodó SVG. Amikor lehetséges, ágyazza be a szükséges erőforrásokat még az SVG importálása előtt. Az SVG‑t alakzatokká csak akkor konvertálja, ha az egyedi vektor elemek szerkesztésére van szükség.

### **A modern, többplatformos kép API használata**

Új Java kódban használja az Aspose.Slides [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) és [Images](https://reference.aspose.com/slides/hu/java/com.aspose.slides/images/) API‑kat a `java.awt.image.BufferedImage` alapú régi nyilvános API helyett. A migrációs útmutatásért lásd a [Modern API](/slides/hu/java/modern-api/) oldalt.  
A WMF és EMF speciális figyelmet igényelnek. Ha ezeket a formátumokat egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) segítségével adjuk át, az [ImageCollection.addImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imagecollection/) a metafájlokat raszteres PNG ábrázolássá konvertálja beszúrás előtt. Ha a metafájl adatok megőrzése fontos, használjon adatfolyam‑alapú [ImageCollection.addImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imagecollection/) túlterhelést. Az EMF tartalom generálása táblázatokból vagy más termékekből egy külön integrációs munkafolyamat, és nem része ennek a cikknek.

## **GYIK**

**Mi a különbség a képtár és a képkeret között?**  
A képtár újrahasználható kép erőforrásokat tárol. A képkeret egy dián lévő alakzat, amely egy ilyen erőforrást jelenít meg, és képspecifikus formázást biztosít, például vágást és effektusokat.

**Mi a legjobb módja annak, hogy mindenhol kicserélje ugyanazt a logót?**  
Ha a logó már egy közös kép erőforrásként van megosztva, cserélje azt a forrást az [IPPImage.replaceImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) segítségével. A prezentáció egészére kiterjedő arculat esetén a logó elhelyezése egy mesterre vagy elrendezésre szintén csökkentheti a duplikált diá tartalmat.

**Miért tűnik el egy hivatkozott kép egy másik számítógépen?**  
A hivatkozott kép a külső fájlra vagy URL‑re támaszkodik. Ha ez az erőforrás nem érhető el a másik számítógépről, a hivatkozott kép elérhetetlen lehet. A prezentáció önállóvá tételekor ágyazza be a képet.

**Lehet beillesztett SVG‑t PowerPoint alakzatokként szerkeszteni?**  
Igen. Konvertálja az SVG‑t az [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/) segítségével; az eredményül kapott csoport szerkeszthető diá alakzatokat tartalmaz egy SVG kép helyett.

**Hogyan tarthatom kisebb méretűnek a sok képet tartalmazó prezentációkat?**  
Használja újra a megosztott kép erőforrásokat, kerülje a szükségtelenül nagy raszteres forrásokat, tömörítse a megfelelő raszteres képeket, ha szükséges, tartsa a gyakran ismétlődő arculatot mestereken vagy elrendezéseken, és csak akkor használjon hivatkozott képeket, ha egy külső függőség elfogadható.