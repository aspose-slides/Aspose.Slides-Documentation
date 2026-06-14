---
title: 在 Android 上管理簡報佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/androidjava/manage-placeholder/
keywords:
- 佔位符
- 文字佔位符
- 圖片佔位符
- 圖表佔位符
- 提示文字
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "輕鬆在 Aspose.Slides for Android via Java 中管理佔位符：取代文字、客製化提示並在 PowerPoint 與 OpenDocument 中設定圖片透明度。"
---
## **概述**

Aspose.Slides 允許您以程式方式管理簡報中的佔位符。本文章說明如何在投影片上尋找佔位符並變更其文字、為佔位符布局設定自訂提示文字，以及調整用作佔位符背景的圖片透明度。本文還包含簡短的 FAQ，闡明基礎佔位符與本機形狀的差異、說明佔位符變更如何透過布局或母片套用，並指向頁首與頁尾佔位符的管理。

## **變更佔位符文字**
使用 [Aspose.Slides for Android via Java](/slides/zh-hant/androidjava/)，您可以在簡報的投影片上查找並修改佔位符。Aspose.Slides 允許您變更佔位符中的文字。

**先決條件**：您需要一個包含佔位符的簡報。您可以在常用的 Microsoft PowerPoint 應用程式中建立此類簡報。

以下說明如何使用 Aspose.Slides 取代該簡報中佔位符的文字：

1. 實例化 [`Presentation`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別，並將簡報作為參數傳入。
2. 透過索引取得投影片參考。
3. 遍歷形狀以尋找佔位符。
4. 將佔位符形狀型別轉換為 [`AutoShape`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AutoShape)，並使用與該 [`AutoShape`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AutoShape) 關聯的 [`TextFrame`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextFrame) 變更文字。
5. 儲存已修改的簡報。

以下 Java 程式碼示範如何變更佔位符中的文字：

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 遍歷形狀以尋找佔位符
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // 更改每個佔位符中的文字
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // 將簡報儲存至磁碟
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **設定佔位符提示文字**
標準與預建布局包含如 ***Click to add a title*** 或 ***Click to add a subtitle*** 等佔位符提示文字。使用 Aspose.Slides，您可以將自訂的提示文字插入佔位符布局中。

以下 Java 程式碼示範如何在佔位符中設定提示文字：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // 遍歷投影片
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint 顯示 "點擊以新增標題"
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // 新增副標題
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **設定佔位符圖片透明度**
Aspose.Slides 允許您設定文字佔位符背景圖片的透明度。透過調整此框架中圖片的透明度，您可以使文字或圖片更為突出（視文字與圖片的顏色而定）。

以下 Java 程式碼示範如何為圖片背景（形狀內部）設定透明度：

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**什麼是基礎佔位符，它與投影片上的本機形狀有何不同？**  
基礎佔位符是布局或母片上原始的形狀，投影片的形狀會從它繼承——包括類型、位置以及部分格式設定。本機形狀則是獨立的；若不存在基礎佔位符，則不會有繼承關係。

**如何在不遍歷每張投影片的情況下更新整個簡報中的所有標題或說明文字？**  
在布局或母片上編輯相應的佔位符。基於這些布局或母片的投影片會自動繼承此變更。

**如何控制標準的頁首/頁尾佔位符——日期與時間、投影片編號以及頁尾文字？**  
在適當的範圍（普通投影片、布局、母片、備註/講義）使用 HeaderFooter 管理器，以開啟或關閉這些佔位符並設定其內容。