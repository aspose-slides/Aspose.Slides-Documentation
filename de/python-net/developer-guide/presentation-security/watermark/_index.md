---
title: Add Watermarks to Presentations in Python
linktitle: Watermark
type: docs
weight: 40
url: /de/python-net/developer-guide/presentation-security/watermark/
keywords:
- watermark
- text watermark
- image watermark
- add watermark
- change watermark
- remove watermark
- delete watermark
- add watermark to PPT
- add watermark to PPTX
- add watermark to ODP
- remove watermark from PPT
- remove watermark from PPTX
- remove watermark from ODP
- delete watermark from PPT
- delete watermark from PPTX
- delete watermark from ODP
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to manage text and image watermarks in PowerPoint and OpenDocument presentations in Python to indicate a draft, confidential information, copyright, and more."
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder auf allen Folien einer Präsentation verwendet wird. Üblicherweise dient ein Wasserzeichen dazu, anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Entwurf“-Wasserzeichen), vertrauliche Informationen enthält (z. B. ein „Vertraulich“-Wasserzeichen), zu welchem Unternehmen sie gehört (z. B. ein „Firmenname“-Wasserzeichen) oder den Autor der Präsentation zu identifizieren. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT, PPTX und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und deren Design und Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen die Klasse [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) verwenden sollten und zum Hinzufügen von Bildwasserzeichen die Klasse [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) oder das Füllen einer Wasserzeichenform mit einem Bild. `PictureFrame` implementiert die Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) und ermöglicht Ihnen die Nutzung aller flexiblen Einstellungen des Shape‑Objekts. Da `TextFrame` kein Shape ist und seine Einstellungen begrenzt sind, wird es in ein [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Objekt eingewickelt.

Ein Wasserzeichen kann auf zwei Arten angewendet werden: auf einer einzelnen Folie oder auf allen Folien der Präsentation. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Folien der Präsentation anzuwenden – das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und anschließend auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu bearbeiten.

Ein Wasserzeichen wird normalerweise als nicht bearbeitbar für andere Benutzer betrachtet. Um zu verhindern, dass das Wasserzeichen (bzw. die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Sperrfunktion für Shapes. Ein bestimmtes Shape kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichenshape auf dem Folienmaster gesperrt ist, ist sie auf allen Folien der Präsentation gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es später anhand dieses Namens in den Folien‑Shapes finden und bei Bedarf löschen können.

Das Wasserzeichen kann nach Belieben gestaltet werden; typischerweise besitzen Wasserzeichen jedoch gemeinsame Merkmale wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Im Folgenden betrachten wir, wie diese Eigenschaften in den Beispielen verwendet werden.

## **Text‑Wasserzeichen**

### **Ein Text‑Wasserzeichen zu einer Folie hinzufügen**

Um ein Text‑Wasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst ein Shape zur Folie hinzufügen und anschließend einen TextFrame zu diesem Shape. Der TextFrame wird durch die Klasse [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) repräsentiert. Dieser Typ erbt nicht von [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), das über einen breiten Satz von Eigenschaften zur flexiblen Positionierung des Wasserzeichens verfügt. Deshalb wird das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-Objekt in ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekt eingewickelt. Um dem Shape Text‑Wasserzeichen hinzuzufügen, verwenden Sie die Methode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) wie unten gezeigt.

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

Wenn Sie ein Text‑Wasserzeichen zur gesamten Präsentation (also zu allen Folien gleichzeitig) hinzufügen möchten, fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) hinzu. Der Rest der Logik entspricht dem Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – Sie erstellen ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekt und fügen anschließend das Wasserzeichen mit der Methode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) hinzu.

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

### **Transparenz der Wasserzeichen‑Form festlegen**

Standardmäßig ist die Rechteck‑Form mit Füll‑ und Linienfarbe formatiert. Die folgenden Code‑Zeilen machen die Form transparent.

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

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren; dazu können Sie folgendes tun:

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

![The text watermark](text_watermark.png)

## **Bild‑Wasserzeichen**

### **Ein Bild‑Wasserzeichen zur Präsentation hinzufügen**

Um ein Bild‑Wasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes tun:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Ein Wasserzeichen vor Bearbeitung sperren**

Falls es nötig ist, ein Wasserzeichen vor Bearbeitung zu schützen, verwenden Sie die Eigenschaft [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) des Shapes. Mit dieser Eigenschaft können Sie das Shape davor schützen, ausgewählt, in der Größe verändert, verschoben, mit anderen Elementen gruppiert, sein Text bearbeitet usw. zu werden:

```py
# Das Wasserzeichen‑Shape vor Änderungen sperren
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Ein Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Shapes über die Methode [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) festgelegt werden. Dazu rufen Sie diese Methode aus der Liste der Präsentationsfolien auf und übergeben das Shape‑Objekt sowie dessen neue Positionsnummer. Auf diese Weise lässt sich ein Shape in den Vordergrund holen oder an den Hintergrund der Folie senden. Diese Funktion ist besonders nützlich, wenn Sie das Wasserzeichen vor dem restlichen Inhalt der Präsentation platzieren möchten:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Wasserzeichen‑Drehung festlegen**

Im Folgenden ein Code‑Beispiel, wie die Drehung des Wasserzeichens so angepasst werden kann, dass es diagonal über die Folie verläuft:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Setzen eines Shape‑Namens. Durch die Verwendung des Shape‑Namens können Sie das Wasserzeichen später wiederfinden, um es zu ändern oder zu löschen. Um den Namen der Wasserzeichen‑Shape zu setzen, weisen Sie ihn der Eigenschaft [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) zu:

```py
watermark_shape.name = "watermark"
```

## **Ein Wasserzeichen entfernen**

Um das Wasserzeichen‑Shape zu entfernen, verwenden Sie die Methode [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) zum Finden in den Folien‑Shapes. Anschließend übergeben Sie das gefundene Shape an die Methode [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Ein Live‑Beispiel**

Probieren Sie die **Aspose.Slides free**‑Tools **[Add Watermark](https://products.aspose.app/slides/watermark)** und **[Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark)** online aus.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**Was ist ein Wasserzeichen und warum sollte ich es verwenden?**

Ein Wasserzeichen ist ein Text‑ oder Bild‑Overlay, das auf Folien angewendet wird, um geistiges Eigentum zu schützen, die Markenbekanntheit zu steigern oder die unautorisierte Nutzung von Präsentationen zu verhindern.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht das Hinzufügen eines Wasserzeichens zu jeder Folie einer Präsentation. Sie können über alle Folien iterieren und die Wasserzeichen‑Einstellungen einzeln anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Sie können die Transparenz des Wasserzeichens ändern, indem Sie die Füll‑Einstellungen ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) des Shapes anpassen. So bleibt das Wasserzeichen dezent und lenkt nicht vom Inhalt der Folie ab.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

**Kann ich die Schriftart und den Stil eines Text‑Wasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und jeden Stil wählen, um das Design Ihrer Präsentation anzupassen und die Marken‑Konsistenz zu wahren.

**Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?**

Sie können die Position und Ausrichtung des Wasserzeichens ändern, indem Sie die Koordinaten, Größe und Drehungs‑Eigenschaften des [shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Objekts anpassen.