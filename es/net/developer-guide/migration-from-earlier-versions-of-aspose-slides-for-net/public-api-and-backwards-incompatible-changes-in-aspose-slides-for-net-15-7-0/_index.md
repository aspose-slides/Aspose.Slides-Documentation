---
title: Cambios en la API pública e incompatibles hacia atrás en Aspose.Slides para .NET 15.7.0
linktitle: Aspose.Slides para .NET 15.7.0
type: docs
weight: 180
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}}

Esta página enumera todas las clases, métodos, propiedades y demás, que han sido [añadido](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) o [eliminado](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/), y otros cambios introducidos con la API de Aspose.Slides para .NET 15.7.0.

{{% /alert %}}
## **Cambios de la API pública**
#### **Se ha añadido el enum ImagePixelFormat**
El enum Aspose.Slides.Export.ImagePixelFormat se ha añadido para especificar el formato de píxel de las imágenes generadas.
#### **Se ha añadido el método IChartDataPoint.GetAutomaticDataPointColor()**
Devuelve un color automático del punto de datos basado en el índice de serie, índice del punto de datos, ParentSeriesGroup, la propiedad IsColorVaried y el estilo del gráfico.
Este color se usa por defecto si FillType es NotDefined.
#### **Se ha añadido el método RenderToGraphics a Slide**
El método RenderToGraphics (y sus sobrecargas) se ha añadido a Aspose.Slides.Slide para renderizar una diapositiva a un objeto Graphics.
#### **Se ha añadido la propiedad PixelFormat a ITiffOptions y TiffOptions**
La propiedad PixelFormat se ha añadido a Aspose.Slides.Export.ITiffOptions y Aspose.Slides.Export.TiffOptions para especificar el formato de píxel de las imágenes TIFF generadas.