---
title: Präsentationslokalisierung
type: docs
weight: 100
url: /de/nodejs-java/presentation-localization/
---

## **Sprache für Präsentation und Text von Shape ändern**

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
- Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- Legen Sie die Language Id für den Text fest.
- Speichern Sie die Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte wird im folgenden Beispiel demonstriert.
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Löst die Sprach‑ID eine automatische Textübersetzung aus?**

Nein. setLanguageId in Aspose.Slides speichert die Sprache für Rechtschreib‑ und Grammatikprüfung, übersetzt jedoch den Text nicht und ändert ihn nicht. Es handelt sich um Metadaten, die PowerPoint für die Korrektur versteht.

**Beeinflusst die Sprach‑ID die Silbentrennung und den Zeilenumbruch beim Rendern?**

In Aspose.Slides dient setLanguageId der Korrektur. Die Qualität der Silbentrennung und des Zeilenumbruchs hängt hauptsächlich von der Verfügbarkeit geeigneter Schriftarten sowie von Layout‑ und Zeilenumbruch‑Einstellungen für das Schriftsystem ab. Stellen Sie sicher, dass die erforderlichen Schriftarten verfügbar sind, konfigurieren Sie Schriftarten‑Ersetzungsregeln und/oder betten Sie Schriftarten in die Präsentation ein.

**Kann ich innerhalb eines einzelnen Absatzes verschiedene Sprachen festlegen?**

Ja. setLanguageId wird auf Ebene des Textabschnitts angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Korrektureinstellungen mischen kann.