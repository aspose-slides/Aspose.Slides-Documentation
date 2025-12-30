---
title: Abrufen und Aktualisieren von Präsentations-Ansichtseigenschaften in PHP
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
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für PHP via Java, um PPT-, PPTX- und ODP-Folienformate anzupassen – Layouts, Zoomstufen und Anzeigeeinstellungen zu verändern."
---

{{% alert color="primary" %}} 

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht denselben Zustand wie beim letzten Speichern der Präsentation hat.

Methode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Normalansichtseigenschaften einer Präsentation zu ermöglichen.  

[INormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties) Schnittstellen und deren Nachfolger sowie das [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType) Enum wurden hinzugefügt.

{{% /alert %}} 

## **Über INormalViewProperties**

Stellt Normalansicht‑Eigenschaften dar.

Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getShowOutlineIcons--) und [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Symbole anzeigen soll, wenn Outline‑Inhalte in einem der Inhaltsbereiche des Normalansichtsmodus dargestellt werden.

Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geben an, ob der vertikale Trenner in einen minimierten Zustand springen soll, wenn der Seitenbereich ausreichend klein ist.

Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getPreferSingleView--) und [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) gibt an, ob der Benutzer es bevorzugt, einen einzigen Inhaltsbereich über das gesamte Fenster zu sehen, anstatt der normalen Ansicht mit drei Inhaltsbereichen. Ist diese Option aktiviert, kann die Anwendung einen der Inhaltsbereiche im gesamten Fenster darstellen.

Methoden [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) geben an, in welchem Zustand die horizontale bzw. vertikale Trennerleiste angezeigt werden soll. Eine horizontale Trennerleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennerleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Maximized) und [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored).

Methoden [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--) und [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) der Wert [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored) verwendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--)) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe (weder minimiert noch maximiert) hat.  

Methode [getDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite bei restoredTop, Höhe bei restoredLeft).  

Methode [getAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht in der Anwendung enthält, neu skaliert wird.  

Ein unten stehendes Beispiel zeigt, wie Sie auf die Eigenschaften [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNormalViewProperties--) einer Präsentation zugreifen können.  
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


## **Standard‑Zoom‑Wert festlegen**
{{% alert color="primary" %}} 

Aspose.Slides für PHP via Java unterstützt jetzt das Festlegen des Standard‑Zoom‑Werts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann über die [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) einer Präsentation geschehen. [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getSlideViewProperties--) sowie [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert gesetzt werden. In diesem Thema sehen wir anhand eines Beispiels, wie die [View‑Eigenschaften](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) einer [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) in [Aspose.Slides](/slides/de/) gesetzt werden.

{{% /alert %}} 

Um die Ansichtseigenschaften festzulegen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
1. Setzen Sie die [View‑Eigenschaften](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.  
   Im unten stehenden Beispiel haben wir den Zoom‑Wert sowohl für die Folienansicht als auch für die Notizansicht festgelegt.  
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

[Ansichtseinstellungen](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen des Dokuments für das gesamte Dokument gilt.

**Kann ich vordefinierte Ansichtszustände für verschiedene Benutzer festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam genutzt. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View‑Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [View‑Properties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erstellen.