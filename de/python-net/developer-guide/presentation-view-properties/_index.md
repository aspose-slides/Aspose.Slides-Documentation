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
- Vertikaler Trennbalken einrasten
- Einzelansicht
- Balkenzustand
- Abmessungsgröße
- Automatische Anpassung
- Standardzoom
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für Python via .NET, um Formate PPT, PPTX und ODP Folien anzupassen - Layouts, Zoomstufen und Anzeigeeinstellungen zu ändern."
---

{{% alert color="primary" %}} 

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Eigenschaften, die sich auf die Positionierung der verschiedenen Inhaltsbereiche beziehen. Diese Informationen ermöglichen es der Anwendung, ihren Anzeigestatus in der Datei zu speichern, sodass beim erneuten Öffnen die Ansicht denselben Zustand hat wie beim letzten Speichern der Präsentation.

Die Eigenschaft [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) wurde hinzugefügt, um Zugriff auf die Normalansichtseigenschaften einer Präsentation zu ermöglichen.

Die Schnittstellen [INormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/) und deren Ableitungen sowie das Aufzählungselement [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) wurden hinzugefügt.

{{% /alert %}} 

## **Über INormalViewProperties** 

Stellt Normalansichtseigenschaften dar.

Die Eigenschaft **ShowOutlineIcons** gibt an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalte in einem der Inhaltsbereiche des Normalansichtsmodus dargestellt werden.

Die Eigenschaft **SnapVerticalSplitter** gibt an, ob der vertikale Trennbalken in den minimierten Zustand springen soll, wenn der seitliche Bereich ausreichend klein ist.

Die Eigenschaft **PreferSingleView** gibt an, ob der Benutzer es bevorzugt, einen einzelnen Inhaltsbereich im Vollfenster zu sehen, anstatt der Standard‑Normalansicht mit drei Inhaltsbereichen. Wenn aktiviert, kann die Anwendung entscheiden, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Eigenschaften **VerticalBarState** und **HorizontalBarState** geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie, eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** und **SplitterBarStateType.Restored**.

Die Eigenschaften **RestoredLeft** und **RestoredTop** geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn für **VerticalBarState** bzw. **HorizontalBarState** der Wert **SplitterBarStateType.Restored** angewendet wird.

## **Über das Wiederherstellen von INormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn Kind von RestoredTop, Höhe, wenn Kind von RestoredLeft) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Eigenschaft **DimensionSize** gibt die Größe des Folienbereichs an (Breite, wenn Kind von restoredTop, Höhe, wenn Kind von restoredLeft).

Die Eigenschaft **AutoAdjust** gibt an, ob die Größe des seitlichen Inhaltsbereichs bei einer Größenänderung des Anwendungsfensters kompensiert werden soll.

Im Folgenden wird ein Beispiel gezeigt, das den Zugriff auf die Eigenschaften **ViewProperties.NormalViewProperties** einer Präsentation veranschaulicht.
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


## **Standard‑Zoom‑Wert festlegen**

Aspose.Slides for Python via .NET unterstützt jetzt das Festlegen des Standard‑Zoom‑Werts für eine Präsentation, sodass beim Öffnen der Präsentation der Zoom bereits eingestellt ist. Dies kann durch Setzen der [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) einer Präsentation erfolgen. Folien‑View‑Properties sowie [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) können programmgesteuert gesetzt werden. In diesem Abschnitt zeigen wir anhand eines Beispiels, wie die View‑Properties einer Präsentation in Aspose.Slides festgelegt werden.

Um die View‑Properties festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 
1. Setzen Sie die View‑[Properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) der Präsentation 
1. Schreiben Sie die Präsentation als PPTX‑Datei 

Im nachfolgenden Beispiel haben wir den Zoom‑Wert für die Folien‑View sowie für die Notizen‑View gesetzt.
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Einstellen der Ansichtseigenschaften der Präsentation
    presentation.view_properties.slide_view_properties.scale = 100 # Zoomwert in Prozent für die Folienansicht
    presentation.view_properties.notes_view_properties.scale = 100 # Zoomwert in Prozent für die Notizenansicht

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich unterschiedliche View‑Einstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen des gesamten Dokuments angewendet wird.

**Kann ich unterschiedliche View‑Zustände für verschiedene Benutzer vordefinieren?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz View‑Properties.

**Kann ich eine Vorlage mit vordefinierten View‑Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen View‑Konfiguration erstellen.