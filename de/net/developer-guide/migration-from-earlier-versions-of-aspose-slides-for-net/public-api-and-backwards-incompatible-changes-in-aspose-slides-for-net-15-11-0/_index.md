---
title: Öffentliche API und nicht rückwärtskompatible Änderungen in Aspose.Slides für .NET 15.11.0
type: docs
weight: 210
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) oder [entfernten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) Klassen, Methoden, Eigenschaften usw. sowie andere Änderungen auf, die mit der Aspose.Slides für .NET 15.11.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**

#### **Veraltete Eigenschaften in der DataLabelCollection-Klasse wurden gelöscht**
Veraltete Eigenschaften in der DataLabelCollection-Klasse wurden gelöscht:
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

#### **Die neue Eigenschaft FirstSlideNumber wurde zur Presentation-Klasse hinzugefügt**
Die neue Eigenschaft FirstSlideNumber, die zur Presentation hinzugefügt wurde, ermöglicht es, die Nummer der ersten Folie in einer Präsentation abzurufen oder festzulegen.

Wenn ein neuer Wert für FirstSlideNumber angegeben wird, werden alle Foliennummern neu berechnet.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

``` 