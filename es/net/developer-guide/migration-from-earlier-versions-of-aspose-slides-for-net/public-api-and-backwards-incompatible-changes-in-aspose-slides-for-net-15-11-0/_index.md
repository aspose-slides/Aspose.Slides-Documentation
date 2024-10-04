---
title: API Pública y Cambios Incompatibles hacia Atrás en Aspose.Slides para .NET 15.11.0
type: docs
weight: 210
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades y demás que se [agregaron](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) o [eliminaron](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/), y otros cambios introducidos con la API de Aspose.Slides para .NET 15.11.0.

{{% /alert %}} 
## **Cambios en la API Pública**

#### **Se han eliminado las propiedades obsoletas en la clase DataLabelCollection**
Se han eliminado las propiedades obsoletas en la clase DataLabelCollection:
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

#### **Se ha agregado la nueva propiedad FirstSlideNumber a la clase Presentation**
La nueva propiedad FirstSlideNumber añadida a Presentation permite obtener o establecer el número de la primera diapositiva en una presentación.

Cuando se especifica un nuevo valor para FirstSlideNumber, todos los números de las diapositivas se recalculan.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

``` 