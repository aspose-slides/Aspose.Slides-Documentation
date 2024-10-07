---
title: ActiveX
type: docs
weight: 80
url: /androidjava/activex/
---

{{% alert color="primary" %}} 

ActiveX-Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für Android über Java ermöglicht es Ihnen, ActiveX-Steuerelemente hinzuzufügen und zu verwalten, aber sie sind etwas kniffliger zu verwalten im Vergleich zu normalen Präsentationsformen. Wir haben die Unterstützung für das Hinzufügen von Media Player ActiveX-Steuerelementen in Aspose.Slides implementiert. Beachten Sie, dass ActiveX-Steuerelemente keine Formen sind; sie sind nicht Teil der [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IShapeCollection) der Präsentation. Sie sind stattdessen Teil der separaten [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection). In diesem Thema zeigen wir Ihnen, wie Sie damit arbeiten.

{{% /alert %}} 

## **Hinzufügen des Media Player ActiveX-Steuerelements zur Folie**
Um ein ActiveX Media Player-Steuerelement hinzuzufügen, tun Sie dies:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)-Klasse und generieren Sie eine leere Präsentationsinstanz.
1. Greifen Sie auf die Ziel-Folie in [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) zu.
1. Fügen Sie das Media Player ActiveX-Steuerelement mit der Methode [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) hinzu, die von [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection) bereitgestellt wird.
1. Greifen Sie auf das Media Player ActiveX-Steuerelement zu und setzen Sie den Videopfad über seine Eigenschaften.
1. Speichern Sie die Präsentation als PPTX-Datei.

Dieser Beispielcode, basierend auf den obigen Schritten, zeigt, wie man ein Media Player ActiveX-Steuerelement zu einer Folie hinzufügt:

```java
// Erstellen einer leeren Präsentationsinstanz
Presentation pres = new Presentation();
try {
    // Hinzufügen des Media Player ActiveX-Steuerelements
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Zugriff auf das Media Player ActiveX-Steuerelement und Festlegen des Videopfads
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Speichern der Präsentation
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ändern des ActiveX-Steuerelements**
{{% alert color="primary" %}} 

Aspose.Slides für Android über Java 7.1.0 und neuere Versionen sind mit Komponenten ausgestattet, um ActiveX-Steuerelemente zu verwalten. Sie können auf das bereits hinzugefügte ActiveX-Steuerelement in Ihrer Präsentation zugreifen und es über seine Eigenschaften ändern oder löschen.

{{% /alert %}} 

Um ein einfaches ActiveX-Steuerelement wie ein Textfeld und eine einfache Schaltfläche auf einer Folie zu verwalten, tun Sie dies:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation, die ActiveX-Steuerelemente enthält.
1. Erhalten Sie eine Folienreferenz nach ihrem Index.
1. Greifen Sie auf die ActiveX-Steuerelemente in der Folie zu, indem Sie auf die [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection) zugreifen.
1. Greifen Sie auf das TextBox1 ActiveX-Steuerelement über das [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControl)-Objekt zu.
1. Ändern Sie die Eigenschaften des TextBox1 ActiveX-Steuerelements, die Text, Schriftart, Schriftgröße und Rahmenposition umfassen.
1. Greifen Sie auf das zweite Steuerelement namens CommandButton1 zu.
1. Ändern Sie die Beschriftung der Schaltfläche, die Schriftart und die Position.
1. Verschieben Sie die Position der ActiveX-Steuerelementrahmen.
1. Schreiben Sie die bearbeitete Präsentation in eine PPTX-Datei.

Dieser Beispielcode, basierend auf den obigen Schritten, zeigt, wie man ein einfaches ActiveX-Steuerelement verwaltet:

```java
// Zugriff auf die Präsentation mit ActiveX-Steuerelementen
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Zugriff auf die erste Folie in der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ändern des Textes im Textfeld
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Geänderter Text";
        control.getProperties().set_Item("Value", newText);

        // Ändern des Ersatzbilds. PowerPoint wird dieses Bild während der ActiveX-Aktivierung ersetzen,
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

    // Ändern der Schaltflächenbeschriftung
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Nachricht anzeigen";
        control.getProperties().set_Item("Caption", newCaption);
        // Ändern des Ersatzbilds
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