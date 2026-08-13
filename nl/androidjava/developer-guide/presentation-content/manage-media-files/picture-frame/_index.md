---
title: Beheer fotolijsten in presentaties op Android
linktitle: Fotolijst
type: docs
weight: 10
url: /nl/androidjava/picture-frame/
keywords:
- fotolijst
- fotolijst toevoegen
- fotolijst maken
- afbeelding toevoegen
- afbeelding maken
- afbeelding extraheren
- rasterafbeelding
- vectorafbeelding
- afbeelding bijsnijden
- bijgesneden gebied
- StretchOff-eigenschap
- opmaak van fotolijst
- eigenschappen van fotolijst
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- afbeeldingstransparantie
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Voeg fotolijsten toe aan PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android via Java. Versnel uw workflow en verbeter het ontwerp van dia's."
---
## **Inleiding**

Een fotolijst is een vorm die een afbeelding bevat – het is als een foto in een lijst.  

U kunt een afbeelding aan een dia toevoegen via een fotolijst. Op deze manier kunt u de afbeelding opmaken door de fotolijst op te maken.

{{% alert  title="Tip" color="info" %}} 

Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die mensen in staat stellen snel presentaties te maken van afbeeldingen. 

{{% /alert %}} 

## **Maak een fotolijst**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Maak een [IPPImage]() object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IImageCollection) die aan het presentatiedocument is gekoppeld en die zal worden gebruikt om de vorm te vullen.  
4. Geef de breedte en hoogte van de afbeelding op.  
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PictureFrame) op basis van de breedte en hoogte van de afbeelding via de `AddPictureFrame`‑methode die wordt aangeboden door het vormobject dat aan de betreffende dia is gekoppeld.  
6. Voeg een fotolijst (die de afbeelding bevat) toe aan de dia.  
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

Deze Java‑code laat zien hoe u een fotolijst maakt:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantiesert de Image-klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Voegt een fotolijst toe met dezelfde hoogte en breedte als de afbeelding
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Schrijft het PPTX-bestand naar schijf
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Maak een fotolijst met relatieve schaal**

Door de relatieve schaal van een afbeelding te wijzigen, kunt u een ingewikkeldere fotolijst maken.  

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een afbeelding toe aan de afbeeldingscollectie van de presentatie.  
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPPImage) object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IImageCollection) die aan het presentatiedocument is gekoppeld en die zal worden gebruikt om de vorm te vullen.  
5. Geef de relatieve breedte en hoogte van de afbeelding op in de fotolijst.  
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

Deze Java‑code laat zien hoe u een fotolijst maakt met relatieve schaal:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instantieer de Presentation-klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieer de Image-klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Voeg een fotolijst toe met dezelfde hoogte en breedte als de afbeelding
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

## **Rasterafbeeldingen extraheren uit fotolijsten**

U kunt rasterafbeeldingen uit [PictureFrame]-objecten extraheren en opslaan in PNG, JPG en andere formaten. Het code‑voorbeeld hieronder laat zien hoe u een afbeelding uit het document "sample.pptx" kunt extraheren en opslaan in PNG‑formaat.

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

## **SVG‑afbeeldingen extraheren uit fotolijsten**

Wanneer een presentatie SVG‑grafieken bevat die in [PictureFrame]-vormen zijn geplaatst, stelt Aspose.Slides voor Android via Java u in staat de originele vectorafbeeldingen met volledige getrouwheid op te halen. Zodra u een [PictureFrame] hebt waarvan de [IPPImage] SVG‑inhoud bevat, kunt u die SVG‑afbeelding lezen en opslaan op schijf of in een stream in het oorspronkelijke SVG‑formaat.

Het volgende code‑voorbeeld laat zien hoe u een SVG‑afbeelding uit een fotolijst kunt extraheren:

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

## **Transparantie van een afbeelding ophalen**

Aspose.Slides maakt het mogelijk de transparantieteffecten die op een afbeelding zijn toegepast op te halen. Deze Java‑code demonstreert de bewerking:

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

Aspose.Slides maakt het mogelijk de helderheids‑ en contrasteffecten die op een afbeelding zijn toegepast op te halen. De [ILuminance](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iluminance/) interface vertegenwoordigt dit afbeeldingstransformatie‑effect.

Deze Java‑code laat zien hoe u de helderheids‑ en contrastinstellingen van een fotolijst kunt ophalen:

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

## **Opmaak van fotolijst**

Aspose.Slides biedt veel opmaakopties die op een fotolijst kunnen worden toegepast. Met die opties kunt u een fotolijst aanpassen zodat deze aan specifieke eisen voldoet.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPPImage) object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IImageCollection) die aan het presentatiedocument is gekoppeld en die zal worden gebruikt om de vorm te vullen.  
4. Geef de breedte en hoogte van de afbeelding op.  
5. Maak een `PictureFrame` op basis van de breedte en hoogte van de afbeelding via de [AddPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)‑methode die wordt aangeboden door het [IShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection) object dat aan de betreffende dia is gekoppeld.  
6. Voeg de fotolijst (die de afbeelding bevat) toe aan de dia.  
7. Stel de lijnkleur van de fotolijst in.  
8. Stel de lijnbreedte van de fotolijst in.  
9. Draai de fotolijst door een positieve of negatieve waarde op te geven.  
   * Een positieve waarde draait de afbeelding met de klok mee.  
   * Een negatieve waarde draait de afbeelding tegen de klok in.  
10. Voeg de fotolijst (die de afbeelding bevat) toe aan de dia.  
11. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

Deze Java‑code demonstreert het opmaakproces van een fotolijst:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instantieert de Presentation-klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieert de Image-klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Voeg een fotolijst toe met dezelfde hoogte en breedte als de afbeelding
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Pas wat opmaak toe op PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Schrijf het PPTX-bestand naar schijf
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Aspose heeft recentelijk een [gratis Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als u ooit JPG/JPEG of PNG‑afbeeldingen wilt samenvoegen, of rasteren uit foto’s wilt maken, kunt u deze service gebruiken. 

{{% /alert %}}

## **Afbeelding als link toevoegen**

Om grote presentaties te voorkomen, kunt u afbeeldingen (of video’s) via links toevoegen in plaats van de bestanden direct in de presentatie te embedden. Deze Java‑code laat zien hoe u een afbeelding en video in een placeholder kunt toevoegen:

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

Deze Java‑code laat zien hoe u een bestaande afbeelding op een dia kunt bijsnijden:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// Creëert nieuw afbeeldingobject
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt een fotolijst toe aan een dia
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Bijsnijdt de afbeelding (percentage waarden)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Slaat het resultaat op
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bijsneden gebieden van een foto verwijderen**

Als u de bijgesneden gebieden van een afbeelding in een lijst wilt verwijderen, kunt u de [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) methode gebruiken. Deze methode retourneert de bijgesneden afbeelding of de oorspronkelijke afbeelding als bijsnijden niet nodig is.

Deze Java‑code demonstreert de bewerking:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Haalt de fotolijst op van de eerste dia
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Verwijdert de bijgesneden gebieden van de afbeelding in de fotolijst en retourneert de bijgesneden afbeelding
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Slaat het resultaat op
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

De [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) methode voegt de bijgesneden afbeelding toe aan de afbeeldingscollectie van de presentatie. Als de afbeelding alleen wordt gebruikt in de verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/), kan deze instelling de presentatiesmallte verkleinen. Anders zal het aantal afbeeldingen in de resulterende presentatie toenemen.

Deze methode zet WMF/EMF‑metabestanden om naar raster‑PNG‑afbeeldingen tijdens het bijsnijden. 

{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met behulp van de [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) methode.  
Deze methode comprimeert een afbeelding door de grootte te verkleinen op basis van de vormgrootte en de opgegeven resolutie, met de optie om bijgesneden gebieden te verwijderen.

Het past de grootte en resolutie van de afbeelding aan op dezelfde manier als de functie **Picture Format > Compress Pictures > Resolution** in PowerPoint.

De volgende Java‑voorbeelden laten zien hoe u een afbeelding in een presentatie comprimeert door een doelresolutie op te geven en eventueel bijgesneden gebieden te verwijderen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Comprimeer de afbeelding met een doelresolutie van 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Controleer het resultaat van de compressie.
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

    // Comprimeer de afbeelding tot 150 DPI (webresolutie), waarbij bijgesneden gebieden worden verwijderd.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

De methode zet de afbeelding om naar een lagere resolutie op basis van de vormgrootte en de opgegeven DPI. Bijgesneden gebieden kunnen ook worden verwijderd om de bestandsgrootte te optimaliseren.  
Als de afbeelding een metafile (WMF/EMF) of SVG is, wordt compressie niet toegepast. Ook wordt de JPEG‑kwaliteit behouden of licht verminderd afhankelijk van de resolutie, vergelijkbaar met de manier waarop PowerPoint hoge‑resolutie JPEG‑s verwerkt.

{{% /alert %}}

## **Verhouding vergrendelen**

Als u wilt dat een vorm met een afbeelding zijn verhoudingen behoudt, zelfs nadat u de afmetingen van de afbeelding hebt gewijzigd, kunt u de [setAspectRatioLocked](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) methode gebruiken om de *Lock Aspect Ratio*‑instelling te activeren.

Deze Java‑code laat zien hoe u de verhoudingen van een vorm kunt vergrendelen:

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

    // stel de vorm in om de beeldverhouding te behouden bij het schalen
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Deze *Lock Aspect Ratio*‑instelling behoudt alleen de verhoudingen van de vorm en niet van de afbeelding die erin zit.

{{% /alert %}}

## **De StretchOff‑eigenschap gebruiken**

Met de [StretchOffsetLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) en [StretchOffsetBottom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) eigenschappen van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPictureFillFormat) interface en [PictureFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPictureFillFormat) klasse kunt u een vulrechthoek specificeren.

Wanneer streching wordt gespecificeerd voor een afbeelding, wordt een brondrechthoek geschaald zodat deze past in de opgegeven vulrechthoek. Elke rand van de vulrechthoek wordt gedefinieerd door een percentage‑offset ten opzichte van de overeenkomstige rand van de begrenzingsdoos van de vorm. Een positief percentage geeft een inset aan, een negatief percentage een outset.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een rechthoek `AutoShape` toe.  
4. Maak een afbeelding.  
5. Stel het opvultype van de vorm in.  
6. Stel de afbeeldingsvullingsmodus van de vorm in.  
7. Voeg een afbeelding toe om de vorm te vullen.  
8. Geef afbeeldingsverschuivingen op ten opzichte van de overeenkomstige rand van de begrenzingsdoos van de vorm.  
9. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

Deze Java‑code demonstreert een proces waarbij een StretchOff‑eigenschap wordt gebruikt:

```java
import com.aspose.slides.*;

// Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide slide = pres.getSlides().get_Item(0);

    // Instantiiert de ImageEx-klasse
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt een AutoShape toe van het type Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Stelt het vultype van de vorm in
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Stelt de picture fill-modus van de vorm in
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Stelt de afbeelding in om de vorm te vullen
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Specificeert de afbeeldingverschuivingen ten opzichte van de corresponderende rand van de vorm
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    //Schrijft het PPTX-bestand naar schijf
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Hoe kan ik achterhalen welke afbeeldingsformaten worden ondersteund voor PictureFrame?

Aspose.Slides ondersteunt zowel rasterafbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vectorafbeeldingen (bijvoorbeeld SVG) via het afbeeldingsobject dat is toegewezen aan een [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/). De lijst van ondersteunde formaten overlapt over het algemeen met de mogelijkheden van de dia‑ en afbeelding‑conversie‑engine.

### Hoe beïnvloedt het toevoegen van tientallen grote afbeeldingen de grootte en prestaties van een PPTX?

Het inbedden van grote afbeeldingen vergroot de bestandsgrootte en het geheugenverbruik; afbeeldingen linken helpt de presentatiesmallte laag te houden, maar vereist dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via een link toe te voegen om de bestandsgrootte te verminderen.

### Hoe kan ik een afbeeldingsobject vergrendelen tegen per ongeluk verplaatsen/vergroten?

Gebruik [shape locks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) voor een [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/) (bijvoorbeeld om verplaatsen of schalen uit te schakelen). Het vergrendelingsmechanisme wordt ondersteund voor diverse vormtypen, inclusief [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/).

### Is SVG‑vector getrouwheid behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?

Aspose.Slides maakt het mogelijk een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/) te extraheren als de originele vector. Bij het [exporteren naar PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/) of [rasterformaten](/slides/nl/androidjava/convert-powerpoint-to-png/), kan het resultaat gerasterd worden afhankelijk van de exportinstellingen; het feit dat de originele SVG als vector is opgeslagen, wordt bevestigd door het extractie‑gedrag.