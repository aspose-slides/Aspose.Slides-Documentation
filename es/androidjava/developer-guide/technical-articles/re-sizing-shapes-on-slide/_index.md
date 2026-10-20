---
title: Redimensionar formas en diapositivas de presentación en Android
type: docs
weight: 130
url: /es/androidjava/resizing-shapes-on-slide/
aliases:
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
## **Descripción general**

Al cambiar el tamaño de la diapositiva de una presentación, puede que también necesite redimensionar y reposicionar sus formas para que encajen en las nuevas dimensiones. Este artículo muestra cómo escalar formas manualmente y cómo manejar tablas en diapositivas, patrones y diseños.

## **Redimensionar formas**

Para conservar la posición y el tamaño relativos de cada forma, multiplique sus coordenadas horizontales y su ancho por la proporción entre el nuevo ancho de la diapositiva y el ancho original. Aplique la proporción correspondiente de altura a sus coordenadas verticales y su altura.

El primer ejemplo carga una presentación cuyas diapositivas no contienen tablas, cambia el tamaño de la diapositiva a A4 y guarda el resultado. Utiliza [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) con [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) de modo que el bucle posterior controle el escalado. Las proporciones no tienen unidades; las posiciones y dimensiones de las formas se miden en puntos. Proporciones distintas de ancho y altura pueden deformar las formas, y cambiar las dimensiones de una forma no escala sus tamaños de fuente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calcular factores de escala independientes horizontales y verticales.
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
Las tablas requieren un manejo separado: escale sus anchos de columna y alturas de fila en lugar de asignar el ancho y la altura globales de la tabla. Las alturas de fila pueden permanecer mayores que lo solicitado si el contenido de la celda necesita más espacio.
{{% /alert %}}

El segundo ejemplo admite tablas y procesa formas en patrones y diseños, así como en diapositivas individuales, antes de guardar la presentación redimensionada. Su asistente gestiona cada [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) escalando los anchos de columna con [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) y las alturas mínimas de fila con [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Después escala la posición de la tabla sin escalar por separado sus dimensiones globales.

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
    // Calcular factores de escala independientes horizontales y verticales.
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

**¿Por qué las formas se deforman o se recortan después de redimensionar una diapositiva?**

Si cambia el tamaño de la diapositiva sin escalar las formas, estas conservan sus posiciones y dimensiones originales y pueden sobresalir de la diapositiva. Escalar el ancho y la altura con proporciones diferentes también puede deformar las formas.

**¿El código proporcionado funciona para todo tipo de formas?**

El primer ejemplo cambia los límites de la forma directamente y está pensado para diapositivas sin tablas. El segundo ejemplo maneja las tablas por separado. Revise el diseño resultante, particularmente texto y tablas, porque estos ejemplos no escalan los tamaños de fuente y el contenido de la tabla puede limitar la altura de las filas.

**¿Cómo redimensionar tablas al redimensionar una diapositiva?**

Escale los anchos de columna según la proporción de ancho y las alturas mínimas de fila según la proporción de altura, luego escale la posición de la tabla, como se muestra en el segundo ejemplo.

**¿Este redimensionamiento funciona para diapositivas patrón y diapositivas de diseño?**

Sí. El segundo ejemplo recorre [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) y cada patrón mediante [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) y aplica la misma lógica de redimensionado a sus formas.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Llame a [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) después de cambiar el tamaño de la diapositiva y antes de leer las dimensiones objetivo, de modo que los factores de escala reflejen la orientación final.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Puede especificar dimensiones personalizadas de diapositiva con [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). Las dimensiones admitidas también dependen del formato de la presentación y de la aplicación utilizada para abrir el archivo.

**¿Cómo evitar que las formas con una relación de aspecto fija se deformen?**

Utilice el mismo factor de escala para ancho y altura. Para adaptar el diseño original a las nuevas dimensiones de la diapositiva, use la menor de las dos proporciones (ancho o altura) tanto para dimensiones como para posiciones. Esto conserva las proporciones pero puede dejar espacio sin usar a lo largo de un borde.