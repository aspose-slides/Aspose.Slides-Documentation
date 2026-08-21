---
title: Low-Code-Präsentationsoperationen in PHP
linktitle: Low-Code-API
type: docs
weight: 50
url: /de/php-java/low-code-presentation-operations/
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
- PHP
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API in PHP, um Präsentationen zu konvertieren und zusammenzuführen, Inhalte zu iterieren, Formen zu sammeln und die Präsentationsgröße zu reduzieren."
---
## **Übersicht**

Der [aspose.slides](https://reference.aspose.com/slides/de/php-java/aspose.slides/) Namespace stellt statische Hilfsklassen für gängige Präsentationsvorgänge bereit. Diese Helfer kapseln häufig verwendete Objektmodell‑Workflows in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Präsentationselemente verarbeiten, Formen sammeln und ungenutzten Inhalt mit weniger Code entfernen können.

Low‑Code‑Helfer sind am nützlichsten, wenn der Vorgang auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Workflow Ihren Anforderungen entspricht. Verwenden Sie das vollständige [Aspose.Slides object model](https://reference.aspose.com/slides/de/php-java/aspose.slides/), wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Formen, Export‑Einstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Helfer zusammen:

| Helfer | Wofür verwenden |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/php-java/aspose.slides/convert/) | Konvertieren einer Präsentation in ein anderes Format mit einem direkten Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/php-java/aspose.slides/merger/) | Kombinieren kompletter Präsentationsdateien desselben Formats. |
| [ForEach_](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/) | Ausführen eines Rückrufs für jede Folie, Form, jeden Absatz oder Textabschnitt. |
| [Collect](https://reference.aspose.com/slides/de/php-java/aspose.slides/collect/) | Abrufen von Formen aus der gesamten Präsentation für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/de/php-java/aspose.slides/compress/) | Entfernen ungenutzter Master und Layouts sowie Reduzieren eingebetteter Schriftartdaten. |

## **Konvertieren einer Präsentation**

Verwenden Sie [Convert::autoByExtension](https://reference.aspose.com/slides/de/php-java/aspose.slides/convert/#autoByExtension), wenn die Dateierweiterung des Ausgabedatei ausreicht, um das Exportformat auszuwählen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

Die [Convert](https://reference.aspose.com/slides/de/php-java/aspose.slides/convert/) Klasse bietet zudem dedizierte Methoden für PDF-, SVG-, JPEG-, PNG‑ und TIFF‑Ausgabe. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export prüfen oder ändern müssen oder eine Exportoption konfigurieren wollen, die vom ausgewählten Helfer nicht bereitgestellt wird. Siehe [Convert Presentation](/php-java/convert-presentation/) für formatbezogene Workflows und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger::process](https://reference.aspose.com/slides/de/php-java/aspose.slides/merger/#process), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabepräsentationen müssen dasselbe Dateiformat haben.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Der Helfer ist geeignet, wenn alle Folien zu einem Ergebnis zusammengefügt werden sollen, ohne sie einzeln auszuwählen oder neu zuzuordnen. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder -Layout anwenden, Abschnitte explizit erhalten oder unterschiedliche Foliengrößen vereinheitlichen müssen. Siehe [Merge Presentations](/php-java/merge-presentation/) für diese Szenarien.

## **Durch Präsentationselemente iterieren**

Die [ForEach_](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/) Klasse ruft für jeden angeforderten Typ von Präsentationselement einen Rückruf auf. Sie vermeidet verschachtelte Sammlungsschleifen und ist praktisch für eine Präsentations‑weite Inspektion oder Formatierungsänderungen.

Das folgende Beispiel verwendet [ForEach_::slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/#paragraph) und [ForEach_::portion](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/#portion), um die entsprechenden Elemente zu inspizieren:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Standardmäßig umfasst die Präsentations‑weite Form‑ und Textdurchlauf normale, Master‑ und Layout‑Folien. Überladungen mit einem `includeNotes`‑Parameter können zudem Notiz‑Folien verarbeiten. Verwenden Sie direkte Sammlungsschleifen, wenn die Durchlauf‑Reihenfolge, ein vorzeitiger Abbruch, Filterung vor dem Aufruf des Rückrufs oder eine detaillierte Eltern‑Kinder‑Steuerung wichtig ist.

## **Formen sammeln**

Verwenden Sie [Collect::shapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/collect/#shapes), wenn Sie eine Sammlung aller Formen in einer Präsentation benötigen, anstatt für jede Form einen Rückruf zu erhalten. Dies ist nützlich, wenn dieselbe Menge mehrmals gefiltert, gezählt oder verarbeitet werden soll.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Verwenden Sie stattdessen [ForEach_::shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/#shape), wenn jede Form sofort verarbeitet werden kann und Sie das gesammelte Ergebnis nicht behalten müssen.

## **Präsentationsinhalt komprimieren**

Die [Compress](https://reference.aspose.com/slides/de/php-java/aspose.slides/compress/) Klasse kann ungenutzte Strukturelemente entfernen und eingebettete Schriftartdaten reduzieren:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) entfernt Layout‑Folien, auf die keine normale Folie verweist.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/compress/#removeUnusedMasterSlides) entfernt Master‑Folien, die nicht mehr verwendet werden.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/compress/#compressEmbeddedFonts) entfernt ungenutzte Zeichen aus eingebetteten Schriftarten.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Entfernen Sie ungenutzte Layouts vor ungenutzten Mastern, damit ein Master, der nach der Layout‑Bereinigung nicht mehr referenziert wird, ebenfalls entfernt werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, falls Sie später die ursprünglichen Master, Layouts oder die vollständigen eingebetteten Schriftartdaten benötigen. Weitere Details siehe [Slide Master](/php-java/slide-master/) und [Embedded Font](/php-java/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API anstelle des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Helfer, wenn ein Standardvorgang auf eine komplette Datei oder Präsentation angewendet wird und keine detaillierte Kontrolle über einzelne Elemente erforderlich ist. Verwenden Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Beziehungen zwischen Master und Layout steuern, Zwischenzustände prüfen oder ein Verhalten konfigurieren müssen, das der Helfer nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger::process](https://reference.aspose.com/slides/de/php-java/aspose.slides/merger/#process) erfordert Eingabepräsentationen im selben Format. Konvertieren Sie die Eingabedateien zunächst in ein gemeinsames Format, beispielsweise mit [Convert::autoByExtension](https://reference.aspose.com/slides/de/php-java/aspose.slides/convert/#autoByExtension), und führen Sie anschließend die konvertierten Dateien zusammen.

**Verarbeitet ForEach_ Master‑, Layout‑ und Notizfolien?**

[ForEach_::slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/#slide) iteriert über normale Präsentationsfolien. Präsentationsweite [ForEach_::shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/#paragraph) und [ForEach_::portion](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/#portion) Vorgänge schließen standardmäßig normale, Master‑ und Layout‑Folien ein. Verwenden Sie deren Überladungen mit `includeNotes` auf `true`, um Notiz‑Folien einzubeziehen.

**Was ist der Unterschied zwischen ForEach_::shape und Collect::shapes?**

Verwenden Sie [ForEach_::shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/#shape), um jede Form sofort über einen Rückruf zu verarbeiten. Verwenden Sie [Collect::shapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/collect/#shapes), wenn Sie ein iterierbares Ergebnis benötigen, das behalten, gefiltert, gezählt oder mehrfach durchlaufen werden kann.

**Reduziert Compress immer die Dateigröße der Präsentation?**

Nicht unbedingt. Das Ergebnis hängt davon ab, ob die Präsentation ungenutzte Layouts, ungenutzte Master oder eingebettete Schriftarten mit ungenutzten Zeichen enthält. Sind keine dieser Elemente vorhanden, können die entsprechenden [Compress](https://reference.aspose.com/slides/de/php-java/aspose.slides/compress/) Vorgänge die Dateigröße möglicherweise nicht verringern.

**Werden Änderungen, die von ForEach_ oder Compress vorgenommen wurden, automatisch gespeichert?**

Nein. Diese Helfer arbeiten auf dem geladenen [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Objekt im Speicher. Nachdem Sie Elemente in einem [ForEach_](https://reference.aspose.com/slides/de/php-java/aspose.slides/foreach_/)‑Rückruf geändert oder [Compress](https://reference.aspose.com/slides/de/php-java/aspose.slides/compress/) ausgeführt haben, rufen Sie [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Präsentation konvertieren](/php-java/convert-presentation/)
- [Präsentationen zusammenführen](/php-java/merge-presentation/)
- [Folienmaster](/php-java/slide-master/)
- [Textfeld verwalten](/php-java/manage-textbox/)
- [Eingebettete Schriftart](/php-java/embedded-font/)