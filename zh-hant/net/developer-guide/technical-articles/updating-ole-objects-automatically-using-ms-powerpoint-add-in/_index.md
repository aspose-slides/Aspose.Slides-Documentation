---
title: 使用 PowerPoint 外掛程式自動更新 OLE 物件
type: docs
weight: 10
url: /zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE 物件
- 更新 OLE
- 自動
- 外掛程式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: 了解如何使用外掛程式和 Aspose.Slides for .NET 在 PowerPoint 中自動更新 OLE 圖表與物件，並提供實用程式碼與最佳化技巧。
---
## **簡介**

Aspose.Slides for .NET 客戶最常提出的問題之一是如何建立或修改可編輯的圖表（或其他 OLE 物件），讓它們在簡報開啟時自動更新。遺憾的是，PowerPoint 並不像 Excel 與 Word 那樣支援自動宏。唯一可用的宏是 `Auto_Open` 和 `Auto_Close`，而且只能從外掛程式自動執行。此簡短的技術提示說明如何達成此目的。

## **自動更新 OLE 物件**

首先，有幾個免費的外掛程式可以為 PowerPoint 加入 Auto_Open 巨集功能，例如 [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) 與 [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html)。

安裝其中一個外掛程式後，只需將 `Auto_Open()` 巨集（若使用 Event Generator，則使用 `OnPresentationOpen()`）加入您的範本簡報，如下所示：

```cs
public void Auto_Open()
{
    // 逐一遍歷簡報中的每張投影片。
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // 遍歷目前投影片上的所有圖形。
        foreach (var oShape in oSlide.Shapes)
        {
            // 檢查此圖形是否為 OLE 物件。
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // 找到 OLE 物件。取得其物件參考並進行更新。
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // 現在，退出 OLE 伺服器程式。
                // 此舉可釋放記憶體，並防止任何問題。
                // 此外，將 oObject 設為 Nothing 以釋放物件。
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

對 Aspose.Slides for .NET 所做的 OLE 物件變更，PowerPoint 開啟簡報時會自動更新。如果您有大量 OLE 物件且不想全部更新，只需在需要處理的形狀加入自訂標記，並在巨集裡檢查該標記。