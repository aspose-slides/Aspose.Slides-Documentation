---
title: Operaciones de Presentación de Bajo Código en PHP
linktitle: API de Bajo Código
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
- eliminar diapositivas patrón no usadas
- eliminar diapositivas de diseño no usadas
- comprimir fuentes incrustadas
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Utiliza la API de bajo código de Aspose.Slides en PHP para convertir y combinar presentaciones, iterar el contenido, recopilar formas y reducir el tamaño de la presentación."
---
## **Resumen**

El espacio de nombres [aspose.slides](https://reference.aspose.com/slides/es/php-java/aspose.slides/) proporciona clases auxiliares estáticas para operaciones comunes con presentaciones. Estos asistentes envuelven flujos de trabajo del modelo de objetos que se usan con frecuencia en métodos concretos, de modo que puedes convertir o combinar archivos, procesar elementos de la presentación, recopilar formas y eliminar contenido no utilizado con menos código.

Los asistentes de bajo código son más útiles cuando la operación se aplica a un archivo o presentación completa y el flujo de trabajo predeterminado se ajusta a tus requisitos. Utiliza el modelo de objetos completo de [Aspose.Slides](https://reference.aspose.com/slides/es/php-java/aspose.slides/) cuando necesites un control detallado sobre diapositivas individuales, patrones, diseños, formas, configuraciones de exportación o relaciones entre los elementos de la presentación.

La siguiente tabla resume los asistentes disponibles:

| Asistente | Uso |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/es/php-java/aspose.slides/convert/) | Convertir una presentación a otro formato mediante una llamada directa de archivo a archivo. |
| [Merger](https://reference.aspose.com/slides/es/php-java/aspose.slides/merger/) | Combinar archivos de presentación completos del mismo formato. |
| [ForEach_](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/) | Ejecutar una devolución de llamada para cada diapositiva, forma, párrafo o fragmento de texto. |
| [Collect](https://reference.aspose.com/slides/es/php-java/aspose.slides/collect/) | Obtener formas de toda la presentación para procesarlas o analizarlas repetidamente. |
| [Compress](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/) | Eliminar patrones y diseños no usados y reducir los datos de fuentes incrustadas. |

## **Convertir una Presentación**

Utiliza [Convert::autoByExtension](https://reference.aspose.com/slides/es/php-java/aspose.slides/convert/#autoByExtension) cuando la extensión del archivo de salida es suficiente para seleccionar el formato de exportación. El método abre la presentación de origen, determina el formato necesario a partir de la ruta de salida y escribe el resultado.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

La clase [Convert](https://reference.aspose.com/slides/es/php-java/aspose.slides/convert/) también ofrece métodos dedicados para salida en PDF, SVG, JPEG, PNG y TIFF. Usa el modelo de objetos completo cuando necesites inspeccionar o modificar la presentación antes de la exportación o configurar una opción de exportación que no esté expuesta por el asistente seleccionado. Consulta [Convert Presentation](/slides/es/php-java/convert-presentation/) para flujos de trabajo y opciones específicos de cada formato.

## **Combinar Presentaciones**

Utiliza [Merger::process](https://reference.aspose.com/slides/es/php-java/aspose.slides/merger/#process) para combinar archivos de presentación completos con una sola llamada. Las presentaciones de entrada deben tener el mismo formato de archivo.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

El asistente es adecuado cuando todas las diapositivas deben añadirse a un único resultado sin seleccionarlas o reasignarlas individualmente. Usa el modelo de objetos completo cuando necesites combinar diapositivas seleccionadas, aplicar un patrón o diseño de destino, preservar secciones de forma explícita o reconciliar tamaños de diapositiva diferentes. Consulta [Merge Presentations](/slides/es/php-java/merge-presentation/) para esos escenarios.

## **Iterar a través de los Elementos de la Presentación**

La clase [ForEach_](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/) invoca una devolución de llamada para cada tipo solicitado de elemento de la presentación. Evita bucles anidados de colecciones y resulta práctica para inspecciones o cambios de formato a nivel de toda la presentación.

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

Por defecto, el recorrido de formas y texto a nivel de presentación incluye diapositivas normales, de patrón y de diseño. Las sobrecargas con un parámetro `includeNotes` también pueden procesar diapositivas de notas. Utiliza bucles de colección directos cuando el orden de recorrido, la salida anticipada, el filtrado antes de la llamada o el control detallado de padres e hijos sea importante.

## **Recopilar Formas**

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

Usa [ForEach_::shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#shape) en su lugar cuando cada forma pueda manejarse inmediatamente y no necesites conservar el resultado recopilado.

## **Comprimir el Contenido de la Presentación**

La clase [Compress](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/) puede eliminar elementos estructurales no usados y reducir los datos de fuentes incrustadas:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) elimina diapositivas de diseño que no son referenciadas por ninguna diapositiva normal.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/#removeUnusedMasterSlides) elimina patrones que ya no se utilizan.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/#compressEmbeddedFonts) elimina caracteres no usados de las fuentes incrustadas.

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

Elimina primero los diseños no usados antes que los patrones, de modo que un patrón que quede sin referencias tras la limpieza de diseños también pueda eliminarse. Guarda la presentación optimizada en un archivo nuevo si más adelante puedes necesitar los patrones, diseños o los datos completos de fuentes incrustadas originales. Para más detalles, consulta [Slide Master](/slides/es/php-java/slide-master/) y [Embedded Font](/slides/es/php-java/embedded-font/).

## **Preguntas frecuentes**

**¿Cuándo debo usar la API de bajo código en lugar del modelo de objetos completo?**

Utiliza los asistentes de bajo código cuando una operación estándar se aplica a un archivo o presentación completa y no requiere control detallado sobre elementos individuales. Usa el modelo de objetos completo cuando necesites seleccionar diapositivas específicas, controlar relaciones entre patrones y diseños, inspeccionar el estado intermedio o configurar un comportamiento que el asistente no exponga.

**¿Puede Merger combinar presentaciones en diferentes formatos de archivo?**

No. [Merger::process](https://reference.aspose.com/slides/es/php-java/aspose.slides/merger/#process) requiere que las presentaciones de entrada tengan el mismo formato. Convierte primero los archivos de origen a un formato común, por ejemplo con [Convert::autoByExtension](https://reference.aspose.com/slides/es/php-java/aspose.slides/convert/#autoByExtension), y luego combina los archivos convertidos.

**¿ForEach_ procesa diapositivas de patrón, diseño y notas?**

[ForEach_::slide](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#slide) recorre las diapositivas normales de la presentación. Las operaciones a nivel de presentación de [ForEach_::shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#paragraph) y [ForEach_::portion](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#portion) incluyen por defecto diapositivas normales, de patrón y de diseño. Utiliza sus sobrecargas con `includeNotes` establecido en `true` para incluir diapositivas de notas.

**¿Cuál es la diferencia entre ForEach_::shape y Collect::shapes?**

Usa [ForEach_::shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_/#shape) para procesar cada forma inmediatamente a través de una devolución de llamada. Usa [Collect::shapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/collect/#shapes) cuando necesites un resultado iterable que pueda conservarse, filtrarse, contarse o recorrerse varias veces.

**¿Compress siempre reduce el tamaño del archivo de la presentación?**

No necesariamente. El resultado depende de si la presentación contiene diseños no usados, patrones no usados o fuentes incrustadas con caracteres no usados. Si ninguno de esos elementos está presente, las operaciones correspondientes de [Compress](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/) pueden no reducir el tamaño del archivo.

**¿Los cambios realizados por ForEach_ o Compress se guardan automáticamente?**

No. Estos asistentes actúan sobre el objeto [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) cargado en memoria. Después de modificar elementos en una devolución de llamada de [ForEach_](https://reference.aspose.com/slides/es/php-java/aspose.slides/foreach_) o de ejecutar [Compress](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/), llama a [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save) para escribir el resultado.

## **Artículos relacionados**

- [Convert Presentation](/slides/es/php-java/convert-presentation/)
- [Merge Presentations](/slides/es/php-java/merge-presentation/)
- [Slide Master](/slides/es/php-java/slide-master/)
- [Manage Text Box](/slides/es/php-java/manage-textbox/)
- [Embedded Font](/slides/es/php-java/embedded-font/)