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
- 預定檢視類型
- 嚴格 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 將 PowerPoint 與 OpenDocument 簡報儲存至檔案或串流，並配置 PPTX 輸出與進度報告。"
---
## **概觀**

在建立簡報或[開啟現有簡報](/slides/zh-hant/androidjava/open-presentation/)之後，使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法寫入結果。Aspose.Slides for Android via Java 能將簡報儲存為檔案或串流，支援 PowerPoint、OpenDocument、PDF 以及其他格式。以下各節說明標準的儲存操作以及 PPTX 輸出可用的選項。

## **將簡報儲存為檔案**

要將簡報儲存為檔案，請將輸出路徑與[SaveFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/)值傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法。格式值決定 Aspose.Slides 產生的檔案類型。

以下範例建立簡報並將其儲存為 PPTX 檔案：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // 在此新增或修改簡報內容。

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以原始格式儲存簡報**

有關檔案與串流偵測範例、新建立簡報的行為，以及來源與輸出格式之區別，請參閱[確定原始簡報格式](/slides/zh-hant/androidjava/detect-presentation-source-format/)。

在批次處理應用程式中，輸入格式可能事先未知。載入檔案後，透過[IPresentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) 方法讀取其原始格式。將取得的[SourceFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sourceformat/)值傳遞給[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) 以取得對應的[SaveFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/)值，然後使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 寫入修改後的簡報。

以下完整範例處理輸入目錄中的每個檔案，更新其標題，並以載入時的格式儲存至輸出目錄：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) 將 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 以及 PowerPoint XML 映射為相對應的簡報儲存格式。它僅映射簡報來源格式；並非用於選取 PDF、HTML、TIFF 或圖像等匯出格式。傳遞不支援或無效的[SourceFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sourceformat/) 值會導致[IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException)。

舊版的 PPT、PPS 與 POT 檔案使用相同的二進位容器。若此類簡報從未帶副檔名的串流載入，PPS 或 POT 檔案可能會被辨識為 PPT。如果需要保留這些舊版子類型，請另行保留原始檔名或格式中繼資料，並在選擇輸出檔名與格式時使用它。

## **將簡報儲存為串流**

若不依賴最終檔案路徑寫入簡報，請將可寫入的串流與[SaveFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/)值傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) 方法。此方式在需要將輸出從 Web 服務回傳、存入資料庫或於記憶體中處理時相當有用。

以下範例將新簡報儲存至檔案串流：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **以預定檢視類型儲存簡報**

您可以指定 PowerPoint 開啟已儲存簡報時的預設檢視。於儲存前，使用[ViewProperties.setLastView](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) 方法，搭配[ViewType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/viewtype/)值。

以下範例將 Slide Master 檢視設定為初始檢視：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以嚴格 Office Open XML 格式儲存簡報**

若要建立符合 Office Open XML 嚴格規範的 PPTX 檔案，請建立 [PptxOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxoptions/) 例項，並使用其 [setConformance](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) 方法，傳入 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict)。然後將此選項傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法。

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **以 Zip64 模式在 Office Open XML 格式儲存簡報**

標準 ZIP 壓縮檔對每個項目的壓縮與未壓縮大小、整體檔案大小以及項目數量皆有限制。由於 PPTX 檔案本質上是 ZIP 壓縮檔，極大型的簡報可能超出這些限制。ZIP64 擴充功能可提升相關的大小與項目數限制。

使用 [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) 方法控制 Aspose.Slides 是否寫入 ZIP64 擴充功能：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zip64mode/#IfNecessary) 只在簡報超過標準 ZIP 限制時使用 ZIP64。這是預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zip64mode/#Never) 停用 ZIP64 擴充功能。
- [Always](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zip64mode/#Always) 總是寫入 ZIP64 擴充功能。

以下範例對輸出簡報始終啟用 ZIP64 擴充功能：

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
如果使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/zip64mode/#Never) 且簡報無法符合標準 ZIP 限制，儲存操作將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級儲存 Office Open XML 格式簡報**

對於 PPTX 輸出，您可使用 [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) 方法在儲存速度與檔案大小之間取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/) 類別提供以下值：

- [None](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#None) 不壓縮資料。
- [Level1](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level1) 提供最快的壓縮速度，但產生的壓縮檔最大。
- [Level2](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level2) 逐步偏好較小的輸出而犧牲儲存速度。
- [Level3](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level3) 逐步偏好較小的輸出而犧牲儲存速度。
- [Level4](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level4) 逐步偏好較小的輸出而犧牲儲存速度。
- [Level5](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level5) 逐步偏好較小的輸出而犧牲儲存速度。
- [Level6](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level6) 在儲存速度與檔案大小之間取得平衡。這是預設等級。
- [Level7](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level7) 更進一步偏好較小的輸出而犧牲儲存速度。
- [Level8](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level8) 更進一步偏好較小的輸出而犧牲儲存速度。
- [Level9](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compressionlevel/#Level9) 提供最強的壓縮，且需要最長的處理時間。

以下範例將簡報儲存為不壓縮：

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

以下範例使用最高壓縮等級：

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **儲存簡報時不重新整理縮圖**

將簡報儲存為 PPTX 時，[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) 方法控制文件縮圖：

- `true` 在儲存時重新產生縮圖。這是預設值。
- `false` 保留現有縮圖。如果簡報沒有縮圖，Aspose.Slides 不會產生縮圖。

以下範例在儲存時不重新整理縮圖：

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
停用縮圖重新整理可減少儲存 PPTX 檔案所需的時間。
{{% /alert %}}

## **以百分比顯示儲存進度更新**

若要監控儲存操作，請實作 [IProgressCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprogresscallback/) 介面，並將實作傳遞給[ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) 方法。Aspose.Slides 隨後會在匯出過程中呼叫[IProgressCallback.reporting](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) 方法，提供進度值。

以下範例將 PDF 匯出的進度回報至主控台：

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose 提供免費的[PowerPoint Splitter](https://products.aspose.app/slides/zh-hant/splitter)，此工具以 Aspose.Slides API 建置，可將簡報中選取的投影片另存為獨立的 PPT 或 PPTX 檔案。
{{% /alert %}}

## **FAQ**

**Aspose.Slides 是否支援增量或「快速儲存」？**

否。每次儲存操作都會寫入完整的輸出檔案，而不是僅更新變更的部分。

**多執行緒能同時儲存同一個 Presentation 例項嗎？**

否。[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 例項**不具備執行緒安全性**（/slides/zh-hant/androidjava/multithreading/）。每次只能由單一執行緒存取與儲存該例項。

**儲存簡報時，超連結與外部連結的檔案會怎樣？**

[超連結](/slides/zh-hant/androidjava/manage-hyperlinks/) 會保留在簡報中。Aspose.Slides 不會複製外部連結的檔案，因此已儲存的簡報仍必須能存取這些位置。

**我可以儲存文件的中繼資料，例如作者、標題、公司與建立日期嗎？**

可以。於儲存之前設定相應的[文件屬性](/slides/zh-hant/androidjava/presentation-properties/)，Aspose.Slides 會將其寫入輸出檔案。