---
title: 在 JavaScript 中儲存簡報
linktitle: 儲存簡報
type: docs
weight: 80
url: /zh-hant/nodejs-java/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存簡報
- 儲存投影片
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 簡報到檔案
- 簡報到串流
- 預先定義的檢視類型
- 嚴格的 Office Open XML 格式
- Zip64 模式
- 刷新縮圖
- 儲存進度
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中將 PowerPoint 與 OpenDocument 簡報儲存為檔案或串流，並設定 PPTX 輸出與進度報告。"
---
## **概述**

建立簡報或[開啟現有的簡報](/slides/zh-hant/nodejs-java/open-presentation/)之後，使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save)方法寫入結果。Aspose.Slides for Node.js via Java 可以將簡報儲存為檔案或串流，支援 PowerPoint、OpenDocument、PDF 以及其他格式。下列章節說明標準的儲存操作以及 PPTX 輸出的可用選項。

## **將簡報儲存至檔案**

要將簡報儲存至檔案，將輸出路徑與[SaveFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/)值傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save)方法。格式值決定 Aspose.Slides 建立的檔案類型。

以下範例建立簡報並將其儲存為 PPTX 檔案：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // 在此加入或修改簡報內容。

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以原始格式儲存簡報**

有關檔案與串流偵測範例、新建立簡報的行為，以及來源與輸出格式之區別，請參閱[Determine the Original Presentation Format](/slides/zh-hant/nodejs-java/detect-presentation-source-format/)。

在批次處理應用程式中，輸入格式可能事先未知。載入檔案後，從[Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getSourceFormat)方法讀取其原始格式。將得到的[SourceFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sourceformat/)值傳遞給[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideutil/#toSaveFormat)以取得相應的[SaveFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/)值，然後使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save)寫入已修改的簡報。

以下完整範例會處理輸入目錄中的每個檔案，更新其標題，並以載入時的格式儲存至輸出目錄：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideutil/#toSaveFormat)將 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 以及 PowerPoint XML 映射到相應的簡報儲存格式。它僅映射簡報來源格式；不應用於選擇 PDF、HTML、TIFF 或影像等匯出格式。傳遞不受支援或無效的[SourceFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sourceformat/)值會導致錯誤。

舊版 PPT、PPS 與 POT 檔案使用相同的二進位容器。若從沒有副檔名的串流載入此類簡報，PPS 或 POT 檔案可能會被辨識為 PPT。若需要保留這些舊版子類型，請另行保留原始檔名或格式中繼資料，並在選擇輸出檔名與格式時使用它們。

## **將簡報儲存至串流**

若不想依賴最終檔案路徑寫入簡報，可將可寫入的串流與[SaveFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/)值傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save)方法。此方式在需要將輸出返回給 Web 服務、存入資料庫或在記憶體中處理時非常有用。

以下範例將新簡報儲存至檔案串流：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **以預先定義的檢視類型儲存簡報**

您可以在 PowerPoint 開啟已儲存簡報時指定其初始檢視。於儲存前使用帶有[ViewType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewtype/)值的[ViewProperties.setLastView](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/#setLastView)方法。

以下範例將母片檢視設定為初始檢視：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以嚴格的 Office Open XML 格式儲存簡報**

若要建立符合 Office Open XML 嚴格規範的 PPTX 檔案，建立[PptxOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxoptions/)實例，並使用其[setConformance](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxoptions/#setConformance)方法傳入[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict)。然後將這些選項傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save)方法。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **以 Zip64 模式在 Office Open XML 格式儲存簡報**

標準 ZIP 壓縮檔對每個條目的壓縮與未壓縮大小、整體檔案大小以及條目數量都有上限。因為 PPTX 檔案本身即為 ZIP 壓縮檔，極大型簡報可能會超過這些限制。ZIP64 延伸可提升相關大小與條目數限制。

使用[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode)方法控制 Aspose.Slides 是否寫入 ZIP64 延伸：

- [IfNecessary]https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zip64mode/#IfNecessary 僅在簡報超過標準 ZIP 限制時使用 ZIP64，為預設模式。
- [Never]https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zip64mode/#Never 停用 ZIP64 延伸。
- [Always]https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zip64mode/#Always 總是寫入 ZIP64 延伸。

以下範例會對輸出簡報永遠啟用 ZIP64 延伸：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
如果使用[Zip64Mode.Never]https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zip64mode/#Never，且簡報無法符合標準 ZIP 限制，儲存作業會拋出[PptxException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級在 Office Open XML 格式儲存簡報**

針對 PPTX 輸出，您可以透過[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel)方法在儲存速度與檔案大小之間取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compressionlevel/)類別提供以下值：

- [None]https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compressionlevel/#None 不壓縮儲存資料。
- [Level1]https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compressionlevel/#Level1 提供最快的壓縮速度且產生最大的壓縮檔案。
- [Level2]https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compressionlevel/#Level2 至 [Level5]https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compressionlevel/#Level5 逐漸偏好較小的輸出而犧牲儲存速度。
- [Level6]https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compressionlevel/#Level6 在儲存速度與檔案大小之間取得平衡，為預設等級。
- [Level7]https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compressionlevel/#Level7 與 [Level8]https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compressionlevel/#Level8 進一步偏好較小的輸出。
- [Level9]https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compressionlevel/#Level9 提供最強的壓縮，但需要最長的處理時間。

以下範例在不使用壓縮的情況下儲存簡報：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

以下範例使用最高壓縮等級：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **儲存簡報時不重新整理縮圖**

當簡報以 PPTX 格式儲存時，[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail)方法控制文件縮圖：

- `true` 在儲存過程中重新產生縮圖，為預設值。
- `false` 保留現有縮圖。若簡報沒有縮圖，Aspose.Slides 不會產生新的縮圖。

以下範例在儲存時不刷新縮圖：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
停用縮圖刷新可減少儲存 PPTX 檔案所需的時間。
{{% /alert %}}

## **以百分比顯示儲存進度更新**

若要監控儲存作業，請使用 Java 代理實作[IProgressCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/)介面，並將實作傳遞給[SaveOptions.setProgressCallback](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveoptions/#setProgressCallback)方法。Aspose.Slides 會在匯出過程中呼叫[IProgressCallback.reporting](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/#reporting-double-)方法，傳回進度值。

以下範例將 PDF 匯出的進度回報至主控台：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose 提供免費的[PowerPoint Splitter](https://products.aspose.app/slides/zh-hant/splitter)，其使用 Aspose.Slides API 建置。它可將簡報中的選取投影片另存為單獨的 PPT 或 PPTX 檔案。
{{% /alert %}}

## **FAQ**

**Aspose.Slides 是否支援增量或「快速儲存」？**

不支援。每次儲存操作都會寫入完整的輸出檔案，而不是只更新變更的部分。

**多個執行緒可以同時儲存同一個 Presentation 實例嗎？**

不行。[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)實例**不是執行緒安全**的。每次只能從單一執行緒存取並儲存該實例。

**儲存簡報時超連結與外部連結檔案會發生什麼事？**

[Hyperlinks](/slides/zh-hant/nodejs-java/manage-hyperlinks/) 仍會保留在簡報中。Aspose.Slides 不會複製外部連結的檔案，儲存後的簡報仍需能存取其原始位置。

**我可以儲存文件的中繼資料，例如作者、標題、公司與建立日期嗎？**

可以。儲存前先設定相應的[文件屬性](/slides/zh-hant/nodejs-java/presentation-properties/)，Aspose.Slides 會將它們寫入輸出檔案。