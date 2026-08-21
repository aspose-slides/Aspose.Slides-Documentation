---
title: Operaciones de presentación de bajo código en PHP
linktitle: API de bajo código
type: docs
weight: 50
url: /es/php-java/low-code-presentation-operations/
keywords:
- API de presentación de bajo código
- convertir presentación
- combinar presentaciones
- iterar diapositivas
- iterar formas
- iterar texto
- recopilar formas
- comprimir presentación
- eliminar diapositivas maestras no usadas
- eliminar diapositivas de diseño no usadas
- comprimir fuentes incrustadas
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Utiliza la API de bajo código de Aspose.Slides en PHP para convertir y combinar presentaciones, iterar el contenido, recopilar formas y reducir el tamaño de la presentación."
---
## **Visión general**

El espacio de nombres [aspose.slides](https://reference.aspose.com/slides/es/php-java/aspose.slides/) proporciona clases auxiliares estáticas para operaciones comunes de presentaciones. Estas ayudas envuelven flujos de trabajo del modelo de objetos usados frecuentemente en métodos concretos, de modo que puedas convertir o combinar archivos, procesar elementos de la presentación, recopilar formas y eliminar contenido no utilizado con menos código.

Los ayudantes de bajo código son más útiles cuando la operación se aplica a un archivo o presentación completa y el flujo de trabajo predeterminado se ajusta a tus requisitos. Utiliza el [modelo de objetos Aspose.Slides](https://reference.aspose.com/slides/es/php-java/aspose.slides/) cuando necesites un control detallado sobre diapositivas individuales, maestros, diseños, formas, configuraciones de exportación o relaciones entre los elementos de la presentación.

La tabla siguiente resume los ayudantes disponibles:

| Ayudante | Para qué sirve |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/es/php-java/aspose.slides/convert/) | Convertir una presentación a otro formato mediante una llamada directa de archivo a archivo. |
| [Merger](https://reference.aspose.com/slides/es/php-java/aspose.slides/merger/) | Combinar archivos de presentación completos del mismo formato. |
| [ForEach_](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/) | Ejecutar una devolución de llamada para cada diapositiva, forma, párrafo o fragmento de texto. |
| [Collect](https://reference.aspose.com/slides/es/php-java/aspose.slides/collect/) | Obtener las formas de toda la presentación para su procesamiento o análisis repetido. |
| [Compress](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/) | Eliminar maestros y diseños no utilizados y reducir los datos de fuentes incrustadas. |

## **Convertir una presentación**

Utiliza [Convert::autoByExtension](https://reference.aspose.com/slides/es/php-java/aspose.slides/convert/#autoByExtension) cuando la extensión del archivo de salida es suficiente para seleccionar el formato de exportación. El método abre la presentación fuente, determina el formato necesario a partir de la ruta de salida y escribe el resultado.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

La clase [Convert](https://reference.aspose.com/slides/es/php-java/aspose.slides/convert/) también ofrece métodos específicos para salida en PDF, SVG, JPEG, PNG y TIFF. Utiliza el modelo de objetos completo cuando necesites inspeccionar o modificar la presentación antes de la exportación o configurar una opción de exportación que no esté disponible en el ayudante seleccionado. Consulta [Convertir presentación](/php-java/convert-presentation/) para flujos de trabajo y opciones específicas de cada formato.

## **Combinar presentaciones**

Utiliza [Merger::process](https://reference.aspose.com/slides/es/php-java/aspose.slides/merger/#process) para combinar archivos de presentación completos con una sola llamada. Las presentaciones de entrada deben tener el mismo formato de archivo.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

El ayudante es apropiado cuando todas las diapositivas deben añadirse a un único resultado sin seleccionarlas o reasignarlas individualmente. Utiliza el modelo de objetos completo cuando necesites combinar diapositivas seleccionadas, aplicar un maestro o diseño de destino, preservar secciones de forma explícita o conciliar tamaños de diapositiva diferentes. Consulta [Combinar presentaciones](/php-java/merge-presentation/) para esos escenarios.

## **Recorrer elementos de la presentación**

La clase [ForEach_](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/) invoca una devolución de llamada para cada tipo solicitado de elemento de la presentación. Evita bucles de colección anidados y es conveniente para inspecciones a nivel de presentación o cambios de formato.

El siguiente ejemplo usa [ForEach_::slide](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#paragraph) y [ForEach_::portion](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#portion) para inspeccionar los elementos correspondientes:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Por defecto, la traversía de formas y texto a nivel de presentación incluye diapositivas normales, maestras y de diseño. Las sobrecargas con un parámetro `includeNotes` también pueden procesar diapositivas de notas. Utiliza bucles de colección directos cuando el orden de recorrido, la salida anticipada, el filtrado antes de la invocación de la devolución de llamada o el control detallado de relaciones padre‑hijo sea importante.

## **Recopilar formas**

Utiliza [Collect::shapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/collect/#shapes) cuando necesites una colección de todas las formas de una presentación en lugar de una devolución de llamada para cada forma. Esto es útil cuando el mismo conjunto será filtrado, contado o procesado más de una vez.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Utiliza [ForEach_::shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#shape) en su lugar cuando cada forma pueda ser manejada inmediatamente y no necesites conservar el resultado recopilado.

## **Comprimir contenido de la presentación**

La clase [Compress](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/) puede eliminar elementos estructurales no utilizados y reducir los datos de fuentes incrustadas:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) elimina las diapositivas de diseño que no son referenciadas por ninguna diapositiva normal.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/#removeUnusedMasterSlides) elimina las diapositivas maestras que ya no se utilizan.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/#compressEmbeddedFonts) elimina los caracteres no utilizados de las fuentes incrustadas.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Elimina primero los diseños no utilizados antes que los maestros no utilizados, de modo que un maestro que quede sin referencias después de la limpieza de diseños también pueda eliminarse. Guarda la presentación optimizada en un archivo nuevo si más adelante pudieras necesitar los maestros, diseños originales o los datos completos de fuentes incrustadas. Para más detalles, consulta [Slide Master](/php-java/slide-master/) y [Embedded Font](/php-java/embedded-font/).

## **Preguntas frecuentes**

**¿Cuándo debería usar la API de bajo código en lugar del modelo de objetos completo?**

Utiliza los ayudantes de bajo código cuando una operación estándar se aplica a un archivo o presentación completa y no requiere un control detallado sobre los elementos individuales. Utiliza el modelo de objetos completo cuando necesites seleccionar diapositivas específicas, controlar las relaciones entre maestros y diseños, inspeccionar el estado intermedio o configurar un comportamiento que el ayudante no expone.

**¿Puede Merger combinar presentaciones en diferentes formatos de archivo?**

No. [Merger::process](https://reference.aspose.com/slides/es/php-java/aspose.slides/merger/#process) requiere que las presentaciones de entrada tengan el mismo formato. Convierte primero los archivos de entrada a un formato común, por ejemplo con [Convert::autoByExtension](https://reference.aspose.com/slides/es/php-java/aspose.slides/convert/#autoByExtension), y luego combina los archivos convertidos.

**¿Procesa ForEach_ diapositivas maestro, de diseño y de notas?**

[ForEach_::slide](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#slide) recorre las diapositivas normales de la presentación. Las operaciones a nivel de presentación de [ForEach_::shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#paragraph) y [ForEach_::portion](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#portion) incluyen, por defecto, diapositivas normales, maestras y de diseño. Utiliza sus sobrecargas con `includeNotes` establecido a `true` para incluir también las diapositivas de notas.

**¿Cuál es la diferencia entre ForEach_::shape y Collect::shapes?**

Utiliza [ForEach_::shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#shape) para procesar cada forma inmediatamente mediante una devolución de llamada. Utiliza [Collect::shapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/collect/#shapes) cuando necesites un resultado iterable que pueda conservarse, filtrarse, contarse o recorrerse varias veces.

**¿Compress siempre reduce el tamaño del archivo de la presentación?**

No necesariamente. El resultado depende de si la presentación contiene diseños no utilizados, maestros no utilizados o fuentes incrustadas con caracteres sin usar. Si ninguno de estos está presente, es posible que las operaciones correspondientes de [Compress](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/) no reduzcan el tamaño del archivo.

**¿Los cambios realizados por ForEach_ o Compress se guardan automáticamente?**

No. Estos ayudantes operan sobre el objeto [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) cargado en memoria. Después de modificar elementos en una devolución de llamada de [ForEach_] o de ejecutar [Compress](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/), llama a [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save) para escribir el resultado.

## **Artículos relacionados**

- [Convertir presentación](/php-java/convert-presentation/)
- [Combinar presentaciones](/php-java/merge-presentation/)
- [Maestro de diapositiva](/php-java/slide-master/)
- [Gestionar cuadro de texto](/php-java/manage-textbox/)
- [Fuente incrustada](/php-java/embedded-font/)