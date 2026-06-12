---
title: ActiveX‑besturingselementen beheren in presentaties op Android
linktitle: ActiveX
type: docs
weight: 80
url: /nl/androidjava/activex/
keywords:
- ActiveX
- ActiveX‑besturingselement
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaplayer
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe Aspose.Slides for Android via Java ActiveX benut om PowerPoint‑presentaties te automatiseren en te verbeteren, waardoor ontwikkelaars krachtige controle over dia's krijgen."
---
## **Introductie**

ActiveX‑besturingselementen worden gebruikt in presentaties. Aspose.Slides for Android via Java stelt u in staat ActiveX‑besturingselementen toe te voegen en te beheren, maar ze zijn iets lastiger te beheren dan normale presentatie‑vormen. We hebben ondersteuning geïmplementeerd voor het toevoegen van een Media Player‑Active‑control in Aspose.Slides. Merk op dat ActiveX‑besturingselementen geen vormen zijn; ze maken geen deel uit van de presentatie’s [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/). Ze behoren tot de aparte [IControlCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icontrolcollection/) in plaats daarvan. In dit onderwerp laten we zien hoe u ermee kunt werken.

## **Een Media Player ActiveX‑control toevoegen aan een dia**
Om een ActiveX Media Player‑control toe te voegen, doet u het volgende:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) aan en genereer een lege presentatie‑instantie.  
2. Open de doel‑dia in de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation).  
3. Voeg de Media Player ActiveX‑control toe met de methode [addControl](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) van de [IControlCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icontrolcollection/).  
4. Open de Media Player ActiveX‑control en stel het videopad in via de eigenschappen.  
5. Sla de presentatie op als een PPTX‑bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, toont hoe u een Media Player ActiveX‑control aan een dia kunt toevoegen:

```java
// Maak lege presentatie‑instantie
Presentation pres = new Presentation();
try {
    // Media Player ActiveX‑control toevoegen
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Toegang tot de Media Player ActiveX‑control en het video‑pad instellen
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Presentatie opslaan
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een ActiveX‑control wijzigen**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 7.1.0 en nieuwere versies zijn uitgerust met componenten voor het beheren van ActiveX‑besturingselementen. U kunt het reeds toegevoegde ActiveX‑control in uw presentatie benaderen en via de eigenschappen wijzigen of verwijderen. 

{{% /alert %}} 

Om een simpel ActiveX‑control, zoals een tekstvak en een eenvoudige opdrachtknop, op een dia te beheren, doet u het volgende:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) en laad de presentatie met ActiveX‑besturingselementen erin.  
2. Verkrijg een dia‑referentie op basis van de index.  
3. Benader de ActiveX‑besturingselementen op de dia via de [IControlCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icontrolcollection/).  
4. Open het TextBox1 ActiveX‑control met behulp van het object [IControl](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icontrol/).  
5. Wijzig de eigenschappen van het TextBox1 ActiveX‑control, waaronder tekst, lettertype, lettergrootte en positie van het kader.  
6. Open de tweede toegang‑control met de naam CommandButton1.  
7. Wijzig de knopbijschrift, het lettertype en de positie.  
8. Verplaats de posities van de frames van de ActiveX‑besturingselementen.  
9. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, toont hoe u een simpel ActiveX‑control kunt beheren:

```java
// Presentatie openen met ActiveX‑besturingselementen
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Eerste dia in de presentatie openen
    ISlide slide = pres.getSlides().get_Item(0);

    // tekst van TextBox wijzigen
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Vervangende afbeelding wijzigen. PowerPoint vervangt deze afbeelding tijdens ActiveX‑activatie,
        // dus soms mag de afbeelding ongewijzigd blijven.
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

            // besturingselementen verwijderen
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **FAQ**

**Behoudt Aspose.Slides ActiveX‑besturingselementen bij het lezen en opnieuw opslaan als ze niet kunnen worden uitgevoerd in de Java‑runtime?**

Ja. Aspose.Slides beschouwt ze als onderdeel van de presentatie en kan hun eigenschappen en frames lezen/wijzigen; het uitvoeren van de besturingselementen zelf is niet vereist om ze te behouden.

**Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten in een presentatie?**

ActiveX‑besturingselementen zijn interactieve beheerde controls (knoppen, tekstvakken, mediaspeler), terwijl [OLE](/slides/nl/androidjava/manage-ole/) verwijst naar ingebedde toepassingsobjecten (bijvoorbeeld een Excel‑werkblad). Ze worden anders opgeslagen en beheerd en hebben verschillende eigenschapsmodellen.

**Werken ActiveX‑events en VBA‑macro's als het bestand is aangepast door Aspose.Slides?**

Aspose.Slides behoudt de bestaande markup en metadata; echter, events en macro's worden alleen uitgevoerd binnen PowerPoint op Windows wanneer de beveiliging het toelaat. De bibliotheek voert geen VBA uit.