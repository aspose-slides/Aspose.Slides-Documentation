---
title: Eigenschaften der Präsentationsansicht
type: docs
url: /de/net/presentation-view-properties/
keywords: "PowerPoint-Viewer, Viewer-Eigenschaften, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Eigenschaften des PowerPoint-Präsentations-Viewers in C# oder .NET"
---

{{% alert color="primary" %}} 

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die sich auf die Positionierung der verschiedenen Inhaltsbereiche beziehen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in der Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist wie beim letzten Speichern der Präsentation.

Die Eigenschaft [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) wurde hinzugefügt, um auf die Eigenschaften der Normalansicht der Präsentation zuzugreifen.

[**INormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties)-Schnittstellen und deren Nachkommen, das [**SplitterBarStateType**](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) Enum wurden hinzugefügt.

{{% /alert %}} 



## **Über INormalViewProperties** #

Stellt die Eigenschaften der Normalansicht dar.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn in einem der Inhaltsbereiche des Normalansichtsmodus Gliederungsinhalte dargestellt werden.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Splitter in einen minimierten Zustand einrasten soll, wenn der Seitenbereich ausreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer es vorzieht, einen Vollfenster-Inhaltsbereich anstelle der standardmäßigen Normalansicht mit drei Inhaltsbereichen anzuzeigen. Wenn aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster darzustellen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale oder vertikale Splitterleiste angezeigt werden soll. Eine horizontale Splitterleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, die vertikale Splitterleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored.**

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe des oberen oder seitlichen Folienbereichs der Normalansicht an, wenn der Wert **SplitterBarStateType.Restored** für **VerticalBarState** und **HorizontalBarState** entsprechend angewendet wird.



## **Über INormalViewRestoredProperties** #

Gibt die Größe des Folienbereichs ((Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe bei der Größenänderung des Fensters, das die Ansicht innerhalb der Anwendung enthält, kompensieren soll.

Ein Beispiel, wie man auf die Eigenschaften **ViewProperties.NormalViewProperties** für eine Präsentation zugreifen kann, wird im Folgenden gegeben.

```c#
//Instanziieren eines Präsentationsobjekts, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```




## **Standardzoomwert festlegen**
Aspose.Slides für .NET unterstützt jetzt die Festlegung des Standardzoomwerts für die Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann erreicht werden, indem die [**ViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) einer Präsentation gesetzt werden. Folienansichtseigenschaften sowie [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) können programmgesteuert festgelegt werden. In diesem Thema werden wir ein Beispiel sehen, wie die Ansichtseigenschaften der Präsentation in Aspose.Slides festgelegt werden.

Um die Ansichtseigenschaften festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) -Klasse
1. Setzen Sie die Ansichtseigenschaften der Präsentation
1. Speichern Sie die Präsentation als PPTX-Datei

Im folgenden Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizenansicht festgelegt.

```c#
//Instanziieren eines Präsentationsobjekts, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("demo.pptx"))
{
    //Festlegen der Ansichtseigenschaften der Präsentation

    presentation.ViewProperties.SlideViewProperties.Scale = 100; //Zoomwert in Prozent für die Folienansicht
    presentation.ViewProperties.NotesViewProperties.Scale = 100; //Zoomwert in Prozent für die Notizenansicht 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```



## **Ansichtseigenschaften festlegen**
Um die Ansichtseigenschaften festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
1. Setzen Sie die Ansichtseigenschaften der Präsentation.
1. Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizenansicht festgelegt.

```c#
//Instanziieren eines Präsentationsobjekts, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("demo.pptx"))
{
    //Festlegen der Ansichtseigenschaften der Präsentation

    presentation.ViewProperties.SlideViewProperties.Scale = 100; //Zoomwert in Prozent für die Folienansicht
    presentation.ViewProperties.NotesViewProperties.Scale = 100; //Zoomwert in Prozent für die Notizenansicht 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```