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
- achtergrondeigenschappen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u dynamische achtergronden instelt in PowerPoint‑ en OpenDocument‑bestanden met Aspose.Slides voor Android via Java, met code‑tips om uw presentaties te verbeteren."
---
## **Inleiding**

Effen kleuren, kleurverlopen en afbeeldingen worden vaak gebruikt als dia‑achtergronden. Je kunt de achtergrond instellen voor een **normale dia** (een enkele dia) of een **master‑dia** (geldt voor meerdere dia’s tegelijk).

![PowerPoint-achtergrond](powerpoint-background.png)

## **Achtergrond met een effen kleur instellen voor een normale dia**

Aspose.Slides stelt je in staat om een effen kleur als achtergrond voor een specifieke dia in een presentatie in te stellen—zelfs wanneer de presentatie een master‑dia gebruikt. De wijziging is alleen van toepassing op de geselecteerde dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)-klasse.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de dia‑achtergrond [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Solid`.
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/) om de effen achtergrondkleur op te geven.
5. Sla de aangepaste presentatie op.

De volgende Java‑voorbeeld toont hoe je een blauwe effen kleur als achtergrond voor een normale dia instelt:

```java
// Maak een instantie van de Presentation-klasse.
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

## **Achtergrond met een effen kleur instellen voor een master‑dia**

Aspose.Slides stelt je in staat om een effen kleur als achtergrond voor de master‑dia in een presentatie in te stellen. De master‑dia fungeert als een sjabloon die de opmaak voor alle dia’s regelt, dus wanneer je een effen kleur kiest voor de achtergrond van de master‑dia, wordt deze op elke dia toegepast.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)-klasse.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/backgroundtype/) van de master‑dia (via `getMasters`) in op `OwnBackground`.
3. Stel de master‑dia‑achtergrond [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Solid`.
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--)‑methode om de effen achtergrondkleur op te geven.
5. Sla de aangepaste presentatie op.

Het volgende Java‑voorbeeld toont hoe je een effen kleur (groen) als achtergrond voor een master‑dia instelt:

```java
// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Stel de achtergrondkleur voor de Master‑dia in op Bosgroen.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Sla de presentatie op naar schijf.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kleurverloop‑achtergrond instellen voor een dia**

Een kleurverloop is een grafisch effect dat wordt gecreëerd door een geleidelijke kleurverandering. Wanneer het als dia‑achtergrond wordt gebruikt, kunnen kleurverlopen presentaties artistieker en professioneler doen lijken. Aspose.Slides stelt je in staat om een kleurverloop als achtergrond voor dia’s in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)-klasse.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de dia‑achtergrond [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Gradient`.
4. Gebruik de [getGradientFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/#getGradientFormat--)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/) om je gewenste kleurverloop‑instellingen te configureren.
5. Sla de aangepaste presentatie op.

Het volgende Java‑voorbeeld toont hoe je een kleurverloopkleur als achtergrond voor een dia instelt:

```java
// Maak een instantie van de Presentation-klasse.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Pas een kleurverloop‑effect toe op de achtergrond.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Sla de presentatie op naar schijf.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Afbeelding instellen als dia‑achtergrond**

Naast effen en kleurverloop‑vullingen stelt Aspose.Slides je in staat om afbeeldingen als dia‑achtergronden te gebruiken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)-klasse.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de dia‑achtergrond [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) in op `Picture`.
4. Laad de afbeelding die je als dia‑achtergrond wilt gebruiken.
5. Voeg de afbeelding toe aan de afbeeldingsverzameling van de presentatie.
6. Gebruik de [getPictureFillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fillformat/) om de afbeelding toe te wijzen als achtergrond.
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
    // Voeg de afbeelding toe aan de afbeeldingsverzameling van de presentatie.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Sla de presentatie op naar schijf.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het volgende code‑voorbeeld toont hoe je het achtergrond‑vullingstype instelt op een betegelde afbeelding en de tegel‑eigenschappen aanpast:

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

    // Stel de afbeeldingsvullingsmodus in op Tegel en pas de tegel-eigenschappen aan.
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
Lees meer: [**Afbeelding als textuur betegelen**](/slides/nl/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Achtergrondafbeelding‑transparantie wijzigen**

Je wilt wellicht de transparantie van de achtergrondafbeelding van een dia aanpassen zodat de inhoud van de dia beter opvalt. De volgende Java‑code laat zien hoe je de transparantie van een dia‑achtergrondafbeelding kunt wijzigen:

```java
int transparencyValue = 30; // Bijvoorbeeld.

 // Haal de collectie van picture transform‑operaties op.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

 // Zoek een bestaande fixed‑percentage transparantie‑effect.
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
```

## **De achtergrondwaarde van de dia ophalen**

Aspose.Slides biedt de [IBackgroundEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibackgroundeffectivedata/)-interface voor het ophalen van de effectieve achtergrondwaarden van een dia. Deze interface geeft toegang tot de effectieve [FillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) en [EffectFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Met de `getBackground`‑methode van de [BaseSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslide/)-klasse kun je de effectieve achtergrond van een dia opvragen.

Het volgende Java‑voorbeeld toont hoe je de effectieve achtergrondwaarde van een dia kunt ophalen:

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

**Kan ik een aangepaste achtergrond opnieuw instellen en de thema-/lay-out‑achtergrond herstellen?**

Ja. Verwijder de aangepaste vulling van de dia en de achtergrond wordt opnieuw geërfd van de bijbehorende [lay-out](/slides/nl/androidjava/slide-layout/)/[master](/slides/nl/androidjava/slide-master/) dia (dwz de [thema‑achtergrond](/slides/nl/androidjava/presentation-theme/)).

**Wat gebeurt er met de achtergrond als ik later het thema van de presentatie wijzig?**

Als een dia een eigen vulling heeft, blijft deze onveranderd. Als de achtergrond wordt geërfd van de [lay-out](/slides/nl/androidjava/slide-layout/)/[master](/slides/nl/androidjava/slide-master/), wordt deze bijgewerkt om overeen te komen met het [nieuwe thema](/slides/nl/androidjava/presentation-theme/).