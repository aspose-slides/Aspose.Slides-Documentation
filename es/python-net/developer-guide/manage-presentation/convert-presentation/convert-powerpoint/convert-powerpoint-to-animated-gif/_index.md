---
title: Convertir PowerPoint a GIF Animado
type: docs
weight: 65
url: /es/python-net/convert-powerpoint-to-animated-gif/
keywords: "Convertir PowerPoint, PPT, PPTX, GIF animado, PPT a GIF animado, PPTX a GIF animado, Python, configuraciones predeterminadas, configuraciones personalizadas"
description: "Convertir Presentación de PowerPoint a GIF animado: PPT a GIF, PPTX a GIF en Python"
---

## Convertir Presentaciones a GIF Animado Usando Configuraciones Predeterminadas ##

Este código de ejemplo en Python muestra cómo convertir una presentación a GIF animado usando configuraciones estándar:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

El GIF animado se creará con parámetros predeterminados.

{{%  alert  title="TIP"  color="primary"  %}} 

Si prefieres personalizar los parámetros para el GIF, puedes usar la clase [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/). Consulta el código de ejemplo a continuación.

{{% /alert %}} 

## Convertir Presentaciones a GIF Animado Usando Configuraciones Personalizadas ##
Este código de ejemplo muestra cómo convertir una presentación a GIF animado usando configuraciones personalizadas en Python:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # el tamaño del GIF resultante  
options.default_delay = 2000 # cuánto tiempo se mostrará cada diapositiva hasta que se cambie a la siguiente
options.transition_fps = 35  # aumentar FPS para una mejor calidad de animación de transición

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}

Es posible que desees probar un conversor GRATUITO de [Texto a GIF](https://products.aspose.app/slides/text-to-gif) desarrollado por Aspose.

{{% /alert %}}