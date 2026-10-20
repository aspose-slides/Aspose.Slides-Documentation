---
title: Redimensionar formas en diapositivas de presentación en Python mediante Java
type: docs
weight: 110
url: /es/python-java/resizing-shapes-on-slide/
aliases:
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
description: "Redimensiona fácilmente formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para Python mediante Java—automatiza los ajustes de diseño de diapositivas y aumenta la productividad."
---
## **Visión general**

Al cambiar el tamaño de la diapositiva de una presentación, también puede ser necesario redimensionar y reposicionar sus formas para que se ajusten a las nuevas dimensiones. Este artículo muestra cómo escalar formas manualmente y cómo manejar tablas en diapositivas, patrones y diseños.

## **Redimensionar formas**

Para preservar la posición y el tamaño relativos de cada forma, multiplique sus coordenadas horizontales y su ancho por la razón entre el nuevo ancho de la diapositiva y el ancho original. Aplique la razón correspondiente de altura a sus coordenadas verticales y su altura.

El primer ejemplo carga una presentación cuyas diapositivas no contienen tablas, cambia el tamaño de la diapositiva a A4 y guarda el resultado. Utiliza [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) con [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) de modo que el bucle posterior controle el escalado. Las razones son adimensionales; las posiciones y dimensiones de las formas se miden en puntos. Diferentes razones de ancho y alto pueden distorsionar las formas, y cambiar las dimensiones de una forma no escala sus tamaños de fuente.

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
Las tablas requieren un manejo independiente: escale sus anchuras de columna y alturas de fila en lugar de asignar el ancho y la altura totales de la tabla. Las alturas de fila pueden permanecer mayores que lo solicitado si el contenido de la celda necesita más espacio.
{{% /alert %}}

El segundo ejemplo admite tablas y procesa formas en patrones y diseños, así como en diapositivas individuales, antes de guardar la presentación redimensionada. Su asistente maneja cada [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) escalando las anchuras de columna con [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) y las alturas mínimas de fila con [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Luego escala la posición de la tabla sin escalar por separado sus dimensiones totales.

```python
import jpage
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

**¿Por qué las formas se distorsionan o se recortan después de redimensionar una diapositiva?**

Si cambia el tamaño de la diapositiva sin escalar las formas, estas conservan sus posiciones y dimensiones originales y pueden sobresalir de la diapositiva. Escalar el ancho y la altura con razones diferentes también puede distorsionar las formas.

**¿El código proporcionado funciona para todos los tipos de forma?**

El primer ejemplo modifica directamente los límites de la forma y está pensado para diapositivas sin tablas. El segundo ejemplo trata las tablas por separado. Revise el diseño resultante, especialmente el texto y las tablas, porque estos ejemplos no escalan los tamaños de fuente y el contenido de la tabla puede limitar las alturas de fila.

**¿Cómo redimensionar tablas al redimensionar una diapositiva?**

Escale las anchuras de columna con la razón de ancho y las alturas mínimas de fila con la razón de alto, y luego escale la posición de la tabla, como se muestra en el segundo ejemplo.

**¿Este redimensionamiento funciona para diapositivas maestras y diapositivas de diseño?**

Sí. El segundo ejemplo recorre [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) y cada [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) del maestro, aplicando la misma lógica de redimensionado a sus formas.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Llame a [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) después de cambiar el tamaño de la diapositiva y antes de leer las dimensiones objetivo, de modo que los factores de escala reflejen la orientación final.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Puede especificar dimensiones de diapositiva personalizadas con [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). Las dimensiones admitidas también dependen del formato de la presentación y de la aplicación utilizada para abrir el archivo.

**¿Cómo evitar que las formas con una relación de aspecto fija se distorsionen?**

Utilice el mismo factor de escala para el ancho y la altura. Para adaptar el diseño original a las nuevas dimensiones de la diapositiva, use la menor de las razones de ancho y altura tanto para las dimensiones como para las posiciones. Esto conserva las proporciones, aunque puede dejar espacio sin usar en uno de los bordes.