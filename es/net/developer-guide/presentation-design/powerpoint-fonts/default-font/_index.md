---
title: Especificar fuentes predeterminadas de la presentación en .NET
linktitle: Fuente predeterminada
type: docs
weight: 30
url: /es/net/default-font/
keywords:
- fuente predeterminada
- fuente regular
- fuente normal
- fuente asiática
- exportación a PDF
- exportación a XPS
- exportación de imágenes
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Establezca fuentes predeterminadas en Aspose.Slides para .NET para garantizar una conversión adecuada de PowerPoint (PPT, PPTX) y OpenDocument (ODP) a PDF, XPS e imágenes."
---

## **Uso de fuentes predeterminadas para renderizar la presentación**
Aspose.Slides le permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegularFont y DefaultAsianFont para usarlas como fuentes predeterminadas. Siga los pasos a continuación para cargar fuentes desde directorios externos mediante la API Aspose.Slides para .NET:

1. Crear una instancia de LoadOptions.  
1. Establecer DefaultRegularFont a la fuente deseada. En el siguiente ejemplo, he usado Wingdings.  
1. Establecer DefaultAsianFont a la fuente deseada. He usado Wingdings en el ejemplo siguiente.  
1. Cargar la presentación usando Presentation y configurando las opciones de carga.  
1. Ahora, generar la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

La implementación de lo anterior se muestra a continuación.  
```c#
// Utilice las opciones de carga para especificar las fuentes regulares y asiáticas predeterminadas
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


## **FAQ**

**¿Qué afectan exactamente DefaultRegularFont y DefaultAsianFont: solo la exportación o también las miniaturas, PDF, XPS, HTML y SVG?**

Participan en la canalización de renderizado para todas las salidas compatibles. Esto incluye miniaturas de diapositivas, [PDF](/slides/es/net/convert-powerpoint-to-pdf/), [XPS](/slides/es/net/convert-powerpoint-to-xps/), [imágenes raster](/slides/es/net/convert-powerpoint-to-png/), [HTML](/slides/es/net/convert-powerpoint-to-html/), y [SVG](/slides/es/net/render-a-slide-as-an-svg-image/), ya que Aspose.Slides utiliza la misma lógica de diseño y resolución de glifos en estos destinos.

**¿Se aplican las fuentes predeterminadas al leer y guardar un PPTX sin ningún renderizado?**

No. Las fuentes predeterminadas importan cuando el texto debe medirse y dibujarse. Un simple abrir‑guardar de una presentación no cambia los grupos de fuentes almacenados ni la estructura del archivo. Las fuentes predeterminadas entran en juego durante operaciones que renderizan o reorganizan el texto.

**Si añado mis propias carpetas de fuentes o suministro fuentes desde la memoria, ¿se tendrán en cuenta al elegir fuentes predeterminadas?**

Sí. Las [fuentes personalizadas](/slides/es/net/custom-font/) amplían el catálogo de familias y glifos disponibles que el motor puede usar. Las fuentes predeterminadas y cualquier [regla de reserva](/slides/es/net/fallback-font/) se resolverán contra esas fuentes primero, ofreciendo una cobertura más fiable en servidores y contenedores.

**¿Afectarán las fuentes predeterminadas a las métricas del texto (kerning, avances) y, por tanto, a los saltos de línea y al ajuste?**

Sí. Cambiar la fuente altera las métricas de los glifos y puede modificar los saltos de línea, el ajuste y la paginación durante el renderizado. Para mantener la estabilidad del diseño, [incorpore las fuentes originales](/slides/es/net/embedded-font/) o seleccione familias predeterminadas y de reserva métricamente compatibles.

**¿Tiene sentido establecer fuentes predeterminadas si todas las fuentes utilizadas en la presentación están incrustadas?**

A menudo no es necesario, porque las [fuentes incrustadas](/slides/es/net/embedded-font/) ya garantizan una apariencia consistente. Las fuentes predeterminadas siguen siendo útiles como red de seguridad para caracteres no cubiertos por el subconjunto incrustado o cuando un archivo combina texto incrustado y no incrustado.