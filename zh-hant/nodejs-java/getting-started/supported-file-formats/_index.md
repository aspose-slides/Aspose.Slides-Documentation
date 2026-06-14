---
title: 支援的檔案格式
type: docs
weight: 30
url: /zh-hant/nodejs-java/supported-file-formats/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "探索 Aspose.Slides for Node.js via Java 能開啟、儲存與轉換的所有檔案格式——包括 PPT、PPTX 與 ODP——並提供清晰的匯入/匯出支援說明。"
---
## **概述**

Aspose.Slides 支援從 Microsoft PowerPoint 97 到 Office 365（含 Microsoft PowerPoint for Mac）的簡報檔案。本文列出程式庫支援的 PowerPoint 版本，並提供可載入、儲存或兩者皆可的檔案格式表。

本文亦回答關於 PDF 合規性、字型嵌入、受密碼保護的檔案、自訂字型、字型備援機制以及 XPS 匯出選項等常見問題。

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
此表格列出 Aspose.Slides for Node.js via Java 可載入與儲存的檔案格式：

|**格式**|**說明**|**載入**|**儲存**|**備註**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 幻燈片播放|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 幻燈片播放|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|支援巨集的 PowerPoint 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|支援巨集的 PowerPoint 幻燈片播放|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|支援巨集的 PowerPoint 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 簡報範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|標籤影像檔案格式| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|增強型中介圖檔格式| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|可攜式文件格式|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML 紙張規範| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|聯合圖像專家組| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|可攜式網路圖形| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|圖形交換格式| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|裝置獨立點陣圖| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|可伸縮向量圖形| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|小型網頁格式| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|超文字標記語言|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|可擴充應用程式標記語言| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 簡報| |{{< emoticons/tick >}}| |

## **常見問題**

**我能將簡報儲存為符合存檔與可存取性標準（PDF/A 與 PDF/UA）的 PDF 嗎？**

是的。Aspose.Slides 支援透過 [compliance](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pdfoptions/setcompliance/) 設定，在 [PDF export options](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pdfoptions/) 中將 PDF 匯出為符合 PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b 以及 PDF/UA 等合規等級。

**程式庫在匯出為 PDF 時是否支援字型嵌入，並能細緻控制嵌入內容？**

是的。您可以透過 PDF 匯出選項控制字型是完整嵌入或僅嵌入使用到的字形（子集），指定常見系統字型的處理方式，並針對 ASCII 文字進行設定。

**我能在實際載入檔案前偵測它是否受密碼保護嗎？**

是的。使用 [factory-based inspection API](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/)，您可以在不完整開啟簡報的情況下查詢檔案是否受密碼保護。

**是否有字型備援機制並支援自訂字型？**

是的。程式庫支援[loading](/slides/zh-hant/nodejs-java/custom-font/)和[embedding](/slides/zh-hant/nodejs-java/embedded-font/)自訂字型，並提供字型[fallback rules](/slides/zh-hant/nodejs-java/fallback-font/)以防止在渲染與轉換過程中出現缺字形的情況。

**我能將投影片匯出為 XPS，且有調整 XPS 輸出之選項嗎？**

是的。支援[Export to XPS](/slides/zh-hant/nodejs-java/convert-powerpoint-to-xps/)，您可以調整相關[save options](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xpsoptions/)以控制 XPS 文件的輸出品質與內容。