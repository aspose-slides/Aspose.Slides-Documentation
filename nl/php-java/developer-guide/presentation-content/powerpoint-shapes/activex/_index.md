---
title: Beheer ActiveX-controls in presentaties met PHP
linktitle: ActiveX
type: docs
weight: 80
url: /nl/php-java/activex/
keywords:
- ActiveX
- ActiveX-control
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe Aspose.Slides for PHP via Java ActiveX benut om PowerPoint-presentaties te automatiseren en te verbeteren, waardoor ontwikkelaars krachtige controle over dia's krijgen."
---
## **Introductie**

ActiveX‑controls worden gebruikt in presentaties. Aspose.Slides for PHP via Java stelt u in staat ActiveX‑controls toe te voegen en te beheren, maar ze zijn iets lastiger te beheren vergeleken met normale vormen in een presentatie. We hebben ondersteuning geïmplementeerd voor het toevoegen van de Media Player Active control in Aspose.Slides. Merk op dat ActiveX‑controls geen vormen zijn; ze maken geen deel uit van de [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/). Ze maken deel uit van de aparte [ControlCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/controlcollection/) in plaats daarvan. In dit onderwerp laten we zien hoe u ermee kunt werken.

## **Voeg een Media Player ActiveX Control toe aan een dia**
Om een ActiveX Media Player‑control toe te voegen, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) klasse en genereer een lege presentatie‑instantie.
2. Open de doel‑dia in [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation).
3. Voeg de Media Player ActiveX‑control toe met de [addControl](https://reference.aspose.com/slides/nl/php-java/aspose.slides/controlcollection/addcontrol/) methode van [ControlCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/controlcollection/).
4. Krijg toegang tot de Media Player ActiveX‑control en stel het video‑pad in via de eigenschappen.
5. Sla de presentatie op als een PPTX‑bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, laat zien hoe u een Media Player ActiveX Control aan een dia toevoegt:

```php
  # Maak lege presentatie‑instantie
  $pres = new Presentation();
  try {
    # Voeg de Media Player ActiveX‑control toe
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Toegang tot de Media Player ActiveX‑control en stel het video‑pad in
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Sla de presentatie op
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Een ActiveX‑control wijzigen**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 7.1.0 en nieuwere versies zijn uitgerust met componenten voor het beheren van ActiveX‑controls. U kunt de reeds toegevoegde ActiveX‑control in uw presentatie benaderen en via de eigenschappen wijzigen of verwijderen.

{{% /alert %}} 

Om een eenvoudige ActiveX‑control zoals een tekstvak en een eenvoudige commandoknop op een dia te beheren, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) klasse en laad de presentatie met ActiveX‑controls erin.
2. Verkrijg een dia‑referentie op basis van de index.
3. Krijg toegang tot de ActiveX‑controls in de dia via de [ControlCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/controlcollection/).
4. Krijg de TextBox1 ActiveX‑control via het [Control](https://reference.aspose.com/slides/nl/php-java/aspose.slides/control/) object.
5. Wijzig de eigenschappen van de TextBox1 ActiveX‑control, waaronder tekst, lettertype, lettergrootte en frame‑positie.
6. Krijg de tweede toegang‑control genaamd CommandButton1.
7. Wijzig de knop‑bijschrift, het lettertype en de positie.
8. Verplaats de positie van de frames van de ActiveX‑controls.
9. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

Deze voorbeeldcode, gebaseerd op de bovenstaande stappen, laat zien hoe u een eenvoudige ActiveX‑control beheert:

```php
  # Toegang krijgen tot de presentatie met ActiveX‑controls
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Toegang tot de eerste dia in de presentatie
    $slide = $pres->getSlides()->get_Item(0);
    # tekst van TextBox wijzigen
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Vervangende afbeelding wijzigen. PowerPoint zal deze afbeelding vervangen tijdens de ActiveX‑activatie,
      # dus soms is het OK om de afbeelding ongewijzigd te laten.
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
    # Bijschrift van knop wijzigen
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Vervangende afbeelding aanpassen
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
    # 100 punten naar beneden verplaatsen
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # controls verwijderen
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Behoudt Aspose.Slides ActiveX‑controls bij het lezen en opnieuw opslaan als ze niet kunnen worden uitgevoerd in de Java‑runtime?**

Ja. Aspose.Slides behandelt ze als onderdeel van de presentatie en kan hun eigenschappen en frames lezen/wijzigen; het uitvoeren van de controls zelf is niet vereist om ze te behouden.

**Hoe verschillen ActiveX‑controls van OLE‑objecten in een presentatie?**

ActiveX‑controls zijn interactieve beheerde controls (knoppen, tekstvakken, mediaspeler), terwijl [OLE](/slides/nl/php-java/manage-ole/) verwijst naar ingebedde toepassingsobjecten (bijvoorbeeld een Excel‑werkblad). Ze worden anders opgeslagen en behandeld en hebben verschillende eigenschapsmodellen.

**Werken ActiveX‑events en VBA‑macro's als het bestand is aangepast door Aspose.Slides?**

Aspose.Slides behoudt de bestaande markup en metadata; echter, events en macro's worden alleen uitgevoerd binnen PowerPoint op Windows wanneer de beveiliging het toestaat. De bibliotheek voert geen VBA uit.