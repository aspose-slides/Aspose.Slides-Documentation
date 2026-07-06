---
title: Lägg till bildramar i presentationer med Python
linktitle: Bildram
type: docs
weight: 10
url: /sv/python-net/picture-frame/
keywords:
- bildram
- lägg till bildram
- skapa bildram
- lägg till bild
- skapa bild
- extrahera bild
- rasterbild
- vektorbild
- beskär bild
- beskuret område
- StretchOff-egenskap
- formatering av bildram
- egenskaper för bildram
- relativ skala
- bildeffekt
- bildförhållande
- bildtransparens
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lägg till bildramar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Effektivisera ditt arbetsflöde och förbättra bilddesignen."
---
## **Introduktion**

Bildramar i Aspose.Slides för Python låter dig placera och hantera raster- och vektorbilder som inbyggda bildobjekt på bilden. Du kan infoga bilder från filer eller strömmar, positionera och ändra storlek med exakta koordinater, applicera rotation, ange transparens och kontrollera z‑ordning tillsammans med andra former. API:et stödjer också beskärning, bevarande av bildförhållanden, inställning av kanter och effekter samt ersättning av den underliggande bilden utan att bygga om layouten. Eftersom bildramar beter sig som vanliga former kan du lägga till animationer, hyperlänkar och alternativ text, vilket gör det enkelt att skapa visuellt rika, tillgängliga presentationer.

## **Skapa bildramar**

Detta avsnitt visar hur du infogar en bild i en bild genom att skapa en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) med Aspose.Slides för Python. Du får lära dig hur du laddar bilden, placerar den exakt på bilden och styr dess storlek och formatering.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en bild efter dess index.
3. Skapa en [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) genom att lägga till bilden i presentationens [ImageCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imagecollection/). Denna bild används för att fylla formen.
4. Ange ramens bredd och höjd.
5. Skapa en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) av den storleken med metoden [add_picture_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Spara presentationen som en PPTX‑fil.

```py
import aspose.slides as slides

# Skapa en instans av Presentation-klassen för att representera en PPTX-fil.
with slides.Presentation() as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till bilden i presentationen.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Lägg till en bildram med storlek anpassad till bilden.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Spara presentationen som PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Bildramar låter dig snabbt skapa presentationsbilder från bilder. När du kombinerar bildramar med Aspose.Slides sparalternativ kan du styra I/O‑operationer för att konvertera bilder från ett format till ett annat. Du kanske vill se dessa sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/python-net/conversion/image-to-jpg/); konvertera [JPG till bild](https://products.aspose.com/slides/sv/python-net/conversion/jpg-to-image/); konvertera [JPG till PNG](https://products.aspose.com/slides/sv/python-net/conversion/jpg-to-png/); konvertera [PNG till JPG](https://products.aspose.com/slides/sv/python-net/conversion/png-to-jpg/); konvertera [PNG till SVG](https://products.aspose.com/slides/sv/python-net/conversion/png-to-svg/); konvertera [SVG till PNG](https://products.aspose.com/slides/sv/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Skapa bildramar med relativ skala**

Detta avsnitt demonstrerar hur du placerar en bild med fast storlek och sedan tillämpar procentuell skalning oberoende på bredd och höjd. Eftersom procentandelarna kan skilja sig kan bildförhållandet förändras. Skalning utförs relativt bildens ursprungliga dimensioner.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en bild efter dess index.
3. Skapa en [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) genom att lägga till bilden i presentationens [ImageCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imagecollection/).
4. Lägg till en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) på bilden.
5. Ange bildramens relativa bredd och höjd.
6. Spara presentationen som en PPTX‑fil.

```py
import aspose.slides as slides

# Skapa en instans av Presentation-klassen för att representera en PPTX-fil.
with slides.Presentation() as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till bilden i presentationens bildsamling.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Lägg till en bildram på bilden.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Ange relativ skalning för bredd och höjd.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Spara presentationen.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Extrahera rasterbilder från bildramar**

Du kan extrahera rasterbilder från [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/)‑objekt och spara dem som PNG, JPG och andra format. Koden nedan visar hur du extraherar en bild från dokumentet "sample.pptx" och sparar den i PNG‑format.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Extrahera SVG‑bilder från bildramar**

När en presentation innehåller SVG‑grafik placerad i [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/)-former låter Aspose.Slides för Python via .NET dig hämta de ursprungliga vektorbilderna med fullständig noggrannhet. Genom att gå igenom bildens formsamling kan du identifiera varje [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/), kontrollera om den underliggande [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) innehåller SVG‑innehåll och sedan spara bilden till disk eller en ström i dess ursprungliga SVG‑format.

Koden nedan demonstrerar hur du extraherar en SVG‑bild från en bildram:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Hämta bildtransparens**

Aspose.Slides låter dig hämta transparenseffekten som applicerats på en bild. Denna Python‑kod demonstrerar operationen:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
Alla effekter som applicerats på bilder finns i [aspose.slides.effects](https://reference.aspose.com/slides/sv/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Hämta ljusstyrka och kontrast för en bild**

Aspose.Slides låter dig hämta ljusstyrke‑ och kontrasteffekten som applicerats på en bild. Klassen [Luminance](https://reference.aspose.com/slides/sv/python-net/aspose.slides.effects/luminance/) representerar denna bildtransformations­effekt.

Denna Python‑kod visar hur du får ljusstyrke‑ och kontrastinställningarna från en bildram:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **Formatering av bildramar**

Aspose.Slides erbjuder många formateringsalternativ som du kan applicera på en bildram. Med dessa alternativ kan du justera en bildram för att möta specifika krav.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en bild efter dess index.
3. Skapa en [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) genom att lägga till bilden i presentationens [ImageCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imagecollection/). Denna bild används för att fylla formen.
4. Ange ramens bredd och höjd.
5. Skapa en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) av den storleken med bildens [add_picture_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_picture_frame/)-metod.
6. Ange bildramens linjefärg.
7. Ange bildramens linjebredd.
8. Rotera bildramen genom att ange ett positivt (medurs) eller negativt (moturs) värde.
9. Spara den ändrade presentationen som en PPTX‑fil.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa en instans av Presentation-klassen för att representera en PPTX-fil.
with slides.Presentation() as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till bilden i presentationens bildsamling.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Lägg till en bildram med storlek anpassad till bilden.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Applicera formatering på bildramen.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Spara presentationen som PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose har utvecklat en gratis [Collage Maker](https://products.aspose.app/slides/sv/collage). Om du behöver [sammanfoga JPG/JPEG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG‑bilder, eller [skapa fotogriddern](https://products.aspose.app/slides/sv/collage/photo-grid), kan du använda denna tjänst.
{{% /alert %}}

## **Lägg till bilder som länkar**

För att hålla presentationsfiler små kan du lägga till bilder eller videor via länkar istället för att bädda in filerna direkt i presentationerna. Följande Python‑kod visar hur du infogar en bild och en video i en platshållare:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Beskär bilder**

I det här avsnittet lär du dig hur du beskär den synliga delen av en bild i en bildram utan att ändra källfilen. Du får också lära dig den grundläggande metoden för att applicera beskärningsmarginaler för att skapa en ren, fokuserad komposition direkt på bilden.

Följande Python‑kod visar hur du beskär en bild på en bild:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lägg till bilden i presentationens bildsamling.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Lägg till en bildram på bilden.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Beskär bilden (procentvärden).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Spara resultatet.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort beskurna områden av bilder**

Om du vill ta bort de beskurna områdena av en bild i en ram, använd metoden [delete_picture_cropped_areas](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Metoden returnerar den beskurna bilden, eller originalbilden om ingen beskärning behövs.

Följande Python‑kod demonstrerar operationen:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Hämta PictureFrame från den första bilden.
    picture_frame = slides.shape[0]

    # Hämta PictureFrame från den första bilden.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Spara resultatet.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Metoden [delete_picture_cropped_areas](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) lägger till den beskurna bilden i presentationens bildsamling. Om bilden endast används i den bearbetade [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) kan detta minska presentationsstorleken; annars kan antalet bilder i den resulterande presentationen öka.

Under beskärning konverterar metoden WMF/EMF‑metafiler till en raster‑PNG‑bild.
{{% /alert %}}

## **Komprimera bilder**

Du kan komprimera en bild i en presentation med metoden [PictureFillFormat.compress_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/compress_image/). Denna metod komprimerar en bild genom att minska dess storlek baserat på formens storlek och angiven upplösning, med möjlighet att ta bort beskurna områden.

Den justerar bildens storlek och upplösning på liknande sätt som PowerPoints **Picture Format → Compress Pictures → Resolution**‑funktion.

Följande Python‑exempel visar hur du komprimerar en bild i en presentation genom att ange en målupplösning och eventuellt ta bort beskurna områden:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Komprimera bilden med en målupplösning på 150 DPI (web-upplösning) och ta bort beskurna områden.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Kontrollera resultatet av komprimeringen.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Eller genom att ange ett eget DPI‑värde direkt:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Komprimera bilden till 150 DPI (web-upplösning), ta bort beskurna områden.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Metoden konverterar bilden till en lägre upplösning baserat på formens storlek och angivet DPI. Beskurna regioner kan också raderas för att optimera filstorleken.
Om bilden är en metafil (WMF/EMF) eller SVG kommer komprimering inte att tillämpas. JPEG‑kvaliteten bevaras eller minskas något beroende på upplösning, på samma sätt som PowerPoint hanterar högupplösta JPEG‑filer.
{{% /alert %}}

## **Lås bildförhållandet**

Om du vill att en form som innehåller en bild ska behålla sitt bildförhållande efter att du ändrat bildens dimensioner, sätt egenskapen [aspect_ratio_locked](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) till `True`.

Följande Python‑kod visar hur du låser en forms bildförhållande:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Lås bildförhållandet vid storleksändring.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Denna *Lock Aspect Ratio*-inställning bevarar endast formens bildförhållande, inte bildens förhållande inuti den.
{{% /alert %}}

## **Använd stretch‑offset‑egenskaper**

Genom att använda egenskaperna `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` och `stretch_offset_bottom` i klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/) kan du definiera en fyllningsrektangel.

När stretchning anges för en bild skalas källrektangeln för att passa fyllningsrektangeln. Varje kant av fyllningsrektangeln definieras av en procentuell offset från motsvarande kant av formens omgivningsruta. En positiv procent anger ett inskjut, medan en negativ procent anger ett utskjut.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till en bild efter dess index.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/).
4. Ange formens fyllningstyp.
5. Ange formens bildfyllningsläge.
6. Ladda en bild.
7. Tilldela bilden för att fylla formen.
8. Ange bildens offset från motsvarande kanter av formens omgivningsruta.
9. Spara presentationen som en PPTX‑fil.

Följande Python‑kod demonstrerar hur du använder stretch‑offset‑egenskaperna:

```py
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar en PPTX-fil.
with slides.Presentation() as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en rektangulär AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Ange formens fyllningstyp.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Ange formens bildfyllningsläge.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Läs in bilden och lägg till den i presentationen.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Tilldela bilden för att fylla formen.
    shape.fill_format.picture_fill_format.picture.image = image

    # Ange bildens offset från motsvarande kanter av formens omgivningsruta.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Spara PPTX-filen till disk.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose tillhandahåller gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter dig snabbt skapa presentationer från bilder.
{{% /alert %}}

## **Vanliga frågor**

**Hur kan jag ta reda på vilka bildformat som stöds för PictureFrame?**

Aspose.Slides stödjer både rasterbilder (PNG, JPEG, BMP, GIF osv.) och vektorbilder (till exempel SVG) via bildobjektet som tilldelas en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/). Listan över stödjade format överlappar i allmänhet med funktionerna i bild‑ och konverteringsmotorn.

**Hur påverkar att lägga till dussintals stora bilder PPTX‑storlek och prestanda?**

Att bädda in stora bilder ökar filstorlek och minnesanvändning; att länka bilder hjälper hålla presentationsstorleken nere men kräver att de externa filerna förblir åtkomliga. Aspose.Slides erbjuder möjlighet att lägga till bilder via länk för att minska filstorleken.

**Hur kan jag låsa ett bildobjekt så att det inte av misstag flyttas eller skalas?**

Använd [shape locks](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/picture_frame_lock/) för en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) (till exempel inaktivera flyttning eller skalning). Låsningsmekanismen beskrivs för former i en separat [protection article](/slides/sv/python-net/applying-protection-to-presentation/) och stöds för olika formtyper, inklusive [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/).

**Bevaras SVG‑vektorfidelitet när en presentation exporteras till PDF/bilder?**

Aspose.Slides låter dig extrahera en SVG från en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) som den ursprungliga vektorn. När du [exporterar till PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/) eller [rasterformat](/slides/sv/python-net/convert-powerpoint-to-png/) kan resultatet rasteriseras beroende på exportinställningarna; faktumet att den ursprungliga SVG:n lagras som en vektor bekräftas av extraktionsbeteendet.