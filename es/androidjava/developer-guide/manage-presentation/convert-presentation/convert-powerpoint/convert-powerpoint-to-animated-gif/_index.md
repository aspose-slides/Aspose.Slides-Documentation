---
title: Convertir presentaciones de PowerPoint a GIF animados en Android
linktitle: PowerPoint a GIF
type: docs
weight: 65
url: /es/androidjava/convert-powerpoint-to-animated-gif/
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
- Android
- Java
- Aspose.Slides
description: "Convierta fácilmente presentaciones de PowerPoint (PPT, PPTX) a GIF animados con Aspose.Slides para Android mediante Java. Resultados rápidos y de alta calidad."
---

## **Convertir presentaciones a GIF animado con la configuración predeterminada**

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

{{%  alert  title="TIP"  color="primary"  %}} 

Si prefieres personalizar los parámetros del GIF, puedes usar la clase [GifOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GifOptions). Consulta el código de ejemplo a continuación.

{{% /alert %}} 

## **Convertir presentaciones a GIF animado usando configuración personalizada**

Este código de ejemplo muestra cómo convertir una presentación a GIF animado usando configuraciones personalizadas en Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // el tamaño del GIF resultante
	gifOptions.setDefaultDelay(2000); // cuánto tiempo se mostrará cada diapositiva antes de cambiar a la siguiente
	gifOptions.setTransitionFps(35); // aumentar FPS para mejorar la calidad de la animación de transición
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


{{% alert title="Info" color="info" %}}

Puede que quieras probar el conversor GRATUITO [Text to GIF](https://products.aspose.app/slides/text-to-gif) desarrollado por Aspose. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué pasa si las fuentes utilizadas en la presentación no están instaladas en el sistema?**

Instala las fuentes que faltan o [configura fuentes de respaldo](/slides/es/androidjava/powerpoint-fonts/). Aspose.Slides las sustituirá, pero la apariencia podría variar. Para la identidad de marca, siempre asegúrate de que los tipos de letra necesarios estén disponibles explícitamente.

**¿Puedo superponer una marca de agua en los fotogramas del GIF?**

Sí. [Agrega un objeto/logo semitransparente](/slides/es/androidjava/watermark/) a la diapositiva maestra o a diapositivas individuales antes de exportar; la marca de agua aparecerá en cada fotograma.