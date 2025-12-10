---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 15.5.0
linktitle: Aspose.Slides para .NET 15.5.0
type: docs
weight: 160
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
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
Esta página enumera todas las clases, métodos, propiedades y demás que fueron [agregados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/), y otros cambios introducidos con la API de Aspose.Slides for .NET 15.5.0.
{{% /alert %}} 
## **Cambios en la API pública**
#### **Se han agregado la clase CommonSlideViewProperties y la interfaz ICommonSlideViewProperties**
La clase Aspose.Slides.CommonSlideViewProperties y la interfaz Aspose.Slides.ICommonSlideViewProperties representan propiedades comunes de la vista de diapositiva (actualmente opciones de escala de vista).
#### **Se ha agregado la propiedad IAxis.LabelOffset**
La propiedad IAxis.LabelOffset especifica la distancia de las etiquetas respecto al eje. Se aplica al eje de categoría o fecha.
#### **Se ha agregado la propiedad IChartTextBlockFormat.AutofitType**
El cambio de esta propiedad solo puede producir cierta influencia en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2013; en PowerPoint 2007 no hay efecto en la renderización).
#### **Se ha agregado la propiedad IChartTextBlockFormat.WrapText**
El cambio de esta propiedad solo puede producir cierta influencia en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2007/2013).
#### **Se han agregado propiedades de margen a IChartTextBlockFormat**
El cambio de estas propiedades solo puede producir cierta influencia en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2013; en PowerPoint 2007 no hay efecto en la renderización).
#### **Se ha agregado la propiedad ViewProperties.NotesViewProperties**
Se ha agregado la propiedad Aspose.Slides.ViewProperties.NotesViewProperties. Esta especifica propiedades comunes de vista asociadas al modo de vista de notas.
#### **Se ha agregado la propiedad ViewProperties.SlideViewProperties**
Se ha agregado la propiedad Aspose.Slides.ViewProperties.SlideViewProperties. Esta especifica propiedades comunes de vista asociadas al modo de vista de diapositiva.