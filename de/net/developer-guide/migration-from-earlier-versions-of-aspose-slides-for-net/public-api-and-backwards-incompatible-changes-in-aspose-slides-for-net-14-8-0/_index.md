---
title: Öffentliches API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 14.8.0
type: docs
weight: 100
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) Klassen, Methoden, Eigenschaften usw. sowie andere Änderungen auf, die mit der Aspose.Slides für .NET 14.8.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen in der öffentlichen API**
### **Geänderte Eigenschaften**
#### **IVbaProject-Interface hinzugefügt, Presentation.VbaProject-Eigenschaft geändert**
Die VbaProject-Eigenschaft der Presentation-Klasse wurde ersetzt. Anstelle der rohen Byte-Darstellung des VBA-Projekts durch die VbaProject-Eigenschaft wurde die neue Implementation des IVbaProject-Interfaces hinzugefügt.

Verwenden Sie die IVbaProject-Eigenschaft, um VBA-Projekte zu verwalten, die in einer Präsentation eingebettet sind. Sie können neue Projektverweise hinzufügen, vorhandene Module bearbeiten und neue erstellen.

Außerdem können Sie ein neues VBA-Projekt mit der VbaProject-Klasse erstellen, die das IVbaProject-Interface implementiert.

Das folgende Beispiel zeigt die Erstellung eines einfachen VBA-Projekts, das ein Modul enthält und zwei erforderliche Verweise auf die Bibliotheken hinzufügt.

``` csharp

 using (Presentation pres = new Presentation())

{

    // Neues VBA-Projekt erstellen

    pres.VbaProject = new VbaProject();

    // Leeres Modul zum VBA-Projekt hinzufügen

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Modul");

    // Quellcode des Moduls festlegen

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Referenz auf <stdole> erstellen

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Referenz auf Office erstellen

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Verweise zum VBA-Projekt hinzufügen

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

Dieses Beispiel zeigt, wie man ein VBA-Projekt von einer vorhandenen Präsentation in eine neue kopiert.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Hinzugefügte Interfaces, Eigenschaften und Enumerationsoptionen**
#### **Die Eigenschaft Aspose.Slides.Charts.IChartSeries.Overlap hinzugefügt**
Die Eigenschaft Aspose.Slides.Charts.IChartSeries.Overlap gibt an, wie viel sich Balken und Säulen in 2D-Diagrammen überschneiden sollen (von -100 bis 100).

Dies ist die Eigenschaft nicht nur dieser Serie, sondern aller Serien in der übergeordneten Seriengruppe - dies ist eine Projektion der entsprechenden Gruppen-Eigenschaft. Daher ist diese Eigenschaft schreibgeschützt.

- Verwenden Sie die Eigenschaft ParentSeriesGroup, um auf die übergeordnete Seriengruppe zuzugreifen.
- Verwenden Sie die lese-/schreibbare Eigenschaft ParentSeriesGroup.Overlap, um den Wert zu ändern.

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
#### **Die Eigenschaft Aspose.Slides.Charts.IChartSeriesGroup.Overlap hinzugefügt**
Die Eigenschaft Aspose.Slides.Charts.IChartSeriesGroup.Overlap gibt an, wie viel sich Balken und Säulen in 2D-Diagrammen überschneiden sollen (von -100 bis 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Enum-Wert ShapeThumbnailBounds.Appearance hinzugefügt**
Dieses Verfahren zur Erstellung von Form-Thumbs ermöglicht Ihnen die Generierung eines Form-Thumbs in den Grenzen ihres Erscheinungsbildes. Es berücksichtigt alle Formeffekte. Der generierte Form-Thumb ist durch die Foliengrenzen eingeschränkt.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

``` 