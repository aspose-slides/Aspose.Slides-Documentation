---
title: WordArt
type: docs
weight: 110
url: /zh/php-java/wordart/
---


## **关于 WordArt？**
WordArt 或 Word Art 是一个功能，允许您为文本应用效果，使其脱颖而出。例如，使用 WordArt，您可以给文本轮廓或填充颜色（或渐变），添加 3D 效果等。您还可以倾斜、弯曲和拉伸文本的形状。

{{% alert color="primary" %}} 

WordArt 允许您像对待图形对象一样处理文本。一般来说，WordArt 由对文本进行的效果或特殊修改组成，使其更具吸引力或显眼。

{{% /alert %}} 

**在 Microsoft PowerPoint 中使用 WordArt**

要在 Microsoft PowerPoint 中使用 WordArt，您必须选择一个预定义的 WordArt 模板。WordArt 模板是一组应用于文本或其形状的效果。

**在 Aspose.Slides 中使用 WordArt**

在 Aspose.Slides for PHP via Java 20.10 中，我们实现了对 WordArt 的支持，并在随后的 Aspose.Slides for PHP via Java 版本中对该功能进行了改进。

使用 Aspose.Slides for PHP via Java，您可以轻松创建自己的 WordArt 模板（一个效果或效果的组合）并将其应用于文本。

## 创建简单的 WordArt 模板并将其应用于文本

**使用 Aspose.Slides** 

首先，我们使用以下 PHP 代码创建一个简单的文本：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
现在，我们通过以下代码将文本的字体高度设置为更大的值，以使效果更明显：

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**使用 Microsoft PowerPoint**

在 Microsoft PowerPoint 中转到 WordArt 效果菜单：

![todo:image_alt_text](image-20200930113926-1.png)

在右侧菜单中，您可以选择一个预定义的 WordArt 效果。在左侧菜单中，您可以指定新 WordArt 的设置。

以下是一些可用的参数或选项：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

在这里，我们使用以下代码将 [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/PatternStyle#SmallGrid) 图案颜色应用于文本，并添加一个 1 像素宽的黑色文本边框：

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```

结果文本：

![todo:image_alt_text](image-20200930114108-4.png)

## 应用其他 WordArt 效果

**使用 Microsoft PowerPoint**

在程序的界面中，您可以将这些效果应用于文本、文本块、形状或类似元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，可以将阴影、反射和发光效果应用于文本；3D 格式和 3D 旋转效果可以应用于文本块；软边缘属性可以应用于形状对象（即使没有设置 3D 格式属性，它也仍然有效）。

### 应用阴影效果

在这里，我们旨在仅设置与文本相关的属性。我们使用以下代码将阴影效果应用于文本：

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);

```

Aspose.Slides API 支持三种类型的阴影：OuterShadow、InnerShadow 和 PresetShadow。

使用 PresetShadow，您可以为文本应用阴影（使用预设值）。

**使用 Microsoft PowerPoint**

在 PowerPoint 中，您可以使用一种类型的阴影。以下是一个示例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 实际上允许您一次应用两种类型的阴影：InnerShadow 和 PresetShadow。

**注意：**

- 当同时使用 OuterShadow 和 PresetShadow 时，仅应用 OuterShadow 效果。
- 如果同时使用 OuterShadow 和 InnerShadow，则所生成或应用的效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果会加倍。但在 PowerPoint 2007 中，应用的是 OuterShadow 效果。

### 向文本添加显示效果

我们通过以下代码示例向文本添加显示效果：

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);

```

### 向文本添加发光效果

我们使用以下代码将发光效果应用于文本，使其闪光或突出：

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);

```

操作结果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

您可以更改阴影、显示和发光的参数。效果的属性在文本的每个部分上单独设置。

{{% /alert %}} 

### 在 WordArt 中使用变换

我们使用此代码通过 Transform 属性（固有于整块文本）：

```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);

```

结果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint 和 Aspose.Slides for PHP via Java 都提供一定数量的预定义变换类型。

{{% /alert %}} 

**使用 PowerPoint**

要访问预定义变换类型，请通过：**格式** -> **文本效果** -> **变换**

**使用 Aspose.Slides**

要选择变换类型，请使用 TextShapeType 枚举。

### 向文本和形状应用 3D 效果

我们使用以下示例代码为文本形状设置 3D 效果：

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

```

结果文本及其形状：

![todo:image_alt_text](image-20200930114816-9.png)

我们使用以下 PHP 代码为文本应用 3D 效果：

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

```

操作结果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

将 3D 效果应用于文本或其形状以及效果之间的交互基于某些规则。

考虑一个文本的场景和包含该文本的形状。3D 效果包含 3D 对象表示和放置对象的场景。

- 当图形和文本都设置了场景时，图形场景具有更高的优先级——文本场景被忽略。
- 当图形没有自己的场景但有 3D 表示时，使用文本场景。
- 否则——当形状最初没有 3D 效果时——形状是平的，3D 效果仅应用于文本。

这些描述与 ThreeDFormat.getLightRig() 和 ThreeDFormat.getCamera() 方法相关。

{{% /alert %}} 

## **将外阴影效果应用于文本**
Aspose.Slides for PHP via Java 提供 [**IOuterShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IOuterShadow) 和 [**IInnerShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IInnerShadow) 类，允许您将阴影效果应用于由 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) 承载的文本。请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
2. 使用索引获取幻灯片的引用。
3. 向幻灯片添加一个矩形类型的 AutoShape。
4. 访问与 AutoShape 关联的 TextFrame。
5. 将 AutoShape 的 FillType 设置为 NoFill。
6. 实例化 OuterShadow 类
7. 设置阴影的 BlurRadius。
8. 设置阴影的 Direction。
9. 设置阴影的 Distance。
10. 将 RectanglelAlign 设置为 TopLeft。
11. 将阴影的 PresetColor 设置为 Black。
12. 将演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

此示例代码——上述步骤的实现——显示了如何将外阴影效果应用于文本：

```php
  $pres = new Presentation();
  try {
    # 获取幻灯片的引用
    $sld = $pres->getSlides()->get_Item(0);
    # 添加一个矩形类型的 AutoShape
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # 向矩形添加 TextFrame
    $ashp->addTextFrame("Aspose TextBox");
    # 禁用形状填充以获取文本阴影
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 添加外阴影并设置所有必要参数
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # 将演示文稿写入磁盘
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **将内阴影效果应用于形状**
请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
2. 获取幻灯片的引用。
3. 添加一个矩形类型的 AutoShape。
4. 启用 InnerShadowEffect。
5. 设置所有必要参数。
6. 将 ColorType 设置为 Scheme。
7. 设置方案颜色。
8. 将演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

此示例代码（基于上述步骤）显示了如何在两个形状之间添加连接器：

```php
  $pres = new Presentation();
  try {
    # 获取幻灯片的引用
    $slide = $pres->getSlides()->get_Item(0);
    # 添加一个矩形类型的 AutoShape
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 向矩形添加 TextFrame
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # 启用 InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # 设置所有必要参数
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # 将 ColorType 设置为 Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # 设置方案颜色
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # 保存演示文稿
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```