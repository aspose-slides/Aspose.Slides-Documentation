---
title: ActiveX
type: docs
weight: 80
url: /de/java/activex/
---


{{% alert color="primary" %}} 

ActiveX-Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für Java ermöglicht es Ihnen, ActiveX-Steuerelemente hinzuzufügen und zu verwalten, aber sie sind etwas schwieriger zu verwalten im Vergleich zu normalen Präsentationsformen. Wir haben die Unterstützung zum Hinzufügen von Media Player Active-Steuerelementen in Aspose.Slides implementiert. Bitte beachten Sie, dass ActiveX-Steuerelemente keine Formen sind; sie sind kein Teil der [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IShapeCollection) der Präsentation. Stattdessen sind sie Teil der separaten [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection). In diesem Thema zeigen wir Ihnen, wie Sie mit ihnen arbeiten.

{{% /alert %}} 

## **Hinzufügen eines Media Player ActiveX-Steuerelements zur Folie**
Um ein ActiveX Media Player-Steuerelement hinzuzufügen, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)-Klasse und generieren Sie eine leere Präsentationsinstanz.
1. Greifen Sie auf die Ziel-Folie in der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) zu.
1. Fügen Sie das Media Player ActiveX-Steuerelement mithilfe der von [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection) bereitgestellten [addControl](https://reference.aspose.com/slides/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) Methode hinzu.
1. Greifen Sie auf das Media Player ActiveX-Steuerelement zu und setzen Sie den Videopfad über seine Eigenschaften.
1. Speichern Sie die Präsentation als PPTX-Datei.

Dieser Beispielcode, basierend auf den obigen Schritten, zeigt, wie Sie ein Media Player ActiveX-Steuerelement zu einer Folie hinzufügen:

```java
// Erstellen Sie eine leere Präsentationsinstanz
Presentation pres = new Presentation();
try {
    // Hinzufügen des Media Player ActiveX-Steuerelements
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Greifen Sie auf das Media Player ActiveX-Steuerelement zu und setzen Sie den Videopfad
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Die Präsentation speichern
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ändern des ActiveX-Steuerelements**
{{% alert color="primary" %}} 

Aspose.Slides für Java 7.1.0 und neuere Versionen sind mit Komponenten zum Verwalten von ActiveX-Steuerelementen ausgestattet. Sie können auf das bereits hinzugefügte ActiveX-Steuerelement in Ihrer Präsentation zugreifen und es über seine Eigenschaften ändern oder löschen.

{{% /alert %}} 

Um ein einfaches ActiveX-Steuerelement wie ein Textfeld und eine einfache Schaltfläche auf einer Folie zu verwalten, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit ActiveX-Steuerelementen.
1. Erhalten Sie eine Folienreferenz anhand ihres Index.
1. Greifen Sie auf die ActiveX-Steuerelemente auf der Folie zu, indem Sie die [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection) aufrufen.
1. Greifen Sie auf das TextBox1 ActiveX-Steuerelement über das [IControl](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControl) Objekt zu.
1. Ändern Sie die Eigenschaften des TextBox1 ActiveX-Steuerelements, einschließlich Text, Schriftart, Schriftgröße und Rahmenposition.
1. Greifen Sie auf das zweite Steuerlement namens CommandButton1 zu.
1. Ändern Sie die Schaltflächenbeschriftung, Schriftart und Position.
1. Verschieben Sie die Position der ActiveX-Steuerelementrahmen.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Beispielcode, basierend auf den obigen Schritten, zeigt, wie Sie ein einfaches ActiveX-Steuerelement verwalten:

```java
// Zugriff auf die Präsentation mit ActiveX-Steuerelementen
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Zugriff auf die erste Folie in der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ändern des Texts im TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Geänderter Text";
        control.getProperties().set_Item("Value", newText);

        // Ändern des Ersatzbildes. PowerPoint wird dieses Bild während der ActiveX-Aktivierung ersetzen,
        // also ist es manchmal in Ordnung, das Bild unverändert zu lassen.
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
        String newCaption = "MessageBox anzeigen";
        control.getProperties().set_Item("Caption", newCaption);
        // Ersetzen
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

    // Verschieben um 100 Punkte nach unten
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // Entfernen der Steuerelemente
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```