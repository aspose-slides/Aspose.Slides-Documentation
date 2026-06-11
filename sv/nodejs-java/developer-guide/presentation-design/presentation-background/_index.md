---
title: Hantera bakgrunder för presentationer i JavaScript
linktitle: Bildbakgrund
type: docs
weight: 20
url: /sv/nodejs-java/presentation-background/
keywords:
- presentationsbakgrund
- bildbakgrund
- enfärgad färg
- gradientfärg
- bildbakgrund
- bakgrundstransparens
- bakgrundsegenskaper
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du ställer in dynamiska bakgrunder i PowerPoint- och OpenDocument-filer med Aspose.Slides för Node.js, med kodtips för att förbättra dina presentationer."
---
## **Introduktion**

Solida färger, gradienter och bilder används ofta som bakgrunder för bilder. Du kan ställa in bakgrunden för en **normal bild** (en enskild bild) eller en **masterbild** (gäller flera bilder samtidigt).

![PowerPoint background](powerpoint-background.png)

## **Ange en solid färgbakgrund för en normal bild**

Aspose.Slides låter dig ställa in en solid färg som bakgrund för en specifik bild i en presentation—även om presentationen använder en masterbild. Ändringen gäller endast den valda bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filltype/) till `Solid`.
4. Använd metoden [getSolidFillColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) på [FillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/) för att ange den solida bakgrundsfärgen.
5. Spara den ändrade presentationen.

Följande JavaScript‑exempel visar hur du anger en blå solid färg som bakgrund för en normal bild:

```js
// Skapa en instans av Presentation-klassen.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Ställ in bildens bakgrundsfärg till blå.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Spara presentationen till disk.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ange en solid färgbakgrund för masterbilden**

Aspose.Slides låter dig ställa in en solid färg som bakgrund för masterbilden i en presentation. Masterbilden fungerar som en mall som styr formatering för alla bilder, så när du väljer en solid färg för masterbildens bakgrund gäller den för varje bild.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Ställ in masterbildens [BackgroundType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/backgroundtype/) (via `getMasters`) till `OwnBackground`.
3. Ställ in masterbildens bakgrunds [FillType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filltype/) till `Solid`.
4. Använd metoden [getSolidFillColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) för att ange den solida bakgrundsfärgen.
5. Spara den ändrade presentationen.

Följande JavaScript‑exempel visar hur du anger en solid färg (grön) som bakgrund för en masterbild:

```js
// Skapa en instans av Presentation-klassen.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Ställ in bakgrundsfärgen för masterbilden till skoggrön.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Spara presentationen till disk.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ange en gradientbakgrund för en bild**

En gradient är en grafisk effekt som skapas genom en gradvis färgändring. När den används som bildbakgrund kan gradienter få presentationer att se mer konstnärliga och professionella ut. Aspose.Slides låter dig ställa in en gradientfärg som bakgrund för bilder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filltype/) till `Gradient`.
4. Använd metoden [getGradientFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/#getGradientFormat) på [FillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/) för att konfigurera dina önskade gradientinställningar.
5. Spara den ändrade presentationen.

Följande JavaScript‑exempel visar hur du anger en gradientfärg som bakgrund för en bild:

```js
// Skapa en instans av Presentation-klassen.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Applicera en gradienteffekt på bakgrunden.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Spara presentationen till disk.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ange en bild som bakgrund för en bild**

Förutom solida och gradientfyllningar låter Aspose.Slides dig använda bilder som bakgrund för bilder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filltype/) till `Picture`.
4. Ladda bilden du vill använda som bildbakgrund.
5. Lägg till bilden i presentationens bildsamling.
6. Använd metoden [getPictureFillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) på [FillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/) för att tilldela bilden som bakgrund.
7. Spara den ändrade presentationen.

Följande JavaScript‑exempel visar hur du anger en bild som bakgrund för en bild:

```js
// Skapa en instans av Presentation-klassen.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Ställ in bakgrundsbildens egenskaper.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Ladda bilden.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Lägg till bilden i presentationens bildsamling.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Spara presentationen till disk.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Följande kodexempel visar hur du ställer in bakgrundsfyllningstypen till en kaklad bild och ändrar kakelinställningarna:

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Ange bilden som används för bakgrundsfyllning.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Ställ in bildfyllningsläget till Kakla och justera kakelinställningarna.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

Läs mer: [**Kaklad bild som textur**](/slides/sv/nodejs-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Ändra bakgrundsbildens transparens**

Du kanske vill justera transparensen för en bilds bakgrundsbild för att låta bildens innehåll framträda tydligare. Följande JavaScript‑kod visar hur du ändrar transparensen för en bildbakgrund:

```js
var transparencyValue = 30; // Till exempel.

// Hämta samlingen av bildtransformationsoperationer.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Hitta en befintlig fast-procent transparenseffekt.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Ställ in det nya transparensvärdet.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Hämta bildens bakgrundsvärde**

Aspose.Slides tillhandahåller klassen `BackgroundEffectiveData` för att hämta en bilds faktiska bakgrundsvärden. Denna klass exponerar den faktiska [FillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/) och [EffectFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effectformat/).

Genom att använda `getBackground`‑metoden på klassen [BaseSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/) kan du erhålla den faktiska bakgrunden för en bild.

Följande JavaScript‑exempel visar hur du får en bilds faktiska bakgrundsvärde:

```js
// Skapa en instans av Presentation-klassen.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Hämta den effektiva bakgrunden, med hänsyn till master, layout och tema.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan jag återställa en anpassad bakgrund och återfå tema‑/layoutbakgrunden?**

Ja. Ta bort bildens anpassade fyllning så ärver bakgrunden igen från motsvarande [layout](/slides/sv/nodejs-java/slide-layout/)/[master](/slides/sv/nodejs-java/slide-master/) (dvs. [tema‑bakgrunden](/slides/sv/nodejs-java/presentation-theme/)).

**Vad händer med bakgrunden om jag senare ändrar presentationens tema?**

Om en bild har sin egen fyllning förblir den oförändrad. Om bakgrunden ärvs från [layout](/slides/sv/nodejs-java/slide-layout/)/[master](/slides/sv/nodejs-java/slide-master/) uppdateras den för att matcha det [nya temat](/slides/sv/nodejs-java/presentation-theme/).