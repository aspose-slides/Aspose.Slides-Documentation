---
title: Convertir PowerPoint a GIF animado
type: docs
weight: 65
url: /es/nodejs-java/convert-powerpoint-to-animated-gif/
keywords: "Convertir PowerPoint a GIF animado, PPT a GIF, PPTX a GIF"
description: "Convertir PowerPoint a GIF animado: PPT a GIF, PPTX a GIF, con la API de Aspose.Slides."
---

## **Convertir presentaciones a GIF animado usando la configuración predeterminada**

Este código de ejemplo en JavaScript le muestra cómo convertir una presentación a GIF animado usando la configuración estándar:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


El GIF animado se creará con los parámetros predeterminados.

{{%  alert  title="TIP"  color="primary"  %}}
Si prefiere personalizar los parámetros del GIF, puede usar la clase [GifOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GifOptions). Vea el código de ejemplo a continuación.
{{% /alert %}}

## **Convertir presentaciones a GIF animado usando configuración personalizada**

Este código de ejemplo le muestra cómo convertir una presentación a GIF animado usando configuraciones personalizadas en JavaScript:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// el tamaño del GIF resultante
    gifOptions.setDefaultDelay(2000);// cuánto tiempo se mostrará cada diapositiva antes de cambiar a la siguiente
    gifOptions.setTransitionFps(35);// aumentar FPS para mejorar la calidad de la animación de transición
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Info" color="info" %}}
Puede que quiera probar un convertidor GRATUITO [Text to GIF](https://products.aspose.app/slides/text-to-gif) desarrollado por Aspose.
{{% /alert %}}

## **FAQ**

**¿Qué pasa si las fuentes usadas en la presentación no están instaladas en el sistema?**

Instale las fuentes faltantes o [configure fallback fonts](/slides/es/nodejs-java/powerpoint-fonts/). Aspose.Slides sustituirá, pero la apariencia puede variar. Para la marca, siempre asegúrese de que los tipos de letra requeridos estén disponibles explícitamente.

**¿Puedo superponer una marca de agua en los fotogramas del GIF?**

Sí. [Add a semi-transparent object/logo](/slides/es/nodejs-java/watermark/) a la diapositiva maestra o a diapositivas individuales antes de la exportación — la marca de agua aparecerá en cada fotograma.