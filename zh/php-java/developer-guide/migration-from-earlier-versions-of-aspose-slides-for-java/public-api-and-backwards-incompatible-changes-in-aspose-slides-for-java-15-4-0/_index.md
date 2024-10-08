---
title: Aspose.Slides for PHP via Java 15.4.0 中的公共 API 和向后不兼容更改
type: docs
weight: 120
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

此页面列出了 Aspose.Slides for PHP via Java 15.4.0 API 中所有 [添加的](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) 类、方法、属性等，以及任何新限制和其他 [更改](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)。

{{% /alert %}} 
## **公共 API 更改**
### **已添加 Enum OrganizationChartLayoutType**
com.aspose.slides.OrganizationChartLayoutType 枚举表示组织图中子节点的格式类型。
### **已添加方法 IBulletFormat.applyDefaultParagraphIndentsShifts()**
方法 com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 设置启用项目符号时有效段落缩进和 MarginLeft 的默认非零偏移量（如果启用段落项目符号/编号，则如 PowerPoint 所做）。如果禁用项目符号，则仅重置段落缩进和 MarginLeft（如果禁用段落项目符号/编号，则如 PowerPoint 所做）。
### **已添加方法 IConnector.reroute()**
方法 com.aspose.slides.IConnector.reroute() 重新路由连接器，以使其在连接的形状之间采取尽可能最短的路径。为此，reroute() 方法可能会更改 StartShapeConnectionSiteIndex 和 EndShapeConnectionSiteIndex。

```php
  $input = new Presentation();
  $shapes = $input->getSlides()->get_Item(0)->getShapes();
  $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
  $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
  $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
  $connector->setStartShapeConnectedTo($ellipse);
  $connector->setEndShapeConnectedTo($rectangle);
  $connector->reroute();
  $input->save("output.pptx", SaveFormat::Pptx);

```
### **已添加方法 IPresentation.getSlideById(long)**
方法 Aspose.Slides.IPresentation.getSlideById(int) 根据幻灯片 ID 返回幻灯片、母版幻灯片或布局幻灯片。

```php
  $presentation = new Presentation();
  $id = $presentation->getSlides()->get_Item(0)->getSlideId();
  $slide = $presentation->getSlideById($id);

```
### **已添加方法 ISmartArt.getNodes()**
方法 com.aspose.slides.ISmartArt.getNodes() 返回 SmartArt 对象中根节点的集合。

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::VerticalBulletList);
  $node = $smart->getNodes()->get_Item(1);// 选择第二个根节点

  $node->getTextFrame()->setText("第二个根节点");
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **已添加方法 ISmartArt.setLayout(int)**
com.aspose.slides.ISmartArt.setLayout(int) 属性已添加。它允许更改现有图表的布局类型。

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $smart->setLayout(SmartArtLayoutType::BasicProcess);
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **已添加方法 ISmartArtNode.isHidden()**
方法 com.aspose.slides.ISmartArtNode.isHidden() 如果该节点在数据模型中为隐藏节点，则返回 true。

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
  $node = $smart->getAllNodes()->addNode();
  $hidden = $node->isHidden();// 返回 true

  if ($hidden) {
    # 执行某些操作或通知
  }
  $pres->Save("out.pptx", SaveFormat::Pptx);

```
### **已添加方法 ISmartArt.isReversed(), setReserved()**
属性 com.aspose.slides.ISmartArt.IsReversed 允许获取或设置 SmartArt 图表的状态，涉及到（从左到右）LTR 或（从右到左）RTL，如果图表支持反转。

```php
  $presentation = new Presentation();
  $smart = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
  $smart->setReversed(true);
  $presentation->save("out.pptx", SaveFormat::Pptx);

```
### **已添加方法 ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)**
方法 com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) 允许获取或设置与当前节点关联的组织图类型。

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
  $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **已添加属性 IShape.getConnectionSiteCount()**
属性 com.aspose.slides.getConnectionSiteCount() 返回形状上的连接点数量。

```php
  $input = new Presentation();
  $shapes = $input->getSlides()->get_Item(0)->getShapes();
  $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
  $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
  $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);
  $connector->setStartShapeConnectedTo($ellipse);
  $connector->setEndShapeConnectedTo($rectangle);
  $wantedIndex = 6;
  if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
    $connector->setStartShapeConnectionSiteIndex($wantedIndex);
  }
  $input->save("output.pptx", SaveFormat::Pptx);

```
### **次要更改**
这是次要 API 更改的列表：

|枚举 com.aspose.slides.BevelColorMode |删除，未使用的枚举 |
| :- | :- |
|方法 ThreeDFormatEffectiveData.getBevelColorMode() |删除，未使用的属性 |
|方法 com.aspose.slides.ChartSeriesGroup.getChart() |已添加 |
|接口 IParagraphFormatEffectiveData 从 ISlideComponent 继承 <br>接口 IThreeDFormat 从 ISlideComponent 继承 |删除 |
|方法 com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |作为过时而删除 |