---
title: 在 JavaScript 中匯出簡報為 XAML
linktitle: 簡報轉 XAML
type: docs
weight: 30
url: /zh-hant/nodejs-java/export-to-xaml/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出簡報
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換簡報
- PowerPoint 轉 XAML
- OpenDocument 轉 XAML
- 簡報轉 XAML
- PPT 轉 XAML
- PPTX 轉 XAML
- ODP 轉 XAML
- 將 PPT 儲存為 XAML
- 將 PPTX 儲存為 XAML
- 將 ODP 儲存為 XAML
- 匯出 PPT 為 XAML
- 匯出 PPTX 為 XAML
- 匯出 ODP 為 XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中將 PowerPoint 與 OpenDocument 投影片轉換為 XAML——快速、無需 Office 的解決方案，保持版面不變。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。內容包括 XAML 的簡要介紹、展示如何使用預設設定將簡報儲存為 XAML，並說明如何透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/) 自訂匯出，包括匯出隱藏投影片。本文亦回答有關備用字型、XAML 堆疊相容性以及隱藏投影片匯出行為的常見問題。

## **關於 XAML**

XAML 是一種基於 XML 的標記語言，用於描述 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）以及 Xamarin.Forms 等框架中的使用者介面。

您可以在視覺設計師中操作 XAML 檔案，或直接編寫與編輯標記。

## **使用預設選項匯出簡報至 XAML**

以下 JavaScript 範例說明如何使用預設設定將簡報匯出為 XAML：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

預設情況下，匯出的投影片會儲存在處理程序目前工作目錄的 `input` 子資料夾中。該資料夾會自動建立，所需的圖像也會儲存在同一處。

輸出資料夾名稱取自來源檔案名稱（不含副檔名）。在 Aspose.Slides for Node.js via Java 26.8 中，匯出 `input.pptx` 會產生類似 `input/input/Slide_1.xaml` 的巢狀路徑。處理輸出時請保留完整產生的路徑。預設的輸出是相對於目前工作目錄，而非一定與輸入檔案同一目錄。

## **使用自訂選項匯出簡報至 XAML**

使用 [IXamlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloptions/) 介面來控制 Aspose.Slides 如何將簡報匯出為 XAML。

若要將輸出儲存至自訂位置，請實作 [IXamlOutputSaver](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloutputsaver/)，並將您的實作實例傳遞給 [XamlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/) 的 [setOutputSaver](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) 方法。

若要在 XAML 輸出中包含隱藏投影片，請如以下 JavaScript 範例所示，以 `true` 呼叫 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides)：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **擷取所有產生的 XAML 產物**

XAML 匯出可能會為每張匯出的投影片產生一個 XAML 文件，外加獨立的圖像與支援資源。將自訂的 [IXamlOutputSaver](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloutputsaver/) 指派給 [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/#setOutputSaver)，即可改用自訂儲存程序接收這些產物，而非使用預設的檔案系統儲存。使用接受 XAML 選項的 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 重載開始匯出。

在 Node.js 中，使用 Aspose.Slides 所使用的 `java` 套件透過 `java.newProxy` 實作 Java 介面。請在匯出完成前保持代理物件可存取。

### **了解回呼生命週期**

匯出器會針對每個產生的產物分別呼叫 [IXamlOutputSaver.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-)：

- `path` 用於識別產物，可能包含相對目錄。請保留此資訊，因為 XAML 可能會使用相對路徑參照資源。
- `data` 包含產物的位元組。圖像與其他二進位資源不得解碼為文字。
- 儲存程序負責在回傳之前保留或持久化資料。範例會將每個 Java byte 陣列複製到應用程式擁有的 Node.js 緩衝區。
- 只有當簡報儲存操作回傳且每個回呼皆成功完成時，才視匯出為成功。不可吞噬儲存錯誤或啟動未觀察的背景寫入。若持久化在之後發生，僅在該步驟也成功後才報告整體成功。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) 同樣適用於自訂儲存程序。預設值 `false` 會排除隱藏投影片的 XAML 文件。傳入 `true` 則會包含它們以及匯出所需的所有資源。資源數量取決於簡報本身；不要假設每張投影片只有一個回呼，或回呼有固定順序。

### **匯出至記憶體並檢查產物**

以下完整範例載入 `input.pptx`，將每個產物收集到 JavaScript 的名稱‑緩衝區映射中，並列印名稱、類型與位元組數。它會完整保留提供的名稱。重複的名稱會使集合無效，而非靜默覆寫產物。範例在使用結果前會先檢查這一點。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // 僅在需要文字檢查時解碼 XAML。
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

檢查副檔名對於檢視很有幫助；請保留所有產物，包括不熟悉的資源類型。儲存或傳輸時請保持位元組不變。僅對需要文字處理的 XAML 使用 UTF‑8 解碼。

### **將收集的產物打包成 ZIP 壓縮檔**

此獨立範例收集匯出結果、驗證其名稱，並使用 Java 橋將原始位元組寫入 ZIP 壓縮檔。ZIP 先在記憶體中組裝，之後再寫入磁碟。唯一的壓縮檔名稱可區分同時進行的匯出工作。ZIP 條目使用正斜線並保留相對目錄。若名稱不安全或正規化後發生衝突，整個套件會在寫入前被拒絕。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // 關閉會在將壓縮檔持久化之前完成 ZIP 目錄的最終化。
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

範例使用 [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) 寫入單一本機壓縮檔；匯出器本身不會寫入散落的 XAML 或影像檔案。若使用遠端儲存，請將寫入壓縮檔的階段替換為上傳已收集的位元組陣列。可使用匯出工作識別碼加上完整的相對產物名稱作為 Blob 金鑰，或將工作識別碼、相對名稱與二進位資料一起存入資料庫列。僅在所有上傳完成或資料庫交易提交後才發布工作。若持久化失敗，請清理部分輸出。

對於大型簡報，自訂儲存程序可以直接將每個產物寫入應用程式儲存，以免在記憶體中保留整個匯出的副本。從匯出器的角度看，請保持每個回呼同步：僅在目的地接受位元組後才回傳，並允許失敗傳遞給呼叫端。

### **保留資源名稱並驗證參照**

- 若目的地需要，正規化路徑分隔符，但仍需保留相對目錄。除非確定每個產生的名稱都是唯一且資源參照仍然有效，否則不要只使用基礎名稱。
- 依目的地執行特定的名稱驗證。寫入散落檔案時，拒絕根路徑與路徑穿越段，將目的地解析為絕對路徑，並確認其仍位於預期的匯出目錄之下（包含目錄分隔符的包含性檢查）。使用不含可重定向符號連結的應用程式受控目錄。
- 為每個匯出工作使用獨立的儲存程序與儲存命名空間。依照分隔符正規化及目的地的大小寫敏感規則偵測衝突。
- 發布前，將每個 XAML 文件解析為 XML，檢查其基於檔案的資源參照，如圖像 `Source` 或 `ImageSource` 屬性。將每個相對 URI 以包含該 XAML 產物的目錄為基礎解析，正規化得到的儲存名稱，並確認對應的映射鍵、ZIP 條目或已儲存物件存在。將外部 URI 與 XAML 標記表達式與相對檔名分開處理。

例如，若 `input/Slide_1.xaml` 參照 `images/image1.png`，則必須以 `input/images/image1.png` 形式提供該資源。僅保留 `image1.png` 會破壞此關係。若使用物件儲存，請在工作前綴下保留相同的佈局，並讓這些資源 URL 能被 XAML 消費者存取。重新打開完成的 ZIP 以驗證條目名稱與資源位元組，並在目標 XAML 環境中載入代表性投影片，以確認圖像正確解析。

## **常見問題**

**如果原始字型在機器上不存在，如何確保字型的可預測性？**

在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/) 中呼叫 [setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) —— 當原始字型缺失時，匯出會使用此字型作為備用字型。但這並不保證產生的 XAML 會參照備用字型，或該字型在目標機器上可用。請確保 XAML 所參照的字型在顯示環境中已安裝。

**匯出的 XAML 只適用於 WPF，還是也能在其他 XAML 堆疊中使用？**

Aspose.Slides 透過其公開 API 匯出 WPF XAML。對於其他 XAML 堆疊（例如 UWP 與 Xamarin.Forms）的相容性不保證。請在目標環境中測試產生的標記。

**是否支援隱藏投影片，且預設如何防止其被匯出？**

預設情況下不會包含隱藏投影片。您可以透過在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/) 中的 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) 來控制此行為——如果不需要匯出隱藏投影片，請保持此設定為停用狀態。