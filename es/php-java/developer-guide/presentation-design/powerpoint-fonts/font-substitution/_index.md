---
title: Configurar sustitución de fuentes en presentaciones usando PHP
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/php-java/font-substitution/
keywords:
- fuente
- fuente sustituta
- sustitución de fuentes
- reemplazar fuente
- reemplazo de fuentes
- regla de sustitución
- regla de reemplazo
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Configure reglas de sustitución de fuentes e inspeccione las fuentes sustituidas en Aspose.Slides para PHP a través de Java al renderizar o convertir presentaciones de PowerPoint y OpenDocument."
---
## **Visión general**

La sustitución de fuentes permite a Aspose.Slides usar una fuente disponible en lugar de una fuente que no se puede acceder cuando se renderiza o convierte una presentación. La sustitución afecta al resultado renderizado; no cambia la fuente asignada al contenido de la presentación.

Puede definir la fuente a usar cuando una fuente concreta no está disponible, y puede inspeccionar las sustituciones que Aspose.Slides realizará durante el renderizado. Esto ayuda a mantener la salida coherente entre entornos con diferentes fuentes instaladas.

## **Obtener sustituciones de fuentes**

Utilice el método [FontsManager::getSubstitutions](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/getsubstitutions/) para determinar qué fuentes se sustituirán cuando se renderice la presentación. El método devuelve objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsubstitutioninfo/) que identifican los nombres de fuente originales y sustituidos.

El siguiente ejemplo en PHP enumera todas las sustituciones de fuentes para una presentación:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Obtener sustituciones de fuentes para diapositivas seleccionadas**

Utilice la sobrecarga del método [FontsManager::getSubstitutions](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/getsubstitutions/) con un argumento `int[] slides` para inspeccionar solo las sustituciones necesarias para renderizar diapositivas específicas. Esto es útil cuando está renderizando o exportando parte de una presentación, revisando una presentación grande de forma incremental, localizando diapositivas que dependen de fuentes no disponibles, preparando un paquete mínimo de fuentes para un servidor o contenedor, o diagnosticando diferencias de renderizado sin procesar diapositivas no relacionadas.

El arreglo `slides` contiene índices de diapositivas basados en uno: `1` identifica la primera diapositiva. En contraste, el accesor de colección [Presentation::getSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSlides) usa índices basados en cero, por lo que la misma diapositiva se accede como `$presentation->getSlides()->get_Item(0)`. Tenga presente esta diferencia al construir el arreglo para evitar errores de off-by-one.

Llame a la sobrecarga mediante el método [Presentation::getFontsManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getFontsManager). Devuelve solo las sustituciones determinadas al renderizar las diapositivas seleccionadas. Cada resultado es un objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsubstitutioninfo/) que contiene los nombres de fuente originales y sustituidos. El resultado refleja el entorno de fuentes actual, las reglas de reserva configuradas, las reglas de sustitución almacenadas en una [FontSubstRuleCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsubstrulecollection/) y las [fuentes cargadas externamente](/slides/es/php-java/custom-font/).

La misma sustitución puede ser requerida por más de una diapositiva seleccionada. Elimine duplicados de los resultados al crear un inventario de fuentes o un informe de preflight. El siguiente ejemplo informa cada sustitución devuelta y luego crea una lista ordenada de asignaciones de fuentes únicas:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

La clase [FontsManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/) proporciona ambas sobrecargas. Elija una según el alcance de la operación de renderizado:

| Sobrecarga | Cuándo usarlo |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/getsubstitutions/) sin argumentos | Necesita sustituciones para la presentación completa. |
| [getSubstitutions](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/getsubstitutions/) con `int[] slides` | Necesita sustituciones para un rango seleccionado, verificación incremental o exportación parcial. |

## **Establecer reglas de sustitución de fuentes**

Para especificar la fuente que Aspose.Slides debe usar cuando una fuente de origen no está disponible:

1. Cargue la presentación.
2. Cree definiciones de fuentes para las fuentes de origen y de sustitución.
3. Cree una [FontSubstRule](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsubstrule/) con la condición [WhenInaccessible](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsubstcondition/).
4. Añada la regla a una [FontSubstRuleCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsubstrulecollection/).
5. Asigne la colección usando el método [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Renderice o convierta la presentación.

El siguiente ejemplo en PHP sustituye `Arial` por `SomeRareFont` cuando `SomeRareFont` no está disponible, y luego renderiza la primera diapositiva para verificar el resultado. La fuente de sustitución debe estar disponible para Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Para un cambio incondicional en las fuentes usadas en toda la presentación, vea [Font Replacement](/slides/es/php-java/font-replacement/).
{{% /alert %}}

## **Limitaciones para fuentes de ecuaciones matemáticas**

Las reglas de sustitución de fuentes forman parte del proceso estándar de selección de fuentes utilizado durante el renderizado y la conversión. Funcionan para texto normal cuando Aspose.Slides puede reemplazar una fuente inaccesible con la fuente disponible especificada por una regla.

Las ecuaciones de Office Math tienen un requisito adicional. Si una ecuación usa **Cambria Math**, Aspose.Slides puede necesitar esa fuente exacta para calcular y renderizar el diseño de la ecuación. Una regla que sustituye otra fuente matemática, como **STIX Two Math**, no puede reemplazar **Cambria Math** para este fin, y el renderizado puede seguir indicando que **Cambria Math** es necesario.

Para renderizar o convertir una presentación de este tipo, haga que **Cambria Math** esté disponible para Aspose.Slides. Instálela en el sistema operativo o cárguela como una [external font](/slides/es/php-java/custom-font/).

Esta limitación se aplica al diseño de ecuaciones. Las reglas de sustitución descritas anteriormente siguen aplicándose al texto normal de la presentación.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre el reemplazo de fuentes y la sustitución de fuentes?**

[Font replacement](/slides/es/php-java/font-replacement/) cambia intencionalmente una fuente por otra en toda la presentación. La sustitución de fuentes selecciona una fuente para la salida renderizada cuando se cumple la condición configurada, como cuando la fuente original no está disponible.

**¿Cuándo se aplican las reglas de sustitución?**

Las reglas forman parte de la [font selection sequence](/slides/es/php-java/font-selection-sequence/) durante el renderizado y la conversión. Con `WhenInaccessible`, una regla se usa solo cuando Aspose.Slides no puede acceder a la fuente de origen.

**¿Qué ocurre cuando falta una fuente y no hay ninguna regla de sustitución configurada?**

Aspose.Slides selecciona la fuente disponible más cercana según su proceso de selección de fuentes. El resultado depende de las fuentes disponibles en el entorno de ejecución.

**¿Puedo cargar fuentes externas para evitar la sustitución?**

Sí. Puede [load external fonts](/slides/es/php-java/custom-font/) para que Aspose.Slides las use durante el renderizado y la conversión.

**¿Aspose distribuye fuentes con la biblioteca?**

No. Usted es responsable de proporcionar las fuentes y cumplir con sus licencias.

**¿Pueden los resultados de sustitución diferir entre Windows, Linux y macOS?**

Sí. Las fuentes instaladas y las ubicaciones de búsqueda de fuentes difieren según el sistema operativo, por lo que una fuente disponible en una máquina puede requerir sustitución en otra.

**¿Cómo puedo mantener la selección de fuentes consistente en conversiones por lotes?**

Utilice los mismos archivos y versiones de fuentes en cada máquina o contenedor, [load required external fonts](/slides/es/php-java/custom-font/), y [embed fonts](/slides/es/php-java/embedded-font/) cuando la licencia lo permita. También puede llamar a [FontsManager::getSubstitutions](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/getsubstitutions/) antes de la exportación para identificar sustituciones inesperadas.