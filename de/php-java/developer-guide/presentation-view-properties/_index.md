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
- Gliederungsicons
- Vertikalen Trenner einrasten
- Einzelansicht
- Leistenstatus
- Dimensionsgröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für PHP über Java Ansichtseigenschaften, um PPT-, PPTX- und ODP‑Folienformate anzupassen – Layouts, Zoomstufen und Anzeigeeinstellungen zu verändern."
---

{{% alert color="primary" %}} 

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, den Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist wie beim letzten Speichern der Präsentation.

Methode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) wurde hinzugefügt, um Zugriff auf die Normalansichts‑Eigenschaften einer Präsentation zu ermöglichen.

Die Klassen [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties) und deren Ableitungen sowie das Aufzählungselement [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType) wurden hinzugefügt.

{{% /alert %}} 

## **Über INormalViewProperties**

Representiert Normalansichts‑Eigenschaften.

Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) und [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) geben an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungs‑Inhalt in einem der Inhaltsbereiche des Normalansichtsmodus angezeigt wird.

Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) geben an, ob der vertikale Teiler in einen minimierten Zustand einrasten soll, wenn der Seitenbereich ausreichend klein ist.

Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) und [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) geben an, ob der Benutzer eine Vollfenster‑Einzel‑Inhaltsregion gegenüber der Standard‑Normalansicht mit drei Inhaltsbereichen bevorzugt. Ist sie aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Methoden [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) und [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Maximized) und [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored).

Methoden [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) und [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties#getRestoredTop) geben die Größe des oberen oder seitlichen Folienbereichs der Normalansicht an, wenn der Wert [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored) für [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) und [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) entsprechend angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Methode [getDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Methode [getAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, in der Anwendung geändert wird.

Ein Beispiel unten zeigt, wie Sie auf die Eigenschaften [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) einer Präsentation zugreifen können.
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


## **Standard-Zoomwert festlegen**
{{% alert color="primary" %}} 

Aspose.Slides für PHP über Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits gesetzt ist. Dies kann erreicht werden, indem die [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) einer Präsentation gesetzt werden. [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) sowie [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) können programmgesteuert gesetzt werden. In diesem Thema sehen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) einer [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) in [Aspose.Slides](/slides/de/) gesetzt werden.

{{% /alert %}} 

Um die Ansichtseigenschaften zu setzen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Setzen Sie die [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.  
   Im unten gezeigten Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizansicht gesetzt.
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


## **FAQ**

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz für das gesamte Dokument gilt, wenn es geöffnet wird.

**Kann ich vordefinierte Ansichtszustände für verschiedene Benutzer festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam genutzt. Anzeige‑Anwendungen können Benutzereinstellungen berücksichtigen, aber die Datei selbst enthält nur einen Satz Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten Ansichtseigenschaften erstellen, damit neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und neue Dokumente daraus erzeugen, die dieselbe anfängliche Ansichtskonfiguration besitzen.