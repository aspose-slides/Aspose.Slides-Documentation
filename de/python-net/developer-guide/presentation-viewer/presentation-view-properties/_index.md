---
title: Eigenschaften der Normalansicht
type: docs
url: /de/python-net/presentation-view-properties/
keywords: "PowerPoint-Viewer, Viewer-Eigenschaften, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Eigenschaften des PowerPoint-Präsentationsviewers in Python"
---

{{% alert color="primary" %}} 

Die normale Ansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die sich auf die Positionierung der verschiedenen Inhaltsbereiche beziehen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in der Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist wie beim letzten Speichern der Präsentation.

Die Eigenschaft [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) wurde hinzugefügt, um Zugriff auf die Eigenschaften der Normalansicht der Präsentation zu gewähren.

Die Schnittstellen [**INormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/) und ihre Abkömmlinge sowie die Enum [**SplitterBarStateType**](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) wurden hinzugefügt.

{{% /alert %}} 



## **Über INormalViewProperties** 

Stellt die Eigenschaften der Normalansicht dar.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen sollte, wenn sie Gliederungsinhalte in einem der Inhaltsbereiche des Normalansichtsmodus anzeigt.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Splitter in einen minimierten Zustand einrasten sollte, wenn der Seitenbereich ausreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer es bevorzugt, einen Vollfenster-Einzelinhaltsbereich anstelle der standardmäßigen Normalansicht mit drei Inhaltsbereichen zu sehen. Wenn aktiviert, kann die Anwendung entscheiden, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben an, in welchem Zustand die horizontale oder vertikale Splitterleiste angezeigt werden soll. Eine horizontale Splitterleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Splitterleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored.**

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größenanpassung des oberen oder seitlichen Folienbereichs der Normalansicht an, wenn der Wert **SplitterBarStateType.Restored** für **VerticalBarState** und **HorizontalBarState** entsprechend angewendet wird.



## **Über INormalViewRestoredProperties** 

Gibt die Größenanpassung des Folienbereichs ((Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe berücksichtigen sollte, wenn das Fenster, das die Ansicht innerhalb der Anwendung enthält, in der Größe geändert wird.

Ein Beispiel, das zeigt, wie Sie auf die Eigenschaften **ViewProperties.NormalViewProperties** für eine Präsentation zugreifen können, wird unten gegeben.

```py
import aspose.slides as slides

#Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```




## **Standard-Zoomwert festlegen**
Aspose.Slides für Python über .NET unterstützt jetzt das Festlegen des Standard-Zoomwerts für die Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch das Festlegen der [**view_properties**](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) einer Präsentation erfolgen. Die Eigenschaften der Folienansicht sowie die [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) können programmgesteuert festgelegt werden. In diesem Thema werden wir anhand eines Beispiels sehen, wie man die Ansichtseigenschaften der Präsentation in Aspose.Slides festlegt.

Um die Ansichtseigenschaften festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse
1. Stellen Sie die Ansicht [Properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) der Präsentation ein
1. Schreiben Sie die Präsentation als PPTX-Datei

Im folgenden Beispiel haben wir den Zoomwert sowohl für die Folienansicht als auch für die Notizenansicht festgelegt.

```py
import aspose.slides as slides

# Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Festlegen der Ansichtseigenschaften der Präsentation
    presentation.view_properties.slide_view_properties.scale = 100 # Zoomwert in Prozent für die Folienansicht
    presentation.view_properties.notes_view_properties.scale = 100 # Zoomwert in Prozent für die Notizenansicht 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Ansichtseigenschaften festlegen**
Um die Ansichtseigenschaften festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
1. Stellen Sie die Ansichtseigenschaften der Präsentation ein.
1. Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir den Zoomwert sowohl für die Folienansicht als auch für die Notizenansicht festgelegt.

```py
import aspose.slides as slides

# Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Festlegen der Ansichtseigenschaften der Präsentation
    presentation.view_properties.slide_view_properties.scale = 100 # Zoomwert in Prozent für die Folienansicht
    presentation.view_properties.notes_view_properties.scale = 100 # Zoomwert in Prozent für die Notizenansicht 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```