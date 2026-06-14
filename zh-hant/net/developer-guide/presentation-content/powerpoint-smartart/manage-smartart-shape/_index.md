---
title: 在 .NET 中管理簡報的 SmartArt 圖形
linktitle: SmartArt 圖形
type: docs
weight: 20
url: /zh-hant/net/manage-smartart-shape/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中自動化 PowerPoint SmartArt 的建立、編輯與樣式設定，提供簡潔的程式碼範例與以效能為導向的指引。"
---
## **概述**

Aspose.Slides 允許您以程式方式在 PowerPoint 簡報中建立與管理 SmartArt 圖形。本文說明如何將 SmartArt 形狀新增至投影片、存取現有的 SmartArt 形狀、依特定版面配置類型查找 SmartArt，並透過變更 SmartArt 樣式或色彩樣式來更新其視覺外觀。

範例示範如何透過簡報投影片的圖形集合處理 SmartArt 形狀、檢查圖形是否為 SmartArt，並進一步修改或檢視其屬性。

## **建立 SmartArt 形狀**
Aspose.Slides for .NET 現在可在投影片中從頭開始新增自訂 SmartArt 形狀。Aspose.Slides for .NET 提供了最簡單的 API，以最容易的方式建立 SmartArt 形狀。若要在投影片中建立 SmartArt 形狀，請遵循以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。
- 使用其 Index 取得投影片的參考。
- 透過設定 LayoutType 來新增 SmartArt 形狀。
- 將修改後的簡報寫入為 PPTX 檔案。

```c#
 // 實例化簡報
 using (Presentation pres = new Presentation())
 {
 
     // 存取簡報投影片
     ISlide slide = pres.Slides[0];
 
     // 新增 Smart Art 形狀
     ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
 
     // 儲存簡報
     pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **存取投影片上的 SmartArt 形狀**
以下程式碼將用於存取簡報投影片中新增的 SmartArt 形狀。在範例程式碼中，我們會遍歷投影片內的每個圖形，並檢查它是否為 SmartArt 形狀。若圖形屬於 SmartArt 類型，則會將其類型轉換為 SmartArt 實例。

```c#
 // 載入所需的簡報
 using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
 {
 
     // 遍歷第一張投影片內的每個圖形
     foreach (IShape shape in pres.Slides[0].Shapes)
     {
         // 檢查圖形是否為 SmartArt 類型
         if (shape is ISmartArt)
         {
             // 將圖形類型轉換為 SmartArtEx
             ISmartArt smart = (ISmartArt)shape;
             System.Console.WriteLine("Shape Name:" + smart.Name);
 
         }
     }
 }
```

## **以特定版面配置類型存取 SmartArt 形狀**
以下範例程式碼可協助存取具有特定 LayoutType 的 SmartArt 形狀。請注意，SmartArt 的 LayoutType 為唯讀，僅在新增 SmartArt 形狀時設定，無法變更。

- 建立 `Presentation` 類別的執行個體，並載入含有 SmartArt 形狀的簡報。
- 使用其 Index 取得第一張投影片的參考。
- 遍歷第一張投影片內的每個圖形。
- 檢查圖形是否為 SmartArt 類型，若是則將選取的圖形轉型為 SmartArt。
- 判斷 SmartArt 形狀的特定 LayoutType，並依需求執行後續操作。

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 遍歷第一張投影片內的每個圖形
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 檢查圖形是否為 SmartArt 類型
        if (shape is ISmartArt)
        {
            // 將圖形類型轉換為 SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // 檢查 SmartArt 版面配置
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```

## **變更 SmartArt 形狀樣式**
以下範例程式碼可協助存取具有特定 LayoutType 的 SmartArt 形狀。

- 建立 `Presentation` 類別的執行個體，並載入含有 SmartArt 形狀的簡報。
- 使用其 Index 取得第一張投影片的參考。
- 遍歷第一張投影片內的每個圖形。
- 檢查圖形是否為 SmartArt 類型，若是則將選取的圖形轉型為 SmartArt。
- 找出具有特定 Style 的 SmartArt 形狀。
- 為 SmartArt 形狀設定新的 Style。
- 儲存簡報。

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 遍歷第一張投影片內的每個圖形
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 檢查圖形是否為 SmartArt 類型
        if (shape is ISmartArt)
        {
            // 將圖形類型轉換為 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // 檢查 SmartArt 樣式
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // 變更 SmartArt 樣式
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // 儲存簡報
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```

## **變更 SmartArt 形狀色彩樣式**
在本範例中，我們將學習如何變更任意 SmartArt 形狀的色彩樣式。以下範例程式碼會存取具有特定色彩樣式的 SmartArt 形狀，並變更其樣式。

- 建立 `Presentation` 類別的執行個體，並載入含有 SmartArt 形狀的簡報。
- 使用其 Index 取得第一張投影片的參考。
- 遍歷第一張投影片內的每個圖形。
- 檢查圖形是否為 SmartArt 類型，若是則將選取的圖形轉型為 SmartArt。
- 找出具有特定 Color Style 的 SmartArt 形狀。
- 為 SmartArt 形狀設定新的 Color Style。
- 儲存簡報。

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 遍歷第一張投影片內的每個圖形
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 檢查圖形是否為 SmartArt 類型
        if (shape is ISmartArt)
        {
            // 將圖形類型轉換為 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // 檢查 SmartArt 顏色類型
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // 變更 SmartArt 顏色類型
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // 儲存簡報
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**我可以將 SmartArt 作為單一物件進行動畫化嗎？**

可以。SmartArt 本身即為一個圖形，您可使用動畫 API 為其套用[標準動畫](/slides/zh-hant/net/powerpoint-animation/)（進場、退場、強調、移動路徑），方式與其他圖形相同。

**如果不知道 SmartArt 的內部 ID，我該如何在投影片上找到特定的 SmartArt？**

設定並使用備用文字 (AltText)，依該值搜尋圖形——這是定位目標圖形的建議方式。

**我可以將 SmartArt 與其他圖形群組嗎？**

可以。您可以將 SmartArt 與其他圖形（圖片、表格等）群組，然後[操作該群組](/slides/zh-hant/net/group/)。

**我如何取得特定 SmartArt 的影像（例如，用於預覽或報告）？**

匯出圖形的縮圖/圖像；函式庫可將[單一圖形轉為點陣檔](/slides/zh-hant/net/create-shape-thumbnails/)（PNG/JPG/TIFF）。

**將整個簡報轉換為 PDF 時，SmartArt 的外觀會被保留嗎？**

會。渲染引擎針對[PDF 匯出](/slides/zh-hant/net/convert-powerpoint-to-pdf/)提供高保真度，且具多種品質與相容性選項。