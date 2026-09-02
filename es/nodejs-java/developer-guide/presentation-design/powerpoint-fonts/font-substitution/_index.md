---
title: Configurar la sustitución de fuentes en presentaciones usando JavaScript
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
description: "Configura reglas de sustitución de fuentes e inspecciona las fuentes sustituidas en Aspose.Slides para Node.js mediante Java al renderizar o convertir presentaciones PowerPoint y OpenDocument."
---
## **Resumen**

La sustitución de fuentes permite a Aspose.Slides usar una fuente disponible en lugar de una fuente que no se puede acceder cuando una presentación se renderiza o se convierte. La sustitución afecta la salida renderizada; no cambia la fuente asignada al contenido de la presentación.

Puede definir la fuente que se usará cuando una fuente concreta no esté disponible y puede inspeccionar las sustituciones que Aspose.Slides realizará durante la renderización. Esto ayuda a mantener la salida coherente entre entornos con fuentes instaladas diferentes.

## **Obtener sustituciones de fuentes**

Utilice el método [FontsManager.getSubstitutions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) para determinar qué fuentes se sustituirán cuando la presentación se renderice. El método devuelve objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsubstitutioninfo/) que identifican los nombres de la fuente original y la fuente sustituida.

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

Utilice la sobrecarga del método [FontsManager.getSubstitutions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) con una matriz de índices de diapositivas para inspeccionar solo las sustituciones necesarias para renderizar diapositivas concretas. Esto es útil cuando está renderizando o exportando parte de una presentación, comprobando una presentación grande de forma incremental, localizando diapositivas que dependen de fuentes no disponibles, preparando un paquete de fuentes mínimo para un servidor o contenedor, o diagnosticando diferencias de renderizado sin procesar diapositivas no relacionadas.

La sobrecarga espera un primitivo Java `int[]`. Créelo con `java.newArray("int", [...])`; una matriz JavaScript simple se convierte a `Integer[]` y no coincide con esta sobrecarga.

La matriz contiene índices de diapositivas basados en uno: `1` identifica la primera diapositiva. En contraste, el accesor de colección [Presentation.getSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getslides/) utiliza indexación basada en cero, de modo que la misma diapositiva se accede como `presentation.getSlides().get_Item(0)`. Tenga presente esta diferencia al crear la matriz para evitar errores de desplazamiento.

Llame a la sobrecarga a través de [Presentation.getFontsManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getfontsmanager/). Devuelve solo las sustituciones determinadas mientras se renderizan las diapositivas seleccionadas. Cada resultado es un objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsubstitutioninfo/) que contiene los nombres de la fuente original y la fuente sustituida. El resultado refleja el entorno de fuentes actual, las reglas de retroceso configuradas, las reglas de sustitución almacenadas en una [FontSubstRuleCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsubstrulecollection/), y las [fuentes cargadas externamente](/slides/es/nodejs-java/custom-font/).

La misma sustitución puede ser requerida por más de una diapositiva seleccionada. Elimine duplicados de los resultados cuando cree un inventario de fuentes o un informe de pre‑vuelo. El siguiente ejemplo informa de cada sustitución devuelta y luego crea una lista ordenada de asignaciones de fuentes únicas:

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

La clase [FontsManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/) proporciona ambas sobrecargas. Elija una según el alcance de la operación de renderizado:

| Sobrecarga | Úselo cuando |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) sin argumentos | Necesite sustituciones para toda la presentación. |
| [getSubstitutions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) con un `int[]` de índices de diapositivas | Necesite sustituciones para un rango seleccionado, una comprobación incremental o una exportación parcial. |

## **Establecer reglas de sustitución de fuentes**

Para especificar la fuente que Aspose.Slides debe usar cuando una fuente origen no esté disponible:

1. Cargue la presentación.
2. Cree definiciones de fuentes para la fuente origen y la fuente sustituta.
3. Cree una [FontSubstRule](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsubstrule/) con la condición [WhenInaccessible](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsubstcondition/).
4. Añada la regla a una [FontSubstRuleCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Asigne la colección mediante el método [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Renderice o convierta la presentación.

El siguiente ejemplo de JavaScript sustituye `Arial` por `SomeRareFont` cuando `SomeRareFont` no está disponible y, a continuación, renderiza la primera diapositiva para verificar el resultado. La fuente sustituta debe estar disponible para Aspose.Slides.

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

{{% alert color="info" title="Nota" %}}
Para un cambio incondicional de las fuentes usadas en toda la presentación, consulte [Reemplazo de fuentes](/slides/es/nodejs-java/font-replacement/).
{{% /alert %}}

## **Limitaciones para fuentes de ecuaciones matemáticas**

Las reglas de sustitución de fuentes forman parte del proceso estándar de selección de fuentes utilizado durante la renderización y la conversión. Funcionan para texto normal cuando Aspose.Slides puede reemplazar una fuente inaccesible por la fuente disponible especificada en una regla.

Las ecuaciones de Office Math tienen un requisito adicional. Si una ecuación utiliza **Cambria Math**, Aspose.Slides puede necesitar esa fuente exacta para calcular y renderizar la disposición de la ecuación. Una regla que sustituya otra fuente matemática, como **STIX Two Math**, no puede reemplazar **Cambria Math** para este propósito, y la renderización puede seguir indicando que **Cambria Math** es necesaria.

Para renderizar o convertir dicha presentación, haga que **Cambria Math** esté disponible para Aspose.Slides. Instálela en el sistema operativo o cárguela como una [fuente externa](/slides/es/nodejs-java/custom-font/).

Esta limitación se aplica a la disposición de las ecuaciones. Las reglas de sustitución descritas anteriormente siguen aplicándose al texto normal de la presentación.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre el reemplazo de fuentes y la sustitución de fuentes?**  
[Reemplazo de fuentes](/slides/es/nodejs-java/font-replacement/) cambia intencionalmente una fuente por otra en toda la presentación. La sustitución de fuentes selecciona una fuente para la salida renderizada cuando se cumple la condición configurada, por ejemplo, cuando la fuente original no está disponible.

**¿Cuándo se aplican las reglas de sustitución?**  
Las reglas participan en la [secuencia de selección de fuentes](/slides/es/nodejs-java/font-selection-sequence/) durante la renderización y la conversión. Con `WhenInaccessible`, una regla se usa solo cuando Aspose.Slides no puede acceder a la fuente origen.

**¿Qué ocurre cuando falta una fuente y no hay ninguna regla de sustitución configurada?**  
Aspose.Slides selecciona la fuente disponible más cercana según su proceso de selección de fuentes. El resultado depende de las fuentes disponibles en el entorno de ejecución.

**¿Puedo cargar fuentes externas para evitar la sustitución?**  
Sí. Puede [cargar fuentes externas](/slides/es/nodejs-java/custom-font/) para que Aspose.Slides las use durante la renderización y la conversión.

**¿Aspose distribuye fuentes con la biblioteca?**  
No. Usted es responsable de proporcionar las fuentes y de cumplir con sus licencias.

**¿Pueden los resultados de sustitución diferir entre Windows, Linux y macOS?**  
Sí. Las fuentes instaladas y las ubicaciones de búsqueda de fuentes difieren según el sistema operativo, de modo que una fuente disponible en una máquina puede requerir sustitución en otra.

**¿Cómo puedo lograr una selección de fuentes coherente en conversiones por lotes?**  
Utilice los mismos archivos y versiones de fuentes en cada máquina o contenedor, [cargue las fuentes externas necesarias](/slides/es/nodejs-java/custom-font/), y [incorpore fuentes](/slides/es/nodejs-java/embedded-font/) cuando la licencia lo permita. También puede llamar a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) antes de la exportación para identificar sustituciones inesperadas.