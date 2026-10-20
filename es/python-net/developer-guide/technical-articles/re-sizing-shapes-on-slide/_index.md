---
title: Redimensionar formas en diapositivas de presentación en Python
type: docs
weight: 130
url: /es/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /es/python-net/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Redimensione fácilmente formas en diapositivas PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET—automatice los ajustes de diseño de diapositivas y aumente la productividad."
---
## **Resumen**

Cuando cambia el tamaño de la diapositiva de una presentación, también puede necesitar redimensionar y reposicionar sus formas para que se ajusten a las nuevas dimensiones. Este artículo muestra cómo escalar manualmente las formas y cómo manejar las tablas en diapositivas, maestros y diseños.

## **Redimensionar formas**

Para conservar la posición y tamaño relativos de cada forma, multiplique sus coordenadas horizontales y el ancho por la proporción entre el nuevo ancho de la diapositiva y el ancho original. Aplique la proporción de altura correspondiente a sus coordenadas verticales y altura.

El primer ejemplo carga una presentación cuyas diapositivas no contienen tablas, cambia el tamaño de la diapositiva a A4 y guarda el resultado. Utiliza [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) con [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) para que el bucle posterior controle el escalado. Las proporciones no tienen unidades; las posiciones y dimensiones de las formas se miden en puntos. Diferentes proporciones de ancho y alto pueden distorsionar las formas, y cambiar las dimensiones de una forma no escala sus tamaños de fuente.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Calcular factores de escala horizontal y vertical independientes.
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
Las tablas requieren un manejo separado: escale el ancho de sus columnas y la altura de sus filas en lugar de asignar el ancho y la altura generales de la tabla. Las alturas de las filas pueden seguir siendo mayores que lo solicitado si el contenido de la celda necesita más espacio.
{{% /alert %}}

El segundo ejemplo admite tablas y procesa las formas en maestros y diseños, así como en diapositivas individuales, antes de guardar la presentación redimensionada. Su asistente maneja cada [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) escalando [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) y [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). Luego escala la posición de la tabla sin escalar por separado sus dimensiones generales.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Las dimensiones de la tabla se controlan mediante el ancho de las columnas y la altura de las filas.
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
    # Calcular factores de escala horizontal y vertical independientes.
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

**¿Por qué se distorsionan o recortan las formas después de redimensionar una diapositiva?**

Si cambia el tamaño de la diapositiva sin escalar las formas, estas mantienen sus posiciones y dimensiones originales y pueden sobresalir de la diapositiva. Escalar el ancho y el alto con distintas proporciones también puede distorsionar las formas.

**¿El código proporcionado funciona para todos los tipos de forma?**

El primer ejemplo modifica los límites de la forma directamente y está pensado para diapositivas sin tablas. El segundo ejemplo trata las tablas por separado. Revise el diseño resultante, especialmente el texto y las tablas, ya que estos ejemplos no escalan los tamaños de fuente y el contenido de la tabla puede limitar la altura de las filas.

**¿Cómo redimensiono las tablas al redimensionar una diapositiva?**

Escale el ancho de las columnas según la proporción de ancho y la altura mínima de las filas según la proporción de alto, luego escale la posición de la tabla, como se muestra en el segundo ejemplo.

**¿Este redimensionamiento funciona para diapositivas maestras y de diseño?**

Sí. El segundo ejemplo recorre [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) y las [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) de cada maestra y aplica la misma lógica de redimensionamiento a sus formas.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionamiento?**

Sí. Establezca [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) después de cambiar el tamaño de la diapositiva y antes de leer las dimensiones objetivo, de modo que los factores de escala reflejen la orientación final.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Puede especificar dimensiones personalizadas de la diapositiva con [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). Las dimensiones compatibles también dependen del formato de la presentación y de la aplicación utilizada para abrir el archivo.

**¿Cómo puedo evitar que las formas con una relación de aspecto fija se distorsionen?**

Utilice el mismo factor de escala para el ancho y el alto. Para ajustar el diseño original dentro de las nuevas dimensiones de la diapositiva, use el menor de los ratios de ancho y alto para ambas dimensiones y posiciones. Esto conserva las proporciones pero puede dejar espacio sin usar a lo largo de un borde.