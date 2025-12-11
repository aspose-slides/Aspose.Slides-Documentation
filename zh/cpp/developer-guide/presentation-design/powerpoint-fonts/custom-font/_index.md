---
title: 在 C++ 中自定义 PowerPoint 字体
linktitle: 自定义字体
type: docs
weight: 20
url: /zh/cpp/custom-font/
keywords:
- 字体
- 自定义字体
- 外部字体
- 加载字体
- 管理字体
- 字体文件夹
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 幻灯片中自定义字体，使您的演示文稿在任何设备上都保持清晰一致。"
---

{{% alert color="primary" %}} 

Aspose Slides 允许您使用[FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/)加载这些字体：

* TrueType（.ttf）和 TrueType Collection（.ttc）字体。参见[TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType（.otf）字体。参见[OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您加载在演示文稿中呈现的字体，而无需安装这些字体。字体从自定义目录加载。

1. 创建[FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/)类的实例并调用[FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/)方法。
2. 加载将要渲染的演示文稿。
3. 清除[FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/)类中的缓存。

此 C++ 代码演示了字体加载过程：
``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// 设置字体路径
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// 加载自定义字体目录中的字体
FontsLoader::LoadExternalFonts(folders);

// 执行一些操作并进行演示/幻灯片渲染
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// 清除字体缓存
FontsLoader::ClearCache();
```


## **获取自定义字体文件夹**

Aspose.Slides 提供[FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/)以便您查找字体文件夹。此方法返回通过`LoadExternalFonts`方法添加的文件夹以及系统字体文件夹。

此 C++ 代码展示了如何使用[FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/)方法：
``` cpp
// 此行输出已检查的字体文件夹。
// 这些文件夹是通过 LoadExternalFonts 方法添加的文件夹以及系统字体文件夹。
auto fontFolders = FontsLoader::GetFontFolders();
```


## **为演示文稿指定使用的自定义字体**

Aspose.Slides 提供[LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/)属性，以便您指定将在演示文稿中使用的外部字体。

此 C++ 代码展示了如何使用[LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/)属性：
``` cpp
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //处理演示文稿
    //CustomFont1、CustomFont2 以及来自 assets\fonts 和 global\fonts 文件夹及其子文件夹的字体可用于演示文稿
}
```


## **外部管理字体**

Aspose.Slides 提供[FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/)方法，以便您将外部字体加载到字节数组中。

此 C++ 代码演示了字节数组字体加载过程：
```cpp
// 文档目录的路径
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```


## **常见问题**

**自定义字体是否会影响导出到所有格式（PDF、PNG、SVG、HTML）？**

是的。已连接的字体在所有导出格式中均由渲染器使用。

**自定义字体是否会自动嵌入生成的 PPTX？**

否。将字体注册用于渲染并不等同于将其嵌入 PPTX。如果需要将字体随演示文稿文件一起携带，必须使用显式的[embedding features](/slides/zh/cpp/embedded-font/)。

**当自定义字体缺少某些字形时，我能控制回退行为吗？**

是的。通过配置[font substitution](/slides/zh/cpp/font-substitution/)、[replacement rules](/slides/zh/cpp/font-replacement/)和[fallback sets](/slides/zh/cpp/fallback-font/)来精确定义在请求的字形缺失时使用哪种字体。

**我能在 Linux/Docker 容器中使用字体而无需在系统范围内安装吗？**

是的。指向您自己的字体文件夹或从字节数组加载字体。这消除了容器镜像中对系统字体目录的任何依赖。

**关于许可——我可以在没有限制的情况下嵌入任何自定义字体吗？**

您需要自行负责字体许可合规。条款各不相同；某些许可证禁止嵌入或商业使用。在分发输出之前，请始终查阅字体的最终用户许可协议（EULA）。