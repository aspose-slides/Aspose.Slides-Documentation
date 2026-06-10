---
title: Java használatával jelenetek képkereteinek kezelése
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
- vektoros kép
- kép vágása
- levágott terület
- StretchOff tulajdonság
- képkeret formázása
- képkeret tulajdonságai
- relatív méretezés
- képhatás
- arány
- kép átlátszósága
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Képkeretek hozzáadása PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for Java használatával. Egyszerűsítse a munkafolyamatot és javítsa a diák tervezését."
---
## **Bevezetés**

A képkeret egy olyan alakzat, amely képet tartalmaz—úgy, mint egy kép a keretben.

Képet egy diához egy képkereten keresztül adhat hozzá. Így a kép formázásához a képkeret formázását használhatja.

{{% alert  title="Tip" color="primary" %}} 

Az Aspose ingyenes konvertereket biztosít—[JPEG a PowerPointba](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG a PowerPointba](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyek lehetővé teszik a felhasználók számára, hogy gyorsan prezentációkat hozzanak létre képekből. 

{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Hozzon létre egy [IPPImage]() objektumot a kép a prezentáció objektumhoz tartozó [IImagescollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IImageCollection) gyűjteményhez adásával, amely a alakzat kitöltésére lesz használva.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/PictureFrame) objektumot a kép szélessége és magassága alapján a `AddPictureFrame` metódus segítségével, amelyet a hivatkozott dián levő alakzat objektum tesz elérhetővé.  
6. Adjon hozzá egy képkeretet (amely a képet tartalmazza) a diára.  
7. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java‑kód bemutatja, hogyan hozhat létre egy képkeretet:

```java
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Létrehozza az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Képkeretet ad hozzá a kép megfelelő magasságával és szélességével
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // A PPTX fájlt a lemezre írja
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

A képkeretek lehetővé teszik, hogy gyorsan készítsen prezentációs diát képek alapján. Ha a képkeretet az Aspose.Slides mentési beállításaival kombinálja, manipulálhatja a be- és kimeneti műveleteket, hogy a képeket az egyik formátumból a másikba konvertálja. Érdemes megtekinteni ezeket az oldalakat: konvertálás [kép JPG‑re](https://products.aspose.com/slides/hu/java/conversion/image-to-jpg/); konvertálás [JPG‑ről képre](https://products.aspose.com/slides/hu/java/conversion/jpg-to-image/); konvertálás [JPG‑ről PNG‑re](https://products.aspose.com/slides/hu/java/conversion/jpg-to-png/), konvertálás [PNG‑ről JPG‑re](https://products.aspose.com/slides/hu/java/conversion/png-to-jpg/); konvertálás [PNG‑ről SVG‑re](https://products.aspose.com/slides/hu/java/conversion/png-to-svg/), konvertálás [SVG‑ről PNG‑re](https://products.aspose.com/slides/hu/java/conversion/svg-to-png/). 

{{% /alert %}}

## **Képkeret létrehozása relatív méretezéssel**

A kép relatív méretezésének módosításával összetettebb képkeretet hozhat létre. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Adjon hozzá egy képet a prezentáció képgyűjteményéhez.  
4. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPPImage) objektumot a kép a prezentáció objektumhoz tartozó [IImagescollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IImageCollection) gyűjteményhez adásával, amely a alakzat kitöltésére lesz használva.  
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java‑kód bemutatja, hogyan hozhat létre egy képkeretet relatív méretezéssel:

```java
// Létrehozza a Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Létrehozza az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Képkeretet ad hozzá a kép magasságának és szélességének megfelelően
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

Raster képeket nyerhet ki a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/PictureFrame) objektumokból, és mentheti őket PNG, JPG és más formátumokba. Az alábbi kódrészlet bemutatja, hogyan nyerjen ki egy képet a "sample.pptx" dokumentumból, és mentse PNG formátumban.

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

Amikor egy prezentáció SVG grafikákat tartalmaz, amelyek [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) alakzatokba vannak ágyazva, az Aspose.Slides for Java lehetővé teszi az eredeti vektorképek teljes hitelességgel történő visszanyerését. A dia alakzatgyűjteményének bejárásával azonosíthatja az egyes [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) objektumokat, ellenőrizheti, hogy a hozzájuk tartozó [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) SVG‑t tartalmaz‑e, majd elmentheti azt lemezre vagy stream‑be natív SVG formátumban.

Az alábbi kódrészlet bemutatja, hogyan nyerjen ki egy SVG képet egy képkeretből:

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

Az Aspose.Slides lehetővé teszi, hogy lekérje egy képre alkalmazott átlátszósági hatást. Ez a Java‑kód demonstrálja a műveletet:

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

Az Aspose.Slides számos formázási lehetőséget kínál, amelyeket egy képkeretre lehet alkalmazni. Ezekkel a lehetőségekkel módosíthatja a képkeretet, hogy megfeleljen a specifikus követelményeknek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPPImage) objektumot a kép a prezentáció objektumhoz tartozó [IImagescollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IImageCollection) gyűjteményhez adásával, amely a alakzat kitöltésére lesz használva.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame` objektumot a kép szélessége és magassága alapján a [AddPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódus segítségével, amelyet a hivatkozott diához tartozó [IShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) objektum biztosít.  
6. Adja hozzá a képkeretet (amely a képet tartalmazza) a diához.  
7. Állítsa be a képkeret vonal színét.  
8. Állítsa be a képkeret vonal vastagságát.  
9. Forgassa el a képkeretet pozitív vagy negatív érték megadásával.  
   * A pozitív érték az órakor irányába forgatja a képet.  
   * A negatív érték az óramutatóval ellentétesen forgatja a képet.  
10. Adja hozzá a képkeretet (amely a képet tartalmazza) a diához.  
11. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java‑kód demonstrálja a képkeret formázási folyamatát:

```java
// Létrehozza a Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Létrehozza az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Képkeretet ad hozzá a kép magasságának és szélességének megfelelően
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Néhány formázást alkalmaz a PictureFrameEx-re
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

{{% alert title="Tip" color="primary" %}}

Az Aspose nemrég fejlesztett egy [ingyenes Collage Maker](https://products.aspose.app/slides/hu/collage) szolgáltatást. Ha valaha is [JPG/JPEG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG képeket kell egyesítenie, vagy [rácsokat szeretne létrehozni fényképekből](https://products.aspose.app/slides/hu/collage/photo-grid), használhatja ezt a szolgáltatást. 

{{% /alert %}}

## **Kép hozzáadása hivatkozásként**

A nagy méretű prezentációk elkerülése érdekében képeket (vagy videókat) hivatkozásokon keresztül adhat hozzá ahelyett, hogy a fájlokat közvetlenül beágyazná a prezentációba. Ez a Java‑kód mutatja, hogyan adjon egy képet és videót egy helyőrzőhöz:

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

Ez a Java‑kód bemutatja, hogyan vághat le egy meglévő képet egy dián:

```java
Presentation pres = new Presentation();
// Új képtárgyat hoz létre
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Képkeretet ad egy diához
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // A képet levágja (százalékos értékek)
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

## **Levágott területek törlése egy képből**

Ha egy keretben lévő kép levágott területeit szeretné törölni, használhatja a [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metódust. Ez a metódus a levágott képet vagy a eredeti képet adja vissza, ha a vágás nem szükséges.

Ez a Java‑kód demonstrálja a műveletet:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lekéri a PictureFrame-et az első diáról
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Törli a PictureFrame kép levágott területeit és visszaadja a levágott képet
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Elmenti az eredményt
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

A [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metódus a levágott képet a prezentáció képgyűjteményéhez adja. Ha a kép csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/)‑ben van használva, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a végleges prezentációban lévő képek száma növekedni fog.

Ez a metódus a vágási művelet során a WMF/EMF metafájlokat raster PNG képpé konvertálja. 

{{% /alert %}}

## **Képek tömörítése**

A [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) metódussal tömörítheti a prezentációban lévő képet. Ez a metódus a kép méretét a shape mérete és a megadott felbontás alapján csökkenti, opcionálisan a levágott területek törlésével.

A kép méretét és felbontását úgy állítja be, mint a PowerPoint **Kép formátum -> Képek tömörítése -> Felbontás** funkciója.

Az alábbi Java‑példák bemutatják, hogyan tömöríthet egy képet a prezentációban célfelbontás megadásával és opcionálisan a levágott területek eltávolításával:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // A képet 150 DPI (web felbontás) célfelbontással tömöríti, és eltávolítja a levágott területeket.
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

Vagy közvetlenül egy egyedi DPI értékkel:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // A képet 150 DPI (web felbontás) felbontásra tömöríti, eltávolítva a levágott területeket.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

A metódus a képet alacsonyabb felbontásra konvertálja a shape mérete és a megadott DPI alapján. A levágott területek szintén törölhetők a fájlméret optimalizálása érdekében.  
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem kerül alkalmazásra. A JPEG minőség a felbontás alapján megmarad vagy enyhén csökken, ahogyan a PowerPoint kezeli a magas felbontású JPEG‑eket. 

{{% /alert %}}

## **Arányok zárolása**

Ha azt szeretné, hogy egy képet tartalmazó alakzat megőrizze az arányait a kép méretének módosítása után is, használhatja a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) metódust az *Arányok zárolása* beállítás aktiválásához. 

Ez a Java‑kód bemutatja, hogyan zárolhatja egy alakzat arányait:

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

    // állítsa be, hogy az alakzat a méretezéskor megőrizze az arányt
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Ez az *Arányok zárolása* beállítás csak az alakzat arányait őrzi meg, nem pedig a benne lévő képet. 

{{% /alert %}}

## **A StretchOff tulajdonság használata**

A [StretchOffsetLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) és [StretchOffsetBottom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) tulajdonságok használatával a [IPictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat) interfészben és a [PictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat) osztályban megadhat egy kitöltési téglalapot. 

Ha egy képhez nyújtás van megadva, egy forrástéglalap úgy méreteződik, hogy illeszkedjen a megadott kitöltési téglalapba. A kitöltési téglalap minden széle egy százalékos eltolással van meghatározva a shape határoló dobozának megfelelő oldalához képest. A pozitív százalékos érték befoglalást, a negatív pedig kiterjesztést jelent.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be a shape kitöltési típusát.  
6. Állítsa be a shape képkitöltési módját.  
7. Adjon hozzá egy képet a shape kitöltéséhez.  
8. Adja meg a kép eltolásait a shape határoló dobozának megfelelő oldalához képest.  
9. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java‑kód bemutatja a StretchOff tulajdonság használatát:

```java
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide slide = pres.getSlides().get_Item(0);

    // Létrehozza az ImageEx osztályt
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // AutoShape-et ad hozzá, típus: Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Beállítja az alakzat kitöltés típusát
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Beállítja az alakzat képkitöltés módját
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Beállítja a képet az alakzat kitöltéséhez
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Megadja a kép eltolásait az alakzat határoló dobozának megfelelő oldalhoz képest
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // A PPTX fájlt a lemezre írja
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hogyan tudom megtudni, hogy mely képformátumok támogatottak a PictureFrame‑hez?**

Az Aspose.Slides támogatja a raszteres képeket (PNG, JPEG, BMP, GIF stb.) és a vektoros képeket (például SVG) a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/)‑hez rendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedésben van a dia‑ és kép‑konverziós motor képességeivel.

**Hogyan befolyásolja a több tucat nagy kép PPTX méretét és teljesítményét?**

A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek hivatkozásként történő hozzáadása segít a prezentáció méretének csökkentésében, de a külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetővé teszi a képek hivatkozás szerinti hozzáadását a fájlméret csökkentése érdekében.

**Hogyan tudom zárolni a képobjektumot a véletlen mozgatás/átméretezés ellen?**

Használjon [shape locks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) egy [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) esetén (például a mozgatás vagy átméretezés letiltásával). A zárolási mechanizmust a shape‑ek védelméről szóló külön [protection article](/slides/hu/java/applying-protection-to-presentation/) tárgyalja, és különböző shape‑típusok, köztük a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) támogatja.

**Megmarad-e az SVG vektorfidelitás a prezentáció PDF‑re/képre exportálásakor?**

Az Aspose.Slides lehetővé teszi egy SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/)-ből eredeti vektorként. PDF‑re ([export to PDF](/slides/hu/java/convert-powerpoint-to-pdf/)) vagy raszteres formátumokra ([export to PNG](/slides/hu/java/convert-powerpoint-to-png/)) exportáláskor az eredmény a beállításoktól függően rasterizálódhat; a kinyerési viselkedés megerősíti, hogy az eredeti SVG vektor marad.