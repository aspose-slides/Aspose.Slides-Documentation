---
title: Hantera bildramar i presentationer med Python
linktitle: Bildram
type: docs
weight: 10
url: /sv/python-net/picture-frame/
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
- ta bort beskurna områden
- komprimera bild
- StretchOffset
- bildramformatering
- relativ skalning
- billedeffekt
- aspektförhållande
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Skapa, formatera, länka, beskära, extrahera och komprimera bildramar i presentationer med Aspose.Slides för Python via .NET."
---
## **Översikt**

En bildram är en bildspelsform som visar en bild. I Aspose.Slides är bildresursen och formen som visar den separata objekt: en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) äger inbäddade bildresurser via sin [ImageCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imagecollection/), medan en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) styr bildens position, storlek, linjeformatering, rotation, beskärning, bildeffekter och andra ramnivåinställningar.

Denna separation är användbar när samma bild visas mer än en gång. Lägg till bilden i presentationen en gång, behåll den returnerade [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/), och använd den bildresursen när du skapar bildramar.

Bildramar kan innehålla rasterbilder såsom PNG eller JPEG och vektorbilder i SVG-format. De kan också referera till länkade bilder istället för att lagra bildens byte‑data i presentationen. Valet påverkar portabilitet, filstorlek, extraktion och exportbeteende, så det är bra att avgöra hur bilden ska lagras innan formatering eller optimering tillämpas.

## **Lägg till och formatera en inbäddad bild**

För en inbäddad bild, lägg till bilddata i presentationen och skapa en bildram med [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_picture_frame/). Bilden blir en del av presentationspaketet, så presentationen förblir självständig när den flyttas till en annan dator.

Följande exempel lägger till en JPEG‑bild, skapar en ram med bildens ursprungliga dimensioner och tillämpar linjeformatering och rotation:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Bildramen styr den visade geometrin; att ändra ramens storlek ändrar inte de ursprungliga pixelmåtten som lagras i den inbäddade bildresursen. Denna skillnad blir viktig när man beskär eller komprimerar en bild senare.

## **Använd relativ skalning**

[PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) exponerar [relative_scale_width](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/relative_scale_width/) och [relative_scale_height](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/relative_scale_height/) för ramen. Ett värde på `1.0` motsvarar 100 % av den ursprungliga bildstorleken. Relativ skalning är användbart när ett arbetsflöde behöver bevara ett förhållande till källbildens storlek istället för att manuellt beräkna slutdimensioner.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

Relativ skalning ändrar ramens skalinställningar; den resamplar eller komprimerar inte den inbäddade bilden.

## **Inbäddade och länkade bilder**

En inbäddad bild lagrar bilddata i presentationen och är därför det säkraste valet för portabilitet och förutsägbar rendering. En länkad bild lagrar en extern plats via [Picture](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picture/) länkväg istället för att bädda in bilddata på samma sätt.

Länkade bilder kan minska mängden bilddata som lagras i PPTX, men de introducerar ett externt beroende. Den länkade filen måste förbli åtkomlig för applikationen som öppnar eller renderar presentationen. Om sökvägen ändras, filen flyttas eller resursen är otillgänglig, kan den länkade bilden kanske inte visas som förväntat. För presentationer som måste e‑postas, arkiveras eller renderas i isolerade miljöer är inbäddade bilder vanligtvis mer pålitliga.

### **Lägg till en länkad bild**

Följande exempel skapar en bildram och pekar den på en lokal bildfil. Det hanterar endast bildlänkning; videolänkning är ett separat mediearbetsflöde och är medvetet inte blandat i detta exempel.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Använd länkar när extern filhantering är avsiktlig. Använd dem inte bara som ett ersättningsmedel för kompression: en liten PPTX med brutna bildberoenden är vanligtvis mindre användbar än en större självständig presentation.

## **Extrahera bilder från bildramar**

Innan du extraherar en bild från en befintlig presentation, kontrollera att en form faktiskt är en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) och att den innehåller en inbäddad bild. Länkade bildramar kanske inte innehåller bildbyte som kan extraheras på samma sätt.

### **Extrahera en rasterbild**

Det moderna bild‑API:et använder [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/) direkt. Följande exempel hittar den första inbäddade rasterbilden på en bild och sparar den som PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Att spara via [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/) konverterar den extraherade bilden till det begärda utdataformatet. Om du behöver de kodade byte som lagras i presentationen snarare än en konverterad rasterfil, använd egenskapen [PPImage.binary_data](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/binary_data/) istället.

### **Extrahera en SVG-bild**

För en SVG-bild exponerar [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) ett [SvgImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/)‑objekt. Detta låter dig hämta SVG‑data direkt istället för att rasterisera bilden först.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Att behålla SVG‑innehållet som SVG bevarar vektorkällan i presentationen. Rasterexport som PNG eller JPEG renderar nödvändigtvis vektorinnholdet till pixlar. PDF‑ eller SVG‑bildexport är också en renderingsoperation, så de exporterade graferna bör inte betraktas som en exakt byte‑för‑byte‑kopia av den ursprungliga inbäddade SVG‑en; använd den inbäddade [SvgImage.svg_data](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/svg_data/) när den ursprungliga vektorresursen själv krävs.

## **Beskär en bild**

Beskärning ändrar vilken del av en bild som är synlig i ramen. Beskärningsvärdena på [PictureFillFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/) är procentandelar av källbildens dimensioner. Beskärning tar inte initialt bort de dolda pixlarna från den inbäddade bilden; den ändrar bara den synliga regionen.

Följande exempel hittar en bildram på ett säkert sätt och tillämpar beskärningsvärden:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Eftersom den dolda bilddatan fortfarande finns kvar, kan beskärningen ändras senare utan att förlora de ursprungliga pixlarna. Om filstorlek är viktigare än återgörbarhet kan de beskurna områdena tas bort fysiskt som beskrivs i nästa avsnitt.

## **Ta bort beskärda bilddata**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) tar bort bilddata utanför den aktuella beskärningsrektangeln och returnerar den resulterande bildresursen. Detta kan minska filstorleken, men det är en destruktiv optimering: efter att presentationen sparats är de borttagna pixlarna inte längre tillgängliga för en senare avbeskärningsåtgärd.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

Metoden kan lägga till en ny bildresurs i presentationen. Om den ursprungliga bilden också används av andra bildramar, behöver dessa ramar fortfarande sin befintliga resurs, så att ta bort beskärda områden inte nödvändigtvis minskar det totala antalet bilder. Beskärning av WMF‑ eller EMF‑innehåll med denna metod rasteriserar det beskurna resultatet till PNG.

## **Komprimera rasterbilder**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/compress_image/) minskar rasterbildens upplösning i förhållande till den storlek som bilden visas i. Den kan också ta bort beskärda områden i samma operation. Metoden returnerar `True` när bilden har ändrats i storlek eller beskärts och `False` när ingen förändring var nödvändig.

Använd ett fördefinierat [PicturesCompression](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/picturescompression/)‑värde när en standardmåluppslösning är tillräcklig:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Ett eget positivt DPI‑värde kan skickas istället för ett enum‑värde när ett specifikt mål krävs.

Komprimering är avsedd för rasterbilder. SVG‑ och metafil‑innehåll minskas inte av detta rasterkomprimeringsflöde. Kom också ihåg att lägre upplösning och borttagna beskärda områden inte kan återställas från den optimerade presentationen. Välj en måluppslösning baserat på den största storlek som bilden faktiskt kommer att visas eller exporteras i, snarare än att tillämpa den lägsta DPI:n globalt.

## **Hantera bildtransformeringseffekter**

För ett komplett arbetsflöde som täcker ljusstyrka, kontrast, färgtransformeringar, oskärpa, alfadeffekter, ordnade kedjor, inspektion, borttagning och dubbelriktad verifiering, se [Image Transform Effects](/slides/sv/python-net/image-transform-effects/).

## **Lås bildramens geometri**

[PictureFrameLock](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframelock/)‑inställningarna styr vilka redigeringsåtgärder som är inaktiverade för en bildram. Till exempel bevarar egenskapen [aspect_ratio_locked](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) formens proportioner när den skalas.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Låset gäller bildramens form. Det tvingar inte källbilden att samplas om eller permanent ändras till samma bildförhållande.

## **Justera StretchOffset‑värdena**

När bildfyllningsläget är stretch definierar stretch‑offset‑värdena på [PictureFillFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/) fyllningsrektangeln relativt bildramens begränsningsruta. Positiva procentandelar skapar en inbuktning från en kant, medan negativa procentandelar skapar en utskjutning.

Detta skiljer sig från beskärning. Beskärningsvärden väljer vilken del av källbilden som är synlig; stretch‑offset‑värden ändrar rektangeln som den synliga bildfyllningen sträcks in i.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Använd stretch‑offset‑värden för placering av fyllning. Använd beskärnings‑egenskaper när målet är att dölja kanter på källbilden.

## **Lagring, filstorlek och exportöverväganden**

De viktigaste avvägningarna är enklare att hantera när bildlagring och bildramformatering behandlas separat:

- **Inbäddade bilder** gör presentationen självständig och är de mest pålitliga för delning och server‑sidig rendering, men stora rasterbilder ökar PPTX‑storleken och minnesanvändningen.
- **Länkade bilder** kan hålla paketet mindre, men presentationen är beroende av att externa filer fortsatt är tillgängliga på de lagrade sökvägarna eller platserna.
- **Beskärning** är initialt icke‑destruktiv. De dolda pixlarna förblir inbäddade tills beskurna områden uttryckligen tas bort eller raderas vid komprimering.
- **Komprimering** kan minska filstorleken avsevärt för överdimensionerade rasterbilder, men den offrar källupplösningen. Den bör tillämpas efter att den avsedda bildstorleken på bilden är känd.
- **SVG‑bilder** bör förbli som SVG när vektorbevarande är viktigt. Extrahera den inbäddade SVG‑filen direkt när du behöver vektorresursen själv. Raster‑bildexporter konverterar alltid den renderade bilden till pixlar.
- **Upprepade bilder** bör återanvända en befintlig [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/)‑resurs när det är möjligt istället för att upprepade gånger ladda samma fil i presentationsarbetsflödet.

För stora presentationer är bildoptimering vanligtvis mest effektiv när den utförs selektivt: behåll logotyper och diagram som vektor­innehåll, komprimera foton enligt deras faktiska visningsstorlek, ta bort beskurna pixlar endast när senare redigering inte krävs, och undvik externa länkar såvida inte beroendehantering är en del av distributionsdesignen.

## **Vanliga frågor**

**Vad är skillnaden mellan en bildram och en bildresurs?**

En [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) representerar en bildresurs som är kopplad till presentationen. En [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) är en form på en bild som visar en bild och lagrar ram‑nivåens geometri och formatering såsom storlek, rotation, beskärningsvärden, effekter och lås.

**Ska jag bädda in eller länka bilder?**

Bädda in bilder när presentationen måste vara portabel, arkiveras eller renderas utan åtkomst till externa resurser. Länka bilder endast när det är avsiktligt att hålla bildfiler utanför PPTX och de externa platserna kan underhållas på ett pålitligt sätt.

**Minskar beskärning PPTX‑filstorleken?**

Inte i sig självt. Vanliga beskärningsinställningar döljer delar av källbilden men behåller de underliggande pixlarna. Använd [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) eller bildkomprimering med borttagning av beskärda områden när dessa pixlar kan kastas permanent.

**Kan jag återställa bildkvaliteten efter kompression?**

Nej. Komprimering kan minska den lagrade rasterupplösningen, och borttagning av beskärda områden kastar bilddata. Behåll den ursprungliga källbilden utanför presentationen om redigering i hög upplösning kan behövas senare.

**Hur bör SVG‑bilder hanteras?**

Behåll SVG‑innehållet som SVG när vektor‑noggrannhet är viktig. Den inbäddade [SvgImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/) kan extraheras direkt. Rendering av en bild till ett rasterformat som PNG eller JPEG rasteriserar SVG‑en som en del av bild‑elementet.

**Hur kan jag undvika osäkra typkonverteringar när jag läser befintliga bilder?**

Kontrollera formtypen innan du använder bildram‑specifika medlemmar. Att använda `isinstance(shape, slides.PictureFrame)` undviker ogiltiga typkonverteringar och låter koden hantera bilder som inte innehåller bildramar.