---
title: Renderizar presentaciones con fuentes de respaldo en .NET
linktitle: Renderizar presentaciones
type: docs
weight: 30
url: /es/net/render-presentation-with-fallback-font/
keywords:
- fuente de respaldo
- renderizar PowerPoint
- renderizar presentación
- renderizar diapositiva
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Renderizar presentaciones con fuentes de respaldo en Aspose.Slides para .NET - mantenga el texto coherente en PPT, PPTX y ODP con ejemplos de código C# paso a paso."
---
## **Visión general**

Aspose.Slides permite renderizar presentaciones usando reglas de fuentes de respaldo. Este artículo muestra cómo crear una colección de reglas de fuentes de respaldo, modificar sus reglas eliminando o añadiendo fuentes de respaldo, y asignar la colección a la propiedad `FontsManager.FontFallBackRulesCollection`.

Una vez que la colección de reglas de fuentes de respaldo se asigna al `FontsManager` de la presentación, las reglas se aplican durante operaciones como guardar, renderizar y convertir la presentación. El ejemplo demuestra cómo usar las reglas configuradas al renderizar una miniatura de diapositiva y guardarla como imagen PNG.

1. Nosotros [creamos una colección de reglas de fuentes de respaldo](/slides/es/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/es/net/aspose.slides/fontfallbackrule/methods/remove) una regla de fuente de respaldo y [AddFallBackFonts()](https://reference.aspose.com/slides/es/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) a otra regla.
1. Establecemos la colección de reglas en la propiedad [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/es/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Con el método [Presentation.Save()](https://reference.aspose.com/slides/es/net/aspose.slides.presentation/save/methods/4) podemos guardar la presentación en el mismo formato, o guardarla en otro. Después de que la colección de reglas de fuentes de respaldo se establece en FontsManager, estas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.

```c#
using Aspose.Slides;

//Crear una nueva instancia de una colección de reglas
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

//crear un número de reglas
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Intentar eliminar la fuente FallBack "Tahoma" de las reglas cargadas
	fallBackRule.Remove("Tahoma");

	//Y actualizar las reglas para el rango especificado
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// También podemos eliminar cualquier regla existente de la lista, manteniendo al menos una regla para renderizar con
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Asignar una lista de reglas preparada para su uso
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    //Renderizar una miniatura usando la colección de reglas inicializada y guardarla como PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


{{% alert color="info" %}} 
Lea más sobre [Guardar y Conversión en Presentación](/slides/es/net/convert-powerpoint-to-png/).
{{% /alert %}}