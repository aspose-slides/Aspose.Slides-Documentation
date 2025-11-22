---
title: 字体替代 - PowerPoint C# API
linktitle: 字体替代
type: docs
weight: 70
url: /zh/net/font-substitution/
keywords:
- 字体
- 替代字体
- PowerPoint
- 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: C# PowerPoint API 允许您在演示文稿中替换字体
---

## **获取字体替代**

为了让您了解在演示渲染过程中被替代的演示字体，Aspose.Slides 提供了来自 [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) 接口的 [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) 方法。

下面的 C# 代码展示如何获取在渲染演示时执行的所有字体替代：
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **设置字体替代规则**

Aspose.Slides 允许您以以下方式为字体设置规则，以决定在特定条件下（例如，无法访问字体时）必须执行的操作：

1. 加载相关的演示文稿。
2. 加载将被替换的字体。
3. 加载新的字体。
4. 为替换添加规则。
5. 将规则添加到演示文稿的字体替换规则集合中。
6. 生成幻灯片图像以观察效果。

下面的 C# 代码演示字体替代过程：
```c#
// 加载演示文稿
Presentation presentation = new Presentation("Fonts.pptx");

// 加载将被替换的源字体
IFontData sourceFont = new FontData("SomeRareFont");

// 加载新字体
IFontData destFont = new FontData("Arial");

// 添加用于字体替换的字体规则
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// 将规则添加到字体替换规则集合
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// 将字体规则集合添加到规则列表
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // 以 JPEG 格式将图像保存到磁盘
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
您可能想查看 [**字体替换**](/slides/zh/net/font-replacement/)。 
{{% /alert %}}

## **常见问题**

**字体替代和字体替换之间有什么区别？**  
[替换](/slides/zh/net/font-replacement/) 是在整个演示文稿中强制用另一种字体覆盖一种字体。替代是一个在特定条件下触发的规则，例如原始字体不可用时，会使用指定的后备字体。

**替代规则到底何时生效？**  
这些规则参与在加载、渲染和转换期间评估的标准 [字体选择](/slides/zh/net/font-selection-sequence/) 流程；如果所选字体不可用，则会应用替换或替代。

**如果既未配置替换也未配置替代，而且系统上缺少该字体，默认行为是什么？**  
库将尝试选择最接近的可用系统字体，类似于 PowerPoint 的行为。

**我能在运行时附加自定义外部字体以避免替代吗？**  
是的。您可以在运行时 [添加外部字体](/slides/zh/net/custom-font/) ，库将在选择和渲染时考虑这些字体，包括后续的转换。

**Aspose 是否随库分发任何字体？**  
不。Aspose 不会分发付费或免费字体；您需要自行添加和使用字体，需自行承担责任。

**在 Windows、Linux 和 macOS 上的替代行为是否有所不同？**  
是的。字体发现从操作系统的字体目录开始。默认可用字体集和搜索路径因平台而异，这会影响可用性以及是否需要替代。

**如何准备环境以最小化批量转换期间意外的替代？**  
在机器或容器之间同步字体集，[添加外部字体](/slides/zh/net/custom-font/) 以满足输出文档的需求，并在可能的情况下在演示文稿中 [嵌入字体](/slides/zh/net/embedded-font/)，以确保渲染时所选字体可用。