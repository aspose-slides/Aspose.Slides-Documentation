---
title: Administrar controles ActiveX en presentaciones con Python
linktitle: ActiveX
type: docs
weight: 80
url: /es/python-net/activex/
keywords:
- ActiveX
- control ActiveX
- administrar ActiveX
- agregar ActiveX
- modificar ActiveX
- reproductor multimedia
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo Aspose.Slides para Python vía .NET aprovecha ActiveX para automatizar y mejorar presentaciones de PowerPoint, ofreciendo a los desarrolladores un control potente sobre las diapositivas."
---

Los controles ActiveX se utilizan en presentaciones. Aspose.Slides para Python vía .NET le permite gestionar controles ActiveX, pero su manipulación es un poco más complicada y diferente de las formas normales de diapositiva. A partir de Aspose.Slides para Python vía .NET 6.9.0, el componente admite la gestión de controles ActiveX. En este momento, puede acceder a los controles ActiveX ya añadidos en su presentación y modificarlos o eliminarlos mediante sus diversas propiedades. Recuerde que los controles ActiveX no son formas y no forman parte de la IShapeCollection de la presentación, sino de la IControlCollection separada. Este artículo muestra cómo trabajar con ellos.

## **Modificar controles ActiveX**
Para administrar un control ActiveX simple, como un cuadro de texto y un botón de comando sencillo en una diapositiva:

1. Crear una instancia de la clase Presentation y cargar la presentación con controles ActiveX.
1. Obtener una referencia a la diapositiva mediante su índice.
1. Acceder a los controles ActiveX de la diapositiva a través de IControlCollection.
1. Acceder al control ActiveX TextBox1 mediante el objeto ControlEx.
1. Cambiar las diferentes propiedades del control ActiveX TextBox1, incluido el texto, la fuente, la altura de la fuente y la posición del marco.
1. Acceder al segundo control llamado CommandButton1.
1. Cambiar el texto del botón, la fuente y la posición.
1. Desplazar la posición de los marcos de los controles ActiveX.
1. Guardar la presentación modificada en un archivo PPTX.

El fragmento de código a continuación actualiza los controles ActiveX en las diapositivas de la presentación como se muestra a continuación.

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
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # cambiando la imagen sustituta. PowerPoint reemplazará esta imagen durante la activación de ActiveX, por lo que a veces está bien dejar la imagen sin cambios.

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

    # cambiando el texto del botón
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # cambiando sustituto
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

    # Guardando la presentación con controles ActiveX editados
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Ahora eliminando controles
    slide.controls.clear()

    # Guardando la presentación con controles ActiveX eliminados
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Agregar control ActiveX Media Player**
Para agregar el control ActiveX Media Player, siga los pasos a continuación:

1. Crear una instancia de la clase Presentation y cargar la presentación de ejemplo con controles ActiveX Media Player.
1. Crear una instancia de la clase Presentation de destino y generar una presentación vacía.
1. Clonar la diapositiva con el control ActiveX Media Player de la presentación de plantilla en la presentación de destino.
1. Acceder a la diapositiva clonada en la presentación de destino.
1. Acceder a los controles ActiveX de la diapositiva mediante IControlCollection.
1. Acceder al control ActiveX Media Player y establecer la ruta del vídeo mediante sus propiedades.
1. Guardar la presentación en un archivo PPTX.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Crear una instancia vacía de presentación
    with slides.Presentation() as newPresentation:

        # Eliminar la diapositiva predeterminada
        newPresentation.slides.remove_at(0)

        # Clonar la diapositiva con el control ActiveX Media Player
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Acceder al control ActiveX Media Player y establecer la ruta del video
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Guardar la presentación
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Aspose.Slides conserva los controles ActiveX al leer y volver a guardarlos si no pueden ejecutarse en el entorno Python?**

Sí. Aspose.Slides los trata como parte de la presentación y puede leer/modificar sus propiedades y marcos; no es necesario ejecutar los controles para conservarlos.

**¿En qué se diferencian los controles ActiveX de los objetos OLE en una presentación?**

Los controles ActiveX son controles interactivos gestionados (botones, cuadros de texto, reproductor multimedia), mientras que [OLE](/slides/es/python-net/manage-ole/) se refiere a objetos de aplicación incrustados (por ejemplo, una hoja de cálculo de Excel). Se almacenan y manejan de forma distinta y poseen modelos de propiedades diferentes.

**¿Los eventos ActiveX y las macros VBA funcionan si el archivo ha sido modificado por Aspose.Slides?**

Aspose.Slides conserva el marcado y los metadatos existentes; sin embargo, los eventos y macros solo se ejecutan dentro de PowerPoint en Windows cuando la seguridad lo permite. La biblioteca no ejecuta VBA.