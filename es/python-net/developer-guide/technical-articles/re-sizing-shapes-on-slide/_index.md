---
title: Redimensionar formas en presentaciones con Python
linktitle: Redimensionar formas
type: docs
weight: 130
url: /es/python-net/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Redimensione fácilmente formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET—automatice los ajustes de diseño de diapositivas y aumente la productividad."
---

## **Descripción general**

Una de las preguntas más comunes de los clientes de Aspose.Slides para Python es cómo redimensionar las formas para que, cuando cambie el tamaño de la diapositiva, los datos no se corten. Este breve artículo técnico muestra cómo hacerlo.

## **Redimensionar formas**

Para evitar que las formas se desalineen cuando cambia el tamaño de la diapositiva, actualice la posición y las dimensiones de cada forma para que se ajusten al nuevo diseño de la diapositiva.
```py
import aspose.slides as slides

# Cargar el archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:
    # Obtener el tamaño original de la diapositiva.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Cambiar el tamaño de la diapositiva sin escalar las formas existentes.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Obtener el nuevo tamaño de la diapositiva.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Redimensionar y reposicionar las formas en cada diapositiva.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Escalar el tamaño de la forma.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Escalar la posición de la forma.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 
Si una diapositiva contiene una tabla, el código anterior no funcionará correctamente. En ese caso, cada celda de la tabla debe redimensionarse.
{{% /alert %}} 

Utilice el siguiente código para redimensionar diapositivas que contienen tablas. Para las tablas, establecer el ancho o la altura es un caso especial: debe ajustar las alturas de las filas individuales y los anchos de las columnas para cambiar el tamaño general de la tabla.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Obtener el tamaño original de la diapositiva.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Cambiar el tamaño de la diapositiva sin escalar las formas existentes.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Obtener el nuevo tamaño de la diapositiva.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Escalar el tamaño de la forma.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Escalar la posición de la forma.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Escalar el tamaño de la forma.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Escalar la posición de la forma.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Escalar el tamaño de la forma.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Escalar la posición de la forma.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Por qué las formas se distorsionan o se recortan después de redimensionar una diapositiva?**

Al redimensionar una diapositiva, las formas conservan su posición y tamaño originales a menos que la escala se cambie explícitamente. Esto puede provocar que el contenido se recorte o que las formas se desalineen.

**¿El código proporcionado funciona para todos los tipos de forma?**

El ejemplo básico funciona para la mayoría de los tipos de forma (cuadros de texto, imágenes, gráficos, etc.). Sin embargo, para las tablas, es necesario manejar filas y columnas por separado, ya que la altura y el ancho de una tabla se determinan por las dimensiones de sus celdas individuales.

**¿Cómo redimensiono tablas al redimensionar una diapositiva?**

Debe recorrer todas las filas y columnas de la tabla y redimensionar su altura y ancho proporcionalmente, como se muestra en el segundo ejemplo de código.

**¿Este redimensionamiento funciona para diapositivas maestras y de diseño?**

Sí, pero también debería recorrer [Masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) y [Layout slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) y aplicar la misma lógica de escalado a sus formas para garantizar la consistencia en toda la presentación.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionamiento?**

Sí. Puede usar [presentation.slide_size.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/islidesize/orientation/) para cambiar la orientación. Asegúrese de establecer la lógica de escalado en consecuencia para preservar el diseño.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Aspose.Slides admite tamaños personalizados, pero los tamaños muy grandes pueden afectar el rendimiento o la compatibilidad con algunas versiones de PowerPoint.

**¿Cómo evito que las formas con proporción fija se distorsionen?**

Puede comprobar la propiedad `aspect_ratio_locked` de la forma antes de escalar. Si está bloqueada, ajuste el ancho o la altura proporcionalmente en lugar de escalarlos individualmente.