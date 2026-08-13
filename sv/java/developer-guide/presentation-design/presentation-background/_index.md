---
title: Hantera presentationsbakgrunder i Java
linktitle: Bildbakgrund
type: docs
weight: 20
url: /sv/java/presentation-background/
keywords:
- presentationsbakgrund
- bildbakgrund
- solid färg
- gradientfärg
- bildbakgrund
- bakgrundstransparens
- bakgrundsegenskaper
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du ställer in dynamiska bakgrunder i PowerPoint- och OpenDocument-filer med Aspose.Slides för Java, med kodtips för att förbättra dina presentationer."
---
## **Introduktion**

Solida färger, gradienter och bilder används ofta som bakgrund för bilder. Du kan ställa in bakgrunden för en **normal bild** (en enskild bild) eller en **masterbild** (gäller flera bilder samtidigt).

![PowerPoint‑bakgrund](powerpoint-background.png)

## **Ställ in en solid färg som bakgrund för en normal bild**

Aspose.Slides låter dig ange en solid färg som bakgrund för en specifik bild i en presentation — även om presentationen använder en masterbild. Ändringen gäller endast den valda bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildens bakgrunds [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Solid`.
4. Använd metoden [getSolidFillColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fillformat/#getSolidFillColor--) på [FillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fillformat/) för att ange den solida bakgrundsfärgen.
5. Spara den ändrade presentationen.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Skapa en instans av Presentation-klassen.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ställ in bildens bakgrundsfärg till blå.
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

Aspose.Slides låter dig ange en solid färg som bakgrund för masterbilden i en presentation. Masterbilden fungerar som en mall som styr formatering för alla bilder, så när du väljer en solid färg för masterbildens bakgrund gäller den för varje bild.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Ställ in masterbildens [BackgroundType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/backgroundtype/) (via `getMasters`) till `OwnBackground`.
3. Ställ in masterbildens bakgrunds [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Solid`.
4. Använd metoden [getSolidFillColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fillformat/#getSolidFillColor--) för att ange den solida bakgrundsfärgen.
5. Spara den ändrade presentationen.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Skapa en instans av Presentation-klassen.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Ställ in bakgrundsfärgen för masterbilden till grönt.
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

En gradient är en grafisk effekt som skapas genom en gradvis färgförändring. När den används som bildbakgrund kan gradienter göra presentationer mer konstnärliga och professionella. Aspose.Slides låter dig ange en gradientfärg som bakgrund för bilder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildens bakgrunds [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Gradient`.
4. Använd metoden [getGradientFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fillformat/#getGradientFormat--) på [FillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fillformat/) för att konfigurera dina önskade gradientinställningar.
5. Spara den ändrade presentationen.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Skapa en instans av Presentation-klassen.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Applicera en gradienteffekt på bakgrunden.
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

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/backgroundtype/) till `OwnBackground`.
3. Ställ in bildens bakgrunds [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Picture`.
4. Läs in bilden du vill använda som bildbakgrund.
5. Lägg till bilden i presentationens bildsamling.
6. Använd metoden [getPictureFillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fillformat/#getPictureFillFormat--) på [FillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fillformat/) för att tilldela bilden som bakgrund.
7. Spara den ändrade presentationen.

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

    // Ställ in bildfyllningsläget till Kakel och justera kakelinställningarna.
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
Läs mer: [**Kakelbild som textur**](/slides/sv/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Ändra bakgrundsbildens transparens**

Du kanske vill justera transparensen för en bilds bakgrundsbild för att få bildens innehåll att framträda tydligare. Följande Java‑kod visar hur du ändrar transparensen för en bildbakgrundsbild:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Till exempel.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hämta samlingen av bildtransformeringsoperationer.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Hitta en befintlig fast-procentuell transparenseffekt.
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

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hämta bildens bakgrundsvärde**

Aspose.Slides tillhandahåller gränssnittet [IBackgroundEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibackgroundeffectivedata/) för att hämta en bilds effektiva bakgrundsvärden. Detta gränssnitt exponerar den effektiva [FillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) och [EffectFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Genom att använda metoden `getBackground` i klassen [BaseSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseslide/) kan du hämta den effektiva bakgrunden för en bild.

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

## **Vanliga frågor**

### Kan jag återställa en anpassad bakgrund och återgå till tema-/layoutbakgrunden?

Ja. Ta bort bildens anpassade fyllning så ärver bakgrunden återigen från motsvarande [layout](/slides/sv/java/slide-layout/)/[master](/slides/sv/java/slide-master/) bild (dvs. [tema‑bakgrunden](/slides/sv/java/presentation-theme/)).

### Vad händer med bakgrunden om jag ändrar presentationens tema senare?

Om en bild har sin egen fyllning förblir den oförändrad. Om bakgrunden ärvs från [layout](/slides/sv/java/slide-layout/)/[master](/slides/sv/java/slide-master/), uppdateras den för att matcha det [nya temat](/slides/sv/java/presentation-theme/).