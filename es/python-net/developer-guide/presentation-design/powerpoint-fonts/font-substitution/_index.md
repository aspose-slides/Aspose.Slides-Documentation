---
title: Configurar la sustitución de fuentes en presentaciones con Python
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/python-net/font-substitution/
keywords:
- fuente
- fuente de sustitución
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
description: "Habilite la sustitución óptima de fuentes en Aspose.Slides for Python via .NET al convertir presentaciones de PowerPoint y OpenDocument a otros formatos de archivo."
---

Aspose.Slides te permite establecer reglas para fuentes que determinan lo que debe hacerse en ciertas condiciones (por ejemplo, cuando no se puede acceder a una fuente) de la siguiente manera:

1. Carga la presentación relevante.
2. Carga la fuente que será reemplazada.
3. Carga la nueva fuente.
4. Agrega una regla para el reemplazo.
5. Agrega la regla a la colección de reglas de reemplazo de fuentes de la presentación.
6. Genera la imagen de la diapositiva para observar el efecto.

Este código en Python demuestra el proceso de sustitución de fuentes:

```python
import aspose.slides as slides

# Carga una presentación
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Carga la fuente de origen que será reemplazada
    sourceFont = slides.FontData("SomeRareFont")

    # Carga la nueva fuente
    destFont = slides.FontData("Arial")

    # Agrega una regla de fuente para la sustitución de fuentes
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Agrega la regla a la colección de reglas de sustitución de fuentes
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Agrega la colección de reglas de fuentes a la lista de reglas
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # La fuente Arial se usará en lugar de SomeRareFont cuando esta última sea inaccesible
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Guarda la imagen en el disco en formato JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTA"  color="warning"   %}} 

Es posible que desees ver [**Reemplazo de Fuentes**](/slides/es/python-net/font-replacement/). 

{{% /alert %}}