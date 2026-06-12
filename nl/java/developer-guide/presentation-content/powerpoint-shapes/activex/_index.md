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
- ActiveX aanpassen
- mediaspeler
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe Aspose.Slides for Java ActiveX benut om PowerPoint-presentaties te automatiseren en te verbeteren, waardoor ontwikkelaars krachtige controle over dia's krijgen."
---
## **Introductie**

ActiveX‑besturingselementen worden gebruikt in presentaties. Aspose.Slides for Java stelt u in staat om ActiveX‑besturingselementen toe te voegen en te beheren, maar ze zijn wat lastiger te beheren in vergelijking met normale presentatievormen. We hebben ondersteuning geïmplementeerd voor het toevoegen van een Media Player Active control in Aspose.Slides. Merk op dat ActiveX‑besturingselementen geen vormen zijn; ze maken geen deel uit van de presentatie‑[IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/). Ze behoren in plaats daarvan tot de aparte [IControlCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icontrolcollection/) . In dit onderwerp laten we zien hoe u ermee kunt werken. 

## **Een Media Player ActiveX‑besturingselement toevoegen aan een dia**
Om een ActiveX Media Player‑besturingselement toe te voegen, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse en genereer een lege presentatie‑instantie.
2. Open de doel‑dia in de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation).
3. Voeg het Media Player ActiveX‑besturingselement toe met behulp van de [addControl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) methode die wordt aangeboden door [IControlCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icontrolcollection/).
4. Open het Media Player ActiveX‑besturingselement en stel het videopad in via zijn eigenschappen.
5. Sla de presentatie op als een PPTX‑bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, toont hoe u een Media Player ActiveX‑besturingselement aan een dia kunt toevoegen:

```java
// Maak lege presentatie‑instantie
Presentation pres = new Presentation();
try {
    // Voeg het Media Player ActiveX‑besturingselement toe
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Open het Media Player ActiveX‑besturingselement en stel het videopad in
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Sla de presentatie op
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een ActiveX‑besturingselement aanpassen**
{{% alert color="primary" %}} 

Aspose.Slides for Java 7.1.0 en nieuwere versies zijn uitgerust met componenten voor het beheren van ActiveX‑besturingselementen. U kunt het reeds toegevoegde ActiveX‑besturingselement in uw presentatie benaderen en via de eigenschappen aanpassen of verwijderen.

{{% /alert %}} 

Om een eenvoudig ActiveX‑besturingselement zoals een tekstvak en een eenvoudige commandoknop op een dia te beheren, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse en laad de presentatie met ActiveX‑besturingselementen.
2. Verkrijg een dia‑referentie aan de hand van de index.
3. Benader de ActiveX‑besturingselementen op de dia via de [IControlCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icontrolcollection/).
4. Open het TextBox1 ActiveX‑besturingselement met behulp van het [IControl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icontrol/) object.
5. Wijzig de eigenschappen van het TextBox1 ActiveX‑besturingselement, waaronder tekst, lettertype, lettergrootte en positie van het frame.
6. Open het tweede besturingselement genaamd CommandButton1.
7. Wijzig de knopbijschrift, het lettertype en de positie.
8. Verschuif de positie van de frames van de ActiveX‑besturingselementen.
9. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, laat zien hoe u een eenvoudig ActiveX‑besturingselement kunt beheren: 

```java
// Toegang tot de presentatie met ActiveX‑besturingselementen
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Toegang tot de eerste dia in de presentatie
    ISlide slide = pres.getSlides().get_Item(0);

    // tekstvaktekst wijzigen
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Vervangende afbeelding wijzigen. PowerPoint zal deze afbeelding vervangen tijdens ActiveX‑activatie,
        // dus soms is het OK om de afbeelding ongewijzigd te laten.
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

            // 100 punten naar beneden verplaatsen
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

**Behoudt Aspose.Slides ActiveX‑besturingselementen bij het lezen en opnieuw opslaan als ze niet uitgevoerd kunnen worden in de Java‑runtime?**

Ja. Aspose.Slides beschouwt ze als onderdeel van de presentatie en kan hun eigenschappen en frames lezen/wijzigen; het uitvoeren van de besturingselementen zelf is niet vereist om ze te behouden.

**Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten in een presentatie?**

ActiveX‑besturingselementen zijn interactieve beheerde besturingselementen (knoppen, tekstvakken, mediaspeler), terwijl [OLE](/slides/nl/java/manage-ole/) verwijst naar ingesloten toepassingsobjecten (bijvoorbeeld een Excel‑werkblad). Ze worden op een andere manier opgeslagen en behandeld en hebben verschillende eigenschapsmodellen.

**Werken ActiveX‑gebeurtenissen en VBA‑macro's als het bestand is aangepast door Aspose.Slides?**

Aspose.Slides behoudt de bestaande markup en metadata; echter, gebeurtenissen en macro's worden alleen uitgevoerd binnen PowerPoint op Windows wanneer de beveiliging dit toestaat. De bibliotheek voert geen VBA uit.