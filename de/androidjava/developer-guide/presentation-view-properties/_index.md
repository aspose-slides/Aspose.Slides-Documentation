---
title: Abrufen und Aktualisieren von Präsentationsansichtseigenschaften unter Android
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/androidjava/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungs-Icons
- vertikaler Trenner einrasten
- Einzelansicht
- Leistenstatus
- Dimensionsgröße
- Automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Android via Java Ansichtseigenschaften, um PPT-, PPTX- und ODP-Folienformate anzupassen - Layouts, Zoom-Stufen und Anzeigeeinstellungen zu ändern."
---

{{% alert color="primary" %}} 

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem Seiten‑Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist, in dem die Präsentation zuletzt gespeichert wurde.

Die Methode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Normalansichts‑Eigenschaften einer Präsentation zu ermöglichen.  

Die Schnittstellen [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties) und deren Ableitungen sowie das Aufzählungselement [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType) wurden hinzugefügt.

{{% /alert %}} 

## **Über INormalViewProperties**

Stellt die Eigenschaften der Normalansicht dar.

Die Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) und [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Icons anzeigen soll, wenn Gliederungs‑Inhalte in einem der Inhaltsbereiche der Normalansicht dargestellt werden.

Die Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geben an, ob der vertikale Trenner in einen minimierten Zustand wechseln soll, wenn der Seitenbereich ausreichend klein ist.

Die Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) und [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) legt fest, ob der Benutzer bevorzugt, einen einzelnen Inhaltsbereich im Vollfenster statt der Standard‑Normalansicht mit drei Inhaltsbereichen zu sehen. Ist sie aktiviert, kann die Anwendung einen der Inhaltsbereiche im gesamten Fenster anzeigen.

Die Methoden [getVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom unteren Inhaltsbereich, eine vertikale Trennleiste trennt die Folie vom Seiten‑Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Die Methoden [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) und [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für [getVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) der Wert [SplitterBarStateType.Restored](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) gilt.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).  

Die Methode [getDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft) an.

Die Methode [getAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) legt fest, ob die Größe des Seiten‑Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung skaliert wird.

Ein nachstehendes Beispiel zeigt, wie Sie auf die Eigenschaften [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) einer Präsentation zugreifen können.
```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Stellen Sie die Ansichtseigenschaften der Präsentation wieder her
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

Aspose.Slides für Android via Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen die Zoom‑Stufe bereits eingestellt ist. Dies kann geschehen, indem die [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) einer Präsentation gesetzt werden. Sowohl [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) als auch [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert gesetzt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) einer [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) in [Aspose.Slides](/slides/de/) festzulegen.

{{% /alert %}} 

Um die Ansichtseigenschaften festzulegen, gehen Sie bitte wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Setzen Sie die [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)-Datei.  
   Im nachstehenden Beispiel haben wir den Zoom‑Wert sowohl für die Folienansicht als auch für die Notizansicht festgelegt.
```java
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

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) werden auf Ebene der Präsentation definiert ([Normal View](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nicht je Abschnitt, sodass ein einziger Parametersatz beim Öffnen für das gesamte Dokument gilt.

**Kann ich vordefinierte Ansichtszustände für verschiedene Benutzer festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam genutzt. Viewer‑Anwendungen können Benutzer‑Präferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) auf Ebene der Präsentation gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erzeugen.