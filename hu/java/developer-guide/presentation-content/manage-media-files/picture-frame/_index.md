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
- raszter kép
- vektor kép
- kép vágása
- vágott terület
- StretchOff tulajdonság
- képkeret formázása
- képkeret tulajdonságai
- relatív méretezés
- képhatás
- oldalarány
- kép átlátszósága
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Képkeretek hozzáadása PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for Java segítségével. Egyszerűsítse a munkafolyamatot és javítsa a dia tervezését."
---
## **Bevezetés**

A képkeret egy olyan alakzat, amely egy képet tartalmaz—mint egy kép a keretben. 

Képet egy diára egy képkereten keresztül adhat hozzá. Így a kép formázását a képkeret formázásával végezheti el.

{{% alert  title="Tip" color="primary" %}} 

Az Aspose ingyenes konvertereket biztosít—[JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyek lehetővé teszik, hogy a felhasználók gyorsan prezentációkat készítsenek képekből. 

{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezzen be egy dia hivatkozást az indexe alapján.  
3. Hozzon létre egy [IPPImage]() objektumot azáltal, hogy egy képet hozzáad a [IImagescollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IImageCollection) a prezentáció objektumához, amelyet az alakzat kitöltésére használnak.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/PictureFrame) a kép szélessége és magassága alapján az `AddPictureFrame` metódus segítségével, amely a hivatkozott dia alakzatobjektumán keresztül érhető el.  
6. Adjon hozzá egy képkeretet (amely a képet tartalmazza) a diához.  
7. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód bemutatja, hogyan hozhat létre egy képkeretet:

```java
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt reprezentál
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Példányosítja az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Hozzáad egy képkeretet a kép megfelelő magasságával és szélességével
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // A PPTX fájlt leírja a lemezre
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

A képkeretek lehetővé teszik, hogy gyorsan hozzon létre prezentációs diákot képek alapján. Ha a képkeretet kombinálja az Aspose.Slides mentési beállításaival, szabályozhatja a bemeneti/kimeneti műveleteket a képek formátumok közti átalakításához. Érdemes megtekinteni ezeket az oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/java/conversion/image-to-jpg/); konvertálás [JPG to image](https://products.aspose.com/slides/hu/java/conversion/jpg-to-image/); konvertálás [JPG to PNG](https://products.aspose.com/slides/hu/java/conversion/jpg-to-png/), konvertálás [PNG to JPG](https://products.aspose.com/slides/hu/java/conversion/png-to-jpg/); konvertálás [PNG to SVG](https://products.aspose.com/slides/hu/java/conversion/png-to-svg/), konvertálás [SVG to PNG](https://products.aspose.com/slides/hu/java/conversion/svg-to-png/).  

{{% /alert %}}

## **Képkeret létrehozása relatív méretezéssel**

A kép relatív méretezésének módosításával összetettebb képkeretet hozhat létre. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezzen be egy dia hivatkozást az indexe alapján.  
3. Adjon hozzá egy képet a prezentáció képgyűjteményéhez.  
4. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPPImage) objektumot azáltal, hogy egy képet hozzáad a [IImagescollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IImageCollection) a prezentáció objektumához, amelyet az alakzat kitöltésére használnak.  
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód bemutatja, hogyan hozhat létre egy képkeretet relatív méretezéssel:

```java
// Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Példányosítja az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Hozzáad egy képkeretet a kép magasságával és szélességével megegyezően
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Beállítja a relatív méretezés magasságát és szélességét
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // A PPTX fájlt leírja a lemezre
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rasterképek kinyerése képkeretekből**

Rasterképeket nyerhet ki a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/PictureFrame) objektumokból, és mentheti őket PNG, JPG és egyéb formátumokba. Az alábbi kódrészlet bemutatja, hogyan nyer ki egy képet a „sample.pptx” dokumentumból, és menti PNG formátumban.

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

Amikor egy prezentáció SVG grafikákat tartalmaz, amelyeket [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) alakzatokba helyeztek, az Aspose.Slides for Java lehetővé teszi az eredeti vektorképek teljes pontosságú kinyerését. A dia alakzatgyűjteményének bejárásával azonosítható minden [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/), ellenőrizhető, hogy a mögöttes [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) tartalmaz‑e SVG tartalmat, majd a képet lemezre vagy folyamra menthetjük natív SVG formátumban.

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

## **Kép átlátszóságának lekérdezése**

Az Aspose.Slides lehetővé teszi a képre alkalmazott átlátszósági hatás lekérdezését. Ez a Java kód demonstrálja a műveletet:

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

## **Kép fényerő és kontrasztjának lekérdezése**

Az Aspose.Slides lehetővé teszi a képre alkalmazott fényerő‑ és kontraszt‑hatás lekérdezését. Az [ILuminance](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iluminance/) interfész képviseli ezt a képpárbeszéd‑effektet.

Ez a Java kód bemutatja, hogyan kérdezheti le a fényerő és kontraszt beállításait egy képkeretből:

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

Az Aspose.Slides számos formázási lehetőséget biztosít, amelyeket egy képkeretre alkalmazhat. Ezekkel a lehetőségekkel módosíthatja a képkeretet, hogy megfeleljen a specifikus követelményeknek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezzen be egy dia hivatkozást az indexe alapján.  
3. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPPImage) objektumot azáltal, hogy egy képet hozzáad a [IImagescollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IImageCollection) a prezentáció objektumához, amelyet az alakzat kitöltésére használnak.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame`‑et a kép szélessége és magassága alapján az [AddPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódus segítségével, amely a [IShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) objektumon keresztül érhető el a hivatkozott dián.  
6. Adjon hozzá a képkeretet (amely a képet tartalmazza) a diához.  
7. Állítsa be a képkeret vonalszínét.  
8. Állítsa be a képkeret vonalvastagságát.  
9. Forgassa el a képkeretet egy pozitív vagy negatív érték megadásával.  
   * A pozitív érték az képet az óramutató járása irányában forgatja.  
   * A negatív érték az óramutató járása ellenkező irányban forgatja.  
10. Adjon hozzá a képkeretet (amely a képet tartalmazza) a diához.  
11. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód demonstrálja a képkeret formázási folyamatát:

```java
// Példányosítja a Presentation osztályt, amely a PPTX-et reprezentálja
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Példányosítja az Image osztályt
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Hozzáad egy képkeretet a kép magasságával és szélességével megegyezően
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Alkalmaz néhány formázást a PictureFrameEx-re
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // A PPTX fájlt leírja a lemezre
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Az Aspose nemrég fejlesztett egy [free Collage Maker](https://products.aspose.app/slides/hu/collage) szolgáltatást. Ha valaha is [JPG/JPEG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG képeket kell egyesíteni, vagy [rácsokat kell létrehozni fotókból](https://products.aspose.app/slides/hu/collage/photo-grid), ezt a szolgáltatást használhatja. 

{{% /alert %}}

## **Kép hozzáadása linkként**

A nagy méretű prezentációk elkerülése érdekében képeket (vagy videókat) linkekkel adhat hozzá a beágyazás helyett. Ez a Java kód bemutatja, hogyan adjon képet és videót egy helyőrzőhöz:

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

Ez a Java kód bemutatja, hogyan vághat le egy meglévő képet egy dián:

```java
Presentation pres = new Presentation();
// Új kép objektumot hoz létre
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Képkeretet ad hozzá egy diahoz
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Levágja a képet (százalék értékek)
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

## **Képkeret vágott területeinek törlése**

Ha egy keretben lévő kép vágott területeit szeretné törölni, használhatja a [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metódust. Ez a metódus a vágott képet vagy az eredeti képet adja vissza, ha a vágás nem szükséges.

Ez a Java kód demonstrálja a műveletet:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lekéri a PictureFrame-et az első diából
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Törli a PictureFrame képének vágott területeit, és visszaadja a vágott képet
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Elmenti az eredményt
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

A [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) metódus a vágott képet hozzáadja a prezentáció képgyűjteményéhez. Ha a kép csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/)‑ben van használva, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a létrejövő prezentációban lévő képek száma növekedni fog.

Ez a metódus a WMF/EMF metafájlokat raster PNG képpé konvertálja a vágási művelet során. 

{{% /alert %}}

## **Képek tömörítése**

Képet tömöríthet egy prezentációban a [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) metódussal. Ez a metódus a kép méretét csökkenti az alakzat mérete és a megadott felbontás alapján, és opcionálisan törli a vágott területeket.

A kép méretét és felbontását hasonlóan állítja be, mint a PowerPoint **Picture Format -> Compress Pictures -> Resolution** funkciója.

A következő Java példák bemutatják, hogyan lehet egy képet tömöríteni egy prezentációban, megadva a célfelbontást és opcionálisan a vágott területek eltávolítását:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Tömöríti a képet 150 DPI (webfelbontás) célfelbontással és eltávolítja a vágott területeket.
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

Vagy egy egyedi DPI értékkel közvetlenül:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Tömöríti a képet 150 DPI-re (webfelbontás), és eltávolítja a vágott területeket.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

A metódus a képet alacsonyabb felbontásra konvertálja az alakzat mérete és a megadott DPI alapján. A vágott területek is törölhetők a fájlméret optimalizálása érdekében.  
Ha a kép egy metafájl (WMF/EMF) vagy SVG, a tömörítés nem kerül alkalmazásra. A JPEG minőség pedig a felbontástól függően marad meg vagy enyhén csökken, hasonlóan a PowerPoint magas felbontású JPEG‑ek kezeléséhez.  

{{% /alert %}}

## **Oldalarány rögzítése**

Ha azt szeretné, hogy egy képet tartalmazó alakzat megtartsa az oldalarányát a kép méretének módosítása után is, használhatja a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) metódust az *Oldalarány rögzítése* beállítás beállításához. 

Ez a Java kód bemutatja, hogyan rögzítheti egy alakzat oldalarányát:

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

    // Beállítja, hogy az alakzat az átméretezéskor megőrizze az oldalarányt
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Ez az *Oldalarány rögzítése* beállítás csak az alakzat oldalarányát őrzi meg, nem a benne lévő képet.  

{{% /alert %}}

## **StretchOff tulajdonság használata**

A [StretchOffsetLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) és [StretchOffsetBottom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) tulajdonságok használatával a [IPictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat) interfészből és a [PictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPictureFillFormat) osztályból egy kitöltő téglalapot adhat meg. 

Ha nyújtás van megadva egy képhez, a forrástéglalap skálázódik, hogy illeszkedjen a megadott kitöltő téglalaphoz. A kitöltő téglalap minden széle egy százalékos eltolással van definiálva az alakzat határoló keretének megfelelő élétől. A pozitív százalékos érték beszúrást jelent, a negatív pedig kinyújtást.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezzen be egy dia hivatkozást az indexe alapján.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be az alakzat kitöltési típusát.  
6. Állítsa be az alakzat képkitöltési módját.  
7. Adjon hozzá egy beállított képet az alakzat kitöltéséhez.  
8. Adja meg a kép eltolásait a alakzat határoló keretének megfelelő élétől.  
9. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a Java kód demonstrálja a StretchOff tulajdonság használatát:

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

    // Hozzáad egy AutoShape-et, amely Rectangle típusú
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Beállítja az alakzat kitöltési típusát
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Beállítja az alakzat képkitöltési módját
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Beállítja a képet az alakzat kitöltéséhez
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Megadja a kép eltolásait a alakzat határoló keretének megfelelő élétől
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // A PPTX fájlt leírja a lemezre
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hogyan tudom megtudni, mely képformátumok támogatottak a PictureFrame‑hez?**

Az Aspose.Slides támogatja mind a raster (PNG, JPEG, BMP, GIF stb.), mind a vektor (például SVG) képeket a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/)‑hez hozzárendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedésben van a dia és a képkonverziós motor képességeivel.

**Hogyan befolyásolja a tucatnyi nagy kép a PPTX méretét és teljesítményét?**

A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek hivatkozásként történő hozzáadása segít alacsonyan tartani a prezentáció méretét, de a külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetővé teszi a képek linkkel történő hozzáadását a fájlméret csökkentése érdekében.

**Hogyan rögzíthetem egy képobjektumot, hogy ne legyen véletlenül áthelyezve vagy átméretezve?**

Használja a [shape locks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) funkciót egy [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) esetén (például a mozgatás vagy átméretezés tiltása). A zárási mechanizmust a formákra vonatkozó különálló [protection article](/slides/hu/java/applying-protection-to-presentation/) taglalja, és számos alakzattípusra, köztük a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/), támogatott.

**Megmarad-e az SVG vektorgenerálás pontossága, ha a prezentációt PDF‑re/képekre exportálom?**

Az Aspose.Slides lehetővé teszi egy SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/)-ből eredeti vektorként. PDF‑re vagy [raster formátumokra](/slides/hu/java/convert-powerpoint-to-png/) történő exportáláskor az eredmény rasterizálódhat az exportbeállításoktól függően; a kinyerési viselkedés megerősíti, hogy az eredeti SVG vektor marad.