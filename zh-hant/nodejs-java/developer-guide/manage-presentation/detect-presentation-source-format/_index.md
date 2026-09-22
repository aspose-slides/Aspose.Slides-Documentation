---
title: 在 Node.js 中確定原始簡報格式
linktitle: 來源格式
type: docs
weight: 35
url: /zh-hant/nodejs-java/detect-presentation-source-format/
keywords:
- 來源格式
- 偵測簡報格式
- PowerPoint
- OpenDocument
- 簡報
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Node.js 中使用 Aspose.Slides for Node.js via Java 讀取已載入簡報的原始格式，比較偵測 API，並處理檔案、串流及舊版格式。"
---
## **概述**

載入簡報後，呼叫 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getSourceFormat) 方法以確定其原始格式。當後續處理取決於目前實例載入的格式時，請使用它。

來源格式不同於為輸出檔案選擇的 [SaveFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/) 。將檔案儲存為其他格式不會更改現有實例的來源格式。

## **讀取檔案的來源格式**

此範例需要一個已存在的 `sample.pptx` 檔案。它載入該檔案並使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getSourceFormat) 來選擇應用程式處理策略，而非依賴檔名。變更輸入路徑即可嘗試其他格式。範例會印出所選的策略；請將訊息替換為您的應用程式邏輯。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **辨識支援的值**

[SourceFormat] 類別定義了可區分以下簡報格式的整數常數。下列副檔名僅為慣用副檔名，並非原始檔名的重建。

| SourceFormat 值 | 副檔名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 簡報 |
| `Pptx` | `.pptx` | Office Open XML 簡報 |
| `Pptm` | `.pptm` | 支援巨集的 Office Open XML 簡報 |
| `Pps` | `.pps` | PowerPoint 97–2003 投影片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 投影片放映 |
| `Ppsm` | `.ppsm` | 支援巨集的 Office Open XML 投影片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 範本 |
| `Potx` | `.potx` | Office Open XML 範本 |
| `Potm` | `.potm` | 支援巨集的 Office Open XML 範本 |
| `Odp` | `.odp` | OpenDocument 簡報 |
| `Otp` | `.otp` | OpenDocument 簡報範本 |
| `Fodp` | `.fodp` | Flat XML ODF 簡報 |
| `Xml` | `.xml` | PowerPoint XML 簡報 |

## **讀取串流的來源格式**

此範例需要一個已存在的 `sample.pps` 檔案。將其位元組讀入記憶體串流，以模擬未提供檔名的輸入，例如資料庫值或上傳的位元組陣列。[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 建構函式僅接受串流。

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT、PPS 與 POT 使用相同的底層二進位格式。以檔案路徑載入時，副檔名可協助區分投影片放映或範本。若沒有檔名，舊版的 PPS 與 POT 內容可能會被報告為 `SourceFormat.Ppt`；上述的 PPS 範例會印出 `SourceFormat.Ppt` 的整數值。

若您的應用程式必須保留此區別，請另行保留原始檔名或子類型中繼資料。副檔名對於這些舊版子類型是一個有用的提示，但不應成為辨識任意簡報內容的唯一依據。

## **比較載入前後的偵測**

在需要於載入完整簡報物件模型之前檢查檔案時，使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) 與 [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat)。在實例已存在時，請使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getSourceFormat)。

此範例需要 `sample.pptx`，分別印出 `LoadFormat.Pptx` 與 `SourceFormat.Pptx` 的整數值。在正式環境中，請選擇適合您處理階段的 API；已載入的簡報不需要再次檢查僅為取得其來源格式。

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

結果使用來自不同類別的常數：[LoadFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadformat/) 與 [SourceFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sourceformat/)。請勿比較它們的數值或假設每種格式都有相同的偵測結果。PowerPoint XML 在載入前可能被報告為 `LoadFormat.Unknown`，載入後則為 `SourceFormat.Xml`。

## **保持來源與輸出格式分離**

此範例需要 `sample.pptx` 並寫入 `converted.odp`。它在儲存原始實例前後皆印出 `SourceFormat.Pptx` 的整數值。只有從 ODP 輸出載入的新實例會報告 `Odp`。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

使用 `new Presentation()` 從頭建立的簡報會報告 `SourceFormat.Pptx`。它沒有輸入檔案：這是新建立實例的預設值，並不代表已載入 PPTX 檔案。若此區別重要，請在應用程式中分別追蹤是建立還是載入實例。

## **將來源格式對應到副檔名**

以下範例需要 `sample.pptx`。它將每個目前支援的 [SourceFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sourceformat/) 值對應到慣用副檔名，且不解析輸入檔名。備用方案可避免對未識別的值悶悶不聲地指派副檔名。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

此對應不會轉換檔案或復原在串流載入期間遺失的舊版 PPS/POT 子類型。實際儲存時，請明確選擇 [SaveFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveformat/)，或使用在 [Save Presentations in Their Original Format](/slides/zh-hant/nodejs-java/save-presentation/#save-presentations-in-their-original-format) 中示範的轉換方式。

## **透過儲存與重新開啟驗證格式**

此獨立範例會建立簡報並在工作目錄寫入三個檔案，若同名檔案會被覆寫。它會以路徑與記憶體串流兩種方式重新開啟每個輸出檔。對於 PPTX 與 ODP，兩種方式皆報告已儲存的格式。對於 PPS，依路徑載入會報告 `Pps`，而在沒有檔名的情況下載入相同位元組會報告 `Ppt`。

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

下表彙總了具有相同副檔名的簡報之來源格式辨識。名稱代表常數；JavaScript 範例會印出它們的整數值：

| 已儲存格式 | 由檔案路徑取得的 SourceFormat | 由無檔名串流取得的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` 分別 | 與檔案路徑相同 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` 分別 | 與檔案路徑相同 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` 分別 | 與檔案路徑相同 |
| ODP, OTP | `Odp`, `Otp` 分別 | 與檔案路徑相同 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

對於無檔名的串流，PPS/POT 內容會被辨識為 `Ppt`。此表說明格式辨識，而非在轉換過程中保留每項簡報功能。

## **常見問題**

**將簡報從 PPTX 儲存為 ODP 會改變其來源格式嗎？**

不會。現有的實例仍報告 `Pptx`。從已儲存的 ODP 檔案載入的實例則報告 `Odp`。

**串流能否永遠區分舊版簡報、投影片放映與範本？**

不能。PPT、PPS 與 POT 使用相同的二進位格式。若需要此區別，請另行保留檔名或子類型中繼資料。

**如果簡報已載入，應使用哪個 API？**

請閱讀 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getSourceFormat)。若要在載入前進行檢查，請使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo)。