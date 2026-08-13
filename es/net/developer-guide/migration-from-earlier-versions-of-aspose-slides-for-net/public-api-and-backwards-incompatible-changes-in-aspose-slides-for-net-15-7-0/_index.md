---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 15.7.0
linktitle: Aspose.Slides para .NET 15.7.0
type: docs
weight: 180
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- migración
- código legado
- código moderno
- enfoque legado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revisa las actualizaciones de la API pública y los cambios que rompen compatibilidad en Aspose.Slides para .NET para migrar sin problemas tus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}}
Esta página enumera todas las [añadidas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) o [eliminadas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) clases, métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides for .NET 15.7.0.
{{% /alert %}} 
## **Cambios en la API pública**
#### **Enum ImagePixelFormat ha sido añadido**
Enum Aspose.Slides.Export.ImagePixelFormat ha sido añadido para especificar el formato de píxel de las imágenes generadas.
#### **IChartDataPoint.GetAutomaticDataPointColor() ha sido añadido**
Devuelve un color automático del punto de datos basado en el índice de serie, el índice del punto de datos, ParentSeriesGroup, la propiedad IsColorVaried y el estilo del gráfico.
Este color se utiliza por defecto si FillType es NotDefined.
#### **RenderToGraphics ha sido añadido a Slide**
Method RenderToGraphics (y sus sobrecargas) ha sido añadido a Aspose.Slides.Slide para renderizar una diapositiva a un objeto Graphics.
#### **PixelFormat ha sido añadido a ITiffOptions y TiffOptions**
Property PixelFormat ha sido añadido a Aspose.Slides.Export.ITiffOptions y Aspose.Slides.Export.TiffOptions para especificar el formato de píxel de las imágenes TIFF generadas.