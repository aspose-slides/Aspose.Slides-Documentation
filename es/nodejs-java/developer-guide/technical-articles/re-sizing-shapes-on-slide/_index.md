---
title: Redimensionar formas en diapositivas de presentación en Node.js
type: docs
weight: 130
url: /es/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
  - /es/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Redimensiona fácilmente formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para Node.js vía Java — automatiza los ajustes de diseño de diapositivas y aumenta la productividad."
---
## **Visión general**

Cuando cambias el tamaño de la diapositiva de una presentación, también puede ser necesario redimensionar y reposicionar sus formas para que se ajusten a las nuevas dimensiones. Este artículo muestra cómo escalar las formas manualmente y cómo manejar tablas en diapositivas, maestros y diseños.

## **Redimensionar formas**

Para conservar la posición y el tamaño relativos de cada forma, multiplica sus coordenadas horizontales y su ancho por la proporción entre el nuevo ancho de diapositiva y el ancho original. Aplica la proporción de altura correspondiente a sus coordenadas verticales y su altura.

El primer ejemplo carga una presentación cuyas diapositivas no contienen tablas, cambia el tamaño de la diapositiva a A4 y guarda el resultado. Utiliza [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) con [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) para que el bucle posterior controle el escalado. Las proporciones no tienen unidades; las posiciones y dimensiones de las formas se miden en puntos. Diferentes proporciones de ancho y altura pueden deformar las formas, y cambiar las dimensiones de una forma no escala el tamaño de sus fuentes.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Calcular factores de escala horizontales y verticales independientes.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Las tablas requieren un manejo separado: escala sus anchuras de columna y alturas de fila en lugar de asignar el ancho y alto total de la tabla. Las alturas de fila pueden permanecer mayores de lo solicitado si el contenido de la celda requiere más espacio.
{{% /alert %}}

El segundo ejemplo admite tablas y procesa las formas en maestros y diseños, así como en diapositivas individuales, antes de guardar la presentación redimensionada. Su asistente maneja cada [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) escalando las anchuras de columna con [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) y las alturas mínimas de fila con [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Luego escala la posición de la tabla sin escalar por separado sus dimensiones totales.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Las dimensiones de la tabla están controladas por las anchuras de columna y las alturas de fila.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Calcular factores de escala horizontales y verticales independientes.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Redimensionar formas definidas en maestros y diseños, así como en diapositivas individuales.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Por qué las formas se deforman o se recortan después de redimensionar una diapositiva?**

Si cambias el tamaño de la diapositiva sin escalar las formas, estas mantienen sus posiciones y dimensiones originales y pueden sobresalir de la diapositiva. Escalar el ancho y la altura con distintas proporciones también puede deformar las formas.

**¿El código proporcionado funciona para todos los tipos de formas?**

El primer ejemplo modifica directamente los límites de las formas y está pensado para diapositivas sin tablas. El segundo ejemplo maneja las tablas por separado. Revisa el diseño resultante, particularmente el texto y las tablas, ya que estos ejemplos no escalan el tamaño de las fuentes y el contenido de la tabla puede limitar la altura de las filas.

**¿Cómo redimensionar tablas al redimensionar una diapositiva?**

Escala las anchuras de columna con la proporción de ancho y las alturas mínimas de fila con la proporción de altura, luego escala la posición de la tabla, como se muestra en el segundo ejemplo.

**¿Funcionará este redimensionado para diapositivas maestras y diapositivas de diseño?**

Sí. El segundo ejemplo itera a través de [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) y de [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) de cada maestro, y aplica la misma lógica de redimensionado a sus formas.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Llama a [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) después de cambiar el tamaño de la diapositiva y antes de leer las dimensiones objetivo, de modo que los factores de escala reflejen la orientación final.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Puedes especificar dimensiones personalizadas de la diapositiva con [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). Las dimensiones admitidas también dependen del formato de la presentación y de la aplicación usada para abrir el archivo.

**¿Cómo puedo evitar que las formas con una relación de aspecto fija se deformen?**

Utiliza el mismo factor de escala para el ancho y la altura. Para ajustar el diseño original dentro de las nuevas dimensiones de la diapositiva, usa la menor de las proporciones de ancho y altura tanto para las dimensiones como para las posiciones. Así se conservan las proporciones, aunque puede quedar espacio sin usar a lo largo de un borde.