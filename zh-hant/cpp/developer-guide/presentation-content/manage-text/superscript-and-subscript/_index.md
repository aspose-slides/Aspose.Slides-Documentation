---
title: 使用 C++ 管理簡報中的上標與下標
linktitle: 上標與下標
type: docs
weight: 80
url: /zh-hant/cpp/superscript-and-subscript/
keywords:
- 上標
- 下標
- 新增上標
- 新增下標
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中精通上標與下標，透過專業文字格式提升簡報的最大衝擊力。"
---
## **概述**

Aspose.Slides 提供將上標和下標文字整合至 PowerPoint (PPT、PPTX) 及 OpenDocument (ODP) 簡報的功能。無論您需要突顯化學式、數學方程式，或以註腳標註內容，這些特殊格式選項都有助於保持清晰與精準。本文將教您如何在每張投影片中無縫套用上標與下標樣式，確保專業成果。

## **管理上標與下標文字**

您可以在任何段落部分內加入上標或下標文字。若要在 Aspose.Slides 文字框中加入上標或下標文字，必須使用 PortionFormat 類別的 **Escapement** 屬性。

此屬性可取得或設定上標或下標文字（值範圍為 -100%（下標）至 100%（上標））。例如：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
- 透過 Index 取得投影片的參考。
- 向投影片新增類型為 Rectangle 的 IAutoShape。
- 取得與 IAutoShape 關聯的 ITextFrame。
- 清除現有的 Paragraphs。
- 建立用於保存上標文字的新段落物件，並將其加入 ITextFrame 的 IParagraphs 集合。
- 建立新的 portion 物件。
- 為該 portion 設定 Escapement 屬性值介於 0 到 100，以加入上標。（0 表示無上標）
- 為 Portion 設定文字，然後將其加入段落的 portion 集合。
- 建立用於保存下標文字的新段落物件，並將其加入 ITextFrame 的 IParagraphs 集合。
- 建立新的 portion 物件。
- 為 portion 設定 Escapement 屬性值介於 0 到 -100，以加入下標。（0 表示無下標）
- 為 Portion 設定文字，然後將其加入段落的 portion 集合。
- 將簡報儲存為 PPTX 檔案。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **常見問題**

**在匯出為 PDF 或其他格式時，上標與下標會被保留嗎？**

是的，Aspose.Slides 在將簡報匯出為 PDF、PPT/PPTX、影像及其他支援的格式時，會正確保留上標與下標的格式。所有輸出檔案中的這些特殊格式皆保持完整。

**上標與下標可以與粗體或斜體等其他格式樣式結合使用嗎？**

是的，Aspose.Slides 允許在同一 portion 內混合多種文字樣式。您可以啟用粗體、斜體、底線，並同時透過設定 [PortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/portionformat/) 的相應屬性來套用上標或下標。

**上標與下標格式在表格、圖表或 SmartArt 內的文字也適用嗎？**

是的，Aspose.Slides 支援在大多數物件內的格式設定，包含表格與圖表元素。使用 SmartArt 時，需取得相應的元素（例如 [SmartArtNode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartartnode/)）及其文字容器，然後以相同方式設定 [PortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/portionformat/) 的屬性。