---
title: 在 .NET 中建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/net/create-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中建立簡報——產生 PPT、PPTX 與 ODP 檔案，支援 OpenDocument，並以程式方式儲存以確保可靠的結果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中建立簡報、在第一張投影片加入文字方塊，並將結果儲存為檔案。亦示範如何建立並儲存空白簡報，及如何開啟已支援格式的現有簡報並將其儲存為其他格式。最後的簡短 FAQ 針對格式、範本、投影片大小、單位、記憶體使用、執行緒、授權、數位簽章以及 VBA 支援等常見問題提供說明。

在開始之前，請從 NuGet 將 Aspose.Slides 加入您的專案。請參閱 [安裝](/slides/zh-hant/net/installation/) 了解在 Windows、Linux 與 macOS 上使用的套件。

## **建立 PowerPoint 簡報**

若要建立簡報並在第一張投影片加入文字方塊，請依下列步驟執行：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的執行個體。新的簡報已包含一張空白投影片。
2. 透過索引 0 從 [Slides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/slides/zh-hant/) 集合取得該投影片。
3. 使用 [AddAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addautoshape/) 方法加入矩形，並設定其 [text](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/text/)。
4. 使用 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法將簡報儲存為 PPTX 檔案。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

此矩形的左上角距投影片左邊緣及上邊緣各 50 點，寬 400 點、高 100 點。儲存的檔案包含一張包含該矩形及其文字的投影片。若未取得授權，Aspose.Slides 會在每張儲存的投影片上加入評估水印；請參閱 [授權](/slides/zh-hant/net/licensing/)。

## **建立並儲存簡報**

<a name="csharp-create-save-presentation"></a>

若要建立空白簡報並儲存，請建立 [Presentation] 類別的執行個體，並以 [SaveFormat] 列舉中的任意格式儲存。結果會得到一個包含一張空白投影片的簡報。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **開啟並儲存簡報**

<a name="csharp-open-save-presentation"></a>

若要將簡報從一種格式轉換為另一種格式，請將其路徑傳遞給 [Presentation] 建構式以開啟，然後以目標格式儲存。Aspose.Slides 能從檔案本身偵測輸入格式，例如 PPT、PPTX 或 ODP。

以下範例假設工作目錄中有名為 *Sample.odp* 的 OpenDocument 簡報，並將其儲存為 PPTX。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **常見問題**

### 我可以將新簡報儲存為哪些格式？

您可以儲存為 [PPTX、PPT 與 ODP](/slides/zh-hant/net/save-presentation/)，並可匯出為 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/net/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/net/render-a-slide-as-an-svg-image/) 以及 [影像](/slides/zh-hant/net/convert-powerpoint-to-png/) 等格式。

### 我可以從範本 (POTX/POTM) 開始，並儲存為一般的 PPTX 嗎？

可以。載入範本後儲存為所需格式；POTX、POTM、PPTM 以及其他類似格式 [已支援](/slides/zh-hant/net/supported-file-formats/)。

### 建立簡報時，如何控制投影片尺寸/長寬比？

設定 [投影片大小](/slides/zh-hant/net/slide-size/)（包括 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

### 尺寸與座標以什麼單位衡量？

使用點 (points) 為單位：1 吋等於 72 點。

### 如何處理包含大量媒體檔案的大型簡報以降低記憶體使用量？

使用 [BLOB 管理策略](/slides/zh-hant/net/manage-blob/)。透過暫存檔限制記憶體內儲存，並偏好基於檔案的工作流程而非純記憶體串流。

### 我可以平行建立/儲存簡報嗎？

您無法在 [多執行緒](/slides/zh-hant/net/multithreading/) 中操作相同的 [Presentation] 執行個體。請於每個執行緒或行程中使用獨立的實例。

### 如何移除試用版水印與限制？

每個行程僅需 [套用授權](/slides/zh-hant/net/licensing/)。授權 XML 必須保持未修改，若有多執行緒，授權設定亦需同步。

### 我可以為所建立的 PPTX 加上數位簽章嗎？

可以。[數位簽章](/slides/zh-hant/net/digital-signature-in-powerpoint/)（加入與驗證）在簡報中受到支援。

### 在建立的簡報中是否支援巨集 (VBA)？

可以。您可以 [建立/編輯 VBA 專案](/slides/zh-hant/net/presentation-via-vba/) 並儲存含巨集的檔案，例如 PPTM/PPSM。