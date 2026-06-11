---
title: Optimera bildhantering i PowerPoint med Python
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/python-net/image/
keywords:
- lägg till bild
- lägg till bild
- lägg till bitmap
- byt ut bild
- byt ut bild
- från webben
- bakgrund
- lägg till PNG
- lägg till JPG
- lägg till SVG
- lägg till EMF
- lägg till WMF
- lägg till TIFF
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Effektivisera bildhantering i PowerPoint och OpenDocument med Aspose.Slides för Python via .NET, optimera prestanda och automatisera ditt arbetsflöde."
---
## **Introduktion**

Bilder gör presentationer mer engagerande och intressanta. I Microsoft PowerPoint kan du infoga bilder från en fil, internet eller andra källor på bildspel. På samma sätt låter Aspose.Slides dig lägga till bilder på bildspel på flera sätt.

{{% alert  title="Tips" color="primary" %}}

Aspose erbjuder gratis konverterare—[JPEG to PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG to PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter dig snabbt skapa presentationer från bilder.

{{% /alert %}}

{{% alert title="Info" color="info" %}}

Om du vill lägga till en bild som ett bildram‑objekt—särskilt om du planerar att använda standardformateringsalternativ såsom storleksändring eller tillämpning av effekter—se [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/sv/python-net/picture-frame/).

{{% /alert %}}

{{% alert title="Obs" color="warning" %}}

Du kan använda bild‑ och presentation‑I/O‑operationer för att konvertera bilder mellan format. Se dessa sidor: konvertera [image to JPG](https://products.aspose.com/slides/sv/python-net/conversion/image-to-jpg/); konvertera [JPG to image](https://products.aspose.com/slides/sv/python-net/conversion/jpg-to-image/); konvertera [JPG to PNG](https://products.aspose.com/slides/sv/python-net/conversion/jpg-to-png/); konvertera [PNG to JPG](https://products.aspose.com/slides/sv/python-net/conversion/png-to-jpg/); konvertera [PNG to SVG](https://products.aspose.com/slides/sv/python-net/conversion/png-to-svg/); och konvertera [SVG to PNG](https://products.aspose.com/slides/sv/python-net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides stödjer arbete med bilder i populära format såsom JPEG, PNG, BMP, GIF och andra.

## **Lägg till lokalt lagrade bilder på bildspel**

Du kan lägga till en eller flera bilder från din dator på en bild i en presentation. Följande Python‑exempel visar hur du lägger till en bild på en bild:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till bilder från webben på bildspel**

Om bilden du vill lägga till på en bild inte finns på din dator kan du infoga den direkt från webben.

Följande Python‑exempel visar hur du lägger till en bild från en URL på en bild:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till bilder på bildmasters**

En bildmaster är den översta bilden som lagrar och styr information—tema, layout och så vidare—för alla bilder under den. När du lägger till en bild på en bildmaster visas den bilden på varje bild som använder den mastern.

Följande Python‑exempel visar hur du lägger till en bild på en bildmaster:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange en bild som bakgrund för en bild**

Du kanske vill använda en bild som bakgrund för en specifik bild eller flera bilder. För detaljer, se [Set an Image as the Background for a Slide](https://docs.aspose.com/slides/sv/python-net/presentation-background/#set-image-as-background-for-slide).

## **Lägg till SVG i presentationer**

Du kan infoga vilken bild som helst i en presentation med metoden [add_picture_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_picture_frame/) i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/).

För att skapa ett bildobjekt från en SVG, följ dessa steg:

1. Skapa en [SvgImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/) och lägg till den i presentationens bildsamling.
2. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/)‑objekt från [SvgImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/).
3. Skapa ett [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/)‑objekt med hjälp av [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/).

Följande Python‑exempel visar hur du lägger till en SVG‑bild i en presentation med dessa steg:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Läs innehållet i en SVG-fil.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # Skapa ett SvgImage-objekt.
        svg_image = slides.SvgImage(svg_content)

        # Skapa ett PPImage-objekt.
        pp_image = presentation.images.add_image(svg_image)

        # Skapa en ny PictureFrame.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # Spara presentationen i PPTX-format.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Konvertera SVG till en uppsättning former**

Aspose.Slides konverterar SVG‑filer till en uppsättning former på ett sätt som liknar PowerPoints SVG‑hantering.

![PowerPoint Popup Menu](img_01_01.png)

Denna funktionalitet tillhandahålls av en överlagring av metoden [add_group_shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_group_shape/) i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/) som tar en [SvgImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/) som första argument. 

Koden nedan visar hur du konverterar en SVG‑fil till en uppsättning former.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Läs SVG-filens innehåll.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Skapa ett SvgImage-objekt.
        svg_image = slides.SvgImage(svg_content)

        # Hämta bildens storlek.
        slide_size = presentation.slide_size.size

        # Konvertera SVG-bilden till en grupp av former och skala den till bildens storlek.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Spara presentationen i PPTX-format.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till bilder som EMF i bildspel**

Aspose.Slides för Python låter dig infoga Enhanced Metafile (EMF)‑bilder i presentationer.

Följande Python‑exempel demonstrerar detta:

```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Byt ut bilder i bildsamlingen**

Aspose.Slides gör det möjligt att ersätta bilder som lagras i en presentations bildsamling, inklusive de som används av bildformer. Detta avsnitt beskriver flera tillvägagångssätt för att uppdatera bilder i samlingen. API‑et tillhandahåller enkla metoder för att ersätta en bild med rå byte‑data, en [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/)‑instans eller en annan bild som redan finns i samlingen.

Följ dessa steg:

1. Ladda presentationen som innehåller bilderna med klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Läs in en ny bild från en fil till en byte‑array.
1. Ersätt mål­bilden med den nya bilden med hjälp av byte‑arrayen.
1. Alternativt, läs in bilden i ett [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/)‑objekt och ersätt mål­bilden med det objektet.
1. Eller ersätt mål­bilden med en bild som redan finns i presentationens bildsamling.
1. Spara den modifierade presentationen som en PPTX‑fil.

```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:

    # Första sättet.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # Andra sättet.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # Tredje sättet.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Spara presentationen till en fil.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}

Med Asposes gratiskonverterare för [Text to GIF](https://products.aspose.app/slides/sv/text-to-gif) kan du enkelt animera text och skapa GIF‑ar från text.

{{% /alert %}}

## **FAQ**

**Behåller den ursprungliga bildens upplösning sin integritet efter infogning?**

Ja. Källpixelna bevaras, men det slutliga utseendet beror på hur [picture](/slides/sv/python-net/picture-frame/) skalas på bilden och eventuell komprimering vid sparande.

**Vad är det bästa sättet att ersätta samma logotyp på dussintals bilder samtidigt?**

Placera logotypen på master‑bilden eller en layout och ersätt den i presentationens bildsamling—uppdateringar sprids till alla element som använder den resursen.

**Kan en infogad SVG konverteras till redigerbara former?**

Ja. Du kan konvertera en SVG till en grupp av former, varpå enskilda delar blir redigerbara med standardformsegenskaper.

**Hur kan jag sätta en bild som bakgrund för flera bilder samtidigt?**

[Assign the image as the background](/slides/sv/python-net/presentation-background/) på master‑bilden eller den relevanta layouten—alla bilder som använder den mastern/layouten kommer att ärva bakgrunden.

**Hur förhindrar jag att presentationen “ballongiseras” i storlek på grund av många bilder?**

Återanvänd en enda bildresurs i stället för dubbletter, välj rimliga upplösningar, tillämpa komprimering vid sparande och håll upprepade grafik på master‑nivå där det är lämpligt.