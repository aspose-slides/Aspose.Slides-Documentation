---
title: Beheren van ActiveX‑besturingselementen in presentaties met Python
linktitle: ActiveX
type: docs
weight: 80
url: /nl/python-net/activex/
keywords:
- ActiveX
- ActiveX‑besturingselement
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe Aspose.Slides for Python via .NET ActiveX gebruikt om PowerPoint‑presentaties te automatiseren en te verbeteren, waardoor ontwikkelaars krachtige controle over dia's krijgen."
---
## **Inleiding**

ActiveX‑besturingselementen worden gebruikt in presentaties. Aspose.Slides for Python via .NET stelt u in staat om ActiveX‑besturingselementen te beheren, maar het beheer daarvan is wat lastiger en verschilt van normale presentatie‑vormen. Vanaf Aspose.Slides for Python via .NET 6.9.0 ondersteunt de component het beheer van ActiveX‑besturingselementen. Op dit moment kunt u een reeds toegevoegd ActiveX‑besturingselement in uw presentatie benaderen en modificeren of verwijderen met behulp van de verschillende eigenschappen. Onthoud dat ActiveX‑besturingselementen geen vormen zijn en geen deel uitmaken van de IShapeCollection van de presentatie, maar van de aparte IControlCollection. Dit artikel laat zien hoe u ermee kunt werken.

## **ActiveX‑besturingselementen wijzigen**
Om een eenvoudig ActiveX‑besturingselement zoals een tekstvak en een eenvoudige opdrachtknop op een dia te beheren:

1. Maak een instantie van de Presentation‑klasse en laad de presentatie die ActiveX‑besturingselementen bevat.
2. Haal een dia‑referentie op via de index.
3. Benader de ActiveX‑besturingselementen in de dia via de IControlCollection.
4. Benader het TextBox1‑ActiveX‑besturingselement met behulp van het ControlEx‑object.
5. Wijzig de verschillende eigenschappen van het TextBox1‑ActiveX‑besturingselement, waaronder tekst, lettertype, lettergrootte en positie van het kader.
6. Benader het tweede besturingselement genoemd CommandButton1.
7. Wijzig de knopbijschrift, het lettertype en de positie.
8. Verplaats de positie van de kaders van de ActiveX‑besturingselementen.
9. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Het onderstaande code‑fragment werkt de ActiveX‑besturingselementen op de presentatiedia’s bij volgens de dia zoals hieronder getoond.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Toegang tot de presentatie met ActiveX‑besturingselementen
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Toegang tot de eerste dia in de presentatie
    slide = presentation.slides[0]

    # tekst van TextBox wijzigen
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # vervangende afbeelding wijzigen. PowerPoint zal deze afbeelding vervangen tijdens ActiveX‑activatie, dus soms mag de afbeelding ongewijzigd blijven.

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

    # knopbijschrift wijzigen
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # vervangende afbeelding wijzigen
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
    
    # ActiveX‑kaders 100 punten naar beneden verplaatsen
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

    # Presentatie opslaan met bewerkte ActiveX‑besturingselementen
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Besturingselementen nu verwijderen
    slide.controls.clear()

    # Presentatie opslaan met verwijderde ActiveX‑besturingselementen
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **ActiveX Media Player‑besturingselement toevoegen**
Om een ActiveX Media Player‑besturingselement toe te voegen, volgt u de onderstaande stappen:

1. Maak een instantie van de Presentation‑klasse en laad de voorbeeldpresentatie die Media Player‑ActiveX‑besturingselementen bevat.
2. Maak een instantie van de doel‑Presentation‑klasse en genereer een lege presentatie‑instantie.
3. Kloon de dia met Media Player‑ActiveX‑besturingselement uit de sjabloon‑presentatie naar de doel‑Presentation.
4. Benader de gekloonde dia in de doel‑Presentation.
5. Benader de ActiveX‑besturingselementen in de dia via de IControlCollection.
6. Benader het Media Player‑ActiveX‑besturingselement en stel het videopad in via de eigenschappen.
7. Sla de presentatie op als een PPTX‑bestand.

```py
import aspose.slides as slides

# Instantieer Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
with slides.Presentation(path + "template.pptx") as presentation:

    # Maak een lege presentatie‑instantie
    with slides.Presentation() as newPresentation:

        # Verwijder de standaarddia
        newPresentation.slides.remove_at(0)

        # Kloon de dia met Media Player ActiveX‑besturingselement
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Toegang tot het Media Player ActiveX‑besturingselement en stel het videopad in
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Sla de presentatie op
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Behoudt Aspose.Slides ActiveX‑besturingselementen bij het lezen en opnieuw opslaan als ze niet uitgevoerd kunnen worden in de Python‑runtime?**

Ja. Aspose.Slides beschouwt ze als onderdeel van de presentatie en kan hun eigenschappen en kaders lezen/wijzigen; het uitvoeren van de besturingselementen zelf is niet vereist om ze te behouden.

**Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten in een presentatie?**

ActiveX‑besturingselementen zijn interactieve beheerde componenten (knoppen, tekstvakken, mediaplayer), terwijl [OLE](/slides/nl/python-net/manage-ole/) verwijst naar ingebedde toepassingsobjecten (bijvoorbeeld een Excel‑werkblad). Ze worden anders opgeslagen en verwerkt en hebben verschillende eigenschapsmodellen.

**Werken ActiveX‑gebeurtenissen en VBA‑macro's als het bestand is aangepast door Aspose.Slides?**

Aspose.Slides behoudt de bestaande markup en metadata; echter, gebeurtenissen en macro's worden alleen uitgevoerd binnen PowerPoint op Windows wanneer de beveiligingsinstellingen dit toestaan. De bibliotheek voert geen VBA uit.