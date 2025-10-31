---
title: Convertir presentaciones a GIF animados en Python
linktitle: Presentación a GIF
type: docs
weight: 65
url: /es/python-net/convert-powerpoint-to-animated-gif/
keywords:
- GIF animado
- convertir PowerPoint
- convertir OpenDocument
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- convertir ODP
- PowerPoint a GIF
- OpenDocument a GIF
- presentación a GIF
- diapositiva a GIF
- PPT a GIF
- PPTX a GIF
- ODP a GIF
- configuración predeterminada
- configuración personalizada
- Python
- Aspose.Slides
description: "Convierta fácilmente presentaciones de PowerPoint (PPT, PPTX) y archivos OpenDocument (ODP) a GIF animados con Aspose.Slides para Python. Resultados rápidos y de alta calidad."
---

## **Convertir presentaciones a GIF animado usando la configuración predeterminada**

Este código de ejemplo en Python muestra cómo convertir una presentación a GIF animado usando la configuración estándar:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

El GIF animado se creará con parámetros predeterminados.

{{%  alert  title="CONSEJO"  color="primary"  %}} 

Si prefiere personalizar los parámetros del GIF, puede usar la clase GifOptions. Vea el código de ejemplo a continuación. 

{{% /alert %}} 

## **Convertir presentaciones a GIF animado usando configuración personalizada**

Este código de ejemplo muestra cómo convertir una presentación a GIF animado usando configuración personalizada en Python:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # el tamaño del GIF resultante
options.default_delay = 2000 # cuánto tiempo se mostrará cada diapositiva antes de cambiar a la siguiente
options.transition_fps = 35  # aumentar FPS para mejorar la calidad de la animación de transición

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Información" color="info" %}}

Tal vez quiera probar el conversor GRATUITO Texto a GIF desarrollado por Aspose. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué pasa si las fuentes utilizadas en la presentación no están instaladas en el sistema?**

Instale las fuentes faltantes o [configure fuentes de respaldo](/slides/es/python-net/powerpoint-fonts/). Aspose.Slides hará sustituciones, pero la apariencia puede variar. Para la marca, siempre asegúrese de que los tipos de letra requeridos estén disponibles explícitamente.

**¿Puedo superponer una marca de agua en los fotogramas del GIF?**

Sí. [Agregue un objeto/logo semitransparente](/slides/es/python-net/watermark/) a la diapositiva maestra o a diapositivas individuales antes de la exportación — la marca de agua aparecerá en cada fotograma.