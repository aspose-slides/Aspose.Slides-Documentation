---
title: 在 Android 上儲存簡報
linktitle: 儲存簡報
type: docs
weight: 80
url: /zh-hant/androidjava/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存簡報
- 儲存投影片
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 簡報至檔案
- 簡報至資料流
- 預先定義的檢視類型
- Strict Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 在 Java 中儲存簡報——匯出為 PowerPoint 或 OpenDocument 同時保留版面配置、字型與特效。"
---
## **概述**

[在 Android 上開啟簡報](/slides/zh-hant/androidjava/open-presentation/) 介紹了如何使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別開啟簡報。本篇說明如何建立與儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別包含簡報的內容。無論是從頭建立簡報或是修改現有簡報，完成後都需要儲存。使用 Aspose.Slides for Android，您可以儲存至 **file** 或 **stream**。本篇說明不同的儲存方式。

## **將簡報儲存至檔案**

呼叫 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的 `save` 方法，傳入檔名與儲存格式，即可將簡報儲存至檔案。以下範例示範如何使用 Aspose.Slides 儲存簡報。

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 在此執行一些工作...

    // 將簡報儲存至檔案。
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將簡報儲存至資料流**

將輸出串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的 `save` 方法，即可將簡報儲存至資料流。簡報可以寫入多種串流類型。以下範例建立新簡報並將其儲存至檔案串流。

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // 將簡報儲存至資料流。
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **使用預先定義的檢視類型儲存簡報**

Aspose.Slides 允許透過 [ViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/) 類別設定 PowerPoint 開啟產生的簡報時的初始檢視。使用 [setLastView](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) 方法，並傳入來自 [ViewType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewtype/) 列舉的值。

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以 Strict Office Open XML 格式儲存簡報**

Aspose.Slides 允許以 Strict Office Open XML 格式儲存簡報。使用 [PptxOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxoptions/) 類別，並在儲存時設定其 `conformance` 屬性。若將其設為 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict)，輸出檔案即會採用 Strict Office Open XML 格式。

以下範例建立簡報並以 Strict Office Open XML 格式儲存。

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 以 Strict Office Open XML 格式儲存簡報。
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **以 Zip64 模式儲存 Office Open XML 格式的簡報**

Office Open XML 檔案是一個 ZIP 壓縮檔，對未壓縮檔案大小、壓縮檔案大小以及整個壓縮檔的總大小皆有限制（4 GB），且檔案數量上限為 65 535 個。ZIP64 格式擴充可將這些限制提升至 2⁶⁴。

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) 方法讓您在儲存 Office Open XML 檔案時選擇何時使用 ZIP64 格式擴充。

此方法可搭配以下模式使用：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zip64mode/#IfNecessary) 僅在簡報超過上述限制時使用 ZIP64 格式擴充。這是預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zip64mode/#Never) 永不使用 ZIP64 格式擴充。
- [Always](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zip64mode/#Always) 總是使用 ZIP64 格式擴充。

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
當您使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zip64mode/#Never) 儲存時，如果簡報無法以 ZIP32 格式儲存，將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxexception/)。
{{% /alert %}}

## **儲存簡報時不重新整理縮圖**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) 方法用於控制儲存 PPTX 時是否產生縮圖：

- 設為 `true` 時，儲存過程會重新整理縮圖（預設值）。
- 設為 `false` 時，保留目前的縮圖。如果簡報本身沒有縮圖，則不會產生新的縮圖。

以下程式碼示範如何在不重新整理縮圖的情況下將簡報儲存為 PPTX。

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
此選項可減少將簡報儲存為 PPTX 格式所需的時間。
{{% /alert %}}

## **以百分比儲存進度更新**

[IProgressCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprogresscallback/) 介面可透過 [ISaveOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isaveoptions/) 介面的 `setProgressCallback` 方法以及抽象的 [SaveOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveoptions/) 類別使用。將實作了 IProgressCallback 的物件以 `setProgressCallback` 設定，即可在儲存時以百分比接收進度更新。

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
Aspose 開發了一個使用其 API 的免費 PowerPoint 分割工具 [PowerPoint Splitter app](https://products.aspose.app/slides/zh-hant/splitter)。此應用程式可將簡報依選取的投影片另存為新 PPTX 或 PPT 檔案，達到分割效果。
{{% /alert %}}

## **常見問題**

**是否支援「快速儲存」（增量儲存）只寫入變更部分？**  
不支援。每次儲存都會重新產生完整目標檔案，未提供增量「快速儲存」功能。

**同一個 Presentation 例項可以從多個執行緒同時儲存嗎？**  
不可以。[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 例項 **不是執行緒安全** 的，請在單一執行緒中完成儲存。

**儲存時會發生什麼事於超連結與外部連結檔案？**  
[Hyperlinks](/slides/zh-hant/androidjava/manage-hyperlinks/) 會被保留。外部連結的檔案（例如以相對路徑引用的影片）不會自動複製，必須自行確保路徑仍可存取。

**我可以設定/儲存文件的中繼資料（作者、標題、公司、日期）嗎？**  
可以。標準的 [document properties](/slides/zh-hant/androidjava/presentation-properties/) 受支援，儲存時會寫入檔案中。