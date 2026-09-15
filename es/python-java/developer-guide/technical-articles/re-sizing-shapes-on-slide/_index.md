---
title: Redimensionar formas en diapositivas de presentación en Python vía Java
type: docs
weight: 110
url: /es/python-java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Redimensiona fácilmente las formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para Python vía Java—automatiza los ajustes del diseño de diapositivas y aumenta la productividad."
---
## **Resumen**

Una de las preguntas más frecuentes de los clientes de Aspose.Slides for Python via Java es cómo redimensionar las formas de modo que, al cambiar el tamaño de la diapositiva, los datos no se recorten. Este breve artículo técnico muestra cómo hacerlo.

## **Redimensionar formas**

Para evitar que las formas se desalineen cuando cambia el tamaño de la diapositiva, actualice la posición y las dimensiones de cada forma para que se ajusten al nuevo diseño de la diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Cargar el archivo de presentación.
presentation = Presentation("sample.ppt")
try:
    # Obtener el tamaño original de la diapositiva.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Cambiar el tamaño de la diapositiva sin escalar las formas existentes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Obtener el nuevo tamaño de la diapositiva.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Redimensionar y reposicionar las formas en cada diapositiva.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Escalar el tamaño de la forma.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Escalar la posición de la forma.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}} 

Las tablas no requieren un tratamiento especial: establecer el ancho y la altura de una tabla reescala sus columnas y filas proporcionalmente, por lo que volver a escalar la altura de las filas y el ancho de las columnas aplicaría la proporción dos veces.

{{% /alert %}} 

El código anterior solo modifica las formas en las diapositivas. Las diapositivas maestras y las diapositivas de diseño conservan sus propias formas, por lo que también hay que escalarlas cuando se quiere que toda la presentación siga el nuevo tamaño de diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Obtener el tamaño original de la diapositiva.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Cambiar el tamaño de la diapositiva sin escalar las formas existentes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Obtener el nuevo tamaño de la diapositiva.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Escalar el tamaño de la forma.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Escalar la posición de la forma.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Escalar el tamaño de la forma.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Escalar la posición de la forma.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Escalar el tamaño de la forma.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Escalar la posición de la forma.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Por qué las formas se distorsionan o recortan después de redimensionar una diapositiva?**

Al redimensionar una diapositiva, las formas conservan su posición y tamaño originales a menos que se cambie explícitamente la escala. Esto puede provocar que el contenido se recorte o que las formas se desalineen.

**¿El código proporcionado funciona para todos los tipos de forma?**

Sí. Establecer la altura y el ancho funciona tanto para cuadros de texto, imágenes, gráficos y tablas.

**¿Cómo redimensiono las tablas al redimensionar una diapositiva?**

Escala la propia forma de tabla, exactamente como cualquier otra forma. Sus filas y columnas se ajustan proporcionalmente, por lo que no debes volver a escalarlas después.

**¿Funcionará este redimensionado para diapositivas maestras y diapositivas de diseño?**

Sí, pero también deberías iterar a través de [Presentation.getMasters](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getMasters) y [Presentation.getLayoutSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getLayoutSlides) y aplicar la misma lógica de escalado a sus formas para garantizar la consistencia en toda la presentación.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Puedes usar [SlideSize.setOrientation](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesize/#setOrientation) para cambiar la orientación. Asegúrate de ajustar la lógica de escalado en consecuencia para conservar el diseño.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Aspose.Slides admite tamaños personalizados, pero los tamaños muy grandes pueden afectar el rendimiento o la compatibilidad con algunas versiones de PowerPoint.

**¿Cómo puedo evitar que las formas con proporción fija se distorsionen?**

Puedes comprobar el método [getAspectRatioLocked](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) del bloqueo de la forma antes de escalar. Si está bloqueado, ajusta el ancho o la altura proporcionalmente en lugar de escalarlos individualmente.