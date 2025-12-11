---
title: 使用 C++ 在演示文稿中配置字体替代
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
description: "在 Aspose.Slides for C++ 中启用最佳的字体替代，以在将 PowerPoint 和 OpenDocument 演示文稿转换为其他文件格式时使用。"
---

## **设置字体替代规则**

Aspose.Slides 允许您为字体设置规则，以确定在特定条件下（例如，无法访问字体时）必须执行的操作，方法如下：

1. 加载相关演示文稿。  
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

// 定义要被替换的字体以及新字体
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// 添加用于字体替换的字体规则
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// 将规则添加到字体替换规则集合
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// 将字体规则集合添加到规则列表
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// 将 PPTX 保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert title="NOTE"  color="warning"   %}} 
您可能想查看[**字体替换**](/slides/zh/cpp/font-replacement/)。 
{{% /alert %}}

## **常见问题**

**字体替换和字体替代之间的区别是什么？**  

[替换](/slides/zh/cpp/font-replacement/)是对整个演示文稿中一种字体进行强制覆盖，以另一种字体。替代是一条在特定条件下触发的规则，例如原始字体不可用时，会使用指定的后备字体。

**替代规则到底何时会被应用？**  

这些规则参与在加载、渲染和转换期间评估的标准[字体选择](/slides/zh/cpp/font-selection-sequence/)序列；如果所选字体不可用，则会应用替换或替代。

**如果既未配置替换也未配置替代且系统缺少该字体，默认行为是什么？**  

库将尝试选择最接近的可用系统字体，类似于 PowerPoint 的行为。

**我可以在运行时附加自定义外部字体以避免替代吗？**  

是的。您可以在运行时[添加外部字体](/slides/zh/cpp/custom-font/)，使库在选择和渲染时考虑它们，包括后续的转换。

**Aspose 是否随库分发任何字体？**  

不。Aspose 不会分发付费或免费字体；您需自行决定并负责添加和使用字体。

**在 Windows、Linux 和 macOS 上的替代行为是否存在差异？**  

是的。字体发现从操作系统的字体目录开始。默认可用字体的集合和搜索路径在不同平台之间有所不同，这会影响字体的可用性以及是否需要替代。

**在批量转换期间，我应如何准备环境以最小化意外的替代？**  

在机器或容器之间同步字体集合，[添加外部字体](/slides/zh/cpp/custom-font/)以满足输出文档的需求，并在可能的情况下[嵌入字体](/slides/zh/cpp/embedded-font/)到演示文稿中，使所选字体在渲染时可用。