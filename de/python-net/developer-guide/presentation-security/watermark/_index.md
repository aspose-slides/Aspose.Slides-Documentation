---
title: Wasserzeichen zu Präsentationen in Python hinzufügen
linktitle: Wasserzeichen
type: docs
weight: 40
url: /de/python-net/watermark/
keywords:
- Wasserzeichen
- Text-Wasserzeichen
- Bild-Wasserzeichen
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
description: "Erfahren Sie, wie Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument-Präsentationen in Python verwalten, um Entwürfe, vertrauliche Informationen, Urheberrecht und mehr anzuzeigen."
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text- oder Bildstempel, der auf einer Folie oder über alle Folien einer Präsentation verwendet wird. Üblicherweise wird ein Wasserzeichen eingesetzt, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Entwurf“-Wasserzeichen), vertrauliche Informationen enthält (z. B. ein „Vertraulich“-Wasserzeichen), zu welchem Unternehmen sie gehört (z. B. ein „Firmenname“-Wasserzeichen), den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen trägt dazu bei, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT-, PPTX- und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und ihr Design sowie Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen die Klasse [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) verwenden und zum Hinzufügen von Bildwasserzeichen die Klasse [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) oder das Füllen einer Wasserzeichenform mit einem Bild. `PictureFrame` implementiert die Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), sodass Sie alle flexiblen Einstellungen des Formobjekts nutzen können. Da `TextFrame` keine Form ist und nur begrenzte Einstellungen hat, wird es in ein [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Objekt eingewickelt.

Ein Wasserzeichen kann auf zwei Arten angewendet werden: auf einer einzelnen Folie oder auf allen Folien der Präsentation. Der Folienmaster wird verwendet, um ein Wasserzeichen auf allen Folien anzuwenden – das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu bearbeiten.

Ein Wasserzeichen gilt in der Regel als nicht editierbar für andere Benutzer. Um zu verhindern, dass das Wasserzeichen (bzw. die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Form‑Sperrungs‑Funktionalität. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichenform auf dem Folienmaster gesperrt ist, ist sie auf allen Folien gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es später anhand dieses Namens in den Folienformen finden und bei Bedarf löschen können.

Sie können das Wasserzeichen nach Belieben gestalten; typischerweise besitzen Wasserzeichen jedoch gemeinsame Merkmale wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Im Folgenden zeigen wir, wie Sie diese Aspekte in den Beispielen nutzen können.

## **Text‑Wasserzeichen**

### **Ein Text‑Wasserzeichen zu einer Folie hinzufügen**

Um ein Text‑Wasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und anschließend einen Textrahmen zu dieser Form. Der Textrahmen wird durch die Klasse [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) repräsentiert. Dieser Typ erbt nicht von [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), das einen großen Satz von Eigenschaften für die flexible Positionierung des Wasserzeichens bietet. Deshalb wird das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-Objekt in ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekt eingewickelt. Um Text zum Wasserzeichen hinzuzufügen, verwenden Sie die Methode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) wie unten gezeigt.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man die TextFrame‑Klasse verwendet](/slides/de/python-net/text-formatting/)
{{% /alert %}}

### **Ein Text‑Wasserzeichen zur gesamten Präsentation hinzufügen**

Wenn Sie ein Text‑Wasserzeichen zur gesamten Präsentation (also allen Folien gleichzeitig) hinzufügen möchten, fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) hinzu. Der Rest der Logik ist identisch zum Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – erstellen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekt und fügen Sie das Wasserzeichen mit der Methode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) hinzu.

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

### **Transparenz der Wasserzeichenform festlegen**

Standardmäßig ist die Rechteckform mit Füll‑ und Linienfarbe gestaltet. Die folgenden Zeilen machen die Form transparent.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Schriftart für ein Text‑Wasserzeichen festlegen**

Sie können die Schriftart des Text‑Wasserzeichens wie folgt ändern.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Farbe des Wasserzeichentextes festlegen**

Um die Farbe des Wasserzeichentextes zu setzen, verwenden Sie folgenden Code:

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

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren. Dazu können Sie Folgendes tun:

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

Das untenstehende Bild zeigt das Endergebnis.

![Das Text‑Wasserzeichen](text_watermark.png)

## **Bild‑Wasserzeichen**

### **Ein Bild‑Wasserzeichen zur Präsentation hinzufügen**

Um ein Bild‑Wasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie folgendes tun:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Ein Wasserzeichen vor Bearbeitung sperren**

Falls es erforderlich ist, ein Wasserzeichen vor Bearbeitung zu schützen, verwenden Sie die Eigenschaft [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) der Form. Mit dieser Eigenschaft können Sie verhindern, dass die Form ausgewählt, in der Größe verändert, repositioniert, mit anderen Elementen gruppiert, ihr Text bearbeitet wird und vieles mehr:

```py
# Sperren der Wasserzeichenform vor Änderungen
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Ein Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Formen über die Methode [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) festgelegt werden. Hierzu rufen Sie diese Methode aus der Folienliste der Präsentation auf und übergeben die Referenz der Form sowie deren neue Reihenfolgen‑Nummer. Auf diese Weise kann eine Form nach vorne oder nach hinten verschoben werden – besonders nützlich, wenn das Wasserzeichen im Vordergrund der Folie stehen soll:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Wasserzeichenrotation festlegen**

Im folgenden Beispiel wird gezeigt, wie die Drehung des Wasserzeichens angepasst wird, sodass es diagonal über die Folie verläuft:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Festlegen eines Namens für eine Form. Durch den Namen können Sie die Form später wiederfinden, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichenform zu setzen, weisen Sie ihn der Eigenschaft [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) zu:

```py
watermark_shape.name = "watermark"
```

## **Ein Wasserzeichen entfernen**

Um die Wasserzeichenform zu entfernen, verwenden Sie die Methode [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) nicht, sondern suchen Sie die Form anhand ihres Namens in den Folienformen und entfernen Sie sie anschließend mit [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Ein Live‑Beispiel**

Probieren Sie die **Aspose.Slides‑Kostenlos**‑Tools **[Wasserzeichen hinzufügen]**(https://products.aspose.app/slides/watermark) und **[Wasserzeichen entfernen]**(https://products.aspose.app/slides/watermark/remove-watermark) online aus.

![Online‑Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)

## **FAQ**

**Was ist ein Wasserzeichen und warum sollte ich es verwenden?**

Ein Wasserzeichen ist ein Text‑ oder Bild‑Overlay, das auf Folien angewendet wird und geistiges Eigentum schützt, die Markenbekanntheit stärkt oder die unbefugte Nutzung von Präsentationen verhindert.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht das Hinzufügen eines Wasserzeichens zu jeder Folie einer Präsentation. Sie können über alle Folien iterieren und die Wasserzeicheneinstellungen einzeln anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Sie können die Transparenz des Wasserzeichens ändern, indem Sie die Füll‑Einstellungen ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) der Form modifizieren. So bleibt das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

**Kann ich die Schriftart und den Stil eines Text‑Wasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und jeden Stil wählen, um das Design Ihrer Präsentation und die Marken‑Konsistenz zu wahren.

**Wie ändere ich die Position oder Orientierung eines Wasserzeichens?**

Sie können die Position und Orientierung des Wasserzeichens ändern, indem Sie die Koordinaten, Größe und Drehungs‑Eigenschaften der [Form](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) anpassen.