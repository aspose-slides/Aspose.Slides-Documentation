---
title: "Androidon történő prezentációk képkockáinak kezelése"
linktitle: "Képkocka"
type: docs
weight: 10
url: /hu/androidjava/picture-frame/
keywords:
- képkocka
- képkocka hozzáadása
- képkocka létrehozása
- kép hozzáadása
- kép létrehozása
- kép kinyerése
- raszteres kép
- vektorkép
- kép vágása
- vágott terület
- StretchOff tulajdonság
- képkocka formázása
- képkocka tulajdonságai
- relatív méretezés
- kép effektus
- oldalarány
- kép átlátszósága
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Adjon hozzá képkockákat PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for Android via Java segítségével. Egyszerűsítse a munkafolyamatot és javítsa a diák tervezését."
---
## **Bevezetés**

A képkocka egy olyan alakzat, amely egy képet tartalmaz—úgy, mint egy kép keretben. 

Képet adhat egy diára egy képkockán keresztül. Így a képet a képkocka formázásával formázhatja.

{{% alert  title="Tip" color="info" %}} 

Az Aspose ingyenes konvertereket kínál—[JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyek lehetővé teszik, hogy az emberek gyorsan hozzanak létre prezentációkat képekből. 

{{% /alert %}} 

## **Képkocka létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Hozzon létre egy [IPPImage]() objektumot úgy, hogy egy képet hozzáad a prezentáció objektumhoz tartozó [IImagescollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IImageCollection) gyűjteményhez, amelyet az alakzat kitöltésére használnak.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PictureFrame) objektumot a kép szélessége és magassága alapján az `AddPictureFrame` metódus segítségével, amely a hivatkozott diához tartozó alakzat objektum által érhető el.  
6. Adjon hozzá egy képkockát (amely a képet tartalmazza) a diához.  
7. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód bemutatja, hogyan hozhat létre egy képkockát:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // A első diát kapja meg
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Példányosítja az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Hozzáad egy képkockát a kép megfelelő magasságával és szélességével
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // A PPTX fájlt lemezre írja
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Képkocka létrehozása relatív méretezéssel**

Az image relatív méretezésének módosításával bonyolultabb képkockát hozhat létre.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy képet a prezentáció képgyűjteményéhez.  
4. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPPImage) objektumot úgy, hogy egy képet hozzáad a prezentáció objektumhoz tartozó [IImagescollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IImageCollection) gyűjteményhez, amelyet az alakzat kitöltésére használnak.  
5. Adja meg a kép relatív szélességét és magasságát a képkockában.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód bemutatja, hogyan hozhat létre egy képkockát relatív méretezéssel:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Az első diát kapja meg
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Példányosítja az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Képkocka hozzáadása a kép magasságával és szélességével megegyező mérettel
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Relatív méretezés szélességének és magasságának beállítása
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // A PPTX fájlt lemezre írja
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Raster képek kinyerése képkockákból**

Raster képeket nyerhet ki [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PictureFrame) objektumokból, és mentheti őket PNG, JPG és egyéb formátumokba. Az alábbi kódrészlet bemutatja, hogyan nyerjen ki egy képet a „sample.pptx” dokumentumból, és mentse PNG formátumban.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **SVG képek kinyerése képkockákból**

Amikor egy prezentáció SVG grafikát tartalmaz, amely [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) alakzatokba van ágyazva, az Aspose.Slides for Android via Java lehetőséget biztosít az eredeti vektor képek hibátlan kinyerésére. Ha rendelkezik egy [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) objektummal, amelynek [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) SVG tartalma van, akkor beolvashatja azt az SVG képet, és elmentheti lemezre vagy streambe natív SVG formátumban.

Az alábbi kódrészlet bemutatja, hogyan nyerjen ki egy SVG képet egy képkockából:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Kép átlátszóságának lekérdezése**

Az Aspose.Slides lehetővé teszi, hogy lekérdezze egy képre alkalmazott átlátszósági effektet. Ez a Java kód demonstrálja a műveletet:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **Kép fényerő és kontraszt lekérdezése**

Az Aspose.Slides lehetővé teszi, hogy lekérdezze egy képre alkalmazott fényerő és kontraszt effektet. Az [ILuminance](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iluminance/) interfész képzi ezt a képmódosító hatást.

Ez a Java kód bemutatja, hogyan kérdezheti le a fényerő és kontraszt beállításait egy képkockából:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Képkocka formázása**

Az Aspose.Slides számos formázási lehetőséget kínál, amelyeket egy képkockára lehet alkalmazni. Ezekkel a lehetőségekkel módosíthatja a képkockát, hogy megfeleljen a specifikus követelményeknek.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPPImage) objektumot úgy, hogy egy képet hozzáad a prezentáció objektumhoz tartozó [IImagescollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IImageCollection) gyűjteményhez, amelyet az alakzat kitöltésére használnak.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame`-et a kép szélessége és magassága alapján a [AddPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódussal, amely a [IShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) objektumon keresztül érhető el a hivatkozott dián.  
6. Adja hozzá a képkockát (amely a képet tartalmazza) a diához.  
7. Állítsa be a képkocka vonalszínét.  
8. Állítsa be a képkocka vonalvastagságát.  
9. Forgassa a képkockát pozitív vagy negatív érték megadásával.  
   * A pozitív érték az órával megegyező irányban forgatja a képet.  
   * A negatív érték az óramutatóval ellentétes irányban forgatja a képet.  
10. Adja hozzá a képkockát (amely a képet tartalmazza) a diához.  
11. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód demonstrálja a képkocka formázási folyamatát:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

//    Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    //    Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    //    Példányosítja az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    //    Hozzáad egy képkockát a kép magasságával és szélességével megegyező mérettel
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    //    Alkalmaz némi formázást a PictureFrameEx-re
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    //    A PPTX fájlt lemezre írja
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Az Aspose nemrég egy [ingyenes Collage Maker](https://products.aspose.app/slides/hu/collage) szolgáltatást fejlesztett ki. Ha valaha JPG/JPEG vagy PNG képeket kell összefésülnie, vagy képrácsokat kell létrehoznia, használhatja ezt a szolgáltatást. 

{{% /alert %}}

## **Kép hozzáadása hivatkozásként**

A nagy méretű prezentációk elkerülése érdekében képeket (vagy videókat) hivatkozásokon keresztül adhat hozzá ahelyett, hogy a fájlokat közvetlenül beágyazná a prezentációba. Ez a Java kód bemutatja, hogyan adjon hozzá egy képet és videót egy helyőrzőhöz:

```java
import com.aspose.slides.*;
import java.util.ArrayList;

Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Képek vágása**

Ez a Java kód bemutatja, hogyan vághat le egy meglévő képet egy dián:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// Új képobjektum létrehozása
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Képkocka hozzáadása egy diára
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // A kép levágása (százalékos értékek)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Az eredmény mentése
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A képkocka vágott területeinek törlése**

Ha egy képkockában lévő kép vágott területeit szeretné törölni, használhatja a [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metódust. Ez a metódus a vágott képet vagy az eredeti képet adja vissza, ha a vágás nem szükséges.

Ez a Java kód demonstrálja a műveletet:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    //     Lekéri a PictureFrame-et az első diáról
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    //     Törli a PictureFrame kép vágott területeit, és visszaadja a vágott képet
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    //     Elmenti az eredményt
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

A [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metódus a vágott képet hozzáadja a prezentáció képgyűjteményéhez. Ha a kép csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) objektumban szerepel, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a kimeneti prezentációban lévő képek száma megnő.

Ez a metódus a vágási művelet során WMF/EMF metafájlokat raszteres PNG képpé konvertál. 

{{% /alert %}}

## **Képek tömörítése**

A [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) metódus segítségével tömöríthet egy képet egy prezentációban.  
Ez a metódus a kép méretét a alakzat mérete és a megadott felbontás alapján csökkenti, opcionálisan a vágott területeket is törölve.

A képméret és felbontás beállítása hasonló a PowerPoint **Picture Format > Compress Pictures > Resolution** funkciójához.

Az alábbi Java példák bemutatják, hogyan tömöríthet egy képet egy prezentációban célfelbontás megadásával, illetve a vágott területek opcionális eltávolításával:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // A kép tömörítése 150 DPI (web felbontás) célfelbontással és a vágott területek eltávolítása.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // A tömörítés eredményének ellenőrzése.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vagy közvetlenül egy egyedi DPI érték megadásával:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // A kép tömörítése 150 DPI-re (web felbontás), a vágott területek eltávolításával.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

A metódus a képet alacsonyabb felbontásra konvertálja az alakzat mérete és a megadott DPI alapján. A vágott területek is törölhetők a fájlméret optimalizálása érdekében.  
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem alkalmazandó. A JPEG minősége megmarad vagy enyhén csökken a felbontástól függően, ahogyan a PowerPoint a nagy felbontású JPEG-eket kezeli.

{{% /alert %}}

## **Oldalarány zárolása**

Ha azt szeretné, hogy egy képet tartalmazó alakzat megtartsa az oldalarányát a kép méretének módosítása után is, használja a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) metódust az *Oldalarány zárolása* beállítás aktiválásához.

Ez a Java kód bemutatja, hogyan zárolhatja egy alakzat oldalarányát:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // állítsa be az alakzatot, hogy megőrizze az oldalarányt átméretezéskor
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Ez az *Oldalarány zárolása* beállítás csak az alakzat oldalarányát őrzi meg, nem a benne lévő képet.

{{% /alert %}}

## **StretchOff tulajdonság használata**

A [StretchOffsetLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) és [StretchOffsetBottom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) tulajdonságok használatával a [IPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat) interfészben és a [PictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat) osztályban egy kitöltési téglalapot adhat meg.

Ha egy kép nyújtásra van beállítva, a forrástéglalap a megadott kitöltési téglalapba skálázódik. A kitöltési téglalap minden oldala a forma határoló dobozának megfelelő oldalához képest százalékos eltolással definiálható. A pozitív százalék belső eltolást, a negatív százalék külső eltolást jelent.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be a forma kitöltési típusát.  
6. Állítsa be a forma képkitöltési módját.  
7. Adjon hozzá egy képet a forma kitöltéséhez.  
8. Adja meg a képek eltolásait a forma határoló dobozának megfelelő oldalához képest.  
9. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód demonstrálja a StretchOff tulajdonság használatával végzett folyamatot:

```java
import com.aspose.slides.*;

// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide slide = pres.getSlides().get_Item(0);

    // Példányosítja az ImageEx osztályt
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // AutoShape objektum hozzáadása Rectangle-ként
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Beállítja az alakzat kitöltési típusát
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Beállítja az alakzat képkitöltési módját
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Beállítja a képet, hogy kitöltse az alakzatot
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Megadja a kép eltolásait a forma határoló dobozának megfelelő oldalához képest
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    //A PPTX fájlt lemezre írja
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

### Hogyan tudom megtudni, mely képformátumok támogatottak a PictureFrame esetén?

Az Aspose.Slides támogatja mind a raszteres (PNG, JPEG, BMP, GIF stb.), mind a vektoros (például SVG) képeket, a [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) objektumhoz rendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedi a diák és a képkonverziós motor képességeit.

### Hogyan befolyásolja a tucatnyi nagy kép hozzáadása a PPTX méretét és teljesítményét?

A nagyméretű képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek hivatkozásként történő használata csökkenti a prezentáció méretét, de a külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetőséget biztosít a képek hivatkozásként történő hozzáadására a fájlméret csökkentése érdekében.

### Hogyan zárolhatok egy képobjektumot a véletlen mozgatás/átméretezés ellen?

Használja a [shape locks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) funkciót egy [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) esetén (például a mozgatás vagy méretezés letiltása). A zárolási mechanizmus több alakzat típusra is támogatott, beleértve a [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) objektumot is.

### Megmarad-e az SVG vektor pontossága, amikor a prezentációt PDF/fájlformátumokra exportáljuk?

Az Aspose.Slides lehetővé teszi egy SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) objektumból eredeti vektorként. Amikor [PDF-re exportálunk](/slides/hu/androidjava/convert-powerpoint-to-pdf/) vagy [raszteres formátumokra](/slides/hu/androidjava/convert-powerpoint-to-png/), az eredmény a beállításoktól függően rasterizálódhat; a CSV eredeti SVG vektorként tárolásáért a kinyerési viselkedés biztosítja a pontosságot.