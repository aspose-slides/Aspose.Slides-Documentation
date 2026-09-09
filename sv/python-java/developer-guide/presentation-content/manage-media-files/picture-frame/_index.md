---
title: Hantera bildramar i presentationer med Python
linktitle: Bildram
type: docs
weight: 10
url: /sv/python-java/picture-frame/
keywords:
- bildram
- lägg till bildram
- skapa bildram
- inbäddad bild
- länkad bild
- extrahera bild
- rasterbild
- SVG-bild
- beskär bild
- ta bort beskärda områden
- komprimera bild
- StretchOffset
- bildramformatering
- relativ skala
- bildeffekt
- bildförhållande
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa, formatera, länka, beskära, extrahera och komprimera bildramar i presentationer med Aspose.Slides för Python via Java."
---
## **Översikt**

En bildram är en bildform på en bildspel som visar en bild. I Aspose.Slides är bildresursen och formen som visar den separata objekt: en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) äger inbäddade bildresurser via sin [ImageCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagecollection/), medan en [PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/) styr bildens position, storlek, linjeformatering, rotation, beskärning, bildeffekter och andra ramnivåinställningar.

Denna separation är användbar när samma bild visas mer än en gång. Lägg till bilden i presentationen en gång, behåll den returnerade [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/), och använd den bildresursen när du skapar bildramar.

Bildramar kan innehålla rasterbilder som PNG eller JPEG och vektor‑SVG‑bilder. De kan också referera till länkade bilder i stället för att lagra bildens byte i presentationen. Valet påverkar portabilitet, filstorlek, extrahering och exportbeteende, så det är bra att bestämma hur bilden ska lagras innan formatering eller optimering tillämpas.

## **Lägg till och formatera en inbäddad bild**

För en inbäddad bild, lägg till bilddata i presentationen och skapa en bildram med [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addPictureFrame). Bilden blir en del av presentationspaketet, så presentationen förblir självständig när den flyttas till en annan dator.

Följande exempel lägger till en JPEG‑bild, skapar en ram med bildens ursprungliga dimensioner och tillämpar linjeformatering och rotation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bildramen styr den visade geometrin; att ändra ramens storlek ändrar inte de ursprungliga pixelmåtten som lagras i den inbäddade bildresursen. Denna skillnad blir viktig när man beskär eller komprimerar en bild senare.

## **Använd relativ skala**

[PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/) exponerar relativ bredd‑ och höjdskalning för ramen via [setRelativeScaleWidth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) och [setRelativeScaleHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Ett värde på `1.0` motsvarar 100% av den ursprungliga bildstorleken. Relativ skala är användbar när ett arbetsflöde behöver bevara ett förhållande till källbildens storlek istället för att manuellt beräkna slutdimensioner.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Relativ skala ändrar ramens skalinställningar; den omprovderar eller komprimerar inte den inbäddade bilden.

## **Inbäddade och länkade bilder**

En inbäddad bild lagrar bilddata i presentationen och är därför det säkraste valet för portabilitet och förutsägbar rendering. En länkad bild lagrar en extern plats via metoden [Picture.setLinkPathLong](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picture/#setLinkPathLong) i stället för att bädda in bilddata på samma sätt.

Länkade bilder kan minska mängden bilddata som lagras i PPTX, men de introducerar ett externt beroende. Den länkade filen måste förbli åtkomlig för applikationen som öppnar eller renderar presentationen. Om sökvägen ändras, filen flyttas eller resursen är otillgänglig, kan den länkade bilden inte visas som förväntat. För presentationer som måste e‑postas, arkiveras eller renderas i isolerade miljöer är inbäddade bilder vanligtvis mer pålitliga.

### **Lägg till en länkad bild**

Följande exempel skapar en bildram och pekar den på en lokal bildfil. Det hanterar endast bildlänkning; videolänkning är ett separat mediearbetsflöde och är avsiktligt inte blandat i detta exempel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Använd länkar när extern filhantering är avsiktlig. Använd dem inte bara som ett substitut för komprimering: en liten PPTX med brutna bildberoenden är vanligtvis mindre användbar än en större självständig presentation.

## **Extrahera bilder från bildramar**

Innan du extraherar en bild från en befintlig presentation, kontrollera att en form faktiskt är en [PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/) och att den innehåller en inbäddad bild. Länkade bildramar kanske inte innehåller bildbyte som kan extraheras på samma sätt.

### **Extrahera en rasterbild**

Det moderna bild‑API‑et arbetar direkt med rasterbilder och kräver inte den äldre Java‑bild‑wrappern. Följande exempel hittar den första inbäddade rasterbilden på en bildspelssida och sparar den som PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Att spara rasterbilden konverterar den extraherade bilden till det begärda utdataformatet. Om du behöver de kodade byte som lagras i presentationen i stället för en konverterad rasterfil, använd bildresursens binära data.

### **Extrahera en SVG‑bild**

För en SVG‑bild exponeras ett [SvgImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgimage/)‑objekt via [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/). Detta låter dig hämta SVG‑data direkt i stället för att rasterisera bilden först.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Att behålla SVG‑innehåll som SVG bevarar vektor­källan i presentationen. Rasterexport som PNG eller JPEG renderar nödvändigtvis vektor­innehållet till pixlar. PDF‑ eller SVG‑bildspelsexport är också en renderingsoperation, så de exporterade grafikerna bör inte behandlas som en exakt byte‑för‑byte‑kopia av den ursprungliga inbäddade SVG:n; använd den inbäddade [SvgImage.getSvgData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgimage/#getSvgData)‑datan när den ursprungliga vektorresursen själv krävs.

## **Beskär en bild**

Beskärning ändrar vilken del av en bild som är synlig i ramen. Beskärningsvärdena på [PictureFillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/) är procent av källbildens dimensioner. Beskärning tar inte initialt bort de dolda pixlarna från den inbäddade bilden; den ändrar bara den synliga regionen.

Följande exempel hittar säkert en bildram och tillämpar beskärningsvärden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Eftersom den dolda bilddatan fortfarande finns kvar kan beskärningen ändras senare utan att förlora de ursprungliga pixlarna. Om filstorlek är viktigare än återställbarhet kan de beskurna regionerna tas bort fysiskt som beskrivs i nästa avsnitt.

## **Ta bort beskurna bilddata**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) tar bort bilddata utanför den aktuella beskärningsrektangeln och returnerar den resulterande bildresursen. Detta kan minska filstorleken, men det är en destruktiv optimering: efter att presentationen sparats är de borttagna pixlarna inte längre tillgängliga för en senare avbeskärning.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metoden kan lägga till en ny bildresurs i presentationen. Om den ursprungliga bilden också används av andra bildramar behöver dessa ramar fortfarande sin befintliga resurs, så att ta bort beskurna områden minskar inte nödvändigtvis det totala antalet bilder. Beskärning av WMF‑ eller EMF‑innehåll med denna metod rasteriserar det beskurna resultatet till PNG.

## **Komprimera rasterbilder**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#compressImage) minskar rasterbildupplösningen i förhållande till den storlek som bilden visas i. Den kan också ta bort beskurna regioner i samma operation. Metoden returnerar `True` när bilden har ändrat storlek eller beskärts och `False` när ingen förändring var nödvändig.

Använd ett fördefinierat värde för [PicturesCompression](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturescompression/) när en standardmålupplösning är tillräcklig:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ett eget positivt DPI‑värde kan anges i stället för ett fördefinierat värde när ett specifikt mål krävs.

Komprimering är avsedd för rasterbilder. SVG‑ och metafil‑innehåll minskas inte av detta rasterkomprimeringsflöde. Kom också ihåg att lägre upplösning och borttagna beskurna regioner inte kan återställas från den optimerade presentationen. Välj en målupplösning baserat på den största storlek som bilden faktiskt kommer att visas eller exporteras i, snarare än att tillämpa den lägsta DPI:n globalt.

## **Hantera bildtransformeringseffekter**

För ett komplett arbetsflöde som täcker ljusstyrka, kontrast, färgtransformeringar, oskärpa, alfa‑effekter, ordnade kedjor, inspektion, borttagning och dubbelriktad verifiering, se [Image Transform Effects](/slides/sv/python-java/image-transform-effects/).

## **Lås bildramens geometri**

[PictureFrameLock](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframelock/)‑inställningarna styr vilka redigeringsåtgärder som är inaktiverade för en bildram. Till exempel bevarar [setAspectRatioLocked](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) formens proportioner när den ändras i storlek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Låset gäller för bildramens form. Det tvingar inte källbilden att omprovas eller permanent ändras till samma bildförhållande.

## **Justera StretchOffset‑värdena**

När bildfyllnadsläget är stretch definierar stretch‑offset‑värdena på [PictureFillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/) fyllningsrektangeln relativt bildramens omgivningsruta. Positiva procentsatser skapar ett inläggning från en kant, medan negativa procentsatser skapar ett utstickande.

Detta skiljer sig från beskärning. Beskärningsvärden väljer vilken del av källbilden som är synlig; stretch‑offset ändrar rektangeln som den synliga bildfyllnaden sträcks in i.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Använd stretch‑offset för placering av fyllning. Använd beskärnings‑egenskaper när målet är att dölja källbildens kanter.

## **Lagring, filstorlek och exportaspekter**

Huvudavvägningarna är lättare att hantera när bildlagring och bildramens formatering behandlas separat:

- **Inbäddade bilder** gör presentationen självständig och är de mest pålitliga för delning och server‑sidhämtning, men stora rasterbilder ökar PPTX‑storlek och minnesanvändning.
- **Länkade bilder** kan hålla paketet mindre, men presentationen är beroende av att externa filer förblir tillgängliga på de lagrade sökvägarna eller platserna.
- **Beskärning** är initialt icke‑destruktiv. De dolda pixlarna förblir inbäddade tills beskurna områden uttryckligen tas bort eller tas bort under komprimering.
- **Komprimering** kan minska filstorleken avsevärt för överdimensionerade rasterbilder, men den offrar källupplösning. Den bör tillämpas efter att den avsedda storleken på bilden är känd.
- **SVG‑bilder** bör förbli som SVG när vektorreproduktion är viktigt. Extrahera den inbäddade SVG:n direkt när du behöver vektorresursen själv. Raster‑slide‑exporter konverterar alltid den renderade sliden till pixlar.
- **Upprepade bilder** bör återanvända en befintlig [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)‑resurs när det är möjligt i stället för att upprepade gånger ladda samma fil i presentationsarbetsflödet.

För stora presentationer är bildoptimering vanligtvis mest effektiv när den utförs selektivt: behåll logotyper och diagram som vektor­innehåll, komprimera fotografier enligt deras faktiska visningsstorlek, ta bort beskurna pixlar endast när senare redigering inte krävs, och undvik externa länkar om inte beroendehantering är en del av distributionsdesignen.

## **FAQ**

**Vad är skillnaden mellan en bildram och en bildresurs?**

En [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/) representerar en bildresurs som är associerad med presentationen. En [PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/) är en form på en bild som visar en bild och lagrar ram‑nivå geometri och formatering såsom storlek, rotation, beskärningsvärden, effekter och lås.

**Ska jag bädda in eller länka bilder?**

Bädda in bilder när presentationen måste vara portabel, arkiverad eller renderas utan åtkomst till externa resurser. Länka bilder endast när det är avsiktligt att hålla bildfilerna utanför PPTX och de externa platserna kan underhållas på ett pålitligt sätt.

**Minskar beskärning PPTX‑filstorleken?**

Inte i sig. Normala beskärningsinställningar döljer delar av källbilden men behåller de underliggande pixlarna. Använd [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) eller bildkomprimering med borttagning av beskurna områden när dessa pixlar kan tas bort permanent.

**Kan jag återställa bildkvaliteten efter komprimering?**

Nej. Komprimering kan minska den lagrade rasterupplösningen, och att ta bort beskurna regioner kastar bilddata. Behåll den ursprungliga källbilden utanför presentationen om högupplöst redigering kan behövas senare.

**Hur bör SVG‑bilder hanteras?**

Behåll SVG‑innehåll som SVG när vektor­noggrannhet är viktig. Den inbäddade [SvgImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/svgimage/) kan extraheras direkt. Att rendera en bild till ett rasterformat som PNG eller JPEG rasteriserar SVG:n som en del av bildens bild.

**Hur kan jag undvika osäkra typkonverteringar när jag läser befintliga bilder?**

Kontrollera formtypen innan du använder bildram‑specifika medlemmar. En `isinstance`‑kontroll mot [PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/) undviker ogiltiga typkonverteringar och låter koden hantera bilder som inte innehåller bildramar.