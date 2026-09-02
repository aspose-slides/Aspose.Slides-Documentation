---
title: Configurar sustitución de fuentes en presentaciones con Python
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/python-net/font-substitution/
keywords:
- fuente
- fuente sustituta
- sustitución de fuentes
- reemplazar fuente
- reemplazo de fuente
- regla de sustitución
- regla de reemplazo
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Configure reglas de sustitución de fuentes e inspeccione las fuentes sustituidas en Aspose.Slides para Python mediante .NET al renderizar o convertir presentaciones de PowerPoint y OpenDocument."
---
## **Visión general**

La sustitución de fuentes permite a Aspose.Slides usar una fuente disponible en lugar de una que no se pueda acceder cuando se renderiza o convierte una presentación. La sustitución afecta al resultado renderizado; no cambia la fuente asignada al contenido de la presentación.

Puede definir la fuente que se usará cuando una fuente determinada no esté disponible, y puede inspeccionar las sustituciones que Aspose.Slides realizará durante el renderizado. Esto ayuda a mantener la salida coherente en entornos con fuentes instaladas diferentes.

## **Obtener sustituciones de fuentes**

Utilice el método [FontsManager.get_substitutions](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_substitutions/) para determinar qué fuentes se sustituirán cuando la presentación se renderice. El método devuelve objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsubstitutioninfo/) que identifican los nombres de fuente originales y sustituidos.

El siguiente ejemplo en Python enumera todas las sustituciones de fuentes para una presentación:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Obtener sustituciones de fuentes para diapositivas seleccionadas**

Utilice [FontsManager.get_substitutions](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_substitutions/) con una lista de índices de diapositivas para inspeccionar solo las sustituciones necesarias para renderizar diapositivas específicas. Esto es útil cuando renderiza o exporta parte de una presentación, verifica una presentación grande de forma incremental, localiza diapositivas que dependen de fuentes no disponibles, prepara un paquete mínimo de fuentes para un servidor o contenedor, o diagnostica diferencias de renderizado sin procesar diapositivas no relacionadas.

La lista contiene índices de diapositivas basados en uno: `1` identifica la primera diapositiva. En contraste, la colección [Presentation.slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/slides/es/) está basada en cero, de modo que la misma diapositiva se accede como `presentation.slides[0]`. Tenga presente esta diferencia al construir la lista para evitar errores por desplazamiento.

Llame al método a través de la propiedad [Presentation.fonts_manager](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/fonts_manager/). Devuelve solo las sustituciones determinadas mientras se renderizan las diapositivas seleccionadas. Cada resultado es un objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsubstitutioninfo/) que contiene los nombres de fuente original y sustituto. El resultado refleja el entorno de fuentes actual, las reglas de reserva configuradas, las reglas de sustitución almacenadas en una [IFontSubstRuleCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/ifontsubstrulecollection/), y [fuentes cargadas externamente](/slides/es/python-net/custom-font/).

La misma sustitución puede ser requerida por más de una diapositiva seleccionada. Elimine duplicados de los resultados cuando cree un inventario de fuentes o un informe de pre‑vuelo. El siguiente ejemplo informa cada sustitución devuelta y luego crea una lista ordenada de asignaciones de fuentes únicas:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

La clase [FontsManager](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/) proporciona ambas formas del método. Elija una según el alcance de la operación de renderizado:

| Llamada al método | Úselo cuando |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_substitutions/) sin argumentos | Necesita sustituciones para toda la presentación. |
| [get_substitutions](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_substitutions/) con una lista de índices de diapositivas | Necesita sustituciones para un rango seleccionado, verificación incremental o exportación parcial. |

## **Establecer reglas de sustitución de fuentes**

Para especificar la fuente que Aspose.Slides debe usar cuando una fuente origen no está disponible:

1. Cargue la presentación.  
2. Cree definiciones de fuentes para la fuente origen y la sustituta.  
3. Cree una [FontSubstRule](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsubstrule/) con la condición [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsubstcondition/).  
4. Añada la regla a una [FontSubstRuleCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsubstrulecollection/).  
5. Asigne la colección a la propiedad [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).  
6. Renderice o convierta la presentación.

El siguiente ejemplo en Python sustituye `Arial` por `SomeRareFont` cuando `SomeRareFont` no está disponible, y luego renderiza la primera diapositiva para verificar el resultado. La fuente sustituta debe estar disponible para Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Nota" %}}
Para un cambio incondicional de las fuentes usadas en toda la presentación, consulte [Font Replacement](/slides/es/python-net/font-replacement/).
{{% /alert %}}

## **Limitaciones para fuentes de ecuaciones matemáticas**

Las reglas de sustitución de fuentes forman parte del proceso estándar de selección de fuentes utilizado durante el renderizado y la conversión. Funcionan para texto normal cuando Aspose.Slides puede reemplazar una fuente inaccesible por la fuente disponible especificada en una regla.

Las ecuaciones de Office Math tienen un requisito adicional. Si una ecuación usa **Cambria Math**, Aspose.Slides puede necesitar esa fuente exacta para calcular y renderizar la disposición de la ecuación. Una regla que sustituya otra fuente matemática, como **STIX Two Math**, no puede reemplazar **Cambria Math** para este propósito, y el renderizado puede seguir indicando que **Cambria Math** es requerida.

Para renderizar o convertir dicha presentación, haga que **Cambria Math** esté disponible para Aspose.Slides. Instálela en el sistema operativo o cárguela como una [fuente externa](/slides/es/python-net/custom-font/).

Esta limitación se aplica a la disposición de ecuaciones. Las reglas de sustitución descritas arriba siguen aplicándose al texto normal de la presentación.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre reemplazo de fuente y sustitución de fuente?**

[Font replacement](/slides/es/python-net/font-replacement/) cambia intencionalmente una fuente por otra en toda la presentación. La sustitución de fuentes selecciona una fuente para la salida renderizada cuando se cumple la condición configurada, como cuando la fuente original no está disponible.

**¿Cuándo se aplican las reglas de sustitución?**

Las reglas participan en la [secuencia de selección de fuentes](/slides/es/python-net/font-selection-sequence/) durante el renderizado y la conversión. Con `WHEN_INACCESSIBLE`, una regla se utiliza sólo cuando Aspose.Slides no puede acceder a la fuente origen.

**¿Qué ocurre cuando falta una fuente y no hay una regla de sustitución configurada?**

Aspose.Slides selecciona la fuente disponible más cercana según su proceso de selección de fuentes. El resultado depende de las fuentes disponibles en el entorno de ejecución.

**¿Puedo cargar fuentes externas para evitar la sustitución?**

Sí. Puede [cargar fuentes externas](/slides/es/python-net/custom-font/) para que Aspose.Slides las use durante el renderizado y la conversión.

**¿Aspose distribuye fuentes con la biblioteca?**

No. Usted es responsable de proporcionar las fuentes y cumplir con sus licencias.

**¿Pueden los resultados de sustitución diferir entre Windows, Linux y macOS?**

Sí. Las fuentes instaladas y las ubicaciones de búsqueda de fuentes difieren según el sistema operativo, por lo que una fuente disponible en una máquina puede requerir sustitución en otra.

**¿Cómo puedo lograr una selección de fuentes coherente en conversiones por lotes?**

Utilice los mismos archivos y versiones de fuentes en cada máquina o contenedor, [cargue las fuentes externas necesarias](/slides/es/python-net/custom-font/), y [incorpore fuentes](/slides/es/python-net/embedded-font/) cuando la licencia lo permita. También puede llamar a [FontsManager.get_substitutions](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_substitutions/) antes de la exportación para identificar sustituciones inesperadas.