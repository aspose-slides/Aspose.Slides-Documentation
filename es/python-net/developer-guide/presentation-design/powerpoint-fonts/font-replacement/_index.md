---
title: Optimizar el reemplazo de fuentes en presentaciones usando Python
linktitle: Reemplazo de fuentes
type: docs
weight: 60
url: /es/python-net/font-replacement/
keywords:
- fuente
- reemplazar fuente
- sustitución de fuentes
- cambiar fuente
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Reemplace fuentes sin problemas en Aspose.Slides Python via .NET para garantizar una tipografía coherente en presentaciones PowerPoint y OpenDocument."
---

## **Reemplazar fuentes**

Si cambias de opinión sobre el uso de una fuente, puedes reemplazar esa fuente por otra. Todas las instancias de la fuente antigua serán sustituidas por la nueva.

Aspose.Slides permite reemplazar una fuente de esta manera:

1. Carga la presentación correspondiente.  
2. Carga la fuente que será reemplazada.  
3. Carga la nueva fuente.  
4. Reemplaza la fuente.  
5. Guarda la presentación modificada como archivo PPTX.

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

Para establecer reglas que determinen qué ocurre en ciertas condiciones (por ejemplo, si no se puede acceder a una fuente), consulta **[Sustitución de fuentes](/slides/es/python-net/font-substitution/)**. 

{{% /alert %}}

## **FAQ**

**¿Cuál es la diferencia entre “reemplazo de fuentes”, “sustitución de fuentes” y “fuentes de respaldo”?**

El reemplazo es un cambio intencional de una familia a otra en todo el documento. **[Sustitución](/slides/es/python-net/font-substitution/)** es una regla como “si la fuente no está disponible, usar X”. **[Fuente de respaldo](/slides/es/python-net/fallback-font/)** se aplica de forma puntual a glifos faltantes cuando la fuente base está instalada pero no contiene los caracteres requeridos.

**¿El reemplazo se aplica a las diapositivas maestras, diseños, notas y comentarios?**

Sí. El reemplazo afecta a todos los objetos de la presentación que usan la fuente original, incluidas las diapositivas maestras y las notas; los comentarios también forman parte del documento y son tenidos en cuenta por el motor de fuentes.

**¿Cambiará la fuente dentro de objetos OLE incrustados (por ejemplo, Excel)?**

No. El **[contenido OLE](/slides/es/python-net/manage-ole/)** está controlado por su propia aplicación. El reemplazo en la presentación no reformatea los datos internos de OLE; pueden mostrarse como una imagen o como contenido editable externamente.

**¿Puedo reemplazar una fuente solo en una parte de la presentación (por diapositivas o regiones)?**

El reemplazo dirigido es posible si cambias la fuente a nivel de los objetos/rangos requeridos en lugar de aplicar un reemplazo global a todo el documento. La lógica de selección de fuentes durante el renderizado sigue siendo la misma.

**¿Cómo puedo determinar de antemano qué fuentes usa la presentación?**

Utiliza el **[administrador de fuentes]**(https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) de la presentación: proporciona una lista de las **[familias en uso]**(https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) e información sobre **[sustituciones/"fuentes desconocidas"]**(https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/), lo que ayuda a planificar el reemplazo.

**¿Funciona el reemplazo de fuentes al convertir a PDF/imágenes?**

Sí. Durante la exportación, Aspose.Slides aplica la misma **[secuencia de selección/sustitución de fuentes](/slides/es/python-net/font-selection-sequence/)**, por lo que un reemplazo realizado con anticipación será respetado durante la conversión.

**¿Necesito instalar la fuente de destino en el sistema o puedo adjuntar una carpeta de fuentes?**

No es necesario instalarla: la biblioteca permite **[cargar fuentes externas](/slides/es/python-net/custom-font/)** desde carpetas de usuario para su uso durante **[renderizado y exportación](/slides/es/python-net/convert-powerpoint/)**.

**¿El reemplazo solucionará los “tofu” (cuadrados) en lugar de caracteres?**

Solo si la fuente de destino realmente contiene los glifos requeridos. De lo contrario, **[configura una fuente de respaldo](/slides/es/python-net/fallback-font/)** para cubrir los caracteres faltantes.