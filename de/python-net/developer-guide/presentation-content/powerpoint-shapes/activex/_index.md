---
title: ActiveX-Steuerelemente in Präsentationen mit Python verwalten
linktitle: ActiveX
type: docs
weight: 80
url: /de/python-net/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Media Player
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python via .NET ActiveX nutzt, um PowerPoint-Präsentationen zu automatisieren und zu erweitern, und Entwicklern leistungsstarke Kontrolle über Folien bietet."
---

ActiveX-Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für Python via .NET ermöglicht die Verwaltung von ActiveX-Steuerelementen, aber deren Verwaltung ist etwas kniffliger und unterscheidet sich von normalen Präsentationsformen. Ab Aspose.Slides für Python via .NET 6.9.0 unterstützt die Komponente die Verwaltung von ActiveX-Steuerelementen. Derzeit können Sie bereits hinzugefügte ActiveX-Steuerelemente in Ihrer Präsentation über deren verschiedene Eigenschaften abrufen und ändern oder löschen. Beachten Sie, dass ActiveX-Steuerelemente keine Formen sind und nicht Teil der IShapeCollection der Präsentation, sondern der separaten IControlCollection sind. Dieser Artikel zeigt, wie man mit ihnen arbeitet.

## **ActiveX-Steuerelemente ändern**
1. Erstellen Sie eine Instanz der Presentation‑Klasse und laden Sie die Präsentation, die ActiveX‑Steuerelemente enthält.  
1. Holen Sie eine Folienreferenz anhand ihres Index.  
1. Greifen Sie über die IControlCollection auf die ActiveX‑Steuerelemente in der Folie zu.  
1. Greifen Sie mit dem ControlEx‑Objekt auf das ActiveX‑Steuerelement TextBox1 zu.  
1. Ändern Sie die verschiedenen Eigenschaften des ActiveX‑Steuerelements TextBox1, einschließlich Text, Schriftart, Schriftgröße und Rahmenposition.  
1. Greifen Sie auf das zweite Zugriffssteuerelement mit dem Namen CommandButton1 zu.  
1. Ändern Sie die Beschriftung, die Schriftart und die Position des Buttons.  
1. Verschieben Sie die Position der Rahmen der ActiveX‑Steuerelemente.  
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.  

Das untenstehende Code‑Snippet aktualisiert die ActiveX‑Steuerelemente auf den Präsentationsfolien wie unten gezeigt.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Zugriff auf die Präsentation mit ActiveX-Steuerelementen
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Zugriff auf die erste Folie in der Präsentation
    slide = presentation.slides[0]

    # Ändern des TextBox-Textes
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # Ändern des Ersatzbildes. PowerPoint ersetzt dieses Bild während der ActiveX-Aktivierung, sodass es manchmal in Ordnung ist, das Bild unverändert zu lassen.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # Ändern der Schaltflächenbeschriftung
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # Ändern des Ersatzes
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # Verschieben der ActiveX-Rahmen um 100 Punkte nach unten
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # Speichern der Präsentation mit bearbeiteten ActiveX-Steuerelementen
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Jetzt werden die Steuerelemente entfernt
    slide.controls.clear()

    # Speichern der Präsentation mit gelöschten ActiveX-Steuerelementen
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **ActiveX Media Player‑Steuerelement hinzufügen**
1. Erstellen Sie eine Instanz der Presentation‑Klasse und laden Sie die Beispielpräsentation, die Media‑Player‑ActiveX‑Steuerelemente enthält.  
1. Erstellen Sie eine Instanz der Ziel‑Presentation‑Klasse und erzeugen Sie eine leere Präsentationsinstanz.  
1. Klonen Sie die Folie mit dem Media‑Player‑ActiveX‑Steuerelement aus der Vorlagenpräsentation in die Ziel‑Presentation.  
1. Greifen Sie auf die geklonte Folie in der Ziel‑Presentation zu.  
1. Greifen Sie über die IControlCollection auf die ActiveX‑Steuerelemente in der Folie zu.  
1. Greifen Sie auf das Media‑Player‑ActiveX‑Steuerelement zu und setzen Sie den Videopfad über dessen Eigenschaften.  
1. Speichern Sie die Präsentation in einer PPTX‑Datei.  

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt
with slides.Presentation(path + "template.pptx") as presentation:

    # Erstellen Sie eine leere Präsentationsinstanz
    with slides.Presentation() as newPresentation:

        # Entfernen Sie die Standardsfolie
        newPresentation.slides.remove_at(0)

        # Klonen Sie die Folie mit dem Media Player ActiveX-Steuerelement
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Greifen Sie auf das Media Player ActiveX-Steuerelement zu und setzen Sie den Videopfad
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Speichern Sie die Präsentation
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Behält Aspose.Slides ActiveX‑Steuerelemente bei, wenn sie beim Lesen und erneuten Speichern nicht im Python‑Laufzeitumfeld ausgeführt werden können?**  
Ja. Aspose.Slides behandelt sie als Teil der Präsentation und kann ihre Eigenschaften und Rahmen lesen/ändern; das Ausführen der Steuerelemente selbst ist nicht erforderlich, um sie zu erhalten.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten in einer Präsentation?**  
ActiveX‑Steuerelemente sind interaktive, verwaltete Steuerelemente (Buttons, Textfelder, Media‑Player), während [OLE](/slides/de/python-net/manage-ole/) sich auf eingebettete Anwendungsobjekte (z. B. ein Excel‑Arbeitsblatt) bezieht. Sie werden unterschiedlich gespeichert und verarbeitet und besitzen unterschiedliche Eigenschaftsmodelle.

**Funktionieren ActiveX‑Ereignisse und VBA‑Makros, wenn die Datei von Aspose.Slides geändert wurde?**  
Aspose.Slides bewahrt das vorhandene Markup und die Metadaten; Ereignisse und Makros werden jedoch nur innerhalb von PowerPoint unter Windows ausgeführt, wenn die Sicherheit es zulässt. Die Bibliothek führt kein VBA aus.