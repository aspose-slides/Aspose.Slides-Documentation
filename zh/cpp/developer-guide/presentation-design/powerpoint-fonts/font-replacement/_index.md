---
title: 字体替换
type: docs
weight: 60
url: /zh/cpp/font-replacement/
keywords: "字体, 替换字体, PowerPoint 演示文稿, C++, CPP, Aspose.Slides for C++"
description: "在 C++ 中显式替换 PowerPoint 中的字体"
---

如果您改变了对使用某种字体的看法，可以用另一种字体替换该字体。所有旧字体的实例将被新字体替换。

Aspose.Slides 允许您这样替换字体：

1. 加载相关的演示文稿。
2. 加载将被替换的源字体。
3. 加载新字体。
4. 替换字体。
5. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示了字体替换：

``` cpp
// 加载演示文稿
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// 加载将被替换的源字体
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// 加载新字体
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// 替换字体
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// 保存演示文稿
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="注意" color="warning" %}} 

要设置在某些条件下的规则（例如如果无法访问某个字体），请参见 [**字体替换**](/slides/zh/cpp/font-substitution/)。 

{{% /alert %}}