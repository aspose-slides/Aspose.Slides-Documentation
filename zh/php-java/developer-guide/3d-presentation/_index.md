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
- 3D 挤压
- 3D 渐变
- 3D 文本
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 为 PowerPoint 形状和文本应用并渲染 3D 效果。配置相机、光照、材质、挤压、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for PHP via Java 可以创建、编辑、保留并渲染类似 PowerPoint 的形状和文本的 3D 格式化。本篇文章涵盖旋转、挤压、斜角、光照、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="primary" %}}
本文介绍的是 PowerPoint 形状和文本的 3D 格式化效果，不涉及插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/) 类及其 [Shape::getThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getThreeDFormat--) 方法对形状应用 3D 格式化。该方法返回 [ThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/)，用于控制该形状的 3D 场景。

对于文本，使用 [TextFrameFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/) 类及其 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#getThreeDFormat--) 方法。这会将 3D 格式化应用于文本框，而非形状本体。

最重要的设置包括：

| 方法或设置 | 控制内容 | 何时使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getCamera--) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getLightRig--) | 光照预设、方向和光线旋转。 | 更改 3D 表面上高光和阴影的呈现方式。 |
| [setMaterial](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setMaterial-byte-) | 表面材质，如平面、哑光、塑料或金属。 | 使相同几何形状看起来更平坦、柔和、光亮或金属质感。 |
| [setExtrusionHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | 形状从正面向后延伸的距离。 | 将平面形状转换为可见的厚 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getExtrusionColor--) | 挤压侧面的颜色。 | 使深度可见，或使侧面颜色与正面填充保持一致。 |
| [setDepth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setDepth-double-) | PowerPoint 3D 格式化使用的附加深度。 | 微调形状或文本的深度，尤其与斜角和材质设置一起使用时。 |
| [getBevelTop](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getBevelBottom--) | 正面和背面的凸起或圆形边缘。 | 添加柔软或成型的边缘，而非锐利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getContourColor--) 和 [setContourWidth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setContourWidth-double-) | 3D 对象的轮廓线。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状通常需要四种设置才能看起来具有可信的 3D 效果：

- 相机设置，因为默认的正视图可能会隐藏挤压效果。
- 光照设置，因为光照使各面和侧面可辨。
- 材质设置，因为表面会影响光线的呈现方式。
- 挤压或深度设置，因为平面形状需要厚度。

下面的示例创建一个矩形，在其正面添加文本，应用 3D 格式化，将演示文稿保存为 PPTX，并将幻灯片渲染为 PNG 图像。

```php
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

![渲染的蓝色 3D 矩形，正面带有白色 3D 文本](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转通过“3‑D 旋转”窗格进行配置。X、Y、Z 旋转值对应于通过相机 API 设置的旋转。

![PowerPoint 3‑D 旋转窗格，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 [ThreeDFormat::getCamera](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getCamera--) 方法设置相机类型和旋转：

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

当需要更改观看者看到对象的方式时使用相机。它不会改变幻灯片上 2D 形状的几何形状，只会改变 PowerPoint 和 Aspose.Slides 渲染时使用的 3D 视点。

## **添加挤压和深度**

挤压通过将形状延伸至正面之后，使其看起来更厚。PowerPoint 中的深度控制设置此可见厚度，颜色控制设置侧面的颜色。

![PowerPoint 深度控制映射到挤压颜色和挤压高度属性](img_02_02.png)

使用 [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) 设置厚度，使用 [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#getExtrusionColor--) 设置侧面颜色：

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

当需要直接使用 PowerPoint 的深度值或将深度与斜角、材质和文本效果组合时，使用 [ThreeDFormat::setDepth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/#setDepth-double-) 。在多数形状场景中，`setExtrusionHeight` 更直观，因为它直接表示可见的挤压。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。您可以对正面使用纯色、渐变、图案或图片填充，同时仍然使用相同的相机、光照、材质和挤压设置。

以下示例对形状使用渐变填充，并对侧面使用更深的挤压颜色：

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

渲染结果保留正面的渐变，并单独渲染挤压侧面：

![渲染的 3D 矩形，蓝到橙渐变填充，橙色挤压](img_02_03.png)

如果要使用图片填充，请将图像添加到演示文稿并分配给形状填充：

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

图片渲染在正面，而挤压渲染为 3D 侧面表面：

![渲染的 3D 矩形，正面使用照片填充，橙色挤压](img_02_04.png)

## **对文本应用 3D 格式化**

形状的 3D 格式化影响形状本体。文本的 3D 格式化影响文本框。这对于类似 WordArt 的效果很有用，需要对字母本身进行挤压、材质、光照和相机设置。

以下示例创建带图案填充的文本，应用 WordArt 变换，并在 [TextFrameFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/) 上配置 3D 设置：

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

文本呈现为弯曲的、挤压的 3D 字体：

![渲染的 3D 文本，带拱形 WordArt 变换、橙色图案填充和深色挤压](img_02_05.png)

## **导出与渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会被光栅化或绘制为 2D 输出。此行为适用于将幻灯片渲染为 [PNG](/slides/zh/php-java/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/php-java/convert-powerpoint-to-html/)，或为 [video conversion](/slides/zh/php-java/convert-powerpoint-to-video/) 生成帧时。

请注意以下要点：

- 导出的图像和 PDF 不是交互式的。导出后，观看者无法旋转对象。
- 最终外观取决于相机、光照、材质、挤压、填充和幻灯片缩放的组合。
- 如果需要检查继承或基于主题的格式化值，请读取 [有效形状属性](/slides/zh/php-java/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果会被渲染，而不是保留为可编辑的 3D 设置。

## **常见问题**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 为形状和文本创建并渲染 PowerPoint 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为观看者可以旋转的交互式 3D 场景。在 PPTX 中，3D 格式化在 PowerPoint 中保持可编辑（前提是该格式支持）。

**3D 模型和 3D 效果有什么区别？**

3D 模型是插入演示文稿的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、挤压、斜角、光照和材质。本文讨论的正是 3D 效果。

**要实现可见的 3D 形状，需要哪些设置？**

最低要求是设置相机旋转以及挤压或深度。实际使用中，还应设置光照和材质，以便渲染的面拥有清晰的高光和阴影。

**我可以将 3D 效果同时应用于形状和文本吗？**

可以。对形状本体使用 [Shape::getThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getThreeDFormat--)，对文本使用 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#getThreeDFormat--)。

**导出为图像、PDF、HTML 或视频帧时，3D 效果会出现吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF、HTML 以及用于视频转换的帧时会渲染 3D 效果。导出文件包含渲染后的外观，而不是可编辑的 3D 对象。

**在继承和主题设置应用后，我可以读取最终的 3D 值吗？**

可以。使用在 [形状有效属性](/slides/zh/php-java/shape-effective-properties/) 中描述的有效格式化 API，读取最终的相机、光照、斜角及相关 3D 值。