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
description: "Aprenda cómo fusionar presentaciones PowerPoint y OpenDocument en PHP clonando diapositivas, controlando másters y layouts, redimensionando el contenido de las diapositivas, preservando secciones y gestionando archivos protegidos o de gran tamaño."
---
## **Visión general**

Aspose.Slides for PHP via Java fusiona presentaciones clonando diapositivas de una [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) a otra. La operación principal es [SlideCollection::addClone()](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/), que puede preservar el formato de la diapositiva origen o adjuntar la diapositiva clonada a un máster o a un layout en la presentación de destino.

Este artículo cubre los flujos de trabajo de fusión más habituales:

- fusionar todas las diapositivas conservando su formato original;
- fusionar diapositivas seleccionadas;
- aplicar un máster de la presentación de destino;
- aplicar un layout específico de la presentación de destino;
- normalizar diferentes tamaños de diapositiva antes de fusionar;
- añadir diapositivas clonadas a una sección;
- fusionar varias presentaciones en un flujo de trabajo de extremo a extremo;
- manejar másters, recursos, notas, comentarios, medios, fuentes, contraseñas, archivos grandes y cuestiones de multihilo.

## **Cómo afecta la clonación de diapositivas a los másters y layouts**

Una diapositiva hereda gran parte de su aspecto de su layout y máster. Por ese motivo, la sobrecarga de clonación que elija determina cómo se integra la diapositiva fusionada en la presentación de destino.

Utilice [SlideCollection::addClone()](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/) de una de estas maneras:

- `addClone(sourceSlide)` — preserva el layout y el formato de la diapositiva origen. Cuando sea necesario, el máster de origen puede clonarse automáticamente en la presentación de destino. Aspose.Slides rastrea los másters clonados automáticamente para que las diapositivas repetidas que usan el mismo máster de origen no provoquen una clonación múltiple del mismo máster.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — adjunta la diapositiva clonada a un [MasterSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/) de destino específico. Aspose.Slides busca un layout coincidente bajo ese máster por tipo o nombre de layout.
- `addClone(sourceSlide, destinationLayout)` — adjunta la diapositiva clonada directamente a un [LayoutSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/) de destino específico.

El máster o layout pasado a una sobrecarga de `addClone` debe pertenecer a la **presentación de destino**, no a la presentación de origen.

## **Fusionar presentaciones completas y preservar el formato de origen**

La fusión más simple copia cada diapositiva de la presentación de origen a la presentación de destino. Esta es la opción adecuada cuando las diapositivas importadas deben conservar su tema, máster y relaciones de layout originales.

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

La presentación resultante puede contener varios másters cuando el origen y el destino utilizan diseños diferentes. Esto es esperado cuando se preserva intencionalmente el formato de origen.

## **Fusionar diapositivas seleccionadas**

No es necesario clonar todas las diapositivas. El ejemplo siguiente importa solo los índices de diapositivas seleccionados del archivo de origen.

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

Valide los índices de diapositiva antes de clonarlos cuando provengan de entrada de usuario o de una configuración externa.

## **Fusionar diapositivas usando un máster de destino**

Utilice la sobrecarga [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/) cuando las diapositivas importadas deban seguir un máster que ya pertenece a la presentación de destino.

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

Aspose.Slides selecciona un layout apropiado bajo el máster especificado al hacer coincidir el tipo o el nombre del layout de origen. Si no existe un layout adecuado y `allowCloneMissingLayout` es `true`, se clona el layout de origen para que la diapositiva pueda añadirse. Si es `false`, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxeditexception/).

Utilice `false` cuando quiera que la fusión falle en lugar de introducir un layout adicional en el máster de destino.

## **Fusionar diapositivas usando un layout específico de destino**

Utilice la sobrecarga [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/) cuando sepa exactamente qué layout de destino deben usar las diapositivas importadas.

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

Aplicar un layout de destino cambia la relación de layout heredada; no rediseña el contenido de la diapositiva origen. Si los layouts de origen y destino tienen estructuras de marcadores diferentes, inspeccione el resultado para confirmar que el formato heredado y el comportamiento de los marcadores son los esperados.

## **Fusionar presentaciones con diferentes tamaños de diapositiva**

Las presentaciones con dimensiones de diapositiva distintas pueden fusionarse, pero clonar una diapositiva en una presentación con otro tamaño de diapositiva no rediseña automáticamente su contenido para el nuevo lienzo. Las formas pueden aparecer desplazadas, escaladas de forma inesperada o fuera del área visible de la diapositiva.

Un enfoque práctico es cambiar el tamaño de la presentación de origen antes de clonar. El método [SlideSize::setSize()](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesize/setsize/) puede escalar el contenido existente mientras cambia las dimensiones de la diapositiva. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesizescaletype/) escala el contenido para que se ajuste al tamaño solicitado.

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

Cambiar el tamaño modifica el objeto de presentación de origen en memoria. Si necesita mantener la presentación de origen sin cambios para otras operaciones, abra una instancia separada para la fusión.

## **Fusionar diapositivas en una sección de presentación**

El bucle básico de clonación de diapositivas no recrea la jerarquía de secciones de la presentación de origen. Si las secciones son relevantes en el resultado, cree o seleccione secciones en la presentación de destino y clone las diapositivas en ellas explícitamente con [addClone(Slide, Section)](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/).

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

Las diapositivas clonadas se añaden al final de la sección de destino especificada. Para preservar varias secciones de origen, recorra [Presentation::getSections](https://reference.aspose.com/slides/es/php-java/aspose.slides/Presentation/#getSections), obtenga las diapositivas actuales de cada sección de origen con [Section::getSlidesListOfSection](https://reference.aspose.com/slides/es/php-java/aspose.slides/Section/#getSlidesListOfSection), recree las secciones en el destino y clone cada diapositiva devuelta en su sección de destino correspondiente. Consulte [Administrar secciones de diapositivas](/slides/es/php-java/slide-section/) para un ejemplo completo de enumeración de secciones, incluidas secciones vacías y cambios estructurales.

## **Fusionar múltiples presentaciones de forma segura**

El ejemplo de extremo a extremo siguiente utiliza la primera presentación como destino, normaliza el tamaño de diapositiva de cada fuente adicional, mantiene cada fuente abierta solo mientras se copia y guarda el archivo final una sola vez.

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

Esta es una base útil para preservar el formato de origen de las diapositivas importadas. Si su salida debe usar un único tema de destino, reemplace la llamada simple `addClone($slide)` por la sobrecarga de máster o layout de destino apropiada mostrada antes.

## **Consideraciones prácticas**

### **Másters, layouts y fidelidad del formato**

La clonación predeterminada de diapositivas puede traer automáticamente un máster de origen necesario a la presentación de destino. Aspose.Slides mantiene un registro interno de los másters clonados automáticamente para evitar clonar el mismo máster repetidamente. Los másters clonados manualmente no se registran en ese registro, por lo que debe evitar preclonar másters a menos que necesite un control explícito sobre la estructura del máster.

No asuma que dos másters o layouts con el mismo nombre sean visualmente equivalentes. Si una plantilla corporativa debe controlar la apariencia final, elija explícitamente un máster o layout de destino y verifique el resultado después de la fusión.

### **Notas y comentarios**

Las notas del orador y los comentarios de diapositiva están asociados al contenido de la diapositiva y se copian cuando una diapositiva se clona. Aspose.Slides también expone APIs dedicadas para [presentation notes](/slides/es/php-java/presentation-notes/) y [presentation comments](/slides/es/php-java/presentation-comments/).

Si el formato de la página de notas es importante, verifique la presentación fusionada porque los másters de notas son objetos a nivel de presentación y pueden diferir entre archivos de origen. Para flujos de revisión, también verifique los autores de los comentarios y los comentarios en hilos después de combinar archivos de distintos autores o plantillas.

### **Imágenes, audio, video, objetos OLE y enlaces externos**

Las diapositivas pueden referenciar recursos a nivel de presentación como imágenes, audio incrustado, vídeo incrustado y datos OLE. Clone la propia diapositiva en lugar de copiar solo sus formas visibles para que Aspose.Slides mantenga las relaciones de la diapositiva con sus recursos.

Los recursos incrustados y los vinculados deben tratarse de forma diferente. Un audio, vídeo, objeto OLE o hipervínculo vinculado sigue dependiendo de su objetivo externo; clonar una diapositiva no convierte un enlace externo en contenido incrustado. Pruebe las rutas y URLs de los recursos vinculados en el entorno donde se abrirá la presentación fusionada.

Aspose.Slides rastrea explícitamente los másters clonados automáticamente, pero esto no debe considerarse una garantía de que recursos binarios idénticos de presentaciones fuentes no relacionadas siempre se deduplicarán. Si el tamaño del archivo de salida es importante, inspeccione el paquete fusionado y mida el resultado en lugar de confiar en la deduplicación implícita.

### **Fuentes incrustadas y disponibilidad de fuentes**

Las fuentes se gestionan a nivel de presentación. Si la tipografía debe mantenerse coherente entre máquinas, no asuma que clonar diapositivas solo garantiza que cada fuente requerida esté disponible en el entorno de destino. Puede inspeccionar las fuentes incrustadas con [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/getembeddedfonts/) y gestionar la incrustación explícitamente como se describe en [Embed Fonts in Presentations](/slides/es/php-java/embedded-font/).

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
    // Trabajar con la presentación desencriptada.
} finally {
    $source->dispose();
}
```

Abrir una fuente cifrada no aplica automáticamente la misma protección a la presentación de destino. Configure la protección de salida por separado cuando sea necesario.

### **Presentaciones grandes y uso de memoria**

Las presentaciones grandes que contienen imágenes de alta resolución, audio, video u otros objetos binarios voluminosos pueden consumir memoria significativa. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) ofrece controles para la gestión de BLOB y el uso de archivos temporales. Consulte [Open Presentations](/slides/es/php-java/open-presentation/#open-large-presentations) para un ejemplo de archivo grande en PHP via Java.

Para archivos grandes, prefiera cargar desde rutas de archivo cuando sea posible, libere cada presentación de origen tan pronto como haya sido fusionada y evite guardar resultados intermedios repetidamente a menos que el flujo de trabajo requiera puntos de control.

### **Seguridad en subprocesos**

No cargue, modifique, guarde ni clone instancias de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) en varios hilos. Estas operaciones no son compatibles con uso multihilo en PHP via Java. Si necesita trabajos de fusión paralelos, ejecútelos en procesos independientes de un solo hilo, cada proceso usando sus propias instancias de presentación, y siga la [Aspose.Slides multithreading guidance](/slides/es/php-java/multithreading/).

## **FAQ**

**¿Cómo mantengo el diseño original de cada presentación de origen?**

Utilice [SlideCollection::addClone](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/) sin proporcionar un máster o layout de destino. Aspose.Slides puede clonar automáticamente el máster de origen cuando la diapositiva importada lo requiera.

**¿Cómo hago que las diapositivas importadas usen el tema de destino?**

Utilice la sobrecarga que acepta un máster de destino. Pase un máster de la presentación de destino, no del origen. Aspose.Slides intentará mapear cada diapositiva de origen a un layout apropiado bajo ese máster.

**¿Cuándo debo usar un layout específico de destino en lugar de un máster de destino?**

Use un layout específico cuando todas las diapositivas importadas deban utilizar un único layout conocido. Use un máster cuando quiera que Aspose.Slides seleccione entre los layouts de ese máster basándose en el tipo o nombre del layout de origen.

**¿Se pueden fusionar presentaciones con diferentes tamaños de diapositiva?**

Sí, pero el contenido de la diapositiva no se rediseña automáticamente para las dimensiones de destino. Redimensione primero la presentación de origen cuando necesite una colocación predecible, por ejemplo con [SlideSize::setSize()](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesize/setsize/) y [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesizescaletype/).

**¿Puedo fusionar archivos PPT, PPTX y ODP en un solo archivo?**

Sí. Cargue cada presentación de origen, clone las diapositivas necesarias en un destino y guarde el destino en un formato de salida compatible. Debido a que los formatos de presentación no soportan exactamente el mismo conjunto de funciones, verifique el contenido complejo después de fusiones entre formatos diferentes. Consulte [Supported File Formats](/slides/es/php-java/supported-file-formats/).

**¿Se conservan automáticamente las secciones de origen?**

No con un bucle básico que solo clona diapositivas. Recree las secciones necesarias en el destino y use la sobrecarga de sección de [addClone](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/addclone/) cuando la estructura de secciones deba preservarse.

**¿Se conservan las notas del orador y los comentarios?**

Se copian con la diapositiva clonada. Para flujos de trabajo que dependen del estilo del máster de notas, de los autores de los comentarios o de datos de revisión en hilos, verifique el resultado fusionado porque esos escenarios implican estructuras a nivel de presentación además del contenido de la diapositiva.

**¿Qué ocurre con audio, vídeo, objetos OLE y hipervínculos?**

El contenido incrustado se transporta como parte de las relaciones de recursos de la diapositiva clonada. Los enlaces externos siguen siendo externos, por lo que sus archivos o URLs objetivo deben seguir estando disponibles después de la fusión.

**¿Se garantiza que las fuentes incrustadas de cada origen estén disponibles en la presentación fusionada?**

No confíe solo en la clonación de diapositivas para el despliegue de fuentes. Inspeccione las fuentes incrustadas del destino y gestione explícitamente la incrustación de fuentes o la disponibilidad externa cuando la tipografía sea importante.

**¿Cómo fusiono un archivo protegido con contraseña?**

Ábralo con la [LoadOptions::setPassword()](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/setpassword/) correcta y luego clone sus diapositivas con normalidad. La protección de salida se configura por separado.

**¿Cómo debo manejar presentaciones muy grandes?**

Utilice la gestión de BLOB cuando los objetos binarios grandes dominen el uso de memoria, prefiera cargar desde rutas de archivo para archivos muy grandes, libere las presentaciones de origen rápidamente y guarde el resultado final solo cuando sea necesario.

**¿Puedo fusionar diapositivas desde varios hilos?**

Cargar, guardar o clonar presentaciones en varios hilos no está soportado en PHP via Java. Para trabajo paralelo, use procesos independientes de un solo hilo y mantenga las instancias de presentación aisladas dentro de cada proceso.