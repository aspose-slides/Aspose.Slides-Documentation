---
title: Configurar fuentes de reserva en Python
linktitle: Configurar fuentes de reserva
type: docs
weight: 20
url: /es/python-net/create-fallback-fonts-collection/
keywords:
- fuente de reserva
- regla de reserva
- colección de fuentes
- configurar fuente
- establecer fuente
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Configure una colección de fuentes de reserva en Aspose.Slides para Python vía .NET para mantener el texto coherente y nítido en presentaciones de PowerPoint y OpenDocument."
---

## **Aplicar reglas de reserva**

Las instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) pueden organizarse en [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/), que implementa la interfaz [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/). Es posible agregar o eliminar reglas de la colección.

Luego esta colección puede asignarse a la propiedad [FontFallBackRulesCollection ](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) de la clase [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). FontsManager controla las fuentes en toda la presentación. Lea más [Acerca de FontsManager y FontsLoader](/slides/es/python-net/about-fontsmanager-and-fontsloader/).

Cada [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) tiene una propiedad [FontsManager ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) con su propia instancia de la clase FontsManager.

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
Lea más cómo [Renderizar presentación con fuente de sustitución](/slides/es/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se incrustarán mis reglas de sustitución en el archivo PPTX y serán visibles en PowerPoint después de guardar?**

No. Las reglas de sustitución son configuraciones de renderizado en tiempo de ejecución; no se serializan en el PPTX y no aparecerán en la interfaz de PowerPoint.

**¿Se aplica la sustitución al texto dentro de SmartArt, WordArt, gráficos y tablas?**

Sí. Se utiliza el mismo mecanismo de sustitución de glifos para cualquier texto en estos objetos.

**¿Distribuye Aspose alguna fuente con la biblioteca?**

No. Usted agrega y usa fuentes por su cuenta y bajo su propia responsabilidad.

**¿Se pueden usar juntos el reemplazo/sustitución de fuentes faltantes y la sustitución para glifos faltantes?**

Sí. Son etapas independientes del mismo pipeline de resolución de fuentes: primero el motor resuelve la disponibilidad de fuentes ([replacement](/slides/es/python-net/font-replacement/)/[substitution](/slides/es/python-net/font-substitution/)), luego la sustitución rellena los vacíos de glifos faltantes en las fuentes disponibles.