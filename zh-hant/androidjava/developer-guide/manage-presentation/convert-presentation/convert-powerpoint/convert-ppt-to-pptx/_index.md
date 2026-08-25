---
title: 在 Android 上將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/androidjava/convert-ppt-to-pptx/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- PPT 轉 PPTX
- 將 PPT 儲存為 PPTX
- 匯出 PPT 為 PPTX
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Android 上將舊版 PPT 檔案轉換為 PPTX。包括單檔與批次轉換的 Java 範例、錯誤處理與忠實度說明。"
---
## **概述**

PPT 是舊版二進位 PowerPoint 格式，而 PPTX 是較新的 Open XML 格式。Aspose.Slides for Android via Java 能在不需要 Microsoft PowerPoint 的情況下載入 PPT 檔並將其儲存為 PPTX。本篇文章說明如何轉換單一檔案或整個目錄的檔案，以及轉換後需要驗證的項目。

## **將 PPT 檔案轉換為 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別載入來源檔案，然後以 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/#Pptx) 呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)。`finally` 區塊會釋放簡報並釋放其資源。

```java
// 載入舊版 PPT 簡報。
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // 以 PPTX 格式儲存簡報。
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

檔案副檔名本身不會決定輸出格式；必須使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/#Pptx) 參數來指定。如果需要保留原始 PPT 檔，請將輸入路徑與輸出路徑設定為不同位置。

## **轉換多個 PPT 檔案**

以下範例會將一個目錄中的每個 `.ppt` 檔案轉換。每個檔案皆獨立處理，單一轉換失敗不會中斷其餘批次。

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

在正式環境中，請記錄完整例外資訊，決定是否允許覆寫已存在的輸出檔，並將失敗的檔案名稱寫入重試或審查佇列。損毀的檔案、未提供正確密碼而開啟的受保護檔案、無法存取的路徑，以及不支援的內容，都可能導致轉換失敗。請參閱 [受密碼保護的簡報](/androidjava/password-protected-presentation/) 以載入加密檔案。

## **忠實度與舊版功能**

轉換通常會保留投影片、母片、版面配置、文字、圖形、影像、表格與圖表。然而，PPT 與 PPTX 並未以完全相同的方式呈現所有功能。若某個舊版功能在 PPTX 中沒有等價項目，或未被函式庫支援，可能會被正規化、略過，或以不同方式顯示。

當轉換的檔案包含動畫、過場、內嵌或連結的 OLE 物件、ActiveX 控制項、內嵌媒體、不常見字型或 VBA 巨集時，請檢查轉換結果。純 PPTX 檔案不是可啟用巨集的格式，若必須保留 VBA，需採用相應的巨集支援工作流程。另外，亦需確認必要的字型與外部資源在開啟或渲染轉換後簡報的環境中皆已存在。

對於重要文件，請以程式方式重新開啟產生的 PPTX，檢查關鍵的投影片數量與內容，然後在目標檢視器中比較其外觀與投影片放映行為。不要將成功的 [Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 呼叫視為所有舊版功能均有完全相同 PPTX 表現的證明。

## **何時使用 PPTX**

當簡報將在最新版 PowerPoint 中編輯、與支援 Open XML 套件的系統交換，或需要以較易檢查與復原的格式儲存時，請使用 PPTX。保留原始 PPT 作為存檔或回滾備份，直到轉換後的簡報通過您的忠實度檢查為止。

若您需要 PDF、HTML、影像、XPS 或其他輸出類型，請參考 [Convert Presentations to Multiple Formats](/slides/zh-hant/androidjava/convert-presentation/) 中針對特定格式的說明，而不要假設所有目標格式皆保留可編輯的 PowerPoint 功能。

## **線上轉換器**

若僅需偶爾轉換單一檔案或快速比較，可使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)。若需可重複的轉換、批次處理或應用層級的錯誤處理，請使用 Android via Java API。

## **相關文章**

- [PPT 與 PPTX 比較](/slides/zh-hant/androidjava/ppt-vs-pptx/)
- [在 Android 上儲存簡報](/slides/zh-hant/androidjava/save-presentation/)
- [支援的檔案格式](/slides/zh-hant/androidjava/supported-file-formats/)
- [在 Android 上開啟簡報](/slides/zh-hant/androidjava/open-presentation/)

## **常見問題**

**我可以在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX 嗎？**

可以。Aspose.Slides for Android via Java 能在不需要 Microsoft PowerPoint 的情況下載入與儲存簡報檔案。

**PPT 轉 PPTX 的轉換會完全保留所有內容嗎？**

它會保留一般的簡報內容，但對於每個舊版或未支援的功能，無法保證精確的忠實度。當檔案包含巨集、OLE 或 ActiveX 物件、媒體、特殊動畫或不常見字型時，請檢查產生的檔案。

**我可以轉換受密碼保護的 PPT 檔案嗎？**

可以，只要在載入檔案時提供正確的密碼。缺少或錯誤的密碼會導致載入失敗。

**轉換完成後我應該刪除 PPT 檔案嗎？**

請保留原始檔，直到您在相關檢視器與工作流程中驗證 PPTX 為止。若舊版功能轉換結果不同，原始檔可作為回滾備份。