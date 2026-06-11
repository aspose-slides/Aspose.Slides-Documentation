---
title: Hantera bildramar i presentationer med JavaScript
linktitle: Bildram
type: docs
weight: 10
url: /sv/nodejs-java/picture-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lägg till bildramar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java. Effektivisera ditt arbetsflöde och förbättra bilddesignen."
---
## **Introduktion**

En bildram är en form som innehåller en bild - den är som en bild i en ram.

Du kan lägga till en bild på en bildspelsida via en bildram. På så sätt kan du formatera bilden genom att formatera bildramen.

{{% alert  title="Tip" color="primary" %}} 

Aspose tillhandahåller gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter användare skapa presentationer snabbt från bilder. 

{{% /alert %}} 

## **Skapa bildram**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en bildspelsidas referens via dess index. 
3. Skapa ett `PPImage`-objekt genom att lägga till en bild i [ImagesCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ImageCollection) som är kopplad till presentationsobjektet och som kommer att användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa en [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PictureFrame) baserad på bildens bredd och höjd via `addPictureFrame`-metoden som exponeras av formobjektet som är associerat med den refererade bilden.
6. Lägg till en bildram (som innehåller bilden) på bilden.
7. Skriv den modifierade presentationen som en PPTX-fil.

Den här JavaScript-koden visar hur du skapar en bildram:

```javascript
// Skapar en instans av Presentation-klassen som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Skapar en instans av Image-klassen
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Lägger till en bildram med bildens motsvarande höjd och bredd
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Skriver PPTX-filen till disk
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Bildramar låter dig snabbt skapa presentationsbilder baserade på bilder. När du kombinerar bildram med sparalternativen i Aspose.Slides kan du manipulera in-/utdataoperationer för att konvertera bilder från ett format till ett annat.

## **Skapa bildram med relativ skalning**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en bildspelsidas referens via dess index. 
3. Lägg till en bild i presentationens bildsamling.
4. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PPImage) objekt genom att lägga till en bild i [ImagesCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ImageCollection) som är kopplad till presentationsobjektet och som kommer att användas för att fylla formen.
5. Ange bildens relativa bredd och höjd i bildramen.
6. Skriv den modifierade presentationen som en PPTX-fil.

Den här JavaScript-koden visar hur du skapar en bildram med relativ skalning:

```javascript
// Instansiera Presentation-klassen som representerar PPTX-filen
var pres = new aspose.slides.Presentation();
try {
    // Hämta den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Instansiera Image-klassen
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Lägg till en bildram med bildens ekvivalenta höjd och bredd
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Ställer in relativ skala för bredd och höjd
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Skriv PPTX-filen till disk
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Extrahera rasterbilder från bildramar**

Du kan extrahera rasterbilder från [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PictureFrame)-objekt och spara dem i PNG, JPG och andra format. Kodexemplet nedan visar hur du extraherar en bild från dokumentet "sample.pptx" och sparar den i PNG-format.

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

## **Extrahera SVG‑bilder från bildramar**

När en presentation innehåller SVG‑grafik placerad i [PictureFrame]‑former låter Aspose.Slides för Node.js via Java dig hämta de ursprungliga vektorbilderna med fullständig trohet. Genom att gå igenom bildens formsamling kan du identifiera varje [PictureFrame], kontrollera om den underliggande [PPImage] innehåller SVG‑innehåll och sedan spara den bilden till disk eller en ström i dess ursprungliga SVG‑format.

Kodexemplet nedan demonstrerar hur du extraherar en SVG‑bild från en bildram:

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

## **Hämta transparens för bild**

Aspose.Slides låter dig hämta transparenseffekten som har tillämpats på en bild. Den här JavaScript-koden demonstrerar operationen:

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

## **Formatering av bildram**

Aspose.Slides erbjuder många formateringsalternativ som kan tillämpas på en bildram. Med hjälp av dessa alternativ kan du ändra en bildram så att den uppfyller specifika krav.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en bildspelsidas referens via dess index. 
3. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PPImage) objekt genom att lägga till en bild i [ImagesCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ImageCollection) som är kopplad till presentationsobjektet och som kommer att användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa en `PictureFrame` baserad på bildens bredd och höjd via [addPictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-)‑metoden som exponeras av [Shapes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection)-objektet som är kopplat till den refererade bilden.
6. Lägg till bildramen (som innehåller bilden) på bilden.
7. Ställ in bildramens linjefärg.
8. Ställ in bildramens linjebredd.
9. Rotera bildramen genom att ge den ett positivt eller negativt värde.
   * Ett positivt värde roterar bilden medurs. 
   * Ett negativt värde roterar bilden moturs.
10. Lägg till bildramen (som innehåller bilden) på bilden.
11. Skriv den modifierade presentationen som en PPTX-fil.

Den här JavaScript-koden demonstrerar processen för formatering av bildram:

```javascript
// Instansierar Presentation-klassen som representerar PPTX
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Instansierar Image-klassen
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Lägger till en bildram med bildens ekvivalenta höjd och bredd
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Tillämpar viss formatering på PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Skriver PPTX-filen till disk
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose har nyligen utvecklat en [gratis Collage Maker](https://products.aspose.app/slides/sv/collage). Om du någonsin behöver [sammanfoga JPG/JPEG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG‑bilder, [skapa rutnät från foton](https://products.aspose.app/slides/sv/collage/photo-grid), kan du använda den här tjänsten. 

{{% /alert %}}

## **Lägg till bild som länk**

För att undvika stora presentationsstorlekar kan du lägga till bilder (eller videor) via länkar istället för att bädda in filerna direkt i presentationerna. Den här JavaScript-koden visar hur du lägger till en bild och en video i en platshållare:

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

## **Beskär bild**

Den här JavaScript-koden visar hur du beskär en befintlig bild på en bildspelsida:

```javascript
var pres = new aspose.slides.Presentation();
// Skapar ett nytt bildobjekt
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
    // Lägger till en bildram på en bild
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Beskär bilden (procentvärden)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Sparar resultatet
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ta bort beskurna områden i bildram**

Om du vill ta bort de beskurna områdena av en bild som finns i en ram kan du använda metoden [deletePictureCroppedAreas()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Denna metod returnerar den beskurna bilden eller originalbilden om beskärning inte är nödvändig.

Denna JavaScript-kod demonstrerar operationen:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Hämtar bildramen från den första bilden
    var picFrame = slide.getShapes().get_Item(0);
    // Tar bort beskurna områden av bildramens bild och returnerar den beskurna bilden
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Sparar resultatet
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Metoden [deletePictureCroppedAreas()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) lägger till den beskurna bilden i presentationens bildsamling. Om bilden endast används i den bearbetade [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/), kan denna konfiguration minska presentationens storlek. Annars ökar antalet bilder i den resulterande presentationen.

Metoden konverterar WMF/EMF‑metafiler till raster‑PNG‑bild i beskärningsoperationen. 

{{% /alert %}}

## **Komprimera bilder**

Du kan komprimera en bild i en presentation med hjälp av metoden [PictureFillFormat.compressImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) .
Denna metod komprimerar en bild genom att minska dess storlek baserat på formens storlek och angiven upplösning, med möjlighet att ta bort beskurna områden.

Den justerar bildens storlek och upplösning på liknande sätt som PowerPoints **Picture Format → Compress Pictures → Resolution**‑funktion.

Följande JavaScript‑exempel visar hur du komprimerar en bild i en presentation genom att ange en målupplösning och eventuellt ta bort beskurna områden:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Komprimera bilden med en målupplösning på 150 DPI (webbupplösning) och ta bort beskurna områden.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Kontrollera resultatet av komprimeringen.
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

Eller genom att använda ett annat fördefinierat DPI‑värde:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Komprimera bilden till 96 DPI (e‑postupplösning), ta bort beskurna områden.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Metoden konverterar bilden till en lägre upplösning baserat på formens storlek och angivet DPI. Beskurna regioner kan också tas bort för att optimera filstorleken.
Om bilden är en metafil (WMF/EMF) eller SVG kommer komprimering inte att tillämpas. JPEG‑kvaliteten bevaras eller minskar något beroende på upplösning, på samma sätt som PowerPoint hanterar högupplösta JPEG‑filer.

{{% /alert %}}

## **Lås bildförhållande**

Om du vill att en form som innehåller en bild ska behålla sitt bildförhållande även efter att du ändrar bildens dimensioner kan du använda metoden [setAspectRatioLocked](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) för att ställa in *Lock Aspect Ratio*-inställningen.

Den här JavaScript‑koden visar hur du låser en formes bildförhållande:

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
    // sätt formen så att den behåller bildförhållandet vid storleksändring
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Denna *Lock Aspect Ratio*-inställning bevarar endast bildförhållandet för formen och inte bilden den innehåller.

{{% /alert %}}

## **Använd StretchOff‑egenskapen**

Genom att använda metoderna [setStretchOffsetLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) och [setStretchOffsetBottom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) från klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PictureFillFormat) kan du ange en fyllningsrektangel.

När stretchning specificeras för en bild skalas en källrektangel för att passa den angivna fyllningsrektangeln. Varje kant av fyllningsrektangeln definieras av en procentuell offset från motsvarande kant av formens omgivningsruta. En positiv procent anger ett inskjut medan en negativ procent anger ett utskjut.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en bildspelsidas referens via dess index.
3. Lägg till en rektangel `AutoShape`. 
4. Skapa en bild.
5. Ställ in formens fyllningstyp.
6. Ställ in formens bildfyllnadsläge.
7. Lägg till en bild för att fylla formen.
8. Ange bildens offset från motsvarande kant av formens omgivningsruta
9. Skriv den modifierade presentationen som en PPTX-fil.

Denna JavaScript‑kod demonstrerar en process där StretchOff‑egenskapen används:

```javascript
// Instansierar Presentation-klassen som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var slide = pres.getSlides().get_Item(0);
    // Instansierar ImageEx-klassen
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Lägger till en AutoShape inställd på rektangel
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Ställer in formens fyllningstyp
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Ställer in formens bildfyllnadsläge
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Ställer in bilden för att fylla formen
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Anger bildens offset från motsvarande kant av formens omgivningsruta
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Skriver PPTX-filen till disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Hur kan jag ta reda på vilka bildformat som stöds för PictureFrame?**

Aspose.Slides stöder både rasterbilder (PNG, JPEG, BMP, GIF osv.) och vektorbilder (t.ex. SVG) via bildobjektet som är tilldelat en [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/). Listan över stödda format överlappar generellt med funktionerna i bild‑ och konverteringsmotorn.

**Hur påverkar det att lägga till dussintals stora bilder PPTX‑storlek och prestanda?**

Inbäddning av stora bilder ökar filstorlek och minnesanvändning; länka bilder hjälper hålla presentationsstorleken nere men kräver att de externa filerna förblir åtkomliga. Aspose.Slides erbjuder möjligheten att lägga till bilder via länk för att minska filstorleken.

**Hur kan jag låsa ett bildobjekt så att det inte av misstag flyttas eller skalas?**

Använd [shape locks](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) för en [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/) (t.ex. inaktivera flyttning eller skalning). Låsningsmekanismen stöds för olika formtyper, inklusive [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/).

**Bevaras SVG‑vektorfideliteten när en presentation exporteras till PDF/bilder?**

Aspose.Slides låter dig extrahera en SVG från en [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/) som den ursprungliga vektorn. När du [exporterar till PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/) eller [rasterformat](/slides/sv/nodejs-java/convert-powerpoint-to-png/) kan resultatet rasteriseras beroende på exportinställningarna; det faktum att den ursprungliga SVG:n lagras som en vektor bekräftas av extraktionsbeteendet.