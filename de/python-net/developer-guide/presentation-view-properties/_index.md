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
- vertikalen Trennbalken einrasten
- Einzelansicht
- Balkenzustand
- Dimensionsgröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Python über .NET Ansichtseigenschaften, um PPT-, PPTX- und ODP-Folienformate anzupassen - Layouts, Zoomstufen und Anzeigeeinstellungen zu ändern."
---

{{% alert color="primary" %}} 

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die die Positionierung der verschiedenen Inhaltsbereiche betreffen. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtsstatus in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht im selben Zustand ist wie beim letzten Speichern der Präsentation.

Die Eigenschaft [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) wurde hinzugefügt, um Zugriff auf die Normalansichtseigenschaften einer Präsentation zu ermöglichen. 

[NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/) Klassen und deren Nachkommen, das [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) Enum wurden hinzugefügt.

{{% /alert %}} 

## **Über INormalViewProperties** 

Stellt Normalansichtseigenschaften dar.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn Outline‑Inhalte in einem der Inhaltsbereiche des Normalansichtsmodus dargestellt werden.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Teiler in einen minimierten Zustand springen soll, wenn der Seitenbereich ausreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer es vorzieht, einen einzelnen Vollbild‑Inhaltsbereich anstelle der Standard‑Normalansicht mit drei Inhaltsbereichen zu sehen. Ist sie aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored**.

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für **VerticalBarState** bzw. **HorizontalBarState** der Wert **SplitterBarStateType.Restored** verwendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn Kind von RestoredTop, Höhe, wenn Kind von RestoredLeft) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn Kind von RestoredTop, Höhe, wenn Kind von RestoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe beim Ändern der Fenstergröße, das die Ansicht enthält, ausgleichen soll.

Ein untenstehendes Beispiel zeigt, wie Sie auf die **ViewProperties.NormalViewProperties**‑Eigenschaften einer Präsentation zugreifen können.
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Wiederherstellen der Ansichtseigenschaften der Präsentation
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```


## **Standard‑Zoomwert festlegen**

Aspose.Slides für Python über .NET unterstützt jetzt das Festlegen des Standard‑Zoomwerts für eine Präsentation, sodass beim Öffnen die Vergrößerung bereits eingestellt ist. Dies kann durch das Setzen der [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) einer Präsentation erfolgen. Folien‑Ansichtseigenschaften sowie [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) können programmgesteuert festgelegt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die Ansichtseigenschaften einer Präsentation in Aspose.Slides gesetzt werden.

Um die Ansichtseigenschaften festzulegen, führen Sie die nachstehenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 
1. Setzen Sie die [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) der Präsentation 
1. Schreiben Sie die Präsentation als PPTX‑Datei 

Im nachstehenden Beispiel haben wir den Zoomwert für die Folienansicht sowie die Notizansicht festgelegt.
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Festlegen der Ansichtseigenschaften der Präsentation
    presentation.view_properties.slide_view_properties.scale = 100 # Zoomwert in Prozent für die Folienansicht
    presentation.view_properties.notes_view_properties.scale = 100 # Zoomwert in Prozent für die Notizansicht 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen auf das gesamte Dokument angewendet wird.

**Kann ich unterschiedliche Ansichts‑zustände für verschiedene Benutzer vordefinieren?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten Ansichtseigenschaften erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) auf Präsentationsebene gespeichert werden, können Sie diese in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erstellen.