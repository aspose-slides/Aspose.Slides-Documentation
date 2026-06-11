---
title: "Hantera ActiveX-kontroller i presentationer med JavaScript"
linktitle: "ActiveX"
type: docs
weight: 80
url: /sv/nodejs-java/activex/
keywords:
- "ActiveX"
- "ActiveX-kontroll"
- "hantera ActiveX"
- "lägga till ActiveX"
- "modifiera ActiveX"
- "mediaspelare"
- "PowerPoint"
- "presentation"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Lär dig hur Aspose.Slides för Node.js via Java utnyttjar ActiveX för att automatisera och förbättra PowerPoint-presentationer, vilket ger utvecklare kraftfull kontroll över bilderna."
---
## **Introduktion**

ActiveX‑kontroller används i presentationer. Aspose.Slides för Node.js via Java låter dig lägga till och hantera ActiveX‑kontroller, men de är något svårare att hantera jämfört med vanliga presentationsformer. Vi har implementerat stöd för att lägga till Media Player‑Active‑control i Aspose.Slides. Observera att ActiveX‑kontroller inte är former; de är inte en del av presentationens [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/). De är en del av den separata [ControlCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/controlcollection/) istället. I detta ämne visar vi hur du arbetar med dem.

## **Lägga till Media Player ActiveX‑control på bild**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) och generera en tom presentationsinstans.  
2. Åtkomst till mål‑bilden i [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).  
3. Lägg till Media Player ActiveX‑control med hjälp av metoden [addControl](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) som exponeras av [ControlCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/controlcollection/).  
4. Åtkomst till Media Player ActiveX‑control och ange videovägen genom att använda dess egenskaper.  
5. Spara presentationen som en PPTX‑fil.  

Det här exempelprogrammet, baserat på stegen ovan, visar hur du lägger till Media Player ActiveX‑control på en bild:

```javascript
// Skapa tom presentationsinstans
var pres = new aspose.slides.Presentation();
try {
    // Lägger till Media Player ActiveX‑kontrollen
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Åtkomst till Media Player ActiveX‑kontrollen och ange videovägen
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Spara presentationen
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modifiera ActiveX‑control**

För att hantera en enkel ActiveX‑control som en textruta och en enkel kommandoknapp på en bild, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) och ladda presentationen som innehåller ActiveX‑kontroller.  
2. Hämta en bildreferens efter dess index.  
3. Åtkomst till ActiveX‑kontrollerna i bilden genom att komma åt [ControlCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/controlcollection/).  
4. Åtkomst till TextBox1 ActiveX‑control med hjälp av objektet [Control](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/control/).  
5. Ändra egenskaperna för TextBox1 ActiveX‑control som inkluderar text, teckensnitt, teckenhöjd och ramposition.  
6. Åtkomst till den andra åtkomstkontrollen som heter CommandButton1.  
7. Ändra knappens rubrik, teckensnitt och position.  
8. Förskjut positionen för ActiveX‑kontrollenas ramar.  
9. Skriv den modifierade presentationen till en PPTX‑fil.  

Det här exempelprogrammet, baserat på stegen ovan, visar hur du hanterar en enkel ActiveX‑control:

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// Åtkomst till presentationen med ActiveX‑kontroller
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Åtkomst till den första bilden i presentationen
    var slide = pres.getSlides().get_Item(0);
    // ändra TextBox‑text
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Ändra ersättningsbild. PowerPoint kommer att ersätta denna bild under ActiveX‑aktivering,
        // så ibland är det OK att låta bilden förbli oförändrad.
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
    // Ändra knappens rubrik
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Ändra ersättning
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
    // flytta 100 punkter nedåt
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // ta bort kontroller
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

**Bevarar Aspose.Slides ActiveX‑kontroller vid läsning och återlagring om de inte kan köras i Python‑runtime?**

Ja. Aspose.Slides behandlar dem som en del av presentationen och kan läsa/ändra deras egenskaper och ramar; att köra själva kontrollerna krävs inte för att bevara dem.

**Hur skiljer sig ActiveX‑kontroller från OLE‑objekt i en presentation?**

ActiveX‑kontroller är interaktiva hanterade kontroller (knappar, textrutor, mediaspelare), medan [OLE](/slides/sv/nodejs-java/manage-ole/) avser inbäddade programobjekt (t.ex. ett Excel‑arbetsblad). De lagras och hanteras på olika sätt och har olika egenskapsmodeller.

**Fungerar ActiveX‑händelser och VBA‑makron om filen har modifierats av Aspose.Slides?**

Aspose.Slides bevarar den befintliga markupen och metadata; dock körs händelser och makron endast i PowerPoint på Windows när säkerheten tillåter det. Biblioteket kör inte VBA.