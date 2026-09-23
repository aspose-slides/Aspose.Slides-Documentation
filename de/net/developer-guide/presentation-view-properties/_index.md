---
title: Abrufen und Aktualisieren von Präsentations‑Ansichtseigenschaften in .NET
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/net/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normale Ansicht
- Gliederungsinhalt
- Gliederungssymbole
- Vertikaler Trennbalken einrasten
- Einzelansicht
- Balkenzustand
- Dimensionsgröße
- Automatische Anpassung
- Standard‑Zoom
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für .NET, um PPT-, PPTX- und ODP‑Folienformate anzupassen – Layouts, Zoom‑Stufen und Anzeigeeinstellungen zu ändern."
---
## **Einleitung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichts‑Zustand in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht denselben Zustand hat wie beim letzten Speichern der Präsentation.

Die Property [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/iviewproperties/properties/normalviewproperties) wurde hinzugefügt, um Zugriff auf die Normalansicht‑Eigenschaften der Präsentation zu ermöglichen.  

[INormalViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/de/net/aspose.slides/inormalviewrestoredproperties) Schnittstellen und ihre Nachfolger sowie das Enum [SplitterBarStateType](https://reference.aspose.com/slides/de/net/aspose.slides/splitterbarstatetype) wurden hinzugefügt.

## **Über INormalViewProperties**

Stellt Normalansicht‑Eigenschaften dar.

Die Property **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalte in einem der Inhaltsbereiche des Normalansicht‑Modus angezeigt werden.

Die Property **SnapVerticalSplitter** gibt an, ob der vertikale Teiler in den minimierten Zustand springen soll, wenn der seitliche Bereich ausreichend klein ist.

Die Property **PreferSingleView** gibt an, ob der Benutzer bevorzugt, einen einzigen Vollfenster‑Inhaltsbereich statt der üblichen Normalansicht mit drei Inhaltsbereichen zu sehen. Ist sie aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster darzustellen.

Die Properties **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom darunter liegenden Inhaltsbereich, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored**.

Die Properties **RestoredLeft** und **RestoredTop** geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für **VerticalBarState** bzw. **HorizontalBarState** der Wert **SplitterBarStateType.Restored** verwendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Property **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft).

Die Property **AutoAdjust** gibt an, ob die Größe des seitlichen Inhaltsbereichs sich an die neue Größe anpassen soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung neu dimensioniert wird.

Ein Beispiel weiter unten zeigt, wie Sie auf die Eigenschaften **ViewProperties.NormalViewProperties** einer Präsentation zugreifen können.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides für .NET unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann erreicht werden, indem die [ViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties) einer Präsentation gesetzt werden. Folien‑Ansichts‑Eigenschaften sowie [NotesViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/properties/notesviewproperties) können programmgesteuert gesetzt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die View‑Properties einer Präsentation in Aspose.Slides gesetzt werden.

Um die View‑Properties zu setzen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)
2. Setzen Sie die View[Properties](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties) der Präsentation
3. Schreiben Sie die Präsentation als PPTX‑Datei

Im unten stehenden Beispiel haben wir den Zoomwert sowohl für die Folienansicht als auch für die Notizansicht gesetzt.

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

Verwenden Sie [Presentation.ViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/viewproperties/) zum Zugriff auf die präsentationsweiten Ansichtseinstellungen. Die Property [IViewProperties.GridSpacing](https://reference.aspose.com/slides/de/net/aspose.slides/iviewproperties/gridspacing/) liest oder ändert das Intervall des zugrundeliegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für eine einzelne Folie. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet eine vorhandene `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Intervall von einem Viertel Zoll und speichert das Ergebnis.

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

Das Raster unterscheidet sich von den [Zeichnungshilfen](/slides/de/net/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichnungshilfen einzelne horizontal oder vertikal ausgerichtete Linien sind. Das Hinzufügen, Verschieben oder Entfernen von Zeichnungshilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichnungshilfen sind Bearbeitungs­hilfen. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Diashow gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: seine Sichtbarkeit hängt ebenfalls von den Einstellungen des Betrachters oder Editors ab.

## **Kommentare beim Öffnen einer Präsentation ein‑ oder ausblenden**

Verwenden Sie [Presentation.ViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/viewproperties/) zum Zugriff auf die präsentationsweiten Ansichtseinstellungen. Lesen oder ändern Sie [IViewProperties.ShowComments](https://reference.aspose.com/slides/de/net/aspose.slides/iviewproperties/showcomments/), um eine Präferenz zu speichern, ob Kommentare beim Öffnen der Präsentation in PowerPoint oder einem anderen kompatiblen Editor angezeigt werden sollen.

Diese Einstellung steuert nur die gespeicherte Ansichtspräferenz. Sie fügt keine Kommentare hinzu, entfernt sie, bearbeitet sie oder löst sie auf. Das Ausblenden von Kommentaren bewahrt deren Inhalt, Autoren, Positionen, Antworten und Status. Siehe [Presentation Comments](/slides/de/net/presentation-comments/) für Vorgänge, die die Kommentare selbst ändern.

Das folgende Beispiel erfordert eine vorhandene `comments.pptx` mit Kommentaren. Es gibt die aktuelle Sichtbarkeitseinstellung aus, fordert das Ausblenden der Kommentare an und speichert eine neue PPTX, ohne Kommentare zu entfernen. Außerdem wird [IViewProperties.LastView](https://reference.aspose.com/slides/de/net/aspose.slides/iviewproperties/lastview/) auf [ViewType.SlideView](https://reference.aspose.com/slides/de/net/aspose.slides/viewtype/) gesetzt, um die anfängliche Bearbeitungsansicht zusammen mit der Kommentar‑Sichtbarkeit zu konfigurieren.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Diese Einstellung bestimmt nicht, ob Kommentare in PDF, HTML, Bild, Notizen‑ oder Handzettel‑Exporten enthalten sind. Konfigurieren Sie die jeweiligen export‑spezifischen Optionen separat.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Prüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Entfernen von Zeichnungshilfen den Rasterabstand?**

Nein. Zeichnungshilfen und Rasterabstand sind unabhängige Einstellungen. Das Entfernen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[Ansichtseinstellungen](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/viewproperties/) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/slideviewproperties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz für das gesamte Dokument beim Öffnen gilt.

**Kann ich vordefinierte Ansichtszustände für verschiedene Benutzer festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam genutzt. Viewer‑Anwendungen können Benutzereinstellungen berücksichtigen, aber die Datei selbst enthält nur einen Satz View‑Properties.

**Kann ich eine Vorlage mit vordefinierten View‑Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [View‑Properties](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/viewproperties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und neue Dokumente daraus erstellen, die dieselbe anfängliche Ansichtskonfiguration besitzen.