---
title: Redimensionar formas en diapositivas de presentación en Python
type: docs
weight: 130
url: /es/python-net/resizing-shapes-on-slide/
aliases:
  - /es/python-net/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Redimensiona fácilmente formas en diapositivas PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET: automatiza ajustes de diseño de diapositivas y aumenta la productividad."
---
## **Visión general**

Cuando cambias el tamaño de la diapositiva de una presentación, también puede ser necesario redimensionar y recolocar sus formas para que se ajusten a las nuevas dimensiones. Este artículo muestra cómo escalar formas manualmente y cómo manejar tablas en diapositivas, diapositivas maestras y diseños.

## **Redimensionar formas**

Para conservar la posición y el tamaño relativos de cada forma, multiplica sus coordenadas horizontales y su ancho por la proporción entre el ancho de la nueva diapositiva y el ancho original. Aplica la proporción de altura correspondiente a sus coordenadas verticales y su altura.

El primer ejemplo carga una presentación cuyas diapositivas no contienen tablas, cambia el tamaño de la diapositiva a A4 y guarda el resultado. Utiliza [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) con [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) para que el bucle posterior controle el escalado. Las proporciones son adimensionales; las posiciones y dimensiones de las formas se miden en puntos. Diferentes proporciones de ancho y altura pueden deformar las formas, y cambiar las dimensiones de una forma no escala sus tamaños de fuente.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Calcular factores de escala horizontales y verticales independientes.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}

Las tablas requieren un manejo separado: escalar sus anchos de columna y alturas de fila en lugar de asignar el ancho y la altura globales de la tabla. Las alturas de fila pueden permanecer mayores de lo solicitado si el contenido de la celda requiere más espacio.

{{% /alert %}}

El segundo ejemplo admite tablas y procesa las formas en diapositivas maestras y diseños, así como en diapositivas individuales, antes de guardar la presentación redimensionada. Su ayuda gestiona cada [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) escalando [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) y [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). Luego escala la posición de la tabla sin escalar por separado sus dimensiones globales.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Las dimensiones de la tabla se controlan mediante los anchos de columna y las alturas de fila.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Calcular factores de escala horizontales y verticales independientes.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Redimensionar formas definidas en maestros y diseños, así como en diapositivas individuales.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Por qué las formas se deforman o se recortan después de redimensionar una diapositiva?**

Si cambias el tamaño de la diapositiva sin escalar las formas, estas conservan sus posiciones y dimensiones originales y pueden sobresalir de la diapositiva. Escalar el ancho y la altura con diferentes proporciones también puede deformar las formas.

**¿El código proporcionado funciona para todos los tipos de forma?**

El primer ejemplo cambia los límites de la forma directamente y está pensado para diapositivas sin tablas. El segundo ejemplo gestiona las tablas por separado. Verifica el diseño resultante, particularmente el texto y las tablas, ya que estos ejemplos no escalan los tamaños de fuente y el contenido de la tabla puede limitar la altura de las filas.

**¿Cómo redimensiono las tablas al redimensionar una diapositiva?**

Escala los anchos de columna según la proporción de ancho y las alturas mínimas de fila según la proporción de altura, luego escala la posición de la tabla, como se muestra en el segundo ejemplo.

**¿Este redimensionado funciona para diapositivas maestras y diapositivas de diseño?**

Sí. El segundo ejemplo recorre [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) y los [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) de cada maestro, y aplica la misma lógica de redimensionado a sus formas.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Establece [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) después de cambiar el tamaño de la diapositiva y antes de leer las dimensiones objetivo, de modo que los factores de escala reflejen la orientación final.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Puedes especificar dimensiones de diapositiva personalizadas con [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). Las dimensiones admitidas también dependen del formato de la presentación y de la aplicación utilizada para abrir el archivo.

**¿Cómo puedo evitar que las formas con una relación de aspecto fija se deformen?**

Utiliza el mismo factor de escala para el ancho y la altura. Para que el diseño original se ajuste a las nuevas dimensiones de la diapositiva, usa la menor de las proporciones de ancho y altura tanto para las dimensiones como para las posiciones. Esto conserva las proporciones pero puede dejar espacio sin usar a lo largo de un borde.