---
title: Beheer afbeeldingsframes in presentaties met JavaScript
linktitle: Afbeeldingsframe
type: docs
weight: 10
url: /nl/nodejs-java/picture-frame/
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
- opmaak van afbeeldingframe
- eigenschappen van afbeeldingframe
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- afbeeldingstransparantie
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Voeg afbeeldingsframes toe aan PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js via Java. Vereenvoudig uw workflow en verbeter het ontwerp van dia's."
---
## **Inleiding**

Een afbeeldingkader is een vorm die een afbeelding bevat – het is als een foto in een lijst. 

U kunt een afbeelding aan een dia toevoegen via een afbeeldingkader. Op deze manier kunt u de afbeelding opmaken door het afbeeldingkader te formatteren.

{{% alert  title="Tip" color="primary" %}} 

Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die mensen in staat stellen snel presentaties te maken van afbeeldingen. 

{{% /alert %}} 

## **Afbeeldingframe maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
2. Haal een referentie naar een dia op via de index. 
3. Maak een `PPImage`-object aan door een afbeelding toe te voegen aan de [ImagesCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ImageCollection) die aan het presentatie‑object is gekoppeld en die zal worden gebruikt om de vorm te vullen.
4. Geef de breedte en hoogte van de afbeelding op.
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFrame) op basis van de breedte en hoogte van de afbeelding via de `addPictureFrame`‑methode van het vormobject dat aan de betreffende dia is gekoppeld.
6. Voeg een afbeeldingframe (met de afbeelding) toe aan de dia.
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```javascript
// Initialiseert de Presentation-klasse die een PPTX‑bestand voorstelt
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Initialiseert de Image‑klasse
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Voegt een afbeeldingsframe toe met de overeenkomstige hoogte en breedte van de afbeelding
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Schrijf het PPTX‑bestand naar schijf
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Afbeeldingsframes stellen u in staat om snel presentatiedia's op basis van afbeeldingen te maken. Wanneer u een afbeeldingsframe combineert met de opslaande opties van Aspose.Slides, kunt u in‑ en uitvoerbewerkingen manipuleren om afbeeldingen van het ene formaat naar het andere te converteren.

## **Afbeeldingframe maken met relatieve schaal**

Door de relatieve schaal van een afbeelding aan te passen, kunt u een complexer afbeeldingframe maken. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
2. Haal een referentie naar een dia op via de index. 
3. Voeg een afbeelding toe aan de afbeeldingscollectie van de presentatie.
4. Maak een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PPImage) object aan door een afbeelding toe te voegen aan de [ImagesCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ImageCollection) die aan het presentatie‑object is gekoppeld en die zal worden gebruikt om de vorm te vullen.
5. Geef de relatieve breedte en hoogte van de afbeelding op in het afbeeldingframe.
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```javascript
// Instantieer de Presentation-klasse die de PPTX voorstelt
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Instantieer de Image-klasse
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Voeg een afbeeldingframe toe met dezelfde hoogte en breedte als de afbeelding
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Instellen van relatieve schaalhoogte en -breedte
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Schrijf het PPTX-bestand naar schijf
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rasterafbeeldingen extraheren uit afbeeldingframes**

U kunt rasterafbeeldingen extraheren uit [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFrame) objecten en deze opslaan als PNG, JPG en andere formaten. Het code‑voorbeeld hieronder toont hoe u een afbeelding uit het document “sample.pptx” kunt extraheren en opslaan in PNG‑formaat.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **SVG‑afbeeldingen extraheren uit afbeeldingframes**

Wanneer een presentatie SVG‑grafieken bevat die in [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/)‑vormen zijn geplaatst, maakt Aspose.Slides voor Node.js via Java het mogelijk om de oorspronkelijke vectorafbeeldingen met volledige getrouwheid op te halen. Door de vormcollectie van de dia te doorlopen, kunt u elk [PictureFrame] identificeren, controleren of de onderliggende [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) SVG‑inhoud bevat, en vervolgens die afbeelding opslaan op schijf of in een stream in het oorspronkelijke SVG‑formaat.

Het volgende code‑voorbeeld toont hoe u een SVG‑afbeelding uit een afbeeldingframe kunt extraheren:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **Transparantie van afbeelding ophalen**

Aspose.Slides stelt u in staat de transparantie‑effect die op een afbeelding is toegepast op te halen. Deze JavaScript‑code demonstreert de bewerking:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **Opmaak van afbeeldingframe**

Aspose.Slides biedt tal van opmaakopties die op een afbeeldingframe kunnen worden toegepast. Met deze opties kunt u een afbeeldingframe aanpassen zodat het aan specifieke eisen voldoet.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
2. Haal een referentie naar een dia op via de index. 
3. Maak een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PPImage) object aan door een afbeelding toe te voegen aan de [ImagesCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ImageCollection) die aan het presentatie‑object is gekoppeld en die zal worden gebruikt om de vorm te vullen.
4. Geef de breedte en hoogte van de afbeelding op.
5. Maak een `PictureFrame` op basis van de breedte en hoogte van de afbeelding via de [addPictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-)‑methode van het [Shapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection) object dat aan de betreffende dia is gekoppeld.
6. Voeg het afbeeldingframe (met de afbeelding) toe aan de dia.
7. Stel de lijnkleur van het afbeeldingframe in.
8. Stel de lijndikte van het afbeeldingframe in.
9. Roteer het afbeeldingframe door een positieve of negatieve waarde op te geven.
   * Een positieve waarde roteert de afbeelding met de klok mee. 
   * Een negatieve waarde roteert de afbeelding tegen de klok in.
10. Voeg het afbeeldingframe (met de afbeelding) toe aan de dia.
11. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```javascript
// Initialiseert de Presentation-klasse die de PPTX voorstelt
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Initialiseert de Image-klasse
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Voegt een afbeeldingframe toe met dezelfde hoogte en breedte als de afbeelding
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Past wat opmaak toe op PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Schrijft het PPTX-bestand naar schijf
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose heeft recentelijk een [gratis Collage‑Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als u ooit [JPG/JPEG](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑afbeeldingen wilt samenvoegen, of [roosters van foto's](https://products.aspose.app/slides/nl/collage/photo-grid) wilt maken, kunt u deze dienst gebruiken. 

{{% /alert %}}

## **Afbeelding toevoegen als koppeling**

Om de grootte van een presentatie te beperken, kunt u afbeeldingen (of video's) via koppelingen toevoegen in plaats van de bestanden direct in de presentatie in te sluiten. Deze JavaScript‑code toont hoe u een afbeelding en video in een placeholder kunt toevoegen:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Afbeelding bijsnijden**

Deze JavaScript‑code laat zien hoe u een bestaande afbeelding op een dia kunt bijsnijden:

```javascript
var pres = new aspose.slides.Presentation();
// Maakt een nieuw afbeeldingsobject
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Voegt een PictureFrame toe aan een dia
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Bijsnijdt de afbeelding (percentagewaarden)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Slaat het resultaat op
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bijsneden gebieden van afbeelding verwijderen**

Als u de bijgesneden gebieden van een afbeelding in een frame wilt verwijderen, kunt u de [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--)‑methode gebruiken. Deze methode retourneert de bijgesneden afbeelding of de originele afbeelding als bijsnijden niet nodig is.

Deze JavaScript‑code demonstreert de bewerking:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Haalt het PictureFrame op van de eerste dia
    var picFrame = slide.getShapes().get_Item(0);
    // Verwijdert bijgesneden gebieden van de PictureFrame-afbeelding en retourneert de bijgesneden afbeelding
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Slaat het resultaat op
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="OPMERKING" color="warning" %}} 

De [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--)‑methode voegt de bijgesneden afbeelding toe aan de afbeeldingscollectie van de presentatie. Als de afbeelding alleen in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) wordt gebruikt, kan deze instelling de grootte van de presentatie verkleinen. Anders neemt het aantal afbeeldingen in de resulterende presentatie toe.

Deze methode converteert WMF/EMF‑metabestanden naar raster‑PNG‑afbeeldingen tijdens de bijsnijdbewerking. 

{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met behulp van de [PictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-)‑methode. Deze methode comprimeert een afbeelding door de grootte te verkleinen op basis van de vormgrootte en de opgegeven resolutie, met de optie om bijgesneden gebieden te verwijderen.

Het past de grootte en resolutie van de afbeelding aan, vergelijkbaar met de PowerPoint‑functie **Afbeeldingsindeling → Afbeeldingen comprimeren → Resolutie**.

De volgende JavaScript‑voorbeelden tonen hoe u een afbeelding in een presentatie kunt comprimeren door een doelresolutie op te geven en eventueel bijgesneden gebieden te verwijderen:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Comprimeer de afbeelding met een doelresolutie van 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Controleer het resultaat van de compressie.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Of door een andere vooraf gedefinieerde DPI‑waarde te gebruiken:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Comprimeer de afbeelding tot 96 DPI (e‑mailresolutie), en verwijder bijgesneden gebieden.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="OPMERKING" color="warning" %}} 

De methode converteert de afbeelding naar een lagere resolutie op basis van de vormgrootte en de opgegeven DPI. Bijgesneden gebieden kunnen ook worden verwijderd om de bestandsgrootte te optimaliseren. Als de afbeelding een metabestand (WMF/EMF) of SVG is, wordt compressie niet toegepast. Bovendien wordt de JPEG‑kwaliteit behouden of licht verminderd afhankelijk van de resolutie, vergelijkbaar met hoe PowerPoint omgaat met JPEG‑afbeeldingen met hoge resolutie.

{{% /alert %}}

## **Beeldverhouding vergrendelen**

Als u wilt dat een vorm met een afbeelding de beeldverhouding behoudt, zelfs nadat u de afmetingen van de afbeelding wijzigt, kunt u de [setAspectRatioLocked](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-)‑methode gebruiken om de *Beeldverhouding vergrendelen* instelling in te schakelen.

Deze JavaScript‑code laat zien hoe u de beeldverhouding van een vorm kunt vergrendelen:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // stel de vorm in zodat de beeldverhouding behouden blijft bij het schalen
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="OPMERKING" color="warning" %}} 

Deze *Beeldverhouding vergrendelen* instelling behoudt alleen de beeldverhouding van de vorm en niet die van de afbeelding die erin zit.

{{% /alert %}}

## **StretchOff‑eigenschap gebruiken**

Door de methoden [setStretchOffsetLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) en [setStretchOffsetBottom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) van de [PictureFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFillFormat)‑klasse te gebruiken, kunt u een vulrechthoek opgeven.

Wanneer uitrekken voor een afbeelding is gespecificeerd, wordt een bronrechthoek geschaald zodat deze in de opgegeven vulrechthoek past. Elke rand van de vulrechthoek wordt gedefinieerd door een percentage‑offset ten opzichte van de overeenkomstige rand van de begrenzende box van de vorm. Een positief percentage geeft een insetting aan, terwijl een negatief percentage een outsetting aangeeft.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
2. Haal een referentie naar een dia op via de index.
3. Voeg een rechthoek `AutoShape` toe. 
4. Maak een afbeelding. 
5. Stel het opvultype van de vorm in. 
6. Stel de afbeeldingsvulmodus van de vorm in. 
7. Voeg een afbeelding toe om de vorm te vullen. 
8. Geef afbeeldingsoffsets op ten opzichte van de overeenkomstige rand van de begrenzende box van de vorm.
9. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze JavaScript‑code demonstreert een proces waarbij een StretchOff‑eigenschap wordt gebruikt:

```javascript
// Instantieert de Presentation-klasse die een PPTX-bestand voorstelt
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia op
    var slide = pres.getSlides().get_Item(0);
    // Instantieert de ImageEx-klasse
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Voegt een AutoShape toe ingesteld op Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Stelt het vultype van de vorm in
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Stelt de picture fill-modus van de vorm in
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Stelt de afbeelding in om de vorm te vullen
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Specificeert de afbeeldingsoffsets ten opzichte van de overeenkomstige rand van de begrenzingsbox van de vorm
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Schrijft het PPTX-bestand naar schijf
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Hoe kan ik achterhalen welke afbeeldingsformaten worden ondersteund voor PictureFrame?**

Aspose.Slides ondersteunt zowel rasterafbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vectorafbeeldingen (bijvoorbeeld SVG) via het afbeeldingsobject dat aan een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) is toegewezen. De lijst met ondersteunde formaten overlapt doorgaans met de mogelijkheden van de slide‑ en afbeeldingsconversie‑engine.

**Hoe zal het toevoegen van tientallen grote afbeeldingen de grootte en prestaties van een PPTX beïnvloeden?**

Het invoegen van grote afbeeldingen vergroot de bestandsgrootte en het geheugenverbruik; het koppelen van afbeeldingen helpt de presentatiegrootte te beperken, maar vereist wel dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via een koppeling toe te voegen om de bestandsgrootte te verkleinen.

**Hoe kan ik een afbeeldingsobject vergrendelen tegen per ongeluk verplaatsen/verschalen?**

Gebruik [shape locks](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) voor een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) (bijvoorbeeld om verplaatsen of schalen uit te schakelen). Het vergrendelingsmechanisme wordt ondersteund voor diverse vormtypen, inclusief [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/).

**Wordt de vectorfideliteit van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?**

Aspose.Slides maakt het mogelijk een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) te extraheren als de oorspronkelijke vector. Bij het [exporteren naar PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/) of naar [rasterformaten](/slides/nl/nodejs-java/convert-powerpoint-to-png/) kan het resultaat gerasterd worden, afhankelijk van de exportinstellingen; het feit dat de oorspronkelijke SVG als vector is opgeslagen, wordt bevestigd door het extractie‑gedrag.