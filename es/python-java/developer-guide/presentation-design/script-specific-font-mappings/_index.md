---
title: Gestionar fuentes temáticas específicas de script en Python mediante Java
linktitle: Fuentes temáticas específicas de script
type: docs
weight: 15
url: /es/python-java/script-specific-font-mappings/
keywords:
- fuente específica de script
- asignación de fuentes del tema
- presentación multilingüe
- sistema de escritura
- fuente cirílica
- fuente árabe
- fuente japonesa
- fuente georgiana
- fuente thaana
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Inspeccionar, agregar, reemplazar y eliminar asignaciones de fuentes específicas de script en los temas de PowerPoint con Aspose.Slides para Python mediante Java."
---
## **Resumen**

Un tema de presentación puede seleccionar distintas familias tipográficas para diferentes sistemas de escritura. Esto permite que el texto multilingüe que aún usa fuentes del tema siga un esquema tipográfico coordinado mientras utiliza fuentes adecuadas para cirílico, árabe, japonés, georgiano, thaana y otros sistemas de escritura.

El [FontScheme](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontscheme/) del tema contiene una colección de fuentes principal, normalmente usada para encabezados, y una colección de fuentes secundaria, normalmente usada para el cuerpo del texto. Además de sus ajustes de fuentes latinas y de Asia Oriental, ambas colecciones exponen asignaciones de etiquetas de sistemas de escritura a nombres de familias tipográficas mediante la clase [Fonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fonts/).

Este artículo muestra cómo inspeccionar y modificar esas asignaciones en el tema maestro de la presentación y comprobar que los cambios perduran tras un ciclo de guardar y volver a cargar.

## **Comprender las etiquetas de script**

Los métodos de fuentes de script utilizan subtags de script BCP 47 de cuatro letras para identificar los sistemas de escritura. Los valores más habituales son:

| Etiqueta de script | Sistema de escritura |
|---|---|
| `Cyrl` | Cirílico |
| `Arab` | Árabe |
| `Hans` | Chino simplificado |
| `Jpan` | Japonés |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Estas asignaciones pertenecen al esquema de fuentes del tema, no a porciones individuales de texto. Una presentación puede definir distintas asignaciones para las colecciones principal y secundaria, y puede omitir asignaciones para algunos scripts.

## **Acceder e inspeccionar las asignaciones de fuentes de script**

Utilice [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getMasterTheme) para acceder al tema a nivel de presentación. Los métodos [FontScheme.getMajor](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontscheme/#getMajor) y [FontScheme.getMinor](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontscheme/#getMinor) devuelven las dos colecciones de [Fonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fonts/).

Llame a [Fonts.getScriptFontMap](https://reference.aspose.com/slides/es/python-java/aspose.slides/fonts/#getScriptFontMap) para obtener todas las asignaciones de una colección. Para buscar un sistema de escritura concreto, llame a [Fonts.getScriptFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/fonts/#getScriptFont) con su etiqueta de script. `getScriptFont` devuelve `None` cuando esa colección no define la asignación solicitada.

## **Modificar asignaciones y comprobar la persistencia**

Utilice [Fonts.setScriptFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/fonts/#setScriptFont) para crear una asignación o reemplazar su familia tipográfica actual. Utilice [Fonts.removeScriptFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/fonts/#removeScriptFont) para eliminar una asignación.

El siguiente ejemplo completo lee todas las asignaciones principales y secundarias existentes, busca la fuente principal japonesa, cambia la fuente principal cirílica, elimina la asignación secundaria de Thaana, guarda la presentación y la vuelve a abrir para verificar ambos cambios. Para que el paso de eliminación sea independiente del tema inicial, el ejemplo crea primero una asignación de Thaana solo cuando no está ya definida.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

La verificación utiliza el mismo comportamiento `None` que una búsqueda ordinaria: tras guardar la eliminación, `getScriptFont("Thaa")` devuelve `None` para la colección secundaria.

## **Distinguir las asignaciones del tema de otras configuraciones de fuentes**

Las asignaciones de tema específicas de script participan en la selección de fuentes, pero resuelven un problema diferente al formato de texto directo, sustitución y fallback:

| Mecanismo | Propósito | Efecto de cambiar una asignación del tema |
|---|---|---|
| Asignación de fuente de tema específica de script | Selecciona una fuente principal o secundaria del tema para un sistema de escritura. | El texto que sigue usando la fuente del tema correspondiente puede resolverse a la nueva familia asignada. |
| Fuente asignada explícitamente a una porción de texto | Fija la familia tipográfica solicitada en esa porción en lugar de depender del tema. | La porción puede permanecer sin cambios porque su formato directo sobrescribe la elección del tema. |
| Sustitución de fuentes | Reemplaza una fuente solicitada cuando esa fuente no está disponible o cuando se aplica una regla de sustitución. | Actúa después de que se ha solicitado una fuente; no redefine la asignación de script del tema. |
| Fallback de fuentes | Proporciona glifos que la fuente seleccionada no contiene, a menudo para rangos Unicode específicos. | Completa la cobertura de glifos faltantes; no cambia la asignación almacenada del tema. |

Para obtener más información sobre los dos últimos mecanismos, consulte [Font Substitution](/slides/es/python-java/font-substitution/) y [Fallback Fonts](/slides/es/python-java/fallback-font/).

Cambiar una asignación en [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getMasterTheme) afecta solo al contenido cuyo formato efectivo sigue dependiendo de ese tema. El texto puede, en su lugar, heredar una sobrescritura de tema de un maestro, diseño o diapositiva, o usar una fuente asignada explícitamente. Inspeccione esos niveles cuando el resultado visible no siga la asignación a nivel de presentación.

## **Poner las fuentes asignadas a disposición y validar el resultado**

Una asignación de script almacena un nombre de familia tipográfica; no instala ni carga el archivo de fuente correspondiente. Para una representación y exportación consistentes, cada fuente asignada debe estar instalada en el entorno o suministrada a Aspose.Slides mediante una fuente personalizada como [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/#loadExternalFonts) o [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Consulte [Custom Fonts](/slides/es/python-java/custom-font/) para conocer las opciones de carga disponibles.

Verificar la asignación guardada confirma solo que la definición del tema se preservó. No prueba que la fuente esté disponible, que contenga todos los glifos necesarios o que produzca el diseño previsto. Renderice texto representativo para cada sistema de escritura requerido en una imagen o PDF y examine el resultado. Esto detecta fuentes faltantes, cobertura de glifos incompleta, comportamiento de fallback y cambios de diseño antes de distribuir la presentación. Vea [Convert PowerPoint Presentations](/slides/es/python-java/convert-powerpoint/) para ejemplos de renderizado y exportación.

## **Preguntas frecuentes**

**¿Qué devuelve `getScriptFont` cuando un script no está asignado?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/fonts/#getScriptFont) devuelve `None` cuando la asignación de script solicitada no está definida en esa colección de fuentes principal o secundaria.

**¿`setScriptFont` añade una segunda asignación cuando el script ya existe?**

No. [Fonts.setScriptFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/fonts/#setScriptFont) crea la asignación cuando falta y reemplaza la familia tipográfica asignada cuando la misma etiqueta de script ya está presente.

**¿Por qué cambiar una asignación del tema no modificó algún texto?**

El texto puede tener una fuente asignada explícitamente, heredar un tema diferente mediante una sobrescritura, o verse afectado por sustitución o fallback durante la renderización. Una asignación de script a nivel de presentación controla solo el texto cuyo formato efectivo sigue refiriéndose a esa colección de fuentes del tema.

**¿Basta con guardar y volver a abrir para validar la salida multilingüe?**

No. Volver a abrir verifica la persistencia de los datos del tema. Además, renderice texto representativo de cada sistema de escritura requerido para confirmar que las fuentes asignadas están disponibles y contienen los glifos necesarios.