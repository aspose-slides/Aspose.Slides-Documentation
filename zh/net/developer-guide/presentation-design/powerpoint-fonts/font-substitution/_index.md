---
title: 字体替换 - PowerPoint C# API
linktitle: 字体替换
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

## **获取字体替换**

为了让您发现演示文稿在呈现过程中被替换的字体，Aspose.Slides 提供了 [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) 方法，该方法来自 [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) 接口。

以下 C# 代码展示了如何获取演示文稿呈现时所执行的所有字体替换：
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **设置字体替换规则**

Aspose.Slides 允许您设置字体规则，以确定在某些条件下必须执行的操作（例如，当无法访问某个字体时）。具体步骤如下：

1. 加载相关的演示文稿。
2. 加载将被替换的字体。
3. 加载新的字体。
4. 为替换添加规则。
5. 将规则添加到演示文稿的字体替换规则集合中。
6. 生成幻灯片图像以观察效果。

以下 C# 代码演示了字体替换的过程：

```c#
// 加载演示文稿
Presentation presentation = new Presentation("Fonts.pptx");

// 加载将被替换的源字体
IFontData sourceFont = new FontData("某种稀有字体");

// 加载新字体
IFontData destFont = new FontData("Arial");

// 为字体替换添加字体规则
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// 将规则添加到字体替代规则集合
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// 将字体规则集合添加到规则列表
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // 将图像以 JPEG 格式保存到磁盘
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="注意"  color="warning"   %}} 

您可能想查看 [**字体替换**](/slides/zh/net/font-replacement/)。 

{{% /alert %}}