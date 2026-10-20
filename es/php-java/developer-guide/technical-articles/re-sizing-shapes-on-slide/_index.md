---
title: Redimensionar formas en diapositivas de presentación en PHP
type: docs
weight: 130
url: /es/php-java/resizing-shapes-on-slide/
aliases:
  - /es/php-java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- cambiar tamaño de forma
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Redimensiona fácilmente las formas en diapositivas de PowerPoint y OpenDocument con Aspose.Slides para PHP a través de Java: automatiza los ajustes de diseño de diapositivas y aumenta la productividad."
---
## **Visión general**

Cuando cambias el tamaño de la diapositiva de una presentación, también puede que necesites redimensionar y reposicionar sus formas para que se ajusten a las nuevas dimensiones. Este artículo muestra cómo escalar manualmente las formas y cómo manejar las tablas en diapositivas, patrones y diseños.

## **Redimensionar formas**

Para conservar la posición y el tamaño relativo de cada forma, multiplica sus coordenadas horizontales y su anchura por la razón entre el ancho nuevo de la diapositiva y el ancho original. Aplica la razón correspondiente de altura a sus coordenadas verticales y a su altura.

El primer ejemplo carga una presentación cuyas diapositivas no contienen tablas, cambia el tamaño de la diapositiva a A4 y guarda el resultado. Utiliza [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) con [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) para que el bucle posterior controle el escalado. Las razones son adimensionales; las posiciones y dimensiones de las formas se miden en puntos. Diferentes razones de anchura y altura pueden distorsionar las formas, y cambiar las dimensiones de una forma no escala los tamaños de fuente.

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
Las tablas requieren un manejo separado: escalar sus anchuras de columna y alturas de fila en lugar de asignar la anchura y altura globales de la tabla. Las alturas de fila pueden permanecer mayores de lo solicitado si el contenido de la celda necesita más espacio.
{{% /alert %}}

El segundo ejemplo admite tablas y procesa las formas en patrones y diseños, así como en diapositivas individuales, antes de guardar la presentación redimensionada. Su asistente maneja cada [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) escalando las anchuras de columna con [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) y las alturas mínimas de fila con [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Luego escala la posición de la tabla sin escalar por separado sus dimensiones globales.

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

    // Redimensionar las formas definidas en maestros y diseños, así como en diapositivas individuales.
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

Si cambias el tamaño de la diapositiva sin escalar las formas, estas mantienen sus posiciones y dimensiones originales y pueden sobresalir más allá de la diapositiva. Escalar la anchura y la altura con razones diferentes también puede distorsionar las formas.

**¿El código proporcionado funciona para todos los tipos de forma?**

El primer ejemplo modifica directamente los límites de la forma y está pensado para diapositivas sin tablas. El segundo ejemplo maneja las tablas por separado. Comprueba el diseño resultante, en particular el texto y las tablas, ya que estos ejemplos no escalan los tamaños de fuente y el contenido de la tabla puede limitar las alturas de fila.

**¿Cómo redimensiono las tablas al redimensionar una diapositiva?**

Escala las anchuras de columna por la razón de anchura y las alturas mínimas de fila por la razón de altura, y luego escala la posición de la tabla, como se muestra en el segundo ejemplo.

**¿Funcionará este redimensionado para diapositivas maestras y diapositivas de diseño?**

Sí. El segundo ejemplo recorre [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) y cada [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) del maestro, y aplica la misma lógica de redimensionado a sus formas.

**¿Puedo cambiar la orientación de una diapositiva (vertical/horizontal) junto con el redimensionado?**

Sí. Llama a [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) después de cambiar el tamaño de la diapositiva y antes de leer las dimensiones objetivo, de modo que los factores de escala reflejen la orientación final.

**¿Existe un límite para el tamaño de diapositiva que puedo establecer?**

Puedes especificar dimensiones de diapositiva personalizadas con [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). Las dimensiones admitidas también dependen del formato de la presentación y de la aplicación utilizada para abrir el archivo.

**¿Cómo puedo evitar que las formas con una relación de aspecto fija se distorsionen?**

Utiliza el mismo factor de escala para la anchura y la altura. Para adaptar el diseño original a las nuevas dimensiones de la diapositiva, usa la menor de las razones de anchura y altura tanto para las dimensiones como para las posiciones. Esto conserva las proporciones pero puede dejar espacio sin usar a lo largo de un borde.