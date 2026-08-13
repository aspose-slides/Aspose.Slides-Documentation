---
title: Cambios en la API pública e incompatibilidades retroactivas en Aspose.Slides para .NET 14.8.0
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
description: "Revise las actualizaciones de la API pública y los cambios disruptivos en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las [añadidas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) o [eliminadas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) clases, métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides para .NET 14.8.0.

{{% /alert %}} 
## **Cambios en la API pública**
### **Propiedades modificadas**
#### **Se añadió la interfaz IVbaProject, se modificó la propiedad Presentation.VbaProject**
La propiedad VbaProject de la clase Presentation ha sido reemplazada. En lugar de la representación en bytes sin procesar del proyecto VBA, se ha añadido la nueva implementación de la interfaz IVbaProject.

Utilice la propiedad IVbaProject para gestionar los proyectos VBA incrustados en una presentación. Puede añadir nuevas referencias de proyecto, editar módulos existentes y crear nuevos.

También puede crear un nuevo proyecto VBA usando la clase VbaProject, que implementa la interfaz IVbaProject.

El siguiente ejemplo muestra la creación de un proyecto VBA simple que contiene un módulo y agrega dos referencias necesarias a las bibliotecas.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // Crear nuevo proyecto VBA
    pres.VbaProject = new VbaProject();
    // Añadir módulo vacío al proyecto VBA
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");
    // Establecer el código fuente del módulo
    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Crear referencia a <stdole>
    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Crear referencia a Office
    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Añadir referencias al proyecto VBA
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);
    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Este ejemplo muestra cómo copiar un proyecto VBA de una presentación existente a una nueva.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Se añadieron interfaces, propiedades y opciones de enumeración**
#### **Se añadió la propiedad Aspose.Slides.Charts.IChartSeries.Overlap**
La propiedad Aspose.Slides.Charts.IChartSeries.Overlap especifica cuánto deben superponerse las barras y columnas en los gráficos 2D (con un rango de -100 a 100).

Esta propiedad no solo corresponde a esta serie, sino a todas las series del grupo de series principal; es una proyección de la propiedad correspondiente del grupo. Por lo tanto, esta propiedad es de solo lectura.

- Utilice la propiedad ParentSeriesGroup para acceder al grupo de series principal.
- Utilice la propiedad ParentSeriesGroup.Overlap de lectura/escritura para cambiar el valor.

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
#### **Se añadió la propiedad Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
La propiedad Aspose.Slides.Charts.IChartSeriesGroup.Overlap especifica cuánto deben superponerse las barras y columnas en los gráficos 2D (de -100 a 100).

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
#### **Se añadió el valor de enumeración ShapeThumbnailBounds.Appearance**
Este método de creación de miniaturas de forma le permite generar una miniatura de la forma dentro de los límites de su apariencia. Tiene en cuenta todos los efectos de la forma. La miniatura generada está limitada por los límites de la diapositiva.

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