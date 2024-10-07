---
title: Eigenschaften der Präsentationsansicht
type: docs
url: /php-java/presentation-view-properties/
---

{{% alert color="primary" %}} 

Die normale Ansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die sich auf die Positionierung der verschiedenen Inhaltsbereiche beziehen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in der Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist wie beim letzten Speichern der Präsentation.

Die Methode [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/php-java/aspose.slides/IViewProperties#getNormalViewProperties--) wurde hinzugefügt, um Zugriff auf die normalen Ansichtseigenschaften der Präsentation zu gewähren. 

Die Schnittstellen [**INormalViewProperties**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties) und deren Nachfolger, sowie das Enum [**SplitterBarStateType**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType) wurden hinzugefügt.

{{% /alert %}} 

## **Über INormalViewProperties** #
Repräsentiert die normalen Ansichtseigenschaften.

Die Methoden [**getShowOutlineIcons**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getShowOutlineIcons--) und [**setShowOutlineIcons**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) geben an, ob die Anwendung Icons anzeigen soll, wenn zusammenfassende Inhalte in einem der Inhaltsbereiche des normalen Ansichtsmodus angezeigt werden.

Die Methoden [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) und [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) geben an, ob der vertikale Splitter auf einen minimierten Zustand einrasten soll, wenn der seitliche Bereich ausreichend klein ist.

Die Eigenschaften [**getPreferSingleView**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getPreferSingleView--) und [**setPreferSingleView**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) geben an, ob der Benutzer es vorzieht, einen Vollbild-Einzelinhaltbereich anstelle der standardmäßigen normalen Ansicht mit drei Inhaltsbereichen zu sehen. Wenn aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Methoden [**getVerticalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) und [**getHorizontalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) geben den Zustand an, in dem die horizontale oder vertikale Splitterleiste angezeigt werden soll. Eine horizontale Splitterleiste trennt die Folie von dem Inhaltsbereich unterhalb der Folie, die vertikale Splitterleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [**SplitterBarStateType::Minimized**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Minimized), [**SplitterBarStateType::Maximized**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Maximized) und [**SplitterBarStateType::Restored**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored).

Die Methoden [**getRestoredLeft**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--) und [**getRestoredTop**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--) geben die Größen für den oberen oder seitlichen Folienbereich der normalen Ansicht an, wenn der Wert [**SplitterBarStateType::Restored**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored) für [**getVerticalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) und [**getHorizontalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties** 
Gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--)) in der normalen Ansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert). 

Die Methode [**getDimensionSize**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getDimensionSize--) gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Die Methode [**getAutoAdjust**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) gibt an, ob die Größe des seitlichen Inhaltsbereichs kompensiert werden soll, wenn die Größe angepasst wird, während das Fenster, das die Ansicht innerhalb der Anwendung enthält, verkleinert wird.

Ein Beispiel wird unten gegeben, das zeigt, wie Sie auf die Eigenschaften [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNormalViewProperties--) für eine Präsentation zugreifen können.

```php
  # Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
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

Aspose.Slides für PHP via Java unterstützt jetzt das Festlegen des Standard-Zoomwerts für die Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch das Festlegen der [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) einer Präsentation geschehen. [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getSlideViewProperties--) sowie [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNotesViewProperties--) können programmgesteuert festgelegt werden. In diesem Thema werden wir mit einem Beispiel sehen, wie man die [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) in [Aspose.Slides](/slides/) festlegt.

{{% /alert %}} 

Um die Ansichtseigenschaften festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Legen Sie die [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) fest.
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.
   Im folgenden Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizenansicht festgelegt.

```php
  # Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
  $presentation = new Presentation();
  try {
    # Festlegen der Ansichtseigenschaften der Präsentation
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100);// Zoomwert in Prozent für die Folienansicht

    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100);// Zoomwert in Prozent für die Notizenansicht

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```