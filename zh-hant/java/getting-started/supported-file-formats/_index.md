---
title: 支援的檔案格式
type: docs
weight: 20
url: /zh-hant/java/supported-file-formats/
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
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 可開啟、儲存與轉換的所有檔案格式——包括 PPT、PPTX 與 ODP——並附有清晰的匯入/匯出支援說明。"
---
## **概觀**

Aspose.Slides 支援從 Microsoft PowerPoint 97 到 Office 365 的簡報檔案，亦包括 Microsoft PowerPoint for Mac。本文章列出程式庫支援的 PowerPoint 版本，並提供可載入、儲存或兩者皆可的檔案格式表。

本文亦回答有關 PDF 合規性、字型嵌入、受密碼保護的檔案、自訂字型、字型備援以及 XPS 匯出選項的常見問題。

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
此表格列出 Aspose.Slides for Java 可載入和儲存的檔案格式：

|**格式**|**說明**|**載入**|**儲存**|**備註**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint 含巨集的簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint 含巨集的放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint 含巨集的範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 簡報範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|標籤影像檔案格式| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|增強型中繼格式| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|可攜式文件格式|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML 紙張規格| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|聯合圖像專家組| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|可攜式網路圖形| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|圖形交換格式| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|設備獨立點陣圖| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|可伸縮向量圖形| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|小型網頁格式| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|超文字標記語言|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|可延伸應用程式標記語言| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 簡報| |{{< emoticons/tick >}}| |

## **常見問題**

**我可以將簡報儲存為符合歸檔與無障礙標準（PDF/A 與 PDF/UA）的 PDF 嗎？**

是的。Aspose.Slides 支援將 PDF 匯出為符合 PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b 以及 PDF/UA 等合規等級，透過在 [PDF 匯出選項](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/) 中的 [compliance](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/#setCompliance-int-) 設定來實現。

**程式庫在匯出為 PDF 時是否支援字型嵌入，並能細緻控制嵌入的內容？**

是的。您可以透過 [PDF 匯出選項](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/) 控制字型是完整嵌入或僅嵌入子集（使用的字形），指定常見系統字型的處理方式，並設定 ASCII 文字的行為。

**我能在實際載入檔案前偵測其是否受密碼保護嗎？**

是的。使用 [基於工廠的檢查 API](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/)，您可以在不完全開啟簡報的情況下查詢檔案是否受密碼保護。

**是否有字型備援機制以及對自訂字型的支援？**

是的。程式庫支援 [載入](/slides/zh-hant/java/custom-font/) 與 [嵌入](/slides/zh-hant/java/embedded-font/) 自訂字型，並提供字型 [備援規則](/slides/zh-hant/java/fallback-font/)，以避免在渲染與轉換過程中出現缺字。

**我可以將投影片匯出為 XPS，並有調整 XPS 輸出選項的功能嗎？**

是的。支援 [匯出為 XPS](/slides/zh-hant/java/convert-powerpoint-to-xps/)，您可以調整相關的 [儲存選項](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xpsoptions/)，以控制 XPS 文件的輸出品質與內容。