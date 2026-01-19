---
title: Configurar colecciones de fuentes de reserva en .NET
linktitle: Colección de fuentes de reserva
type: docs
weight: 20
url: /es/net/create-fallback-fonts-collection/
keywords:
- fuente de reserva
- regla de reserva
- colección de fuentes
- configurar fuente
- configurar fuente
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Configure una colección de fuentes de reserva en Aspose.Slides para .NET para mantener el texto coherente y nítido en presentaciones de PowerPoint y OpenDocument."
---

## **Aplicar reglas de reserva**

Instancias de [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) pueden organizarse en [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection), que implementa la interfaz [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection). Es posible añadir o eliminar reglas de la colección.

Luego esta colección puede asignarse a la propiedad [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) de la clase [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager). FontsManager controla las fuentes en toda la presentación.

Cada [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) tiene una propiedad [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager) con su propia instancia de la clase FontsManager.

A continuación se muestra un ejemplo de cómo crear una colección de reglas de fuentes de reserva y asignarla al FontsManager de una presentación concreta:   
```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```


Una vez que FontsManager se inicializa con la colección de fuentes de reserva, las fuentes de reserva se aplican durante la renderización de la presentación.

{{% alert color="primary" %}} 
Obtén más información sobre cómo [Render Presentation with Fallback Font](/slides/es/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se incrustarán mis reglas de reserva en el archivo PPTX y serán visibles en PowerPoint después de guardar?**

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución; no se serializan en el PPTX y no aparecerán en la interfaz de PowerPoint.

**¿Se aplican las reservas a texto dentro de SmartArt, WordArt, gráficos y tablas?**

Sí. El mismo mecanismo de sustitución de glifos se utiliza para cualquier texto en estos objetos.

**¿Aspose distribuye fuentes con la biblioteca?**

No. Usted añade y usa fuentes por su cuenta y bajo su propia responsabilidad.

**¿Se pueden usar conjuntamente la sustitución/reemplazo de fuentes faltantes y la reserva para glifos faltantes?**

Sí. Son etapas independientes del mismo proceso de resolución de fuentes: primero el motor resuelve la disponibilidad de fuentes ([replacement](/slides/es/net/font-replacement/)/[substitution](/slides/es/net/font-substitution/)), luego la reserva rellena los vacíos de glifos faltantes en las fuentes disponibles.