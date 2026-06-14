---
title: 在 C++ 中建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/cpp/create-presentation/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中建立簡報—產生 PPT、PPTX 與 ODP 檔案，支援 OpenDocument，並以程式方式儲存以獲得可靠的結果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中建立簡報、在投影片中加入簡單內容，並將結果儲存為檔案。

## **建立 PowerPoint 簡報**
若要在簡報的選取投影片上加入一條簡單的直線，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的執行個體。
1. 以 Index 取得投影片的參考。
1. 使用 Shapes 物件提供的 AddAutoShape 方法，新增類型為 Line 的 AutoShape。
1. 將修改後的簡報寫入為 PPTX 檔案。

在下方範例中，我們已在簡報的第一張投影片上加入一條直線。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **常見問與答**

**我可以將新簡報儲存為哪些格式？**

您可以儲存為 [PPTX, PPT, and ODP](/slides/zh-hant/cpp/save-presentation/)，並匯出為 [PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/cpp/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/cpp/convert-powerpoint-to-png/)、以及 [images](/slides/zh-hant/cpp/convert-powerpoint-to-png/)，等等。

**我可以從範本 (POTX/POTM) 開始並儲存為一般的 PPTX 嗎？**

可以。載入範本後儲存為所需格式；POTX/POTM/PPTM 等類似格式 [are supported](/slides/zh-hant/cpp/supported-file-formats/)。

**建立簡報時，如何控制投影片大小/長寬比？**

設定 [slide size](/slides/zh-hant/cpp/slide-size/)（包括 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

**尺寸和座標的單位是什麼？**

以點 (point) 為單位：1 英吋等於 72 單位。

**如何處理非常大的簡報（含大量媒體檔案）以減少記憶體使用？**

使用 [BLOB management strategies](/slides/zh-hant/cpp/manage-blob/)，透過暫存檔限制記憶體中的儲存，並優先採用基於檔案的工作流程而非純記憶體串流。

**我可以平行建立/儲存簡報嗎？**

您無法從 [multiple threads](/slides/zh-hant/cpp/multithreading/) 同時操作同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 實例。請為每個執行緒或行程使用獨立的實例。

**如何移除試用版浮水印與限制？**

在每個行程中 [Apply a license](/slides/zh-hant/cpp/licensing/)。授權 XML 必須保持未修改，若有多執行緒，授權設定需同步。

**我可以為建立的 PPTX 加上數位簽章嗎？**

可以。支援 [Digital signatures](/slides/zh-hant/cpp/digital-signature-in-powerpoint/)（簽署與驗證）於簡報。

**在建立的簡報中是否支援巨集 (VBA)？**

可以。您可以 [create/edit VBA projects](/slides/zh-hant/cpp/presentation-via-vba/) 並儲存含巨集的檔案，例如 PPTM/PPSM。