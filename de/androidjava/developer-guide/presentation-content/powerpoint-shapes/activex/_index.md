---
title: ActiveX-Steuerelemente in Präsentationen auf Android verwalten
linktitle: ActiveX
type: docs
weight: 80
url: /de/androidjava/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Medienplayer
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Android via Java ActiveX nutzt, um PowerPoint-Präsentationen zu automatisieren und zu verbessern, und Entwicklern leistungsstarke Kontrolle über Folien bietet."
---

{{% alert color="primary" %}} 

ActiveX-Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für Android über Java ermöglicht das Hinzufügen und Verwalten von ActiveX-Steuerelementen, aber sie sind im Vergleich zu normalen Präsentationsformen etwas schwieriger zu handhaben. Wir haben die Unterstützung für das Hinzufügen des Media Player Active‑Steuerelements in Aspose.Slides implementiert. Beachten Sie, dass ActiveX-Steuerelemente keine Formen sind; sie sind nicht Teil der Präsentation's [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IShapeCollection). Sie gehören stattdessen zur separaten [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection). In diesem Thema zeigen wir Ihnen, wie Sie mit ihnen arbeiten.

{{% /alert %}} 

## **Ein Media Player ActiveX‑Steuerelement zu einer Folie hinzufügen**
Um ein ActiveX Media Player‑Steuerelement hinzuzufügen, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) und erzeugen Sie eine leere Präsentationsinstanz.
2. Greifen Sie auf die Zielfolie in [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) zu.
3. Fügen Sie das Media Player ActiveX‑Steuerelement mit der Methode [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) hinzu, die von [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection) bereitgestellt wird.
4. Greifen Sie auf das Media Player ActiveX‑Steuerelement zu und setzen Sie den Videopfad über dessen Eigenschaften.
5. Speichern Sie die Präsentation als PPTX‑Datei.

Dieser Beispielcode, basierend auf den obigen Schritten, zeigt, wie man ein Media Player ActiveX‑Steuerelement zu einer Folie hinzufügt:
```java
// Leere Präsentationsinstanz erstellen
Presentation pres = new Presentation();
try {
    // Media Player ActiveX-Steuerelement hinzufügen
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Auf das Media Player ActiveX-Steuerelement zugreifen und den Videopfad setzen
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Präsentation speichern
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ein ActiveX‑Steuerelement ändern**
{{% alert color="primary" %}} 

Aspose.Slides für Android über Java 7.1.0 und neuere Versionen sind mit Komponenten zur Verwaltung von ActiveX‑Steuerelementen ausgestattet. Sie können das bereits hinzugefügte ActiveX‑Steuerelement in Ihrer Präsentation über dessen Eigenschaften zugreifen und es ändern oder löschen.

{{% /alert %}} 

Um ein einfaches ActiveX‑Steuerelement wie ein Textfeld und eine einfache Schaltfläche auf einer Folie zu verwalten, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) und laden Sie die Präsentation, die ActiveX‑Steuerelemente enthält.
2. Holen Sie sich eine Folienreferenz anhand ihres Index.
3. Greifen Sie über die [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection) auf die ActiveX‑Steuerelemente in der Folie zu.
4. Greifen Sie mit dem [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControl)‑Objekt auf das ActiveX‑Steuerelement TextBox1 zu.
5. Ändern Sie die Eigenschaften des ActiveX‑Steuerelements TextBox1, einschließlich Text, Schriftart, Schriftgröße und Rahmenposition.
6. Greifen Sie auf das zweite Steuerelement mit dem Namen CommandButton1 zu.
7. Ändern Sie die Beschriftung, Schriftart und Position der Schaltfläche.
8. Verschieben Sie die Position der Rahmen der ActiveX‑Steuerelemente.
9. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser Beispielcode, basierend auf den obigen Schritten, zeigt, wie man ein einfaches ActiveX‑Steuerelement verwaltet: 
```java
// Zugriff auf die Präsentation mit ActiveX-Steuerelementen
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Zugriff auf die erste Folie in der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox-Text ändern
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Ersetzen des Platzhalterbildes. PowerPoint wird dieses Bild während der ActiveX-Aktivierung ersetzen,
        // manchmal ist es in Ordnung, das Bild unverändert zu lassen.
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

    // Schaltflächenbeschriftung ändern
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Platzhalter ändern
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

**Behält Aspose.Slides ActiveX‑Steuerelemente beim Lesen und erneuten Speichern bei, wenn sie nicht in der Java‑Laufzeit ausgeführt werden können?**

Ja. Aspose.Slides behandelt sie als Teil der Präsentation und kann deren Eigenschaften und Rahmen lesen/ändern; das Ausführen der Steuerelemente selbst ist nicht erforderlich, um sie zu erhalten.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten in einer Präsentation?**

ActiveX‑Steuerelemente sind interaktive, verwaltete Steuerelemente (Schaltflächen, Textfelder, Media Player), während [OLE](/slides/de/androidjava/manage-ole/) sich auf eingebettete Anwendungsobjekte (z. B. ein Excel‑Arbeitsblatt) bezieht. Sie werden anders gespeichert und verarbeitet und besitzen unterschiedliche Eigenschaftsmodelle.

**Funktionieren ActiveX‑Ereignisse und VBA‑Makros, wenn die Datei von Aspose.Slides geändert wurde?**

Aspose.Slides bewahrt das vorhandene Markup und die Metadaten; Ereignisse und Makros werden jedoch nur innerhalb von PowerPoint unter Windows ausgeführt, sofern die Sicherheit dies zulässt. Die Bibliothek führt kein VBA aus.