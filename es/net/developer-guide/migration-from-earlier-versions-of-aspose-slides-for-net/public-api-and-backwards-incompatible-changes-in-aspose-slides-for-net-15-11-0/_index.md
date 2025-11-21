---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 15.11.0
linktitle: Aspose.Slides para .NET 15.11.0
type: docs
weight: 210
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
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
description: "Revisa las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas tus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades y demás [added](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) o [removed](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) introducidos con la API de Aspose.Slides for .NET 15.11.0.

{{% /alert %}} 
## **Cambios de la API pública**

#### **Propiedades obsoletas en la clase DataLabelCollection han sido eliminadas**
Obsolete properties in DataLabelCollection class have been deleted:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **Se ha añadido la nueva propiedad FirstSlideNumber a la clase Presentation**
La nueva propiedad FirstSlideNumber añadida a Presentation permite obtener o establecer el número de la primera diapositiva en una presentación.

Cuando se especifica un nuevo valor para FirstSlideNumber, todos los números de diapositiva se recalculan.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```