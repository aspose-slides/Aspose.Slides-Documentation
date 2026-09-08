---
title: Hantera bildtransformeringseffekter i presentationer med Python
linktitle: Bildtransformeringseffekter
type: docs
weight: 11
url: /sv/python-java/image-transform-effects/
keywords:
- bildtransformering
- bildeffekt
- ljusstyrka
- kontrast
- gråskala
- duoton
- nyans
- HSL
- färgbyte
- oskärpa
- genomskinlighet
- alfaeffekt
- effektkedja
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Applicera, kedja, inspektera, ta bort och verifiera bildtransformeringseffekter för bildramar med Aspose.Slides för Python via Java."
---
## **Översikt**

Aspose.Slides representerar bildjusteringar som en ordnad samling av bildtransformeringsoperationer. För en bildram, börja med ramens [Picture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picture/) och kom åt [Picture.getImageTransform](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picture/#getImageTransform). Den returnerade [ImageTransformOperationCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/) låter dig lägga till, enumerera, inspektera, ta bort och rensa effekter utan att skriva om de ursprungliga bildbytena.

Denna artikel demonstrerar ett komplett arbetsflöde för ljusstyrka och kontrast, färgtransformeringar, oskärpa, genomskinlighet, ordnade effektkedjor, effektiva värden, borttagning och PPTX‑rundresan‑verifiering.

## **Förstå äganderätt för effekter och återanvändning av bild**

En bildresurs och bilden som visar den är olika objekt:

- [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/) lagrar eller refererar källbilddata som ägs av presentationen.
- [Picture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picture/) hör till en bildfyllning och refererar till en bildresurs samtidigt som den lagrar bildtransformeringssamlingen.
- [PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/) är bildformen på bilden som äger den relevanta bildfyllningen, geometrin, beskärningsinställningarna och annan ram‑nivå‑formatering.

Därför ändrar bildtransformeringsoperationer inte byten i [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/). När samma `PPImage` skickas till [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addPictureFrame) mer än en gång, får varje ny bildram sin egen `Picture` och sin egen transform‑samling. Att applicera gråskala på en ram gör inte de andra ramarna gråskalade, även om alla återanvänder samma inbäddade bildresurs.

Samma `Picture.getImageTransform`‑modell används också av andra bildfyllningar, såsom en form eller bildbakgrund. Exemplen nedan fokuserar på bildramar.

## **Använd giltiga parameterintervall och enheter**

De demonstrerade metoderna använder följande semantiska intervall och enheter. Håll värden inom dessa intervall även om ett specifikt biblioteks­version inte avvisar varje värde utanför intervallet omedelbart; målpresentationens format kan normalisera, utelämna eller avvisa ogiltiga data under sparande eller när PowerPoint öppnar filen.

| Operation | Parametrar | Giltigt intervall och enhet |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` till `100`, procent; `0` lämnar komponenten oförändrad. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Ingen | Inga numeriska parametrar. Alfa förblir oförändrad. |
| [addDuotoneEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Två färger för mörka respektive ljusa pixlar. RGB‑ och alfakanaler i `java.awt.Color` använder `0` till `255`. |
| [addTintEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Nyans är `0` inklusivt till `360` exklusivt, i grader; mängd är `-100` till `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Nyans är `0` inklusivt till `360` exklusivt, i grader; mättnad och luminans är `-100` till `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Ersättningsfärgen använder kanalvärden från `0` till `255`. Befintliga alfavärden förblir oförändrade. |
| [addBlurEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Radie är icke‑negativ och mäts i punkter; `grow` är en boolesk som styr om suddiga områden får sträcka sig utanför originalens gränser. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Icke‑negativ procent. Använd `0` till `100` för vanlig opacitets‑skalning: `0` är helt genomskinlig och `100` bevarar befintlig alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` till `100`, procent opacitet. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` till `100`, procent alfatröskel. Värden under blir transparenta; värden på eller över blir ogenomskinliga. |

För fast alfa‑modulering är genomskinlighet och opacitet komplementära. Till exempel motsvarar 35 % genomskinlighet en alfa‑moduleringsmängd på 65 %.

## **Applicera ljusstyrka och kontrast**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) returnerar en [BrightnessContrast](https://reference.aspose.com/slides/sv/python-java/aspose.slides/brightnesscontrast/)‑operation. Dess skalära inställningar anges när operationen skapas. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/brightnesscontrast/#getEffective) returnerar beräknade endast‑lästa värden som kan inspekteras eller loggas.

Följande exempel ökar ljusstyrkan med 15 % och kontrasten med 20 %, och renderar sedan en förhandsvisning utan att ändra den inbäddade bilden:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/sv/python-java/aspose.slides/brightnesscontrast/) är en Office 2010‑bild‑effekt‑utökning och är mindre portabel än den standardiserade DrawingML‑luminans‑effekten. När ljusstyrka och kontrast måste förbli redigerbara efter en PPTX‑rundresa, använd [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) och verifiera resultatet efter att filen har öppnats igen. Avsnittet om formatbegränsningar förklarar denna skillnad mer i detalj.

## **Applicera färgtransformeringar**

Färgeffekter kan appliceras oberoende på olika bildramar som återanvänder samma bildresurs. Följande exempel skapar fem ramar och applicerar gråskala, duotone, nyans, HSL‑justering och färgbyte.

[Duotone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/duotone/) innehåller två oberoende redigerbara färgparametrar: `color1` mappar mörka pixlar, medan `color2` mappar ljusa pixlar. Detta gör den till ett användbart exempel på en effekt vars inställningar är mer komplexa än ett enda skalärt värde.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) ersätter varje pixels färg med en fast färg medan alfa bevaras. Det skiljer sig från [addColorChangeEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), som mappar en källfärg till en annan och exponerar både källa‑ och mål‑färgformat.

## **Lägg till oskärpa, genomskinlighet och alfa‑effekter**

[addBlurEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) påverkar alla färgkanaler, inklusive alfa. Sätt `grow` till `True` när den suddiga kanten kan sträcka sig utanför den ursprungliga bildens gränser.

För enhetlig genomskinlighet, använd [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Den multiplicerar varje befintligt alfavärde, så delvis transparenta pixlar förblir proportionellt olika. [addAlphaReplaceEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) tilldelar istället ett alfavärde till alla pixlar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) konverterar alfa till två nivåer baserat på ett tröskelvärde.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Andra alfa‑operationer utan parametrar inkluderar [addAlphaCeilingEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), som gör varje icke‑noll alfa helt ogenomskinlig; [addAlphaFloorEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), som gör varje alfa under 100 % helt transparent; och [addAlphaInverseEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), som ändrar alfa till `100% - alpha`.

## **Bygg en ordnad effektkedja**

Varje `add...Effect`‑metod lägger till en ny operation i slutet av samlingen. Renderaren använder samlingen som en ordnad pipeline: utdata från operation 0 blir indata för operation 1, osv. Följaktligen kan samma operationer i en annan ordning producera en annan bild.

Till exempel tar gråskala följt av nyans först bort kromatisk information och färglägger sedan luminansresultatet. Nyans följt av gråskala tar bort nyansen igen. På liknande sätt kan alfa‑ersättning åsidosätta alfavärden beräknade av tidigare operationer, medan alfa‑modulering bevarar deras relativa skillnader.

Följande exempel bygger en kedja med fyra operationer, sparar den som PPTX, öppnar presentationen igen, kontrollerar både operationstyperna och deras ordning, och renderar det återöppnade resultatet:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

Samlingen pålägger ingen kompatibilitetsmatris som begränsar färg‑, alfa‑ och oskärpa‑operationer till separata kedjor. De kan kombineras, men kombinationer är inte alltid användbara. En fast färgbyte tar bort RGB‑variation som tidigare färgeffekter producerat; gråskala efter duotone tar bort de två valda färgerna; och alfa‑ceiling, floor, replacement eller bi‑level‑operationer kan förkasta alfa‑detaljer som skapats tidigare. Bygg kedjan enligt den önskade pixel‑bearbetningssekvensen snarare än att behandla dess element som oordnade formateringsflaggor.

## **Inspektera redigerbara och effektiva värden**

En redigerbar operation är objektet lagrat i `Picture.getImageTransform`. Beroende på effekten kan den exponera skrivbara medlemmar direkt. Till exempel exponerar [Blur](https://reference.aspose.com/slides/sv/python-java/aspose.slides/blur/) skrivbara `radius`‑ och `grow`‑värden, [AlphaModulateFixed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/alphamodulatefixed/) exponerar en skrivbar `amount`, och [AlphaBiLevel](https://reference.aspose.com/slides/sv/python-java/aspose.slides/alphabilevel/) exponerar en skrivbar `threshold`. Färgeffekter som [Duotone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/duotone/) exponerar muterbara [ColorFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/colorformat/)‑objekt.

Vissa operationsklasser, inklusive [BrightnessContrast](https://reference.aspose.com/slides/sv/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tint/), och [AlphaReplace](https://reference.aspose.com/slides/sv/python-java/aspose.slides/alphareplace/), exponerar inte sina skapande‑skalärer som skrivbara egenskaper. För att ändra dessa inställningar, ta bort operationen och lägg till en ersättning på den erforderliga positionen.

Effektiv data som returneras av `getEffective` är beräknad och skrivskyddad. Den är användbar för att lösa temaberoende färger och läsa de normaliserade värden som renderaren använder, men den är inte en annan redigeringsyta. Följande exempel enumererar kedjan och inspekterar effektiva värden där motsvarande API tillhandahåller dem:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

Effektfri parametrar som gråskala, alfa‑ceiling och alfa‑inverse har fortfarande ett effektiv‑datat objekt, men det finns inga skalära inställningar att skriva ut. Deras närvaro och position i samlingen är den viktiga informationen.

## **Ta bort eller rensa bildtransformeringar**

Använd [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) för att ta bort en operation efter index. Eftersom index skiftar efter borttagning, sök först efter målet och ta bort det efter enumeration. Använd [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#clear) för att ta bort hela kedjan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Att ta bort eller rensa transformeringar ändrar bara bildens formatering. Det tar inte bort, recomprimerar eller på annat sätt förändrar den återanvända [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)‑resursen.

## **Överväg presentationsformat och exportmål**

Bildtransformeringar har sitt ursprung i DrawingML, så PPTX är det föredragna redigerbara formatet för effektkedjor. Även med PPTX har inte varje operation identisk portabilitet:

- Standard‑DrawingML‑operationer såsom luminans, gråskala, duotone, nyans, HSL, oskärpa och vanliga alfa‑operationer har störst chans att överleva en PPTX‑rundresa. Öppna alltid den genererade filen igen och inspektera samlingen när bevarande är ett krav.
- [BrightnessContrast](https://reference.aspose.com/slides/sv/python-java/aspose.slides/brightnesscontrast/) är en Office 2010‑utökning snarare än den standardiserade DrawingML‑luminans‑operationen. Den kan användas för rendering i minnet, men det är inte garanterat att den förblir en redigerbar [BrightnessContrast](https://reference.aspose.com/slides/sv/python-java/aspose.slides/brightnesscontrast/) efter att PPTX sparats och öppnats igen. Föredra [addLuminanceEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) för bestående ljusstyrke‑ och kontrastjusteringar.
- Det binära PPT‑formatet föregick den fullständiga DrawingML‑effektmodellen. Sparas till PPT kan det utesluta icke‑stödda operationer, reducera en kedja till ett stödjande delmängd eller approximera utseendet. Använd inte PPT som verifieringsformat för en komplex redigerbar kedja.
- Rendering till PNG, JPEG, TIFF, PDF, SVG, HTML eller andra visuella utdata applicerar den stödjade kedjan på den renderade bilden. Dessa utdata innehåller inte en redigerbar `ImageTransformOperationCollection`; rasterformat flattenar resultatet till pixlar, och dokument‑/vektorexport lagrar sin egen renderingsrepresentation.
- Effekter gör inte en länkad bild självförsörjande. Rendering av en länkad bild beror fortfarande på att den länkade resursen är tillgänglig när presentationen laddas.

Olika presentationskonsumenter kan rendera kantfall olika, särskilt när flera alfa‑ eller färg‑kvantiseringsoperationer kombineras. För kritisk utdata, testa både den redigerbara rundresan och det slutgiltiga exportformatet med samma Aspose.Slides‑version som används i produktion.

## **FAQ**

**Modifierar bildtransformeringseffekter den inbäddade bilddata?**

Nej. Operationerna tillhör den `Picture` som används av bildfyllningen. Den underliggande `PPImage`‑bytena förblir oförändrade.

**Kommer två bildramar som återanvänder samma bild att dela sina effekter?**

Nej. Återanvändning av en `PPImage` undviker duplicerad bilddata, men varje bildram har normalt en separat `Picture` och en separat bildtransformeringssamling.

**Kan färg-, oskärpa‑ och alfa‑effekter kombineras?**

Ja. Samlingen accepterar dem i en ordnad kedja. Överväg vad varje operation gör med föregående resultat eftersom ersättnings‑ och tröskeloperationer kan förkasta tidigare färg‑ eller alfadetaljer.

**Varför är effektiva värden skrivskyddade?**

Effektiv data representerar beräknade värden som används för rendering, inklusive lösta färger. Redigera operationen som lagras i transform‑samlingen där skrivbara medlemmar finns; annars ta bort den och lägg till en ersättning med nya skapande‑parametrar.

**Vilket format bör jag använda för att bevara en transformkedja?**

Använd PPTX och verifiera filen genom att öppna den igen. Äldre PPT kan inte representera hela DrawingML‑effektmodellen, och renderade exportformat bevarar endast utseendet snarare än redigerbara transform‑operationer.