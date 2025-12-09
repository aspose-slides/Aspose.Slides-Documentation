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
description: "Überblick über öffentliche API-Updates und breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT-, PPTX- und ODP-Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) Klassen, Methoden, Eigenschaften und derartige Elemente sowie weitere Änderungen, die mit der Aspose.Slides for .NET 14.8.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **Geänderte Eigenschaften**
#### **Das IVbaProject-Interface hinzugefügt, die Presentation.VbaProject‑Eigenschaft geändert**
Die VbaProject‑Eigenschaft der Presentation‑Klasse wurde ersetzt. Statt der rohen Byte‑Darstellung des VBA‑Projekts wurde die neue IVbaProject‑Interface‑Implementierung hinzugefügt.

Verwenden Sie die IVbaProject‑Eigenschaft, um VBA‑Projekte, die in einer Präsentation eingebettet sind, zu verwalten. Sie können neue Projekt‑Referenzen hinzufügen, vorhandene Module bearbeiten und neue erstellen.

Außerdem können Sie ein neues VBA‑Projekt über die VbaProject‑Klasse erstellen, die das IVbaProject‑Interface implementiert.

Das folgende Beispiel zeigt die Erstellung eines einfachen VBA‑Projekts mit einem Modul und dem Hinzufügen von zwei erforderlichen Referenzen zu den Bibliotheken.

``` csharp

 using (Presentation pres = new Presentation())

{

    // Create new VBA Project

    pres.VbaProject = new VbaProject();

    // Add empty module to the VBA project

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Set module source code

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Create reference to <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Create reference to Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Add references to the VBA project

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

Dieses Beispiel zeigt, wie ein VBA‑Projekt von einer bestehenden Präsentation in eine neue kopiert wird.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Interfaces, Eigenschaften und Aufzählungsoptionen hinzugefügt**
#### **Die Aspose.Slides.Charts.IChartSeries.Overlap‑Eigenschaft hinzugefügt**
Die Aspose.Slides.Charts.IChartSeries.Overlap‑Eigenschaft gibt an, wie stark Balken und Säulen in 2D‑Diagrammen überlappen (Werte von -100 bis 100).

Dies ist nicht nur die Eigenschaft dieser Serie, sondern aller Serien in der übergeordneten Seriengruppe – sie ist eine Projektion der entsprechenden Gruppeneigenschaft. Daher ist diese Eigenschaft schreibgeschützt.

- Verwenden Sie die ParentSeriesGroup‑Eigenschaft, um auf die übergeordnete Seriengruppe zuzugreifen.
- Verwenden Sie die ParentSeriesGroup.Overlap‑Lese‑/‑Schreib‑Eigenschaft, um den Wert zu ändern.

``` csharp

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
#### **Die Aspose.Slides.Charts.IChartSeriesGroup.Overlap‑Eigenschaft hinzugefügt**
Die Aspose.Slides.Charts.IChartSeriesGroup.Overlap‑Eigenschaft gibt an, wie stark Balken und Säulen in 2D‑Diagrammen überlappen (von -100 bis 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Den ShapeThumbnailBounds.Appearance‑Enum‑Wert hinzugefügt**
Diese Methode zur Erstellung von Form‑Thumbnails ermöglicht das Generieren eines Thumbnails innerhalb der Grenzen des Erscheinungsbildes der Form. Alle Form‑Effekte werden berücksichtigt. Das erzeugte Thumbnail ist durch die Folienränder begrenzt.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```