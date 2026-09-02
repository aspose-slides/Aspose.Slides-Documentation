---
title: Optimera bildhantering i PowerPoint med Python
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/python-net/image/
keywords:
- lägg till bild
- lägg till foto
- lägg till bitmap
- ersätt bild
- ersätt foto
- från webben
- bakgrund
- lägg till PNG
- lägg till JPG
- lägg till SVG
- lägg till EMF
- lägg till WMF
- lägg till TIFF
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Effektivisera bildhantering i PowerPoint och OpenDocument med Aspose.Slides för Python via .NET, optimera prestanda och automatisera ditt arbetsflöde."
---
## **Introduktion**

Bilder gör presentationer mer engagerande och intressanta. I Microsoft PowerPoint kan du infoga bilder från en fil, internet eller andra källor på bildspel. På samma sätt låter Aspose.Slides dig lägga till bilder på bildspel på flera sätt.

{{% alert  title="Tip" color="primary" %}}
Aspose tillhandahåller gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter dig snabbt skapa presentationer från bilder.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Om du vill lägga till en bild som ett ramobjekt—särskilt om du planerar att använda standardformateringsalternativ såsom storleksändring eller applicering av effekter—se [Lägg till bildramar i presentationer med Python](https://docs.aspose.com/slides/sv/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Du kan använda bild- och presentation I/O‑operationer för att konvertera bilder mellan format. Se dessa sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/python-net/conversion/image-to-jpg/); konvertera [JPG till bild](https://products.aspose.com/slides/sv/python-net/conversion/jpg-to-image/); konvertera [JPG till PNG](https://products.aspose.com/slides/sv/python-net/conversion/jpg-to-png/); konvertera [PNG till JPG](https://products.aspose.com/slides/sv/python-net/conversion/png-to-jpg/); konvertera [PNG till SVG](https://products.aspose.com/slides/sv/python-net/conversion/png-to-svg/); och konvertera [SVG till PNG](https://products.aspose.com/slides/sv/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides stöder arbete med bilder i vanliga format som JPEG, PNG, BMP, GIF och andra.

## **Lägg till bilder som lagras lokalt på bildspel**

Du kan lägga till en eller flera bilder från din dator till en bild i en presentation. Följande Python‑exempel visar hur du lägger till en bild på en bild:

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
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ladda ner de råa bildbytarna.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till bilder till bildmaster**

En bildmaster är den översta bilden som lagrar och styr information—tema, layout osv.—för alla bilder under den. När du lägger till en bild till en bildmaster visas den bilden på varje bild som använder den mastern.

Följande Python‑exempel visar hur du lägger till en bild till en bildmaster:

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

## **Lägg till bilder som bildbakgrunder**

Du kan använda en bild som bakgrund för en eller flera bilder. För detaljer, se *[Ställa in bilder som bakgrunder för bilder](/slides/sv/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **Lägg till SVG i presentationer**

SVG‑innehåll kan läggas till i en presentation med hjälp av klassen [SvgImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/). Den resulterande SVG‑bilden kan sedan läggas till i presentationens bildsamling och användas för att skapa en bildram.

Följande Python‑exempel importerar en självständig SVG‑sträng. Alla bilder, stilar och andra resurser som används av denna SVG är inbäddade direkt i SVG‑innehållet.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Konvertera SVG till en uppsättning former**

Aspose.Slides konverterar SVG‑filer till en uppsättning former på ett sätt som liknar PowerPoints hantering av SVG.

![PowerPoint Popup Menu](img_01_01.png)

Denna funktionalitet tillhandahålls av en överlagring av metoden [add_group_shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_group_shape/) i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/) som tar en [SvgImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/svgimage/) som sitt första argument.

Exempelkoden nedan visar hur man konverterar en SVG‑fil till en uppsättning former.

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

## **Lägg till bilder som EMF på bildspel**

Aspose.Slides för Python låter dig infoga Enhanced Metafile (EMF)-bilder i presentationer.

Följande Python‑exempel demonstrerar detta:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Ersätt bilder i bildsamlingen**

Aspose.Slides låter dig ersätta bilder som lagras i en presentations bildsamling, inklusive de som används av bildformer. Detta avsnitt beskriver flera tillvägagångssätt för att uppdatera bilder i samlingen. API:et erbjuder enkla metoder för att ersätta en bild med rå byte‑data, en [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/)‑instans, eller en annan bild som redan finns i samlingen.

Följ dessa steg:

1. Läs in presentationen som innehåller bilderna med klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Läs in en ny bild från en fil till en byte‑array.
1. Ersätt målbilden med den nya bilden med hjälp av byte‑arrayen.
1. Alternativt, läs in bilden i ett [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/)‑objekt och ersätt målbilden med det objektet.
1. Eller ersätt målbilden med en bild som redan finns i presentationens bildsamling.
1. Spara den ändrade presentationen som en PPTX‑fil.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Skapa ett Presentation-objekt som representerar en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:

    # Det första sättet.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # Det andra sättet.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # Det tredje sättet.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Spara presentationen till en fil.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Med Asposes gratis [Text till GIF](https://products.aspose.app/slides/sv/text-to-gif)-konverterare kan du enkelt animera text och skapa GIF‑filer från text.
{{% /alert %}}

## **Vanliga frågor**

**Behåller den ursprungliga bildupplösningen sin integritet efter infogning?**

Ja. Källpixlarna bevaras, men det slutliga utseendet beror på hur [bilden](/slides/sv/python-net/picture-frame/) skalas på bilden och eventuell kompression som appliceras vid sparning.

**Vad är det bästa sättet att ersätta samma logotyp på dussintals bilder samtidigt?**

Placera logotypen på masterbilden eller en layout och ersätt den i presentationens bildsamling — uppdateringar sprids till alla element som använder den resursen.

**Kan en infogad SVG konverteras till redigerbara former?**

Ja. Du kan konvertera en SVG till en grupp former, varefter enskilda delar blir redigerbara med standardformsegenskaper.

**Hur kan jag sätta en bild som bakgrund för flera bilder samtidigt?**

[Tilldela bilden som bakgrund](/slides/sv/python-net/presentation-background/) på masterbilden eller den relevanta layouten — alla bilder som använder den mastern/layouten kommer att ärva bakgrunden.

**Hur förhindrar jag att en presentation blir för stor på grund av många bilder?**

Återanvänd en enda bildresurs i stället för dubbletter, välj rimliga upplösningar, tillämpa kompression vid sparning och håll upprepade grafik på mastern där det är lämpligt.