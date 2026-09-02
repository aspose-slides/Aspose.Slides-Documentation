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
description: "Configure reglas de sustitución de fuentes y examine las fuentes sustituidas en Aspose.Slides para .NET al renderizar o convertir presentaciones de PowerPoint y OpenDocument."
---
## **Descripción general**

La sustitución de fuentes permite a Aspose.Slides usar una fuente disponible en lugar de una fuente que no se puede acceder cuando se renderiza o convierte una presentación. La sustitución afecta a la salida renderizada; no cambia la fuente asignada al contenido de la presentación.

Puede definir la fuente que se usará cuando una fuente concreta no esté disponible y puede inspeccionar las sustituciones que Aspose.Slides realizará durante el renderizado. Esto ayuda a mantener la salida coherente entre entornos con fuentes instaladas diferentes.

## **Obtener sustituciones de fuentes**

Utilice el método [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/getsubstitutions/) para determinar qué fuentes se sustituirán cuando se renderice la presentación. El método devuelve objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/es/net/aspose.slides/fontsubstitutioninfo/) que identifican los nombres de fuente original y sustituta.

El siguiente ejemplo en C# muestra todas las sustituciones de fuentes para una presentación:

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

Utilice la sobrecarga de [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/getsubstitutions/) con un argumento `int[] slides` para inspeccionar solo las sustituciones necesarias para renderizar diapositivas específicas. Esto es útil cuando renderiza o exporta parte de una presentación, comprueba una presentación grande de forma incremental, localiza diapositivas que dependen de fuentes no disponibles, prepara un paquete de fuentes mínimo para un servidor o contenedor, o diagnostica diferencias de renderizado sin procesar diapositivas no relacionadas.

La matriz `slides` contiene índices de diapositivas basados en uno: `1` identifica la primera diapositiva. Por el contrario, el indexador de la colección [Presentation.Slides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slides/es/) es cero‑basado, de modo que esa misma diapositiva se accede como `presentation.Slides[0]`. Tenga presente esta diferencia al crear la matriz para evitar errores de desbordamiento.

Llame a la sobrecarga a través de la propiedad [Presentation.FontsManager](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/fontsmanager/). Devuelve solo las sustituciones determinadas mientras se renderizan las diapositivas seleccionadas. Cada resultado es un objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/es/net/aspose.slides/fontsubstitutioninfo/) que contiene los nombres de fuente original y sustituta. El resultado refleja el entorno de fuentes actual, las reglas de reserva configuradas, las reglas de sustitución almacenadas en una [IFontSubstRuleCollection](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsubstrulecollection/) y [fuentes cargadas externamente](/slides/es/net/custom-font/).

La misma sustitución puede ser requerida por más de una diapositiva seleccionada. Elimine los duplicados de los resultados cuando cree un inventario de fuentes o un informe de preflight. El siguiente ejemplo informa de cada sustitución devuelta y luego crea una lista ordenada de asignaciones de fuentes únicas:

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

La interfaz [IFontsManager](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/) ofrece ambas sobrecargas. Elija una según el alcance de la operación de renderizado:

| Sobrecarga | Cuándo usarla |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/getsubstitutions/) sin argumentos | Necesita sustituciones para toda la presentación. |
| [GetSubstitutions](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/getsubstitutions/) con `int[] slides` | Necesita sustituciones para un rango seleccionado, una comprobación incremental o una exportación parcial. |

## **Definir reglas de sustitución de fuentes**

Para especificar la fuente que Aspose.Slides debe usar cuando una fuente origen no esté disponible:

1. Cargue la presentación.
2. Cree definiciones de fuentes para la fuente origen y la sustituta.
3. Cree una [FontSubstRule](https://reference.aspose.com/slides/es/net/aspose.slides/fontsubstrule/) con la condición [WhenInaccessible](https://reference.aspose.com/slides/es/net/aspose.slides/fontsubstcondition/).
4. Añada la regla a una [FontSubstRuleCollection](https://reference.aspose.com/slides/es/net/aspose.slides/fontsubstrulecollection/).
5. Asigne la colección a la propiedad [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/es/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Renderice o convierta la presentación.

El siguiente ejemplo en C# sustituye `Arial` por `SomeRareFont` cuando `SomeRareFont` no está disponible y luego renderiza la primera diapositiva para verificar el resultado. La fuente sustituta debe estar disponible para Aspose.Slides.

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
Para un cambio incondicional de las fuentes utilizadas en toda la presentación, consulte [Font Replacement](/slides/es/net/font-replacement/).
{{% /alert %}}

## **Limitaciones para fuentes de ecuaciones matemáticas**

Las reglas de sustitución de fuentes forman parte del proceso estándar de selección de fuentes utilizado durante el renderizado y la conversión. Funcionan para texto normal cuando Aspose.Slides puede reemplazar una fuente inaccesible por la fuente disponible especificada en una regla.

Las ecuaciones de Office Math tienen un requisito adicional. Si una ecuación usa **Cambria Math**, Aspose.Slides puede necesitar esa fuente exacta para calcular y renderizar el diseño de la ecuación. Una regla que sustituya otra fuente matemática, como **STIX Two Math**, no puede reemplazar **Cambria Math** para este fin, y el renderizado puede seguir informando que **Cambria Math** es necesaria.

Para renderizar o convertir dicha presentación, haga que **Cambria Math** esté disponible para Aspose.Slides. Instálela en el sistema operativo o cárguela como una [fuente externa](/slides/es/net/custom-font/).

Esta limitación se aplica al diseño de ecuaciones. Las reglas de sustitución descritas arriba siguen aplicándose al texto normal de la presentación.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre el reemplazo de fuentes y la sustitución de fuentes?**

[Font replacement](/slides/es/net/font-replacement/) cambia intencionalmente una fuente por otra en toda la presentación. La sustitución de fuentes selecciona una fuente para la salida renderizada cuando se cumple la condición configurada, como cuando la fuente original no está disponible.

**¿Cuándo se aplican las reglas de sustitución?**

Las reglas participan en la [secuencia de selección de fuentes](/slides/es/net/font-selection-sequence/) durante el renderizado y la conversión. Con `WhenInaccessible`, una regla se usa solo cuando Aspose.Slides no puede acceder a la fuente origen.

**¿Qué ocurre cuando falta una fuente y no hay ninguna regla de sustitución configurada?**

Aspose.Slides selecciona la fuente disponible más cercana según su proceso de selección de fuentes. El resultado depende de las fuentes disponibles en el entorno de ejecución.

**¿Puedo cargar fuentes externas para evitar la sustitución?**

Sí. Puede [cargar fuentes externas](/slides/es/net/custom-font/) para que Aspose.Slides las utilice durante el renderizado y la conversión.

**¿Aspose distribuye fuentes con la biblioteca?**

No. Usted es responsable de proporcionar las fuentes y de cumplir con sus licencias.

**¿Pueden los resultados de la sustitución diferir entre Windows, Linux y macOS?**

Sí. Las fuentes instaladas y las ubicaciones de búsqueda de fuentes difieren según el sistema operativo, por lo que una fuente disponible en una máquina puede requerir sustitución en otra.

**¿Cómo puedo hacer que la selección de fuentes sea coherente en conversiones por lotes?**

Utilice los mismos archivos y versiones de fuentes en cada máquina o contenedor, [cargue las fuentes externas requeridas](/slides/es/net/custom-font/) y [incorpore fuentes](/slides/es/net/embedded-font/) cuando la licencia lo permita. También puede llamar a [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/getsubstitutions/) antes de la exportación para identificar sustituciones inesperadas.