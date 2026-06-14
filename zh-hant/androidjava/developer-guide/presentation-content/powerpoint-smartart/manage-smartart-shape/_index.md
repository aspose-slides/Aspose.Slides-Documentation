---
title: 在 Android 上管理簡報中的 SmartArt 圖形
linktitle: SmartArt 圖形
type: docs
weight: 20
url: /zh-hant/androidjava/manage-smartart-shape/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 自動化 PowerPoint SmartArt 的建立、編輯與樣式設定，提供簡潔的 Java 程式碼範例與性能導向的指引。"
---
## **概覽**

Aspose.Slides 允許您以程式方式在 PowerPoint 簡報中建立與管理 SmartArt 圖形。本文說明如何將 SmartArt 圖形新增至投影片、存取現有 SmartArt 圖形、依特定版面配置類型尋找 SmartArt，並透過變更 SmartArt 樣式或顏色樣式來更新其外觀。

示例說明如何透過簡報投影片的圖形集合操作 SmartArt 圖形、檢查圖形是否為 SmartArt，然後修改或檢視其屬性。

## **建立 SmartArt 圖形**
Aspose.Slides for Android via Java 提供了建立 SmartArt 圖形的 API。若要在投影片中建立 SmartArt 圖形，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。
2. 使用索引取得投影片的參照。
3. 透過設定 [LayoutType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArtLayoutType) 來 [Add a SmartArt shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)。
4. 將已修改的簡報儲存為 PPTX 檔案。

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 新增 SmartArt 圖形
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // 儲存簡報
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**圖：已新增至投影片的 SmartArt 圖形**|

## **存取投影片上的 SmartArt 圖形**
以下程式碼將用於存取簡報投影片中已新增的 SmartArt 圖形。於範例程式碼中，我們會遍歷投影片內的每個圖形，並檢查其是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArt) 圖形。若圖形屬於 SmartArt 類型，則會將其型別轉換為 [**SmartArt**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArt) 實例。

```java
// 載入指定的簡報
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 遍歷第一張投影片內的每個圖形
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // 檢查圖形是否為 SmartArt 類型
        if (shape instanceof ISmartArt)
        {
            // 將圖形型別轉換為 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **存取具有特定版面配置類型的 SmartArt 圖形**
以下範例程式碼可協助存取具有特定 LayoutType 的 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArt) 圖形。請注意，SmartArt 的 LayoutType 為唯讀，僅在新增 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArt) 圖形時設定，無法變更。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體，並載入包含 SmartArt 圖形的簡報。
2. 使用索引取得第一張投影片的參照。
3. 遍歷第一張投影片內的每個圖形。
4. 檢查圖形是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArt) 類型，若是則將選取的圖形型別轉換為 SmartArt。
5. 檢查具有特定 LayoutType 的 SmartArt 圖形，並在之後執行所需的操作。

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 遍歷第一張投影片內的每個圖形
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // 檢查圖形是否為 SmartArt 類型
        if (shape instanceof ISmartArt)
        {
            // 將圖形型別轉換為 SmartArtEx
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

## **變更 SmartArt 圖形樣式**
在此範例中，我們將學習如何變更任意 SmartArt 圖形的快速樣式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體，並載入包含 SmartArt 圖形的簡報。
2. 使用索引取得第一張投影片的參照。
3. 遍歷第一張投影片內的每個圖形。
4. 檢查圖形是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArt) 類型，若是則將選取的圖形型別轉換為 SmartArt。
5. 尋找具有特定 Style 的 SmartArt 圖形。
6. 為 SmartArt 圖形設定新的 Style。
7. 儲存簡報。

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍歷第一張投影片內的每個圖形
    for (IShape shape : slide.getShapes()) 
    {
        // 檢查圖形是否為 SmartArt 類型
        if (shape instanceof ISmartArt) 
        {
            // 將圖形型別轉換為 SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // 檢查 SmartArt 樣式
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // 變更 SmartArt 樣式
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // 儲存簡報
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**圖：已變更樣式的 SmartArt 圖形**|

## **變更 SmartArt 圖形顏色樣式**
在此範例中，我們將學習如何變更任意 SmartArt 圖形的顏色樣式。以下範例程式碼會存取具有特定顏色樣式的 SmartArt 圖形，並變更其樣式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體，並載入包含 SmartArt 圖形的簡報。
2. 使用索引取得第一張投影片的參照。
3. 遍歷第一張投影片內的每個圖形。
4. 檢查圖形是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArt) 類型，若是則將選取的圖形型別轉換為 SmartArt。
5. 尋找具有特定 Color Style 的 SmartArt 圖形。
6. 為 SmartArt 圖形設定新的 Color Style。
7. 儲存簡報。

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍歷第一張投影片內的每個圖形
    for (IShape shape : slide.getShapes()) 
    {
        // 檢查圖形是否為 SmartArt 類型
        if (shape instanceof ISmartArt) 
        {
            // 將圖形型別轉換為 SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // 檢查 SmartArt 顏色類型
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // 變更 SmartArt 顏色類型
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // 儲存簡報
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**圖：已變更色彩樣式的 SmartArt 圖形**|

## **FAQ**

**我可以將 SmartArt 作為單一物件進行動畫設定嗎？**

可以。SmartArt 為圖形，因此您可以透過動畫 API（進入、退出、強調、移動路徑）套用 [standard animations](/slides/zh-hant/androidjava/powerpoint-animation/)，就像對其他圖形一樣。

**若不知道 SmartArt 的內部 ID，該如何在投影片上找到特定的 SmartArt？**

設定並使用「替代文字」(AltText)，依該值搜尋圖形——這是定位目標圖形的建議方式。

**我可以將 SmartArt 與其他圖形群組嗎？**

可以。您可以將 SmartArt 與其他圖形（圖片、表格等）群組，然後 [manipulate the group](/slides/zh-hant/androidjava/group/)。

**如何取得特定 SmartArt 的圖像（例如作為預覽或報告）？**

匯出圖形的縮圖/影像；函式庫可以將個別圖形 [render individual shapes](/slides/zh-hant/androidjava/create-shape-thumbnails/) 為光柵檔案（PNG/JPG/TIFF）。

**將整份簡報轉換為 PDF 時，SmartArt 的外觀會被保留嗎？**

會。渲染引擎針對 [PDF export](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/) 追求高忠實度，並提供多種品質與相容性選項。