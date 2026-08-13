---
title: ActiveX-Steuerungen in Präsentationen auf Android verwalten
linktitle: ActiveX
type: docs
weight: 80
url: /de/androidjava/activex/
keywords:
- ActiveX
- ActiveX-Steuerung
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Media Player
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Android via Java ActiveX nutzt, um PowerPoint-Präsentationen zu automatisieren und zu verbessern, und Entwicklern eine leistungsstarke Kontrolle über Folien bietet."
---
## **Einleitung**

ActiveX‑Steuerungen werden in Präsentationen verwendet. Aspose.Slides für Android via Java ermöglicht das Hinzufügen und Verwalten von ActiveX‑Steuerungen, ist jedoch im Vergleich zu normalen Präsentationsformen etwas schwieriger zu handhaben. Wir haben die Unterstützung zum Hinzufügen einer Media Player Active‑Steuerung in Aspose.Slides implementiert. Hinweis: ActiveX‑Steuerungen sind keine Formen; sie gehören nicht zur Präsentation‑[IShapeCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/). Sie sind stattdessen Teil der separaten [IControlCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icontrolcollection/) . In diesem Thema zeigen wir Ihnen, wie Sie mit ihnen arbeiten.

## **Media Player ActiveX-Steuerung zu einer Folie hinzufügen**
Um eine ActiveX Media Player‑Steuerung hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) und erzeugen Sie eine leere Präsentationsinstanz.  
2. Greifen Sie auf die Zielfolie in [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) zu.  
3. Fügen Sie die Media Player ActiveX‑Steuerung mit der Methode [addControl](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) hinzu, die von [IControlCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icontrolcollection/) bereitgestellt wird.  
4. Greifen Sie auf die Media Player ActiveX‑Steuerung zu und setzen Sie den Video‑Pfad über deren Eigenschaften.  
5. Speichern Sie die Präsentation als PPTX‑Datei.

Dieser Beispielcode, basierend auf den oben genannten Schritten, zeigt, wie Sie eine Media Player ActiveX‑Steuerung zu einer Folie hinzufügen:

```java
import com.aspose.slides.*;

// Leere Präsentationsinstanz erstellen
Presentation pres = new Presentation();
try {
    // Hinzufügen der Media Player ActiveX-Steuerung
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Zugriff auf die Media Player ActiveX-Steuerung und Festlegen des Videopfads
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Präsentation speichern
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ActiveX-Steuerung bearbeiten**
{{% alert color="info" %}} 

Aspose.Slides für Android via Java 7.1.0 und neuere Versionen verfügen über Komponenten zur Verwaltung von ActiveX‑Steuerungen. Sie können die bereits hinzugefügte ActiveX‑Steuerung in Ihrer Präsentation über deren Eigenschaften abrufen und ändern oder löschen.

{{% /alert %}} 

Um eine einfache ActiveX‑Steuerung wie ein Textfeld und eine einfache Schaltfläche auf einer Folie zu verwalten, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) und laden Sie die Präsentation, die ActiveX‑Steuerungen enthält.  
2. Holen Sie sich eine Folienreferenz über ihren Index.  
3. Greifen Sie auf die ActiveX‑Steuerungen in der Folie zu, indem Sie die [IControlCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icontrolcollection/) verwenden.  
4. Greifen Sie mit dem Objekt [IControl](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icontrol/) auf die ActiveX‑Steuerung TextBox1 zu.  
5. Ändern Sie die Eigenschaften der ActiveX‑Steuerung TextBox1, einschließlich Text, Schriftart, Schriftgröße und Rahmenposition.  
6. Greifen Sie auf die zweite Zugriffsteuerung mit dem Namen CommandButton1 zu.  
7. Ändern Sie die Beschriftung, Schriftart und Position des Buttons.  
8. Verschieben Sie die Position der Rahmen der ActiveX‑Steuerungen.  
9. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

Dieser Beispielcode, basierend auf den oben genannten Schritten, zeigt, wie Sie eine einfache ActiveX‑Steuerung verwalten: 

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// Zugriff auf die Präsentation mit ActiveX-Steuerungen
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Zugriff auf die erste Folie in der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox-Text ändern
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Ersetzen des Ersatzbildes ändern. PowerPoint ersetzt dieses Bild während der ActiveX-Aktivierung,
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

    // Verschieben um 100 Punkte nach unten
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // Steuerungen entfernen
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Behält Aspose.Slides ActiveX-Steuerungen bei, wenn sie beim Lesen und erneuten Speichern nicht in der Java‑Laufzeit ausgeführt werden können?

Ja. Aspose.Slides behandelt sie als Teil der Präsentation und kann ihre Eigenschaften und Rahmen lesen/ändern; die Ausführung der Steuerungen selbst ist nicht erforderlich, um sie zu erhalten.

### Wie unterscheiden sich ActiveX-Steuerungen von OLE-Objekten in einer Präsentation?

ActiveX‑Steuerungen sind interaktive verwaltete Steuerungen (Buttons, Textfelder, Media Player), während [OLE](/slides/de/androidjava/manage-ole/) sich auf eingebettete Anwendungsobjekte (z. B. ein Excel‑Arbeitsblatt) bezieht. Sie werden unterschiedlich gespeichert und gehandhabt und besitzen unterschiedliche Property‑Modelle.

### Funktionieren ActiveX‑Ereignisse und VBA‑Makros, wenn die Datei von Aspose.Slides geändert wurde?

Aspose.Slides erhält das vorhandene Markup und die Metadaten; jedoch werden Ereignisse und Makros nur in PowerPoint unter Windows ausgeführt, sofern die Sicherheit dies zulässt. Die Bibliothek führt kein VBA aus.