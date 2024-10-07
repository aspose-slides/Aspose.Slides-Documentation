---
title: Zoom verwalten
type: docs
weight: 60
url: /python-net/manage-zoom/
keywords: "Zoom, Zoomrahmen, Zoom hinzufügen, Zoomrahmen formatieren, Zusammenfassungszoom, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Fügen Sie Zoom oder Zoomrahmen zu PowerPoint-Präsentationen in Python hinzu"
---

## **Überblick**
Zooms in PowerPoint ermöglichen es Ihnen, zwischen bestimmten Folien, Abschnitten und Teilen einer Präsentation zu springen. Diese Fähigkeit, während einer Präsentation schnell durch den Inhalt zu navigieren, kann sehr nützlich sein.

![overview](overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Zusammenfassungszoom](#Zusammenfassungszoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Folienzoom](#Folienzoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Abschnittszoom](#Abschnittszoom).

## **Folienzoom**

Ein Folienzoom kann Ihre Präsentation dynamischer gestalten, indem er es Ihnen ermöglicht, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folienzooms eignen sich hervorragend für kurze Präsentationen ohne viele Abschnitte, können aber auch in verschiedenen Präsentationsszenarien genutzt werden.

Folienzooms helfen Ihnen, mehrere Informationsstücke zu vertiefen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden.

![slidezoomsel](slidezoomsel.png)

Für Folienzoom-Objekte bietet Aspose.Slides die [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/) Aufzählung, das [IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/) Interface und einige Methoden im [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) Interface.

### **Erstellen von Zoomrahmen**
Sie können einen Zoomrahmen auf einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erstellen Sie neue Folien, mit denen Sie verknüpfen möchten.
3. Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4. Fügen Sie Zoomrahmen (die Verweise zu den erstellten Folien enthalten) zur ersten Folie hinzu.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Beispielcode zeigt Ihnen, wie Sie einen Zoomrahmen auf einer Folie erstellen:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Neue Folien zur Präsentation hinzufügen
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Erstellen Sie einen Hintergrund für die zweite Folie
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Erstellen Sie ein Textfeld für die zweite Folie
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Zweite Folie"

    # Erstellen Sie einen Hintergrund für die dritte Folie
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Erstellen Sie ein Textfeld für die dritte Folie
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Dritte Folie"

    #ZoomFrame-Objekte hinzufügen
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Die Präsentation speichern
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Erstellen von Zoomrahmen mit benutzerdefinierten Bildern**
Mit Aspose.Slides für Python über .NET können Sie einen Zoomrahmen mit einem anderen Bild als dem Folienvorschau-Bild folgendermaßen erstellen: 
1. Erstellen Sie eine Instanz der `Presentation`-Klasse.
2. Erstellen Sie eine neue Folie, mit der Sie verknüpfen möchten. 
3. Fügen Sie der erstellten Folie einen Identifikationstext und einen Hintergrund hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem Präsentationsobjekt verknüpft ist und verwendet wird, um den Rahmen zu füllen.
5. Fügen Sie Zoomrahmen (die den Verweis zur erstellten Folie enthalten) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie einen Zoomrahmen mit einem anderen Bild erstellen:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Fügen Sie eine neue Folie zur Präsentation hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Erstellen Sie einen Hintergrund für die zweite Folie
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Erstellen Sie ein Textfeld für die dritte Folie
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Zweite Folie"

    # Erstellen Sie ein neues Bild für das Zoomobjekt
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Fügen Sie das ZoomFrame-Objekt hinzu
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Die Präsentation speichern
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatieren von Zoomrahmen**
In den vorherigen Abschnitten (oben) haben wir Ihnen gezeigt, wie Sie einfache Zoomrahmen erstellen. Um kompliziertere Zoomrahmen zu erstellen, müssen Sie die Formatierung der Rahmen ändern. Sie können mehrere Formatierungseinstellungen auf einen Zoomrahmen anwenden. 

Sie können die Formatierung eines Zoomrahmens auf einer Folie folgendermaßen steuern:

1. Erstellen Sie eine Instanz der `Presentation`-Klasse.
2. Erstellen Sie neue Folien, um darauf zu verlinken.
3. Fügen Sie der erstellten Folie Identifikationstext und Hintergrund hinzu.
4. Fügen Sie Zoomrahmen (die Verweise zu den erstellten Folien enthalten) zur ersten Folie hinzu.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem Präsentationsobjekt verknüpft ist und benutzt wird, um den Rahmen zu füllen.
6. Stellen Sie ein benutzerdefiniertes Bild für das erste Zoomrahmenobjekt ein.
7. Ändern Sie die Linienformatierung für das zweite Zoomrahmenobjekt.
8. Entfernen Sie den Hintergrund von einem Bild des zweiten Zoomrahmenobjekts.
9. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Beispielcode zeigt Ihnen, wie Sie die Formatierung eines Zoomrahmens ändern: 

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Neue Folien zur Präsentation hinzufügen
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Erstellen Sie einen Hintergrund für die zweite Folie
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Erstellen Sie ein Textfeld für die zweite Folie
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Zweite Folie"

    # Erstellen Sie einen Hintergrund für die dritte Folie
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Erstellen Sie ein Textfeld für die dritte Folie
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Dritte Folie"

    #ZoomFrame-Objekte hinzufügen
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Erstellen Sie ein neues Bild für das Zoomobjekt
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Setzen Sie das benutzerdefinierte Bild für das zoomFrame1-Objekt
    zoomFrame1.image = image

    # Setzen Sie ein Zoomrahmenformat für das zoomFrame2-Objekt
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Hintergrund für das zoomFrame2-Objekt nicht anzeigen
    zoomFrame2.show_background = False

    # Die Präsentation speichern
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Abschnittszoom**

Ein Abschnittszoom ist ein Link zu einem Abschnitt in Ihrer Präsentation. Sie können Abschnittszooms verwenden, um zu Abschnitten zurückzukehren, die Sie wirklich betonen möchten. Oder Sie können sie verwenden, um hervorzuheben, wie bestimmte Teile Ihrer Präsentation zusammenhängen.

![seczoomsel](seczoomsel.png)

Für Abschnittszoom-Objekte bietet Aspose.Slides das [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) Interface und einige Methoden im [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) Interface.

### **Erstellen von Abschnittszoomrahmen**

Sie können einen Abschnittszoomrahmen folgendermaßen zu einer Folie hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erstellen Sie eine neue Folie. 
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoomrahmen hinzufügen möchten. 
5. Fügen Sie eine Abschnittszoomrahmen (der Referenzen zum erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie einen Zoomrahmen auf einer Folie erstellen:

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
    pres.sections.add_section("Abschnitt 1", slide)

    # Fügt ein SectionZoomFrame-Objekt hinzu
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Speichert die Präsentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Erstellen von Abschnittszoomrahmen mit benutzerdefinierten Bildern**

Mit Aspose.Slides für Python können Sie einen Abschnittszoomrahmen mit einem anderen Folienvorschau-Bild folgendermaßen erstellen: 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie einen Identifikationshintergrund zur erstellten Folie hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoomrahmen hinzufügen möchten. 
5. Erstellen Sie ein `IPPImage` Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Objekt verknüpft ist und verwendet wird, um den Rahmen zu füllen.
6. Fügen Sie einen Abschnittszoomrahmen hinzu (der einen Verweis auf den erstellten Abschnitt enthält) zur ersten Folie.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie einen Zoomrahmen mit einem anderen Bild erstellen:

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
    pres.sections.add_section("Abschnitt 1", slide)

    # Erstellt ein neues Bild für das Zoomobjekt
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Fügt ein SectionZoomFrame-Objekt hinzu
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Speichert die Präsentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatieren von Abschnittszoomrahmen**

Um kompliziertere Abschnittszoomrahmen zu erstellen, müssen Sie die Formatierung eines einfachen Rahmens ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnittszoomrahmen anwenden können. 

Sie können die Formatierung eines Abschnittszoomrahmens auf einer Folie folgendermaßen steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoomrahmen hinzufügen möchten. 
5. Fügen Sie eine Abschnittszoomrahmen (die Referenzen zum erstellten Abschnitt enthält) zur ersten Folie hinzu.
6. Ändern Sie die Größe und Position des erstellten Abschnittszoomobjekts.
7. Erstellen Sie ein `IPPImage` Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Objekt verknüpft ist und verwendet wird, um den Rahmen zu füllen.
8. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoomrahmenobjekt.
9. Aktivieren Sie die Fähigkeit, *zur ursprünglichen Folie aus dem verknüpften Abschnitt zurückzukehren*. 
10. Entfernen Sie den Hintergrund von einem Bild des Abschnittszoomrahmenobjekts.
11. Ändern Sie die Linienformatierung für das zweite Zoomrahmenobjekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie die Formatierung eines Abschnittszoomrahmens ändern:

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
    pres.sections.add_section("Abschnitt 1", slide)

    # Fügen Sie ein SectionZoomFrame-Objekt hinzu
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

## **Zusammenfassungszoom**

Ein Zusammenfassungszoom ist wie eine Landing Page, auf der alle Teile Ihrer Präsentation auf einmal angezeigt werden. Wenn Sie präsentieren, können Sie den Zoom verwenden, um von einem Ort in Ihrer Präsentation an einen anderen an beliebiger Stelle zu springen. Sie können kreativ werden, vorspringen oder Teile Ihrer Diashow erneut besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](summaryzoom.png)

Für Zusammenfassungszoom-Objekte bietet Aspose.Slides das [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) Interfaces sowie einige Methoden im [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) Interface.

### **Erstellen von Zusammenfassungszoom**

Sie können einen Zusammenfassungszoomrahmen folgendermaßen zu einer Folie hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie den Zusammenfassungszoomrahmen zur ersten Folie hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie einen Zusammenfassungszoomrahmen auf einer Folie erstellen:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Erstellen Sie ein Array von Folien
    for slideNumber in range(5):
        #Neue Folien zur Präsentation hinzufügen
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Erstellen Sie einen Hintergrund für die Folie
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Erstellen Sie ein Textfeld für die Folie
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Folien - {num}".format(num = (slideNumber + 2))

    # Erstellen Sie Zoomobjekte für alle Folien in der ersten Folie
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Setzen Sie die ReturnToParent-Eigenschaft, um zur ersten Folie zurückzukehren
        zoomFrame.return_to_parent = True

    # Präsentation speichern
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **Hinzufügen und Entfernen von Zusammenfassungszoomabschnitten**

Alle Abschnitte in einem Zusammenfassungszoomrahmen werden durch [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) Objekte dargestellt, die in dem [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) Objekt gespeichert sind. Sie können ein Zusammenfassungszoomabschnittsobjekt durch das [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) Interface folgendermaßen hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungszoomrahmen in die erste Folie ein.
4. Fügen Sie eine neue Folie und einen Abschnitt zur Präsentation hinzu.
5. Fügen Sie den erstellten Abschnitt zum Zusammenfassungszoomrahmen hinzu.
6. Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungszoomrahmen.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie Abschnitte in einem Zusammenfassungszoomrahmen hinzufügen und entfernen:

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
    pres.sections.add_section("Abschnitt 1", slide)

    #Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.sections.add_section("Abschnitt 2", slide)

    # Fügt ein SummaryZoomFrame-Objekt hinzu
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    section3 = pres.sections.add_section("Abschnitt 3", slide)

    # Fügt einen Abschnitt zum Zusammenfassungszoom hinzu
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Entfernt einen Abschnitt aus dem Zusammenfassungszoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Speichert die Präsentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatieren von Zusammenfassungszoomabschnitten**

Um kompliziertere Zusammenfassungszoomabschnittobjekte zu erstellen, müssen Sie die Formatierung eines einfachen Rahmens ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungszoomabschnittobjekt anwenden können. 

Sie können die Formatierung für ein Zusammenfassungszoomabschnittobjekt in einem Zusammenfassungszoomrahmen folgendermaßen steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungszoomrahmen zur ersten Folie hinzu.
4. Erhalten Sie ein Zusammenfassungszoomabschnittobjekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
5. Erstellen Sie ein `IPPImage`-Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Objekt verknüpft ist und verwendet wird, um den Rahmen zu füllen.
6. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoomrahmenobjekt.
7. Aktivieren Sie die Fähigkeit, *zur ursprünglichen Folie aus dem verknüpften Abschnitt zurückzukehren*. 
8. Ändern Sie die Linienformatierung für das zweite Zoomrahmenobjekt.
9. Ändern Sie die Übergangsdauer.
10. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie die Formatierung für ein Zusammenfassungszoomabschnittobjekt ändern:

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
    pres.sections.add_section("Abschnitt 1", slide)

    #Fügt eine neue Folie zur Präsentation hinzu
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Fügt einen neuen Abschnitt zur Präsentation hinzu
    pres.sections.add_section("Abschnitt 2", slide)

    # Fügt ein SummaryZoomFrame-Objekt hinzu
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Erhält das erste SummaryZoomSection-Objekt
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Formatierung für das SummaryZoomSection-Objekt
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