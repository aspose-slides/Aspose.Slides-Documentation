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
- Folien iterieren
- Formen iterieren
- Text iterieren
- Formen sammeln
- Präsentation komprimieren
- Nicht verwendete Masterfolien entfernen
- Nicht verwendete Layoutfolien entfernen
- Eingebettete Schriftarten komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API auf Android, um Präsentationen zu konvertieren und zusammenzuführen, Inhalte zu iterieren, Formen zu sammeln und die Präsentationsgröße zu reduzieren."
---
## **Übersicht**

Das Paket [com.aspose.slides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/) bietet statische Hilfsklassen für gängige Präsentationsoperationen. Diese Hilfsklassen kapseln häufig verwendete Objektmodell‑Arbeitsabläufe in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Präsentationselemente verarbeiten, Formen sammeln und nicht verwendete Inhalte mit weniger Code entfernen können.

Low‑code‑Hilfsklassen sind am nützlichsten, wenn die Operation auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Arbeitsablauf Ihren Anforderungen entspricht. Verwenden Sie das vollständige Aspose.Slides‑Objektmodell, wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Formen, Export‑Einstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Hilfsklassen zusammen:

| Hilfsklasse | Verwendungszweck |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/convert/) | Konvertieren einer Präsentation in ein anderes Format mit einem direkten Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/merger/) | Kombinieren kompletter Präsentationsdateien desselben Formats. |
| [ForEach](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/) | Ausführen einer Aktion für jede Folie, Form, Absatz oder Textportion. |
| [Collect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/collect/) | Abrufen von Formen aus der gesamten Präsentation für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/) | Entfernen nicht verwendeter Master und Layouts sowie Reduzieren eingebetteter Schriftartdaten. |

## **Eine Präsentation konvertieren**

Verwenden Sie [Convert.autoByExtension](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), wenn die Dateierweiterung des Ausgabedokuments ausreicht, um das Exportformat auszuwählen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Die [Convert](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/convert/)‑Klasse bietet zudem dedizierte Methoden für PDF-, SVG-, JPEG-, PNG‑ und TIFF‑Ausgabe. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export inspizieren oder ändern müssen oder eine Exportoption konfigurieren wollen, die von der Hilfsklasse nicht bereitgestellt wird. Siehe [Präsentation konvertieren](/androidjava/convert-presentation/) für format‑spezifische Arbeitsabläufe und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger.process](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabedateien müssen dasselbe Dateiformat besitzen.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Die Hilfsklasse ist geeignet, wenn alle Folien zu einem Ergebnis angehängt werden sollen, ohne sie einzeln auszuwählen oder neu zuzuordnen. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder ein Ziel‑Layout anwenden, Abschnitte explizit erhalten oder unterschiedliche Foliengrößen abgleichen müssen. Siehe [Präsentationen zusammenführen](/androidjava/merge-presentation/) für diese Szenarien.

## **Durch Präsentationselemente iterieren**

Die [ForEach](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/)‑Klasse ruft einen Callback für jeden angeforderten Typ von Präsentationselement auf. Sie vermeidet verschachtelte Schleifen über Sammlungen und ist praktisch für eine Präsentations‑weite Inspektion oder Formatierungsänderungen.

Im folgenden Beispiel werden [ForEach.slide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) und [ForEach.portion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) verwendet, um die entsprechenden Elemente zu inspizieren:

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

Standardmäßig umfasst die Präsentations‑weite Traversierung von Formen und Text normale, Master‑ und Layout‑Folien. Überladungen mit einem `includeNotes`‑Parameter können zudem Notizfolien verarbeiten. Verwenden Sie direkte Schleifen, wenn die Traversierungsreihenfolge, frühzeitiger Abbruch, Vor‑Filterung vor dem Callback‑Aufruf oder eine detaillierte Eltern‑Kind‑Steuerung wichtig sind.

## **Formen sammeln**

Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), wenn Sie eine Sammlung aller Formen einer Präsentation benötigen, anstatt für jede Form einen Callback zu erhalten. Dies ist nützlich, wenn dieselbe Menge gefiltert, gezählt oder mehrfach verarbeitet werden soll.

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

Verwenden Sie stattdessen [ForEach.shape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), wenn jede Form sofort verarbeitet werden kann und Sie das gesammelte Ergebnis nicht behalten müssen.

## **Präsentationsinhalt komprimieren**

Die [Compress](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/)‑Klasse kann nicht verwendete strukturelle Elemente entfernen und eingebettete Schriftartdaten reduzieren:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) entfernt Layout‑Folien, die von keiner normalen Folie referenziert werden.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) entfernt Master‑Folien, die nicht mehr verwendet werden.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) entfernt nicht verwendete Zeichen aus eingebetteten Schriftarten.

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

Entfernen Sie zuerst nicht verwendete Layouts, bevor Sie nicht verwendete Master entfernen, damit ein Master, der nach der Layout‑Bereinigung nicht mehr referenziert wird, ebenfalls entfernt werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, falls Sie die ursprünglichen Master, Layouts oder die vollständigen eingebetteten Schriftartdaten später noch benötigen. Weitere Details finden Sie unter [Folienmaster](/androidjava/slide-master/) und [Eingebettete Schriftart](/androidjava/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API anstelle des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Hilfsklassen, wenn eine Standard‑Operation auf eine komplette Datei oder Präsentation zutrifft und keine detaillierte Kontrolle über einzelne Elemente erforderlich ist. Verwenden Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Master‑ und Layout‑Beziehungen steuern, Zwischenergebnisse prüfen oder ein Verhalten konfigurieren müssen, das die Hilfsklasse nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger.process](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) erfordert Eingabedateien im gleichen Format. Konvertieren Sie die Eingabedateien zuerst in ein gemeinsames Format, beispielsweise mit [Convert.autoByExtension](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), und führen Sie anschließend die konvertierten Dateien zusammen.

**Verarbeitet ForEach Master‑, Layout‑ und Notizfolien?**

[ForEach.slide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iteriert über normale Präsentationsfolien. Präsentations‑weite [ForEach.shape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) und [ForEach.portion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) schließen standardmäßig normale, Master‑ und Layout‑Folien ein. Verwenden Sie ihre Überladungen mit `includeNotes` = `true`, um Notizfolien mit einzubeziehen.

**Was ist der Unterschied zwischen ForEach.shape und Collect.shapes?**

Verwenden Sie [ForEach.shape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), um jede Form sofort über einen Callback zu verarbeiten. Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), wenn Sie ein iterierbares Ergebnis benötigen, das behalten, gefiltert, gezählt oder mehrmals durchlaufen werden kann.

**Komprimiert Compress immer die Präsentationsdatei?**

Nicht unbedingt. Das Ergebnis hängt davon ab, ob die Präsentation nicht verwendete Layouts, nicht verwendete Master oder eingebettete Schriftarten mit ungenutzten Zeichen enthält. Wenn keiner dieser Fälle vorliegt, reduzieren die entsprechenden [Compress](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/)-Operationen die Dateigröße möglicherweise nicht.

**Werden Änderungen, die durch ForEach oder Compress vorgenommen wurden, automatisch gespeichert?**

Nein. Diese Hilfsklassen arbeiten auf dem geladenen [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)-Objekt im Speicher. Nachdem Sie Elemente in einem [ForEach](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/foreach/)-Callback oder nach dem Aufruf von [Compress](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/) geändert haben, rufen Sie [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Präsentation konvertieren](/androidjava/convert-presentation/)
- [Präsentationen zusammenführen](/androidjava/merge-presentation/)
- [Folienmaster](/androidjava/slide-master/)
- [Textfeld verwalten](/androidjava/manage-textbox/)
- [Eingebettete Schriftart](/androidjava/embedded-font/)