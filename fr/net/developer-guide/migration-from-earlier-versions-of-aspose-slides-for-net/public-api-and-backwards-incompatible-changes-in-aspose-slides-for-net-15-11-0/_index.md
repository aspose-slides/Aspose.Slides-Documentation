---
title: API public et changements incompatibles avec les versions précédentes dans Aspose.Slides pour .NET 15.11.0
type: docs
weight: 210
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les classes, méthodes, propriétés ajoutées ou supprimées et ainsi de suite, ainsi que d'autres changements introduits avec l'API Aspose.Slides pour .NET 15.11.0.

{{% /alert %}} 
## **Changements de l'API publique**

#### **Les propriétés obsolètes dans la classe DataLabelCollection ont été supprimées**
Les propriétés obsolètes dans la classe DataLabelCollection ont été supprimées :
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

#### **La nouvelle propriété FirstSlideNumber a été ajoutée à la classe Presentation**
La nouvelle propriété FirstSlideNumber ajoutée à Presentation permet d'obtenir ou de définir le numéro de la première diapositive dans une présentation.

Lorsqu'une nouvelle valeur FirstSlideNumber est spécifiée, tous les numéros de diapositive sont recalculés.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```