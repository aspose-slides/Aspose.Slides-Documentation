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

Aspose.Slides 能夠辨識簡報的格式，並在不建立完整簡報物件模型的情況下讀取文件的中繼資料。當您需要分類檔案、建立清單或在決定是否載入與處理簡報內容之前檢查屬性時，這非常有用。

本文示範如何使用 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/) 與 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/) 進行輕量檢查，以及如何透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/) 進行目標更新。

## **檢查簡報格式**

使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) 可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例的情況下檢查檔案。[PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/getloadformat/) 方法會回報偵測到的格式，例如 PPTX、PPT 或 ODP。

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **建立輕量簡報清單**

當您處理大量簡報檔案時，可能需要緊湊的清單以供驗證、索引或文件管理系統使用。在此情境下，使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) 取得 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/) 物件，然後呼叫 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) 讀取文件中繼資料。此作法不會建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例，也不需要遍歷完整的簡報物件模型。

由 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/) 提供的擴充屬性會回傳以下清單值：

| 方法 | 清單值 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#getSlides) | 投影片總數。 |
| [getHiddenSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | 隱藏投影片的數量。 |
| [getNotes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#getNotes) | 含有備註的投影片數量。 |
| [getParagraphs](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | 段落總數（若有提供）。 |
| [getWords](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#getWords) | 單詞總數。 |
| [getMultimediaClips](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | 音訊與視訊剪輯的總數。 |

以下範例在未建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 物件的情況下讀取這些值，並列印緊湊的清單。它同時結合 [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) 與 [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) 以顯示字型、佈景主題與投影片標題等內容群組。

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

每個 [HeadingPair](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/headingpair/) 會透過 [HeadingPair.getName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/headingpair/#getName) 提供群組名稱，並透過 [HeadingPair.getCount](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/headingpair/#getCount) 提供該群組的項目數量。[DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) 會回傳平面且已排序的陣列，因而依照每個 heading pair 指定的連續標題數量進行取用。

### **已儲存的中繼資料與格式限制**

由 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) 回傳的清單屬性反映來源文件中可用的中繼資料。Aspose.Slides 不會在此呼叫中載入並遍歷簡報物件模型以重新計算這些值。缺少的屬性會以預設值表示，而已儲存的值若在上次儲存檔案的應用程式未更新文件屬性，則可能已過時。

- **PPTX：** 此格式提供投影片、備註、隱藏投影片、段落、單詞與多媒體計數的擴充文件屬性，以及 heading pair 與 part title。可用性取決於文件產生者寫入了哪些屬性。
- **PPT：** 二進位格式可以儲存對應的文件摘要屬性。若屬性缺失或未由文件產生者重新整理，Aspose.Slides 會回傳其已儲存或預設值，而非從投影片重新計算。
- **ODP：** OpenDocument 中繼資料提供一般文件統計資訊，如頁面、段落與單詞計數，但這些值未必對應每個 PowerPoint 專屬的擴充屬性。隱藏投影片、備註投影片、多媒體、heading‑pair 與 part‑title 中繼資料可能不存在，清單屬性可能回傳預設值。請勿將零值或空陣列視為對應內容缺失的權威證明。

在建立清單與初步檢查時使用輕量中繼資料方法。若結果必須反映記憶體中的變更，或需要驗證實際簡報內容，請載入簡報並檢查其即時物件模型。

## **更新簡報屬性**

由 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) 回傳的屬性也可以在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例的情況下修改。使用 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) 套用變更，然後以 [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/) 將綁定的簡報寫出。

下圖顯示原始文件屬性。

![Original document properties of the PowerPoint presentation](input_properties.png)

以下範例變更標題與最後儲存時間，並將結果寫入新檔案：

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

下圖顯示已更新的文件屬性。

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **相關連結**

欲了解相關的安全性檢查與保護設定，請參閱以下文章：

- [Password-Protect Presentations](/slides/zh-hant/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/zh-hant/nodejs-java/write-protected-presentation/)

## **常見問題**

**如何檢查字型是否已嵌入以及是哪一些？**

載入簡報並使用 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getfontsmanager/)。呼叫 [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) 取得已嵌入的字型，並呼叫 [FontsManager.getFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getfonts/) 取得簡報使用的字型。比較兩個結果即可找出需要渲染但未嵌入的字型。

**如何快速判斷檔案是否有隱藏投影片以及數量？**

當已儲存的文件中繼資料足以使用時，透過 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) 及 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) 讀取 [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides)。此方式適用於輕量清單。如果簡報已在記憶體中被修改，或需要驗證即時值，請遍歷 [Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getslides/) 並檢查每張投影片的 [Slide.getHidden](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/gethidden/) 方法。

**我可以偵測是否使用自訂投影片尺寸與方向，且是否與預設不同嗎？**

可以。載入簡報後呼叫 [Presentation.getSlideSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getslidesize/)。使用 [SlideSize.getType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesize/gettype/)、[SlideSize.getSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesize/getsize/)、[SlideSize.getOrientation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesize/getorientation/) 與預設設定與尺寸進行比較。

**有沒有快速方法檢查圖表是否參照外部資料來源？**

有。找出每個 [Chart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/) 並呼叫 [ChartData.getDataSourceType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)。若為外部活頁簿，請呼叫 [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)。資料來源類型與路徑能識別外部參照，但是否可取得目標需另行檢查資源。

**如何評估可能導致渲染或 PDF 匯出變慢的「重」投影片？**

沒有單一的複雜度屬性。遍歷 [Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getslides/) 並檢查每張投影片的 [BaseSlide.getShapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/#getShapes) 集合。使用形狀數量、大尺寸圖片、效果、動畫或多媒體的存在作為篩選信號，並在確認投影片為真正的效能瓶頸前，先執行具代表性的渲染或匯出測試。