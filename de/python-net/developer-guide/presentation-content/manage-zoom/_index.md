---
title: Zooms in Präsentationen mit Python verwalten
linktitle: Zoom
type: docs
weight: 60
url: /de/python-net/manage-zoom/
keywords:
- Zoom
- Zoom-Frame
- Folienzoom
- Abschnittszoom
- Übersichtszoom
- Zoom hinzufügen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und anpassen von Zooms mit Aspose.Slides für Python via .NET – springen Sie zwischen Abschnitten, fügen Sie Miniaturansichten und Übergänge in PPT-, PPTX- und ODP-Präsentationen hinzu."
---

## **Übersicht**
Zooms in PowerPoint ermöglichen das Springen zu und von bestimmten Folien, Abschnitten und Teilen einer Präsentation. Beim Präsentieren kann diese schnelle Navigation sehr nützlich sein. 

![Übersicht](overview.png)

* Um die gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Übersichtszoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Folienzoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Abschnittszoom](#Section-Zoom).

## **Folienzoom**

Ein Folienzoom kann Ihre Präsentation dynamischer machen, indem Sie frei zwischen Folien in beliebiger Reihenfolge navigieren können, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folienzooms eignen sich gut für kurze Präsentationen ohne viele Abschnitte, können aber dennoch in verschiedenen Präsentationsszenarien verwendet werden.

Folienzooms helfen Ihnen, in mehrere Informationsstücke zu vertiefen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden. 

![slidezoomsel](slidezoomsel.png)

Für Folienzoom‑Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/), das Interface [IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) bereit.

### **Erstellen von Zoom‑Frames**
Sie können einen Zoom‑Frame auf einer Folie folgendermaßen hinzufügen:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2.	Erstellen Sie neue Folien, zu denen Sie verlinken möchten. 
3.	Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4.	Fügen Sie Zoom‑Frames (die Referenzen zu den erstellten Folien enthalten) in die erste Folie ein.
5.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieses Beispiel zeigt, wie Sie einen Zoom‑Frame in einer Folie erstellen:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Neue Folien zur Präsentation hinzufügen
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Hintergrund für die zweite Folie erstellen
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Textfeld für die zweite Folie erstellen
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Hintergrund für die dritte Folie erstellen
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Textfeld für die dritte Folie erstellen
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #ZoomFrame-Objekte hinzufügen
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Präsentation speichern
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **Erstellen von Zoom‑Frames mit benutzerdefinierten Bildern**
Mit Aspose.Slides for Python via .NET können Sie einen Zoom‑Frame mit einem anderen Bild als dem Folienvorschau‑Bild folgendermaßen erstellen: 
1.	Erstellen Sie eine Instanz der `Presentation`‑Klasse.
2.	Erstellen Sie eine neue Folie, zu der Sie verlinken möchten. 
3.	Fügen Sie der erstellten Folie einen Identifikationstext und einen Hintergrund hinzu.
4.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)‑Objekt, indem Sie ein Bild zur Images‑Sammlung des Presentation‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
5.	Fügen Sie Zoom‑Frames (die die Referenz zur erstellten Folie enthalten) in die erste Folie ein.
6.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Eine neue Folie zur Präsentation hinzufügen
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Hintergrund für die zweite Folie erstellen
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Textfeld für die dritte Folie erstellen
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Neues Bild für das Zoom-Objekt erstellen
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #ZoomFrame-Objekt hinzufügen
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Präsentation speichern
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formatieren von Zoom‑Frames**
In den vorherigen Abschnitten (oben) haben wir gezeigt, wie Sie einfache Zoom‑Frames erstellen. Um komplexere Zoom‑Frames zu erstellen, müssen Sie die Formatierung der Frames ändern. Es gibt mehrere Formatierungseinstellungen, die Sie auf einen Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Zoom‑Frames in einer Folie folgendermaßen steuern:

1.	Erstellen Sie eine Instanz der `Presentation`‑Klasse.
2.	Erstellen Sie neue Folien, zu denen Sie verlinken.
3.	Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4.	Fügen Sie Zoom‑Frames (die Referenzen zu den erstellten Folien enthalten) in die erste Folie ein.
5.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)‑Objekt, indem Sie ein Bild zur Images‑Sammlung des Presentation‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
6.	Weisen Sie dem ersten Zoom‑Frame‑Objekt ein benutzerdefiniertes Bild zu.
7.	Ändern Sie das Linienformat des zweiten Zoom‑Frame‑Objekts.
8.	Entfernen Sie den Hintergrund eines Bildes des zweiten Zoom‑Frame‑Objekts.
5.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Beispielcode zeigt, wie Sie die Formatierung eines Zoom‑Frames ändern: 
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Neue Folien zur Präsentation hinzufügen
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Hintergrund für die zweite Folie erstellen
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Textfeld für die zweite Folie erstellen
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Hintergrund für die dritte Folie erstellen
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Textfeld für die dritte Folie erstellen
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #ZoomFrame-Objekte hinzufügen
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Neues Bild für das Zoom-Objekt erstellen
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Benutzerdefiniertes Bild für zoomFrame1-Objekt festlegen
    zoomFrame1.image = image

    # Zoom-Frame-Format für zoomFrame2-Objekt festlegen
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Hintergrund für zoomFrame2-Objekt nicht anzeigen
    zoomFrame2.show_background = False

    # Präsentation speichern
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```


## **Abschnittszoom**

Ein Abschnittszoom ist ein Link zu einem Abschnitt Ihrer Präsentation. Sie können Abschnittszooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders hervorheben möchten. Oder Sie nutzen sie, um zu verdeutlichen, wie bestimmte Teile Ihrer Präsentation miteinander verbunden sind. 

![seczoomsel](seczoomsel.png)

Für Abschnittszoom‑Objekte stellt Aspose.Slides das Interface [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) bereit.

### **Erstellen von Abschnittszoom‑Frames**

Sie können einen Abschnittszoom‑Frame zu einer Folie folgendermaßen hinzufügen:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2.	Erstellen Sie eine neue Folie. 
3.	Fügen Sie der erstellten Folie einen Identifikations‑Hintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.	Fügen Sie einen Abschnittszoom‑Frame (der Referenzen zum erstellten Abschnitt enthält) zur ersten Folie hinzu.
6.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie Sie einen Zoom‑Frame auf einer Folie erstellen:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.sections.add_section("Section 1", slide)

    # Fügt ein SectionZoomFrame-Objekt hinzu
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Speichert die Präsentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Erstellen von Abschnittszoom‑Frames mit benutzerdefinierten Bildern**

Mit Aspose.Slides for Python können Sie einen Abschnittszoom‑Frame mit einem anderen Folienvorschau‑Bild folgendermaßen erstellen: 

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2.	Erstellen Sie eine neue Folie.
3.	Fügen Sie der erstellten Folie einen Identifikations‑Hintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.	Erstellen Sie ein `IPPImage`‑Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
6.	Fügen Sie einen Abschnittszoom‑Frame (der eine Referenz zum erstellten Abschnitt enthält) zur ersten Folie hinzu.
7.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie Sie einen Zoom‑Frame mit einem anderen Bild erstellen:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.sections.add_section("Section 1", slide)

    # Erstellt ein neues Bild für das Zoom-Objekt
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Fügt ein SectionZoomFrame-Objekt hinzu
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Speichert die Präsentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formatieren von Abschnittszoom‑Frames**

Um komplexere Abschnittszoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnittszoom‑Frame anwenden können. 

Sie können die Formatierung eines Abschnittszoom‑Frames auf einer Folie folgendermaßen steuern:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2.	Erstellen Sie eine neue Folie.
3.	Fügen Sie der erstellten Folie einen Identifikations‑Hintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.	Fügen Sie einen Abschnittszoom‑Frame (der Referenzen zum erstellten Abschnitt enthält) zur ersten Folie hinzu.
6.	Ändern Sie Größe und Position des erstellten Abschnittszoom‑Objekts.
7.	Erstellen Sie ein `IPPImage`‑Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
8.	Weisen Sie dem erstellten Abschnittszoom‑Frame‑Objekt ein benutzerdefiniertes Bild zu.
9.	Stellen Sie die *Zurück‑zur‑Originalfolie‑aus‑dem‑verlinkten‑Abschnitt*-Funktion ein. 
10.	Entfernen Sie den Hintergrund eines Bildes des Abschnittszoom‑Frame‑Objekts.
11.	Ändern Sie das Linienformat des zweiten Zoom‑Frame‑Objekts.
12.	Ändern Sie die Übergangsdauer.
13.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie Sie die Formatierung eines Abschnittszoom‑Frames ändern:
```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.sections.add_section("Section 1", slide)

    # Fügt ein SectionZoomFrame-Objekt hinzu
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


## **Übersichtszoom**

Ein Übersichtszoom ist wie eine Landing‑Page, auf der alle Teile Ihrer Präsentation auf einmal angezeigt werden. Beim Präsentieren können Sie den Zoom verwenden, um von einer Stelle der Präsentation zu einer anderen in beliebiger Reihenfolge zu springen. Sie können kreativ sein, Vorsprünge machen oder Teile Ihrer Bildschirmpräsentation erneut besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![summaryzoom](summaryzoom.png)

Für Übersichtszoom‑Objekte stellt Aspose.Slides die Interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) sowie einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) bereit.

### **Erstellen von Übersichtszoom**

Sie können einen Übersichtszoom‑Frame zu einer Folie folgendermaßen hinzufügen:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie den Übersichtszoom‑Frame zur ersten Folie hinzu.
4.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie Sie einen Übersichtszoom‑Frame auf einer Folie erstellen:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Folien-Array erstellen
    for slideNumber in range(5):
        # Neue Folien zur Präsentation hinzufügen
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Hintergrund für die Folie erstellen
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Textfeld für die Folie erstellen
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Zoom-Objekte für alle Folien in der ersten Folie erstellen
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Setze die ReturnToParent-Eigenschaft, um zur ersten Folie zurückzukehren
        zoomFrame.return_to_parent = True

    # Präsentation speichern
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```


### **Hinzufügen und Entfernen von Übersichtszoom‑Abschnitten**

Alle Abschnitte in einem Übersichtszoom‑Frame werden durch [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/)‑Objekte repräsentiert, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/)‑Objekt gespeichert sind. Sie können ein Übersichtszoom‑Abschnitts‑Objekt über das [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/)‑Interface folgendermaßen hinzufügen oder entfernen:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie einen Übersichtszoom‑Frame in die erste Folie ein.
4.	Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5.	Fügen Sie den erstellten Abschnitt zum Übersichtszoom‑Frame hinzu.
6.	Entfernen Sie den ersten Abschnitt aus dem Übersichtszoom‑Frame.
7.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie Sie Abschnitte in einem Übersichtszoom‑Frame hinzufügen und entfernen:
``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.sections.add_section("Section 1", slide)

    #Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.sections.add_section("Section 2", slide)

    # Fügt ein SummaryZoomFrame-Objekt hinzu
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    section3 = pres.sections.add_section("Section 3", slide)

    # Fügt einen Abschnitt zum Summary Zoom hinzu
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Entfernt einen Abschnitt aus dem Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Speichert die Präsentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formatieren von Übersichtszoom‑Abschnitten**

Um komplexere Übersichtszoom‑Abschnitts‑Objekte zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Übersichtszoom‑Abschnitts‑Objekt anwenden können. 

Sie können die Formatierung eines Übersichtszoom‑Abschnitts‑Objekts in einem Übersichtszoom‑Frame folgendermaßen steuern:

1.	Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie einen Übersichtszoom‑Frame zur ersten Folie hinzu.
4.	Holen Sie ein Übersichtszoom‑Abschnitts‑Objekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
5.	Erstellen Sie ein `IPPImage`‑Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
6.	Weisen Sie dem erstellten Abschnittszoom‑Frame‑Objekt ein benutzerdefiniertes Bild zu.
7.	Stellen Sie die *Zurück‑zur‑Originalfolie‑aus‑dem‑verlinkten‑Abschnitt*-Funktion ein. 
8.	Ändern Sie das Linienformat des zweiten Zoom‑Frame‑Objekts.
9.	Ändern Sie die Übergangsdauer.
10.	Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie Sie die Formatierung eines Übersichtszoom‑Abschnitts‑Objekts ändern:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.sections.add_section("Section 1", slide)

    #Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt einen neuen Abschnitt zur Präsentation hinzu
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

**Kann ich das Zurückkehren zur „Eltern“-Folie nach dem Anzeigen des Ziels steuern?**

Ja. Der [Zoom frame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) oder [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) verfügt über ein `return_to_parent`‑Verhalten, das, wenn aktiviert, die Betrachter nach dem Besuch des Zielinhalts zur Ausgangsfolie zurücksendet.

**Kann ich die „Geschwindigkeit“ oder Dauer des Zoom‑Übergangs anpassen?**

Ja. Zoom unterstützt das Setzen einer `transition_duration`, sodass Sie steuern können, wie lange die Sprunganimation dauert.

**Gibt es Beschränkungen, wie viele Zoom‑Objekte eine Präsentation enthalten kann?**

Es gibt keine harte API‑Grenze laut Dokumentation. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistung des Viewers ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.