---
title: ActiveX-Steuerungen in Präsentationen mit PHP verwalten
linktitle: ActiveX
type: docs
weight: 80
url: /de/php-java/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Media Player
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für PHP via Java ActiveX nutzt, um PowerPoint-Präsentationen zu automatisieren und zu verbessern, und Entwicklern leistungsstarke Kontrolle über Folien zu geben."
---

{{% alert color="primary" %}} 

ActiveX-Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für PHP via Java ermöglicht das Hinzufügen und Verwalten von ActiveX-Steuerelementen, aber sie sind im Vergleich zu normalen Präsentationsformen etwas schwieriger zu handhaben. Wir haben die Unterstützung für das Hinzufügen des Media Player Active-Steuerelements in Aspose.Slides implementiert. Beachten Sie, dass ActiveX-Steuerelemente keine Formen sind; sie gehören nicht zur [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/). Sie gehören stattdessen zur separaten [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/) . In diesem Thema zeigen wir Ihnen, wie Sie mit ihnen arbeiten.

{{% /alert %}} 

## **Ein Media Player ActiveX-Steuerelement zu einer Folie hinzufügen**
Um ein ActiveX Media Player‑Steuerelement hinzuzufügen, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse und erzeugen Sie eine leere Präsentationsinstanz.
1. Greifen Sie auf die Zielfolie in [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) zu.
1. Fügen Sie das Media Player ActiveX‑Steuerelement mit der [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/addcontrol/) Methode hinzu, die von [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/) bereitgestellt wird.
1. Greifen Sie auf das Media Player ActiveX‑Steuerelement zu und setzen Sie den Videopfad über dessen Eigenschaften.
1. Speichern Sie die Präsentation als PPTX‑Datei.

Dieser Beispielcode, basierend auf den obigen Schritten, zeigt, wie man ein Media Player ActiveX‑Steuerelement zu einer Folie hinzufügt: 
```php
  # Leere Präsentationsinstanz erstellen
  $pres = new Presentation();
  try {
    # Hinzufügen des Media Player ActiveX-Steuerelements
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Zugriff auf das Media Player ActiveX-Steuerelement und Festlegen des Video-Pfads
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Präsentation speichern
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ein ActiveX‑Steuerelement bearbeiten**
{{% alert color="primary" %}} 

Aspose.Slides für PHP via Java 7.1.0 und neuere Versionen sind mit Komponenten zum Verwalten von ActiveX‑Steuerelementen ausgestattet. Sie können auf das bereits hinzugefügte ActiveX‑Steuerelement in Ihrer Präsentation zugreifen und es über seine Eigenschaften ändern oder löschen.

{{% /alert %}} 

Um ein einfaches ActiveX‑Steuerelement wie ein Textfeld und einen einfachen Schaltknopf auf einer Folie zu verwalten, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse und laden Sie die Präsentation mit ActiveX‑Steuerelementen.
1. Holen Sie sich eine Folienreferenz anhand ihres Index.
1. Greifen Sie auf die ActiveX‑Steuerelemente in der Folie zu, indem Sie die [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/) abrufen.
1. Greifen Sie mittels des [Control](https://reference.aspose.com/slides/php-java/aspose.slides/control/)‑Objekts auf das TextBox1 ActiveX‑Steuerelement zu.
1. Ändern Sie die Eigenschaften des TextBox1 ActiveX‑Steuerelements, einschließlich Text, Schriftart, Schriftgröße und Rahmenposition.
1. Greifen Sie auf das zweite Steuerelement namens CommandButton1 zu.
1. Ändern Sie die Beschriftung des Buttons, die Schriftart und die Position.
1. Verschieben Sie die Position der Rahmen der ActiveX‑Steuerelemente.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

Dieser Beispielcode, basierend auf den obigen Schritten, zeigt, wie man ein einfaches ActiveX‑Steuerelement verwaltet: 
```php
  # Zugriff auf die Präsentation mit ActiveX-Steuerelementen
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Zugriff auf die erste Folie in der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Text der TextBox ändern
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Ersetzen des Ersatzbildes. PowerPoint wird dieses Bild während der ActiveX-Aktivierung ersetzen,
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
    # Beschriftung der Schaltfläche ändern
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Ersatzbild ändern
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
    # 100 Punkte nach unten verschieben
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # Steuerelemente entfernen
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

**Behält Aspose.Slides ActiveX‑Steuerelemente bei, wenn sie beim Lesen und erneuten Speichern nicht in der Java‑Laufzeit ausgeführt werden können?**

Ja. Aspose.Slides behandelt sie als Teil der Präsentation und kann ihre Eigenschaften und Rahmen lesen/ändern; das Ausführen der Steuerelemente selbst ist nicht erforderlich, um sie zu erhalten.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten in einer Präsentation?**

ActiveX‑Steuerelemente sind interaktive, verwaltete Steuerelemente (z. B. Schaltflächen, Textfelder, Media Player), während [OLE](/slides/de/php-java/manage-ole/) sich auf eingebettete Anwendungsobjekte bezieht (z. B. ein Excel‑Arbeitsblatt). Sie werden unterschiedlich gespeichert und verarbeitet und besitzen unterschiedliche Property‑Modelle.

**Funktionieren ActiveX‑Ereignisse und VBA‑Makros, wenn die Datei von Aspose.Slides geändert wurde?**

Aspose.Slides erhält das vorhandene Markup und die Metadaten; jedoch werden Ereignisse und Makros nur innerhalb von PowerPoint unter Windows ausgeführt, sofern die Sicherheit dies zulässt. Die Bibliothek führt kein VBA aus.