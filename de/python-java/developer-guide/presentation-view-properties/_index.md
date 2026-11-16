---
title: Abrufen und Aktualisieren von Präsentationsansichtseigenschaften in Python via Java
linktitle: Ansichtseigenschaften
type: docs
weight: 80
url: /de/python-java/presentation-view-properties/
keywords:
- Ansichtseigenschaften
- Normalansicht
- Gliederungsinhalt
- Gliederungssymbole
- Vertikalen Trenner einrasten lassen
- Einzelansicht
- Leistenstatus
- Dimensionsgröße
- Automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Python via Java, um das Layout der Normalansicht, den Zoom von Folie und Notizen, den Rasterabstand und die Sichtbarkeit von Kommentaren in PowerPoint-Präsentationen zu konfigurieren."
---
## **Einleitung**

In der Normalansicht von PowerPoint wird die Folie zwischen einem Seitenbereich für Miniaturbilder oder einer Gliederung und einem Notizenbereich unten angezeigt. Aspose.Slides für Python via Java stellt die gespeicherten Bearbeitungspräferenzen der Präsentation über [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) bereit. Diese umfassen das Layout des Bereichs, Zoomstufen, Rasterabstand und die Sichtbarkeit von Kommentaren.

## **Über NormalViewProperties**

Verwenden Sie [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) um auf die Klasse [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/) zuzugreifen. [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) steuert, ob Symbole neben den Folientiteln in der Gliederung angezeigt werden. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) lässt den Seitenbereich in den minimierten Zustand einrasten, wenn der Benutzer ihn verkleinert. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) gibt eine Präferenz an, ein Feld im Vollfenster anzuzeigen.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) steuert den Trenner zwischen dem Seitenbereich und der Folie. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) steuert den Trenner über dem Notizenbereich. Beide akzeptieren einen Wert vom Typ [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) von `Minimized`, `Maximized` oder `Restored`.

## **Über das Wiederherstellen von NormalViewProperties**

Wenn ein Trenner wiederhergestellt wird, liefert [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) die gespeicherte Größe des Seitenbereichs und [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) die gespeicherte Größe des oberen Folienbereichs. Beide geben eine Instanz von [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/) zurück. Die Methode [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) akzeptiert einen Prozentsatz von 0 bis 100, und [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) steuert, ob der Editor die Größe bei einer Fenstergrößenänderung anpasst.

Dieses Beispiel aktualisiert eine vorhandene Präsentation. Es stellt den horizontalen Trenner wieder her, legt die von [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) zurückgegebene Größe auf 80% mit aktivierter automatischer Anpassung fest und maximiert den vertikalen Trenner. Es ruft außerdem [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) auf, um Symbole in der Gliederungsansicht anzuzeigen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Standard-Zoomwert festlegen**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) und [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) speichern unabhängige Zoom-Einstellungen für den Editor. Diese Einstellungen beeinflussen nicht die Folienabmessungen, die Wiedergabe von Bildschirmen oder die Auflösung beim Bildexport.

Dieses Beispiel öffnet eine vorhandene Präsentation und ruft [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) auf, um die Folie an das Bearbeitungsfenster anzupassen. Für die Notizenseite deaktiviert es die automatische Skalierung und ruft [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) auf, um einen festen Zoom von 80% festzulegen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rasterabstand festlegen**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) legt den Abstand zwischen den Bearbeitungsrasterlinien in der gesamten Präsentation fest. Es nimmt einen positiven Wert in Punkten entgegen, wobei 72 Punkte einem Zoll entsprechen. Dieses Beispiel gibt den aktuellen Abstand in einer vorhandenen Präsentation aus und speichert ein Viertel‑Zoll‑Raster, indem es das Intervall auf 18 Punkte setzt.

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

Das Raster wiederholt sich in einem festen Intervall. [Zeichnungshilfen](/slides/de/python-java/drawing-guides/) markieren einzelne horizontale oder vertikale Positionen. Beide sind Bearbeitungshilfen und erscheinen nur in Editoren, die sie anzeigen. Bildschirme und Exporte nach PDF, Bildern oder SVG lassen sie weg.

## **Kommentare beim Öffnen einer Präsentation ein- oder ausblenden**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) speichert eine Präferenz, die kompatible Editoren beim Öffnen der Präsentation verwenden. Für eine vorhandene Präsentation mit Kommentaren gibt dieses Beispiel die aktuelle Einstellung aus und speichert eine Kopie mit ausgeblendeten Kommentaren. Es ruft außerdem [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) mit [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) auf, sodass die Kopie in der Folienansicht geöffnet wird.

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

Das Ausblenden von Kommentaren bewahrt deren Text, Autoren, Positionen, Antworten und Status. Um die Kommentare selbst zu ändern, siehe [Präsentationskommentare](/slides/de/python-java/presentation-comments/). Exporteinstellungen bestimmen, ob Kommentare in PDF, HTML, Bildern, Notizen oder Handzetteln erscheinen.

## **FAQ**

**Warum ist das Raster ausgeblendet, wenn ich die Präsentation erneut öffne?**

Die Präsentation speichert das Rasterintervall. Um das Raster zu sehen, aktivieren Sie die Rasteranzeige im Editor.

**Ändert das Löschen von Zeichenhilfen den Rasterabstand?**

Nein. Das Hinzufügen, Verschieben oder Löschen einer Hilfslinie ändert das Rasterintervall nicht.

**Können verschiedene Abschnitte einer Präsentation unterschiedliche Ansichtseinstellungen haben?**

Nein. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) gilt für die gesamte Präsentation.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Benutzer speichern?**

Die Datei speichert einen Satz von Ansichtseigenschaften für alle. Ein Editor kann außerdem die lokalen Präferenzen eines Benutzers anwenden.

**Kann ich Ansichtseinstellungen in einer Vorlage speichern?**

Ja. Aus der Vorlage erstellte Präsentationen übernehmen deren gespeicherte Ansichtseinstellungen.