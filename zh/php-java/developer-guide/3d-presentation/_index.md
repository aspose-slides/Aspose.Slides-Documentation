---
title: 在 PHP 中创建 3D 演示文稿
linktitle: 3D 演示文稿
type: docs
weight: 232
url: /zh/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 演示文稿
- 3D 旋转
- 3D 深度
- 3D 拉伸
- 3D 渐变
- 3D 文本
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中轻松生成交互式 3D 演示文稿。快速导出为 PowerPoint 和 OpenDocument 格式，以实现多用途使用。"
---

## **概览**
Since Aspose.Slides Java 20.9 its possible to create 3D in presentations. PowerPoint 3D is a way to give life to presentations. Show the real world objects 
with 3D presentation, demonstrate 3D model of your future business project, 3D model of the building or its interior, 3D model of the game character, 
or just a 3D representation of your data. 

PowerPoint 3D models can be created from 2D shapes, by applying such effects on them: 3D rotation, 3D depth and extrusion, 3D gradient, 3D text, etc. 
The list of 3D features applied to the shapes can be found in **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** class.
The instance of the class can be get by:
 
- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getThreeDFormat--)** method for creating a PowerPoint 3D Model.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** method for creating a 3D Text
(WordArt).

All effects implemented in **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** can be used for both shapes and text.
Let us have a quick look on the main methods of **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** class. In the next example
we create a rectangle 2D shape with a text on it. By getting camera view on the shape, we change its rotation and make looking as a 3D model. Setting a flat light 
and its direction to the top of the 3D model, bring more volume to the model. Changed materials, extrusion height and color make the 3D model look more alive.  
``` php 
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("sandbox_3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


Here is the resulting 3D model:

![todo:image_alt_text](img_01_01.png)

## **3D 旋转**
The rotation of 3D model in PowerPoint can be done via menu:

![todo:image_alt_text](img_02_01.png)

To rotate 3D model with Aspose.Slides API, use **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getCamera--)**
method, set the rotation of the camera relatively to 3D shape:
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
// ... 设置其他 3D 场景参数

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


## **3D 深度和拉伸**
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)**
and **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** methods
are used to create extrusion on shape:
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 128, 0, 128));
# ... 设置其他 3D 场景参数

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


In PowerPoint, Depth of the shape is set via:

![todo:image_alt_text](img_02_02.png)

## **3D 渐变**
3D gradient can bring more volume to PowerPoint 3D shape:
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getFillFormat()->setFillType(FillType::Gradient);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 255, 140, 0));

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->dispose();
```


效果如下：

![todo:image_alt_text](img_02_03.png)
  
You may also create an image gradient:
``` php
$shape->getFillFormat()->setFillType(FillType::Picture);

$image = Images->fromFile("image.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
# ... 设置 3D：shape.ThreeDFormat.Camera，shape.ThreeDFormat.LightRig，shape.ThreeDFormat.Extrusion* 属性

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```



Here is the result:

![todo:image_alt_text](img_02_04.png)

## **3D 文本 (WordArt)**
To create a 3D text (WordArt), do the following:
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getFillFormat()->setFillType(FillType::NoFill);
$shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
$shape->getTextFrame()->setText("3D Text");

$portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
$portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new java("java.awt.Color", 255, 140, 0));
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);
$textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
# 设置 "Arch Up" WordArt 变换效果
$textFrameFormat->setTransform(TextShapeType::ArchUp);

$textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
$textFrameFormat->getThreeDFormat()->setDepth(3);
$textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
$textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
$textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
$textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("text3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("text3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


Here is the result:

![todo:image_alt_text](img_02_05.png)

## **常见问题**

**导出演示文稿为图像/PDF/HTML 时，3D 效果会被保留吗？**

是的。Slides 的 3D 引擎在导出为支持的格式时会渲染 3D 效果（[图像](/slides/zh/php-java/convert-powerpoint-to-png/)，[PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)，[HTML](/slides/zh/php-java/convert-powerpoint-to-html/)，等）。

**我可以检索考虑主题、继承等因素的“有效”（最终）3D 参数值吗？**

是的。Slides 提供了用于[读取有效值](/slides/zh/php-java/shape-effective-properties/)的 API（包括 3D 的灯光、斜角等），因此您可以查看最终的应用设置。

**将演示文稿转换为视频时，3D 效果会正常工作吗？**

是的。当[为视频生成帧](/slides/zh/php-java/convert-powerpoint-to-video/)时，3D 效果的渲染方式与[导出图像](/slides/zh/php-java/convert-powerpoint-to-png/)时相同。