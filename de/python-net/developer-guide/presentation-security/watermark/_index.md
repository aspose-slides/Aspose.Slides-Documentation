---
title: Wasserzeichen
type: docs
weight: 40
url: /de/python-net/watermark/
keywords:
- wasserzeichen
- wasserzeichen hinzufügen
- textwasserzeichen
- bildwasserzeichen
- PowerPoint
- präsentation
- Python
- Aspose.Slides für Python über .NET
description: "Fügen Sie Text- und Bildwasserzeichen zu PowerPoint-Präsentationen in Python hinzu"
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text- oder Bildstempel, der auf einer Folie oder auf allen Präsentationsfolien verwendet wird. Üblicherweise wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z.B. ein „Entwurf“-Wasserzeichen), dass sie vertrauliche Informationen enthält (z.B. ein „Vertraulich“-Wasserzeichen), um anzugeben, welchem Unternehmen sie gehört (z.B. ein „Unternehmensname“-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden sollte. Wasserzeichen werden sowohl in PowerPoint- als auch in OpenOffice-Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint PPT, PPTX und OpenOffice ODP-Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint- oder OpenOffice-Dokumenten zu erstellen und deren Design und Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zur Hinzufügung von Textwasserzeichen die [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) Klasse verwenden sollten, und um Bildwasserzeichen hinzuzufügen, verwenden Sie die [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) Klasse oder füllen eine Wasserzeichenform mit einem Bild. `PictureFrame` implementiert die [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) Klasse, die es Ihnen ermöglicht, alle flexiblen Einstellungen des Formobjekts zu verwenden. Da `TextFrame` keine Form ist und seine Einstellungen eingeschränkt sind, wird es in ein [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) Objekt eingekapselt.

Ein Wasserzeichen kann auf zwei Arten angewendet werden: auf einer einzelnen Folie oder auf allen Präsentationsfolien. Der Folienmaster wird verwendet, um ein Wasserzeichen auf allen Präsentationsfolien anzuwenden – das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Berechtigung zum Ändern des Wasserzeichens auf einzelnen Folien zu beeinträchtigen.

Ein Wasserzeichen wird normalerweise als nicht bearbeitbar für andere Benutzer betrachtet. Um zu verhindern, dass das Wasserzeichen (oder besser gesagt, die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Funktion zum Sperren von Formen. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichenform auf dem Folienmaster gesperrt ist, ist sie auf allen Präsentationsfolien gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, damit Sie es in Zukunft, wenn Sie es löschen möchten, in den Formen der Folie nach Namen finden können.

Sie können das Wasserzeichen auf jede Weise gestalten; jedoch gibt es normalerweise häufige Merkmale in Wasserzeichen, wie z.B. zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Wir werden im Folgenden betrachten, wie man diese in den Beispielen verwendet.

## **Textwasserzeichen**

### **Fügen Sie ein Textwasserzeichen zu einer Folie hinzu**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und dann einen Textbereich zu dieser Form hinzufügen. Der Textbereich wird durch die [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) Klasse dargestellt. Dieser Typ erbt nicht von [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), die über eine breite Palette von Eigenschaften verfügt, um das Wasserzeichen flexibel zu positionieren. Daher wird das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) Objekt in ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) Objekt eingekapselt. Um dem Form Wasserzeichentext hinzuzufügen, verwenden Sie die [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) Methode, wie unten gezeigt.

```py
watermark_text = "VERTRAULICH"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man die TextFrame-Klasse verwendet](/slides/de/python-net/text-formatting/)
{{% /alert %}}

### **Fügen Sie ein Textwasserzeichen zur Präsentation hinzu**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d.h. zu allen Folien auf einmal) hinzufügen möchten, fügen Sie es zum [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) hinzu. Der Rest der Logik ist dieselbe wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – erstellen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) Objekt und fügen Sie dann das Wasserzeichen mit der [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) Methode hinzu.

```py
watermark_text = "VERTRAULICH"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man den Folienmaster verwendet](/slides/de/python-net/slide-master/)
{{% /alert %}}

### **Setzen Sie die Transparenz der Wasserzeichenform**

Standardmäßig wird die rechteckige Form mit Füll- und Linienfarben gestylt. Die folgenden Zeilen von Code machen die Form transparent.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Legen Sie die Schriftart für ein Textwasserzeichen fest**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Setzen Sie die Textfarbe des Wasserzeichens**

Um die Farbe des Wasserzeichentextes einzustellen, verwenden Sie diesen Code:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Zentrieren Sie ein Textwasserzeichen**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren, und dafür können Sie Folgendes tun:

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

![Das Textwasserzeichen](text_watermark.png)

## **Bildwasserzeichen**

### **Fügen Sie ein Bildwasserzeichen zu einer Präsentation hinzu**

Um ein Bildwasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes tun:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Sperren Sie ein Wasserzeichen vor der Bearbeitung**

Wenn es notwendig ist, zu verhindern, dass ein Wasserzeichen bearbeitet wird, verwenden Sie die [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) Eigenschaft auf der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, verschoben, neu positioniert, mit anderen Elementen gruppiert, ihre Texte vor der Bearbeitung gesperrt und vieles mehr zu werden:

```py
# Sperren Sie die Wasserzeichenform vor Änderungen
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Bringen Sie ein Wasserzeichen nach vorne**

In Aspose.Slides kann die Z-Reihenfolge von Formen über die [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) Methode festgelegt werden. Dazu müssen Sie diese Methode von der Liste der Präsentationsfolien aufrufen und die Formreferenz sowie ihre Reihenfolgenummer in die Methode übergeben. Auf diese Weise ist es möglich, eine Form nach vorne zu bringen oder sie nach hinten auf der Folie zu senden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor der Präsentation platzieren müssen:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Setzen Sie die Wasserzeichen-Drehung**

Hier ist ein Codebeispiel, wie Sie die Drehung des Wasserzeichens anpassen können, damit es diagonal über die Folie positioniert wird:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Setzen Sie einen Namen für ein Wasserzeichen**

Aspose.Slides ermöglicht es Ihnen, den Namen einer Form festzulegen. Durch die Verwendung des Formnamens können Sie in Zukunft darauf zugreifen, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichenform festzulegen, weisen Sie ihn der [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) Eigenschaft zu:

```py
watermark_shape.name = "watermark"
```

## **Entfernen Sie ein Wasserzeichen**

Um die Wasserzeichenform zu entfernen, verwenden Sie die [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) Methode, um sie in den Folienformen zu finden. Übergeben Sie dann die Wasserzeichenform an die [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) Methode:

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Ein Live-Beispiel**

Sie möchten möglicherweise die **Aspose.Slides kostenlose** [Wasserzeichen hinzufügen](https://products.aspose.app/slides/watermark) und [Wasserzeichen entfernen](https://products.aspose.app/slides/watermark/remove-watermark) Online-Tools ausprobieren.

![Online-Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)