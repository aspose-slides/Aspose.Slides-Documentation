---
title: Beheer presentatie‑achtergronden in Java
linktitle: Dia‑achtergrond
type: docs
weight: 20
url: /nl/java/presentation-background/
keywords:
- presentatie‑achtergrond
- dia‑achtergrond
- effen kleur
- verloopkleur
- afbeeldingsachtergrond
- achtergrondtransparantie
- achtergrond‑eigenschappen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u dynamische achtergronden kunt instellen in PowerPoint‑ en OpenDocument‑bestanden met Aspose.Slides voor Java, met code‑tips om uw presentaties te verbeteren."
---
## **Inleiding**

Effen kleuren, verlopen en afbeeldingen worden vaak gebruikt als dia‑achtergronden. Je kunt de achtergrond instellen voor een **normale dia** (een enkele dia) of een **master‑dia** (geldt voor meerdere dia’s tegelijk).

![PowerPoint background](powerpoint-background.png)

## **Een effen kleur als achtergrond instellen voor een normale dia**

Aspose.Slides maakt het mogelijk om een effen kleur als achtergrond in te stellen voor een specifieke dia in een presentatie — zelfs als de presentatie een master‑dia gebruikt. De wijziging geldt alleen voor de geselecteerde dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de dia‑achtergrond in op `Solid`.
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/#getSolidFillColor--)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/) om de effen achtergrondkleur op te geven.
5. Sla de aangepaste presentatie op.

Het volgende Java‑voorbeeld toont hoe je een blauwe effen kleur als achtergrond voor een normale dia instelt:

```java
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

## **Een effen kleur als achtergrond instellen voor een master‑dia**

Aspose.Slides maakt het mogelijk om een effen kleur als achtergrond voor de master‑dia van een presentatie in te stellen. De master‑dia fungeert als een sjabloon dat de opmaak van alle dia’s regelt, dus wanneer je een effen kleur voor de master‑dia‑achtergrond kiest, wordt deze op elke dia toegepast.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/backgroundtype/) van de master‑dia in (via `getMasters`) op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de master‑dia‑achtergrond in op `Solid`.
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/#getSolidFillColor--)‑methode om de effen achtergrondkleur op te geven.
5. Sla de aangepaste presentatie op.

Het volgende Java‑voorbeeld toont hoe je een groene effen kleur als achtergrond voor een master‑dia instelt:

```java
// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Stel de achtergrondkleur voor de master‑dia in op bosgroen.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Sla de presentatie op schijf.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een verloop als achtergrond instellen voor een dia**

Een verloop is een grafisch effect dat ontstaat door een geleidelijke kleurschakeling. Wanneer het als dia‑achtergrond wordt gebruikt, kan een verloop een presentatie artistieker en professioneler doen ogen. Aspose.Slides maakt het mogelijk om een verloopkleur als achtergrond voor dia’s in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de dia‑achtergrond in op `Gradient`.
4. Gebruik de [getGradientFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/#getGradientFormat--)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/) om je gewenste verloopinstellingen te configureren.
5. Sla de aangepaste presentatie op.

Het volgende Java‑voorbeeld toont hoe je een verloopkleur als achtergrond voor een dia instelt:

```java
// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Pas een verloop‑effect toe op de achtergrond.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Sla de presentatie op schijf.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een afbeelding als dia‑achtergrond instellen**

Naast effen en verloopvullingen maakt Aspose.Slides het mogelijk om afbeeldingen als dia‑achtergrond te gebruiken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) van de dia‑achtergrond in op `Picture`.
4. Laad de afbeelding die je wilt gebruiken als dia‑achtergrond.
5. Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
6. Gebruik de [getPictureFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/#getPictureFillFormat--)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fillformat/) om de afbeelding als achtergrond toe te wijzen.
7. Sla de aangepaste presentatie op.

Het volgende Java‑voorbeeld toont hoe je een afbeelding als achtergrond voor een dia instelt:

```java
// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Stel de eigenschappen van de achtergrondafbeelding in.
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

Het volgende code‑voorbeeld laat zien hoe je het vultype van de achtergrond instelt op een getegelde afbeelding en de tegel‑eigenschappen wijzigt:

```java
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

{{% alert color="primary" %}}
Lees meer: [**Tile Picture As Texture**](/slides/nl/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparantie van de achtergrondafbeelding wijzigen**

Je wilt misschien de transparantie van de achtergrondafbeelding van een dia aanpassen zodat de inhoud beter opvalt. De volgende Java‑code laat zien hoe je de transparantie van een dia‑achtergrondafbeelding wijzigt:

```java
int transparencyValue = 30; // Bijvoorbeeld.

// Get the collection of picture transform operations.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **De achtergrondwaarde van een dia ophalen**

Aspose.Slides biedt de [IBackgroundEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibackgroundeffectivedata/)‑interface voor het ophalen van de effectieve achtergrondwaarden van een dia. Deze interface geeft toegang tot de effectieve [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) en [EffectFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Met de `getBackground`‑methode van de [BaseSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseslide/)‑klasse kun je de effectieve achtergrond van een dia verkrijgen.

Het volgende Java‑voorbeeld toont hoe je de effectieve achtergrondwaarde van een dia ophaalt:

```java
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

**Kan ik een aangepaste achtergrond resetten en het thema/lay‑out‑achtergrond herstellen?**

Ja. Verwijder de aangepaste vulling van de dia, dan wordt de achtergrond opnieuw overgeërfd van de bijbehorende [lay‑out](/slides/nl/java/slide-layout/)/[master](/slides/nl/java/slide-master/) dia (dus de [thematische achtergrond](/slides/nl/java/presentation-theme/)).

**Wat gebeurt er met de achtergrond als ik later het thema van de presentatie wijzig?**

Als een dia een eigen vulling heeft, blijft die ongewijzigd. Als de achtergrond wordt geërfd van de [lay‑out](/slides/nl/java/slide-layout/)/[master](/slides/nl/java/slide-master/), wordt deze bijgewerkt zodat hij overeenkomt met het [nieuwe thema](/slides/nl/java/presentation-theme/).