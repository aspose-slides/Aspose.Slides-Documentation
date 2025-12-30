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

Aspose Slides 允许您使用 [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) 加载以下字体：

* TrueType（.ttf）和 TrueType 集合（.ttc）字体。参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType（.otf）字体。参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您在演示文稿中加载使用的字体，而无需在系统上安装这些字体。这会影响导出输出——如 PDF、图像以及其他受支持的格式——从而使生成的文档在不同环境中保持一致。字体可从自定义目录加载。

1. 指定一个或多个包含字体文件的文件夹。
2. 调用静态方法 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) 从这些文件夹加载字体。
3. 加载并渲染/导出演示文稿。
4. 调用 [FontsLoader.clearCache](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/clearcache/) 清除字体缓存。

以下代码示例演示了字体加载过程：
```cpp
// 定义包含自定义字体文件的文件夹。
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// 从指定的文件夹加载自定义字体。
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 使用已加载的字体渲染/导出演示文稿（例如导出为 PDF、图像或其他格式）。
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// 工作完成后清除字体缓存。
FontsLoader::ClearCache();
```


{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) 会向字体搜索路径添加额外的文件夹，但不会更改字体初始化顺序。字体按以下顺序初始化：

1. 默认的操作系统字体路径。
1. 通过 [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) 加载的路径。

{{%/alert %}}

## **获取自定义字体文件夹**
Aspose.Slides 提供 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/)，帮助您查找字体文件夹。该方法返回通过 `LoadExternalFonts` 方法添加的文件夹以及系统字体文件夹。

以下 C++ 代码展示了如何使用 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) 方法：
``` cpp
// 此行输出检查字体文件的文件夹。
// 这些文件夹包括通过 LoadExternalFonts 方法添加的文件夹和系统字体文件夹。
auto fontFolders = FontsLoader::GetFontFolders();
```


## **为演示文稿指定使用的自定义字体**
Aspose.Slides 提供 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 属性，以便您指定将在演示文稿中使用的外部字体。

以下 C++ 代码展示了如何使用 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 属性：
``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // 对演示文稿进行操作
    // CustomFont1、CustomFont2以及来自 assets\fonts 和 global\fonts 文件夹及其子文件夹的字体均可在演示文稿中使用
}
```


## **外部管理字体**
Aspose.Slides 提供 [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) 方法，允许您将外部字体加载到字节数组中。

以下 C++ 代码演示了字节数组加载字体的过程：
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

**自定义字体会影响所有导出格式（PDF、PNG、SVG、HTML）吗？**

会。已连接的字体会在所有导出格式的渲染器中使用。

**自定义字体会自动嵌入生成的 PPTX 吗？**

不会。将字体注册用于渲染与将其嵌入 PPTX 是不同的操作。如果需要将字体随演示文稿文件一起携带，必须使用显式的[嵌入功能](/slides/zh/cpp/embedded-font/)。

**当自定义字体缺少某些字形时，能否控制回退行为？**

可以。配置[字体替代](/slides/zh/cpp/font-substitution/)、[替换规则](/slides/zh/cpp/font-replacement/) 和[回退集合](/slides/zh/cpp/fallback-font/)，即可精确指定在请求的字形缺失时使用哪个字体。

**能否在 Linux/Docker 容器中使用字体而无需系统范围安装？**

可以。指向您自己的字体文件夹或从字节数组加载字体。这样即可消除容器镜像对系统字体目录的任何依赖。

**关于许可——是否可以在没有限制的情况下嵌入任何自定义字体？**

您需自行负责字体许可合规。许可证条款各不相同，有些禁止嵌入或商业使用。分发输出前，请务必查阅字体的最终用户许可协议（EULA）。