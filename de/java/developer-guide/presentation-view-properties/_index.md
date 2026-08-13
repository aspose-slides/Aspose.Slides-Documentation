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
- vertikaler trenner einrasten
- einzelansicht
- balkenstatus
- dimensiongröße
- automatische anpassung
- standardzoom
- PowerPoint
- OpenDocument
- präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für Java, um PPT-, PPTX- und ODP-Folien anzupassen - Layouts, Zoomstufen und Anzeigeeinstellungen zu ändern."
---
## **Einleitung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die sich auf die Positionierung der verschiedenen Inhaltsbereiche beziehen. Diese Informationen ermöglichen es der Anwendung, den Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist wie beim letzten Speichern der Präsentation.

Die Methode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Normalansichtseigenschaften einer Präsentation zu ermöglichen.  

Die Schnittstellen [INormalViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewRestoredProperties) sowie deren Ableitungen und das Aufzählungstyp [SplitterBarStateType](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType) wurden hinzugefügt.

## **Über INormalViewProperties**

Stellt die Normalansichtseigenschaften dar.

Die Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) und [setShowOutlineIcons](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalte in einem der Inhaltsbereiche des Normalansichtsmodus dargestellt werden.

Die Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) legen fest, ob der vertikale Trenner in einen minimierten Zustand einrasten soll, wenn der seitliche Bereich ausreichend klein ist.

Die Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) und [setPreferSingleView](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) bestimmen, ob der Benutzer eine Vollfenster‑Einzel‑Inhaltsbereich‑Ansicht der Standard‑Normalansicht mit drei Inhaltsbereichen bevorzugt. Ist sie aktiviert, kann die Anwendung einen der Inhaltsbereiche im gesamten Fenster anzeigen.

Die Methoden [getVerticalBarState](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geben an, in welchem Zustand die horizontale bzw. vertikale Trennerleiste angezeigt werden soll. Eine horizontale Trennerleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennerleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType#Restored).

Die Methoden [getRestoredLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) und [getRestoredTop](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für [getVerticalBarState](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) der Wert [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/java/com.aspose.slides/SplitterBarStateType#Restored) angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Methode [getDimensionSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs (Breite, wenn Kind von restoredTop, Höhe, wenn Kind von restoredLeft) an.

Die Methode [getAutoAdjust](https://reference.aspose.com/slides/de/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des seitlichen Inhaltsbereichs automatisch angepasst werden soll, wenn das Fenster, das die Ansicht enthält, in der Anwendung geändert wird.

Ein Beispiel unten zeigt, wie Sie auf die Eigenschaften [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) einer Präsentation zugreifen können.

```java
import com.aspose.slides.*;

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

## **Standard-Zoomwert festlegen**

{{% alert color="info" %}} 

Aspose.Slides für Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann erreicht werden, indem die [ViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties) einer Präsentation gesetzt werden. [getSlideViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) sowie [getNotesViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert festgelegt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties) einer [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation) in Aspose.Slides festgelegt werden.

{{% /alert %}} 

Um die Ansichtseigenschaften festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
1. Setzen Sie die [View Properties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.  
   Im nachstehenden Beispiel haben wir den Zoomwert sowohl für die Folienansicht als auch für die Notizansicht festgelegt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Festlegen der Ansichtseigenschaften der Präsentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwert in Prozent für die Folienansicht
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwert in Prozent für die Notizansicht 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?

Ansichtseinstellungen werden auf Präsentationsebene definiert (Normalansicht/Folienansicht) und nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen auf das gesamte Dokument angewendet wird.

### Kann ich unterschiedliche Ansichts‑Zustände für verschiedene Benutzer vordefinieren?

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam genutzt. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält einen einzigen Satz von Ansichtseigenschaften.

### Kann ich eine Vorlage mit vordefinierten Ansichtseigenschaften erstellen, sodass neue Präsentationen gleich geöffnet werden?

Ja. Da Ansichtseigenschaften auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erstellen.