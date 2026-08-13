---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 14.8.0
linktitle: Aspose.Slides für .NET 14.8.0
type: docs
weight: 100
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
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
description: "Überblick über öffentliche API-Updates und kompatibilitätsbrechende Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT-, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [added](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) oder [removed](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for .NET 14.8.0 API eingeführt wurden.

{{% /alert %}} 
## **Public API Changes**
### **Changed Properties**
#### **Added the IVbaProject Interface, Changed the Presentation.VbaProject Property**
Die VbaProject‑Eigenschaft der Presentation‑Klasse wurde ersetzt. Statt h3. Added Interfaces, Properties and Enumeration Options die Roh‑Byte‑Darstellung des VBA‑Projekts wurde durch eine Implementierung der neuen IVbaProject‑Schnittstelle ergänzt.

Verwenden Sie die IVbaProject‑Eigenschaft, um in einer Präsentation eingebettete VBA‑Projekte zu verwalten. Sie können neue Projektverweise hinzufügen, vorhandene Module bearbeiten und neue erstellen.

Außerdem können Sie ein neues VBA‑Projekt mit der VbaProject‑Klasse erstellen, die die IVbaProject‑Schnittstelle implementiert.

Das folgende Beispiel zeigt die Erstellung eines einfachen VBA‑Projekts mit einem Modul und dem Hinzufügen von zwei erforderlichen Bibliotheksverweisen.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // Neues VBA-Projekt erstellen
    pres.VbaProject = new VbaProject();

    // Leeres Modul zum VBA-Projekt hinzufügen
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Modul-Quellcode festlegen
    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Verweis auf <stdole> erstellen
    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Verweis auf Office erstellen
    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Verweise zum VBA-Projekt hinzufügen
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);
    pres.Save("test.pptm", SaveFormat.Pptm);
}
``` 

Dieses Beispiel zeigt, wie ein VBA‑Projekt von einer bestehenden Präsentation in eine neue kopiert wird.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Added Interfaces, Properties and Enumeration Options**
#### **Added the Aspose.Slides.Charts.IChartSeries.Overlap Property**
Die Aspose.Slides.Charts.IChartSeries.Overlap‑Eigenschaft gibt an, wie stark Balken und Säulen in 2D‑Diagrammen überlappen sollen (von -100 bis 100).

Diese Eigenschaft gilt nicht nur für diese Serie, sondern für alle Serien in der übergeordneten Seriengruppe – sie ist eine Projektion der entsprechenden Gruppeneigenschaft. Daher ist diese Eigenschaft schreibgeschützt.

- Verwenden Sie die ParentSeriesGroup‑Eigenschaft, um auf die übergeordnete Seriengruppe zuzugreifen.  
- Verwenden Sie die ParentSeriesGroup.Overlap‑Eigenschaft (lesen/schreiben), um den Wert zu ändern.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}
``` 
#### **Added the Aspose.Slides.Charts.IChartSeriesGroup.Overlap Property**
Die Aspose.Slides.Charts.IChartSeriesGroup.Overlap‑Eigenschaft gibt an, wie stark Balken und Säulen in 2D‑Diagrammen (von -100 bis 100) überlappen sollen.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **Added the ShapeThumbnailBounds.Appearance Enum Value**
Diese Methode zur Erstellung von Form‑Thumbnails ermöglicht das Generieren eines Thumbnails innerhalb der Grenzen seines Erscheinungsbildes. Alle Form‑Effekte werden berücksichtigt. Das erzeugte Form‑Thumbnail ist durch die Folienränder begrenzt.

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```