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
description: "在 Aspose.Slides for Android 中使用回退字体渲染演示文稿 —— 通过逐步 Java 代码示例保持 PPT、PPTX 和 ODP 文本的一致性。"
---

以下示例包括以下步骤：

1. 我们[创建回退字体规则集合](/slides/zh/androidjava/create-fallback-fonts-collection/)。
2. [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 一个回退字体规则并[addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)到另一个规则。
3. 将规则集合设置为[getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--)。[getFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) 方法。
4. 使用[Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法可以将演示文稿保存为相同格式，或保存为其他格式。将回退字体规则集合设置到[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) 后，这些规则将在对演示文稿的任何操作中生效：保存、渲染、转换等。
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

// 同样我们可以从列表中移除任何已有的规则
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // 分配准备好的规则列表以供使用
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 使用已初始化的规则集合渲染缩略图并保存为 JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // 将图像保存到磁盘的 JPEG 格式
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
了解更多关于[Convert PPT and PPTX to JPG on Android](/slides/zh/androidjava/convert-powerpoint-to-jpg/)的信息。
{{% /alert %}}