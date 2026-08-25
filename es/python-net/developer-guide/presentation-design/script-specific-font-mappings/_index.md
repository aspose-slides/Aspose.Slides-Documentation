---
title: Gestionar fuentes de tema específicas de script en Python
linktitle: Fuentes de tema específicas de script
type: docs
weight: 15
url: /es/python-net/script-specific-font-mappings/
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
- Python
- Aspose.Slides
description: "Inspeccionar, añadir, reemplazar y eliminar asignaciones de fuentes específicas de script en los temas de PowerPoint con Aspose.Slides para Python a través de .NET."
---
## **Visión general**

Un tema de presentación puede seleccionar diferentes familias tipográficas para distintos sistemas de escritura. Esto permite que el texto multilingüe que sigue usando fuentes del tema mantenga un esquema tipográfico coordinado mientras emplea fuentes adecuadas para cirílico, árabe, japonés, georgiano, thaana y otros alfabetos.

El [FontScheme](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/fontscheme/) del tema contiene una colección de fuentes principal, normalmente usada para encabezados, y una colección secundaria, normalmente usada para el cuerpo del texto. Además de sus propiedades de fuentes latinas y de Asia Oriental, ambas colecciones exponen asignaciones de etiquetas de sistema de escritura a nombres de familia tipográfica mediante la clase [Fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides/fonts/).

Este artículo muestra cómo inspeccionar y modificar esas asignaciones en el tema maestro de la presentación y verificar que los cambios sobrevivan a un ciclo de guardado y recarga.

## **Comprender las etiquetas de script**

Los métodos de fuente de script usan subtags de script BCP 47 de cuatro letras para identificar sistemas de escritura. Los valores más habituales son:

| Etiqueta de script | Sistema de escritura |
|---|---|
| `Cyrl` | Cirílico |
| `Arab` | Árabe |
| `Hans` | Chino simplificado |
| `Jpan` | Japonés |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Estas asignaciones pertenecen al esquema tipográfico del tema, no a fragmentos de texto individuales. Una presentación puede definir asignaciones distintas para las colecciones principal y secundaria, y puede omitir asignaciones para algunos scripts.

## **Acceder e inspeccionar las asignaciones de fuentes de script**

Utilice [Presentation.master_theme](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/master_theme/) para acceder al tema a nivel de presentación. Las propiedades [FontScheme.major](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/fontscheme/major/) y [FontScheme.minor](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/fontscheme/minor/) devuelven las dos colecciones [Fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides/fonts/).

Llame a [Fonts.get_script_font_map](https://reference.aspose.com/slides/es/python-net/aspose.slides/fonts/get_script_font_map/) para obtener todas las asignaciones de una colección. Para buscar un único sistema de escritura, llame a [Fonts.get_script_font](https://reference.aspose.com/slides/es/python-net/aspose.slides/fonts/get_script_font/) con su etiqueta de script. `get_script_font` devuelve `None` cuando esa colección no define la asignación solicitada.

## **Modificar las asignaciones y verificar la persistencia**

Utilice [Fonts.set_script_font](https://reference.aspose.com/slides/es/python-net/aspose.slides/fonts/set_script_font/) para crear una asignación o sustituir la familia tipográfica actual. Utilice [Fonts.remove_script_font](https://reference.aspose.com/slides/es/python-net/aspose.slides/fonts/remove_script_font/) para eliminar una asignación.

El siguiente ejemplo de extremo a extremo lee todas las asignaciones principales y secundarias existentes, busca la fuente principal japonesa, cambia la fuente principal cirílica, elimina la asignación secundaria de Thaana, guarda la presentación y la vuelve a abrir para verificar ambos cambios. Para que el paso de eliminación sea independiente del tema inicial, el ejemplo crea primero una asignación de Thaana solo cuando no hay ninguna ya definida.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

La verificación utiliza el mismo comportamiento de `None` que una consulta ordinaria: tras guardar la eliminación, `get_script_font("Thaa")` devuelve `None` para la colección secundaria.

## **Distinguir las asignaciones del tema de otras configuraciones de fuentes**

Las asignaciones de tema específicas de script participan en la selección de fuentes, pero resuelven un problema diferente al formato directo del texto, la sustitución y la reserva de fuentes:

| Mecanismo | Propósito | Efecto de cambiar una asignación del tema |
|---|---|---|
| Asignación de fuente del tema específica de script | Selecciona una fuente principal o secundaria del tema para un sistema de escritura. | El texto que sigue usando la fuente del tema correspondiente puede resolverse a la nueva familia asignada. |
| Fuente asignada explícitamente a un fragmento de texto | Fija la familia tipográfica solicitada en ese fragmento en lugar de depender del tema. | El fragmento puede permanecer sin cambios porque su formato directo sobrescribe la elección del tema. |
| Sustitución de fuentes | Reemplaza una fuente solicitada cuando esa fuente no está disponible o cuando se aplica una regla de sustitución. | Actúa después de que se haya solicitado una fuente; no redefine la asignación de script del tema. |
| Reserva de fuentes | Proporciona glifos que la fuente seleccionada no contiene, a menudo para rangos Unicode específicos. | Completa la cobertura de glifos faltantes; no modifica la asignación almacenada en el tema. |

Para obtener más información sobre los dos últimos mecanismos, consulte [Font Substitution](/slides/es/python-net/font-substitution/) y [Fallback Fonts](/slides/es/python-net/fallback-font/).

Cambiar una asignación en [Presentation.master_theme](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/master_theme/) afecta solo al contenido cuyo formato efectivo sigue dependiendo de ese tema. El texto puede, en su lugar, heredar una sustitución de tema de una diapositiva maestra, un diseño o una diapositiva concreta, o usar una fuente asignada explícitamente. Inspeccione esos niveles cuando el resultado visible no siga la asignación a nivel de presentación.

## **Hacer que las fuentes asignadas estén disponibles y validar el resultado**

Una asignación de script almacena un nombre de familia tipográfica; no instala ni carga el archivo de fuente correspondiente. Para una representación y exportación coherentes, cada fuente asignada debe estar instalada en el entorno o suministrada a Aspose.Slides mediante una fuente personalizada como [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsloader/load_external_fonts/) o [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/document_level_font_sources/). Consulte [Custom Fonts](/slides/es/python-net/custom-font/) para conocer las opciones de carga disponibles.

Verificar la asignación guardada confirma solo que la definición del tema se conservó. No prueba que la fuente esté disponible, que contenga todos los glifos requeridos o que produzca el diseño previsto. Renderice texto representativo para cada sistema de escritura requerido en una imagen o PDF y examine la salida. Esto detecta fuentes faltantes, cobertura de glifos incompleta, comportamiento de reserva y cambios de diseño antes de distribuir la presentación. Véase [Convert PowerPoint Presentations](/slides/es/python-net/convert-powerpoint/) para ejemplos de renderizado y exportación.

## **Preguntas frecuentes**

**¿Qué devuelve `get_script_font` cuando un script no está asignado?**

[Fonts.get_script_font](https://reference.aspose.com/slides/es/python-net/aspose.slides/fonts/get_script_font/) devuelve `None` cuando la asignación de script solicitada no está definida en esa colección de fuentes principal o secundaria.

**¿`set_script_font` añade una segunda asignación cuando el script ya existe?**

No. [Fonts.set_script_font](https://reference.aspose.com/slides/es/python-net/aspose.slides/fonts/set_script_font/) crea la asignación cuando falta y reemplaza la familia tipográfica asignada cuando la misma etiqueta de script ya está presente.

**¿Por qué al cambiar una asignación del tema no se modificó algún texto?**

El texto puede tener una fuente asignada explícitamente, heredar un tema diferente mediante una sustitución, o verse afectado por sustitución o reserva durante el renderizado. Una asignación de script a nivel de presentación controla solo el texto cuyo formato efectivo aún hace referencia a esa colección de fuentes del tema.

**¿Es suficiente guardar y volver a abrir para validar la salida multilingüe?**

No. Volver a abrir verifica la persistencia de los datos del tema. Además, renderice texto representativo de cada sistema de escritura requerido para confirmar que las fuentes asignadas están disponibles y contienen los glifos necesarios.