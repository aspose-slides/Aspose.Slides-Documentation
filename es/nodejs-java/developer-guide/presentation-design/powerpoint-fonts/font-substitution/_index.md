---
title: Configurar sustitución de fuentes en presentaciones usando JavaScript
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/nodejs-java/font-substitution/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Configure reglas de sustitución de fuentes e inspeccione las fuentes sustituidas en Aspose.Slides para Node.js mediante Java al renderizar o convertir presentaciones de PowerPoint y OpenDocument."
---
## **Visión general**

La sustitución de fuentes permite a Aspose.Slides usar una fuente disponible en lugar de una fuente que no se puede acceder cuando una presentación se renderiza o se convierte. La sustitución afecta la salida renderizada; no cambia la fuente asignada al contenido de la presentación.

Puede definir la fuente a usar cuando una fuente concreta no está disponible, y puede inspeccionar las sustituciones que Aspose.Slides realizará durante el renderizado. Esto ayuda a mantener la salida coherente entre entornos con diferentes fuentes instaladas.

Si una fuente está disponible pero no tiene una tipografía negrita dedicada, consulte [Manejar fuentes sin una tipografía negrita dedicada](/slides/es/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Esa sección explica cómo rasterizar el texto afectado durante la exportación a PDF y las consecuencias para la selección de texto, la búsqueda y el escalado.

## **Obtener sustituciones de fuentes**

Utilice el método [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) para determinar qué fuentes serán sustituidas cuando la presentación se renderice. El método devuelve objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) que identifican los nombres de la fuente original y la sustituta.

El siguiente ejemplo de JavaScript enumera todas las sustituciones de fuentes para una presentación:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Obtener sustituciones de fuentes para diapositivas seleccionadas**

Utilice la sobrecarga del método [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) con una matriz de índices de diapositivas para inspeccionar solo las sustituciones necesarias para renderizar diapositivas específicas. Esto es útil cuando está renderizando o exportando una parte de una presentación, comprobando una presentación grande de forma incremental, localizando diapositivas que dependen de fuentes no disponibles, preparando un paquete mínimo de fuentes para un servidor o contenedor, o diagnosticando diferencias de renderizado sin procesar diapositivas no relacionadas.

La sobrecarga espera un tipo primitivo Java `int[]`. Créelo con `java.newArray("int", [...])`; una matriz JavaScript simple se convierte en `Integer[]` y no coincide con esta sobrecarga.

La matriz contiene índices de diapositivas basados en uno: `1` identifica la primera diapositiva. En contraste, el accesor de colección [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) utiliza indexación basada en cero, por lo que esa misma diapositiva se accede como `presentation.getSlides().get_Item(0)`. Tenga en cuenta esta diferencia al crear la matriz para evitar errores de desplazamiento.

Llame a la sobrecarga mediante [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). Devuelve solo las sustituciones determinadas al renderizar las diapositivas seleccionadas. Cada resultado es un objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) que contiene los nombres de la fuente original y la sustituta. El resultado refleja el entorno de fuentes actual, las reglas de reserva configuradas, las reglas de sustitución almacenadas en una [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/), y las [fuentes cargadas externamente](/slides/es/nodejs-java/custom-font/).

La misma sustitución puede ser requerida por más de una diapositiva seleccionada. Desduplicar los resultados al crear un inventario de fuentes o un informe de pre‑vuelo. El siguiente ejemplo muestra cada sustitución devuelta y luego crea una lista ordenada de asignaciones de fuentes únicas:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

La clase [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) ofrece ambas sobrecargas. Elija una según el alcance de la operación de renderizado:

| Sobrecarga | Úselo cuando |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) sin argumentos | Necesita sustituciones para toda la presentación. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) con un `int[]` Java de índices de diapositivas | Necesita sustituciones para un rango seleccionado, una comprobación incremental o una exportación parcial. |

## **Establecer reglas de sustitución de fuentes**

Para especificar la fuente que Aspose.Slides debe usar cuando una fuente de origen no está disponible:

1. Cargue la presentación.
2. Cree definiciones de fuente para la fuente de origen y la fuente sustituta.
3. Cree una [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) con la condición [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/).
4. Agregue la regla a una [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Asigne la colección utilizando el método [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Renderice o convierta la presentación.

El siguiente ejemplo de JavaScript sustituye `Arial` por `SomeRareFont` cuando `SomeRareFont` no está disponible, y luego renderiza la primera diapositiva para verificar el resultado. La fuente sustituta debe estar disponible para Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Para un cambio incondicional de las fuentes utilizadas en toda la presentación, consulte [Reemplazo de fuentes](/slides/es/nodejs-java/font-replacement/).
{{% /alert %}}

## **Limitaciones para fuentes de ecuaciones matemáticas**

Las reglas de sustitución de fuentes forman parte del proceso estándar de selección de fuentes utilizado durante el renderizado y la conversión. Funcionan para texto regular cuando Aspose.Slides puede reemplazar una fuente inaccesible por la fuente disponible especificada por una regla.

Las ecuaciones de Office Math tienen un requisito adicional. Si una ecuación utiliza **Cambria Math**, Aspose.Slides puede necesitar esa fuente exacta para calcular y renderizar el diseño de la ecuación. Una regla que sustituya otra fuente matemática, como **STIX Two Math**, no puede reemplazar **Cambria Math** para este propósito, y el renderizado puede seguir indicando que **Cambria Math** es necesaria.

Para renderizar o convertir una presentación de este tipo, haga que **Cambria Math** esté disponible para Aspose.Slides. Instálela en el sistema operativo o cárguela como una [fuente externa](/slides/es/nodejs-java/custom-font/).

Esta limitación se aplica al diseño de ecuaciones. Las reglas de sustitución descritas anteriormente siguen aplicándose al texto normal de la presentación.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre el reemplazo de fuentes y la sustitución de fuentes?**  
[Reemplazo de fuentes](/slides/es/nodejs-java/font-replacement/) cambia intencionalmente una fuente por otra en toda la presentación. La sustitución de fuentes selecciona una fuente para la salida renderizada cuando se cumple la condición configurada, como cuando la fuente original no está disponible.

**¿Cuándo se aplican las reglas de sustitución?**  
Las reglas participan en la [secuencia de selección de fuentes](/slides/es/nodejs-java/font-selection-sequence/) durante el renderizado y la conversión. Con `WhenInaccessible`, una regla se utiliza solo cuando Aspose.Slides no puede acceder a la fuente de origen.

**¿Qué ocurre cuando falta una fuente y no hay una regla de sustitución configurada?**  
Aspose.Slides selecciona la fuente disponible más cercana según su proceso de selección de fuentes. El resultado depende de las fuentes disponibles en el entorno de ejecución.

**¿Puedo cargar fuentes externas para evitar la sustitución?**  
Sí. Puede [cargar fuentes externas](/slides/es/nodejs-java/custom-font/) para que Aspose.Slides las utilice durante el renderizado y la conversión.

**¿Aspose distribuye fuentes con la biblioteca?**  
No. Usted es responsable de proporcionar las fuentes y de cumplir con sus licencias.

**¿Pueden los resultados de sustitución diferir entre Windows, Linux y macOS?**  
Sí. Las fuentes instaladas y las ubicaciones de búsqueda de fuentes difieren según el sistema operativo, de modo que una fuente disponible en una máquina puede requerir sustitución en otra.

**¿Cómo puedo hacer que la selección de fuentes sea consistente en conversiones por lotes?**  
Utilice los mismos archivos y versiones de fuentes en cada máquina o contenedor, [cargue las fuentes externas requeridas](/slides/es/nodejs-java/custom-font/) y [incorpore fuentes](/slides/es/nodejs-java/embedded-font/) cuando las licencias lo permitan. También puede llamar a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) antes de la exportación para identificar sustituciones inesperadas.