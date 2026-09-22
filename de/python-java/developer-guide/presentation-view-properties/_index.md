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
- vertikalen Trenner einrasten lassen
- Einzelansicht
- Leistenzustand
- Dimensiongröße
- automatische Anpassung
- Standardzoom
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Entdecken Sie die Ansichtseigenschaften von Aspose.Slides für Python via Java, um PPT-, PPTX- und ODP-Folien anzupassen - Layouts, Zoom-Stufen und Anzeigeeinstellungen zu verändern."
---
## **Einführung**

Die Normalansicht besteht aus drei Inhaltsbereichen: der Folie selbst, einem seitlichen Inhaltsbereich und einem unteren Inhaltsbereich. Die Eigenschaften der Normalansicht beschreiben die Positionierung dieser Inhaltsbereiche. Diese Informationen ermöglichen es der Anwendung, ihren Ansichtszustand in die Datei zu speichern, sodass beim erneuten Öffnen die Ansicht denselben Zustand hat wie beim letzten Speichern der Präsentation.

Die Methode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getNormalViewProperties) wurde hinzugefügt, um Zugriff auf die Normalansichtseigenschaften einer Präsentation zu ermöglichen.

Die Klassen [NormalViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/) und [NormalViewRestoredProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewrestoredproperties/) sowie die Aufzählung [SplitterBarStateType](https://reference.aspose.com/slides/de/python-java/aspose.slides/splitterbarstatetype/) wurden hinzugefügt.

## **Über NormalViewProperties**

Stellt die Normalansichtseigenschaften dar.

Die Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) und [setShowOutlineIcons](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) geben an, ob die Anwendung Symbole anzeigen soll, wenn Gliederungsinhalte in einem der Inhaltsbereiche des Normalansichtsmodus angezeigt werden.

Die Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) und [setSnapVerticalSplitter](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) geben an, ob der vertikale Trenner in einen minimierten Zustand einrasten soll, wenn der Seitenbereich ausreichend klein ist.

Die Methoden [getPreferSingleView](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) und [setPreferSingleView](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) geben an, ob der Benutzer es bevorzugt, einen einzelnen Inhaltsbereich im Vollfenster gegenüber der Standard‑Normalansicht mit drei Inhaltsbereichen zu sehen. Ist dies aktiviert, kann die Anwendung wählen, einen der Inhaltsbereiche im gesamten Fenster anzuzeigen.

Die Methoden [getVerticalBarState](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) und [getHorizontalBarState](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) geben den Zustand an, in dem die horizontale bzw. vertikale Trennerleiste angezeigt werden soll. Eine horizontale Trennerleiste trennt die Folie vom Inhaltsbereich unterhalb der Folie; eine vertikale Trennerleiste trennt die Folie vom seitlichen Inhaltsbereich. Mögliche Werte sind: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/de/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/de/python-java/aspose.slides/splitterbarstatetype/#Maximized) und [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/python-java/aspose.slides/splitterbarstatetype/#Restored).

Die Methoden [getRestoredLeft](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) und [getRestoredTop](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getRestoredTop) geben die Größe des oberen bzw. seitlichen Folienbereichs der Normalansicht an, wenn der Wert [SplitterBarStateType.Restored](https://reference.aspose.com/slides/de/python-java/aspose.slides/splitterbarstatetype/#Restored) auf [getVerticalBarState](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) bzw. [getHorizontalBarState](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) angewendet wird.

## **Über das Wiederherstellen von NormalViewProperties**

Gibt die Größe des Folienbereichs (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getRestoredTop), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) der Normalansicht an, wenn der Bereich eine variable wiederhergestellte Größe hat (weder minimiert noch maximiert).

Die Methode [getDimensionSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) gibt die Größe des Folienbereichs an (Breite, wenn ein Kind von [getRestoredTop](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getRestoredTop), Höhe, wenn ein Kind von [getRestoredLeft](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Die Methode [getAutoAdjust](https://reference.aspose.com/slides/de/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) gibt an, ob die Größe des seitlichen Inhaltsbereichs die neue Größe ausgleichen soll, wenn das Fenster, das die Ansicht enthält, innerhalb der Anwendung geändert wird.

Das nachstehende Beispiel zeigt, wie man [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getNormalViewProperties) für eine Präsentation aufruft.

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

## **Standard-Zoomwert festlegen**

{{% alert color="info" title="Note" %}}
Aspose.Slides für Python via Java unterstützt das Festlegen des Standard‑Zoomwerts, sodass er bereits beim Öffnen der Präsentation angewendet wird. Dies kann erreicht werden, indem die [ViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/) einer Präsentation gesetzt werden. [getSlideViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getSlideViewProperties) sowie [getNotesViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getNotesViewProperties) können programmgesteuert konfiguriert werden. In diesem Thema zeigen wir anhand eines Beispiels, wie die [View Properties](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/) von [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) in Aspose.Slides festgelegt werden.
{{% /alert %}}

Um die Ansichtseigenschaften festzulegen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
1. Setzen Sie die [View Properties](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/) von [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
1. Schreiben Sie die Präsentation als [PPTX](https://docs.fileformat.com/presentation/pptx/)-Datei.

Im nachstehenden Beispiel setzen wir den Zoomwert sowohl für die Folienansicht als auch für die Notizenansicht.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Setze die Ansichtseigenschaften der Präsentation.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Zoom-Prozentsatz für die Folienansicht.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Zoom-Prozentsatz für die Notizenansicht.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rasterabstand festlegen**

Verwenden Sie [Presentation.getViewProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getViewProperties), um auf die Präsentations‑weiten Ansichtseinstellungen zuzugreifen. Die Methoden [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getGridSpacing) und [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#setGridSpacing) lesen bzw. ändern das Intervall des zugrunde liegenden Bearbeitungsrasters. Diese Einstellung gilt für die gesamte Präsentation, nicht für einzelne Folien. Der Rasterabstand wird in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Verwenden Sie einen positiven Wert, wie in der API‑Dokumentation gefordert.

Das folgende Beispiel öffnet eine vorhandene `demo.pptx`, gibt den aktuellen Rasterabstand aus, setzt ein Intervall von einem Viertelzoll und speichert das Ergebnis.

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

Das Raster unterscheidet sich von den [Zeichnungshilfen](/slides/de/python-java/drawing-guides/). Der Rasterabstand steuert ein regelmäßiges Intervall, während Zeichnungshilfen einzeln positionierte horizontale oder vertikale Ausrichtungslinien sind. Das Hinzufügen, Verschieben oder Entfernen von Zeichnungshilfen ändert den Rasterabstand nicht.

Sowohl das Raster als auch die Zeichnungshilfen sind Bearbeitungshilfen. Sie werden nicht als Folieninhalt in PDF, Bildern, SVG oder einer Bildschirmpräsentation gerendert. Das Speichern des Rasterabstands garantiert nicht, dass ein Editor das Raster anzeigt: dessen Sichtbarkeit hängt auch von den Einstellungen des Betrachters oder Editors ab.

## **FAQ**

**Warum ist das Raster nach dem erneuten Öffnen der Präsentation nicht sichtbar?**

Die Datei speichert den Rasterabstand, aber der Editor entscheidet, ob das Raster angezeigt wird. Prüfen Sie die Raster‑Sichtbarkeitseinstellungen des Editors.

**Ändert das Entfernen von Zeichnungshilfen den Rasterabstand?**

Nein. Zeichnungshilfen und Rasterabstand sind unabhängige Einstellungen. Das Entfernen von Hilfen lässt das gespeicherte Rasterintervall unverändert.

**Kann ich unterschiedliche Ansichtseinstellungen für verschiedene Abschnitte einer Präsentation festlegen?**

[Ansichtseinstellungen](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getViewProperties) werden auf Präsentationsebene definiert ([Normal View](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), nicht pro Abschnitt, sodass ein einziger Parametersatz beim Öffnen des gesamten Dokuments gilt.

**Kann ich für verschiedene Benutzer unterschiedliche Ansichts‑zustände vordefinieren?**

Nein. Die Einstellungen werden in der Datei gespeichert und sind gemeinsam nutzbar. Betrachter‑Anwendungen können Benutzerpräferenzen berücksichtigen, aber die Datei selbst enthält nur einen Satz Ansichtseigenschaften.

**Kann ich eine Vorlage mit vordefinierten Ansichtseigenschaften erstellen, sodass neue Präsentationen gleich geöffnet werden?**

Ja. Da [Ansichtseigenschaften](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getViewProperties) auf Präsentationsebene gespeichert werden, können Sie sie in einer Vorlage einbetten und daraus neue Dokumente mit derselben anfänglichen Ansichtskonfiguration erzeugen.