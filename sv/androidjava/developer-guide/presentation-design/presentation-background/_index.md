---
title: Hantera presentationsbakgrunder på Android
linktitle: Bildbakgrund
type: docs
weight: 20
url: /sv/androidjava/presentation-background/
keywords:
- presentationsbakgrund
- bildbakgrund
- enhetlig färg
- gradientfärg
- bildbakgrund
- bakgrundstransparens
- bakgrundsegenskaper
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du ställer in dynamiska bakgrunder i PowerPoint- och OpenDocument-filer med Aspose.Slides för Android via Java, med kodtips för att förbättra dina presentationer."
---
## **Introduktion**

Solida färger, gradienter och bilder används vanligtvis för bildbakgrunder. Du kan ställa in bakgrunden för en **normal bild** (en enda bild) eller en **masterbild** (gäller för flera bilder samtidigt).

![PowerPoint-bakgrund](powerpoint-background.png)

## **Ställ in en solid färg som bakgrund för en normal bild**

Aspose.Slides låter dig ställa in en solid färg som bakgrund för en specifik bild i en presentation — även om presentationen använder en masterbild. Ändringen gäller endast den valda bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/filltype/) till `Solid`.
4. Använd metoden [getSolidFillColor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) på [FillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fillformat/) för att ange den solida bakgrundsfärgen.
5. Spara den ändrade presentationen.

Följande Java‑exempel visar hur du ställer in en blå solid färg som bakgrund för en normal bild:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Skapa en instans av Presentation-klassen.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ställ in bakgrundsfärgen för bilden till blå.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Spara presentationen till disk.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in en solid färg som bakgrund för en masterbild**

Aspose.Slides låter dig ställa in en solid färg som bakgrund för masterbilden i en presentation. Masterbilden fungerar som en mall som styr formatering för alla bilder, så när du väljer en solid färg för masterbildens bakgrund gäller den för varje bild.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Ställ in masterbildens [BackgroundType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/backgroundtype/) (via `getMasters`) till `OwnBackground`.
3. Ställ in masterbildens bakgrund [FillType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/filltype/) till `Solid`.
4. Använd metoden [getSolidFillColor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) för att ange den solida bakgrundsfärgen.
5. Spara den ändrade presentationen.

Följande Java‑exempel visar hur du ställer in en solid färg (grön) som bakgrund för en masterbild:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Skapa en instans av Presentation-klassen.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Ställ in bakgrundsfärgen för masterbilden till grön.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Spara presentationen till disk.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in en gradientbakgrund för en bild**

En gradient är en grafisk effekt som skapas genom en gradvis färgförändring. När den används som bildbakgrund kan gradienter göra presentationer mer konstnärliga och professionella. Aspose.Slides låter dig ställa in en gradientfärg som bakgrund för bilder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/filltype/) till `Gradient`.
4. Använd metoden [getGradientFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) på [FillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fillformat/) för att konfigurera dina önskade gradientinställningar.
5. Spara den ändrade presentationen.

Följande Java‑exempel visar hur du ställer in en gradientfärg som bakgrund för en bild:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Skapa en instans av Presentation-klassen.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Tillämpa en gradienteffekt på bakgrunden.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Lägg till gradientfärgerna. Utan gradientstopp återgår bakgrunden till en standard svart-till-vit ramp.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Spara presentationen till disk.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in en bild som bakgrund för en bild**

Förutom solida och gradientfyllningar låter Aspose.Slides dig använda bilder som bildbakgrunder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/filltype/) till `Picture`.
4. Läs in den bild du vill använda som bildbakgrund.
5. Lägg till bilden i presentationens bildsamling.
6. Använd metoden [getPictureFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) på [FillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fillformat/) för att tilldela bilden som bakgrund.
7. Spara den ändrade presentationen.

Följande Java‑exempel visar hur du ställer in en bild som bakgrund för en bild:

```java
import com.aspose.slides.*;

// Skapa en instans av Presentation-klassen.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ställ in bakgrundsbildens egenskaper.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Läs in bilden.
    IImage image = Images.fromFile("Tulips.jpg");
    // Lägg till bilden i presentationens bildsamling.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Spara presentationen till disk.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Följande kodexempel visar hur du ställer in bakgrundsfylltypen till en mosaikbild och ändrar mosaikegenskaperna:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Ställ in bilden som används för bakgrundsfyllningen.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Ställ in bildfyllningsläget till Tile och justera tile egenskaperna.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
Läs mer: [**Tile Picture As Texture**](/slides/sv/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Ändra bakgrundsbildens transparens**

Du kanske vill justera transparensen för en bilds bakgrundsbild för att låta bildens innehåll framträda. Följande Java‑kod visar hur du ändrar transparensen för en bildbakgrundsbild:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Till exempel.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hämta samlingen av bildtransformationsoperationer.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Hitta en befintlig fast procents transparenseffekt.
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // Ställ in det nya transparensvärdet.
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hämta bildens bakgrundsvärde**

Aspose.Slides tillhandahåller gränssnittet [IBackgroundEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibackgroundeffectivedata/) för att hämta en bilds faktiska bakgrundsvärden. Detta gränssnitt visar den faktiska [FillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) och [EffectFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Genom att använda metoden `getBackground` i klassen [BaseSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseslide/) kan du få den faktiska bakgrunden för en bild.

Följande Java‑exempel visar hur du hämtar en bilds faktiska bakgrundsvärde:

```java
import com.aspose.slides.*;

// Skapa en instans av Presentation-klassen.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hämta den effektiva bakgrunden, med hänsyn till master, layout och tema.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Kan jag återställa en anpassad bakgrund och återfå temats/layoutbakgrund?

Ja. Ta bort bildens anpassade fyllning, så ärver bakgrunden igen från motsvarande [layout](/slides/sv/androidjava/slide-layout/)/[master](/slides/sv/androidjava/slide-master/) bild (dvs. [temats bakgrund](/slides/sv/androidjava/presentation-theme/)).

### Vad händer med bakgrunden om jag ändrar presentationens tema senare?

Om en bild har sin egen fyllning förblir den oförändrad. Om bakgrunden ärvs från [layout](/slides/sv/androidjava/slide-layout/)/[master](/slides/sv/androidjava/slide-master/) uppdateras den för att matcha det [nya temat](/slides/sv/androidjava/presentation-theme/).