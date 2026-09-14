---
title: Wasserzeichen zu Präsentationen in Python hinzufügen
linktitle: Wasserzeichen
type: docs
weight: 40
url: /de/python-java/watermark/
keywords:
- Wasserzeichen
- Textwasserzeichen
- Bildwasserzeichen
- Wasserzeichen hinzufügen
- Wasserzeichen ändern
- Wasserzeichen entfernen
- Wasserzeichen löschen
- Wasserzeichen zu PPT hinzufügen
- Wasserzeichen zu PPTX hinzufügen
- Wasserzeichen zu ODP hinzufügen
- Wasserzeichen aus PPT entfernen
- Wasserzeichen aus PPTX entfernen
- Wasserzeichen aus ODP entfernen
- Wasserzeichen aus PPT löschen
- Wasserzeichen aus PPTX löschen
- Wasserzeichen aus ODP löschen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument-Präsentationen mit Python, um Entwürfe, vertrauliche Informationen, Urheberrechte und mehr anzuzeigen."
---
## **Einführung**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder über alle Folien einer Präsentation verwendet wird. Üblicherweise dient ein Wasserzeichen dazu, anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Entwurf“-Wasserzeichen), vertrauliche Informationen enthält (z. B. ein „Vertraulich“-Wasserzeichen), zu welchem Unternehmen sie gehört (z. B. ein „Firmenname“-Wasserzeichen), den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT, PPTX und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/de/python-java/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und ihr Design sowie Verhalten zu ändern. Der gemeinsame Punkt ist, dass zum Hinzufügen von Textwasserzeichen die [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/)‑Klasse verwendet werden sollte und zum Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/)‑Klasse oder das Füllen einer Wasserzeichen‑Form mit einem Bild. [PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/) erbt von der [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/)‑Klasse, sodass Sie alle flexiblen Einstellungen des Shape‑Objekts nutzen können. Da [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) kein Shape ist und seine Einstellungen begrenzt sind, wird es in ein [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/)‑Objekt eingebettet.

Es gibt zwei Möglichkeiten, ein Wasserzeichen anzuwenden: auf einer einzelnen Folie oder auf allen Folien der Präsentation. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Folien anzuwenden – das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu bearbeiten.

Ein Wasserzeichen gilt in der Regel als für andere Benutzer nicht bearbeitbar. Um zu verhindern, dass das Wasserzeichen (bzw. das übergeordnete Shape des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Shape‑Sperrfunktionalität. Ein bestimmtes Shape kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn das Wasserzeichen‑Shape auf dem Folienmaster gesperrt ist, wird es auf allen Folien der Präsentation gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es später anhand des Namens unter den Shapes der Folie finden und bei Bedarf löschen können.

Das Wasserzeichen kann nach Belieben gestaltet werden; üblich sind jedoch Eigenschaften wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Wie man diese in den nachfolgenden Beispielen verwendet, wird erläutert.

## **Textwasserzeichen**

### **Ein Textwasserzeichen zu einer Folie hinzufügen**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zuerst ein Shape zur Folie hinzufügen und anschließend einen TextFrame zu diesem Shape. Der TextFrame wird durch die [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/)‑Klasse repräsentiert. Dieser Typ erbt nicht von [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/), das über einen breiten Satz von Eigenschaften zur flexiblen Positionierung des Wasserzeichens verfügt. Deshalb wird das [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/)‑Objekt in ein [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/)‑Objekt eingebettet. Um Wasserzeichentext zum Shape hinzuzufügen, verwenden Sie die Methode [addTextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/#addTextFrame) wie unten gezeigt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Wie man die TextFrame-Klasse verwendet](/slides/de/python-java/text-formatting/)
{{% /alert %}}

### **Ein Textwasserzeichen zu einer Präsentation hinzufügen**

Wenn Sie ein Textwasserzeichen der gesamten Präsentation hinzufügen möchten (also allen Folien gleichzeitig), fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/) hinzu. Der Rest der Logik entspricht dem Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – Sie erstellen ein [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/)‑Objekt und fügen das Wasserzeichen mithilfe der Methode [addTextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/#addTextFrame) hinzu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Wie man den Folienmaster verwendet](/slides/de/python-java/slide-master/)
{{% /alert %}}

### **Transparenz der Wasserzeichenform festlegen**

Standardmäßig ist das Rechteck‑Shape mit Füll‑ und Linienfarben gestaltet. Die folgenden Codezeilen machen das Shape transparent.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **Schriftart für ein Textwasserzeichen festlegen**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **Farbe des Wasserzeichen‑Texts festlegen**

Um die Farbe des Wasserzeichen‑Texts zu setzen, verwenden Sie diesen Code:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Textwasserzeichen zentrieren**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren; dazu können Sie Folgendes tun:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

Das Bild unten zeigt das Endergebnis.

![Das Textwasserzeichen](text_watermark.png)

## **Bildwasserzeichen**

### **Ein Bildwasserzeichen zu einer Präsentation hinzufügen**

Um ein Bildwasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes ausführen:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Wasserzeichen vor Bearbeitung sperren**

Falls es notwendig ist, ein Wasserzeichen vor Bearbeitung zu schützen, verwenden Sie die Methode [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/#getAutoShapeLock) am Shape. Mit dieser Eigenschaft können Sie das Shape davor schützen, ausgewählt, in der Größe geändert, neu positioniert, mit anderen Elementen gruppiert, der Text gesperrt usw. zu werden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Sperrt das Wasserzeichen-Shape vor Änderungen.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Shapes über die Methode [ShapeCollection.reorder](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#reorder) festgelegt werden. Dafür rufen Sie diese Methode aus der Shape‑Collection der Folie auf und übergeben die Shape‑Referenz sowie deren Reihenfolgenummer. Auf diese Weise lässt sich ein Shape in den Vordergrund holen oder in den Hintergrund der Folie senden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor dem Rest der Präsentation platzieren möchten:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **Wasserzeichenrotation festlegen**

Im Folgenden ein Codebeispiel, wie die Drehung des Wasserzeichens so angepasst wird, dass es diagonal über die Folie verläuft:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Setzen eines Shape‑Namens. Durch die Verwendung des Shape‑Namens können Sie das Shape später zum Ändern oder Löschen ansprechen. Um den Namen des Wasserzeichen‑Shapes zu setzen, übergeben Sie ihn an die Methode [Shape.setName](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#setName):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Ein Wasserzeichen entfernen**

Um das Wasserzeichen‑Shape zu entfernen, nutzen Sie die Methode [Shape.getName](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getName), um es in den Folien‑Shapes zu finden. Anschließend übergeben Sie das Wasserzeichen‑Shape an die Methode [ShapeCollection.remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#remove):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **FAQ**

**Was ist ein Wasserzeichen und warum sollte ich es verwenden?**

Ein Wasserzeichen ist ein Text‑ oder Bildüberlagerung, die auf Folien angewendet wird, um geistiges Eigentum zu schützen, die Markenbekanntheit zu steigern oder die unautorisierte Nutzung von Präsentationen zu verhindern.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht das programmgesteuerte Hinzufügen eines Wasserzeichens zu jeder Folie einer Präsentation. Sie können alle Folien iterieren und die Wasserzeicheneinstellungen einzeln anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Sie können die Transparenz des Wasserzeichens anpassen, indem Sie die Fülleigenschaften ([getFillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getFillFormat)) des Shapes ändern. So bleibt das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

**Kann ich die Schriftart und den Stil eines Textwasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und Stil wählen, um das Design Ihrer Präsentation anzupassen und die Marken­konsistenz zu wahren.

**Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?**

Sie können die Position und Ausrichtung eines Wasserzeichens programmgesteuert ändern, indem Sie die Koordinaten, Größe und Drehungseigenschaften des Shapes anpassen.