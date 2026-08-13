---
title: 在 Android 上使用回退字体渲染演示文稿
linktitle: 渲染演示文稿
type: docs
weight: 30
url: /zh/androidjava/render-presentation-with-fallback-font/
keywords:
- 回退字体
- 渲染 PowerPoint
- 渲染演示文稿
- 渲染幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Android 上的 Aspose.Slides 中使用回退字体渲染演示文稿 —— 通过一步一步的 Java 代码示例，保持 PPT、PPTX 和 ODP 中文本一致。"
---
## **概览**

Aspose.Slides 允许您使用回退字体规则渲染演示文稿。本文展示了如何创建回退字体规则集合、通过删除或添加回退字体来修改其规则，以及如何使用 `FontsManager.setFontFallBackRulesCollection` 方法分配该集合。

一旦将回退字体规则集合分配给演示文稿的 `FontsManager`，这些规则将在保存、渲染和转换演示文稿等操作期间生效。示例演示了在渲染幻灯片缩略图并将其保存为 JPEG 图像时如何使用已配置的规则。

## **使用回退字体规则渲染幻灯片**

以下示例包括以下步骤：

1. 我们[创建回退字体规则集合](/slides/zh/androidjava/create-fallback-fonts-collection/)。
1. [Remove](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 一个回退字体规则并[addFallBackFonts](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 到另一个规则。
1. 将规则集合设置为[getFontsManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) 方法。
1. 使用[Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法，我们可以将演示文稿保存为相同格式，或者保存为其他格式。将回退字体规则集合设置到[FontsManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FontsManager) 后，这些规则将在对演示文稿的任何操作期间生效：保存、渲染、转换等。

```java
import com.aspose.slides.*;

// 创建一个规则集合的新实例
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // 尝试从已加载的规则中移除回退字体 "Tahoma"
    fallBackRule.remove("Tahoma");

    // 并更新指定范围的规则
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// 同时我们可以从列表中移除任何已有的规则，但保留至少一个用于渲染的规则
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // 为使用分配已准备好的规则列表
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 使用已初始化的规则集合渲染缩略图并保存为 JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // 将图像以 JPEG 格式保存到磁盘
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
阅读更多关于[在 Android 上将 PPT 和 PPTX 转换为 JPG](/slides/zh/androidjava/convert-powerpoint-to-jpg/)。
{{% /alert %}}