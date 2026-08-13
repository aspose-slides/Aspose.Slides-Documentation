---
title: Képkeretek kezelése prezentációkban Java használatával
linktitle: Képkeret
type: docs
weight: 10
url: /hu/java/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- kép hozzáadása
- kép létrehozása
- kép kinyerése
- raszteres kép
- vektorkép
- kép vágása
- vágott terület
- StretchOff tulajdonság
- képkeret formázása
- képkeret tulajdonságai
- relatív méretezés
- kép effektus
- oldalarány
- kép átlátszósága
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Adjon hozzá képkereteket PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for Java segítségével. Hatékonyabbá teheti a munkafolyamatát és gazdagíthatja a diák tervezését."
---
## **Bevezetés**

A képkeret egy alakzat, amely egy képet tartalmaz—úgy, mint egy kép egy keretben.  

Képet egy diára képkereten keresztül adhat hozzá. Így a kép formázását a képkeret formázásával végezheti.

{{% alert  title="Tip" color="info" %}} 
Az Aspose ingyenes konvertereket biztosít—[JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyek lehetővé teszik, hogy gyorsan prezentációkat hozzanak létre képekből. 
{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Hozzon létre egy [IPPImage]() objektumot úgy, hogy képet ad a [IImagescollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IImageCollection) gyűjteményhez, amely a prezentáció objektumhoz kapcsolódik, és a forma kitöltésére szolgál.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/PictureFrame) objektumot a kép szélessége és magassága alapján az `AddPictureFrame` metódus segítségével, amely a hivatkozott dia alakzat objektumán keresztül érhető el.  
6. Adjon hozzá egy képkeretet (amely a képet tartalmazza) a diához.  
7. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód bemutatja, hogyan hozhat létre képkeretet:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Létrehozza az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Képkeretet ad hozzá a kép egyenlő magasságával és szélességével
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Kiírja a PPTX fájlt a lemezre
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
A képkeretek lehetővé teszik, hogy gyorsan készítsen prezentációs diákat képek alapján. Ha a képkeretet kombinálja az Aspose.Slides mentési beállításaival, akkor manipulálhatja a be- és kimeneti műveleteket a képek formátumok közötti átalakításához. Érdemes megtekinteni ezeket az oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/java/conversion/image-to-jpg/); konvertálás [JPG to image](https://products.aspose.com/slides/hu/java/conversion/jpg-to-image/); konvertálás [JPG to PNG](https://products.aspose.com/slides/hu/java/conversion/jpg-to-png/), konvertálás [PNG to JPG](https://products.aspose.com/slides/hu/java/conversion/png-to-jpg/); konvertálás [PNG to SVG](https://products.aspose.com/slides/hu/java/conversion/png-to-svg/), konvertálás [SVG to PNG](https://products.aspose.com/slides/hu/java/conversion/svg-to-png/). 
{{% /alert %}} 

## **Képkeret létrehozása relatív méretezéssel**

A kép relatív méretezésének módosításával összetettebb képkeretet hozhat létre.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Adjon egy képet a prezentáció képgallériájához.  
4. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPPImage) objektumot úgy, hogy képet ad a [IImagescollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IImageCollection) gyűjteményhez, amely a prezentáció objektumhoz kapcsolódik, és a forma kitöltésére szolgál.  
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód bemutatja, hogyan hozhat létre képkeretet relatív méretezéssel:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Példányosítja az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Képkeretet ad hozzá a kép magasságával és szélességével egyenlő mérettel
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Relatív skála szélességének és magasságának beállítása
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Kiírja a PPTX fájlt a lemezre
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Raster képek kinyerése képkeretekből**

Raster képeket nyerhet ki a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/PictureFrame) objektumokból, és PNG, JPG, illetve más formátumokban mentheti el. Az alábbi kódrészlet bemutatja, hogyan nyerhet ki egy képet a "sample.pptx" dokumentumból, és mentse PNG formátumban.

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

## **SVG képek kinyerése képkeretekből**

Amikor egy prezentáció SVG grafikákat tartalmaz, amelyek [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) alakzatokban helyezkednek el, az Aspose.Slides for Java lehetővé teszi az eredeti vektorkép teljes hitelességgel történő lekérését. A dia alakzatgyűjteményének bejárásával azonosíthatja az egyes [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) objektumokat, ellenőrizheti, hogy az alatta lévő [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) SVG tartalmat tartalmaz-e, és elmentheti azt lemezre vagy adatfolyamba natív SVG formátumban.

A következő kódrészlet bemutatja, hogyan nyerhet ki egy SVG képet egy képkeretből:

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

        // A getSvgImage null értéket ad vissza, ha a kép raszteres kép.
        if (svgImage != null) {
            FileOutputStream fos = new FileOutputStream("output.svg");
            fos.write(svgImage.getSvgData());
            fos.close();
        }
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Kép átlátszóságának lekérdezése**

Az Aspose.Slides lehetővé teszi a képre alkalmazott átlátszósági hatás lekérdezését. Ez a Java kód mutatja be a műveletet:

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

## **Kép fényerő és kontrasztjának lekérdezése**

Az Aspose.Slides lehetővé teszi a képre alkalmazott fényerő- és kontraszt-hatás lekérdezését. Az [ILuminance](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iluminance/) interfész képviseli ezt a képtranszformációs hatást.

Ez a Java kód bemutatja, hogyan kérdezheti le a fényerő- és kontrasztbeállításokat egy képkeretből:

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

## **Képkeret formázása**

Az Aspose.Slides számos formázási lehetőséget kínál a képkeretekre. Ezekkel a lehetőségekkel módosíthatja a képkeretet, hogy megfeleljen a specifikus követelményeknek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPPImage) objektumot úgy, hogy képet ad a [IImagescollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IImageCollection) gyűjteményhez, amely a prezentáció objektumhoz kapcsolódik, és a forma kitöltésére szolgál.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame` objektumot a kép szélessége és magassága alapján az [AddPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódus segítségével, amely a hivatkozott dia [IShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) objektumán keresztül érhető el.  
6. Adjon hozzá egy képkeretet (amely a képet tartalmazza) a diához.  
7. Állítsa be a képkeret vonalszínét.  
8. Állítsa be a képkeret vonalszélességét.  
9. Forgassa el a képkeretet pozitív vagy negatív érték megadásával.  
   * A pozitív érték az irányt az óramutató járásával megegyező irányba forgatja.  
   * A negatív érték az óramutató járásával ellentétes irányba forgatja.  
10. Adjon hozzá a képkeretet (amely a képet tartalmazza) a diához.  
11. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód bemutatja a képkeret formázási folyamatát:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Létrehozza a Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Létrehozza az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Képkeretet ad hozzá a kép magasságával és szélességével egyenlő mérettel
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Alkalmaz némi formázást a PictureFrameEx-re
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Kiírja a PPTX fájlt a lemezre
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Az Aspose nemrég fejlesztett egy [ingyenes Collage Maker](https://products.aspose.app/slides/hu/collage) eszközt. Ha valaha szüksége van [JPG/JPEG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG képek egyesítésére, [rácsok létrehozására fényképekből](https://products.aspose.app/slides/hu/collage/photo-grid), használhatja ezt a szolgáltatást. 
{{% /alert %}}

## **Kép hozzáadása hivatkozásként**

A nagy prezentációméretek elkerülése érdekében képeket (vagy videókat) hivatkozásokon keresztül adhat hozzá ahelyett, hogy a fájlokat közvetlenül beágyazná a prezentációba. Ez a Java kód bemutatja, hogyan adjon hozzá egy képet és videót egy helyőrzőhöz:

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

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

Presentation pres = new Presentation();
// Létrehoz egy új képobjektumot
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Képkeretet ad hozzá egy diához
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Levágja a képet (százalékértékek)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Elmenti az eredményt
    pres.save(outPptxFile, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kép vágott részeinek törlése**

Ha a keretben lévő kép vágott részeit szeretné törölni, használhatja a [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metódust. Ez a metódus visszaadja a vágott képet, vagy az eredeti képet, ha a vágás nem szükséges.

Ez a Java kód demonstrálja a műveletet:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Az első diáról lekéri a PictureFrame-et
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // A PictureFrame képének vágott részeit törli, és visszaadja a vágott képet
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Elmenti az eredményt
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Az [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metódus a vágott képet a prezentáció képgyűjteményéhez adja hozzá. Ha a képet csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) használja, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a végső prezentációban lévő képek száma növekedni fog.

Ez a metódus a vágási művelet során a WMF/EMF metafájlokat raster PNG képpé konvertálja. 
{{% /alert %}}

## **Képek tömörítése**

A [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) metódussal tömörítheti egy prezentáció képét. Ez a metódus a kép méretét a forma mérete és a megadott felbontás alapján csökkenti, a vágott területek törlésének lehetőségével.

A kép méretét és felbontását úgy állítja be, mint a PowerPoint **Picture Format -> Compress Pictures -> Resolution** funkciója.

A következő Java példák bemutatják, hogyan tömöríthet egy képet a prezentációban célfelbontás megadásával és opcionálisan a vágott területek eltávolításával:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Tömöríti a képet 150 DPI (web felbontás) célfelbontással, és eltávolítja a vágott területeket.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Ellenőrzi a tömörítés eredményét.
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

Vagy közvetlenül egy egyéni DPI értéket használva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Tömöríti a képet 150 DPI (web felbontás) értékre, és eltávolítja a vágott területeket.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
A metódus a képet alacsonyabb felbontásra konvertálja a forma mérete és a megadott DPI alapján. A vágott területek is törölhetők a fájlméret optimalizálása érdekében.  
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem kerül alkalmazásra. Emellett a JPEG minősége a felbontás alapján megmarad vagy enyhén csökken, ahogy a PowerPoint a nagy felbontású JPEG-eket kezeli. 
{{% /alert %}}

## **Arányzár beállítása**

Ha azt szeretné, hogy egy képet tartalmazó alakzat megtartsa az arányát még a kép méreteinek megváltoztatása után is, használhatja a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) metódust a *Lock Aspect Ratio* beállítás beállításához. 

Ez a Java kód bemutatja, hogyan zárolhatja egy alakzat arányát:

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

    // Állítsa be a formát úgy, hogy a méretezéskor megőrizze az oldalarányt
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Ez a *Lock Aspect Ratio* beállítás csak az alakzat arányát őrzi meg, nem a benne lévő képet. 
{{% /alert %}}

## **A StretchOff tulajdonság használata**

A [StretchOffsetLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) és [StretchOffsetBottom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) tulajdonságok használatával az [IPictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat) interfészből és a [PictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat) osztályból, megadhat egy kitöltő téglalapot.

Ha egy képhez nyújtást adunk meg, a forrás téglalap úgy méreteződik, hogy illeszkedjen a megadott kitöltő téglalapba. A kitöltő téglalap minden élét egy százalékos eltolás definiálja az alakzat határoló dobozának megfelelő élétől. A pozitív százalék egy belső eltolást jelent, a negatív százalék pedig egy külső eltolást.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be az alakzat kitöltési típusát.  
6. Állítsa be az alakzat képkitöltési módját.  
7. Adjon meg egy képet a forma kitöltéséhez.  
8. Adja meg a kép eltolásait a forma határoló dobozának megfelelő élétől  
9. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód bemutat egy folyamatot, amelyben a StretchOff tulajdonságot használják:

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

    // AutoShape-et ad hozzá, téglalap formátumban
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Beállítja a forma kitöltési típusát
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Beállítja a forma képkitöltési módját
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Beállítja a képet a forma kitöltéséhez
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Megadja a kép eltolásait a forma határoló dobozának megfelelő élétől
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // Kiírja a PPTX fájlt a lemezre
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

### Hogyan tudom megtudni, mely képformátumok támogatottak a PictureFrame számára?

Az Aspose.Slides támogatja a raster képeket (PNG, JPEG, BMP, GIF stb.) és a vektorképeket (például SVG) is a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/)‑hez rendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedi a dia- és képkonvertáló motor képességeit.

### Hogyan befolyásolja a több tucat nagy kép hozzáadása a PPTX méretét és teljesítményét?

A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek hivatkozással való hozzáadása segít alacsonyan tartani a prezentáció méretét, de megköveteli, hogy a külső fájlok elérhetők maradjanak. Az Aspose.Slides lehetővé teszi a képek hivatkozással történő hozzáadását a fájlméret csökkentése érdekében.

### Hogyan zárhatom le a képobjektumot a véletlen mozgatás/átméretezés ellen?

Használja a [shape locks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) funkciót egy [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) esetén (például a mozgatás vagy átméretezés letiltásához). A zárolási mechanizmust egy külön [protection article](/slides/hu/java/applying-protection-to-presentation/) részletezi, és különböző alakzat típusokra, többek között a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) esetén támogatja.

### Megmarad az SVG vektor hűsége a prezentáció PDF/képek formátumba exportálásakor?

Az Aspose.Slides lehetővé teszi az SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) -ből eredeti vektorként. Amikor [PDF-be exportálunk](/slides/hu/java/convert-powerpoint-to-pdf/) vagy [raszteres formátumokba](/slides/hu/java/convert-powerpoint-to-png/), az eredmény a beállításoktól függően raszteres lehet; a kinyerési viselkedés megerősíti, hogy az eredeti SVG vektorként van tárolva.