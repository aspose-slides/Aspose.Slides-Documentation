---
title: Beheer afbeeldingskaders in presentaties op Android
linktitle: Afbeeldingskader
type: docs
weight: 10
url: /nl/androidjava/picture-frame/
keywords:
- afbeeldingskader
- afbeeldingskader toevoegen
- afbeeldingskader maken
- afbeelding toevoegen
- afbeelding maken
- afbeelding extraheren
- rasterafbeelding
- vectorafbeelding
- afbeelding bijsnijden
- bijgesneden gebied
- StretchOff-eigenschap
- opmaak van afbeeldingskader
- eigenschappen van afbeeldingskader
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
description: "Voeg afbeeldingskaders toe aan PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android via Java. Versnel uw workflow en verbeter het ontwerp van dia's."
---
## **Inleiding**

Een afbeeldingskader is een vorm die een afbeelding bevat - het is als een foto in een lijst.  

U kunt een afbeelding aan een dia toevoegen via een afbeeldingskader. Op deze manier kunt u de afbeelding opmaken door het afbeeldingskader op te maken.

{{% alert  title="Tip" color="primary" %}} 

Aspose biedt gratis converters - [JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt) - die gebruikers in staat stellen snel presentaties te maken van afbeeldingen. 

{{% /alert %}} 

## **Maak een afbeeldingskader**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Maak een [IPPImage]() object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IImageCollection) die bij het presentatie‑object hoort en die gebruikt zal worden om de vorm te vullen.  
4. Geef de breedte en hoogte van de afbeelding op.  
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PictureFrame) op basis van de breedte en hoogte van de afbeelding via de `AddPictureFrame`‑methode die wordt aangeboden door het vormobject dat gekoppeld is aan de gerefereerde dia.  
6. Voeg een afbeeldingskader (met de afbeelding) toe aan de dia.  
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.  

Deze Java‑code laat zien hoe u een afbeeldingskader maakt:

```java
// Instantieert de Presentation-klasse die een PPTX-bestand representeert
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieert de Image-klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Voegt een afbeeldingskader toe met dezelfde hoogte en breedte als de afbeelding
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Schrijf het PPTX-bestand naar schijf
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Maak een afbeeldingskader met relatieve schaal**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een afbeelding toe aan de afbeeldingsverzameling van de presentatie.  
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPPImage) object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IImageCollection) die bij het presentatie‑object hoort en die gebruikt zal worden om de vorm te vullen.  
5. Geef de relatieve breedte en hoogte van de afbeelding op in het afbeeldingskader.  
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.  

Deze Java‑code laat zien hoe u een afbeeldingskader maakt met relatieve schaal:

```java
// Instantieer de Presentation-klasse die de PPTX representeert
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieer de Image-klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Voeg een Picture Frame toe met dezelfde hoogte en breedte als de afbeelding
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Instellen van relatieve schaal voor breedte en hoogte
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Schrijf het PPTX-bestand naar schijf
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rasterafbeeldingen extraheren uit afbeeldingskaders**

U kunt rasterafbeeldingen uit [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PictureFrame) objecten extraheren en opslaan in PNG, JPG en andere formaten. Het onderstaande codevoorbeeld laat zien hoe u een afbeelding uit het document "sample.pptx" extrahert en opslaat in PNG‑formaat.

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

## **SVG‑afbeeldingen extraheren uit afbeeldingskaders**

Wanneer een presentatie SVG‑grafieken bevat die in [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/) vormen zijn geplaatst, stelt Aspose.Slides voor Android via Java u in staat om de oorspronkelijke vectorafbeeldingen met volledige getrouwheid op te halen. Door de vormverzameling van de dia te doorlopen, kunt u elk [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/) identificeren, controleren of de onderliggende [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) SVG‑inhoud bevat, en vervolgens die afbeelding opslaan op schijf of in een stream in het oorspronkelijke SVG‑formaat.  

Het volgende codevoorbeeld laat zien hoe u een SVG‑afbeelding uit een afbeeldingskader kunt extraheren:

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

## **Transparantie van een afbeelding ophalen**

Aspose.Slides stelt u in staat de toegepaste transparantie‑effect van een afbeelding op te halen. Deze Java‑code demonstreert de bewerking:

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

## **Opmaak van afbeeldingskader**

Aspose.Slides biedt vele opmaakopties die toegepast kunnen worden op een afbeeldingskader. Met behulp van die opties kunt u een afbeeldingskader aanpassen zodat het aan specifieke eisen voldoet.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPPImage) object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IImageCollection) die bij het presentatie‑object hoort en die gebruikt zal worden om de vorm te vullen.  
4. Geef de breedte en hoogte van de afbeelding op.  
5. Maak een `PictureFrame` op basis van de breedte en hoogte van de afbeelding via de [AddPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)‑methode die wordt aangeboden door het [IShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection) object dat gekoppeld is aan de gerefereerde dia.  
6. Voeg het afbeeldingskader (met de afbeelding) toe aan de dia.  
7. Stel de lijnkleur van het afbeeldingskader in.  
8. Stel de lijndikte van het afbeeldingskader in.  
9. Roteer het afbeeldingskader door het een positieve of negatieve waarde te geven.  
   * Een positieve waarde roteert de afbeelding met de klok mee.  
   * Een negatieve waarde roteert de afbeelding tegen de klok in.  
10. Voeg het afbeeldingskader (met de afbeelding) toe aan de dia.  
11. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.  

Deze Java‑code demonstreert het opmaakproces van een afbeeldingskader:

```java
// Instantieert de Presentation-klasse die de PPTX representeert
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieert de Image-klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Voegt een Picture Frame toe met dezelfde hoogte en breedte als de afbeelding
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Past wat opmaak toe op PictureFrameEx
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

Aspose heeft onlangs een [gratis Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als u ooit [JPG/JPEG moet samenvoegen](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑afbeeldingen, [roosters van foto's wilt maken](https://products.aspose.app/slides/nl/collage/photo-grid), kunt u deze dienst gebruiken. 

{{% /alert %}}

## **Afbeelding toevoegen als koppeling**

Om grote presentaties te voorkomen, kunt u afbeeldingen (of video’s) via koppelingen toevoegen in plaats van de bestanden direct in de presentatie in te sluiten. Deze Java‑code laat zien hoe u een afbeelding en video in een tijdelijke aanduiding kunt toevoegen:

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

Deze Java‑code laat zien hoe u een bestaande afbeelding op een dia kunt bijsnijden:

```java
Presentation pres = new Presentation();
// Creëert een nieuw afbeeldingsobject
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt een PictureFrame toe aan een dia
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Bijsnijden van de afbeelding (percentagewaarden)
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

## **Bijsneden gebieden van een afbeelding verwijderen**

Als u de bijgesneden gebieden van een afbeelding in een kader wilt verwijderen, kunt u de [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)‑methode gebruiken. Deze methode retourneert de bijgesneden afbeelding of de oorspronkelijke afbeelding als bijsnijden niet nodig is.  

Deze Java‑code demonstreert de bewerking:

```java
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

{{% alert title="OPMERKING" color="warning" %}} 

De [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) methode voegt de bijgesneden afbeelding toe aan de afbeeldingsverzameling van de presentatie. Als de afbeelding alleen wordt gebruikt in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/), kan deze instelling de presentatiegrootte verkleinen. Anders zal het aantal afbeeldingen in de resulterende presentatie toenemen.  

Deze methode converteert WMF/EMF‑metabestanden naar raster‑PNG‑afbeeldingen tijdens de bijsnijdoperatie. 

{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met behulp van de [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-)‑methode. Deze methode comprimeert een afbeelding door de grootte te verkleinen op basis van de vormgrootte en de opgegeven resolutie, met de mogelijkheid om bijgesneden gebieden te verwijderen.  

Hij past de grootte en resolutie van de afbeelding aan, vergelijkbaar met de PowerPoint‑functie **Picture Format > Compress Pictures > Resolution**.  

De volgende Java‑voorbeelden tonen hoe u een afbeelding in een presentatie comprimeert door een doelresolutie op te geven en eventueel bijgesneden gebieden te verwijderen:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Comprimeert de afbeelding met een doelresolutie van 150 DPI (webresolutie) en verwijdert bijgesneden gebieden.
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

Of door rechtstreeks een aangepaste DPI‑waarde te gebruiken:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Comprimeert de afbeelding tot 150 DPI (webresolutie), en verwijdert bijgesneden gebieden.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="OPMERKING" color="warning" %}} 

De methode converteert de afbeelding naar een lagere resolutie op basis van de vormgrootte en de opgegeven DPI. Bijgesneden gebieden kunnen ook worden verwijderd om de bestandsgrootte te optimaliseren. Als de afbeelding een metabestand (WMF/EMF) of SVG is, wordt compressie niet toegepast. Bovendien wordt de JPEG‑kwaliteit behouden of licht verminderd afhankelijk van de resolutie, vergelijkbaar met hoe PowerPoint omgaat met JPEG's met hoge resolutie.  

{{% /alert %}}

## **Beeldverhouding vergrendelen**

Als u wilt dat een vorm met een afbeelding zijn beeldverhouding behoudt, zelfs nadat u de afmetingen van de afbeelding wijzigt, kunt u de [setAspectRatioLocked](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-)‑methode gebruiken om de *Lock Aspect Ratio*-instelling in te schakelen.  

Deze Java‑code laat zien hoe u de beeldverhouding van een vorm vergrendelt:

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

{{% alert title="OPMERKING" color="warning" %}} 

Deze *Lock Aspect Ratio*-instelling behoudt alleen de beeldverhouding van de vorm en niet van de afbeelding die erin zit.  

{{% /alert %}}

## **Gebruik de StretchOff‑eigenschap**

Door de eigenschappen [StretchOffsetLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) en [StretchOffsetBottom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPictureFillFormat)‑interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPictureFillFormat)‑klasse te gebruiken, kunt u een vulrechthoek opgeven.  

Wanneer rekken wordt gespecificeerd voor een afbeelding, wordt een bronrechthoek geschaald om te passen in de opgegeven vulrechthoek. Elke rand van de vulrechthoek wordt gedefinieerd door een procentuele offset ten opzichte van de corresponderende rand van de begrenzingskader van de vorm. Een positief percentage geeft een insnijding aan, een negatief percentage een uitsteeksel.  

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een rechthoek `AutoShape` toe.  
4. Maak een afbeelding.  
5. Stel het vultype van de vorm in.  
6. Stel de afbeeldingsvulmodus van de vorm in.  
7. Voeg een afbeelding toe om de vorm te vullen.  
8. Geef de afbeeldingsoffsets op ten opzichte van de overeenkomstige rand van de begrenzingskader van de vorm.  
9. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.  

Deze Java‑code demonstreert een proces waarbij een StretchOff‑eigenschap wordt gebruikt:

```java
// Instantieert de Presentation-klasse die een PPTX-bestand representeert
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

    // Voegt een AutoShape toe ingesteld op Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Stelt het vultype van de vorm in
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Stelt de afbeeldingvulmodus van de vorm in
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Stelt de afbeelding in om de vorm te vullen
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Specificeert de afbeeldingoffsets ten opzichte van de overeenkomstige rand van de begrenzingskader van de vorm
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

Aspose.Slides ondersteunt zowel rasterafbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vectorafbeeldingen (bijvoorbeeld SVG) via het afbeeldingobject dat is toegewezen aan een [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/). De lijst van ondersteunde formaten overlapt over het algemeen met de mogelijkheden van de dia‑ en afbeeldingconversie‑engine.

**Hoe beïnvloeden tientallen grote afbeeldingen de PPTX‑grootte en prestaties?**

Het insluiten van grote afbeeldingen vergroot de bestandsgrootte en het geheugenverbruik; het linken van afbeeldingen helpt de presentatiemaat klein te houden, maar vereist wel dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via een koppeling toe te voegen om de bestandsgrootte te verkleinen.

**Hoe kan ik een afbeelding vergrendelen tegen per ongeluk verplaatsen/schalen?**

Gebruik [shape locks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) voor een [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/) (bijvoorbeeld verplaatsen of schalen uitschakelen). Het vergrendelingsmechanisme wordt ondersteund voor verschillende vormtypen, inclusief [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/).

**Wordt de vectorgetrouwheid van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?**

Aspose.Slides maakt het mogelijk een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe/) te extraheren als de oorspronkelijke vector. Bij het [exporteren naar PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/) of [rasterformaten](/slides/nl/androidjava/convert-powerpoint-to-png/) kan het resultaat gerasterd worden afhankelijk van de exportinstellingen; het feit dat de oorspronkelijke SVG als vector is opgeslagen, wordt bevestigd door het extractiegedrag.