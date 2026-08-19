---
title: Fusionar presentaciones de forma eficiente en PHP
linktitle: Fusionar presentaciones
type: docs
weight: 40
url: /es/php-java/merge-presentation/
keywords:
- fusionar PowerPoint
- fusionar presentaciones
- fusionar diapositivas
- fusionar PPT
- fusionar PPTX
- fusionar ODP
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- PHP
- Aspose.Slides
description: "Aprenda a fusionar presentaciones PowerPoint y OpenDocument en PHP clonando diapositivas, controlando masters y diseños, redimensionando el contenido de las diapositivas, preservando secciones y manejando archivos protegidos o grandes."
---
## **Descripción general**

Aspose.Slides para PHP a través de Java combina presentaciones clonando diapositivas de una [Presentación](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) a otra. La operación principal es [SlideCollection::addClone()](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/), que puede preservar el formato de la diapositiva original o adjuntar la diapositiva clonada a un master o diseño en la presentación de destino.

Este artículo cubre los flujos de trabajo de combinación más habituales:

- combinar todas las diapositivas manteniendo su formato original;
- combinar diapositivas seleccionadas;
- aplicar un master de la presentación de destino;
- aplicar un diseño específico de la presentación de destino;
- normalizar diferentes tamaños de diapositiva antes de combinar;
- añadir diapositivas clonadas a una sección;
- combinar varias presentaciones en un flujo de trabajo de extremo a extremo;
- gestionar masters, recursos, notas, comentarios, medios, fuentes, contraseñas, archivos grandes y consideraciones de multihilo.

## **Cómo afecta la clonación de diapositivas a los masters y diseños**

Una diapositiva hereda gran parte de su apariencia de su diseño y master. Por esa razón, la sobrecarga de clonación que elija determina cómo se integra la diapositiva combinada en la presentación de destino.

Utilice [SlideCollection::addClone()](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/) de una de estas formas:

- `addClone(sourceSlide)` — preserva el diseño y formato de la diapositiva origen. Cuando sea necesario, el master origen puede clonarse automáticamente en la presentación de destino. Aspose.Slides rastrea los masters clonados automáticamente para que las diapositivas repetidas que usan el mismo master origen no provoquen una clonación múltiple de ese master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — adjunta la diapositiva clonada a un [MasterSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/) de destino específico. Aspose.Slides busca un diseño coincidente bajo ese master por tipo o nombre de diseño.
- `addClone(sourceSlide, destinationLayout)` — adjunta la diapositiva clonada directamente a un [LayoutSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/) de destino específico.

El master o diseño pasado a una sobrecarga de `addClone` debe pertenecer a la **presentación de destino**, no a la presentación de origen.

## **Combinar presentaciones completas y preservar el formato de origen**

La combinación más simple copia cada diapositiva de la presentación de origen a la de destino. Esta es la opción adecuada cuando las diapositivas importadas deben conservar su tema, master y relaciones de diseño originales.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

La presentación resultante puede contener varios masters cuando el origen y el destino utilizan diseños diferentes. Esto es esperado cuando se preserva intencionalmente el formato de origen.

## **Combinar diapositivas seleccionadas**

No es necesario clonar cada diapositiva. El siguiente ejemplo importa solo los índices de diapositiva seleccionados de la presentación de origen.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Valide los índices de diapositiva antes de clonarlos cuando provengan de entrada del usuario o de una configuración externa.

## **Combinar diapositivas usando un master de destino**

Utilice la sobrecarga [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/) cuando las diapositivas importadas deban seguir un master que ya pertenece a la presentación de destino.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides selecciona un diseño apropiado bajo el master especificado coincidiendo con el tipo o nombre del diseño origen. Si no existe un diseño adecuado y `allowCloneMissingLayout` es `true`, el diseño origen se clona para que la diapositiva pueda añadirse. Si es `false`, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxeditexception/).

Use `false` cuando desee que la combinación falle en lugar de introducir un diseño adicional en el master de destino.

## **Combinar diapositivas usando un diseño de destino específico**

Utilice la sobrecarga [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/) cuando sepa exactamente qué diseño de destino deben usar las diapositivas importadas.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aplicar un diseño de destino cambia la relación de diseño heredada; no rediseña el contenido de la diapositiva origen. Si los diseños origen y destino tienen estructuras de marcadores de posición diferentes, inspeccione el resultado para confirmar que el formato heredado y el comportamiento de los marcadores son adecuados.

## **Combinar presentaciones con tamaños de diapositiva diferentes**

Las presentaciones con dimensiones de diapositiva distintas pueden combinarse, pero clonar una diapositiva en una presentación con otro tamaño de diapositiva no rediseña automáticamente su contenido para el nuevo lienzo. Por ello, las formas pueden aparecer desplazadas, escaladas inesperadamente o fuera del área visible de la diapositiva.

Un enfoque práctico es redimensionar la presentación de origen antes de clonar. El método [SlideSize::setSize()](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesize/setsize/) puede escalar el contenido existente mientras cambia las dimensiones de la diapositiva. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesizescaletype/) escala el contenido para ajustarlo al tamaño solicitado.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Redimensionar modifica el objeto de la presentación de origen en memoria. Si necesita que la presentación de origen permanezca sin cambios para otras operaciones, abra una instancia independiente para la combinación.

## **Combinar diapositivas en una sección de presentación**

El bucle básico de clonación de diapositivas no recrea la jerarquía de secciones de la presentación de origen. Si las secciones son importantes en la salida, cree o seleccione secciones en la presentación de destino y clone diapositivas en ellas explícitamente con [addClone(Slide, Section)](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Las diapositivas clonadas se añaden al final de la sección de destino especificada. Para preservar varias secciones de origen, recree esas secciones en el destino y asocie cada diapositiva de origen con la sección de destino correspondiente.

## **Combinar varias presentaciones de forma segura**

El siguiente ejemplo de extremo a extremo usa la primera presentación como destino, normaliza el tamaño de diapositiva de cada origen adicional, mantiene cada origen abierto solo mientras se copia y guarda el archivo final una sola vez.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

Esta es una base útil para preservar el formato de origen de las diapositivas importadas. Si su salida debe usar un único tema de destino, reemplace la llamada simple `addClone($slide)` por la sobrecarga de master o diseño de destino adecuada mostrada previamente.

## **Consideraciones prácticas**

### **Masters, diseños y fidelidad del formato**

La clonación de diapositivas por defecto puede traer automáticamente un master necesario del origen a la presentación de destino. Aspose.Slides mantiene un registro interno de los masters clonados automáticamente para evitar clonar el mismo master repetidamente. Los masters clonados manualmente no se registran, por lo que debe evitar preclonar masters a menos que necesite un control explícito sobre la estructura del master.

No asuma que dos masters o diseños con el mismo nombre son visualmente equivalentes. Si una plantilla corporativa debe controlar la apariencia final, elija explícitamente un master o diseño de destino y verifique el resultado después de combinar.

### **Notas y comentarios**

Las notas del orador y los comentarios de la diapositiva están asociados al contenido de la diapositiva y se copian cuando se clona una diapositiva. Aspose.Slides también expone API dedicadas para [presentation notes](https://docs.aspose.com/slides/es/php-java/presentation-notes/) y [presentation comments](https://docs.aspose.com/slides/es/php-java/presentation-comments/).

Si el formato de la página de notas es importante, verifique la presentación combinada porque los masters de notas son objetos a nivel de presentación y pueden diferir entre archivos de origen. Para flujos de revisión, también verifique los autores de los comentarios y los hilos de comentarios después de combinar archivos de diferentes autores o plantillas.

### **Imágenes, audio, vídeo, objetos OLE y enlaces externos**

Las diapositivas pueden referenciar recursos a nivel de presentación como imágenes, audio incrustado, vídeo incrustado y datos OLE. Clone la propia diapositiva en lugar de copiar solo sus formas visibles para que Aspose.Slides pueda mantener las relaciones de la diapositiva con sus recursos.

Los recursos incrustados y los enlazados deben tratarse de forma diferente. Un audio, vídeo, objeto OLE o hipervínculo enlazado sigue dependiendo de su destino externo; clonar una diapositiva no convierte un enlace externo en contenido incrustado. Pruebe las rutas y URLs de los recursos enlazados en el entorno donde se abrirá la presentación combinada.

Aspose.Slides rastrea explícitamente los masters clonados automáticamente, pero esto no debe interpretarse como una garantía general de que recursos binarios idénticos de presentaciones de origen no relacionadas siempre se deduplicarán. Si el tamaño del archivo de salida es importante, inspeccione el paquete combinado y mida el resultado en lugar de confiar en la deduplicación implícita.

### **Fuentes incrustadas y disponibilidad de fuentes**

Las fuentes se gestionan a nivel de presentación. Si la tipografía debe permanecer coherente entre máquinas, no asuma que clonar diapositivas solo garantiza que cada fuente requerida esté disponible en el entorno de destino. Puede inspeccionar las fuentes incrustadas con [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/getembeddedfonts/) y gestionar la incrustación explícitamente como se describe en [Embed Fonts in Presentations](https://docs.aspose.com/slides/es/php-java/embedded-font/).

También verifique que tenga permiso para incrustar las fuentes utilizadas por los archivos de origen. Las licencias de fuentes pueden restringir la incrustación.

### **Presentaciones protegidas con contraseña**

Una fuente protegida con contraseña debe abrirse correctamente antes de que sus diapositivas puedan clonarse. Proporcione la contraseña mediante [LoadOptions::setPassword()](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Trabajar con la presentación descifrada.
} finally {
    $source->dispose();
}
```

Abrir una fuente cifrada no aplica automáticamente la misma protección a la presentación de destino. Configure la protección de salida por separado cuando sea necesario.

### **Presentaciones grandes y uso de memoria**

Las presentaciones grandes que contienen imágenes de alta resolución, audio, vídeo u otros objetos binarios grandes pueden consumir mucha memoria. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) ofrece controles para la gestión de BLOB y el uso de archivos temporales. Consulte [Open Presentations](https://docs.aspose.com/slides/es/php-java/open-presentation/#open-large-presentations) para un ejemplo de archivo grande en PHP a través de Java.

Para archivos grandes, prefiera cargar desde rutas de archivo cuando sea posible, libere cada presentación de origen tan pronto como se haya combinado y evite guardar resultados intermedios repetidamente a menos que el flujo de trabajo requiera puntos de control.

### **Seguridad en entornos multihilo**

No cargue, modifique, guarde ni clone instancias de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) en varios hilos. Estas operaciones no son compatibles para uso multihilo en PHP a través de Java. Si necesita trabajos de combinación paralela, ejecútelos en procesos independientes de un solo hilo, cada proceso usando sus propias instancias de presentación, y siga la [guía de multihilo de Aspose.Slides](https://docs.aspose.com/slides/es/php-java/multithreading/).

## **FAQ**

**¿Cómo mantengo el diseño original de cada presentación de origen?**

Utilice [`addClone(sourceSlide)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/) sin proporcionar un master o diseño de destino. Aspose.Slides puede clonar automáticamente el master de origen cuando la diapositiva importada lo requiera.

**¿Cómo hago que las diapositivas importadas usen el tema del destino?**

Utilice la sobrecarga que acepta un master de destino. Pase un master de la presentación de destino, no del origen. Aspose.Slides intentará asignar cada diapositiva de origen a un diseño apropiado bajo ese master.

**¿Cuándo debo usar un diseño de destino específico en lugar de un master de destino?**

Use un diseño específico cuando cada diapositiva importada deba usar un diseño conocido. Use un master cuando quiera que Aspose.Slides seleccione entre los diseños de ese master según el tipo o nombre del diseño de origen.

**¿Se pueden combinar presentaciones con tamaños de diapositiva diferentes?**

Sí, pero el contenido de la diapositiva no se rediseña automáticamente para las dimensiones de destino. Redimensione la presentación de origen primero cuando necesite una colocación predecible, por ejemplo con [SlideSize::setSize()](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesize/setsize/) y [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesizescaletype/).

**¿Puedo combinar presentaciones PPT, PPTX y ODP en un solo archivo?**

Sí. Cargue cada presentación de origen, clone las diapositivas necesarias en una presentación de destino y guarde el destino en un formato de salida admitido. Debido a que los formatos de presentación no soportan exactamente el mismo conjunto de funciones, verifique el contenido complejo después de combinaciones entre formatos. consulte [Supported File Formats](https://docs.aspose.com/slides/es/php-java/supported-file-formats/).

**¿Se conservan automáticamente las secciones de origen?**

No con un bucle básico que solo clona diapositivas. Recree las secciones necesarias en el destino y use la sobrecarga de sección de [addClone](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/) cuando la estructura de secciones deba preservarse.

**¿Se conservan las notas del orador y los comentarios?**

Se copian con la diapositiva clonada. Para flujos de trabajo que dependan del estilo del master de notas, de los autores de comentarios o de los hilos de revisión, verifique el resultado combinado porque esos escenarios involucran estructuras a nivel de presentación así como contenido a nivel de diapositiva.

**¿Qué ocurre con audio, vídeo, objetos OLE y hipervínculos?**

El contenido incrustado se transporta como parte de las relaciones de recursos de la diapositiva clonada. Los enlaces externos permanecen externos, por lo que sus archivos o URLs de destino deben seguir estando disponibles después de la combinación.

**¿Se garantiza que las fuentes incrustadas de cada origen estén disponibles en la presentación combinada?**

No confíe solo en la clonación de diapositivas para la distribución de fuentes. Inspeccione las fuentes incrustadas en el destino y gestione explícitamente la incrustación de fuentes o la disponibilidad de fuentes externas cuando la tipografía sea importante.

**¿Cómo combino un archivo protegido con contraseña?**

Ábralo con la [LoadOptions::setPassword()](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/setpassword/) correcta y luego clone sus diapositivas normalmente. La protección de salida se configura por separado.

**¿Cómo debo manejar presentaciones muy grandes?**

Utilice la gestión de BLOB cuando los objetos binarios grandes dominen el uso de memoria, prefiera la carga desde rutas de archivo para archivos muy grandes, libere pronto las presentaciones de origen y guarde el resultado final solo cuando sea necesario.

**¿Puedo combinar diapositivas desde varios hilos?**

Cargar, guardar o clonar presentaciones en varios hilos no está soportado en PHP a través de Java. Para trabajo paralelo, use procesos separados de un solo hilo y mantenga las instancias de presentación aisladas dentro de cada proceso.