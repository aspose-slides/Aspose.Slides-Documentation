---
title: Beheer afbeeldingstransformatie‑effecten in presentaties met Java
linktitle: Afbeeldingstransformatie‑effecten
type: docs
weight: 11
url: /nl/java/image-transform-effects/
keywords:
- afbeeldingstransformatie
- beeld‑effect
- helderheid
- contrast
- grijstinten
- duotoon
- tint
- HSL
- kleurvervanging
- vervaging
- transparantie
- alfa‑effect
- effectketen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Pas afbeeldingstransformatie‑effecten toe, koppel ze, inspecteer, verwijder en verifieer ze voor afbeeldingskaders met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides vertegenwoordigt afbeeldingaanpassingen als een geordende collectie beeldtransformatie‑operaties. Voor een afbeeldingskader begin je met het kader's [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) en krijg je toegang tot [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--). De geretourneerde [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) laat je toe om effecten toe te voegen, te enumereren, te inspecteren, te verwijderen en te wissen zonder de originele afbeeldingsbytes opnieuw te schrijven.

Dit artikel toont een volledige werkwijze voor helderheid en contrast, kleurtransformaties, vervaging, transparantie, geordende effectketens, effectieve waarden, verwijderen en PPTX round‑trip verificatie.

## **Begrijp eigendom van effecten en hergebruik van afbeeldingen**

Een afbeeldingsbron en de afbeelding die deze weergeeft zijn verschillende objecten:

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) slaat de bronafbeeldingsgegevens op of verwijst ernaar en behoort toe aan de presentatie.
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) maakt deel uit van een afbeeldingenvulling en verwijst naar een afbeeldingsbron terwijl het de beeldtransformatie‑collectie opslaat.
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) is de dia‑vorm die de bijbehorende afbeeldingenvulling, geometrie, uitsnijdinstellingen en andere kadrage‑opmaak bezit.

Daarom wijzigen beeldtransformatie‑operaties de bytes in [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) niet. Wanneer dezelfde `IPPImage` meer dan één keer aan [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) wordt doorgegeven, krijgt elk nieuw afbeeldingskader zijn eigen `ISlidesPicture` en eigen transformatie‑collectie. Het toepassen van grijstinten op één kader maakt de andere kaders niet grijs, ook al gebruiken ze allemaal dezelfde ingebedde afbeeldingsbron.

Hetzelfde `ISlidesPicture.getImageTransform`‑model wordt ook gebruikt door andere afbeeldingenvullingen, zoals een vorm of dia‑achtergrond. De onderstaande voorbeelden zijn gericht op afbeeldingskaders.

## **Gebruik geldige parameterbereiken en eenheden**

De gedemonstreerde methoden gebruiken de volgende semantische bereiken en eenheden. Houd waarden binnen deze bereiken, zelfs als een specifieke bibliotheekversie niet meteen elke out‑of‑range‑waarde afwijst; het doelformaat van de presentatie kan ongeldige gegevens normaliseren, weglaten of afwijzen tijdens het opslaan of wanneer PowerPoint het bestand opent.

| Operatie | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat de component ongewijzigd. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Geen | Geen numerieke parameters. Alfa blijft ongewijzigd. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Twee kleuren voor donkere en lichte pixels. RGB‑ en alfacanalen in `java.awt.Color` gebruiken `0` tot `255`. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Tint (`hue`) is `0` inclusief tot `360` exclusief, in graden; hoeveelheid (`amount`) is `-100` tot `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Tint (`hue`) is `0` inclusief tot `360` exclusief, in graden; verzadiging en luminantie zijn `-100` tot `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | De vervangingskleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alfabewerkingen blijven ongewijzigd. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Straal is niet‑negatief en wordt gemeten in points; `grow` is een Boolean die bepaalt of vervaagd beeld buiten de oorspronkelijke grenzen mag uitsteken. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Niet‑negatief procent. Gebruik `0` tot `100` voor gewone opacity‑schaal: `0` is volledig transparant en `100` behoudt de bestaande alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` tot `100`, procent opacity. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` tot `100`, procent alfabdrempel. Waarden eronder worden transparant; waarden gelijk aan of hoger worden ondoorzichtig. |

Voor vaste alfabemodulatie zijn transparantie en opacity complementair. Bijvoorbeeld, 35 % transparantie komt overeen met een alfabemodulatie van 65 %.

## **Pas helderheid en contrast toe**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) retourneert een [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/)‑operatie. De scalaire instellingen worden meegegeven bij het aanmaken van de operatie. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) retourneert berekende alleen‑lezen‑waarden die ge‑inspecteerd of gelogd kunnen worden.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 %, waarna een preview wordt gerenderd zonder de ingebedde afbeelding te wijzigen:

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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) is een Office 2010‑afbeeldingseffect‑extensie en minder draagbaar dan het standaard DrawingML‑luminantie‑effect. Wanneer helderheid en contrast na een PPTX‑round‑trip bewerkbaar moeten blijven, gebruik dan [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) en controleer het resultaat na het opnieuw openen van het bestand. De sectie over formaatbeperkingen legt dit onderscheid nader uit.

## **Pas kleurtransformaties toe**

Kleureffecten kunnen onafhankelijk van elkaar op verschillende afbeeldingskaders worden toegepast die één afbeeldingsbron hergebruiken. Het volgende voorbeeld maakt vijf kaders en past grijstinten, duotone, tint, HSL‑aanpassing en kleurvervanging toe.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) bevat twee onafhankelijk bewerkbare kleurparameters: `color1` mappt donkere pixels, terwijl `color2` lichte pixels mappt. Dit maakt het een nuttig voorbeeld van een effect waarvan de instellingen complexer zijn dan een enkele scalaire waarde.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) vervangt de kleur van elke pixel door één vaste kleur, terwijl alfa wordt behouden. Het verschilt van [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), dat één bronkleur naar een andere mappt en beide kleurformaten blootlegt.

### **Pas een luminantiedrempel toe**

Een luminantiedrempel kan vage strepen op een gescande pagina beter vanaf de achtergrond laten onderscheiden. [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) behoudt tussenliggende grijstinten. [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) mappt luminantie naar zwart of wit, terwijl [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) een drempel op opacity toepast.

De luminantiedrempel varieert van 0 % tot 100 %, inclusief. Pixels onder de drempel worden zwart. Pixels gelijk aan of boven de drempel worden wit. Het verhogen van de drempel maakt meer tinten zwart omdat meer ervan onder de cutoff vallen.

Download [grayscale-swatches.png](grayscale-swatches.png) naar de werkmap. Elk label geeft het oorspronkelijke grijsniveau op een schaal van 0 tot 255 weer. Het voorbeeld plaatst het origineel naast twee kopieën en slaat de drempel van elke kopie op in de presentatie.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Open de uitvoer‑presentatie in PowerPoint om de drie kaders te vergelijken. Het kleurstaal met label 96 heeft ongeveer 38 % luminantie (96 van 255). Het wordt wit bij een drempel van 20 % en zwart bij 60 %.

![Originele grijstinten‑staal naast de zwart‑wit‑resultaten bij luminantiedrempels van 20 % en 60 %](luminance-threshold.png)

## **Voeg vervaging, transparantie en alfa‑effecten toe**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) beïnvloedt alle kleurkanalen, inclusief alfa. Stel `grow` in op `true` wanneer de vervaagde rand buiten de oorspronkelijke afbeeldingsgrenzen mag uitstrekken.

Voor uniforme transparantie, gebruik [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Het vermenigvuldigt elke bestaande alfa‑waarde, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) wijst in plaats daarvan één alfa‑waarde toe aan alle pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) converteert alfa naar twee niveaus op basis van een drempel.

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

Andere alfa‑operaties zonder parameters zijn onder meer [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), die elke niet‑nul alfa volledig ondoorzichtig maakt; [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), die elke alfa onder 100 % volledig transparant maakt; en [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), die alfa verandert naar `100 % - alpha`.

## **Bouw een geordende effectketen**

Elke `add...Effect`‑methode voegt een nieuwe operatie toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de uitvoer van operatie 0 wordt de invoer van operatie 1, enzovoort. Daarom kan hetzelfde set van operaties in een andere volgorde een ander beeld opleveren.

Zo verwijdert grijsschaal gevolgd door tint eerst chromatische informatie en kleurt vervolgens het luminantie‑resultaat opnieuw. Tint gevolgd door grijsschaal verwijdert de tint weer. Evenzo kan alfabervanging alfa‑waarden overschrijven die door eerdere operaties zijn berekend, terwijl alfabemodulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier operaties, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de operatietypen als hun volgorde, en rendert het heropende resultaat:

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

De collectie legt geen compatibiliteitsmatrix op die kleur‑, alfa‑ en vervagingsoperaties tot gescheiden ketens beperkt. Ze kunnen gecombineerd worden, maar combinaties zijn niet altijd nuttig. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleureffecten is gecreëerd; grijsschaal na duotone verwijdert de twee geselecteerde kleuren; en alfa‑ceil, floor, vervanging of bi‑level operaties kunnen alfa‑detail dat eerder is aangemaakt, verwijderen. Bouw de keten op volgens de gewenste pixel‑verwerkingsvolgorde in plaats van de items als ongeordende formatteringsvlaggen te beschouwen.


<!-- visual-explanation:image-transform-effects:start -->
[![Dezelfde afbeelding gaat eerst door grijsschaal dan tint, en tint dan grijsschaal. De twee uiteindelijke grijsschaal‑afbeeldingen hebben verschillende tinten.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In deze illustratieve Aspose.Slides for .NET 26.11‑rendering laat een tint van 220° op 25 % de grijsschaal‑afbeelding ongewijzigd. Het toepassen van dezelfde tint vóór grijsschaal levert verschillende tinten op.*
<!-- visual-explanation:image-transform-effects:end -->

## **Inspecteer bewerkbare en effectieve waarden**

Een bewerkbare operatie is het object opgeslagen in `ISlidesPicture.getImageTransform`. Afhankelijk van het effect kan het rechtstreeks schrijfbare leden blootleggen. Bijvoorbeeld, [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) toont schrijfbare `radius`‑ en `grow`‑waarden, [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) toont een schrijfbare `amount`, en [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) toont een schrijfbare `threshold`. Kleur‑effecten zoals [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) tonen mutable [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/)‑objecten.

Sommige operationele interfaces, waaronder [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/), en [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/), onthullen hun creatiescalars niet als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijder je de operatie en voeg je een vervanging toe op de vereiste positie.

Effectieve gegevens die door `getEffective()` worden geretourneerd, zijn berekend en alleen‑lezen. Ze zijn nuttig voor het oplossen van themagerelateerde kleuren en voor het lezen van de genormaliseerde waarden die de renderer gebruikt, maar vormen geen extra bewerkbare laag. Het onderstaande voorbeeld enumerateert de keten en inspecteert effectieve waarden waar de corresponderende API ze biedt:

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

Effectloze operaties zoals grijsschaal, alfa‑ceil en alfa‑inverse hebben nog steeds een effectief‑datobject, maar er zijn geen scalaire instellingen om af te drukken. Hun aanwezigheid en positie in de collectie zijn de belangrijke informatie.

## **Verwijder of wis beeldtransformaties**

Gebruik [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) om één operatie op index te verwijderen. Omdat indexen verschuiven na verwijdering, zoek eerst naar het doel en verwijder het daarna na enumeratie. Gebruik [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) om de volledige keten te verwijderen.

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

Het verwijderen of wissen van transformaties verandert alleen de opmaak van de afbeelding. Het verwijdert, comprimeert of wijzigt de hergebruikte [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) bron niet.

## **Overweeg presentatieformaten en exportdoelen**

Beeldtransformaties ontstaan in DrawingML, dus PPTX is het voorkeurs‑bewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke operatie identieke draagbaarheid:

- Standaard DrawingML‑operaties zoals luminantie, grijsschaal, duotone, tint, HSL, vervaging en algemene alfa‑operaties hebben de grootste kans om een PPTX‑round‑trip te overleven. Open altijd het gegenereerde bestand opnieuw en inspecteer de collectie wanneer behoud een vereiste is.
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) is een Office 2010‑extensie in plaats van de standaard DrawingML‑luminantie‑operatie. Het kan gebruikt worden voor in‑memory rendering, maar er is geen garantie dat het na opslaan en heropenen van PPTX bewerkbaar blijft als een [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/). Geef de voorkeur aan [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) voor blijvende helderheids‑ en contrast‑aanpassingen.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan naar PPT kan niet‑ondersteunde operaties weglaten, een keten reduceren tot een ondersteund subset, of het uiterlijk benaderen. Gebruik PPT niet als verificatie‑formaat voor een complexe bewerkbare keten.
- Rendering naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele output past de ondersteunde keten toe op het gerenderde uiterlijk. Die uitvoer bevat geen bewerkbare `IImageTransformOperationCollection`; rasterformaten flattenen het resultaat naar pixels, en document‑/vector‑exports slaan hun eigen renderingsrepresentatie op.
- Effecten maken een gekoppelde afbeelding niet zelf‑containend. Het renderen van een gekoppelde afbeelding blijft afhankelijk van de beschikbaarheid van de gekoppelde bron wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen randgevallen anders renderen, vooral wanneer meerdere alfa‑ of kleur‑kwantisering‑operaties worden gecombineerd. Voor kritische output test zowel de bewerkbare round‑trip als het uiteindelijke exportformaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Wijzigen beeldtransformatie‑effecten de ingebedde afbeeldingsdata?**

Nee. De operaties behoren tot de `ISlidesPicture` die door de afbeeldingenvulling wordt gebruikt. De onderliggende `IPPImage`‑bytes blijven ongewijzigd.

**Willen twee afbeeldingskaders die dezelfde afbeelding hergebruiken elkaars effecten delen?**

Nee. Het hergebruiken van een `IPPImage` voorkomt dubbele afbeeldingsdata, maar elk afbeeldingskader heeft normaal gesproken een eigen `ISlidesPicture` en eigen beeldtransformatie‑collectie.

**Kunnen kleur‑, vervaging‑ en alfa‑effecten worden gecombineerd?**

Ja. De collectie accepteert ze in één geordende keten. Houd rekening met wat elke operatie doet met de output van de vorige, want vervangings‑ en drempel‑operaties kunnen eerdere kleur‑ of alfabedetails weggooien.

**Waarom zijn effectieve waarden alleen‑lezen?**

Effectieve data vertegenwoordigt berekende waarden die voor rendering worden gebruikt, inclusief opgeloste kleuren. Bewerk de operatie die in de transformatie‑collectie is opgeslagen wanneer er schrijfbare leden bestaan; anders verwijder je de operatie en voeg je een vervanging met nieuwe creatie‑parameters toe.

**Welk formaat moet ik gebruiken om een transformatie‑keten te behouden?**

Gebruik PPTX en controleer het bestand door het opnieuw te openen. Het legacy‑PPT‑formaat kan het volledige DrawingML‑effectmodel niet weergeven, en gerenderde exportformaten behouden alleen het uiterlijk, niet bewerkbare transformatie‑operaties.