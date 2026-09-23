---
title: Abrufen und Aktualisieren von Präsentationsansichtseigenschaften in Python
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/python-net/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- Vertikalen Trennbalken einrasten
- Einzelansicht
- Balkenstatus
- Abmessungsgröße
- Automatische Anpassung
- Standardzoom
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Python über .NET Ansichtseigenschaften, um PPT-, PPTX- und ODP-Folien anzupassen – Layouts, Zoomstufen und Anzeigeeinstellungen zu verändern."
---
## **Einführung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtszustand in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht denselben Zustand hat wie beim letzten Speichern der Präsentation.

Die Eigenschaft [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/normal_view_properties/) wurde hinzugefügt, um Zugriff auf die Normalansichts‑Eigenschaften einer Präsentation zu ermöglichen.  

Die Klassen [NormalViewProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/normalviewrestoredproperties/) sowie deren Ableitungen, das Aufzählungselement [SplitterBarStateType](https://reference.aspose.com/slides/de/python-net/aspose.slides/splitterbarstatetype/) wurden hinzugefügt.

## **Über INormalViewProperties**

Stellt Normalansichts‑Eigenschaften dar.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn Outline‑Inhalt in einem der Inhaltsbereiche der Normalansicht angezeigt wird.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Trennbalken in einen minimierten Zustand einrasten soll, wenn der Seitenbereich hinreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer es bevorzugt, einen einzelnen Inhaltsbereich im Vollfenster statt der üblichen Normalansicht mit drei Inhaltsbereichen zu sehen. Ist diese Option aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster darzustellen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom darunter liegenden Inhaltsbereich, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored**.

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für **VerticalBarState** bzw. **HorizontalBarState** der Wert **SplitterBarStateType.Restored** angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Legt die Größenangaben des Folienbereichs (Breite, wenn Kind von RestoredTop, Höhe, wenn Kind von RestoredLeft) der Normalansicht fest, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn Kind von restoredTop, Höhe, wenn Kind von restoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe kompensieren soll, wenn das Fenster, das die Ansicht enthält, in der Anwendung neu skaliert wird.

Ein Beispiel wird unten gezeigt, wie Sie auf die Eigenschaften **ViewProperties.NormalViewProperties** einer Präsentation zugreifen können.

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

Aspose.Slides für Python über .NET unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch Festlegen der [view_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/view_properties/) einer Präsentation erfolgen. Folienansichts‑Eigenschaften sowie [notes_view_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/notes_view_properties/) können programmgesteuert gesetzt werden. In diesem Thema sehen wir anhand eines Beispiels, wie die Ansichtseigenschaften einer Präsentation in Aspose.Slides festgelegt werden.

Um die Ansichtseigenschaften festzulegen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)  
1. Setzen Sie die [view properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/) der Präsentation  
1. Speichern Sie die Präsentation als PPTX-Datei  

Im nachstehenden Beispiel haben wir den Zoomwert für die Folienansicht sowie für die Notizansicht festgelegt.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Festlegen der Ansichtseigenschaften der Präsentation
    presentation.view_properties.slide_view_properties.scale = 100 # Zoomwert in Prozent für die Folienansicht
    presentation.view_properties.notes_view_properties.scale = 100 # Zoomwert in Prozent für die Notizansicht 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rasterabstand festlegen**

Verwenden Sie [Presentation.view_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/view_properties/), um die präsentationsweiten Ansichtseinstellungen zuzugreifen. Die Eigenschaft [ViewProperties.grid_spacing](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/grid_spacing/) liest oder ändert das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für einzelne Folien. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet ein vorhandenes `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Intervall von einem Viertelzoll und speichert das Ergebnis.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Das Raster unterscheidet sich von den [drawing guides](/slides/de/python-net/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichenhilfen einzelne horizontale oder vertikale Ausrichtungslinien sind. Das Hinzufügen, Verschieben oder Entfernen von Zeichenhilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichenhilfen dienen als Bearbeitungshilfen. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Diashow dargestellt. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: dessen Sichtbarkeit hängt auch von den Einstellungen des Betrachters oder Editors ab.

## **Kommentare beim Öffnen einer Präsentation anzeigen oder ausblenden**

Verwenden Sie [Presentation.view_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/view_properties/), um die präsentationsweiten Ansichtseinstellungen zuzugreifen. Lesen oder ändern Sie [ViewProperties.show_comments](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/show_comments/), um eine Präferenz zu speichern, ob Kommentare angezeigt werden sollen, wenn die Präsentation in PowerPoint oder einem anderen kompatiblen Editor geöffnet wird.

Diese Einstellung steuert nur die gespeicherte Ansichtspräferenz. Sie fügt Kommentare nicht hinzu, entfernt sie nicht, bearbeitet sie nicht und löst sie nicht auf. Das Ausblenden von Kommentaren bewahrt deren Inhalt, Autoren, Positionen, Antworten und Status. Siehe [Presentation Comments](/slides/de/python-net/presentation-comments/) für Vorgänge, die Kommentare selbst ändern.

Das folgende Beispiel erfordert ein vorhandenes `comments.pptx` mit Kommentaren. Es gibt die aktuelle Sichtbarkeitseinstellung aus, fordert das Ausblenden der Kommentare an und speichert ein neues PPTX, ohne Kommentare zu entfernen. Es setzt außerdem [ViewProperties.last_view](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/last_view/) auf [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewtype/), um die anfängliche Bearbeitungsansicht zusammen mit der Kommentar­sichtbarkeit zu konfigurieren.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Diese Einstellung bestimmt nicht, ob Kommentare in PDF-, HTML-, Bild-, Notiz‑ oder Handout‑Exporten enthalten sind. Konfigurieren Sie die entsprechenden export‑spezifischen Optionen separat.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**  
Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Überprüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Entfernen von Zeichenhilfen den Rasterabstand?**  
Nein. Zeichenhilfen und Rasterabstand sind unabhängige Einstellungen. Das Entfernen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**  
[Ansichtseinstellungen](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/view_properties/) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/slide_view_properties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen des gesamten Dokuments gilt.

**Kann ich unterschiedliche Ansichtszustände für verschiedene Benutzer vordefinieren?**  
Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam nutzbar. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz von Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten Ansichtseigenschaften erstellen, damit neue Präsentationen gleich geöffnet werden?**  
Ja. Da [Ansichtseigenschaften](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/view_properties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben initialen Ansichtskonfiguration erstellen.