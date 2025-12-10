---
title: Abrufen und Aktualisieren von Präsentationsansichtseigenschaften in Java
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/java/presentation-view-properties/
keywords:
- ansichtseigenschaften
- normalansicht
- gliederungsinhalt
- gliederungssymbole
- vertikaler splitter einrasten
- einzelansicht
- balkenzustand
- dimensionsgröße
- automatische anpassung
- standardzoom
- PowerPoint
- OpenDocument
- präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für Java, um PPT-, PPTX- und ODP-Folien anzupassen - Layouts, Zoomstufen und Anzeigeeinstellungen zu ändern."
---

{{% alert color="primary" %}} 

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht denselben Zustand hat wie beim letzten Speichern der Präsentation.

Methode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Normalansichts‑Eigenschaften der Präsentation zu ermöglichen. 

[INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties) Schnittstellen und ihre Nachfolger, [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType) Enum wurden hinzugefügt.

{{% /alert %}} 

## **Über INormalViewProperties**

Stellt Normalansichts‑Eigenschaften dar.

Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) und [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Symbole anzeigen soll, wenn Outline‑Inhalte in einem der Inhaltsbereiche des Normalansichts‑Modus angezeigt werden.

Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geben an, ob der vertikale Trenner in einen minimierten Zustand springen soll, wenn der Seitenbereich ausreichend klein ist.

Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) und [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) gibt an, ob der Benutzer ein einzelnes Voll‑Fenster‑Inhaltsbereich bevorzugt statt der Standard‑Normalansicht mit drei Inhaltsbereichen. Ist dies aktiviert, kann die Anwendung einen der Inhaltsbereiche im gesamten Fenster anzeigen.

Methoden [getVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom Inhaltsbereich unter der Folie, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored).

Methoden [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) und [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für [getVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) der Wert [SplitterBarStateType.Restored](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored) verwendet wird.

## **Über das Wiederherstellen von INormalViewProperties** 

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert). 

Methode [getDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Methode [getAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe kompensieren soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung verkleinert oder vergrößert wird.

Ein Beispiel wird unten gezeigt, wie Sie auf [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) Eigenschaften einer Präsentation zugreifen können.
```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Wiederherstellen der Ansichtseigenschaften der Präsentation
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Standard‑Zoomwert festlegen**

{{% alert color="primary" %}} 

Aspose.Slides for Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch das Festlegen der [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) einer Präsentation erfolgen. [getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) sowie [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert gesetzt werden. In diesem Thema sehen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) einer [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) in [Aspose.Slides](/slides/de/) gesetzt werden.

{{% /alert %}} 

Um die Ansichtseigenschaften zu setzen, folgen Sie bitte den untenstehenden Schritten:

1. Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) erstellen.
1. [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) festlegen.
1. Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei schreiben.
   Im nachstehenden Beispiel haben wir den Zoom‑Wert für die Folienansicht sowie die Notizansicht gesetzt.
```java
Presentation presentation = new Presentation();
try {
    // Die Ansichtseigenschaften der Präsentation festlegen
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwert in Prozent für die Folienansicht
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwert in Prozent für die Notizenansicht 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Kann ich verschiedene Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) werden auf Ebene der Präsentation definiert ([Normal View](https://reference.aspose.com/slides/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen des Dokuments für das gesamte Dokument gilt.

**Kann ich verschiedene Ansichts‑Zustände für verschiedene Benutzer vordefinieren?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind für alle Benutzer gleich. Viewer‑Anwendungen können Benutzer‑Präferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View‑Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) auf Ebene der Präsentation gespeichert werden, können Sie sie in einer Vorlage einbetten und neue Dokumente daraus erstellen, die dieselbe anfängliche Ansichtskonfiguration besitzen.