---
title: 在 Android 上使用備援字型呈現簡報
linktitle: 呈現簡報
type: docs
weight: 30
url: /zh-hant/androidjava/render-presentation-with-fallback-font/
keywords:
- 備援字型
- 渲染 PowerPoint
- 渲染簡報
- 渲染投影片
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 的 Aspose.Slides 中使用備援字型呈現簡報 —— 透過逐步 Java 程式碼範例，確保 PPT、PPTX 與 ODP 的文字保持一致。"
---
## **概觀**

Aspose.Slides 允許您使用備援字型規則來呈現簡報。本文章說明如何建立備援字型規則集合、透過移除或新增備援字型來修改規則，並使用 `FontsManager.setFontFallBackRulesCollection` 方法指派該集合。

將備援字型規則集合指派給簡報的 `FontsManager` 後，規則會在儲存、呈現與轉換簡報等操作期間套用。此範例示範如何在呈現投影片縮圖並將其儲存為 JPEG 圖片時使用已設定的規則。

## **使用備援字型規則呈現投影片**

以下範例包含這些步驟：

1. 我們[建立備援字型規則集合](/slides/zh-hant/androidjava/create-fallback-fonts-collection/)。
1. [移除](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-)備援字型規則並[addFallBackFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)至另一個規則。
1. 將規則集合設定至[getFontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) 方法。
1. 使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法，我們可以將簡報儲存為相同格式，或儲存為其他格式。當備援字型規則集合已設定至[FontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontsManager)，這些規則會在對簡報的任何操作期間套用：儲存、呈現、轉換等。

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

    // 並更新指定範圍的規則
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// 也可以從列表中移除任何現有規則，至少保留一個規則以供呈現
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // 指定已準備好的規則清單供使用
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
了解更多有關[在 Android 上將 PPT 與 PPTX 轉換為 JPG](/slides/zh-hant/androidjava/convert-powerpoint-to-jpg/)的資訊。
{{% /alert %}}