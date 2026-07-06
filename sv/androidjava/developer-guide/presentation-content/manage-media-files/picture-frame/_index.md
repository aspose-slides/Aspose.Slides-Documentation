---
title: Hantera bildramar i presentationer på Android
linktitle: Bildram
type: docs
weight: 10
url: /sv/androidjava/picture-frame/
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
- relativ skala
- bildeffekt
- bildförhållande
- bildtransparens
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Lägg till bildramar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Android via Java. Förenkla ditt arbetsflöde och förbättra bilddesignen."
---
## **Introduktion**

En bildram är en form som innehåller en bild—det är som en bild i en ram.  

Du kan lägga till en bild på en bildspel genom en bildram. På så sätt kan du formatera bilden genom att formatera bildramen.

{{% alert  title="Tips" color="primary" %}} 
Aspose tillhandahåller gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter användare skapa presentationer snabbt från bilder. 
{{% /alert %}} 

## **Skapa en bildram**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index. 
3. Skapa ett [IPPImage]()‑objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IImageCollection) som är kopplad till presentationsobjektet och som kommer att användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa en [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/PictureFrame) baserat på bildens bredd och höjd via `AddPictureFrame`‑metoden som exponeras av formobjektet som är kopplat till den refererade bilden.
6. Lägg till en bildram (som innehåller bilden) på bilden.
7. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar en bildram:

```java
// Skapar en instans av Presentation-klassen som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Skapar en instans av Image-klassen
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

## **Skapa en bildram med relativ skala**

Genom att ändra en bilds relativa skalning kan du skapa en mer komplex bildram. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index. 
3. Lägg till en bild i presentationens bildsamling.
4. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPPImage)‑objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IImageCollection) som är kopplad till presentationsobjektet och som kommer att användas för att fylla formen.
5. Ange bildens relativa bredd och höjd i bildramen.
6. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar en bildram med relativ skala:

```java
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
    
    // Skriv PPTX-filen till disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extrahera rasterbilder från bildramar**

Du kan extrahera rasterbilder från [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/PictureFrame)‑objekt och spara dem i PNG, JPG och andra format. Kodexemplet nedan visar hur du extraherar en bild från dokumentet "sample.pptx" och sparar den i PNG‑format.

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

## **Extrahera SVG‑bilder från bildramar**

När en presentation innehåller SVG‑grafik placerad i [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pictureframe/)‑former låter Aspose.Slides för Android via Java dig hämta de ursprungliga vektorbilderna med fullständig kvalitet. Genom att gå igenom bildens formsamling kan du identifiera varje [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pictureframe/), kontrollera om den underliggande [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/) innehåller SVG‑innehåll och sedan spara den bilden till disk eller en ström i dess ursprungliga SVG‑format.

Följande kodexempel visar hur du extraherar en SVG‑bild från en bildram:

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

## **Hämta transparens för en bild**

Aspose.Slides låter dig hämta transparenseffekten som tillämpats på en bild. Denna Java‑kod demonstrerar operationen:

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

## **Hämta ljusstyrka och kontrast för en bild**

Aspose.Slides låter dig hämta ljusstyrke‑ och kontrasteffekten som tillämpats på en bild. Gränssnittet [ILuminance](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iluminance/) representerar denna bildtransformering.

Denna Java‑kod visar hur du får ljusstyrke‑ och kontrastinställningarna från en bildram:

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

## **Formatering av bildram**

Aspose.Slides erbjuder många formateringsalternativ som kan tillämpas på en bildram. Med hjälp av dessa alternativ kan du ändra en bildram så att den uppfyller specifika krav.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index. 
3. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPPImage)‑objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IImageCollection) som är kopplad till presentationsobjektet och som kommer att användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa en `PictureFrame` baserat på bildens bredd och höjd via [AddPictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)‑metoden som exponeras av [IShapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection)‑objektet som är kopplat till den refererade bilden.
6. Lägg till bildramen (som innehåller bilden) på bilden.
7. Ställ in bildramens linjefärg.
8. Ställ in bildramens linjebredd.
9. Rotera bildramen genom att ange ett positivt eller negativt värde.
   * Ett positivt värde roterar bilden medurs. 
   * Ett negativt värde roterar bilden moturs.
10. Lägg till bildramen (som innehåller bilden) på bilden.
11. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod demonstrerar processen för formatering av bildram:

```java
// Instansierar Presentation-klassen som representerar PPTX
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instansierar Image-klassen
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Lägger till bildram med bildens motsvarande höjd och bredd
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Tillämpar viss formatering på PictureFrameEx
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

{{% alert title="Tips" color="primary" %}}
Aspose har nyligen utvecklat en [gratis Collage Maker](https://products.aspose.app/slides/sv/collage). Om du någonsin behöver [sammanfoga JPG/JPEG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG‑bilder, [skapa rutnät från foton](https://products.aspose.app/slides/sv/collage/photo-grid), kan du använda den här tjänsten. 
{{% /alert %}}

## **Lägg till en bild som en länk**

För att undvika stora presentationsstorlekar kan du lägga till bilder (eller videor) via länkar istället för att bädda in filerna direkt i presentationerna. Denna Java‑kod visar hur du lägger till en bild och video i en platshållare:

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

## **Beskär bilder**

Denna Java‑kod visar hur du beskär en befintlig bild på en bild:

```java
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
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ta bort beskurna områden från en bildram**

Om du vill ta bort de beskurna områdena av en bild som finns i en ram kan du använda metoden [deletePictureCroppedAreas()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Denna metod returnerar den beskurna bilden eller originalbilden om beskärning är onödig.

Denna Java‑kod demonstrerar operationen:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hämtar bildramen från den första bilden
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Tar bort beskurna områden i PictureFrame-bilden och returnerar den beskurna bilden
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Sparar resultatet
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="OBS" color="warning" %}} 
Metoden [deletePictureCroppedAreas()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) lägger till den beskurna bilden i presentationens bildsamling. Om bilden endast används i den behandlade [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pictureframe/), kan denna konfiguration minska presentationsstorleken. Annars ökar antalet bilder i den resulterande presentationen.

Denna metod konverterar WMF/EMF‑metafiler till raster‑PNG‑bilder i beskärningsoperationen. 
{{% /alert %}}

## **Komprimera bilder**

Du kan komprimera en bild i en presentation med hjälp av metoden [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) .
Denna metod komprimerar en bild genom att minska dess storlek baserat på formens storlek och angiven upplösning, med möjlighet att ta bort beskurna områden.

Den justerar bildens storlek och upplösning på liknande sätt som PowerPoints funktion **Picture Format > Compress Pictures > Resolution**.

Följande Java‑exempel visar hur du komprimerar en bild i en presentation genom att ange en målupplösning och eventuellt ta bort beskurna områden:

```java
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

Eller genom att ange ett eget DPI‑värde direkt:

```java
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

{{% alert title="OBS" color="warning" %}} 
Metoden konverterar bilden till en lägre upplösning baserat på formens storlek och angivet DPI. Beskurna regioner kan också tas bort för att optimera filstorleken.  
Om bilden är en metafil (WMF/EMF) eller SVG kommer komprimering inte att tillämpas. JPEG‑kvaliteten bevaras eller minskas något beroende på upplösning, på liknande sätt som PowerPoint hanterar högupplösta JPEG‑bilder. 
{{% /alert %}}

## **Lås bildförhållande**

Om du vill att en form som innehåller en bild ska behålla sitt bildförhållande även efter att du ändrat bildens dimensioner kan du använda metoden [setAspectRatioLocked](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) för att aktivera inställningen *Lock Aspect Ratio*.

Denna Java‑kod visar hur du låser en forms bildförhållande:

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

    // ställ in formen så att bildförhållandet bevaras vid storleksändring
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="OBS" color="warning" %}} 
Denna *Lock Aspect Ratio*-inställning bevarar endast formens bildförhållande och inte bilden den innehåller. 
{{% /alert %}}

## **Använd egenskapen StretchOff**

Genom att använda egenskaperna [StretchOffsetLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) och [StretchOffsetBottom](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) från gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPictureFillFormat) och klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPictureFillFormat) kan du ange en fyllningsrektangel.

När stretching specificeras för en bild skalas en källrektangel för att passa den angivna fyllningsrektangeln. Varje kant på fyllningsrektangeln definieras av ett procentuellt avstånd från motsvarande kant på formens omgivande låda. Ett positivt procenttal anger en inskjutning medan ett negativt procenttal anger en utskjutning.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till en rektangel `AutoShape`. 
4. Skapa en bild.
5. Ställ in formens fyllningstyp.
6. Ställ in formens bildfyllningsläge.
7. Lägg till en bild för att fylla formen.
8. Ange bildens förskjutningar från motsvarande kant på formens omgivande låda.
9. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod demonstrerar en process där en StretchOff‑egenskap används:

```java
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

    // Lägger till en AutoShape inställd på Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Anger formens fyllningstyp
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Anger formens bildfyllningsläge
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Anger bilden för att fylla formen
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Specificerar bildens förskjutningar från motsvarande kant på formens omgivande låda
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Skriver PPTX-filen till disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hur kan jag ta reda på vilka bildformat som stöds för PictureFrame?**

Aspose.Slides stöder både rasterbilder (PNG, JPEG, BMP, GIF osv.) och vektorbilder (t.ex. SVG) via bildobjektet som tilldelas en [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pictureframe/). Listan över stödjade format överlappar generellt med möjligheterna i bild‑ och konverteringsmotorn.

**Hur påverkar tillägg av dussintals stora bilder PPTX‑storlek och prestanda?**

Inbäddning av stora bilder ökar filstorlek och minnesanvändning; länka bilder håller presentationsstorleken nere men kräver att de externa filerna förblir åtkomliga. Aspose.Slides erbjuder möjligheten att lägga till bilder via länk för att minska filstorleken.

**Hur kan jag låsa ett bildobjekt så att det inte av misstag flyttas/ändras i storlek?**

Använd [shape locks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) för en [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pictureframe/) (t.ex. inaktivera flyttning eller storleksändring). Låsningsmekanismen stöds för olika formtyper, inklusive [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pictureframe/).

**Bevaras SVG‑vektorens kvalitet vid export av en presentation till PDF/bilder?**

Aspose.Slides låter dig extrahera en SVG från en [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pictureframe/) som den ursprungliga vektorn. Vid [export till PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/) eller [rasterformat](/slides/sv/androidjava/convert-powerpoint-to-png/) kan resultatet rasteriseras beroende på exportinställningarna; faktumet att den ursprungliga SVG:n lagras som en vektor bekräftas av extraheringsbeteendet.