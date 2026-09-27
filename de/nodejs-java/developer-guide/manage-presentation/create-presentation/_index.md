---
title: Präsentationen in JavaScript erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/nodejs-java/create-presentation/
keywords:
- Präsentation erstellen
- neue Präsentation
- PPT erstellen
- neue PPT
- PPTX erstellen
- neue PPTX
- ODP erstellen
- neue ODP
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen Sie Präsentationen mit Aspose.Slides – erzeugen Sie PPT-, PPTX- und ODP-Dateien, profitieren Sie von OpenDocument-Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---
## **Übersicht**

Dieser Artikel zeigt, wie man eine Präsentation in Aspose.Slides erstellt, ein Textfeld auf die erste Folie hinzufügt und das Ergebnis als Datei speichert.

Bevor Sie beginnen, installieren Sie das npm‑Paket `aspose.slides.via.java` zusammen mit dem JDK, Python und den benötigten C++‑Build‑Tools. Siehe [Installation](/slides/de/nodejs-java/installation/).

## **Erstellen einer PowerPoint‑Präsentation**

Um eine Präsentation zu erstellen und ein Textfeld auf die erste Folie zu setzen, folgen Sie diesen Schritten:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Eine neue Präsentation enthält bereits eine leere Folie.
1. Holen Sie diese Folie aus der [Folien‑Sammlung](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) über ihren Index 0.
1. Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addautoshape/) ein Rechteck hinzu und setzen Sie dessen Text mit [setText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/settext/).
1. Speichern Sie die Präsentation als PPTX‑Datei mit der Methode [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/).
1. Geben Sie die Präsentation mit der Methode [dispose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/dispose/) frei und beenden Sie den Vorgang.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides läuft in einer Java-virtuellen Maschine, die Node.js am Laufen hält, daher das Verfahren explizit beenden.
process.exit(0);
```

Die linke obere Ecke des Rechtecks befindet sich 50 Punkte vom linken Rand und 50 Punkte vom oberen Rand der Folie, und das Rechteck ist 400 Punkte breit und 100 Punkte hoch. Speichern Sie den Code als *hello.js* in Ihrem Projektordner und führen Sie `node hello.js` aus: Es speichert *hello.pptx* mit einer Folie, die dieses Rechteck und dessen Text enthält, im aktuellen Ordner.

Aspose.Slides läuft in einer Java‑Virtuellen Maschine, die das `java`‑Paket innerhalb des Node.js‑Prozesses startet. Diese Virtuelle Maschine verhindert, dass Node.js nach Abschluss des Skripts von selbst beendet wird, sodass das Beispiel mit `process.exit(0)` endet.

Ohne Lizenz fügt Aspose.Slides jedem gespeicherten Folien ein Evaluations‑Wasserzeichen hinzu; siehe [Licensing](/slides/de/nodejs-java/licensing/).

## **FAQ**

### In welchen Formaten kann ich eine neue Präsentation speichern?

Sie können in [PPTX, PPT und ODP](/slides/de/nodejs-java/save-presentation/) speichern und in [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/de/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/de/nodejs-java/render-a-slide-as-an-svg-image/) und [Bilder](/slides/de/nodejs-java/convert-powerpoint-to-png/) exportieren, unter anderem.

### Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate werden [unterstützt](/slides/de/nodejs-java/supported-file-formats/).

### Wie steuere ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation?

Stellen Sie die [Foliengröße](/slides/de/nodejs-java/slide-size/) ein (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie, wie der Inhalt skaliert werden soll.

### In welchen Einheiten werden Größen und Koordinaten gemessen?

In Punkten: 1 Zoll entspricht 72 Einheiten.

### Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/nodejs-java/manage-blob/), begrenzen Sie den Speicher im Arbeitsspeicher durch die Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Arbeitsabläufe gegenüber rein speicherbasierten Streams.

### Kann ich Präsentationen parallel erstellen/speichern?

Sie können nicht gleichzeitig auf dieselbe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Instanz von [mehreren Threads](/slides/de/nodejs-java/multithreading/) zugreifen. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

### Wie entferne ich das Test‑Wasserzeichen und die Einschränkungen?

[Wenden Sie eine Lizenz](/slides/de/nodejs-java/licensing/) pro Prozess an. Die Lizenz‑XML muss unverändert bleiben, und die Lizenzkonfiguration sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

### Kann ich das erstellte PPTX digital signieren?

Ja. [Digitale Signaturen](/slides/de/nodejs-java/digital-signature-in-powerpoint/) (Hinzufügen und Verifizieren) werden für Präsentationen unterstützt.

### Werden Makros (VBA) in erstellten Präsentationen unterstützt?

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/nodejs-java/presentation-via-vba/) und makroaktivierte Dateien wie PPTM/PPSM speichern.