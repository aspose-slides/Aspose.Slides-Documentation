---
title: Präsentationsansicht Eigenschaften
type: docs
url: /java/presentation-view-properties/
---

{{% alert color="primary" %}} 

Die normale Ansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem Seiteninhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die sich auf die Positionierung der verschiedenen Inhaltsbereiche beziehen. Diese Information ermöglicht es der Anwendung, ihren Ansichtsstatus in der Datei zu speichern, sodass beim Wiederöffnen die Ansicht in demselben Zustand ist wie bei der letzten Speicherung der Präsentation.

Die Methode [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die Eigenschaften der normalen Ansicht der Präsentation zu gewähren. 

[**INormalViewProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties) Schnittstellen und deren Nachkommen, [**SplitterBarStateType**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType) Enum wurden hinzugefügt.

{{% /alert %}} 


## **Über INormalViewProperties** #
Stellt Eigenschaften der normalen Ansicht dar.

Die Methoden [**getShowOutlineIcons**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) und [**setShowOutlineIcons**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Icons anzeigen soll, wenn sie Gliederungsinhalte in einem der Inhaltsbereiche des normalen Ansichtsmodus anzeigt.

Die Methoden [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) und [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geben an, ob der vertikale Splitter in einen minimierten Zustand schnappen soll, wenn der Seitenbereich ausreichend klein ist.

Die Eigenschaft [**getPreferSingleView**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) und [**setPreferSingleView**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) gibt an, ob der Benutzer es vorzieht, einen Vollbild-Inhaltsbereich anstelle der standardmäßigen normalen Ansicht mit drei Inhaltsbereichen zu sehen. Wenn aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Methoden [**getVerticalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [**getHorizontalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geben den Zustand an, in dem die horizontale oder vertikale Splitterleiste angezeigt werden soll. Eine horizontale Splitterleiste trennt die Folie vom Inhaltsbereich unter der Folie, eine vertikale Splitterleiste trennt die Folie vom Seiteninhaltsbereich. Mögliche Werte sind: [**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Minimized), [**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Maximized) und [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored).

Die Methoden [**getRestoredLeft**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) und [**getRestoredTop**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) geben die Größe des oberen oder seitlichen Folienbereichs der normalen Ansicht an, wenn der Wert [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored) für [**getVerticalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [**getHorizontalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) entsprechend angewendet wird.


## **Über die Wiederherstellung von INormalViewProperties** 
Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) der normalen Ansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert). 

Die Methode [**getDimensionSize**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Die Methode [**getAutoAdjust**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des Seiteninhaltsbereichs für die neue Größe beim Ändern der Größe des Fensters, das die Ansicht innerhalb der Anwendung enthält, kompensiert werden soll.

Ein Beispiel wird weiter unten gezeigt, wie Sie auf die [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) Eigenschaften für eine Präsentation zugreifen können.

```java
// Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Stellen Sie die Ansichtsparameter der Präsentation wieder her
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Standard-Zoom-Wert festlegen**
{{% alert color="primary" %}} 

Aspose.Slides für Java unterstützt jetzt das Festlegen des Standard-Zoomwerts für Präsentationen, sodass beim Öffnen der Präsentation bereits der Zoom eingestellt ist. Dies kann erfolgen, indem die [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) einer Präsentation festgelegt werden. [getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) sowie [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert eingestellt werden. In diesem Thema werden wir an einem Beispiel sehen, wie man die [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) in [Aspose.Slides](/slides/) festlegt.

{{% /alert %}} 

Um die Ansichtsparameter festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. Legen Sie die [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) fest.
1. Schreiben Sie die Präsentation als [PPTX ](https://docs.fileformat.com/presentation/pptx/)Datei.
   Im unten gegebenen Beispiel haben wir den Zoomwert sowohl für die Folienansicht als auch für die Notizenansicht festgelegt.

```java
// Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation();
try {
    // Einstellungen für die Ansichtsparameter der Präsentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwert in Prozent für die Folienansicht
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwert in Prozent für die Notizenansicht 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```