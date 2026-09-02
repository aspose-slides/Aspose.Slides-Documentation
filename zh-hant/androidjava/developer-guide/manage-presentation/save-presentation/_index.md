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
- 簡報至串流
- 預先定義的檢視類型
- Strict Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Android
- Java
- Aspose.Slides
description: "探索如何使用 Aspose.Slides for Android 在 Java 中儲存簡報—匯出為 PowerPoint 或 OpenDocument，同時保留版面配置、字型與效果。"
---
## **概述**

[Open Presentations on Android](/slides/zh-hant/androidjava/open-presentation/) 說明如何使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別來開啟簡報。本文說明如何建立與儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別包含簡報的內容。無論您是從頭建立簡報或是修改現有簡報，完成後都需要將其儲存。使用 Aspose.Slides for Android，您可以儲存至 **檔案** 或 **串流**。本文說明儲存簡報的不同方式。

## **將簡報儲存至檔案**

透過呼叫 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的 `save` 方法將簡報儲存為檔案。將檔名與儲存格式傳遞給該方法。以下範例說明如何使用 Aspose.Slides 儲存簡報。

```java
import com.aspose.slides.*;

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

## **將簡報儲存至串流**

您可以透過將輸出串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的 `save` 方法，將簡報儲存至串流。簡報可以寫入多種串流類型。以下範例中，我們建立新簡報並將其儲存至檔案串流。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// 實例化代表簡報檔案的 Presentation 類別。
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

## **使用預先定義的檢視類型儲存簡報**

Aspose.Slides 允許您透過 [ViewProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/) 類別設定產生的簡報開啟時 PowerPoint 使用的初始檢視。使用 [setLastView](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) 方法，並傳入來自 [ViewType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewtype/) 列舉的值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以 Strict Office Open XML 格式儲存簡報**

Aspose.Slides 讓您以 Strict Office Open XML 格式儲存簡報。儲存時使用 [PptxOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxoptions/) 類別並設定其 conformance 屬性。若設定 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict)，則輸出檔案會以 Strict Office Open XML 格式儲存。

以下範例建立簡報並以 Strict Office Open XML 格式儲存。

```java
import com.aspose.slides.*;

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

Office Open XML 檔案是一個 ZIP 壓縮檔，其對任何檔案的未壓縮大小、壓縮後大小以及整個壓縮檔的總大小皆限制在 4 GB (2^32 位元組)，且檔案數量上限為 65,535 (2^16-1) 個。ZIP64 格式擴充可將這些限制提升至 2^64。

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) 方法讓您在儲存 Office Open XML 檔案時選擇何時使用 ZIP64 格式擴充。

此方法可搭配以下模式使用：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zip64mode/#IfNecessary) 僅在簡報超過上述限制時才使用 ZIP64 格式擴充。這是預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zip64mode/#Never) 絕不使用 ZIP64 格式擴充。
- [Always](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zip64mode/#Always) 總是使用 ZIP64 格式擴充。

以下程式碼示範如何在啟用 ZIP64 格式擴充的情況下將簡報儲存為 PPTX 檔案：

```java
import com.aspose.slides.*;

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
使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zip64mode/#Never) 儲存時，如果簡報無法以 ZIP32 格式儲存，將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級儲存 Office Open XML 格式的簡報**

處理大型簡報時，您可以調整壓縮等級以在檔案大小與處理時間之間取得平衡。根據需求，您可能會偏好較快的處理速度或較小的輸出檔案。

Aspose.Slides 提供 [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) 方法，讓您在以 Office Open XML 格式儲存簡報時指定壓縮等級。

以下壓縮等級可供選擇：

- [**None**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#None): 不套用壓縮。檔案會原樣儲存。
- [**Level1**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level1): 壓縮速度最快，但壓縮比最低。
- [**Level2**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level2): 壓縮速度較快，且壓縮比略優於 **Level1**。
- [**Level3**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level3): 壓縮比優於 **Level2**，對處理時間有適度影響。
- [**Level4**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level4): 壓縮比優於 **Level3**。
- [**Level5**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level5): 在 **Level4** 基礎上提升壓縮比，但需額外的處理時間。
- [**Level6**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level6): 標準壓縮，提供處理速度與檔案大小的良好平衡。這是 *預設壓縮等級*。
- [**Level7**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level7): 壓縮比優於 **Level6**，但處理較慢。
- [**Level8**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level8): 壓縮比優於 **Level7**。
- [**Level9**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level9): 最高壓縮。產生最小檔案大小，但需最長的處理時間。

以下範例示範如何將簡報儲存為 PPTX 檔案 *不使用壓縮*：

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

此範例示範如何將簡報儲存為 PPTX 檔案，並使用 *最高壓縮*：

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **儲存簡報時不重新整理縮圖**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) 方法控制儲存簡報為 PPTX 時是否產生縮圖：

- 設為 `true` 時，儲存過程中會重新整理縮圖。這是預設行為。
- 設為 `false` 時，保留目前的縮圖。如果簡報沒有縮圖，則不會產生。

以下程式碼示範將簡報儲存為 PPTX 而不重新整理其縮圖。

```java
import com.aspose.slides.*;

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

[IProgressCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprogresscallback/) 介面透過 [ISaveOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isaveoptions/) 介面與抽象類別 [SaveOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveoptions/) 中的 `setProgressCallback` 方法使用。使用 `setProgressCallback` 指定 [IProgressCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprogresscallback/) 實作，即可以百分比方式接收儲存進度更新。

以下程式碼片段示範如何使用 `IProgressCallback`。

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // 在此使用進度百分比值。
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose 已開發一個使用其自身 API 的 [free PowerPoint Splitter app](https://products.aspose.app/slides/zh-hant/splitter)。該應用程式讓您透過將選取的投影片儲存為新的 PPTX 或 PPT 檔案，將簡報分割成多個檔案。
{{% /alert %}}

## **常見問題**

**是否支援「快速儲存」（增量儲存）只寫入變更？**

否。儲存每次都會建立完整的目標檔案；不支援增量的「快速儲存」。

**從多執行緒同時儲存同一個 Presentation 實例是否安全？**

否。`Presentation` 實例「不是執行緒安全」的；請從單一執行緒儲存。

**儲存時超連結與外部連結檔案會發生什麼情況？**

[Hyperlinks] 會被保留。外部連結的檔案（例如以相對路徑的影片）不會自動複製——請確保相關路徑仍然可存取。

**我可以設定/儲存文件中繼資料（作者、標題、公司、日期）嗎？**

可以。支援標準的 [document properties]，且儲存時會寫入檔案。