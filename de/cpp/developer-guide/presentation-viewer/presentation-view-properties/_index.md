---
title: Eigenschaften der Präsentationsansicht
type: docs
url: /cpp/presentation-view-properties/
---

{{% alert color="primary" %}} 

Die normale Ansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem Seiteninhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die sich auf die Positionierung der verschiedenen Inhaltsbereiche beziehen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in der Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist wie zuletzt beim Speichern der Präsentation.

Die Methode [**IViewProperties::get_NormalViewProperties()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06) wurde hinzugefügt, um den Zugriff auf die Eigenschaften der Normalansicht der Präsentation zu ermöglichen.

[**INormalViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties), [**INormalViewRestoredProperties** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties) Schnittstellen und deren Nachkommen, [**SplitterBarStateType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950) Enum wurden hinzugefügt.

{{% /alert %}} 



## **Über INormalViewProperties** #

Stellt die Eigenschaften der Normalansicht dar.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn sie umreißende Inhalte in einem der Inhaltsbereiche des normalen Ansichtsmodus anzeigt.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Splitter in einen minimierten Zustand „snappen“ soll, wenn der Seitenbereich ausreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer es vorzieht, einen Vollbild-Inhaltsbereich anstelle der Standardnormalansicht mit drei Inhaltsbereichen anzuzeigen. Wenn aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem der horizontale oder vertikale Splitterbalken angezeigt werden soll. Ein horizontaler Splitterbalken trennt die Folie vom Inhaltsbereich unter der Folie, der vertikale Splitterbalken trennt die Folie vom Seiteninhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored.**

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe des oberen oder seitlichen Folienbereichs der Normalansicht an, wenn der Wert **SplitterBarStateType.Restored** für **VerticalBarState** und **HorizontalBarState** entsprechend angewendet wird.



## **Über INormalViewRestoredProperties** #

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe des Seiteninhaltsbereichs die neue Größe beim Ändern der Größe des Fensters, das die Ansicht innerhalb der Anwendung enthält, kompensieren sollte.

Ein Beispiel wird unten angegeben, das zeigt, wie Sie auf die Eigenschaften **ViewProperties.NormalViewProperties** für eine Präsentation zugreifen können.

``` cpp
//Eine Präsentationsobjekt instanziieren, das eine Präsentationsdatei darstellt
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **Standard-Zoomwert festlegen**
Aspose.Slides für C++ unterstützt jetzt die Festlegung des Standard-Zoomwerts für Präsentationen, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann erreicht werden, indem die [**ViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) einer Präsentation festgelegt werden. Die Eigenschaften der Folienansicht sowie [get_NotesViewProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) können programmgesteuert festgelegt werden. In diesem Thema werden wir anhand eines Beispiels sehen, wie die Ansichtseigenschaften der Präsentation in Aspose.Slides festgelegt werden.

Um die Ansichtseigenschaften festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse
1. Legen Sie die Ansicht [Properties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) der Präsentation fest
1. Schreiben Sie die Präsentation als PPTX-Datei

Im nachstehenden Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizenansicht festgelegt.

``` cpp
// Eine Präsentationsobjekt instanziieren, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
// Ansichtseigenschaften der Präsentation festlegen

presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// Zoomwert in Prozent für die Folienansicht
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);
// Zoomwert in Prozent für die Notizenansicht 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```



## **Sichtbarkeitseigenschaften festlegen**
Um die Ansichtseigenschaften festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
1. Legen Sie die Sichtbarkeitseigenschaften der Präsentation fest.
1. Schreiben Sie die Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizenansicht festgelegt.

``` cpp
// Eine Präsentationsobjekt instanziieren, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Einstellung der Sichtbarkeitseigenschaften der Präsentation
// Zoomwert in Prozent für die Folienansicht
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// Zoomwert in Prozent für die Notizenansicht
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```