---
title: 在 Python 中將 PowerPoint 簡報轉換為 XPS
linktitle: PowerPoint 轉 XPS
type: docs
weight: 70
url: /zh-hant/python-net/convert-powerpoint-to-xps/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- PowerPoint 轉 XPS
- 簡報 轉 XPS
- PPT 轉 XPS
- PPTX 轉 XPS
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中將 PowerPoint PPT/PPTX 轉換為高品質、跨平台的 XPS。獲取逐步指南與範例程式碼。"
---
## **概述**

Aspose.Slides 允許您透過將 PPT 或 PPTX 檔案儲存為 XPS 格式來將 PowerPoint 簡報轉換為 XPS。本文說明何時 XPS 格式可能有用，並展示如何使用 Aspose.Slides 以預設設定或自訂 [XpsOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/xpsoptions/) 設定執行轉換。

## **關於 XPS**
Microsoft 開發了 [XPS](https://docs.fileformat.com/page-description-language/xps/) 作為 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它允許您透過產生與 PDF 非常相似的檔案來列印內容。XPS 格式基於 XML。XPS 檔案的版面配置或結構在所有作業系統與印表機上皆保持相同。

## 何時使用 Microsoft XPS 格式

{{% alert color="primary" %}} 

若要了解 Aspose.Slides 如何將 PPT 或 PPTX 簡報轉換為 XPS 格式，您可以查看[此免費線上轉換應用程式](https://products.aspose.app/slides/zh-hant/conversion)。

{{% /alert %}} 

如果您想降低儲存成本，可以將 Microsoft PowerPoint 簡報轉換為 XPS 格式。如此一來，您會發現儲存、共享與列印文件更加方便。

Microsoft 持續在 Windows（甚至在 Windows 10）中實作對 XPS 的強大支援，因此您可能會考慮將檔案儲存為此格式。如果您使用 Windows 8.1、Windows 8、Windows 7 或 Windows Vista，XPS 實際上可能是某些操作的最佳選擇。

- **Windows 8** 使用 OXPS（Open XPS）格式作為 XPS 檔案。OXPS 是原始 XPS 格式的標準化版本。Windows 8 對 XPS 檔案的支援優於 PDF 檔案。 
  - **XPS**：內建 XPS 檢視器/閱讀器，並提供列印至 XPS 功能。 
  - **PDF**：提供 PDF 閱讀器，但沒有列印至 PDF 功能。 

- **Windows 7** 與 **Windows Vista** 使用原始 XPS 格式。這些作業系統對 XPS 檔案的支援也優於 PDF。 
  - **XPS**：內建 XPS 檢視器，並提供列印至 XPS 功能。 
  - **PDF**：無 PDF 閱讀器，亦無列印至 PDF 功能。 

|<p>**輸入 PPT(X)：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**輸出 XPS：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft 最終在 Windows 10 中透過「列印至 PDF」功能實作了 PDF 的列印支援。此之前，使用者預期透過 XPS 格式來列印文件。

## 使用 Aspose.Slides 進行 XPS 轉換

在 .NET 的 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/python-net/) 中，您可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別提供的 [**Save**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 方法將整個簡報轉換為 XPS 文件。

將簡報轉換為 XPS 時，您必須使用以下任一設定儲存簡報：

- 預設設定（不使用 [**XPSOptions**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/xpsoptions/)）
- 自訂設定（使用 [**XPSOptions**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/xpsoptions/)）

### **使用預設設定將簡報轉換為 XPS**

以下 Python 範例程式碼示範如何使用標準設定將簡報轉換為 XPS 文件：

```py
import aspose.slides as slides

# 建立一個代表簡報檔案的 Presentation 物件
pres = slides.Presentation("Convert_XPS.pptx")

# 將簡報儲存為 XPS 文件
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **使用自訂設定將簡報轉換為 XPS**
以下範例程式碼示範如何在 Python 中使用自訂設定將簡報轉換為 XPS 文件：

```py
import aspose.slides as slides

# 建立一個代表簡報檔案的 Presentation 物件
pres = slides.Presentation("Convert_XPS_Options.pptx")

# 建立 TiffOptions 類別實例
options = slides.export.XpsOptions()

# 將 MetaFiles 儲存為 PNG
options.save_metafiles_as_png = True

# 將簡報儲存為 XPS 文件
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **常見問題**

**我可以將 XPS 儲存至串流而非檔案嗎？**

是的——Aspose.Slides 允許您直接匯出至串流，這在 Web API、伺服器端管線或任何需要在不觸及檔案系統的情況下傳送 XPS 的情境中特別理想。

**隱藏投影片會被帶入 XPS 嗎？我可以排除它們嗎？**

預設情況下，僅會渲染一般（可見）投影片。您可以在儲存為 XPS 之前透過[包含或排除隱藏投影片](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/)以及[匯出設定](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/xpsoptions/)來控制，確保輸出正好包含您想要的頁面。