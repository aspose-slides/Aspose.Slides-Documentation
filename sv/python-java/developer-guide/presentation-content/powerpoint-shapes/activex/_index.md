---
title: "Hantera ActiveX-kontroller i presentationer med Python"
linktitle: "ActiveX"
type: docs
weight: 80
url: /sv/python-java/activex/
keywords:
- ActiveX
- "ActiveX-kontroll"
- "hantera ActiveX"
- "lägga till ActiveX"
- "modifiera ActiveX"
- "mediaspelare"
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur Aspose.Slides för Python via Java använder ActiveX för att automatisera och förbättra PowerPoint-presentationer, vilket ger utvecklare kraftfull kontroll över bildspel."
---
## **Introduction**

ActiveX-kontroller används i presentationer. Aspose.Slides för Python via Java låter dig lägga till och hantera ActiveX-kontroller, men de är lite svårare att hantera jämfört med vanliga presentationsformer. Aspose.Slides stödjer att lägga till Media Player ActiveX-kontroller. Observera att ActiveX-kontroller inte är former; de är inte en del av presentationens [ShapeCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/). De är en del av den separata [ControlCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/controlcollection/) istället. I detta avsnitt visar vi hur du arbetar med dem.

## **Add a Media Player ActiveX Control to a Slide**

1. Skapa en instans av klassen [Presentation] och skapa ett tomt presentationsobjekt.
2. Hämta målbilden i [Presentation].
3. Lägg till Media Player ActiveX-kontrollen med metoden [addControl] som exponeras av [ControlCollection].
4. Hämta Media Player ActiveX-kontrollen och ange videovägen via dess egenskaper.
5. Spara presentationen som en PPTX-fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Skapa en tom presentation.
presentation = Presentation()
try:
    # Lägg till Media Player ActiveX-kontrollen.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Ange videovägen.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Spara presentationen.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modify an ActiveX Control**

{{% alert color="info" title="Note" %}}
Aspose.Slides för Python via Java tillhandahåller komponenter för att hantera ActiveX-kontroller. Du kan komma åt den redan tillagda ActiveX-kontrollen i din presentation och ändra eller ta bort den via dess egenskaper.
{{% /alert %}}

1. Skapa en instans av klassen [Presentation] och ladda presentationen som innehåller ActiveX-kontroller.
2. Hämta en bildreferens via dess index.
3. Kom åt ActiveX-kontrollerna på bilden genom att nå [ControlCollection].
4. Hämta TextBox1 ActiveX-kontrollen med hjälp av objektet [Control].
5. Ändra egenskaperna för TextBox1 ActiveX-kontrollen, inklusive text, teckensnitt, teckensnittshöjd och ramposition.
6. Hämta den andra ActiveX-kontrollen som heter CommandButton1.
7. Ändra knappens rubrik, teckensnitt och position.
8. Justera positionen för ActiveX-kontrollerna ramar.
9. Skriv den ändrade presentationen till en PPTM-fil.

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

# Läs in presentationen med ActiveX-kontroller.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Hämta den första bilden.
        slide = presentation.getSlides().get_Item(0)

        # Ändra textrutans text.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Ändra ersättningsbilden. PowerPoint ersätter den under ActiveX-aktivering,
            # så den ibland kan lämnas oförändrad.
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

        # Ändra knappens rubrik.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Ändra ersättningsbilden.
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

        # Flytta kontrollerna neråt med 100 punkter.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Ta bort kontrollerna.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **FAQ**

**Does Aspose.Slides preserve ActiveX controls when reading and re-saving if they cannot be executed in the Python runtime?**

Ja. Aspose.Slides betraktar dem som en del av presentationen och kan läsa/ändra deras egenskaper och ramar; att köra kontrollerna själva krävs inte för att bevara dem.

**How do ActiveX controls differ from OLE objects in a presentation?**

ActiveX-kontroller är interaktiva hanterade kontroller (knappar, textrutor, mediaplayer), medan [OLE](/slides/sv/python-java/manage-ole/) avser inbäddade programobjekt (t.ex. ett Excel‑kalkylblad). De lagras och behandlas på olika sätt och har olika egenskapsmodeller.

**Do ActiveX events and VBA macros work if the file has been modified by Aspose.Slides?**

Aspose.Slides bevarar befintlig markup och metadata; dock körs händelser och makron endast i PowerPoint på Windows när säkerheten tillåter det. Biblioteket kör inte VBA.