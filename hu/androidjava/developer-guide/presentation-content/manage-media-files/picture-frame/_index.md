---
title: "Képkeretek kezelése prezentációkban Androidon"
linktitle: "Képkeret"
type: docs
weight: 10
url: /hu/androidjava/picture-frame/
keywords:
- "képkeret"
- "képkeret hozzáadása"
- "képkeret létrehozása"
- "kép hozzáadása"
- "kép létrehozása"
- "kép kinyerése"
- "raszteres kép"
- "vektorkép"
- "kép vágása"
- "vágott terület"
- "StretchOff tulajdonság"
- "képkeret formázása"
- "képkeret tulajdonságai"
- "relatív méretezés"
- "kép effektus"
- "oldalarány"
- "kép átlátszósága"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Adj hozzá képkereteket PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for Android Java használatával. Egyszerűsítse a munkafolyamatot és javítsa a diák kialakítását."
---
## **Bevezetés**

A képkeret olyan alakzat, amely képet tartalmaz – ez olyan, mint egy kép a keretben.

Képet egy diára egy képkereten keresztül adhat hozzá. Így a kép formázását a képkeret formázásával végezheti el.

{{% alert title="Tipp" color="primary" %}} 
Az Aspose ingyenes konvertereket biztosít — [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) — amelyek lehetővé teszik a felhasználók számára, hogy képekből gyorsan prezentációkat hozzanak létre. 
{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia referenciáját az indexe alapján.  
3. Hozzon létre egy [IPPImage]() objektumot úgy, hogy egy képet hozzáad a a prezentáció objektumhoz tartozó [IImagescollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IImageCollection) gyűjteményhez, amelyet az alakzat kitöltésére használ.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PictureFrame) objektumot a kép szélessége és magassága alapján az `AddPictureFrame` metódus segítségével, amelyet a hivatkozott diához tartozó alakzat objektum biztosít.  
6. Adjon egy képkeretet (amely a képet tartalmazza) a diára.  
7. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód megmutatja, hogyan lehet képkeretet létrehozni:

```java
// Példányosítja a PPTX fájlt képviselő Presentation osztályt
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Példányosítja az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Hozzáad egy képkeretet a kép megfelelő magasságával és szélességével
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // A PPTX fájlt lemezre írja
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Képkeret létrehozása relatív méretezéssel**

A kép relatív méretezésének módosításával összetettebb képkeretet hozhat létre. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia referenciáját az indexe alapján.  
3. Adjon hozzá egy képet a prezentáció képgyűjteményéhez.  
4. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPPImage) objektumot úgy, hogy egy képet hozzáad a a prezentáció objektumhoz tartozó [IImagescollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IImageCollection) gyűjteményhez, amelyet az alakzat kitöltésére használ.  
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód megmutatja, hogyan lehet képkeretet létrehozni relatív méretezéssel:

```java
// Példányosítja a PPTX-et képviselő Presentation osztályt
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Példányosítja az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Hozzáad egy képkeretet a kép magasságával és szélességével megegyezően
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

## **Raster képek kinyerése képkeretekből**

Raster képeket nyerhet ki a [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PictureFrame) objektumokból, és elmentheti őket PNG, JPG és más formátumokban. Az alábbi kódrészlet bemutatja, hogyan lehet egy képet kinyerni a "sample.pptx" dokumentumból, és PNG formátumban elmenteni.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **SVG képek kinyerése képkeretekből**

Amikor egy prezentáció SVG grafikákat tartalmaz, amelyeket [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) alakzatokba helyeztek, az Aspose.Slides for Android Java lehetővé teszi az eredeti vektor képek teljes hűségű visszanyerését. A dia alakzatgyűjteményének bejárásával azonosíthatja a [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) elemeket, ellenőrizheti, hogy a mögöttes [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) SVG tartalmat tartalmaz-e, majd elmentheti azt a lemezre vagy egy áramlásba natív SVG formátumban.

A következő kódrészlet bemutatja, hogyan lehet SVG képet kinyerni egy képkeretből:

```java
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

## **Kép átlátszóságának lekérése**

Az Aspose.Slides lehetővé teszi a képhez alkalmazott átlátszósági hatás lekérését. Ez a Java kód bemutatja a műveletet:

```java
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

## **Képkeret formázása**

Az Aspose.Slides számos formázási lehetőséget kínál, amelyeket egy képkeretre lehet alkalmazni. Ezekkel a beállításokkal módosíthatja a képkeretet, hogy megfeleljen a specifikus követelményeknek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia referenciáját az indexe alapján.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPPImage) objektumot úgy, hogy egy képet hozzáad a a prezentáció objektumhoz tartozó [IImagescollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IImageCollection) gyűjteményhez, amelyet az alakzat kitöltésére használ.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame`-et a kép szélessége és magassága alapján a [AddPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódus segítségével, amelyet a hivatkozott diához tartozó [IShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) objektum biztosít.  
6. Adjon a képkeretet (amely a képet tartalmazza) a diára.  
7. Állítsa be a képkeret vonalszínét.  
8. Állítsa be a képkeret vonalszélességét.  
9. Forgassa el a képkeretet pozitív vagy negatív érték megadásával.  
   * A pozitív érték az órák irányába forgatja a képet.  
   * A negatív érték az óramutatóval ellentétes irányba forgatja a képet.  
10. Adjon a képkeretet (amely a képet tartalmazza) a diára.  
11. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód bemutatja a képkeret formázási folyamatát:

```java
// Példányosítja a PPTX-et képviselő Presentation osztályt
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Példányosítja az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Hozzáad egy képkeretet a kép magasságával és szélességével megegyezően
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Alkalmaz némi formázást a PictureFrameEx-re
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // A PPTX fájlt lemezre írja
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tipp" color="primary" %}}

Az Aspose nemrég egy ingyenes [Collage Maker](https://products.aspose.app/slides/hu/collage) szolgáltatást fejlesztett ki. Ha JPG/JPEG vagy PNG képeket szeretne **egyesíteni**, vagy fényképekből **rácsokat** készíteni, használhatja ezt a szolgáltatást. 

{{% /alert %}}

## **Kép hozzáadása linkként**

A nagy prezentációk méretének elkerülése érdekében a képeket (vagy videókat) linkeken keresztül adhatja hozzá a fájlok közvetlen beágyazása helyett. Ez a Java kód megmutatja, hogyan lehet képet és videót egy helyőrzőbe beilleszteni:

```java
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

Ez a Java kód megmutatja, hogyan lehet egy létező képet egy dián kivágni:

```java
Presentation pres = new Presentation();
// Új képobjektumot hoz létre
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Képkeretet ad a diához
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Vágja a képet (százalékos értékek)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Elmenti az eredményt
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **A kép vágott területeinek törlése**

Ha a keretben lévő kép vágott részeit szeretné törölni, használhatja a [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metódust. Ez a metódus a vágott képet vagy az eredeti képet adja vissza, ha a vágás nem szükséges.

Ez a Java kód bemutatja a műveletet:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lekéri a PictureFrame-et az első diáról
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Törli a PictureFrame kép vágott területeit és visszaadja a vágott képet
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Elmenti az eredményt
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 
A [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metódus a vágott képet a prezentáció képgyűjteményéhez adja. Ha a kép csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/)‑ben van felhasználva, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a végleges prezentációban a képek száma növekedni fog.  

A metódus a vágás során a WMF/EMF metafájlokat raszteres PNG képekké konvertálja. 
{{% /alert %}}

## **Képek tömörítése**

A [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) metódus segítségével tömöríthet egy képet egy prezentációban. Ez a metódus a kép méretét csökkenti az alakzat mérete és a megadott felbontás alapján, a vágott területek törlésének lehetőségével.

A kép méretét és felbontását a PowerPoint **Kép formátum > Képek tömörítése > Felbontás** funkciójához hasonlóan állítja be.

Az alábbi Java példák azt mutatják be, hogyan lehet egy képet tömöríteni egy prezentációban, célfelbontás megadásával és opcionálisan a vágott területek eltávolításával:

```java
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

Vagy közvetlenül egy saját DPI érték használatával:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Tömöríti a képet 150 DPI-re (web felbontás), eltávolítva a vágott területeket.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 
A metódus a képet alacsonyabb felbontásra konvertálja a alakzat mérete és a megadott DPI alapján. A vágott részek is törölhetők a fájlméret optimalizálása érdekében.  
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem kerül alkalmazásra. Emellett a JPEG minősége megmarad vagy a felbontás függvényében kissé csökken, ahogyan a PowerPoint kezeli a nagy felbontású JPEG‑eket. 
{{% /alert %}}

## **Arányok zárolása**

Ha azt szeretné, hogy egy képet tartalmazó alakzat megtartsa az oldalarányát a kép méreteinek módosítása után is, használhatja a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) metódust az *Arányok zárolása* beállítás aktiválásához.

Ez a Java kód megmutatja, hogyan lehet egy alakzat oldalarányát zárolni:

```java
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
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // állítsa be, hogy az alakzat átméretezéskor megtartsa az oldalarányt
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 
Ez az *Arányok zárolása* beállítás csak az alakzat oldalarányát őrzi meg, nem pedig a benne lévő képet. 
{{% /alert %}}

## **StretchOff tulajdonság használata**

A [StretchOffsetLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) és [StretchOffsetBottom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) tulajdonságok használatával az [IPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat) osztály segítségével megadhat egy kitöltő téglalapot.

Ha egy képhez nyújtás van megadva, a forrástéglalap skálázódik, hogy illeszkedjen a megadott kitöltő téglalaphoz. A kitöltő téglalap minden élét egy százalékos eltolás határozza meg a megfelelő alakzat határvonalához viszonyítva. A pozitív százalékos érték belső eltolást, a negatív pedig külső eltolást jelent.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia referenciáját az indexe alapján.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be az alakzat kitöltéstípusát.  
6. Állítsa be az alakzat képkitöltési módját.  
7. Adjon hozzá egy beállított képet az alakzat kitöltéséhez.  
8. Adja meg a kép eltolásait a alakzat határvonalához viszonyítva.  
9. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód egy olyan folyamatot mutat be, amelyben a StretchOff tulajdonságot használják:

```java
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

    // Hozzáad egy Rectangle típusú AutoShape-et
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Beállítja az alakzat kitöltéstípusát
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Beállítja az alakzat képkitöltési módját
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Beállítja a képet, hogy kitöltse az alakzatot
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Meghatározza a kép eltolásait az alakzat határoló keretének megfelelő élétől
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
//A PPTX fájlt lemezre írja
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hogyan tudom megtudni, hogy mely képformátumok támogatottak a PictureFrame‑hez?**

Az Aspose.Slides támogatja mind a raszteres (PNG, JPEG, BMP, GIF stb.), mind a vektoros (például SVG) képeket, amelyeket a [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/)‑hez rendelt képobjektum használ. A támogatott formátumok listája általában átfedi a dia- és képkonvertáló motor képességeit.

**Hogyan befolyásolja a tucatnyi nagy kép a PPTX méretét és teljesítményét?**

A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek linkeléssel csökkenthető a prezentáció mérete, de ekkor a külső fájloknak hozzáférhetőnek kell maradniuk. Az Aspose.Slides lehetővé teszi a képek linkként való hozzáadását a fájlméret csökkentése érdekében.

**Hogyan zárolhatom a képobjektumot a véletlen mozgatás/átméretezés ellen?**

Használja a [shape locks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) funkciót egy [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) esetén (például a mozgatás vagy átméretezés letiltásával). A zárási mechanizmus több alakzattípusra is vonatkozik, beleértve a [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) elemeket is.

**Megmarad-e az SVG vektorhűség, ha a prezentációt PDF‑re/képre exportáljuk?**

Az Aspose.Slides lehetővé teszi az SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/)-ből eredeti vektor formátumban. PDF‑re vagy raszteres formátumokra ([PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/) vagy [PNG](/slides/hu/androidjava/convert-powerpoint-to-png/)) exportáláskor az eredmény rasterizálódhat az export beállításaitól függően; a kinyerési viselkedés igazolja, hogy az eredeti SVG vektorként van tárolva.