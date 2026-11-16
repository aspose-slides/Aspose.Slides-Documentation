---
title: Präsentationsansichtseigenschaften in Python abrufen und aktualisieren
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/python-net/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- Vertikalen Trenner einrasten
- Einzelansicht
- Balkenstatus
- Dimensionsgröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Python über .NET, um das Layout der Normalansicht, den Zoom von Folien und Notizen, den Rasterabstand und die Sichtbarkeit von Kommentaren in PowerPoint-Präsentationen zu konfigurieren."
---
## **Einführung**

In der Normalansicht von PowerPoint wird die Folie zwischen einem Seitenbereich für Miniaturansichten oder einer Gliederung und einem Notizbereich unten angezeigt. Aspose.Slides für Python über .NET stellt die gespeicherten Bearbeitungspräferenzen der Präsentation über [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Dazu gehören das Layout der Bereiche, die Zoomstufen, der Rasterabstand und die Sichtbarkeit von Kommentaren.

## **Über NormalViewProperties**

Verwenden Sie [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) um auf das Objekt [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/) zuzugreifen. [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) steuert, ob Symbole neben den Folientiteln in der Gliederung angezeigt werden. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) lässt den Seitenbereich in den minimierten Zustand springen, wenn der Benutzer ihn verkleinert. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) gibt an, dass ein einzelner Bereich im Vollbildfenster angezeigt werden soll.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) steuert den Trenner zwischen dem Seitenbereich und der Folie. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) steuert den Trenner über dem Notizbereich. Beide akzeptieren einen [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) Wert von `MINIMIZED`, `MAXIMIZED` oder `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![Ein konzeptueller Editor trennt ein Seitenpanel, einen Folienbereich und einen unteren Bereich mit beschrifteten vertikalen und horizontalen Teilern.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*In der Normalansicht steuert der vertikale Trenner die Breite des Seitenbereichs. Der horizontale Trenner steuert den Raum über dem Notizbereich.*
<!-- visual-explanation:presentation-view-properties:end -->

## **Über das Wiederherstellen von NormalViewProperties**

Wenn ein Trenner wiederhergestellt wird, liefert [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) die gespeicherte Größe des Seitenbereichs und [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) die gespeicherte Größe des oberen Folienbereichs. Beide stellen [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/) bereit. Die Eigenschaft [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) akzeptiert einen Prozentsatz von 0 bis 100, und [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) steuert, ob der Editor die Größe bei einer Fenstergrößenänderung anpasst.

Dieses Beispiel aktualisiert eine bestehende Präsentation. Es stellt den horizontalen Trenner wieder her, setzt [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) auf 80 % mit aktivierter automatischer Anpassung und maximiert den vertikalen Trenner. Außerdem wird [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) für die Gliederungsansicht aktiviert.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Standard-Zoomwert festlegen**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) und [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) speichern unabhängige Zoom‑Einstellungen für den Editor. Diese Einstellungen beeinflussen nicht die Folienabmessungen, die Wiedergabe von Bildschirmen oder die Auflösung beim Export von Bildern.

Dieses Beispiel öffnet eine bestehende Präsentation und aktiviert [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/), um die Folie an das Bearbeitungsfenster anzupassen. Für die Notizseite wird die automatische Skalierung deaktiviert und [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) auf einen festen Zoom von 80 % gesetzt.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Rasterabstand festlegen**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) legt den Abstand zwischen den Bearbeitungsrasterlinien in der gesamten Präsentation fest. Es nimmt einen positiven Wert in Punkten, wobei 72 Punkte einem Zoll entsprechen. Dieses Beispiel gibt den aktuellen Abstand in einer bestehenden Präsentation aus und speichert ein Viertel‑Zoll‑Raster, indem das Intervall auf 18 Punkte gesetzt wird.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Das Raster wiederholt sich in einem festen Intervall. [Zeichenhilfen](/slides/de/python-net/drawing-guides/) markieren einzelne horizontale oder vertikale Positionen. Beide dienen als Hilfsmittel beim Bearbeiten und erscheinen nur in Editoren, die sie anzeigen. Bildschirmp​räsentationen und Exporte nach PDF, Bildern oder SVG lassen sie weg.

## **Kommentare beim Öffnen einer Präsentation ein- oder ausblenden**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) speichert eine Präferenz, die kompatible Editoren beim Öffnen der Präsentation verwenden. Für eine bestehende Präsentation mit Kommentaren gibt dieses Beispiel die aktuelle Einstellung aus und speichert eine Kopie mit ausgeblendeten Kommentaren. Außerdem wird [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) auf [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) gesetzt, sodass die Kopie in der Folienansicht geöffnet wird.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Das Ausblenden von Kommentaren bewahrt deren Text, Autoren, Positionen, Antworten und Status. Um die Kommentare selbst zu ändern, siehe [Präsentationskommentare](/slides/de/python-net/presentation-comments/). Exporteinstellungen steuern, ob Kommentare in PDF, HTML, Bildern, Notizen oder Handzetteln erscheinen.

## **FAQ**

**Warum ist das Raster ausgeblendet, wenn ich die Präsentation erneut öffne?**

Die Präsentation speichert das Rasterintervall. Um das Raster zu sehen, aktivieren Sie die Rasteranzeige im Editor.

**Ändert das Löschen von Zeichenhilfen den Rasterabstand?**

Nein. Das Hinzufügen, Verschieben oder Löschen einer Hilfslinie lässt das Rasterintervall unverändert.

**Können verschiedene Abschnitte einer Präsentation unterschiedliche Ansichtseinstellungen haben?**

Nein. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) gilt für die gesamte Präsentation.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Benutzer speichern?**

Die Datei speichert einen Satz von Ansichtseigenschaften für alle. Ein Editor kann zusätzlich die lokalen Präferenzen eines Benutzers anwenden.

**Kann ich Ansichtseinstellungen in einer Vorlage speichern?**

Ja. Präsentationen, die aus der Vorlage erstellt werden, übernehmen die dort gespeicherten Ansichtseinstellungen.