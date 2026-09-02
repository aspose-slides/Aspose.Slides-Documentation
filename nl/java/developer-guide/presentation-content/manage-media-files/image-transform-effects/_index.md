---
title: Beheer afbeeldingstransformatie‑effecten in presentaties met Java
linktitle: Afbeeldingstransformatie‑effecten
type: docs
weight: 11
url: /nl/java/image-transform-effects/
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
- alfabeffect
- effectketen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Pas afbeeldingstransformatie‑effecten toe, combineer, inspecteer, verwijder en verifieer ze voor afbeeldingframes met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides vertegenwoordigt afbeeldingaanpassingen als een geordende collectie van beeldtransformatie‑bewerkingen. Voor een afbeeldingframe begin met het frame‑s ISlidesPicture en haal [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidespicture/#getImageTransform--) op. De geretourneerde [IImageTransformOperationCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/) laat je effecten toevoegen, opsommen, inspecteren, verwijderen en wissen zonder de originele afbeeldingsbytes opnieuw te schrijven.

Dit artikel laat een volledige workflow zien voor helderheid en contrast, kleurtransformaties, onscherpte, transparantie, geordende effectketens, effectieve waarden, verwijdering en PPTX‑round‑trip‑verificatie.

## **Begrijp eigendom van effecten en hergebruik van afbeeldingen**

Een afbeeldingsbron en de afbeelding die deze weergeeft zijn verschillende objecten:

- [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) slaat de bronafbeeldingsdata op of verwijst ernaar en behoort tot de presentatie.
- [ISlidesPicture](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidespicture/) maakt deel uit van een afbeelding‑vulling en verwijst naar een afbeeldingsbron terwijl het de afbeeldingstransformatie‑collectie opslaat.
- [IPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframe/) is de dia‑vorm die de betreffende afbeelding‑vulling, geometrie, uitsnijdinstellingen en andere frame‑niveau opmaak bezit.

Daarom wijzigen beeldtransformatie‑bewerkingen de bytes in [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) niet. Wanneer dezelfde `IPPImage` meer dan één keer wordt doorgegeven aan [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-), krijgt elk nieuw afbeeldingframe zijn eigen `ISlidesPicture` en zijn eigen transformatie‑collectie. Het toepassen van grijstinten op één frame maakt de andere frames niet grijs, hoewel ze allemaal dezelfde ingebedde afbeeldingsbron hergebruiken.

Hetzelfde `ISlidesPicture.getImageTransform`‑model wordt ook gebruikt door andere afbeeldingvullingen, zoals een vorm‑ of dia‑achtergrond. De onderstaande voorbeelden richten zich op afbeeldingframes.

## **Gebruik geldige parameterbereiken en eenheden**

De getoonde methoden gebruiken de volgende semantische bereiken en eenheden. Houd waarden binnen deze bereiken, zelfs als een bepaalde bibliotheekversie een ongeldige waarde niet onmiddellijk afwijst; het doelpresentatie‑formaat kan tijdens opslaan of bij openen door PowerPoint normaliseren, weglaten of ongeldige data afwijzen.

| Bewerkingen | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat de component ongewijzigd. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Geen | Geen numerieke parameters. Alfa blijft ongewijzigd. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Twee kleuren voor donkere en lichte pixels. RGB‑ en alfachannelen in `java.awt.Color` gebruiken `0` tot `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Tint is `0` inclusief tot `360` exclusief, in graden; hoeveelheid is `-100` tot `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Tint is `0` inclusief tot `360` exclusief, in graden; verzadiging en luminantie zijn `-100` tot `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | De vervangingskleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alfabwaarden blijven ongewijzigd. |
| [addBlurEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radius is niet‑negatief en wordt gemeten in punten; `grow` is een Boolean die bepaalt of onscherpe inhoud buiten de oorspronkelijke grenzen mag uitsteken. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Niet‑negatief procent. Gebruik `0` tot `100` voor gebruikelijke opacity‑schaling: `0` is volledig transparant en `100` behoudt de bestaande alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` tot `100`, procent opacity. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` tot `100`, procent alfabdrempel. Waarden lager worden transparant; waarden op of boven de drempel worden ondoorzichtig. |

Voor vaste alfabmodulatie zijn transparantie en opacity complementair. Bijvoorbeeld, 35 % transparantie komt overeen met een alfabmodulatie‑hoeveelheid van 65 %.

## **Pas helderheid en contrast toe**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) geeft een [IBrightnessContrast](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibrightnesscontrast/) bewerking terug. De scalare instellingen worden opgegeven bij het aanmaken van de bewerking. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) retourneert berekende alleen‑lezen waarden die kunnen worden geïnspecteerd of gelogd.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 % en rendert vervolgens een voorbeeld zonder de ingebedde afbeelding te wijzigen:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

[BrightnessContrast](https://reference.aspose.com/slides/nl/java/com.aspose.slides/brightnesscontrast/) is een Office 2010‑afbeeldingseffect‑extensie en minder draagbaar dan het standaard DrawingML‑luminantie‑effect. Wanneer helderheid en contrast bewerkbaar moeten blijven na een PPTX‑round‑trip, gebruik dan [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) en verifieer het resultaat na het opnieuw openen van het bestand. De sectie over format‑beperkingen legt dit onderscheid uitgebreider uit.

## **Pas kleurtransformaties toe**

Kleureffecten kunnen onafhankelijk worden toegepast op verschillende afbeeldingframes die dezelfde afbeeldingsbron hergebruiken. Het volgende voorbeeld maakt vijf frames en past grijstinten, duotoon, tint, HSL‑aanpassing en kleurvervanging toe.

[IDuotone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iduotone/) bevat twee onafhankelijk bewerkbare kleurparameters: `color1` mappt donkere pixels, terwijl `color2` lichte pixels mappt. Dit maakt het een nuttig voorbeeld van een effect waarvan de instellingen complexer zijn dan een enkel scalair waarde.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) vervangt elke pixelkleur door één vaste kleur terwijl alfa behouden blijft. Het verschilt van [addColorChangeEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), dat één bronkleur naar een andere mapt en zowel bron‑ als doelkleurformaten blootlegt.

## **Voeg onscherpte, transparantie en alfadeffecten toe**

[addBlurEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) beïnvloedt alle kleurkanalen, inclusief alfa. Stel `grow` in op `true` wanneer de onscherpe rand buiten de oorspronkelijke afbeeldingsgrenzen mag uitstrekken.

Voor uniforme transparantie, gebruik [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Het vermenigvuldigt elke bestaande alfabwaarde, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) wijst in plaats daarvan één alfabwaarde toe aan alle pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) zet alfa om naar twee niveaus op basis van een drempel.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Andere effect‑bewerkingen zonder parameters omvatten [addAlphaCeilingEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) die elke niet‑nul alfa volledig ondoorzichtig maakt; [addAlphaFloorEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) die elke alfa onder 100 % volledig transparant maakt; en [addAlphaInverseEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) die alfa verandert naar `100% - alpha`.

## **Bouw een geordende effectketen**

Elke `add...Effect`‑methode voegt een nieuwe bewerking toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de output van bewerking 0 wordt de input van bewerking 1, enzovoort. Daardoor kan dezelfde reeks bewerkingen in een andere volgorde een ander beeld opleveren.

Bijvoorbeeld, grijstinten gevolgd door tint verwijdert eerst chromatische informatie en kleurt daarna het luminantie‑resultaat. Tint gevolgd door grijstinten verwijdert de tint weer. Evenzo kan alfabvervanging alfabwaarden die door eerdere bewerkingen zijn berekend overschrijven, terwijl alfabmodulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier bewerkingen, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de bewerkingstypen als hun volgorde, en rendert het heropende resultaat:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

De collectie legt geen compatibiliteitsmatrix op die kleur‑, alfab‑ en onscherpte‑bewerkingen tot afzonderlijke ketens beperkt. Ze kunnen gecombineerd worden, maar combinaties zijn niet altijd zinvol. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleur‑effecten is gecreëerd; grijstinten na duotoon verwijderen de twee geselecteerde kleuren; en alfab‑ceil, floor, replacement of bi‑level‑bewerkingen kunnen alfab‑detail dat eerder is gecreëerd verwerpen. Bouw de keten op volgens de gewenste pixel‑verwerkingsvolgorde in plaats van de items te zien als ongeordende opmaak‑vlaggen.

## **Inspecteer bewerkbare en effectieve waarden**

Een bewerkbare bewerking is het object dat is opgeslagen in `ISlidesPicture.getImageTransform`. Afhankelijk van het effect kan het direct schrijfbare leden blootleggen. Bijvoorbeeld, [IBlur](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iblur/) onthult schrijfbare `radius`‑ en `grow`‑waarden, [IAlphaModulateFixed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ialphamodulatefixed/) onthult een schrijfbare `amount`, en [IAlphaBiLevel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ialphabilevel/) onthult een schrijfbare `threshold`. Kleur‑effecten zoals [IDuotone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iduotone/) onthullen mutabele [IColorFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icolorformat/) objecten.

Sommige bewerkings‑interfaces, waaronder [IBrightnessContrast](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itint/) en [IAlphaReplace](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ialphareplace/), onthullen hun creatiescalaren niet als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijder je de bewerking en voeg je een vervanging toe op de vereiste positie.

Effectieve data die door `getEffective()` wordt geretourneerd, zijn berekend en alleen‑lezen. Ze zijn nuttig voor het oplossen van themagerelateerde kleuren en het lezen van de genormaliseerde waarden die de renderer gebruikt, maar vormen geen tweede bewerkingsoppervlak. Het volgende voorbeeld loopt de keten door en inspecteert effectieve waarden waar de bijbehorende API ze levert:

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

Effect‑vrije bewerkingen zoals grijstinten, alfab‑ceil en alfab‑inverse hebben nog steeds een effectieve‑data‑object, maar er zijn geen scalare instellingen om af te drukken. Hun aanwezigheid en positie in de collectie zijn de belangrijke informatie.

## **Verwijder of wis afbeeldingstransformaties**

Gebruik [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) om één bewerking op index te verwijderen. Omdat indexen verschuiven na het verwijderen, zoek eerst naar het doel en verwijder het daarna na het doorlopen. Gebruik [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imagetransformoperationcollection/#clear--) om de gehele keten te verwijderen.

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

Het verwijderen of wissen van transformaties verandert alleen de afbeelding‑opmaak. Het verwijdert, recomprimeert of wijzigt de hergebruikte [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) bron niet.

## **Overweeg presentatieformaten en exportdoelen**

Afbeeldingstransformaties ontstaan in DrawingML, dus PPTX is het voorkeurs‑bewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke bewerking identieke draagbaarheid:

- Standaard DrawingML‑bewerkingen zoals luminantie, grijstinten, duotoon, tint, HSL, onscherpte en gemeenschappelijke alfab‑bewerkingen hebben de grootste kans om een PPTX‑round‑trip te overleven. Open altijd het gegenereerde bestand opnieuw en inspecteer de collectie wanneer behoud een vereiste is.
- [BrightnessContrast](https://reference.aspose.com/slides/nl/java/com.aspose.slides/brightnesscontrast/) is een Office 2010‑extensie in plaats van de standaard DrawingML‑luminantie‑bewerking. Het kan worden gebruikt voor in‑memory rendering, maar garandeert niet dat het na opslaan en heropenen van PPTX bewerkbaar blijft als een [IBrightnessContrast](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibrightnesscontrast/). Geef de voorkeur aan [addLuminanceEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) voor blijvende helderheids‑ en contrast‑aanpassingen.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan naar PPT kan niet‑ondersteunde bewerkingen weglaten, een keten tot een ondersteunde subset reduceren, of het uiterlijk benaderen. Gebruik PPT niet als verificatieformaat voor een complexe bewerkbare keten.
- Renderen naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele output past de ondersteunde keten toe op het gerenderde uiterlijk. Deze uitvoer bevat geen bewerkbare `IImageTransformOperationCollection`; rasterformaten vlakt het resultaat af tot pixels, en document‑/vector‑exports slaan hun eigen renderrepresentatie op.
- Effecten maken een gelinkte afbeelding niet zelfstandig. Het renderen van een gelinkte afbeelding blijft afhankelijk van de beschikbaarheid van de gelinkte bron wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen randgevallen verschillend renderen, vooral wanneer meerdere alfab‑ of kleur‑kwantisatie‑bewerkingen worden gecombineerd. Voor kritieke output, test zowel de bewerkbare round‑trip als het uiteindelijke exportformaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Wijzigen afbeeldingstransformatie‑effecten de ingebedde afbeeldingsdata?**

Nee. De bewerkingen behoren tot de `ISlidesPicture` die door de afbeelding‑vulling wordt gebruikt. De onderliggende `IPPImage`‑bytes blijven ongewijzigd.

**Delen twee afbeeldingframes die dezelfde afbeelding hergebruiken hun effectinstellingen?**

Nee. Het hergebruiken van een `IPPImage` voorkomt dubbele afbeeldingsdata, maar elk afbeeldingframe heeft normaal gesproken een afzonderlijk `ISlidesPicture` en een afzonderlijke transformatie‑collectie.

**Kunnen kleur‑, onscherpte‑ en alfab‑effecten gecombineerd worden?**

Ja. De collectie accepteert ze in één geordende keten. Houd rekening met wat elke bewerking doet met de output van de vorige, omdat vervangings‑ en drempel‑bewerkingen eerdere kleur‑ of alfab‑detail kunnen verwerpen.

**Waarom zijn effectieve waarden alleen‑lezen?**

Effectieve data vertegenwoordigt berekende waarden die voor het renderen worden gebruikt, inclusief opgeloste kleuren. Bewerk de bewerking die in de transformatie‑collectie is opgeslagen waar schrijfbare leden bestaan; verwijder anders de bewerking en voeg een vervanging toe met nieuwe creatie‑parameters.

**Welk formaat moet ik gebruiken om een transformatie‑keten te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Het legacy‑PPT‑formaat kan het volledige DrawingML‑effectmodel niet representeren, en gerenderde exportformaten behouden alleen het uiterlijk, niet bewerkbare transformatie‑bewerkingen.