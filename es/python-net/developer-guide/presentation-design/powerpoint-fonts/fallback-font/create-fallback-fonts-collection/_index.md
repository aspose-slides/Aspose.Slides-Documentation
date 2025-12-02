---
title: Configurar colecciones de fuentes de sustitución en Python
linktitle: Colección de fuentes de sustitución
type: docs
weight: 20
url: /es/python-net/create-fallback-fonts-collection/
keywords:
- fuente de sustitución
- regla de sustitución
- colección de fuentes
- configurar fuente
- establecer fuente
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Configure una colección de fuentes de sustitución en Aspose.Slides para Python a través de .NET para mantener el texto consistente y nítido en presentaciones de PowerPoint y OpenDocument."
---

## **Aplicar reglas de sustitución de fuentes**

Las instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) pueden organizarse en la [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/), que implementa la interfaz [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/). Es posible agregar o eliminar reglas de la colección.

Luego, esta colección puede asignarse a la propiedad [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) de la clase [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). FontsManager controla las fuentes en toda la presentación. Lea más sobre [About FontsManager and FontsLoader](/slides/es/python-net/about-fontsmanager-and-fontsloader/).

Cada [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) tiene una propiedad [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) con su propia instancia de la clase FontsManager.

A continuación se muestra un ejemplo de cómo crear una colección de reglas de fuentes de sustitución y asignarla al FontsManager de una presentación determinada:  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


Después de que FontsManager se inicializa con la colección de fuentes de sustitución, las fuentes de sustitución se aplican durante la renderización de la presentación.

{{% alert color="primary" %}} 
Lea más sobre cómo [Render Presentation with Fallback Font](/slides/es/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se incrustarán mis reglas de sustitución en el archivo PPTX y serán visibles en PowerPoint después de guardar?**

No. Las reglas de sustitución son configuraciones de renderizado en tiempo de ejecución; no se serializan en el PPTX y no aparecerán en la interfaz de PowerPoint.

**¿La sustitución se aplica al texto dentro de SmartArt, WordArt, gráficos y tablas?**

Sí. Se utiliza el mismo mecanismo de sustitución de glifos para cualquier texto en esos objetos.

**¿Aspose distribuye fuentes con la biblioteca?**

No. Usted añade y usa fuentes por su cuenta y bajo su propia responsabilidad.

**¿Se pueden usar conjuntamente la sustitución/reemplazo de fuentes faltantes y la sustitución de glifos faltantes?**

Sí. Son etapas independientes del mismo proceso de resolución de fuentes: primero el motor resuelve la disponibilidad de fuentes ([replacement](/slides/es/python-net/font-replacement/)/[substitution](/slides/es/python-net/font-substitution/)), luego la sustitución cubre los glifos faltantes en las fuentes disponibles.