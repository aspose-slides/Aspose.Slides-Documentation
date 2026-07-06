---
title: Képkeretek kezelése prezentációkban Androidon
linktitle: Képkeret
type: docs
weight: 10
url: /hu/androidjava/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- kép hozzáadása
- kép létrehozása
- kép kinyerése
- raszter kép
- vektor kép
- kép vágása
- vágott terület
- StretchOff tulajdonság
- képkeret formázása
- képkeret tulajdonságai
- relatív méretezés
- kép hatás
- oldalarány
- kép átlátszóság
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Képkeretek hozzáadása PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for Android via Java segítségével. Egyszerűsítse a munkafolyamatot és javítsa a diák tervezését."
---
## **Bevezetés**

A képkeret egy alakzat, amely képet tartalmaz—úgy, mint egy kép a keretben.

Képet adhat hozzá egy diára egy képkereten keresztül. Így a kép formázását a képkeret formázásával végezheti.

{{% alert title="Tipp" color="primary" %}} 
Az Aspose ingyenes konvertereket biztosít—[JPEG PowerPoint-hoz](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG PowerPoint-hoz](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyek lehetővé teszik, hogy a felhasználók gyorsan prezentációkat hozzanak létre képekből. 
{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze be egy dia referenciaját az indexe alapján.  
3. Hozzon létre egy [IPPImage]() objektumot a képet a [IImagescollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IImageCollection) gyűjteményhez adva, amely a prezentációobjektumhoz kapcsolódik, és a forma kitöltéséhez lesz használva.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PictureFrame) objektumot a kép szélessége és magassága alapján az `AddPictureFrame` metóduson keresztül, amely a hivatkozott dia alakzatobjektuma által érhető el.  
6. Adjon hozzá egy képkeretet (amely a képet tartalmazza) a diához.  
7. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód bemutatja, hogyan hozhat létre egy képkeretet:

```java
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Létrehozza az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Hozzáad egy képkeretet a kép megfelelő magasságával és szélességével
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // A PPTX fájlt a lemezre írja
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Képkeret létrehozása relatív méretezéssel**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze be egy dia referenciaját az indexe alapján.  
3. Adjon hozzá egy képet a prezentáció képgyűjteményéhez.  
4. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPPImage) objektumot a képet a [IImagescollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IImageCollection) gyűjteményhez adva, amely a prezentációobjektumhoz kapcsolódik, és a forma kitöltéséhez lesz használva.  
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód bemutatja, hogyan hozhat létre egy képkeretet relatív méretezéssel:

```java
// Létrehozza a Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Létrehozza az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Hozzáad egy képkeretet a kép magasságával és szélességével megegyezően
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // A relatív méretezés szélességének és magasságának beállítása
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // A PPTX fájlt a lemezre írja
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Raster képek kinyerése képkeretekből**

Raster képeket nyerhet ki [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PictureFrame) objektumokból, és mentheti őket PNG, JPG és egyéb formátumokba. Az alábbi kódrészlet bemutatja, hogyan nyerhet ki egy képet a "sample.pptx" dokumentumból, és mentheti PNG formátumban.

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

Amikor egy prezentáció SVG grafikákat tartalmaz, amelyeket [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) alakzatokba helyeztek, az Aspose.Slides for Android Java segítségével visszanyerheti az eredeti vektorképeket teljes pontossággal. A dia alakzatgyűjteményének bejárásával azonosíthatja az egyes [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) objektumokat, ellenőrizheti, hogy az alatta lévő [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) SVG tartalmat tartalmaz‑e, majd elmentheti azt a lemezen vagy egy streamben natív SVG formátumban.

Az alábbi kódrészlet bemutatja, hogyan nyerhet ki egy SVG képet egy képkeretből:

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

Az Aspose.Slides lehetővé teszi, hogy lekérje egy képre alkalmazott átlátszósági hatást. Ez a Java kód bemutatja a műveletet:

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

## **Kép fényerő és kontraszt beállításainak lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy képre alkalmazott fényerő‑ és kontraszt‑hatást. A [ILuminance](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iluminance/) interfész ezt a képet átalakító hatást képviseli.

Ez a Java kód bemutatja, hogyan kérheti le a fényerő és kontraszt beállításait egy képkeretből:

```java
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

Az Aspose.Slides számos formázási lehetőséget kínál, amelyeket egy képkeretre lehet alkalmazni. Ezekkel a lehetőségekkel módosíthatja a képkeretet, hogy megfeleljen a konkrét követelményeknek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze be egy dia referenciaját az indexe alapján.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPPImage) objektumot a képet a [IImagescollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IImageCollection) gyűjteményhez adva, amely a prezentációobjektumhoz kapcsolódik, és a forma kitöltéséhez lesz használva.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame` objektumot a kép szélessége és magassága alapján a [AddPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metóduson keresztül, amely a [IShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) objektumhoz kapcsolódik a hivatkozott dián.  
6. Adja hozzá a képkeretet (amely a képet tartalmazza) a diához.  
7. Állítsa be a képkeret vonalszínét.  
8. Állítsa be a képkeret vonalvastagságát.  
9. Forgassa el a képkeretet pozitív vagy negatív érték megadásával.  
   * A pozitív érték az ábrát az óramutató járása szerint forgatja.  
   * A negatív érték az ábrát az óramutató járásával ellentétes irányban forgatja.  
10. Adja hozzá a képkeretet (amely a képet tartalmazza) a diához.  
11. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód bemutatja a képkeret formázási folyamatát:

```java
// Létrehozza a Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Létrehozza az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Hozzáad egy képkeretet a kép magasságával és szélességével megegyezően
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Alkalmaz némi formázást a PictureFrameEx-re
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // A PPTX fájlt a lemezre írja
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tipp" color="primary" %}}

Az Aspose nemrég fejlesztett egy [ingyenes Collage Maker](https://products.aspose.app/slides/hu/collage) alkalmazást. Ha valaha is össze kell [összeillesztenie JPG/JPEG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG képeket, vagy [rácsokat kell létrehoznia fotókból](https://products.aspose.app/slides/hu/collage/photo-grid), használhatja ezt a szolgáltatást. 
{{% /alert %}}

## **Kép hozzáadása linkként**

A nagy prezentációs méretek elkerülése érdekében képeket (vagy videókat) is hozzáadhat linkeken keresztül, ahelyett, hogy közvetlenül beágyazná a fájlokat a prezentációkba. Ez a Java kód bemutatja, hogyan adhat hozzá képet és videót egy helykitöltőbe:

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

Ez a Java kód bemutatja, hogyan vághat le egy már létező képet egy dián:

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

    // Képkeretet ad hozzá egy diához
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Levágja a képet (százalékos értékek)
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

## **Vágott területek törlése egy képből**

Ha törölni szeretné egy képkeretben lévő kép vágott részeit, használhatja a [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metódust. Ez a metódus a vágott képet, vagy a forrásképet adja vissza, ha a vágás nem szükséges.

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

A [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metódus a vágott képet a prezentáció képgyűjteményéhez adja. Ha a kép csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/)‑ben van használva, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a végső prezentációban a képek száma növekedni fog.

A metódus a vágási művelet során a WMF/EMF meta‑fájlokat raszter PNG képpé konvertálja. 
{{% /alert %}}

## **Képek tömörítése**

A [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) metódus segítségével tömöríthet egy képet a prezentációban. Ez a metódus a képet a forma mérete és a megadott felbontás alapján csökkenti, a vágott területek törlésének lehetőségével.

A kép méretét és felbontását úgy állítja be, ahogy a PowerPoint **Picture Format > Compress Pictures > Resolution** funkciója.

Az alábbi Java példák azt mutatják be, hogyan tömöríthet egy képet a prezentációban egy célfelbontás megadásával, és opcionálisan a vágott területek eltávolításával:

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

Vagy közvetlenül egy egyéni DPI érték használatával:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Tömöríti a képet 150 DPI (web felbontás) értékre, eltávolítva a vágott területeket.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 

A metódus a képet alacsonyabb felbontásra konvertálja a forma mérete és a megadott DPI alapján. A vágott területek is törölhetők a fájlméret optimalizálása érdekében.  
Ha a kép meta‑fájl (WMF/EMF) vagy SVG, a tömörítés nem lesz alkalmazva. Emellett a JPEG minősége a felbontás függvényében marad vagy csak enyhén csökken, ahogy a PowerPoint kezeli a magas felbontású JPEG‑eket.
{{% /alert %}}

## **Arányok rögzítése**

Ha azt szeretné, hogy egy képet tartalmazó forma megőrizze az arányait akkor is, ha a kép méreteit megváltoztatja, a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) metódust használhatja az *Arányok rögzítése* beállítás beállításához.

Ez a Java kód bemutatja, hogyan rögzítheti egy forma arányait:

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

    // állítsa be a formát, hogy átméretezéskor megőrizze az oldalarányt
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 

Ez az *Arányok rögzítése* beállítás csak a forma arányait őrzi meg, nem a benne lévő képet. 
{{% /alert %}}

## **A StretchOff tulajdonság használata**

A [StretchOffsetLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) és [StretchOffsetBottom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) tulajdonságok a [IPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat) interfészből és a [PictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPictureFillFormat) osztályból lehetővé teszik egy kitöltő téglalap meghatározását.

Ha egy képet nyújtunk, akkor egy forrástéglalap kerül átméretezésre, hogy illeszkedjen a megadott kitöltő téglalaphoz. A kitöltő téglalap minden éle egy százalékos eltolással van meghatározva, amely a forma korlátos dobozának megfelelő élétől számít. A pozitív százalékos érték egy belső eltolást jelent, a negatív pedig egy külső eltolást.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze be egy dia referenciaját az indexe alapján.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be a forma kitöltési típusát.  
6. Állítsa be a forma képkitöltési módját.  
7. Adjon hozzá egy képet a forma kitöltéséhez.  
8. Adja meg a kép eltolásait a forma korlátos dobozának megfelelő élhez képest.  
9. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód mutat egy folyamatot, amelyben a StretchOff tulajdonságot használja:

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

    // AutoShape hozzáadása Rectangle típusra
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Beállítja a forma kitöltési típusát
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Beállítja a forma képkitöltési módját
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Beállítja a képet a forma kitöltésére
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Megadja a kép eltolásait a forma körülhatároló dobozának megfelelő élétől
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //Writes the PPTX file to disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hogyan tudom megtudni, hogy mely képformátumok támogatottak a PictureFrame‑hez?**

Az Aspose.Slides mind raszter képeket (PNG, JPEG, BMP, GIF stb.), mind vektor képeket (például SVG) támogat a [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/)‑hez rendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedi a dia‑ és képkonverziós motor képességeit.

**Hogyan befolyásolja a több tucat nagy kép hozzáadása a PPTX méretét és teljesítményét?**

A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek linkként való hivatkozása segít csökkenteni a prezentáció méretét, de megköveteli, hogy a külső fájlok elérhetők maradjanak. Az Aspose.Slides lehetőséget biztosít a képek linkként történő hozzáadására a fájlméret csökkentése érdekében.

**Hogyan rögzíthetem egy képobjektust a véletlen áthelyezés/túlméretezés ellen?**

Használja a [shape locks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) funkciót egy [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) esetén (például a mozgatás vagy átméretezés letiltása). A zárolási mechanizmus több alakzattípusra is érvényes, beleértve a [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/)‑t is.

**Megmarad-e az SVG vektor pontossága, ha a prezentációt PDF‑be vagy képfájlokba exportáljuk?**

Az Aspose.Slides lehetővé teszi egy SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/)‑ből eredeti vektorként. PDF‑re vagy raszter formátumokra ([PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/) vagy [PNG](/slides/hu/androidjava/convert-powerpoint-to-png/)) történő exportálás esetén az eredmény a beállításoktól függően raszterizálódhat; a kinyerés viselkedése megerősíti, hogy az eredeti SVG vektor marad.