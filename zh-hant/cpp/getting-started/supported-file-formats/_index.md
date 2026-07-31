---
title: 支援的檔案格式
type: docs
weight: 20
url: /zh-hant/cpp/supported-file-formats/
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
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 可以開啟、儲存與轉換的所有檔案格式 — 包含 PPT、PPTX 與 ODP — 並提供清晰的匯入/匯出支援說明。"
---
## **概述**

Aspose.Slides 支援從 Microsoft PowerPoint 97 到 Office 365 的簡報檔案，包括 macOS 版 Microsoft PowerPoint。本篇文章列出程式庫支援的 PowerPoint 版本，並提供可載入、儲存或兩者皆可的檔案格式表。

本文亦回答有關 PDF 合規性、字型嵌入、受密碼保護的檔案、自訂字型、字型回退以及 XPS 匯出選項的常見問題。

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
此表列出 Aspose.Slides for C++ 可以載入與儲存的檔案格式：

|**格式**|**說明**|**載入**|**儲存**|**備註**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 幻燈片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 幻燈片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint 含巨集的簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint 含巨集的幻燈片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint 含巨集的範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 簡報範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tag Image File Format| |{{< emoticons/tick >}}||
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile Format| |{{< emoticons/tick >}}||
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification| |{{< emoticons/tick >}}||
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group| |{{< emoticons/tick >}}||
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics| |{{< emoticons/tick >}}||
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format| |{{< emoticons/tick >}}||
|[BMP](https://docs.fileformat.com/image/bmp/)|Device Independent Bitmap| |{{< emoticons/tick >}}||
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics| |{{< emoticons/tick >}}||
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format| |{{< emoticons/tick >}}||
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language| |{{< emoticons/tick >}}||
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 簡報| |{{< emoticons/tick >}}| 

## **常見問題**

**是否能將簡報儲存為符合封存與無障礙標準（PDF/A 與 PDF/UA）的 PDF？**

可以。Aspose.Slides 支援使用 [PDF 匯出選項](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 中的 [compliance](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/set_compliance/) 設定，匯出符合 PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b 以及 PDF/UA 等合規等級的 PDF。

**在匯出為 PDF 時，程式庫是否支援字型嵌入，且能細部控制嵌入方式？**

可以。您可以決定字型是完整嵌入還是子集（僅使用的字形），指定常見系統字型的處理方式，並透過 [PDF 匯出選項](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 設定 ASCII 文字的行為。

**是否能在實際載入之前偵測檔案是否受密碼保護？**

可以。使用 [factory‑based inspection API](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentationfactory/)，您可以在不完整開啟簡報的情況下查詢檔案是否受到密碼保護。

**是否提供字型回退機制與自訂字型支援？**

可以。程式庫支援[載入](/slides/zh-hant/cpp/custom-font/)和[嵌入](/slides/zh-hant/cpp/embedded-font/)自訂字型，並提供字型[回退規則](/slides/zh-hant/cpp/fallback-font/)，以防止在渲染與轉換時出現缺少字形的情況。

**是否能將投影片匯出為 XPS，且可調整 XPS 輸出選項？**

可以。支援[匯出為 XPS](/slides/zh-hant/cpp/convert-powerpoint-to-xps/)，且您可以調整相關的[儲存選項](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/xpsoptions/) 以控制 XPS 文件的品質與內容。