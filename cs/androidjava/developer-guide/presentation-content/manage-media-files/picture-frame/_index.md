---
title: "Správa obrázkových rámečků v prezentacích na Androidu"
linktitle: "Obrázkový rámeček"
type: docs
weight: 10
url: /cs/androidjava/picture-frame/
keywords:
- obrázkový rámeček
- přidat obrázkový rámeček
- vytvořit obrázkový rámeček
- přidat obrázek
- vytvořit obrázek
- extrahovat obrázek
- rastrový obrázek
- vektorový obrázek
- oříznout obrázek
- oříznutá oblast
- vlastnost StretchOff
- formátování obrázkového rámečku
- vlastnosti obrázkového rámečku
- relativní měřítko
- efekt obrázku
- poměr stran
- průhlednost obrázku
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přidejte obrázkové rámečky do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Android přes Java. Zjednodušte svůj pracovní postup a vylepšete návrhy snímků."
---
## **Úvod**

Obrázkový rámeček je tvar, který obsahuje obrázek – je to jako obrázek v rámu.

Obrázek můžete na snímku přidat pomocí obrázkového rámečku. Tímto způsobem můžete obrázek formátovat úpravou vlastností rámečku.

{{% alert  title="Tip" color="primary" %}} 
Aspose poskytuje zdarma konvertory – [JPEG na PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG na PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt) – které uživatelům umožňují rychle vytvářet prezentace z obrázků. 
{{% /alert %}} 

## **Vytvoření obrázkového rámečku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu. 
3. Vytvořte objekt [IPPImage]() přidáním obrázku do kolekce [IImagescollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IImageCollection) spojené s objektem prezentace, který bude použit k vyplnění tvaru.
4. Zadejte šířku a výšku obrázku.
5. Vytvořte [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/PictureFrame) na základě šířky a výšky obrázku pomocí metody `AddPictureFrame`, kterou nabízí objekt tvaru spojený s odkazovaným snímkem.
6. Přidejte obrázkový rámeček (obsahující obrázek) na snímek.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód vám ukáže, jak vytvořit obrázkový rámeček:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získá první snímek
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Vytvoří instanci třídy Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Přidá obrázkový rámeček s výškou a šířkou odpovídající obrázku
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Zapíše soubor PPTX na disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vytvoření obrázkového rámečku s relativním měřítkem**

Úpravou relativního měřítka obrázku můžete vytvořit složitější obrázkový rámeček. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu. 
3. Přidejte obrázek do kolekce obrázků prezentace.
4. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPPImage) přidáním obrázku do kolekce [IImagescollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IImageCollection) spojené s objektem prezentace, která bude použita k vyplnění tvaru.
5. Zadejte relativní šířku a výšku obrázku v obrázkovém rámečku.
6. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód vám ukáže, jak vytvořit obrázkový rámeček s relativním měřítkem:

```java
// Vytvořte instanci třídy Presentation, která představuje PPTX
Presentation pres = new Presentation();
try {
    // Získejte první snímek
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Vytvořte instanci třídy Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Přidejte obrázkový rámeček s výškou a šířkou odpovídající obrázku
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Nastavení relativního měřítka šířky a výšky
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Zapíšete soubor PPTX na disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extrahování rastrových obrázků z obrázkových rámečků**

Můžete extrahovat rastrové obrázky z objektů [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/PictureFrame) a uložit je ve formátech PNG, JPG a dalších. Následující ukázkový kód demonstruje, jak extrahovat obrázek z dokumentu „sample.pptx“ a uložit jej ve formátu PNG.

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

## **Extrahování SVG obrázků z obrázkových rámečků**

Když prezentace obsahuje SVG grafiku umístěnou uvnitř tvarů [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe/), Aspose.Slides pro Android via Java vám umožní získat původní vektorové obrázky s plnou věrností. Procházením kolekce tvarů snímku můžete identifikovat každý [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe/), zkontrolovat, zda podkladový [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) obsahuje SVG obsah, a poté tento obrázek uložit na disk či do proudu v jeho nativním SVG formátu.

Následující ukázkový kód demonstruje, jak extrahovat SVG obrázek z obrázkového rámečku:

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

## **Získání průhlednosti obrázku**

Aspose.Slides umožňuje získat efekt průhlednosti aplikovaný na obrázek. Tento Java kód ukazuje operaci:

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

## **Formátování obrázkového rámečku**

Aspose.Slides poskytuje mnoho možností formátování, které lze aplikovat na obrázkový rámeček. Pomocí těchto možností můžete upravit rámeček tak, aby splňoval konkrétní požadavky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu. 
3. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPPImage) přidáním obrázku do kolekce [IImagescollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IImageCollection) spojené s objektem prezentace, který bude použit k vyplnění tvaru.
4. Zadejte šířku a výšku obrázku.
5. Vytvořte `PictureFrame` na základě šířky a výšky obrázku pomocí metody [AddPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) poskytované objektem [IShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection) spojeným s odkazovaným snímkem.
6. Přidejte obrázkový rámeček (obsahující obrázek) na snímek.
7. Nastavte barvu čáry obrázkového rámečku.
8. Nastavte šířku čáry obrázkového rámečku.
9. Otočte obrázkový rámeček zadáním kladné nebo záporné hodnoty.
   * Kladná hodnota otáčí obrázek ve směru hodinových ručiček. 
   * Záporná hodnota otáčí obrázek proti směru hodinových ručiček.
10. Přidejte obrázkový rámeček (obsahující obrázek) na snímek.
11. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód demonstruje proces formátování obrázkového rámečku:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získá první snímek
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Vytvoří instanci třídy Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Přidá obrázkový rámeček s výškou a šířkou odpovídající obrázku
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Aplikuje nějaké formátování na PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Zapíše soubor PPTX na disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose nedávno vyvinul [bezplatný Collage Maker](https://products.aspose.app/slides/cs/collage). Pokud potřebujete [sloučit JPG/JPEG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG obrázky, [vytvořit mřížky z fotografií](https://products.aspose.app/slides/cs/collage/photo-grid), můžete tento službu použít. 
{{% /alert %}}

## **Přidání obrázku jako odkazu**

Aby se snížila velikost prezentace, můžete obrázky (nebo videa) přidávat pomocí odkazů místo vkládání souborů přímo do prezentace. Tento Java kód vám ukáže, jak přidat obrázek a video do zástupce:

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

## **Ořezávání obrázků**

Tento Java kód vám ukáže, jak oříznout existující obrázek na snímku:

```java
Presentation pres = new Presentation();
// Vytvoří nový objekt obrázku
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Přidá PictureFrame do snímku
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Ořízne obrázek (procentuální hodnoty)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Uloží výsledek
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odstranění oříznutých oblastí obrázku**

Pokud chcete odstranit oříznuté oblasti obrázku obsaženého v rámečku, můžete použít metodu [deletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Tato metoda vrací oříznutý obrázek nebo původní obrázek, pokud ořez není nutný.

Tento Java kód demonstruje operaci:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Získá PictureFrame z prvního snímku
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Odstraní oříznuté oblasti obrázku PictureFrame a vrátí oříznutý obrázek
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Uloží výsledek
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="POZNÁMKA" color="warning" %}} 
Metoda [deletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) přidává oříznutý obrázek do kolekce obrázků prezentace. Pokud je obrázek používán pouze v upravovaném [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe/), může toto nastavení snížit velikost prezentace. V opačném případě se počet obrázků ve výsledné prezentaci zvýší.

Tato metoda při operaci ořezávání převádí WMF/EMF metafily na rastrový PNG obrázek. 
{{% /alert %}}

## **Komprese obrázků**

Obrázek v prezentaci můžete komprimovat pomocí metody [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . Tato metoda komprimuje obrázek snížením jeho velikosti na základě velikosti tvaru a zadaného rozlišení, s možností odstranit oříznuté oblasti.

Upravuje velikost a rozlišení obrázku podobně jako funkce PowerPoint **Formát obrázku > Komprimovat obrázky > Rozlišení**.

Následující Java příklady ukazují, jak komprimovat obrázek v prezentaci zadáním cílového rozlišení a volitelným odstraněním oříznutých oblastí:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Komprimuje obrázek s cílovým rozlišením 150 DPI (webové rozlišení) a odstraní oříznuté oblasti.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Zkontroluje výsledek komprese.
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

Nebo přímo pomocí vlastní hodnoty DPI:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Komprimuje obrázek na 150 DPI (webové rozlišení) a odstraňuje oříznuté oblasti.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="POZNÁMKA" color="warning" %}} 
Metoda převádí obrázek na nižší rozlišení na základě velikosti tvaru a zadaného DPI. Oříznuté oblasti lze také odstranit pro optimalizaci velikosti souboru.  
Pokud je obrázek metafile (WMF/EMF) nebo SVG, komprese se neaplikuje. Kvalita JPEG je také zachována nebo mírně snížena podle rozlišení, podobně jako PowerPoint zachází s JPEG vysokého rozlišení.
{{% /alert %}}

## **Uzamčení poměru stran**

Pokud chcete, aby tvar obsahující obrázek zachoval poměr stran i po změně rozměrů obrázku, můžete použít metodu [setAspectRatioLocked](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) k nastavení volby *Lock Aspect Ratio*.

Tento Java kód vám ukáže, jak uzamknout poměr stran tvaru:

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

    // nastavte tvar, aby při změně velikosti zachovával poměr stran
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="POZNÁMKA" color="warning" %}} 
Nastavení *Lock Aspect Ratio* uchovává pouze poměr stran tvaru, nikoli obrázku, který obsahuje.
{{% /alert %}}

## **Použití vlastnosti StretchOff**

Pomocí vlastností [StretchOffsetLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) a [StretchOffsetBottom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) z rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPictureFillFormat) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPictureFillFormat) můžete určit výplňový obdélník.

Když je pro obrázek zadáno natažení, zdrojový obdélník se škáluje tak, aby zapadl do určeného výplňového obdélníka. Každý okraj výplňového obdélníka je definován procentuálním posunem od odpovídajícího okraje ohraničujícího rámečku tvaru. Kladné procento určuje vnitřní odsazení, záporné procento vnější posun.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte obdélník `AutoShape`. 
4. Vytvořte obrázek.
5. Nastavte typ výplně tvaru.
6. Nastavte režim výplně obrázkem tvaru.
7. Přidejte nastavený obrázek k výplni tvaru.
8. Zadejte posuny obrázku od odpovídajících okrajů ohraničujícího rámečku tvaru
9. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód demonstruje proces, ve kterém je použita vlastnost StretchOff:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získá první snímek
    ISlide slide = pres.getSlides().get_Item(0);

    // Vytvoří instanci třídy ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Přidá AutoShape nastavený na obdélník
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Nastaví typ výplně tvaru
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Nastaví režim výplně obrázkem tvaru
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Nastaví obrázek, který vyplní tvar
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Určuje posuny obrázku od odpovídajících okrajů ohraničujícího rámce tvaru
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Zapíše soubor PPTX na disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Jak zjistit, které formáty obrázků jsou podporovány pro PictureFrame?**

Aspose.Slides podporuje jak rastrové obrázky (PNG, JPEG, BMP, GIF atd.), tak vektorové obrázky (například SVG) prostřednictvím objektu obrázku přiřazeného k [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe/). Seznam podporovaných formátů obecně překrývá možnosti enginu pro snímky a konverzi obrázků.

**Jaký vliv má přidání desítek velkých obrázků na velikost a výkon PPTX?**

Vkládání velkých obrázků zvyšuje velikost souboru i využití paměti; propojování obrázků pomáhá udržet velikost prezentace nízkou, ale vyžaduje, aby externí soubory zůstaly dostupné. Aspose.Slides poskytuje možnost přidávat obrázky pomocí odkazů pro snížení velikosti souboru.

**Jak mohu zamknout objekt obrázku proti nechtěnému přesunu/změně velikosti?**

Použijte [shape locks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) pro [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe/) (například zakázat přesun nebo změnu velikosti). Zámek je podporován pro různé typy tvarů, včetně [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe/).

**Zachovává se věrnost vektorového SVG při exportu prezentace do PDF/obrázků?**

Aspose.Slides umožňuje extrahovat SVG z [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe/) jako původní vektor. Při [exportu do PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/) nebo [rasterových formátů](/slides/cs/androidjava/convert-powerpoint-to-png/) může být výsledek v závislosti na nastavení exportu rasterizován; fakt, že původní SVG je uložen jako vektor, je potvrzen chováním při extrakci.