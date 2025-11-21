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
description: "Establecer fuentes predeterminadas en Aspose.Slides para Python para garantizar una conversión adecuada de PowerPoint (PPT, PPTX) y OpenDocument (ODP) a PDF, XPS e imágenes."
---

## **Uso de fuentes predeterminadas para renderizar presentaciones**
Aspose.Slides le permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegularFont y DefaultAsianFont para usarlas como fuentes predeterminadas. Siga los pasos a continuación para cargar fuentes desde directorios externos usando Aspose.Slides for Python via .NET API:

1. Crear una instancia de LoadOptions.
1. Establecer DefaultRegularFont a la fuente deseada. En el ejemplo siguiente, he usado Wingdings.
1. Establecer DefaultAsianFont a la fuente deseada. He usado Wingdings en el siguiente ejemplo.
1. Cargar la presentación usando Presentation y configurando las opciones de carga.
1. Ahora, genere la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

La implementación anterior se muestra a continuación.
```py
import aspose.slides as slides

# Usar opciones de carga para definir las fuentes predeterminadas regulares y asiáticas# Usar opciones de carga para definir las fuentes predeterminadas regulares y asiáticas
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Cargar la presentación
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Generar miniatura de diapositiva
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Generar PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Generar XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```


## **FAQ**

**¿Qué afecta exactamente default_regular_font y default_asian_font—solo la exportación, o también miniaturas, PDF, XPS, HTML y SVG?**

Participan en la canalización de renderizado para todas las salidas compatibles. Esto incluye miniaturas de diapositivas, [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/es/python-net/convert-powerpoint-to-xps/), [imágenes raster](/slides/es/python-net/convert-powerpoint-to-png/), [HTML](/slides/es/python-net/convert-powerpoint-to-html/), y [SVG](/slides/es/python-net/render-a-slide-as-an-svg-image/), porque Aspose.Slides utiliza la misma lógica de diseño y resolución de glifos en estos destinos.

**¿Se aplican las fuentes predeterminadas al leer y guardar un PPTX sin ningún renderizado?**

No. Las fuentes predeterminadas solo son relevantes cuando el texto debe medirse y dibujarse. Un simple abrir‑guardar de una presentación no cambia los fragmentos de fuente almacenados ni la estructura del archivo. Las fuentes predeterminadas entran en juego durante operaciones que renderizan o reflujo el texto.

**Si agrego mis propias carpetas de fuentes o suministro fuentes desde la memoria, ¿se tendrán en cuenta al elegir fuentes predeterminadas?**

Sí. [Fuentes personalizadas](/slides/es/python-net/custom-font/) amplían el catálogo de familias y glifos disponibles que el motor puede usar. Las fuentes predeterminadas y cualquier [regla de reserva](/slides/es/python-net/fallback-font/) se resolverán contra esas fuentes primero, proporcionando una cobertura más fiable en servidores y contenedores.

**¿Las fuentes predeterminadas afectan las métricas del texto (kerning, avances) y, por lo tanto, los saltos de línea y el ajuste?**

Sí. Cambiar la fuente modifica las métricas de los glifos y puede alterar los saltos de línea, el ajuste y la paginación durante el renderizado. Para mantener la estabilidad del diseño, [incorpore las fuentes originales](/slides/es/python-net/embedded-font/) o seleccione familias predeterminadas y de reserva métricamente compatibles.

**¿Tiene sentido establecer fuentes predeterminadas si todas las fuentes usadas en la presentación están incrustadas?**

A menudo no es necesario, porque las [fuentes incrustadas](/slides/es/python-net/embedded-font/) ya garantizan una apariencia consistente. Las fuentes predeterminadas siguen sirviendo como red de seguridad para caracteres no cubiertos por el subconjunto incrustado o cuando un archivo combina texto incrustado y no incrustado.