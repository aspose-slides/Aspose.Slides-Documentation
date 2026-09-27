---
title: Präsentationen in Java erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/java/create-presentation/
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
- Java
- Aspose.Slides
description: "Erstellen Sie Präsentationen in Java mit Aspose.Slides – erzeugen Sie PPT-, PPTX- und ODP-Dateien, nutzen Sie die OpenDocument-Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---
## **Übersicht**

Dieser Artikel zeigt, wie man in Aspose.Slides eine Präsentation erstellt, einer ihrer ersten Folien eine Form mit Text hinzufügt und das Ergebnis als PPTX-Datei speichert. Um eine vorhandene Präsentation zu öffnen und in ein anderes Format zu speichern, siehe [Open Presentations](/slides/de/java/open-presentation/) und [Save Presentations](/slides/de/java/save-presentation/). Ein kurzer FAQ am Ende behandelt häufige Fragen zu Formaten, Vorlagen, Foliengröße, Einheiten, Speicherverbrauch, Threading, Lizenzierung, digitalen Signaturen und VBA‑Unterstützung.

Bevor Sie beginnen, fügen Sie Aspose.Slides für Java Ihrem Projekt aus dem Maven‑Repository von Aspose hinzu. Siehe [Installation](/slides/de/java/installation/) für die Maven‑Konfiguration und die zusätzlichen Anforderungen für Linux.

## **Präsentation erstellen**

Das Erstellen einer PowerPoint‑Datei von Grund auf in Aspose.Slides für Java beginnt mit einer Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/). Der Konstruktor liefert eine leere Präsentation mit einer einzigen Folie, die bereit ist für Formen, Text, Diagramme oder andere Inhalte, die Ihre Anwendung benötigt. Nachdem Sie diese Folie bearbeitet oder neue hinzugefügt haben, können Sie das Ergebnis im PPTX‑, alten PPT‑ oder OpenDocument‑Format speichern.

Um eine Präsentation zu erstellen und auf ihrer ersten Folie eine Form mit Text zu platzieren, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/). Eine neue Präsentation enthält bereits eine leere Folie.
1. Holen Sie diese Folie anhand ihres Index 0 aus der Sammlung, die [getSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getSlides--) zurückgibt.
1. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) des Typs `Cloud` mit der Methode [addAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) hinzu und setzen Sie dessen Text mit [setText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#setText-java.lang.String-).
1. Speichern Sie die Präsentation als PPTX‑Datei mit der Methode [save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-).

Das untenstehende Beispiel ist ein vollständiges Programm. Im Maven‑Projekt aus [Installation](/slides/de/java/installation/) speichern Sie es als *src/main/java/HelloSlides.java* und führen `mvn compile exec:java` aus.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Präsentation erstellen. Sie enthält bereits eine leere Folie.
        Presentation presentation = new Presentation();
        try {
            // Erste Folie holen.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Eine Wolkenform hinzufügen und Text darin platzieren.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Präsentation als PPTX-Datei speichern.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Die obere linke Ecke der Wolke befindet sich 20 Punkte vom linken Rand und 20 Punkte vom oberen Rand der Folie, und die Form ist 200 Punkte breit und 80 Punkte hoch. Das Programm speichert *new_presentation.pptx* mit einer Folie, die die Wolke und ihren Text enthält. Ohne Lizenz fügt Aspose.Slides jedem gespeicherten Blatt ein Evaluierungswasserzeichen hinzu; siehe [Licensing](/slides/de/java/licensing/).

Das Ergebnis:

![The new presentation](new_presentation.png)

## **FAQ**

### In welche Formate kann ich eine neue Präsentation speichern?

Sie können in [PPTX, PPT und ODP](/slides/de/java/save-presentation/) speichern und in [PDF](/slides/de/java/convert-powerpoint-to-pdf/), [XPS](/slides/de/java/convert-powerpoint-to-xps/), [HTML](/slides/de/java/convert-powerpoint-to-html/), [SVG](/slides/de/java/render-a-slide-as-an-svg-image/) sowie in [Bilder](/slides/de/java/convert-powerpoint-to-png/) exportieren, unter anderem.

### Kann ich aus einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate [werden unterstützt](/slides/de/java/supported-file-formats/).

### Wie kann ich die Foliengröße bzw. das Seitenverhältnis bei der Erstellung einer Präsentation steuern?

Stellen Sie die [Foliengröße](/slides/de/java/slide-size/) ein (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie, wie der Inhalt skaliert werden soll.

### In welchen Einheiten werden Größen und Koordinaten gemessen?

In Punkten: 1 Zoll entspricht 72 Einheiten.

### Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/java/manage-blob/), begrenzen Sie den Speicher im Arbeitsspeicher durch Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherbasierten Streams.

### Kann ich Präsentationen parallel erstellen/speichern?

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz von [mehreren Threads](/slides/de/java/multithreading/) aus verwenden. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

### Wie entferne ich das Testwasserzeichen und die Einschränkungen?

[​Lizenz anwenden](/slides/de/java/licensing/) einmal pro Prozess. Die Lizenz‑XML muss unverändert bleiben, und die Lizenzkonfiguration sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

### Kann ich das von mir erstellte PPTX digital signieren?

Ja. [Digitale Signaturen](/slides/de/java/digital-signature-in-powerpoint/) (Hinzufügen und Verifizieren) werden für Präsentationen unterstützt.

### Werden Makros (VBA) in erstellten Präsentationen unterstützt?

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/java/presentation-via-vba/) und makrofähige Dateien wie PPTM/PPSM speichern.