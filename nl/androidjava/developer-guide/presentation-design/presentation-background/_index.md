---
title: Beheer presentatie‑achtergronden op Android
linktitle: Dia‑achtergrond
type: docs
weight: 20
url: /nl/androidjava/presentation-background/
keywords:
- presentatie‑achtergrond
- dia‑achtergrond
- effen kleur
- kleurverloop
- afbeeldingsachtergrond
- achtergrondtransparantie
- achtergrond‑eigenschappen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u dynamische achtergronden in PowerPoint- en OpenDocument‑bestanden kunt instellen met Aspose.Slides voor Android via Java, met code‑tips om uw presentaties te verbeteren."
---
## **Introductie**

Effen kleuren, kleurverlopen en afbeeldingen worden vaak gebruikt voor dia‑achtergronden. U kunt de achtergrond instellen voor een **normale dia** (een enkele dia) of een **master‑dia** (geldt voor meerdere dia's tegelijk).

![PowerPoint-achtergrond](powerpoint-background.png)

## **Stel een effen kleurachtergrond in voor een normale dia**

Aspose.Slides maakt het mogelijk om een effen kleur als achtergrond in te stellen voor een specifieke dia in een presentatie — zelfs als de presentatie een master‑dia gebruikt. De wijziging geldt alleen voor de geselecteerde dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de dia‑achtergrond [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Solid`.
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/) om de effen achtergrondkleur op te geven.
5. Sla de gewijzigde presentatie op.

De volgende Java‑voorbeeld laat zien hoe u een blauwe effen kleur als achtergrond voor een normale dia instelt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een instantie van de Presentation‑klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Stel de achtergrondkleur van de dia in op blauw.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Sla de presentatie op naar schijf.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel een effen kleurachtergrond in voor een master‑dia**

Aspose.Slides maakt het mogelijk om een effen kleur als achtergrond in te stellen voor de master‑dia in een presentatie. De master‑dia fungeert als een sjabloon dat de opmaak voor alle dia's regelt, dus wanneer u een effen kleur kiest voor de achtergrond van de master‑dia, wordt deze op elke dia toegepast.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/backgroundtype/) van de master‑dia in (via `getMasters`) op `OwnBackground`.
3. Stel de master‑dia‑achtergrond [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Solid`.
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--)‑methode om de effen achtergrondkleur op te geven.
5. Sla de gewijzigde presentatie op.

De volgende Java‑voorbeeld laat zien hoe u een effen kleur (groen) als achtergrond voor een master‑dia instelt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Stel de achtergrondkleur voor de master-dia in op groen.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Sla de presentatie op naar schijf.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel een kleurverloop‑achtergrond in voor een dia**

Een kleurverloop is een grafisch effect dat wordt gecreëerd door een geleidelijke kleurverandering. Wanneer het wordt gebruikt als dia‑achtergrond, kunnen kleurverlopen presentaties er meer artistiek en professioneel laten uitzien. Aspose.Slides maakt het mogelijk om een kleurverloop als achtergrond voor dia's in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de dia‑achtergrond [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Gradient`.
4. Gebruik de [getGradientFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/#getGradientFormat--)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/) om uw gewenste kleurverloopinstellingen te configureren.
5. Sla de gewijzigde presentatie op.

De volgende Java‑voorbeeld laat zien hoe u een kleurverloop als achtergrond voor een dia instelt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Pas een kleurverloop‑effect toe op de achtergrond.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Voeg de kleurverloopkleuren toe. Zonder gradient stops valt de achtergrond terug op een standaard zwart‑naar‑wit verloop.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Sla de presentatie op naar schijf.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel een afbeelding in als dia‑achtergrond**

Naast effen en kleurverloopvullingen maakt Aspose.Slides het mogelijk om afbeeldingen als dia‑achtergronden te gebruiken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de dia‑achtergrond [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Picture`.
4. Laad de afbeelding die u als dia‑achtergrond wilt gebruiken.
5. Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
6. Gebruik de [getPictureFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/) om de afbeelding als achtergrond toe te wijzen.
7. Sla de gewijzigde presentatie op.

De volgende Java‑voorbeeld laat zien hoe u een afbeelding als achtergrond voor een dia instelt:

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
    
    // Sla de presentatie op naar schijf.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De volgende code‑voorbeeld laat zien hoe u het achtergrond‑vultype instelt op een getegelde afbeelding en de tegel‑eigenschappen aanpast:

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

    // Stel de afbeeldingvulmodus in op Tile en pas de tegel‑eigenschappen aan.
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

Read more: [**Afbeelding betegelen als textuur**](/slides/nl/androidjava/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **De transparantie van de achtergrondafbeelding wijzigen**

U wilt misschien de transparantie van de achtergrondafbeelding van een dia aanpassen zodat de inhoud van de dia beter opvalt. De volgende Java‑code laat zien hoe u de transparantie van een dia‑achtergrondafbeelding wijzigt:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Bijvoorbeeld.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Haal de verzameling van picture‑transform‑operaties op.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Zoek een bestaand transparantie‑effect met vaste percentage.
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

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **De achtergrondwaarde van de dia ophalen**

Aspose.Slides biedt de [IBackgroundEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibackgroundeffectivedata/) interface om de effectieve achtergrondwaarden van een dia op te halen. Deze interface geeft toegang tot de effectieve [FillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) en [EffectFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Met de `getBackground`‑methode van de [BaseSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslide/)‑klasse kunt u de effectieve achtergrond van een dia verkrijgen.

De volgende Java‑voorbeeld laat zien hoe u de effectieve achtergrondwaarde van een dia ophaalt:

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Haal de effectieve achtergrond op, rekening houdend met master, layout en thema.
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

### Kan ik een aangepaste achtergrond resetten en het thema‑/lay‑out‑achtergrond herstellen?

Ja. Verwijder de aangepaste vulling van de dia, en de achtergrond wordt opnieuw geërfd van de bijbehorende [layout](/slides/nl/androidjava/slide-layout/)/[master](/slides/nl/androidjava/slide-master/) dia (dus van de [theme background](/slides/nl/androidjava/presentation-theme/)).

### Wat gebeurt er met de achtergrond als ik later het thema van de presentatie wijzig?

Als een dia zijn eigen vulling heeft, blijft deze onveranderd. Als de achtergrond wordt geërfd van de [layout](/slides/nl/androidjava/slide-layout/)/[master](/slides/nl/androidjava/slide-master/), wordt deze bijgewerkt om overeen te komen met het [new theme](/slides/nl/androidjava/presentation-theme/).