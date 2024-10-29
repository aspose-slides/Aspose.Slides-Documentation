---
title: Fuente predeterminada - API de PowerPoint en C#
linktitle: Fuente predeterminada
type: docs
weight: 30
url: /es/net/default-font/
keywords: 
- fuente
- fuente predeterminada
- renderizar presentación
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides para .NET
description: La API de PowerPoint en C# te permite establecer la fuente predeterminada para renderizar presentaciones en PDF, XPS o miniaturas
---

## **Uso de fuentes predeterminadas para renderizar presentaciones**
Aspose.Slides te permite establecer la fuente predeterminada para renderizar la presentación en PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegular
Font y DefaultAsian Font para usarlas como fuentes predeterminadas. Por favor, sigue los pasos a continuación para cargar fuentes desde directorios externos utilizando la API de Aspose.Slides para .NET:

1. Crea una instancia de LoadOptions.
1. Establece DefaultRegularFont a la fuente deseada. En el siguiente ejemplo, he utilizado Wingdings.
1. Establece DefaultAsianFont a la fuente deseada. He utilizado Wingdings en el siguiente ejemplo.
1. Carga la presentación utilizando Presentation y estableciendo las opciones de carga.
1. Ahora, genera la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

La implementación de lo anterior se muestra a continuación.

```c#
// Usa las opciones de carga para especificar fuentes regulares y asiáticas predeterminadas
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```