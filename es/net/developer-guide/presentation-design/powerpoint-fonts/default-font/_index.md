---
title: Fuente predeterminada - API de PowerPoint C#
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
- Aspose.Slides for .NET
description: La API de PowerPoint C# le permite establecer la fuente predeterminada para renderizar presentaciones a PDF, XPS o miniaturas
---

## **Uso de fuentes predeterminadas para renderizar presentaciones**
Aspose.Slides le permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegularFont y DefaultAsianFont para usarlas como fuentes predeterminadas. Siga los pasos a continuación para cargar fuentes desde directorios externos usando la API Aspose.Slides para .NET:

1. Cree una instancia de LoadOptions.
2. Establezca DefaultRegularFont con la fuente que desee. En el siguiente ejemplo, he usado Wingdings.
3. Establezca DefaultAsianFont con la fuente que desee. He usado Wingdings en el siguiente ejemplo.
4. Cargue la presentación usando Presentation y configurando las opciones de carga.
5. Ahora, genere la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

La implementación de lo anterior se muestra a continuación.
```c#
// Utilice las opciones de carga para especificar fuentes regulares y asiáticas predeterminadas
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


## **Preguntas frecuentes**

**¿Qué afecta exactamente DefaultRegularFont y DefaultAsianFont: solo la exportación o también miniaturas, PDF, XPS, HTML y SVG?**

Participan en la canalización de renderizado para todas las salidas compatibles. Esto incluye miniaturas de diapositivas, [PDF](/slides/es/net/convert-powerpoint-to-pdf/), [XPS](/slides/es/net/convert-powerpoint-to-xps/), [imágenes raster](/slides/es/net/convert-powerpoint-to-png/), [HTML](/slides/es/net/convert-powerpoint-to-html/), y [SVG](/slides/es/net/render-a-slide-as-an-svg-image/), porque Aspose.Slides utiliza la misma lógica de diseño y resolución de glifos en estos destinos.

**¿Se aplican las fuentes predeterminadas al leer y guardar simplemente un PPTX sin ningún renderizado?**

No. Las fuentes predeterminadas son relevantes cuando el texto debe medirse y dibujarse. Un simple abrir‑guardar de una presentación no cambia los fragmentos de fuente almacenados ni la estructura del archivo. Las fuentes predeterminadas intervienen durante operaciones que renderizan o reorganizan el texto.

**Si agrego mis propias carpetas de fuentes o suministro fuentes desde la memoria, ¿se tendrán en cuenta al elegir fuentes predeterminadas?**

Sí. [Custom font sources](/slides/es/net/custom-font/) amplían el catálogo de familias y glifos disponibles que el motor puede usar. Las fuentes predeterminadas y cualquier [fallback rules](/slides/es/net/fallback-font/) se resolverán contra esas fuentes primero, proporcionando una cobertura más fiable en servidores y contenedores.

**¿Afectarán las fuentes predeterminadas a las métricas de texto (kerning, avances) y, por lo tanto, a los saltos de línea y al ajuste?**

Sí. Cambiar la fuente altera las métricas de los glifos y puede modificar los saltos de línea, el ajuste y la paginación durante el renderizado. Para la estabilidad del diseño, [embed the original fonts](/slides/es/net/embedded-font/) o seleccione familias predeterminadas y de reserva métricamente compatibles.

**¿Tiene sentido establecer fuentes predeterminadas si todas las fuentes usadas en la presentación están incrustadas?**

A menudo no es necesario, porque [embedded fonts](/slides/es/net/embedded-font/) ya garantizan una apariencia coherente. Las fuentes predeterminadas siguen siendo útiles como red de seguridad para caracteres no cubiertos por el subconjunto incrustado o cuando un archivo mezcla texto incrustado y no incrustado.