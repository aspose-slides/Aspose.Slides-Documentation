---
title: Android 上的群組簡報形狀
linktitle: 形狀群組
type: docs
weight: 40
url: /zh-hant/androidjava/group/
keywords:
- 群組形狀
- 形狀群組
- 新增群組
- 替代文字
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "學習使用 Aspose.Slides for Android 在 PowerPoint 投影片中群組與解除群組形狀──快速、一步一步的指南，提供免費的 Java 程式碼。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用群組形狀。它展示了如何將群組形狀新增至投影片、在其中放置形狀，並儲存更新後的簡報。還示範了如何存取群組內的形狀並讀取其 `AlternativeText` 值。此外，本文還簡要說明了相關的群組形狀功能，例如巢狀群組、Z 順序和鎖定選項。

## **新增群組形狀**
Aspose.Slides 支援在投影片上操作群組形狀。此功能協助開發人員建立更豐富的簡報。Aspose.Slides for Android via Java 支援新增或存取群組形狀。您可以將形狀加入已新增的群組形狀以填充內容，或存取群組形狀的任何屬性。使用 Aspose.Slides for Android via Java 將群組形狀新增至投影片的步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
1. 以索引取得投影片的參照。
1. 向投影片新增群組形狀。
1. 將形狀加入已新增的群組形狀。
1. 將修改後的簡報另存為 PPTX 檔案。

以下範例將群組形狀新增至投影片。

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 存取投影片的形狀集合
    IShapeCollection slideShapes = sld.getShapes();

    // 向投影片新增群組形狀
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // 在已新增的群組形狀內加入形狀
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // 新增群組形狀框架
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // 將 PPTX 檔寫入磁碟
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **存取 AltText 屬性**
本主題提供簡易步驟與程式碼範例，說明如何在投影片上新增群組形狀並存取其 AltText 屬性。使用 Aspose.Slides for Android via Java 在投影片中存取群組形狀的 AltText，步驟如下：

1. 實例化代表 PPTX 檔案的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別。
1. 以索引取得投影片的參照。
1. 取得投影片的形狀集合。
1. 取得群組形狀。
1. 取得 [AlternativeText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShape#getAlternativeText--) 屬性。

以下範例存取群組形狀的替代文字。

```java
// 實例化代表 PPTX 檔的 Presentation 類別
Presentation pres = new Presentation("AltText.pptx");
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // 存取投影片的形狀集合
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // 存取群組形狀。
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // 存取 AltText 屬性
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**是否支援巢狀群組（群組內部的群組）？**

是的。[GroupShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/groupshape/) 具備 [getParentGroup](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getParentGroup--) 方法，直接表明支援階層結構（群組可以是另一個群組的子層）。

**如何控制群組相對於投影片上其他物件的 Z 順序？**

使用 [GroupShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/groupshape/) 的 [getZOrderPosition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getZOrderPosition--) 方法來檢查其在顯示堆疊中的位置。

**我可以防止移動 / 編輯 / 解除群組嗎？**

可以。群組的鎖定區段可透過 [getGroupShapeLock](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) 取得，讓您限制對該物件的操作。