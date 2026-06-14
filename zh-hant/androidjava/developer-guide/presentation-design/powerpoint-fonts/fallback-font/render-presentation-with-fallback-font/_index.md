---
title: 渲染 Android 上的備援字型簡報
linktitle: 渲染簡報
type: docs
weight: 30
url: /zh-hant/androidjava/render-presentation-with-fallback-font/
keywords:
- 備援字型
- 呈現 PowerPoint
- 呈現簡報
- 呈現投影片
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中使用備援字型渲染簡報——透過一步一步的 Java 程式碼範例，確保 PPT、PPTX 與 ODP 之間的文字保持一致。"
---
## **概觀**

Aspose.Slides 允許您使用備援字型規則來呈現簡報。本篇文章說明如何建立備援字型規則集合、透過移除或新增備援字型來修改其規則，並使用 `FontsManager.setFontFallBackRulesCollection` 方法指派該集合。

將備援字型規則集合指派給簡報的 `FontsManager` 後，這些規則會在儲存、渲染與轉換簡報等操作期間套用。範例展示了在渲染投影片縮圖並將其儲存為 PNG 圖片時，如何使用已設定的規則。

## **使用備援字型規則呈現投影片**

以下範例包含這些步驟：

1. 我們[建立備援字型規則集合](/slides/zh-hant/androidjava/create-fallback-fonts-collection/)。
1. [移除](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-)一個備援字型規則，並對另一個規則使用[addFallBackFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)。
1. 將規則集合設定給[getFontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) 方法。
1. 透過[Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法，我們可以以相同格式儲存簡報，或以其他格式儲存。在將備援字型規則集合設定給[FontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontsManager) 後，這些規則會在對簡報的任何操作期間套用：儲存、渲染、轉換等。

```java
// 建立規則集合的新實例
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //嘗試從已載入的規則中移除備援字型 "Tahoma"
    fallBackRule.remove("Tahoma");

    //並為指定範圍更新規則
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//同時我們可以從清單中移除任何現有的規則
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //指派已準備好的規則清單供使用
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 使用已初始化的規則集合渲染縮圖並儲存為 JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //以 JPEG 格式將影像儲存至磁碟
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
閱讀更多關於[Convert PPT and PPTX to JPG on Android](/slides/zh-hant/androidjava/convert-powerpoint-to-jpg/)的資訊。
{{% /alert %}}