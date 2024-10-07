---
title: Hyperlinks verwalten
type: docs
weight: 20
url: /python-net/manage-hyperlinks/
keywords: "Hyperlink hinzufügen, PowerPoint-Präsentation, PowerPoint-Hyperlink, Text-Hyperlink, Folien-Hyperlink, Formen-Hyperlink, Bild-Hyperlink, Video-Hyperlink, Python"
description: "Hyperlink zu einer PowerPoint-Präsentation in Python hinzufügen"
---

Ein Hyperlink ist ein Verweis auf ein Objekt oder Daten oder einen Ort in etwas. Dies sind gängige Hyperlinks in PowerPoint-Präsentationen:

* Links zu Websites innerhalb von Texten, Formen oder Medien
* Links zu Folien

Aspose.Slides für Python über .NET ermöglicht es Ihnen, viele Aufgaben im Zusammenhang mit Hyperlinks in Präsentationen durchzuführen.

{{% alert color="primary" %}} 

Sie möchten möglicherweise den einfachen, [kostenlosen Online-PowerPoint-Editor von Aspose überprüfen.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **URL-Hyperlinks hinzufügen**

### **URL-Hyperlinks zu Texten hinzufügen**

Dieser Python-Code zeigt Ihnen, wie Sie einen Website-Hyperlink zu einem Text hinzufügen:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: File Format APIs")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "Mehr als 70 % der Fortune-100-Unternehmen vertrauen auf Aspose APIs"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32
    
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **URL-Hyperlinks zu Formen oder Rahmen hinzufügen**

Dieser Beispielcode in Python zeigt Ihnen, wie Sie einen Website-Hyperlink zu einer Form hinzufügen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Mehr als 70 % der Fortune-100-Unternehmen vertrauen auf Aspose APIs"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

### **URL-Hyperlinks zu Medien hinzufügen**

Aspose.Slides ermöglicht es Ihnen, Hyperlinks zu Bildern, Audio- und Videodateien hinzuzufügen.

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einem **Bild** hinzufügen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Bild zur Präsentation hinzufügen
    with open("img.jpeg", "rb") as fs:
        data = fs.read()
        image = pres.images.add_image(data)
        
        # Erstellt einen Bilderrahmen auf Folie 1 basierend auf dem zuvor hinzugefügten Bild
        pictureFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

        pictureFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        pictureFrame.hyperlink_click.tooltip = "Mehr als 70 % der Fortune-100-Unternehmen vertrauen auf Aspose APIs"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einer **Audiodatei** hinzufügen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("audio.mp3", "rb") as fs:
        data = fs.read()
        audio = pres.audios.add_audio(data)
        
        audioFrame = pres.slides[0].shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

        audioFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        audioFrame.hyperlink_click.tooltip = "Mehr als 70 % der Fortune-100-Unternehmen vertrauen auf Aspose APIs"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einem **Video** hinzufügen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("video.avi", "rb") as fs:
        data = fs.read()
        video = pres.videos.add_video(data)
        
        videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 100, 100, video)

        videoFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        videoFrame.hyperlink_click.tooltip = "Mehr als 70 % der Fortune-100-Unternehmen vertrauen auf Aspose APIs"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert  title="Tipp"  color="primary"  %}} 

Sie möchten möglicherweise *[OLE verwalten](https://docs.aspose.com/slides/python-net/manage-ole/)* sehen.

{{% /alert %}}



## **Hyperlinks verwenden, um ein Inhaltsverzeichnis zu erstellen**

Da Hyperlinks es Ihnen ermöglichen, Verweise auf Objekte oder Orte hinzuzufügen, können Sie sie verwenden, um ein Inhaltsverzeichnis zu erstellen.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Inhaltsverzeichnis mit Hyperlinks erstellen:

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
    paragraph.text = "Titel der Folie 2 .......... "

    linkPortion = slides.Portion()
    linkPortion.text = "Seite 2"
    linkPortion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(linkPortion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```



## **Hyperlinks formatieren**

### **Farbe**

Mit der [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/) Eigenschaft in der [IHyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/) Schnittstelle können Sie die Farbe für Hyperlinks festlegen und auch die Farbinformationen von Hyperlinks abrufen. Die Funktion wurde erstmals in PowerPoint 2019 eingeführt, sodass Änderungen bezüglich der Eigenschaft nicht auf ältere PowerPoint-Versionen zutreffen.

Dieser Beispielcode demonstriert eine Operation, bei der Hyperlinks mit unterschiedlichen Farben zur selben Folie hinzugefügt wurden:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Das ist ein Beispiel für einen farbigen Hyperlink.")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.fill_type = slides.FillType.SOLID
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("Das ist ein Beispiel für einen gewöhnlichen Hyperlink.")
    shape2.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```



## **Hyperlinks in Präsentationen entfernen**

### **Hyperlinks aus Texten entfernen**

Dieser Python-Code zeigt Ihnen, wie Sie den Hyperlink aus einem Text in einer Präsentationsfolie entfernen:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    portion.portion_format.hyperlink_manager.remove_hyperlink_click()
    pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Hyperlinks aus Formen oder Rahmen entfernen**

Dieser Python-Code zeigt Ihnen, wie Sie den Hyperlink aus einer Form in einer Präsentationsfolie entfernen: 

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as pres:
   slide = pres.slides[0]
   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()
   pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```



## **Veränderlicher Hyperlink**

Die [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink) Klasse ist veränderlich. Mit dieser Klasse können Sie die Werte für diese Eigenschaften ändern:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.History](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)

Der Codeausschnitt zeigt Ihnen, wie Sie einen Hyperlink zu einer Folie hinzufügen und später seine Tooltipps bearbeiten:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: File Format APIs")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "Mehr als 70 % der Fortune-100-Unternehmen vertrauen auf Aspose APIs"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```




## **Unterstützte Eigenschaften in IHyperlinkQueries**

Sie können auf IHyperlinkQueries aus einer Präsentation, einer Folie oder einem Text zugreifen, für den der Hyperlink definiert ist. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)

Die Klasse IHyperlinkQueries unterstützt diese Methoden und Eigenschaften: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)