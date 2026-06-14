---
title: 在 Android 上建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/androidjava/create-presentation/
keywords:
- 建立簡報
- 新簡報
- 建立 PPT
- 新 PPT
- 建立 PPTX
- 新 PPTX
- 建立 ODP
- 新 ODP
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides for Java 建立簡報——產生 PPT、PPTX 與 ODP 檔案，受惠於 OpenDocument 支援，並以程式方式儲存以確保可靠的結果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中建立簡報、向投影片添加簡單內容，並將結果儲存為檔案。它還示範了如何建立並儲存新簡報、以支援的格式開啟現有簡報，並將其另存為其他格式。

## **建立 PowerPoint 簡報**
若要在簡報的選定投影片上添加一條簡單的純線，請依照以下步驟操作：

1. 建立 Presentation 類別的實例。
1. 透過索引取得投影片的參考。
1. 使用 Shapes 物件提供的 addAutoShape 方法，新增類型為 Line 的 AutoShape。
1. 將修改後的簡報寫入為 PPTX 檔案。

在下方範例中，我們已在簡報的第一張投影片加入一條線。

```java
// 實例化一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增類型為線的 AutoShape
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以將新簡報儲存為哪些格式？**

您可以儲存為 [PPTX, PPT, and ODP](/slides/zh-hant/androidjava/save-presentation/)，並匯出為 [PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/androidjava/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)，以及[images](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)，等其他格式。

**我可以從範本 (POTX/POTM) 開始，並儲存為一般的 PPTX 嗎？**

是的。載入範本並儲存為所需的格式；POTX/POTM/PPTM 與類似的格式[已支援](/slides/zh-hant/androidjava/supported-file-formats/)。

**在建立簡報時，如何控制投影片尺寸/長寬比？**

設定[slide size](/slides/zh-hant/androidjava/slide-size/)（包括 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

**大小與座標的單位是什麼？**

使用點（point）作為單位：1 英吋等於 72 點。

**如何處理含有大量媒體檔案的超大型簡報以減少記憶體使用？**

使用[BLOB 管理策略](/slides/zh-hant/androidjava/manage-blob/)，透過暫存檔限制記憶體內的儲存，並且優先使用基於檔案的工作流程，而非純粹的記憶體串流。

**我可以平行建立/儲存簡報嗎？**

您無法在多個執行緒中同時操作同一個[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)實例。請為每個執行緒或程序執行獨立的實例。

**如何移除試用版浮水印與限制？**

在每個程序中[套用授權](/slides/zh-hant/androidjava/licensing/)一次。授權 XML 必須保持未被修改，若有多個執行緒，授權設定需同步執行。

**我可以對我建立的 PPTX 進行數位簽章嗎？**

是的。[Digital signatures](/slides/zh-hant/androidjava/digital-signature-in-powerpoint/)（加入與驗證）已支援於簡報。

**在建立的簡報中是否支援巨集 (VBA)？**

是的。您可以[建立/編輯 VBA 專案](/slides/zh-hant/androidjava/presentation-via-vba/)，並儲存支援巨集的檔案，例如 PPTM/PPSM。