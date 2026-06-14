---
title: 使用 JavaScript 建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 建立簡報—產生 PPT、PPTX 與 ODP 檔案，受益於 OpenDocument 支援，並以程式方式儲存以確保可靠的結果。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中建立簡報、在投影片上新增簡單內容，並將結果儲存為檔案。

## **建立 PowerPoint 簡報**

若要在簡報的選定投影片上加入一條簡單的直線，請依照以下步驟操作：

1. 建立 Presentation 類別的實例。
1. 使用索引取得投影片的參照。
1. 使用 Shapes 物件提供的 addAutoShape 方法，新增類型為 Line 的 AutoShape。
1. 將修改後的簡報寫入為 PPTX 檔案。

以下範例中，我們已在簡報的第一張投影片上加入一條直線。

```javascript
// 實例化一個表示簡報檔的 Presentation 物件
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增類型為 line 的自動形狀
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以將新簡報儲存為哪些格式？**

您可以儲存為 [PPTX、PPT 與 ODP](/slides/zh-hant/nodejs-java/save-presentation/)，並匯出為 [PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/nodejs-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/)，以及 [images](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 等格式。

**我可以從模板 (POTX/POTM) 開始，並儲存為普通的 PPTX 嗎？**

是的。載入模板後儲存為所需格式；POTX/POTM/PPTM 及其他類似格式 [已受支援](/slides/zh-hant/nodejs-java/supported-file-formats/)。

**建立簡報時，如何控制投影片尺寸/長寬比？**

設定 [投影片尺寸](/slides/zh-hant/nodejs-java/slide-size/)（包括 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

**尺寸與座標的單位是什麼？**

以點 (point) 為單位：1 吋等於 72 點。

**如何處理包含大量媒體檔案的超大型簡報，以降低記憶體使用量？**

使用 [BLOB 管理策略](/slides/zh-hant/nodejs-java/manage-blob/)，透過暫存檔限制記憶體內部儲存，並優先使用檔案為基礎的工作流程，而非純記憶體串流。

**我可以平行建立/儲存簡報嗎？**

您無法在多個執行緒中同時操作相同的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例；請在每個執行緒或程序中執行獨立的實例。

**我該如何移除試用版浮水印與限制？**

[套用授權](/slides/zh-hant/nodejs-java/licensing/) 每個程序一次。授權 XML 必須保持未修改，且若有多執行緒，授權設定需同步執行。

**我可以為我建立的 PPTX 加上數位簽章嗎？**

是的。支援 [數位簽章](/slides/zh-hant/nodejs-java/digital-signature-in-powerpoint/)（加入與驗證）於簡報。

**在建立的簡報中是否支援巨集 (VBA)？**

是的。您可以 [建立/編輯 VBA 專案](/slides/zh-hant/nodejs-java/presentation-via-vba/)，並儲存為支援巨集的檔案，例如 PPTM/PPSM。