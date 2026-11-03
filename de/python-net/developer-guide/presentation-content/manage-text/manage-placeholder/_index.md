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
- Aufforderungstext
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text-, Bild-, Diagramm- und Inhaltsplatzhalter prüfen und bearbeiten und die Platzhaltervererbung mit Aspose.Slides für Python via .NET verstehen."
---
## **Übersicht**

Ein Platzhalter ist eine Form, die in einer Präsentationsvorlage eine Position für eine bestimmte Art von Inhalt reserviert. Häufige Beispiele sind Titel-, Text-, Bild-, Diagramm- und allgemeine Inhaltsplatzhalter. Im Gegensatz zu einer gewöhnlichen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layout‑Folie oder einer Master‑Folie erben.

Aspose.Slides stellt Platzhalterinformationen über die [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/)‑Eigenschaft bereit. Die Eigenschaft gibt ein [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/)‑Objekt zurück oder `None` für eine normale Form. Verwenden Sie [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/), um zu bestimmen, welchen Inhalt der Platzhalter enthalten soll.

Die Formklasse ist weiterhin wichtig, nachdem Sie den Platzhaltertyp kennen:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhaltsplatzhalter wird häufig durch ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) dargestellt.
- Ein ausgefüllter Bildplatzhalter kann durch ein [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) dargestellt werden.
- Ein ausgefüllter Diagrammplatzhalter kann durch ein [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) dargestellt werden.
- Ein Inhaltsplatzhalter kann verschiedene Arten von Inhalt enthalten. Prüfen Sie sowohl [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) als auch die Laufzeit‑Formklasse, anstatt davon auszugehen, dass jeder Platzhalter ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ist.

{{% alert color="warning" title="Warnung" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) beschreibt die Rolle eines Platzhalters; sie garantiert nicht die Laufzeitklasse der Form. Verwenden Sie stets eine Typprüfung, bevor Sie auf Text‑, Bild‑, Diagramm‑, Tabellen‑ oder medien‑spezifische Member zugreifen.
{{% /alert %}}

## **Verstehen der Platzhaltervererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Master‑Folie definiert wiederverwendbare Stile und, in einigen Fällen, Master‑Platzhalter.
2. Eine Layout‑Folie definiert das Layout, das von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) auf, um eine Ebene in dieser Hierarchie nach oben zu gehen. Ein Folien‑Platzhalter gibt normalerweise seinen Layout‑Platzhalter zurück; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode gibt `None` zurück, wenn die Form keinen Basis‑Platzhalter hat.

Das folgende Beispiel listet die Platzhalter auf der ersten Folie auf und gibt ihre Basis‑Platzhalter aus:

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

Das Bearbeiten eines Platzhalters auf einer normalen Folie erstellt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Eine lokale gewöhnliche Form hat keinen Basis‑Platzhalter und beginnt nicht zu erben, nur weil sie dieselben Koordinaten belegt.

## **Platzhalterstatus entfernen**

Wenn Sie eine Vorlage anpassen, verwenden Sie [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/), um ein bestehendes Objekt als gewöhnliche Form zu behalten. Seine [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/)‑Eigenschaft wird zu `None`, aber die Form bleibt in der Folien‑Sammlung. Im Gegensatz dazu löscht [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) die Form aus dieser Sammlung.

Das folgende Beispiel erfordert `template.pptx` mit mindestens einer Folie und einem nicht leeren Text‑Platzhalter auf der ersten Folie. Verwenden Sie einen Platzhalter mit vom Layout oder Master geerbter Formatierung, um die Auswirkung des Entfernens dieser Beziehung zu sehen. Das Beispiel prüft, dass dieselbe Form erhalten bleibt, ruft die Methode erneut auf der nun gewöhnlichen Form auf und speichert das Ergebnis.

{{% alert color="warning" title="Warnung" %}}
Das Entfernen des Platzhalterstatus bewahrt nicht automatisch vererbte Erscheinungseinstellungen. Das untenstehende Beispiel lässt diese Einstellungen bewusst unverändert, sodass die Ausgabe anders aussehen kann. Eine Form, deren Position und Größe vollständig vererbt wurden, kann nach dem Aufruf Koordinaten und Abmessungen von 0 haben und unsichtbar werden, obwohl sie in der Sammlung verbleibt.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # Aufruf der Methode auf einer gewöhnlichen Form hat keine Auswirkung.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

Für einen passenden Platzhalter geben alle drei Prüfungen `True` aus. Der Text bleibt erhalten, aber vererbte Position, Größe, Drehung, Schriftart, Absatzausrichtung, Text‑Frame‑Abstände, vertikale Verankerung, Füll‑ und Linien‑Einstellungen können sich ändern, wenn die Platzhalter‑Beziehung entfernt wird. Beispielsweise kann vererbte Titel‑Formatierung auf normale Text‑Formatierung zurückfallen. Siehe [Slide Layout](/slides/de/python-net/slide-layout/) für weitere Informationen zu Layouts.

Um das gewünschte Erscheinungsbild zu bewahren, erfassen Sie Position, Größe und Drehung vor dem Aufruf und kopieren Sie die erforderlichen effektiven Formatierungswerte in separate Variablen. Holen Sie diese Werte über [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) und [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/). Verlassen Sie sich nicht nur auf die effektiven Format‑Objekte, da deren Text‑Formatierungswerte nach dem Entfernen der Beziehung geändert werden können. Wenden Sie die erfassten Werte anschließend explizit auf die gewöhnliche Form an, einschließlich Schriftfamilie, Größe, Stil, Farbe, Absatz‑Einstellungen, Text‑Frame‑Einstellungen, Füll‑ und Linien‑Einstellungen, die Ihre Vorlage verwendet.

Vererbte Formgeometrie muss ggf. ebenfalls explizit über [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/) zugewiesen werden. Für einen rechteckigen Text‑Platzhalter bedeutet das die Zuweisung von [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/); das Wiederherstellen nur von Füll‑ und Linien‑Einstellungen stellt das sichtbare Rechteck nicht wieder her. Vorlagen mit zusätzlichen Effekten oder komplexerer Formatierung erfordern ebenfalls die entsprechende Behandlung dieser Einstellungen.

## **Text in einem Platzhalter ändern**

Titel‑, zentrierte‑Titel‑, Untertitel‑, Text‑ und Inhalts‑Platzhalter unterstützen normalerweise Text. Prüfen Sie vor der Verwendung von [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) die Form auf ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).

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

Dieses Muster vermeidet die Behandlung von Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhaltern als [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekte. Es identifiziert den Platzhalter zudem nach Zweck statt nach einem fragilen Form‑Index.

## **Aufforderungstext auf einem Layout festlegen**

Aufforderungstext ist die Design‑Zeit‑Anweisung, die in einem leeren Platzhalter angezeigt wird, z. B. *Klicken, um Titel hinzuzufügen*. Legen Sie benutzerdefinierten Aufforderungstext am Layout‑Platzhalter fest, anstatt zu versuchen, ihn über die Form‑Sammlung einer normalen Folie zu erreichen. Greifen Sie über [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) auf das Layout zu und iterieren Sie über [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/).

Das folgende Beispiel ändert die Titel‑ und Untertitel‑Aufforderungen im Layout, das von der ersten Folie verwendet wird:

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

Aufforderungstext ist kein normaler Folieninhalt. Er ist für leere Platzhalter in Bearbeitungs‑Anwendungen wie PowerPoint gedacht. Sobald ein Benutzer oder ein Programm echten Inhalt liefert, wird die Aufforderung nicht mehr angezeigt. Das Ändern einer Aufforderung ersetzt außerdem nicht den bereits vorhandenen Text auf Folien, die das Layout verwenden.

## **Ein Bild‑Platzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bild‑Platzhalter bereits gefüllt ist und durch ein [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) dargestellt wird, ersetzen Sie das Bild über [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) und [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/).
- Wenn er noch ein leerer Platzhalter ist, fügen Sie an den Koordinaten des Platzhalters einen Bildrahmen mit [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) hinzu und entfernen Sie den leeren Platzhalter.

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

Der für einen leeren Platzhalter erstellte Ersatz ist ein lokaler Bildrahmen, kein neuer Platzhalter, weil [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) schreibgeschützt ist. Er behält die reservierte Position bei, erbt jedoch kein platzhalterspezifisches Verhalten mehr. Wenn das Beibehalten der Platzhalter‑Beziehung entscheidend ist, bereiten Sie den Platzhalter zuerst in PowerPoint vor und aktualisieren dann den resultierenden [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) mit Aspose.Slides.

Für Bildtransparenz, Zuschneiden und andere bild‑spezifische Effekte siehe [Manage Picture Frames](/slides/de/python-net/picture-frame/). Diese Vorgänge gehören zum Bildrahmen bzw. zum Bild‑Füllformat, nicht zu den Platzhalter‑Metadaten.

## **Mit Diagramm‑ und Inhalts‑Platzhaltern arbeiten**

Ein gefüllter Diagramm‑Platzhalter kann durch ein [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm sowohl nach Platzhaltertyp als auch nach Laufzeitklasse, ändert dessen Titel und speichert die Datei:

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

Ein allgemeiner Inhalts‑Platzhalter hat üblicherweise [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/). In PowerPoint fungiert er als Launcher für verschiedene Inhaltsarten, darunter Diagramme, Tabellen, Diagramme, Bilder und Medien. Nachdem er befüllt wurde, prüfen Sie die tatsächliche Formklasse, um zu erfahren, was er enthält. Spezialisierte Layouts können zudem [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/) oder [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/) bereitstellen.

Aspose.Slides konvertiert einen leeren [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Platzhalter nicht in ein [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), nur weil [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) geändert wird; der Typ ist schreibgeschützt. Um ein leeres Diagramm‑ oder Inhaltsfeld programmgesteuert zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters ein und entfernen anschließend den leeren Platzhalter. Das folgende Beispiel demonstriert dies für ein Diagramm:

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

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die dedizierten [Chart‑Management‑Artikel](/slides/de/python-net/powerpoint-charts/), wenn Sie Kategorien, Serien oder Arbeitsblatt‑Daten ersetzen müssen.

## **Vollständiges Beispiel: Text‑ oder Bildinhalt aktualisieren**

Das folgende End‑zu‑Ende‑Beispiel öffnet eine Vorlage, sucht auf der ersten Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft die Platzhalter‑ und Formtypen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel vermeidet bewusst Annahmen über Form‑Indizes oder die Behandlung jedes Platzhalters als gleiche Formklasse.

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

Ein Basis‑Platzhalter ist die entsprechende Form im Layout oder Master, von der ein anderer Platzhalter erbt. Verwenden Sie [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/), um ihn abzurufen. Eine gewöhnliche lokale Form gibt `None` zurück, weil sie nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können über ein Layout vererbte Formatierung oder Aufforderungstext ändern, aber vorhandene Titel‑Inhalte liegen in den normalen Folien. Um den eigentlichen Titeltext einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren Sie jeden Titel‑Platzhalter.

**Wie verwalte ich Platzhalter für Datum, Folien‑Nummer, Kopf‑ und Fußzeile?**

Verwenden Sie die Header‑ und Footer‑Manager im jeweiligen Folien‑, Layout‑, Master‑, Notiz‑ oder Handout‑Umfang. Siehe [Manage Presentation Header and Footer](/slides/de/python-net/presentation-header-and-footer/) für vollständige Beispiele.