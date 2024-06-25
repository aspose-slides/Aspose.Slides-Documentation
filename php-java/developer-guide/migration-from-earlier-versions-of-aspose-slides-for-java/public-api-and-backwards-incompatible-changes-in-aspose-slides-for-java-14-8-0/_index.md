---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for PHP via Java 14.8.0
type: docs
weight: 70
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) classes, methods, properties and so on, any new restrictions and other [changes](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) introduced with the Aspose.Slides for PHP via Java 14.8.0 API.

{{% /alert %}} 
## **Public API Changes**
### **Added the Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap(), and setOverlap(byte) Mehtods**
The Aspose.Slides.Charts.IChartSeries.getOverlap() gets how much bars and columns should overlap on 2D charts (in a range from -100 to 100).
This method is not only for specific series but for all series of the parent series group - this is projection of the appropriate group property.

- Use IChartSeries.getParentSeriesGroup() method for accessing to parent series group.
- Use IChartSeriesGroup.getOverlap() and setOverlap(byte) methods to manage the value.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
  $series = $chart->getChartData()->getSeries();
  if ($series->get_Item(0)->getOverlap() == 0) {
    $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
  }
```
### **Added the ShapeThumbnailBounds.Appearance Enum Value**
This method of creating shape thumbnails allows developers to generate a shape thumbnail in the bounds of its appearance. It takes into account all shape effects. The generated shape thumbnail is restricted by the slide bounds.

```php
  $pres = new Presentation();
  $st = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail(ShapeThumbnailBounds->Appearance, 1, 1);

```
### **Added the VbaProject Class and IVbaProject Interface, Changed the Presentation.getVbaProject() and setVbaProject(VbaProject) Methods**
A new feature allows developers to create and edit VBA projects in a presentation.

```php
  $pres = new Presentation();
  // Create new VBA Project
  $pres->setVbaProject(new VbaProject());
  // Add empty module to the VBA project
  $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
  // Set module source code
  $module->setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");
  // Create reference to <stdole>
  $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
  // Create reference to Office
  $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
  // Add references to the VBA project
  $pres->getVbaProject()->getReferences()->add($stdoleReference);
  $pres->getVbaProject()->getReferences()->add($officeReference);
  $pres->save("data\\test.pptm", SaveFormat->Pptm);

```
