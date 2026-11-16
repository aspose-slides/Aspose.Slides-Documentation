---
title: Abrufen und Aktualisieren von Präsentationsansichtseigenschaften in PHP
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/php-java/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- Vertikalen Trenner einrasten lassen
- Einzelansicht
- Leistenstatus
- Abmessungsgröße
- Automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für PHP via Java, um das Layout der Normalansicht, den Zoom von Folien und Notizen, den Rasterabstand und die Sichtbarkeit von Kommentaren in PowerPoint-Präsentationen zu konfigurieren."
---
## **Einleitung**

In der normalen Ansicht von PowerPoint wird die Folie zwischen einem Seitenbereich für Miniaturansichten oder einer Gliederung und einem Notizenbereich unten angezeigt. Aspose.Slides für PHP via Java stellt die gespeicherten Bearbeitungspräferenzen der Präsentation über [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) zur Verfügung. Dazu gehören das Layout der Bereiche, Zoom‑Stufen, Rasterabstand und die Sichtbarkeit von Kommentaren.

## **Über NormalViewProperties**

Verwenden Sie [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/), um auf die Klasse [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/) zuzugreifen. [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) steuert, ob Symbole neben den Folientiteln in der Gliederungsansicht angezeigt werden. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) lässt den Seitenbereich in den minimierten Zustand „einrasten“, wenn der Benutzer ihn verkleinert. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) gibt eine Präferenz an, ein Feld im Vollfenster anzuzeigen.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) steuert den Trenner zwischen dem Seitenbereich und der Folie. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) steuert den Trenner über dem Notizenbereich. Beide akzeptieren einen [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/)-Wert von `Minimized`, `Maximized` oder `Restored`.

## **Über das Wiederherstellen von NormalViewProperties**

Wenn ein Trenner wiederhergestellt wird, liefert [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) die gespeicherte Größe des Seitenbereichs und [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) die gespeicherte Größe des oberen Folienbereichs. Beide geben [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/) frei. Die Methode [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) akzeptiert einen Prozentsatz von 0 bis 100, und [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) steuert, ob der Editor die Größe beim Ändern der Fenstergröße anpasst.

Dieses Beispiel aktualisiert eine vorhandene Präsentation. Es stellt den horizontalen Trenner wieder her, setzt die von [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) zurückgegebene Größe auf 80 % mit aktivierter automatischer Anpassung und maximiert den vertikalen Trenner. Außerdem wird [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) aufgerufen, um Symbole in der Gliederungsansicht anzuzeigen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Standard‑Zoomwert festlegen**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) und [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) speichern unabhängige Zoom‑Einstellungen für den Editor. Diese Einstellungen beeinflussen weder die Folienabmessungen, die Wiedergabe von Bildschirmen, noch die Auflösung beim Export von Bildern.

Dieses Beispiel öffnet eine vorhandene Präsentation und ruft [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) auf, um die Folie an das Bearbeitungsfenster anzupassen. Für die Notizseite deaktiviert es die automatische Skalierung und ruft [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) auf, um einen festen Zoom von 80 % festzulegen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Rasterabstand festlegen**

Die Methode `setGridSpacing` von [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) legt den Abstand zwischen den Bearbeitungsrastern in der gesamten Präsentation fest. Sie akzeptiert einen positiven Wert in Punkten, wobei 72 Punkte einem Zoll entsprechen. Dieses Beispiel gibt den aktuellen Abstand in einer vorhandenen Präsentation aus und speichert ein Raster von einem Viertel Zoll, indem es das Intervall auf 18 Punkte setzt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Raster wiederholt sich in einem festen Intervall. [Drawing guides](/slides/de/php-java/drawing-guides/) markieren einzelne horizontale oder vertikale Positionen. Beide dienen als Bearbeitungshilfen und erscheinen nur in Editoren, die sie anzeigen. Bildschirminterpretationen sowie Exporte nach PDF, Bildern oder SVG lassen sie weg.

## **Kommentare beim Öffnen einer Präsentation ein‑ oder ausblenden**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) speichert eine Präferenz, die kompatible Editoren beim Öffnen der Präsentation verwenden. Für eine vorhandene Präsentation mit Kommentaren gibt dieses Beispiel die aktuelle Einstellung aus und speichert eine Kopie mit ausgeblendeten Kommentaren. Außerdem wird [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) mit [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) aufgerufen, damit die Kopie in der Folienansicht geöffnet wird.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ausblenden von Kommentaren bewahrt deren Text, Autoren, Positionen, Antworten und Status. Um die Kommentare selbst zu ändern, siehe [Presentation Comments](/slides/de/php-java/presentation-comments/). Exporteinstellungen bestimmen, ob Kommentare in PDF, HTML, Bildern, Notizen oder Handzetteln erscheinen.

## **FAQ**

**Warum ist das Raster ausgeblendet, wenn ich die Präsentation erneut öffne?**

Die Präsentation speichert das Rasterintervall. Um das Raster zu sehen, aktivieren Sie die Rasteranzeige im Editor.

**Ändert das Entfernen von Zeichenhilfen den Rasterabstand?**

Nein. Das Hinzufügen, Verschieben oder Entfernen einer Hilfslinie lässt das Rasterintervall unverändert.

**Können verschiedene Abschnitte einer Präsentation unterschiedliche Ansichtseinstellungen haben?**

Nein. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) gilt für die gesamte Präsentation.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Benutzer speichern?**

Die Datei speichert einen Satz von Ansichtseigenschaften für alle. Ein Editor kann zudem die lokalen Präferenzen eines Benutzers anwenden.

**Kann ich Ansichtseinstellungen in einer Vorlage speichern?**

Ja. Aus einer Vorlage erstellte Präsentationen übernehmen deren gespeicherte Ansichtseinstellungen.