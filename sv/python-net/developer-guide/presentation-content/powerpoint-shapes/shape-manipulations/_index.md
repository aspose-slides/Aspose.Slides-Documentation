---
title: Hantera former i presentationer med Python
linktitle: Formmanipulering
type: docs
weight: 40
url: /sv/python-net/shape-manipulations/
keywords:
- PowerPoint-form
- presentationsform
- form på bild
- hitta form
- klona form
- ta bort form
- dölj form
- ändra formordning
- hämta interop-form-ID
- formens alternativa text
- formlayoutformat
- form som SVG
- form till SVG
- justera form
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig skapa, redigera och optimera former i Aspose.Slides för Python via .NET och leverera högpresterande PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Den här guiden introducerar formmanipulation i Aspose.Slides för Python via .NET. Lär dig praktiska mönster för att hitta former (inklusive via Alternativ Text), duplicera, ta bort eller dölja, ändra ordning, justera och vända, läsa ID:n och layoutdriven formatering, samt exportera enskilda former till SVG med hjälp av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) API:erna.

## **Hitta former på bilder**

PowerPoint identifierar former endast med interna ID:n. Tilldela en unik Alt Text till målformen i PowerPoint, öppna sedan presentationen med Aspose.Slides för Python, iterera över bildens former och välj den vars Alt Text matchar. Metoden `find_shape` implementerar detta tillvägagångssätt och returnerar den matchande formen.

```py
import aspose.slides as slides

# Hittar en form på en bild via dess alternativa text.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instansiera Presentation-klassen som representerar en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Hitta formen med Alt Text "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **Klona former**

För att klona former från en källbild till en ny bild i Aspose.Slides, följ dessa steg:

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) från källfilen.
1. Hämta källbilden efter index och dess samling av former.
1. Hämta en tom layout från mastern.
1. Lägg till en tom bild med den layouten och hämta dess former.
1. Klona formerna till målbilden.
1. Spara presentationen som PPTX.

Följande kodexempel klonar former från en bild till en annan.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Spara presentationen till disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort former**

Aspose.Slides låter dig ta bort vilken form som helst från en bild. Till exempel, för att radera en form från den första bilden med dess alternativtext, följ dessa steg:

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans och läs in filen.
1. Öppna den första bilden från samlingen av bilder.
1. Hitta formen efter alternativtextvärdet.
1. Ta bort formen från bildens samling av former.
1. Spara presentationen till disk i PPTX‑format.

```py
import aspose.slides as slides

# Hittar en form på en bild via dess alternativa text.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instansiera Presentation-klassen som representerar en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Hitta formen med Alt Text "User Defined".
    shape = find_shape(slide, "User Defined")
    # Ta bort formen.
    slide.shapes.remove(shape)
    # Spara presentationen till disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dölj former**

Aspose.Slides låter dig dölja vilken form som helst på en bild. Till exempel, för att dölja en form på den första bilden med dess Alternativ Text, följ dessa steg:

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans och läs in filen.
1. Öppna den första bilden från samlingen av bilder.
1. Hitta formen efter Alternativ Text‑värdet.
1. Dölj formen.
1. Spara presentationen till disk i PPTX‑format.

```py
# Hittar en form på en bild via dess alternativa text.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instansiera Presentation-klassen som representerar en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Hitta formen med Alt Text "User Defined".
    shape = find_shape(slide, "User Defined")
    # Dölj formen.
    shape.hidden = True
    # Spara presentationen till disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ändra ordningen på former**

Aspose.Slides låter utvecklare ändra ordningen på former (ändra deras z‑order). Omordning avgör vilken form som visas framför eller bakom. Till exempel, för att omordna två former på den första bilden, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Öppna den första bilden.
1. Lägg till den första formen (till exempel en rektangel).
1. Lägg till den andra formen (till exempel en triangel).
1. Ändra ordningen på formerna genom att flytta den andra formen till den första positionen i samlingen.
1. Spara presentationen till disk.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Lägg till två former på bilden.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Flytta den andra formen till den första positionen.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Hämta Interop‑form‑ID**

Aspose.Slides låter dig hämta en forms unika identifierare på bildnivå, till skillnad från egenskapen `unique_id` som är unik för hela presentationen. Egendomen `office_interop_shape_id` finns på klassen [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/). Dess värde motsvarar `Id` för objektet `Microsoft.Office.Interop.PowerPoint.Shape`. Ett exempel på kodsnutt visas nedan.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Hämta formens unika identifierare inom bilden.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **Ange alternativ text för former**

Aspose.Slides låter utvecklare ange alternativ text för vilken form som helst. Du kan använda alternativ text för att identifiera och lokalisera former i en presentation. Egendomen för alternativ text kan läsas och skrivas både via Aspose.Slides och Microsoft PowerPoint. Genom att märka former med denna egendom kan du senare ta bort, dölja eller omordna dem på en bild.

För att ange alternativ text för en form, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Öppna den första bilden.
1. Lägg till en form på bilden.
1. Ange den alternativa texten.
1. Spara presentationen till disk.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar en PPTX-fil.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Lägg till en form.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Ange den alternativa texten för formen.
    shape.alternative_text = "User Defined"
    # Spara presentationen till disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till layoutformat för former**

Aspose.Slides tillhandahåller ett enkelt API för att komma åt layoutformat för former. Detta avsnitt visar hur man får åtkomst till layoutformat.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **Rendera former som SVG**

Aspose.Slides stödjer rendering av former som SVG. Metoden `write_as_svg` (och dess överlagringar) på klassen [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) låter dig spara en fas innehåll som en SVG‑bild. Kodsnutten nedan visar hur man exporterar en form till en SVG‑fil.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Hämta den första formen på den första bilden.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **Justera form**

Med metoden `align_shape` i klassen [SlidesUtil](https://reference.aspose.com/slides/sv/python-net/aspose.slides.util/slideutil/) kan du:

* Justera former i förhållande till bildens marginaler (se Exempel 1).
* Justera former i förhållande till varandra (se Exempel 2).

Enumerationen [ShapesAlignmentType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapesalignmenttype/) definierar de tillgängliga justeringsalternativen.

**Exempel 1**

Denna Python‑kod visar hur man justerar formerna med index 1, 2 och 4 till bildens överkant:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**Exempel 2**

Detta Python‑exempel visar hur man justerar alla former i en samling i förhållande till den nedersta formen i samlingen:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **Vänd‑egenskaper**

I Aspose.Slides ger klassen [ShapeFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapeframe/) kontroll över horisontell och vertikal spegling av former via egenskaperna `flip_h` och `flip_v`. Båda egenskaperna är av typen [NullableBool](https://reference.aspose.com/slides/sv/python-net/aspose.slides/nullablebool/), vilket tillåter värdena `TRUE` för att indikera en vändning, `FALSE` för ingen vändning, eller `NOT_DEFINED` för att använda standardbeteende. Dessa värden är åtkomliga från en forms [Frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/frame/).

För att ändra vändinställningarna skapas en ny [ShapeFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapeframe/)‑instans med formens aktuella position och storlek, önskade värden för `flip_h` och `flip_v` samt rotationsvinkeln. Genom att tilldela denna instans till formens [Frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/frame/) och spara presentationen tillämpas speglings‑transformationerna och skrivs till utdatafilen.

Anta att vi har en fil sample.pptx där den första bilden innehåller en enda form med standardvändningsinställningar, som visas nedan.

![Formen som ska vändas](shape_to_be_flipped.png)

Följande kodexempel hämtar formens aktuella vändegenskaper och vänder den både horisontellt och vertikalt.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Hämta den horisontella vändningsegenskapen för formen.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Hämta den vertikala vändningsegenskapen för formen.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Vänd horisontellt och vertikalt.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

![Den vända formen](flipped_shape.png)

## **FAQ**

**Kan jag kombinera former (union/intersect/subtract) på en bild som i en skrivbordsredigerare?**

Det finns inget inbyggt API för booleska operationer. Du kan approximera det genom att själva konstruera den önskade konturen – t.ex. beräkna den resulterande geometrin (via [GeometryPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides/geometrypath/)) och skapa en ny form med den konturen, eventuellt ta bort de ursprungliga.

**Hur kan jag kontrollera staplingsordningen (z‑order) så att en form alltid förblir "överst"?**

Ändra insättnings‑/flyttordningen inom bildens [shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/shapes/)‑samling. För förutsägbara resultat, avsluta z‑ordningen efter alla andra bildändringar.

**Kan jag "låsa" en form för att hindra användare från att redigera den i PowerPoint?**

Ja. Ställ in [skyddflaggor på formnivå](/slides/sv/python-net/applying-protection-to-presentation/) (t.ex. lås urval, förflyttning, storleksändring, textredigering). Vid behov kan liknande restriktioner tillämpas på mastern eller layouten. Observera att detta är skydd på UI‑nivå, inte en säkerhetsfunktion; för starkare skydd, kombinera med fil‑nivårestriktioner som [rekommendationer för skrivskydd eller lösenord](/slides/sv/python-net/password-protected-presentation/).