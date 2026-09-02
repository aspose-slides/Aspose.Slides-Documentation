---
title: 在 Java 中將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/java/convert-ppt-to-pptx/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- PPT 轉 PPTX
- 將 PPT 儲存為 PPTX
- 將 PPT 匯出為 PPTX
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中將舊版 PPT 檔案轉換為 PPTX。包括單檔與批次轉換的 Java 範例、錯誤處理與相容性說明。"
---
## **概觀**

PPT 是舊版的二進位 PowerPoint 格式，而 PPTX 是較新的 Open XML 格式。Aspose.Slides for Java 能在不使用 Microsoft PowerPoint 的情況下載入 PPT 檔案並將其另存為 PPTX。本文說明如何轉換單一檔案或整個目錄的檔案，並解釋轉換後需要檢查的項目。

## **將 PPT 檔案轉換為 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別載入來源檔案，然後呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 並傳入 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/#Pptx)。`finally` 區塊會釋放簡報並釋放其資源。

```java
// 載入舊版 PPT 簡報。
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // 將簡報儲存為 PPTX 格式。
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

檔案副檔名本身不會決定輸出格式；必須使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/#Pptx) 參數來指定。如需保留原始 PPT 檔案，請確保輸入路徑與輸出路徑不同。

## **一次轉換多個 PPT 檔案**

以下範例會將一個目錄中的所有 `.ppt` 檔案轉換。每個檔案獨立處理，單一轉換失敗不會中斷其餘批次。

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

在正式環境中，請記錄完整例外資訊，決定是否允許覆寫已存在的輸出檔案，並將失敗的檔名寫入重試或審查佇列。損壞的檔案、未提供正確密碼而開啟的受保護檔案、無法存取的路徑以及不支援的內容，都可能導致轉換失敗。請參閱 [Password-Protected Presentations](/java/password-protected-presentation/) 以了解載入加密檔案的方法。

## **相容性與舊版功能**

轉換通常會保留投影片、母片、版面配置、文字、圖形、影像、表格與圖表。然而，PPT 與 PPTX 並不以完全相同的方式呈現所有功能。若舊版功能在 PPTX 中沒有對應項目，或是程式庫不支援，可能會被正規化、略過或以不同方式顯示。

當檔案包含動畫、過場、內嵌或連結的 OLE 物件、ActiveX 控制項、內嵌媒體、少見字型或 VBA 巨集時，請檢查轉換後的檔案。一般的 PPTX 檔案不支援巨集，若必須保留 VBA，請使用相應的巨集支援工作流程。同時也要確認所需字型與外部資源是否已在開啟或轉譯轉換後簡報的環境中存在。

針對重要文件，請以程式方式重新開啟產生的 PPTX，檢查主要投影片數量與內容，並在目標檢視器中比較其外觀與投影片播放效果。不要將成功的 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 呼叫視為所有舊版功能都有完全對應的 PPTX 表示的證明。

## **何時使用 PPTX**

當簡報需要在最新的 PowerPoint 版本中編輯、與支援 Open XML 套件的系統交換，或是希望以較易檢視與復原的格式儲存時，請使用 PPTX。保留原始 PPT 作為歸檔或回滾副本，直到轉換後的簡報通過您的相容性檢查為止。

如果您需要 PDF、HTML、影像、XPS 或其他輸出類型，請參考 [Convert Presentations to Multiple Formats](/java/convert-presentation/) 中針對特定格式的說明，而不要假設所有目標都能保留可編輯的 PowerPoint 功能。

## **線上轉換器**

若僅需偶爾轉換單一檔案或快速比較，可使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)。若需重複轉換、批次處理或應用層級的錯誤處理，請使用 Java API。

## **相關文章**

- [PPT 與 PPTX 比較](/java/ppt-vs-pptx/)
- [在 Java 中儲存簡報](/java/save-presentation/)
- [支援的檔案格式](/java/supported-file-formats/)
- [在 Java 中開啟簡報](/java/open-presentation/)

## **常見問題**

**我可以在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX 嗎？**

可以。Aspose.Slides for Java 能在不需要 Microsoft PowerPoint 的情況下載入與儲存簡報檔案。

**PPT 轉換為 PPTX 會完整保留所有內容嗎？**

它會保留一般的簡報內容，但對於每個舊版或未支援的功能，無法保證完全相同的相容性。當檔案包含巨集、OLE 或 ActiveX 物件、媒體、特殊動畫或少見字型時，請檢查產生的檔案。

**我可以轉換受密碼保護的 PPT 檔案嗎？**

可以，只要在載入檔案時提供正確的密碼。如果缺少或密碼錯誤，載入操作將失敗。

**轉換完成後，我應該刪除 PPT 檔案嗎？**

請保留原始檔案，直到您在相關的檢視器與工作流程中驗證 PPTX 為止。若舊版功能轉換後有所不同，這樣可以作為回滾備份。