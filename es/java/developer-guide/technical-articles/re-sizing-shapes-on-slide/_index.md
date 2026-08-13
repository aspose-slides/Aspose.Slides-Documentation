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
description: "Redimensione fácilmente las formas en diapositivas PowerPoint y OpenDocument con Aspose.Slides para Java—automatice los ajustes del diseño de diapositivas y aumente la productividad."
---
## **Visión general**

Una de las preguntas más habituales de los clientes de Aspose.Slides para Java es cómo cambiar el tamaño de las formas para que, cuando cambia el tamaño de la diapositiva, los datos no se recorten. Este breve artículo técnico muestra cómo hacerlo.

## **Redimensionar formas**

Para evitar que las formas se desalineen cuando cambia el tamaño de la diapositiva, actualice la posición y las dimensiones de cada forma para que se ajusten al nuevo diseño de la diapositiva.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 
Las tablas no requieren un tratamiento especial: establecer el ancho y la altura de una tabla redimensiona sus columnas y filas proporcionalmente, por lo que volver a escalar las alturas de fila y los anchos de columna aplicaría la proporción dos veces.
{{% /alert %}} 

```java
import com.aspose.slides.*;

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
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

### ¿Por qué las formas se distorsionan o recortan después de redimensionar una diapositiva?

Al redimensionar una diapositiva, las formas conservan su posición y tamaño originales a menos que la escala se modifique explícitamente. Esto puede provocar que el contenido se recorte o que las formas se desalineen.

### ¿El código proporcionado funciona para todos los tipos de forma?

Sí. Establecer la altura y el ancho funciona tanto para cuadros de texto, imágenes, gráficos y tablas.

### ¿Cómo redimensiono las tablas al redimensionar una diapositiva?

Escale la propia forma de tabla, exactamente como cualquier otra forma. Sus filas y columnas se ajustan proporcionalmente, por lo que no debe volver a escalarlas después.

### ¿Este redimensionado funcionará para diapositivas maestras y diapositivas de diseño?

Sí, pero también debe iterar sobre los [Maestras](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getMasters--) y las [diapositivas de diseño](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getLayoutSlides--) y aplicar la misma lógica de escalado a sus formas para garantizar la coherencia en toda la presentación.

### ¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?

Sí. Puede usar [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/es/java/com.aspose.slides/islidesize/#setOrientation-int-) para cambiar la orientación. Asegúrese de establecer la lógica de escalado adecuadamente para preservar el diseño.

### ¿Existe un límite para el tamaño de diapositiva que puedo establecer?

Aspose.Slides admite tamaños personalizados, pero los tamaños muy grandes pueden afectar el rendimiento o la compatibilidad con algunas versiones de PowerPoint.

### ¿Cómo puedo evitar que las formas con relación de aspecto fija se distorsionen?

Puede comprobar el método `getAspectRatioLocked` de la forma antes de escalarla. Si está bloqueada, ajuste el ancho o la altura proporcionalmente en lugar de escalarlos individualmente.