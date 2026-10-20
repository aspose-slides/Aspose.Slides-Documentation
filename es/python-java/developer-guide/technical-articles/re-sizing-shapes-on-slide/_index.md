---
title: Redimensionar formas en diapositivas de presentación en Python mediante Java
type: docs
weight: 110
url: /es/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /es/python-java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Redimensione fácilmente formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para Python mediante Java: automatice los ajustes del diseño de diapositivas y aumente la productividad."
---
## **Visión general**

Cuando cambias el tamaño de la diapositiva de una presentación, también puede ser necesario redimensionar y reposicionar sus formas para adaptarse a las nuevas dimensiones. Este artículo muestra cómo escalar manualmente las formas y cómo manejar las tablas en diapositivas, maestros y diseños.

## **Redimensionar formas**

Para conservar la posición y el tamaño relativo de cada forma, multiplica sus coordenadas horizontales y su ancho por la proporción entre el nuevo ancho de la diapositiva y el ancho original. Aplica la proporción de altura correspondiente a sus coordenadas verticales y su altura.

El primer ejemplo carga una presentación cuyas diapositivas no contienen tablas, cambia el tamaño de la diapositiva a A4 y guarda el resultado. Utiliza [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) con [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) para que el bucle posterior controle el escalado. Las proporciones son adimensionales; las posiciones y dimensiones de las formas se miden en puntos. Diferentes proporciones de ancho y altura pueden deformar las formas, y cambiar las dimensiones de una forma no escala sus tamaños de fuente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Calcular factores de escala horizontales y verticales independientes.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Las tablas requieren un manejo separado: escalar sus anchuras de columna y alturas de fila en lugar de asignar el ancho y alto globales de la tabla. Las alturas de fila pueden permanecer mayores que lo solicitado si el contenido de la celda requiere más espacio.
{{% /alert %}}

El segundo ejemplo admite tablas y procesa las formas en maestros y diseños, así como en diapositivas individuales, antes de guardar la presentación redimensionada. Su asistente maneja cada [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) escalando las anchuras de columna con [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) y las alturas mínimas de fila con [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Luego escala la posición de la tabla sin escalar por separado sus dimensiones globales.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Las dimensiones de la tabla se controlan mediante el ancho de las columnas y la altura de las filas.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Calcular factores de escala horizontales y verticales independientes.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Redimensionar formas definidas en maestros y diseños, así como en diapositivas individuales.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Por qué se deforman o recortan las formas después de redimensionar una diapositiva?**

Si cambias el tamaño de la diapositiva sin escalar las formas, estas mantienen sus posiciones y dimensiones originales y pueden sobresalir de la diapositiva. Escalar el ancho y la altura con distintas proporciones también puede deformar las formas.

**¿El código proporcionado funciona para todos los tipos de forma?**

El primer ejemplo cambia los límites de la forma directamente y está pensado para diapositivas sin tablas. El segundo ejemplo maneja las tablas por separado. Verifica el diseño resultante, especialmente el texto y las tablas, porque estos ejemplos no escalan los tamaños de fuente y el contenido de la tabla puede limitar las alturas de fila.

**¿Cómo redimensiono las tablas al redimensionar una diapositiva?**

Escala las anchuras de columna por la proporción de ancho y las alturas mínimas de fila por la proporción de altura, y luego escala la posición de la tabla, como se muestra en el segundo ejemplo.

**¿Este redimensionado funciona para diapositivas maestras y diapositivas de diseño?**

Sí. El segundo ejemplo recorre [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) y, para cada maestro, sus [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides), y aplica la misma lógica de redimensionado a sus formas.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Llama a [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) después de cambiar el tamaño de la diapositiva y antes de leer las dimensiones objetivo, de modo que los factores de escala reflejen la orientación final.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Puedes especificar dimensiones de diapositiva personalizadas con [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). Las dimensiones admitidas también dependen del formato de la presentación y de la aplicación utilizada para abrir el archivo.

**¿Cómo puedo evitar que las formas con una relación de aspecto fija se deformen?**

Utiliza el mismo factor de escala para el ancho y la altura. Para ajustar el diseño original dentro de las nuevas dimensiones de la diapositiva, emplea la menor de las proporciones de ancho y altura tanto para las dimensiones como para las posiciones. Esto conserva las proporciones pero puede dejar espacio sin usar a lo largo de un borde.