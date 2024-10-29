---
title: Convertir PowerPoint a GIF Animado
type: docs
weight: 65
url: /es/androidjava/convert-powerpoint-to-animated-gif/
keywords: "Convertir PowerPoint a GIF animado, PPT a GIF, PPTX a GIF"
description: "Convertir PowerPoint a GIF animado: PPT a GIF, PPTX a GIF, con la API Aspose.Slides."
---

## Convertir Presentaciones a GIF Animado Usando Configuraciones Predeterminadas ##

Este código de muestra en Java te muestra cómo convertir una presentación a GIF animado usando configuraciones estándar:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

El GIF animado se creará con parámetros predeterminados.

{{%  alert  title="CONSEJO"  color="primary"  %}} 

Si prefieres personalizar los parámetros para el GIF, puedes usar la clase [GifOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GifOptions). Mira el código de muestra a continuación.

{{% /alert %}} 

## Convertir Presentaciones a GIF Animado Usando Configuraciones Personalizadas ##
Este código de muestra te muestra cómo convertir una presentación a GIF animado usando configuraciones personalizadas en Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // el tamaño del GIF resultante  
	gifOptions.setDefaultDelay(2000); // cuánto tiempo se mostrará cada diapositiva antes de cambiar a la siguiente
	gifOptions.setTransitionFps(35); // aumentar FPS para mejor calidad de animación de transición
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

Puede que quieras probar un convertidor GRATUITO de [Texto a GIF](https://products.aspose.app/slides/text-to-gif) desarrollado por Aspose.

{{% /alert %}}