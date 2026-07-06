---
title: Beheer foto-frames in presentaties met Java
linktitle: Foto-frame
type: docs
weight: 10
url: /nl/java/picture-frame/
keywords:
- foto-frame
- foto-frame toevoegen
- foto-frame maken
- afbeelding toevoegen
- afbeelding maken
- afbeelding extraheren
- raster-afbeelding
- vector-afbeelding
- afbeelding bijsnijden
- bijgesneden gebied
- StretchOff eigenschap
- foto-frame opmaak
- foto-frame eigenschappen
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- afbeeldingstransparantie
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Voeg foto-frames toe aan PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Java. Vereenvoudig je workflow en verbeter dia-ontwerpen."
---
## **Introductie**

Een foto-frame is een vorm die een afbeelding bevat – het is als een foto in een frame. 

Je kunt een afbeelding aan een dia toevoegen via een foto-frame. Op deze manier kun je de afbeelding opmaken door het foto-frame op te maken.

{{% alert  title="Tip" color="primary" %}} 

Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die mensen in staat stellen snel presentaties te maken van afbeeldingen. 

{{% /alert %}} 

## **Maak een foto-frame**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Maak een [IPPImage]() object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImageCollection) die aan het presentatiewerkobject is gekoppeld en die wordt gebruikt om de vorm te vullen.  
4. Geef de breedte en hoogte van de afbeelding op.  
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PictureFrame) aan op basis van de breedte en hoogte van de afbeelding via de `AddPictureFrame`‑methode die beschikbaar is in het vormobject dat aan de referentie‑dia is gekoppeld.  
6. Voeg een foto-frame (met de afbeelding) toe aan de dia.  
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

Deze Java‑code laat zien hoe je een foto-frame maakt:

```java
// Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieert de Image-klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Voegt een foto-frame toe met de overeenkomstige hoogte en breedte van de afbeelding
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Schrijft het PPTX-bestand naar schijf
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Foto-frames stellen je in staat snel presentatiedia's te maken op basis van afbeeldingen. Wanneer je een foto-frame combineert met de opslaoptopties van Aspose.Slides, kun je in‑ en uitvoerbewerkingen manipuleren om afbeeldingen van het ene formaat naar het andere te converteren. Mogelijk wil je deze pagina's bekijken: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/java/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/java/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/java/conversion/jpg-to-png/), converteer [PNG naar JPG](https://products.aspose.com/slides/nl/java/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/java/conversion/png-to-svg/), converteer [SVG naar PNG](https://products.aspose.com/slides/nl/java/conversion/svg-to-png/). 

{{% /alert %}}

## **Maak een foto-frame met relatieve schaal**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een afbeelding toe aan de presentatie‑afbeeldingscollectie.  
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPPImage) object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImageCollection) die aan het presentatiewerkobject is gekoppeld en die wordt gebruikt om de vorm te vullen.  
5. Geef de relatieve breedte en hoogte van de afbeelding op in het foto‑frame.  
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

Deze Java‑code laat zien hoe je een foto-frame maakt met relatieve schaal:

```java
// Instantieer de Presentation-klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieer de Image-klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Voeg een Picture Frame toe met dezelfde hoogte en breedte als de afbeelding
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Instelling van relatieve schaalbreedte en -hoogte
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Schrijf het PPTX-bestand naar schijf
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rasterafbeeldingen uit foto‑frames extraheren**

Je kunt rasterafbeeldingen uit [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PictureFrame) objecten extraheren en opslaan in PNG, JPG en andere formaten. Het onderstaande code‑voorbeeld laat zien hoe je een afbeelding uit het document “sample.pptx” haalt en opslaat in PNG‑formaat.

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

## **SVG‑afbeeldingen uit foto‑frames extraheren**

Wanneer een presentatie SVG‑grafieken bevat die in [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) vormen staan, laat Aspose.Slides for Java je de oorspronkelijke vectorafbeeldingen met volledige nauwkeurigheid ophalen. Door de vormcollectie van de dia te doorlopen, kun je elk [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) identificeren, controleren of de onderliggende [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) SVG‑inhoud bevat, en vervolgens die afbeelding op schijf of in een stream opslaan in het oorspronkelijke SVG‑formaat.

Het volgende code‑voorbeeld laat zien hoe je een SVG‑afbeelding uit een foto‑frame haalt:

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

## **Transparantie van een afbeelding verkrijgen**

Aspose.Slides stelt je in staat de transparanteffecten op een afbeelding op te vragen. Deze Java‑code demonstreert de bewerking:

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

## **Helderheid en contrast van een afbeelding verkrijgen**

Aspose.Slides stelt je in staat de helderheids‑ en contrast‑effecten op een afbeelding op te vragen. De [ILuminance](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iluminance/) interface vertegenwoordigt dit transformatie‑effect.

Deze Java‑code laat zien hoe je de helderheids‑ en contrastinstellingen van een foto‑frame ophaalt:

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

## **Opmaak van foto‑frames**

Aspose.Slides biedt veel opmaakopties die op een foto‑frame kunnen worden toegepast. Met die opties kun je een foto‑frame aanpassen zodat het aan specifieke eisen voldoet.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPPImage) object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImageCollection) die aan het presentatiewerkobject is gekoppeld en die wordt gebruikt om de vorm te vullen.  
4. Geef de breedte en hoogte van de afbeelding op.  
5. Maak een `PictureFrame` aan op basis van de breedte en hoogte van de afbeelding via de [AddPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)‑methode die beschikbaar is in het [IShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection) object dat aan de referentie‑dia is gekoppeld.  
6. Voeg het foto‑frame (met de afbeelding) toe aan de dia.  
7. Stel de lijnkleur van het foto‑frame in.  
8. Stel de lijndikte van het foto‑frame in.  
9. Draai het foto‑frame door een positieve of negatieve waarde op te geven.  
   * Een positieve waarde draait de afbeelding met de klok mee.  
   * Een negatieve waarde draait de afbeelding tegen de klok in.  
10. Voeg het foto‑frame (met de afbeelding) toe aan de dia.  
11. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

Deze Java‑code demonstreert het opmaakproces van een foto‑frame:

```java
// Instantieert de Presentation-klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieert de Image-klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Voegt een foto-frame toe met dezelfde hoogte en breedte als de afbeelding
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

{{% alert title="Tip" color="primary" %}}

Aspose heeft recent een [gratis Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als je ooit [JPG/JPEG samenvoegt](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑afbeeldingen wilt combineren, of [roosters maakt van foto’s](https://products.aspose.app/slides/nl/collage/photo-grid), kun je deze service gebruiken. 

{{% /alert %}}

## **Een afbeelding als link toevoegen**

Om grote presentaties te voorkomen, kun je afbeeldingen (of video's) via links toevoegen in plaats van de bestanden direct in de presentatie in te sluiten. Deze Java‑code laat zien hoe je een afbeelding en een video in een placeholder kunt invoegen:

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

## **Afbeeldingen bijsnijden**

Deze Java‑code laat zien hoe je een bestaande afbeelding op een dia kunt bijsnijden:

```java
Presentation pres = new Presentation();
// Maak een nieuw afbeeldingobject
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt een foto-frame toe aan een dia
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Bijsnijdt de afbeelding (percentage waarden)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Slaat het resultaat op
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bijsneden gebieden van een foto verwijderen**

Als je de bijgesneden gebieden van een afbeelding in een frame wilt verwijderen, kun je de [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) methode gebruiken. Deze methode retourneert de bijgesneden afbeelding of de oorspronkelijke afbeelding als bijsnijden niet nodig is.

Deze Java‑code demonstreert de bewerking:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Haalt het PictureFrame op van de eerste dia
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Verwijdert bijgesneden gebieden van de PictureFrame-afbeelding en retourneert de bijgesneden afbeelding
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Slaat het resultaat op
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

De [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) methode voegt de bijgesneden afbeelding toe aan de presentatie‑afbeeldingscollectie. Als de afbeelding alleen wordt gebruikt in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/), kan deze instelling de presentatiegrootte verkleinen. Anders zal het aantal afbeeldingen in de uiteindelijke presentatie toenemen.

Deze methode converteert WMF/EMF‑metabestanden naar raster‑PNG‑afbeeldingen tijdens de bijsnijdbewerking. 

{{% /alert %}}

## **Afbeeldingen comprimeren**

Je kunt een foto in een presentatie comprimeren met de [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) methode. Deze methode comprimeert een afbeelding door de grootte te verkleinen op basis van de vormgrootte en de opgegeven resolutie, met de optie om bijgesneden gebieden te verwijderen.

Het past de grootte en resolutie van de afbeelding aan, vergelijkbaar met de PowerPoint‑functie **Picture Format -> Compress Pictures -> Resolution**.

De volgende Java‑voorbeelden laten zien hoe je een afbeelding in een presentatie comprimeert door een doelresolutie op te geven en eventueel bijgesneden gebieden te verwijderen:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Comprimeer de afbeelding met een targetresolutie van 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
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
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Comprimeer de afbeelding naar 150 DPI (webresolutie), verwijder bijgesneden gebieden.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

De methode converteert de afbeelding naar een lagere resolutie op basis van de vormgrootte en de opgegeven DPI. Bijgesneden gebieden kunnen ook worden verwijderd om de bestandsgrootte te optimaliseren.  
Als de afbeelding een metabestand (WMF/EMF) of SVG is, wordt compressie niet toegepast. Ook wordt de JPEG‑kwaliteit behouden of licht verlaagd afhankelijk van de resolutie, net zoals PowerPoint omgaat met hoge‑resolutie JPEG‑bestanden.

{{% /alert %}}

## **Verhouding vastzetten**

Als je wilt dat een vorm met een afbeelding de verhouding behoudt, zelfs nadat je de afmetingen van de afbeelding verandert, kun je de [setAspectRatioLocked](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) methode gebruiken om de instelling *Lock Aspect Ratio* in te stellen. 

Deze Java‑code laat zien hoe je de verhouding van een vorm vastzet:

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

    // stel de vorm in om de beeldverhouding te behouden bij het schalen
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Deze *Lock Aspect Ratio* instelling behoudt alleen de verhouding van de vorm en niet van de afbeelding die erin zit.

{{% /alert %}}

## **Gebruik de StretchOff‑eigenschap**

Door de eigenschappen [StretchOffsetLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) en [StretchOffsetBottom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat) interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat) klasse te gebruiken, kun je een opvulrechthoek definiëren. 

Wanneer stretching wordt opgegeven voor een afbeelding, wordt een bronrechthoek geschaald om te passen binnen de opgegeven opvulrechthoek. Elke rand van de opvulrechthoek wordt gedefinieerd door een procentuele verschuiving ten opzichte van de overeenkomende rand van de omvattende doos van de vorm. Een positieve procentwaarde geeft een insprong aan, een negatieve waarde een uitsteeksel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een rechthoek `AutoShape` toe.  
4. Maak een afbeelding.  
5. Stel het vultype van de vorm in.  
6. Stel de vullingmodus van de afbeelding in.  
7. Voeg de afbeelding toe om de vorm te vullen.  
8. Specificeer afbeeldingsverschuivingen ten opzichte van de overeenkomstige rand van de omvattende doos van de vorm.  
9. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

Deze Java‑code demonstreert een proces waarin een StretchOff‑eigenschap wordt gebruikt:

```java
// Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide slide = pres.getSlides().get_Item(0);

    // Instantieert de ImageEx-klasse
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt een AutoShape toe van het type Rechthoek
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Stelt het vultype van de vorm in
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Stelt de afbeeldingsvullingsmodus van de vorm in
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Stelt de afbeelding in om de vorm te vullen
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Specificeert de afbeeldingsverschuivingen ten opzichte van de overeenkomstige rand van de omvattende doos van de vorm
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Schrijft het PPTX-bestand naar schijf
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hoe kan ik achterhalen welke afbeeldingsformaten worden ondersteund voor PictureFrame?**

Aspose.Slides ondersteunt zowel raster‑afbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vector‑afbeeldingen (bijvoorbeeld SVG) via het afbeeldingsobject dat aan een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) is toegewezen. De lijst met ondersteunde formaten overlapt doorgaans met de mogelijkheden van de dia‑ en afbeelding‑conversie‑engine.

**Hoe beïnvloedt het toevoegen van tientallen grote afbeeldingen de PPTX‑grootte en prestaties?**

Grote afbeeldingen insluiten vergroot de bestandsgrootte en het geheugengebruik; afbeeldingen linken houdt de presentatiegrootte klein, maar vereist dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via link toe te voegen om de bestandsgrootte te reduceren.

**Hoe kan ik een afbeeldingsobject vergrendelen tegen per ongeluk verplaatsen/vergroten?**

Gebruik [vorm‑vergrendelingen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) voor een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) (bijvoorbeeld om verplaatsen of vergroten uit te schakelen). Het vergrendelingsmechanisme wordt beschreven voor vormen in een apart [beschermings‑artikel](/slides/nl/java/applying-protection-to-presentation/) en wordt ondersteund voor diverse vormtypes, inclusief [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/).

**Wordt de vector‑fidelity van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?**

Aspose.Slides maakt het mogelijk een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) te extraheren als de oorspronkelijke vector. Bij het [exporteren naar PDF](/slides/nl/java/convert-powerpoint-to-pdf/) of [rasterformaten](/slides/nl/java/convert-powerpoint-to-png/) kan het resultaat gerasterd worden afhankelijk van de exportinstellingen; het feit dat de oorspronkelijke SVG als vector is opgeslagen, wordt bevestigd door het extractie‑gedrag.