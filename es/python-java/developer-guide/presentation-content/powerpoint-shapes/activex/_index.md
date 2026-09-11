---
title: Gestionar controles ActiveX en presentaciones usando Python
linktitle: ActiveX
type: docs
weight: 80
url: /es/python-java/activex/
keywords:
- ActiveX
- control ActiveX
- gestionar ActiveX
- añadir ActiveX
- modificar ActiveX
- reproductor multimedia
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo Aspose.Slides para Python a través de Java utiliza ActiveX para automatizar y mejorar presentaciones de PowerPoint, ofreciendo a los desarrolladores un control potente sobre las diapositivas."
---
## **Introducción**

Los controles ActiveX se usan en presentaciones. Aspose.Slides para Python a través de Java le permite agregar y administrar controles ActiveX, pero son un poco más complicados de gestionar en comparación con las formas normales de la presentación. Aspose.Slides admite la incorporación de controles ActiveX Media Player. Tenga en cuenta que los controles ActiveX no son formas; no forman parte de la presentación’s [ShapeCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/). En su lugar forman parte de la [ControlCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/controlcollection/) separada. En este tema, le mostraremos cómo trabajar con ellos.

## **Agregar un control ActiveX Media Player a una diapositiva**

Para agregar un control ActiveX Media Player, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y genere una instancia de presentación vacía.
2. Acceda a la diapositiva de destino en [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
3. Agregue el control ActiveX Media Player mediante el método [addControl](https://reference.aspose.com/slides/es/python-java/aspose.slides/controlcollection/#addControl) expuesto por [ControlCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/controlcollection/).
4. Acceda al control ActiveX Media Player y establezca la ruta del video utilizando sus propiedades.
5. Guarde la presentación como archivo PPTX.

Este fragmento de código, basado en los pasos anteriores, muestra cómo agregar un control ActiveX Media Player a una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Crear una presentación vacía.
presentation = Presentation()
try:
    # Añadir el control ActiveX Media Player.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Establecer la ruta del vídeo.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Guardar la presentación.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modificar un control ActiveX**

{{% alert color="info" title="Note" %}}
Aspose.Slides para Python a través de Java proporciona componentes para gestionar controles ActiveX. Puede acceder al control ActiveX ya agregado en su presentación y modificarlo o eliminarlo mediante sus propiedades.
{{% /alert %}}

Para gestionar un control ActiveX simple, como un cuadro de texto y un botón de comando sencillo en una diapositiva, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargue la presentación que contiene controles ActiveX.
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Acceda a los controles ActiveX en la diapositiva mediante el acceso a la [ControlCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/controlcollection/).
4. Acceda al control ActiveX TextBox1 utilizando el objeto [Control](https://reference.aspose.com/slides/es/python-java/aspose.slides/control/).
5. Modifique las propiedades del control ActiveX TextBox1, que incluyen texto, fuente, altura de la fuente y posición del marco.
6. Acceda al segundo control ActiveX llamado CommandButton1.
7. Modifique el texto del botón, la fuente y la posición.
8. Desplace la posición de los marcos de los controles ActiveX.
9. Guarde la presentación modificada en un archivo PPTM.

Este fragmento de código, basado en los pasos anteriores, muestra cómo gestionar un control ActiveX sencillo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# Cargar la presentación con controles ActiveX.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Acceder a la primera diapositiva.
        slide = presentation.getSlides().get_Item(0)

        # Cambiar el texto del cuadro de texto.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Cambiar la imagen sustituta. PowerPoint la reemplaza durante la activación de ActiveX,
            # por lo que a veces puede dejarse sin cambios.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Cambiar el texto del botón.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Cambiar la imagen sustituta.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Mover los controles 100 puntos hacia abajo.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Eliminar los controles.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Aspose.Slides conserva los controles ActiveX al leer y volver a guardar si no pueden ejecutarse en el entorno de Python?**

Sí. Aspose.Slides los trata como parte de la presentación y puede leer/modificar sus propiedades y marcos; no es necesario ejecutar los controles para conservarlos.

**¿En qué se diferencian los controles ActiveX de los objetos OLE en una presentación?**

Los controles ActiveX son controles interactivos gestionados (botones, cuadros de texto, reproductor multimedia), mientras que [OLE](/slides/es/python-java/manage-ole/) hace referencia a objetos de aplicación incrustados (por ejemplo, una hoja de cálculo de Excel). Se almacenan y manejan de forma diferente y tienen modelos de propiedades distintos.

**¿Los eventos ActiveX y las macros VBA funcionan si el archivo ha sido modificado por Aspose.Slides?**

Aspose.Slides conserva el marcado y los metadatos existentes; sin embargo, los eventos y macros solo se ejecutan dentro de PowerPoint en Windows cuando la seguridad lo permite. La biblioteca no ejecuta VBA.