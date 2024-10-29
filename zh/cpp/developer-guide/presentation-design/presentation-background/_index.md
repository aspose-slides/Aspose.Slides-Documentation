---
title: 演示文稿背景
type: docs
weight: 20
url: /zh/cpp/presentation-background/
keywords: "PowerPoint 背景，设置背景"
description: "在 CPP 中设置 PowerPoint 演示文稿的背景"
---

纯色、渐变色和图片通常用作幻灯片的背景图片。您可以为**普通幻灯片**（单张幻灯片）或**母版幻灯片**（多张幻灯片）设置背景。

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **为普通幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿中的特定幻灯片设置纯色背景（即使该演示文稿包含母版幻灯片）。背景的更改仅影响选定的幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) 枚举设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) 枚举设置为 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) 属性通过 [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) 指定背景的纯色。
5. 保存修改后的演示文稿。

以下 C++ 代码演示如何将纯色（蓝色）设置为普通幻灯片的背景：

```c++
// 文档目录的路径。

	const String OutPath = L"../out/SetSlideBackgroundNormal_out.pptx";

	// 创建 Presentation 类的实例
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 将第一张 ISlide 的背景颜色设置为蓝色
	pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	//将演示文稿写入磁盘
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **为母版幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿中的母版幻灯片设置纯色背景。母版幻灯片作为模板，包含并控制所有幻灯片的格式设置。因此，当您选择将纯色作为母版幻灯片的背景时，该新背景将用于所有幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 将母版幻灯片（`Masters`）的 [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) 枚举设置为 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) 属性通过 [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) 指定背景的纯色。
5. 保存修改后的演示文稿。

以下 C++ 代码演示如何将纯色（森林绿色）设置为演示文稿中的母版幻灯片背景：

```c++
	// 文档目录的路径。

	const String OutPath = L"../out/SetSlideBackgroundMaster_out.pptx";

	// 创建 Presentation 类的实例
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 将母版 ISlide 的背景颜色设置为森林绿色
	pres->get_Masters()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_ForestGreen());

	//将演示文稿写入磁盘
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **为幻灯片设置渐变色背景**

渐变是一种基于颜色逐渐变化的图形效果。当用作幻灯片背景时，渐变色使演示文稿看起来更具艺术感和专业性。Aspose.Slides 允许您为演示文稿中的幻灯片设置渐变色作为背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) 枚举设置为 `Gradient`。
4. 使用 [GradientFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#aa686ab9c84e7e20e65dfe73458f1a823) 属性通过 [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) 指定您喜欢的渐变设置。
5. 保存修改后的演示文稿。

以下 C++ 代码演示如何将渐变色设置为幻灯片的背景：

```c++
// 创建 Presentation 类的实例
auto pres = System::MakeObject<Presentation>(u"SetBackgroundToGradient.pptx");

// 将渐变效果应用于背景
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// 将演示文稿写入磁盘
pres->Save(u"ContentBG_Grad_out.pptx", SaveFormat::Pptx);
```

## **为幻灯片设置图片背景**

除了纯色和渐变色之外，Aspose.Slides 还允许您为演示文稿中的幻灯片设置图片作为背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) 枚举设置为 `Picture`。
4. 加载您想要用作幻灯片背景的图片。
5. 将图片添加到演示文稿的图片集合中。
6. 使用 [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a7f2b7e6afce822667cecd3e80336bfae) 属性通过 [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) 设置图片作为背景。
7. 保存修改后的演示文稿。

以下 C++ 代码演示如何将图片设置为幻灯片的背景：

```c++
// 文档目录的路径。

const String templatePath = L"../templates/SetImageAsBackground.pptx";
const String imagePath = L"../templates/Tulips.jpg";
const String outPath = L"../out/ContentBG_Img_out.pptx";

// 创建 Presentation 类的实例
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 设置背景图片的条件
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// 加载图片
auto image = Images::FromFile(imagePath);

// 将图片添加到演示文稿的图片集合中
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// 将演示文稿写入磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **更改背景图片的透明度**

您可能希望调整幻灯片背景图片的透明度，以使幻灯片内容更突出。以下 C++ 代码演示如何更改幻灯片背景图片的透明度：

```c++
int32_t transparencyValue = 30;
// 例如
// 获取图片变换操作的集合
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();
// 查找具有固定百分比的透明效果。
System::SharedPtr<AlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (System::ObjectExt::Is<AlphaModulateFixed>(operation))
    {
        transparencyOperation = System::ExplicitCast<AlphaModulateFixed>(operation);
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

## **获取幻灯片背景的值**

Aspose.Slides 提供了 [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data/) 接口，允许您获取幻灯片背景的有效值。此接口包含有关有效的 [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a097ba368423bf4a9ab7a6a61870bfc8e) 和有效的 [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a446676281ac4195cb7eb989e4a8110f8) 的信息。

通过 [BaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide/) 类的 [Background](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide#ac12d4a7683bf6fa20b3eef387219cf16) 属性，您可以获取幻灯片背景的有效值。

以下 C++ 代码演示如何获取幻灯片的有效背景值：

```c++
// 创建 Presentation 类的实例
const String templatePath = u"../templates/SamplePresentation.pptx";
	

	auto pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<IBackgroundEffectiveData> effBackground = pres->get_Slides()->idx_get(0)->CreateBackgroundEffective();
	if (effBackground->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Solid)
	{
		System::Console::WriteLine(System::String(u"填充颜色: ") + effBackground->get_FillFormat()->get_SolidFillColor());
	}
	else
	{
		System::Console::WriteLine(System::String(u"填充类型: ") + System::ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
	}
```