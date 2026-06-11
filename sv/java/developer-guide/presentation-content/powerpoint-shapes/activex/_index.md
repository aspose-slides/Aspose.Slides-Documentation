---
title: Hantera ActiveX-kontroller i presentationer med Java
linktitle: ActiveX
type: docs
weight: 80
url: /sv/java/activex/
keywords:
- ActiveX
- ActiveX-kontroll
- hantera ActiveX
- lägga till ActiveX
- ändra ActiveX
- mediaspelare
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur Aspose.Slides for Java utnyttjar ActiveX för att automatisera och förbättra PowerPoint-presentationer, vilket ger utvecklare kraftfull kontroll över bildspel."
---
## **Introduktion**

ActiveX‑kontroller används i presentationer. Aspose.Slides for Java låter dig lägga till och hantera ActiveX‑kontroller, men de är lite svårare att hantera jämfört med vanliga presentationsformer. Vi har implementerat stöd för att lägga till Media Player‑Active‑control i Aspose.Slides. Observera att ActiveX‑kontroller inte är former; de ingår inte i presentationens [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/). De är en del av den separata [IControlCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icontrolcollection/) istället. I det här avsnittet visar vi hur du arbetar med dem. 

## **Lägg till en Media Player ActiveX‑kontroll på en bild**
För att lägga till en ActiveX Media Player‑kontroll gör du så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) och generera en tom presentationsinstans.
2. Öppna målbilden i [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
3. Lägg till Media Player ActiveX‑kontrollen med metoden [addControl](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) som tillhandahålls av [IControlCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icontrolcollection/).
4. Få åtkomst till Media Player ActiveX‑kontrollen och ange videovägen genom att använda dess egenskaper.
5. Spara presentationen som en PPTX‑fil.

Denna exempelkod, baserad på stegen ovan, visar hur du lägger till Media Player ActiveX‑kontroll på en bild:

```java
// Skapa tom presentationsinstans
Presentation pres = new Presentation();
try {
    // Lägger till Media Player ActiveX-kontrollen
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Åtkomst till Media Player ActiveX-kontrollen och ange videovägen
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Spara presentationen
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ändra en ActiveX‑kontroll**
{{% alert color="primary" %}} 

Aspose.Slides for Java 7.1.0 och senare versioner är utrustade med komponenter för att hantera ActiveX‑kontroller. Du kan komma åt den redan tillagda ActiveX‑kontrollen i din presentation och ändra eller ta bort den via dess egenskaper.

{{% /alert %}} 

För att hantera en enkel ActiveX‑kontroll som en textruta och en enkel kommandoknapp på en bild gör du så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) och ladda presentationen som innehåller ActiveX‑kontroller.
2. Hämta en bildreferens med dess index.
3. Få åtkomst till ActiveX‑kontrollerna på bilden genom att använda [IControlCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icontrolcollection/).
4. Få åtkomst till TextBox1 ActiveX‑kontrollen via objektet [IControl](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icontrol/).
5. Ändra egenskaperna för TextBox1 ActiveX‑kontrollen, såsom text, teckensnitt, teckensnittshöjd och ramposition.
6. Få åtkomst till den andra åtkomstkontrollen som heter CommandButton1.
7. Ändra knappens rubrik, teckensnitt och position.
8. Förflytta positionen för ActiveX‑kontrollerna.
9. Skriv den ändrade presentationen till en PPTX‑fil.

Denna exempelkod, baserad på stegen ovan, visar hur du hanterar en enkel ActiveX‑kontroll: 

```java
// Åtkomst till presentationen med ActiveX-kontroller
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Åtkomst till den första bilden i presentationen
    ISlide slide = pres.getSlides().get_Item(0);

    // ändrar TextBox‑text
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Byter ersättningsbild. PowerPoint kommer att ersätta denna bild under ActiveX-aktivering,
        // så ibland är det OK att låta bilden förbli oförändrad.
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

    // Ändrar knappens rubrik
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Byter ersättningsbild
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

    // flyttar 100 punkt ner
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // tar bort kontroller
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Behåller Aspose.Slides ActiveX‑kontroller när de läses in och sparas om de inte kan köras i Java‑runtime‑miljön?**

Ja. Aspose.Slides behandlar dem som en del av presentationen och kan läsa/ändra deras egenskaper och ramar; det krävs inte att själva kontrollerna körs för att bevara dem.

**Hur skiljer sig ActiveX‑kontroller från OLE‑objekt i en presentation?**

ActiveX‑kontroller är interaktiva hanterade kontroller (knappar, textfält, mediaspelare), medan [OLE](/slides/sv/java/manage-ole/) avser inbäddade programobjekt (till exempel ett Excel‑blad). De lagras och hanteras på olika sätt och har olika egenskapsmodeller.

**Fungerar ActiveX‑händelser och VBA‑makron om filen har ändrats av Aspose.Slides?**

Aspose.Slides bevarar den befintliga markupen och metadatan; dock körs händelser och makron endast i PowerPoint på Windows när säkerheten tillåter det. Biblioteket kör inte VBA.