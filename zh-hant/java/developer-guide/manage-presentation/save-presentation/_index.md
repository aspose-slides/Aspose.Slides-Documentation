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
- Strict Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Java
- Aspose.Slides
description: "探索如何使用 Aspose.Slides 在 Java 中儲存簡報——匯出至 PowerPoint 或 OpenDocument，同時保留版面配置、字型與效果。"
---
## **概覽**

[Open Presentations in Java](/slides/zh-hant/java/open-presentation/) 說明了如何使用 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別開啟簡報。本文章闡述如何建立與儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別包含簡報的內容。無論是從頭建立簡報或是修改現有簡報，完成後都需要儲存。使用 Aspose.Slides for Java，您可以儲存至 **檔案** 或 **串流**。本文章說明儲存簡報的不同方式。

## **將簡報儲存至檔案**

透過呼叫 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的 `save` 方法，即可將簡報儲存至檔案。將檔名與儲存格式傳遞給該方法。以下範例示範如何使用 Aspose.Slides 儲存簡報。

```java
import com.aspose.slides.*;

// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 在此執行一些操作...
    
    // 將簡報儲存至檔案。
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將簡報儲存至串流**

您可以透過將輸出串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的 `save` 方法，將簡報儲存至串流。簡報可寫入多種串流類型。以下範例中，我們建立新的簡報並儲存至檔案串流。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

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

## **以預先設定的檢視類型儲存簡報**

Aspose.Slides 允許您透過 [ViewProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/) 類別設定產生的簡報開啟時 PowerPoint 使用的初始檢視。使用 [setLastView](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/#setLastView-int-) 方法，傳入來自 [ViewType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewtype/) 列舉的值。

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

Aspose.Slides 允許您以 Strict Office Open XML 格式儲存簡報。儲存時使用 [PptxOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxoptions/) 類別並設定其 conformance 屬性。若設定為 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/conformance/#Iso29500-2008-Strict)，輸出檔案即以 Strict Office Open XML 格式儲存。

以下範例建立簡報並以 Strict Office Open XML 格式儲存。

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 以 Strict Office Open XML 格式儲存簡報。
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **以 Zip64 模式儲存 Office Open XML 格式的簡報**

Office Open XML 檔案是 ZIP 壓縮檔，對任何檔案的未壓縮大小、壓縮後大小以及整個壓縮檔的總大小皆有限制 4 GB (2^32 位元組)，且檔案數量上限為 65,535 (2^16‑1) 個。ZIP64 格式擴充可將這些限制提升至 2^64。

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) 方法讓您在儲存 Office Open XML 檔案時選擇何時使用 ZIP64 格式擴充。

此方法可搭配以下模式使用：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/zip64mode/#IfNecessary) 僅在簡報超過上述限制時使用 ZIP64 格式擴充。這是預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/zip64mode/#Never) 永不使用 ZIP64 格式擴充。
- [Always](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/zip64mode/#Always) 總是使用 ZIP64 格式擴充。

以下程式碼示範如何以啟用 ZIP64 格式擴充的方式將簡報儲存為 PPTX 檔案：

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
當您以 [Zip64Mode.Never](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/zip64mode/#Never) 儲存時，如果簡報無法以 ZIP32 格式儲存，將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級儲存 Office Open XML 格式的簡報**

處理大型簡報時，您可以調整壓縮等級，以平衡檔案大小與處理時間。根據需求，您可能偏好較快的處理速度或較小的輸出檔案。

Aspose.Slides 提供的 [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) 方法，允許您在儲存 Office Open XML 格式的簡報時指定壓縮等級。

以下壓縮等級可供選擇：

- [**None**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#None)：不套用任何壓縮。檔案保持原樣儲存。
- [**Level1**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level1)：最快的壓縮速度，壓縮比最低。
- [**Level2**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level2)：比 Level1 稍佳的壓縮比，速度仍快。
- [**Level3**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level3)：比 Level2 更佳的壓縮，對處理時間有適度影響。
- [**Level4**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level4)：較 Level3 更好的壓縮。
- [**Level5**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level5)：較 Level4 有改進的壓縮，但需要更多處理時間。
- [**Level6**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level6)：標準壓縮，於處理速度與檔案大小之間取得良好平衡。此為 *預設壓縮等級*。
- [**Level7**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level7)：較 Level6 更佳的壓縮，但處理較慢。
- [**Level8**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level8)：較 Level7 更佳的壓縮。
- [**Level9**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level9)：最高壓縮率。產生最小檔案大小，但需最長的處理時間。

以下範例示範如何以 *不壓縮* 的方式將簡報儲存為 PPTX 檔案：

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

此範例示範如何以 *最高壓縮* 的方式將簡報儲存為 PPTX 檔案：

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

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) 方法控制在將簡報儲存為 PPTX 時是否產生縮圖：

- 若設定為 `true`，儲存時會重新整理縮圖。這是預設設定。
- 若設定為 `false`，保留現有縮圖。若簡報沒有縮圖，則不會產生。

以下程式碼將簡報儲存為 PPTX，且不會重新整理其縮圖。

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
此選項有助於縮短以 PPTX 格式儲存簡報所需的時間。
{{% /alert %}}

## **以百分比顯示儲存進度更新**

[IProgressCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/) 介面可透過 [ISaveOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isaveoptions/) 介面及抽象類別 [SaveOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveoptions/) 所公開的 `setProgressCallback` 方法使用。將實作了 IProgressCallback 的類別以 `setProgressCallback` 設定，即可在儲存過程中以百分比接收進度更新。

以下程式碼片段示範如何使用 `IProgressCallback`。

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // 在此使用進度百分比值。
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose 使用其 API 開發了一個 [免費的 PowerPoint 切割工具](https://products.aspose.app/slides/zh-hant/splitter)。此應用程式可將簡報切割成多個檔案，方法是將選取的投影片另存為新的 PPTX 或 PPT 檔案。
{{% /alert %}}

## **常見問題**

**是否支援「快速儲存」（增量儲存）僅寫入變更？**

不支援。每次儲存都會重新產生完整的目標檔案，未提供增量「快速儲存」功能。

**從多執行緒同時儲存相同的 Presentation 實例是否為執行緒安全？**

不安全。`[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)` 實例 **不是執行緒安全**（/slides/zh-hant/java/multithreading/），請僅在單一執行緒中進行儲存。

**儲存時超連結與外部連結檔案會發生什麼情形？**

[超連結](/slides/zh-hant/java/manage-hyperlinks/) 會被保留。外部連結的檔案（例如以相對路徑引用的影片）不會自動複製——必須確保這些路徑在儲存後仍可存取。

**我可以設定/儲存文件中繼資料（作者、標題、公司、日期）嗎？**

可以。支援標準的 [文件屬性](/slides/zh-hant/java/presentation-properties/)，且會在儲存時寫入檔案中。