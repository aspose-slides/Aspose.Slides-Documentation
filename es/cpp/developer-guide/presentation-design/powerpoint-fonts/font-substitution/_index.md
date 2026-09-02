---
title: Configurar sustitución de fuentes en presentaciones en C++
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/cpp/font-substitution/
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
- C++
- Aspose.Slides
description: "Configure reglas de sustitución de fuentes e inspeccione las fuentes sustituidas en Aspose.Slides para C++ al renderizar o convertir presentaciones de PowerPoint y OpenDocument."
---
## **Visión general**

La sustitución de fuentes permite a Aspose.Slides usar una fuente disponible en lugar de una fuente que no se puede acceder cuando se renderiza o convierte una presentación. La sustitución afecta la salida renderizada; no cambia la fuente asignada al contenido de la presentación.

Puedes definir la fuente a usar cuando una fuente concreta no está disponible, y puedes inspeccionar las sustituciones que Aspose.Slides realizará durante la renderización. Esto ayuda a mantener la salida coherente entre entornos con diferentes fuentes instaladas.

## **Obtener sustituciones de fuentes**

Utiliza el método [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/getsubstitutions/) para determinar qué fuentes serán sustituidas cuando se renderice la presentación. El método devuelve objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsubstitutioninfo/) que identifican los nombres de la fuente original y la fuente sustituta.

El siguiente ejemplo en C++ enumera todas las sustituciones de fuentes para una presentación:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Obtener sustituciones de fuentes para diapositivas seleccionadas**

Utiliza la sobrecarga del método [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/getsubstitutions/) con un argumento `System::ArrayPtr<int32_t> slides` para inspeccionar sólo las sustituciones necesarias para renderizar diapositivas específicas. Esto es útil cuando renderizas o exportas una parte de una presentación, comprobando una presentación grande de forma incremental, localizando diapositivas que dependen de fuentes no disponibles, preparando un paquete de fuentes mínimo para un servidor o contenedor, o diagnosticando diferencias de renderizado sin procesar diapositivas no relacionadas.

La matriz `slides` contiene índices de diapositivas basados en uno: `1` identifica la primera diapositiva. Por el contrario, el método [Presentation::get_Slide](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_slide/) usa un índice basado en cero, de modo que la misma diapositiva se accede como `presentation->get_Slide(0)`. Ten en cuenta esta diferencia al construir la matriz para evitar errores de desplazamiento.

Llama a la sobrecarga a través del método [Presentation::get_FontsManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_fontsmanager/). Devuelve sólo las sustituciones determinadas mientras se renderizan las diapositivas seleccionadas. Cada resultado es un objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsubstitutioninfo/) que contiene los nombres de la fuente original y la fuente sustituta. El resultado refleja el entorno de fuentes actual, las reglas de reserva configuradas, las reglas de sustitución almacenadas en una [IFontSubstRuleCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsubstrulecollection/), y [fuentes cargadas externamente](/slides/es/cpp/custom-font/).

La misma sustitución puede ser requerida por más de una diapositiva seleccionada. Desduplicar los resultados cuando creas un inventario de fuentes o un informe de preflight. El siguiente ejemplo informa cada sustitución devuelta y luego crea una lista ordenada de asignaciones de fuentes únicas:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

La interfaz [IFontsManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/) proporciona ambas sobrecargas. Elige una según el alcance de la operación de renderizado:

| Sobrecarga | Úselo cuando |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/getsubstitutions/) sin argumentos | Necesites sustituciones para toda la presentación. |
| [GetSubstitutions](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/getsubstitutions/) con `System::ArrayPtr<int32_t> slides` | Necesites sustituciones para un rango seleccionado, una comprobación incremental o una exportación parcial. |

## **Establecer reglas de sustitución de fuentes**

Para especificar la fuente que Aspose.Slides debe usar cuando una fuente origen no está disponible:

1. Cargue la presentación.
2. Cree definiciones de fuentes para la fuente origen y la fuente sustituta.
3. Cree una [FontSubstRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsubstrule/) con la condición [WhenInaccessible](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsubstcondition/).
4. Añada la regla a una [FontSubstRuleCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsubstrulecollection/).
5. Asigne la colección usando el método [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).
6. Renderice o convierta la presentación.

El siguiente ejemplo en C++ sustituye `Arial` por `SomeRareFont` cuando `SomeRareFont` no está disponible, y luego renderiza la primera diapositiva para verificar el resultado. La fuente sustituta debe estar disponible para Aspose.Slides.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Nota" %}}
Para un cambio incondicional de las fuentes usadas en toda la presentación, consulta [Font Replacement](/slides/es/cpp/font-replacement/).
{{% /alert %}}

## **Limitaciones para fuentes de ecuaciones matemáticas**

Las reglas de sustitución de fuentes forman parte del proceso estándar de selección de fuentes utilizado durante la renderización y conversión. Funcionan para texto normal cuando Aspose.Slides puede reemplazar una fuente inaccesible por la fuente disponible especificada por una regla.

Las ecuaciones de Office Math tienen un requisito adicional. Si una ecuación usa **Cambria Math**, Aspose.Slides puede necesitar esa fuente exacta para calcular y renderizar la disposición de la ecuación. Una regla que sustituya otra fuente matemática, como **STIX Two Math**, no puede reemplazar **Cambria Math** con este fin, y la renderización puede seguir indicando que **Cambria Math** es necesaria.

Para renderizar o convertir dicha presentación, haz **Cambria Math** disponible para Aspose.Slides. Instálala en el sistema operativo o cárgala como una [fuente externa](/slides/es/cpp/custom-font/).

Esta limitación se aplica a la disposición de la ecuación. Las reglas de sustitución descritas arriba siguen aplicándose al texto normal de la presentación.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre reemplazo de fuentes y sustitución de fuentes?**

[Font replacement](/slides/es/cpp/font-replacement/) cambia intencionalmente una fuente por otra en toda la presentación. La sustitución de fuentes selecciona una fuente para la salida renderizada cuando se cumple la condición configurada, como cuando la fuente original no está disponible.

**¿Cuándo se aplican las reglas de sustitución?**

Las reglas participan en la [secuencia de selección de fuentes](/slides/es/cpp/font-selection-sequence/) durante la renderización y conversión. Con `WhenInaccessible`, una regla se usa sólo cuando Aspose.Slides no puede acceder a la fuente origen.

**¿Qué ocurre cuando falta una fuente y no hay ninguna regla de sustitución configurada?**

Aspose.Slides elige la fuente disponible más cercana según su proceso de selección de fuentes. El resultado depende de las fuentes disponibles en el entorno de ejecución.

**¿Puedo cargar fuentes externas para evitar la sustitución?**

Sí. Puedes [cargar fuentes externas](/slides/es/cpp/custom-font/) para que Aspose.Slides las use durante la renderización y conversión.

**¿Aspose distribuye fuentes con la biblioteca?**

No. Tú eres responsable de proporcionar las fuentes y cumplir con sus licencias.

**¿Pueden los resultados de sustitución diferir entre Windows, Linux y macOS?**

Sí. Las fuentes instaladas y las ubicaciones de búsqueda de fuentes difieren según el sistema operativo, por lo que una fuente disponible en una máquina puede requerir sustitución en otra.

**¿Cómo puedo hacer que la selección de fuentes sea coherente en conversiones por lotes?**

Utiliza los mismos archivos de fuentes y versiones en cada máquina o contenedor, [carga las fuentes externas necesarias](/slides/es/cpp/custom-font/), y [incorpora fuentes](/slides/es/cpp/embedded-font/) cuando la licencia lo permita. También puedes llamar a [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/getsubstitutions/) antes de la exportación para identificar sustituciones inesperadas.