---
title: 以 JavaScript 建立簡報
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
description: "使用 Aspose.Slides 建立簡報——產生 PPT、PPTX 與 ODP 檔案，受益於 OpenDocument 支援，並以程式方式儲存以獲得可靠的結果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中建立簡報、在第一張投影片加入文字方塊，並將結果儲存為檔案。

開始之前，請從 npm 安裝 `aspose.slides.via.java` 套件，並安裝其所需的 JDK、Python 與 C++ 建置工具。請參閱[安裝](/slides/zh-hant/nodejs-java/installation/)。

## **建立 PowerPoint 簡報**

若要建立簡報並在第一張投影片加入文字方塊，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。新簡報已預先包含一張空的投影片。
1. 透過索引 0，從[投影片集合](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getslides/)取得該投影片。
1. 使用[addAutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/addautoshape/) 方法加入矩形，並以[setText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/settext/) 設定其文字。
1. 以[save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/save/) 方法將簡報儲存為 PPTX 檔案。
1. 使用[dispose](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/dispose/) 方法釋放簡報，並結束程序。

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides 在一個 Java 虛擬機器中執行，該虛擬機器會讓 Node.js 持續執行，因此必須明確結束程序。
process.exit(0);
```

該矩形的左上角距離投影片左邊緣 50 點、上邊緣 50 點，寬度為 400 點、高度為 100 點。將程式碼另存為 *hello.js* 放在專案資料夾中，然後執行 `node hello.js`：它會在當前資料夾產生 *hello.pptx*，其中包含一張投影片，內含該矩形及其文字。

Aspose.Slides 在一個由 `java` 套件於 Node.js 進程內啟動的 Java 虛擬機器中執行。此虛擬機器會阻止 Node.js 在腳本執行完畢後自行退出，故範例最後以 `process.exit(0)` 結束。

若未取得授權，Aspose.Slides 亦會在每張儲存的投影片上加上評估水印；請參閱[授權](/slides/zh-hant/nodejs-java/licensing/)。

## **常見問題**

### 可以將新簡報儲存為哪些格式？

您可以儲存為[PPTX、PPT 與 ODP](/slides/zh-hant/nodejs-java/save-presentation/)，並匯出為[PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/nodejs-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/nodejs-java/render-a-slide-as-an-svg-image/)、以及[影像](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/)等格式。

### 可以從範本 (POTX/POTM) 開始並儲存為一般 PPTX 嗎？

可以。載入範本後儲存為所需格式；POTX/POTM/PPTM 以及其他類似格式[均受支援](/slides/zh-hant/nodejs-java/supported-file-formats/)。

### 建立簡報時，如何控制投影片尺寸/長寬比？

設定[投影片尺寸](/slides/zh-hant/nodejs-java/slide-size/)（包含 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

### 尺寸與座標以何種單位表示？

以點 (point) 為單位：1 吋等於 72 點。

### 如何處理包含大量媒體檔案的大型簡報，以降低記憶體使用？

使用[BLOB 管理策略](/slides/zh-hant/nodejs-java/manage-blob/)，透過暫存檔案限制記憶體內的儲存，並優先採用基於檔案的工作流程，而非純粹使用記憶體串流。

### 我可以平行建立/儲存簡報嗎？

您無法在[多執行緒](/slides/zh-hant/nodejs-java/multithreading/)中操作同一個[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)實例。請於每個執行緒或行程中執行獨立的實例。

### 如何移除試用水印與限制？

每個行程僅需[套用授權](/slides/zh-hant/nodejs-java/licensing/)。授權 XML 必須保持未被修改，若有多執行緒，授權設定亦須同步。

### 我可以對建立的 PPTX 進行數位簽章嗎？

可以。[數位簽章](/slides/zh-hant/nodejs-java/digital-signature-in-powerpoint/)（新增與驗證）在簡報中受到支援。

### 在建立的簡報中支援巨集 (VBA) 嗎？

可以。您可以[建立/編輯 VBA 專案](/slides/zh-hant/nodejs-java/presentation-via-vba/)，並儲存如 PPTM/PPSM 等巨集啟用檔案。