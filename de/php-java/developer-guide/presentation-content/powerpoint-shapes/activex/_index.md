---
title: ActiveX
type: docs
weight: 80
url: /de/php-java/activex/
---


{{% alert color="primary" %}} 

ActiveX-Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für PHP über Java ermöglicht es Ihnen, ActiveX-Steuerelemente hinzuzufügen und zu verwalten, diese sind jedoch im Vergleich zu normalen Präsentationsformen etwas schwieriger zu handhaben. Wir haben die Unterstützung zum Hinzufügen von Media Player Active-Steuerelementen in Aspose.Slides implementiert. Beachten Sie, dass ActiveX-Steuerelemente keine Formen sind; sie sind kein Teil der [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IShapeCollection) der Präsentation. Sie sind stattdessen Teil der separaten [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection). In diesem Thema zeigen wir Ihnen, wie Sie mit ihnen arbeiten.

{{% /alert %}} 

## **Hinzufügen des Media Player ActiveX-Steuerelements zur Folie**
Um ein ActiveX Media Player-Steuerelement hinzuzufügen, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse und generieren Sie eine leere Präsentationsinstanz.
1. Greifen Sie auf die Ziel-Folie in der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) zu.
1. Fügen Sie das Media Player ActiveX-Steuerelement mit der [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/IControlCollection#addControl-int-float-float-float-float-) Methode hinzu, die von [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection) bereitgestellt wird.
1. Greifen Sie auf das Media Player ActiveX-Steuerelement zu und setzen Sie den Videopfad über seine Eigenschaften.
1. Speichern Sie die Präsentation als PPTX-Datei.

Dieser Beispielcode, basierend auf den oben genannten Schritten, zeigt, wie Sie das Media Player ActiveX-Steuerelement zu einer Folie hinzufügen:

```php
  # Erstellen Sie eine leere Präsentationsinstanz
  $pres = new Presentation();
  try {
    # Hinzufügen des Media Player ActiveX-Steuerelements
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Greifen Sie auf das Media Player ActiveX-Steuerelement zu und setzen Sie den Videopfad
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Speichern Sie die Präsentation
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändern des ActiveX-Steuerelements**
{{% alert color="primary" %}} 

Aspose.Slides für PHP über Java 7.1.0 und neuere Versionen sind mit Komponenten zum Verwalten von ActiveX-Steuerelementen ausgestattet. Sie können auf das bereits hinzugefügte ActiveX-Steuerelement in Ihrer Präsentation zugreifen und es über seine Eigenschaften ändern oder löschen.

{{% /alert %}} 

Um ein einfaches ActiveX-Steuerelement wie ein Textfeld und einen einfachen Befehlsbutton auf einer Folie zu verwalten, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit ActiveX-Steuerelementen.
1. Erhalten Sie eine Folienreferenz nach ihrem Index.
1. Greifen Sie auf die ActiveX-Steuerelemente in der Folie zu, indem Sie auf die [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection) zugreifen.
1. Greifen Sie mit dem [IControl](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControl)-Objekt auf das TextBox1 ActiveX-Steuerelement zu.
1. Ändern Sie die Eigenschaften des TextBox1 ActiveX-Steuerelements, die Text, Schriftart, Schriftgröße und Rahmenposition umfassen.
1. Greifen Sie auf das zweite Steuerelement mit dem Namen CommandButton1 zu.
1. Ändern Sie die Beschriftung, Schriftart und Position des Buttons.
1. Verschieben Sie die Position der Rahmen der ActiveX-Steuerelemente.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Beispielcode, basierend auf den oben genannten Schritten, zeigt, wie man ein einfaches ActiveX-Steuerelement verwaltet:

```php
  # Zugriff auf die Präsentation mit ActiveX-Steuerelementen
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Zugriff auf die erste Folie in der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ändern des Texts in der TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Geänderter Text";
      $control->getProperties()->set_Item("Value", $newText);
      # Ändern des Ersatzbildes. PowerPoint wird dieses Bild während der ActiveX-Aktivierung ersetzen,
      # daher ist es manchmal in Ordnung, das Bild unverändert zu lassen.
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
    # Ändern der Buttonbeschriftung
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Nachricht anzeigen";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Ändern des Ersatzbildes
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
    # Verschieben um 100 Punkte nach unten
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # Entfernen der Steuerelemente
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```