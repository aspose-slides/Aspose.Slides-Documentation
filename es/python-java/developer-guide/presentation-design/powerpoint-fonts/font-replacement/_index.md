---
title: Optimizar el reemplazo de fuentes en presentaciones usando Python vía Java
linktitle: Reemplazo de fuentes
type: docs
weight: 60
url: /es/python-java/font-replacement/
keywords:
- fuente
- reemplazar fuente
- sustitución de fuentes
- cambiar fuente
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Reemplace fuentes de forma fluida en Aspose.Slides para Python vía Java y garantice una tipografía coherente en presentaciones PowerPoint y OpenDocument."
---
## **Visión general**

Aspose.Slides le permite reemplazar una fuente por otra en toda la presentación. Cuando se sustituye una fuente, todas las apariciones de la fuente original se cambian a la nueva fuente.

Para realizar el reemplazo de fuentes, cargue la presentación, defina la fuente original y la fuente de sustitución, llame al método de reemplazo de fuentes y guarde la presentación modificada como archivo PPTX. Este enfoque es útil cuando se desea cambiar intencionalmente de una familia tipográfica a otra en toda la presentación.

## **Reemplazar fuentes**

Si cambia de opinión sobre el uso de una fuente, puede reemplazar esa fuente por otra. Todas las apariciones de la fuente antigua serán sustituidas por la nueva.

Aspose.Slides permite reemplazar una fuente de la siguiente manera:

1. Cargue la presentación correspondiente.  
2. Cargue la fuente que será reemplazada.  
3. Cargue la nueva fuente.  
4. Reemplace la fuente.  
5. Guarde la presentación modificada como archivo PPTX.

Este código Python muestra el reemplazo de fuentes:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# Cargar una presentación.
presentation = Presentation("Fonts.pptx")
try:
    # Cargar la fuente origen que será reemplazada.
    source_font = FontData("Arial")

    # Cargar la nueva fuente.
    destination_font = FontData("Times New Roman")

    # Reemplazar la fuente.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # Guardar la presentación.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}} 
Para establecer reglas que determinen qué ocurre en determinadas condiciones (por ejemplo, si una fuente no se puede acceder), consulte [Font Substitution](/slides/es/python-java/font-substitution/). 
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre “reemplazo de fuentes”, “sustitución de fuentes” y “fuentes de respaldo”?**

El reemplazo es un cambio intencional de una familia tipográfica a otra en todo el documento. [Substitution](/slides/es/python-java/font-substitution/) es una regla del tipo “si la fuente no está disponible, usar X”. [Fallback](/slides/es/python-java/fallback-font/) se aplica a glifos individuales que faltan cuando la fuente base está instalada pero no contiene los caracteres requeridos.

**¿El reemplazo se aplica a diapositivas maestras, diseños, notas y comentarios?**

Sí. El reemplazo afecta a todos los objetos de la presentación que usan la fuente original, incluidas las diapositivas maestras y las notas; los comentarios también forman parte del documento y son tenidos en cuenta por el motor de fuentes.

**¿Cambiará la fuente dentro de objetos OLE incrustados (por ejemplo, Excel)?**

No. El [OLE content](/slides/es/python-java/manage-ole/) está controlado por su propia aplicación. El reemplazo en la presentación no reformatea los datos internos de OLE; pueden mostrarse como una imagen o como contenido editable externamente.

**¿Puedo reemplazar una fuente solo en una parte de la presentación (por diapositivas o regiones)?**

El reemplazo selectivo es posible si se cambia la fuente a nivel de los objetos/rangos requeridos en lugar de aplicar un reemplazo global a todo el documento. La lógica general de selección de fuentes durante el renderizado sigue siendo la misma.

**¿Cómo puedo determinar con antelación qué fuentes usa la presentación?**

Utilice el [font manager]​(https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/) de la presentación: proporciona una lista de las [familias en uso]​(https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#getFonts) e información sobre [sustituciones/"fuentes desconocidas"]​(https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#getSubstitutions), lo que ayuda a planificar el reemplazo.

**¿Funciona el reemplazo de fuentes al convertir a PDF/imágenes?**

Sí. Durante la exportación, Aspose.Slides aplica la misma [secuencia de selección/sustitución de fuentes](/slides/es/python-java/font-selection-sequence/), por lo que un reemplazo realizado previamente será respetado durante la conversión.

**¿Es necesario instalar la fuente objetivo en el sistema o puedo adjuntar una carpeta de fuentes?**

No es necesario instalarla: la biblioteca permite [cargar fuentes externas](/slides/es/python-java/custom-font/) desde carpetas del usuario para su uso durante el [renderizado y la exportación](/slides/es/python-java/convert-powerpoint/).

**¿El reemplazo corregirá los “tofu” (cuadrados) en lugar de los caracteres?**

Solo si la fuente objetivo realmente contiene los glifos requeridos. De lo contrario, [configure fallback](/slides/es/python-java/fallback-font/) para cubrir los caracteres que faltan.