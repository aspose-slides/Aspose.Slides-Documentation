---
title: "Hantera bildramar i presentationer med Java"
linktitle: "Bildram"
type: docs
weight: 10
url: /sv/java/picture-frame/
keywords:
- bildram
- lägg till bildram
- skapa bildram
- lägg till bild
- skapa bild
- extrahera bild
- rasterbild
- vektorbild
- beskär bild
- beskuret område
- StretchOff-egenskap
- formatering av bildram
- egenskaper för bildram
- relativ skalning
- bildeffekt
- bildförhållande
- bildtransparens
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lägg till bildramar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Java. Effektivisera ditt arbetsflöde och förbättra bilddesignen."
---
## **Introduktion**

En bildram är en form som innehåller en bild – den är som en bild i en ram. 

Du kan lägga till en bild på en bildruta via en bildram. På så sätt kan du formatera bilden genom att formatera bildramen.

{{% alert  title="Tip" color="info" %}} 

Aspose tillhandahåller gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter användare skapa presentationer snabbt från bilder. 

{{% /alert %}} 

## **Skapa en bildram**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index. 
3. Skapa ett [IPPImage]()‑objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IImageCollection) som är associerad med presentationsobjektet och som ska användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa en [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/PictureFrame) baserat på bildens bredd och höjd via metoden `AddPictureFrame` som exponeras av formeobjektet som är associerat med den refererade bilden.
6. Lägg till en bildram (som innehåller bilden) till bilden.
7. Spara den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar en bildram:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instansierar Presentation-klassen som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instansierar Image-klassen
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Lägger till en bildram med bildens motsvarande höjd och bredd
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Skriver PPTX-filen till disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Bildramar låter dig snabbt skapa presentationsbilder baserade på bilder. När du kombinerar bildram med sparalternativen i Aspose.Slides kan du manipulera in‑/utdata‑operationer för att konvertera bilder från ett format till ett annat. Du kan vilja se dessa sidor: konvertera [image to JPG](https://products.aspose.com/slides/sv/java/conversion/image-to-jpg/); konvertera [JPG to image](https://products.aspose.com/slides/sv/java/conversion/jpg-to-image/); konvertera [JPG to PNG](https://products.aspose.com/slides/sv/java/conversion/jpg-to-png/), konvertera [PNG to JPG](https://products.aspose.com/slides/sv/java/conversion/png-to-jpg/); konvertera [PNG to SVG](https://products.aspose.com/slides/sv/java/conversion/png-to-svg/), konvertera [SVG to PNG](https://products.aspose.com/slides/sv/java/conversion/svg-to-png/).

{{% /alert %}}

## **Skapa en bildram med relativ skalning**

Genom att ändra en bilds relativa skalning kan du skapa en mer komplex bildram. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index. 
3. Lägg till en bild i presentationens bildsamling.
4. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPPImage)‑objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IImageCollection) som är associerad med presentationsobjektet och som ska användas för att fylla formen.
5. Ange bildens relativa bredd och höjd i bildramen.
6. Spara den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar en bildram med relativ skalning:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instansiera Presentation-klassen som representerar PPTX
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instansiera Image-klassen
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Lägg till bildram med bildens motsvarande höjd och bredd
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Ställer in relativ skala för bredd och höjd
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Skriver PPTX-filen till disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extrahera rasterbilder från bildramar**

Du kan extrahera rasterbilder från [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/PictureFrame)-objekt och spara dem i PNG, JPG och andra format. Kodexemplet nedan visar hur du extraherar en bild från dokumentet "sample.pptx" och sparar den i PNG‑format.

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

## **Extrahera SVG‑bilder från bildramar**

När en presentation innehåller SVG‑grafik placerad i [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pictureframe/)-former, låter Aspose.Slides for Java dig hämta de ursprungliga vektorbilderna med fullständig trohet. Genom att traversera bildens formsamling kan du identifiera varje [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pictureframe/), kontrollera om den underliggande [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ippimage/) innehåller SVG‑innehåll, och sedan spara den bilden till disk eller en ström i dess inhemska SVG‑format.

Följande kodexempel visar hur du extraherar en SVG‑bild från en bildram:

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

        // getSvgImage returnerar null när bilden är en rasterbild.
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

## **Hämta transparens för en bild**

Aspose.Slides låter dig hämta den transparenseffekt som har applicerats på en bild. Denna Java‑kod demonstrerar operationen:

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

## **Hämta ljusstyrka och kontrast för en bild**

Aspose.Slides låter dig hämta ljusstyrka‑ och kontrasteffekten som har applicerats på en bild. Interfacet [ILuminance](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iluminance/) representerar denna bildtransformering.

Denna Java‑kod demonstrerar hur du hämtar ljusstyrke‑ och kontrastinställningarna från en bildram:

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

## **Formatering av bildramar**

Aspose.Slides tillhandahåller många formateringsalternativ som kan tillämpas på en bildram. Med dessa alternativ kan du ändra en bildram så att den uppfyller specifika krav.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index. 
3. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPPImage)‑objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IImageCollection) som är associerad med presentationsobjektet och som ska användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa ett `PictureFrame` baserat på bildens bredd och höjd via metoden [AddPictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) som exponeras av objektet [IShapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection) som är associerat med den refererade bilden.
6. Lägg till bildramen (som innehåller bilden) till bilden.
7. Ställ in bildramens linjefärg.
8. Ställ in bildramens linjebredd.
9. Rotera bildramen genom att ge den ett positivt eller negativt värde.  
   * Ett positivt värde roterar bilden medurs.  
   * Ett negativt värde roterar bilden moturs.
10. Lägg till bildramen (som innehåller bilden) till bilden.
11. Spara den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod demonstrerar processen för bildramformatering:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instansierar Presentation-klassen som representerar PPTX
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instansierar Image-klassen
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Lägger till en bildram med bildens motsvarande höjd och bredd
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Applicerar lite formatering på PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Skriver PPTX-filen till disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Aspose har nyligen utvecklat en [fri Collage Maker](https://products.aspose.app/slides/sv/collage). Om du någonsin behöver [sammanfoga JPG/JPEG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG‑bilder, [skapa rutnät från foton](https://products.aspose.app/slides/sv/collage/photo-grid), kan du använda den här tjänsten. 

{{% /alert %}}

## **Lägg till en bild som en länk**

För att undvika stora presentationsstorlekar kan du lägga till bilder (eller videor) via länkar istället för att bädda in filerna direkt i presentationerna. Denna Java‑kod visar hur du lägger till en bild och video i en platshållare:

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

## **Beskär bilder**

Denna Java‑kod visar hur du beskär en befintlig bild på en bild:

```java
import com.aspose.slides.*;

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

Presentation pres = new Presentation();
// Skapar nytt bildobjekt
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Lägger till en bildram på en bild
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Beskär bilden (procentvärden)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Sparar resultatet
    pres.save(outPptxFile, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ta bort beskurna områden i en bild**

Om du vill ta bort de beskurna områdena av en bild som finns i en ram, kan du använda metoden [deletePictureCroppedAreas()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Denna metod returnerar den beskurna bilden eller originalbilden om beskärning inte är nödvändig.

Denna Java‑kod demonstrerar operationen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hämtar PictureFrame från den första bilden
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Tar bort beskurna områden i PictureFrames bild och returnerar den beskurna bilden
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Sparar resultatet
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Metoden [deletePictureCroppedAreas()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) lägger till den beskurna bilden i presentationens bildsamling. Om bilden endast används i den behandlade [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pictureframe/), kan denna inställning minska presentationsstorleken. Annars ökar antalet bilder i den resulterande presentationen.

Denna metod konverterar WMF/EMF‑metafiler till raster‑PNG‑bild vid beskärningsoperationen. 

{{% /alert %}}

## **Komprimera bilder**

Du kan komprimera en bild i en presentation med hjälp av metoden [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . Denna metod komprimerar en bild genom att minska dess storlek baserat på formens storlek och angiven upplösning, med möjlighet att ta bort beskurna områden.

Den justerar bildens storlek och upplösning på samma sätt som PowerPoints **Picture Format → Compress Pictures → Resolution**‑funktion.

Följande Java‑exempel demonstrerar hur du komprimerar en bild i en presentation genom att ange en målupplösning och eventuellt ta bort beskurna områden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Komprimera bilden med en målupplösning på 150 DPI (webbupplösning) och ta bort beskurna områden.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Kontrollera resultatet av komprimeringen.
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

Eller genom att ange ett anpassat DPI‑värde direkt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Komprimera bilden till 150 DPI (webbupplösning), ta bort beskurna områden.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Metoden konverterar bilden till en lägre upplösning baserat på formens storlek och angivet DPI. Beskurna regioner kan också tas bort för att optimera filstorleken.  
Om bilden är en metafil (WMF/EMF) eller SVG, kommer komprimering inte att tillämpas. JPEG‑kvaliteten bevaras eller minskas något beroende på upplösning, på samma sätt som PowerPoint hanterar högupplösta JPEG‑filer.

{{% /alert %}}

## **Lås bildförhållande**

Om du vill att en form som innehåller en bild ska behålla sitt bildförhållande även efter att du ändrat bildens dimensioner, kan du använda metoden [setAspectRatioLocked](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) för att ställa in *Lock Aspect Ratio*-inställningen. 

Denna Java‑kod visar hur du låser ett formes bildförhållande:

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

    // ställ in formen så att bildförhållandet bevaras vid storleksändring
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Denna *Lock Aspect Ratio*-inställning bevarar endast formens bildförhållande och inte bilden den innehåller.

{{% /alert %}}

## **Använd StretchOff‑egenskapen**

Genom att använda egenskaperna [StretchOffsetLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) och [StretchOffsetBottom](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) från interfacet [IPictureFillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPictureFillFormat) och klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPictureFillFormat) kan du ange en fyllningsrektangel. 

När stretching anges för en bild, skalas en källrektangel för att passa den angivna fyllningsrektangeln. Varje kant av fyllningsrektangeln definieras av en procentuell offset från motsvarande kant av formens omgivande ruta. En positiv procentsats anger ett inskjut, medan en negativ procentsats anger ett utskjut.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till en rektangel `AutoShape`. 
4. Skapa en bild.
5. Ställ in formens fyllningstyp.
6. Ställ in formens bildfyllningsläge.
7. Lägg till en bild för att fylla formen.
8. Ange bildoffsets från motsvarande kant av formens omgivande ruta.
9. Spara den modifierade presentationen som en PPTX‑fil.

Denna Java‑kod demonstrerar ett förfarande där en StretchOff‑egenskap används:

```java
import com.aspose.slides.*;

// Instansierar Presentation-klassen som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Instansierar ImageEx-klassen
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Lägger till en AutoShape med rektangel
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Ställer in formens fyllningstyp
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Ställer in formens bildfyllningsläge
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Ställer in bilden för att fylla formen
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Anger bildens offset från motsvarande kant av formens omgivande ruta
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // Skriver PPTX-filen till disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Hur kan jag ta reda på vilka bildformat som stöds för PictureFrame?

Aspose.Slides stöder både rasterbilder (PNG, JPEG, BMP, GIF, osv.) och vektorbilder (t.ex. SVG) via bildobjektet som tilldelas en [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pictureframe/). Listan över stödda format överlappar generellt med funktionerna i bild‑ och konverteringsmotorn för bilder.

### Hur påverkar det att lägga till dussintals stora bilder PPTX‑storleken och prestandan?

Inbäddning av stora bilder ökar filstorlek och minnesanvändning; länka bilder hjälper hålla presentationsstorleken nere men kräver att de externa filerna förblir tillgängliga. Aspose.Slides erbjuder möjligheten att lägga till bilder via länkar för att minska filstorleken.

### Hur kan jag låsa ett bildobjekt så att det inte av misstag flyttas/ändras i storlek?

Använd [shape locks](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) för en [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pictureframe/) (t.ex. inaktivera flyttning eller storleksändring). Låsningsmekanismen beskrivs för former i en separat [skyddsartikel](/slides/sv/java/applying-protection-to-presentation/) och stöds för olika former, inklusive [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pictureframe/).

### Bevaras SVG‑vektorfideliteten när en presentation exporteras till PDF/bilder?

Aspose.Slides låter dig extrahera en SVG från en [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pictureframe/) som den ursprungliga vektorn. När du [exporterar till PDF](/slides/sv/java/convert-powerpoint-to-pdf/) eller [rasterformat](/slides/sv/java/convert-powerpoint-to-png/) kan resultatet rasteriseras beroende på exportinställningarna; att original‑SVG:n lagras som en vektor bekräftas av extraheringsbeteendet.