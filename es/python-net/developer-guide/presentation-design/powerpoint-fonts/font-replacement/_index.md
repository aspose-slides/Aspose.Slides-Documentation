---
title: Optimizar el reemplazo de fuentes en presentaciones usando Python
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
description: "Reemplace fuentes de forma fluida en Aspose.Slides para Python a través de .NET para garantizar una tipografía coherente en presentaciones de PowerPoint y OpenDocument."
---

## **Reemplazar fuentes**

Si cambias de opinión sobre el uso de una fuente, puedes reemplazar esa fuente por otra. Todas las instancias de la fuente antigua serán sustituidas por la nueva.

Aspose.Slides te permite reemplazar una fuente de la siguiente manera:

1. Cargar la presentación correspondiente. 
2. Cargar la fuente que será reemplazada. 
3. Cargar la nueva fuente. 
4. Reemplazar la fuente. 
5. Guardar la presentación modificada como archivo PPTX. 

Este código Python demuestra el reemplazo de fuentes:

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

{{% alert title="Nota" color="warning" %}} 

Para establecer reglas que determinen qué ocurre en ciertas condiciones (por ejemplo, si una fuente no se puede acceder), consulta [**Sustitución de fuentes**](/slides/es/python-net/font-substitution/). 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre "reemplazo de fuentes", "sustitución de fuentes" y "fuentes de reserva"?**

El reemplazo es un cambio intencional de una familia a otra en todo el documento. [Sustitución](/slides/es/python-net/font-substitution/) es una regla como "si la fuente no está disponible, usar X". [Fuentes de reserva](/slides/es/python-net/fallback-font/) se aplican de manera puntual para glifos faltantes individuales cuando la fuente base está instalada pero no contiene los caracteres requeridos.

**¿El reemplazo se aplica a diapositivas maestras, diseños, notas y comentarios?**

Sí. El reemplazo afecta a todos los objetos de la presentación que utilizan la fuente original, incluidas las diapositivas maestras y las notas; los comentarios también forman parte del documento y son tenidos en cuenta por el motor de fuentes.

**¿Cambiará la fuente dentro de objetos OLE incrustados (por ejemplo, Excel)?**

No. El [contenido OLE](/slides/es/python-net/manage-ole/) está controlado por su propia aplicación. El reemplazo en la presentación no reformatea los datos internos de OLE; pueden mostrarse como una imagen o como contenido editable externamente.

**¿Puedo reemplazar una fuente solo en una parte de la presentación (por diapositivas o regiones)?**

El reemplazo dirigido es posible si cambias la fuente a nivel de los objetos/rangos requeridos en lugar de aplicar un reemplazo global a todo el documento. La lógica general de selección de fuentes durante el renderizado permanece igual.

**¿Cómo puedo determinar de antemano qué fuentes utiliza la presentación?**

Utiliza el [administrador de fuentes](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/): proporciona una lista de las [familias en uso](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) e información sobre [sustituciones/"fuentes desconocidas"](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/), lo que ayuda a planificar el reemplazo.

**¿El reemplazo de fuentes funciona al convertir a PDF/imagenes?**

Sí. Durante la exportación, Aspose.Slides aplica la misma [secuencia de selección/sustitución de fuentes](/slides/es/python-net/font-selection-sequence/), por lo que un reemplazo realizado previamente será respetado durante la conversión.

**¿Necesito instalar la fuente objetivo en el sistema, o puedo adjuntar una carpeta de fuentes?**

No se requiere instalación: la biblioteca permite [cargar fuentes externas](/slides/es/python-net/custom-font/) desde carpetas de usuario para su uso durante el [renderizado y exportación](/slides/es/python-net/convert-powerpoint/).

**¿El reemplazo corregirá el "tofu" (cuadrados) en lugar de los caracteres?**

Solo si la fuente objetivo realmente contiene los glifos requeridos. En caso contrario, [configura fuentes de reserva](/slides/es/python-net/fallback-font/) para cubrir los caracteres faltantes.