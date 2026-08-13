---
title: Beheer afbeeldingframes in presentaties met Java
linktitle: Afbeeldingsframe
type: docs
weight: 10
url: /nl/java/picture-frame/
keywords:
- afbeeldingframe
- afbeeldingframe toevoegen
- afbeeldingframe maken
- afbeelding toevoegen
- afbeelding maken
- afbeelding extraheren
- rasterafbeelding
- vectorafbeelding
- afbeelding bijsnijden
- bijgesneden gebied
- StretchOff‑eigenschap
- opmaak van afbeeldingframe
- eigenschappen van afbeeldingframe
- relatieve schaal
- afbeeldingseffect
- aspectverhouding
- afbeeldingstransparantie
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Voeg afbeeldingframes toe aan PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Java. Versnel uw workflow en verbeter het ontwerp van dia's."
---
## **Inleiding**

Een afbeeldingframe is een vorm die een afbeelding bevat—het is als een foto in een frame.  

U kunt een afbeelding aan een dia toevoegen via een afbeeldingframe. Op deze manier kunt u de afbeelding opmaken door het afbeeldingframe op te maken.

{{% alert  title="Tip" color="info" %}} 

Aspose biedt gratis converters—[JPEG to PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG to PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die mensen in staat stellen om snel presentaties te maken van afbeeldingen. 

{{% /alert %}} 

## **Maak een afbeeldingframe**

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Maak een [IPPImage]()‑object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImageCollection) die gekoppeld is aan het presentatie‑object dat zal worden gebruikt om de vorm te vullen.  
4. Specificeer de breedte en hoogte van de afbeelding.  
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PictureFrame) aan op basis van de breedte en hoogte van de afbeelding via de `AddPictureFrame`‑methode die wordt blootgesteld door het vorm‑object dat is gekoppeld aan de refererende dia.  
6. Voeg een afbeeldingframe (met de afbeelding) toe aan de dia.  
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe u een afbeeldingframe maakt:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instantieert de Presentation‑klasse die een PPTX‑bestand representeert
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieert de Image‑klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Voegt een afbeeldingframe toe met dezelfde hoogte en breedte als de afbeelding
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Schrijft het PPTX‑bestand naar schijf
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Afbeeldingframes laten u snel presentatiedia's maken op basis van afbeeldingen. Wanneer u een afbeeldingframe combineert met de opslaan‑opties van Aspose.Slides, kunt u in‑ en uitvoerbewerkingen manipuleren om afbeeldingen van het ene formaat naar het andere te converteren. U wilt wellicht de volgende pagina’s bekijken: converteer [image to JPG](https://products.aspose.com/slides/nl/java/conversion/image-to-jpg/); converteer [JPG to image](https://products.aspose.com/slides/nl/java/conversion/jpg-to-image/); converteer [JPG to PNG](https://products.aspose.com/slides/nl/java/conversion/jpg-to-png/), converteer [PNG to JPG](https://products.aspose.com/slides/nl/java/conversion/png-to-jpg/); converteer [PNG to SVG](https://products.aspose.com/slides/nl/java/conversion/png-to-svg/), converteer [SVG to PNG](https://products.aspose.com/slides/nl/java/conversion/svg-to-png/).

{{% /alert %}}

## **Maak een afbeeldingframe met relatieve schaal**

Door de relatieve schaal van een afbeelding te wijzigen, kunt u een ingewikkelder afbeeldingframe creëren.  

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een afbeelding toe aan de presentatie‑afbeeldingscollectie.  
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPPImage)‑object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImageCollection) die gekoppeld is aan het presentatie‑object dat zal worden gebruikt om de vorm te vullen.  
5. Specificeer de relatieve breedte en hoogte van de afbeelding in het afbeeldingframe.  
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe u een afbeeldingframe met relatieve schaal maakt:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instantieer Presentation-klasse die de PPTX representeert
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieer Image-klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Voeg Picture Frame toe met dezelfde hoogte en breedte als de afbeelding
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Instellen van relatieve schaalbreedte en -hoogte
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Schrijf het PPTX-bestand naar schijf
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Raster‑afbeeldingen uit afbeeldingframes extraheren**

U kunt raster‑afbeeldingen uit [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PictureFrame)‑objecten extraheren en opslaan in PNG, JPG en andere formaten. Het code‑voorbeeld hieronder toont hoe u een afbeelding uit het document “sample.pptx” haalt en opslaat in PNG‑formaat.

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

## **SVG‑afbeeldingen uit afbeeldingframes extraheren**

Wanneer een presentatie SVG‑grafieken bevat die in [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/)‑vormen zijn geplaatst, laat Aspose.Slides for Java u de oorspronkelijke vector‑afbeeldingen met volledige nauwkeurigheid ophalen. Door de vormcollectie van de dia te doorlopen, kunt u elke [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) identificeren, controleren of de onderliggende [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) SVG‑inhoud bevat, en vervolgens die afbeelding naar schijf of een stream opslaan in het originele SVG‑formaat.

Het volgende code‑voorbeeld toont hoe u een SVG‑afbeelding uit een afbeeldingframe haalt:

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

        // getSvgImage retourneert null wanneer de afbeelding een rasterafbeelding is.
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

## **Transparantie van een afbeelding ophalen**

Aspose.Slides stelt u in staat de transparantie‑effecten op een afbeelding op te halen. Deze Java‑code demonstreert de bewerking:

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

## **Helderheid en contrast van een afbeelding ophalen**

Aspose.Slides stelt u in staat de helderheid‑ en contrast‑effecten op een afbeelding op te halen. De [ILuminance](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iluminance/)‑interface vertegenwoordigt dit afbeeldingstransformatie‑effect.

Deze Java‑code toont hoe u de helderheid‑ en contrastinstellingen van een afbeeldingframe ophaalt:

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

## **Opmaak van afbeeldingframes**

Aspose.Slides biedt vele opmaakopties die op een afbeeldingframe kunnen worden toegepast. Met die opties kunt u een afbeeldingframe aanpassen zodat het voldoet aan specifieke eisen.

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPPImage)‑object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImageCollection) die gekoppeld is aan het presentatie‑object dat zal worden gebruikt om de vorm te vullen.  
4. Specificeer de breedte en hoogte van de afbeelding.  
5. Maak een `PictureFrame` aan op basis van de breedte en hoogte van de afbeelding via de [AddPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)‑methode die wordt blootgesteld door het [IShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection)‑object dat is gekoppeld aan de refererende dia.  
6. Voeg het afbeeldingframe (met de afbeelding) toe aan de dia.  
7. Stel de lijnkleur van het afbeeldingframe in.  
8. Stel de lijndikte van het afbeeldingframe in.  
9. Roteer het afbeeldingframe door een positieve of negatieve waarde op te geven.  
   * Een positieve waarde roteert de afbeelding met de klok mee.  
   * Een negatieve waarde roteert de afbeelding tegen de klok in.  
10. Voeg het afbeeldingframe (met de afbeelding) nogmaals toe aan de dia.  
11. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code demonstreert het opmaakproces van een afbeeldingframe:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instantieert de Presentation-klasse die de PPTX representeert
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieert de Image-klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Voegt een afbeeldingframe toe met dezelfde hoogte en breedte als de afbeelding
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Past enige opmaak toe op PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Schrijft het PPTX-bestand naar schijf
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Aspose heeft recentelijk een [gratis Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als u ooit JPG/JPEG‑ of PNG‑afbeeldingen wilt [samenvoegen](https://products.aspose.app/slides/nl/collage/jpg) of rasternen wilt maken van foto’s, kunt u deze service gebruiken. 

{{% /alert %}}

## **Een afbeelding als link toevoegen**

Om de bestandsgrootte van een presentatie laag te houden, kunt u afbeeldingen (of video’s) toevoegen via koppelingen in plaats van de bestanden direct in de presentatie te embedden. Deze Java‑code laat zien hoe u een afbeelding en video in een placeholder toevoegt:

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

## **Afbeeldingen bijsnijden**

Deze Java‑code toont hoe u een bestaande afbeelding op een dia bijsnijdt:

```java
import com.aspose.slides.*;

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

Presentation pres = new Presentation();
// Maakt een nieuw afbeeldingobject
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt een afbeeldingframe toe aan een dia
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Bijsnijdt de afbeelding (percentagewaarden)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Slaat het resultaat op
    pres.save(outPptxFile, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bijsneden gebieden van een afbeelding verwijderen**

Als u de bijgesneden gebieden van een afbeelding in een frame wilt verwijderen, kunt u de [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)‑methode gebruiken. Deze methode retourneert de bijgesneden afbeelding of de originele afbeelding indien bijsnijden niet nodig is.

Deze Java‑code demonstreert de bewerking:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Haalt het PictureFrame op van de eerste dia
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Verwijdert bijgesneden gebieden van de PictureFrame‑afbeelding en retourneert de bijgesneden afbeelding
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Slaat het resultaat op
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

De [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)‑methode voegt de bijgesneden afbeelding toe aan de presentatie‑afbeeldingscollectie. Als de afbeelding alleen wordt gebruikt in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/), kan deze instelling de presentatiegrootte verkleinen. Anders zal het aantal afbeeldingen in de resulterende presentatie toenemen.

Deze methode converteert WMF/EMF‑metabestanden naar raster‑PNG‑afbeeldingen tijdens de bijsnijdoperatie. 

{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met de [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-)‑methode. Deze methode comprimeert een afbeelding door de grootte te verkleinen op basis van de vormgrootte en de opgegeven resolutie, met de optie om bijgesneden gebieden te verwijderen.

Het past de grootte en resolutie van de afbeelding aan op dezelfde manier als de PowerPoint‑functie **Picture Format → Compress Pictures → Resolution**.

De volgende Java‑voorbeelden tonen hoe u een afbeelding in een presentatie comprimeert door een doellocatie‑resolutie op te geven en eventueel bijgesneden gebieden te verwijderen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Comprimeer de afbeelding met een doelresolutie van 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Check the result of the compression.
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

Of door direct een aangepaste DPI‑waarde te gebruiken:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Comprimeer de afbeelding naar 150 DPI (webresolutie), waarbij bijgesneden gebieden worden verwijderd.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

De methode converteert de afbeelding naar een lagere resolutie op basis van de vormgrootte en de opgegeven DPI. Bijgesneden gebieden kunnen ook worden verwijderd om de bestandsgrootte te optimaliseren.  
Als de afbeelding een metafile (WMF/EMF) of SVG is, wordt compressie niet toegepast. Ook behoudt JPEG‑kwaliteit zich of wordt licht verminderd afhankelijk van de resolutie, vergelijkbaar met hoe PowerPoint hoge‑resolutie JPEG‑bestanden hanteert.

{{% /alert %}}

## **Aspectverhouding vergrendelen**

Als u wilt dat een vorm met een afbeelding zijn aspectverhouding behoudt, zelfs nadat u de afbeeldingsdimensies wijzigt, kunt u de [setAspectRatioLocked](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-)‑methode gebruiken om de instelling *Lock Aspect Ratio* in te stellen. 

Deze Java‑code toont hoe u de aspectverhouding van een vorm vergrendelt:

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

    // stel de vorm in om de aspectverhouding bij het schalen te behouden
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Deze *Lock Aspect Ratio*‑instelling behoudt alleen de aspectverhouding van de vorm en niet van de afbeelding die erin zit.

{{% /alert %}}

## **Gebruik de StretchOff‑eigenschap**

Door de eigenschappen [StretchOffsetLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) en [StretchOffsetBottom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) te gebruiken vanuit de [IPictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat)‑interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat)‑klasse, kunt u een vulrechthoek specificeren.  

Wanneer rekken voor een afbeelding wordt gespecificeerd, wordt een bronrechthoek geschaald om in de opgegeven vulrechthoek te passen. Elke rand van de vulrechthoek wordt gedefinieerd door een procentuele offset ten opzichte van de overeenkomstige rand van de begrenzende rechthoek van de vorm. Een positief percentage geeft een inset aan, een negatief percentage een outset.

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een rechthoek `AutoShape` toe.  
4. Maak een afbeelding.  
5. Stel het vultype van de vorm in.  
6. Stel de picture‑fill‑modus van de vorm in.  
7. Voeg een afbeelding toe om de vorm te vullen.  
8. Specificeer afbeeldingsoffsets ten opzichte van de overeenkomstige rand van de begrenzende rechthoek van de vorm.  
9. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code demonstreert een proces waarin een StretchOff‑eigenschap wordt gebruikt:

```java
import com.aspose.slides.*;

// Instantieert de Presentation-klasse die een PPTX-bestand representeert
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide slide = pres.getSlides().get_Item(0);

    // Instantieert de Image-klasse
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt een AutoShape toe ingesteld op rechthoek
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Stelt het vultype van de vorm in
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Stelt de picture-fill-modus van de vorm in
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Stelt de afbeelding in om de vorm te vullen
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Specificeert de afbeeldingsoffsets ten opzichte van de overeenkomstige rand van de begrenzende rechthoek van de vorm
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // Schrijft het PPTX-bestand naar schijf
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Hoe kan ik achterhalen welke afbeeldingformaten worden ondersteund voor PictureFrame?

Aspose.Slides ondersteunt zowel rasterafbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vectorafbeeldingen (bijvoorbeeld SVG) via het afbeeldingobject dat is toegewezen aan een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/). De lijst met ondersteunde formaten overlapt doorgaans met de mogelijkheden van de dia‑ en afbeeldingconversie‑engine.

### Hoe beïnvloedt het toevoegen van tientallen grote afbeeldingen de grootte en prestaties van een PPTX‑bestand?

Grote afbeeldingen embedden vergroot de bestandsgrootte en het geheugenverbruik; afbeeldingen koppelen helpt de presentatiegrootte klein te houden maar vereist dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via koppeling toe te voegen om de bestandsgrootte te reduceren.

### Hoe kan ik een afbeeldingobject vergrendelen tegen per ongeluk verplaatsen/vergroten of -verkleinen?

Gebruik [shape locks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) voor een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) (bijvoorbeeld om verplaatsen of schalen te uitschakelen). Het vergrendelingsmechanisme wordt beschreven voor vormen in een apart [protection article](/slides/nl/java/applying-protection-to-presentation/) en wordt ondersteund voor diverse vormtypen, inclusief [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/).

### Wordt de vector‑fidelity van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?

Aspose.Slides maakt het mogelijk een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) te extraheren als de originele vector. Bij het [exporteren naar PDF](/slides/nl/java/convert-powerpoint-to-pdf/) of [rasterformaten](/slides/nl/java/convert-powerpoint-to-png/) kan het resultaat gerasterd worden afhankelijk van de exportinstellingen; het feit dat de originele SVG als vector wordt bewaard, wordt bevestigd door het extractie‑gedrag.