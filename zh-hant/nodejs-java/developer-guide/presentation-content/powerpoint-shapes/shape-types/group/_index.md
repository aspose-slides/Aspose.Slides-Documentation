---
title: JavaScript 中的群組簡報形狀
linktitle: 形狀群組
type: docs
weight: 40
url: /zh-hant/nodejs-java/group/
keywords:
- 群組形狀
- 形狀群組
- 新增群組
- 替代文字
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 簡報中學習群組與解除群組形狀——快速、一步步的指南，搭配免費 JavaScript 程式碼。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用群組形狀。它展示了如何將群組形狀新增至投影片、在其中放置形狀，並儲存更新後的簡報。它還示範了如何存取群組內的形狀以及讀取它們的 `AlternativeText` 值。此外，本文還簡要介紹了相關的群組形狀功能，例如巢狀群組、Z 順序和鎖定選項。

## **新增群組形狀**
Aspose.Slides 支援在投影片上使用群組形狀。此功能協助開發人員建立更豐富的簡報。Aspose.Slides for Node.js via Java 支援新增或存取群組形狀。可以將形狀新增至已建立的群組形狀中以填充其內容，或存取群組形狀的任何屬性。若要使用 Aspose.Slides for Node.js via Java 將群組形狀新增至投影片：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
1. 使用索引取得投影片的參考。
1. 將群組形狀新增至投影片。
1. 將形狀新增至已新增的群組形狀。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下範例將群組形狀新增至投影片。

```javascript
// 建立 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 存取投影片的形狀集合
    var slideShapes = sld.getShapes();
    // 將群組形狀新增至投影片
    var groupShape = slideShapes.addGroupShape();
    // 在已新增的群組形狀內加入形狀
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // 新增群組形狀框架
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // 將 PPTX 檔寫入磁碟
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **存取 AltText 屬性**
本主題展示簡單步驟，並附有程式碼範例，說明如何在投影片上新增群組形狀以及存取群組形狀的 AltText 屬性。若要使用 Aspose.Slides for Node.js via Java 存取投影片中群組形狀的 AltText：

1. 實例化代表 PPTX 檔案的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別。
1. 使用索引取得投影片的參考。
1. 存取投影片的形狀集合。
1. 取得群組形狀。
1. 呼叫 [getAlternativeText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#getAlternativeText--) 屬性。

以下範例存取群組形狀的替代文字。

```javascript
// 建立代表 PPTX 檔的 Presentation 類別
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // 存取投影片的形狀集合
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // 存取群組形狀。
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // 存取 AltText 屬性
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問答**

**是否支援巢狀分組（群組內的群組）？**

是的。[GroupShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/groupshape/) 具備 [getParentGroup](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getparentgroup/) 方法，直接說明支援階層結構（群組可以是另一個群組的子項）。

**如何控制群組相對於投影片上其他物件的 Z 順序？**

使用 [GroupShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/groupshape/) 的 [getZOrderPosition](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getzorderposition/) 方法，即可檢查其在顯示堆疊中的位置。

**我可以防止移動/編輯/解除群組嗎？**

是的。群組的鎖定區段可透過 [GroupShapeLock](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/groupshape/getgroupshapelock/) 取得，讓您限制對該物件的各種操作。