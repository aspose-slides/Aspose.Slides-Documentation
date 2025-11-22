---
title: Convertir presentaciones de PowerPoint a GIF animados en Java
linktitle: PowerPoint a GIF
type: docs
weight: 65
url: /es/java/convert-powerpoint-to-animated-gif/
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
- Java
- Aspose.Slides
description: "Convierta fácilmente presentaciones de PowerPoint (PPT, PPTX) a GIF animados con Aspose.Slides para Java. Resultados rápidos y de alta calidad."
---

## Convertir presentaciones a GIF animado usando la configuración predeterminada ##

Este código de ejemplo en Java muestra cómo convertir una presentación a GIF animado usando la configuración estándar:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```


El GIF animado se creará con los parámetros predeterminados. 

{{% alert title="CONSEJO" color="primary" %}} 

Si prefiere personalizar los parámetros del GIF, puede usar la clase [GifOptions](https://reference.aspose.com/slides/java/com.aspose.slides/GifOptions). Consulte el código de ejemplo a continuación. 

{{% /alert %}} 

## Convertir presentaciones a GIF animado usando configuraciones personalizadas ##
Este código de ejemplo muestra cómo convertir una presentación a GIF animado usando configuraciones personalizadas en Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // el tamaño del GIF resultante
	gifOptions.setDefaultDelay(2000); // cuánto tiempo se mostrará cada diapositiva antes de cambiar a la siguiente
	gifOptions.setTransitionFps(35); // incrementar FPS para una mejor calidad de animación de transición

	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


{{% alert title="Información" color="info" %}}

Es posible que desee probar un conversor GRATUITO [Text to GIF](https://products.aspose.app/slides/text-to-gif) desarrollado por Aspose. 

{{% /alert %}}