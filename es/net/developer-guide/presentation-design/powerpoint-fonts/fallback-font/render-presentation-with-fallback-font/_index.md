---
title: Renderizar presentaciones con fuentes de reserva en .NET
linktitle: Renderizar presentaciones
type: docs
weight: 30
url: /es/net/render-presentation-with-fallback-font/
keywords:
- fuente de reserva
- renderizar PowerPoint
- renderizar presentación
- renderizar diapositiva
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Renderiza presentaciones con fuentes de reserva en Aspose.Slides para .NET – mantiene el texto coherente en PPT, PPTX y ODP con ejemplos de código C# paso a paso."
---

El siguiente ejemplo incluye estos pasos:

1. Creamos una [creamos una colección de reglas de fuentes de reserva](/slides/es/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) una regla de fuente de reserva y [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) a otra regla.
1. Establecemos la colección de reglas en la propiedad [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Con el método [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) podemos guardar la presentación en el mismo formato o guardarla en otro. Después de que la colección de reglas de fuentes de reserva se establece en FontsManager, estas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.
```c#
// Crear una nueva instancia de una colección de reglas
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// Crear varias reglas
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
 //rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Intentar eliminar la fuente de reserva "Tahoma" de las reglas cargadas
	fallBackRule.Remove("Tahoma");

	// Y actualizar las reglas para el rango especificado
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// También podemos eliminar cualquier regla existente de la lista
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Asignar una lista de reglas preparada para usar
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Renderizar una miniatura usando la colección de reglas inicializada y guardarla como PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```



{{% alert color="primary" %}} 
Obtenga más información sobre [Guardar y Conversión en la Presentación](/slides/es/net/convert-powerpoint-to-png/).
{{% /alert %}}