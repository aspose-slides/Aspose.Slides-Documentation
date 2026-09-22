---
title: "Abrufen und Aktualisieren von Präsentations‑Ansichtseigenschaften in PHP"
linktitle: "Ansichtseigenschaften"
type: docs
weight: 80
url: /de/php-java/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungs‑Symbole
- Vertikalen Trennbalken einrasten
- Einzelansicht
- Balkenstatus
- Dimensiongröße
- Automatische Anpassung
- Standard‑Zoom
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für PHP via Java, um PPT-, PPTX- und ODP‑Folien anzupassen — Layouts, Zoom‑Stufen und Anzeigeeinstellungen ändern."
---
## **Einleitung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, den Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im selben Zustand ist wie beim letzten Speichern der Präsentation.

Die Methode [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) wurde hinzugefügt, um Zugriff auf die Normalansichts‑Eigenschaften einer Präsentation zu bieten. 

Klassen [NormalViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewRestoredProperties) sowie deren Nachfolger und das Aufzählungs‑Enum [SplitterBarStateType](https://reference.aspose.com/slides/de/php-java/aspose.slides/SplitterBarStateType) wurden ergänzt.

## **Über INormalViewProperties**

Stellt Normalansichts‑Eigenschaften dar.

Die Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) und [setShowOutlineIcons](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) geben an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungs‑Inhalt in einem der Inhaltsbereiche der Normalansicht dargestellt wird.

Die Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) geben an, ob der vertikale Trennbalken in einen minimierten Zustand \"schnappen\" soll, wenn der seitliche Bereich ausreichend klein ist.

Die Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) und [setPreferSingleView](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) gibt an, ob der Benutzer es bevorzugt, einen einzigen Inhaltsbereich über das gesamte Fenster zu sehen, anstatt der normalen Ansicht mit drei Inhaltsbereichen. Ist sie aktiviert, kann die Anwendung einen der Inhaltsbereiche über das gesamte Fenster darstellen.

Die Methoden [getVerticalBarState](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) und [getHorizontalBarState](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) geben den Zustand an, in dem der horizontale bzw. vertikale Trennbalken angezeigt werden soll. Ein horizontaler Trennbalken trennt die Folie vom darunter liegenden Inhaltsbereich, ein vertikaler Trennbalken trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/de/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/de/php-java/aspose.slides/SplitterBarStateType/#Maximized) und [SplitterBarStateType::Restored](https://reference.aspose.com/slides/de/php-java/aspose.slides/SplitterBarStateType/#Restored).

Die Methoden [getRestoredLeft](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) und [getRestoredTop](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties#getRestoredTop) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für [getVerticalBarState](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) und [getHorizontalBarState](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) der Wert [SplitterBarStateType::Restored](https://reference.aspose.com/slides/de/php-java/aspose.slides/SplitterBarStateType/#Restored) verwendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert). 

Die Methode [getDimensionSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) gibt die Größe des Folienbereichs an (Breite bei restoredTop, Höhe bei restoredLeft).

Die Methode [getAutoAdjust](https://reference.aspose.com/slides/de/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, in der Anwendung geändert wird.

Ein unten stehendes Beispiel zeigt, wie Sie auf die [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties/#getNormalViewProperties)‑Eigenschaften einer Präsentation zugreifen können.

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

Aspose.Slides for PHP via Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch Setzen der [ViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties) einer Präsentation erfolgen. [getSlideViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) sowie [getNotesViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) können programmgesteuert gesetzt werden. In diesem Abschnitt zeigen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties) von [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation) in Aspose.Slides festgelegt werden.

{{% /alert %}} 

Um die Ansichtseigenschaften zu setzen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation)‑Klasse.
1. Setzen Sie die [View Properties](https://reference.aspose.com/slides/de/php-java/aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation).
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei. Im unten stehenden Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizansicht festgelegt.

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

Verwenden Sie [Presentation::getViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getViewProperties), um auf die präsentationsweiten Ansichtseinstellungen zuzugreifen. Die Methoden [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/#getGridSpacing) und [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/#setGridSpacing) lesen bzw. ändern das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für einzelne Folien. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet ein vorhandenes `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Viertel‑Zoll‑Intervall und speichert das Ergebnis.

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

Das Raster unterscheidet sich von [drawing guides](/slides/de/php-java/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichnungshilfen einzeln positionierte horizontale oder vertikale Ausrichtungslinien sind. Das Hinzufügen, Verschieben oder Löschen von Zeichnungshilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichnungshilfen sind Bearbeitungshilfen. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Vorführung gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: Seine Sichtbarkeit hängt ebenfalls von den Einstellungen des Viewers oder Editors ab.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Prüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Löschen von Zeichnungshilfen den Rasterabstand?**

Nein. Zeichnungshilfen und Rasterabstand sind unabhängige Einstellungen. Das Entfernen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getviewproperties/) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/getslideviewproperties/)) und gelten für das gesamte Dokument beim Öffnen.

**Kann ich vordefinierte Ansichtszustände für verschiedene Benutzer festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind für alle Benutzer gemeinsam. Viewer‑Anwendungen können Benutzereinstellungen berücksichtigen, aber die Datei selbst enthält nur einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getviewproperties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben Anfangsansicht erzeugen.