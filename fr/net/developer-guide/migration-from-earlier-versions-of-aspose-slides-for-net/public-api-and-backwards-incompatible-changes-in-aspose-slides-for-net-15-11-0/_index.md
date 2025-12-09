---
title: API publique et modifications incompatibles avec les versions antérieures dans Aspose.Slides pour .NET 15.11.0
linktitle: Aspose.Slides pour .NET 15.11.0
type: docs
weight: 210
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Passez en revue les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) classes, méthodes, propriétés et ainsi de suite, ainsi que les autres changements introduits avec l’API Aspose.Slides for .NET 15.11.0.

{{% /alert %}} 
## **Modifications de l'API publique**

#### **Les propriétés obsolètes de la classe DataLabelCollection ont été supprimées**
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

#### **La nouvelle propriété FirstSlideNumber a été ajoutée à la classe Presentation**
La nouvelle propriété FirstSlideNumber ajoutée à Presentation permet d'obtenir ou de définir le numéro de la première diapositive d'une présentation.

Lorsque la valeur FirstSlideNumber est spécifiée, tous les numéros de diapositives sont recalculés.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```