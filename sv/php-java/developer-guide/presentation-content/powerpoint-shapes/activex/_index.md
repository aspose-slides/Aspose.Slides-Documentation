---
title: Hantera ActiveX-kontroller i presentationer med PHP
linktitle: ActiveX
type: docs
weight: 80
url: /sv/php-java/activex/
keywords:
- ActiveX
- ActiveX-kontroll
- hantera ActiveX
- lägga till ActiveX
- ändra ActiveX
- mediaplayer
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur Aspose.Slides för PHP via Java utnyttjar ActiveX för att automatisera och förbättra PowerPoint-presentationer, vilket ger utvecklare kraftfull kontroll över bilderna."
---
## **Introduktion**

ActiveX-kontroller används i presentationer. Aspose.Slides för PHP via Java låter dig lägga till och hantera ActiveX-kontroller, men de är lite svårare att hantera jämfört med vanliga presentationsformer. Vi har implementerat stöd för att lägga till Media Player Active-kontroll i Aspose.Slides. Observera att ActiveX-kontroller inte är former; de ingår inte i presentationens [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/). De är istället en del av den separata [ControlCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/controlcollection/) istället. I detta avsnitt visar vi hur du arbetar med dem.

## **Lägg till en Media Player ActiveX-kontroll på en bild**
För att lägga till en Media Player ActiveX-kontroll, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) och skapa en tom presentationsinstans.
2. Åtkomst till målbilden i [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
3. Lägg till Media Player ActiveX-kontrollen med metoden [addControl](https://reference.aspose.com/slides/sv/php-java/aspose.slides/controlcollection/addcontrol/) som exponeras av [ControlCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/controlcollection/).
4. Få åtkomst till Media Player ActiveX-kontrollen och ange videosträngen genom att använda dess egenskaper.
5. Spara presentationen som en PPTX-fil.

Detta exempelkod, baserat på stegen ovan, visar hur man lägger till Media Player ActiveX-kontrollen på en bild:

```php
  # Skapa tom presentationsinstans
  $pres = new Presentation();
  try {
    # Lägga till Media Player ActiveX‑kontroll
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Åtkomst till Media Player ActiveX‑kontrollen och ange videovägen
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Spara presentationen
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändra en ActiveX-kontroll**
{{% alert color="primary" %}} 

Aspose.Slides för PHP via Java 7.1.0 och nyare versioner är utrustade med komponenter för att hantera ActiveX-kontroller. Du kan komma åt den redan tillagda ActiveX-kontrollen i din presentation och ändra eller ta bort den via dess egenskaper.

{{% /alert %}} 

För att hantera en enkel ActiveX-kontroll som en textruta och en enkel kommandoknapp på en bild, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) och läs in presentationen som innehåller ActiveX-kontroller.
2. Hämta en bildreferens efter dess index.
3. Få åtkomst till ActiveX-kontrollerna på bilden genom att komma åt [ControlCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/controlcollection/).
4. Få åtkomst till TextBox1 ActiveX-kontrollen med [Control](https://reference.aspose.com/slides/sv/php-java/aspose.slides/control/)‑objektet.
5. Ändra egenskaperna för TextBox1 ActiveX-kontrollen som inkluderar text, teckensnitt, teckenhöjd och ramposition.
6. Åtkomst till den andra åtkomstkontrollen som heter CommandButton1.
7. Ändra knappens rubrik, teckensnitt och position.
8. Flytta positionen för ActiveX-kontrollets ramar.
9. Skriv den modifierade presentationen till en PPTX-fil.

Detta exempelkod, baserat på stegen ovan, visar hur man hanterar en enkel ActiveX-kontroll: 

```php
  # Åtkomst till presentationen med ActiveX-kontroller
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Åtkomst till den första bilden i presentationen
    $slide = $pres->getSlides()->get_Item(0);
    # ändra TextBox-text
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Ändra ersättningsbild. PowerPoint kommer att ersätta den här bilden under activeX-aktivering,
      # så ibland är det OK att låta bilden vara oförändrad.
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # Ändra knapptext
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Ändra ersättningsbild
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # flytta 100 punkter nedåt
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # ta bort kontroller
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Behåller Aspose.Slides ActiveX-kontroller när de läses in och sparas om de inte kan köras i Java‑runtime?**

Ja. Aspose.Slides behandlar dem som en del av presentationen och kan läsa/ändra deras egenskaper och ramar; att köra själva kontrollerna krävs inte för att bevara dem.

**Hur skiljer sig ActiveX-kontroller från OLE-objekt i en presentation?**

ActiveX-kontroller är interaktiva hanterade kontroller (knappar, textrutor, mediaplayer), medan [OLE](/slides/sv/php-java/manage-ole/) avser inbäddade programobjekt (till exempel ett Excel‑arbetsblad). De lagras och hanteras på olika sätt och har olika egenskapsmodeller.

**Fungerar ActiveX‑händelser och VBA‑makron om filen har modifierats av Aspose.Slides?**

Aspose.Slides bevarar den befintliga markupen och metadata; dock körs händelser och makron endast i PowerPoint på Windows när säkerheten tillåter det. Biblioteket kör inte VBA.