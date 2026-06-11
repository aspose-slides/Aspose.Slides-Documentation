---
title: Hantera ActiveX‑kontroller i presentationer med Python
linktitle: ActiveX
type: docs
weight: 80
url: /sv/python-net/activex/
keywords:
- ActiveX
- ActiveX‑kontroll
- hantera ActiveX
- lägga till ActiveX
- modifiera ActiveX
- media spelare
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur Aspose.Slides för Python via .NET utnyttjar ActiveX för att automatisera och förbättra PowerPoint‑presentationer, vilket ger utvecklare kraftfull kontroll över bilder."
---
## **Introduktion**

ActiveX‑kontroller används i presentationer. Aspose.Slides för Python via .NET låter dig hantera ActiveX‑kontroller, men det är lite knepigare och annorlunda än vanliga presentationsformer. Från Aspose.Slides för Python via .NET 6.9.0 stödjer komponenten hantering av ActiveX‑kontroller. För närvarande kan du komma åt redan tillagda ActiveX‑kontroller i din presentation och ändra eller ta bort dem genom att använda deras olika egenskaper. Kom ihåg att ActiveX‑kontroller inte är former och inte ingår i presentationens IShapeCollection utan i den separata IControlCollection. Denna artikel visar hur du arbetar med dem.

## **Ändra ActiveX‑kontroller**
För att hantera en enkel ActiveX‑kontroll som en textruta och en enkel kommandoknapp på en bild:

1. Skapa en instans av Presentation‑klassen och läs in presentationen som innehåller ActiveX‑kontroller.
1. Hämta en referens till en bild via dess index.
1. Kom åt ActiveX‑kontrollerna på bilden genom att använda IControlCollection.
1. Kom åt TextBox1‑ActiveX‑kontrollen med ControlEx‑objektet.
1. Ändra de olika egenskaperna för TextBox1‑ActiveX‑kontrollen inklusive text, teckensnitt, teckenhöjd och ramposition.
1. Kom åt den andra åtkomstkontrollen som heter CommandButton1.
1. Ändra knappens rubrik, teckensnitt och position.
1. Justera positionen för ActiveX‑kontrollernas ramar.
1. Skriv den modifierade presentationen till en PPTX‑fil.

Kodsnutten nedan uppdaterar ActiveX‑kontrollerna på presentationsbilderna till bilden som visas nedan.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Öppnar presentationen med ActiveX‑kontroller
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Öppnar den första bilden i presentationen
    slide = presentation.slides[0]

    # ändrar TextBox‑text
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # byter ersättningsbild. PowerPoint kommer att ersätta denna bild under ActiveX‑aktivering, så ibland är det OK att låta bilden vara oförändrad.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # byter knapptext
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # byter ersättning
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # Flyttar ActiveX‑ramar 100 punkter nedåt
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # Sparar presentationen med redigerade ActiveX‑kontroller
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Tar nu bort kontroller
    slide.controls.clear()

    # Sparar presentationen med rensade ActiveX‑kontroller
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Lägg till ActiveX Media Player‑kontroll**
För att lägga till en ActiveX Media Player‑kontroll, följ dessa steg:

1. Skapa en instans av Presentation‑klassen och läs in exempelpresentationen som innehåller Media Player‑ActiveX‑kontroller.
1. Skapa en instans av mål‑Presentation‑klassen och skapa ett tomt presentationsobjekt.
1. Klon bild med Media Player‑ActiveX‑kontroll från mallpresentationen till mål‑Presentation.
1. Kom åt den klonade bilden i mål‑Presentation.
1. Kom åt ActiveX‑kontrollerna på bilden genom att använda IControlCollection.
1. Kom åt Media Player‑ActiveX‑kontrollen och ange videovägen via dess egenskaper.
1. Spara presentationen till en PPTX‑fil.

```py
import aspose.slides as slides

# Instansiera Presentation‑klass som representerar PPTX‑fil
with slides.Presentation(path + "template.pptx") as presentation:

    # Skapa tom presentationinstans
    with slides.Presentation() as newPresentation:

        # Ta bort standardbild
        newPresentation.slides.remove_at(0)

        # Klona bild med Media Player ActiveX‑kontroll
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Hämta Media Player ActiveX‑kontrollen och ange videovägen
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Spara presentationen
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Behåller Aspose.Slides ActiveX‑kontroller när de läses in och sparas om de inte kan köras i Python‑runtime?**

Ja. Aspose.Slides behandlar dem som en del av presentationen och kan läsa/ändra deras egenskaper och ramar; det är inte nödvändigt att köra kontrollerna för att bevara dem.

**Hur skiljer sig ActiveX‑kontroller från OLE‑objekt i en presentation?**

ActiveX‑kontroller är interaktiva hanterade kontroller (knappar, textrutor, media player), medan [OLE](/slides/sv/python-net/manage-ole/) avser inbäddade programobjekt (till exempel ett Excel‑blad). De lagras och hanteras på olika sätt och har olika egenskapsmodeller.

**Fungerar ActiveX‑händelser och VBA‑makron om filen har modifierats av Aspose.Slides?**

Aspose.Slides bevarar den befintliga markupen och metadata; dock körs händelser och makron endast i PowerPoint på Windows när säkerheten tillåter det. Biblioteket kör inte VBA.