---
title: Zeichnungshilfen in Präsentationen mit Python verwalten
linktitle: Zeichnungshilfen
type: docs
weight: 85
url: /de/python-net/drawing-guides/
keywords:
- Zeichnungshilfe
- Horizontale Hilfslinie
- Vertikale Hilfslinie
- Ausrichtungshilfe
- Folienansicht
- Masterfolie
- Layoutfolie
- Notizen-Master
- Handzettel-Master
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Horizontale und vertikale Zeichnungshilfen in PowerPoint-Präsentationen hinzufügen, darauf zugreifen und löschen mit Aspose.Slides für Python über .NET."
---
## **Übersicht**

Zeichnungshilfen sind einstellbare horizontale und vertikale Linien, die Benutzern helfen, Formen beim Bearbeiten einer PowerPoint‑Präsentation konsistent auszurichten. Sie sind besonders nützlich, wenn eine Anwendung eine Präsentation generiert, die später manuell verfeinert wird: Die Anwendung kann dieselben Ausrichtungs­hilfen speichern, denen Autoren beim Hinzufügen oder Verschieben von Inhalten folgen sollten.

Zeichnungshilfen sind Bearbeitungshilfen, kein Folieninhalt. Sie werden in einer Bildschirmpräsentation oder gerenderten Ausgabe nicht angezeigt. Aspose.Slides für Python über .NET stellt sie über das Interface [IDrawingGuidesCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/idrawingguidescollection/) bereit. Eine Hilfslinie wird durch [IDrawingGuide](https://reference.aspose.com/slides/de/python-net/aspose.slides/idrawingguide/) repräsentiert und besitzt eine Ausrichtung, eine Position und eine Farbe.

Die Position wird in Punkten vom oberen linken Eckpunkt der jeweiligen Folie oder des Masters gemessen. Eine vertikale Hilfslinie verwendet eine horizontale Koordinate, typischerweise zwischen Null und der Folienbreite. Eine horizontale Hilfslinie verwendet eine vertikale Koordinate, typischerweise zwischen Null und der Folienhöhe.

## **Hilfslinien zur Folienansicht hinzufügen**

Verwenden Sie [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/de/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) , um die während der Bearbeitung normaler Folien angezeigten Hilfslinien zu verwalten. Rufen Sie [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/de/python-net/aspose.slides/idrawingguidescollection/add/) mit einem [Orientation](https://reference.aspose.com/slides/de/python-net/aspose.slides/orientation/)‑Wert und einer Position in Punkten auf.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Auf Zeichnungshilfen zugreifen**

Die Eigenschaft [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/de/python-net/aspose.slides/idrawingguidescollection/count/) und der Indexer ermöglichen den Zugriff auf vorhandene Hilfslinien. Die Eigenschaften [IDrawingGuide.orientation](https://reference.aspose.com/slides/de/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/de/python-net/aspose.slides/idrawingguide/position/) und [IDrawingGuide.color](https://reference.aspose.com/slides/de/python-net/aspose.slides/idrawingguide/color/) können gelesen oder geändert werden.

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Hilfslinien zu Master‑ und Layout‑Folien hinzufügen**

Ein Folien‑Master und jede seiner Layout‑Folien können eigene Zeichnungshilfen‑Sammlungen besitzen. Verwenden Sie [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterslide/drawing_guides/) für einen Master‑Slide und [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/de/python-net/aspose.slides/ilayoutslide/drawing_guides/) für einen Layout‑Slide.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Hilfslinien zu Notizen‑ und Handzettel‑Meistern hinzufügen**

Notizen‑Master und Handzettel‑Master unterstützen ebenfalls Zeichnungshilfen. Verwenden Sie [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasternotesslide/drawing_guides/) und [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterhandoutslide/drawing_guides/), um auf deren Sammlungen zuzugreifen. Wenn eine Präsentation keinen dieser Master enthält, erzeugt [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) bzw. [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) den Standard‑Master und gibt ihn zurück.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Zeichnungshilfen löschen**

Rufen Sie [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/de/python-net/aspose.slides/idrawingguidescollection/clear/) auf, um alle Hilfslinien aus einer bestimmten Sammlung zu entfernen. Das Leeren einer Sammlung wirkt sich nicht auf Hilfslinien aus, die in einem anderen Geltungsbereich gespeichert sind.

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Erscheinen Zeichnungshilfen in einer Bildschirmpräsentation oder exportierten Bildern?**

Nein. Zeichnungshilfen sind Ausrichtungs­hilfen für die Bearbeitung und werden nicht als Präsentationsinhalt gerendert.

**Kann eine Zeichnungshilfe direkt zu einer einzelnen normalen Folie hinzugefügt werden?**

Bearbeitungs­hilfen für normale Folien werden in den Folien‑Ansicht‑Eigenschaften der Präsentation gespeichert. Separate Hilfslinien‑Sammlungen stehen für Folien‑Master, Layout‑Folien, Notizen‑Master und Handzettel‑Master zur Verfügung.

**Welche Einheiten werden für die Positionen von Hilfslinien verwendet?**

Positionen werden in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Vertikale Positionen werden vom linken Rand gemessen, horizontale Positionen vom oberen Rand.

**Entfernt das Löschen von Zeichnungshilfen Formen oder ändert den Folieninhalt?**

Nein. Die Methode `clear` entfernt nur die Hilfslinien in der ausgewählten Sammlung. Formen und anderer Folieninhalt bleiben unverändert.