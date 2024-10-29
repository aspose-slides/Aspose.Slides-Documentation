---
title: 渲染带回退字体的演示文稿
type: docs
weight: 30
url: /zh/androidjava/render-presentation-with-fallback-font/
---

以下示例包含以下步骤：

1. 我们 [创建回退字体规则集合](/slides/zh/androidjava/create-fallback-fonts-collection/)。
1. [移除](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 一个回退字体规则并 [添加回退字体](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 到另一个规则。
1. 将规则集合设置为 [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--)。 [getFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) 方法。
1. 通过 [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法，我们可以以相同格式保存演示文稿，或将其保存为其他格式。在回退字体规则集合设置为 [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) 之后，这些规则将在对演示文稿的任何操作中应用：保存、渲染、转换等。

```java
// 创建规则集合的新实例
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// 创建若干规则
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // 尝试从加载的规则中移除回退字体 "Tahoma"
    fallBackRule.remove("Tahoma");

    // 并更新指定范围的规则
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// 我们还可以从列表中移除任何现有规则
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // 分配准备好的规则列表以供使用
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 使用初始化的规则集合渲染缩略图并保存为JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // 将图像保存到磁盘为JPEG格式
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
阅读更多关于 [演示文稿中的保存与转换](/slides/zh/androidjava/creating-saving-and-converting-a-presentation/) 的信息。
{{% /alert %}}