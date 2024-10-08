---
title: 嵌入式字体
type: docs
weight: 40
url: /zh/cpp/embedded-font/
keywords: "字体, 嵌入式字体, 添加字体, PowerPoint 演示文稿 C++, CPP, Aspose.Slides for C++"
description: "在 C++ 中使用 PowerPoint 演示文稿中的嵌入式字体"
---

**PowerPoint 中的嵌入式字体** 在您希望您的演示文稿在任何系统或设备上正确显示时非常有用。如果您使用了第三方或非标准字体，因为您在工作中表现得很有创意，那么您更需要嵌入您的字体。否则（没有嵌入字体的情况下），幻灯片上的文本或数字、布局、样式等可能会发生改变或变成令人困惑的矩形。

[FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) 类、[FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/) 类、[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) 类及其接口包含了您在 PowerPoint 演示文稿中处理嵌入式字体所需的大多数属性和方法。

## **获取或删除演示文稿中的嵌入式字体**

Aspose.Slides 提供了 [GetEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) 方法（由 [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) 类公开），允许您获取（或找出）演示文稿中嵌入的字体。要删除字体，使用 [RemoveEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/removeembeddedfont/) 方法（由同一类公开）。

以下 C++ 代码展示了如何从演示文稿中获取和删除嵌入式字体：

```c++
// 实例化一个表示演示文稿文件的 Presentation 对象
auto presentation = System::MakeObject<Presentation>(u"EmbeddedFonts.pptx");
// 渲染一个包含使用嵌入式 "FunSized" 的文本框的幻灯片
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"picture1_out.png", ImageFormat::Png);

auto fontsManager = presentation->get_FontsManager();

// 获取所有嵌入式字体
auto embeddedFonts = fontsManager->GetEmbeddedFonts();

std::function<bool(SharedPtr<IFontData>)> comparer = [](SharedPtr<IFontData> data) -> bool
{
    return data->get_FontName() == u"Calibri";
};

// 查找 "Calibri" 字体
auto funSizedEmbeddedFont = Array<SharedPtr<IFontData>>::Find(embeddedFonts, comparer);

// 移除 "Calibri" 字体
fontsManager->RemoveEmbeddedFont(funSizedEmbeddedFont);

// 渲染演示文稿；"Calibri" 字体被替换为现有字体
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"picture2_out.png", ImageFormat::Png);

// 保存没有嵌入 "Calibri" 字体的演示文稿到磁盘
presentation->Save(u"WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
```

## **向演示文稿添加嵌入式字体**

通过使用 [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) 枚举和两种重载的 [AddEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/) 方法，您可以选择首选的（嵌入）规则将字体嵌入到演示文稿中。以下 C++ 代码展示了如何将字体嵌入并添加到演示文稿中：

```c++
// 加载演示文稿
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// 加载要替换的源字体
auto sourceFont = System::MakeObject<FontData>(u"Arial");

auto allFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (SharedPtr<IFontData> font : allFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&font](SharedPtr<IFontData> data) -> bool
    {
        return data == font;
    };

    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        presentation->get_FontsManager()->AddEmbeddedFont(font, EmbedFontCharacters::All);
    }
}

// 将演示文稿保存到磁盘
presentation->Save(u"AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
```

## **压缩嵌入式字体**

为了让您能够压缩嵌入演示文稿中的字体并减少其文件大小，Aspose.Slides 提供了 [CompressEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) 方法（由 [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) 类公开）。

以下 C++ 代码展示了如何压缩嵌入的 PowerPoint 字体：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

Aspose::Slides::LowCode::Compress::CompressEmbeddedFonts(pres);
pres->Save(u"pres-out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```