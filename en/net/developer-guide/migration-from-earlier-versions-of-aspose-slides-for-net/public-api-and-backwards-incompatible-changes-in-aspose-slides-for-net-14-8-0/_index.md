---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 14.8.0
type: docs
weight: 100
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 14.8.0 API.

{{% /alert %}} 
## **Public API Changes**
### **Changed Properties**
#### **Added the IVbaProject Interface, Changed the Presentation.VbaProject Property**
The Presentation class' VbaProject property has been replaced. Instead of h3. Added Interfaces, Properties and Enumeration Options
the VbaProject property's raw byte representation of VBA project, the new IVbaProject interface implementation has been added.

Use the IVbaProject property to manage VBA projects embedded in a presentation. You can add new project references, edit existing modules and create new ones.

Also, you can create a new VBA project using the VbaProject class which implements the IVbaProject interface.

The following example shows the creation of a simple VBA project containing one module and adding two required references to the libraries.

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

This example shows how to copy a VBA project from an existing presentation to a new one.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Added Interfaces, Properties and Enumeration Options**
#### **Added the Aspose.Slides.Charts.IChartSeries.Overlap Property**
The Aspose.Slides.Charts.IChartSeries.Overlap property specifies how much bars and columns shall overlap on 2D charts (ranging from -100 to 100).

This is the property not only of this series but of all series in the parent series group - this is a projection of the appropriate group property. And so this property is read-only.

- Use the ParentSeriesGroup property to access the parent series group.
- Use the ParentSeriesGroup.Overlap read/write property to change value.

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
#### **Added the Aspose.Slides.Charts.IChartSeriesGroup.Overlap Property**
The Aspose.Slides.Charts.IChartSeriesGroup.Overlap property specifies how much bars and columns should overlap on 2D charts (from -100 to 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Added the ShapeThumbnailBounds.Appearance Enum Value**
This method of shape thumbnail creation allows you to generate a shape thumbnail in the bounds of its appearance. It takes into account all shape effects. The generated shape thumbnail is restricted by slide bounds.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

``` 
