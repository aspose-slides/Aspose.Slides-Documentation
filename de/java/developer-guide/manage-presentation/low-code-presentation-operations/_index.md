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
- Formen iterieren
- Text iterieren
- Formen sammeln
- Präsentation komprimieren
- Unbenutzte Master-Folien entfernen
- Unbenutzte Layout-Folien entfernen
- Eingebettete Schriftarten komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API in Java, um Präsentationen zu konvertieren und zusammenzuführen, Inhalte zu iterieren, Formen zu sammeln und die Größe der Präsentation zu reduzieren."
---
## **Übersicht**

Das Paket [com.aspose.slides](https://reference.aspose.com/slides/de/java/com.aspose.slides/) bietet statische Hilfsklassen für gängige Präsentationsoperationen. Diese Helfer verpacken häufig genutzte Objektmodell‑Workflows in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Präsentationselemente verarbeiten, Formen sammeln und ungenutzte Inhalte mit weniger Code entfernen können.

Low‑Code‑Helfer sind am nützlichsten, wenn die Operation auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Workflow Ihren Anforderungen entspricht. Verwenden Sie das vollständige [Aspose.Slides‑Objektmodell](https://reference.aspose.com/slides/de/java/com.aspose.slides/), wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Formen, Exporteinstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Helfer zusammen:

| Helfer | Verwendungszweck |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/java/com.aspose.slides/convert/) | Konvertieren einer Präsentation in ein anderes Format mit einem direkten Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/java/com.aspose.slides/merger/) | Zusammenführen kompletter Präsentationsdateien desselben Formats. |
| [ForEach](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/) | Ausführen einer Aktion für jede Folie, Form, Absatz oder Textportion. |
| [Collect](https://reference.aspose.com/slides/de/java/com.aspose.slides/collect/) | Abrufen von Formen aus der gesamten Präsentation für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/) | Entfernen ungenutzter Master und Layouts sowie Reduzieren eingebetteter Schriftartdaten. |

## **Konvertieren einer Präsentation**

Verwenden Sie [Convert.autoByExtension](https://reference.aspose.com/slides/de/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), wenn die Dateierweiterung des Ausgabedateinamens ausreicht, um das Exportformat zu bestimmen. Die Methode öffnet die Quellpräsentation, bestimmt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Die Klasse [Convert] bietet außerdem dedizierte Methoden für die Ausgabe als PDF, SVG, JPEG, PNG und TIFF. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export inspizieren oder ändern oder eine Exportoption konfigurieren müssen, die vom ausgewählten Helfer nicht bereitgestellt wird. Siehe [Präsentation konvertieren](/java/convert-presentation/) für format‑spezifische Workflows und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger.process](https://reference.aspose.com/slides/de/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabepräsentationen müssen dasselbe Dateiformat haben.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Der Helfer ist geeignet, wenn alle Folien zu einem Ergebnis angehängt werden sollen, ohne sie einzeln auszuwählen oder neu zuzuordnen. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder -Layout anwenden, Abschnitte explizit erhalten oder unterschiedliche Foliengrößen abgleichen müssen. Siehe [Präsentationen zusammenführen](/java/merge-presentation/) für diese Szenarien.

## **Durch Präsentationselemente iterieren**

Die Klasse [ForEach](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/) ruft für jeden angeforderten Typ von Präsentationselement einen Callback auf. Sie vermeidet verschachtelte Sammlungsschleifen und ist praktisch für die Inspektion oder Formatierungsänderungen über die gesamte Präsentation hinweg.

Das nachfolgende Beispiel verwendet [ForEach.slide](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), und [ForEach.portion](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) zur Inspektion der entsprechenden Elemente:

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

Standardmäßig umfasst die form‑ und textweite Durchlauf‑Iteration normale, Master‑ und Layout‑Folien. Überladungen mit einem `includeNotes`‑Parameter können auch Notizfolien verarbeiten. Verwenden Sie direkte Sammlungsschleifen, wenn die Durchlaufreihenfolge, ein früher Abbruch, Filterung vor dem Callback‑Aufruf oder eine detaillierte Eltern‑Kind‑Kontrolle wichtig sind.

## **Formen sammeln**

Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), wenn Sie eine Sammlung aller Formen in einer Präsentation benötigen, anstatt für jede Form einen Callback zu erhalten. Dies ist nützlich, wenn dieselbe Menge mehrfach gefiltert, gezählt oder verarbeitet werden soll.

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

Verwenden Sie stattdessen [ForEach.shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), wenn jede Form sofort verarbeitet werden kann und Sie das gesammelte Ergebnis nicht behalten müssen.

## **Präsentationsinhalt komprimieren**

Die Klasse [Compress](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/) kann ungenutzte Strukturelemente entfernen und eingebettete Schriftartdaten reduzieren:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) entfernt Layout‑Folien, auf die keine normale Folie verweist.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) entfernt Master‑Folien, die nicht mehr verwendet werden.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) entfernt ungenutzte Zeichen aus eingebetteten Schriftarten.

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

Entfernen Sie ungenutzte Layouts, bevor Sie ungenutzte Masters entfernen, damit ein Master, der nach der Bereinigung der Layouts nicht mehr referenziert wird, ebenfalls entfernt werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, falls Sie die ursprünglichen Masters, Layouts oder die vollständigen eingebetteten Schriftartdaten später benötigen. Weitere Details siehe [Folienmaster](/java/slide-master/) und [Eingebettete Schriftart](/java/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API anstelle des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Helfer, wenn ein Standardvorgang auf eine komplette Datei oder Präsentation angewendet wird und keine detaillierte Kontrolle über einzelne Elemente erforderlich ist. Verwenden Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Master‑ und Layout‑Beziehungen steuern, den Zwischenzustand inspizieren oder ein Verhalten konfigurieren müssen, das der Helfer nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger.process](https://reference.aspose.com/slides/de/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) erfordert, dass die Eingabedateien dasselbe Format haben. Konvertieren Sie die Eingabedateien zuerst in ein gemeinsames Format, beispielsweise mit [Convert.autoByExtension](https://reference.aspose.com/slides/de/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), und führen Sie dann die konvertierten Dateien zusammen.

**Verarbeitet ForEach Master‑, Layout‑ und Notizfolien?**

[ForEach.slide](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iteriert über normale Präsentationsfolien. Presentation‑weite [ForEach.shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), und [ForEach.portion](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) beinhalten standardmäßig normale, Master‑ und Layout‑Folien. Verwenden Sie deren Überladungen mit `includeNotes` auf `true`, um Notizfolien einzuschließen.

**Was ist der Unterschied zwischen ForEach.shape und Collect.shapes?**

Verwenden Sie [ForEach.shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), um jede Form sofort über einen Callback zu verarbeiten. Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), wenn Sie ein iterierbares Ergebnis benötigen, das behalten, gefiltert, gezählt oder mehrfach durchlaufen werden kann.

**Reduziert Compress immer die Dateigröße der Präsentation?**

Nicht unbedingt. Das Ergebnis hängt davon ab, ob die Präsentation ungenutzte Layouts, ungenutzte Masters oder eingebettete Schriftarten mit nicht verwendeten Zeichen enthält. Wenn keines davon vorhanden ist, können die entsprechenden [Compress]-Operationen die Dateigröße möglicherweise nicht reduzieren.

**Werden Änderungen, die durch ForEach oder Compress vorgenommen wurden, automatisch gespeichert?**

Nein. Diese Helfer arbeiten mit dem geladenen [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)-Objekt im Speicher. Nachdem Sie Elemente in einem [ForEach](https://reference.aspose.com/slides/de/java/com.aspose.slides/foreach/)-Callback geändert oder [Compress](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/) ausgeführt haben, rufen Sie [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Präsentation konvertieren](/java/convert-presentation/)
- [Präsentationen zusammenführen](/java/merge-presentation/)
- [Folienmaster](/java/slide-master/)
- [Textfeld verwalten](/java/manage-textbox/)
- [Eingebettete Schriftart](/java/embedded-font/)