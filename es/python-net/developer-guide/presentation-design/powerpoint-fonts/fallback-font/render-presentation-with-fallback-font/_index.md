---
title: Renderizar Presentación con Fuente de Alternativa
type: docs
weight: 30
url: /es/python-net/render-presentation-with-fallback-font/
keywords: "Fuente de alternativa, renderizar PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Renderizar PowerPoint con fuente de alternativa en Python"
---

El siguiente ejemplo incluye estos pasos:

1. [Creamos colección de reglas de fuente de alternativa](/slides/es/python-net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) una regla de fuente de alternativa y [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) a otra regla.
1. Establecer la colección de reglas en la propiedad [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/).
1. Con el método [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) podemos guardar la presentación en el mismo formato, o guardarla en otro. Después de que la colección de reglas de fuente de alternativa esté establecida en FontsManager, estas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.

```py
import aspose.slides as slides

# Crear nueva instancia de una colección de reglas
rulesList = slides.FontFallBackRulesCollection()

# crear un número de reglas
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	#Intentando eliminar la fuente de alternativa "Tahoma" de las reglas cargadas
	fallBackRule.remove("Tahoma")

	#Y actualizar las reglas para el rango especificado
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

#También podemos eliminar cualquier regla existente de la lista
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	#Asignando una lista de reglas preparadas para usar
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Renderizando la miniatura utilizando la colección de reglas inicializada y guardando en PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Lee más sobre [Guardar y Conversión en Presentación](/slides/es/python-net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}