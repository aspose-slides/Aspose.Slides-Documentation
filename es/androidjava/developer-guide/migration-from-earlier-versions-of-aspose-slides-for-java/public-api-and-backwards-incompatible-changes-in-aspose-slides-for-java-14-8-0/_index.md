---
title: API Público y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para Java 14.8.0
type: docs
weight: 70
url: /es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/), métodos, propiedades, y así sucesivamente, cualquier nueva restricción y otros [cambios](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) introducidos con la API de Aspose.Slides para Java 14.8.0.

{{% /alert %}} 
## **Cambios en la API Pública**
### **Añadidos los Métodos Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap(), y setOverlap(byte)**
El método Aspose.Slides.Charts.IChartSeries.getOverlap() determina cuánto deben superponerse las barras y columnas en gráficos 2D (en un rango de -100 a 100).
Este método no es solo para series específicas, sino para todas las series del grupo de series padre; esta es la proyección de la propiedad correspondiente del grupo.

- Utilice el método IChartSeries.getParentSeriesGroup() para acceder al grupo de series padre.
- Utilice los métodos IChartSeriesGroup.getOverlap() y setOverlap(byte) para gestionar el valor.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **Añadido el Valor Enum ShapeThumbnailBounds.Appearance**
Este método de creación de miniaturas de formas permite a los desarrolladores generar una miniatura de forma en los límites de su apariencia. Tiene en cuenta todos los efectos de la forma. La miniatura de forma generada está restringida por los límites de la diapositiva.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Añadida la Clase VbaProject y la Interfaz IVbaProject, Cambiados los Métodos Presentation.getVbaProject() y setVbaProject(VbaProject)**
Una nueva característica permite a los desarrolladores crear y editar proyectos VBA en una presentación.

``` java

 Presentation pres = new Presentation();

// Crear nuevo proyecto VBA

pres.setVbaProject(new VbaProject());

// Agregar módulo vacío al proyecto VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Módulo");

// Establecer el código fuente del módulo

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Crear referencia a <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Crear referencia a Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Agregar referencias al proyecto VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```