---
title: Wasserzeichen zu Präsentationen in Python hinzufügen
linktitle: Wasserzeichen
type: docs
weight: 40
url: /de/python-net/watermark/
keywords:
- wasserzeichen
- textwasserzeichen
- bildwasserzeichen
- wasserzeichen hinzufügen
- wasserzeichen ändern
- wasserzeichen entfernen
- wasserzeichen löschen
- wasserzeichen zu ppt hinzufügen
- wasserzeichen zu pptx hinzufügen
- wasserzeichen zu odp hinzufügen
- wasserzeichen von ppt entfernen
- wasserzeichen von pptx entfernen
- wasserzeichen von odp entfernen
- wasserzeichen von ppt löschen
- wasserzeichen von pptx löschen
- wasserzeichen von odp löschen
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument‑Präsentationen in Python verwalten, um Entwürfe, vertrauliche Informationen, Urheberrecht und mehr zu kennzeichnen."
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder über alle Folien hinweg verwendet wird. Üblicherweise wird ein Wasserzeichen eingesetzt, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Draft“-Wasserzeichen), vertrauliche Informationen enthält (z. B. ein „Confidential“-Wasserzeichen), zu welchem Unternehmen sie gehört (z. B. ein „Company Name“-Wasserzeichen), den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es signalisiert, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT, PPTX und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und deren Design sowie Verhalten zu ändern. Der gemeinsame Aspekt ist, dass zum Hinzufügen von Textwasserzeichen die Klasse [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) verwendet wird und zum Hinzufügen von Bildwasserzeichen die Klasse [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) oder das Befüllen einer Wasserzeichen‑Form mit einem Bild. `PictureFrame` implementiert die Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), sodass alle flexiblen Einstellungen des Shape‑Objekts genutzt werden können. Da `TextFrame` kein Shape ist und nur begrenzte Einstellungen besitzt, wird es in ein [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Objekt eingebettet.

Ein Wasserzeichen kann auf zwei Arten angewendet werden: auf einer einzelnen Folie oder auf allen Folien der Präsentation. Der Folien‑Master wird verwendet, um ein Wasserzeichen auf alle Folien anzuwenden – das Wasserzeichen wird dem Folien‑Master hinzugefügt, dort komplett gestaltet und anschließend auf alle Folien übertragen, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu ändern.

Ein Wasserzeichen gilt in der Regel als nicht zur Bearbeitung durch andere Benutzer verfügbar. Um zu verhindern, dass das Wasserzeichen (bzw. das übergeordnete Shape) bearbeitet wird, stellt Aspose.Slides eine Shape‑Lock‑Funktionalität bereit. Ein bestimmtes Shape kann auf einer normalen Folie oder auf einem Folien‑Master gesperrt werden. Wird das Wasserzeichen‑Shape auf dem Folien‑Master gesperrt, ist es auf allen Folien gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es später anhand dieses Namens in den Shapes der Folie finden und ggf. löschen können.

Das Wasserzeichen kann nach Belieben gestaltet werden; üblicherweise besitzen Wasserzeichen jedoch gemeinsame Merkmale wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Im Folgenden sehen Sie, wie diese Eigenschaften in den Beispielen verwendet werden.

## **Textwasserzeichen**

### **Ein Textwasserzeichen zu einer Folie hinzufügen**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, fügen Sie zunächst ein Shape zur Folie hinzu und anschließend ein TextFrame zu diesem Shape. Das TextFrame wird durch die Klasse [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) repräsentiert. Dieser Typ erbt nicht von [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), das über umfangreiche Eigenschaften zur flexiblen Positionierung des Wasserzeichens verfügt. Daher wird das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-Objekt in ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekt eingebettet. Um Text zum Shape hinzuzufügen, verwenden Sie die Methode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) wie unten gezeigt.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie die TextFrame‑Klasse verwendet wird](/slides/de/python-net/text-formatting/)
{{% /alert %}}

### **Ein Textwasserzeichen zur gesamten Präsentation hinzufügen**

Wenn Sie ein Textwasserzeichen für die gesamte Präsentation (also alle Folien gleichzeitig) hinzufügen möchten, fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) hinzu. Der Rest funktioniert wie beim Hinzufügen zu einer einzelnen Folie – erstellen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekt und fügen Sie das Wasserzeichen mittels der Methode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) hinzu.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie der Folien‑Master verwendet wird](/slides/de/python-net/slide-master/)
{{% /alert %}}

### **Transparenz des Wasserzeichen‑Shapes festlegen**

Standardmäßig ist das Rechteck‑Shape mit Füll‑ und Linienfarbe versehen. Die folgenden Zeilen machen das Shape transparent.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Schriftart für ein Textwasserzeichen festlegen**

Die Schriftart des Textwasserzeichens kann wie folgt geändert werden.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Farbe des Wasserzeichentextes festlegen**

Um die Farbe des Wasserzeichentextes zu setzen, verwenden Sie diesen Code:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Textwasserzeichen zentrieren**

Das Wasserzeichen kann auf einer Folie zentriert werden. Dazu können Sie folgenden Code verwenden:

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

## **Bildwasserzeichen**

### **Ein Bildwasserzeichen zur Präsentation hinzufügen**

Um ein Bildwasserzeichen zu einer Folie hinzuzufügen, können Sie folgenden Code verwenden:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Ein Wasserzeichen vor Bearbeitung schützen**

Falls ein Wasserzeichen nicht bearbeitet werden soll, nutzen Sie die Eigenschaft [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) des Shapes. Damit können Sie das Shape davor schützen, ausgewählt, in der Größe geändert, verschoben, gruppiert, der Text gesperrt usw. zu werden:

```py
# Das Wasserzeichen‑Shape vor Änderungen schützen
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Ein Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Shapes über die Methode [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) festgelegt werden. Rufen Sie diese Methode aus der Folienliste der Präsentation auf und übergeben Sie das Shape‑Objekt sowie die Zielposition. So lässt sich ein Shape nach vorne oder nach hinten verschieben – nützlich, wenn ein Wasserzeichen vor den anderen Inhalten stehen soll:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Wasserzeichen‑Drehung festlegen**

Im folgenden Beispiel wird die Drehung des Wasserzeichens so angepasst, dass es diagonal über die Folie verläuft:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides erlaubt das Setzen eines Shape‑Namens. Damit können Sie das Shape später leichter finden, um es zu ändern oder zu löschen. Der Name wird über die Eigenschaft [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) gesetzt:

```py
watermark_shape.name = "watermark"
```

## **Ein Wasserzeichen entfernen**

Um das Wasserzeichen‑Shape zu entfernen, finden Sie es zuerst über den Namen in den Shapes der Folie und entfernen es anschließend mit [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Ein Live‑Beispiel**

Probieren Sie die kostenlosen **Aspose.Slides**‑Online‑Tools **[Watermark hinzufügen](https://products.aspose.app/slides/watermark)** und **[Watermark entfernen](https://products.aspose.app/slides/watermark/remove-watermark)** aus.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**Was ist ein Wasserzeichen und warum sollte ich es verwenden?**

Ein Wasserzeichen ist ein Text‑ oder Bild‑Overlay, das Folien überlagert und geistiges Eigentum schützt, die Markenpräsenz stärkt oder die unautorisierte Nutzung von Präsentationen verhindert.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht das Hinzufügen eines Wasserzeichens zu jeder Folie einer Präsentation. Sie können über alle Folien iterieren und die Wasserzeichen‑Einstellungen einzeln anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Die Transparenz lässt sich über die Füll‑Einstellungen ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) des Shapes ändern, sodass das Wasserzeichen dezent bleibt und den Folieninhalt nicht ablenkt.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt zahlreiche Bildformate, darunter PNG, JPEG, GIF, BMP, SVG und weitere.

**Kann ich die Schriftart und den Stil eines Textwasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und jeden Stil wählen, um das Design Ihrer Präsentation und Marken­konsistenz zu wahren.

**Wie ändere ich Position oder Ausrichtung eines Wasserzeichens?**

Die Position und Ausrichtung lässt sich über die Koordinaten, Größe und Drehungs‑Eigenschaften des [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Objekts anpassen.