---
title: Crear colección de fuentes de reserva
type: docs
weight: 20
url: /net/create-fallback-fonts-collection/
keywords: "Colección de fuentes de reserva, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Colección de fuentes de reserva en PowerPoint en C# o .NET"
---

Las instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) pueden organizarse en [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection), que implementa la interfaz [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection). Es posible agregar o eliminar reglas de la colección.

Luego, esta colección se puede asignar a la propiedad [FontFallBackRulesCollection ](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) del [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager) clase. FontsManager controla las fuentes a lo largo de la presentación. Lea más sobre [Acerca de FontsManager y FontsLoader](/slides/net/about-fontsmanager-and-fontsloader/).

Cada [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) tiene una propiedad [FontsManager ](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager) con su propia instancia de la clase FontsManager.

Aquí hay un ejemplo de cómo crear una colección de reglas de fuentes de reserva y asignarla al FontsManager de una presentación determinada:

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Después de que FontsManager se inicializa con la colección de fuentes de reserva, las fuentes de reserva se aplican durante la renderización de la presentación.

{{% alert color="primary" %}} 
Lea más sobre cómo [Renderizar presentación con fuente de reserva](/slides/net/render-presentation-with-fallback-font/).
{{% /alert %}}