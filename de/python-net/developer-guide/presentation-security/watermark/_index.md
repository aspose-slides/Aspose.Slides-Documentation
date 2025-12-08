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
description: "Erfahren Sie, wie Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument-Präsentationen in Python verwalten, um einen Entwurf, vertrauliche Informationen, Urheberrecht und mehr anzuzeigen."
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder auf allen Folien einer Präsentation verwendet wird. Üblicherweise wird ein Wasserzeichen eingesetzt, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Entwurf“-Wasserzeichen), vertrauliche Informationen enthält (z. B. ein „Vertraulich“-Wasserzeichen), welchem Unternehmen sie zuzuordnen ist (z. B. ein „Firmenname“-Wasserzeichen), den Autor der Präsentation zu kennzeichnen usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es deutlich macht, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT, PPTX und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und ihr Design sowie Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen die Klasse [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) verwenden und zum Hinzufügen von Bildwasserzeichen die Klasse [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) oder das Befüllen einer Wasserzeichen‑Form mit einem Bild. `PictureFrame` implementiert die Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), sodass Sie alle flexiblen Einstellungen des Form‑Objekts nutzen können. Da `TextFrame` keine Form ist und seine Einstellungen eingeschränkt sind, wird es in ein [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Objekt eingewickelt.

Ein Wasserzeichen kann auf zwei Arten angewendet werden: auf einer einzelnen Folie oder auf allen Folien der Präsentation. Der Folien‑Master wird verwendet, um ein Wasserzeichen auf alle Folien anzuwenden – das Wasserzeichen wird dem Folien‑Master hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu ändern.

Ein Wasserzeichen gilt normalerweise als nicht zur Bearbeitung durch andere Benutzer verfügbar. Um zu verhindern, dass das Wasserzeichen (bzw. die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Form‑Sperrfunktion. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folien‑Master gesperrt werden. Wird die Wasserzeichen‑Form auf dem Folien‑Master gesperrt, ist sie auf allen Folien gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es später anhand des Namens in den Folien‑Formen finden und ggf. löschen können.

Sie können das Wasserzeichen nach Belieben gestalten; üblicherweise weisen Wasserzeichen jedoch gemeinsame Merkmale wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. auf. Im Folgenden betrachten wir, wie diese Eigenschaften in den Beispielen verwendet werden.

## **Textwasserzeichen**

### **Ein Textwasserzeichen zu einer Folie hinzufügen**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, fügen Sie zunächst eine Form zur Folie hinzu und anschließend einen Textrahmen zu dieser Form. Der Textrahmen wird durch die Klasse [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) repräsentiert. Dieser Typ ist nicht von [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) abgeleitet, das über einen umfangreichen Satz von Eigenschaften zur flexiblen Positionierung des Wasserzeichens verfügt. Daher wird das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-Objekt in ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekt eingebettet. Um Text zum Wasserzeichen‑Shape hinzuzufügen, verwenden Sie die Methode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) wie unten gezeigt.
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

### **Ein Textwasserzeichen zu einer Präsentation hinzufügen**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d. h. zu allen Folien gleichzeitig) hinzufügen möchten, fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) hinzu. Der Rest der Logik ist identisch zu dem Vorgehen beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – erzeugen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekt und fügen Sie das Wasserzeichen über die Methode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) hinzu.
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

### **Transparenz der Wasserzeichen‑Form festlegen**

Standardmäßig ist die Rechteckform mit Füll‑ und Linienfarben formatiert. Die folgenden Codezeilen machen die Form transparent.
```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```


### **Schriftart für ein Textwasserzeichen festlegen**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.
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


### **Ein Textwasserzeichen zentrieren**

Das Wasserzeichen kann auf einer Folie zentriert werden; dazu gehen Sie wie folgt vor:
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

### **Ein Bildwasserzeichen zu einer Präsentation hinzufügen**

Um ein Bildwasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes ausführen:
```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```


## **Ein Wasserzeichen vor Bearbeitung schützen**

Falls ein Wasserzeichen nicht bearbeitet werden soll, verwenden Sie die Eigenschaft [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, in der Größe geändert, verschoben, mit anderen Elementen gruppiert, ihr Text bearbeitet usw. zu werden:
```py
# Sperren Sie die Wasserzeichen-Form vor Änderungen
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```


## **Ein Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Formen über die Methode [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) festgelegt werden. Rufen Sie diese Methode aus der Folienliste der Präsentation auf und übergeben Sie die Referenz der Form sowie deren Reihenfolgenummer. Auf diese Weise lässt sich eine Form in den Vordergrund bzw. in den Hintergrund der Folie verschieben. Diese Funktion ist besonders nützlich, wenn das Wasserzeichen vor dem Rest der Präsentation platziert werden soll:
```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```


## **Wasserzeichen‑Rotation festlegen**

Im folgenden Beispiel wird gezeigt, wie Sie die Drehung des Wasserzeichens so anpassen, dass es diagonal über die Folie verläuft:
```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```


## **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Festlegen eines Namens für eine Form. Mit dem Form‑Namen können Sie später auf die Form zugreifen, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichen‑Form zu setzen, weisen Sie ihn der Eigenschaft [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) zu:
```py
watermark_shape.name = "watermark"
```


## **Ein Wasserzeichen entfernen**

Um die Wasserzeichen‑Form zu entfernen, verwenden Sie die Methode [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) zum Auffinden in den Folien‑Formen. Anschließend übergeben Sie die Wasserzeichen‑Form an die Methode [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):
```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```


## **Ein Live‑Beispiel**

Probieren Sie die kostenlosen Aspose.Slides‑Online‑Tools **Add Watermark** und **Remove Watermark** aus.

![Online‑Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)

## **FAQ**

**Was ist ein Wasserzeichen und warum sollte ich es verwenden?**

Ein Wasserzeichen ist ein Text‑ oder Bild‑Overlay, das auf Folien angewendet wird, um geistiges Eigentum zu schützen, die Markenbekanntheit zu steigern oder die unbefugte Nutzung von Präsentationen zu verhindern.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht das Hinzufügen eines Wasserzeichens zu jeder Folie einer Präsentation. Sie können über alle Folien iterieren und die Wasserzeichen‑Einstellungen einzeln anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Sie können die Transparenz des Wasserzeichens anpassen, indem Sie die Füll‑Einstellungen ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) der Form ändern. So bleibt das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

**Kann ich die Schriftart und den Stil eines Textwasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und jeden Stil wählen, um das Design Ihrer Präsentation anzupassen und die Marken‑Konsistenz zu wahren.

**Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?**

Sie können die Position und Ausrichtung des Wasserzeichens ändern, indem Sie die Koordinaten, Größe und Drehungs‑Eigenschaften der [shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Form anpassen.