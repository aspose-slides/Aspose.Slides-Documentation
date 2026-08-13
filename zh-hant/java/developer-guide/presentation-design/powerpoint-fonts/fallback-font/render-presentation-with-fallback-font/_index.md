---
title: 在 Java 中使用備援字型呈現簡報
linktitle: 呈現簡報
type: docs
weight: 30
url: /zh-hant/java/render-presentation-with-fallback-font/
keywords:
- 備援字型
- 呈現 PowerPoint
- 呈現簡報
- 呈現投影片
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中使用備援字型呈現簡報 – 透過一步一步的 Java 程式碼範例，確保 PPT、PPTX 與 ODP 之間的文字保持一致。"
---
## **概覽**

Aspose.Slides 允許您使用備援字型規則來呈現簡報。本文說明如何建立備援字型規則集合、透過移除或新增備援字型來修改規則，並使用 `FontsManager.setFontFallBackRulesCollection` 方法指派該集合。

將備援字型規則集合指派給簡報的 `FontsManager` 後，這些規則會在儲存、呈現以及轉換簡報等操作中套用。範例示範了在呈現投影片縮圖並將其儲存為 JPEG 圖像時，如何使用已配置的規則。

## **使用備援字型規則呈現投影片**

以下範例包含這些步驟：

1. 我們[建立備援字型規則集合](/slides/zh-hant/java/create-fallback-fonts-collection/)。
1. [移除](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 一個備援字型規則，並將[addFallBackFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 新增至另一個規則。
1. 將規則集合設定為[getFontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) 方法。
1. 使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法，我們可以以相同格式儲存簡報，或以其他格式儲存。將備援字型規則集合設定給[FontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsManager) 後，這些規則會在簡報的任何操作中套用：儲存、呈現、轉換等。

```java
import com.aspose.slides.*;

// 建立規則集合的新實例
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // 嘗試從已載入的規則中移除備援字型 "Tahoma"
    fallBackRule.remove("Tahoma");

    // 並為指定範圍更新規則
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// 也可以從列表中移除任何現有規則，至少保留一個規則以供呈現
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // 指定已準備好的規則清單以供使用
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 使用已初始化的規則集合呈現縮圖並儲存為 JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // 將影像以 JPEG 格式儲存至磁碟
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
了解更多有關如何在 Java 中將 PPT 與 PPTX 轉換為 JPG 的資訊[將 PPT 與 PPTX 轉換為 JPG（Java）](/slides/zh-hant/java/convert-powerpoint-to-jpg/)。
{{% /alert %}}