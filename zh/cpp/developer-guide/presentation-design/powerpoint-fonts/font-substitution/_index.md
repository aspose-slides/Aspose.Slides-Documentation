---
title: 字体替换
type: docs
weight: 70
url: /zh/cpp/font-substitution/
keywords: "字体, 替代字体, PowerPoint 演示文稿, C++, CPP, Aspose.Slides for C++"
description: "在 C++ 中替代 PowerPoint 中的字体"
---

Aspose.Slides 允许您设置字体规则，以确定在某些条件下必须执行的操作（例如，当无法访问字体时），步骤如下：

1. 加载相关的演示文稿。
2. 加载将被替换的字体。
3. 加载新字体。
4. 添加替换规则。
5. 将规则添加到演示文稿字体替换规则集合中。
6. 生成幻灯片图像以观察效果。

以下 C++ 代码演示了字体替换的过程：

```c++
// 文档目录的路径。
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// 加载演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 定义将被替换的字体和新字体
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// 为字体替换添加字体规则
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// 将规则添加到字体替换规则集合
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// 将字体规则集合添加到规则列表
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// 将 PPTX 保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="注意"  color="warning"   %}} 

您可能想查看 [**字体替换**](/slides/zh/cpp/font-replacement/)。 

{{% /alert %}}