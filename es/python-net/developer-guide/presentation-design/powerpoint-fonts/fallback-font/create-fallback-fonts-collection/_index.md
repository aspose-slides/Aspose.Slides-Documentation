---
title: Crear Colección de Fuentes de Respaldo
type: docs
weight: 20
url: /python-net/create-fallback-fonts-collection/
keywords: "Colección de fuentes de respaldo, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Colección de fuentes de respaldo en PowerPoint en Python"
---

Las instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) se pueden organizar en [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/), que implementa la interfaz [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/). Es posible agregar o eliminar reglas de la colección.

Luego, esta colección se puede asignar a la propiedad [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) de la clase [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). FontsManager controla las fuentes a través de la presentación. Lea más [Acerca de FontsManager y FontsLoader](/slides/python-net/about-fontsmanager-and-fontsloader/).

Cada [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) tiene una propiedad [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) con su propia instancia de la clase FontsManager.

Aquí hay un ejemplo de cómo crear una colección de reglas de fuentes de respaldo y asignarla al FontsManager de una presentación determinada:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

Después de que FontsManager se inicializa con la colección de fuentes de respaldo, las fuentes de respaldo se aplican durante el renderizado de la presentación.

{{% alert color="primary" %}} 
Lea más sobre cómo [Renderizar Presentación con Fuente de Respaldo](/slides/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}