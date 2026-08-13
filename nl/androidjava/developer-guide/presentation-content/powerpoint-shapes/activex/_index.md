---
title: ActiveX-controls beheren in presentaties op Android
linktitle: ActiveX
type: docs
weight: 80
url: /nl/androidjava/activex/
keywords:
- ActiveX
- ActiveX-control
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe Aspose.Slides for Android via Java ActiveX benut om PowerPoint‑presentaties te automatiseren en te verbeteren, waardoor ontwikkelaars krachtige controle over dia’s krijgen."
---
## **Introductie**

ActiveX-controls worden gebruikt in presentaties. Aspose.Slides for Android via Java stelt u in staat om ActiveX-controls toe te voegen en te beheren, maar ze zijn wat lastiger te hanteren vergeleken met normale presentatie‑vormen. We hebben ondersteuning geïmplementeerd voor het toevoegen van een Media Player‑Active‑control in Aspose.Slides. Merk op dat ActiveX-controls geen vormen zijn; ze maken geen deel uit van de [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/) van de presentatie. Ze behoren tot de afzonderlijke [IControlCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icontrolcollection/) in plaats daarvan. In dit onderwerp laten we u zien hoe u ermee kunt werken.

## **Een Media Player‑ActiveX‑control toevoegen aan een dia**
Om een ActiveX Media Player‑control toe te voegen, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse en genereer een lege presentatiesessie.  
2. Ga naar de gewenste dia in de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation).  
3. Voeg de Media Player‑ActiveX‑control toe met behulp van de [addControl](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-)‑methode die wordt aangeboden door [IControlCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icontrolcollection/).  
4. Benader de Media Player‑ActiveX‑control en stel het videopad in via de eigenschappen.  
5. Sla de presentatie op als een PPTX‑bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, toont hoe u een Media Player‑ActiveX‑control aan een dia toevoegt:

```java
import com.aspose.slides.*;

// Maak lege presentatie‑instantie
Presentation pres = new Presentation();
try {
    // Media Player ActiveX‑control toevoegen
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Benader de Media Player ActiveX‑control en stel het videopad in
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Sla de presentatie op
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een ActiveX‑control wijzigen**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java 7.1.0 en nieuwere versies zijn uitgerust met componenten voor het beheren van ActiveX-controls. U kunt de reeds toegevoegde ActiveX‑control in uw presentatie benaderen en deze via de eigenschappen wijzigen of verwijderen.

{{% /alert %}} 

Om een eenvoudige ActiveX‑control, zoals een tekstvak en een eenvoudige commandobutton, op een dia te beheren, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse en laad de presentatie met de ActiveX-controls erin.  
2. Verkrijg een dia‑referentie op basis van de index.  
3. Benader de ActiveX-controls op de dia via de [IControlCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icontrolcollection/).  
4. Benader de TextBox1‑ActiveX‑control met behulp van het [IControl](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icontrol/)‑object.  
5. Wijzig de eigenschappen van de TextBox1‑ActiveX‑control, waaronder tekst, lettertype, lettergrootte en positie van het frame.  
6. Benader de tweede control genaamd CommandButton1.  
7. Wijzig de knop‑bijschrift, het lettertype en de positie.  
8. Verschuif de positie van de frames van de ActiveX-controls.  
9. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, laat zien hoe u een eenvoudige ActiveX‑control beheert: 

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// Toegang tot de presentatie met ActiveX-controls
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Toegang tot de eerste dia in de presentatie
    ISlide slide = pres.getSlides().get_Item(0);

    // Tekst van TextBox wijzigen
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Vervangende afbeelding wijzigen. PowerPoint zal deze afbeelding vervangen bij activering van de ActiveX,
        // dus soms is het oké om de afbeelding ongewijzigd te laten.
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

    // Knopbijschrift wijzigen
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

    // controls verwijderen
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Behoudt Aspose.Slides ActiveX-controls bij het lezen en opnieuw opslaan wanneer ze niet kunnen worden uitgevoerd in de Java‑runtime?

Ja. Aspose.Slides behandelt ze als onderdeel van de presentatie en kan hun eigenschappen en frames lezen/wijzigen; het uitvoeren van de controls zelf is niet vereist om ze te behouden.

### Hoe verschillen ActiveX-controls van OLE‑objecten in een presentatie?

ActiveX-controls zijn interactieve beheerde controls (knoppen, tekstvakken, mediaplayers), terwijl [OLE](/slides/nl/androidjava/manage-ole/) verwijst naar ingebedde toepassingsobjecten (bijvoorbeeld een Excel‑werkblad). Ze worden anders opgeslagen en behandeld en hebben verschillende eigenschapsmodellen.

### Werken ActiveX‑gebeurtenissen en VBA‑macro’s als het bestand is aangepast door Aspose.Slides?

Aspose.Slides behoudt de bestaande markup en metadata; echter, gebeurtenissen en macro’s worden alleen uitgevoerd in PowerPoint op Windows wanneer de beveiliging dit toelaat. De bibliotheek voert geen VBA uit.