---
title: Renderizar Presentación con Fuente de Respaldo
type: docs
weight: 30
url: /net/render-presentation-with-fallback-font/
keywords: 
- fuente de respaldo
- renderizar PowerPoint
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides para .NET
description: "Renderizar PowerPoint con fuente de respaldo en C# o .NET"
---

El siguiente ejemplo incluye estos pasos:

1. [Creamos una colección de reglas de fuente de respaldo](/slides/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) una regla de fuente de respaldo y [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) a otra regla.
1. Establecer la colección de reglas a la propiedad [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Con el método [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) podemos guardar la presentación en el mismo formato o guardarla en otro. Después de que la colección de reglas de fuente de respaldo se establece en FontsManager, estas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.

```c#
// Crear nueva instancia de una colección de reglas
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// crear un número de reglas
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Intentando eliminar la fuente de respaldo "Tahoma" de las reglas cargadas
	fallBackRule.Remove("Tahoma");

	//Y actualizar las reglas para el rango especificado
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

//También podemos eliminar cualquier regla existente de la lista
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Asignando una lista de reglas preparadas para usar
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Renderización de miniatura utilizando la colección de reglas inicializada y guardándola en PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
Lee más sobre [Guardar y Conversión en Presentación](/slides/net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}