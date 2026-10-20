---
title: Redimensionar formas en diapositivas de presentación en Android
type: docs
weight: 130
url: /es/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/redimensionar-formas-en-diapositiva/
  - /es/androidjava/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- Android
- Aspose.Slides
description: "Redimensione fácilmente formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para Android mediante Java: automatice ajustes de diseño de diapositivas y aumente la productividad."
---
## **Visión general**

Cuando cambias el tamaño de la diapositiva de una presentación, es posible que también necesites redimensionar y reposicionar sus formas para que se ajusten a las nuevas dimensiones. Este artículo muestra cómo escalar formas manualmente y cómo manejar tablas en diapositivas, patrones y diseños.

## **Redimensionar formas**

Para conservar la posición y el tamaño relativos de cada forma, multiplica sus coordenadas horizontales y su anchura por la proporción entre el nuevo ancho de la diapositiva y el ancho original. Aplica la proporción de altura correspondiente a sus coordenadas verticales y a su altura.

El primer ejemplo carga una presentación cuyas diapositivas no contienen tablas, cambia el tamaño de la diapositiva a A4 y guarda el resultado. Utiliza [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) con [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) para que el bucle posterior controle el escalado. Las proporciones no tienen unidades; las posiciones y dimensiones de las formas se miden en puntos. Diferentes proporciones de anchura y altura pueden distorsionar las formas, y cambiar las dimensiones de una forma no escala los tamaños de fuente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calcular factores de escala horizontales y verticales independientes.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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

Las tablas requieren un manejo separado: escalar el ancho de sus columnas y la altura de sus filas en lugar de asignar el ancho y la altura globales de la tabla. Las alturas de fila pueden permanecer mayores que lo solicitado si el contenido de la celda necesita más espacio.

{{% /alert %}}

El segundo ejemplo admite tablas y procesa las formas en patrones y diseños, así como en diapositivas individuales, antes de guardar la presentación redimensionada. Su asistente maneja cada [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) escalando los anchos de columna con [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) y las alturas mínimas de fila con [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Luego escala la posición de la tabla sin escalar por separado sus dimensiones globales.

```java
import com.aspose.slides.*;

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
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Redimensionar formas definidas en patrones y diseños, así como en diapositivas individuales.
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

Si cambias el tamaño de la diapositiva sin escalar las formas, estas mantienen sus posiciones y dimensiones originales y pueden exceder el borde de la diapositiva. Escalar la anchura y la altura con diferentes proporciones también puede distorsionar las formas.

**¿Funciona el código proporcionado con todos los tipos de forma?**

El primer ejemplo cambia los límites de la forma directamente y está pensado para diapositivas sin tablas. El segundo ejemplo maneja las tablas por separado. Revisa el diseño resultante, especialmente el texto y las tablas, porque estos ejemplos no escalan los tamaños de fuente y el contenido de la tabla puede limitar la altura de las filas.

**¿Cómo redimensiono las tablas al redimensionar una diapositiva?**

Escala los anchos de columna con la proporción de anchura y las alturas mínimas de fila con la proporción de altura, luego escala la posición de la tabla, como se muestra en el segundo ejemplo.

**¿Funcionará este redimensionado en diapositivas patrón y en diapositivas de diseño?**

Sí. El segundo ejemplo recorre [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) y los [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) de cada patrón y aplica la misma lógica de redimensionado a sus formas.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Llama a [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) después de cambiar el tamaño de la diapositiva y antes de leer las dimensiones objetivo, de modo que los factores de escala reflejen la orientación final.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Puedes especificar dimensiones personalizadas de la diapositiva con [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). Las dimensiones compatibles también dependen del formato de la presentación y de la aplicación utilizada para abrir el archivo.

**¿Cómo puedo evitar que las formas con una relación de aspecto fija se distorsionen?**

Utiliza el mismo factor de escala para la anchura y la altura. Para adaptar el diseño original a las nuevas dimensiones de la diapositiva, usa la menor de las proporciones de anchura y altura tanto para las dimensiones como para las posiciones. Esto conserva las proporciones pero puede dejar espacio sin usar en uno de los bordes.