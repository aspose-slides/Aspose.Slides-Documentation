---
title: ActiveX
type: docs
weight: 80
url: /de/python-net/activex/
keywords: "ActiveX, ActiveX-Steuerelemente, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Verwalten Sie ActiveX-Steuerelemente in PowerPoint-Präsentationen mit Python"
---

ActiveX-Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für Python über .NET ermöglicht Ihnen die Verwaltung von ActiveX-Steuerelementen, jedoch ist die Verwaltung etwas komplizierter und anders als die von normalen Präsentationsformen. Ab Aspose.Slides für Python über .NET 6.9.0 unterstützt die Komponente die Verwaltung von ActiveX-Steuerelementen. Momentan können Sie bereits hinzugefügte ActiveX-Steuerelemente in Ihrer Präsentation aufrufen und deren verschiedene Eigenschaften ändern oder löschen. Denken Sie daran, dass ActiveX-Steuerelemente keine Formen sind und nicht Teil der IShapeCollection der Präsentation, sondern Teil der separaten IControlCollection. Dieser Artikel zeigt, wie man mit ihnen arbeitet.
## **ActiveX-Steuerelemente ändern**
Um ein einfaches ActiveX-Steuerelement wie ein Textfeld und eine einfache Schaltfläche auf einer Folie zu verwalten:

1. Erstellen Sie eine Instanz der Präsentationsklasse und laden Sie die Präsentation mit den ActiveX-Steuerelementen.
1. Erhalten Sie eine Folienreferenz anhand ihres Index.
1. Greifen Sie auf die ActiveX-Steuerelemente in der Folie zu, indem Sie auf die IControlCollection zugreifen.
1. Greifen Sie auf das ActiveX-Steuerelement TextBox1 über das ControlEx-Objekt zu.
1. Ändern Sie die verschiedenen Eigenschaften des ActiveX-Steuerelements TextBox1, einschließlich Text, Schriftart, Schriftgrad und Rahmenposition.
1. Greifen Sie auf das zweite Steuerelement namens CommandButton1 zu.
1. Ändern Sie die Schaltflächenschrift und -position.
1. Verschieben Sie die Position der ActiveX-Steuerelementrahmen.
1. Schreiben Sie die bearbeitete Präsentation in eine PPTX-Datei.

Der folgende Codeausschnitt aktualisiert die ActiveX-Steuerelemente auf den Präsentationsfolien wie folgt.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Zugriff auf die Präsentation mit ActiveX-Steuerelementen
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Zugriff auf die erste Folie in der Präsentation
    slide = presentation.slides[0]

    # Ändern des Textfeld-Texts
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Geänderter Text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # Ändern des Ersatzbildes. Powerpoint wird dieses Bild während der ActiveX-Aktivierung ersetzen, daher ist es manchmal in Ordnung, das Bild unverändert zu lassen.

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

    # Ändern der Schaltflächenschrift
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


    # Jetzt Steuerelemente entfernen
    slide.controls.clear()

    # Speichern der Präsentation mit geleerten ActiveX-Steuerelementen
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **Aktivieren Sie das ActiveX Mediaplayer-Steuerelement**
Um das ActiveX Mediaplayer-Steuerelement hinzuzufügen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Präsentationsklasse und laden Sie die Beispieldatei mit Mediaplayer ActiveX-Steuerelementen.
1. Erstellen Sie eine Instanz der Zielpräsentationsklasse und generieren Sie eine leere Präsentationsinstanz.
1. Klonen Sie die Folie mit dem Mediaplayer ActiveX-Steuerelement aus der Vorlage in die Zielpräsentation.
1. Greifen Sie auf die geklonte Folie in der Zielpräsentation zu.
1. Greifen Sie auf die ActiveX-Steuerelemente in der Folie zu, indem Sie auf die IControlCollection zugreifen.
1. Greifen Sie auf das Mediaplayer ActiveX-Steuerelement zu und setzen Sie den Videopfad mithilfe seiner Eigenschaften.
1. Speichern Sie die Präsentation in einer PPTX-Datei.

```py
import aspose.slides as slides

# Instanziierung der Präsentationsklasse, die die PPTX-Datei darstellt
with slides.Presentation(path + "template.pptx") as presentation:

    # Erstellen Sie eine leere Präsentationsinstanz
    with slides.Presentation() as newPresentation:

        # Entfernen Sie die Standardfolie
        newPresentation.slides.remove_at(0)

        # Klonen Sie die Folie mit dem Mediaplayer ActiveX-Steuerelement
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Greifen Sie auf das Mediaplayer ActiveX-Steuerelement zu und setzen Sie den Videopfad
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Speichern Sie die Präsentation
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```