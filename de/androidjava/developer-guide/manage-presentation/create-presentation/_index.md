---
title: Präsentationen auf Android erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/androidjava/create-presentation/
keywords:
- Präsentation erstellen
- neue Präsentation
- PPT erstellen
- neues PPT
- PPTX erstellen
- neues PPTX
- ODP erstellen
- neues ODP
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen Sie Präsentationen in Java mit Aspose.Slides für Android – erzeugen Sie PPT-, PPTX- und ODP-Dateien, profitieren Sie von OpenDocument-Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---
## **Übersicht**

Dieser Artikel zeigt, wie man eine Präsentation in Aspose.Slides für Android über Java erstellt, eine Textbox zur ersten Folie hinzufügt und das Ergebnis als Datei im Speicher Ihrer App speichert. Um eine vorhandene Präsentation zu öffnen oder sie in ein anderes Format zu speichern, siehe [Präsentation öffnen](/slides/de/androidjava/open-presentation/) und [Präsentation speichern](/slides/de/androidjava/save-presentation/). Ein kurzer FAQ am Ende behandelt häufige Fragen zu Formaten, Vorlagen, Foliengröße, Einheiten, Speichernutzung, Threading, Lizenzierung, digitalen Signaturen und VBA‑Unterstützung.

Bevor Sie beginnen, fügen Sie Aspose.Slides Ihrem Android-Projekt aus dem Maven-Repository von Aspose hinzu. Siehe [Installation](/slides/de/androidjava/install-aspose-slides-for-android-via-java/).

## **PowerPoint‑Präsentation erstellen**

Um eine Präsentation zu erstellen und eine Textbox auf der ersten Folie zu platzieren, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Ein neue Präsentation enthält bereits eine leere Folie.  
2. Holen Sie diese Folie aus der [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) , indem Sie den Index 0 angeben.  
3. Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) der [shape collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) ein Rechteck hinzu und setzen Sie den Text seines [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) mit der Methode [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Speichern Sie die Präsentation als PPTX-Datei mit der Methode [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) , im Format [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/).

Der Code wird innerhalb einer `Activity` ausgeführt, zum Beispiel in deren `onCreate`‑Methode. Er speichert die Datei in dem Verzeichnis, das von der Methode [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) zurückgegeben wird: dem privaten Speicher Ihrer App, in den ohne zusätzliche Berechtigungen geschrieben werden kann.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die linke obere Ecke des Rechtecks befindet sich 50 Punkte vom linken Rand und 50 Punkte vom oberen Rand der Folie, und das Rechteck ist 400 Punkte breit und 100 Punkte hoch. Die gespeicherte Datei enthält eine Folie mit diesem Rechteck und dessen Text. Ohne Lizenz fügt Aspose.Slides jedem gespeicherten Blatt ein Evaluations‑Wasserzeichen hinzu; siehe [Lizenzierung](/slides/de/androidjava/licensing/).

Um die Datei anzusehen, öffnen Sie den [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) von Android Studio und finden Sie *hello.pptx* unter *data/data/* im *files*-Ordner Ihrer App. In einer echten Anwendung sollten Präsentationen in einem Hintergrund‑Thread verarbeitet werden, damit die Benutzeroberfläche reaktionsfähig bleibt.

## **FAQ**

### In welchen Formaten kann ich eine neue Präsentation speichern?

Sie können in [PPTX, PPT und ODP](/slides/de/androidjava/save-presentation/) speichern und in [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/de/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/de/androidjava/convert-powerpoint-to-html/), [SVG](/slides/de/androidjava/render-a-slide-as-an-svg-image/) sowie in [Bilder](/slides/de/androidjava/convert-powerpoint-to-png/) exportieren, unter anderem.

### Kann ich aus einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate [werden unterstützt](/slides/de/androidjava/supported-file-formats/).

### Wie kann ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation steuern?

Legen Sie die [Foliengröße](/slides/de/androidjava/slide-size/) fest (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und bestimmen Sie, wie der Inhalt skaliert werden soll.

### In welchen Einheiten werden Größen und Koordinaten gemessen?

In Punkt: 1 Zoll entspricht 72 Einheiten.

### Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?

Verwenden Sie [BLOB management strategies](/slides/de/androidjava/manage-blob/), begrenzen Sie den Speicher im Arbeitsspeicher durch Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherbasierten Streams.

### Kann ich Präsentationen parallel erstellen/speichern?

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Instanz von [mehreren Threads](/slides/de/androidjava/multithreading/) aus bearbeiten. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

### Wie entferne ich das Test‑Wasserzeichen und die Einschränkungen?

[Lizenz anwenden](/slides/de/androidjava/licensing/) einmal pro Prozess. Die Lizenz‑XML darf nicht verändert werden, und die Lizenzeinrichtung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

### Kann ich das erstellte PPTX digital signieren?

Ja. [Digital signatures](/slides/de/androidjava/digital-signature-in-powerpoint/) (Hinzufügen und Verifizieren) werden für Präsentationen unterstützt.

### Werden Makros (VBA) in erstellten Präsentationen unterstützt?

Ja. Sie können [create/edit VBA projects](/slides/de/androidjava/presentation-via-vba/) erstellen/bearbeiten und makrofähige Dateien wie PPTM/PPSM speichern.