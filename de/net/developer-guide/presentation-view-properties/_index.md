---
title: Präsentationsansichtseigenschaften
type: docs
weight: 80
url: /de/net/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normale Ansicht
- Gliederungsinhalt
- Gliederungssymbole
- vertikalen Trenner einrasten
- Einzelansicht
- Leistenstatus
- Dimensiongröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Verwalten Sie Ansichtseigenschaften von PowerPoint-Präsentationen in C# oder .NET"
---

{{% alert color="primary" %}} 

Die Normalansicht besteht aus drei Inhaltsregionen: der Folie selbst, einer Seiteninhaltsregion und einer unteren Inhaltsregion. Eigenschaften, die sich auf die Positionierung der verschiedenen Inhaltsregionen beziehen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in der Datei zu speichern, sodass beim erneuten Öffnen die Ansicht denselben Zustand hat wie beim letzten Speichern der Präsentation.

Die Eigenschaft [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) wurde hinzugefügt, um Zugriff auf die Normalansichtseigenschaften der Präsentation zu ermöglichen.

Die Schnittstellen [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties) und [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) sowie deren Nachfolger und das Aufzählungstyp [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) wurden hinzugefügt.

{{% /alert %}}

## **Über INormalViewProperties**

Stellt Normalansichtseigenschaften dar.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalte in einer der Inhaltsregionen des Normalansichtsmodus angezeigt werden.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Trenner in einen minimierten Zustand springen soll, wenn die Seitenregion ausreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer es bevorzugt, eine einbettungsregion im Vollfenster gegenüber der Standard‑Normalansicht mit drei Inhaltsregionen zu sehen. Wenn aktiviert, kann die Anwendung wählen, eine der Inhaltsregionen im gesamten Fenster anzuzeigen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale bzw. vertikale Trennerleiste angezeigt werden soll. Eine horizontale Trennerleiste trennt die Folie von der Inhaltsregion unterhalb der Folie, eine vertikale Trennerleiste trennt die Folie von der Seiteninhaltsregion. Mögliche Werte sind: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored**.

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe der oberen bzw. seitlichen Folienregion der Normalansicht an, wenn der Wert **SplitterBarStateType.Restored** für **VerticalBarState** bzw. **HorizontalBarState** angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe der Folienregion (Breite wenn ein Kind von RestoredTop, Höhe wenn ein Kind von RestoredLeft) der Normalansicht an, wenn die Region eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Eigenschaft **DimensionSize** gibt die Größe der Folienregion an (Breite wenn ein Kind von RestoredTop, Höhe wenn ein Kind von RestoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe der Seiteninhaltsregion die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, in der Anwendung neu dimensioniert wird.

Ein Beispiel wird unten gezeigt, wie Sie auf die Eigenschaften **ViewProperties.NormalViewProperties** einer Präsentation zugreifen können.

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Wiederherstellen der Ansichtseigenschaften der Präsentation
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```


## **Standard‑Zoomwert festlegen**

Aspose.Slides für .NET unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch das Setzen der [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) einer Präsentation erfolgen. Folienansichtseigenschaften sowie [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) können programmgesteuert festgelegt werden. In diesem Thema sehen wir anhand eines Beispiels, wie die View Properties einer Präsentation in Aspose.Slides festgelegt werden.

Um die Ansichtseigenschaften festzulegen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. Setzen Sie die Ansicht [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) der Präsentation
3. Schreiben Sie die Präsentation als PPTX-Datei

Im nachfolgenden Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizenansicht festgelegt.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Festlegen der Ansichtseigenschaften der Präsentation
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoomwert in Prozent für die Folienansicht
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoomwert in Prozent für die Notizenansicht 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) werden auf Präsentationsebene ([Normal View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/)) definiert, nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen des gesamten Dokuments gilt.

**Kann ich unterschiedliche Ansichtszustände für verschiedene Benutzer vordefinieren?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erzeugen.