---
title: Convertir PowerPoint a GIF Animado
type: docs
weight: 65
url: /es/php-java/convert-powerpoint-to-animated-gif/
keywords: "Convertir PowerPoint a GIF animado, PPT a GIF, PPTX a GIF"
description: "Convertir PowerPoint a GIF animado: PPT a GIF, PPTX a GIF, con la API de Aspose.Slides."
---

## Convertir Presentaciones a GIF Animado Usando Configuraciones Predeterminadas ##

Este código de muestra muestra cómo convertir una presentación a GIF animado usando configuraciones estándar:

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

El GIF animado se creará con parámetros predeterminados.

{{% alert title="CONSEJO" color="primary" %}} 

Si prefieres personalizar los parámetros para el GIF, puedes usar la clase [GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions). Consulta el código de muestra a continuación.

{{% /alert %}} 

## Convertir Presentaciones a GIF Animado Usando Configuraciones Personalizadas ##
Este código de muestra muestra cómo convertir una presentación a GIF animado usando configuraciones personalizadas:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// el tamaño del GIF resultante

    $gifOptions->setDefaultDelay(2000);// cuánto tiempo se mostrará cada diapositiva hasta que se cambie a la siguiente

    $gifOptions->setTransitionFps(35);// aumentar los FPS para mejorar la calidad de la animación de transición

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}

Es posible que desees consultar un convertidor GRATUITO de [Texto a GIF](https://products.aspose.app/slides/text-to-gif) desarrollado por Aspose.

{{% /alert %}}