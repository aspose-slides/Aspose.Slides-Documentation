---
title: 在 Java 中使用回退字体渲染演示文稿
linktitle: 渲染演示文稿
type: docs
weight: 30
url: /zh/java/render-presentation-with-fallback-font/
keywords:
- 回退字体
- 渲染 PowerPoint
- 渲染演示文稿
- 渲染幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 的回退字体渲染演示文稿 - 通过逐步的 Java 代码示例，使 PPT、PPTX 和 ODP 中的文本保持一致。"
---

以下示例包括以下步骤：

1. 我们[创建回退字体规则集合](/slides/zh/java/create-fallback-fonts-collection/)。
1. [删除](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-)回退字体规则并[addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)到另一个规则。
1. 将规则集合设置为[getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--)方法。
1. 使用[Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-)方法，我们可以将演示文稿保存为相同格式，或保存为其他格式。在将回退字体规则集合设置到[FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)后，这些规则将在演示文稿的任何操作中生效：保存、渲染、转换等。
```java
// 创建规则集合的新实例
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// 创建多个规则
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // 尝试从已加载的规则中移除回退字体 "Tahoma"
    fallBackRule.remove("Tahoma");

    // 并为指定范围更新规则
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// 也可以从列表中移除任何现有规则
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // 为使用分配准备好的规则列表
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


{{% alert color="primary" %}} 
了解更多关于如何在 Java 中[将 PPT 和 PPTX 转换为 JPG](/slides/zh/java/convert-powerpoint-to-jpg/)的内容。
{{% /alert %}}