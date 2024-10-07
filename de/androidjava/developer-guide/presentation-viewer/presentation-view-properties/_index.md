---
title: Eigenschaften der Präsentationsansicht
type: docs
url: /androidjava/presentation-view-properties/
---

{{% alert color="primary" %}} 

Die normale Ansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die sich auf die Positionierung der verschiedenen Inhaltsbereiche beziehen. Diese Informationen ermöglichen der Anwendung, ihren Ansichtsstatus in der Datei zu speichern, sodass beim Wiederöffnen die Ansicht im selben Zustand ist wie beim letzten Speichern der Präsentation.

Die Methode [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die normalen Ansichtseigenschaften der Präsentation zu ermöglichen. 

Die Schnittstellen [**INormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties) und ihre Nachfahren, das Enum [**SplitterBarStateType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType), wurden hinzugefügt.

{{% /alert %}} 


## **Über INormalViewProperties** #
Repräsentiert die normalen Ansichtseigenschaften.

Die Methoden [**getShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) und [**setShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Symbole anzeigen soll, wenn sie Gliederungsinhalte in einem der Inhaltsbereiche des normalen Ansichtsmodus anzeigt.

Die Methoden [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) und [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geben an, ob der vertikale Splitter sich in einen minimierten Zustand einfügen soll, wenn der seitliche Bereich ausreichend klein ist.

Die Eigenschaft [**getPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) und [**setPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) gibt an, ob der Benutzer es bevorzugt, ein Vollfenster mit einem einzigen Inhaltsbereich anstelle der standardmäßigen normalen Ansicht mit drei Inhaltsbereichen zu sehen. Bei Aktivierung kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Methoden [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) geben den Zustand an, in dem die horizontale oder vertikale Splitterleiste angezeigt werden soll. Eine horizontale Splitterleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Splitterleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) und [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Die Methoden [**getRestoredLeft**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) und [**getRestoredTop**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) geben die Größe des oberen oder seitlichen Folienbereichs der normalen Ansicht an, wenn der Wert [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) für [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) und [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) entsprechend angewendet wird.


## **Über die Wiederherstellung von INormalViewProperties** 
Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) der normalen Ansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert). 

Die Methode [**getDimensionSize**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Die Methode [**getAutoAdjust**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe beim Ändern der Größe des Fensters, das die Ansicht innerhalb der Anwendung enthält, ausgleichen soll.

Ein Beispiel ist unten gegeben, das zeigt, wie Sie auf die [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) Eigenschaften für eine Präsentation zugreifen können.

```java
// Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
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
{{% alert color="primary" %}} 

Aspose.Slides für Android über Java unterstützt nun das Festlegen des Standard-Zoomwerts für Präsentationen, sodass beim Öffnen der Präsentation der Zoom bereits festgelegt ist. Dies kann durch Festlegen der [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) einer Präsentation erreicht werden. [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) sowie [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert festgelegt werden. In diesem Thema werden wir mit einem Beispiel sehen, wie man die [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) in [Aspose.Slides](/slides/) festlegt.

{{% /alert %}} 

Um die Ansichtseigenschaften festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Stellen Sie die [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) ein.
1. Schreiben Sie die Präsentation als [PPTX ](https://docs.fileformat.com/presentation/pptx/) Datei.
   Im folgenden Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizenansicht festgelegt.

```java
// Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation();
try {
    // Festlegen der Ansichtseigenschaften der Präsentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwert in Prozent für die Folienansicht
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwert in Prozent für die Notizenansicht 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```