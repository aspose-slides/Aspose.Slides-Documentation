---
title: Cambios de API pública y incompatibles hacia atrás en Aspose.Slides para .NET 15.7.0
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
description: "Revisa las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas tus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todos los [añadidos](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) clases, métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides para .NET 15.7.0.

{{% /alert %}} 
## **Cambios de la API pública**
#### **Se ha añadido el enum ImagePixelFormat**
Se ha añadido el enum Aspose.Slides.Export.ImagePixelFormat para especificar el formato de píxeles de las imágenes generadas.
#### **Se ha añadido el método IChartDataPoint.GetAutomaticDataPointColor()**
Devuelve un color automático del punto de datos basado en el índice de la serie, el índice del punto de datos, ParentSeriesGroup, la propiedad IsColorVaried y el estilo del gráfico.
Este color se utiliza por defecto si FillType es igual a NotDefined.
#### **Se ha añadido el método RenderToGraphics a Slide**
Se ha añadido el método RenderToGraphics (y sus sobrecargas) a Aspose.Slides.Slide para renderizar una diapositiva en un objeto Graphics.
#### **Se ha añadido la propiedad PixelFormat a ITiffOptions y TiffOptions**
Se ha añadido la propiedad PixelFormat a Aspose.Slides.Export.ITiffOptions y Aspose.Slides.Export.TiffOptions para especificar el formato de píxeles de las imágenes TIFF generadas.