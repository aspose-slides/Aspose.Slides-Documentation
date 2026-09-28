---
title: Configurar sustitución de fuentes en presentaciones en .NET
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/net/font-substitution/
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
- .NET
- C#
- Aspose.Slides
description: "Configurar reglas de sustitución de fuentes e inspeccionar fuentes sustituidas en Aspose.Slides para .NET al renderizar o convertir presentaciones PowerPoint y OpenDocument."
---
## **Visión general**

La sustitución de fuentes permite a Aspose.Slides usar una fuente disponible en lugar de una fuente que no puede ser accesada cuando una presentación se renderiza o convierte. La sustitución afecta la salida renderizada; no cambia la fuente asignada al contenido de la presentación.

Puede definir la fuente que se debe usar cuando una fuente concreta no está disponible, y puede inspeccionar las sustituciones que Aspose.Slides realizará durante la renderización. Esto ayuda a mantener la salida coherente entre entornos con diferentes fuentes instaladas.

## **Obtener sustituciones de fuentes**

Utilice el método [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) para determinar qué fuentes serán sustituidas cuando la presentación se renderice. El método devuelve objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) que identifican los nombres de la fuente original y la fuente sustituta.

El siguiente ejemplo en C# enumera todas las sustituciones de fuentes para una presentación:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Obtener sustituciones de fuentes para diapositivas seleccionadas**

Utilice la sobrecarga [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) con un argumento `int[] slides` para inspeccionar solo las sustituciones necesarias para renderizar diapositivas específicas. Esto es útil cuando está renderizando o exportando parte de una presentación, comprobando una presentación grande de forma incremental, localizando diapositivas que dependen de fuentes no disponibles, preparando un paquete de fuentes mínimo para un servidor o contenedor, o diagnosticando diferencias de renderizado sin procesar diapositivas no relacionadas.

La matriz `slides` contiene índices de diapositivas basados en uno: `1` identifica la primera diapositiva. En contraste, el indexador de la colección [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) está basado en cero, por lo que esa misma diapositiva se accede como `presentation.Slides[0]`. Tenga en cuenta esta diferencia al construir la matriz para evitar errores de desbordamiento de uno.

Llame a la sobrecarga mediante la propiedad [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). Devuelve solo las sustituciones determinadas mientras se renderizan las diapositivas seleccionadas. Cada resultado es un objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) que contiene los nombres de la fuente original y la fuente sustituta. El resultado refleja el entorno de fuentes actual y las [fuentes cargadas externamente](/slides/es/net/custom-font/). Las reglas de sustitución almacenadas en una [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) modifican la salida renderizada pero no se reflejan en el resultado.

La misma sustitución puede ser requerida por más de una diapositiva seleccionada. Desduplicar los resultados cuando cree un inventario de fuentes o un informe de pre‑vuelo. El siguiente ejemplo muestra cada sustitución devuelta y luego crea una lista ordenada de asignaciones de fuentes únicas:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

La interfaz [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) proporciona ambas sobrecargas. Elija una según el alcance de la operación de renderizado:

| Sobrecarga | Cuándo usarla |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) sin argumentos | Necesita sustituciones para toda la presentación. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) con `int[] slides` | Necesita sustituciones para un rango seleccionado, comprobación incremental o exportación parcial. |

## **Establecer reglas de sustitución de fuentes**

Para especificar la fuente que Aspose.Slides debe usar cuando una fuente origen no está disponible:

1. Cargue la presentación.
2. Cree definiciones de fuentes para las fuentes origen y sustituta.
3. Cree una [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) con la condición [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).
4. Añada la regla a una [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).
5. Asigne la colección a la propiedad [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Renderice o convierta la presentación.

El siguiente ejemplo en C# sustituye `Arial` por `SomeRareFont` cuando `SomeRareFont` no está disponible, y luego renderiza la primera diapositiva para verificar el resultado. La fuente sustituta debe estar disponible para Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
Para un cambio incondicional de las fuentes usadas en toda la presentación, vea [Font Replacement](/slides/es/net/font-replacement/).
{{% /alert %}}

## **Limitaciones para fuentes de ecuaciones matemáticas**

Las reglas de sustitución de fuentes forman parte del proceso estándar de selección de fuentes utilizado durante la renderización y conversión. Funcionan para texto normal cuando Aspose.Slides puede reemplazar una fuente inaccesible por la fuente disponible especificada por una regla.

Las ecuaciones de Office Math tienen un requisito adicional. Si una ecuación usa **Cambria Math**, Aspose.Slides puede necesitar esa fuente exacta para calcular y renderizar el diseño de la ecuación. Una regla que sustituya otra fuente matemática, como **STIX Two Math**, no puede reemplazar **Cambria Math** para este fin, y la renderización aún puede indicar que **Cambria Math** es necesaria.

Para renderizar o convertir una presentación de este tipo, haga que **Cambria Math** esté disponible para Aspose.Slides. Instálela en el sistema operativo o cárguela como una [fuente externa](/slides/es/net/custom-font/).

Esta limitación se aplica al diseño de la ecuación. Las reglas de sustitución descritas arriba siguen aplicándose al texto normal de la presentación.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre sustitución de fuentes y reemplazo de fuentes?**

[Font replacement](/slides/es/net/font-replacement/) cambia intencionalmente una fuente por otra en toda la presentación. La sustitución de fuentes selecciona una fuente para la salida renderizada cuando se cumple la condición configurada, como cuando la fuente original no está disponible.

**¿Cuándo se aplican las reglas de sustitución?**

Las reglas participan en la [secuencia de selección de fuentes](/slides/es/net/font-selection-sequence/) durante la renderización y conversión. Con `WhenInaccessible`, una regla se utiliza solo cuando Aspose.Slides no puede acceder a la fuente origen.

**¿Qué ocurre cuando falta una fuente y no hay ninguna regla de sustitución configurada?**

Aspose.Slides selecciona la fuente disponible más cercana según su proceso de selección de fuentes. El resultado depende de las fuentes disponibles en el entorno de ejecución.

**¿Puedo cargar fuentes externas para evitar la sustitución?**

Sí. Puede [cargar fuentes externas](/slides/es/net/custom-font/) para que Aspose.Slides las utilice durante la renderización y conversión.

**¿Aspose distribuye fuentes con la biblioteca?**

No. Usted es responsable de proporcionar las fuentes y cumplir con sus licencias.

**¿Pueden los resultados de la sustitución diferir entre Windows, Linux y macOS?**

Sí. Las fuentes instaladas y las ubicaciones de búsqueda de fuentes difieren según el sistema operativo, por lo que una fuente disponible en una máquina puede requerir sustitución en otra.

**¿Cómo puedo hacer que la selección de fuentes sea coherente en conversiones por lotes?**

Utilice los mismos archivos y versiones de fuentes en cada máquina o contenedor, [cargue las fuentes externas requeridas](/slides/es/net/custom-font/) y [incorpore fuentes](/slides/es/net/embedded-font/) cuando la licencia lo permita. También puede llamar a [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) antes de la exportación para identificar sustituciones inesperadas.