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
description: "使用 JavaScript 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以獲得更快速的洞見與更智慧的內容稽核。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中檢查簡報資訊。它解釋了如何在不載入完整檔案的情況下判斷簡報的目前格式、讀取其文件屬性，並在需要時更新這些屬性。

這些範例基於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/) 與 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/) API，展示了處理簡報中繼資料的典型操作。

## **檢查簡報格式**

在處理簡報之前，您可能想先了解目前簡報的格式（PPT、PPTX、ODP 等）。

您可以在不載入簡報的情況下檢查其格式。請參考以下 JavaScript 程式碼：

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX 格式
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT 格式
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP 格式
```

## **取得簡報屬性**

此 JavaScript 程式碼示範如何取得簡報屬性（簡報的資訊）：

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ...
```

您可能想查看 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) 類別下的屬性。

## **更新簡報屬性**

Aspose.Slides 提供 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) 方法，讓您可以修改簡報屬性。

假設我們有一個 PowerPoint 簡報，其文件屬性如下所示。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

以下程式碼範例示範如何編輯部分簡報屬性：

```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

變更文件屬性的結果顯示如下。

![PowerPoint 簡報的變更後文件屬性](output_properties.png)

## **實用連結**

若要取得有關簡報及其安全屬性的更多資訊，以下連結可能對您有幫助：

- [檢查簡報是否已加密](https://docs.aspose.com/slides/zh-hant/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [檢查簡報是否為寫入保護（唯讀）](https://docs.aspose.com/slides/zh-hant/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [在載入前檢查簡報是否受密碼保護](https://docs.aspose.com/slides/zh-hant/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [確認用於保護簡報的密碼](https://docs.aspose.com/slides/zh-hant/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **常見問題**

**如何檢查字型是否已嵌入以及是哪一些字型？**

在簡報層級查找 [embedded-font information](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/)，然後將這些條目與 [fonts actually used across content](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getfonts/) 的集合比較，以辨識哪些字型對於渲染至關重要。

**如何快速判斷檔案是否有隱藏投影片以及隱藏的數量？**

遍歷 [slide collection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/) 並檢查每張投影片的 [visibility flag](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/gethidden/)。

**我能偵測是否使用自訂投影片尺寸與方向，且是否與預設值不同嗎？**

可以。比較目前的 [slide size](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getslidesize/) 與方向與標準預設，這有助於預測列印和匯出的行為。

**是否有快速方法查看圖表是否參照外部資料來源？**

可以。遍歷所有 [charts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/)，檢查其 [data source](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)，並註明資料是內部還是連結型，包括任何斷開的連結。

**如何評估可能導致渲染或 PDF 輸出緩慢的「繁重」投影片？**

對每張投影片統計物件數量，留意大型影像、透明度、陰影、動畫及多媒體，根據這些因素給予粗略的複雜度分數，以標示潛在的效能瓶頸。