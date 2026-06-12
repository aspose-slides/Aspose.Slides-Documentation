---
title: "Beheer presentatie‑achtergronden in JavaScript"
linktitle: "Dia‑achtergrond"
type: docs
weight: 20
url: /nl/nodejs-java/presentation-background/
keywords:
- presentatieachtergrond
- dia‑achtergrond
- effen kleur
- verloopkleur
- afbeelding‑achtergrond
- achtergrondtransparantie
- achtergrond‑eigenschappen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe je dynamische achtergronden instelt in PowerPoint‑ en OpenDocument‑bestanden met Aspose.Slides voor Node.js, met code‑tips om je presentaties te verbeteren."
---
## **Introductie**

Effen kleuren, kleurverlopen en afbeeldingen worden vaak gebruikt als dia‑achtergronden. Je kunt de achtergrond instellen voor een **normale dia** (een enkele dia) of een **master‑dia** (geldt voor meerdere dia’s tegelijk).

![PowerPoint background](powerpoint-background.png)

## **Effen kleurachtergrond instellen voor een normale dia**

Aspose.Slides stelt je in staat een effen kleur als achtergrond in te stellen voor een specifieke dia in een presentatie—zelfs als de presentatie een master‑dia gebruikt. De wijziging geldt alleen voor de geselecteerde dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse aan.  
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.  
3. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) van de dia‑achtergrond in op `Solid`.  
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) methode op [FillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/) om de effen achtergrondkleur op te geven.  
5. Sla de gewijzigde presentatie op.

Het volgende JavaScript‑voorbeeld laat zien hoe je een blauwe effen kleur als achtergrond voor een normale dia instelt:

```js
// Maak een instantie van de Presentation‑klasse.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Stel de achtergrondkleur van de dia in op blauw.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Sla de presentatie op naar schijf.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Effen kleurachtergrond instellen voor de master‑dia**

Aspose.Slides stelt je in staat een effen kleur als achtergrond in te stellen voor de master‑dia in een presentatie. De master‑dia fungeert als een sjabloon dat de opmaak voor alle dia’s beheert, zodat wanneer je een effen kleur kiest voor de achtergrond van de master‑dia, deze op elke dia wordt toegepast.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse aan.  
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/backgroundtype/) van de master‑dia (via `getMasters`) in op `OwnBackground`.  
3. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) van de master‑dia‑achtergrond in op `Solid`.  
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) methode om de effen achtergrondkleur op te geven.  
5. Sla de gewijzigde presentatie op.

Het volgende JavaScript‑voorbeeld laat zien hoe je een effen kleur (groen) als achtergrond voor een master‑dia instelt:

```js
// Maak een instantie van de Presentation‑klasse.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Stel de achtergrondkleur voor de Master‑dia in op Bosgroen.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Sla de presentatie op naar schijf.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kleurverloopachtergrond instellen voor een dia**

Een kleurverloop is een grafisch effect dat ontstaat door een geleidelijke kleurschakeling. Wanneer het wordt gebruikt als dia‑achtergrond, kan een kleurverloop presentaties een meer artistieke en professionele uitstraling geven. Aspose.Slides stelt je in staat een kleurverloop als achtergrond voor dia's in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse aan.  
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.  
3. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) van de dia‑achtergrond in op `Gradient`.  
4. Gebruik de [getGradientFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/#getGradientFormat) methode op [FillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/) om je gewenste kleurverloopinstellingen te configureren.  
5. Sla de gewijzigde presentatie op.

Het volgende JavaScript‑voorbeeld laat zien hoe je een kleurverloop als achtergrond voor een dia instelt:

```js
// Maak een instantie van de Presentation‑klasse.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Pas een kleurverloop‑effect toe op de achtergrond.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Sla de presentatie op naar schijf.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een afbeelding als dia‑achtergrond instellen**

Bovendien kun je naast effen en kleurverloopvullingen afbeeldingen als dia‑achtergrond gebruiken met Aspose.Slides.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse aan.  
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.  
3. Stel de [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) van de dia‑achtergrond in op `Picture`.  
4. Laad de afbeelding die je als dia‑achtergrond wilt gebruiken.  
5. Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.  
6. Gebruik de [getPictureFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) methode op [FillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/) om de afbeelding als achtergrond toe te wijzen.  
7. Sla de gewijzigde presentatie op.

Het volgende JavaScript‑voorbeeld laat zien hoe je een afbeelding als achtergrond voor een dia instelt:

```js
// Maak een instantie van de Presentation‑klasse.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Stel eigenschappen van de achtergrondafbeelding in.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Laad de afbeelding.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Sla de presentatie op naar schijf.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De volgende codevoorbeeld laat zien hoe je het achtergrondvulltype instelt op een getegelde afbeelding en de tegel‑eigenschappen wijzigt:

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

    // Stel de afbeelding in die wordt gebruikt voor de achtergrondvulling.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Stel de afbeeldingsvullingsmodus in op Tegel en pas de tegel‑eigenschappen aan.
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
Lees meer: [**Afbeelding als tegeltextuur**](/slides/nl/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparantie van de achtergrondafbeelding wijzigen**

Je wilt misschien de transparantie van de achtergrondafbeelding van een dia aanpassen zodat de inhoud van de dia beter tot uiting komt. De volgende JavaScript‑code laat zien hoe je de transparantie van een achtergrondafbeelding van een dia wijzigt:

```js
var transparencyValue = 30; // Bijvoorbeeld.

// Verkrijg de collectie van afbeeldings‑transformatiebewerkingen.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Zoek een bestaand vaste‑percentage transparantie‑effect.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Stel de nieuwe transparantiewaarde in.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **De achtergrondwaarde van een dia ophalen**

Aspose.Slides biedt de klasse `BackgroundEffectiveData` om de effectieve achtergrondwaarden van een dia op te halen. Deze klasse geeft de effectieve [FillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/) en [EffectFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effectformat/) weer.

Met de `getBackground`‑methode van de [BaseSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/)‑klasse kun je de effectieve achtergrond van een dia verkrijgen.

Het volgende JavaScript‑voorbeeld laat zien hoe je de effectieve achtergrondwaarde van een dia ophaalt:

```js
// Maak een instantie van de Presentation‑klasse.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Haal de effectieve achtergrond op, rekening houdend met master, layout en thema.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **Veelgestelde vragen**

**Kan ik een aangepaste achtergrond resetten en de thema-/lay‑out‑achtergrond herstellen?**

Ja. Verwijder de aangepaste vulling van de dia, dan wordt de achtergrond opnieuw geërfd van de overeenkomstige [layout](/slides/nl/nodejs-java/slide-layout/)/[master](/slides/nl/nodejs-java/slide-master/) dia (d.w.z. de [theme background](/slides/nl/nodejs-java/presentation-theme/)).

**Wat gebeurt er met de achtergrond als ik later het thema van de presentatie wijzig?**

Als een dia een eigen vulling heeft, blijft deze ongewijzigd. Als de achtergrond wordt geërfd van de [layout](/slides/nl/nodejs-java/slide-layout/)/[master](/slides/nl/nodejs-java/slide-master/), wordt deze bijgewerkt zodat deze overeenkomt met het [new theme](/slides/nl/nodejs-java/presentation-theme/).