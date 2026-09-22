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
- Vertikalen Trenner einrasten lassen
- Einzelansicht
- Leistenstatus
- Abmessungsgröße
- Automatische Anpassung
- Standard-Zoom
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für .NET, um PPT-, PPTX- und ODP-Folienformate anzupassen – Layouts, Zoomstufen und Anzeigeeinstellungen zu ändern."
---
## **Einleitung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtszustand in der Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist wie beim letzten Speichern der Präsentation.

Eigenschaft [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/iviewproperties/properties/normalviewproperties) wurde hinzugefügt, um Zugriff auf die Normalansichtseigenschaften einer Präsentation zu bieten. 

Die Schnittstellen [INormalViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/de/net/aspose.slides/inormalviewrestoredproperties) sowie deren Ableitungen und das Aufzählungselement [SplitterBarStateType](https://reference.aspose.com/slides/de/net/aspose.slides/splitterbarstatetype) wurden hinzugefügt.

## **Über INormalViewProperties**

Repräsentiert Normalansichtseigenschaften.

Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalte in einem der Inhaltsbereiche des Normalansichtsmodus dargestellt werden.

Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Trenner in einen minimierten Zustand springen soll, wenn der seitliche Bereich ausreichend klein ist.

Eigenschaft **PreferSingleView** gibt an, ob der Benutzer lieber einen einzelnen Inhaltsbereich im Vollfenster sehen möchte statt der Standard‑Normalansicht mit drei Inhaltsbereichen. Ist sie aktiviert, kann die Anwendung entscheiden, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale bzw. vertikale Trennerleiste angezeigt werden soll. Eine horizontale Trennerleiste trennt die Folie vom darunter liegenden Inhaltsbereich, eine vertikale Trennerleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored**.

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für **VerticalBarState** bzw. **HorizontalBarState** der Wert **SplitterBarStateType.Restored** angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties** 

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert). 

Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft).

Eigenschaft **AutoAdjust** gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, in der Anwendung resized wird.

Ein Beispiel unten zeigt, wie Sie auf die Eigenschaften **ViewProperties.NormalViewProperties** einer Präsentation zugreifen können.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Wiederherstellung der Ansichtseigenschaften der Präsentation
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Standard‑Zoomwert festlegen**

Aspose.Slides für .NET unterstützt jetzt das Festlegen eines Standard‑Zoomwerts für die Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch Festlegen der [ViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties) einer Präsentation geschehen. Folienansichtseigenschaften sowie [NotesViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/properties/notesviewproperties) können programmgesteuert festgelegt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die Ansichtseigenschaften einer Präsentation in Aspose.Slides gesetzt werden.

Um die Ansichtseigenschaften zu setzen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)
2. Setzen Sie die Ansicht[Properties](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties) der Präsentation
3. Schreiben Sie die Präsentation als PPTX‑Datei

Im nachfolgenden Beispiel haben wir den Zoomwert sowohl für die Folienansicht als auch für die Notizansicht festgelegt.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Festlegen der Ansichtseigenschaften der Präsentation
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoomwert in Prozent für die Folienansicht
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoomwert in Prozent für die Notizansicht 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Rasterabstand festlegen**

Verwenden Sie [Presentation.ViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/viewproperties/) , um die präsentationsweiten Ansichtseinstellungen zu nutzen. Die Eigenschaft [IViewProperties.GridSpacing](https://reference.aspose.com/slides/de/net/aspose.slides/iviewproperties/gridspacing/) liest oder ändert das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für einzelne Folien. Der Rasterabstand wird in Punkt angegeben, wobei 72 Punkt einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet ein vorhandenes `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Intervall von einem Viertelzoll und speichert das Ergebnis.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Das Raster unterscheidet sich von [Zeichenhilfen](/slides/de/net/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichenhilfen einzelne, horizontal oder vertikal positionierte Ausrichtungs­linien sind. Das Hinzufügen, Verschieben oder Löschen von Zeichenhilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichenhilfen dienen als Bearbeitungshilfen. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Diashow gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: dessen Sichtbarkeit hängt ebenfalls von den Einstellungen des Viewers oder Editors ab.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Prüfen Sie die Sichtbarkeitseinstellungen des Rasters im Editor.

**Ändert das Löschen von Zeichenhilfen den Rasterabstand?**

Nein. Zeichenhilfen und Rasterabstand sind unabhängige Einstellungen. Das Löschen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[Ansichtseinstellungen](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/viewproperties/) werden auf Präsentationsebene definiert ([Normalansicht](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/normalviewproperties/)/[Folienansicht](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/slideviewproperties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen des Dokuments gilt.

**Kann ich vordefinierte Ansichtszustände für verschiedene Benutzer festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und gemeinsam genutzt. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält einen einzigen Satz Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten Ansichtseigenschaften erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [Ansichtseigenschaften](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/viewproperties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und neue Dokumente daraus erzeugen, die dieselbe Anfangsansichtskonfiguration besitzen.