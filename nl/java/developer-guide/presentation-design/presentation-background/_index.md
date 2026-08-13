---
title: Beheer presentatie-achtergronden in Java
linktitle: Dia-achtergrond
type: docs
weight: 20
url: /nl/java/presentation-background/
keywords:
- presentatie-achtergrond
- dia-achtergrond
- effen kleur
- verloopkleur
- afbeeldingsachtergrond
- achtergrondtransparantie
- achtergrond-eigenschappen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u dynamische achtergronden kunt instellen in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor Java, met code-tips om uw presentaties te verbeteren."
---
## **Inleiding**

Effen kleuren, verlopen en afbeeldingen worden vaak gebruikt voor dia‑achtergronden. Je kunt de achtergrond instellen voor een **normale dia** (één enkele dia) of een **master‑dia** (geldt voor meerdere dia's tegelijk).

![PowerPoint-achtergrond](powerpoint-background.png)

## **Stel een effen kleur in als achtergrond voor een normale dia**

Aspose.Slides stelt je in staat om een effen kleur als achtergrond in te stellen voor een specifieke dia in een presentatie—ook al gebruikt de presentatie een master‑dia. De wijziging is alleen van toepassing op de geselecteerde dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de dia‑achtergrond in op `Solid`.
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/#getSolidFillColor--)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/) om de effen achtergrondkleur op te geven.
5. Sla de aangepaste presentatie op.

Het volgende Java‑voorbeeld laat zien hoe je een blauwe effen kleur als achtergrond voor een normale dia instelt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Stel de achtergrondkleur van de dia in op blauw.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Sla de presentatie op schijf.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel een effen kleur in als achtergrond voor een master‑dia**

Aspose.Slides stelt je in staat om een effen kleur als achtergrond in te stellen voor de master‑dia in een presentatie. De master‑dia fungeert als een sjabloon die de opmaak voor alle dia's bepaalt, zodat een gekozen effen kleur voor de achtergrond van de master‑dia geldt voor elke dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/backgroundtype/) van de master‑dia (via `getMasters`) in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de master‑dia‑achtergrond in op `Solid`.
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/#getSolidFillColor--)‑methode om de effen achtergrondkleur op te geven.
5. Sla de aangepaste presentatie op.

Het volgende Java‑voorbeeld laat zien hoe je een effen kleur (groen) als achtergrond voor een master‑dia instelt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Stel de achtergrondkleur van de master‑dia in op groen.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Sla de presentatie op schijf.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel een verloop‑achtergrond in voor een dia**

Een verloop is een grafisch effect dat ontstaat door een geleidelijke kleursverandering. Wanneer het wordt gebruikt als dia‑achtergrond, kunnen verlopen presentaties een meer artistieke en professionele uitstraling geven. Aspose.Slides stelt je in staat om een verloopkleur als achtergrond voor dia's in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de dia‑achtergrond in op `Gradient`.
4. Gebruik de [getGradientFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/#getGradientFormat--)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/) om de gewenste verloopinstellingen te configureren.
5. Sla de aangepaste presentatie op.

Het volgende Java‑voorbeeld laat zien hoe je een verloopkleur als achtergrond voor een dia instelt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Pas een verloop-effect toe op de achtergrond.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Voeg de verloopkleuren toe. Zonder verloopstops valt de achtergrond terug op een standaard zwart-naar-wit bereik.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Sla de presentatie op schijf.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel een afbeelding in als dia‑achtergrond**

Naast effen en verloopvullingen stelt Aspose.Slides je in staat om afbeeldingen te gebruiken als dia‑achtergronden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de dia‑achtergrond in op `Picture`.
4. Laad de afbeelding die je wilt gebruiken als dia‑achtergrond.
5. Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
6. Gebruik de [getPictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/#getPictureFillFormat--)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/) om de afbeelding als achtergrond toe te wijzen.
7. Sla de aangepaste presentatie op.

Het volgende Java‑voorbeeld laat zien hoe je een afbeelding als achtergrond voor een dia instelt:

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Stel eigenschappen van de achtergrondafbeelding in.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Laad de afbeelding.
    IImage image = Images.fromFile("Tulips.jpg");
    // Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Sla de presentatie op schijf.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De volgende code‑voorbeeld laat zien hoe je het vultype van de achtergrond instelt op een getegelde afbeelding en de tegel‑eigenschappen aanpast:

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

    // Stel de afbeelding in die wordt gebruikt voor de achtergrondvulling.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Stel de beeldvullingsmodus in op Tegel en pas de tegel‑eigenschappen aan.
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

Lees meer: [**Tile Picture As Texture**](/slides/nl/java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Verander de transparantie van de achtergrondafbeelding**

Je wilt misschien de transparantie van de achtergrondafbeelding van een dia aanpassen zodat de inhoud van de dia meer opvalt. De volgende Java‑code laat zien hoe je de transparantie van een achtergrondafbeelding van een dia wijzigt:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Bijvoorbeeld.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Haal de collectie van afbeeldingstransformatie‑operaties op.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Zoek een bestaand vast‑percentage transparantie‑effect.
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // Stel de nieuwe transparantiewaarde in.
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

## **Haalt de achtergrondwaarde van de dia op**

Aspose.Slides levert de [IBackgroundEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibackgroundeffectivedata/)‑interface voor het ophalen van de effectieve achtergrondwaarden van een dia. Deze interface stelt de effectieve [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) en [EffectFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) bloot.

Met de `getBackground`‑methode van de [BaseSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseslide/)‑klasse kun je de effectieve achtergrond van een dia verkrijgen.

Het volgende Java‑voorbeeld laat zien hoe je de effectieve achtergrondwaarde van een dia ophaalt:

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Haal de effectieve achtergrond op, rekening houdend met master, lay-out en thema.
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

### Kan ik een aangepaste achtergrond resetten en de thema-/lay‑out‑achtergrond herstellen?

Ja. Verwijder de aangepaste vulling van de dia, en de achtergrond wordt opnieuw overgeërfd van de bijbehorende [layout](/slides/nl/java/slide-layout/)/[master](/slides/nl/java/slide-master/) dia (d.w.z. de [themabackground](/slides/nl/java/presentation-theme/)).

### Wat gebeurt er met de achtergrond als ik later het thema van de presentatie wijzig?

Als een dia zijn eigen vulling heeft, blijft deze ongewijzigd. Als de achtergrond is geërfd van de [layout](/slides/nl/java/slide-layout/)/[master](/slides/nl/java/slide-master/), wordt deze bijgewerkt om overeen te komen met het [nieuwe thema](/slides/nl/java/presentation-theme/).