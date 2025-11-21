---
title: Simplificar el reemplazo de fuentes en presentaciones usando Python
linktitle: Reemplazo de fuentes
type: docs
weight: 60
url: /es/python-net/font-replacement/
keywords:
- fuente
- reemplazar fuente
- reemplazo de fuentes
- cambiar fuente
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Reemplace fuentes sin problemas en Aspose.Slides Python a través de .NET para garantizar una tipografía coherente en presentaciones PowerPoint y OpenDocument."
---

## **Reemplazar fuentes**

Si cambias de opinión acerca de usar una fuente, puedes reemplazar esa fuente por otra. Todas las instancias de la fuente antigua serán sustituidas por la nueva.

Aspose.Slides permite reemplazar una fuente de la siguiente manera:

1. Carga la presentación correspondiente. 
2. Carga la fuente que será reemplazada. 
3. Carga la nueva fuente. 
4. Reemplaza la fuente. 
5. Guarda la presentación modificada como un archivo PPTX.

Este código Python muestra la sustitución de fuentes:
```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Carga una presentación
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Carga la fuente origen que será reemplazada
    sourceFont = slides.FontData("Arial")

    # Carga la nueva fuente
    destFont = slides.FontData("Times New Roman")

    # Reemplaza las fuentes
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Guarda la presentación
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Note" color="warning" %}} 

Para establecer reglas que determinen qué ocurre en ciertas condiciones (por ejemplo, si no se puede acceder a una fuente), consulta [**Sustitución de fuentes**](/slides/es/python-net/font-substitution/). 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre "reemplazo de fuentes", "sustitución de fuentes" y "fuentes de respaldo"?**

El reemplazo es un cambio intencional de una familia a otra en todo el documento. La [Sustitución](/slides/es/python-net/font-substitution/) es una regla del tipo "si la fuente no está disponible, usar X". El [Respaldo](/slides/es/python-net/fallback-font/) se aplica de forma puntual para glifos ausentes cuando la fuente base está instalada pero no contiene los caracteres requeridos.

**¿El reemplazo se aplica a diapositivas maestras, diseños, notas y comentarios?**

Sí. El reemplazo afecta a todos los objetos de la presentación que utilizan la fuente original, incluidas las diapositivas maestras y las notas; los comentarios también forman parte del documento y son tenidos en cuenta por el motor de fuentes.

**¿Cambiará la fuente dentro de objetos OLE incrustados (por ejemplo, Excel)?**

No. El [contenido OLE](/slides/es/python-net/manage-ole/) está controlado por su propia aplicación. El reemplazo en la presentación no reformatea los datos internos de OLE; pueden mostrarse como una imagen o como contenido editable externamente.

**¿Puedo reemplazar una fuente solo en una parte de la presentación (por diapositivas o regiones)?**

El reemplazo dirigido es posible si cambias la fuente a nivel de los objetos/rangos necesarios en lugar de aplicar un reemplazo global a todo el documento. La lógica general de selección de fuentes durante el renderizado permanece igual.

**¿Cómo puedo determinar de antemano qué fuentes usa la presentación?**

Utiliza el [administrador de fuentes](/slides/es/python-net/aspose.slides/fontsmanager/) de la presentación: proporciona una lista de las [familias en uso](/slides/es/python-net/aspose.slides/fontsmanager/get_fonts/) e información sobre [sustituciones/"fuentes desconocidas"](/slides/es/python-net/aspose.slides/fontsmanager/get_substitutions/), lo que ayuda a planificar el reemplazo.

**¿Funciona el reemplazo de fuentes al convertir a PDF/imágenes?**

Sí. Durante la exportación, Aspose.Slides aplica la misma [secuencia de selección/sustitución de fuentes](/slides/es/python-net/font-selection-sequence/), por lo que un reemplazo realizado previamente será respetado durante la conversión.

**¿Necesito instalar la fuente objetivo en el sistema o puedo adjuntar una carpeta de fuentes?**

No es necesario instalarla: la biblioteca permite [cargar fuentes externas](/slides/es/python-net/custom-font/) desde carpetas de usuario para usarlas durante el [renderizado y la exportación](/slides/es/python-net/convert-powerpoint/).

**¿El reemplazo corregirá los “tofu” (cuadrados) en lugar de los caracteres?**

Solo si la fuente objetivo realmente contiene los glifos requeridos. De lo contrario, [configure el respaldo](/slides/es/python-net/fallback-font/) para cubrir los caracteres ausentes.