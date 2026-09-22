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
- 預定義檢視類型
- Strict Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中將 PowerPoint 與 OpenDocument 簡報儲存為檔案或串流，並設定 PPTX 輸出與進度回報。"
---
## **概述**

建立簡報或[開啟已存在的簡報](/slides/zh-hant/java/open-presentation/)之後，使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法寫入結果。Aspose.Slides for Java 可以將簡報儲存為檔案或串流，支援 PowerPoint、OpenDocument、PDF 等多種格式。以下章節說明標準儲存操作以及 PPTX 輸出可用的選項。

## **將簡報儲存為檔案**

要將簡報儲存為檔案，將輸出路徑與一個 [SaveFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/) 值傳入 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法。格式值決定 Aspose.Slides 產生的檔案類型。

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

## **將簡報儲存為原始格式**

有關檔案與串流偵測範例、新建立簡報的行為，以及來源與輸出格式之差異，請參閱 [確定原始簡報格式](/slides/zh-hant/java/detect-presentation-source-format/)。

在批次處理應用程式中，輸入格式可能事先未知。載入檔案後，從 [IPresentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getSourceFormat--) 方法讀取其原始格式。將取得的 [SourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sourceformat/) 值傳給 [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideutil/#toSaveFormat-int-) 以取得相對應的 [SaveFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/) 值，然後使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 寫入已修改的簡報。

以下完整範例處理輸入目錄中的每個檔案，更新其標題，並以載入時的格式儲存到輸出目錄：

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideutil/#toSaveFormat-int-) 會將 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 以及 PowerPoint XML 映射到相對應的簡報儲存格式。它僅映射簡報來源格式；不應用於選擇 PDF、HTML、TIFF 或影像等匯出格式。傳入不支援或無效的 [SourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sourceformat/) 會拋出 [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)。

舊版 PPT、PPS 與 POT 使用相同的二進位容器。如果此類簡報從沒有副檔名的串流載入，PPS 或 POT 檔案可能會被識別為 PPT。若需要保留這些舊版子類型，請另外保留原始檔名或格式中繼資料，並在選擇輸出檔名與格式時使用它們。

## **將簡報儲存為串流**

若不想依賴最終檔案路徑寫入簡報，請將可寫入的串流與一個 [SaveFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/) 值傳入 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) 方法。此方式在需要從 Web 服務返回、存入資料庫或在記憶體中處理輸出時非常有用。

以下範例將新簡報儲存到檔案串流：

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

## **以預先定義的檢視類型儲存簡報**

您可以指定 PowerPoint 開啟已儲存簡報時的預設檢視。於儲存前使用 [ViewProperties.setLastView](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewproperties/#setLastView-int-) 方法，傳入 [ViewType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/viewtype/) 值。

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

## **以 Strict Office Open XML 格式儲存簡報**

若要建立符合 Office Open XML Strict 檔案設定的 PPTX，先建立 [PptxOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxoptions/) 實例，並使用其 [setConformance](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxoptions/#setConformance-int-) 方法，傳入 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/conformance/#Iso29500-2008-Strict)。然後將此選項傳給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法。

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

## **以 Zip64 模式儲存 Office Open XML 格式簡報**

標準 ZIP 壓縮檔對每個項目的壓縮與未壓縮大小、總檔案大小以及項目數量都有上限。因為 PPTX 本身即為 ZIP 壓縮檔，極大型的簡報可能會超過這些限制。ZIP64 延伸可提升相關大小與項目數上限。

使用 [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) 方法控制 Aspose.Slides 是否寫入 ZIP64 延伸：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/zip64mode/#IfNecessary) 只在簡報超出標準 ZIP 限制時使用 ZIP64，為預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/zip64mode/#Never) 停用 ZIP64 延伸。
- [Always](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/zip64mode/#Always) 總是寫入 ZIP64 延伸。

以下範例於輸出簡報時始終啟用 ZIP64 延伸：

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
如果使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/zip64mode/#Never) 且簡報無法在標準 ZIP 限制內容納，儲存作業會拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級儲存 Office Open XML 格式簡報**

對於 PPTX 輸出，您可以使用 [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) 方法在儲存速度與檔案大小之間取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/) 類別提供以下值：

- [None](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#None) 不進行壓縮。
- [Level1](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level1) 壓縮最快，產生最大的壓縮檔。
- [Level2](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level2) 至 [Level5](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level5) 逐步偏好較小的輸出而犧牲儲存速度。
- [Level6](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level6) 在儲存速度與檔案大小間取得平衡，為預設等級。
- [Level7](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level7) 與 [Level8](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level8) 更偏好較小的輸出。
- [Level9](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compressionlevel/#Level9) 提供最強的壓縮，需耗費最多處理時間。

以下範例在無壓縮的情況下儲存簡報：

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

當簡報以 PPTX 格式儲存時，[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) 方法可控制文件縮圖：

- `true` 在儲存過程中重新產生縮圖，為預設值。
- `false` 保留現有縮圖。如果簡報本身沒有縮圖，Aspose.Slides 不會產生新縮圖。

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
停用縮圖重新整理可以縮短 PPTX 檔案的儲存時間。
{{% /alert %}}

## **以百分比方式接收儲存進度更新**

若要監控儲存作業，請實作 [IProgressCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/) 介面，並將實作傳入 [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) 方法。Aspose.Slides 會在匯出期間呼叫 [IProgressCallback.reporting](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprogresscallback/#reporting-double-) 方法，傳回進度值。

以下範例在主控台上報告 PDF 匯出的進度：

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
Aspose 提供免費的 [PowerPoint Splitter](https://products.aspose.app/slides/zh-hant/splitter) 應用程式，內部使用 Aspose.Slides API。它可將簡報中的選定投影片另存為獨立的 PPT 或 PPTX 檔案。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援增量或「快速儲存」？**

不支援。每次儲存都會寫入完整的輸出檔，而不是僅更新變更的部分。

**多執行緒可以同時儲存相同的 Presentation 實例嗎？**

不可以。[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 實例 **非執行緒安全**，請一次只由單一執行緒存取與儲存。

**儲存簡報時，超連結與外部連結檔案會發生什麼事？**

[Hyperlinks](/slides/zh-hant/java/manage-hyperlinks/) 仍會保留在簡報中。Aspose.Slides 不會複製外部連結的檔案，因此儲存後的簡報仍須能存取這些位置。

**我可以儲存文件的中繼資料（例如作者、標題、公司或建立日期）嗎？**

可以。於儲存前設定相應的[文件屬性](/slides/zh-hant/java/presentation-properties/)，Aspose.Slides 會將它們寫入輸出檔。