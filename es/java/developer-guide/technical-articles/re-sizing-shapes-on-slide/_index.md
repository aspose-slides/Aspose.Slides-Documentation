---
title: Redimensionar formas en diapositivas de presentación
type: docs
weight: 110
url: /es/java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Redimensione fácilmente formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para Java—automatice los ajustes de diseño de diapositivas y mejore la productividad."
---

## **Visión general**

Una de las preguntas más frecuentes de los clientes de Aspose.Slides para Java es cómo redimensionar formas de modo que, cuando cambia el tamaño de la diapositiva, los datos no se recorten. Este breve artículo técnico muestra cómo hacerlo.

## **Redimensionar formas**

Para evitar que las formas se desalineen cuando cambia el tamaño de la diapositiva, actualice la posición y dimensiones de cada forma para que se adapten al nuevo diseño de la diapositiva.
```java
// Cargar el archivo de presentación.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Obtener el tamaño original de la diapositiva.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Cambiar el tamaño de la diapositiva sin escalar las formas existentes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Obtener el nuevo tamaño de la diapositiva.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Redimensionar y reposicionar las formas en cada diapositiva.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
        // Escalar el tamaño de la forma.
        shape.setHeight(shape.getHeight() * heightRatio);
        shape.setWidth(shape.getWidth() * widthRatio);

        // Escalar la posición de la forma.
        shape.setY(shape.getY() * heightRatio);
        shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}} 

Si una diapositiva contiene una tabla, el código anterior no funcionará correctamente. En ese caso, cada celda de la tabla debe redimensionarse.

{{% /alert %}} 

Utilice el siguiente código para redimensionar diapositivas que contienen tablas. Para las tablas, establecer el ancho o la altura es un caso especial: debe ajustar individualmente las alturas de las filas y los anchos de las columnas para cambiar el tamaño general de la tabla.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Obtener el tamaño original de la diapositiva.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Cambiar el tamaño de la diapositiva sin escalar las formas existentes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Obtener el nuevo tamaño de la diapositiva.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Escalar el tamaño de la forma.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Escalar la posición de la forma.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Escalar el tamaño de la forma.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Escalar la posición de la forma.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Escalar el tamaño de la forma.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Escalar la posición de la forma.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


## **Preguntas frecuentes**

**¿Por qué las formas se distorsionan o se recortan después de redimensionar una diapositiva?**

Al redimensionar una diapositiva, las formas conservan su posición y tamaño originales a menos que la escala se cambie explícitamente. Esto puede generar que el contenido se recorte o que las formas se desalineen.

**¿El código proporcionado funciona para todos los tipos de forma?**

El ejemplo básico funciona para la mayoría de los tipos de forma (cuadros de texto, imágenes, gráficos, etc.). Sin embargo, para las tablas, es necesario manejar filas y columnas por separado, ya que la altura y el ancho de una tabla se determinan por las dimensiones de sus celdas individuales.

**¿Cómo redimensiono tablas al redimensionar una diapositiva?**

Debe iterar sobre todas las filas y columnas de la tabla y redimensionar sus alturas y anchos de forma proporcional, como se muestra en el segundo ejemplo de código.

**¿Este redimensionado funciona para diapositivas maestras y de diseño?**

Sí, pero también debe iterar sobre [Maestros](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) y [Diapositivas de diseño](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) y aplicar la misma lógica de escala a sus formas para garantizar la coherencia en toda la presentación.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Puede usar [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/#setOrientation-int-) para cambiar la orientación. Asegúrese de ajustar la lógica de escala en consecuencia para preservar el diseño.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Aspose.Slides admite tamaños personalizados, pero los tamaños muy grandes pueden afectar el rendimiento o la compatibilidad con algunas versiones de PowerPoint.

**¿Cómo evitar que las formas con proporción fija se distorsionen?**

Puede consultar el método `getAspectRatioLocked` de la forma antes de escalarla. Si está bloqueado, ajuste el ancho o la altura de forma proporcional en lugar de escalarlos individualmente.