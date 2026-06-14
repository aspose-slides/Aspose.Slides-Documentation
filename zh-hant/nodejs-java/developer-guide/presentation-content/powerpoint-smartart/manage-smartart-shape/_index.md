---
title: 使用 JavaScript 管理簡報中的 SmartArt 圖形
linktitle: SmartArt 圖形
type: docs
weight: 20
url: /zh-hant/nodejs-java/manage-smartart-shape/
keywords:
- SmartArt 物件
- SmartArt 圖形
- SmartArt 樣式
- SmartArt 顏色
- 建立 SmartArt
- 新增 SmartArt
- 編輯 SmartArt
- 變更 SmartArt
- 存取 SmartArt
- SmartArt 版面配置類型
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中自動化 PowerPoint SmartArt 的建立、編輯與樣式設定，提供簡潔的程式碼範例與以效能為導向的指引。"
---
## **概覽**

Aspose.Slides 允許您以程式方式在 PowerPoint 簡報中建立與管理 SmartArt 圖形。本文說明如何將 SmartArt 形狀新增至投影片、存取現有的 SmartArt 形狀、依特定版面配置類型尋找 SmartArt，並透過變更 SmartArt 樣式或色彩樣式來更新其視覺外觀。  
範例示範如何透過簡報投影片的形狀集合操作 SmartArt 形狀、檢查形狀是否為 SmartArt，並進一步修改或檢視其屬性。

## **建立 SmartArt 形狀**
Aspose.Slides for Node.js via Java 已提供建立 SmartArt 形狀的 API。若要在投影片中建立 SmartArt 形狀，請依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
1. 使用索引取得投影片的參考。  
1. 使用設定 [LayoutType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArtLayoutType) 來 [Add a SmartArt shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-)。  
1. 將修改後的簡報儲存為 PPTX 檔案。

```javascript
// 實例化 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增 Smart Art 形狀
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // 儲存簡報
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**圖示：已新增至投影片的 SmartArt 形狀**|

## **存取投影片中的 SmartArt 形狀**
以下程式碼將用於存取簡報投影片中新增的 SmartArt 形狀。在示範程式碼中，我們會遍歷投影片內的每個形狀，並檢查它是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 形狀。若形狀屬於 SmartArt 類型，則會將其型別轉換為 [**SmartArt**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 實例。

```javascript
// 載入所需的簡報
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // 遍歷第一張投影片內的每個形狀
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 檢查形狀是否為 SmartArt 類型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 將形狀型別轉換為 SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **以特定版面配置類型存取 SmartArt 形狀**
以下範例程式碼可協助存取具有特定 LayoutType 的 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 形狀。請注意，SmartArt 的 LayoutType 為唯讀，僅在新增 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 形狀時設定，無法變更。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例，並載入含有 SmartArt 形狀的簡報。  
1. 使用索引取得第一張投影片的參考。  
1. 遍歷第一張投影片內的所有形狀。  
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 類型，若是則將選取的形狀型別轉換為 SmartArt。  
1. 檢查具特定 LayoutType 的 SmartArt 形狀，並執行後續所需的操作。

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // 遍歷第一張投影片內的每個形狀
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 檢查形狀是否為 SmartArt 類型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 將形狀型別轉換為 SmartArtEx
            var smart = shape;
            // 檢查 SmartArt 版面配置
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **變更 SmartArt 形狀樣式**
在此範例中，我們將學習如何變更任何 SmartArt 形狀的快速樣式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例，並載入含有 SmartArt 形狀的簡報。  
1. 使用索引取得第一張投影片的參考。  
1. 遍歷第一張投影片內的所有形狀。  
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 類型，若是則將選取的形狀型別轉換為 SmartArt。  
1. 尋找具特定樣式的 SmartArt 形狀。  
1. 為 SmartArt 形狀設定新的樣式。  
1. 儲存簡報。

```javascript
// 實例化 Presentation 類別
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // 取得第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 遍歷第一張投影片內的每個形狀
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // 檢查形狀是否為 SmartArt 類型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 將形狀型別轉換為 SmartArtEx
            var smart = shape;
            // 檢查 SmartArt 樣式
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // 變更 SmartArt 樣式
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // 儲存簡報
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**圖示：已變更樣式的 SmartArt 形狀**|

## **變更 SmartArt 形狀色彩樣式**
在此範例中，我們將學習如何變更任何 SmartArt 形狀的色彩樣式。以下範例程式碼會存取具特定色彩樣式的 SmartArt 形狀，並變更其樣式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例，並載入含有 SmartArt 形狀的簡報。  
1. 使用索引取得第一張投影片的參考。  
1. 遍歷第一張投影片內的所有形狀。  
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SmartArt) 類型，若是則將選取的形狀型別轉換為 SmartArt。  
1. 尋找具特定色彩樣式的 SmartArt 形狀。  
1. 為 SmartArt 形狀設定新的色彩樣式。  
1. 儲存簡報。

```javascript
// 實例化 Presentation 類別
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // 取得第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 遍歷第一張投影片內的每個形狀
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // 檢查形狀是否為 SmartArt 類型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 將形狀型別轉換為 SmartArtEx
            var smart = shape;
            // 檢查 SmartArt 色彩類型
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // 變更 SmartArt 色彩類型
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // 儲存簡報
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**圖示：已變更色彩樣式的 SmartArt 形狀**|

## **常見問題**

**我可以將 SmartArt 作為單一物件進行動畫化嗎？**

可以。SmartArt 為形狀，您可以透過動畫 API （進入、退出、強調、移動路徑）套用[標準動畫](/slides/zh-hant/nodejs-java/powerpoint-animation/)，就像其他形狀一樣。

**如果我不知道 SmartArt 的內部 ID，該如何在投影片上找到特定的 SmartArt？**

設定並使用替代文字 (AltText)，再依該值搜尋形狀——這是定位目標形狀的建議方式。

**我可以將 SmartArt 與其他形狀群組嗎？**

可以。您可以將 SmartArt 與其他形狀（圖片、表格等）群組，然後[操作群組](/slides/zh-hant/nodejs-java/group/)。

**我要如何取得特定 SmartArt 的影像（例如，用於預覽或報告）？**

匯出該形狀的縮圖/影像；程式庫可將[個別形狀轉換](/slides/zh-hant/nodejs-java/create-shape-thumbnails/)為點陣檔（PNG/JPG/TIFF）。

**將整份簡報轉換為 PDF 時，SmartArt 的外觀會被保留嗎？**

會。渲染引擎針對[PDF 匯出](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)提供高保真度，並具備多種品質與相容性選項。