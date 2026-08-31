---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /zh-hant/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- PowerPoint 自動化 Python
- Python PPT 程式庫
- 匯出 PowerPoint 為 PDF Python
- 匯出 PowerPoint 為 SVG Python
- 在 Python 中編輯 PowerPoint
- Python PowerPoint（無需 Microsoft Office）
- 使用 Python 管理 PPTX
- Python 投影片預覽
- Python 為投影片加入音訊
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET 提供完整的功能集，包括管理文字、圖形、表格與動畫、為投影片加入音訊與影片、投影片預覽，以及匯出為 SVG、PDF 等格式。"
---
{{% alert color="info" %}}

**歡迎使用 Aspose.Slides for Python via .NET**

![Aspose.Slides for Python via .NET 產品標誌](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET 是一個強大的類別庫，允許您的應用程式在不需要 Microsoft PowerPoint® 的情況下讀寫 PowerPoint® 簡報。

它是第一個也是唯一一個為 Python 開發人員提供完整 PowerPoint® 文件管理功能的元件。

Aspose.Slides for Python via .NET 包含廣泛的功能，例如處理文字、形狀、表格和動畫；新增音訊和視訊；預覽投影片；以及將投影片匯出為 SVG、PDF 等格式。

{{% /alert %}}

## 安裝 Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

此套件已包含所需的 .NET 執行環境，無需額外安裝，也不需要 Microsoft PowerPoint。支援 Windows、Linux 或 macOS 上的 Python 3.7 及以上版本。

## 使用 Python 建立 PowerPoint 簡報

此範例會建立簡報，於第一張投影片加入文字形狀，並將結果同時儲存為 PPTX 與 PDF。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

執行後會將 `presentation.pptx`（約 34 KB）與 `presentation.pdf`（約 36 KB）寫入工作目錄。

若未授權，函式庫會以評估模式執行，會加入浮水印且限制投影片數量。請參閱[授權](/slides/zh-hant/python-net/licensing/) 以套用授權。

## Aspose.Slides for Python via .NET 資源

探索以下有用資源：

- [Aspose.Slides for Python via .NET 線上文件](/slides/zh-hant/python-net/)
- [Aspose.Slides for Python via .NET 功能](/slides/zh-hant/python-net/features-overview/)
- [Aspose.Slides for Python via .NET 發行說明](https://releases.aspose.com/slides/zh-hant/python-net/release-notes/)
- [Aspose.Slides for Python via .NET 產品頁面](https://products.aspose.com/slides/zh-hant/python-net/)
- [下載 Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/zh-hant/python-net/)
- [安裝 Aspose.Slides for Python via .NET PyPi 套件](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API 參考手冊](https://reference.aspose.com/slides/zh-hant/python-net/)
- [Aspose.Slides for Python via .NET 免費支援論壇](https://forum.aspose.com/c/slides/zh-hant/11)
- [Aspose.Slides for Python via .NET 付費支援服務台](https://helpdesk.aspose.com/)

## 常見問題

### 什麼是 Aspose.Slides for Python via .NET？

Aspose.Slides for Python via .NET 是一個功能強大的 Python 程式庫，允許您在未安裝 Microsoft PowerPoint 的情況下，以程式方式建立、編輯與轉換 PowerPoint 簡報（PPT、PPTX、ODP）。

### Aspose.Slides 支援哪些簡報功能？

此函式庫支援管理文字、形狀、表格、圖表、動畫、母片、音訊、視訊等功能，亦可進行投影片預覽、繪製，並匯出為 PDF、SVG、HTML 以及影像等格式。

### 我可以使用 Aspose.Slides 轉換簡報為其他格式嗎？

可以。Aspose.Slides 能將 PowerPoint 檔案轉換為 PDF、SVG、HTML、JPG、PNG、TIFF 及其他格式，且具備高保真度與效能。

### 使用 Aspose.Slides 是否需要 Microsoft PowerPoint？

不需要。Aspose.Slides 為獨立的 API，無需 Microsoft Office 或任何第三方軟體。

### Aspose.Slides for Python via .NET 支援哪些平台？

它是跨平台的，可在 Windows、Linux 與 macOS 環境中運作。

### 如何開始使用 Aspose.Slides for Python？

您可以透過 PyPi 安裝，並參閱[開發者指南](/slides/zh-hant/python-net/developer-guide/) 開始使用示例、API 參考與教學。