---
title: 在 Java 中使用回退字體呈現簡報
linktitle: 呈現簡報
type: docs
weight: 30
url: /zh-hant/java/render-presentation-with-fallback-font/
keywords:
- 回退字體
- 呈現 PowerPoint
- 呈現簡報
- 呈現投影片
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中使用回退字體呈現簡報 – 透過逐步 Java 程式碼範例，確保 PPT、PPTX 與 ODP 的文字一致。"
---
## **概觀**

Aspose.Slides 允許您使用回退字體規則來呈現簡報。本文說明如何建立回退字體規則集合、透過移除或新增回退字體來修改規則，並使用 `FontsManager.setFontFallBackRulesCollection` 方法指派該集合。

將回退字體規則集合指派給簡報的 `FontsManager` 後，這些規則會在保存、渲染和轉換簡報等操作期間套用。此範例示範在渲染投影片縮圖並將其儲存為 PNG 圖片時，如何使用已配置的規則。

## **使用回退字體規則渲染投影片**

以下範例包含這些步驟：

1. 我們[建立回退字體規則集合](/slides/zh-hant/java/create-fallback-fonts-collection/)。
1. [移除](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-)一個回退字體規則，並將[addFallBackFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)新增至另一個規則。
1. 將規則集合設定為[getFontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) 方法。
1. 透過[Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#save-java.lang.String-int-)方法，我們可以以相同格式或其他格式儲存簡報。設定回退字體規則集合後，這些規則會在對簡報執行的任何操作（保存、渲染、轉換等）期間套用。

```java
// 建立規則集合的新實例
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// 建立多個規則
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // 嘗試從已載入的規則中移除回退字體「Tahoma」
    fallBackRule.remove("Tahoma");

    // 並為指定範圍更新規則
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// 也可以從清單中移除任何現有的規則
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // 指派已準備好的規則清單以供使用
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 使用已初始化的規則集合渲染縮圖並儲存為 JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // 將影像以 JPEG 格式儲存到磁碟
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
如需了解如何在 Java 中將 PPT 與 PPTX 轉換為 JPG，請點擊此處[將 PPT 與 PPTX 轉換為 JPG（Java）](/slides/zh-hant/java/convert-powerpoint-to-jpg/)。
{{% /alert %}}