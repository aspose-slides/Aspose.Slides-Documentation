---
title: 在 Java 中儲存簡報
linktitle: 儲存簡報
type: docs
weight: 80
url: /zh-hant/java/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存簡報
- 儲存投影片
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 簡報至檔案
- 簡報至串流
- 預先定義的檢視類型
- 嚴格 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Java 中儲存簡報——匯出為 PowerPoint 或 OpenDocument，同時保留版面配置、字型與效果。"
---
## **概覽**

[Open Presentations in Java](/slides/zh-hant/java/open-presentation/) 說明了如何使用 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別開啟簡報。本文章說明如何建立和儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別包含簡報的內容。無論是從頭建立簡報或是修改現有簡報，完成後都需要將其儲存。使用 Aspose.Slides for Java，您可以儲存至 **檔案** 或 **串流**。本文章說明儲存簡報的不同方式。

## **將簡報儲存至檔案**

透過呼叫 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的 `save` 方法即可將簡報儲存至檔案。將檔名與儲存格式傳入該方法。下列範例示範如何使用 Aspose.Slides 儲存簡報。

```java
// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 在此執行一些作業……
    // 將簡報儲存至檔案。
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將簡報儲存至串流**

您可以透過將輸出串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的 `save` 方法，將簡報儲存至串流。簡報可以寫入多種串流類型。以下範例中，我們建立新簡報並將其儲存至檔案串流。

```java
// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // 將簡報儲存至串流。
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **以預定義檢視類型儲存簡報**

Aspose.Slides 允許您透過 [ViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/) 類別設定產生的簡報開啟時 PowerPoint 使用的初始檢視。使用來自 [ViewType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewtype/) 列舉的值，呼叫 [setLastView](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/#setLastView-int-) 方法。

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以嚴格 Office Open XML 格式儲存簡報**

Aspose.Slides 允許您以嚴格 Office Open XML 格式儲存簡報。儲存時使用 [PptxOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxoptions/) 類別並設定其 conformance 屬性。若將其設定為 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/conformance/#Iso29500-2008-Strict)，則輸出檔案會以嚴格 Office Open XML 格式儲存。

以下範例建立簡報並以嚴格 Office Open XML 格式儲存。

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 將簡報儲存為嚴格的 Office Open XML 格式。
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **以 Zip64 模式在 Office Open XML 格式儲存簡報**

Office Open XML 檔案是一個 ZIP 壓縮檔，對任何檔案的未壓縮大小、壓縮後大小以及整個壓縮檔的總大小皆限制為 4 GB（2^32 位元組），且檔案數量上限為 65,535（2^16-1）個。ZIP64 格式擴充可將這些限制提升至 2^64。

透過 [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) 方法，您可以在儲存 Office Open XML 檔案時選擇何時使用 ZIP64 格式擴充。

此方法可搭配以下模式使用：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/zip64mode/#IfNecessary) 只在簡報超過上述限制時使用 ZIP64 格式擴充。這是預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/zip64mode/#Never) 永不使用 ZIP64 格式擴充。
- [Always](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/zip64mode/#Always) 總是使用 ZIP64 格式擴充。

以下程式碼示範如何在啟用 ZIP64 格式擴充的情況下將簡報儲存為 PPTX：

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
當您以 [Zip64Mode.Never](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/zip64mode/#Never) 儲存時，如果簡報無法以 ZIP32 格式儲存，將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxexception/)。
{{% /alert %}}

## **儲存簡報時不重新整理縮圖**

透過 [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) 方法可控制將簡報儲存為 PPTX 時的縮圖產生：

- 若設定為 `true`，則在儲存過程中重新整理縮圖。這是預設值。
- 若設定為 `false`，則保留現有縮圖。若簡報沒有縮圖，則不會產生。

以下程式碼將簡報儲存為 PPTX，且不會重新整理縮圖。

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
此選項有助於縮短儲存 PPTX 格式簡報所需的時間。
{{% /alert %}}

## **以百分比顯示儲存進度更新**

[IProgressCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/) 介面會透過 [ISaveOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isaveoptions/) 介面的 `setProgressCallback` 方法以及抽象的 [SaveOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveoptions/) 類別使用。使用 `setProgressCallback` 指派一個 [IProgressCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/) 實作，即可接收以百分比表示的儲存進度更新。

以下程式碼片段示範如何使用 `IProgressCallback`。

```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // 在此使用進度百分比值。
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose 已開發一個使用其 API 的 [免費 PowerPoint Splitter 應用程式](https://products.aspose.app/slides/zh-hant/splitter)。此應用程式可將簡報分割成多個檔案，透過將選取的投影片另存為新的 PPTX 或 PPT 檔案。
{{% /alert %}}

## **常見問題**

**是否支援「快速儲存」（增量儲存）僅寫入變更？**

不支援。每次儲存都會重新建立完整目標檔案，未支援增量「快速儲存」。

**從多個執行緒儲存同一 Presentation 實例是否為執行緒安全？**

不支援。 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 實例 [不是執行緒安全](/slides/zh-hant/java/multithreading/)。請在單一執行緒中儲存。

**儲存時超連結與外部連結檔案會發生什麼情況？**

[Hyperlinks](/slides/zh-hant/java/manage-hyperlinks/) 會被保留。外部連結檔案（例如使用相對路徑的影片）不會自動複製——請確保相關路徑仍可存取。

**我可以設定/儲存文件中繼資料（作者、標題、公司、日期）嗎？**

可以。支援標準的 [document properties](/slides/zh-hant/java/presentation-properties/)，儲存時會寫入檔案。