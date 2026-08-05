---
title: 在 C++ 中配置演示文稿的字体替代
linktitle: 字体替代
type: docs
weight: 70
url: /zh/cpp/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替代
- 替换字体
- 字体替换
- 替代规则
- 替换规则
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在使用 C++ 的 Aspose.Slides 将 PowerPoint 和 OpenDocument 演示文稿转换为其他文件格式时，启用最佳字体替代。"
---
## **概述**

字体替代允许 Aspose.Slides 在渲染或转换期间原始演示文稿的字体不可用时使用其他字体。您可以使用 `IFontsManager` 接口的 `GetSubstitutions` 方法检查哪些字体被替代。

Aspose.Slides 还允许您定义字体替代规则。例如，您可以指定将不可访问的字体替换为另一个可用字体，然后通过演示文稿的字体管理器应用这些规则。

## **设置字体替代规则**

Aspose.Slides 允许您为字体设置规则，以确定在特定条件下（例如，当字体无法访问时）应执行的操作，方法如下：

1. 加载相关的演示文稿。
2. 加载将被替换的字体。
3. 加载新字体。
4. 添加替换规则。
5. 将规则添加到演示文稿的字体替换规则集合中。
6. 生成幻灯片图像以观察效果。

下面的 C++ 代码演示了字体替代过程：

```c++
// 文档目录的路径。
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// 加载演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 定义要被替换的字体和新字体
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// 添加字体替换规则
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// 将规则添加到字体替代规则集合
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// 将字体规则集合添加到规则列表
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// 将 PPTX 保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
您可能想查看 [**字体替换**](/slides/zh/cpp/font-replacement/)。 
{{% /alert %}}

## **数学公式字体的限制**

字体替代规则参与渲染和转换期间使用的标准字体选择过程。它们适用于常规文本场景，Aspose.Slides 可以根据配置的规则将不可访问的字体替换为另一个可用字体。

但是，Office 数学公式存在一个重要限制。如果一个公式是使用 **Cambria Math** 创建的，Aspose.Slides 仍可能需要原始的 **Cambria Math** 字体才能正确计算和渲染公式布局。因此，用其他数学字体（例如 **STIX Two Math**）替代 **Cambria Math** 不受公式渲染支持，仍可能导致出现指示需要 **Cambria Math** 的异常。

要成功转换此类演示文稿，请确保运行时 Aspose.Slides 能够使用 **Cambria Math**。您可以在操作系统中安装该字体，或将其作为 [外部字体](/slides/zh/cpp/custom-font/) 提供，以便在渲染和转换期间参与正常的字体选择过程。

此限制仅针对公式渲染。上述标准的字体替代规则仍适用于原始字体不可访问的常规演示文稿文本。

## **常见问题**

**字体替换 与 字体替代 有何区别？**

[替换](/slides/zh/cpp/font-replacement/) 是在整个演示文稿中强制将一种字体覆盖为另一种字体。字体替代是一条规则，在特定条件触发，例如原始字体不可用时，使用指定的回退字体。

**替代规则究竟何时生效？**

这些规则参与在加载、渲染和转换期间评估的标准[字体选择](/slides/zh/cpp/font-selection-sequence/)序列；如果所选字体不可用，将应用替换或替代。

**如果未配置替换或替代且系统缺少该字体，默认行为是什么？**

库会尝试选择最接近的可用系统字体，类似于 PowerPoint 的行为。

**我可以在运行时附加自定义外部字体以避免替代吗？**

可以。您可以在运行时[添加外部字体](/slides/zh/cpp/custom-font/)，库会将其纳入选择和渲染，包括后续的转换。

**Aspose 是否随库分发任何字体？**

不会。Aspose 不会分发付费或免费字体；您需自行决定并负责添加和使用字体。

**在 Windows、Linux 和 macOS 上，替代行为是否存在差异？**

是的。字体发现从操作系统的字体目录开始。默认可用字体集合和搜索路径在各平台之间不同，这会影响字体可用性及是否需要替代。

**如何准备环境以最大限度减少批量转换期间的意外替代？**

在机器或容器之间同步字体集合，[添加外部字体](/slides/zh/cpp/custom-font/)以满足输出文档的需求，并在可能的情况下在演示文稿中[嵌入字体](/slides/zh/cpp/embedded-font/)，以确保在渲染期间可用所选字体。