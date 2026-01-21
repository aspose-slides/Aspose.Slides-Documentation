---
title: Verwalten von ActiveX-Steuerungen in Präsentationen mit Java
linktitle: ActiveX
type: docs
weight: 80
url: /de/java/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Medienplayer
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Java ActiveX nutzt, um PowerPoint-Präsentationen zu automatisieren und zu verbessern, und Entwicklern eine leistungsstarke Steuerung über Folien bietet."
---

{{% alert color="primary" %}} 

ActiveX-Steuerelemente werden in Präsentationen verwendet. Aspose.Slides for Java ermöglicht das Hinzufügen und Verwalten von ActiveX-Steuerelementen, aber sie sind etwas schwieriger zu handhaben im Vergleich zu normalen Präsentationsformen. Wir haben Unterstützung für das Hinzufügen von Media Player Active Control in Aspose.Slides implementiert. Beachten Sie, dass ActiveX-Steuerelemente keine Formen sind; sie sind kein Teil der [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/). Sie gehören stattdessen zur separaten [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/) . In diesem Thema zeigen wir Ihnen, wie Sie mit ihnen arbeiten. 

{{% /alert %}} 

## **Ein Media Player ActiveX-Steuerelement zu einer Folie hinzufügen**
Um ein ActiveX Media Player-Steuerelement hinzuzufügen, führen Sie Folgendes aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)‑Klasse und erzeugen Sie eine leere Präsentationsinstanz.  
1. Greifen Sie auf die Zielfolie in [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) zu.  
1. Fügen Sie das Media Player ActiveX‑Steuerelement mit der [addControl](https://reference.aspose.com/slides/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-)‑Methode, die von [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/) bereitgestellt wird, hinzu.  
1. Greifen Sie auf das Media Player ActiveX‑Steuerelement zu und setzen Sie den Videopfad über dessen Eigenschaften.  
1. Speichern Sie die Präsentation als PPTX‑Datei.  

Dieser Beispielcode, basierend auf den obigen Schritten, zeigt, wie ein Media Player ActiveX‑Steuerelement zu einer Folie hinzugefügt wird:
```java
// Leere Präsentationsinstanz erstellen
Presentation pres = new Presentation();
try {
    // Hinzufügen des Media Player ActiveX-Steuerelements
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Zugriff auf das Media Player ActiveX-Steuerelement und Festlegen des Videopfads
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Präsentation speichern
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ein ActiveX‑Steuerelement ändern**
{{% alert color="primary" %}} 

Aspose.Slides for Java 7.1.0 und neuere Versionen sind mit Komponenten zum Verwalten von ActiveX‑Steuerelementen ausgestattet. Sie können das bereits hinzugefügte ActiveX‑Steuerelement in Ihrer Präsentation zugreifen und es über seine Eigenschaften ändern oder löschen.

{{% /alert %}} 

Um ein einfaches ActiveX‑Steuerelement wie ein Textfeld und eine einfache Schaltfläche auf einer Folie zu verwalten, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)‑Klasse und laden Sie die Präsentation, die ActiveX‑Steuerelemente enthält.  
1. Holen Sie sich eine Folienreferenz anhand ihres Index.  
1. Greifen Sie auf die ActiveX‑Steuerelemente in der Folie zu, indem Sie die [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/) öffnen.  
1. Greifen Sie auf das TextBox1‑ActiveX‑Steuerelement über das [IControl](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/)‑Objekt zu.  
1. Ändern Sie die Eigenschaften des TextBox1‑ActiveX‑Steuerelements, einschließlich Text, Schriftart, Schriftgröße und Rahmenposition.  
1. Greifen Sie auf das zweite Zugriffsteuerelement namens CommandButton1 zu.  
1. Ändern Sie die Beschriftung des Buttons, Schriftart und Position.  
1. Verschieben Sie die Position der Rahmen der ActiveX‑Steuerelemente.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.  

Dieser Beispielcode, basierend auf den obigen Schritten, zeigt, wie ein einfaches ActiveX‑Steuerelement verwaltet wird: 
```java
// Zugreifen auf die Präsentation mit ActiveX-Steuerelementen
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Zugreifen auf die erste Folie in der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Text des TextBox-Textes ändern
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Ersetzen des Ersatzbildes ändern. PowerPoint wird dieses Bild während der ActiveX-Aktivierung ersetzen,
        // daher ist es manchmal in Ordnung, das Bild unverändert zu lassen.
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

    // Beschriftung der Schaltfläche ändern
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Ersatzbild ändern
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

            // 100 Punkte nach unten verschieben
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // Steuerelemente entfernen
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```


## **FAQ**

**Behält Aspose.Slides ActiveX-Steuerelemente beim Einlesen und erneuten Speichern bei, wenn sie in der Java‑Laufzeit nicht ausgeführt werden können?**

Ja. Aspose.Slides behandelt sie als Teil der Präsentation und kann ihre Eigenschaften und Rahmen lesen/ändern; die Ausführung der Steuerelemente selbst ist nicht erforderlich, um sie zu erhalten.

**Wie unterscheiden sich ActiveX-Steuerelemente von OLE-Objekten in einer Präsentation?**

ActiveX-Steuerelemente sind interaktive verwaltete Steuerelemente (Schaltflächen, Textfelder, Media Player), während [OLE](/slides/de/java/manage-ole/) sich auf eingebettete Anwendungsobjekte (z. B. ein Excel‑Arbeitsblatt) bezieht. Sie werden unterschiedlich gespeichert und verarbeitet und besitzen unterschiedliche Property‑Modelle.

**Funktionieren ActiveX-Ereignisse und VBA-Makros, wenn die Datei von Aspose.Slides geändert wurde?**

Aspose.Slides bewahrt das vorhandene Markup und die Metadaten; jedoch werden Ereignisse und Makros nur in PowerPoint unter Windows ausgeführt, wenn die Sicherheit dies zulässt. Die Bibliothek führt kein VBA aus.