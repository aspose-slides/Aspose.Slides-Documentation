---
title: Personalizar fuentes predeterminadas en presentaciones con Python
linktitle: Fuente predeterminada
type: docs
weight: 30
url: /es/python-net/default-font/
keywords:
- fuente predeterminada
- fuente regular
- fuente normal
- fuente asiática
- exportación PDF
- exportación XPS
- exportación de imagen
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Establezca fuentes predeterminadas en Aspose.Slides para Python y garantice una conversión adecuada de PowerPoint (PPT, PPTX) y OpenDocument (ODP) a PDF, XPS e imágenes."
---

## **Uso de fuentes predeterminadas para renderizar la presentación**
Aspose.Slides le permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegularFont y DefaultAsianFont para usarlas como fuentes predeterminadas. Siga los pasos a continuación para cargar fuentes desde directorios externos mediante Aspose.Slides para Python a través de la API .NET:

1. Cree una instancia de LoadOptions.  
2. Establezca DefaultRegularFont con la fuente que desee. En el siguiente ejemplo, he usado Wingdings.  
3. Establezca DefaultAsianFont con la fuente que desee. He usado Wingdings en el ejemplo siguiente.  
4. Cargue la presentación usando Presentation y estableciendo las opciones de carga.  
5. Ahora, genere la miniatura de la diapositiva, el PDF y el XPS para verificar los resultados.  

La implementación anterior se muestra a continuación.

```py
import aspose.slides as slides

# Usar opciones de carga para definir las fuentes regulares y asiáticas predeterminadas
# Usar opciones de carga para definir las fuentes regulares y asiáticas predeterminadas
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Cargar la presentación
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Generar miniatura de la diapositiva
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Generar PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Generar XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **FAQ**

**¿Qué afectan exactamente default_regular_font y default_asian_font—solo la exportación, o también las miniaturas, PDF, XPS, HTML y SVG?**

Participan en la canalización de renderizado para todas las salidas compatibles. Esto incluye miniaturas de diapositivas, [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/es/python-net/convert-powerpoint-to-xps/), [imágenes raster](/slides/es/python-net/convert-powerpoint-to-png/), [HTML](/slides/es/python-net/convert-powerpoint-to-html/), y [SVG](/slides/es/python-net/render-a-slide-as-an-svg-image/), porque Aspose.Slides usa la misma lógica de diseño y resolución de glifos en estos destinos.

**¿Se aplican las fuentes predeterminadas al leer y guardar simplemente un PPTX sin ningún renderizado?**

No. Las fuentes predeterminadas son relevantes cuando el texto debe medirse y dibujarse. Un simple abrir‑guardar de una presentación no cambia los runs de fuente almacenados ni la estructura del archivo. Las fuentes predeterminadas entran en juego durante operaciones que renderizan o reorganizan el texto.

**Si añado mis propias carpetas de fuentes o suministro fuentes desde memoria, ¿se tendrán en cuenta al elegir fuentes predeterminadas?**

Sí. [Fuentes personalizadas](/slides/es/python-net/custom-font/) amplían el catálogo de familias y glifos disponibles que el motor puede usar. Las fuentes predeterminadas y cualquier [regla de respaldo](/slides/es/python-net/fallback-font/) se resolverán contra esas fuentes primero, ofreciendo una cobertura más fiable en servidores y contenedores.

**¿Afectarán las fuentes predeterminadas a las métricas del texto (kerning, avances) y por tanto a los saltos de línea y al ajuste?**

Sí. Cambiar la fuente modifica las métricas de los glifos y puede alterar los saltos de línea, el ajuste y la paginación durante el renderizado. Para mantener la estabilidad del diseño, [incorpore las fuentes originales](/slides/es/python-net/embedded-font/) o seleccione familias predeterminadas y de respaldo compatibles métricamente.

**¿Tiene sentido establecer fuentes predeterminadas si todas las fuentes usadas en la presentación están incrustadas?**

A menudo no es necesario, porque las [fuentes incrustadas](/slides/es/python-net/embedded-font/) ya garantizan una apariencia consistente. Las fuentes predeterminadas siguen siendo útiles como red de seguridad para caracteres no cubiertos por el subconjunto incrustado o cuando un archivo combina texto incrustado y no incrustado.