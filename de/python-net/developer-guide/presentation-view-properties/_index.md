---
title: "Abrufen und Aktualisieren von Ansichtseigenschaften einer Präsentation in Python"
linktitle: "Ansichtseigenschaften"
type: docs
weight: 80
url: /de/python-net/presentation-view-properties/
keywords:
- "Ansichtseigenschaften"
- "Normalansicht"
- "Gliederungsinhalt"
- "Gliederungssymbole"
- "Vertikalen Splitter einrasten"
- "Einzelansicht"
- "Balkenzustand"
- "Dimensionsgröße"
- "automatische Anpassung"
- "Standardzoom"
- "PowerPoint"
- "Präsentation"
- "Python"
- "Aspose.Slides"
description: "Entdecken Sie Aspose.Slides für Python via .NET Ansichtseigenschaften, um PPT-, PPTX- und ODP‑Folienformate anzupassen – Layouts, Zoomstufen und Anzeigeeinstellungen zu ändern."
---
## **Einleitung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichts‑Zustand in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im gleichen Zustand ist wie beim letzten Speichern der Präsentation.

Die Eigenschaft [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/normal_view_properties/) wurde hinzugefügt, um Zugriff auf die Normalansicht‑Eigenschaften einer Präsentation zu ermöglichen.  

Die Klassen [NormalViewProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/normalviewrestoredproperties/) und deren Ableitungen sowie das Aufzählungselement [SplitterBarStateType](https://reference.aspose.com/slides/de/python-net/aspose.slides/splitterbarstatetype/) wurden hinzugefügt.

## **Über INormalViewProperties**

Stellt Normalansichts‑Eigenschaften dar.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn Inhaltsübersichts‑Inhalte in einem der Inhaltsbereiche des Normalansichts‑Modus dargestellt werden.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Splitter in einen minimierten Zustand „schnappen“ soll, sobald der seitliche Bereich hinreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer lieber eine vollständige Einzelfenster‑Ansicht über den standardmäßigen Drei‑Bereich‑Normalmodus sehen möchte. Ist sie aktiviert, kann die Anwendung einen der Inhaltsbereiche im gesamten Fenster anzeigen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom darunter liegenden Inhaltsbereich, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored**.

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für **VerticalBarState** bzw. **HorizontalBarState** der Wert **SplitterBarStateType.Restored** angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von RestoredTop, Höhe, wenn ein Kind von RestoredLeft) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe (weder minimiert noch maximiert) hat.

Die Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von restoredTop, Höhe, wenn ein Kind von restoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung neu skaliert wird.

Im Folgenden wird ein Beispiel gezeigt, wie Sie auf die Eigenschaften **ViewProperties.NormalViewProperties** einer Präsentation zugreifen können.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Wiederherstellen der Ansichtseigenschaften der Präsentation
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Standard‑Zoomwert festlegen**

Aspose.Slides für Python via .NET unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann erreicht werden, indem die [view_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/view_properties/) einer Präsentation gesetzt werden. Sowohl die Folien‑Ansichtseigenschaften als auch die [notes_view_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/notes_view_properties/) können programmgesteuert festgelegt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die Ansichtseigenschaften einer Präsentation in Aspose.Slides gesetzt werden.

Um die Ansichtseigenschaften festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)  
2. Setzen Sie die [view properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/) der Präsentation  
3. Schreiben Sie die Präsentation als PPTX-Datei

Im nachfolgenden Beispiel haben wir den Zoomwert für die Folienansicht sowie für die Notizansicht gesetzt.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Festlegen der Ansichtseigenschaften der Präsentation
    presentation.view_properties.slide_view_properties.scale = 100 # Zoomwert in Prozent für die Folienansicht
    presentation.view_properties.notes_view_properties.scale = 100 # Zoomwert in Prozent für die Notizansicht 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rasterabstand festlegen**

Verwenden Sie [Presentation.view_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/view_properties/), um die präsentationsweiten Ansichtseinstellungen zu erreichen. Die Eigenschaft [ViewProperties.grid_spacing](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/grid_spacing/) liest oder ändert das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für eine einzelne Folie. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet eine vorhandene `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Intervall von einem Viertelzoll und speichert das Ergebnis.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Das Raster unterscheidet sich von den [drawing guides](/slides/de/python-net/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichenhilfen einzeln positionierte horizontale oder vertikale Ausrichtungs‑Linien sind. Das Hinzufügen, Verschieben oder Löschen von Zeichenhilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichenhilfen sind Hilfsmittel zur Bearbeitung. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Bildschirmpräsentation gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: Die Sichtbarkeit hängt auch von den Präferenzen des Betrachters oder Editors ab.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**  
Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Prüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Löschen von Zeichenhilfen den Rasterabstand?**  
Nein. Zeichenhilfen und Rasterabstand sind unabhängige Einstellungen. Das Löschen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**  
Ansichtseinstellungen ([View settings](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/view_properties/)) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/slide_view_properties/)), nicht pro Abschnitt. Daher gilt ein einziger Parametersatz für das gesamte Dokument beim Öffnen.

**Kann ich unterschiedliche Ansichts‑Zustände für verschiedene Benutzer vordefinieren?**  
Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten Ansichtseigenschaften vorbereiten, sodass neue Präsentationen gleich geöffnet werden?**  
Ja. Da [view properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/view_properties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und neue Dokumente daraus mit derselben anfänglichen Ansichtskonfiguration erzeugen.