---
title: Redimensionar formas en diapositivas de presentación en PHP
type: docs
weight: 130
url: /es/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
  - /es/php-java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Redimensiona fácilmente las formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para PHP mediante Java: automatiza los ajustes de diseño de diapositivas y aumenta la productividad."
---
## **Resumen**

Cuando cambias el tamaño de la diapositiva de una presentación, también puede ser necesario redimensionar y reposicionar sus formas para que encajen en las nuevas dimensiones. Este artículo muestra cómo escalar manualmente las formas y cómo manejar tablas en diapositivas, patrones y diseños.

## **Redimensionar formas**

Para preservar la posición y el tamaño relativos de cada forma, multiplica sus coordenadas horizontales y su anchura por la proporción entre el ancho nuevo de la diapositiva y el ancho original. Aplica la proporción de altura correspondiente a sus coordenadas verticales y a su altura.

El primer ejemplo carga una presentación cuyas diapositivas no contienen tablas, cambia el tamaño de la diapositiva a A4 y guarda el resultado. Utiliza [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) con [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) de modo que el bucle posterior controle la escala. Las proporciones no tienen unidades; las posiciones y dimensiones de las formas se miden en puntos. Diferentes proporciones de ancho y altura pueden distorsionar las formas, y cambiar las dimensiones de una forma no escala sus tamaños de fuente.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Calcular factores de escala horizontales y verticales independientes.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Las tablas requieren un manejo separado: escalar el ancho de sus columnas y la altura de sus filas en lugar de asignar el ancho y la altura globales de la tabla. Las alturas de fila pueden permanecer mayores que lo solicitado si el contenido de la celda necesita más espacio.
{{% /alert %}}

El segundo ejemplo admite tablas y procesa formas en patrones y diseños, así como en diapositivas individuales, antes de guardar la presentación redimensionada. Su asistente maneja cada [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) escalando el ancho de las columnas con [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) y la altura mínima de las filas con [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Después escala la posición de la tabla sin escalar por separado sus dimensiones globales.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // Las dimensiones de la tabla se controlan mediante el ancho de las columnas y la altura de las filas.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // Calcular factores de escala horizontales y verticales independientes.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Redimensionar formas definidas en maestros y diseños, así como en diapositivas individuales.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Por qué se distorsionan o recortan las formas después de redimensionar una diapositiva?**

Si cambias el tamaño de la diapositiva sin escalar las formas, estas conservan sus posiciones y dimensiones originales y pueden sobresalir de la diapositiva. Escalar el ancho y la altura con proporciones diferentes también puede distorsionar las formas.

**¿El código proporcionado funciona para todos los tipos de forma?**

El primer ejemplo modifica los límites de las formas directamente y está pensado para diapositivas sin tablas. El segundo ejemplo maneja las tablas por separado. Verifica el diseño resultante, particularmente el texto y las tablas, ya que estos ejemplos no escalan los tamaños de fuente y el contenido de la tabla puede limitar la altura de las filas.

**¿Cómo redimensiono las tablas al redimensionar una diapositiva?**

Escala el ancho de las columnas con la proporción de anchura y la altura mínima de las filas con la proporción de altura, y luego escala la posición de la tabla, como se muestra en el segundo ejemplo.

**¿Este redimensionamiento funciona para diapositivas maestras y diapositivas de diseño?**

Sí. El segundo ejemplo recorre [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) y cada [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) del maestro y aplica la misma lógica de redimensionado a sus formas.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Llama a [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) después de cambiar el tamaño de la diapositiva y antes de leer las dimensiones objetivo, de modo que los factores de escala reflejen la orientación final.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Puedes especificar dimensiones de diapositiva personalizadas con [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). Las dimensiones admitidas también dependen del formato de la presentación y de la aplicación utilizada para abrir el archivo.

**¿Cómo puedo evitar que las formas con una relación de aspecto fija se distorsionen?**

Utiliza el mismo factor de escala para el ancho y la altura. Para ajustar el diseño original dentro de las nuevas dimensiones de la diapositiva, emplea la menor de las proporciones de ancho y altura para ambas dimensiones y posiciones. Esto preserva las proporciones, pero puede dejar espacio sin usar en uno de los bordes.