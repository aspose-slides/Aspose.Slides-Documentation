---
title: 支援的檔案格式
type: docs
weight: 20
url: /zh-hant/cpp/supported-file-formats/
keywords:
- 檔案格式
- 支援的格式
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
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 能開啟、儲存與轉換的所有檔案格式——包括 PPT、PPTX 與 ODP——並清楚標示其匯入/匯出支援情形。"
---
## **概覽**

Aspose.Slides 支援 Microsoft PowerPoint 97 至 Office 365 的簡報檔案，亦包含 Microsoft PowerPoint for Mac。本篇文章列出程式庫支援的 PowerPoint 版本，並提供可載入、儲存或同時支援的檔案格式表。

本文同時回答有關 PDF 合規性、字型嵌入、受密碼保護的檔案、自訂字型、字型備援以及 XPS 匯出選項的常見問題。

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
此表格列出 Aspose.Slides for С++ 能夠載入與儲存的檔案格式：

|**格式**|**說明**|**載入**|**儲存**|**備註**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 投影片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 投影片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint 含巨集的簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint 含巨集的投影片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint 含巨集的範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 簡報範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|標籤影像檔案格式| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|增強型圖圖形檔案格式| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|便攜式文件格式|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML 紙張規範| |{{< emoticons/tick >}}| |
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

**我能將簡報儲存為符合檔案與無障礙標準的 PDF (PDF/A 與 PDF/UA) 嗎？**

是的。Aspose.Slides 透過 [PDF export options](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 中的 [compliance](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/set_compliance/) 設定，支援 PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b 以及 PDF/UA 等合規層級的匯出。

**在匯出為 PDF 時，程式庫是否支援字型嵌入，且能細部控制嵌入內容？**

是的。您可以決定字型是完整嵌入或僅嵌入使用到的子集合（子集），指定常見系統字型的處理方式，並透過 [PDF export options](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 針對 ASCII 文字進行設定。

**我可以在實際載入檔案前偵測它是否受密碼保護嗎？**

是的。使用 [factory-based inspection API](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentationfactory/) 時，您可以在不完全開啟簡報的情況下查詢檔案是否受密碼保護。

**程式庫是否提供字型備援機制並支援自訂字型？**

是的。程式庫支援 [loading](/slides/zh-hant/cpp/custom-font/) 與 [embedding](/slides/zh-hant/cpp/embedded-font/) 自訂字型，並提供字型 [fallback rules](/slides/zh-hant/cpp/fallback-font/) 以防止在渲染與轉換時出現缺字。

**我能將投影片匯出為 XPS，且能調校 XPS 輸出選項嗎？**

是的。支援 [Export to XPS](/slides/zh-hant/cpp/convert-powerpoint-to-xps/)，您可以調整相關的 [save options](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/xpsoptions/) 來控制 XPS 文件的輸出品質與內容。