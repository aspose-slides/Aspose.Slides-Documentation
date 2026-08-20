---
title: 在 Android 上將 PPT 轉換為 PPTX
linktitle: PPT 轉換為 PPTX
type: docs
weight: 20
url: /zh-hant/androidjava/convert-ppt-to-pptx/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- PPT 轉換為 PPTX
- 將 PPT 儲存為 PPTX
- 匯出 PPT 為 PPTX
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Android 上將舊版 PPT 檔案轉換為 PPTX。包含單檔與批次轉換的 Java 範例、錯誤處理與相容性說明。"
---
## **概覽**

PPT 是舊式的二進位 PowerPoint 格式，而 PPTX 是較新的 Open XML 格式。Aspose.Slides for Android via Java 能在未安裝 Microsoft PowerPoint 的情況下載入 PPT 檔案並將其儲存為 PPTX。本文說明如何轉換單一檔案或整個目錄，並解釋轉換後需要檢查的項目。

## **將 PPT 檔案轉換為 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別載入來源檔案，然後以 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/#Pptx) 作為參數呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)。`finally` 區塊會釋放 Presentation 並釋放其資源。

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

檔案副檔名本身不會決定輸出格式；需由 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/#Pptx) 參數指定。如果需要保留原始 PPT 檔案，請確保輸入與輸出路徑不同。

## **一次轉換多個 PPT 檔案**

以下範例會將單一目錄中的每個 `.ppt` 檔案轉換。每個檔案皆獨立處理，單一轉換失敗不會中斷其餘批次。

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

在正式環境中，請記錄完整例外資訊，決定是否允許覆寫已存在的輸出檔案，並將失敗的檔名寫入重試或審查佇列。損壞的檔案、未提供正確密碼而開啟的受保護檔案、無法存取的路徑以及不支援的內容，都可能導致轉換失敗。請參閱 [Password-Protected Presentations](/androidjava/password-protected-presentation/) 以載入加密檔案。

## **相容性與舊版功能**

轉換通常會保留投影片、投影片母版、版面配置、文字、圖形、影像、表格與圖表。然而，PPT 與 PPTX 並未以完全相同方式呈現所有功能。若某個舊版功能在 PPTX 中沒有對應項目，或未被函式庫支援，可能會被正規化、省略或以不同方式顯示。

若轉換後的檔案包含動畫、轉場、內嵌或連結的 OLE 物件、ActiveX 控制項、內嵌媒體、不常見的字型或 VBA 巨集，請特別檢查。純 PPTX 檔案並非支援巨集的格式，若必須保留 VBA，需使用支援巨集的工作流程。此外，亦需確認所需字型與外部資源已存在於開啟或渲染轉換後簡報的環境中。

對於重要文件，請以程式方式重新開啟產生的 PPTX，檢查關鍵的投影片數量與內容，然後在目標檢視器中比較其外觀與投影片放映行為。不要僅僅因為 [Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 呼叫成功，就認為所有舊版功能均有精確的 PPTX 對應。

## **何時使用 PPTX**

當簡報需要在最新的 PowerPoint 版本中編輯、與支援 Open XML 套件的系統交換，或以較易檢視與復原的格式儲存時，請使用 PPTX。請將原始 PPT 保留為存檔或回滾備份，直至轉換後的簡報通過相容性檢查。

若需要 PDF、HTML、影像、XPS 或其他輸出類型，請參考 [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) 中針對特定格式的說明，而不要假設所有目標格式皆能保留可編輯的 PowerPoint 功能。

## **線上轉換工具**

若僅需偶爾轉換單一檔案或快速比對，可使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)。若需要重複轉換、批次處理或應用層面的錯誤處理，請使用 Android via Java API。

## **相關文章**

- [PPT 與 PPTX 比較](/androidjava/ppt-vs-pptx/)
- [在 Android 上儲存簡報](/androidjava/save-presentation/)
- [支援的檔案格式](/androidjava/supported-file-formats/)
- [在 Android 上開啟簡報](/androidjava/open-presentation/)

## **常見問題**

**我可以在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX 嗎？**

可以。Aspose.Slides for Android via Java 能在不需要 Microsoft PowerPoint 的情況下載入與儲存簡報檔案。

**PPT 轉換為 PPTX 會完整保留所有內容嗎？**

它會保留常見的簡報內容，但對於每個舊版或不受支援的功能，無法保證完全相同的相容性。當檔案包含巨集、OLE 或 ActiveX 物件、媒體、特殊動畫或不常見字型時，請仔細檢查產生的檔案。

**我可以轉換受密碼保護的 PPT 檔案嗎？**

可以，只要在載入檔案時提供正確的密碼。若密碼遺失或不正確，載入操作會失敗。

**轉換完成後我應該刪除 PPT 檔案嗎？**

請保留原始檔案，直到您在相關的檢視器與工作流程中驗證過 PPTX 為止。這樣可在舊版功能轉換異常時提供回滾備份。