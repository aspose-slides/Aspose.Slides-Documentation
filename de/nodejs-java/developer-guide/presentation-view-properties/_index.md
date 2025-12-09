---
title: Ansichtseigenschaften der Präsentation
type: docs
weight: 80
url: /de/nodejs-java/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- vertikaler Trenner einrasten
- Einzelansicht
- Leistenstatus
- Dimensiongröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- Präsentation
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: "Verwalten Sie Ansichtseigenschaften von PowerPoint-Präsentationen in JavaScript"
---

{{% alert color="primary" %}} 

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die sich auf die Positionierung der verschiedenen Inhaltsbereiche beziehen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist, wie als die Präsentation zuletzt gespeichert wurde.

Die Methode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Normalansichts‑Eigenschaften einer Präsentation zu ermöglichen.  

Die Klassen [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties) und ihre Ableitungen sowie das [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType)‑Enum wurden hinzugefügt.

{{% /alert %}} 

## **Über NormalViewProperties**

Repräsentiert die Normalansichts‑Eigenschaften.

Die Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) und [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalte in einem der Inhaltsbereiche des Normalansichts‑Modus dargestellt werden.

Die Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) geben an, ob der vertikale Trenner in einen minimierten Zustand springen soll, wenn der Seitenbereich ausreichend klein ist.

Die Eigenschaft [getPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) und [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) gibt an, ob der Benutzer es vorzieht, einen einzelnen Inhaltsbereich im Vollfenster anstelle der Standard‑Normalansicht mit drei Inhaltsbereichen zu sehen. Wenn aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster darzustellen.

Die Methoden [getVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) legen den Zustand fest, in dem die horizontale bzw. vertikale Trennerleiste angezeigt werden soll. Eine horizontale Trennerleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennerleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Die Methoden [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) und [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für [getVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) und [getHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) der Wert [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored) angewendet wird.

## **Über das Wiederherstellen von NormalViewProperties** 

Gibt die Größe des Folienbereichs (Breite, wenn es ein Kind von [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) ist, Höhe, wenn es ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) ist) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).  

Die Methode [getDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite, wenn Kind von restoredTop, Höhe, wenn Kind von restoredLeft).  

Die Methode [getAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des seitlichen Inhaltsbereichs sich an die neue Größe anpassen soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung geändert wird.  

Das nachstehende Beispiel zeigt, wie Sie auf die Eigenschaften [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) einer Präsentation zugreifen können.
```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Wiederherstellen der Ansichtseigenschaften der Präsentation
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Standard‑Zoomwert festlegen**

{{% alert color="primary" %}} 

Aspose.Slides für Node.js über Java unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits gesetzt ist. Dies kann erfolgen, indem die [ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) einer Präsentation gesetzt wird. [getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) sowie [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert gesetzt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) einer [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) in [Aspose.Slides](/slides/de/) gesetzt werden.

{{% /alert %}} 

Um die Ansichts‑Eigenschaften festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)‑Klasse.  
1. Setzen Sie die [View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).  
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.  
   Im nachstehenden Beispiel haben wir den Zoom‑Wert für die Folienansicht sowie die Notizansicht gesetzt.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Festlegen der Ansichtseigenschaften der Präsentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwert in Prozent für die Folienansicht
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwert in Prozent für die Notizansicht
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getviewproperties/) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz für das gesamte Dokument gilt, wenn es geöffnet wird.

**Kann ich für verschiedene Benutzer unterschiedliche Ansichts‑Zustände vordefinieren?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam. Viewer‑Anwendungen können Benutzereinstellungen berücksichtigen, aber die Datei selbst enthält nur einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View Properties vorbereiten, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getviewproperties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erstellen.