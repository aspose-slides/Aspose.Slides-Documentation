---
title: Configurar sustitución de fuentes en presentaciones con Python
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/python-net/font-substitution/
keywords:
- fuente
- sustituir fuente
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
description: "Habilite la sustitución óptima de fuentes en Aspose.Slides para Python mediante .NET al convertir presentaciones de PowerPoint y OpenDocument a otros formatos de archivo."
---

## **Establecer reglas de sustitución**

Aspose.Slides le permite establecer reglas para fuentes que determinan qué debe hacerse en ciertas condiciones (por ejemplo, cuando una fuente no se puede acceder) de esta manera:

1. Cargue la presentación pertinente.
2. Cargue la fuente que será reemplazada.
3. Cargue la nueva fuente.
4. Añada una regla para el reemplazo.
5. Añada la regla a la colección de reglas de reemplazo de fuentes de la presentación.
6. Genere la imagen de la diapositiva para observar el efecto.

Este código Python muestra el proceso de sustitución de fuentes:

```python
import aspose.slides as slides

# Carga una presentación
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Carga la fuente origen que será reemplazada
    sourceFont = slides.FontData("SomeRareFont")

    # Carga la nueva fuente
    destFont = slides.FontData("Arial")

    # Añade una regla de fuente para el reemplazo de fuente
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Añade la regla a la colección de reglas de sustitución de fuentes
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Asigna la colección de reglas de fuentes a la lista de reglas
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # La fuente Arial se usará en lugar de SomeRareFont cuando esta última sea inaccesible
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Guarda la imagen en disco en formato JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTA"  color="warning"   %}} 
Es posible que desee ver [**Reemplazo de fuentes**](/slides/es/python-net/font-replacement/). 
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre el reemplazo de fuentes y la sustitución de fuentes?**

[Reemplazo](/slides/es/python-net/font-replacement/) es una sobrescritura forzada de una fuente por otra en toda la presentación. La sustitución es una regla que se activa bajo una condición específica, por ejemplo cuando la fuente original no está disponible, y entonces se utiliza una fuente de respaldo designada.

**¿Cuándo se aplican exactamente las reglas de sustitución?**

Las reglas participan en la secuencia estándar de [selección de fuentes](/slides/es/python-net/font-selection-sequence/) que se evalúa durante la carga, el renderizado y la conversión; si la fuente elegida no está disponible, se aplica el reemplazo o la sustitución.

**¿Cuál es el comportamiento predeterminado si ni el reemplazo ni la sustitución están configurados y la fuente falta en el sistema?**

La biblioteca intentará escoger la fuente del sistema disponible más cercana, similar al comportamiento de PowerPoint.

**¿Puedo adjuntar fuentes externas personalizadas en tiempo de ejecución para evitar la sustitución?**

Sí. Puede [añadir fuentes externas](/slides/es/python-net/custom-font/) en tiempo de ejecución para que la biblioteca las considere en la selección y el renderizado, incluidas conversiones posteriores.

**¿Aspose distribuye alguna fuente con la biblioteca?**

No. Aspose no distribuye fuentes pagas ni gratuitas; usted añade y usa fuentes bajo su propio criterio y responsabilidad.

**¿Existen diferencias en el comportamiento de sustitución en Windows, Linux y macOS?**

Sí. El descubrimiento de fuentes comienza en los directorios de fuentes del sistema operativo. El conjunto de fuentes predeterminadas disponibles y las rutas de búsqueda difieren entre plataformas, lo que afecta la disponibilidad y la necesidad de sustitución.

**¿Cómo debo preparar el entorno para minimizar sustituciones inesperadas durante conversiones por lotes?**

Sincronice el conjunto de fuentes entre máquinas o contenedores, [añada las fuentes externas](/slides/es/python-net/custom-font/) requeridas para los documentos de salida, y [incorpore fuentes](/slides/es/python-net/embedded-font/) en las presentaciones cuando sea posible para que las fuentes elegidas estén disponibles durante el renderizado.