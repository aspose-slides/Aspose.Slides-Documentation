---
title: Optimieren der Bildverwaltung in Präsentationen mit Python
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/python-net/image/
keywords:
- Bild hinzufügen
- Bild einfügen
- Bild ersetzen
- Bildsammlung
- Bildrahmen
- Verknüpftes Bild
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- SVG zu Formen
- externe SVG-Ressourcen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Raster- und SVG-Bilder in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python über .NET hinzufügen, wiederverwenden, verlinken, ersetzen und verwalten."
---
## **Einleitung**

Aspose.Slides für Python über .NET bietet mehrere Möglichkeiten, mit Bildern zu arbeiten, und jede dient einem anderen Zweck. Sie können ein Bild in einer Präsentation speichern, es in einem Bildrahmen anzeigen, als Folienhintergrund verwenden, zu einem externen Bild verlinken, eine gemeinsam genutzte Bildressource ersetzen oder SVG‑Inhalte in editierbare Formen konvertieren.

Dieser Artikel konzentriert sich auf Bildressourcen und deren Verwendung in einer Präsentation. Informationen zu Zuschneiden, Transparenz, Effekten, Dehnung und anderen Formatierungen, die auf einen einzelnen Bildrahmen angewendet werden, finden Sie unter [Bildrahmen](/slides/de/python-net/picture-frame/).

## **Verstehen des Bildmodells**

Die folgenden API‑Konzepte stehen in engem Zusammenhang, sind jedoch nicht austauschbar:

- Die [Bildsammlung der Präsentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/) speichert Bildressourcen, die von der Präsentation verwendet werden. Verwenden Sie [ImageCollection.add_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/add_image/), um Bilddaten hinzuzufügen und eine [IPPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ippimage/)-Ressource zu erhalten.
- Ein [Bildrahmen](https://reference.aspose.com/slides/de/python-net/aspose.slides/ipictureframe/) ist eine Form, die ein Bild auf einer Folie, einem Layout oder einer Masterfolie anzeigt. Verwenden Sie [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_picture_frame/), um eine Bildressource auf einer Folie zu platzieren.
- Ein Folienhintergrund verwendet ein Bild als Teil der Folienfüllung und nicht als Form. Er verhält sich daher nicht wie ein Bildrahmen.
- [IPPImage.replace_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/ippimage/replace_image/) ersetzt eine Bildressource. Wenn mehrere Präsentationselemente diese Ressource verwenden, verwenden sie alle die Ersetzung.
- Das Konvertieren eines SVG in Formen erzeugt editierbare Folienformen. Nach der Konvertierung wird der Inhalt nicht mehr als ein einzelnes Bildressourcen‑Objekt verwaltet.

Ein typischer Arbeitsablauf lautet daher: Bilddaten zur Bildsammlung hinzufügen, ein [IPPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ippimage/) erhalten und diese Ressource anschließend in einem oder mehreren Bildrahmen oder Füllungen verwenden.

## **Ein eingebettetes Bild hinzufügen**

Um ein lokales Bild einzufügen, lesen Sie die Datei, fügen Sie deren Daten zur Bildsammlung hinzu und erstellen Sie einen Bildrahmen, der das zurückgegebene `IPPImage` verwendet.

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Das auf diese Weise hinzugefügte Bild ist in der Präsentation eingebettet, sodass die resultierende Datei nicht von der Verfügbarkeit der ursprünglichen Bilddatei abhängt.

### **Ein Bild aus dem Web hinzufügen**

Wenn ein Bild über HTTP oder HTTPS verfügbar ist, laden Sie dessen Bytes herunter, fügen Sie sie zur Bildsammlung der Präsentation hinzu und verwenden Sie die zurückgegebene Bildressource wie ein lokales Bild.

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

In langlaufenden Anwendungen sollten Sie einen HTTP‑Client oder einen Verbindungs‑Pool wiederverwenden, anstatt für jede Anforderung eine neue Verbindung zu erstellen. Validieren Sie außerdem entfernte URLs, Antwortgrößen und Inhaltstypen, wenn die Quelle nicht vertrauenswürdig ist.

## **Bilder über Folien hinweg wiederverwenden**

Wenn dasselbe Bild mehrmals benötigt wird, fügen Sie es einmal zur Präsentation hinzu und verwenden das zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ippimage/) beim Erstellen weiterer Bildrahmen. Dadurch wird das wiederholte Laden derselben Quelldaten vermieden und die Beziehung zwischen der gemeinsamen Bildressource und ihren Verwendungen wird explizit.

Für Grafiken, die automatisch auf vielen Folien erscheinen sollen, z. B. ein Firmenlogo, sollten Sie den Bildrahmen auf einem [Folienmaster](/slides/de/python-net/slide-master/) oder Layout platzieren, anstatt die entsprechende Form zu jeder Folie hinzuzufügen.

## **Ein Bild als Folienhintergrund verwenden**

Ein Hintergrundbild wird der Folienfüllung zugewiesen; es wird nicht als Bildrahmen‑Form hinzugefügt. Dies ist nützlich, wenn das Bild den gesamten Folienhintergrund abdecken und nicht wie ein normales Folienobjekt manipuliert werden soll.

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

Weitere Hintergrundoptionen, einschließlich Master‑ und Layout‑Hintergründen, finden Sie unter [Präsentationshintergrund](/slides/de/python-net/presentation-background/).

## **Eingebettete und verknüpfte Bilder**

Eingebettete und verknüpfte Bilder haben unterschiedliche Portabilitäts‑ und Dateigrößen‑Abwägungen:

- **Eingebettetes Bild:** Die Bilddaten werden innerhalb der Präsentation gespeichert. Die Präsentation ist eigenständig, aber die Dateigröße beinhaltet die Bilddaten.
- **Verknüpftes Bild:** Die Präsentation speichert einen Pfad oder eine URL zu einem externen Bild. Dadurch kann die Präsentationsgröße reduziert werden, jedoch muss die externe Ressource beim Öffnen oder Rendern der Präsentation erreichbar sein.

Ein verknüpftes Bild kann erstellt werden, indem der externe Pfad oder die URL über [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/de/python-net/aspose.slides/islidespicture/link_path_long/) zugewiesen wird, anstatt die Bilddaten einzubetten.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Verwenden Sie verknüpfte Bilder nur, wenn die Bereitstellungsumgebung zuverlässig auf die externe Ressource zugreifen kann. Für Präsentationen, die offline funktionieren oder zwischen Systemen verschoben werden müssen, sind eingebettete Bilder in der Regel sicherer.

## **Arbeiten mit SVG-Bildern**

SVG ist ein Vektorformat und eignet sich daher für Symbole, Diagramme und andere Grafiken, die ohne Detailverlust skalieren sollen. Aspose.Slides unterstützt SVG sowohl als Bildressource als auch als Quelle für editierbare Folienformen.

### **Ein SVG als Bild hinzufügen**

Erstellen Sie ein [SvgImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/svgimage/), fügen Sie es zur Bildsammlung hinzu und platzieren Sie die resultierende Bildressource in einem Bildrahmen.

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **SVG in editierbare Formen konvertieren**

Aspose.Slides kann ein SVG in eine Gruppe editierbarer Folienformen konvertieren, ähnlich dem entsprechenden PowerPoint‑Befehl.

![PowerPoint Popup Menu](img_01_01.png)

Verwenden Sie die [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_group_shape/)-Überladung, die ein [ISvgImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/isvgimage/) akzeptiert, um die Konvertierung durchzuführen.

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Setzen Sie die SVG‑zu‑Formen‑Konvertierung ein, wenn einzelne Vektorelemente als PowerPoint‑Formen bearbeitet werden müssen. Wenn das SVG nur angezeigt werden soll, ist das Beibehalten als Bild einfacher und vermeidet das Erzeugen vieler separater Formen.

## **Eine vorhandene Bildressource ersetzen**

Verwenden Sie [IPPImage.replace_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/ippimage/replace_image/), wenn Sie eine vorhandene Bildressource ersetzen möchten. Dies ist besonders nützlich für gemeinsam genutzte Grafiken wie Logos.

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Wenn mehrere Bildrahmen, Hintergründe, Master‑Folien oder Layouts dieselbe Bildressource verwenden, aktualisiert das Ersetzen dieser Ressource alle Verwendungen. Soll nur ein Bildrahmen geändert werden, weisen Sie diesem Rahmen ein anderes Bild zu, anstatt die gemeinsam genutzte Ressource zu ersetzen.

`replace_image` bietet außerdem Überladungen, die ein [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) oder ein weiteres [IPPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ippimage/) akzeptieren.

## **Praktische Anleitung zur Bildverwaltung**

### **Präsentationsgröße kontrollieren**

Große Rasterbilder können eine Präsentation unnötig groß machen. Verwenden Sie Quellbilder mit Abmessungen, die für die beabsichtigte Anzeigegröße geeignet sind, nutzen Sie gemeinsam genutzte Bildressourcen nach Möglichkeit wieder und vermeiden Sie das Einbetten mehrfach vorkommender Voll‑Auflösung‑Grafiken.

Für Rasterbilder, die bereits in Bildrahmen platziert wurden, kann [PictureFillFormat.compress_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/compress_image/) Bilddaten gemäß der eingestellten Auflösung und den Zuschneide‑Einstellungen reduzieren. Dies ist eine Bildrahmen‑Verarbeitung und keine Verwaltung der Bildsammlung, siehe daher [Bildrahmen](/slides/de/python-net/picture-frame/) für zugehörige Formatierungs‑Operationen.

### **Auswahl zwischen eingebetteten und verknüpften Inhalten**

Einbetten macht die Präsentation portabel, weil alle benötigten Bilddaten mit der Datei transportiert werden. Verknüpfen kann die Dateigröße reduzieren, führt jedoch zu einer externen Abhängigkeit. Verwenden Sie Verknüpfungen nur, wenn diese Abhängigkeit akzeptabel und stabil ist.

### **Gemeinsame Marken wiederverwenden**

Für wiederholte Logos, Wasserzeichen oder dekorative Grafiken verwenden Sie eine Bildressource und nutzen Sie diese mehrfach. Wenn die Grafik zum Design der Präsentation und nicht zum Folieninhalt gehört, platzieren Sie sie auf einem Master oder Layout, sodass sie von den entsprechenden Folien geerbt wird.

### **SVG-Ressourcen portabel halten**

Ein eigenständiges SVG lässt sich leichter verschieben und konsistent rendern als ein SVG, das von externen Dateien oder Netzwerk‑Ressourcen abhängt. Wenn möglich, betten Sie benötigte Ressourcen ein, bevor Sie das SVG importieren. Konvertieren Sie SVG zu Formen nur, wenn die einzelnen Vektorelemente bearbeitet werden müssen.

### **Verwenden Sie die moderne plattformübergreifende Bild‑API**

Für neuen Python‑via‑.NET‑Code verwenden Sie die Aspose.Slides [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) und [Images](https://reference.aspose.com/slides/de/python-net/aspose.slides/images/) APIs anstelle der veralteten `aspose.pydrawing.Image`‑ oder `aspose.pydrawing.Bitmap`‑Bild‑APIs. Siehe [Modern API](/slides/de/python-net/modern-api/) für Migrations‑Hinweise.

WMF‑ und EMF‑Formate benötigen besondere Beachtung. Wenn diese Formate über ein [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) übergeben werden, konvertiert [ImageCollection.add_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/add_image/) die Metadatei vor dem Einfügen in eine Raster‑PNG‑Darstellung. Wenn das Beibehalten der Metadatei wichtig ist, verwenden Sie stattdessen die Stream‑basierte [ImageCollection.add_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/add_image/)‑Überladung. Das Erzeugen von EMF‑Inhalten aus Tabellenkalkulationen oder anderen Produkten ist ein separater Integrations‑Workflow und fällt nicht in den Umfang dieses Artikels.

## **FAQ**

**Was ist der Unterschied zwischen der Bildsammlung und einem Bildrahmen?**

Die Bildsammlung speichert wiederverwendbare Bildressourcen. Ein Bildrahmen ist eine Folienform, die eine dieser Ressourcen anzeigt und bildspezifische Formatierungen wie Zuschneiden und Effekte bereitstellt.

**Was ist der beste Weg, dasselbe Logo überall zu ersetzen?**

Wenn das Logo bereits als eine gemeinsame Bildressource vorliegt, ersetzen Sie diese Ressource mit [IPPImage.replace_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/ippimage/replace_image/). Für eine präsentationsweite Markenführung kann das Platzieren des Logos auf einem Master oder Layout ebenfalls duplizierten Folieninhalt reduzieren.

**Warum verschwindet ein verknüpftes Bild auf einem anderen Computer?**

Ein verknüpftes Bild hängt von seiner externen Datei oder URL ab. Wenn diese Ressource vom anderen Computer aus nicht erreichbar ist, ist das verknüpfte Bild nicht verfügbar. Betten Sie das Bild ein, wenn die Präsentation eigenständig sein muss.

**Kann ein eingefügtes SVG als PowerPoint‑Formen bearbeitet werden?**

Ja. Konvertieren Sie das SVG mit [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_group_shape/); die resultierende Gruppe enthält editierbare Folienformen anstelle eines einzelnen SVG‑Bildes.

**Wie kann ich Präsentationen mit vielen Bildern klein halten?**

Wiederverwenden Sie gemeinsam genutzte Bildressourcen, vermeiden Sie unnötig große Rasterquellen, komprimieren Sie geeignete Rasterbilder bei Bedarf, platzieren Sie wiederholte Marken auf Mastern oder Layouts und verwenden Sie verknüpfte Bilder nur, wenn eine externe Abhängigkeit akzeptabel ist.