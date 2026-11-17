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
- onscherpte
- transparantie
- alfa‑effect
- effectketen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Pas afbeeldingstransformatie‑effecten toe, koppel ze, inspecteer, verwijder en verifieer ze voor afbeeldingsframes met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Aspose.Slides vertegenwoordigt afbeeldingsaanpassingen als een geordende verzameling van beeldtransformatie‑operaties. Voor een afbeeldingsframe begin je met het frame's [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) en krijg je toegang tot [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). De geretourneerde [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) stelt je in staat om effecten toe te voegen, te enumereren, te inspecteren, te verwijderen en te wissen zonder de oorspronkelijke afbeeldingsbytes opnieuw te schrijven.

Dit artikel demonstreert een volledige workflow voor helderheid en contrast, kleurtransformaties, onscherpte, transparantie, geordende effectketens, effectieve waarden, verwijderen en PPTX‑round‑trip‑verificatie.

## **Begrijp eigendom van effecten en hergebruik van afbeeldingen**

Een afbeeldingsbron en de afbeelding die deze weergeeft zijn verschillende objecten:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) slaat de bronafbeeldingsgegevens op of verwijst ernaar die eigendom zijn van de presentatie.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) behoort tot een afbeeldingsvulling en verwijst naar een afbeeldingsbron terwijl het de collectie van beeldtransformaties opslaat.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) is de dia‑vorm die de betreffende afbeeldingsvulling, geometrie, bijsnij‑instellingen en andere opmaak op frame‑niveau bezit.

Daarom wijzigen beeldtransformatie‑operaties de bytes in [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) niet. Wanneer dezelfde `IPPImage` meer dan één keer wordt doorgegeven aan [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) , krijgt elk nieuw afbeeldingsframe zijn eigen `ISlidesPicture` en zijn eigen transformatie‑collectie. Het toepassen van grijstinten op één frame maakt de andere frames niet grijs, zelfs al gebruiken ze allemaal dezelfde ingebedde afbeeldingsbron.

Hetzelfde `ISlidesPicture.getImageTransform`‑model wordt ook gebruikt door andere afbeeldingsvullingen, zoals een vorm of dia‑achtergrond. De onderstaande voorbeelden richten zich op afbeeldingsframes.

## **Gebruik geldige parameterbereiken en eenheden**

De gedemonstreerde methoden gebruiken de volgende semantische bereiken en eenheden. Houd waarden binnen deze bereiken, zelfs als een bepaalde bibliotheekversie niet direct elke buiten‑range waarde afwijst; het doelformaat van de presentatie kan ongeldige gegevens normaliseren, weglaten of afwijzen tijdens het opslaan of wanneer PowerPoint het bestand opent.

| Operatie | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat het onderdeel ongewijzigd. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | Geen numerieke parameters. Alpha blijft ongewijzigd. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Twee kleuren voor donkere en lichte pixels. RGB- en alfakanalwaarden die door `android.graphics.Color` worden gebruikt, lopen van `0` tot `255`. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Tint is `0` inclusief tot `360` exclusief, in graden; hoeveelheid is `-100` tot `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Tint is `0` inclusief tot `360` exclusief, in graden; verzadiging en luminantie zijn `-100` tot `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | De vervangende kleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alfa‑waarden blijven ongewijzigd. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radius is niet‑negatief en wordt gemeten in punten; `grow` is een Boolean die bepaalt of vervaagd materiaal buiten de oorspronkelijke grenzen mag uitsteken. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Niet‑negatief procent. Gebruik `0` tot `100` voor gewone transparantie‑schaling: `0` is volledig transparant en `100` behoudt de bestaande alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` tot `100`, procent doorzichtigheid. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` tot `100`, procent alfa‑drempel. Waarden eronder worden transparant; waarden op of boven de drempel worden ondoorzichtig. |

Voor vaste alfa‑modulatie zijn transparantie en opaciteit complementair. Bijvoorbeeld, 35% transparantie komt overeen met een alfa‑modulatie‑bedrag van 65%.

## **Pas helderheid en contrast toe**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) retourneert een [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/)‑operatie. De scalair‑instellingen worden geleverd wanneer de operatie wordt aangemaakt. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) retourneert berekende alleen‑lees‑waarden die kunnen worden geïnspecteerd of gelogd.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 %, en rendert vervolgens een voorbeeld zonder de ingebedde afbeelding te wijzigen:

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

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) is een Office 2010 afbeelding‑effect‑extensie en minder draagbaar dan het standaard DrawingML‑luminant‑effect. Wanneer helderheid en contrast bewerkbaar moeten blijven na een PPTX‑round‑trip, gebruik dan [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) en verifieer het resultaat na het opnieuw openen van het bestand. De sectie over format‑beperkingen legt dit onderscheid nader uit.

## **Pas kleurtransformaties toe**

Kleureffecten kunnen onafhankelijk worden toegepast op verschillende afbeeldingsframes die één afbeeldingsbron hergebruiken. Het volgende voorbeeld maakt vijf frames en past grijstinten, duotoon, tint, HSL‑aanpassing en kleurvervanging toe.

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) bevat twee onafhankelijk bewerkbare kleurparameters: `color1` wijst donkere pixels toe, terwijl `color2` lichte pixels wijst. Dit maakt het een nuttig voorbeeld van een effect waarvan de instellingen complexer zijn dan een enkele scalair‑waarde.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) vervangt de kleur van elke pixel door één vaste kleur, terwijl alfa behouden blijft. Het verschilt van [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), dat één bronkleur naar een andere afbeeldt en zowel bron‑ als doelkleurformaten blootlegt.

### **Pas een luminantiedrempel toe**

Een luminantiedrempel kan vage markeringen op een gescande pagina beter van de achtergrond onderscheiden. [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) behoudt tussenliggende grijstinten. [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) zet luminantie om in zwart of wit, terwijl [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) een drempel op de opaciteit toepast.

De luminantiedrempel varieert van 0 % tot 100 %, inclusief. Pixels onder de drempel worden zwart. Pixels op of boven de drempel worden wit. Het verhogen van de drempel maakt meer tinten zwart omdat meer ervan onder de afkapwaarde vallen.

Download [grayscale-swatches.png](grayscale-swatches.png) naar de werkmap. Elk etiket geeft het oorspronkelijke grijsniveau op een schaal van 0 tot 255 weer. Het voorbeeld plaatst het origineel naast twee kopieën en slaat de drempel van elke kopie op in de presentatie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Open de uitvoerpresentatie in PowerPoint om de drie frames te vergelijken. Het kleurstaal met label 96 heeft ongeveer 38 % luminantie (96 van 255). Het wordt wit bij de drempel van 20 % en zwart bij de drempel van 60 %.

![Originele grijstinten naast de zwart‑wit resultaten bij luminantiedrempels van 20 % en 60 %](luminance-threshold.png)

## **Voeg onscherpte, transparantie en alfa‑effecten toe**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) beïnvloedt alle kleurkanalen, inclusief alfa. Stel `grow` in op `true` wanneer de vervaagde rand buiten de oorspronkelijke afbeeldingsgrenzen kan uitstrekken.

Voor uniforme transparantie, gebruik [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Het vermenigvuldigt elke bestaande alfadeelwaarde, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) kent daarentegen één alfadeelwaarde toe aan alle pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) zet alfa om in twee niveaus op basis van een drempel.

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

Andere alfa‑operaties zonder parameters omvatten [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), die elke niet‑nul alfa volledig ondoorzichtig maakt; [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), die elke alfa onder 100 % volledig transparant maakt; en [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), die alfa verandert naar `100% - alpha`.

## **Bouw een geordende effectketen op**

Elke `add...Effect`‑methode voegt een nieuwe operatie toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de output van operatie 0 wordt de input van operatie 1, enzovoort. Daardoor kan dezelfde reeks operaties in een andere volgorde een ander beeld opleveren.

Bijvoorbeeld, grijstinten gevolgd door tint verwijdert eerst chromatische informatie en kleurt vervolgens het luminantieresultaat opnieuw. Tint gevolgd door grijstinten verwijdert de tint weer. Evenzo kan alfa‑vervanging alfa‑waarden die door eerdere operaties zijn berekend, overschrijven, terwijl alfa‑modulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier operaties, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de type operaties als hun volgorde, en rendert het heropende resultaat:

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

De collectie legt geen compatibiliteitsmatrix op die kleur-, alfa- en onscherpte‑operaties tot afzonderlijke ketens beperkt. Ze kunnen worden gecombineerd, maar combinaties zijn niet altijd nuttig. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleureffecten is geproduceerd; grijstinten na duotoon verwijderen de twee geselecteerde kleuren; en alfa‑plafond, -vloer, -vervanging of -bilevel‑operaties kunnen alfa‑details die eerder zijn gemaakt, weggooien. Bouw de keten volgens de gewenste pixel‑verwerkingsvolgorde in plaats van de items te zien als ongeordende opmaak‑vlaggen.

<!-- visual-explanation:image-transform-effects:start -->
[![Dezelfde afbeelding gaat eerst door grijstinten daarna tint, en eerst door tint daarna grijstinten. De twee uiteindelijke grijstint‑afbeeldingen hebben verschillende tonen.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In dit illustratieve Aspose.Slides voor .NET 26.11‑render, een tint van 220° op 25 % laat de grijstint‑afbeelding ongewijzigd. Het toepassen van dezelfde tint vóór grijstinten leidt tot verschillende tinten.*
<!-- visual-explanation:image-transform-effects:end -->

## **Inspecteer bewerkbare en effectieve waarden**

Een bewerkbare operatie is het object dat is opgeslagen in `ISlidesPicture.getImageTransform`. Afhankelijk van het effect kan het direct schrijfbare leden blootleggen. Bijvoorbeeld, [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) biedt schrijfbare `radius`‑ en `grow`‑waarden, [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) biedt een schrijfbare `amount`, en [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) biedt een schrijfbare `threshold`. Klee­rijeffecten zoals [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) bieden mutable [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/)‑objecten.

Sommige operatie‑interfaces, inclusief [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/), en [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/), tonen hun creatiescalars niet als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijder de operatie en voeg een vervanging toe op de vereiste positie.

Effectieve gegevens die worden geretourneerd door `getEffective()` zijn berekend en alleen‑lees. Ze zijn nuttig voor het oplossen van themakerende kleuren en het lezen van de genormaliseerde waarden die de renderer gebruikt, maar vormen geen extra bewerkingsoppervlak. Het volgende voorbeeld enumerateert de keten en inspecteert effectieve waarden waar de corresponderende API ze levert:

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

Effecten zonder parameters zoals grijstinten, alfa‑plafond en alfa‑inverse hebben nog steeds een effectieve‑dat object, maar er zijn geen scalair‑instellingen om af te drukken. Hun aanwezigheid en positie in de collectie zijn de belangrijke informatie.

## **Verwijder of wis beeldtransformaties**

Gebruik [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) om één operatie op basis van index te verwijderen. Omdat indexen verschuiven na verwijdering, zoek eerst naar het doel en verwijder het daarna na enumeratie. Gebruik [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) om de volledige keten te verwijderen.

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

Het verwijderen of wissen van transformaties wijzigt alleen de afbeeldingsopmaak. Het verwijdert, recomprimeert of wijzigt de hergebruikte [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/)‑bron niet.

## **Overweeg presentatieformaten en exportdoelen**

Beeldtransformaties komen voort uit DrawingML, dus PPTX is het voorkeurs‑bewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke operatie dezelfde draagbaarheid:

- Standaard DrawingML‑operaties zoals luminantie, grijstinten, duotoon, tint, HSL, onscherpte en gangbare alfa‑operaties hebben de grootste kans om een PPTX‑round‑trip te overleven. Open het gegenereerde bestand altijd opnieuw en inspecteer de collectie wanneer bewaring een vereiste is.
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) is een Office 2010‑extensie in plaats van de standaard DrawingML‑luminantie‑operatie. Het kan worden gebruikt voor in‑memory rendering, maar het is niet gegarandeerd dat het blijft als een bewerkbare [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) na het opslaan en opnieuw openen van PPTX. Geef de voorkeur aan [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) voor blijvende helderheids‑ en contrast‑aanpassingen.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan naar PPT kan niet‑ondersteunde operaties weglaten, een keten reduceren tot een ondersteunde subset, of het uiterlijk benaderen. Gebruik PPT niet als verificatie‑formaat voor een complexe bewerkbare keten.
- Renderen naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele output past de ondersteunde keten toe op het gerenderde uiterlijk. Deze uitvoerbestanden bevatten geen bewerkbare `IImageTransformOperationCollection`; rasterformaten flatten het resultaat naar pixels, en document‑/vector‑exports slaan hun eigen renderrepresentatie op.
- Effecten maken een gekoppelde afbeelding niet zelfvoorzienend. Het renderen van een gekoppelde afbeelding blijft afhankelijk van de beschikbaarheid van de gekoppelde bron wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen randgevallen verschillend renderen, vooral wanneer meerdere alfa‑ of kleur‑kwantisatie‑operaties worden gecombineerd. Voor kritieke output, test zowel de bewerkbare round‑trip als het uiteindelijke exportformaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Veranderen beeldtransformatie‑effecten de ingebedde afbeeldingsgegevens?**

Nee. De operaties behoren tot de `ISlidesPicture` die door de afbeeldingsvulling wordt gebruikt. De onderliggende `IPPImage`‑bytes blijven ongewijzigd.

**Zullen twee afbeeldingsframes die dezelfde afbeelding hergebruiken hun effecten delen?**

Nee. Het hergebruiken van een `IPPImage` voorkomt dubbele afbeeldingsdata, maar elk afbeeldingsframe heeft normaal een aparte `ISlidesPicture` en een eigen beeldtransformatie‑collectie.

**Kunnen kleur-, onscherpte‑ en alfa‑effecten worden gecombineerd?**

Ja. De collectie accepteert ze in één geordende keten. Overweeg wat elke operatie doet met de output van de vorige, omdat vervangings‑ en drempel‑operaties eerdere kleur‑ of alfade details kunnen weggooien.

**Waarom zijn effectieve waarden alleen‑lees?**

Effectieve data vertegenwoordigt berekende waarden die voor rendering worden gebruikt, inclusief opgeloste kleuren. Bewerk de operatie die in de transform‑collectie is opgeslagen wanneer er schrijfbare leden bestaan; verwijder anders de operatie en voeg een vervanging toe met nieuwe creatie‑parameters.

**Welk formaat moet ik gebruiken om een transform‑keten te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Legacy PPT kan het volledige DrawingML‑effectmodel niet weergeven, en gerenderde exportformaten behouden alleen het uiterlijk, niet bewerkbare transform‑operaties.