---
title: Ändern der Notizseitengröße und -orientierung in PHP
linktitle: Notizseitengröße
type: docs
weight: 10
url: /de/php-java/notes-size/
keywords:
- Notizseitengröße
- Notizorientierung
- Querformat-Notizen
- Hochformat-Notizen
- Handout-Größe
- PowerPoint
- Präsentation
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Lesen und ändern Sie die Notizseitengrößen in Aspose.Slides für PHP via Java, wechseln Sie die Orientierung, überprüfen Sie die gespeicherten Größen und exportieren Sie Notizen oder Handouts zu PDF und Bildern."
---
## **Übersicht**

Verwenden Sie [Presentation::getNotesSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getnotessize/), um auf die Einstellungen der Notizseiten der Präsentation zuzugreifen. Die Methode gibt ein [NotesSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/notessize/)-Objekt zurück, dessen [setSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/notessize/setsize/)-Methode die Seitenabmessungen festlegt. Obwohl das Einstellungsobjekt selbst nicht ersetzt werden kann, können Sie über diese Methode neue Abmessungen zuweisen.

Breite und Höhe werden in **Punkten** angegeben, wobei 72 Punkte einem Zoll entsprechen. Zum Beispiel entsprechen 900 × 600 Punkte 12,5 × 8 ⅓ Zoll. Diese Einstellungen gelten für die gesamte Präsentation und nicht für die Notizen einer einzelnen Folie.

| Einstellung | Zweck |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getnotessize/) | Steuert die Abmessungen der Notizseite und die Seitenabmessungen, die beim Handout‑Export verwendet werden. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getslidesize/) | Steuert die regulären Folienabmessungen der Präsentation über [SlideSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesize/). |

Das Ändern einer Einstellung ändert die andere nicht automatisch. Das Ändern der Orientierung der Notizseite dreht die regulären Folien ebenfalls nicht. Siehe [Slide Size](/slides/de/php-java/slide-size/), um reguläre Folien zu skalieren.

Die nachfolgenden Beispiele verwenden eine vorhandene `sample.pptx`. Für die Export‑Beispiele benötigen Sie eine Präsentation mit mindestens einer Folie, die Sprecher‑Notizen enthält. Jedes Beispiel kann unabhängig voneinander ausgeführt werden, nachdem die PHP/Java‑Bridge und der Aspose.Slides‑PHP‑Wrapper geladen wurden. Numerische Werte, die von Java zurückgegeben werden, werden vor dem Vergleich oder der Berechnung mit `java_values` in PHP‑Werte konvertiert.

## **Lesen der Notizseitengröße und -orientierung**

Lesen Sie Breite und Höhe und vergleichen Sie sie, um die Orientierung zu bestimmen: Eine breitere Seite ist querformatig, eine höhere Seite ist hochformatig, und gleiche Abmessungen beschreiben eine quadratische Seite. Dieses Beispiel gibt die tatsächlichen Abmessungen in Punkten aus, ohne eine Standard‑Papiergröße anzunehmen.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Wechsel zu Querformat ohne Änderung der Papiergröße**

Um nur die Orientierung zu ändern, vertauschen Sie die vorhandene Breite und Höhe. Dadurch bleiben die Längen beider Seiten erhalten, einschließlich einer benutzerdefinierten Papiergröße. Die Bedingung unten verhindert, dass bereits im Querformat befindliche Seiten wieder in Hochformat gewechselt werden, und lässt eine quadratische Seite unverändert.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Für Hochformat verwenden Sie dieselbe Zuweisung, wenn `java_values($size->getWidth()) > java_values($size->getHeight())`. Ersetzen Sie nicht A4‑ oder Letter‑Abmessungen, es sei denn, Sie möchten auch die Papiergröße ändern.

## **Benutzerdefinierte Notizseitengröße festlegen und überprüfen**

Weisen Sie beide Abmessungen zusammen zu und verwenden Sie dann [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/save/), um die Präsentation zu speichern. Dieses Beispiel legt eine 900 × 600‑Punkte‑Querformat‑Seite fest, speichert sie als PPTX und öffnet die gespeicherte Datei erneut, um die persistierten Werte zu prüfen. Der Vergleich erlaubt eine Toleranz von 0,01 Punkten für Fließkommawerte; er garantiert keine Präzision für jedes Dateiformat.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Das erwartete Ergebnis ist `900 x 600 points` und `Size preserved: true`. Das Prüfen einer neu geöffneten Präsentation verifiziert die gespeicherte Datei und nicht nur die In‑Memory‑Einstellungen.

## **Export von Notizen und Handouts**

Die Seitenabmessungen definieren den verfügbaren Bereich für Notizen‑ oder Handout‑Layouts. Sie aktivieren diese Layouts nicht von selbst: Konfigurieren Sie auch die Export‑Optionen. Der reguläre Folien‑Export verwendet weiterhin die Folienabmessungen.

### **Export von Notizen nach PDF und PNG**

Weisen Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/notescommentslayoutingoptions/) zu [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions), um Notizen in das PDF aufzunehmen. Dieses Beispiel rendert außerdem die erste Folie mit Notizen nach PNG mit [Slide::getImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getImage) und [RenderingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/renderingoptions/).

Der Modus [BottomTruncated](https://reference.aspose.com/slides/de/php-java/aspose.slides/notespositions/) hält die Notizen auf einer Seite; Notizen, die nicht passen, werden abgeschnitten. Das PDF verwendet 900 × 600‑Punkte‑Seiten. Bei dem unten verwendeten Bildmaßstab von 1 × 1 beträgt das PNG 900 × 600 Pixel. Punkte beschreiben die Seitengeometrie; Pixel beschreiben die Rasterausgabe, deren Abmessungen ebenfalls vom Render‑Skalierungsfaktor abhängen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Für den PDF‑Export mit langen Notizen erlaubt [BottomFull](https://reference.aspose.com/slides/de/php-java/aspose.slides/notespositions/) zusätzliche Seiten nach Bedarf. Verwenden Sie diesen Modus nicht mit dem oben gezeigten Einzel‑Folie‑Bildaufruf, da dieser ihn nicht unterstützt. Nach einer Größenänderung prüfen Sie die Ausgabe auf abgeschnittene Notizen und die Platzierung vorhandener notes‑master‑Objekte; das bloße Ändern der Seitenabmessungen sollte nicht als Garantie dafür angesehen werden, dass sämtlicher Inhalt passt. Siehe [Convert PowerPoint to PDF with Notes](/slides/de/php-java/convert-powerpoint-to-pdf-with-notes/) für weitere Informationen zum Notizen‑Export.

### **Export von Handouts nach PDF**

Verwenden Sie [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/handoutlayoutingoptions/) für mehrere Folien‑Miniaturansichten auf einer Seite. Das folgende Beispiel legt eine 900 × 600‑Punkte‑Seite fest und nutzt [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/de/php-java/aspose.slides/handouttype/), um bis zu vier Folien pro Seite anzuordnen. Das horizontale Preset steuert die Folienreihenfolge; die Seitenorientierung ergibt sich aus Breite und Höhe.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Das Ändern der Seitengröße ändert den für das Handout‑Raster verfügbaren Bereich, ohne die Abmessungen der Quellfolien zu verändern. Für Handout‑Bilder verwenden Sie [Presentation::getImages](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getimages/) mit dem Handout‑Layout, nicht die Bild‑Methode einer einzelnen Folie. In Aspose.Slides nutzt die handout‑bezogene Darstellung auf Präsentationsebene die Notizseitengrößen, während der Bildaufruf einer einzelnen Folie nicht die Handout‑Seite erzeugt. Siehe [Handout Mode](/slides/de/php-java/convert-powerpoint-in-handout-mode/) für Layout‑Optionen.

## **Seitengröße in Viewer‑Anwendungen, Export und Druck**

Bewahren Sie die gespeicherte Präsentationsgröße, die exportierte Seitengröße und die gedruckte Papiergröße getrennt:

- **Viewer‑Anwendungen:** Ein Viewer kann Notizen mit eigenen Layout‑Regeln anzeigen oder drucken. Wenn eine andere Anwendung die Datei speichert, öffnen Sie sie erneut und prüfen Sie die Abmessungen; die Formatkonvertierung dieser Anwendung kann sie normalisieren.
- **Export‑Formate:** Die obigen PDF‑Beispiele für Notizen und Handouts verwenden die konfigurierten Seitengrößen. Rasterbilder verwenden ganzzahlige Pixel‑Abmessungen und einen Render‑Skalierungsfaktor, sodass Bruchteil‑Punkt‑Werte im Bildausgabebild gerundet werden können. Der Export regulärer Folien berücksichtigt nicht die Notizseitengröße.
- **Druckertreiber:** Papierauswahl, automatische Drehung und Fit‑to‑Page‑Einstellungen können das physische Ergebnis ändern, ohne die in der Präsentation oder im PDF gespeicherten Abmessungen zu verändern. Für eine bestimmte Papiergröße stimmen Sie die Druckereinstellungen ab und prüfen Sie die Druckvorschau.

## **FAQ**

**Kann ich die Notizgröße nur für eine Folie festlegen?**

Die Notizseitengröße ist eine Einstellung auf Präsentationsebene. Einzelne Folien können unterschiedliche Notizinhalte haben, aber diese Eigenschaft stellt keine separate Seitengröße für jede Folie bereit.

**Warum hat das Ändern der Notizorientierung meine Folien nicht beeinflusst?**

Notizseiten und reguläre Folien besitzen unabhängige Abmessungen. Verwenden Sie die regulären Foliengrößeneinstellungen, wenn Sie die Folien selbst skalieren möchten.

**Warum hat mein gespeichertes oder gedrucktes Ergebnis eine andere Größe?**

Öffnen Sie zunächst die gespeicherte Präsentation erneut und vergleichen Sie deren Notizabmessungen. Wenn sie sich geändert haben, prüfen Sie, ob das Speichern oder Konvertieren der Datei in einer anderen Anwendung die Seiteneinstellungen geändert hat. Wenn nicht, prüfen Sie das Export‑Layout, den Bild‑Skalierungsfaktor, die Viewer‑Einstellungen und die Drucker‑Papierauswahl.