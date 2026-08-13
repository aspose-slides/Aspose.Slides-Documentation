---
title: Správa obrázkových rámečků v prezentacích pomocí Javy
linktitle: Obrázkový rámeček
type: docs
weight: 10
url: /cs/java/picture-frame/
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
- Java
- Aspose.Slides
description: "Přidejte obrázkové rámečky do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Javu. Zefektivněte svůj pracovní postup a vylepšete návrhy snímků."
---
## **Úvod**

Obrázkový rámeček je tvar, který obsahuje obrázek – je to jako obrázek v rámu. 

Můžete přidat obrázek do snímku pomocí obrázkového rámečku. Tímto způsobem můžete formátovat obrázek formátováním rámečku.

{{% alert  title="Tip" color="info" %}} 

Aspose poskytuje bezplatné konvertory — [JPEG do PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt) — které umožňují rychle vytvářet prezentace z obrázků. 

{{% /alert %}} 

## **Vytvoření obrázkového rámečku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek podle jeho indexu. 
3. Vytvořte objekt [IPPImage]() přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IImageCollection) přidruženého k objektu prezentace, který bude použit k vyplnění tvaru.
4. Zadejte šířku a výšku obrázku.
5. Vytvořte [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/PictureFrame) na základě šířky a výšky obrázku pomocí metody `AddPictureFrame`, která je součástí objektu tvaru přidruženého k odkazovanému snímku.
6. Přidejte obrázkový rámeček (obsahující obrázek) do snímku.
7. Uložte upravenou prezentaci jako soubor PPTX.

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získá první snímek
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Vytvoří instanci třídy Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Přidá obrázkový rámeček se stejnou výškou a šířkou jako obrázek
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Zapíše soubor PPTX na disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Obrázkové rámečky vám umožňují rychle vytvářet snímky prezentace na základě obrázků. Když kombinujete obrázkový rámeček s možnostmi uložení v Aspose.Slides, můžete manipulovat s operacemi vstupu/výstupu pro převod obrázků z jednoho formátu do druhého. Můžete se podívat na následující stránky: převod [image to JPG](https://products.aspose.com/slides/cs/java/conversion/image-to-jpg/); převod [JPG to image](https://products.aspose.com/slides/cs/java/conversion/jpg-to-image/); převod [JPG to PNG](https://products.aspose.com/slides/cs/java/conversion/jpg-to-png/), převod [PNG to JPG](https://products.aspose.com/slides/cs/java/conversion/png-to-jpg/); převod [PNG to SVG](https://products.aspose.com/slides/cs/java/conversion/png-to-svg/), převod [SVG to PNG](https://products.aspose.com/slides/cs/java/conversion/svg-to-png/).

{{% /alert %}} 

## **Vytvoření obrázkového rámečku s relativním měřítkem**

Úpravou relativního měřítka obrázku můžete vytvořit složitější obrázkový rámeček. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek podle jeho indexu. 
3. Přidejte obrázek do kolekce obrázků prezentace.
4. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPPImage) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IImageCollection) přidruženého k objektu prezentace, který bude použit k vyplnění tvaru.
5. Zadejte relativní šířku a výšku obrázku v obrázkovém rámečku.
6. Uložte upravenou prezentaci jako soubor PPTX.

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získá první snímek
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Vytvoří instanci třídy Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Přidá obrázkový rámeček se stejnou výškou a šířkou jako obrázek
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Nastavení relativního měřítka šířky a výšky
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Zapíše soubor PPTX na disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extrahování rastrových obrázků z obrázkových rámečků**

Můžete extrahovat rastrové obrázky z objektů [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/PictureFrame) a uložit je ve formátech PNG, JPG a dalších. Níže uvedený příklad kódu ukazuje, jak extrahovat obrázek z dokumentu „sample.pptx“ a uložit jej ve formátu PNG.

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

## **Extrahování SVG obrázků z obrázkových rámečků**

Jakmile prezentace obsahuje SVG grafiku umístěnou uvnitř tvarů [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe/), Aspose.Slides pro Java vám umožní získat původní vektorové obrázky s plnou věrností. Procházením kolekce tvarů snímku můžete identifikovat každý [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe/), zjistit, zda podkladový [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/) obsahuje SVG obsah, a poté uložit tento obrázek na disk nebo do proudu v jeho nativním SVG formátu.

Následující příklad kódu ukazuje, jak extrahovat SVG obrázek z obrázkového rámečku:

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

        // getSvgImage vrací null, pokud je obrázek rastrový.
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

## **Získání průhlednosti obrázku**

Aspose.Slides vám umožňuje získat efekt průhlednosti aplikovaný na obrázek. Tento Java kód demonstruje operaci:

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

## **Získání jasu a kontrastu obrázku**

Aspose.Slides vám umožňuje získat efekt jasu a kontrastu aplikovaný na obrázek. Rozhraní [ILuminance](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iluminance/) představuje tento transformační efekt obrázku.

Tento Java kód ukazuje, jak získat nastavení jasu a kontrastu z obrázkového rámečku:

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

## **Formátování obrázkového rámečku**

Aspose.Slides poskytuje mnoho možností formátování, které lze použít na obrázkový rámeček. Pomocí těchto možností můžete upravit obrázkový rámeček tak, aby vyhovoval konkrétním požadavkům.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek podle jeho indexu. 
3. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPPImage) přidáním obrázku do [IImagescollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IImageCollection) přidruženého k objektu prezentace, který bude použit k vyplnění tvaru.
4. Zadejte šířku a výšku obrázku.
5. Vytvořte `PictureFrame` na základě šířky a výšky obrázku pomocí metody [AddPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) vystavené objektem [IShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection) přidruženým k odkazovanému snímku.
6. Přidejte obrázkový rámeček (obsahující obrázek) do snímku.
7. Nastavte barvu obrysu obrázkového rámečku.
8. Nastavte šířku obrysu obrázkového rámečku.
9. Otočte obrázkový rámeček zadáním kladné nebo záporné hodnoty.
   * Kladná hodnota otáčí obrázek po směru hodinových ručiček. 
   * Záporná hodnota otáčí obrázek proti směru hodinových ručiček.
10. Přidejte obrázkový rámeček (obsahující obrázek) do snímku.
11. Uložte upravenou prezentaci jako soubor PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Vytvoří instanci třídy Presentation, která představuje PPTX
Presentation pres = new Presentation();
try {
    // Získá první snímek
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Vytvoří instanci třídy Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Přidá obrázkový rámeček se stejnou výškou a šířkou jako obrázek
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

{{% alert title="Tip" color="info" %}}

Aspose nedávno vyvinul [bezplatný Collage Maker](https://products.aspose.app/slides/cs/collage). Pokud potřebujete [sloučit JPG/JPEG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG obrázky, [vytvořit mřížky ze fotografií](https://products.aspose.app/slides/cs/collage/photo-grid), můžete použít tuto službu. 

{{% /alert %}}

## **Přidání obrázku jako odkazu**

Aby se předešlo velkým velikostem prezentací, můžete přidávat obrázky (nebo videa) prostřednictvím odkazů místo vkládání souborů přímo do prezentací. Tento Java kód vám ukazuje, jak přidat obrázek a video do zástupce:

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

## **Oříznutí obrázků**

Tento Java kód vám ukazuje, jak oříznout existující obrázek na snímku:

```java
import com.aspose.slides.*;

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

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

    // Přidá obrázkový rámeček do snímku
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Ořízne obrázek (procentuální hodnoty)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Uloží výsledek
    pres.save(outPptxFile, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odstranění oříznutých oblastí obrázku**

Pokud chcete odstranit oříznuté oblasti obrázku obsaženého v rámečku, můžete použít metodu [deletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). Tato metoda vrací oříznutý obrázek nebo původní obrázek, pokud oříznutí není nutné.

Tento Java kód demonstruje operaci:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Získá obrázkový rámeček z prvního snímku
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Odstraní oříznuté oblasti obrázku v obrázkovém rámečku a vrátí oříznutý obrázek
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Uloží výsledek
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Metoda [deletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) přidává oříznutý obrázek do kolekce obrázků prezentace. Pokud je obrázek použit jen v zpracovávaném [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe/), toto nastavení může snížit velikost prezentace. V opačném případě se počet obrázků ve výsledné prezentaci zvýší.

Tato metoda převádí WMF/EMF metasybory na rastrový PNG obrázek během operace oříznutí. 

{{% /alert %}}

## **Komprese obrázků**

Můžete komprimovat obrázek v prezentaci pomocí metody [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-). Tato metoda komprimuje obrázek snížením jeho velikosti na základě velikosti tvaru a zadaného rozlišení, s možností odstranit oříznuté oblasti.

Upravuje velikost a rozlišení obrázku podobně jako funkce PowerPointu **Picture Format -> Compress Pictures -> Resolution**.

Následující Java příklady ukazují, jak komprimovat obrázek v prezentaci zadáním cílového rozlišení a případně odstraněním oříznutých oblastí:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Zkomprimuje obrázek na cílové rozlišení 150 DPI (webové rozlišení) a odstraní oříznuté oblasti.
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
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Komprimuje obrázek na 150 DPI (webové rozlišení), odstraňuje oříznuté oblasti.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Metoda převádí obrázek na nižší rozlišení na základě velikosti tvaru a zadaného DPI. Oříznuté oblasti mohou být také smazány za účelem optimalizace velikosti souboru.  
Pokud je obrázek met soubor (WMF/EMF) nebo SVG, komprese se nepoužije. Kvalita JPEG je zachována nebo mírně snížena podle rozlišení, podobně jako PowerPoint zachází s vysokým rozlišením JPEG.

{{% /alert %}}

## **Zamčení poměru stran**

Pokud chcete, aby tvar obsahující obrázek zachoval svůj poměr stran i po změně rozměrů obrázku, můžete použít metodu [setAspectRatioLocked](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) k nastavení volby *Lock Aspect Ratio*.

Tento Java kód ukazuje, jak zamknout poměr stran tvaru:

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

    // nastavit tvar, aby při změně velikosti zachoval poměr stran
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Toto nastavení *Lock Aspect Ratio* zachovává pouze poměr stran tvaru, nikoli obrázku, který obsahuje.

{{% /alert %}}

## **Použití vlastnosti StretchOff**

Pomocí vlastností [StretchOffsetLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) a [StretchOffsetBottom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) z rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPictureFillFormat) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPictureFillFormat) můžete určit výplňový obdélník. 

Když je pro obrázek zadáno roztahování, zdrojový obdélník se škáluje tak, aby zapadl do určeného výplňového obdélníku. Každý okraj výplňového obdélníku je definován procentuálním posunem od odpovídajícího okraje ohraničujícího rámečku tvaru. Kladné procento určuje vnitřní posun, záporné procento vnější posun.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte obdélník `AutoShape`. 
4. Vytvořte obrázek.
5. Nastavte typ výplně tvaru.
6. Nastavte režim výplně obrázkem tvaru.
7. Přidejte obrázek k výplni tvaru.
8. Zadejte posuny obrázku od odpovídajícího okraje ohraničujícího rámečku tvaru
9. Uložte upravenou prezentaci jako soubor PPTX.

```java
import com.aspose.slides.*;

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

    // Nastaví obrázek pro výplň tvaru
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Určí posuny obrázku od odpovídajícího okraje ohraničujícího rámečku tvaru
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    //Zapíše soubor PPTX na disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

### Jak zjistím, které formáty obrázků jsou podporovány pro PictureFrame?

Aspose.Slides podporuje jak rastrové obrázky (PNG, JPEG, BMP, GIF atd.), tak vektorové obrázky (například SVG) prostřednictvím objektu obrázku, který je přiřazen k [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe/). Seznam podporovaných formátů se obecně překrývá s možnostmi engine pro snímky a konverzi obrázků.

### Jaký vliv bude mít přidání desítek velkých obrázků na velikost a výkon PPTX?

Vkládání velkých obrázků zvyšuje velikost souboru a spotřebu paměti; propojování obrázků pomáhá udržet velikost prezentace nízkou, ale vyžaduje, aby externí soubory zůstaly dostupné. Aspose.Slides poskytuje možnost přidávat obrázky jako odkazy k snížení velikosti souboru.

### Jak mohu zamknout objekt obrázku před neúmyslným přesunem/změnou velikosti?

Použijte [shape locks](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) pro [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe/) (například zakázat přesun nebo změnu velikosti). Mechanismus zamykání je popsán pro tvary v samostatném [článku o ochraně](/slides/cs/java/applying-protection-to-presentation/) a je podporován pro různé typy tvarů, včetně [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe/).

### Je zachována vektorová věrnost SVG při exportu prezentace do PDF/obrázků?

Aspose.Slides umožňuje extrahovat SVG z [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe/) jako původní vektor. Při [exportu do PDF](/slides/cs/java/convert-powerpoint-to-pdf/) nebo [rasterových formátů](/slides/cs/java/convert-powerpoint-to-png/) může být výsledek v závislosti na nastavení exportu rasterizován; fakt, že původní SVG je uložen jako vektor, je potvrzen chováním při extrakci.