---
title: 管理 C++ 中的演示文稿背景
linktitle: 幻灯片背景
type: docs
weight: 20
url: /zh/cpp/presentation-background/
keywords:
- 演示文稿背景
- 幻灯片背景
- 纯色
- 渐变色
- 图像背景
- 背景透明度
- 背景属性
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 文件中设置动态背景，并提供提升演示效果的代码技巧。"
---

## **概述**

纯色、渐变和图像通常用于幻灯片背景。您可以为 **普通幻灯片**（单张幻灯片）或 **母版幻灯片**（一次应用于多张幻灯片）设置背景。

![PowerPoint background](powerpoint-background.png)

## **为普通幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿中的特定幻灯片设置纯色背景，即使演示文稿使用了母版幻灯片。更改仅适用于所选幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) 设置为 `Solid`。
4. 在 [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) 上使用 [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) 方法指定纯色背景颜色。
5. 保存修改后的演示文稿。

以下 C++ 示例演示如何将蓝色纯色设置为普通幻灯片的背景：
```cpp
// 创建 Presentation 类的实例。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// 将幻灯片的背景颜色设置为蓝色。
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// 将演示文稿保存到磁盘。
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **为母版幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿的母版幻灯片设置纯色背景。母版幻灯片充当模板，控制所有幻灯片的格式，因此当您为母版幻灯片的背景选择纯色时，它会应用于每一张幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过 `get_Masters` 将母版幻灯片的 [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) 设置为 `Solid`。
4. 使用 [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) 方法指定纯色背景颜色。
5. 保存修改后的演示文稿。

以下 C++ 示例演示如何将森林绿设置为母版幻灯片的纯色背景：
```cpp
// 创建 Presentation 类的实例。
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// 为母版幻灯片设置背景颜色为森林绿。
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// 将演示文稿保存到磁盘。
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **为幻灯片设置渐变背景**

渐变是一种通过颜色逐渐变化实现的图形效果。作为幻灯片背景使用时，渐变可以使演示文稿更具艺术感和专业感。Aspose.Slides 允许您为幻灯片设置渐变颜色背景。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) 设置为 `Gradient`。
4. 在 [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) 上使用 [get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_gradientformat/) 方法配置所需的渐变设置。
5. 保存修改后的演示文稿。

以下 C++ 示例演示如何将渐变颜色设置为幻灯片的背景：
```cpp
// 创建 Presentation 类的实例。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// 对背景应用渐变效果。
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// 将演示文稿保存到磁盘。
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **将图像设为幻灯片背景**

除了纯色和渐变填充，Aspose.Slides 还支持使用图像作为幻灯片背景。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) 设置为 `Picture`。
4. 加载要用作幻灯片背景的图像。
5. 将图像添加到演示文稿的图像集合中。
6. 在 [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) 上使用 [get_PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_picturefillformat/) 方法将图像指定为背景。
7. 保存修改后的演示文稿。

以下 C++ 示例演示如何将图像设置为幻灯片的背景：
```cpp
// 创建 Presentation 类的实例。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// 设置背景图像属性。
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// 加载图像。
auto image = Images::FromFile(u"Tulips.jpg");
// 将图像添加到演示文稿的图像集合中。
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// 将演示文稿保存到磁盘。
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


以下代码示例演示如何将背景填充类型设置为平铺图片并修改平铺属性：
```cpp
auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert color="primary" %}}
了解更多: [**Tile Picture As Texture**](/slides/zh/cpp/shape-formatting/#tile-picture-as-texture)。
{{% /alert %}}

### **更改背景图像的透明度**

您可能需要调整幻灯片背景图像的透明度，以使幻灯片内容更突出。以下 C++ 代码展示了如何更改幻灯片背景图像的透明度：
```cpp
auto transparencyValue = 30; // 例如。

// 获取图片变换操作的集合。
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// 查找已存在的固定百分比透明度效果。
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// 设置新的透明度值。
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```


## **获取幻灯片背景值**

Aspose.Slides 提供 [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/) 接口用于检索幻灯片的有效背景值。该接口公开有效的 [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) 和 [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/)。

使用 [BaseSlide](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/) 类的 `get_Background` 方法，您可以获取幻灯片的有效背景。

以下 C++ 示例演示如何获取幻灯片的有效背景值：
```cpp
// 创建 Presentation 类的实例。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// 检索有效背景，考虑母版、布局和主题。
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```


## **常见问题**

**我可以重置自定义背景并恢复主题/布局背景吗？**

可以。删除幻灯片的自定义填充后，背景将再次从相应的 [layout](/slides/zh/cpp/slide-layout/)/[master](/slides/zh/cpp/slide-master/) 幻灯片（即 [theme background](/slides/zh/cpp/presentation-theme/)）继承。

**如果之后更改演示文稿的主题，背景会怎样？**

如果幻灯片拥有自己的填充，则保持不变。如果背景是从 [layout](/slides/zh/cpp/slide-layout/)/[master](/slides/zh/cpp/slide-master/) 继承的，则会随 [new theme](/slides/zh/cpp/presentation-theme/) 更新。