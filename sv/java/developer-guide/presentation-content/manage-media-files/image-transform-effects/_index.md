---
title: Hantera bildtransformeringseffekter i presentationer med Java
linktitle: Bildtransformeringseffekter
type: docs
weight: 11
url: /sv/java/image-transform-effects/
keywords:
- bildtransformering
- bild effekt
- ljusstyrka
- kontrast
- gråskala
- duoton
- färgton
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
description: "Applicera, kedja ihop, inspektera, ta bort och verifiera bildtransformeringseffekter för bildramar med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides representerar bildjusteringar som en ordnad samling av bildtransformationsoperationer. För en bildram, börja med ramens [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) och får åtkomst till [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--). Den returnerade [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) låter dig lägga till, enumerera, inspektera, ta bort och rensa effekter utan att skriva om de ursprungliga bildbytena.

Den här artikeln visar ett komplett arbetsflöde för ljusstyrka och kontrast, färgtransformeringar, oskärpa, transparens, ordnade effektkedjor, effektiva värden, borttagning och PPTX‑rundresa‑verifiering.

## **Förstå effektägande och återanvändning av bilder**

En bildresurs och den bild som visar den är olika objekt:

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) lagrar eller refererar källbilddata som ägs av presentationen.
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) tillhör en bildfyllning och pekar på en bildresurs samtidigt som den lagrar bildtransformationssamlingen.
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) är bildens form som äger den relevanta bildfyllningen, geometri, beskärningsinställningar och annan ram‑nivå‑formatering.

Därför modifierar bildtransformationsoperationer inte byten i [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). När samma `IPPImage` skickas till [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) mer än en gång, får varje ny bildram sin egen `ISlidesPicture` och sin egen transformssamling. Att applicera gråskala på en ram gör inte de andra ramarna gråskala, även om alla återanvänder samma inbäddade bildresurs.

Samma `ISlidesPicture.getImageTransform`‑modell används också av andra bildfyllningar, såsom en form eller bildens bakgrund. Exemplen nedan fokuserar på bildramar.

## **Använd giltiga parameterintervall och enheter**

De demonstrerade metoderna använder följande semantiska intervall och enheter. Håll värdena inom dessa intervall även om en viss biblioteks­version inte omedelbart avvisar varje värde utanför intervallet; målpresentationens format kan normalisera, utelämna eller avvisa ogiltiga data vid sparande eller när PowerPoint öppnar filen.

| Operation | Parametrar | Giltigt intervall och enhet |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` till `100`, procent; `0` lämnar komponenten oförändrad. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Ingen | Inga numeriska parametrar. Alfa förblir oförändrad. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Två färger för mörka respektive ljusa pixlar. RGB‑ och alfakanaler i `java.awt.Color` använder `0` till `255`. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Nyans är `0` inkl. till `360` exkl., i grader; mängd är `-100` till `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Nyans är `0` inkl. till `360` exkl., i grader; mättnad och luminans är `-100` till `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Ersättningsfärgen använder kanalvärden från `0` till `255`. Existerande alfavärden förblir oförändrade. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radie är icke‑negativ och mäts i punkter; `grow` är en boolesk som styr om suddad innehåll får sträcka sig utanför de ursprungliga gränserna. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Icke‑negativ procent. Använd `0` till `100` för vanlig opacitets‑skalning: `0` är helt transparent och `100` bevarar befintlig alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` till `100`, procent opacitet. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` till `100`, procent alfatröskel. Värden under blir transparenta; värden på eller över blir ogenomskinliga. |

För fast alfa‑modulering är transparens och opacitet komplementära. Till exempel motsvarar 35 % transparens en alfa‑moduleringsmängd på 65 %.

## **Applicera ljusstyrka och kontrast**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) returnerar en [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/)‑operation. Dess skalära inställningar anges när operationen skapas. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) returnerar beräknade skrivskyddade värden som kan inspekteras eller loggas.

Följande exempel ökar ljusstyrkan med 15 % och kontrasten med 20 %, och renderar sedan en förhandsgranskning utan att modifiera den inbäddade bilden:

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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) är en Office 2010‑bild‑effekt‑utökning och är mindre portabel än den standardiserade DrawingML‑luminans‑effekten. När ljusstyrka och kontrast måste förbli redigerbara efter en PPTX‑rundresa, använd [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) och verifiera resultatet efter att filen har öppnats på nytt. Avsnittet om formatbegränsningar förklarar denna skillnad mer i detalj.

## **Applicera färgtransformeringar**

Färgeffekter kan appliceras oberoende på olika bildramar som återanvänder samma bildresurs. Följande exempel skapar fem ramar och applicerar gråskala, duoton, färgton, HSL‑justering och färgbyte.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) innehåller två oberoende redigerbara färgparametrar: `color1` styr mörka pixlar, medan `color2` styr ljusa pixlar. Detta gör den till ett bra exempel på en effekt vars inställningar är mer komplexa än ett enkelt skalärt värde.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) ersätter varje pixels färg med en fast färg samtidigt som alfa bevaras. Det skiljer sig från [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), som mappar en källfärg till en annan och exponerar både käll‑ och mål‑färgformat.

### **Applicera en luminanströskel**

En luminanströskel kan göra svaga märken på en skannad sida lättare att särskilja från bakgrunden. [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) bevarar mellantoner av grått. [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) mappar luminans till svart eller vitt, medan [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) applicerar en tröskel på opacitet.

Luminanströskeln sträcker sig från 0 % till 100 %, inklusive. Pixlar under tröskeln blir svarta. Pixlar på eller över tröskeln blir vita. Att höja tröskeln gör fler nyanser svarta eftersom fler faller under gränsen.

Ladda ner [grayscale-swatches.png](grayscale-swatches.png) till arbetskatalogen. Varje etikett anger den ursprungliga grånivån på en skala från 0 till 255. Exemplet placerar originalet bredvid två kopior och sparar varje kopias tröskel i presentationen.

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

Öppna den genererade presentationen i PowerPoint för att jämföra de tre ramarna. Swatchen märkt 96 har cirka 38 % luminans (96 av 255). Den blir vit vid 20 % tröskel och svart vid 60 % tröskel.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Lägg till oskärpa, transparens och alfa‑effekter**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) påverkar alla färgkanaler, inklusive alfa. Sätt `grow` till `true` när den suddiga kanten kan sträcka sig utanför bildramens ursprungliga gränser.

För enhetlig transparens, använd [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Den multiplicerar varje befintligt alfavärde, så delvis transparenta pixlar förblir proportionellt olika. [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) tilldelar i stället ett enda alfavärde till alla pixlar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) konverterar alfa till två nivåer baserat på en tröskel.

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

Andra alfa‑operationer utan parametrar inkluderar [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) som gör varje icke‑noll alfa helt ogenomskinlig; [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) som gör varje alfa under 100 % helt transparent; och [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) som ändrar alfan till `100% - alpha`.

## **Bygg en ordnad effektkedja**

Varje `add...Effect`‑metod lägger till en ny operation sist i samlingen. Renderaren använder samlingen som en ordnad pipeline: utdata från operation 0 blir indata till operation 1, och så vidare. Följaktligen kan samma operationer i en annan ordning ge ett annat resultat.

Till exempel tar gråskala följt av färgton först bort kromatisk information och färglägger sedan luminansresultatet. Färgton följt av gråskala tar bort färgtonen igen. På liknande sätt kan alfa‑ersättning skriva över alfa‑värden beräknade av tidigare operationer, medan alfa‑modulering bevarar deras relativa skillnader.

Följande exempel bygger en kedja med fyra operationer, sparar den som PPTX, öppnar presentationen på nytt, kontrollerar både operationstyper och deras ordning, och renderar det återöppnade resultatet:

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

Samlingen påför ingen kompatibilitetsmatris som begränsar färg‑, alfa‑ och oskärpa‑operationer till separata kedjor. De kan kombineras, men kombinationerna är inte alltid användbara. En fast färg‑ersättning tar bort RGB‑variation som tidigare färgeffekter producerat; gråskala efter duoton tar bort de två valda färgerna; och alfa‑ceiling, -floor, -replacement eller -bilevel kan kasta bort alfa‑detalj som skapats tidigare. Bygg kedjan enligt den önskade pixel‑bearbetningssekvensen snarare än att behandla dess element som oordnade formateringsflaggor.

<!-- visual-explanation:image-transform-effects:start -->
[![Samma bild går först genom gråskala sedan färgton, och omvänt. De två slutgiltiga gråskalebilderna har olika toner.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*I denna illustrativa Aspose.Slides för .NET 26.11‑rendering lämnar en 220°‑färgton vid 25 % den gråskalade bilden oförändrad. Att applicera samma färgton före gråskala ger olika toner.*
<!-- visual-explanation:image-transform-effects:end -->

## **Inspektera redigerbara och effektiva värden**

En redigerbar operation är objektet som lagras i `ISlidesPicture.getImageTransform`. Beroende på effekten kan den exponera skrivbara medlemmar direkt. Till exempel exponerar [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) skrivbara `radius`‑ och `grow`‑värden, [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) en skrivbar `amount`, och [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) en skrivbar `threshold`. Färgeffekter såsom [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) exponerar muterbara [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/)-objekt.

Vissa operationsgränssnitt, inklusive [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/) och [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/), exponerar inte sina skapande‑skalärer som skrivbara egenskaper. För att ändra dessa inställningar, ta bort operationen och lägg till en ersättare på den önskade positionen.

Effektiva data som returneras av `getEffective()` är beräknade och skrivskyddade. De är användbara för att lösa temaberoende färger och läsa de normaliserade värden som renderaren använder, men de är inte en annan redigeringsyta. Följande exempel enumererar kedjan och inspekterar effektiva värden där motsvarande API tillhandahåller dem:

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

Effekter utan parametrar som gråskala, alfa‑ceiling och alfa‑inverse har fortfarande ett effekt‑data‑objekt, men det finns inga skalära inställningar att skriva ut. Deras närvaro och position i samlingen är den viktiga informationen.

## **Ta bort eller rensa bildtransformeringar**

Använd [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) för att ta bort en operation via index. Eftersom index skiftar efter en borttagning, sök först efter målet och ta sedan bort det efter enumeration. Använd [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) för att ta bort hela kedjan.

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

Att ta bort eller rensa transformeringar ändrar endast bildens formatering. Det raderar inte, komprimerar om eller ändrar på den återanvända [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)‑resursen.

## **Tänk på presentationsformat och exportmål**

Bildtransformeringar har sitt ursprung i DrawingML, så PPTX är det föredragna redigerbara formatet för effektkedjor. Även med PPTX har inte alla operationer identisk portabilitet:

- Standard‑DrawingML‑operationer såsom luminans, gråskala, duoton, färgton, HSL, oskärpa och vanliga alfa‑operationer har bäst chans att överleva en PPTX‑rundresa. Öppna alltid den genererade filen och inspektera samlingen när bevarande är ett krav.
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) är en Office 2010‑utökning snarare än den standardiserade DrawingML‑luminans‑operationen. Den kan användas för rendering i minnet, men den garanteras inte att förbli en redigerbar [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) efter sparande och återöppning av PPTX. Föredra [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) för bestående ljusstyrke‑ och kontrastjusteringar.
- Det binära PPT‑formatet föregick den fullständiga DrawingML‑effektmodellen. Att spara till PPT kan utelämna icke‑stödda operationer, reducera en kedja till ett stödjande delmängd eller approximera utseendet. Använd inte PPT som verifieringsformat för en komplex redigerbar kedja.
- Rendering till PNG, JPEG, TIFF, PDF, SVG, HTML eller andra visuella utdata applicerar den stödjade kedjan på den renderade bilden. Dessa utdata innehåller ingen redigerbar `IImageTransformOperationCollection`; rasterformat plattar ut resultatet till pixlar, och dokument‑/vektorexporter lagrar sin egen renderingsrepresentation.
- Effekter gör inte en länkad bild självförsörjande. Rendering av en länkad bild beror fortfarande på att den länkade resursen är tillgänglig när presentationen laddas.

Olika presentationsklienter kan rendera kantfall olika, särskilt när flera alfa‑ eller färg‑kvantisering‑operationer kombineras. För kritiska resultat, testa både den redigerbara rundresan och det slutgiltiga exportformatet med samma Aspose.Slides‑version som används i produktion.

## **FAQ**

**Modifierar bildtransformeringseffekter den inbäddade bilddatan?**

Nej. Operationerna tillhör den `ISlidesPicture` som används av bildfyllningen. De underliggande `IPPImage`‑bytena förblir oförändrade.

**Kommer två bildramar som återanvänder samma bild att dela sina effekter?**

Nej. Återanvändning av en `IPPImage` undviker duplicerad bilddata, men varje bildram har normalt sin egen `ISlidesPicture` och egen bildtransformationssamling.

**Kan färg‑, oskärpa‑ och alfa‑effekter kombineras?**

Ja. Samlingen accepterar dem i en ordnad kedja. Tänk på vad varje operation gör med föregående outputs, eftersom ersättnings‑ och tröskeloperationer kan kasta bort tidigare färg‑ eller alfat detaljer.

**Varför är effektiva värden skrivskyddade?**

Effektiva data representerar beräknade värden som används för rendering, inklusive lösta färger. Redigera den operation som lagras i transformssamlingen där skrivbara medlemmar finns; annars ta bort den och lägg till en ersättare med nya parametrar.

**Vilket format bör jag använda för att bevara en transformkedja?**

Använd PPTX och verifiera filen genom att öppna den på nytt. Äldre PPT kan inte representera hela DrawingML‑effektmodellen, och renderade exportformat bevarar bara utseendet snarare än redigerbara transformoperationer.