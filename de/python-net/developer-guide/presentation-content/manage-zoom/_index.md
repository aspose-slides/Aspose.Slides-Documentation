---
title: Zooms in Präsentationen mit Python verwalten
linktitle: Zoom
type: docs
weight: 60
url: /de/python-net/manage-zoom/
keywords:
- zoom
- Zoom-Frame
- Folien-Zoom
- Abschnitts-Zoom
- Zusammenfassungs-Zoom
- Zoom hinzufügen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und anpassen von Zooms mit Aspose.Slides für Python via .NET — zwischen Abschnitten springen, Miniaturansichten und Übergänge in PPT-, PPTX- und ODP‑Präsentationen hinzufügen."
---

## **Übersicht**
Zooms in PowerPoint ermöglichen das Springen zu und von bestimmten Folien, Abschnitten und Teilen einer Präsentation. Beim Präsentieren kann diese Fähigkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein. 

![overview](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Summary Zoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Slide Zoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Section Zoom](#Section-Zoom).

## **Folien‑Zoom**

Ein Folien‑Zoom kann Ihre Präsentation dynamischer machen, indem er Ihnen erlaubt, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Ablauf Ihrer Präsentation zu unterbrechen. Folien‑Zooms eignen sich gut für kurze Präsentationen ohne viele Abschnitte, können aber auch in anderen Präsentationsszenarien verwendet werden.

Folien‑Zooms helfen Ihnen, in mehrere Informationsstücke zu vertiefen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden. 

![slidezoomsel](slidezoomsel.png)

For slide zoom objects, Aspose.Slides provides the [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/) enumeration, the [ZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) class, and some methods in the [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) class.

### **Erstellen von Zoom‑Frames**
You can add a zoom frame on a slide this way:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2.	Erstellen Sie neue Folien, zu denen Sie verlinken möchten.  
3.	Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.  
4.	Fügen Sie Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) in die erste Folie ein.  
5.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.  

This sample code shows you how to create a zoom frame in a slide:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Neue Folien zur Präsentation hinzufügen
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Erstelle einen Hintergrund für die zweite Folie
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Erstelle ein Textfeld für die zweite Folie
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Erstelle einen Hintergrund für die dritte Folie
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Erstelle ein Textfeld für die dritte Folie
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Add ZoomFrame-Objekte
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Speichere die Präsentation
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **Erstellen von Zoom‑Frames mit benutzerdefinierten Bildern**
With Aspose.Slides for Python via .NET, you can create a zoom frame with an image other than the slide preview image this way: 
1.	Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2.	Erstellen Sie eine neue Folie, zu der Sie verlinken möchten.  
3.	Fügen Sie dem erstellten Folie einen Identifikationstext und einen Hintergrund hinzu.  
4.	Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)‑Objekt, indem Sie ein Bild zur Images‑Collection des Presentation‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.  
5.	Fügen Sie Zoom‑Frames (die den Verweis auf die erstellte Folie enthalten) in die erste Folie ein.  
6.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.  

This python code shows you how to create a zoom frame with a different image:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Eine neue Folie zur Präsentation hinzufügen
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Erstelle einen Hintergrund für die zweite Folie
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Erstelle ein Textfeld für die dritte Folie
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Erstelle ein neues Bild für das Zoom-Objekt
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Zoom-Frame-Objekt hinzufügen
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Speichere die Präsentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formatieren von Zoom‑Frames**
In den vorherigen Abschnitten (oben) haben wir Ihnen gezeigt, wie Sie einfache Zoom‑Frames erstellen. Um komplexere Zoom‑Frames zu erstellen, müssen Sie die Formatierung der Frames ändern. Es gibt mehrere Formatierungseinstellungen, die Sie auf einen Zoom‑Frame anwenden können. 

You can control the formatting of a zoom frame in a slide this way:

1.	Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2.	Erstellen Sie neue Folien, zu denen Sie verlinken möchten.  
3.	Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.  
4.	Fügen Sie Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) in die erste Folie ein.  
5.	Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)‑Objekt, indem Sie ein Bild zur Images‑Collection des Presentation‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.  
6.	Legen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt fest.  
7.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.  
8.	Entfernen Sie den Hintergrund eines Bildes des zweiten Zoom‑Frame‑Objekts.  
5.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.  

This python sample code shows you how to change the formatting of a zoom frame: 
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Neue Folien zur Präsentation hinzufügen
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Erstelle einen Hintergrund für die zweite Folie
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Erstelle ein Textfeld für die zweite Folie
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Erstelle einen Hintergrund für die dritte Folie
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Erstelle ein Textfeld für die dritte Folie
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #ZoomFrame-Objekte hinzufügen
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    #Erstelle ein neues Bild für das Zoom-Objekt
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Setze ein benutzerdefiniertes Bild für das zoomFrame1-Objekt
    zoomFrame1.image = image

    # Setze ein Zoom-Frame-Format für das zoomFrame2-Objekt
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Hintergrund für zoomFrame2-Objekt nicht anzeigen
    zoomFrame2.show_background = False

    #Speichere die Präsentation
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```


## **Abschnitts‑Zoom**

Ein Abschnitts‑Zoom ist ein Link zu einem Abschnitt in Ihrer Präsentation. Sie können Abschnitts‑Zooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders hervorheben möchten. Oder Sie können sie nutzen, um zu verdeutlichen, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind. 

![seczoomsel](seczoomsel.png)

For section zoom objects, Aspose.Slides provides the [SectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) class and some methods under the [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) class.

### **Erstellen von Abschnitts‑Zoom‑Frames**

You can add a section zoom frame to a slide this way:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2.	Erstellen Sie eine neue Folie.  
3.	Fügen Sie dem erstellten Folie einen Identifikations‑Hintergrund hinzu.  
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten.  
5.	Fügen Sie einen Abschnitts‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.  
6.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.  

This python code shows you how to create a zoom frame on a slide:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Fügt der Präsentation eine neue Folie hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.sections.add_section("Section 1", slide)

    # Fügt ein SectionZoomFrame-Objekt hinzu
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Speichert die Präsentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Erstellen von Abschnitts‑Zoom‑Frames mit benutzerdefinierten Bildern**

Using Aspose.Slides for Python, you can create a section zoom frame with a different slide preview image this way: 

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2.	Erstellen Sie eine neue Folie.  
3.	Fügen Sie dem erstellten Folie einen Identifikations‑Hintergrund hinzu.  
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten.  
5.	Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)‑Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.  
6.	Fügen Sie einen Abschnitts‑Zoom‑Frame (der einen Verweis auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.  
7.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.  

This python code shows you how to create a zoom frame with a different image:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Fügt der Präsentation eine neue Folie hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.sections.add_section("Section 1", slide)

    # Erstellt ein neues Bild für das Zoom-Objekt
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Fügt ein SectionZoomFrame-Objekt hinzu
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Speichert die Präsentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formatieren von Abschnitts‑Zoom‑Frames**

To create more complicated section zoom frames, you have to alter a simple frame's formatting. There are several formatting options you can apply to a section zoom frame. 

You can control a section zoom frame's formatting on a slide this way:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2.	Erstellen Sie eine neue Folie.  
3.	Fügen Sie dem erstellten Folie einen Identifikations‑Hintergrund hinzu.  
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten.  
5.	Fügen Sie einen Abschnitts‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.  
6.	Ändern Sie Größe und Position des erstellten Abschnitts‑Zoom‑Objekts.  
7.	Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)‑Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.  
8.	Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt.  
9.	Setzen Sie die *Rückkehr zur Originalfolie aus dem verknüpften Abschnitt*‑Funktion.  
10.	Entfernen Sie den Hintergrund eines Bildes des Abschnitts‑Zoom‑Frame‑Objekts.  
11.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.  
12.	Ändern Sie die Übergangsdauer.  
13.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.  

This python code shows you how to change a section zoom frame's formatting:
```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Fügt der Präsentation eine neue Folie hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.sections.add_section("Section 1", slide)

    # Fügt SectionZoomFrame-Objekt hinzu
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Formatierung für SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Speichert die Präsentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Zusammenfassungs‑Zoom**

A summary zoom is like a landing page where all the pieces of your presentation are displayed at once. When you're presenting, you can use the zoom to go from one place in your presentation to another in any order you like. You can get creative, skip ahead, or revisit pieces of your slide show without interrupting the flow of your presentation.

![overview_image](summaryzoom.png)

For summary zoom objects, Aspose.Slides provides the [SummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/), and [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) class and some methods under the [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) class.

### **Erstellen von Zusammenfassungs‑Zoom**

You can add a summary zoom frame to a slide this way:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.  
3.	Fügen Sie den Zusammenfassungs‑Zoom‑Frame zur ersten Folie hinzu.  
4.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.  

This python code shows you how to create a summary zoom frame on a slide:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Erstelle ein Folien-Array
    for slideNumber in range(5):
        #Füge neue Folien zur Präsentation hinzu
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Erstelle einen Hintergrund für die Folie
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Erstelle ein Textfeld für die Folie
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Erstelle Zoom-Objekte für alle Folien in der ersten Folie
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Setze die ReturnToParent-Eigenschaft, um zur ersten Folie zurückzukehren
        zoomFrame.return_to_parent = True

    # Speichere die Präsentation
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```


### **Hinzufügen und Entfernen von Zusammenfassungs‑Zoom‑Abschnitten**

All sections in a summary zoom frame are represented by [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/) objects, which are stored in the [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) object. You can add or remove a summary zoom section object through the [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) class this way:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.  
3.	Fügen Sie einen Zusammenfassungs‑Zoom‑Frame in die erste Folie ein.  
4.	Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.  
5.	Fügen Sie den erstellten Abschnitt zum Zusammenfassungs‑Zoom‑Frame hinzu.  
6.	Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungs‑Zoom‑Frame.  
7.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.  

This python code shows you how to add and remove sections in a summary zoom frame:
``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Fügt der Präsentation eine neue Folie hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.sections.add_section("Section 1", slide)

    #Fügt der Präsentation eine neue Folie hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.sections.add_section("Section 2", slide)

    # Fügt SummaryZoomFrame-Objekt hinzu
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Fügt der Präsentation eine neue Folie hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt der Präsentation einen neuen Abschnitt hinzu
    section3 = pres.sections.add_section("Section 3", slide)

    # Fügt einen Abschnitt zum Summary Zoom hinzu
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Entfernt Abschnitt aus dem Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Speichert die Präsentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formatieren von Zusammenfassungs‑Zoom‑Abschnitten**

To create more complicated summary zoom section objects, you have to alter a simple frame's formatting. There are several formatting options you can apply to a summary zoom section object. 

You can control the formatting for a summary zoom section object in a summary zoom frame this way:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.  
3.	Fügen Sie einen Zusammenfassungs‑Zoom‑Frame zur ersten Folie hinzu.  
4.	Holen Sie ein SummaryZoomSection‑Objekt für das erste Objekt aus der `SummaryZoomSectionCollection`.  
5.	Erstellen Sie ein `PPImage`‑Objekt, indem Sie ein Bild zur Images‑Collection des [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.  
6.	Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt.  
7.	Setzen Sie die *Rückkehr zur Originalfolie aus dem verknüpften Abschnitt*‑Funktion.  
8.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.  
9.	Ändern Sie die Übergangsdauer.  
10.	Speichern Sie die geänderte Präsentation als PPTX‑Datei.  

This python code shows you how to change the formatting for a summary zoom section object:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Fügt der Präsentation eine neue Folie hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.sections.add_section("Section 1", slide)

    #Fügt der Präsentation eine neue Folie hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt der Präsentation einen neuen Abschnitt hinzu
    pres.sections.add_section("Section 2", slide)

    # Fügt ein SummaryZoomFrame-Objekt hinzu
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Holt das erste SummaryZoomSection-Objekt
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Formatierung für SummaryZoomSection-Objekt
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Speichert die Präsentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich die Rückkehr zur übergeordneten Folie nach Anzeige des Ziels steuern?**

Ja. Der [Zoom frame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) oder [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) hat ein `return_to_parent`‑Verhalten, das, wenn aktiviert, die Betrachter nach dem Besuch des Zielinhalts zurück zur Ausgangsfolie führt.

**Kann ich die 'Geschwindigkeit' oder Dauer der Zoom‑Übergangs anpassen?**

Ja. Zoom unterstützt das Setzen einer `transition_duration`, sodass Sie steuern können, wie lange die Sprunganimation dauert.

**Gibt es Grenzen, wie viele Zoom‑Objekte eine Präsentation enthalten kann?**

Es gibt keine harte API‑Grenze laut Dokumentation. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistung des Viewers ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.