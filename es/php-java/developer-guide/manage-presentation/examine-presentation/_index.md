---
title: Recuperar y actualizar información de la presentación en PHP
linktitle: Información de la presentación
type: docs
weight: 30
url: /es/php-java/examine-presentation/
keywords:
- formato de presentación
- propiedades de la presentación
- propiedades del documento
- obtener propiedades
- leer propiedades
- cambiar propiedades
- modificar propiedades
- actualizar propiedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Explore diapositivas, estructura y metadatos en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para PHP para obtener información más rápida y auditorías de contenido más inteligentes."
---
## **Visión general**

Aspose.Slides puede identificar el formato de una presentación y leer sus metadatos de documento sin crear un modelo de objeto de presentación completo. Esto es útil cuando necesita clasificar archivos, crear un inventario o inspeccionar propiedades antes de decidir cargar y procesar el contenido de la presentación.

Este artículo muestra la inspección ligera a través de [PresentationFactory](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/) y [PresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/), así como actualizaciones dirigidas mediante [DocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/).

## **Comprobar el formato de una presentación**

Utilice [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/) para inspeccionar un archivo sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/). El método [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#getLoadFormat) informa del formato detectado, como PPTX, PPT o ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Construir un inventario ligero de presentaciones**

Cuando procesa muchos archivos de presentación, puede necesitar un inventario compacto para validación, indexación o un sistema de gestión documental. En este escenario, utilice [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/) para obtener un objeto [PresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/), y luego llame a [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#readDocumentProperties) para leer los metadatos del documento. Este enfoque no crea una instancia de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) ni requiere recorrer todo el modelo de objeto de la presentación.

Las propiedades extendidas expuestas por [DocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/) proporcionan los siguientes valores de inventario:

| Método | Valor del inventario |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getSlides) | Número total de diapositivas. |
| [getHiddenSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Número de diapositivas ocultas. |
| [getNotes](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getNotes) | Número de diapositivas que contienen notas. |
| [getParagraphs](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getParagraphs) | Número total de párrafos, cuando está disponible. |
| [getWords](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getWords) | Número total de palabras. |
| [getMultimediaClips](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Número total de clips de audio y vídeo. |

El ejemplo siguiente lee estos valores sin crear un objeto [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) y muestra un inventario compacto. También combina [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getHeadingPairs) con [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getTitlesOfParts) para mostrar grupos de contenido como fuentes, temas y títulos de diapositivas.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Cada [HeadingPair](https://reference.aspose.com/slides/es/php-java/aspose.slides/headingpair/) proporciona un nombre de grupo y el número de elementos en ese grupo. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getTitlesOfParts) devuelve una matriz plana y ordenada, por lo que debe consumir el número de títulos consecutivos especificados por cada par de encabezado.

### **Metadatos almacenados y limitaciones de formato**

Las propiedades de inventario devueltas por [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#readDocumentProperties) reflejan los metadatos disponibles en el documento fuente. Aspose.Slides no carga ni recorre el modelo de objeto de la presentación para recalcular estos valores en esta llamada. Las propiedades ausentes se representan con valores predeterminados, y los valores almacenados pueden estar desactualizados si la aplicación que guardó el archivo por última vez no actualizó sus propiedades de documento.

- **PPTX:** El formato proporciona propiedades de documento extendidas para recuentos de diapositivas, notas, diapositivas ocultas, párrafos, palabras y multimedia, así como pares de encabezados y títulos de partes. La disponibilidad depende de qué propiedades fueron escritas por el creador del documento.
- **PPT:** El formato binario puede almacenar propiedades de resumen de documento correspondientes. Si una propiedad falta o no fue refrescada por el creador del documento, Aspose.Slides devuelve su valor almacenado o predeterminado en lugar de calcularlo a partir de las diapositivas.
- **ODP:** Los metadatos de OpenDocument proporcionan estadísticas generales del documento, como recuentos de páginas, párrafos y palabras, pero estos valores no se asignan a todas las propiedades extendidas específicas de PowerPoint. Los metadatos de diapositivas ocultas, notas, multimedia, pares de encabezados y títulos de partes pueden no estar disponibles, y las propiedades de inventario pueden devolver valores predeterminados. No se debe considerar que un valor cero o una matriz vacía sea prueba concluyente de que el contenido correspondiente está ausente.

Utilice el enfoque ligero de metadatos para inventarios y comprobaciones preliminares. Cargue la presentación e inspeccione su modelo de objeto en vivo cuando el resultado deba reflejar cambios en memoria o cuando necesite verificar el contenido real de la presentación.

## **Actualizar propiedades de la presentación**

Las propiedades devueltas por [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#readDocumentProperties) también pueden modificarse sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/). Aplique los cambios con [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) y, a continuación, escriba la presentación vinculada con [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

La siguiente imagen muestra las propiedades del documento original.

![Propiedades del documento original de la presentación PowerPoint](input_properties.png)

El siguiente ejemplo cambia el título y la hora de la última guardada y escribe el resultado en un nuevo archivo:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

La siguiente imagen muestra las propiedades del documento modificadas.

![Propiedades del documento modificadas de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para comprobaciones de seguridad relacionadas y configuraciones de protección, consulte los artículos siguientes:

- [Password-Protect Presentations](/slides/es/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/es/php-java/write-protected-presentation/)

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Cargue la presentación y utilice [Presentation::getFontsManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getFontsManager). Llame a [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) para obtener las fuentes incrustadas y a [FontsManager::getFonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/#getFonts) para obtener las fuentes usadas por la presentación. Compare los dos resultados para encontrar fuentes necesarias para la representación que no están incrustadas.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Cuando los metadatos del documento almacenado son suficientes, lea [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getHiddenSlides) a través de [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/) y [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Esto es adecuado para un inventario ligero. Si la presentación se ha modificado en memoria, los metadatos almacenados pueden faltar o estar desactualizados, o necesita verificar los valores en vivo; en ese caso, recorra [Presentation::getSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSlides) e inspeccione el método [Slide::getHidden](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#getHidden) de cada diapositiva.

**¿Puedo detectar si se usa un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**

Sí. Cargue la presentación y llame a [Presentation::getSlideSize](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSlideSize). Utilice [SlideSize::getType](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesize/#getSize) y [SlideSize::getOrientation](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesize/#getOrientation) para comparar la configuración actual con los valores predefinidos y las dimensiones esperadas.

**¿Existe una manera rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Localice cada [Chart](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/) y llame a [ChartData::getDataSourceType](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/#getDataSourceType). Para un libro de trabajo externo, llame a [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). El tipo de fuente de datos y la ruta identifican una referencia externa, pero verificar si el objetivo está disponible requiere una comprobación de recursos separada.

**¿Cómo puedo evaluar las diapositivas 'pesadas' que pueden ralentizar el renderizado o la exportación a PDF?**

No existe una única propiedad de complejidad. Recorra [Presentation::getSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSlides) y la colección [BaseSlide::getShapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslide/#getShapes) de cada diapositiva. Utilice el recuento de formas y la presencia de imágenes grandes, efectos, animaciones o multimedia como señales de filtrado, y mida una representación o exportación representativa antes de considerar una diapositiva como un cuello de botella confirmado de rendimiento.