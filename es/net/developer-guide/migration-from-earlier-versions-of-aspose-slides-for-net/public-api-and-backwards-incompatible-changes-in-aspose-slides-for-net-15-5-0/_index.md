---
title: Cambios en la API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 15.5.0
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
description: "Revise las actualizaciones de la API pública y los cambios que rompen la compatibilidad en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades y demás [añadidas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) o [eliminadas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/), y otros cambios introducidos con la API de Aspose.Slides para .NET 15.5.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Se han añadido la clase CommonSlideViewProperties y la interfaz ICommonSlideViewProperties**
La clase Aspose.Slides.CommonSlideViewProperties y la interfaz Aspose.Slides.ICommonSlideViewProperties representan propiedades comunes de la vista de diapositivas (actualmente opciones de escala de vista).
#### **Se ha añadido la propiedad IAxis.LabelOffset**
La propiedad IAxis.LabelOffset especifica la distancia de las etiquetas respecto al eje. Se aplica al eje de categoría o de fecha.
#### **Se ha añadido la propiedad IChartTextBlockFormat.AutofitType**
Cambiar esta propiedad puede producir una cierta influencia solo en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2013; en PowerPoint 2007 no hay efecto en el renderizado).
#### **Se ha añadido la propiedad IChartTextBlockFormat.WrapText**
Cambiar esta propiedad puede producir una cierta influencia solo en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2007/2013).
#### **Se han añadido propiedades de margen a IChartTextBlockFormat**
Cambiar estas propiedades puede producir una cierta influencia solo en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2013; en PowerPoint 2007 no hay efecto en el renderizado).
#### **Se ha añadido la propiedad ViewProperties.NotesViewProperties**
Se ha añadido la propiedad Aspose.Slides.ViewProperties.NotesViewProperties. Esta especifica propiedades de vista comunes asociadas con el modo de vista de notas.
#### **Se ha añadido la propiedad ViewProperties.SlideViewProperties**
Se ha añadido la propiedad Aspose.Slides.ViewProperties.SlideViewProperties. Esta especifica propiedades de vista comunes asociadas con el modo de vista de diapositiva.