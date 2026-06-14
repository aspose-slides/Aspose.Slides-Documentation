---
title: Java 中的群組簡報圖形
linktitle: 圖形群組
type: docs
weight: 40
url: /zh-hant/java/group/
keywords:
- 群組圖形
- 圖形群組
- 新增群組
- 替代文字
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "學習使用 Aspose.Slides for Java 在 PowerPoint 簡報中群組與解除群組圖形——快速、一步步的指南，附免費 Java 程式碼。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用群組圖形。展示了如何將群組圖形加入投影片、在其中放置圖形，以及儲存更新後的簡報。還示範了如何存取群組內的圖形並讀取其 `AlternativeText` 值。此外，本文簡要說明了相關的群組圖形功能，例如巢狀群組、Z 軸順序以及鎖定選項。

## **新增群組圖形**
Aspose.Slides 支援在投影片上操作群組圖形。此功能協助開發人員建立更豐富的簡報。Aspose.Slides for Java 支援新增或存取群組圖形。可以向已新增的群組圖形中加入圖形以填充內容，或存取群組圖形的任意屬性。使用 Aspose.Slides for Java 將群組圖形加入投影片的步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
1. 依照索引取得投影片的參照。
1. 向投影片加入群組圖形。
1. 向已新增的群組圖形中加入圖形。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下範例將群組圖形加入投影片。

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 存取投影片的圖形集合
    IShapeCollection slideShapes = sld.getShapes();

    // 在投影片中新增群組圖形
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // 在已新增的群組圖形內加入圖形
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // 新增群組圖形框架
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // 將 PPTX 檔寫入磁碟
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **存取 AltText 屬性**
本章節示範簡單步驟與程式碼範例，說明如何新增群組圖形以及存取投影片上群組圖形的 AltText 屬性。使用 Aspose.Slides for Java 存取投影片中群組圖形的 AltText 方法如下：

1. 實例化代表 PPTX 檔案的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別。
1. 依照索引取得投影片的參照。
1. 取得投影片的圖形集合。
1. 取得群組圖形。
1. 取得 [AlternativeText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#getAlternativeText--) 屬性。

以下範例存取群組圖形的替代文字。

```java
// 實例化表示 PPTX 檔的 Presentation 類別
Presentation pres = new Presentation("AltText.pptx");
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // 存取投影片的圖形集合
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // 存取群組圖形。
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

**是否支援巢狀群組（群組內部再有群組）？**

是的。[GroupShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/groupshape/) 具有 [getParentGroup](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getParentGroup--) 方法，直接說明支援階層結構（群組可以是另一個群組的子項）。

**如何控制群組相對於投影片上其他物件的 Z 軸順序？**

使用 [GroupShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/groupshape/) 的 [getZOrderPosition](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getZOrderPosition--) 方法即可檢查其在顯示堆疊中的位置。

**我可以防止移動、編輯或解除群組嗎？**

可以。群組的鎖定區段透過 [GroupShapeLock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/groupshape/#getGroupShapeLock--) 取得，讓您限制對該物件的操作。