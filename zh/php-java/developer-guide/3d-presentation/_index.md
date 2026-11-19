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
- 3D 挤出
- 3D 渐变
- 3D 文本
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 为 PowerPoint 形状和文本应用并渲染 3D 效果。配置相机、灯光、材质、挤出、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for PHP via Java 可以创建、编辑、保留并渲染 PowerPoint 样式的形状和文本的 3D 格式。本指南涵盖旋转、挤出、倒角、灯光、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="Note" %}}
本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果，而不是插入或编辑独立的 3D 模型文件。当将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) 方法为形状应用 3D 格式。该方法返回 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/)，用于控制该形状的 3D 场景。

对于文本，使用 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) 方法。这会对文本框而不是形状本体应用 3D 格式。

最重要的 API 成员如下：

| API 成员 | 控制内容 | 何时使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | 灯光预设、方向和灯光旋转。 | 更改 3D 表面上高光和阴影的显示方式。 |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) 和 [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | 表面材质，如平面、哑光、塑料或金属。 | 让相同几何形状看起来更扁平、柔和、有光泽或金属感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) 和 [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | 形状从前表面向后延伸的距离。 | 将平面形状变成可见厚度的 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | 挤出侧面的颜色。 | 使深度可见或将侧面颜色与前填充协调。 |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) 和 [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式使用的附加深度。 | 对形状或文本进行细微深度调节，尤其与倒角和材质设置共同使用时。 |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | 前后表面的提升或圆角边缘。 | 添加柔化或成型的边缘，而不是锐利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) 、 [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) 和 [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | 3D 对象的轮廓线。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状在看起来逼真的 3D 效果之前，通常需要四类设置：

- 相机设置，因为默认的正面视图可能隐藏挤出效果。
- 灯光设置，因为光照使各面和侧面可辨识。
- 材质设置，因为表面影响光线的渲染方式。
- 挤出或深度设置，因为平面形状需要厚度。

下面的示例创建一个矩形，在其正面添加文本，并应用 3D 格式。相机旋转值以度为单位，挤出高度为 100 点。示例将幻灯片渲染为 PNG 图像（尺寸为默认的两倍），并将演示文稿保存为 PPTX。

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

渲染后的幻灯片图像显示该矩形是一个厚实的 3D 块：

![渲染的蓝色 3D 矩形，正面带有白色 3D 文本](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转通过 “3-D 旋转” 面板配置。X、Y、Z 旋转值对应于通过相机 API 设置的旋转。

![PowerPoint 3-D 旋转面板，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) 访问相机。以下示例创建一个矩形，选择正投影视图，并将其 X、Y、Z 旋转分别设置为 20、30、40 度。它在内存中配置形状而不保存文件：

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

当需要改变查看者看到对象的方式时使用相机。它不会改变幻灯片上 2D 形状的几何形状，只会改变 PowerPoint 和 Aspose.Slides 渲染时使用的 3D 视点。

### **从模板形状复制相机方向**

要匹配模板形状的方向，使用 [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) 读取其相机预设，并使用 [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation) 读取旋转角度。示例打开 `template.pptx`，并将第一张幻灯片上第一个形状的相机方向复制到第二个形状。两个形状已经具有 3D 灯光，第二个形状没有显式的相机旋转。

角度以度为单位。索引 `0` 为纬度，索引 `1` 为经度，索引 `2` 为旋转。按该顺序传递给 [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation)。如果源返回 `null`，则表示没有显式旋转，保持第二个形状的角度未设置。显式的 `(0, 0, 0)` 旋转会返回三个零，应当被复制。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在 PowerPoint 中重新打开 `camera-copy.pptx`，右侧的箭头与左侧的矩形拥有相同的相机预设和旋转。两个形状使用相同的灯光和挤出深度。

![一个蓝色 3D 矩形和一个右箭头，具有匹配的相机方向，从上方和右侧观看](camera-orientation.png)

## **添加挤出和深度**

挤出通过在前表面后方延伸形状来产生厚度。在 PowerPoint 中，深度控制设置可见的厚度，颜色控制侧面的颜色。

![PowerPoint 深度控制映射到挤出颜色和挤出高度属性](img_02_02.png)

使用 [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) 设置厚度，使用 [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) 获取侧面颜色。以下示例为矩形设置 100 点的紫色侧面挤出，并旋转相机以显示其厚度。它在内存中配置形状而不保存文件：

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

[ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) 方法设置 3D 形状的深度。[setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) 方法控制挤出效果的高度，如本示例所示。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。您可以对前表面使用纯色、渐变、图案或图片填充，同时保持相同的相机、灯光、材质和挤出设置。

以下示例对前表面应用蓝到橙的渐变，对 150 点的挤出使用深橙色。渐变停止点 0 和 100 分别标记渐变的开始和结束。相机旋转值以度为单位。幻灯片渲染为 PNG 图像（尺寸为默认的两倍）：

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

渲染输出保持前表面的渐变，并单独渲染挤出侧面：

![渲染的 3D 矩形，前表面为蓝到橙的渐变填充，侧面为橙色挤出](img_02_03.png)

如果要使用图片填充，请将图像添加到演示文稿并分配给形状填充。此示例需要工作目录中已有名为 “image.jpg” 的文件。它将图片拉伸填满矩形，应用 150 点的挤出，并以度为单位设置相机旋转。它在内存中配置形状而不保存或渲染文件：

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

图片在前表面渲染，挤出则渲染为 3D 侧面表面：

![渲染的 3D 矩形，前表面为照片填充，侧面为橙色挤出](img_02_04.png)

## **将 3D 格式应用于文本**

形状的 3D 格式影响形状本体，文本的 3D 格式影响文本框。这对于类似 WordArt 的效果很有用，需要对文字本身进行挤出、材质、灯光和相机设置。

以下示例创建带有橙白网格图案的文字，应用向上拱形，并通过 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) 配置 3D 设置。挤出高度和深度以点为单位，灯光旋转以度为单位。形状填充和轮廓被隐藏，仅显示文字。示例将 PNG 图像渲染为默认幻灯片尺寸的两倍，并将演示文稿保存为 PPTX：

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

文本以弧形、挤出的 3D 字体呈现：

![渲染的 3D 文本，带有拱形 WordArt 变换、橙色图案填充和深色挤出](img_02_05.png)

## **在 3D 形状上保持文本平面**

要在保持形状的 3D 外观的同时让文字易读，请通过 [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat) 调用 [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat)。当值为 `true` 时，文字保持在 3D 场景之外；为 `false` 时，文字参与场景并遵循其 3D 方向。

此设置不会移除形状的 3D 格式：相机、灯光、材质和挤出仍通过 [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) 配置。它也不同于普通旋转。[Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) 在幻灯片平面内旋转形状，而 [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) 控制文本在其边界框内的自定义旋转。保持文字在 3D 场景之外不会重置上述任一角度。

以下完整示例创建一个带文字的蓝色矩形，并在原始旁边克隆一份。两个形状拥有相同的 3D 格式，唯一区别在于文字设置：左侧为 `false`，右侧为 `true`。相机角度以度为单位，挤出高度为 40 点。示例将演示文稿保存为 PPTX，并将比较幻灯片渲染为 PNG（尺寸为默认的两倍）。

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

左侧文字遵循 3D 方向；右侧文字保持平面，更易阅读。两个矩形的可见挤出和 3D 方向保持一致。

![并排的 3D 矩形：左侧文字遵循 3D 方向，右侧文字保持平面](keep_text_flat.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式。渲染或导出为固定布局格式时，3D 场景会被光栅化或绘制为 2D 结果。这适用于将幻灯片渲染为 [PNG](/slides/zh/php-java/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/php-java/convert-powerpoint-to-html/)，或生成用于 [video conversion](/slides/zh/php-java/convert-powerpoint-to-video/) 的帧。

请注意以下要点：

- 导出的图像和 PDF 不是交互式的，导出后对象无法被观看者旋转。
- 最终外观取决于相机、灯光装置、材质、挤出、填充和幻灯片缩放的组合。
- 若需检查继承或基于主题的格式值，请读取 [effective shape properties](/slides/zh/php-java/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式。在这些格式中，视觉结果是渲染后的，而不是可编辑的 3D 设置。

## **常见问题**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 创建并渲染 PowerPoint 形状和文本的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为可交互的 3D 场景，观看者无法旋转。在 PPTX 中，3D 格式在 PowerPoint 支持的情况下仍保持可编辑。

**3D 模型与 3D 效果有什么区别？**

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式，如旋转、挤出、倒角、灯光和材质。本文讨论的是 3D 效果。

**要让 3D 形状可见，需要哪些设置？**

至少需要设置相机旋转以及挤出或深度。实际使用时，还应设置灯光装置和材质，以便渲染出的面具有清晰的高光和阴影。

**我可以同时对形状和文本应用 3D 效果吗？**

可以。对形状本体使用 [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat)，对文本使用 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat)。

**导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF 输出、HTML 输出以及用于视频转换的帧时，会渲染 3D 效果。导出的文件包含渲染后的外观，而不是可编辑的 3D 对象。

**我可以在继承和主题设置应用后读取最终的 3D 值吗？**

可以。使用在 [Shape Effective Properties](/slides/zh/php-java/shape-effective-properties/) 中描述的有效格式化 API，读取最终的相机、灯光装置、倒角及相关 3D 值。