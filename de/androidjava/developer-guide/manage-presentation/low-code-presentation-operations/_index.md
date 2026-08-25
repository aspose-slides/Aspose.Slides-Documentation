---
title: Low-Code-Präsentationsoperationen auf Android
linktitle: Low-Code-API
type: docs
weight: 50
url: /de/androidjava/low-code-presentation-operations/
keywords:
- Low-Code-Präsentations-API
- Präsentation konvertieren
- Präsentationen zusammenführen
- Folien durchlaufen
- Formen durchlaufen
- Text durchlaufen
- Formen sammeln
- Präsentation komprimieren
- Unbenutzte Masterfolien entfernen
- Unbenutzte Layoutfolien entfernen
- Eingebettete Schriftarten komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API unter Android, um Präsentationen zu konvertieren und zusammenzuführen, Inhalte zu durchlaufen, Shapes zu sammeln und die Präsentationsgröße zu reduzieren."
---
## **Übersicht**

Das [com.aspose.slides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/)‑Paket stellt statische Hilfsklassen für gängige Präsentationsvorgänge bereit. Diese Helfer kapseln häufig verwendete Objektmodell‑Workflows in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Präsentationselemente verarbeiten, Shapes sammeln und ungenutzten Inhalt mit weniger Code entfernen können.

Low‑Code‑Helfer sind am nützlichsten, wenn der Vorgang auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Workflow Ihren Anforderungen entspricht. Verwenden Sie das komplette [Aspose.Slides‑Objektmodell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/), wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Shapes, Export‑Einstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Helfer zusammen:

| Hilfsmittel | Wofür verwenden |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/convert/) | Konvertieren einer Präsentation in ein anderes Format mit einem direkten Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/merger/) | Kombinieren vollständiger Präsentationsdateien desselben Formats. |
| [ForEach](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/) | Ausführen einer Aktion für jede Folie, jedes Shape, jeden Absatz oder Textabschnitt. |
| [Collect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/collect/) | Abrufen von Shapes aus der gesamten Präsentation für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/) | Entfernen ungenutzter Master und Layouts sowie Reduzieren eingebetteter Schriftartdaten. |

## **Convert a Presentation**

Verwenden Sie [Convert.autoByExtension](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), wenn die Dateierweiterung des Ausgabedokuments ausreicht, um das Exportformat zu bestimmen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Die [Convert](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/convert/)‑Klasse bietet außerdem dedizierte Methoden für PDF, SVG, JPEG, PNG und TIFF. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export prüfen oder verändern oder eine Exportoption konfigurieren müssen, die vom ausgewählten Helfer nicht bereitgestellt wird. Siehe [Convert Presentation](/slides/de/androidjava/convert-presentation/) für format‑spezifische Workflows und Optionen.

## **Merge Presentations**

Verwenden Sie [Merger.process](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabedateien müssen dasselbe Dateiformat besitzen.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Der Helfer ist geeignet, wenn alle Folien zu einem Ergebnis angehängt werden sollen, ohne dass sie einzeln ausgewählt oder neu zugeordnet werden. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder ein Ziel‑Layout anwenden, Abschnitte explizit erhalten oder unterschiedliche Foliengrößen abgleichen müssen. Siehe [Merge Presentations](/slides/de/androidjava/merge-presentation/) für diese Szenarien.

## **Iterate Through Presentation Elements**

Die [ForEach](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/)‑Klasse ruft einen Callback für jeden angeforderten Typ von Präsentationselement auf. Sie vermeidet verschachtelte Sammlungsschleifen und ist praktisch für die prüfung oder Formatierung von Präsentations‑weiten Elementen.

Das folgende Beispiel verwendet [ForEach.slide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) und [ForEach.portion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-), um die entsprechenden Elemente zu inspizieren:

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

Standardmäßig umfasst die Präsentations‑weite Shape‑ und Text‑Durchquerung normale Folien sowie Master‑ und Layout‑Folien. Überladungen mit einem `includeNotes`‑Parameter können zudem Notiz‑Folien verarbeiten. Verwenden Sie direkte Sammlungsschleifen, wenn die Durchlaufreihenfolge, ein vorzeitiger Abbruch, Filterung vor dem Callback‑Aufruf oder eine detaillierte Eltern‑Kind‑Kontrolle wichtig sind.

## **Collect Shapes**

Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), wenn Sie eine Sammlung aller Shapes in einer Präsentation benötigen, anstatt eines Callbacks für jedes einzelne Shape. Dies ist nützlich, wenn dieselbe Menge mehrfach gefiltert, gezählt oder verarbeitet werden soll.

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

Verwenden Sie stattdessen [ForEach.shape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), wenn jedes Shape sofort verarbeitet werden kann und Sie das gesammelte Ergebnis nicht behalten müssen.

## **Compress Presentation Content**

Die [Compress](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/)‑Klasse kann ungenutzte Strukturelemente entfernen und eingebettete Schriftartdaten reduzieren:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) entfernt Layout‑Folien, die von keiner normalen Folie referenziert werden.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) entfernt Master‑Folien, die nicht mehr verwendet werden.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) entfernt ungenutzte Zeichen aus eingebetteten Schriftarten.

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

Entfernen Sie zuerst ungenutzte Layouts und erst danach ungenutzte Master, damit ein Master, der nach dem Aufräumen von Layouts nicht mehr referenziert wird, ebenfalls entfernt werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, falls Sie die ursprünglichen Master, Layouts oder die vollständigen eingebetteten Schriftartdaten später benötigen. Weitere Details finden Sie unter [Slide Master](/slides/de/androidjava/slide-master/) und [Embedded Font](/slides/de/androidjava/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API statt des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Helfer, wenn ein Standardvorgang auf eine komplette Datei oder Präsentation angewendet wird und keine detaillierte Kontrolle über einzelne Elemente erforderlich ist. Verwenden Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Master‑ und Layout‑Beziehungen steuern, Zwischenergebnisse prüfen oder Verhaltensweisen konfigurieren müssen, die der Helfer nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger.process](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) erfordert Eingabedateien im gleichen Format. Konvertieren Sie die Eingabedateien zuerst in ein gemeinsames Format, beispielsweise mit [Convert.autoByExtension](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), und führen Sie anschließend die konvertierten Dateien zusammen.

**Verarbeitet ForEach Master‑, Layout‑ und Notiz‑Folien?**

[ForEach.slide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iteriert über normale Präsentationsfolien. Präsentations‑weite [ForEach.shape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) und [ForEach.portion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) schließen standardmäßig normale, Master‑ und Layout‑Folien ein. Verwenden Sie deren Überladungen mit `includeNotes` = `true`, um Notiz‑Folien einzubeziehen.

**Was ist der Unterschied zwischen ForEach.shape und Collect.shapes?**

Verwenden Sie [ForEach.shape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), um jedes Shape sofort über einen Callback zu verarbeiten. Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), wenn Sie ein iterierbares Ergebnis benötigen, das behalten, gefiltert, gezählt oder mehrfach durchlaufen werden kann.

**Macht Compress die Präsentationsdatei immer kleiner?**

Nicht zwingend. Das Ergebnis hängt davon ab, ob die Präsentation ungenutzte Layouts, ungenutzte Master oder eingebettete Schriftarten mit ungenutzten Zeichen enthält. Sind diese nicht vorhanden, können die entsprechenden [Compress](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/)‑Operationen die Dateigröße möglicherweise nicht reduzieren.

**Werden Änderungen durch ForEach oder Compress automatisch gespeichert?**

Nein. Diese Helfer arbeiten auf dem geladenen [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Objekt im Speicher. Nachdem Sie Elemente in einem [ForEach](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/)‑Callback geändert oder [Compress](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/) ausgeführt haben, rufen Sie [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) auf, um das Ergebnis zu schreiben.

## **Related Articles**

- [Convert Presentation](/slides/de/androidjava/convert-presentation/)
- [Merge Presentations](/slides/de/androidjava/merge-presentation/)
- [Slide Master](/slides/de/androidjava/slide-master/)
- [Manage Text Box](/slides/de/androidjava/manage-textbox/)
- [Embedded Font](/slides/de/androidjava/embedded-font/)