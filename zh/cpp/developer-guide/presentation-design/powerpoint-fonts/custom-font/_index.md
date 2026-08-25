---
title: "在 C++ 中自定义 PowerPoint 字体"
linktitle: "自定义字体"
type: docs
weight: 20
url: /zh/cpp/custom-font/
keywords:
- "字体"
- "自定义字体"
- "外部字体"
- "加载字体"
- "管理字体"
- "字体文件夹"
- "PowerPoint"
- "OpenDocument"
- "演示文稿"
- "C++"
- "Aspose.Slides"
description: "使用 Aspose.Slides for C++ 在 PowerPoint 幻灯片中自定义字体，以确保您的演示文稿在任何设备上保持清晰一致。"
---
## **概述**

Aspose.Slides 允许您在演示文稿中使用自定义字体，而无需在操作系统上安装它们。您可以从自定义文件夹加载字体、通过文档级字体源为特定演示文稿提供字体，或直接从二进制数据加载外部字体。

加载的字体将在演示文稿渲染或导出时使用，例如导出为 PDF、图像以及其他受支持的格式。这有助于在不同环境中保持演示文稿输出的一致性。本文还说明了如何检查 Aspose.Slides 使用的字体文件夹以及在使用外部字体后如何清除字体缓存。

为渲染注册自定义字体与将字体嵌入 PPTX 文件是分开的。如果必须将字体存储在演示文稿本身内部，请显式使用字体嵌入功能。

演示文稿主题可以为各个书写系统引用不同的字体系列。这些映射仅存储字体名称，不会安装或加载字体文件。请参阅[Script-Specific Theme Fonts](/slides/zh/cpp/script-specific-font-mappings/)以管理映射，并使用下面的加载选项使引用的字体可用于一致的渲染。

{{% alert color="info" title="Note" %}}
Aspose Slides 允许您使用[FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsloader/loadexternalfonts/)加载这些字体：

* TrueType（.ttf）和 TrueType 集合（.ttc）字体。参见[TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType（.otf）字体。参见[OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您在不将字体安装到系统的情况下加载演示文稿使用的字体。这会影响导出输出（如 PDF、图像和其他受支持的格式），从而确保生成的文档在不同环境中保持一致。字体将从自定义目录加载。

1. 指定一个或多个包含字体文件的文件夹。
2. 调用静态[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsloader/loadexternalfonts/)方法从这些文件夹加载字体。
3. 加载并渲染/导出演示文稿。
4. 调用[FontsLoader.clearCache](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsloader/clearcache/)清除字体缓存。

以下代码示例演示了字体加载过程：

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 定义包含自定义字体文件的文件夹。
String externalFontFolder = u"assets/fonts";
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
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsloader/loadexternalfonts/)会向字体搜索路径添加额外的文件夹，但不会改变字体初始化顺序。字体的初始化顺序如下：

1. 默认的操作系统字体路径。
1. 通过[FontsLoader](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsloader/)加载的路径。
{{%/alert %}}

## **获取自定义字体文件夹**

Aspose.Slides 提供[FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsloader/getfontfolders/)以便您查找字体文件夹。该方法返回通过`LoadExternalFonts`方法添加的文件夹以及系统字体文件夹。

以下 C++ 代码展示了如何使用[FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsloader/getfontfolders/)方法：

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// 此行输出检查字体文件的文件夹。
// 这些文件夹是通过 LoadExternalFonts 方法添加的以及系统字体文件夹。
auto fontFolders = FontsLoader::GetFontFolders();
```

## **为演示文稿指定使用的自定义字体**

Aspose.Slides 提供[LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/)属性，以便您指定将在演示文稿中使用的外部字体。

以下 C++ 代码展示了如何使用[LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/)属性：

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // 对演示文稿进行操作
    // CustomFont1、CustomFont2 以及来自 assets\fonts 和 global\fonts 文件夹及其子文件夹的字体均可用于该演示文稿
}
```

## **外部管理字体**

Aspose.Slides 提供[FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsloader/loadexternalfont/)方法，以便您将外部字体加载为字节数组。

以下 C++ 代码演示了字节数组字体加载过程：

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

### 自定义字体是否会影响所有格式（PDF、PNG、SVG、HTML）的导出？

是的。已连接的字体会在渲染器中用于所有导出格式。

### 自定义字体会自动嵌入生成的 PPTX 中吗？

不会。为渲染注册字体并不等同于将其嵌入 PPTX。如果需要将字体随演示文稿文件一起携带，必须使用显式的[embedding features](/slides/zh/cpp/embedded-font/)。

### 当自定义字体缺少某些字形时，我可以控制回退行为吗？

可以。配置[font substitution](/slides/zh/cpp/font-substitution/)、[replacement rules](/slides/zh/cpp/font-replacement/)和[fallback sets](/slides/zh/cpp/fallback-font/)即可精确定义在请求的字形缺失时使用哪个字体。

### 我能在 Linux/Docker 容器中使用字体而无需全局安装吗？

可以。指向您自己的字体文件夹或从字节数组加载字体，即可消除对容器镜像中系统字体目录的依赖。

### 关于授权——我可以在没有限制的情况下嵌入任何自定义字体吗？

您需要自行负责字体授权合规性。不同字体的授权条款各异，有些禁止嵌入或商业使用。请在分发输出之前始终查阅字体的 EULA。