---
title: ActiveX
type: docs
weight: 80
url: /es/python-net/activex/
keywords: "ActiveX, controles ActiveX, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Gestionar controles ActiveX en una presentación de PowerPoint en Python"
---

Los controles ActiveX se utilizan en presentaciones. Aspose.Slides para Python a través de .NET te permite gestionar controles ActiveX, pero gestionarlos es un poco más complicado y diferente de las formas normales de presentación. A partir de Aspose.Slides para Python a través de .NET 6.9.0, el componente admite la gestión de controles ActiveX. En este momento, puedes acceder a los controles ActiveX que ya se han añadido en tu presentación y modificarlos o eliminarlos usando sus diversas propiedades. Recuerda que los controles ActiveX no son formas y no forman parte de la IShapeCollection de la presentación, sino de la IControlCollection separada. Este artículo muestra cómo trabajar con ellos.
## **Modificar Controles ActiveX**
Para gestionar un control ActiveX simple como un cuadro de texto y un botón de comando simple en una diapositiva:

1. Crea una instancia de la clase Presentation y carga la presentación con controles ActiveX en ella.
1. Obtén una referencia a la diapositiva por su índice.
1. Accede a los controles ActiveX en la diapositiva accediendo a la IControlCollection.
1. Accede al control ActiveX TextBox1 usando el objeto ControlEx.
1. Cambia las diferentes propiedades del control ActiveX TextBox1, incluyendo texto, fuente, altura de fuente y posición del marco.
1. Accede al segundo control llamado CommandButton1.
1. Cambia el texto del botón, la fuente y la posición.
1. Cambia la posición de los marcos de los controles ActiveX.
1. Escribe la presentación modificada en un archivo PPTX.

El siguiente fragmento de código actualiza los controles ActiveX en las diapositivas de la presentación como se muestra a continuación.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Accediendo a la presentación con controles ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Accediendo a la primera diapositiva en la presentación
    slide = presentation.slides[0]

    # cambiando el texto del TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Texto cambiado"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # cambiando la imagen sustituta. PowerPoint reemplazará esta imagen durante la activación de ActiveX, así que a veces está bien dejar la imagen sin cambios.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # fuente = draw.Font(control.properties["FontName"], 14)
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

    # cambiando el texto del Botón
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MensajeBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # cambiando la imagen sustituta
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # fuente = draw.Font(control.properties["FontName"], 14)
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
    
    # Moviendo los marcos ActiveX 100 puntos hacia abajo
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

    # Guardar la presentación con los controles ActiveX editados
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Ahora eliminando los controles
    slide.controls.clear()

    # Guardando la presentación con los controles ActiveX limpiados
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **Agregar Control de Reproductor Multimedia ActiveX**
Para agregar un control de Reproductor Multimedia ActiveX, por favor realiza los siguientes pasos:

1. Crea una instancia de la clase Presentation y carga la presentación de muestra con controles ActiveX de Reproductor Multimedia en ella.
1. Crea una instancia de la clase Presentation de destino y genera una instancia de presentación vacía.
1. Clona la diapositiva con el control ActiveX de Reproductor Multimedia en la presentación de plantilla a la Presentación de destino.
1. Accede a la diapositiva clonada en la Presentación de destino.
1. Accede a los controles ActiveX en la diapositiva accediendo a la IControlCollection.
1. Accede al control ActiveX de Reproductor Multimedia y establece la ruta del video usando sus propiedades.
1. Guarda la presentación en un archivo PPTX.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Crear una instancia de presentación vacía
    with slides.Presentation() as newPresentation:

        # Eliminar la diapositiva predeterminada
        newPresentation.slides.remove_at(0)

        # Clonar diapositiva con Control ActiveX de Reproductor Multimedia
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Acceder al control ActiveX de Reproductor Multimedia y establecer la ruta del video
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Guardar la presentación
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```