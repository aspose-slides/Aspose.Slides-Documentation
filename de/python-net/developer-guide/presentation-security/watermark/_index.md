---
title: Wasserzeichen zu Präsentationen in Python hinzufügen
linktitle: Wasserzeichen
type: docs
weight: 40
url: /de/python-net/watermark/
keywords:
- wasserzeichen
- text wasserzeichen
- bild wasserzeichen
- wasserzeichen hinzufügen
- wasserzeichen ändern
- wasserzeichen entfernen
- wasserzeichen löschen
- wasserzeichen zu PPT hinzufügen
- wasserzeichen zu PPTX hinzufügen
- wasserzeichen zu ODP hinzufügen
- wasserzeichen von PPT entfernen
- wasserzeichen von PPTX entfernen
- wasserzeichen von ODP entfernen
- wasserzeichen von PPT löschen
- wasserzeichen von PPTX löschen
- wasserzeichen von ODP löschen
- PowerPoint
- OpenDocument
- präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument-Präsentationen mit Python verwalten, um Entwürfe, vertrauliche Informationen, Urheberrechte und mehr zu kennzeichnen."
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder über alle Folien hinweg verwendet wird. Üblicherweise wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Entwurf“-Wasserzeichen), vertrauliche Informationen enthält (z. B. ein „Vertraulich“-Wasserzeichen), zu welchem Unternehmen sie gehört (z. B. ein „Firmenname“-Wasserzeichen) oder den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT, PPTX und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und ihr Design sowie Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen die Klasse [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) verwenden und zum Hinzufügen von Bildwasserzeichen die Klasse [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) oder das Füllen einer Wasserzeichnungsform mit einem Bild. `PictureFrame` implementiert die Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), sodass Sie alle flexiblen Einstellungen des Shape‑Objekts nutzen können. Da `TextFrame` kein Shape ist und seine Einstellungen begrenzt sind, wird es in ein [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Objekt eingewickelt.

Ein Wasserzeichen kann auf zwei Arten angewendet werden: auf einer einzelnen Folie oder auf allen Folien einer Präsentation. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Folien anzuwenden – das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und anschließend auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu ändern.

Ein Wasserzeichen wird in der Regel als nicht editierbar für andere Benutzer betrachtet. Um zu verhindern, dass das Wasserzeichen (bzw. das übergeordnete Shape des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Shape‑Sperrfunktionalität. Ein bestimmtes Shape kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wird das Wasserzeichen‑Shape auf dem Folienmaster gesperrt, ist es auf allen Folien gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es später anhand des Namens in den Folien‑Shapes finden und ggf. löschen können.

Sie können das Wasserzeichen beliebig gestalten; typischerweise weisen Wasserzeichen jedoch gemeinsame Merkmale wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. auf. Im Folgenden sehen Sie, wie Sie diese in den Beispielen nutzen können.

## **Text‑Wasserzeichen**

### **Ein Text‑Wasserzeichen zu einer Folie hinzufügen**

Um ein Text‑Wasserzeichen in PPT, PPTX oder ODP hinzuzufügen, fügen Sie zunächst ein Shape zur Folie hinzu und dann einen TextFrame zu diesem Shape. Der TextFrame wird durch die Klasse [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) repräsentiert. Dieser Typ erbt nicht von [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), das über zahlreiche Eigenschaften zur flexiblen Positionierung des Wasserzeichens verfügt. Daher wird das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-Objekt in ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekt eingebettet. Um Text zum Shape hinzuzufügen, verwenden Sie die Methode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) wie unten gezeigt.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man die TextFrame-Klasse verwendet](/slides/de/python-net/text-formatting/)
{{% /alert %}}

### **Ein Text‑Wasserzeichen zu einer gesamten Präsentation hinzufügen**

Wenn Sie ein Text‑Wasserzeichen der gesamten Präsentation hinzufügen möchten (also allen Folien gleichzeitig), fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) hinzu. Der übrige Ablauf ist identisch zum Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – erstellen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekt und fügen Sie das Wasserzeichen mit der Methode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) hinzu.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man den Folienmaster verwendet](/slides/de/python-net/slide-master/)
{{% /alert %}}

### **Transparenz des Wasserzeichen‑Shapes festlegen**

Standardmäßig ist das Rechteck‑Shape mit Füll‑ und Linienfarbe formatiert. Die folgenden Zeilen machen das Shape transparent.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Schriftart für ein Text‑Wasserzeichen festlegen**

Sie können die Schriftart des Text‑Wasserzeichens wie unten gezeigt ändern.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Farbe des Wasserzeichen‑Texts festlegen**

Um die Farbe des Wasserzeichen‑Texts zu setzen, verwenden Sie diesen Code:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Ein Text‑Wasserzeichen zentrieren**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren. Dafür können Sie folgendes tun:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

Das Bild unten zeigt das Endergebnis.

![Das Text‑Wasserzeichen](text_watermark.png)

## **Bild‑Wasserzeichen**

### **Ein Bild‑Wasserzeichen zu einer Präsentation hinzufügen**

Um ein Bild‑Wasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie folgendes tun:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Ein Wasserzeichen vor Bearbeitung sperren**

Falls ein Wasserzeichen nicht bearbeitet werden soll, verwenden Sie die Eigenschaft [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) des Shapes. Mit dieser Eigenschaft können Sie das Shape davor schützen, ausgewählt, in der Größe verändert, neu positioniert, mit anderen Elementen gruppiert, sein Text bearbeitet usw. zu werden:

```py
# Das Wasserzeichen‑Shape vor Änderungen sperren
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Ein Wasserzeichen in den Vordergrund holen**

In Aspose.Slides kann die Z‑Reihenfolge von Shapes über die Methode [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) festgelegt werden. Rufen Sie diese Methode von der Präsentations‑Slide‑Liste auf und übergeben Sie die Shape‑Referenz sowie deren neue Reihenfolgen‑Nummer. So lässt sich ein Shape nach vorne oder nach hinten verschieben – nützlich, wenn das Wasserzeichen vor dem Rest der Folie angezeigt werden soll:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Drehung des Wasserzeichens festlegen**

Im folgenden Beispiel wird gezeigt, wie Sie die Drehung des Wasserzeichens anpassen, sodass es diagonal über die Folie verläuft:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Setzen eines Shape‑Namens. Mit dem Shape‑Namen können Sie das Wasserzeichen später wiederfinden, um es zu ändern oder zu löschen. Setzen Sie den Namen des Wasserzeichen‑Shapes über die Eigenschaft [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **Ein Wasserzeichen entfernen**

Um das Wasserzeichen‑Shape zu entfernen, verwenden Sie die Methode [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) zum Suchen in den Folien‑Shapes. Anschließend übergeben Sie das gefundene Shape an die Methode [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Ein Live‑Beispiel**

Probieren Sie die **Aspose.Slides‑kostenlosen** Online‑Tools **[Watermark hinzufügen]**(https://products.aspose.app/slides/watermark) und **[Watermark entfernen]**(https://products.aspose.app/slides/watermark/remove-watermark) aus.

![Online‑Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)

## **FAQ**

**Was ist ein Wasserzeichen und warum sollte ich es verwenden?**

Ein Wasserzeichen ist ein Text‑ oder Bild‑Overlay, das Folien überlagert und dabei hilft, geistiges Eigentum zu schützen, die Markenbekanntheit zu steigern oder unbefugte Nutzung von Präsentationen zu verhindern.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht das Hinzufügen eines Wasserzeichens zu jeder Folie einer Präsentation. Sie können über alle Folien iterieren und die Wasserzeichen‑Einstellungen einzeln anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Sie können die Transparenz des Wasserzeichens ändern, indem Sie die Füll‑Einstellungen ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) des Shapes anpassen. Dadurch bleibt das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

**Kann ich die Schriftart und den Stil eines Text‑Wasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und jeden Stil wählen, um das Design Ihrer Präsentation zu ergänzen und Marken­konsistenz zu wahren.

**Wie ändere ich die Position oder Orientierung eines Wasserzeichens?**

Sie können die Position und Orientierung des Wasserzeichens ändern, indem Sie die Koordinaten, Größe und Drehungs‑Eigenschaften des [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Elements anpassen.