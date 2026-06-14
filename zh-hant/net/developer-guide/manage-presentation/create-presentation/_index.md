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
description: "在 .NET 中使用 Aspose.Slides 建立簡報 — 產生 PPT、PPTX 與 ODP 檔案，支援 OpenDocument，並以程式方式儲存以獲得可靠的結果。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中建立簡報、在投影片上加入簡單內容，並將結果儲存為檔案。同時示範如何建立並儲存新的簡報、開啟支援格式的現有簡報，並將其儲存為其他格式。此外，本文還包含一段簡短 FAQ，涵蓋有關格式、範本、投影片尺寸、單位、記憶體使用、執行緒、授權、數位簽章以及 VBA 支援的常見問題。

## **建立 PowerPoint 簡報**
若要在簡報的選定投影片上加入一條簡單的直線，請依照以下步驟：

1. 建立 Presentation 類別的實例。
2. 使用 Index 取得投影片的參照。
3. 透過 Shapes 物件的 AddAutoShape 方法，新增線條類型的 AutoShape。
4. 將修改後的簡報寫入為 PPTX 檔案。

以下範例中，我們已在簡報的第一張投影片加入了一條直線。

```c#
// 實例化一個代表簡報檔案的 Presentation 物件
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片
    ISlide slide = presentation.Slides[0];

    // 新增類型為線條的自動圖形
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **建立並儲存簡報**

<a name="csharp-create-save-presentation"><strong>步驟：在 C# 中建立並儲存簡報</strong></a>

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 將 _Presentation_ 儲存為 [SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 所支援的任何格式。

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **開啟並儲存簡報**

<a name="csharp-open-save-presentation"><strong>步驟：在 C# 中開啟並儲存簡報</strong></a>

1. 使用任意格式（例如 PPT、PPTX、ODP 等）建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 將 _Presentation_ 儲存為 [SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 所支援的任何格式。

```c#
// 載入 Presentation 中任何支援的檔案，例如 ppt、pptx、odp 等。
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **常見問題**

**我可以將新簡報儲存為哪些格式？**

您可以儲存為 [PPTX、PPT 與 ODP](/slides/zh-hant/net/save-presentation/)，並且可匯出為 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/net/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/net/convert-powerpoint-to-png/)，以及 [圖像](/slides/zh-hant/net/convert-powerpoint-to-png/)，等等。

**我可以從範本（POTX/POTM）開始，並儲存為一般的 PPTX 嗎？**

可以。載入範本後儲存為所需的格式；POTX、POTM、PPTM 以及其他類似格式皆[受支援](/slides/zh-hant/net/supported-file-formats/)。

**建立簡報時，如何控制投影片大小/長寬比？**

設定[投影片大小](/slides/zh-hant/net/slide-size/)（包含 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

**尺寸與座標的單位是什麼？**

以點 (point) 為單位：1 英吋等於 72 點。

**如何處理包含大量媒體檔案的超大型簡報以減少記憶體使用？**

使用[BLOB 管理策略](/slides/zh-hant/net/manage-blob/)，透過暫存檔限制記憶體內部儲存，並且優先採用檔案為基礎的工作流程，而非純粹的記憶體串流。

**我可以平行建立/儲存簡報嗎？**

您無法在[多個執行緒](/slides/zh-hant/net/multithreading/)中操作同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例。請為每個執行緒或程序執行獨立的實例。

**如何移除試用版浮水印與限制？**

[套用授權](/slides/zh-hant/net/licensing/)一次於每個程序。授權 XML 必須保持未修改，若有多個執行緒，授權設定亦需同步化。

**我可以對所建立的 PPTX 進行數位簽署嗎？**

可以。[數位簽章](/slides/zh-hant/net/digital-signature-in-powerpoint/)（加入與驗證）在簡報中受到支援。

**在建立的簡報中是否支援巨集 (VBA)？**

可以。您可[建立/編輯 VBA 專案](/slides/zh-hant/net/presentation-via-vba/)，並儲存支援巨集的檔案，例如 PPTM/PPSM。