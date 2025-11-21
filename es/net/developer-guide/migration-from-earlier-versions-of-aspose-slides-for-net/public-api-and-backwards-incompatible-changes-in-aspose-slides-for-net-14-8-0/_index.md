---
title: API pública y cambios incompatibles con versiones anteriores en Aspose.Slides para .NET 14.8.0
linktitle: Aspose.Slides para .NET 14.8.0
type: docs
weight: 100
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revisa las actualizaciones de la API pública y los cambios disruptivos en Aspose.Slides para .NET para migrar sin problemas tus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todos los [agregados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) clases, métodos, propiedades y demás, y otros cambios introducidos con la API de Aspose.Slides para .NET 14.8.0.

{{% /alert %}} 
## **Cambios en la API pública**
### **Propiedades modificadas**
#### **Añadida la interfaz IVbaProject, Cambiada la propiedad Presentation.VbaProject**
La propiedad VbaProject de la clase Presentation ha sido reemplazada. En lugar de la representación en bytes cruda del proyecto VBA, se ha añadido la nueva implementación de la interfaz IVbaProject.

Utilice la propiedad IVbaProject para gestionar proyectos VBA incrustados en una presentación. Puede agregar nuevas referencias de proyecto, editar módulos existentes y crear nuevos.

También puede crear un nuevo proyecto VBA utilizando la clase VbaProject que implementa la interfaz IVbaProject.

El siguiente ejemplo muestra la creación de un proyecto VBA sencillo que contiene un módulo y agrega dos referencias requeridas a las bibliotecas.

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

Este ejemplo muestra cómo copiar un proyecto VBA de una presentación existente a una nueva.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Interfaces, propiedades y opciones de enumeración añadidas**
#### **Añadida la propiedad Aspose.Slides.Charts.IChartSeries.Overlap**
La propiedad Aspose.Slides.Charts.IChartSeries.Overlap especifica cuánto se superponen las barras y columnas en los gráficos 2D (rango de -100 a 100).

Esta es la propiedad no solo de esta serie sino de todas las series en el grupo de series padre; es una proyección de la propiedad del grupo correspondiente. Por lo tanto, esta propiedad es de solo lectura.

- Utilice la propiedad ParentSeriesGroup para acceder al grupo de series padre.
- Utilice la propiedad ParentSeriesGroup.Overlap de lectura/escritura para cambiar el valor.

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
#### **Añadida la propiedad Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
La propiedad Aspose.Slides.Charts.IChartSeriesGroup.Overlap especifica cuánto se superponen las barras y columnas en los gráficos 2D (de -100 a 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Añadido el valor de enumeración ShapeThumbnailBounds.Appearance**
Este método de creación de miniaturas de forma le permite generar una miniatura de forma dentro de los límites de su apariencia. Tiene en cuenta todos los efectos de la forma. La miniatura generada está restringida por los límites de la diapositiva.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```