---
title: Verwalten von Präsentationsplatzhaltern in Python
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/python-java/manage-placeholder/
keywords:
- Platzhalter
- Textplatzhalter
- Bildplatzhalter
- Diagrammplatzhalter
- Inhaltsplatzhalter
- Hinweistext
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text-, Bild-, Diagramm- und Inhaltsplatzhalter untersuchen und bearbeiten sowie die Platzhaltervererbung mit Aspose.Slides für Python via Java verstehen."
---
## **Überblick**

Ein Platzhalter ist eine Form, die in einer Präsentationsvorlage eine Position für eine bestimmte Art von Inhalt reserviert. Häufige Beispiele sind Titel, Textkörper, Bild, Diagramm und allgemein nutzbare Inhaltsplatzhalter. Im Gegensatz zu einer gewöhnlichen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layout‑Folie oder einer Master‑Folie erben.

Aspose.Slides stellt Platzhalterinformationen über die [Shape.getPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getPlaceholder)-Methode bereit. Die Methode gibt ein [Placeholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/placeholder/)‑Objekt oder `None` für eine normale Form zurück. Verwenden Sie [Placeholder.getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/placeholder/#getType), um zu bestimmen, welchen Inhalt der Platzhalter enthalten soll.

Der Formtyp bleibt nach Kenntnis des Platzhaltertyps relevant:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhaltsplatzhalter wird typischerweise durch ein [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/)-Objekt dargestellt.
- Ein befüllter Bildplatzhalter kann durch ein [PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/) repräsentiert werden.
- Ein befüllter Diagrammplatzhalter kann durch ein [Chart](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/) dargestellt werden.
- Ein Inhaltsplatzhalter kann mehrere Arten von Inhalten enthalten. Prüfen Sie sowohl [Placeholder.getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/placeholder/#getType) als auch den Laufzeit‑Formtyp, anstatt davon auszugehen, dass jeder Platzhalter ein [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) ist.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/placeholder/#getType) beschreibt die Rolle eines Platzhalters; sie garantiert nicht den Laufzeit‑Formtyp. Verwenden Sie stets eine Typprüfung, bevor Sie auf text‑, bild‑, diagramm‑, tabellen‑ oder medienspezifische Member zugreifen.
{{% /alert %}}

## **Verstehen der Platzhaltervererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Master‑Folie definiert wiederverwendbare Stile und ggf. Master‑Platzhalter.
2. Eine Layout‑Folie definiert die Anordnung, die von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [Shape.getBasePlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getBasePlaceholder) auf, um eine Ebene in dieser Hierarchie nach oben zu gehen. Ein Folien‑Platzhalter gibt normalerweise seinen Layout‑Platzhalter zurück; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode liefert `None`, wenn die Form keinen Basis‑Platzhalter hat.

Das folgende Beispiel listet die Platzhalter auf der ersten Folie auf und gibt deren Basis‑Platzhalter aus:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Das Bearbeiten eines Platzhalters auf einer normalen Folie erstellt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Eine lokale gewöhnliche Form hat keinen Basis‑Platzhalter und beginnt nicht zu erben, nur weil sie dieselben Koordinaten belegt.

## **Text in einem Platzhalter ändern**

Titel‑, zentrierte‑Titel‑, Untertitel‑, Text‑ und Inhaltsplatzhalter unterstützen normalerweise Text. Prüfen Sie vor der Verwendung von [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) dessen [getTextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/#getTextFrame)-Methode.

Dieses Beispiel aktualisiert den ersten Titelplatzhalter auf der ersten Folie und speichert das Ergebnis:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dieses Muster vermeidet das Behandeln von Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhaltern als [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/). Es identifiziert den Platzhalter zudem nach Zweck statt anhand eines fragilen Form‑Index.

## **Prompt‑Text auf einem Layout festlegen**

Prompt‑Text ist die Design‑Zeit‑Anweisung, die in einem leeren Platzhalter angezeigt wird, z. B. *Klicken Sie, um Titel hinzuzufügen*. Legen Sie benutzerdefinierten Prompt‑Text auf dem Layout‑Platzhalter fest, anstatt zu versuchen, ihn über die Form‑Sammlung einer normalen Folie zu erreichen. Greifen Sie über [Slide.getLayoutSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getLayoutSlide) auf das Layout zu und iterieren Sie über die Sammlung, die von [BaseSlide.getShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getShapes) zurückgegeben wird.

Das folgende Beispiel ändert die Titel‑ und Untertitel‑Prompts im Layout, das von der ersten Folie verwendet wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Prompt‑Text ist kein normaler Folieninhalt. Er ist für leere Platzhalter in Bearbeitungs‑Apps wie PowerPoint gedacht. Sobald ein Benutzer oder ein Programm echten Inhalt liefert, wird der Prompt nicht mehr angezeigt. Das Ändern eines Prompts ersetzt zudem nicht den bereits vorhandenen Text auf Folien, die das Layout verwenden.

## **Ein Bild‑Platzhalter aktualisieren**

Es gibt zwei Fälle zu behandeln:

- Wenn der Bild‑Platzhalter bereits befüllt ist und durch ein [PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/) repräsentiert wird, ersetzen Sie das Bild über [PictureFillFormat.getPicture](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/#getPicture) und [Picture.setImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/picture/#setImage).
- Wenn es noch ein leerer Platzhalter ist, fügen Sie ein Bild‑Frame an den Koordinaten des Platzhalters mit [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addPictureFrame) hinzu und entfernen Sie den leeren Platzhalter.

Das nächste Beispiel unterstützt beide Fälle und speichert die Präsentation:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der Ersatz, der für einen leeren Platzhalter erstellt wird, ist ein lokales Bild‑Frame, kein neuer Platzhalter, weil [Shape.getPlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getPlaceholder) keinen Setter bereitstellt. Er behält die reservierte Position bei, erbt jedoch kein platzhalterspezifisches Verhalten mehr. Wenn die Beibehaltung der Platzhalter‑Beziehung wesentlich ist, sollten Sie den Platzhalter zunächst in PowerPoint vorbereiten und befüllen und anschließend das resultierende [PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/) mit Aspose.Slides aktualisieren.

Für Bild‑Transparenz, Zuschneiden und andere bild‑spezifische Effekte siehe [Manage Picture Frames](/slides/de/python-java/picture-frame/). Diese Vorgänge betreffen das Bild‑Frame bzw. den Bild‑Füllbereich, nicht die Platzhalter‑Metadaten.

## **Arbeiten mit Diagramm‑ und Inhalts‑Platzhaltern**

Ein befüllter Diagramm‑Platzhalter kann durch ein [Chart](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm anhand sowohl des Platzhaltertyps als auch des Laufzeittyps, ändert dessen Titel und speichert die Datei:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ein allgemeiner Inhalts‑Platzhalter hat normalerweise [PlaceholderType.Object](https://reference.aspose.com/slides/de/python-java/aspose.slides/placeholdertype/#Object). In PowerPoint fungiert er als Launcher für mehrere Inhaltsarten, einschließlich Diagramme, Tabellen, Diagramme, Bilder und Medien. Nachdem er befüllt wurde, prüfen Sie den tatsächlichen Formtyp, um zu erfahren, was er enthält. Spezialisierte Layouts können auch [PlaceholderType.Chart](https://reference.aspose.com/slides/de/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/de/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/de/python-java/aspose.slides/placeholdertype/#Media) oder [PlaceholderType.Diagram](https://reference.aspose.com/slides/de/python-java/aspose.slides/placeholdertype/#Diagram) aufweisen.

Aspose.Slides konvertiert einen leeren [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/)‑Platzhalter nicht in ein [Chart](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/) allein durch Ändern von [Placeholder.getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/placeholder/#getType); der Typ kann über die API nicht geändert werden. Um ein leeres Diagramm‑ oder Inhalts‑Gebiet programmgesteuert zu füllen, fügen Sie das gewünschte Objekt an den Koordinaten des Platzhalters hinzu und entfernen anschließend den leeren Platzhalter. Das folgende Beispiel erledigt dies für ein Diagramm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die spezialisierten [chart management articles](/slides/de/python-java/powerpoint-charts/), wenn Sie Kategorien, Serien oder Arbeitsblattdaten ersetzen müssen.

## **Komplettes Beispiel: Text‑ oder Bild‑Inhalt aktualisieren**

Das folgende End‑zu‑Ende‑Beispiel öffnet eine Vorlage, durchsucht die erste Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft Platzhalter‑ und Formtypen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel vermeidet bewusst die Annahme eines Form‑Index oder das Behandeln jedes Platzhalters als denselben Typ.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**Was ist ein Basis‑Platzhalter?**

Ein Basis‑Platzhalter ist die entsprechende Form im Layout oder Master, von der ein anderer Platzhalter erbt. Verwenden Sie [Shape.getBasePlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getBasePlaceholder), um ihn abzurufen. Eine gewöhnliche lokale Form liefert `None`, weil sie nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können über ein Layout vererbte Formatierungen oder Prompt‑Texte ändern, aber vorhandene Titelinhalte sind in den normalen Folien gespeichert. Um den tatsächlichen Titeltext in einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren jeden Titel‑Platzhalter.

**Wie verwalte ich Datums‑, Folien‑Nummer‑, Kopf‑ und Fußzeilen‑Platzhalter?**

Verwenden Sie die Header‑ und Footer‑Manager auf der jeweiligen Folien‑, Layout‑, Master‑, Notizen‑ oder Handout‑Ebene. Siehe [Manage Presentation Header and Footer](/slides/de/python-java/presentation-header-and-footer/) für vollständige Beispiele.