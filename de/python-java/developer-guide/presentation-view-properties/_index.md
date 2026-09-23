---
title: Abrufen und Aktualisieren von Präsentationsansichtseigenschaften in Python über Java
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/python-java/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- Vertikalen Trenner einrasten
- Einzelansicht
- Balkenzustand
- Dimensiongröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für Python über Java, um PPT-, PPTX- und ODP‑Folien anzupassen – Layouts, Zoomstufen und Anzeigeeinstellungen ändern."
---
## **Einleitung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Die Normalansicht‑Eigenschaften beschreiben die Positionierung dieser Inhaltsbereiche. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtszustand in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht denselben Zustand hat wie beim letzten Speichern der Präsentation.

Die Methode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getNormalViewProperties) wurde hinzugefügt, um Zugriff auf die Normalansicht‑Eigenschaften einer Präsentation zu ermöglichen.

Die Klassen [NormalViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/) und [NormalViewRestoredProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewrestoredproperties/) sowie die Aufzählung [SplitterBarStateType](https://reference.aspose.com/slides/de/python-java/aspose.slides/splitterbarstatetype/) wurden hinzugefügt.

## **Über NormalViewProperties**

Stellt die Normalansicht‑Eigenschaften dar.

Die Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) und [setShowOutlineIcons](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) geben an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalte in einem der Inhaltsbereiche des Normalansichtsmodus angezeigt werden.

Die Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) geben an, ob der vertikale Trenner in einen minimierten Zustand einrasten soll, wenn der Seitenbereich ausreichend klein ist.

Die Methoden [getPreferSingleView](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) und [setPreferSingleView](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) geben an, ob der Benutzer bevorzugt, einen vollflächigen Einzel‑Inhaltsbereich statt der Standard‑Normalansicht mit drei Inhaltsbereichen zu sehen. Ist diese Option aktiviert, kann die Anwendung einen der Inhaltsbereiche im gesamten Fenster anzeigen.

Die Methoden [getVerticalBarState](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) und [getHorizontalBarState](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) geben den Zustand an, in dem die horizontale bzw. vertikale Trennleiste angezeigt werden soll. Eine horizontale Trennleiste trennt die Folie vom darunter liegenden Inhaltsbereich; eine vertikale Trennleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/de/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/de/python-java/aspose.slides/splitterbarstatetype/#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/python-java/aspose.slides/splitterbarstatetype/#Restored).

Die Methoden [getRestoredLeft](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) und [getRestoredTop](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getRestoredTop) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn der Wert [SplitterBarStateType.Restored] jeweils auf [getVerticalBarState] bzw. [getHorizontalBarState] angewendet wird.

## **Über das Wiederherstellen von NormalViewProperties**

Legt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop] ist, Höhe, wenn ein Kind von [getRestoredLeft] ist) der Normalansicht fest, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Methode [getDimensionSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von [getRestoredTop] ist, Höhe, wenn ein Kind von [getRestoredLeft] ist).

Die Methode [getAutoAdjust](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe kompensieren soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendunggrößenänderung angepasst wird.

Das folgende Beispiel zeigt, wie man auf [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getNormalViewProperties) einer Präsentation zugreift.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Wiederherstellen der Ansichtseigenschaften der Präsentation.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Standard‑Zoomwert festlegen**

{{% alert color="info" title="Note" %}}
Aspose.Slides für Python über Java unterstützt das Festlegen des standardmäßigen Zoomwerts, sodass er bereits beim Öffnen der Präsentation angewendet wird. Dies kann durch das Setzen der [ViewProperties] einer Präsentation erfolgen. [getSlideViewProperties] sowie [getNotesViewProperties] können programmgesteuert konfiguriert werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die [View Properties] der [Presentation] in Aspose.Slides festgelegt werden.
{{% /alert %}}

Um die Ansichtseigenschaften festzulegen, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
1. Setzen Sie die [View Properties](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/) der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Datei.

Im folgenden Beispiel setzen wir den Zoomwert sowohl für die Folienansicht als auch für die Notizansicht.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Setzen Sie die Ansichtseigenschaften der Präsentation.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Zoom-Prozentsatz für die Folienansicht.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Zoom-Prozentsatz für die Notizansicht.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rasterabstand festlegen**

Verwenden Sie [Presentation.getViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getViewProperties), um auf die präsentationsweiten Ansichtseinstellungen zuzugreifen. Die Methoden [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getGridSpacing) und [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#setGridSpacing) lesen bzw. ändern das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für eine einzelne Folie. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet ein vorhandenes `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Intervall von einem Viertelzoll und speichert das Ergebnis.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Raster unterscheidet sich von den [drawing guides](/slides/de/python-java/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichnungshilfen individuell platzierte horizontale oder vertikale Ausrichtungslinien sind. Das Hinzufügen, Verschieben oder Entfernen von Zeichnungshilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichnungshilfen sind Hilfsmittel beim Bearbeiten. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Diashow gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: dessen Sichtbarkeit hängt ebenfalls von den Einstellungen des Betrachters oder Editors ab.

## **Kommentare beim Öffnen einer Präsentation anzeigen oder ausblenden**

Verwenden Sie [Presentation.getViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getViewProperties), um auf die präsentationsweiten Ansichtseinstellungen zuzugreifen. Mit [ViewProperties.getShowComments](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getShowComments) und [ViewProperties.setShowComments](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#setShowComments) können Sie die gespeicherte Präferenz auslesen bzw. ändern, ob Kommentare angezeigt werden sollen, wenn die Präsentation in PowerPoint oder einem anderen kompatiblen Editor geöffnet wird.

Diese Einstellung steuert nur die gespeicherte Ansichtspräferenz. Sie fügt keine Kommentare hinzu, entfernt sie nicht, bearbeitet sie nicht und löst sie nicht auf. Das Ausblenden von Kommentaren bewahrt deren Inhalt, Autoren, Positionen, Antworten und Status. Siehe [Presentation Comments](/slides/de/python-java/presentation-comments/) für Vorgänge, die die Kommentare selbst ändern.

Das folgende Beispiel erfordert ein vorhandenes `comments.pptx`, das Kommentare enthält. Es gibt die aktuelle Sichtbarkeitseinstellung aus, fordert an, dass Kommentare ausgeblendet werden, und speichert ein neues PPTX, ohne Kommentare zu entfernen. Es verwendet außerdem [ViewProperties.setLastView](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#setLastView) zusammen mit [ViewType.SlideView](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewtype/#SlideView), um die anfängliche Bearbeitungsansicht zusammen mit der Kommentar‑Sichtbarkeit zu konfigurieren.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Diese Einstellung bestimmt nicht, ob Kommentare in PDF-, HTML-, Bild-, Notiz- oder Handout‑Exporten enthalten sind. Konfigurieren Sie die entsprechenden exportbezogenen Optionen separat.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Überprüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Entfernen von Zeichnungshilfen den Rasterabstand?**

Nein. Zeichnungshilfen und Rasterabstand sind unabhängige Einstellungen. Das Entfernen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[View settings](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getViewProperties) werden auf Präsentationsebene ([Normal View](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getSlideViewProperties)) definiert und nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen auf das gesamte Dokument angewendet wird.

**Kann ich unterschiedliche Ansichtszustände für verschiedene Benutzer im Voraus festlegen?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam. Viewer‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten View Properties erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [view properties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getViewProperties) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erstellen.