---
title: Beheer ActiveX‑controles in presentaties met JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /nl/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX‑control
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe Aspose.Slides voor Node.js via Java ActiveX benut om PowerPoint‑presentaties te automatiseren en te verbeteren, waardoor ontwikkelaars krachtige controle over dia’s krijgen."
---
## **Introductie**

ActiveX‑controles worden gebruikt in presentaties. Aspose.Slides voor Node.js via Java stelt je in staat om ActiveX‑controles toe te voegen en te beheren, maar ze zijn wat ingewikkelder te hanteren dan gewone presentatie‑vormen. We hebben ondersteuning geïmplementeerd voor het toevoegen van de Media Player‑Active‑control in Aspose.Slides. Merk op dat ActiveX‑controles geen vormen zijn; ze maken geen deel uit van de [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/) van de presentatie. Ze behoren in plaats daarvan tot de afzonderlijke [ControlCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/controlcollection/). In dit onderwerp laten we je zien hoe je ermee kunt werken.

## **Media Player‑ActiveX‑control aan dia toevoegen**
Om een ActiveX Media Player‑control toe te voegen, doe je het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse en genereer een lege presentatie‑instantie.
1. Open de doel‑dia in [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation).
1. Voeg de Media Player‑ActiveX‑control toe met de [addControl](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-)‑methode die wordt aangeboden door [ControlCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/controlcollection/).
1. Open de Media Player‑ActiveX‑control en stel het video‑pad in via de eigenschappen.
1. Sla de presentatie op als een PPTX‑bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, laat zien hoe je een Media Player‑ActiveX‑control aan een dia kunt toevoegen:

```javascript
// Maak een lege presentatie‑instantie
var pres = new aspose.slides.Presentation();
try {
    // ActiveX Media Player‑control toevoegen
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Open de Media Player‑ActiveX‑control en stel het video‑pad in
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Sla de presentatie op
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ActiveX‑control aanpassen**

Om een eenvoudige ActiveX‑control, zoals een tekstvak en een eenvoudige opdrachtknop, op een dia te beheren, doe je het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse en laad de presentatie met ActiveX‑controles erin.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Open de ActiveX‑controles in de dia door de [ControlCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/controlcollection/) te benaderen.
1. Open de TextBox1‑ActiveX‑control via het [Control](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/control/)‑object.
1. Wijzig de eigenschappen van de TextBox1‑ActiveX‑control, waaronder tekst, lettertype, lettergrootte en positie van het frame.
1. Open de tweede toegang‑control genaamd CommandButton1.
1. Wijzig de knop‑bijschrift, het lettertype en de positie.
1. Verschuif de positie van de frames van de ActiveX‑controles.
1. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, laat zien hoe je een eenvoudige ActiveX‑control beheert:

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// De presentatie met ActiveX‑controles benaderen
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // De eerste dia in de presentatie benaderen
    var slide = pres.getSlides().get_Item(0);
    // tekst van TextBox wijzigen
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Vervangende afbeelding wijzigen. PowerPoint zal deze afbeelding vervangen tijdens ActiveX‑activatie,
        // dus soms is het oké om de afbeelding ongewijzigd te laten.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // Onderschrift van knop wijzigen
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Vervangende afbeelding wijzigen
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // 100 punten omlaag verplaatsen
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // controles verwijderen
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Behoudt Aspose.Slides ActiveX‑controles bij het lezen en opnieuw opslaan wanneer ze niet kunnen worden uitgevoerd in de Python‑runtime?**

Ja. Aspose.Slides beschouwt ze als onderdeel van de presentatie en kan hun eigenschappen en frames lezen/wijzigen; het uitvoeren van de controles zelf is niet vereist om ze te behouden.

**Hoe verschillen ActiveX‑controles van OLE‑objecten in een presentatie?**

ActiveX‑controles zijn interactieve beheerde controles (knoppen, tekstvakken, mediaplayer), terwijl [OLE](/slides/nl/nodejs-java/manage-ole/) verwijst naar ingebedde toepassingsobjecten (bijvoorbeeld een Excel‑werkblad). Ze worden anders opgeslagen en behandeld en hebben een ander eigenschapsmodel.

**Werken ActiveX‑gebeurtenissen en VBA‑macro's als het bestand is gewijzigd door Aspose.Slides?**

Aspose.Slides behoudt de bestaande markup en metadata; echter, gebeurtenissen en macro's worden alleen uitgevoerd in PowerPoint op Windows wanneer de beveiliging dit toelaat. De bibliotheek voert zelf geen VBA uit.