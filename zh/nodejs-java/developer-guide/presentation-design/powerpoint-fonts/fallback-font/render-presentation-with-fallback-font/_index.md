---
title: 在 JavaScript 中使用后备字体渲染演示文稿
linktitle: 渲染演示文稿
type: docs
weight: 30
url: /zh/nodejs-java/render-presentation-with-fallback-font/
keywords:
- 后备字体
- 渲染 PowerPoint
- 渲染演示文稿
- 渲染幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中使用后备字体渲染演示文稿 – 通过逐步的 JavaScript 代码示例，使 PPT、PPTX 和 ODP 中的文本保持一致。"
---

以下示例包括以下步骤：

1. 我们[创建后备字体规则集合](/slides/zh/nodejs-java/create-fallback-fonts-collection/)。
1. [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-)后备字体规则并将[addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)添加到另一个规则。
1. 将规则集合设置为[getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--)方法。
1. 使用[Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-)方法，我们可以以相同格式保存演示文稿，或另存为其他格式。将后备字体规则集合设置到[FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager)后，这些规则将在对演示文稿的任何操作期间应用：保存、渲染、转换等。

```javascript
// 创建规则集合的新实例
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// 创建若干规则
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // 尝试从已加载的规则中移除回退字体 "Tahoma"
    fallBackRule.remove("Tahoma");
    // 并为指定范围更新规则
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// 我们也可以从列表中移除任何现有的规则
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // 分配已准备好的规则列表以供使用
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // 使用已初始化的规则集合渲染缩略图并保存为 JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // 以 JPEG 格式将图像保存到磁盘
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
了解更多关于如何在 JavaScript 中将[将 PPT 和 PPTX 转换为 JPG（JavaScript）](/slides/zh/nodejs-java/convert-powerpoint-to-jpg/)的内容。 
{{% /alert %}}