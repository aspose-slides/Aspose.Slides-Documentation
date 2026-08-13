---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.11.0
linktitle: Aspose.Slides für .NET 15.11.0
type: docs
weight: 210
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überprüfen Sie die öffentlichen API-Updates und breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint-PPT-, PPTX- und ODP-Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 15.11.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**

#### **Veraltete Eigenschaften in der DataLabelCollection-Klasse wurden entfernt**
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

#### **Die neue Eigenschaft FirstSlideNumber wurde zur Presentation-Klasse hinzugefügt**
Die neue Eigenschaft FirstSlideNumber, die zur Presentation-Klasse hinzugefügt wurde, ermöglicht das Abrufen oder Festlegen der Nummer der ersten Folie in einer Präsentation.

Wenn ein neuer FirstSlideNumber-Wert festgelegt wird, werden alle Foliennummern neu berechnet.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string path = "sample.pptx";
string newPath = "output.pptx";

using (var pres = new Presentation(path))
{
    int firstSlideNumber = pres.FirstSlideNumber;

    pres.FirstSlideNumber = 10;

    pres.Save(newPath, SaveFormat.Pptx);
}
```