---
title: Low-Code-Präsentationsoperationen in Java
linktitle: Low-Code-API
type: docs
weight: 50
url: /de/java/low-code-presentation-operations/
keywords:
- Low-Code-Präsentations-API
- Präsentation konvertieren
- Präsentationen zusammenführen
- Folien iterieren
- Shapes iterieren
- Text iterieren
- Shapes sammeln
- Präsentation komprimieren
- Unbenutzte Masterfolien entfernen
- Unbenutzte Layoutfolien entfernen
- Eingebettete Schriften komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API in Java, um Präsentationen zu konvertieren und zusammenzuführen, Inhalte zu iterieren, Shapes zu sammeln und die Präsentationsgröße zu reduzieren."
---
## **Übersicht**

Das Paket [com.aspose.slides](https://reference.aspose.com/slides/de/java/com.aspose.slides/) stellt statische Hilfsklassen für gängige Vorgänge mit Präsentationen bereit. Diese Helfer kapseln häufig genutzte Objektmodell‑Workflows in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Präsentationselemente verarbeiten, Shapes sammeln und ungenutzten Inhalt mit weniger Code entfernen können.

Low‑Code‑Helfer sind am nützlichsten, wenn der Vorgang auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Workflow Ihren Anforderungen entspricht. Verwenden Sie das vollständige [Aspose.Slides‑Objektmodell](https://reference.aspose.com/slides/de/java/com.aspose.slides/), wenn Sie feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Shapes, Export‑Einstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Helfer zusammen:

| Helfer | Verwendung für |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/java/com.aspose.slides/convert/) | Konvertieren einer Präsentation in ein anderes Format mit einem direkten Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/java/com.aspose.slides/merger/) | Zusammenführen kompletter Präsentationsdateien desselben Formats. |
| [ForEach](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/) | Ausführen einer Aktion für jede Folie, jedes Shape, jeden Absatz oder jeden Textanteil. |
| [Collect](https://reference.aspose.com/slides/de/java/com.aspose.slides/collect/) | Abrufen von Shapes aus der gesamten Präsentation für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/) | Entfernen ungenutzter Master und Layouts sowie Reduzierung eingebetteter Schriftartdaten. |

## **Eine Präsentation konvertieren**

Verwenden Sie [Convert.autoByExtension](https://reference.aspose.com/slides/de/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), wenn die Dateierweiterung des Ausgabepfads ausreicht, um das Exportformat zu bestimmen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Die Klasse [Convert](https://reference.aspose.com/slides/de/java/com.aspose.slides/convert/) bietet zudem dedizierte Methoden für PDF, SVG, JPEG, PNG und TIFF. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export prüfen oder ändern oder eine Exportoption konfigurieren müssen, die vom ausgewählten Helfer nicht bereitgestellt wird. Siehe [Convert Presentation](/slides/de/java/convert-presentation/) für format‑spezifische Workflows und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger.process](https://reference.aspose.com/slides/de/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabedateien müssen dasselbe Dateiformat besitzen.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Der Helfer ist geeignet, wenn alle Folien zu einem Ergebnis hinzugefügt werden sollen, ohne sie einzeln auswählen oder neu zuzuordnen. Nutzen Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder ein Ziel‑Layout anwenden, Abschnitte explizit erhalten oder unterschiedliche Foliengrößen abgleichen müssen. Siehe [Merge Presentations](/slides/de/java/merge-presentation/) für diese Szenarien.

## **Durch Präsentationselemente iterieren**

Die Klasse [ForEach](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/) ruft für jeden angeforderten Typ von Präsentationselement einen Callback auf. Sie vermeidet verschachtelte Schleifen über Sammlungen und ist praktisch für die prüfungsgleiche Inspektion oder Formatierungsänderungen in der gesamten Präsentation.

Das folgende Beispiel verwendet [ForEach.slide](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) und [ForEach.portion](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-), um die entsprechenden Elemente zu inspizieren:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Standardmäßig umfasst die traversal über Shapes und Text in der gesamten Präsentation normale, Master‑ und Layout‑Folien. Überladungen mit einem `includeNotes`‑Parameter können zudem Notizfolien verarbeiten. Verwenden Sie direkte Sammlungs‑Schleifen, wenn die Durchlaufreihenfolge, ein vorzeitiger Abbruch, Filterung vor dem Callback‑Aufruf oder eine detaillierte Eltern‑Kind‑Steuerung wichtig sind.

## **Shapes sammeln**

Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), wenn Sie eine Sammlung aller Shapes in einer Präsentation benötigen, anstatt für jedes Shape einen Callback zu erhalten. Dies ist nützlich, wenn dieselbe Menge mehrfach gefiltert, gezählt oder verarbeitet werden soll.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Verwenden Sie stattdessen [ForEach.shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), wenn jedes Shape sofort verarbeitet werden kann und Sie das gesammelte Ergebnis nicht behalten müssen.

## **Präsentationsinhalt komprimieren**

Die Klasse [Compress](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/) kann ungenutzte Strukturelemente entfernen und eingebettete Schriftartdaten reduzieren:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) entfernt Layout‑Folien, auf die keine normale Folie verweist.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) entfernt Master‑Folien, die nicht mehr verwendet werden.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) entfernt ungenutzte Zeichen aus eingebetteten Schriften.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Entfernen Sie zuerst ungenutzte Layouts, bevor Sie ungenutzte Master entfernen, damit ein Master, der nach der Layout‑Bereinigung nicht mehr referenziert wird, ebenfalls entfernt werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, falls Sie die ursprünglichen Master, Layouts oder die vollständigen eingebetteten Schriftartdaten später noch benötigen. Weitere Details finden Sie unter [Slide Master](/slides/de/java/slide-master/) und [Embedded Font](/slides/de/java/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API anstelle des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Helfer, wenn ein Standardvorgang auf eine komplette Datei oder Präsentation angewendet wird und keine detaillierte Kontrolle über einzelne Elemente erforderlich ist. Nutzen Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Beziehungen zwischen Master und Layout steuern, einen Zwischenstatus prüfen oder ein Verhalten konfigurieren müssen, das der Helfer nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger.process](https://reference.aspose.com/slides/de/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) verlangt Eingabedateien im gleichen Format. Konvertieren Sie die Eingabedateien zuerst in ein gemeinsames Format, beispielsweise mit [Convert.autoByExtension](https://reference.aspose.com/slides/de/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), und führen Sie anschließend die konvertierten Dateien zusammen.

**Verarbeitet ForEach Master‑, Layout‑ und Notizfolien?**

[ForEach.slide](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iteriert über normale Präsentationsfolien. Das Präsentations‑weite [ForEach.shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) und [ForEach.portion](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) schließen standardmäßig normale, Master‑ und Layout‑Folien ein. Verwenden Sie deren Überladungen mit `includeNotes` = `true`, um Notizfolien einzubeziehen.

**Was ist der Unterschied zwischen ForEach.shape und Collect.shapes?**

Verwenden Sie [ForEach.shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), um jedes Shape sofort über einen Callback zu verarbeiten. Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), wenn Sie ein iterierbares Ergebnis benötigen, das Sie behalten, filtern, zählen oder mehrmals durchlaufen können.

**Macht Compress die Präsentationsdatei immer kleiner?**

Nicht unbedingt. Das Ergebnis hängt davon ab, ob die Präsentation ungenutzte Layouts, ungenutzte Master oder eingebettete Schriften mit ungenutzten Zeichen enthält. Wenn keiner dieser Punkte vorkommt, reduzieren die entsprechenden [Compress](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/)‑Operationen die Dateigröße möglicherweise nicht.

**Werden Änderungen durch ForEach oder Compress automatisch gespeichert?**

Nein. Diese Helfer arbeiten mit dem geladenen [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)-Objekt im Speicher. Nachdem Sie Elemente in einem [ForEach](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/)-Callback geändert oder [Compress](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/) ausgeführt haben, rufen Sie [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Convert Presentation](/slides/de/java/convert-presentation/)
- [Merge Presentations](/slides/de/java/merge-presentation/)
- [Slide Master](/slides/de/java/slide-master/)
- [Manage Text Box](/slides/de/java/manage-textbox/)
- [Embedded Font](/slides/de/java/embedded-font/)