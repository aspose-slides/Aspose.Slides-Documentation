---
title: Redimensionar formas en diapositivas de presentación en Java
type: docs
weight: 130
url: /es/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /es/java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Redimensiona fácilmente las formas en diapositivas PowerPoint y OpenDocument con Aspose.Slides para Java: automatiza los ajustes de diseño de diapositivas y aumenta la productividad."
---
## **Visión general**

Cuando cambias el tamaño de la diapositiva de una presentación, también puede ser necesario redimensionar y reposicionar sus formas para que se ajusten a las nuevas dimensiones. Este artículo muestra cómo escalar las formas manualmente y cómo manejar tablas en diapositivas, maestros y diseños.

## **Redimensionar formas**

Para preservar la posición y el tamaño relativos de cada forma, multiplica sus coordenadas horizontales y su ancho por la razón del ancho nuevo de la diapositiva respecto al ancho original. Aplica la razón de altura correspondiente a sus coordenadas verticales y su altura.

El primer ejemplo carga una presentación cuyas diapositivas no contienen tablas, cambia el tamaño de la diapositiva a A4 y guarda el resultado. Utiliza [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) con [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) para que el bucle posterior controle el escalado. Las razones son adimensionales; las posiciones y dimensiones de las formas se miden en puntos. Diferentes razones de ancho y altura pueden distorsionar las formas, y cambiar las dimensiones de una forma no escala el tamaño de sus fuentes.

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
Las tablas requieren un manejo separado: escalar sus anchos de columna y alturas de fila en lugar de asignar el ancho y la altura generales de la tabla. Las alturas de fila pueden permanecer más grandes de lo solicitado si el contenido de la celda necesita más espacio.
{{% /alert %}}

El segundo ejemplo admite tablas y procesa las formas en maestros y diseños, así como en diapositivas individuales, antes de guardar la presentación redimensionada. Su ayudante gestiona cada [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) escalando los anchos de columna con [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) y las alturas mínimas de fila con [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). Luego escala la posición de la tabla sin escalar por separado sus dimensiones generales.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Las dimensiones de la tabla se controlan mediante los anchos de columna y las alturas de fila.
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

    // Redimensionar formas definidas en maestros y diseños, así como en diapositivas individuales.
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

**¿Por qué las formas se distorsionan o se recortan después de cambiar el tamaño de una diapositiva?**

Si cambias el tamaño de la diapositiva sin escalar las formas, estas conservan sus posiciones y dimensiones originales y pueden sobresalir de la diapositiva. Escalar el ancho y la altura con diferentes razones también puede distorsionar las formas.

**¿El código proporcionado funciona para todos los tipos de forma?**

El primer ejemplo cambia los límites de la forma directamente y está destinado a diapositivas sin tablas. El segundo ejemplo maneja las tablas por separado. Verifica el diseño resultante, particularmente el texto y las tablas, ya que estos ejemplos no escalan los tamaños de fuente y el contenido de la tabla puede limitar la altura de las filas.

**¿Cómo redimensiono las tablas al redimensionar una diapositiva?**

Escala los anchos de columna con la razón de ancho y las alturas mínimas de fila con la razón de altura, luego escala la posición de la tabla, como se muestra en el segundo ejemplo.

**¿Funcionará este redimensionado para diapositivas maestras y diapositivas de diseño?**

Sí. El segundo ejemplo recorre [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) y, para cada maestro, sus [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--), y aplica la misma lógica de redimensionado a sus formas.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Llama a [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) después de cambiar el tamaño de la diapositiva y antes de leer las dimensiones objetivo, de modo que los factores de escala reflejen la orientación final.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Puedes especificar dimensiones personalizadas de la diapositiva con [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). Las dimensiones admitidas también dependen del formato de la presentación y de la aplicación utilizada para abrir el archivo.

**¿Cómo puedo evitar que las formas con una relación de aspecto fija se distorsionen?**

Utiliza el mismo factor de escala para el ancho y la altura. Para que el diseño original se ajuste a las nuevas dimensiones de la diapositiva, usa la menor de las razones de ancho y altura tanto para las dimensiones como para las posiciones. Esto conserva las proporciones pero puede dejar espacio sin usar a lo largo de un borde.