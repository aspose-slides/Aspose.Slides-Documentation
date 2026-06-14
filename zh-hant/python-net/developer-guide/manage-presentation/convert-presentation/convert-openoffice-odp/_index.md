---
title: 在 Python 中轉換 OpenDocument 簡報
linktitle: 轉換 OpenDocument
type: docs
weight: 10
url: /zh-hant/python-net/convert-openoffice-odp/
keywords:
- 轉換 OpenDocument
- 轉換 ODP
- ODP 轉 PDF
- ODP 轉 PPT
- ODP 轉 PPTX
- ODP 轉 XPS
- ODP 轉 HTML
- ODP 轉 TIFF
- ODP 轉 SWF
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中將 OpenDocument ODP 轉換為 PDF、PPT、PPTX、XPS、HTML、TIFF 或 SWF：程式碼範例、高保真、批次轉換與自訂。"
---
## **簡介**

[**Aspose.Slides API**](https://products.aspose.com/slides/zh-hant/python-net/) 允許您將 OpenDocument (ODP) 簡報轉換為多種格式 (HTML、PDF、TIFF、SWF、XPS 等)。用於將 ODP 檔案轉換為其他文件格式的 API 與用於 PowerPoint (PPT 和 PPTX) 轉換操作的 API 相同。

例如，如果您需要將 ODP 簡報轉換為 PDF，您可以按如下方式操作：

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **常見問題**

**我可以在不安裝 LibreOffice 或 OpenOffice 的情況下將 ODP 轉換為 PPTX 嗎？**

可以。Aspose.Slides 是一個完整的獨立庫，能夠處理 PowerPoint 與 OpenOffice 格式，且不需要任何外部應用程式。

**Aspose.Slides 能夠開啟和儲存受密碼保護的 ODP/OTP 檔案嗎？**

可以。當您提供密碼時，它可以 [載入加密的簡報](/slides/zh-hant/python-net/password-protected-presentation/)，也可以將簡報儲存為加密和保護設定。

**我可以在轉換 ODP 之前提取內嵌的媒體檔案（音訊/影片）嗎？**

可以。Aspose.Slides 讓您能夠存取並提取簡報中內嵌的 [音訊](/slides/zh-hant/python-net/audio-frame/) 與 [影片](/slides/zh-hant/python-net/video-frame/)，這對於轉換前的處理或單獨再利用很有幫助。

**我可以將轉換後的 ODP 儲存為 Strict Office Open XML 嗎？**

可以。將檔案儲存為 PPTX 時，您可以透過 [儲存選項](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pptxoptions/) 啟用 Strict OOXML，以符合更嚴格的合規要求。