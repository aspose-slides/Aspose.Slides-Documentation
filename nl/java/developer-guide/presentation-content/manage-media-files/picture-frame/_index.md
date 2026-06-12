---
title: Beheer afbeeldingsframes in presentaties met Java
linktitle: Afbeeldingsframe
type: docs
weight: 10
url: /nl/java/picture-frame/
keywords:
- afbeeldingsframe
- afbeeldingsframe toevoegen
- afbeeldingsframe maken
- afbeelding toevoegen
- afbeelding maken
- afbeelding extraheren
- rasterafbeelding
- vectorafbeelding
- afbeelding bijsnijden
- bijgesneden gebied
- StretchOff-eigenschap
- opmaak van afbeeldingsframe
- eigenschappen van afbeeldingsframe
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- afbeeldingstransparantie
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Voeg afbeeldingsframes toe aan PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Java. Versnel uw workflow en verbeter het ontwerp van dia’s."
---
## **Introduction**

Een afbeeldingframe is een vorm die een afbeelding bevat – het is als een foto in een lijst. 

U kunt een afbeelding aan een dia toevoegen via een afbeeldingframe. Op deze manier kunt u de afbeelding opmaken door het afbeeldingframe op te maken.

{{% alert  title="Tip" color="primary" %}} 

Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die het mogelijk maken om snel presentaties te maken vanuit afbeeldingen. 

{{% /alert %}} 

## **Maak een afbeeldingframe**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) aan.
2. Haal een referentie naar een dia op via de index. 
3. Maak een [IPPImage]()‑object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImageCollection) die is gekoppeld aan het presentat​​ie‑object en die zal worden gebruikt om de vorm te vullen.
4. Geef de breedte en hoogte van de afbeelding op.
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PictureFrame) op basis van de breedte en hoogte van de afbeelding via de methode `AddPictureFrame` die wordt aangeboden door het vorm‑object gekoppeld aan de genoemde dia.
6. Voeg een afbeeldingframe (met de afbeelding) toe aan de dia.
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe u een afbeeldingframe maakt:

```java
// Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieert de Image‑klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Voeg een afbeeldingsframe toe met de overeenkomstige hoogte en breedte van de afbeelding
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Schrijf het PPTX‑bestand naar schijf
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Afbeeldingsframes stellen u in staat om snel presentatiedia's te maken op basis van afbeeldingen. Wanneer u een afbeeldingframe combineert met de opslaan‑opties van Aspose.Slides, kunt u invoer/uitvoer‑bewerkingen manipuleren om afbeeldingen van het ene formaat naar het andere te converteren. U wilt misschien de volgende pagina's bekijken: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/java/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/java/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/java/conversion/jpg-to-png/), converteer [PNG naar JPG](https://products.aspose.com/slides/nl/java/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/java/conversion/png-to-svg/), converteer [SVG naar PNG](https://products.aspose.com/slides/nl/java/conversion/svg-to-png/).

{{% /alert %}}

## **Maak een afbeeldingframe met relatieve schaal**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) aan.
2. Haal een referentie naar een dia op via de index. 
3. Voeg een afbeelding toe aan de afbeeldingscollectie van de presentatie.
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPPImage)‑object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImageCollection) die is gekoppeld aan het presentat​​ie‑object en die zal worden gebruikt om de vorm te vullen.
5. Geef de relatieve breedte en hoogte van de afbeelding op in het afbeeldingframe.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe u een afbeeldingframe maakt met relatieve schaal:

```java
// Instantieer de Presentation‑klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieer de Image‑klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Voeg een afbeeldingframe toe met dezelfde hoogte en breedte als de afbeelding
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Stel de relatieve schaal van breedte en hoogte in
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Schrijf het PPTX‑bestand naar schijf
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rasterafbeeldingen uit afbeeldingframes extraheren**

U kunt rasterafbeeldingen uit [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/PictureFrame)‑objecten extraheren en opslaan in PNG, JPG en andere formaten. Het code‑voorbeeld hieronder toont hoe u een afbeelding uit het document "sample.pptx" haalt en opslaat in PNG‑formaat.

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

## **SVG-afbeeldingen uit afbeeldingframes extraheren**

Wanneer een presentatie SVG‑grafieken bevat die zijn geplaatst binnen [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/)‑vormen, maakt Aspose.Slides voor Java het mogelijk om de originele vectorafbeeldingen met volledige getrouwheid op te halen. Door de vormcollectie van de dia te doorlopen, kunt u elk [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) identificeren, controleren of de onderliggende [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) SVG‑inhoud bevat, en vervolgens die afbeelding opslaan op schijf of in een stream in het oorspronkelijke SVG‑formaat.

Het volgende code‑voorbeeld laat zien hoe u een SVG‑afbeelding uit een afbeeldingframe haalt:

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

Aspose.Slides stelt u in staat om het transparantie‑effect op een afbeelding op te halen. Deze Java‑code demonstreert de bewerking:

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

## **Opmaak van afbeeldingframes**

Aspose.Slides biedt veel opmaakopties die op een afbeeldingframe kunnen worden toegepast. Met die opties kunt u een afbeeldingframe aanpassen zodat het aan specifieke eisen voldoet.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) aan.
2. Haal een referentie naar een dia op via de index. 
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPPImage)‑object aan door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImageCollection) die is gekoppeld aan het presentat​​ie‑object en die zal worden gebruikt om de vorm te vullen.
4. Geef de breedte en hoogte van de afbeelding op.
5. Maak een `PictureFrame` op basis van de breedte en hoogte van de afbeelding via de [AddPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)‑methode die wordt aangeboden door het [IShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection)‑object gekoppeld aan de genoemde dia.
6. Voeg het afbeeldingframe (met de afbeelding) toe aan de dia.
7. Stel de lijnkleur van het afbeeldingframe in.
8. Stel de lijndikte van het afbeeldingframe in.
9. Roteer het afbeeldingframe door een positieve of negatieve waarde op te geven. 
   * Een positieve waarde roteert de afbeelding met de klok mee. 
   * Een negatieve waarde roteert de afbeelding tegen de klok in.
10. Voeg het afbeeldingframe (met de afbeelding) toe aan de dia.
11. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code demonstreert het opmaakproces van een afbeeldingframe:

```java
// Instantieert de Presentation‑klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantieert de Image‑klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Voegt een afbeeldingframe toe met dezelfde hoogte en breedte als de afbeelding
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Past enkele opmaak toe op PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Schrijft het PPTX‑bestand naar schijf
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Aspose heeft recent een [gratis Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als u ooit [JPG/JPEG](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑afbeeldingen wilt samenvoegen, of [roosters van foto’s](https://products.aspose.app/slides/nl/collage/photo-grid) wilt maken, kunt u deze service gebruiken. 

{{% /alert %}}

## **Een afbeelding als koppeling toevoegen**

Om grote presentaties te vermijden, kunt u afbeeldingen (of video's) via koppelingen toevoegen in plaats van de bestanden direct in de presentatie in te sluiten. Deze Java‑code laat zien hoe u een afbeelding en video in een placeholder toevoegt:

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

Deze Java‑code laat zien hoe u een bestaande afbeelding op een dia bijsnijdt:

```java
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

    // Voegt een PictureFrame toe aan een dia
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

## **Bijsnijde gebieden van een afbeelding verwijderen**

Als u de bijgesneden gebieden van een afbeelding in een frame wilt verwijderen, kunt u de methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) gebruiken. Deze methode retourneert de bijgesneden afbeelding of de originele afbeelding als bijsnijden niet nodig is.

Deze Java‑code demonstreert de bewerking:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Haalt het PictureFrame van de eerste dia op
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

De methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) voegt de bijgesneden afbeelding toe aan de afbeeldingscollectie van de presentatie. Als de afbeelding alleen wordt gebruikt in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/), kan deze configuratie de presentatiegrootte verkleinen. Anders zal het aantal afbeeldingen in de resulterende presentatie toenemen.

Deze methode converteert WMF/EMF‑metabestanden naar raster‑PNG‑afbeeldingen tijdens de bijsnijdingsbewerking. 

{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met behulp van de methode [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . Deze methode comprimeert een afbeelding door de grootte te verkleinen op basis van de vormgrootte en de opgegeven resolutie, met de mogelijkheid om bijgesneden gebieden te verwijderen.

Het past de grootte en resolutie van de afbeelding aan, vergelijkbaar met de PowerPoint‑functie **Afbeeldingsopmaak → Afbeeldingen comprimeren → Resolutie**.

De volgende Java‑voorbeelden laten zien hoe u een afbeelding in een presentatie comprimeert door een doelresolutie op te geven en eventueel bijgesneden gebieden te verwijderen:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Compress de afbeelding met een doelresolutie van 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
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

    // Compress de afbeelding naar 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

De methode converteert de afbeelding naar een lagere resolutie op basis van de vormgrootte en de opgegeven DPI. Bijgesneden regio's kunnen ook worden verwijderd om de bestandsgrootte te optimaliseren.  
Als de afbeelding een metafile (WMF/EMF) of SVG is, wordt compressie niet toegepast. Ook wordt de JPEG‑kwaliteit behouden of licht verminderd op basis van de resolutie, vergelijkbaar met hoe PowerPoint omgaat met hoge‑resolutie JPEG‑s.

{{% /alert %}}

## **Verhoudingen vergrendelen**

Als u wilt dat een vorm met een afbeelding zijn beeldverhouding behoudt, zelfs nadat u de afbeeldingsafmetingen wijzigt, kunt u de methode [setAspectRatioLocked](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) gebruiken om de instelling *Verhoudingen vergrendelen* in te stellen. 

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

{{% alert title="NOTE" color="warning" %}} 

Deze instelling *Verhoudingen vergrendelen* behoudt alleen de beeldverhouding van de vorm, niet die van de afbeelding die erin zit.

{{% /alert %}}

## **Gebruik de StretchOff‑eigenschap**

Door de eigenschappen [StretchOffsetLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) en [StretchOffsetBottom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) van de interface [IPictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat) en de klasse [PictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPictureFillFormat) te gebruiken, kunt u een vulrechthoek opgeven. 

Wanneer rekken is gespecificeerd voor een afbeelding, wordt een bronrechthoek geschaald om in de opgegeven vulrechthoek te passen. Elke rand van de vulrechthoek wordt gedefinieerd door een procentuele offset ten opzichte van de overeenkomstige rand van de begrenzings‑box van de vorm. Een positief percentage geeft een inset aan, een negatief percentage een outset.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse.
2. Haal een referentie naar een dia op via de index.
3. Voeg een rechthoek `AutoShape` toe.
4. Maak een afbeelding.
5. Stel het vultype van de vorm in.
6. Stel de beeldvulgmodus van de vorm in.
7. Voeg een afbeelding toe om de vorm te vullen.
8. Geef afbeelding‑offsets op ten opzichte van de overeenkomstige rand van de begrenzings‑box van de vorm.
9. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code demonstreert een proces waarbij een StretchOff‑eigenschap wordt gebruikt:

```java
// Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide slide = pres.getSlides().get_Item(0);

    // Instantieert de ImageEx‑klasse
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt een AutoShape toe van type Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Stelt het vultype van de vorm in
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Stelt de afbeeldingvulmodus van de vorm in
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Stelt de afbeelding in om de vorm te vullen
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Specificeert de afbeelding‑offsets ten opzichte van de overeenkomstige rand van de begrenzings‑box van de vorm
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //Schrijft het PPTX‑bestand naar schijf
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Veelgestelde vragen**

**Hoe kan ik achterhalen welke afbeeldingsformaten worden ondersteund voor PictureFrame?**

Aspose.Slides ondersteunt zowel rasterafbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vectorafbeeldingen (bijvoorbeeld SVG) via het afbeeldingsobject dat aan een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) is toegewezen. De lijst met ondersteunde formaten overlapt over het algemeen met de mogelijkheden van de dia‑ en afbeeldingconversie‑engine.

**Hoe beïnvloeden tientallen grote afbeeldingen de grootte en prestaties van een PPTX?**

Het insluiten van grote afbeeldingen vergroot de bestandsgrootte en het geheugenverbruik; afbeeldingen koppelen helpt de presentatiegrootte te beperken, maar vereist wel dat de externe bestanden beschikbaar blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via een koppeling toe te voegen om de bestandsgrootte te verkleinen.

**Hoe kan ik een afbeeldingsobject vergrendelen tegen per ongeluk verplaatsen/vergroten?**

Gebruik [vormvergrendelingen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) voor een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) (bijvoorbeeld verplaatsing of wijziging uitschakelen). Het vergrendelingsmechanisme wordt beschreven voor vormen in een apart [beschermingsartikel](/slides/nl/java/applying-protection-to-presentation/) en wordt ondersteund voor verschillende vormtypen, inclusief [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/).

**Wordt de vectorfideliteit van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?**

Aspose.Slides maakt het mogelijk om een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe/) te extraheren als de originele vector. Bij het [exporteren naar PDF](/slides/nl/java/convert-powerpoint-to-pdf/) of [rasterformaten](/slides/nl/java/convert-powerpoint-to-png/) kan het resultaat gerasterd worden afhankelijk van de exportinstellingen; het feit dat de originele SVG als vector is opgeslagen, wordt bevestigd door het extractiegedrag.