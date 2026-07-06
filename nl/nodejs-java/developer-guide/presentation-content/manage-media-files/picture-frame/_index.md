---
title: Beheer afbeeldingskaders in presentaties met JavaScript
linktitle: Afbeeldingskader
type: docs
weight: 10
url: /nl/nodejs-java/picture-frame/
keywords:
- afbeeldingskader
- afbeeldingskader toevoegen
- afbeeldingskader aanmaken
- afbeelding toevoegen
- afbeelding aanmaken
- afbeelding extraheren
- rasterafbeelding
- vectorafbeelding
- afbeelding bijsnijden
- bijgesneden gebied
- StretchOff eigenschap
- opmaak van afbeeldingskader
- eigenschappen van afbeeldingskader
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
description: "Voeg afbeeldingskaders toe aan PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js via Java. Versnel uw workflow en verbeter het ontwerp van dia's."
---
## **Inleiding**

Een afbeeldingskader is een vorm die een afbeelding bevat — het is als een foto in een lijst. 

U kunt een afbeelding aan een dia toevoegen via een afbeeldingskader. Op deze manier kunt u de afbeelding opmaken door het afbeeldingskader op te maken.

{{% alert  title="Tip" color="primary" %}} 

Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die gebruikers in staat stellen snel presentaties te maken vanuit afbeeldingen. 

{{% /alert %}} 

## **Afbeeldingskader maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een dia op via de index.  
3. Maak een `PPImage`-object aan door een afbeelding toe te voegen aan de [ImagesCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ImageCollection) die bij het presentatiewerkobject hoort en die wordt gebruikt om de vorm te vullen.  
4. Geef de breedte en hoogte van de afbeelding op.  
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFrame) aan op basis van de breedte en hoogte van de afbeelding via de `addPictureFrame`-methode die beschikbaar is op het vormobject dat gekoppeld is aan de betreffende dia.  
6. Voeg een afbeeldingskader (met de afbeelding) toe aan de dia.  
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

Deze JavaScript‑code laat zien hoe u een afbeeldingskader maakt:

```javascript
// Instantiëert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Instantiëert de Image‑klasse
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Voegt een afbeeldingskader toe met de overeenkomstige hoogte en breedte van de afbeelding
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Schrijft het PPTX‑bestand naar schijf
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Afbeeldingskaders stellen u in staat snel presentatiedia's te maken op basis van afbeeldingen. Wanneer u een afbeeldingskader combineert met de opslagopties van Aspose.Slides, kunt u invoer‑/uitvoerbewerkingen manipuleren om afbeeldingen van het ene formaat naar het andere te converteren.

## **Afbeeldingskader maken met relatieve schaal**

Door de relatieve schaal van een afbeelding te wijzigen, kunt u een complexer afbeeldingskader maken. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een afbeelding toe aan de afbeeldingsverzameling van de presentatie.  
4. Maak een `PPImage`-object aan door een afbeelding toe te voegen aan de [ImagesCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ImageCollection) die bij het presentatiewerkobject hoort en die wordt gebruikt om de vorm te vullen.  
5. Geef de relatieve breedte en hoogte van de afbeelding op in het afbeeldingskader.  
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

De volgende JavaScript‑code toont hoe u een afbeeldingskader met relatieve schaal kunt maken:

```javascript
// Instantieer de Presentation‑klasse die de PPTX vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Instantieer de Image‑klasse
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Voeg een Picture Frame toe met dezelfde hoogte en breedte als de afbeelding
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Instellen van relatieve schaalbreedte en -hoogte
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Schrijf het PPTX‑bestand naar schijf
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rasterafbeeldingen extraheren uit afbeeldingskaders**

U kunt rasterafbeeldingen extraheren uit [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFrame)‑objecten en deze opslaan in PNG, JPG en andere formaten. Het code‑voorbeeld hieronder laat zien hoe u een afbeelding uit het document "sample.pptx" haalt en opslaat in PNG‑formaat.

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

## **SVG‑afbeeldingen extraheren uit afbeeldingskaders**

Wanneer een presentatie SVG‑grafieken bevat die geplaatst zijn binnen [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/)‑vormen, stelt Aspose.Slides voor Node.js via Java u in staat de originele vectorafbeeldingen met volledige getrouwheid op te halen. Door de vormcollectie van de dia te doorlopen, kunt u elk [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) identificeren, controleren of de onderliggende [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) SVG‑inhoud bevat, en vervolgens die afbeelding opslaan op schijf of in een stream in het oorspronkelijke SVG‑formaat.

Het volgende code‑voorbeeld toont hoe u een SVG‑afbeelding uit een afbeeldingskader kunt extraheren:

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

Aspose.Slides stelt u in staat het transparantie‑effect dat op een afbeelding is toegepast op te halen. Deze JavaScript‑code toont de bewerking:

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

## **Helderheid en contrast van een afbeelding ophalen**

Aspose.Slides stelt u in staat het helderheids‑ en contrast‑effect dat op een afbeelding is toegepast op te halen. De [Luminance](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/luminance/)‑klasse vertegenwoordigt dit afbeeldings‑transformatieteffect.

Deze JavaScript‑code toont hoe u de helderheids‑ en contrastinstellingen van een afbeeldingskader kunt ophalen:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Opmaak van afbeeldingskader**

Aspose.Slides biedt vele opmaakopties die op een afbeeldingskader toegepast kunnen worden. Met deze opties kunt u een afbeeldingskader aanpassen zodat het aan specifieke vereisten voldoet.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een dia op via de index.  
3. Maak een `PPImage`-object aan door een afbeelding toe te voegen aan de [ImagesCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ImageCollection) die bij het presentatiewerkobject hoort en die wordt gebruikt om de vorm te vullen.  
4. Geef de breedte en hoogte van de afbeelding op.  
5. Maak een `PictureFrame` aan op basis van de breedte en hoogte van de afbeelding via de [addPictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-)‑methode die beschikbaar is op het [Shapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection)‑object dat gekoppeld is aan de betreffende dia.  
6. Voeg het afbeeldingskader (met de afbeelding) toe aan de dia.  
7. Stel de lijnkleur van het afbeeldingskader in.  
8. Stel de lijndikte van het afbeeldingskader in.  
9. Roteer het afbeeldingskader door het een positieve of negatieve waarde te geven.  
   * Een positieve waarde roteert de afbeelding met de klok mee.  
   * Een negatieve waarde roteert de afbeelding tegen de klok in.  
10. Voeg het afbeeldingskader (met de afbeelding) toe aan de dia.  
11. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

Deze JavaScript‑code toont het opmaakproces van een afbeeldingskader:

```javascript
// Instantiëert de Presentation‑klasse die de PPTX vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Instantiëert de Image‑klasse
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Voegt een Picture Frame toe met dezelfde hoogte en breedte als de afbeelding
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Past enige opmaak toe op PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Schrijft het PPTX‑bestand naar schijf
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose heeft recentelijk een [gratis Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als u ooit [JPG/JPEG samenvoegen](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑afbeeldingen, [roosters uit foto’s maken](https://products.aspose.app/slides/nl/collage/photo-grid) wilt, kunt u deze service gebruiken. 

{{% /alert %}}

## **Afbeelding als koppeling toevoegen**

Om grote presentaties te voorkomen, kunt u afbeeldingen (of video’s) via koppelingen toevoegen in plaats van de bestanden direct in de presentatie in te sluiten. Deze JavaScript‑code toont hoe u een afbeelding en video in een placeholder kunt toevoegen:

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

Deze JavaScript‑code toont hoe u een bestaande afbeelding op een dia kunt bijsnijden:

```javascript
var pres = new aspose.slides.Presentation();
// Creëert een nieuw afbeeldingobject
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
    // Bijsnijdt de afbeelding (percentage waarden)
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

## **Bijsneden delen van afbeelding verwijderen**

Als u de bijgesneden delen van een afbeelding in een kader wilt verwijderen, kunt u de [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--)‑methode gebruiken. Deze methode levert de bijgesneden afbeelding terug, of de oorspronkelijke afbeelding als bijsnijden niet nodig is.

Deze JavaScript‑code toont de bewerking:

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

De [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--)‑methode voegt de bijgesneden afbeelding toe aan de afbeeldingsverzameling van de presentatie. Als de afbeelding alleen wordt gebruikt in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/), kan deze instelling de grootte van de presentatie verkleinen. Anders zal het aantal afbeeldingen in de resulterende presentatie toenemen.

Deze methode converteert WMF/EMF‑metabestanden naar raster‑PNG‑afbeeldingen tijdens de bijsnijd‑bewerking. 

{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met behulp van de [PictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-)‑methode. Deze methode comprimeert een afbeelding door de grootte te verkleinen op basis van de vormgrootte en opgegeven resolutie, met de optie om bijgesneden delen te verwijderen.

Hij past de grootte en resolutie van de afbeelding aan, vergelijkbaar met de functie **Picture Format → Compress Pictures → Resolution** van PowerPoint.

De volgende JavaScript‑voorbeelden demonstreren hoe u een afbeelding in een presentatie kunt comprimeren door een doelresolutie op te geven en eventueel bijgesneden delen te verwijderen:

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

    // Comprimeer de afbeelding tot 96 DPI (e-mailresolutie) en verwijder bijgesneden gebieden.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="OPMERKING" color="warning" %}} 

De methode converteert de afbeelding naar een lagere resolutie op basis van de vormgrootte en opgegeven DPI. Bijgesneden gebieden kunnen ook verwijderd worden om de bestandsgrootte te optimaliseren.  
Als de afbeelding een metabestand (WMF/EMF) of SVG is, wordt compressie niet toegepast. Ook wordt de JPEG‑kwaliteit behouden of licht verminderd afhankelijk van de resolutie, vergelijkbaar met hoe PowerPoint omgaat met hoog‑resolutie JPEG‑bestanden. 

{{% /alert %}}

## **Beeldverhouding vergrendelen**

Als u wilt dat een vorm die een afbeelding bevat zijn beeldverhouding behoudt, zelfs nadat u de afmetingen van de afbeelding wijzigt, kunt u de [setAspectRatioLocked](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-)‑methode gebruiken om de instelling *Lock Aspect Ratio* in te schakelen.

Deze JavaScript‑code laat zien hoe u de beeldverhouding van een vorm vergrendelt:

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
    // stel de vorm in om de beeldverhouding te behouden bij het wijzigen van de grootte
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="OPMERKING" color="warning" %}} 

Deze *Lock Aspect Ratio*‑instelling behoudt alleen de beeldverhouding van de vorm en niet van de afbeelding die erin zit. 

{{% /alert %}}

## **StretchOff‑eigenschap gebruiken**

Met de [setStretchOffsetLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) en [setStretchOffsetBottom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-)‑methoden van de [PictureFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PictureFillFormat)‑klasse kunt u een vulrechthoek specificeren.

Wanneer stretching voor een afbeelding wordt opgegeven, wordt een bronrechthoek geschaald zodat deze past in de opgegeven vulrechthoek. Elke kant van de vulrechthoek wordt gedefinieerd door een procentuele offset ten opzichte van de overeenkomstige kant van de begrenzende doos van de vorm. Een positieve procentuele waarde geeft een insnijding aan, een negatieve waarde een uitsteeking.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een rechthoek `AutoShape` toe.  
4. Maak een afbeelding aan.  
5. Stel het opvultype van de vorm in.  
6. Stel de picture‑fill‑modus van de vorm in.  
7. Voeg een afbeelding toe om de vorm te vullen.  
8. Geef de afbeeldingsoffsets op ten opzichte van de overeenkomstige rand van de omhullende van de vorm.  
9. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

Deze JavaScript‑code toont een proces waarbij de StretchOff‑eigenschap wordt gebruikt:

```javascript
// Instantiëert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia op
    var slide = pres.getSlides().get_Item(0);
    // Instantiëert de ImageEx‑klasse
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Voegt een AutoShape toe met type Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Stelt het vultype van de vorm in
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Stelt de picture‑fill‑modus van de vorm in
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Stelt de afbeelding in als vulling van de vorm
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Specificeert de afbeeldingsoffsets ten opzichte van de overeenkomstige rand van de begrenzende doos van de vorm
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Schrijft het PPTX‑bestand naar schijf
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Hoe kan ik achterhalen welke afbeeldingformaten ondersteund worden voor PictureFrame?**

Aspose.Slides ondersteunt zowel rasterafbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vectorafbeeldingen (bijvoorbeeld SVG) via het afbeeldingobject dat aan een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) is toegewezen. De lijst met ondersteunde formaten overlapt doorgaans met de mogelijkheden van de dia- en afbeeldingsconversie‑engine.

**Hoe beïnvloedt het toevoegen van tientallen grote afbeeldingen de grootte en prestaties van een PPTX?**

Het insluiten van grote afbeeldingen vergroot de bestandsgrootte en het geheugenverbruik; het koppelen van afbeeldingen houdt de presentatiegrootte laag, maar vereist dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via koppeling toe te voegen om de bestandsgrootte te reduceren.

**Hoe kan ik een afbeelding‑object vergrendelen tegen per ongeluk verplaatsen/verkleinen?**

Gebruik [shape locks](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) voor een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) (bijvoorbeeld om verplaatsen of verkleinen uit te schakelen). Het vergrendelingsmechanisme wordt ondersteund voor diverse vormtypen, waaronder [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/).

**Wordt de vectorgetrouwheid van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?**

Aspose.Slides maakt het mogelijk een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) te extraheren als de originele vector. Bij het [exporteren naar PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/) of naar [rasterformaten](/slides/nl/nodejs-java/convert-powerpoint-to-png/) kan het resultaat rasteren, afhankelijk van de exportinstellingen; het feit dat de originele SVG als vector wordt bewaard, wordt bevestigd door het extractie‑gedrag.