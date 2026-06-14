---
title: 使用 PowerPoint 外掛自動更新 OLE 物件
type: docs
weight: 10
url: /zh-hant/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE 物件
- 更新 OLE
- 自動
- 外掛
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 PowerPoint 中使用外掛與 Aspose.Slides for Java 自動更新 OLE 圖表和物件，並提供實用程式碼與最佳化技巧。"
---
## **簡介**

Aspose.Slides for Java 的客戶最常問的問題之一是如何建立或修改可編輯的圖表（或其他 OLE 物件），使其在簡報開啟時自動更新。遺憾的是，PowerPoint 並不像 Excel 與 Word 那樣支援自動巨集。唯一可用的巨集是 `Auto_Open` 和 `Auto_Close`，且這些巨集只能透過外掛自動執行。本技術小提示說明如何達成此目的。

## **自動更新 OLE 物件**

首先，有多個免費外掛可為 PowerPoint 加入 Auto_Open 巨集功能，例如 [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) 與 [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html)。

安裝其中一個外掛後，只需如下圖所示，在您的範本簡報中加入 `Auto_Open()` 巨集（若使用 Event Generator，則加入 `OnPresentationOpen()`）。

```java
// 逐一遍歷簡報中的每張投影片。
for (var oSlide : ActivePresentation.Slides) {
    // 遍歷目前投影片上的所有圖形。
    for (var oShape : oSlide.Shapes) {
        // 檢查此圖形是否為 OLE 物件。
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // 找到 OLE 物件。取得其物件參考並進行更新。
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // 現在，退出 OLE 伺服器程式。
            // 這會釋放記憶體，並防止任何問題。
            // 同時，將 oObject 設為 Nothing 以釋放物件。
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

使用 Aspose.Slides for Java 所做的任何 OLE 物件變更，皆會在 PowerPoint 開啟簡報時自動更新。若您有大量 OLE 物件且不想全部更新，只需在需要處理的圖形上加入自訂標記，並在巨集內檢查該標記即可。