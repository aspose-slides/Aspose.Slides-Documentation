---
title: C++中的自定义字体
type: docs
weight: 20
url: /cpp/custom-font/
keywords: "字体, 自定义字体, PowerPoint 演示文稿, C++, CPP, Aspose.Slides for C++"
description: "C++中的PowerPoint自定义字体"
---

{{% alert color="primary" %}} 

Aspose Slides 允许您使用 [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) 加载这些字体：

* TrueType (.ttf) 和 TrueType Collection (.ttc) 字体。请参阅 [TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType (.otf) 字体。请参阅 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您加载在演示文稿中渲染的字体，而不必安装这些字体。字体从自定义目录加载。

1. 创建 [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) 类的实例并调用 [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) 方法。
2. 加载将要呈现的演示文稿。
3. 清除 [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) 类中的缓存。

以下C++代码演示了字体加载过程：

``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// 设置字体路径
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// 加载自定义字体目录中的字体
FontsLoader::LoadExternalFonts(folders);

// 执行一些工作并进行演示文稿/幻灯片渲染
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// 清除字体缓存
FontsLoader::ClearCache();
```

## **获取自定义字体文件夹**
Aspose.Slides 提供 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) 允许您查找字体文件夹。此方法返回通过 `LoadExternalFonts` 方法和系统字体文件夹添加的文件夹。

以下C++代码显示了如何使用 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) 方法：

``` cpp
// 此行输出检查字体文件的文件夹。
// 这些是通过LoadExternalFonts方法和系统字体文件夹添加的文件夹。
auto fontFolders = FontsLoader::GetFontFolders();
```

## **指定与演示文稿一起使用的自定义字体**
Aspose.Slides 提供 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 属性，允许您指定将与演示文稿一起使用的外部字体。

以下C++代码显示了如何使用 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 属性：

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //与演示文稿一起工作
    //CustomFont1、CustomFont2以及资产\fonts & global\fonts文件夹及其子文件夹中的字体可用于演示文稿
}
```

## **外部管理字体**
Aspose.Slides 提供 [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) 方法，允许您将外部字体加载到字节数组中。

以下C++代码演示了字节数组字体加载过程：

```cpp
// 文档目录的路径
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```