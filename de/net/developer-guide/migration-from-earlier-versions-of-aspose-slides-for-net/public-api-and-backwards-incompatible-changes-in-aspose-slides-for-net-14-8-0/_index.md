---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 14.8.0
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
description: "Überblick über öffentliche API-Updates und breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint-PPT, PPTX- und ODP-Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit Aspose.Slides for .NET 14.8.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **Geänderte Eigenschaften**
#### **Hinzugefügtes IVbaProject-Interface, geänderte Presentation.VbaProject-Eigenschaft**
Die VbaProject‑Eigenschaft der Klasse Presentation wurde ersetzt. Anstelle der rohen Byte‑Darstellung des VBA‑Projekts wurde die neue IVbaProject‑Schnittstellen‑Implementierung hinzugefügt.

Verwenden Sie die IVbaProject‑Eigenschaft, um in einer Präsentation eingebettete VBA‑Projekte zu verwalten. Sie können neue Projekt‑Referenzen hinzufügen, bestehende Module bearbeiten und neue erstellen.

Außerdem können Sie ein neues VBA‑Projekt mit der VbaProject‑Klasse erzeugen, die das IVbaProject‑Interface implementiert.

Das folgende Beispiel zeigt die Erstellung eines einfachen VBA‑Projekts mit einem Modul und dem Hinzufügen zweier erforderlicher Bibliotheks‑Referenzen.

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
### **Hinzugefügte Schnittstellen, Eigenschaften und Aufzählungsoptionen**
#### **Hinzugefügte Aspose.Slides.Charts.IChartSeries.Overlap‑Eigenschaft**
Die Aspose.Slides.Charts.IChartSeries.Overlap‑Eigenschaft gibt an, wie stark Balken und Säulen in 2D‑Diagrammen überlappen sollen (von –100 bis 100).

Dies ist nicht nur die Eigenschaft dieser Serie, sondern aller Serien in der übergeordneten Seriengruppe – es handelt sich um eine Projektion der entsprechenden Gruppeneigenschaft. Diese Eigenschaft ist daher schreibgeschützt.

- Verwenden Sie die ParentSeriesGroup‑Eigenschaft, um auf die übergeordnete Seriengruppe zuzugreifen.
- Verwenden Sie die ParentSeriesGroup.Overlap‑Lese‑/Schreib‑Eigenschaft, um den Wert zu ändern.

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
#### **Hinzugefügte Aspose.Slides.Charts.IChartSeriesGroup.Overlap‑Eigenschaft**
Die Aspose.Slides.Charts.IChartSeriesGroup.Overlap‑Eigenschaft gibt an, wie stark Balken und Säulen in 2D‑Diagrammen überlappen sollen (von –100 bis 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Hinzugefügter ShapeThumbnailBounds.Appearance‑Enum‑Wert**
Diese Methode zur Erstellung von Shape‑Thumbnails ermöglicht es, ein Thumbnail im Rahmen des Erscheinungsbildes der Form zu erzeugen. Alle Form‑Effekte werden berücksichtigt. Das erzeugte Thumbnail wird durch die Folienrandbegrenzung eingeschränkt.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```