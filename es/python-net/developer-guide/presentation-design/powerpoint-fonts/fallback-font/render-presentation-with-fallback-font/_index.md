---
title: Renderizar presentaciones con fuentes de reserva en Python
linktitle: Renderizar presentaciones
type: docs
weight: 30
url: /es/python-net/render-presentation-with-fallback-font/
keywords:
- fuente de reserva
- renderizar PowerPoint
- renderizar presentación
- renderizar diapositiva
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Renderiza presentaciones con fuentes de reserva en Aspose.Slides para Python mediante .NET – mantiene el texto coherente en PPT, PPTX y ODP con ejemplos de código paso a paso."
---

El siguiente ejemplo incluye estos pasos:

1. Creamos [crear colección de reglas de fuentes de reserva](/slides/es/python-net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) una regla de fuente de reserva y [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) a otra regla.
1. Establecemos la colección de reglas en la propiedad [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/).
1. Con el método [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) podemos guardar la presentación en el mismo formato o guardarla en otro. Después de que la colección de reglas de fuentes de reserva se asigna a FontsManager, estas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.
```py
import aspose.slides as slides

# Crear una nueva instancia de una colección de reglas
rulesList = slides.FontFallBackRulesCollection()

# Crear un número de reglas
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Intentar eliminar la fuente de reserva "Tahoma" de las reglas cargadas
	fallBackRule.remove("Tahoma")

	# Y actualizar las reglas para el rango especificado
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# También podemos eliminar cualquier regla existente de la lista
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Asignar una lista de reglas preparada para su uso
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Renderizar una miniatura utilizando la colección de reglas inicializada y guardarla en PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```



{{% alert color="primary" %}} 
Obtén más información sobre cómo [Convertir diapositivas de PowerPoint a PNG en Python](/slides/es/python-net/convert-powerpoint-to-png/).
{{% /alert %}}