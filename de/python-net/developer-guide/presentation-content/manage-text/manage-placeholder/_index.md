---
title: Verwalten von Präsentationsplatzhaltern in Python
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/python-net/manage-placeholder/
keywords:
- Platzhalter
- Textplatzhalter
- Bildplatzhalter
- Diagrammplatzhalter
- Inhaltsplatzhalter
- Eingabeaufforderung
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text-, Bild-, Diagramm- und Inhaltsplatzhalter inspizieren und bearbeiten und die Platzhaltervererbung mit Aspose.Slides für Python via .NET verstehen."
---
## **Übersicht**

Ein Platzhalter ist eine Form, die eine Position für eine bestimmte Art von Inhalt in einer Präsentationsvorlage reserviert. Häufige Beispiele sind Titel, Text, Bild, Diagramm und allgemeine Inhaltsplatzhalter. Im Gegensatz zu einer normalen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layoutfolie oder Masterfolie erben.

Aspose.Slides stellt Platzhalterinformationen über die Eigenschaft [Shape.placeholder](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/placeholder/) bereit. Die Eigenschaft gibt ein [Placeholder](https://reference.aspose.com/slides/de/python-net/aspose.slides/placeholder/)‑Objekt oder `None` für eine normale Form zurück. Verwenden Sie [Placeholder.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/placeholder/type/), um zu bestimmen, welchen Inhalt der Platzhalter erwartet.

Die Form‑Klasse bleibt auch nach Kenntnis des Platzhaltertyps relevant:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhaltsplatzhalter wird häufig durch ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) dargestellt.
- Ein gefüllter Bildplatzhalter kann durch ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) dargestellt werden.
- Ein gefüllter Diagramm‑Platzhalter kann durch ein [Chart](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/) dargestellt werden.
- Ein Inhaltsplatzhalter kann mehrere Arten von Inhalt enthalten. Prüfen Sie sowohl [Placeholder.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/placeholder/type/) als auch die Laufzeit‑Form‑Klasse, anstatt anzunehmen, dass jeder Platzhalter ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) ist.

{{% alert color="warning" title="Warning" %}}
[Placeholder.type] beschreibt die Rolle eines Platzhalters; es garantiert nicht die Laufzeitklasse der Form. Verwenden Sie stets eine Typprüfung, bevor Sie auf text‑, bild‑, diagramm‑, tabellen‑ oder medienspezifische Mitglieder zugreifen.
{{% /alert %}}

## **Verstehen von Platzhaltervererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Masterfolie definiert wiederverwendbare Stile und, in einigen Fällen, Master‑Platzhalter.
2. Eine Layoutfolie definiert das Layout, das von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [Shape.get_base_placeholder](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_base_placeholder/) auf, um eine Ebene in dieser Hierarchie nach oben zu gehen. Ein Folien‑Platzhalter gibt normalerweise seinen Layout‑Platzhalter zurück; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode gibt `None` zurück, wenn die Form keinen Basis‑Platzhalter hat.

Das folgende Beispiel listet die Platzhalter der ersten Folie auf und gibt deren Basis‑Platzhalter aus:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Das Bearbeiten eines Platzhalters auf einer normalen Folie erstellt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Eine lokale normale Form hat keinen Basis‑Platzhalter und beginnt nicht zu erben, nur weil sie dieselben Koordinaten einnimmt.

## **Text in einem Platzhalter ändern**

Titel‑, zentrierte‑Titel‑, Untertitel‑, Text‑ und Body‑Platzhalter unterstützen in der Regel Text. Prüfen Sie, ob es sich um ein [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) handelt, bevor Sie dessen [text_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/text_frame/)‑Eigenschaft verwenden.

Dieses Beispiel aktualisiert den ersten Titel‑Platzhalter auf der ersten Folie und speichert das Ergebnis:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Dieses Muster vermeidet, Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhalter als [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/)‑Objekte zu behandeln. Es identifiziert den Platzhalter zudem nach Zweck statt nach einem fragilen Form‑Index.

## **Prompt‑Text auf einem Layout festlegen**

Prompt‑Text ist die Entwurfs‑Anweisung, die in einem leeren Platzhalter angezeigt wird, z. B. *Klicken Sie, um Titel hinzuzufügen*. Setzen Sie benutzerdefinierten Prompt‑Text auf dem Layout‑Platzhalter, anstatt zu versuchen, ihn über die Form‑Sammlung einer normalen Folie zu erreichen. Greifen Sie über [Slide.layout_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/layout_slide/) auf das Layout zu und iterieren Sie über [LayoutSlide.shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/shapes/).

Das folgende Beispiel ändert die Prompt‑Texte für Titel und Untertitel im Layout, das von der ersten Folie verwendet wird:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Prompt‑Text ist kein regulärer Folieninhalt. Er ist für leere Platzhalter in Bearbeitungs‑Apps wie PowerPoint gedacht. Sobald ein Benutzer oder ein Programm echten Inhalt bereitstellt, wird der Prompt nicht mehr angezeigt. Das Ändern eines Prompts ersetzt außerdem keinen vorhandenen Text auf Folien, die das Layout verwenden.

## **Bildplatzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bildplatzhalter bereits gefüllt ist und durch ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) dargestellt wird, ersetzen Sie das Bild über [PictureFillFormat.picture](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/picture/) und [Picture.image](https://reference.aspose.com/slides/de/python-net/aspose.slides/picture/image/).
- Wenn er noch ein leerer Platzhalter ist, fügen Sie mithilfe von [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_picture_frame/) an den Koordinaten des Platzhalters einen Bildrahmen ein und entfernen Sie den leeren Platzhalter.

Das nächste Beispiel unterstützt beide Fälle und speichert die Präsentation:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Der für einen leeren Platzhalter erstellte Ersatz ist ein lokaler Bildrahmen, kein neuer Platzhalter, da [Shape.placeholder](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/placeholder/) schreibgeschützt ist. Er behält die reservierte Position bei, erbt jedoch nicht mehr das platzhalterspezifische Verhalten. Wenn das Beibehalten der Platzhalter‑Beziehung wichtig ist, bereiten Sie den Platzhalter zunächst in PowerPoint vor und aktualisieren Sie anschließend den resultierenden [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) mit Aspose.Slides.

Für Bild‑Transparenz, Zuschnitt und andere bild‑spezifische Effekte siehe [Manage Picture Frames](/slides/de/python-net/picture-frame/). Diese Vorgänge gehören zum Bildrahmen bzw. zum Bild‑Füllformat, nicht zu Platzhalter‑Metadaten.

## **Arbeiten mit Diagramm‑ und Inhaltsplatzhaltern**

Ein gefüllter Diagramm‑Platzhalter kann durch ein [Chart](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm sowohl über den Platzhaltertyp als auch über die Laufzeit‑Klasse, ändert dessen Titel und speichert die Datei:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Ein allgemeiner Inhaltsplatzhalter hat in der Regel [PlaceholderType.OBJECT](https://reference.aspose.com/slides/de/python-net/aspose.slides/placeholdertype/). In PowerPoint fungiert er als Launcher für mehrere Inhaltsarten, einschließlich Diagrammen, Tabellen, Diagrammen, Bildern und Medien. Nachdem er gefüllt wurde, prüfen Sie die tatsächliche Form‑Klasse, um zu erfahren, was er enthält. Spezial‑Layouts können zudem [PlaceholderType.CHART](https://reference.aspose.com/slides/de/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/de/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/de/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/de/python-net/aspose.slides/placeholdertype/) oder [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/de/python-net/aspose.slides/placeholdertype/) bereitstellen.

Aspose.Slides konvertiert keinen leeren [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/)‑Platzhalter in ein [Chart](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/), nur weil [Placeholder.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/placeholder/type/) geändert wird; der Typ ist schreibgeschützt. Um ein leeres Diagramm‑ oder Inhaltsfeld programmgesteuert zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters ein und entfernen anschließend den leeren Platzhalter. Das folgende Beispiel demonstriert dies für ein Diagramm:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

Das hinzugefügte Diagramm ist ein normales lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die speziellen [chart management articles](/slides/de/python-net/powerpoint-charts/), wenn Sie Kategorien, Serien oder Arbeitsblattdaten ersetzen müssen.

## **Vollständiges Beispiel: Text‑ oder Bildinhalt aktualisieren**

Das folgende End‑zu‑Ende‑Beispiel öffnet eine Vorlage, sucht in der ersten Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft die Platzhalter‑ und Form‑Typen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel verzichtet bewusst darauf, einen Form‑Index anzunehmen oder jeden Platzhalter als dieselbe Form‑Klasse zu behandeln.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Was ist ein Basis‑Platzhalter?**

Ein Basis‑Platzhalter ist die entsprechende Form auf dem Layout oder Master, von der ein anderer Platzhalter erbt. Verwenden Sie [Shape.get_base_placeholder](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_base_placeholder/), um ihn abzurufen. Eine normale lokale Form gibt `None` zurück, weil sie nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können über ein Layout vererbte Formatierungen oder Prompt‑Texte ändern, aber der vorhandene Titelinhalt wird auf den normalen Folien gespeichert. Um den tatsächlichen Titeltext in einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren Sie jeden Titel‑Platzhalter.

**Wie verwalte ich Datum‑, Folien‑Nummer‑, Kopf‑ und Fußzeilen‑Platzhalter?**

Verwenden Sie die Header‑ und Footer‑Manager im jeweiligen Folien‑, Layout‑, Master‑, Notiz‑ oder Handout‑Umfang. Siehe [Manage Presentation Header and Footer](/slides/de/python-net/presentation-header-and-footer/) für vollständige Beispiele.