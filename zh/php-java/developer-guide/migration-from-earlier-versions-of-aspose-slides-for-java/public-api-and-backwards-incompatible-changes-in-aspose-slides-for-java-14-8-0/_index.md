---
title: Aspose.Slides for PHP via Java 14.8.0 中的公共 API 和向后不兼容的更改
type: docs
weight: 70
url: /zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for PHP via Java 14.8.0 API 中引入的[添加](/slides/zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/)的类、方法、属性等，任何新的限制和其他[更改](/slides/zh/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/)。

{{% /alert %}} 
## **公共 API 更改**
### **添加了 Aspose.Slides.Charts.IChartSeries.getOverlap()、IChartSeriesGroup.getOverlap() 和 setOverlap(byte) 方法**
Aspose.Slides.Charts.IChartSeries.getOverlap() 获取在 2D 图表中条形和列的重叠程度（范围从 -100 到 100）。
此方法不仅适用于特定系列，还适用于父系列组的所有系列 - 这是相应组属性的投影。

- 使用 IChartSeries.getParentSeriesGroup() 方法访问父系列组。
- 使用 IChartSeriesGroup.getOverlap() 和 setOverlap(byte) 方法管理值。

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
  $series = $chart->getChartData()->getSeries();
  if (java_values($series->get_Item(0)->getOverlap()) == 0) {
    $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
  }
```
### **添加了 ShapeThumbnailBounds.Appearance 枚举值**
此创建形状缩略图的方法允许开发人员在其外观的边界内生成形状缩略图。它考虑了所有形状效果。生成的形状缩略图受到幻灯片边界的限制。

```php
  $pres = new Presentation();
  $st = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail(ShapeThumbnailBounds->Appearance, 1, 1);
```
### **添加了 VbaProject 类和 IVbaProject 接口，修改了 Presentation.getVbaProject() 和 setVbaProject(VbaProject) 方法**
一个新特性允许开发人员在演示文稿中创建和编辑 VBA 项目。

```php
  $pres = new Presentation();
  # 创建新的 VBA 项目
  $pres->setVbaProject(new VbaProject());
  # 向 VBA 项目添加空模块
  $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
  # 设置模块源代码
  $module->setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");
  # 创建对 <stdole> 的引用
  $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
  # 创建对 Office 的引用
  $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
  # 向 VBA 项目添加引用
  $pres->getVbaProject()->getReferences()->add($stdoleReference);
  $pres->getVbaProject()->getReferences()->add($officeReference);
  $pres->save("data\\test.pptm", SaveFormat::Pptm);

```