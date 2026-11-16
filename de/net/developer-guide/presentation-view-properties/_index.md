---
title: "Abrufen und Aktualisieren von Präsentationsansichtseigenschaften in .NET"
linktitle: "Ansichtseigenschaften"
type: docs
weight: 80
url: /de/net/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungsicons
- Vertikalen Splitter einrasten
- Einzelansicht
- Leistenstatus
- Dimensionsgröße
- Autoanpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für .NET, um das Layout der Normalansicht, den Zoom von Folien und Notizen, den Rasterabstand und die Sichtbarkeit von Kommentaren in PowerPoint‑Präsentationen zu konfigurieren."
---
## **Einleitung**

In der Normalansicht von PowerPoint wird die Folie zwischen einem Seitenbereich für Miniaturansichten oder einer Gliederung und einem Notizenbereich unten angezeigt. Aspose.Slides für .NET stellt die gespeicherten Bearbeitungseinstellungen der Präsentation über [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) bereit. Dazu gehören das Layout der Bereiche, Zoomstufen, Rasterabstand und die Sichtbarkeit von Kommentaren.

## **Über INormalViewProperties**

Verwenden Sie [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) um auf die Schnittstelle [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/) zuzugreifen. [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) steuert, ob Symbole neben den Folientiteln in der Gliederung angezeigt werden. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) kann den Seitenbereich beim Verengen durch den Benutzer in den minimierten Zustand einrasten lassen. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) gibt eine Vorliebe an, einen einzigen Bereich im Vollfenster anzuzeigen.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) steuert den Trenner zwischen dem Seitenbereich und der Folie. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) steuert den Trenner über dem Notizenbereich. Beide akzeptieren einen [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) Wert von `Minimized`, `Maximized` oder `Restored`.

## **Über das Wiederherstellen von INormalViewProperties**

Wenn ein Trenner wiederhergestellt wird, liefert [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) die gespeicherte Größe des Seitenbereichs und [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) die gespeicherte Größe des oberen Folienbereichs. Beide stellen [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/) bereit. Die Eigenschaft [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) akzeptiert einen Prozentsatz von 0 bis 100, und [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) steuert, ob der Editor die Größe bei einer Fenstergrößenänderung anpasst.

Dieses Beispiel aktualisiert eine vorhandene Präsentation. Es stellt den horizontalen Trenner wieder her, setzt [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) auf 80 % mit aktivierter automatischer Anpassung und maximiert den vertikalen Trenner. Außerdem wird [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) für die Gliederungsansicht aktiviert.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Standard‑Zoomwert festlegen**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) und [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) speichern unabhängige Zoomeinstellungen für den Editor. Diese Einstellungen wirken sich nicht auf die Folienabmessungen, die Wiedergabe der Bildpräsentation oder die Auflösung beim Bildexport aus.

Dieses Beispiel öffnet eine vorhandene Präsentation und aktiviert [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/), um die Folie an das Bearbeitungsfenster anzupassen. Für die Notizenseite deaktiviert es die automatische Skalierung und setzt [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) auf einen festen Zoom von 80 %.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Rasterabstand festlegen**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) legt den Abstand zwischen den Bearbeitungsrasterlinien in der gesamten Präsentation fest. Es nimmt einen positiven Wert in Punkten, wobei 72 Punkte einem Zoll entsprechen. Dieses Beispiel gibt den aktuellen Abstand in einer vorhandenen Präsentation aus und speichert ein Raster von einem Viertel Zoll, indem es das Intervall auf 18 Punkte setzt.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Das Raster wiederholt sich in festen Intervallen. [Drawing guides](/slides/de/net/drawing-guides/) markieren einzelne horizontale oder vertikale Positionen. Beide sind Hilfsmittel beim Bearbeiten und werden nur in Editoren angezeigt, die sie unterstützen. Bildpräsentationen und Exporte nach PDF, Bildern oder SVG lassen sie weg.

## **Kommentare beim Öffnen einer Präsentation ein- oder ausblenden**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) speichert eine Präferenz, die kompatible Editoren beim Öffnen der Präsentation verwenden. Für eine vorhandene Präsentation mit Kommentaren gibt dieses Beispiel die aktuelle Einstellung aus und speichert eine Kopie mit ausgeblendeten Kommentaren. Es setzt zudem [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) auf [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/), sodass die Kopie in der Folienansicht geöffnet wird.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Das Ausblenden von Kommentaren bewahrt deren Text, Autoren, Positionen, Antworten und Status. Um die Kommentare selbst zu ändern, siehe [Presentation Comments](/slides/de/net/presentation-comments/). Export‑Einstellungen bestimmen, ob Kommentare in PDF, HTML, Bildern, Notizen oder Handzetteln angezeigt werden.

## **FAQ**

**Warum ist das Raster ausgeblendet, wenn ich die Präsentation erneut öffne?**

Die Präsentation speichert das Rasterintervall. Um das Raster zu sehen, aktivieren Sie die Raster‑Sichtbarkeit im Editor.

**Verändert das Entfernen von Zeichenhilfen den Rasterabstand?**

Nein. Das Hinzufügen, Verschieben oder Entfernen einer Hilfslinie ändert das Rasterintervall nicht.

**Können verschiedene Abschnitte einer Präsentation unterschiedliche Ansichtseinstellungen haben?**

Nein. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) gilt für die gesamte Präsentation.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Benutzer speichern?**

Die Datei speichert einen Satz von Ansichtseigenschaften für alle. Ein Editor kann zudem die lokalen Präferenzen eines Benutzers anwenden.

**Kann ich Ansichtseinstellungen in einer Vorlage speichern?**

Ja. Präsentationen, die aus der Vorlage erstellt wurden, übernehmen deren gespeicherte Ansichtseinstellungen.