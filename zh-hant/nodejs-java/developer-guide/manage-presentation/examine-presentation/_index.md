---
title: 在 JavaScript 中檢索與更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/nodejs-java/examine-presentation/
keywords:
- 簡報格式
- 簡報屬性
- 文件屬性
- 取得屬性
- 讀取屬性
- 變更屬性
- 修改屬性
- 更新屬性
- 檢查 PPTX
- 檢查 PPT
- 檢查 ODP
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以獲得更快速的洞察與更智慧的內容稽核。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中檢查簡報資訊。它解釋了如何在不載入完整檔案的情況下判斷簡報的目前格式、讀取其文件屬性，以及在需要時更新這些屬性。

範例基於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/) 與 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/) API，示範了處理簡報中繼資料的典型操作。

## **檢查簡報格式**

在處理簡報之前，您可能想先了解目前簡報的格式（PPT、PPTX、ODP 等）。

您可以在不載入簡報的情況下檢查其格式。請參考以下 JavaScript 程式碼：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **取得簡報屬性**

此 JavaScript 程式碼示範如何取得簡報屬性（關於簡報的資訊）：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ……
```

您也可以查看 [DocumentProperties 類別下的屬性](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--)。

## **更新簡報屬性**

Aspose.Slides 提供 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) 方法，讓您可以變更簡報屬性。

假設我們有一個 PowerPoint 簡報，其文件屬性如下所示。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

以下程式碼示範如何編輯部分簡報屬性：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

變更文件屬性的結果如下所示。

![PowerPoint 簡報的變更後文件屬性](output_properties.png)

## **有用的連結**

若想取得更多關於簡報及其安全屬性的資訊，以下連結可能有幫助：

- [Password-Protect Presentations](/slides/zh-hant/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/zh-hant/nodejs-java/write-protected-presentation/)

## **常見問題**

**如何確認是否已嵌入字型以及是哪些字型？**

請在簡報層級檢查 [embedded-font 資訊](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/)，再將這些條目與實際在內容中使用的 [字型清單](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getfonts/) 進行比對，以辨識哪些字型對於呈現至關重要。

**如何快速判斷檔案是否有隱藏投影片以及有多少張？**

遍歷 [投影片集合](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/)，檢查每張投影片的 [可見性旗標](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/gethidden/)。

**我能偵測是否使用自訂投影片大小與方向，且是否與預設不同嗎？**

可以。比較目前的 [投影片大小](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getslidesize/) 與方向，與標準預設值做比對；這有助於預測列印與匯出的行為。

**有沒有快速方法查看圖表是否參考外部資料來源？**

可以。遍歷所有 [圖表](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/)，檢查其 [資料來源類型](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)，並註明資料是內部還是連結式，亦包括任何失效的連結。

**如何評估「較重」的投影片，避免降低渲染或 PDF 匯出的速度？**

對每張投影片，統計物件數量，留意大型圖片、透明度、陰影、動畫與多媒體檔案；根據這些指標給予粗略的複雜度分數，以標示可能的效能瓶頸。