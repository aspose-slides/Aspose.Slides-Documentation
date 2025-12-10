---
title: Abrufen und Aktualisieren von Präsentationsansichtseigenschaften in .NET
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/net/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- Vertikalen Teiler einrasten lassen
- Einzelansicht
- Balkenstatus
- Abmessungsgröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für .NET, um PPT-, PPTX- und ODP-Folien anzupassen – Layouts, Zoomstufen und Anzeigeeinstellungen zu ändern."
---

{{% alert color="primary" %}} 

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die sich auf die Positionierung der verschiedenen Inhaltsbereiche beziehen. Diese Informationen ermöglichen es der Anwendung, den Ansichtsstatus in der Datei zu speichern, sodass beim erneuten Öffnen die Ansicht denselben Zustand hat wie beim letzten Speichern der Präsentation.

Die Eigenschaft [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) wurde hinzugefügt, um Zugriff auf die Normalansichtseigenschaften einer Präsentation zu ermöglichen.

Die Schnittstellen [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) sowie deren Ableitungen, das Aufzählungstyp [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) wurden hinzugefügt.

{{% /alert %}}

## **Über INormalViewProperties**

Stellt Normalansichtseigenschaften dar.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalte in einem der Inhaltsbereiche des Normalansichtsmodus dargestellt werden.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Teiler in einen minimierten Zustand einrasten soll, wenn der Seitenbereich ausreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer es bevorzugt, einen einzigen Inhaltsbereich im Vollfenster zu sehen, anstatt der Standard‑Normalansicht mit drei Inhaltsbereichen. Wenn aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennleiste trennt die Folie vom Seiteninhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored.**

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für **VerticalBarState** und **HorizontalBarState** jeweils der Wert **SplitterBarStateType.Restored** angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties** 

Spezifiziert die Größe des Folienbereichs (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft) der Normalansicht, wenn der Bereich eine variable wiederhergestellte Größe (weder minimiert noch maximiert) hat.

Die Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe des Seiteninhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht in der Anwendung enthält, geändert wird.

Ein Beispiel unten zeigt, wie Sie auf die Eigenschaften **ViewProperties.NormalViewProperties** einer Präsentation zugreifen können.
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


## **Standard‑Zoom‑Wert festlegen**

Aspose.Slides für .NET unterstützt jetzt das Festlegen des Standard‑Zoom‑Werts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch Festlegen der [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) einer Präsentation erfolgen. Folien‑Ansichtseigenschaften sowie [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) können programmgesteuert festgelegt werden. In diesem Thema sehen wir anhand eines Beispiels, wie die View‑Eigenschaften einer Präsentation in Aspose.Slides gesetzt werden.

Um die Ansichtseigenschaften festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Instanziieren Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. Setzen Sie die View [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) der Präsentation
1. Schreiben Sie die Präsentation als PPTX‑Datei

Im unten gezeigten Beispiel haben wir den Zoom‑Wert sowohl für die Folienansicht als auch für die Notizansicht festgelegt.
```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Festlegen der Ansichtseigenschaften der Präsentation
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoomwert in Prozent für die Folienansicht
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoomwert in Prozent für die Notizansicht 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) sind auf Ebene der Präsentation definiert ([Normal View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen auf das gesamte Dokument angewendet wird.

**Kann ich unterschiedliche Ansichts‑zustände für verschiedene Benutzer vordefinieren?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam genutzt. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten Ansichtseigenschaften erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) auf Ebene der Präsentation gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben Anfangsansichtskonfiguration erzeugen.