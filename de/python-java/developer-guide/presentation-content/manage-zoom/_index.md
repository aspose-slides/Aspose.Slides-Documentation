---
title: Zoom in Python über Java verwalten
linktitle: Zoom verwalten
type: docs
weight: 60
url: /de/python-java/manage-zoom/
keywords:
- zoom
- zoom-frame
- folien-zoom
- abschnitts-zoom
- zusammenfassungs-zoom
- zoom hinzufügen
- PowerPoint
- präsentation
- Python
- Java
- Aspose.Slides
description: "Zoom mit Aspose.Slides für Python über Java erstellen und anpassen — zwischen Abschnitten springen, Miniaturbilder und Übergänge in PowerPoint‑Präsentationen hinzufügen."
---
## **Einführung**

PowerPoint-Zooms ermöglichen es Ihnen, während einer Bildschirmpräsentation zwischen bestimmten Folien und Abschnitten zu navigieren. Mit Aspose.Slides für Python über Java können Sie Folien-, Abschnitts- und Zusammenfassungs-Zooms erstellen und deren Vorschauen, Rahmen und Übergänge anpassen.

![PowerPoint-Zoom-Übersicht](overview.png)

* Um die gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Zusammenfassungs-Zoom](#summary-zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Folien-Zoom](#slide-zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Abschnitts-Zoom](#section-zoom).

## **Folien-Zoom**

Ein Folien-Zoom kann Ihre Präsentation dynamischer machen, indem er Ihnen erlaubt, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Ablauf Ihrer Präsentation zu unterbrechen. Folien-Zooms eignen sich hervorragend für kurze Präsentationen ohne viele Abschnitte, können jedoch auch in verschiedenen Präsentationsszenarien verwendet werden.

Folien-Zooms ermöglichen es Ihnen, verwandte Informationen von einer einzigen Übersichtsfolie aus zu erkunden.

![Auswahl von Folien für einen Folien-Zoom](slidezoomsel.png)

Für Folien-Zoom-Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/) die Klasse [ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/) und Methoden der Klasse [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) bereit.

### **Zoom-Frames erstellen**

Verwenden Sie [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame), um Links zu einzelnen Folien auf einer Übersichtsfolie zu platzieren. Dieses Beispiel erstellt zwei Ziel-Folien mit unterschiedlichen Hintergründen und Beschriftungen, fügt dann eine Vorschau jeder Folie zur ersten Folie hinzu und speichert die Präsentation als PPTX. Rahmen-Positionen und -Abmessungen werden in Punkten angegeben.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zoom-Frames mit benutzerdefinierten Bildern erstellen**

Übergeben Sie ein benutzerdefiniertes Bild an [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame), um die Standard-Vorschau der Ziel-Folie zu ersetzen. Dieses Beispiel erfordert ein lokales Bild, lädt es mit [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile), und fügt es der Präsentation über [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) hinzu. Der resultierende Rahmen zeigt dieses Bild an, während er weiterhin auf die zweite Folie verlinkt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    overview_slide.getShapes().addZoomFrame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zoom-Frames formatieren**

Dieses Beispiel passt zwei Folien-Zoom-Frames an. Es weist dem ersten Frame ein lokales Bild über [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) zu und gibt dem zweiten Frame einen fünf Punkt breiten, strich-punkt-gestrichelten pinken Rahmen über [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat). Das Übergeben von `False` an [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) blendet den Hintergrund des zweiten Frames aus. Ein lokales Bild ist für die benutzerdefinierte Vorschau erforderlich; beide Frames behalten ihre Folien-Ziele in der gespeicherten PPTX bei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    first_zoom_frame = overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_zoom_frame.setZoomImage(preview_image)

    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(255, 105, 180))
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    second_zoom_frame.setShowBackground(False)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Abschnitts-Zoom**

Ein Abschnitts-Zoom verlinkt zu einem Abschnitt Ihrer Präsentation. Verwenden Sie ihn, um ein Thema erneut zu besuchen oder zu zeigen, wie verschiedene Teile der Präsentation zusammenhängen.

![Auswahl eines Abschnitts für einen Abschnitts-Zoom](seczoomsel.png)

Für Abschnitts-Zoom-Objekte stellt Aspose.Slides die Klasse [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) sowie Methoden der Klasse [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) bereit.

### **Abschnitts-Zoom-Frames erstellen**

Erstellen Sie einen Abschnitt mit [SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection), und übergeben Sie den zurückgegebenen Abschnitt an [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame). Dieses Beispiel platziert einen Abschnitts-Zoom auf der ersten Folie und verlinkt ihn zu einem Abschnitt, der mit einer farbigen Folie beginnt. Die Position und Abmessungen des Frames werden in Punkten angegeben, und die Präsentation wird als PPTX gespeichert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Abschnitts-Zoom-Frames mit benutzerdefinierten Bildern erstellen**

Die Bild-Überladung von [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) ermöglicht es Ihnen, eine benutzerdefinierte Vorschau anzuzeigen, ohne den Zielabschnitt zu ändern. Dieses Beispiel erfordert ein lokales Bild, das mit [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) geladen und über [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) hinzugefügt wird. Die gespeicherte Präsentation enthält einen Abschnitts-Zoom auf der ersten Folie, der mit dem neu erstellten Abschnitt verknüpft ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zielabschnitt eines Abschnitts-Zooms ändern**

Verwenden Sie [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection), um einen bestehenden Abschnitts-Zoom umzuleiten, ohne ihn neu zu erstellen. Wählen Sie einen gefüllten Abschnitt aus der [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections)-Sammlung derselben Präsentation. Das Zuweisen eines leeren Abschnitts lässt das aktuelle Ziel unverändert, prüfen Sie daher [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) bevor Sie es zuweisen. Siehe [Abschnitte verwalten](/slides/de/python-java/slide-section/) für weitere Informationen zu Abschnitten.

Das folgende Beispiel lädt eine Präsentationsdatei, die mehrere gefüllte Abschnitte, einen bestehenden Abschnitts-Zoom mit dem Namen `Section navigation` und einen Abschnitt mit dem eindeutigen Namen `Results` enthalten muss. Es durchsucht alle Folien nach dem Zoom und findet das Ziel anhand des Namens anstatt eines Sammlungs-Index, der sich ändern kann, wenn Abschnitte neu geordnet werden. Wenn Namen nicht eindeutig sind, verwenden Sie [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId), um das Ziel stattdessen zu ermitteln.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SectionZoomFrame

presentation = Presentation("section-zoom.pptx")
try:
    zoom = None
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, SectionZoomFrame) and shape.getName() == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = None
    for section in presentation.getSections():
        if section.getName() == "Results":
            target_section = section
            break

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif target_section.getSlidesListOfSection().size() == 0:
        print("The destination section is empty.")
    else:
        current_section = zoom.getTargetSection()
        current_name = "" if current_section is None else current_section.getName()
        print("Current section: " + str(current_name))
        zoom.setTargetSection(target_section)
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Abschnitts-Zoom-Frames formatieren**

Dieses Beispiel verschiebt und skaliert einen Abschnitts-Zoom auf 100 × 75 Punkte, weist über [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) ein lokales Bild zu und wendet einen 2,5 Punkt breiten, strich-punkt-gestrichelten braunen Rahmen an. Es aktiviert [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent), um nach dem Abschnitt zur Ausgangs-Folie zurückzukehren, deaktiviert [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground), und setzt [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) auf 1,5 Sekunden. Ein lokales Bild ist für die benutzerdefinierte Vorschau erforderlich.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)

    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section_zoom_frame.setZoomImage(preview_image)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zusammenfassungs-Zoom**

Ein Zusammenfassungs-Zoom bietet einen Überblick über die Abschnitte einer Präsentation. Während einer Bildschirmpräsentation können Sie ihn verwenden, um zu einem Abschnitt zu springen, weiterzublättern oder ein Thema erneut zu besuchen, ohne der Folienreihenfolge zu folgen.

![Auswahl von Abschnitten für einen Zusammenfassungs-Zoom](sumzoomsel.png)

Für Zusammenfassungs-Zoom-Objekte stellt Aspose.Slides die Klassen [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/), und [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/) sowie Methoden der Klasse [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) bereit.

### **Zusammenfassungs-Zoom erstellen**

Verwenden Sie [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame), um einen Überblick über die Abschnitte der Präsentation zu erstellen. Dieses Beispiel erstellt vier Abschnitte mit unterschiedlichen Folien-Hintergründen und fügt einen Zusammenfassungs-Zoom zur ersten Folie hinzu. Die Position und Abmessungen des Frames werden in Punkten angegeben, und der resultierende Überblick wird in einer PPTX-Präsentation gespeichert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 3", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(0, 100, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 4", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Eine Zusammenfassungs-Zoom-Sektion hinzufügen und entfernen**

Ein Zusammenfassungs-Zoom speichert seine [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/)-Objekte in [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection). Dieses Beispiel erstellt einen Überblick über zwei Abschnitte, fügt über [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) einen dritten Abschnitt hinzu und entfernt den Eintrag des ersten Abschnitts mittels [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection). Das Entfernen des Eintrags lässt den Präsentations-Abschnitt und dessen Folien unverändert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    first_section = presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    third_section = presentation.getSections().addSection("Section 3", slide)

    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(first_section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zusammenfassungs-Zoom-Sektionen formatieren**

Dieses Beispiel formatiert den ersten Eintrag in [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection), wobei der nullbasierte Index `0` verwendet wird. Es erfordert ein lokales Bild für [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage), wendet einen 1,5 Punkt breiten, strich-punkt-gestrichelten schwarzen Rahmen an und setzt [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) auf 1,5 Sekunden. Das Übergeben von `False` an [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) deaktiviert die automatische Rückkehr zur Zusammenfassungs-Folien für diesen Eintrag.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    summary_section.setZoomImage(preview_image)
    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich die Rückkehr zur „Eltern‑“Folien nach Anzeige des Ziels steuern?**

Ja. Rufen Sie [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) mit `True` auf, um nach Anzeige des Zielinhalts zur Ausgangs-Folie zurückzukehren.

**Kann ich die „Geschwindigkeit“ oder Dauer des Zoom-Übergangs anpassen?**

Ja. Verwenden Sie [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration), um die Übergangsdauer in Sekunden zu steuern.

**Gibt es Beschränkungen, wie viele Zoom-Objekte eine Präsentation enthalten kann?**

Es gibt keine dokumentierte harte API-Grenze. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistung des Betrachters ab. Sie können viele Zoom-Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.