---
title: Gestionar fuentes de tema específicas de script en PHP
linktitle: Fuentes de tema específicas de script
type: docs
weight: 15
url: /es/php-java/script-specific-font-mappings/
keywords:
- fuente específica de script
- asignación de fuente de tema
- presentación multilingüe
- sistema de escritura
- fuente cirílica
- fuente árabe
- fuente japonesa
- fuente georgiana
- fuente thaana
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Inspeccionar, añadir, reemplazar y eliminar asignaciones de fuentes específicas de script en temas de PowerPoint con Aspose.Slides para PHP vía Java."
---
## **Visión general**

Un tema de presentación puede seleccionar diferentes familias tipográficas para distintos sistemas de escritura. Esto permite que el texto multilingüe que sigue usando las fuentes del tema siga un esquema tipográfico coordinado mientras utiliza fuentes adecuadas para cirílico, árabe, japonés, georgiano, thaana y otros scripts.

El [FontScheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontscheme/) del tema contiene una colección de fuentes mayor, normalmente usada para encabezados, y una colección de fuentes menor, normalmente usada para el cuerpo del texto. Además de sus configuraciones de fuentes latinas y de Asia Oriental, ambas colecciones [Fonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/fonts/) exponen asignaciones de etiquetas de sistemas de escritura a nombres de familias tipográficas.

Este artículo muestra cómo inspeccionar y modificar esas asignaciones en el tema maestro de la presentación y verificar que los cambios sobrevivan a un ciclo de guardado y recarga.

## **Entender las etiquetas de script**

Los métodos de fuentes de script usan subtags de script BCP 47 de cuatro letras para identificar los sistemas de escritura. Los valores comunes incluyen:

| Etiqueta de script | Sistema de escritura |
|---|---|
| `Cyrl` | Cirílico |
| `Arab` | Árabe |
| `Hans` | Chino simplificado |
| `Jpan` | Japonés |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Estas asignaciones pertenecen al esquema tipográfico del tema, no a porciones de texto individuales. Una presentación puede definir asignaciones diferentes para las colecciones mayor y menor, y puede omitir asignaciones para algunos scripts.

## **Acceder e inspeccionar las asignaciones de fuentes de script**

Utilice [Presentation::getMasterTheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getMasterTheme) para acceder al tema a nivel de presentación. Los métodos [MasterTheme::getFontScheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontscheme/#getMajor) y [FontScheme::getMinor](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontscheme/#getMinor) proporcionan acceso a las dos colecciones [Fonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/fonts/).

Llame a [Fonts::getScriptFontMap](https://reference.aspose.com/slides/es/php-java/aspose.slides/fonts/#getScriptFontMap) para obtener todas las asignaciones de una colección. Para buscar un sistema de escritura, llame a [Fonts::getScriptFont](https://reference.aspose.com/slides/es/php-java/aspose.slides/fonts/#getScriptFont) con su etiqueta de script. `Fonts::getScriptFont` devuelve `null` cuando esa colección no define la asignación solicitada.

## **Modificar asignaciones y verificar la persistencia**

Utilice [Fonts::setScriptFont](https://reference.aspose.com/slides/es/php-java/aspose.slides/fonts/#setScriptFont) para crear una asignación o reemplazar su familia tipográfica actual. Utilice [Fonts::removeScriptFont](https://reference.aspose.com/slides/es/php-java/aspose.slides/fonts/#removeScriptFont) para eliminar una asignación.

El siguiente ejemplo de extremo a extremo lee todas las asignaciones mayor y menor existentes, busca la fuente mayor japonesa, cambia la fuente mayor cirílica, elimina la asignación menor de Thaana, guarda la presentación y la vuelve a abrir para verificar ambos cambios. Para que el paso de eliminación sea independiente del tema inicial, el ejemplo primero crea una asignación Thaana solo cuando no está ya definida.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

La verificación utiliza el mismo comportamiento `null` que una búsqueda ordinaria: después de que se guarde la eliminación, `Fonts::getScriptFont("Thaa")` devuelve `null` para la colección menor.

## **Diferenciar las asignaciones del tema de otras configuraciones de fuentes**

Las asignaciones de tema específicas de script participan en la selección de fuentes, pero resuelven un problema distinto al formato directo del texto, sustitución y reserva:

| Mecanismo | Propósito | Efecto de cambiar una asignación del tema |
|---|---|---|
| Asignación de fuente de tema específica de script | Selecciona una fuente mayor o menor del tema para un sistema de escritura. | El texto que sigue usando la fuente de tema correspondiente puede resolverse a la nueva familia asignada. |
| Fuente asignada explícitamente a una porción de texto | Fija la familia tipográfica solicitada en esa porción en lugar de depender del tema. | La porción puede permanecer sin cambios porque su formato directo sobrescribe la elección del tema. |
| Sustitución de fuentes | Reemplaza una fuente solicitada cuando esa fuente no está disponible o cuando se aplica una regla de sustitución. | Actúa después de que se ha solicitado una fuente; no redefine la asignación de script del tema. |
| Reserva de fuentes | Proporciona glifos que la fuente seleccionada no contiene, a menudo para rangos Unicode específicos. | Completa la cobertura de glifos faltantes; no cambia la asignación del tema almacenada. |

Para obtener más información sobre los dos últimos mecanismos, consulte [Font Substitution](/slides/es/php-java/font-substitution/) y [Fallback Fonts](/slides/es/php-java/fallback-font/).

Cambiar una asignación en [Presentation::getMasterTheme](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getMasterTheme) afecta solo al contenido cuyo formato efectivo todavía depende de ese tema. El texto puede, en su lugar, heredar una sobrescritura de tema de un maestro, diseño o diapositiva, o usar una fuente asignada explícitamente. Inspeccione esos niveles cuando el resultado visible no siga la asignación a nivel de presentación.

## **Hacer que las fuentes asignadas estén disponibles y validar el resultado**

Una asignación de script almacena un nombre de familia tipográfica; no instala ni carga el archivo de fuente correspondiente. Para una representación y exportación consistentes, cada fuente asignada debe estar instalada en el entorno o suministrada a Aspose.Slides mediante una fuente personalizada como [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsloader/#loadExternalFonts) o [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Consulte [Custom Fonts](/slides/es/php-java/custom-font/) para conocer las opciones de carga disponibles.

Verificar la asignación guardada confirma solo que la definición del tema se preservó. No prueba que la fuente esté disponible, que contenga todos los glifos requeridos o que produzca el diseño previsto. Renderice texto representativo para cada sistema de escritura requerido en una imagen o PDF e inspeccione el resultado. Esto detecta fuentes faltantes, cobertura de glifos incompleta, comportamiento de reserva y cambios de diseño antes de distribuir la presentación. Consulte [Convert PowerPoint Presentations](/slides/es/php-java/convert-powerpoint/) para ejemplos de renderizado y exportación.

## **FAQ**

**¿Qué devuelve `Fonts::getScriptFont` cuando un script no está asignado?**

[Fonts::getScriptFont](https://reference.aspose.com/slides/es/php-java/aspose.slides/fonts/#getScriptFont) devuelve `null` cuando la asignación de script solicitada no está definida en esa colección de fuentes mayor o menor.

**¿`Fonts::setScriptFont` agrega una segunda asignación cuando el script ya existe?**

No. [Fonts::setScriptFont](https://reference.aspose.com/slides/es/php-java/aspose.slides/fonts/#setScriptFont) crea la asignación cuando falta y reemplaza la familia tipográfica asignada cuando la misma etiqueta de script ya está presente.

**¿Por qué al cambiar una asignación del tema no se modificó algún texto?**

El texto puede tener una fuente asignada explícitamente, heredar un tema diferente mediante una sobrescritura, o verse afectado por sustitución o reserva durante el renderizado. Una asignación de script a nivel de presentación controla solo el texto cuyo formato efectivo todavía hace referencia a esa colección de fuentes del tema.

**¿Es suficiente guardar y volver a abrir para validar la salida multilingüe?**

No. Volver a abrir verifica la persistencia de los datos del tema. También debe renderizar texto representativo de cada sistema de escritura requerido para confirmar que las fuentes asignadas están disponibles y contienen los glifos necesarios.