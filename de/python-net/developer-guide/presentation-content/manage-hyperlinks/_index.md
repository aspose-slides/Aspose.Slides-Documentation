---
title: Hyperlinks in Präsentationen mit Python verwalten
linktitle: Hyperlink verwalten
type: docs
weight: 20
url: /de/python-net/manage-hyperlinks/
keywords:
- URL hinzufügen
- Hyperlink hinzufügen
- Hyperlink erstellen
- Hyperlink formatieren
- Hyperlink entfernen
- Hyperlink aktualisieren
- Text‑Hyperlink
- Folien‑Hyperlink
- Form‑Hyperlink
- Bild‑Hyperlink
- Video‑Hyperlink
- veränderbarer Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- Python
description: "Mühelose Verwaltung von Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET – Interaktivität und Workflow in Minuten verbessern."
---

## **Übersicht**

Ein Hyperlink ist ein Verweis auf eine externe Ressource, ein Objekt oder ein Datenelement bzw. einen bestimmten Ort innerhalb einer Datei. Häufige Hyperlink‑Typen in PowerPoint‑Präsentationen umfassen:

* Links zu Websites, eingebettet in Text, Formen oder Medien
* Links zu Folien

Aspose.Slides für Python via .NET ermöglicht eine Vielzahl von Hyperlink‑bezogenen Vorgängen in Präsentationen.

## **URL‑Hyperlinks hinzufügen**

Dieser Abschnitt erklärt, wie URL‑Hyperlinks zu Folienelementen hinzugefügt werden, wenn mit Aspose.Slides gearbeitet wird. Er behandelt das Zuweisen von Linkadressen zu Text, Formen und Bildern, um eine reibungslose Navigation während Präsentationen zu gewährleisten.

### **URL‑Hyperlinks zu Text hinzufügen**

Das folgende Codebeispiel zeigt, wie ein Website‑Hyperlink zu Text hinzugefügt wird:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **URL‑Hyperlinks zu Formen oder Rahmen hinzufügen**

Das folgende Codebeispiel zeigt, wie ein Website‑Hyperlink zu einer Form hinzugefügt wird:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **URL‑Hyperlinks zu Medien hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Hyperlinks zu Bild‑, Audio‑ und Videodateien.

Das folgende Codebeispiel zeigt, wie ein Hyperlink zu einem **Bild** hinzugefügt wird:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an image to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Create a picture frame on slide 1 using the image added earlier.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Das folgende Codebeispiel zeigt, wie ein Hyperlink zu einer **Audiodatei** hinzugefügt wird:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Das folgende Codebeispiel zeigt, wie ein Hyperlink zu einem **Video** hinzugefügt wird:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Vielleicht möchten Sie sich [OLE in Präsentationen mit Python verwalten](/slides/de/python-net/manage-ole/) ansehen.
{{% /alert %}}

## **Hyperlinks zum Erstellen eines Inhaltsverzeichnisses verwenden**

Da Hyperlinks es ermöglichen, Objekte oder Orte zu referenzieren, können Sie sie zum Erstellen eines Inhaltsverzeichnisses verwenden.

Der nachstehende Beispielcode zeigt, wie ein Inhaltsverzeichnis mit Hyperlinks erstellt wird:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlinks formatieren**

Dieser Abschnitt zeigt, wie das Aussehen von Hyperlinks in Aspose.Slides formatiert wird. Sie lernen, Farbe und andere Stiloptionen zu steuern, um die Hyperlink‑Formatierung über Text, Formen und Bilder hinweg konsistent zu halten.

### **Hyperlink‑Farbe**

Mit der Eigenschaft [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) der Klasse [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) können Sie die Farbe eines Hyperlinks festlegen und dessen Farbinformation auslesen. Diese Funktion wurde in PowerPoint 2019 eingeführt, sodass Änderungen über diese Eigenschaft nicht für frühere PowerPoint‑Versionen gelten.

Das folgende Beispiel demonstriert, wie Hyperlinks mit unterschiedlichen Farben zur selben Folie hinzugefügt werden:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlinks aus Präsentationen entfernen**

Dieser Abschnitt erklärt, wie Hyperlinks aus Präsentationen entfernt werden, wenn mit Aspose.Slides gearbeitet wird. Sie lernen, Linkziele aus Text, Formen und Bildern zu entfernen, während der ursprüngliche Inhalt und das Format erhalten bleiben.

### **Hyperlinks aus Text entfernen**

Der folgende Beispielcode zeigt, wie Hyperlinks aus Text auf einer Präsentationsfolie entfernt werden:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Hyperlinks aus Formen oder Rahmen entfernen**

Der folgende Beispielcode zeigt, wie Hyperlinks aus Formen auf einer Präsentationsfolie entfernt werden: 

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Veränderbare Hyperlinks**

Die Klasse [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) ist veränderbar. Mit dieser Klasse können Sie die Werte der folgenden Eigenschaften ändern:

- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

Das folgende Code‑Snippet zeigt, wie ein Hyperlink zu einer Folie hinzugefügt und anschließend sein Tooltip bearbeitet wird:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Unterstützte Eigenschaften in IHyperlinkQueries**

Sie können [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) aus der Präsentation, Folie oder dem Text, der den Hyperlink enthält, aufrufen.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/)

Die Klasse [HyperlinkQueries] unterstützt folgende Methoden: 

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Vielleicht möchten Sie Asposes einfachen, kostenlosen Online‑[PowerPoint‑Editor](https://products.aspose.app/slides/editor) ansehen.
{{% /alert %}}

## **FAQ**

**Wie kann ich eine interne Navigation nicht nur zu einer Folie, sondern zu einem „Abschnitt“ oder der ersten Folie eines Abschnitts erstellen?**

Abschnitte in PowerPoint sind Gruppierungen von Folien; die Navigation zielt technisch auf eine bestimmte Folie ab. Um zu einem Abschnitt zu navigieren, verlinkt man in der Regel zu dessen erster Folie.

**Kann ich einem Master‑Folienelement einen Hyperlink zuweisen, sodass er auf allen Folien funktioniert?**

Ja. Master‑Folien‑ und Layout‑Elemente unterstützen Hyperlinks. Solche Links erscheinen auf den untergeordneten Folien und sind während der Vorführung anklickbar.

**Werden Hyperlinks beim Exportieren nach PDF, HTML, Bildern oder Video erhalten bleiben?**

In [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/) und [HTML](/slides/de/python-net/convert-powerpoint-to-html/) ja — Links werden im Allgemeinen erhalten. Beim Exportieren zu [Bildern](/slides/de/python-net/convert-powerpoint-to-png/) und [Video](/slides/de/python-net/convert-powerpoint-to-video/) geht die Klickbarkeit verloren, da diese Formate (Rasterbilder/Video) keine Hyperlinks unterstützen.