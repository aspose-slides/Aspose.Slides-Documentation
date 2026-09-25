---
title: 使用 PHP 在演示文稿中创建 3D 效果
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
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 为 PowerPoint 形状和文本应用并渲染 3D 效果。配置摄像机、光照、材质、拉伸、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for PHP via Java 可以创建、编辑、保留并渲染 PowerPoint 样式的形状和文本的 3D 格式化。本文章涵盖旋转、拉伸、斜角、光照、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="Note" %}}
本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果。它不涉及插入或编辑独立的 3D 模型文件。将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的二维输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [Shape::getThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getThreeDFormat--) 方法对形状应用 3D 格式化。该方法返回 [ThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/)，用于控制该形状的 3D 场景。

对于文本，使用 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#getThreeDFormat--) 方法。这会将 3D 格式化应用于文本框，而不是形状本体。

最重要的 API 成员如下：

| API 成员 | 它控制的内容 | 何时使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getCamera--) | 视点、预设摄像机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getLightRig--) | 灯光预设、方向和灯光旋转。 | 更改 3D 表面上高光和阴影的呈现方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getMaterial--) 和 [setMaterial](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setMaterial-byte-) | 表面材质，如平面、哑光、塑料或金属。 | 使相同的几何形状看起来更平整、柔软、光亮或金属感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getExtrusionHeight--) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | 形状从前表面向后延伸的距离。 | 将平面形状转换为可见的厚 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getExtrusionColor--) | 拉伸侧面的颜色。 | 使深度可见或使侧面颜色与前填充色协调。 |
| [getDepth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getDepth--) 和 [setDepth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setDepth-double-) | PowerPoint 3D 格式化使用的额外 3D 深度。 | 微调形状或文本的深度，尤其是与斜角和材质设置一起使用时。 |
| [getBevelTop](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getBevelBottom--) | 前后表面的凸起或圆形边缘。 | 添加柔和或成形的边缘，而不是尖锐的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getContourColor--)、[getContourWidth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getContourWidth--) 和 [setContourWidth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setContourWidth-double-) | 3D 对象的轮廓线。 | 在渲染输出中突出对象边界。 |

## **创建 3D 形状**

一个形状通常需要四类设置才能看起来逼真 3D：

- 摄像机设置，因为默认的前视图可能会隐藏拉伸效果。
- 灯光设置，因为光照使面和侧面可辨识。
- 材质设置，因为表面会影响光线的渲染方式。
- 拉伸或深度设置，因为平面形状需要厚度。

以下示例创建一个矩形，在其前面添加文本，并应用 3D 格式化。摄像机旋转值以度为单位，拉伸高度为 100 点。示例将幻灯片渲染为尺寸为默认两倍的 PNG 图像，并将演示文稿保存为 PPTX。

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

渲染后的幻灯片图像显示矩形为一个厚实的 3D 块：

![渲染的蓝色 3D 矩形，前面有白色 3D 文本](img_01_01.png)

## **使用摄像机旋转形状**

在 PowerPoint 中，3D 旋转通过“3-D 旋转”面板配置。X、Y、Z 旋转值对应于通过摄像机 API 设置的旋转。

![PowerPoint 3-D 旋转面板，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 [ThreeDFormat::getCamera](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getCamera--) 访问摄像机。此示例创建一个矩形，选择正交前视图，并分别将其 X、Y、Z 旋转设置为 20、30、40 度。它在内存中配置形状而不保存文件：

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

当需要改变观看者看到对象的方式时使用摄像机。它不会改变幻灯片上 2D 形状的几何形状，只会改变 PowerPoint 和 Aspose.Slides 在渲染时使用的 3D 视点。

## **添加拉伸和深度**

拉伸通过将形状延伸到前面之后，使其看起来更厚。 在 PowerPoint 中，深度控制设置可见的厚度，颜色控制设置侧面的颜色。

![PowerPoint 深度控制映射到拉伸颜色和拉伸高度属性](img_02_02.png)

使用 [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) 设置厚度，使用 [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getExtrusionColor--) 访问侧面颜色。此示例为矩形设置 100 点的拉伸，侧面为紫色，并旋转摄像机以显示其厚度。它在内存中配置形状而不保存文件：

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

[ThreeDFormat::setDepth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setDepth-double-) 方法设置 3D 形状的深度。 [setExtrusionHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) 方法控制拉伸效果的高度，如本例所示。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。您可以对前面应用纯色、渐变、图案或图片填充，同时仍使用相同的摄像机、灯光、材质和拉伸设置。

此示例对前面应用蓝到橙的渐变，对 150 点的拉伸使用深橙色。渐变在 0 和 100 处标记渐变的开始和结束。摄像机旋转值以度为单位。幻灯片渲染为尺寸为默认两倍的 PNG 图像：

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

渲染输出保留前面的渐变，并单独渲染拉伸效果：

![渲染的 3D 矩形，蓝到橙的渐变填充和橙色拉伸](img_02_03.png)

若改用图片填充，需将图像添加到演示文稿并分配给形状填充。此示例需要工作目录中存在名为 "image.jpg" 的文件。它将图片拉伸填满矩形，应用 150 点的拉伸，并以度为单位设置摄像机旋转。它在内存中配置形状而不保存或渲染文件：

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

图片在前面渲染，而拉伸在 3D 侧面渲染：

![渲染的 3D 矩形，前面为照片填充，橙色拉伸](img_02_04.png)

## **将 3D 格式化应用于文本**

形状的 3D 格式化影响形状本体。文本的 3D 格式化影响文本框。这对于类似 WordArt 的效果很有用，需要对字母本身进行拉伸、材质、光照和摄像机设置。

以下示例创建带有橙白网格图案的文本，应用向上拱形，并通过 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#getThreeDFormat--) 配置 3D 设置。拉伸高度和深度以点为单位，灯光旋转以度为单位。形状填充和轮廓被隐藏，仅显示文本。示例将 PNG 图像渲染为默认幻灯片尺寸的两倍，并将演示文稿保存为 PPTX：

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

文本被渲染为弯曲、拉伸的 3D 字体：

![渲染的 3D 文本，拱形 WordArt 变换，橙色图案填充，深色拉伸](img_02_05.png)

## **保持文本在 3D 形状上平面**

为了在保持形状 3D 外观的同时让文本可读，需通过 [TextFrame::getTextFrameFormat] 调用 [TextFrameFormat::setKeepTextFlat]。当值为 `true` 时，文本保持在 3D 场景之外；当为 `false` 时，文本参与场景并遵循其 3D 方向。

此设置不会移除形状的 3D 格式化：其摄像机、灯光、材质和拉伸仍通过 [Shape::getThreeDFormat] 配置。它也不同于普通旋转。[Shape::setRotation] 在幻灯片平面上旋转形状，而 [TextFrameFormat::setRotationAngle] 控制文本在其边界框内的自定义旋转。将文本保持在 3D 场景之外不会重置这两个角度中的任何一个。

下面的独立示例创建一个带文本的蓝色矩形，并在原始旁边克隆它。两个形状具有相同的 3D 格式化；唯一不同的是文本设置：左侧为 `false`，右侧为 `true`。摄像机角度以度为单位，拉伸高度为 40 点。示例将演示文稿保存为 PPTX，并将比较幻灯片渲染为默认尺寸的两倍 PNG。

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

左侧的文本遵循 3D 方向。右侧的文本保持平面，易于阅读。两个矩形保留相同的可见拉伸和 3D 方向。

![并排的 3D 矩形：左侧文本遵循 3D 方向，右侧文本保持平面](keep_text_flat.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。在渲染或导出为固定布局格式时，3D 场景会光栅化或绘制为 2D 输出。当您将幻灯片渲染为 [PNG](/slides/zh/php-java/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/php-java/convert-powerpoint-to-html/)，或为 [video conversion](/slides/zh/php-java/convert-powerpoint-to-video/) 生成帧时，均适用此规则。

请注意以下要点：

- 导出的图像和 PDF 不具交互性。导出后观众无法旋转对象。
- 最终外观取决于摄像机、灯光装置、材质、拉伸、填充和幻灯片缩放的组合。
- 如果需要检查继承或基于主题的格式化值，请阅读 [effective shape properties](/slides/zh/php-java/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果会被渲染，而不是以可编辑的 3D 设置形式保留。

## **FAQ**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 为形状和文本创建并渲染 PowerPoint 的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为观众可以旋转的交互式 3D 场景。在 PPTX 中，3D 格式化在 PowerPoint 中仍保持可编辑（前提是格式支持）。

**3D 模型与 3D 效果有什么区别？**

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、拉伸、斜角、光照和材质。本文讨论的是 3D 效果。

**可见的 3D 形状需要哪些设置？**

至少要设置摄像机旋转和拉伸或深度。实际使用时，还应设置灯光装置和材质，以便渲染的面具有清晰的高光和阴影。

**我可以将 3D 效果同时应用于形状和文本吗？**

可以。对形状本体使用 [Shape::getThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getThreeDFormat--)，对文本使用 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#getThreeDFormat--)。

**导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF 输出、HTML 输出以及用于视频转换的帧时会渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

**在应用继承和主题设置后，我可以读取最终的 3D 值吗？**

可以。使用在 [Shape Effective Properties](/slides/zh/php-java/shape-effective-properties/) 中描述的有效格式化 API，读取最终的摄像机、灯光装置、斜角和相关 3D 值。