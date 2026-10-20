---
title: Redimensionar formas en diapositivas de presentación en Java
type: docs
weight: 130
url: /es/java/resizing-shapes-on-slide/
aliases:
  - /es/java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Redimensiona fácilmente formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para Java: automatiza ajustes del diseño de diapositivas y aumenta la productividad."
---
## **Descripción general**

Cuando cambias el tamaño de la diapositiva de una presentación, también puede ser necesario redimensionar y reposicionar sus formas para que se ajusten a las nuevas dimensiones. Este artículo muestra cómo escalar formas manualmente y cómo manejar tablas en diapositivas, patrones maestros y diseños.

## **Redimensionar formas**

Para preservar la posición y el tamaño relativos de cada forma, multiplica sus coordenadas horizontales y su anchura por la razón entre la anchura de la nueva diapositiva y la anchura original. Aplica la razón de altura correspondiente a sus coordenadas verticales y a su altura.

El primer ejemplo carga una presentación cuyas diapositivas no contienen tablas, cambia el tamaño de la diapositiva a A4 y guarda el resultado. Utiliza [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) con [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) para que el bucle posterior controle el escalado. Las razones son adimensionales; las posiciones y dimensiones de las formas se miden en puntos. Diferentes razones de anchura y altura pueden distorsionar las formas, y cambiar las dimensiones de una forma no escalará los tamaños de fuente.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calcular factores de escala horizontales y verticales independientes.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Las tablas requieren un manejo separado: escalar sus anchuras de columna y alturas de fila en lugar de asignar la anchura y altura globales de la tabla. Las alturas de fila pueden permanecer mayores que lo solicitado si el contenido de la celda necesita más espacio.
{{% /alert %}}

El segundo ejemplo admite tablas y procesa formas en patrones maestros y diseños, así como en diapositivas individuales, antes de guardar la presentación redimensionada. Su asistente gestiona cada [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) escalando las anchuras de columna con [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) y las alturas mínimas de fila con [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). Luego escala la posición de la tabla sin escalar por separado sus dimensiones globales.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Las dimensiones de la tabla se controlan mediante el ancho de las columnas y la altura de las filas.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calcular factores de escala horizontales y verticales independientes.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Redimensionar formas definidas en patrones maestros y diseños, así como en diapositivas individuales.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Por qué las formas se distorsionan o se recortan después de redimensionar una diapositiva?**

Si cambias el tamaño de la diapositiva sin escalar las formas, estas conservan sus posiciones y dimensiones originales y pueden sobresalir de la diapositiva. Escalar la anchura y la altura con diferentes razones también puede distorsionar las formas.

**¿El código proporcionado funciona para todos los tipos de forma?**

El primer ejemplo modifica los límites de la forma directamente y está pensado para diapositivas sin tablas. El segundo ejemplo maneja las tablas por separado. Verifica el diseño resultante, particularmente el texto y las tablas, ya que estos ejemplos no escalan los tamaños de fuente y el contenido de la tabla puede restringir la altura de las filas.

**¿Cómo redimensiono las tablas al redimensionar una diapositiva?**

Escala las anchuras de columna por la razón de anchura y las alturas mínimas de fila por la razón de altura, luego escala la posición de la tabla, como se muestra en el segundo ejemplo.

**¿Este redimensionado funciona para diapositivas maestras y diapositivas de diseño?**

Sí. El segundo ejemplo recorre [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) y las [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) de cada maestro y aplica la misma lógica de redimensionado a sus formas.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Llama a [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) después de cambiar el tamaño de la diapositiva y antes de leer las dimensiones objetivo, de modo que los factores de escala reflejen la orientación final.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Puedes especificar dimensiones de diapositiva personalizadas con [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). Las dimensiones compatibles también dependen del formato de la presentación y de la aplicación utilizada para abrir el archivo.

**¿Cómo puedo evitar que las formas con una relación de aspecto fija se distorsionen?**

Utiliza el mismo factor de escala para la anchura y la altura. Para adaptar el diseño original dentro de las nuevas dimensiones de la diapositiva, usa la menor de las razones de anchura y altura para ambas dimensiones y posiciones. Esto preserva las proporciones pero puede dejar espacio sin usar a lo largo de un borde.