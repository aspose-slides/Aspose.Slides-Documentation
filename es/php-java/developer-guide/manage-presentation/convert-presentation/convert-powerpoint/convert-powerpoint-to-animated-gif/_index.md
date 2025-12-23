---
title: Convertir presentaciones de PowerPoint a GIF animados en PHP
linktitle: PowerPoint a GIF
type: docs
weight: 65
url: /es/php-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF animado
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a GIF
- presentación a GIF
- diapositiva a GIF
- PPT a GIF
- PPTX a GIF
- guardar PPT como GIF
- guardar PPTX como GIF
- exportar PPT como GIF
- exportar PPTX como GIF
- configuración predeterminada
- configuración personalizada
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Convierta fácilmente presentaciones de PowerPoint (PPT, PPTX) a GIF animados con Aspose.Slides para PHP mediante Java. Resultados rápidos y de alta calidad."
---

## **Convertir presentaciones a GIF animado usando la configuración predeterminada**

Este código de ejemplo le muestra cómo convertir una presentación a GIF animado usando la configuración estándar:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


El GIF animado se creará con los parámetros predeterminados. 

{{%  alert  title="CONSEJO"  color="primary"  %}} 

Si prefiere personalizar los parámetros del GIF, puede usar la clase [GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions). Consulte el código de ejemplo a continuación.

{{% /alert %}} 

## **Convertir presentaciones a GIF animado usando configuraciones personalizadas**
Este código de ejemplo le muestra cómo convertir una presentación a GIF animado usando configuraciones personalizadas:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// el tamaño del GIF resultante
    $gifOptions->setDefaultDelay(2000);// cuánto tiempo se mostrará cada diapositiva antes de pasar a la siguiente
    $gifOptions->setTransitionFps(35);// incrementar FPS para mejorar la calidad de la animación de transición
    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Información" color="info" %}}

Puede probar el conversor GRATUITO [Text to GIF](https://products.aspose.app/slides/text-to-gif) desarrollado por Aspose. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué pasa si las fuentes usadas en la presentación no están instaladas en el sistema?**

Instale las fuentes faltantes o [configure fuentes de reserva](/slides/es/php-java/powerpoint-fonts/). Aspose.Slides las sustituirá, pero la apariencia puede variar. Para la marca, siempre asegúrese de que los tipos de letra requeridos estén disponibles explícitamente.

**¿Puedo superponer una marca de agua en los fotogramas del GIF?**

Sí. [Añada un objeto/logo semitransparente](/slides/es/php-java/watermark/) a la diapositiva maestra o a diapositivas individuales antes de la exportación; la marca de agua aparecerá en cada fotograma.