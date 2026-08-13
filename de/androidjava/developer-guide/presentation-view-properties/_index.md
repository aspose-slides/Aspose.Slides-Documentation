---
title: Abrufen und Aktualisieren von Präsentations‑Ansichtseigenschaften unter Android
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/androidjava/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- vertikaler Trenner einrasten
- Einzelansicht
- Leistenstatus
- Dimensionsgröße
- automatische Anpassung
- Standard‑Zoom
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Android via Java Ansichtseigenschaften, um PPT-, PPTX- und ODP‑Folienformate anzupassen – Layouts, Zoom‑Stufen und Anzeigeeinstellungen zu ändern."
---
## **Einleitung**

Die normale Ansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, den Ansichtsstatus in der Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im selben Zustand ist, wie sie beim letzten Speichern der Präsentation war.

Die Methode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Normalansicht‑Eigenschaften einer Präsentation zu ermöglichen.

Die Schnittstellen [INormalViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewRestoredProperties) und ihre Ableitungen sowie das Aufzählungselement [SplitterBarStateType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType) wurden hinzugefügt.

## **Über INormalViewProperties**

Stellt die Normalansicht‑Eigenschaften dar.

Die Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) und [setShowOutlineIcons](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) legen fest, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalte in einem der Inhaltsbereiche des Normalansichts‑Modus dargestellt werden.

Die Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) bestimmen, ob der vertikale Trenner in den minimierten Zustand einrasten soll, wenn der seitliche Bereich ausreichend klein ist.

Die Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) und [setPreferSingleView](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) legt fest, ob der Benutzer lieber einen Vollfenster‑Einzelinhaltsbereich statt der standardmäßigen Normalansicht mit drei Inhaltsbereichen sehen möchte. Ist sie aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Methoden [getVerticalBarState](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom darunter liegenden Inhaltsbereich, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Die Methoden [getRestoredLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) und [getRestoredTop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) bestimmen die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht, wenn für [getVerticalBarState](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) der Wert [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SplitterBarStateType#Restored) angelegt ist.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn er ein Kind von [getRestoredTop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), Höhe, wenn er ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Methode [getDimensionSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite, wenn er ein Kind von restoredTop ist, Höhe, wenn er ein Kind von restoredLeft ist).

Die Methode [getAutoAdjust](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des seitlichen Inhaltsbereichs sich an die neue Größe anpassen soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung geändert wird.

Im Folgenden wird ein Beispiel gezeigt, wie Sie auf die Eigenschaften von [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) einer Präsentation zugreifen können.

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

## **Standard‑Zoomwert festlegen**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits gesetzt ist. Dies kann erreicht werden, indem die [ViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties) einer Präsentation gesetzt wird. Sowohl [getSlideViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) als auch [getNotesViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert gesetzt werden. In diesem Thema sehen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties) von [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) in [Aspose.Slides](/slides/de/) festgelegt werden.

{{% /alert %}} 

Um die Ansichts‑Eigenschaften festzulegen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation).
1. Setzen Sie die [View Properties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ViewProperties) von [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation).
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.
   Im nachstehenden Beispiel haben wir den Zoom‑Wert sowohl für die Folienansicht als auch für die Notizansicht festgelegt.

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

### Kann ich verschiedene Ansichtseinstellungen für unterschiedliche Abschnitte einer Präsentation festlegen?

Die [View settings](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getViewProperties--) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen des gesamten Dokuments gilt.

### Kann ich verschiedene Ansichts‑Zustände für verschiedene Benutzer vordefinieren?

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam genutzt. Anzeige‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz von Ansichtseigenschaften.

### Kann ich eine Vorlage mit vordefinierten View Properties erstellen, sodass neue Präsentationen gleichermaßen geöffnet werden?

Ja. Da die [view properties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getViewProperties--) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erstellen.