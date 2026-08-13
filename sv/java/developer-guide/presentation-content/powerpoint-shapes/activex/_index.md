---
title: "Hantera ActiveX‑kontroller i presentationer med Java"
linktitle: "ActiveX"
type: docs
weight: 80
url: /sv/java/activex/
keywords:
- "ActiveX"
- "ActiveX‑kontroll"
- "hantera ActiveX"
- "lägga till ActiveX"
- "modifiera ActiveX"
- "mediaspelare"
- "PowerPoint"
- "presentation"
- "Java"
- "Aspose.Slides"
description: "Lär dig hur Aspose.Slides för Java utnyttjar ActiveX för att automatisera och förbättra PowerPoint‑presentationer, vilket ger utvecklare kraftfull kontroll över bildspel."
---
## **Introduction**

ActiveX‑kontroller används i presentationer. Aspose.Slides för Java låter dig lägga till och hantera ActiveX‑kontroller, men de är något svårare att hantera jämfört med vanliga presentationsformer. Vi har implementerat stöd för att lägga till Media Player‑aktivkontroll i Aspose.Slides. Observera att ActiveX‑kontroller inte är former; de är inte en del av presentationens [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/). De är istället en del av den separata [IControlCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icontrolcollection/) . I det här avsnittet visar vi hur du arbetar med dem. 

## **Add a Media Player ActiveX Control to a Slide**
För att lägga till en ActiveX‑Media Player‑kontroll gör du så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) och generera en tom presentationsinstans.
1. Kom åt målbilden i [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
1. Lägg till Media Player‑ActiveX‑kontrollen med metoden [addControl](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) som exponeras av [IControlCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icontrolcollection/).
1. Kom åt Media Player‑ActiveX‑kontrollen och ange videovägen genom att använda dess egenskaper.
1. Spara presentationen som en PPTX‑fil.

Denna exempelkod, baserad på stegen ovan, visar hur man lägger till Media Player‑ActiveX‑kontroll på en bild:

```java
import com.aspose.slides.*;

// Skapa tom presentationsinstans
Presentation pres = new Presentation();
try {
    // Lägger till Media Player ActiveX‑kontrollen
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Kom åt Media Player ActiveX‑kontrollen och ange videovägen
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Spara presentationen
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modify an ActiveX Control**
{{% alert color="info" %}} 

Aspose.Slides för Java 7.1.0 och senare versioner är utrustade med komponenter för att hantera ActiveX‑kontroller. Du kan komma åt den redan tillagda ActiveX‑kontrollen i din presentation och ändra eller ta bort den via dess egenskaper.

{{% /alert %}} 

För att hantera en enkel ActiveX‑kontroll som en textruta och en enkel kommandoknapp på en bild gör du så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) och öppna presentationen som innehåller ActiveX‑kontroller.
1. Hämta en bildreferens via dess index.
1. Kom åt ActiveX‑kontrollerna på bilden genom att nå [IControlCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icontrolcollection/).
1. Kom åt TextBox1‑ActiveX‑kontrollen med hjälp av objektet [IControl](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icontrol/).
1. Ändra egenskaperna för TextBox1‑ActiveX‑kontrollen, såsom text, teckensnitt, teckenhöjd och ramposition.
1. Kom åt den andra åtkomstkontrollen som heter CommandButton1.
1. Ändra knappens rubrik, teckensnitt och position.
1. Flytta positionen för ActiveX‑kontrollernas ramar.
1. Skriv den ändrade presentationen till en PPTX‑fil.

Denna exempelkod, baserad på stegen ovan, visar hur du hanterar en enkel ActiveX‑kontroll: 

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// Åtkomst till presentationen med ActiveX‑kontroller
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Åtkomst till den första bilden i presentationen
    ISlide slide = pres.getSlides().get_Item(0);

    // ändrar TextBox‑text
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Byter ersättningsbild. PowerPoint kommer att ersätta denna bild under ActiveX‑aktivering,
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

    // Ändrar knapptext
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

            // flyttar 100 punkter nedåt
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

### Does Aspose.Slides preserve ActiveX controls when reading and re-saving if they cannot be executed in the Java runtime?

Ja. Aspose.Slides behandlar dem som en del av presentationen och kan läsa/ändra deras egenskaper och ramar; det är inte nödvändigt att exekvera själva kontrollerna för att bevara dem.

### How do ActiveX controls differ from OLE objects in a presentation?

ActiveX‑kontroller är interaktiva hanterade kontroller (knappar, textrutor, media player), medan [OLE](/slides/sv/java/manage-ole/) avser inbäddade programobjekt (till exempel ett Excel‑kalkylblad). De lagras och hanteras på olika sätt och har olika egenskapsmodeller.

### Do ActiveX events and VBA macros work if the file has been modified by Aspose.Slides?

Aspose.Slides bevarar den befintliga markupen och metadata; dock körs händelser och makron endast i PowerPoint på Windows när säkerheten tillåter det. Biblioteket kör inte VBA.