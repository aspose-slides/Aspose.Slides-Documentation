---
title: Cambios en la API pública y cambios incompatibles hacia atrás en Aspose.Slides para Java 14.8.0
linktitle: Aspose.Slides para Java 14.8.0
type: docs
weight: 70
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revisa las actualizaciones de la API pública y los cambios disruptivos en Aspose.Slides para Java para migrar sin problemas tus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las [añadidos](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) clases, métodos, propiedades, etc., cualquier nueva restricción y otros [cambios](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) introducidos con la API de Aspose.Slides para Java 14.8.0.

{{% /alert %}} 
## **Cambios en la API pública**
### **Añadidos los métodos Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() y setOverlap(byte)**
El método Aspose.Slides.Charts.IChartSeries.getOverlap() obtiene cuánto deben superponerse las barras y columnas en gráficos 2D (en un rango de -100 a 100).  
Este método no es solo para una serie específica, sino para todas las series del grupo de series padre: es la proyección de la propiedad correspondiente del grupo.

- Utilice el método IChartSeries.getParentSeriesGroup() para acceder al grupo de series padre.  
- Utilice los métodos IChartSeriesGroup.getOverlap() y setOverlap(byte) para gestionar el valor.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Añadido el valor de enumeración ShapeThumbnailBounds.Appearance**
Este método de creación de miniaturas de forma permite a los desarrolladores generar una miniatura de forma dentro de los límites de su apariencia. Tiene en cuenta todos los efectos de la forma. La miniatura generada está limitada por los límites de la diapositiva.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Añadidas la clase VbaProject y la interfaz IVbaProject, modificados los métodos Presentation.getVbaProject() y setVbaProject(VbaProject)**
Una nueva característica permite a los desarrolladores crear y editar proyectos VBA en una presentación.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Crear nuevo proyecto VBA

pres.setVbaProject(new VbaProject());

// Añadir módulo vacío al proyecto VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

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

// Añadir referencias al proyecto VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);
```