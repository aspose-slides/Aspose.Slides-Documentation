---
title: Reemplazo de Fuentes
type: docs
weight: 60
url: /es/python-net/font-replacement/
keywords: "Fuente, reemplazar fuente, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Reemplazar fuentes explícitamente en PowerPoint en Python"
---

Si cambias de opinión sobre el uso de una fuente, puedes reemplazar esa fuente por otra fuente. Todas las instancias de la fuente antigua serán reemplazadas por la nueva fuente.

Aspose.Slides te permite reemplazar una fuente de esta manera:

1. Carga la presentación relevante.
2. Carga la fuente que será reemplazada.
3. Carga la nueva fuente.
4. Reemplaza la fuente.
5. Escribe la presentación modificada como un archivo PPTX.

Este código en Python demuestra el reemplazo de fuente:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Carga una presentación
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Carga la fuente de origen que será reemplazada
    sourceFont = slides.FontData("Arial")

    # Carga la nueva fuente
    destFont = slides.FontData("Times New Roman")

    # Reemplaza las fuentes
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Guarda la presentación
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Nota" color="warning" %}} 

Para establecer reglas que determinen lo que sucede en ciertas condiciones (si no se puede acceder a una fuente, por ejemplo), consulta [**Sustitución de Fuentes**](/slides/es/python-net/font-substitution/). 

{{% /alert %}}