---
title: 支援的檔案格式
type: docs
weight: 150
url: /zh-hant/androidjava/supported-file-formats/
keywords:
- 檔案格式
- 支援格式
- PPT
- POT
- PPS
- PPTX
- POTX
- PPSX
- PPTM
- PPSM
- POTM
- ODP
- FODP
- OTP
- TIFF
- EMF
- PDF
- XPS
- JPEG
- PNG
- GIF
- BMP
- SVG
- SWF
- HTML
- XAML
- MD
- XML
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Android via Java 能開啟、儲存與轉換的所有檔案格式 —— 包含 PPT、PPTX 與 ODP —— 並附有清晰的匯入/匯出支援說明。"
---
## **概述**

Aspose.Slides 支援從 Microsoft PowerPoint 97 到 Office 365 的簡報檔案，包括 Microsoft PowerPoint for Mac。本文件列出函式庫支援的 PowerPoint 版本，並提供可載入、儲存或兩者皆支援的檔案格式表。

本文亦說明 PDF 合規性、字型嵌入、受密碼保護的檔案、客製字型、字型回退機制以及 XPS 匯出選項的相關常見問題。

## **支援的 Microsoft PowerPoint 版本**
- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for MAC
- Office 365

## **支援的檔案格式**
此表格列出 Aspose.Slides for Android via Java 可載入與儲存的檔案格式：

|**格式**|**說明**|**載入**|**儲存**|**備註**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 投影片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 投影片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|支援巨集的 PowerPoint 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|支援巨集的 PowerPoint 投影片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|支援巨集的 PowerPoint 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 簡報範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tag Image File Format| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile Format| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|Device Independent Bitmap| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 簡報| |{{< emoticons/tick >}}| |

## **常見問題**

**我可以將簡報儲存為符合存檔與可存取性標準 (PDF/A 與 PDF/UA) 的 PDF 嗎？**

是的。Aspose.Slides 透過 [PDF 匯出選項](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/) 中的 [compliance](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/#setCompliance-int-) 設定，支援 PDF/A‑2a、PDF/A‑2b、PDF/A‑2u、PDF/A‑3a、PDF/A‑3b 以及 PDF/UA 等合規等級。

**函式庫在匯出為 PDF 時是否支援字型嵌入，且能細緻控制嵌入內容？**

是的。您可以決定字型是完整嵌入或僅嵌入使用到的字形（子集合），指定系統字型的處理方式，並透過 [PDF 匯出選項](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/) 設定 ASCII 文字的行為。

**我能在真正載入檔案之前偵測它是否受密碼保護嗎？**

可以。使用 [基於工廠的檢查 API](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationfactory/) ，您可以在不完整開啟簡報的情況下查詢檔案是否受密碼保護。

**是否提供字型回退機制及自訂字型支援？**

是的。函式庫支援 [載入](/slides/zh-hant/androidjava/custom-font/) 與 [嵌入](/slides/zh-hant/androidjava/embedded-font/) 自訂字型，並提供字型 [回退規則](/slides/zh-hant/androidjava/fallback-font/)，避免在轉換與渲染時出現缺字情況。

**我可以將投影片匯出為 XPS 嗎？是否有調整 XPS 輸出的選項？**

可以。支援 [匯出為 XPS](/slides/zh-hant/androidjava/convert-powerpoint-to-xps/)，您亦可透過相關的 [儲存選項](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xpsoptions/) 調整 XPS 文件的品質與內容。