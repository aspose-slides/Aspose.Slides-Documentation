---
title: ActiveX
type: docs
weight: 80
url: /de/nodejs-java/activex/
---

{{% alert color="primary" %}} 

ActiveX‑Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für Node.js über Java ermöglicht das Hinzufügen und Verwalten von ActiveX‑Steuerelementen, ist jedoch im Vergleich zu normalen Präsentationsformen etwas schwieriger zu handhaben. Wir haben die Unterstützung für das Hinzufügen des Media Player‑Active‑Steuerelements in Aspose.Slides implementiert. Beachten Sie, dass ActiveX‑Steuerelemente keine Formen sind; sie sind nicht Teil der Präsentations‑[ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/). Sie gehören stattdessen zur separaten [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/). In diesem Thema zeigen wir Ihnen, wie Sie damit arbeiten.

{{% /alert %}} 

## **Hinzufügen des Media Player ActiveX‑Steuerelements zur Folie**
Um ein ActiveX‑Media‑Player‑Steuerelement hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) und erzeugen Sie eine leere Präsentationsinstanz.  
2. Greifen Sie in [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) auf die Zielfolie zu.  
3. Fügen Sie das Media Player‑ActiveX‑Steuerelement mit der Methode [addControl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) hinzu, die von der [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/) bereitgestellt wird.  
4. Greifen Sie auf das Media Player‑ActiveX‑Steuerelement zu und setzen Sie den Videopfad über seine Eigenschaften.  
5. Speichern Sie die Präsentation als PPTX‑Datei.  

Dieser Beispielcode, basierend auf den oben genannten Schritten, zeigt, wie ein Media Player‑ActiveX‑Steuerelement zu einer Folie hinzugefügt wird:
```javascript
// Leere Präsentationsinstanz erstellen
var pres = new aspose.slides.Presentation();
try {
    // Hinzufügen des Media Player ActiveX-Steuerelements
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Zugriff auf das Media Player ActiveX-Steuerelement und Festlegen des Videopfads
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Präsentation speichern
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ändern von ActiveX‑Steuerelementen**

Um ein einfaches ActiveX‑Steuerelement wie ein Textfeld und einen einfachen Befehlsbutton auf einer Folie zu verwalten, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) und laden Sie die Präsentation, die ActiveX‑Steuerelemente enthält.  
2. Holen Sie sich eine Folienreferenz anhand ihres Index.  
3. Greifen Sie über die [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/) auf die ActiveX‑Steuerelemente in der Folie zu.  
4. Greifen Sie mit dem [Control](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/)‑Objekt auf das ActiveX‑Steuerelement TextBox1 zu.  
5. Ändern Sie die Eigenschaften des TextBox1‑ActiveX‑Steuerelements, einschließlich Text, Schriftart, Schriftgröße und Rahmenposition.  
6. Greifen Sie auf das zweite Steuerelement mit dem Namen CommandButton1 zu.  
7. Ändern Sie die Beschriftung, die Schriftart und die Position des Buttons.  
8. Verschieben Sie die Position der Rahmen der ActiveX‑Steuerelemente.  
9. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.  

Dieser Beispielcode, basierend auf den oben genannten Schritten, zeigt, wie ein einfaches ActiveX‑Steuerelement verwaltet wird: 
```javascript
const imageio = java.import("javax.imageio.ImageIO");
// Zugriff auf die Präsentation mit ActiveX‑Steuerelementen
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Zugriff auf die erste Folie in der Präsentation
    var slide = pres.getSlides().get_Item(0);
    // Text des TextBox‑Steuerelements ändern
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Ersatzbild ändern. PowerPoint ersetzt dieses Bild während der ActiveX‑Aktivierung,
        // daher ist es manchmal in Ordnung, das Bild unverändert zu lassen.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // Beschriftung des Buttons ändern
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Ersatz ändern
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // 100 Punkte nach unten verschieben
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // Steuerelemente entfernen
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Behält Aspose.Slides ActiveX‑Steuerelemente bei, wenn sie beim Lesen und erneuten Speichern nicht in der Python‑Laufzeit ausgeführt werden können?**

Ja. Aspose.Slides behandelt sie als Teil der Präsentation und kann ihre Eigenschaften und Rahmen lesen bzw. ändern; die Ausführung der Steuerelemente selbst ist nicht erforderlich, um sie zu erhalten.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten in einer Präsentation?**

ActiveX‑Steuerelemente sind interaktive, verwaltete Steuerelemente (Buttons, Textfelder, Media‑Player), während [OLE](/slides/de/nodejs-java/manage-ole/) sich auf eingebettete Anwendungsobjekte (z. B. ein Excel‑Arbeitsblatt) bezieht. Sie werden unterschiedlich gespeichert und behandelt und besitzen unterschiedliche Eigenschaftsmodelle.

**Funktionieren ActiveX‑Ereignisse und VBA‑Makros, wenn die Datei von Aspose.Slides geändert wurde?**

Aspose.Slides bewahrt das vorhandene Markup und die Metadaten; jedoch werden Ereignisse und Makros nur innerhalb von PowerPoint unter Windows ausgeführt, sofern die Sicherheitsrichtlinien dies zulassen. Die Bibliothek führt kein VBA aus.