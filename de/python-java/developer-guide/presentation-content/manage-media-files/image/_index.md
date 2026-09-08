---
title: Optimieren der Bildverwaltung in Präsentationen mit Python
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/python-java/image/
keywords:
- Bild hinzufügen
- Bild einfügen
- Bild ersetzen
- Bildersammlung
- Bildrahmen
- Verknüpftes Bild
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- SVG zu Formen
- Externe SVG-Ressourcen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Raster- und SVG-Bilder in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via Java hinzufügen, wiederverwenden, verlinken, ersetzen und verwalten."
---
## **Einleitung**

Aspose.Slides für Python via Java bietet mehrere Möglichkeiten, mit Bildern zu arbeiten, und jede dient einem anderen Zweck. Sie können ein Bild in einer Präsentation speichern, es in einem Bildrahmen anzeigen, es als Folienhintergrund verwenden, auf ein externes Bild verlinken, eine gemeinsam genutzte Bildressource ersetzen oder SVG‑Inhalt in bearbeitbare Formen konvertieren.

Dieser Artikel konzentriert sich auf Bildressourcen und deren Verwendung in einer Präsentation. Informationen zu Zuschneiden, Transparenz, Effekten, Dehnen und anderen Formatierungen, die auf einen einzelnen Bildrahmen angewendet werden, finden Sie unter [Bildrahmen](/slides/de/python-java/picture-frame/).

## **Verstehen des Bildmodells**

Die folgenden API‑Konzepte stehen in engem Zusammenhang, sind jedoch nicht austauschbar:

- Die [Bildersammlung der Präsentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagecollection/) speichert Bildressourcen, die in der Präsentation verwendet werden. Verwenden Sie [ImageCollection.addImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagecollection/#addImage), um Bilddaten hinzuzufügen und eine [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/)-Ressource zu erhalten.
- Ein [Bildrahmen](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/) ist eine Form, die ein Bild auf einer Folie, einem Layout oder einer Masterfolie anzeigt. Verwenden Sie [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addPictureFrame), um eine Bildressource auf einer Folie zu platzieren.
- Ein Folienhintergrund verwendet ein Bild als Teil der Folienfüllung und nicht als Form. Er verhält sich daher nicht wie ein Bildrahmen.
- [PPImage.replaceImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#replaceImage) ersetzt eine Bildressource. Wenn mehrere Präsentationselemente diese Ressource verwenden, nutzen sie alle die Ersetzung.
- Das Konvertieren eines SVG in Formen erzeugt bearbeitbare Folienformen. Nach der Konvertierung wird der Inhalt nicht mehr als ein einziges Bild verwaltet.

Ein typischer Workflow lautet daher: Bilddaten zur Bildersammlung hinzufügen, eine [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) erhalten und diese Ressource dann in einem oder mehreren Bildrahmen oder Füllungen verwenden.

## **Ein eingebettetes Bild hinzufügen**

Um ein lokales Bild einzufügen, laden Sie die Datei, fügen Sie sie zur Bildersammlung hinzu und erstellen Sie einen Bildrahmen, der die zurückgegebene [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) verwendet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das auf diese Weise hinzugefügte Bild ist in der Präsentation eingebettet, sodass die resultierende Datei nicht von der Verfügbarkeit der ursprünglichen Bilddatei abhängt.

### **Ein Bild aus dem Web hinzufügen**

Wenn ein Bild über HTTP oder HTTPS verfügbar ist, laden Sie dessen Bytes herunter, fügen Sie sie zur Bildersammlung der Präsentation hinzu und verwenden Sie die zurückgegebene Bildressource wie bei einem lokalen Bild.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In langlaufenden Anwendungen sollten Sie einen HTTP‑Client oder eine Verbindungs‑Management‑Strategie wiederverwenden, die zur Anwendung passt, anstatt wiederholt unnötige Netzwerk‑Infrastruktur zu erzeugen. Validieren Sie außerdem entfernte URLs, Antwortgrößen und Inhaltstypen, wenn die Quelle nicht vertrauenswürdig ist.

## **Bilder über Folien hinweg wiederverwenden**

Wenn dasselbe Bild mehr als einmal benötigt wird, fügen Sie es einmal zur Präsentation hinzu und verwenden Sie die zurückgegebene [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/), wenn Sie zusätzliche Bildrahmen erstellen. Das vermeidet wiederholtes Laden derselben Quelldaten und macht die Beziehung zwischen der geteilten Bildressource und ihren Verwendungen explizit.

Für Grafiken, die automatisch auf vielen Folien erscheinen sollen, wie ein Firmenlogo, sollten Sie in Erwägung ziehen, den Bildrahmen auf einem [Folien‑Master](/slides/de/python-java/slide-master/) oder Layout zu platzieren, anstatt die entsprechende Form auf jeder Folie hinzuzufügen.

## **Ein Bild als Folienhintergrund verwenden**

Ein Hintergrundbild wird der Folienfüllung zugewiesen; es wird nicht als Bildrahmen‑Form hinzugefügt. Das ist nützlich, wenn das Bild den gesamten Folienhintergrund abdecken und nicht wie ein normales Folienobjekt manipuliert werden soll.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Weitere Hintergrundoptionen, einschließlich Master‑ und Layout‑Hintergründen, finden Sie unter [Präsentationshintergrund](/slides/de/python-java/presentation-background/).

## **Eingebettete Bilder und verlinkte Bilder**

Eingebettete und verlinkte Bilder haben unterschiedliche Portabilitäts‑ und Dateigrößen‑Kompromisse:

- **Eingebettetes Bild:** Die Bilddaten werden innerhalb der Präsentation gespeichert. Die Präsentation ist eigenständig, aber die Dateigröße enthält die Bilddaten.
- **Verlinktes Bild:** Die Präsentation speichert einen Pfad oder eine URL zu einem externen Bild. Dies kann die Präsentationsgröße reduzieren, erfordert jedoch, dass die externe Ressource beim Öffnen oder Rendern der Präsentation zugänglich bleibt.

Ein verknüpftes Bild kann erstellt werden, indem der externe Pfad oder die URL über [Picture.setLinkPathLong](https://reference.aspose.com/slides/de/python-java/aspose.slides/picture/#setLinkPathLong) zugewiesen wird, anstatt die Bilddaten einzubetten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Verwenden Sie verlinkte Bilder nur, wenn die Bereitstellungsumgebung die externe Ressource zuverlässig erreichen kann. Für Präsentationen, die offline funktionieren oder zwischen Systemen verschoben werden müssen, sind eingebettete Bilder in der Regel sicherer.

## **Arbeiten mit SVG‑Bildern**

SVG ist ein Vektorformat und eignet sich daher für Symbole, Diagramme und andere Grafiken, die ohne Detailverlust skalieren sollen. Aspose.Slides unterstützt SVG sowohl als Bildressource als auch als Quelle für bearbeitbare Folienformen.

### **Ein SVG als Bild hinzufügen**

Erstellen Sie ein [SvgImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/), fügen Sie es zur Bildersammlung hinzu und platzieren Sie die resultierende Bildressource in einem Bildrahmen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **SVG‑Dateien mit externen Ressourcen**

Ein SVG kann externe Bilder, Stylesheets oder Schriftarten referenzieren. Für diese Fälle bietet [SvgImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/) Konstruktoren, die einen [ExternalResourceResolver](https://reference.aspose.com/slides/de/python-java/aspose.slides/externalresourceresolver/) und einen Basis‑URI akzeptieren. Der Resolver kann einen relativen URI zu einem erlaubten absoluten URI abbilden und einen Stream für die angeforderte Ressource zurückgeben.

Der Resolver stellt externe Ressourcen während der Verarbeitung des SVGs durch Aspose.Slides zur Verfügung, rewrites das SVG jedoch nicht zu einem eigenständigen Dokument. Wenn das SVG portabel bleiben muss, betten Sie die erforderlichen Ressourcen im SVG selbst ein, beispielsweise mithilfe von `data:`‑URIs für verknüpfte Bilder.

Wenn SVG‑Dateien aus nicht vertrauenswürdigen Quellen stammen, beschränken Sie die Schemas, Dateipfade und Hosts, auf die der Resolver zugreifen kann. Netz‑Resolver sollten außerdem Time‑outs, Begrenzungen der Antwortgröße und Inhaltsvalidierungen anwenden.

### **SVG in bearbeitbare Formen konvertieren**

Aspose.Slides kann ein SVG in eine Gruppe bearbeitbarer Folienformen konvertieren, ähnlich dem entsprechenden PowerPoint‑Befehl.

![PowerPoint Popup Menu](img_01_01.png)

Verwenden Sie die Überladung von [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addGroupShape), die ein [SvgImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/) akzeptiert, um die Konvertierung durchzuführen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Setzen Sie die SVG‑zu‑Form‑Konvertierung ein, wenn einzelne Vektorelemente als PowerPoint‑Formen bearbeitet werden müssen. Wenn das SVG nur angezeigt werden soll, ist es einfacher, es als Bild zu behalten, und es werden keine vielen separaten Formen erzeugt.

## **Eine vorhandene Bildressource ersetzen**

Verwenden Sie [PPImage.replaceImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#replaceImage), wenn Sie eine vorhandene Bildressource ersetzen möchten. Dies ist besonders nützlich für gemeinsam genutzte Grafiken wie Logos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wenn mehrere Bildrahmen, Hintergründe, Master‑ oder Layout‑Folien dieselbe Bildressource verwenden, aktualisiert das Ersetzen dieser Ressource alle Verwendungen. Sollte nur ein Bildrahmen geändert werden, weisen Sie diesem Rahmen ein anderes Bild zu, anstatt die geteilte Ressource zu ersetzen.

[PPImage.replaceImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#replaceImage) bietet außerdem Überladungen, die ein Byte‑Array oder eine andere [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) akzeptieren.

## **Praktische Anleitung zur Bildverwaltung**

### **Präsentationsgröße kontrollieren**

Große Rasterbilder können eine Präsentation unnötig vergrößern. Verwenden Sie Quellbilder mit Abmessungen, die für die beabsichtigte Anzeigegröße passend sind, wiederverwenden Sie gemeinsam genutzte Bildressourcen, wo es möglich ist, und vermeiden Sie das Einbetten mehrfacher Kopien derselben hochauflösenden Grafik.

Für bereits in Bildrahmen platzierte Rasterbilder kann [PictureFillFormat.compressImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/#compressImage) die Bilddaten entsprechend der ausgewählten Auflösung und den Zuschnittseinstellungen reduzieren. Dies ist eine Bildrahmen‑Verarbeitung und kein Bildersammlungs‑Management, siehe daher [Bildrahmen](/slides/de/python-java/picture-frame/) für zugehörige Formatierungs‑Operationen.

### **Auswahl zwischen eingebettetem und verlinktem Inhalt**

Einbetten macht die Präsentation portabel, da alle erforderlichen Bilddaten mit der Datei reisen. Verlinken kann die Dateigröße reduzieren, führt jedoch zu einer externen Abhängigkeit. Verwenden Sie Links nur, wenn diese Abhängigkeit akzeptabel und stabil ist.

### **Gemeinsame Markenbilder wiederverwenden**

Für wiederkehrende Logos, Wasserzeichen oder dekorative Grafiken verwenden Sie eine Bildressource und nutzen Sie sie mehrfach. Wenn die Grafik zum Präsentationsdesign und nicht zum Folieninhalt gehört, platzieren Sie sie auf einem Master oder Layout, damit sie von den entsprechenden Folien geerbt wird.

### **SVG‑Ressourcen portabel halten**

Ein eigenständiges SVG lässt sich leichter verschieben und konsistent rendern als ein SVG, das von externen Dateien oder Netzwerkressourcen abhängt. Betten Sie nach Möglichkeit erforderliche Ressourcen ein, bevor Sie das SVG importieren. Konvertieren Sie SVGs nur in Formen, wenn die einzelnen Vektorelemente bearbeitet werden müssen.

### **Die moderne plattformübergreifende Bild‑API verwenden**

Für neuen Python‑via‑Java‑Code verwenden Sie die plattformübergreifenden Bildobjekte von Aspose.Slides und die [Images](https://reference.aspose.com/slides/de/python-java/aspose.slides/images/)‑APIs anstelle der veralteten öffentlichen API, die auf `java.awt.image.BufferedImage` basiert. Siehe [Moderne API](/slides/de/python-java/modern-api/) für Migrationshinweise.

WMF und EMF erfordern besondere Berücksichtigung. Wenn diese Formate über ein plattformübergreifendes Bildobjekt übergeben werden, konvertiert [ImageCollection.addImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagecollection/#addImage) die Metadatei in eine Raster‑PNG‑Darstellung vor dem Einfügen. Wenn das Beibehalten der Metadaten wichtig ist, verwenden Sie die strombasierte Überladung von [ImageCollection.addImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagecollection/#addImage). Das Erzeugen von EMF‑Inhalten aus Tabellenkalkulationen oder anderen Produkten ist ein separater Integrations‑Workflow und liegt außerhalb des Umfangs dieses Artikels.

## **FAQ**

**Was ist der Unterschied zwischen der Bildersammlung und einem Bildrahmen?**

Die Bildersammlung speichert wiederverwendbare Bildressourcen. Ein Bildrahmen ist eine Folienform, die eine dieser Ressourcen anzeigt und bildspezifische Formatierungen wie Zuschnitt und Effekte bietet.

**Wie ersetze ich dasselbe Logo überall am besten?**

Wenn das Logo bereits als eine Bildressource geteilt wird, ersetzen Sie diese Ressource mit [PPImage.replaceImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#replaceImage). Für präsentationsweite Markenbildung kann das Platzieren des Logos auf einem Master oder Layout ebenfalls duplizierten Folieninhalt reduzieren.

**Warum verschwindet ein verlinktes Bild auf einem anderen Computer?**

Ein verlinktes Bild hängt von seiner externen Datei oder URL ab. Wenn diese Ressource vom anderen Computer aus nicht erreichbar ist, kann das verlinkte Bild nicht angezeigt werden. Betten Sie das Bild ein, wenn die Präsentation eigenständig sein muss.

**Kann ein eingefügtes SVG als PowerPoint‑Formen bearbeitet werden?**

Ja. Konvertieren Sie das SVG mit [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addGroupShape); die resultierende Gruppe enthält bearbeitbare Folienformen statt eines einzelnen SVG‑Bildes.

**Wie kann ich Präsentationen mit vielen Bildern kleiner halten?**

Wiederverwenden Sie geteilte Bildressourcen, vermeiden Sie unnötig große Rasterquellen, komprimieren Sie geeignete Rasterbilder bei Bedarf, halten Sie wiederkehrende Marken auf Mastern oder Layouts und verwenden Sie verlinkte Bilder nur, wenn eine externe Abhängigkeit akzeptabel ist.