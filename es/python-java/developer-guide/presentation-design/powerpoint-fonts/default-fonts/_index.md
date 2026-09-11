---
title: Especificar fuentes predeterminadas de la presentación en Python mediante Java
linktitle: Fuente predeterminada
type: docs
weight: 30
url: /es/python-java/default-font/
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
- Python
- Java
- Aspose.Slides
description: "Establezca fuentes predeterminadas en Aspose.Slides para Python mediante Java para garantizar una conversión adecuada de PowerPoint (PPT, PPTX) y OpenDocument (ODP) a PDF, XPS e imágenes."
---
## **Visión general**

Aspose.Slides le permite especificar fuentes predeterminadas que se utilizan cuando se renderiza una presentación. Esto resulta útil al generar miniaturas de diapositivas o al exportar una presentación a formatos como PDF y XPS. Las fuentes predeterminadas se configuran a través de [LoadOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/) antes de cargar la presentación.

El método [setDefaultRegularFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) define la fuente predeterminada para el texto normal, mientras que [setDefaultAsianFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) define la fuente predeterminada para el texto asiático. Después de establecer estas opciones, la presentación puede cargarse y renderizarse usando las fuentes especificadas.

## **Utilizar fuentes predeterminadas para renderizar una presentación**

Aspose.Slides le permite establecer fuentes predeterminadas para renderizar una presentación a PDF, XPS o miniaturas. Esta sección muestra cómo definir fuentes predeterminadas para texto normal y asiático usando Aspose.Slides para Python a través de Java:

1. Cree una instancia de [LoadOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/).
1. Utilice [setDefaultRegularFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) para especificar la fuente que desee. El siguiente ejemplo usa Wingdings.
1. Utilice [setDefaultAsianFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) para especificar la fuente que desee. El siguiente ejemplo también usa Wingdings.
1. Cargue la presentación mediante [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) con las opciones de carga.
1. Genere la miniatura de la diapositiva, el PDF y el XPS para verificar los resultados.

El siguiente ejemplo implementa estos pasos:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Utilice opciones de carga para definir las fuentes predeterminadas regular y asiática.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Cargue la presentación.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Genere una miniatura de diapositiva.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Guarde la imagen en disco.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Genere un PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Genere un documento XPS.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué afectan exactamente las fuentes predeterminadas regular y asiática: solo la exportación o también las miniaturas, PDF, XPS, HTML y SVG?**

Participan en la cadena de renderizado para todas las salidas admitidas. Esto incluye miniaturas de diapositivas, [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/es/python-java/convert-powerpoint-to-xps/), [imágenes rasterizadas](/slides/es/python-java/convert-powerpoint-to-png/), [HTML](/slides/es/python-java/convert-powerpoint-to-html/), y [SVG](/slides/es/python-java/render-a-slide-as-an-svg-image/), porque Aspose.Slides utiliza la misma lógica de diseño y resolución de glifos en estos destinos.

**¿Se aplican las fuentes predeterminadas al leer y guardar un PPTX sin realizar ningún renderizado?**

No. Las fuentes predeterminadas son relevantes cuando el texto debe medirse y dibujarse. Un simple abrir‑guardar de una presentación no modifica los fragmentos de fuente almacenados ni la estructura del archivo. Las fuentes predeterminadas intervienen durante operaciones que renderizan o reorganizan el texto.

**Si añado mis propias carpetas de fuentes o suministro fuentes desde la memoria, ¿se tendrán en cuenta al elegir fuentes predeterminadas?**

Sí. Las [fuentes personalizadas](/slides/es/python-java/custom-font/) amplían el catálogo de familias y glifos disponibles que el motor puede usar. Las fuentes predeterminadas y cualquier [regla de sustitución](/slides/es/python-java/fallback-font/) se resolverán contra esas fuentes primero, ofreciendo una cobertura más fiable en servidores y contenedores.

**¿Las fuentes predeterminadas afectan a las métricas del texto (kerning, avances) y, por tanto, a los saltos de línea y al ajuste?**

Sí. Cambiar la fuente modifica las métricas de los glifos y puede alterar los saltos de línea, el ajuste y la paginación durante el renderizado. Para mantener la estabilidad del diseño, [incorpore las fuentes originales](/slides/es/python-java/embedded-font/) o seleccione familias predeterminadas y de sustitución métricamente compatibles.

**¿Tiene sentido establecer fuentes predeterminadas si todas las fuentes usadas en la presentación están incrustadas?**

A menudo no es necesario, porque las [fuentes incrustadas](/slides/es/python-java/embedded-font/) ya garantizan una apariencia consistente. Las fuentes predeterminadas siguen sirviendo como medida de seguridad para caracteres no cubiertos por el subconjunto incrustado o cuando un archivo combina texto incrustado y no incrustado.