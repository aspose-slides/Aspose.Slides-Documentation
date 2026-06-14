---
title: 使用 Java 管理簡報中的 SmartArt 圖形
linktitle: SmartArt 圖形
type: docs
weight: 20
url: /zh-hant/java/manage-smartart-shape/
keywords:
- SmartArt 物件
- SmartArt 圖形
- SmartArt 樣式
- SmartArt 色彩
- 建立 SmartArt
- 新增 SmartArt
- 編輯 SmartArt
- 變更 SmartArt
- 存取 SmartArt
- SmartArt 版面配置類型
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中自動化 PowerPoint SmartArt 的建立、編輯與樣式設定，提供精簡的程式碼範例及以效能為導向的指導。"
---
## **概觀**

Aspose.Slides 允許您以程式方式在 PowerPoint 簡報中建立和管理 SmartArt 圖形。本文說明如何將 SmartArt 形狀新增至投影片、存取現有的 SmartArt 形狀、依特定版面配置類型尋找 SmartArt，並透過變更 SmartArt 樣式或色彩樣式來更新其視覺外觀。

範例示範如何透過簡報投影片的形狀集合處理 SmartArt 形狀、檢查形狀是否為 SmartArt，並進一步修改或檢視其屬性。

## **建立 SmartArt 形狀**
Aspose.Slides for Java 已提供建立 SmartArt 形狀的 API。若要在投影片中建立 SmartArt 形狀，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
2. 使用索引取得投影片的參照。
3. [新增 SmartArt 形狀](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) 並設定其 [LayoutType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArtLayoutType)。
4. 將修改後的簡報儲存為 PPTX 檔案。

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 新增 Smart Art 形狀
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // 保存簡報
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**圖：已新增至投影片的 SmartArt 形狀**|

## **存取投影片上的 SmartArt 形狀**
以下程式碼用於存取簡報投影片中新增的 SmartArt 形狀。在範例程式碼中，我們會遍歷投影片內的每個形狀，並檢查它是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArt) 形狀。如果形狀屬於 SmartArt 類型，我們會將其轉型為 [**SmartArt**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArt) 實例。

```java
// 載入所需的簡報
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof ISmartArt)
        {
            // 將形狀型別轉換為 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **以特定版面配置類型存取 SmartArt 形狀**
以下範例程式碼可協助存取具有特定 LayoutType 的 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArt) 形狀。請注意，SmartArt 的 LayoutType 為唯讀，只能在新增 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArt) 形狀時設定，無法後續變更。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例，並載入含有 SmartArt 形狀的簡報。
2. 使用索引取得第一張投影片的參照。
3. 遍歷第一張投影片內的每個形狀。
4. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArt) 類型，若是則將選取的形狀轉型為 SmartArt。
5. 檢查具有特定 LayoutType 的 SmartArt 形狀，並執行後續所需的操作。

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof ISmartArt)
        {
            // 將形狀型別轉換為 SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // 檢查 SmartArt 版面配置
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **變更 SmartArt 形狀樣式**
在此範例中，我們將學習如何變更任何 SmartArt 形狀的快速樣式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例，並載入含有 SmartArt 形狀的簡報。
2. 使用索引取得第一張投影片的參照。
3. 遍歷第一張投影片內的每個形狀。
4. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArt) 類型，若是則將選取的形狀轉型為 SmartArt。
5. 尋找具有特定 Style 的 SmartArt 形狀。
6. 為 SmartArt 形狀設定新的 Style。
7. 儲存簡報。

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : slide.getShapes()) 
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof ISmartArt) 
        {
            // 將形狀型別轉換為 SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // 檢查 SmartArt 樣式
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // 變更 SmartArt 樣式
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // 保存簡報
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**圖：已變更 Style 的 SmartArt 形狀**|

## **變更 SmartArt 形狀色彩樣式**
在此範例中，我們將學習如何變更任意 SmartArt 形狀的色彩樣式。以下範例程式碼會存取具有特定色彩樣式的 SmartArt 形狀，並修改其樣式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例，並載入含有 SmartArt 形狀的簡報。
2. 使用索引取得第一張投影片的參照。
3. 遍歷第一張投影片內的每個形狀。
4. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArt) 類型，若是則將選取的形狀轉型為 SmartArt。
5. 尋找具有特定 Color Style 的 SmartArt 形狀。
6. 為 SmartArt 形狀設定新的 Color Style。
7. 儲存簡報。

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍歷第一張投影片內的每個形狀
    for (IShape shape : slide.getShapes()) 
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape instanceof ISmartArt) 
        {
            // 將形狀型別轉換為 SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // 檢查 SmartArt 色彩類型
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // 變更 SmartArt 色彩類型
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // 保存簡報
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**圖：已變更 Color Style 的 SmartArt 形狀**|

## **常見問題**

**我可以將 SmartArt 作為單一物件進行動畫設定嗎？**

可以。SmartArt 是一種形狀，您可以透過動畫 API 套用 [標準動畫](/slides/zh-hant/java/powerpoint-animation/)（進入、退出、強調、移動路徑），與其他形狀的操作方式相同。

**如果我不知道 SmartArt 的內部 ID，該如何在投影片上找到特定的 SmartArt？**

設定並使用替代文字 (AltText)，再以該值搜尋形狀——這是定位目標形狀的建議方式。

**我可以將 SmartArt 與其他形狀分組嗎？**

可以。您可以將 SmartArt 與其他形狀（圖片、表格等）分組，然後 [操作該群組](/slides/zh-hant/java/group/)。

**如何取得特定 SmartArt 的影像（例如，用於預覽或報告）？**

匯出該形狀的縮圖/影像；此函式庫能將 [個別形狀轉換](/slides/zh-hant/java/create-shape-thumbnails/) 為點陣檔（PNG/JPG/TIFF）。

**將整份簡報轉換為 PDF 時，SmartArt 的外觀會被保留嗎？**

會。渲染引擎在 [PDF 匯出](/slides/zh-hant/java/convert-powerpoint-to-pdf/) 時旨在高保真，提供多種品質與相容性選項。