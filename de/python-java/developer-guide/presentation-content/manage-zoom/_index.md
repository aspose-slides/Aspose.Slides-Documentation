---
title: "Präsentations‑Zoom in Python via Java verwalten"
linktitle: "Zoom verwalten"
type: docs
weight: 60
url: /de/python-java/manage-zoom/
keywords:
- "Zoom"
- "Zoom‑Frame"
- "Folien‑Zoom"
- "Abschnitts‑Zoom"
- "Zusammenfassungs‑Zoom"
- "Zoom hinzufügen"
- "PowerPoint"
- "Präsentation"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Erstellen und anpassen von Zoom mit Aspose.Slides für Python via Java — zwischen Abschnitten springen, Miniaturansichten und Übergänge in PPT-, PPTX- und ODP‑Präsentationen hinzufügen."
---
## **Einleitung**

Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Bereichen einer Präsentation zu springen und von dort zurückzukehren. Beim Präsentieren kann diese Fähigkeit, schnell im Inhalt zu navigieren, sehr nützlich sein.

![overview_image](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Summary Zoom](#summary-zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Slide Zoom](#slide-zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Section Zoom](#section-zoom).

## **Folien‑Zoom**
Ein Folien‑Zoom kann Ihre Präsentation dynamischer machen, indem er Ihnen ermöglicht, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folien‑Zooms eignen sich hervorragend für kurze Präsentationen ohne viele Abschnitte, können jedoch auch in anderen Präsentationsszenarien verwendet werden.

Folien‑Zooms helfen Ihnen, mehrere Informationsstücke zu vertiefen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden.

![overview_image](slidezoomsel.png)

Für Folien‑Zoom‑Objekte stellt Aspose.Slides die [ZoomImageType](https://reference.aspose.com/slides/de/python-java/aspose.slides/zoomimagetype/)‑Aufzählung, die [ZoomFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/zoomframe/)‑Klasse und einige Methoden in der [ShapeCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/)‑Klasse bereit.

### **Zoom‑Frames erstellen**

Sie können einen Zoom‑Frame auf einer Folie wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken möchten.
3. Fügen Sie den erstellten Folien identifizierenden Text und einen Hintergrund hinzu.
4. Fügen Sie Zoom‑Frames (die die Verweise auf die erstellten Folien enthalten) zur ersten Folie hinzu.
5. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python‑Code zeigt Ihnen, wie Sie einen Zoom‑Frame auf einer Folie erstellen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Fügt neue Folien zur Präsentation hinzu
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Erstellt einen Hintergrund für die zweite Folie
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Erstellt ein Textfeld für die zweite Folie
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Erstellt einen Hintergrund für die dritte Folie
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Erstellt ein Textfeld für die dritte Folie
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Fügt ZoomFrame-Objekte hinzu
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Speichert die Präsentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Zoom‑Frames mit benutzerdefinierten Bildern erstellen**
Mit Aspose.Slides für Python via Java können Sie einen Zoom‑Frame mit einem anderen Folien‑Vorschau‑Bild wie folgt erstellen:
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie eine neue Folie, zu der Sie den Zoom‑Frame verlinken möchten.
3. Fügen Sie der Folie identifizierenden Text und einen Hintergrund hinzu.
4. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/)‑Objekt, indem Sie ein Bild zur Bildersammlung des [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
5. Fügen Sie Zoom‑Frames (die den Verweis auf die erstellte Folie enthalten) zur ersten Folie hinzu.
6. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python‑Code zeigt Ihnen, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Fügt eine neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Erstellt einen Hintergrund für die zweite Folie
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Erstellt ein Textfeld für die zweite Folie
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Erstellt ein neues Bild für das Zoom-Objekt
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Fügt das ZoomFrame-Objekt hinzu
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Speichert die Präsentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Zoom‑Frames formatieren**
In den vorherigen Abschnitten haben wir Ihnen gezeigt, wie Sie einfache Zoom‑Frames erstellen. Um komplexere Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom‑Frame anwenden können.

Sie können die Formatierung eines Zoom‑Frames auf einer Folie wie folgt steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken möchten.
3. Fügen Sie den erstellten Folien identifizierenden Text und einen Hintergrund hinzu.
4. Fügen Sie Zoom‑Frames (die die Verweise auf die erstellten Folien enthalten) zur ersten Folie hinzu.
5. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/)‑Objekt, indem Sie ein Bild zur Bildersammlung des [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
6. Legen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt fest.
7. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
8. Entfernen Sie den Hintergrund eines Bildes des zweiten Zoom‑Frame‑Objekts.
9. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Fügt neue Folien zur Präsentation hinzu
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Erstellt einen Hintergrund für die zweite Folie
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Erstellt ein Textfeld für die zweite Folie
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Erstellt einen Hintergrund für die dritte Folie
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Erstellt ein Textfeld für die dritte Folie
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Fügt ZoomFrame-Objekte hinzu
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Erstellt ein neues Bild für das Zoom-Objekt
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Setzt ein benutzerdefiniertes Bild für das first_zoom_frame-Objekt
    first_zoom_frame.setZoomImage(picture)

    #  Setzt ein Zoom-Frame-Format für das second_zoom_frame-Objekt
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Einstellung zum Nicht‑Anzeigen des Hintergrunds für das second_zoom_frame-Objekt
    second_zoom_frame.setShowBackground(False)

    #  Speichert die Präsentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Abschnitts‑Zoom**

Ein Abschnitts‑Zoom ist ein Link zu einem Abschnitt in Ihrer Präsentation. Sie können Abschnitts‑Zooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders hervorheben möchten. Oder Sie können sie nutzen, um zu verdeutlichen, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind.

![overview_image](seczoomsel.png)

Für Abschnitts‑Zoom‑Objekte stellt Aspose.Slides die [SectionZoomFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/sectionzoomframe/)‑Klasse und einige Methoden in der [ShapeCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/)‑Klasse bereit.

### **Abschnitts‑Zoom‑Frames erstellen**

Sie können einen Abschnitts‑Zoom‑Frame zu einer Folie wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie dem erstellten Folie einen unverwechselbaren Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten.
5. Fügen Sie einen Abschnitts‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python‑Code zeigt Ihnen, wie Sie einen Zoom‑Frame auf einer Folie erstellen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Fügt eine neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Fügt einen neuen Abschnitt zur Präsentation hinzu
    presentation.getSections().addSection("Section 1", slide)

    #  Fügt ein SectionZoomFrame-Objekt hinzu
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Speichert die Präsentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Abschnitts‑Zoom‑Frames mit benutzerdefinierten Bildern erstellen**

Mit Aspose.Slides für Python via Java können Sie einen Abschnitts‑Zoom‑Frame mit einem anderen Folien‑Vorschau‑Bild wie folgt erstellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie dem erstellten Folie einen unverwechselbaren Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten.
5. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/)‑Objekt, indem Sie ein Bild zur Bildersammlung des [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
6. Fügen Sie einen Abschnitts‑Zoom‑Frame (der einen Verweis auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
7. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python‑Code zeigt Ihnen, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Fügt neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Fügt einen neuen Abschnitt zur Präsentation hinzu
    presentation.getSections().addSection("Section 1", slide)

    #  Erstellt ein neues Bild für das Zoom-Objekt
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Fügt SectionZoomFrame-Objekt hinzu
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Speichert die Präsentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Abschnitts‑Zoom‑Frames formatieren**

Um komplexere Abschnitts‑Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnitts‑Zoom‑Frame anwenden können.

Sie können die Formatierung eines Abschnitts‑Zoom‑Frames auf einer Folie wie folgt steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie dem erstellten Folie einen unverwechselbaren Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten.
5. Fügen Sie einen Abschnitts‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Ändern Sie die Größe und Position des erstellten Abschnitts‑Zoom‑Objekts.
7. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/)‑Objekt, indem Sie ein Bild zur Bildersammlung des [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
8. Legen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt fest.
9. Aktivieren Sie die *Rückkehr zur ursprünglichen Folie aus dem verlinkten Abschnitt*.
10. Entfernen Sie den Hintergrund eines Bildes des Abschnitts‑Zoom‑Frame‑Objekts.
11. Ändern Sie das Linienformat für das Abschnitts‑Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Fügt eine neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Fügt einen neuen Abschnitt zur Präsentation hinzu
    presentation.getSections().addSection("Section 1", slide)

    #  Fügt SectionZoomFrame-Objekt hinzu
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Formatierung für SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Speichert die Präsentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zusammenfassungs‑Zoom**

Ein Zusammenfassungs‑Zoom ist wie eine Startseite, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Beim Präsentieren können Sie den Zoom verwenden, um von einer Stelle Ihrer Präsentation zu einer anderen in beliebiger Reihenfolge zu springen. Sie können kreativ sein, vorspringen oder Teile Ihrer Vorführung erneut besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungs‑Zoom‑Objekte stellt Aspose.Slides die [SummaryZoomFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/de/python-java/aspose.slides/summaryzoomsection/), und [SummaryZoomSectionCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/summaryzoomsectioncollection/)-Klassen sowie einige Methoden in der [ShapeCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/)‑Klasse bereit.

### **Ein Zusammenfassungs‑Zoom erstellen**

Sie können einen Zusammenfassungs‑Zoom‑Frame zu einer Folie wie folgt hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie neue Folien mit einem unverwechselbaren Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie den Zusammenfassungs‑Zoom‑Frame zur ersten Folie hinzu.
4. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python‑Code zeigt Ihnen, wie Sie einen Zusammenfassungs‑Zoom‑Frame auf einer Folie erstellen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Fügt eine neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Fügt einen neuen Abschnitt zur Präsentation hinzu
    presentation.getSections().addSection("Section 1", slide)

    # Fügt eine neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Fügt einen neuen Abschnitt zur Präsentation hinzu
    presentation.getSections().addSection("Section 2", slide)

    # Fügt eine neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Fügt einen neuen Abschnitt zur Präsentation hinzu
    presentation.getSections().addSection("Section 3", slide)

    # Fügt eine neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Fügt einen neuen Abschnitt zur Präsentation hinzu
    presentation.getSections().addSection("Section 4", slide)

    #  Fügt ein SummaryZoomFrame-Objekt hinzu
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Speichert die Präsentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Eine Zusammenfassungs‑Zoom‑Sektion hinzufügen und entfernen**

Alle Sektionen in einem Zusammenfassungs‑Zoom‑Frame werden durch [SummaryZoomSection]-Objekte dargestellt, die im [SummaryZoomSectionCollection]-Objekt gespeichert sind. Sie können eine Zusammenfassungs‑Zoom‑Sektion über die [SummaryZoomSectionCollection]-Klasse wie folgt hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie neue Folien mit einem unverwechselbaren Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungs‑Zoom‑Frame in die erste Folie ein.
4. Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5. Fügen Sie den erstellten Abschnitt zum Zusammenfassungs‑Zoom‑Frame hinzu.
6. Entfernen Sie die erste Sektion aus dem Zusammenfassungs‑Zoom‑Frame.
7. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Fügt eine neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Fügt einen neuen Abschnitt zur Präsentation hinzu
    presentation.getSections().addSection("Section 1", slide)

    # Fügt eine neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Fügt einen neuen Abschnitt zur Präsentation hinzu
    presentation.getSections().addSection("Section 2", slide)

    #  Fügt SummaryZoomFrame-Objekt hinzu
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Fügt eine neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Fügt einen neuen Abschnitt zur Präsentation hinzu
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Fügt dem Summary Zoom einen Abschnitt hinzu
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Entfernt einen Abschnitt aus dem Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Speichert die Präsentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zusammenfassungs‑Zoom‑Sektionen formatieren**

Um komplexere Zusammenfassungs‑Zoom‑Sektion‑Objekte zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungs‑Zoom‑Sektion‑Objekt anwenden können.

Sie können die Formatierung eines Zusammenfassungs‑Zoom‑Sektion‑Objekts in einem Zusammenfassungs‑Zoom‑Frame wie folgt steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Erstellen Sie neue Folien mit einem unverwechselbaren Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungs‑Zoom‑Frame zur ersten Folie hinzu.
4. Rufen Sie das erste Zusammenfassungs‑Zoom‑Sektion‑Objekt aus der [SummaryZoomSectionCollection] ab.
5. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/)‑Objekt, indem Sie ein Bild zur Bildersammlung des [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Objekts hinzufügen, das zum Befüllen des Frames verwendet wird.
6. Legen Sie ein benutzerdefiniertes Bild für das Zusammenfassungs‑Zoom‑Sektion‑Objekt fest.
7. Aktivieren Sie die *Rückkehr zur ursprünglichen Folie aus dem verlinkten Abschnitt*.
8. Ändern Sie das Linienformat für das Zusammenfassungs‑Zoom‑Sektion‑Objekt.
9. Ändern Sie die Übergangsdauer.
10. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Fügt eine neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Fügt einen neuen Abschnitt zur Präsentation hinzu
    presentation.getSections().addSection("Section 1", slide)

    # Fügt eine neue Folie zur Präsentation hinzu
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Fügt einen neuen Abschnitt zur Präsentation hinzu
    presentation.getSections().addSection("Section 2", slide)

    #  Fügt ein SummaryZoomFrame-Objekt hinzu
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Holt das erste SummaryZoomSection-Objekt
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  Formatierung für das SummaryZoomSection-Objekt
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Speichert die Präsentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich die Rückkehr zur „Eltern“-Folie nach dem Anzeigen des Ziels steuern?**

Ja. Der [ZoomFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/zoomframe/) oder [SectionZoomFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/sectionzoomframe/) unterstützt die Rückkehr zur Ausgangsfolie über [setReturnToParent](https://reference.aspose.com/slides/de/python-java/aspose.slides/zoomobject/#setReturnToParent), das die Betrachter nach dem Besuch des Zielinhalts zurückführt, wenn es aktiviert ist.

**Kann ich die „Geschwindigkeit“ oder Dauer des Zoom‑Übergangs anpassen?**

Ja. Zoom unterstützt das Festlegen einer Übergangsdauer mit [setTransitionDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/zoomobject/#setTransitionDuration), sodass Sie steuern können, wie lange die Sprunganimation dauert.

**Gibt es Begrenzungen, wie viele Zoom‑Objekte eine Präsentation enthalten kann?**

Es gibt kein festes API‑Limit laut Dokumentation. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistung des Betrachters ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.