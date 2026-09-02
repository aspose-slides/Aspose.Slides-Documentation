---
title: "Hantera bildramar i presentationer med Python"
linktitle: "Bildram"
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
  - beskära bild
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
  - Aspose.Slides
description: "Skapa, formatera, länka, beskära, extrahera och komprimera bildramar i presentationer med Aspose.Slides för Python via .NET."
---
## **Översikt**

En bildram är en bildform på en bildspel som visar en bild. I Aspose.Slides är bildresursen och formen som visar den separata objekt: en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) äger inbäddade bildresurser via sin [ImageCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imagecollection/), medan en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) styr bildens position, storlek, linjeformat, rotation, beskärning, bildeffekter och andra inställningar på ramnivå.

Denna separation är användbar när samma bild visas mer än en gång. Lägg till bilden i presentationen en gång, behåll den returnerade [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/), och använd den bildresursen när du skapar bildramar.

Bildramar kan innehålla rasterbilder såsom PNG eller JPEG samt vektor‑SVG‑bilder. De kan också referera till länkade bilder istället för att lagra bildbytes i presentationen. Valet påverkar portabilitet, filstorlek, extrahering och exportbeteende, så det är bra att bestämma hur bilden ska lagras innan formatering eller optimering tillämpas.

## **Lägg till och formatera en inbäddad bild**

För en inbäddad bild, lägg till bilddata i presentationen och skapa en bildram med [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_picture_frame/). Bilden blir en del av presentationspaketet, så presentationen förblir självständig när den flyttas till en annan dator.

Följande exempel lägger till en JPEG‑bild, skapar en ram med bildens ursprungliga dimensioner och tillämpar linjeformat och rotation:

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

Bildramen styr den visade geometrin; att ändra ramens storlek ändrar inte de ursprungliga pixelmåtten som lagras i den inbäddade bildresursen. Detta blir viktigt när man beskär eller komprimerar en bild senare.

## **Använd relativ skala**

[PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) exponerar [relative_scale_width](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/relative_scale_width/) och [relative_scale_height](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/relative_scale_height/) för ramen. Ett värde på `1.0` motsvarar 100 % av den ursprungliga bildstorleken. Relativ skala är användbart när ett arbetsflöde behöver bevara ett förhållande till källbildens storlek istället för att beräkna slutdimensioner manuellt.

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

Relativ skala ändrar ramens skalningsinställningar; den omprovtagar eller komprimerar inte den inbäddade bilden.

## **Inbäddade och länkade bilder**

En inbäddad bild lagrar bilddata i presentationen och är därför det säkraste valet för portabilitet och förutsägbar rendering. En länkad bild lagrar en extern plats via [Picture](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picture/)-länkvägen istället för att bädda in bilddata på samma sätt.

Länkade bilder kan minska mängden bilddata som lagras i PPTX, men de introducerar ett externt beroende. Den länkade filen måste förbli åtkomlig för applikationen som öppnar eller renderar presentationen. Om sökvägen ändras, filen flyttas eller resursen blir otillgänglig kan den länkade bilden saknas som förväntat. För presentationer som måste skickas via e‑post, arkiveras eller renderas i isolerade miljöer är inbäddade bilder vanligtvis mer tillförlitliga.

### **Lägg till en länkad bild**

Följande exempel skapar en bildram och pekar den på en lokal bildfil. Det hanterar endast bildlänkning; videolänkning är ett separat mediaprocess och är medvetet inte blandat i detta exempel.

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

Använd länkar när extern filhantering är avsiktlig. Använd dem inte bara som ersättning för komprimering: en liten PPTX med brutna bildberoenden är vanligtvis mindre användbar än en större självständig presentation.

## **Extrahera bilder från bildramar**

Innan du extraherar en bild från en befintlig presentation, kontrollera att en form faktiskt är en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) och att den innehåller en inbäddad bild. Länkade bildramar kan sakna bildbytes som kan extraheras på samma sätt.

### **Extrahera en rasterbild**

Det moderna bild‑API‑et använder [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/) direkt. Följande exempel hittar den första inbäddade rasterbilden på en bild och sparar den som PNG:

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

Sparande via [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/) konverterar den extraherade bilden till det begärda utdataformatet. Om du behöver de kodade bytes som lagras i presentationen snarare än en konverterad rasterfil, använd egenskapen [PPImage.binary_data](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/binary_data/) istället.

### **Extrahera en SVG‑bild**

För en SVG‑bild exponerar [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) ett [SvgImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/)-objekt. Detta låter dig hämta SVG‑data direkt istället för att rasterisera bilden först.

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

Att behålla SVG‑innehåll som SVG bevarar den vektor‑källan i presentationen. Rasterexport som PNG eller JPEG renderar nödvändigtvis den vektorinnehållet till pixlar. PDF‑ eller SVG‑slide‑export är också en renderingsoperation, så de exporterade grafikerna bör inte betraktas som en exakt byte‑för‑byte‑kopia av den inbäddade SVG‑filen; använd den inbäddade [SvgImage.svg_data](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/svg_data/) när den ursprungliga vektorresursen själv krävs.

## **Beskär en bild**

Beskärning ändrar vilken del av en bild som är synlig i ramen. Beskärningsvärdena på [PictureFillFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/) är procentandelar av källbildens dimensioner. Beskärning raderar inte initialt de dolda pixlarna från den inbäddade bilden; den ändrar bara den synliga regionen.

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

Eftersom den dolda bilddatan fortfarande finns kvar kan beskärningen ändras senare utan att förlora de ursprungliga pixlarna. Om filstorlek betyder mer än reverserbarhet kan de beskurna regionerna fysiskt tas bort som beskrivs i nästa avsnitt.

## **Ta bort beskärd bilddata**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) tar bort bilddata utanför den aktuella beskärningsrektangeln och returnerar den resulterande bildresursen. Detta kan minska filstorleken, men det är en destruktiv optimering: efter att presentationen sparats är de borttagna pixlarna inte längre tillgängliga för en senare avbeskära‑operation.

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

Metoden kan lägga till en ny bildresurs i presentationen. Om den ursprungliga bilden också används av andra bildramar behöver de ramarna fortfarande sin befintliga resurs, så att ta bort beskärda områden inte nödvändigtvis minskar det totala antalet bilder. Att beskärma WMF‑ eller EMF‑innehåll med denna metod rasteriserar det beskurna resultatet till PNG.

## **Komprimera rasterbilder**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/compress_image/) minskar rasterbildens upplösning i förhållande till den storlek som bilden visas i. Den kan också ta bort beskärda regioner i samma operation. Metoden returnerar `True` när bilden har storleksändrats eller beskärts och `False` när ingen förändring var nödvändig.

Använd ett fördefinierat [PicturesCompression](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/picturescompression/)‑värde när en standardmål‑upplösning är tillräcklig:

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

Komprimering är avsedd för rasterbilder. SVG‑ och metafil‑innehåll reduceras inte av detta rasterkomprimerings‑arbetsflöde. Kom också ihåg att lägre upplösning och borttagna beskärda regioner inte kan återställas från den optimerade presentationen. Välj en mål‑upplösning baserat på den största storleken som bilden faktiskt kommer att visas eller exporteras i, snarare än att applicera låg DPI globalt.

## **Inspektera bildeffekter**

Bildeffekter lagras på bilden som används av ramen. Bildtransform‑samlingen kan innehålla effekter såsom fast alfa‑modulering för transparens och luminans för ljusstyrka och kontrast. Exemplet nedan läser säkert båda typerna av effekter från den första bildramen på en bild:

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
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/sv/python-net/aspose.slides.effects/alphamodulatefixed/) och [Luminance](https://reference.aspose.com/slides/sv/python-net/aspose.slides.effects/luminance/) ändrar hur bilden renderas i ramen; de omskriver inte de ursprungliga inbäddade bildbyterna.

## **Lås bildramens geometri**

[PictureFrameLock](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframelock/)‑inställningarna styr vilka redigeringsoperationer som är inaktiverade för en bildram. Till exempel bevarar egenskapen [aspect_ratio_locked](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) ramens proportioner när den ändras i storlek.

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

Låset gäller bildramformen. Det tvingar inte källbilden att provprovtagas eller permanent ändras till samma bildförhållande.

## **Justera StretchOffset‑värdena**

När bildfyllnadsläget är stretch definierar stretch‑offset‑värdena på [PictureFillFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/) fyllningsrektangeln relativt bildramens omgivningsruta. Positiva procentandelar skapar ett inre avstånd från en kant, medan negativa procentandelar skapar ett yttre avstånd.

Detta skiljer sig från beskärning. Beskärningsvärden väljer vilken del av källbilden som är synlig; stretch‑offset ändrar rektangeln som den synliga bildfyllnaden sträcks in i.

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

Använd stretch‑offset för placering av fyllning. Använd beskärnings‑egenskaper när målet är att dölja kanter i källbilden.

## **Lagring, filstorlek och exportöverväganden**

De viktigaste avvägningarna blir enklare att hantera när bildlagring och bildram‑formatering behandlas separat:

- **Inbäddade bilder** gör presentationen självständig och är det mest pålitliga alternativet för delning och server‑sida rendering, men stora rasterbilder ökar PPTX‑storlek och minnesanvändning.
- **Länkade bilder** kan hålla paketet mindre, men presentationen beror på att externa filer förblir tillgängliga på de lagrade sökvägarna eller platserna.
- **Beskärning** är initialt icke‑destruktiv. Dolda pixlar förblir inbäddade tills beskärda områden explicit tas bort eller tas bort under komprimering.
- **Komprimering** kan minska filstorleken avsevärt för överdimensionerade rasterbilder, men den offrar källupplösning. Den bör tillämpas efter att den avsedda storleken på bilden i sliden är känd.
- **SVG‑bilder** bör förbli SVG när vektorbevarande är viktigt. Extrahera den inbäddade SVG:n direkt när du behöver vektorresursen själv. Raster‑slide‑exporter konverterar alltid den renderade sliden till pixlar.
- **Upprepade bilder** bör återanvända en befintlig [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/)‑resurs när det är möjligt istället för att upprepade gånger ladda samma fil i presentationsarbetsflödet.

För stora presentationer är bildoptimering vanligtvis mest effektiv när den utförs selektivt: behåll logotyper och diagram som vektor­innehåll, komprimera fotografier enligt deras faktiska visningsstorlek, ta bort beskurna pixlar endast när senare redigering inte krävs, och undvik externa länkar om inte beroendehantering är en del av distributionsdesignen.

## **Vanliga frågor**

**Vad är skillnaden mellan en bildram och en bildresurs?**

En [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) representerar en bildresurs som är associerad med presentationen. En [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) är en form på en bild som visar en bild och lagrar ram‑nivå geometri och format såsom storlek, rotation, beskärningsvärden, effekter och lås.

**Bör jag bädda in eller länka bilder?**

Bädda in bilder när presentationen måste vara portabel, arkiverad eller renderas utan åtkomst till externa resurser. Länka bilder endast när det är avsiktligt att hålla bildfiler utanför PPTX och de externa platserna kan underhållas på ett pålitligt sätt.

**Minskar beskärning PPTX‑filens storlek?**

Inte i sig. Vanliga beskärningsinställningar döljer delar av källbilden men behåller de underliggande pixlarna. Använd [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) eller bildkomprimering med borttagning av beskärda områden när dessa pixlar kan kastas bort permanent.

**Kan jag återställa bildkvaliteten efter komprimering?**

Nej. Komprimering kan minska den lagrade raster‑upplösningen, och borttagning av beskärda regioner kastar bort bilddata. Behåll originalbilden utanför presentationen om senare högupplöst redigering kan behövas.

**Hur bör SVG‑bilder hanteras?**

Behåll SVG‑innehåll som SVG när vektorprecision är viktig. Den inbäddade [SvgImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/) kan extraheras direkt. Rendering av en slide till ett rasterformat som PNG eller JPEG rasteriserar SVG:n som en del av slide‑bilden.

**Hur undviker jag osäkra cast‑operationer när jag läser befintliga slides?**

Kontrollera formtypen innan du använder bildram‑specifika medlemmar. Att använda `isinstance(shape, slides.PictureFrame)` undviker ogiltiga cast‑operationer och låter koden hantera slides som inte innehåller bildramar.