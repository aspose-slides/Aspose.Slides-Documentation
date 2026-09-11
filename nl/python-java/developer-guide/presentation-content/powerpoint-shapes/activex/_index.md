---
title: Beheer ActiveX-besturingselementen in presentaties met Python
linktitle: ActiveX
type: docs
weight: 80
url: /nl/python-java/activex/
keywords:
- ActiveX
- ActiveX-besturingselement
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe Aspose.Slides for Python via Java ActiveX gebruikt om PowerPoint-presentaties te automatiseren en te verbeteren, waardoor ontwikkelaars volledige controle over dia's krijgen."
---
## **Introductie**

ActiveX-besturingselementen worden gebruikt in presentaties. Aspose.Slides for Python via Java stelt u in staat ActiveX-besturingselementen toe te voegen en te beheren, maar ze zijn iets lastiger te hanteren dan gewone presentatie-vormen. Aspose.Slides ondersteunt het toevoegen van Media Player ActiveX-besturingselementen. Merk op dat ActiveX-besturingselementen geen vormen zijn; ze maken geen deel uit van de presentatie's [ShapeCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/). Ze behoren tot de aparte [ControlCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/controlcollection/) in plaats daarvan. In dit onderwerp laten we u zien hoe u ermee kunt werken.

## **Een Media Player ActiveX-besturingselement toevoegen aan een dia**

Om een ActiveX Media Player-besturingselement toe te voegen, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)-klasse en genereer een lege presentatie‑instantie.
1. Open de doel‑dia in de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/).
1. Voeg het Media Player ActiveX-besturingselement toe met behulp van de [addControl](https://reference.aspose.com/slides/nl/python-java/aspose.slides/controlcollection/#addControl)-methode die wordt aangeboden door de [ControlCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/controlcollection/).
1. Verkrijg toegang tot het Media Player ActiveX-besturingselement en stel het video-pad in via zijn eigenschappen.
1. Sla de presentatie op als een PPTX-bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, toont hoe u een Media Player ActiveX-besturingselement aan een dia toevoegt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Maak een lege presentatie.
presentation = Presentation()
try:
    # Voeg het Media Player ActiveX-besturingselement toe.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Stel het video-pad in.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Sla de presentatie op.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Een ActiveX-besturingselement wijzigen**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java biedt componenten voor het beheren van ActiveX-besturingselementen. U kunt het reeds toegevoegde ActiveX-besturingselement in uw presentatie benaderen en via de eigenschappen wijzigen of verwijderen.
{{% /alert %}}

Om een eenvoudig ActiveX-besturingselement, zoals een tekstvak en een eenvoudige opdrachtknop op een dia, te beheren, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)-klasse en laad de presentatie die ActiveX-besturingselementen bevat.
1. Verkrijg een dia-referentie op basis van de index.
1. Benader de ActiveX-besturingselementen op de dia via de [ControlCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/controlcollection/).
1. Verkrijg toegang tot het TextBox1 ActiveX-besturingselement met behulp van het [Control](https://reference.aspose.com/slides/nl/python-java/aspose.slides/control/)-object.
1. Wijzig de eigenschappen van het TextBox1 ActiveX-besturingselement, zoals tekst, lettertype, lettergrootte en frame-positie.
1. Benader het tweede ActiveX-besturingselement genaamd CommandButton1.
1. Wijzig de knop-bijschrift, het lettertype en de positie.
1. Verplaats de positie van de frames van de ActiveX-besturingselementen.
1. Schrijf de aangepaste presentatie naar een PPTM-bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, toont hoe u een eenvoudig ActiveX-besturingselement beheert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# Laad de presentatie met ActiveX-besturingselementen.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Open de eerste dia.
        slide = presentation.getSlides().get_Item(0)

        # Wijzig de tekst van het tekstvak.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Wijzig de vervangende afbeelding. PowerPoint vervangt deze tijdens ActiveX‑activering,
            # waardoor het soms onveranderd kan blijven.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Wijzig het knopbijschrift.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Wijzig de vervangende afbeelding.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Verplaats de besturingselementen omlaag met 100 punten.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Verwijder de besturingselementen.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **Veelgestelde vragen**

**Behoudt Aspose.Slides ActiveX-besturingselementen bij het lezen en opnieuw opslaan als ze niet kunnen worden uitgevoerd in de Python-runtime?**

Ja. Aspose.Slides beschouwt ze als onderdeel van de presentatie en kan hun eigenschappen en frames lezen/wijzigen; het uitvoeren van de besturingselementen zelf is niet vereist om ze te behouden.

**Hoe verschillen ActiveX-besturingselementen van OLE-objecten in een presentatie?**

ActiveX-besturingselementen zijn interactieve beheerde besturingselementen (knoppen, tekstvakken, mediaspeler), terwijl [OLE](/slides/nl/python-java/manage-ole/) verwijst naar ingesloten toepassingsobjecten (bijvoorbeeld een Excel-werkblad). Ze worden anders opgeslagen en verwerkt en hebben verschillende eigenschapsmodellen.

**Werken ActiveX-events en VBA-macro's als het bestand is gewijzigd door Aspose.Slides?**

Aspose.Slides behoudt de bestaande markup en metadata; echter, events en macro's worden alleen uitgevoerd in PowerPoint op Windows wanneer de beveiliging het toestaat. De bibliotheek voert geen VBA uit.