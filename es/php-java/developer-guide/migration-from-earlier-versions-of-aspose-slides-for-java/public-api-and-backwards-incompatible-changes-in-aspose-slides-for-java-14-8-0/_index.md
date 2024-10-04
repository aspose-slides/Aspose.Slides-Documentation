---
title: API Público y Cambios Incompatibles en Aspose.Slides para PHP a través de Java 14.8.0
type: docs
weight: 70
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/), métodos, propiedades, etc., cualquier nueva restricción y otros [cambios](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) introducidos con el API de Aspose.Slides para PHP a través de Java 14.8.0.

{{% /alert %}} 
## **Cambios en el API Público**
### **Añadidos los Métodos Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() y setOverlap(byte)**
El Aspose.Slides.Charts.IChartSeries.getOverlap() obtiene cuánto deben superponerse las barras y columnas en gráficos 2D (en un rango de -100 a 100).
Este método no es solo para series específicas, sino para todas las series del grupo de series padre; esta es la proyección de la propiedad del grupo adecuado.

- Utiliza el método IChartSeries.getParentSeriesGroup() para acceder al grupo de series padre.
- Utiliza los métodos IChartSeriesGroup.getOverlap() y setOverlap(byte) para gestionar el valor.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
  $series = $chart->getChartData()->getSeries();
  if (java_values($series->get_Item(0)->getOverlap()) == 0) {
    $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
  }
```
### **Añadido el Valor de Enum ShapeThumbnailBounds.Appearance**
Este método de crear miniaturas de formas permite a los desarrolladores generar una miniatura de forma dentro de los límites de su apariencia. Toma en cuenta todos los efectos de la forma. La miniatura de la forma generada está restringida por los límites de la diapositiva.

```php
  $pres = new Presentation();
  $st = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail(ShapeThumbnailBounds->Appearance, 1, 1);
```
### **Añadida la Clase VbaProject y la Interfaz IVbaProject, Cambiados los Métodos Presentation.getVbaProject() y setVbaProject(VbaProject)**
Una nueva característica permite a los desarrolladores crear y editar proyectos VBA en una presentación.

```php
  $pres = new Presentation();
  # Crear nuevo proyecto VBA
  $pres->setVbaProject(new VbaProject());
  # Añadir módulo vacío al proyecto VBA
  $module = $pres->getVbaProject()->getModules()->addEmptyModule("Módulo");
  # Establecer el código fuente del módulo
  $module->setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");
  # Crear referencia a <stdole>
  $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
  # Crear referencia a Office
  $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
  # Añadir referencias al proyecto VBA
  $pres->getVbaProject()->getReferences()->add($stdoleReference);
  $pres->getVbaProject()->getReferences()->add($officeReference);
  $pres->save("data\\test.pptm", SaveFormat::Pptm);
```