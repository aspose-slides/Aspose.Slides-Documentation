---
title: Beheer ActiveX-besturingselementen in presentaties met Java
linktitle: ActiveX
type: docs
weight: 80
url: /nl/java/activex/
keywords:
- ActiveX
- ActiveX-besturingselement
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe Aspose.Slides for Java ActiveX benut om PowerPoint-presentaties te automatiseren en te verbeteren, en ontwikkelaars krachtige controle over dia's biedt."
---
## **Inleiding**

ActiveX‑besturingselementen worden gebruikt in presentaties. Aspose.Slides for Java stelt u in staat ActiveX‑besturingselementen toe te voegen en te beheren, maar ze zijn iets lastiger te hanteren dan gewone presentatieshape‑s. We hebben ondersteuning geïmplementeerd voor het toevoegen van een Media Player‑active‑control in Aspose.Slides. Merk op dat ActiveX‑besturingselementen geen shapes zijn; ze maken geen deel uit van de [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/). Ze behoren tot de aparte [IControlCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icontrolcollection/) in plaats daarvan. In dit onderwerp laten we u zien hoe u ermee werkt. 

## **Een Media Player ActiveX‑besturingselement toevoegen aan een dia**
Om een ActiveX Media Player‑control toe te voegen, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse aan en genereer een lege presentatie‑instantie.
1. Open de doel‑dia in de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation).
1. Voeg het Media Player ActiveX‑besturingselement toe met de [addControl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-)‑methode die wordt aangeboden door [IControlCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icontrolcollection/).
1. Open het Media Player ActiveX‑besturingselement en stel het videopath in via de eigenschappen.
1. Sla de presentatie op als een PPTX‑bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, laat zien hoe u een Media Player ActiveX‑besturingselement aan een dia toevoegt:

```java
import com.aspose.slides.*;

// Maak een lege presentatie‑instantie
Presentation pres = new Presentation();
try {
    // Media Player ActiveX‑besturingselement toevoegen
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Open het Media Player ActiveX‑besturingselement en stel het video‑pad in
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Sla de presentatie op
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een ActiveX‑besturingselement wijzigen**
{{% alert color="info" %}} 

Aspose.Slides for Java 7.1.0 en nieuwere versies zijn uitgerust met componenten voor het beheren van ActiveX‑besturingselementen. U kunt het reeds toegevoegde ActiveX‑besturingselement in uw presentatie benaderen en via de eigenschappen wijzigen of verwijderen.

{{% /alert %}} 

Om een eenvoudig ActiveX‑besturingselement, zoals een tekstvak en een eenvoudige commandoknop, op een dia te beheren, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse aan en laad de presentatie met daarin ActiveX‑besturingselementen.
1. Verkrijg een slide‑referentie op basis van de index.
1. Open de ActiveX‑besturingselementen in de dia via de [IControlCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icontrolcollection/).
1. Open het TextBox1 ActiveX‑besturingselement met behulp van het [IControl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icontrol/)‑object.
1. Wijzig de eigenschappen van het TextBox1 ActiveX‑besturingselement, waaronder tekst, lettertype, letterhoogte en positie van het frame.
1. Open het tweede besturingselement met de naam CommandButton1.
1. Wijzig de knoptitel, het lettertype en de positie.
1. Verplaats de posities van de frames van de ActiveX‑besturingselementen.
1. Schrijf de gewijzigde presentatie weg naar een PPTX‑bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, laat zien hoe u een eenvoudig ActiveX‑besturingselement beheert: 

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// De presentatie met ActiveX‑besturingselementen benaderen
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // De eerste dia in de presentatie benaderen
    ISlide slide = pres.getSlides().get_Item(0);

    // tekst van TextBox wijzigen
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Vervangende afbeelding wijzigen. PowerPoint vervangt deze afbeelding bij ActiveX‑activatie,
        // dus soms is het OK om de afbeelding ongemoeid te laten.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // Knoptitel wijzigen
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Vervangende afbeelding wijzigen
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
                graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
                graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

                graphics.dispose();

                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                ImageIO.write(image, "PNG", baos);

                control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
            }

            // 100 punten omlaag verplaatsen
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // besturingselementen verwijderen
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **FAQ**

### Behoudt Aspose.Slides ActiveX‑besturingselementen bij het lezen en opnieuw opslaan als ze niet kunnen worden uitgevoerd in de Java‑runtime?

Ja. Aspose.Slides beschouwt ze als onderdeel van de presentatie en kan hun eigenschappen en frames lezen/wijzigen; het uitvoeren van de besturingselementen zelf is niet nodig om ze te behouden.

### Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten in een presentatie?

ActiveX‑besturingselementen zijn interactieve beheerde elementen (knoppen, tekstvakken, mediaspeler), terwijl [OLE](/slides/nl/java/manage-ole/) verwijst naar ingebedde toepassingsobjecten (bijvoorbeeld een Excel‑werkblad). Ze worden anders opgeslagen en behandeld en hebben verschillende eigenschapsmodellen.

### Werken ActiveX‑events en VBA‑macro's als het bestand is aangepast door Aspose.Slides?

Aspose.Slides behoudt de bestaande markup en metadata; echter, events en macro's worden alleen uitgevoerd binnen PowerPoint op Windows wanneer de beveiliging dit toestaat. De bibliotheek voert geen VBA uit.