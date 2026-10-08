---
title: Configuración de la sustitución de fuentes en presentaciones usando Python a través de Java
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/python-java/font-substitution/
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
- Python
- Java
- Aspose.Slides
description: "Configura reglas de sustitución de fuentes e inspecciona las fuentes sustituidas en Aspose.Slides para Python a través de Java al renderizar o convertir presentaciones de PowerPoint y OpenDocument."
---
## **Descripción general**

La sustitución de fuentes permite a Aspose.Slides usar una fuente disponible en lugar de una fuente que no se puede acceder cuando una presentación se renderiza o se convierte. La sustitución afecta la salida renderizada; no cambia la fuente asignada al contenido de la presentación.

Puede definir la fuente a usar cuando una fuente concreta no esté disponible, y puede inspeccionar las sustituciones que Aspose.Slides realizará durante el renderizado. Esto ayuda a mantener la salida coherente en entornos con fuentes instaladas diferentes.

Si una fuente está disponible pero no tiene una variante negrita dedicada, consulte [Gestionar fuentes sin una tipografía negrita dedicada](/slides/es/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Esa sección explica cómo rasterizar el texto afectado durante la exportación a PDF y las consecuencias para la selección de texto, la búsqueda y el escalado.

## **Obtener sustituciones de fuentes**

Utilice el método [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) para determinar qué fuentes se sustituirán cuando la presentación se renderice. El método devuelve objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) que identifican los nombres de fuente original y sustituta.

El siguiente ejemplo en Python enumera todas las sustituciones de fuentes para una presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Obtener sustituciones de fuentes para diapositivas seleccionadas**

Utilice la sobrecarga del método [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) con un argumento de matriz de enteros Java para inspeccionar solo las sustituciones necesarias para renderizar diapositivas específicas. Esto es útil cuando está renderizando o exportando una parte de una presentación, comprobando una presentación grande de forma incremental, localizando diapositivas que dependen de fuentes no disponibles, preparando un paquete mínimo de fuentes para un servidor o contenedor, o diagnosticando diferencias de renderizado sin procesar diapositivas no relacionadas.

La matriz `slides` contiene índices de diapositivas basados en 1: `1` identifica la primera diapositiva. En contraste, el accessor de la colección [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) usa indexación basada en 0, de modo que la misma diapositiva se accede como `presentation.getSlides().get_Item(0)`. Tenga presente esta diferencia al crear la matriz para evitar errores de desplazamiento.

Llame a la sobrecarga a través del método [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager). Éste devuelve solo las sustituciones determinadas mientras se renderizan las diapositivas seleccionadas. Cada resultado es un objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) que contiene los nombres de fuente original y sustituta. El resultado refleja el entorno de fuentes actual, las reglas de reserva configuradas, las reglas de sustitución almacenadas en una [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) y [fuentes cargadas externamente](/slides/es/python-java/custom-font/).

La misma sustitución puede ser requerida por más de una diapositiva seleccionada. Desduplicar los resultados cuando cree un inventario de fuentes o un informe de preflight. El siguiente ejemplo informa cada sustitución devuelta y luego crea una lista ordenada de asignaciones de fuentes únicas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

La clase [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) proporciona ambas sobrecargas. Elija una según el alcance de la operación de renderizado:

| Sobrecarga | Usar cuando |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) sin argumentos | Necesite sustituciones para toda la presentación. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) con una matriz de enteros Java | Necesite sustituciones para un rango seleccionado, una comprobación incremental o una exportación parcial. |

## **Establecer reglas de sustitución de fuentes**

Para especificar la fuente que Aspose.Slides debe usar cuando una fuente de origen no esté disponible:

1. Cargue la presentación.  
2. Cree definiciones de fuentes para la fuente de origen y la fuente sustituta.  
3. Cree una [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) con la condición [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).  
4. Añada la regla a una [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/).  
5. Asigne la colección mediante el método [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).  
6. Renderice o convierta la presentación.

El siguiente ejemplo en Python sustituye `Arial` por `SomeRareFont` cuando `SomeRareFont` no está disponible, y luego renderiza la primera diapositiva para verificar el resultado. La fuente sustituta debe estar disponible para Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Para un cambio incondicional en las fuentes utilizadas en toda la presentación, consulte [Reemplazo de fuentes](/slides/es/python-java/font-replacement/).
{{% /alert %}}

## **Limitaciones para fuentes de ecuaciones matemáticas**

Las reglas de sustitución de fuentes forman parte del proceso estándar de selección de fuentes utilizado durante el renderizado y la conversión. Funcionan para texto normal cuando Aspose.Slides puede reemplazar una fuente inaccesible por la fuente disponible especificada en una regla.

Las ecuaciones de Office Math tienen un requisito adicional. Si una ecuación usa **Cambria Math**, Aspose.Slides puede necesitar esa fuente exacta para calcular y renderizar el diseño de la ecuación. Una regla que sustituya otra fuente matemática, como **STIX Two Math**, no puede reemplazar **Cambria Math** para este fin, y el renderizado puede seguir indicando que **Cambria Math** es necesaria.

Para renderizar o convertir dicha presentación, haga que **Cambria Math** esté disponible para Aspose.Slides. Instálela en el sistema operativo o cárguela como una [fuente externa](/slides/es/python-java/custom-font/).

Esta limitación se aplica al diseño de ecuaciones. Las reglas de sustitución descritas anteriormente siguen aplicándose al texto normal de la presentación.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre el reemplazo de fuentes y la sustitución de fuentes?**

[reemplazo de fuentes](/slides/es/python-java/font-replacement/) cambia intencionalmente una fuente por otra en toda la presentación. La sustitución de fuentes selecciona una fuente para la salida renderizada cuando se cumple la condición configurada, como cuando la fuente original no está disponible.

**¿Cuándo se aplican las reglas de sustitución?**

Las reglas participan en la [secuencia de selección de fuentes](/slides/es/python-java/font-selection-sequence/) durante el renderizado y la conversión. Con `WhenInaccessible`, una regla se usa solo cuando Aspose.Slides no puede acceder a la fuente de origen.

**¿Qué ocurre cuando falta una fuente y no hay ninguna regla de sustitución configurada?**

Aspose.Slides selecciona la fuente disponible más cercana según su proceso de selección de fuentes. El resultado depende de las fuentes disponibles en el entorno de tiempo de ejecución.

**¿Puedo cargar fuentes externas para evitar la sustitución?**

Sí. Puede [cargar fuentes externas](/slides/es/python-java/custom-font/) para que Aspose.Slides las use durante el renderizado y la conversión.

**¿Aspose distribuye fuentes con la biblioteca?**

No. Usted es responsable de proporcionar las fuentes y de cumplir con sus licencias.

**¿Pueden los resultados de sustitución diferir entre Windows, Linux y macOS?**

Sí. Las fuentes instaladas y las ubicaciones de búsqueda de fuentes difieren según el sistema operativo, por lo que una fuente disponible en una máquina puede requerir sustitución en otra.

**¿Cómo puedo lograr una selección de fuentes coherente en conversiones por lotes?**

Utilice los mismos archivos y versiones de fuentes en cada máquina o contenedor, [cargue las fuentes externas necesarias](/slides/es/python-java/custom-font/), y [incorpore fuentes](/slides/es/python-java/embedded-font/) cuando la licencia lo permita. También puede llamar a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) antes de la exportación para identificar sustituciones inesperadas.