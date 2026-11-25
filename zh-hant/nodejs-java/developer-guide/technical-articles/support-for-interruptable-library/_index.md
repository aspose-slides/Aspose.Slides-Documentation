---
title: 中斷 Node.js 中長時間執行的簡報操作
linktitle: 中斷簡報操作
type: docs
weight: 120
url: /zh-hant/nodejs-java/support-for-interruptable-library/
keywords:
- 可中斷的操作
- 中斷 token
- 取消 token
- 轉換逾時
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中取消長時間執行的簡報操作、設定轉換逾時，並追蹤取消前已匯出的投影片。"
---
## **概覽**

Aspose.Slides for Node.js via Java 在載入、儲存或呈現簡報時支援取消。您也可以在自己的匯出迴圈中檢查相同的 token，以在下一張投影片之前停止，並回傳已儲存的投影片編號。

## **中斷簡報操作**

建立一個[InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/)，使用[getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) 取得其 token，並將其傳遞給[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken)。 在建構[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 時使用這些選項。對來源呼叫[interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) 會請求取消目前的操作。Aspose.Slides 會在下次檢查 token 時停止。

### **設定轉換逾時**

以下範例允許 20 秒開啟 `sample.pptx` 並將其儲存為 `sample.pdf`。建構子與儲存皆透過 Java 橋接以非同步方式執行，讓 Node.js 計時器能在任一操作期間觸發。範例在載入後以及儲存後檢查 token，因為函式庫呼叫可能在取消請求後才回傳。當操作結束時會釋放簡報，若轉換提前完成則清除計時器。若在儲存期間發生取消，輸出檔案可能已存在且可能不完整。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

若要在 10 秒限制下轉換為較舊的 PowerPoint 格式，請將 `"sample.ppt"`、`slides.SaveFormat.Ppt` 與 `10000` 作為最後三個參數傳入。

## **在處理下一張投影片前停止**

在每次匯出之前使用[isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested)，以便呼叫端可以使用部分結果。針對選取投影片的[save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) 多載接受一個 Java `int[]`，其中的投影片編號從 1 開始。僅在其 PDF 成功儲存後才記錄每個編號。

以包含至少兩張投影片、名稱為 `sample.pptx` 的簡報執行範例。為了示範匯出之間的取消，範例會在儲存第一張投影片後立即請求取消。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

範例會寫入 `slide-1.pdf`，並印出 `Starting slide 1`，接著是 `Completed: [1]`。迴圈在開始第二張投影片前偵測到取消。如果儲存本身被中斷，返回的清單僅包含先前成功的匯出。

若要讓呼叫端將取消視為錯誤處理，請將迴圈頂部的檢查與 `break` 替換為[throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested)，以 `token.throwIfInterruptionRequested()` 呼叫。於儲存之後使用相同的拋出檢查，並移除其周圍的 `try`/`catch`。使用相同的輸入時，第一個 PDF 仍會寫入，第二次迭代會在函式返回清單之前拋出例外。

## **常見問答**

**什麼時候應該請求取消？**

當期限已到或應用程式不再需要結果時，請求取消。載入、儲存與呈現皆可使用在建構簡報時傳入的 token。

**來源與 token 有何不同？**

來源讓應用程式請求取消。token 讓 Aspose.Slides 以及您的程式碼檢查該請求。

**Node.js 計時器能中斷同步儲存嗎？**

同步儲存會阻塞呼叫執行緒上的 JavaScript。請使用逾時範例中示範的非同步 Java 橋接呼叫，使計時器能在儲存執行期間請求取消。

**取消會立即生效嗎？**

取消是合作式的。正在執行的操作會在偵測到請求時停止。已完成的操作會保留其結果。

**多個操作可以共用同一來源嗎？**

可以。呼叫 `interrupt()` 會對所有使用該來源產生的 token 的操作請求取消。若希望獨立取消每個操作，請為每個操作使用不同的來源。