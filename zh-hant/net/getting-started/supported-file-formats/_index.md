---
title: 支援的檔案格式
type: docs
weight: 30
url: /zh-hant/net/supported-file-formats/
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
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 能開啟、儲存和轉換的全部檔案格式——包括 PPT、PPTX 和 ODP——並提供清晰的匯入/匯出支援說明。"
---
## **概述**

Aspose.Slides 支援從 Microsoft PowerPoint 97 到 Office 365 的簡報檔案，亦包括 Microsoft PowerPoint for Mac。本篇文章列出程式庫支援的 PowerPoint 版本，並提供可載入、儲存或同時支援的檔案格式表。

本文亦解答有關 PDF 合規性、字型嵌入、受密碼保護的檔案、自訂字型、字型後備機制以及 XPS 匯出選項的常見問題。

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
- Microsoft PowerPoint for Mac
- Office 365

## **支援的檔案格式**
此表格列出 Aspose.Slides for .NET 可以載入與儲存的檔案格式：

|**格式**|**說明**|**載入**|**儲存**|**備註**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 投影片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 投影片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint 巨集啟用簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint 巨集啟用投影片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint 巨集啟用範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 簡報範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tag Image File Format||{{< emoticons/tick >}}||
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile Format||{{< emoticons/tick >}}||
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification||{{< emoticons/tick >}}||
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group||{{< emoticons/tick >}}||
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics||{{< emoticons/tick >}}||
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format||{{< emoticons/tick >}}||
|[BMP](https://docs.fileformat.com/image/bmp/)|Device Independent Bitmap||{{< emoticons/tick >}}||
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics||{{< emoticons/tick >}}||
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format||{{< emoticons/tick >}}||
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language||{{< emoticons/tick >}}||
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown||{{< emoticons/tick >}}|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 簡報||{{< emoticons/tick >}}|

## **常見問題**

**我可以將簡報儲存為符合檔案保存與可及性標準（PDF/A 與 PDF/UA）的 PDF 嗎？**

可以。Aspose.Slides 透過 [合規性](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/compliance/) 設定與 [PDF 匯出選項](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/)，支援匯出符合 PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b 以及 PDF/UA 等合規等級的 PDF。

**程式庫是否支援在匯出為 PDF 時嵌入字型，並能細緻控制嵌入的內容？**

可以。您可以透過 [PDF 匯出選項](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 控制字型是完整嵌入或僅嵌入子集（僅使用的字形），指定常見系統字型的處理方式，並設定 ASCII 文字的行為。

**我能在實際載入前偵測檔案是否受密碼保護嗎？**

可以。利用 [基於工廠的檢查 API](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/)，可在不完整開啟簡報檔的情況下查詢其是否受密碼保護。

**是否提供字型後備機制以及自訂字型的支援？**

可以。程式庫支援[載入](/slides/zh-hant/net/custom-font/)與[嵌入](/slides/zh-hant/net/embedded-font/)自訂字型，並提供字型[後備規則](/slides/zh-hant/net/fallback-font/)，以避免在渲染與轉換時出現缺字。

**我可以將投影片匯出為 XPS，且有調整 XPS 輸出的選項嗎？**

可以。支援[匯出至 XPS](/slides/zh-hant/net/convert-powerpoint-to-xps/)，且您可調整相關的[儲存選項](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/xpsoptions/)，以控制 XPS 文件的輸出品質與內容。