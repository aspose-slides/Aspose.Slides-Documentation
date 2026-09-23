---
title: Abrufen und Aktualisieren von Präsentations‑Ansichtseigenschaften in PHP
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/php-java/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- Vertikalen Trenner einrasten
- Einzelansicht
- Leistenstatus
- Abmessungsgröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für PHP via Java, um PPT‑, PPTX‑ und ODP‑Folien anzupassen — Layouts, Zoomstufen und Anzeigeeinstellungen zu ändern."
---
## **Einleitung**

Die normale Ansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem Seiten-Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, den Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht denselben Zustand hat wie beim letzten Speichern der Präsentation.

Methode [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) wurde hinzugefügt, um Zugriff auf die Normalansichts‑Eigenschaften einer Präsentation zu bieten. 

Klassen [NormalViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewRestoredProperties) und deren Ableitungen sowie das Aufzählungs‑Element [SplitterBarStateType](https://reference.aspose.com/slides/de/php-java/aspose.slides/SplitterBarStateType) wurden hinzugefügt.

## **Über INormalViewProperties**

Stellt Normalansichts‑Eigenschaften dar.

Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) und [setShowOutlineIcons](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) geben an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungs‑Inhalte in einem der Inhaltsbereiche des Normalansichts‑Modus dargestellt werden.

Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) geben an, ob der vertikale Trenner in einen minimierten Zustand „einrasten“ soll, wenn der Seitenbereich ausreichend klein ist.

Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) und [setPreferSingleView](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) geben an, ob der Benutzer es bevorzugt, einen einzelnen Inhaltsbereich über das gesamte Fenster anstelle der üblichen Normalansicht mit drei Inhaltsbereichen zu sehen. Ist diese Option aktiviert, kann die Anwendung einen der Inhaltsbereiche im gesamten Fenster anzeigen.

Methoden [getVerticalBarState](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) und [getHorizontalBarState](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) geben den Zustand an, in dem die horizontale bzw. vertikale Trennerleiste angezeigt werden soll. Eine horizontale Trennerleiste trennt die Folie vom unteren Inhaltsbereich, eine vertikale Trennerleiste trennt die Folie vom Seiten‑Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/de/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/de/php-java/aspose.slides/SplitterBarStateType/#Maximized) und [SplitterBarStateType::Restored](https://reference.aspose.com/slides/de/php-java/aspose.slides/SplitterBarStateType/#Restored).

Methoden [getRestoredLeft](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) und [getRestoredTop](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties#getRestoredTop) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für [getVerticalBarState](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) und [getHorizontalBarState](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) der Wert [SplitterBarStateType::Restored](https://reference.aspose.com/slides/de/php-java/aspose.slides/SplitterBarStateType/#Restored) verwendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) ist, Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) ist) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Methode [getDimensionSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) gibt die Größe des Folienbereichs an (Breite bei restoredTop, Höhe bei restoredLeft).

Methode [getAutoAdjust](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) gibt an, ob die Größe des Seiten‑Inhaltsbereichs die neue Größe kompensieren soll, wenn das Anwendungsfenster, das die Ansicht enthält, verändert wird.

Ein untenstehendes Beispiel zeigt, wie Sie auf die Eigenschaften [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) einer Präsentation zugreifen können.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Wiederherstellen der Ansichtseigenschaften der Präsentation
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Standard‑Zoomwert festlegen**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen die Ansicht bereits gezoomt ist. Dies kann durch Setzen der [ViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties) einer Präsentation erfolgen. [getSlideViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) sowie [getNotesViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) können programmatisch gesetzt werden. In diesem Thema sehen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties) einer [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation) in Aspose.Slides festgelegt werden.

{{% /alert %}} 

Um die Ansichtseigenschaften zu setzen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation).
2. Setzen Sie die [View Properties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation).
3. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei. Im nachstehenden Beispiel haben wir den Zoomwert sowohl für die Folienansicht als auch für die Notizansicht gesetzt.

```php
  $presentation = new Presentation();
  try {
    # Festlegen der Ansichtseigenschaften der Präsentation
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Zoomwert in Prozent für die Folienansicht
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Zoomwert in Prozent für die Notizansicht

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Rasterabstand festlegen**

Verwenden Sie [Presentation::getViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getViewProperties), um die anwendungsweiten Ansichtseinstellungen einer Präsentation abzurufen. Die Methoden [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/#getGridSpacing) und [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/#setGridSpacing) lesen bzw. ändern das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für einzelne Folien. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet eine vorhandene `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Viertel‑Zoll‑Intervall und speichert das Ergebnis.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Raster unterscheidet sich von den [drawing guides](/slides/de/php-java/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichenhilfen einzelne, horizontal oder vertikal positionierte Ausrichtungs‑Linien sind. Das Hinzufügen, Verschieben oder Entfernen von Zeichenhilfen ändert den Rasterabstand nicht.

Sowohl Raster als auch Zeichenhilfen sind Hilfsmittel zur Bearbeitung. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Diashow gerendert. Das Speichern des Rasterabstandes garantiert nicht, dass ein Editor das Raster anzeigt: seine Sichtbarkeit hängt ebenfalls von den Präferenzen des Viewers oder Editors ab.

## **Kommentare beim Öffnen einer Präsentation ein‑ oder ausblenden**

Verwenden Sie [Presentation::getViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getviewproperties/), um die anwendungsweiten Ansichtseinstellungen einer Präsentation abzurufen. Mit [ViewProperties::getShowComments](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/getshowcomments/) und [ViewProperties::setShowComments](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/setshowcomments/) können Sie die gespeicherte Präferenz auslesen bzw. ändern, ob Kommentare beim Öffnen der Präsentation in PowerPoint oder einem anderen kompatiblen Editor angezeigt werden sollen.

Diese Einstellung steuert nur die gespeicherte Ansichtsvoreinstellung. Sie fügt keine Kommentare hinzu, entfernt sie, bearbeitet sie oder löst sie auf. Das Ausblenden von Kommentaren bewahrt deren Inhalt, Autoren, Positionen, Antworten und Status. Siehe [Presentation Comments](/slides/de/php-java/presentation-comments/) für Vorgänge, die Kommentare selbst ändern.

Das folgende Beispiel erfordert eine vorhandene `comments.pptx`‑Datei mit Kommentaren. Es gibt die aktuelle Sichtbarkeitseinstellung aus, fordert das Ausblenden der Kommentare an und speichert ein neues PPTX, ohne Kommentare zu entfernen. Zusätzlich wird [ViewProperties::setLastView](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/setlastview/) zusammen mit [ViewType::SlideView](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewtype/#SlideView) verwendet, um die anfängliche Bearbeitungsansicht neben der Kommentar‑Sichtbarkeit zu konfigurieren.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Diese Einstellung bestimmt nicht, ob Kommentare in PDF-, HTML-, Bild-, Notiz‑ oder Handout‑Exporten enthalten sind. Konfigurieren Sie die jeweiligen export‑spezifischen Optionen separat.

## **FAQ**

**Warum ist das Raster nach erneutem Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Prüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Entfernen von Zeichenhilfen den Rasterabstand?**

Nein. Zeichenhilfen und Rasterabstand sind unabhängige Einstellungen. Das Entfernen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getviewproperties/) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/getslideviewproperties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz für das gesamte Dokument gilt, wenn es geöffnet wird.

**Kann ich vordefinierte Ansichtszustände für unterschiedliche Benutzer festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam genutzt. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getviewproperties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erzeugen.