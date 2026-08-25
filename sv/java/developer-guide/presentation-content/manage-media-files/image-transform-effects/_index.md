---
title: Hantera bildtransformeringseffekter i presentationer med Java
linktitle: Bildtransformeringseffekter
type: docs
weight: 11
url: /sv/java/image-transform-effects/
keywords:
- bildtransformering
- bildeffekt
- ljusstyrka
- kontrast
- gråskala
- duoton
- nyans
- HSL
- färgersättning
- oskärpa
- transparens
- alfaeffekt
- effektkedja
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Applicera, kedja, inspektera, ta bort och verifiera bildtransformeringseffekter för bildramar med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides representerar bildjusteringar som en ordnad samling av bildtransformationsoperationer. För en bildram, börja med ramens [ISlidesPicture](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidespicture/) och få åtkomst till [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidespicture/#getImageTransform--). Den returnerade [IImageTransformOperationCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/) låter dig lägga till, enumerera, inspektera, ta bort och rensa effekter utan att skriva om de ursprungliga bildbyterna.

Denna artikel demonstrerar ett komplett arbetsflöde för ljusstyrka och kontrast, färgtransformeringar, oskärpa, transparens, ordnade effektkedjor, effektiva värden, borttagning och PPTX‑rundresesverifiering.

## **Förstå effektägarskap och bildåteranvändning**

- [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ippimage/) lagrar eller refererar källbilddata som ägs av presentationen.  
- [ISlidesPicture](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidespicture/) tillhör en bildfyllning och refererar till en bildresurs samtidigt som den lagrar samlingen av bildtransformeringar.  
- [IPictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipictureframe/) är slide‑formen som äger den relevanta bildfyllningen, geometri, beskärningsinställningar och annan ram‑nivåformatering.  

Alltså modifierar bildtransformationsoperationer inte byten i [IPPImage]. När samma `IPPImage` skickas till [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) fler än en gång, får varje ny bildram sin egen `ISlidesPicture` och sin egen transform‑samling. Att applicera gråskala på en ram gör inte de andra ramarna gråskala, även om alla återanvänder samma inbäddade bildresurs.

Samma `ISlidesPicture.getImageTransform`‑modell används också av andra bildfyllningar, som en form eller slide‑bakgrund. Exemplen nedan fokuserar på bildramar.

## **Använd giltiga parametrarange och enheter**

De demonstrerade metoderna använder följande semantiska intervall och enheter. Håll värden inom dessa intervall även om ett specifikt biblioteksversion inte omedelbart avvisar varje värde utanför intervallet; målpresentationens format kan normalisera, utelämna eller avvisa ogiltiga data vid sparning eller när PowerPoint öppnar filen.

| Operation | Parametrar | Giltigt intervall och enhet |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` till `100`, procent; `0` lämnar komponenten oförändrad. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Ingen | Inga numeriska parametrar. Alfa förblir oförändrad. |
| [addDuotoneEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Två färger för mörka och ljusa pixlar. RGB‑ och alfakanaler i `java.awt.Color` använder `0` till `255`. |
| [addTintEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Nyans är `0` inklusiv till `360` exklusiv, i grader; mängd är `-100` till `100`, i procent. |
| [addHSLEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Nyans är `0` inklusiv till `360` exklusiv, i grader; mättnad och luminans är `-100` till `100`, i procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Ersättningsfärgen använder kanalvärden från `0` till `255`. Befintliga alfavärden förblir oförändrade. |
| [addBlurEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radien är icke‑negativ och mäts i punkter; `grow` är en Boolesk variabel som styr om suddigt innehåll får sträcka sig utanför de ursprungliga gränserna. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Icke‑negativ procent. Använd `0` till `100` för vanlig opacitets­skalning: `0` är helt transparent och `100` bevarar befintlig alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` till `100`, procent opacitet. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` till `100`, procent alfa‑tröskel. Värden under blir transparenta; värden på eller över blir ogenomskinliga. |

För fast alfa‑modulering är transparens och opacitet komplementära. Till exempel motsvarar 35 % transparens ett alfa‑moduleringsvärde på 65 %.

## **Tillämpa ljusstyrka och kontrast**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) returnerar en [IBrightnessContrast](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibrightnesscontrast/)‑operation. Dess skalära inställningar anges när operationen skapas. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) returnerar beräknade skrivskyddade värden som kan inspekteras eller loggas.

Följande exempel ökar ljusstyrkan med 15 % och kontrasten med 20 %, och renderar sedan en förhandsgranskning utan att ändra den inbäddade bilden:

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

[BrightnessContrast](https://reference.aspose.com/slides/sv/java/com.aspose.slides/brightnesscontrast/) är ett Office 2010‑bild‑effekt‑tillägg och är mindre portabelt än den standardiserade DrawingML‑luminanseffekten. När ljusstyrka och kontrast måste förbli redigerbara efter en PPTX‑rundresa, använd [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) och verifiera resultatet efter att filen har öppnats igen. Avsnittet om formatbegränsningar förklarar detta närmare.

## **Tillämpa färgtransformeringar**

Färgeffekter kan appliceras oberoende på olika bildramar som återanvänder en bildresurs. Följande exempel skapar fem ramar och applicerar gråskala, duotone, nyans, HSL‑justering och färgbyte.

[IDuotone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iduotone/) innehåller två oberoende redigerbara färgparametrar: `color1` mappar mörka pixlar, medan `color2` mappar ljusa pixlar. Detta gör det till ett användbart exempel på en effekt vars inställningar är mer komplexa än ett enskilt skalärt värde.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) ersätter varje pixels färg med en fast färg samtidigt som alfa bevaras. Det skiljer sig från [addColorChangeEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), som mappar en källfärg till en annan och exponerar både käll‑ och målformat för färger.

## **Lägg till oskärpa, transparens och alfa‑effekter**

[addBlurEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) påverkar alla färgkanaler, inklusive alfa. Sätt `grow` till `true` när den suddiga kanten kan sträcka sig utanför den ursprungliga bildens gränser.

För enhetlig transparens, använd [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Den multiplicerar varje befintligt alfavärde, så delvis transparenta pixlar förblir proportionellt olika. [addAlphaReplaceEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) tilldelar istället ett alfavärde till alla pixlar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) konverterar alfa till två nivåer baserat på en tröskel.

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

Andra alfa‑operationer utan parametrar inkluderar [addAlphaCeilingEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), som gör varje icke‑noll alfa helt ogenomskinlig; [addAlphaFloorEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), som gör varje alfa under 100 % helt transparent; och [addAlphaInverseEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), som ändrar alfa till `100% - alpha`.

## **Bygg en ordnad effektkedja**

Varje `add...Effect`‑metod lägger till en ny operation i slutet av samlingen. Renderaren använder samlingen som en ordnad pipeline: utdata från operation 0 blir indata till operation 1, och så vidare. Följaktligen kan samma operationer i en annan ordning producera en annan bild.

Följande exempel bygger en kedja med fyra operationer, sparar den som PPTX, öppnar presentationen igen, kontrollerar både operationstyperna och deras ordning, och renderar det återöppnade resultatet:

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

Samlingen påför ingen kompatibilitetsmatris som begränsar färg‑, alfa‑ och oskärpeoperationer till separata kedjor. De kan kombineras, men kombinationer är inte alltid användbara. Ett fast färgbyte tar bort RGB‑variation producerad av tidigare färgeffekter; gråskala efter duotone tar bort de två valda färgerna; och alfa‑ceiling, floor, replacement eller bi‑level‑operationer kan eliminera alfa‑detalj som skapats tidigare. Bygg kedjan enligt den önskade pixel‑bearbetningssekvensen snarare än att behandla dess objekt som oordnade formateringsflaggor.

## **Inspektera redigerbara och effektiva värden**

En redigerbar operation är objektet som lagras i `ISlidesPicture.getImageTransform`. Beroende på effekten kan den direkt exponera skrivbara medlemmar. Till exempel exponerar [IBlur](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iblur/) skrivbara `radius`‑ och `grow`‑värden, [IAlphaModulateFixed](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ialphamodulatefixed/) ett skrivbart `amount`, och [IAlphaBiLevel](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ialphabilevel/) ett skrivbart `threshold`. Färgeffekter som [IDuotone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iduotone/) exponeras som muterbara [IColorFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icolorformat/)‑objekt.

Några operationsgränssnitt, inklusive [IBrightnessContrast](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itint/), och [IAlphaReplace](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ialphareplace/), exponerar inte deras skapande skalärvärden som skrivbara egenskaper. För att ändra dessa inställningar, ta bort operationen och lägg till en ersättning på den önskade positionen.

Effektiv data som returneras av `getEffective()` är beräknad och skrivskyddad. Den är användbar för att lösa temaberoende färger och läsa de normaliserade värden som renderaren använder, men den är inte en annan redigeringsyta. Följande exempel enumererar kedjan och inspekterar effektiva värden där motsvarande API tillhandahåller dem:

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

Parameterfria effekter såsom gråskala, alfa‑ceiling och alfa‑inverse har fortfarande ett effektiva‑datatobjekt, men det finns inga skalära inställningar att skriva ut. Deras förekomst och position i samlingen är den viktiga informationen.

## **Ta bort eller rensa bildtransformeringar**

Använd [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) för att ta bort en operation efter index. Eftersom index skiftar efter borttagning, sök först efter målet och ta sedan bort det efter enumeration. Använd [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imagetransformoperationcollection/#clear--) för att ta bort hela kedjan.

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

Att ta bort eller rensa transformeringar ändrar endast bildformateringen. Det tar inte bort, komprimerar om eller på annat sätt ändrar den återanvända [IPPImage]-resursen.

## **Överväg presentationsformat och exportmål**

Bildtransformeringar har sitt ursprung i DrawingML, så PPTX är det föredragna redigerbara formatet för effektkedjor. Även med PPTX har inte varje operation identisk portabilitet:

- Standard‑DrawingML‑operationer såsom luminans, gråskala, duotone, nyans, HSL, oskärpa och vanliga alfa‑operationer har störst chans att överleva en PPTX‑rundresa. Öppna alltid den genererade filen igen och inspektera samlingen när bevarande är ett krav.  
- [BrightnessContrast] är ett Office 2010‑tillägg snarare än den standardiserade DrawingML‑luminanseffekten. Den kan användas för rendering i minnet, men den garanteras inte att förbli en redigerbar [IBrightnessContrast] efter att PPTX har sparats och öppnats igen. Föredra [addLuminanceEffect] för bestående ljusstyrke‑ och kontrastjusteringar.  
- Det binära PPT‑formatet föregick den fullständiga DrawingML‑effektmodellen. Att spara till PPT kan utelämna icke‑stödda operationer, reducera en kedja till ett stödjande delmängd eller approximera utseendet. Använd inte PPT som verifieringsformat för en komplex redigerbar kedja.  
- Rendering till PNG, JPEG, TIFF, PDF, SVG, HTML eller annan visuell output applicerar den stödjade kedjan på den renderade bilden. Dessa utdata innehåller inte en redigerbar `IImageTransformOperationCollection`; rasterformat plattar ut resultatet till pixlar, och dokument‑/vektor‑exporter lagrar sin egen renderingsrepresentation.  
- Effekter gör inte en länkad bild självförsörjande. Rendering av en länkad bild beror fortfarande på att den länkade resursen är tillgänglig när presentationen laddas.  

Olika presentation‑klienter kan rendera kantfall olika, särskilt när flera alfa‑ eller färg‑kvantiseringsoperationer kombineras. För kritisk output, testa både den redigerbara rundresan och det slutgiltiga exportformatet med samma Aspose.Slides‑version som används i produktion.

## **FAQ**

**Modifierar bildtransformeringseffekter den inbäddade bilddatan?**

Nej. Operationerna tillhör `ISlidesPicture` som används av bildfyllningen. De underliggande `IPPImage`‑byten förblir oförändrade.

**Kommer två bildramar som återanvänder samma bild att dela sina effekter?**

Nej. Återanvändning av ett `IPPImage` undviker duplicerad bilddata, men varje bildram har normalt en separat `ISlidesPicture` och bildtransformeringssamling.

**Kan färg-, oskärpa‑ och alfa‑effekter kombineras?**

Ja. Samlingen accepterar dem i en ordnad kedja. Tänk på vad varje operation gör med outputen från föregående, eftersom ersättnings‑ och tröskeloperationer kan kassera tidigare färg‑ eller alfabitar.

**Varför är effektiva värden skrivskyddade?**

Effektiv data representerar beräknade värden som används för rendering, inklusive lösta färger. Redigera den operation som lagras i transform‑samlingen där skrivbara medlemmar finns; annars ta bort den och lägg till en ersättning med nya skapandeparametrar.

**Vilket format bör jag använda för att bevara en transformkedja?**

Använd PPTX och verifiera filen genom att öppna den igen. Äldre PPT kan inte representera den fullständiga DrawingML‑effektmodellen, och renderade exportformat bevarar endast utseendet snarare än redigerbara transform‑operationer.