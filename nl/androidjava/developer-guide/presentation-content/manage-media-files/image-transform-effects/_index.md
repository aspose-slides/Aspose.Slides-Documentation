---
title: Beheer afbeeldingstransformatie‑effecten in presentaties op Android
linktitle: Afbeeldingstransformatie‑effecten
type: docs
weight: 11
url: /nl/androidjava/image-transform-effects/
keywords:
- afbeeldingstransformatie
- afbeeldingseffect
- helderheid
- contrast
- grijstinten
- duotoon
- tint
- HSL
- kleurvervanging
- vervaging
- transparantie
- alpha‑effect
- effectketen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Toepassen, samenvoegen, inspecteren, verwijderen en verifiëren van afbeeldingstransformatie‑effecten voor afbeelding‑frames met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Aspose.Slides vertegenwoordigt afbeeldingsaanpassingen als een geordende collectie van afbeeldings‑transformatie‑operaties. Voor een afbeelding‑frame begin je met de frame‑behorende [ISlidesPicture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidespicture/) en krijg je toegang tot [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). De geretourneerde [IImageTransformOperationCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/) laat je effecten toevoegen, enumereren, inspecteren, verwijderen en wissen zonder de oorspronkelijke afbeeldingsbytes te herschrijven.

Dit artikel laat een volledige workflow zien voor helderheid en contrast, kleuropties, vervaging, transparantie, geordende effectketens, effectieve waarden, verwijdering en PPTX round‑trip verificatie.

## **Begrijp eigendom van effecten en hergebruik van afbeeldingen**

Een afbeelding‑resource en de afbeelding die deze weergeeft zijn verschillende objecten:

- [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) slaat de bron‑afbeeldingsgegevens op of verwijst ernaar en behoort toe aan de presentatie.
- [ISlidesPicture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidespicture/) hoort bij een afbeelding‑vulling en verwijst naar een afbeelding‑resource terwijl de afbeeldings‑transformatie‑collectie wordt bewaard.
- [IPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/) is de dia‑vorm die de bijbehorende afbeelding‑vulling, geometrie, bijsnij‑instellingen en andere frame‑niveau opmaak bezit.

Daarom wijzigen afbeeldings‑transformatie‑operaties de bytes in [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) niet. Wanneer dezelfde `IPPImage` meer dan één keer wordt doorgegeven aan [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-), krijgt elk nieuw afbeelding‑frame zijn eigen `ISlidesPicture` en zijn eigen transformatie‑collectie. Het toepassen van grijstinten op één frame maakt de andere frames niet grijs, ook al gebruiken ze dezelfde ingesloten afbeelding‑resource.

Hetzelfde `ISlidesPicture.getImageTransform`‑model wordt ook gebruikt door andere afbeelding‑vullingen, zoals een vorm of dia‑achtergrond. De voorbeelden hieronder richten zich op afbeelding‑frames.

## **Gebruik geldige parameterbereiken en eenheden**

De getoonde methoden gebruiken de volgende semantische bereiken en eenheden. Houd waarden binnen deze bereiken, zelfs als een bepaalde bibliotheekversie niet meteen elke buiten‑range‑waarde afwijst; het doel‑presentatieformaat kan tijdens opslaan of bij openen door PowerPoint normaliseren, verwijderen of ongeldige gegevens afwijzen.

| Operatie | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat het onderdeel ongewijzigd. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Geen | Geen numerieke parameters. Alpha blijft ongewijzigd. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Twee kleuren voor donkere en lichte pixels. RGB‑ en alfacanaalwaarden die door `android.graphics.Color` worden gebruikt, lopen van `0` tot `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Tint (`hue`) is `0` inclusief tot `360` exclusief, in graden; hoeveelheid (`amount`) is `-100` tot `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Tint (`hue`) is `0` inclusief tot `360` exclusief, in graden; verzadiging en luminantie zijn `-100` tot `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | De vervangingskleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alfadewaarden blijven ongewijzigd. |
| [addBlurEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Straal is niet‑negatief en wordt gemeten in punten; `grow` is een Boolean die bepaalt of vervaagde inhoud buiten de oorspronkelijke randen mag uitbreiden. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Niet‑negatief percentage. Gebruik `0` tot `100` voor gewone opaciteits‑schaal: `0` is volledig transparant en `100` behoudt de bestaande alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` tot `100`, procent opaciteit. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` tot `100`, procent alpha‑drempel. Waarden lager dan de drempel worden transparant; waarden gelijk aan of hoger worden ondoorzichtig. |

Voor vaste alpha‑modulatie zijn transparantie en opaciteit complementair. Een transparantie van 35 % komt overeen met een alpha‑modulatie‑waarde van 65 %.

## **Pas helderheid en contrast toe**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) retourneert een [IBrightnessContrast](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibrightnesscontrast/)‑operatie. De scalare instellingen worden meegegeven wanneer de operatie wordt aangemaakt. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) levert berekende alleen‑lezen waarden die kunnen worden geïnspecteerd of gelogd.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 %, en rendert daarna een voorbeeld zonder de ingesloten afbeelding te wijzigen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/brightnesscontrast/) is een Office 2010 afbeelding‑effect‑extensie en minder draagbaar dan het standaard DrawingML‑luminantie‑effect. Wanneer helderheid en contrast bewerkbaar moeten blijven na een PPTX‑round‑trip, gebruik dan [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) en verifieer het resultaat na het opnieuw openen van het bestand. De sectie over format‑beperkingen legt dit onderscheid uitgebreider uit.

## **Pas kleurtransformaties toe**

Kleureffecten kunnen onafhankelijk worden toegepast op verschillende afbeelding‑frames die één afbeelding‑resource hergebruiken. Het volgende voorbeeld maakt vijf frames en past grijstinten, duotoon, tint, HSL‑aanpassing en kleurvervanging toe.

[IDuotone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iduotone/) bevat twee onafhankelijk bewerkbare kleurparameters: `color1` wijst donkere pixels toe, terwijl `color2` lichte pixels wijst. Dit maakt het een nuttig voorbeeld van een effect waarvan de instellingen complexer zijn dan één enkele scalare waarde.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) vervangt elke pixelkleur door één vaste kleur terwijl de alpha behouden blijft. Het verschilt van [addColorChangeEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), dat één bron‑kleur naar een andere mappt en zowel bron‑ als doel‑kleurformaten onthult.

## **Voeg vervaging, transparantie en alpha‑effecten toe**

[addBlurEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) beïnvloedt alle kleurkanalen, inclusief alpha. Stel `grow` in op `true` wanneer de vervaagde rand buiten de oorspronkelijke afbeeldingsgrenzen kan uitbreiden.

Voor uniforme transparantie, gebruik [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Het vermenigvuldigt elke bestaande alfadewaarde, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) wijst in plaats daarvan één alfadewaarde toe aan alle pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) zet alpha om in twee niveaus op basis van een drempel.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Andere parameter‑vrije alpha‑operaties omvatten [addAlphaCeilingEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), die elke niet‑nul alpha volledig ondoorzichtig maakt; [addAlphaFloorEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), die elke alpha onder 100 % volledig transparant maakt; en [addAlphaInverseEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), die alpha verandert naar `100% - alpha`.

## **Bouw een geordende effectketen**

Elke `add...Effect`‑methode voegt een nieuwe operatie toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de uitvoer van operatie 0 wordt de invoer van operatie 1, enzovoort. Bijgevolg kan dezelfde reeks operaties in een andere volgorde een ander beeld opleveren.

Bijvoorbeeld, grijstinten gevolgd door tint verwijdert eerst chromatische informatie en kleurt daarna het luminantie‑resultaat opnieuw. Tint gevolgd door grijstinten verwijdert vervolgens de tint weer. Evenzo kan een alpha‑vervanging alpha‑waarden die door eerdere operaties zijn berekend overschrijven, terwijl alpha‑modulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier operaties, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de operatietypen als hun volgorde, en rendert het heropende resultaat:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

De collectie legt geen compatibiliteitsmatrix op die kleur‑, alpha‑ en vervagingsoperaties tot afzonderlijke ketens beperkt. Ze kunnen gecombineerd worden, hoewel combinaties niet altijd zinvol zijn. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleureffecten is gecreëerd; grijstinten na duotoon verwijderen de twee geselecteerde kleuren; en alpha‑ceiling, floor, replacement of bi‑level operaties kunnen eerder gemaakte alpha‑details verwijderen. Bouw de keten volgens de gewenste pixel‑verwerkingsvolgorde in plaats van de items als ongeordende opmaak‑vlaggen te beschouwen.

## **Inspecteer bewerkbare en effectieve waarden**

Een bewerkbare operatie is het object dat wordt opgeslagen in `ISlidesPicture.getImageTransform`. Afhankelijk van het effect kan het direct schrijfbare leden exposeren. Bijvoorbeeld, [IBlur](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iblur/) exposeert schrijfbare `radius`‑ en `grow`‑waarden, [IAlphaModulateFixed](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ialphamodulatefixed/) exposeert een schrijfbare `amount`, en [IAlphaBiLevel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ialphabilevel/) exposeert een schrijfbare `threshold`. Kleur‑effecten zoals [IDuotone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iduotone/) exposeren mutabele [IColorFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icolorformat/) objecten.

Sommige operatie‑interfaces, waaronder [IBrightnessContrast](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itint/) en [IAlphaReplace](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ialphareplace/), exposeren hun creatiescalaren niet als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijder je de operatie en voeg je een vervanger toe op de gewenste positie.

Effectieve data die door `getEffective()` wordt geretourneerd, is berekend en alleen‑lezen. Het is nuttig voor het oplossen van themagebaseerde kleuren en het lezen van de genormaliseerde waarden die de renderer gebruikt, maar het is geen extra bewerkingsvlak. Het volgende voorbeeld enumerateert de keten en inspecteert effectieve waarden waar de corresponderende API ze biedt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Parameter‑vrije effecten zoals grijstinten, alpha‑ceiling en alpha‑inverse hebben nog steeds een effectieve‑data‑object, maar er zijn geen scalar‑instellingen om af te drukken. Hun aanwezigheid en positie in de collectie zijn de belangrijke informatie.

## **Verwijder of wis afbeeldings‑transformaties**

Gebruik [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) om één operatie op index te verwijderen. Omdat indexen na een verwijdering verschuiven, zoek je eerst het doel en verwijder het daarna na enumeratie. Gebruik [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) om de volledige keten te verwijderen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Het verwijderen of wissen van transformaties wijzigt alleen de afbeelding‑opmaak. Het verwijdert, recomprimeert of verandert de hergebruikte [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) resource niet.

## **Beschouw presentatieformaten en export‑doelen**

Afbeeldings‑transformaties ontstaan in DrawingML, dus PPTX is het geprefereerde bewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke operatie identieke draagbaarheid:

- Standaard DrawingML‑operaties zoals luminantie, grijstinten, duotoon, tint, HSL, vervaging en gangbare alpha‑operaties hebben de grootste kans om een PPTX‑round‑trip te overleven. Open altijd het gegenereerde bestand opnieuw en inspecteer de collectie wanneer behoud een vereiste is.
- [BrightnessContrast](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/brightnesscontrast/) is een Office 2010‑extensie in plaats van de standaard DrawingML‑luminantie‑operatie. Het kan voor in‑memory rendering worden gebruikt, maar het is niet gegarandeerd dat het na opslaan en heropenen van PPTX bewerkbaar blijft als [IBrightnessContrast](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibrightnesscontrast/). Geef de voorkeur aan [addLuminanceEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) voor persistente helderheid‑ en contrast‑aanpassingen.
- Het binair PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan naar PPT kan niet‑ondersteunde operaties weglaten, een keten terugbrengen tot een ondersteunde subset, of een benadering van het uiterlijk geven. Gebruik PPT niet als verificatie‑formaat voor een complexe bewerkbare keten.
- Renderen naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele output past de ondersteunde keten toe op het gerenderde uiterlijk. Die outputs bevatten geen bewerkbare `IImageTransformOperationCollection`; rasterformaten flatten het resultaat naar pixels, en document‑/vector‑exports slaan hun eigen renderingsrepresentatie op.
- Effecten maken een gekoppelde afbeelding niet zelf‑voorzienend. Het renderen van een gekoppelde afbeelding blijft afhankelijk van de beschikbaarheid van de gekoppelde resource wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen randgevallen verschillend renderen, vooral wanneer meerdere alpha‑ of kleur‑kwantisatie‑operaties gecombineerd worden. Voor kritieke output, test zowel de bewerkbare round‑trip als het uiteindelijke export‑formaat met dezelfde versie van Aspose.Slides die in productie wordt gebruikt.

## **FAQ**

**Wijzigen afbeelding‑transformatie‑effecten de ingesloten afbeeldingsdata?**

Nee. De operaties behoren tot de `ISlidesPicture` die door de afbeelding‑vulling wordt gebruikt. De onderliggende `IPPImage`‑bytes blijven ongewijzigd.

**Delen twee afbeelding‑frames die dezelfde afbeelding hergebruiken hun effecten?**

Nee. Het hergebruiken van een `IPPImage` voorkomt dubbele afbeeldingsdata, maar elk afbeelding‑frame heeft normaal gesproken een apart `ISlidesPicture` en een aparte transformatie‑collectie.

**Kunnen kleur‑, vervagings‑ en alpha‑effecten gecombineerd worden?**

Ja. De collectie accepteert ze in één geordende keten. Overweeg wat elke operatie doet met de uitvoer van de vorige, want vervangings‑ en drempel‑operaties kunnen eerdere kleur‑ of alpha‑details verwijderen.

**Waarom zijn effectieve waarden alleen‑lezen?**

Effectieve data vertegenwoordigt berekende waarden die voor het renderen worden gebruikt, inclusief opgeloste kleuren. Bewerk de operatie die in de transformatie‑collectie is opgeslagen waar schrijfbare leden bestaan; anders verwijder je deze en voeg je een vervanger toe met nieuwe creatie‑parameters.

**Welk formaat moet ik gebruiken om een transform‑keten te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Legacy PPT kan het volledige DrawingML‑effectmodel niet representeren, en gerenderde export‑formaten behouden alleen het uiterlijk, niet bewerkbare transform‑operaties.