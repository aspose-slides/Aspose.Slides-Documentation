---
title: PowerPoint-Präsentation in JavaScript erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/nodejs-java/create-presentation/
keywords: PowerPoint erstellen java, PowerPoint-Präsentation erstellen, pptx java erstellen
description: Erfahren Sie, wie Sie PowerPoint-Präsentationen wie PPT und PPTX mit JavaScript von Grund auf erstellen.
---

## **PowerPoint-Präsentation erstellen**

Um eine einfache Gerade zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den nachstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse Presentation.
1. Rufen Sie die Referenz einer Folie über deren Index ab.
1. Fügen Sie mit der Methode addAutoShape, die vom Shapes‑Objekt bereitgestellt wird, ein AutoShape vom Typ Linie hinzu.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.
```javascript
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holen Sie die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Fügen Sie ein AutoShape vom Typ Linie hinzu
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Welche Formate kann ich für das Speichern einer neuen Präsentation verwenden?**

Sie können in [PPTX, PPT und ODP](/slides/de/nodejs-java/save-presentation/) speichern und in [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/de/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/de/nodejs-java/convert-powerpoint-to-png/) und [Bilder](/slides/de/nodejs-java/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) ausgehen und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate werden [unterstützt](/slides/de/nodejs-java/supported-file-formats/).

**Wie kann ich die Foliengröße/Seitenverhältnis beim Erstellen einer Präsentation steuern?**

Stellen Sie die [Foliengröße](/slides/de/nodejs-java/slide-size/) ein (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie, wie der Inhalt skaliert werden soll.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB-Verwaltungsstrategien](/slides/de/nodejs-java/manage-blob/), begrenzen Sie den Speicher im Arbeitsspeicher durch die Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherbasierten Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht auf dieselbe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Instanz von [mehreren Threads](/slides/de/nodejs-java/multithreading/) aus zugreifen. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

**Wie entferne ich das Testwasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz an](/slides/de/nodejs-java/licensing/) einmal pro Prozess. Die Lizenz‑XML muss unverändert bleiben und die Lizenzkonfiguration sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das von mir erstellte PPTX digital signieren?**

Ja. [Digitale Signaturen](/slides/de/nodejs-java/digital-signature-in-powerpoint/) (Hinzufügen und Verifizieren) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/nodejs-java/presentation-via-vba/) und makroaktivierte Dateien wie PPTM/PPSM speichern.