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
- exportar a PDF
- exportar a XPS
- exportar imágenes
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Establezca fuentes predeterminadas en Aspose.Slides for Python para garantizar la correcta conversión de PowerPoint (PPT, PPTX) y OpenDocument (ODP) a PDF, XPS e imágenes."
---

## **Uso de Fuentes Predeterminadas para Renderizar Presentaciones**
Aspose.Slides permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegular Font y DefaultAsian Font para su uso como fuentes predeterminadas. Siga los pasos a continuación para cargar fuentes desde directorios externos utilizando Aspose.Slides para Python a través de la API .NET:

1. Cree una instancia de LoadOptions.
1. Establezca DefaultRegularFont en su fuente deseada. En el siguiente ejemplo, he utilizado Wingdings.
1. Establezca DefaultAsianFont en su fuente deseada. He utilizado Wingdings en el siguiente ejemplo.
1. Cargue la presentación utilizando Presentation y estableciendo las opciones de carga.
1. Ahora, genere la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

La implementación de lo anterior se da a continuación.

```py
import aspose.slides as slides

# Use load options to define the default regualr and asian fonts# Use load options to define the default regualr and asian fonts
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Load the presentation
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Generate slide thumbnail
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Generate PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Generate XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```