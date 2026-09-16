---
title: 在 Java 中將簡報匯出為 XAML
linktitle: 簡報至 XAML
type: docs
weight: 30
url: /zh-hant/java/export-to-xaml/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出簡報
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換簡報
- PowerPoint 轉 XAML
- OpenDocument 轉 XAML
- 簡報 轉 XAML
- PPT 轉 XAML
- PPTX 轉 XAML
- ODP 轉 XAML
- 將 PPT 儲存為 XAML
- 將 PPTX 儲存為 XAML
- 將 ODP 儲存為 XAML
- 匯出 PPT 為 XAML
- 匯出 PPTX 為 XAML
- 匯出 ODP 為 XAML
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中將 PowerPoint 與 OpenDocument 投影片轉換為 XAML──快速、無需 Office 的解決方案，保持版面完整。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。內容包括 XAML 的簡要介紹、示範如何使用預設設定將簡報儲存為 XAML，以及如何透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/) 自訂匯出行為（包括匯出隱藏投影片）。此外，本文亦回答有關備用字型、XAML 堆疊相容性與隱藏投影片匯出行為的常見問題。

## **關於 XAML**

XAML 是一種基於 XML 的標記語言，用於描述 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）與 Xamarin.Forms 等框架中的使用者介面。

您可以在視覺設計師中使用 XAML 檔案，或直接編寫與編輯標記內容。

## **使用預設選項將簡報匯出為 XAML**

以下 Java 範例展示如何使用預設設定將簡報匯出為 XAML：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

預設情況下，匯出的投影片會儲存在程式執行目錄的 `pres` 子資料夾中，此路徑是以空字串傳給 [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-) 解析後取得。系統會自動建立該資料夾，所需的影像亦會儲存在同一位置。

輸出資料夾名稱取自來源檔案的檔名（不含副檔名）。以 `pres.pptx` 為例，輸出檔案會命名為 `pres/Slide_1.xaml`、`pres/Slide_2.xaml`，以此類推。即使您傳入絕對路徑作為輸入簡報，輸出資料夾仍會相對於目前工作目錄建立，而非與輸入檔案同階層。

## **使用自訂選項將簡報匯出為 XAML**

使用 [IXamlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloptions/) 介面來控制 Aspose.Slides 如何將簡報匯出為 XAML。

若要將輸出儲存至自訂位置，請實作 [IXamlOutputSaver](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloutputsaver/) 並將您的實例傳遞給 [XamlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/) 的 [setOutputSaver](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) 方法。

若要在 XAML 輸出中包含隱藏投影片，請如以下 Java 範例所示，以 `true` 呼叫 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-)：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **擷取所有產生的 XAML 產物**

XAML 匯出可能會為每張匯出的投影片產生一個 XAML 文件，外加獨立的影像與相關資源。將自訂的 [IXamlOutputSaver](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloutputsaver/) 指派給 [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) 後，即可接收這些產物，而非使用預設的檔案系統儲存器。使用接受 XAML 選項的 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 版本啟動匯出。

### **了解回呼生命週期**

匯出器會針對每個產生的產物分別呼叫 [IXamlOutputSaver.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-)：

- `path` 用來識別產物，可能包含相對目錄。請保留此資訊，因為 XAML 可能會以相對路徑參照資源。
- `data` 包含產物的位元組。影像與其他二進位資源不應以文字方式解碼。
- 儲存器必須在回傳前保留或持久化資料。範例會將每個位元組陣列複製到應用程式擁有的記憶體中。
- 只有當簡報的儲存操作回傳且所有回呼皆成功完成時，才視為匯出成功。請勿吞掉儲存錯誤或啟動未觀察的背景寫入。若持久化在之後發生，僅在該步驟也成功後才回報整體成功。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) 亦適用於自訂儲存器。預設值 `false` 會排除隱藏投影片的 XAML 文件。傳入 `true` 則會包含它們以及匯出所需的任何資源。資源數量取決於簡報本身，請勿假設每張投影片只有一個回呼，或回呼順序固定。

### **匯出至記憶體並檢查產物**

以下完整範例載入 `pres.pptx`，將每個產物收集到一個 [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html)，並列印其名稱、類型與位元組數。名稱會完整保留。若出現重複名稱，集合會被視為無效，而不是靜默覆寫。範例在使用結果前會先檢查此情況。

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // 僅解碼 XAML，且僅在需要文字檢查時執行。
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

檢查副檔名對於檢視很有幫助；請保留所有產物，包括不熟悉的資源類型。儲存或傳輸時，請保持位元組不變。僅在需要文字處理的 XAML 時，才使用 UTF-8 的 [String 建構函式](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-)。

### **將收集的產物打包成 ZIP 壓縮檔**

此獨立範例會收集匯出結果、驗證名稱，並將原始位元組寫入 ZIP 壓縮檔。唯一的壓縮檔名稱可區分同時執行的匯出工作。ZIP 條目使用正斜線並保留相對目錄。若名稱在正規化後衝突或不安全，則在寫入前整體拒絕打包。

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // ZIP 目錄已在關閉時完成，之後才報告成功。
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

範例使用 [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) 寫入單一本地壓縮檔；匯出器本身不會寫入散落的 XAML 或影像檔案。若需遠端儲存，請將寫入壓縮檔的階段改為上傳收集的位元組陣列。可使用匯出工作識別碼加上完整相對產物名稱作為 Blob 鍵，或在資料庫的欄位中儲存工作識別碼、相對名稱與二進位資料。僅在所有上傳完成或資料庫交易提交後才發布工作。若持久化失敗，請清除部分輸出。

對於大型簡報，自訂儲存器可直接將每個產物持久化至應用程式儲存，以免在記憶體中保留整個匯出的額外副本。從匯出器的觀點來看，請讓每個回呼保持同步：僅在目的地接受位元組後才返回，並讓失敗傳遞至呼叫端。

### **保留資源名稱並驗證參考**

- 正規化路徑分隔符號以符合目的地需求，但仍保留相對目錄。除非能保證每個產生的名稱皆唯一且資源參考仍然有效，否則不要僅使用 [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--)。
- 依目的地套用名稱驗證。寫入散落檔案時，拒絕根路徑與目錄遍歷段落，使用 [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--) 解析目的地，並確認其仍位於預期的匯出目錄之下（包含目錄分隔符的包含檢查）。使用不含可能重新導向寫入的符號連結的受控目錄。
- 為每個匯出工作使用獨立的儲存器與命名空間。依照分隔符正規化後以及目的地的大小寫敏感規則偵測衝突。
- 發布前，將每個 XAML 文件作為 XML 解析，檢查其檔案型資源參考，如影像的 `Source` 或 `ImageSource` 屬性。將每個相對 URI 以包含該 XAML 產物的目錄為基礎解析，正規化得到的儲存名稱，並確認對應的 map 鍵、ZIP 條目或已儲存的物件是否存在。將外部 URI 與 XAML 標記表達式與相對檔名分開處理。

例如，若 `pres/Slide_1.xaml` 參考 `images/image1.png`，則必須以 `pres/images/image1.png` 的路徑儲存該資源。僅保留 `image1.png` 會導致關聯失效。若使用物件儲存，請在工作前綴下保留相同的層次結構，並讓這些資源 URL 可供 XAML 消費者存取。重新打開完成的 ZIP 檢查條目名稱與資源位元組，並在目標 XAML 環境中載入代表性投影片，以確認影像正確解析。

## **常見問題**

**如果原始字型在機器上不可用，如何確保字型可預測？**  
在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/) 中呼叫 [setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-)，此字型在匯出時會作為備用字型使用。這並不保證產生的 XAML 會引用備用字型，或目標機器上一定有該字型。請確保 XAML 所參考的字型在顯示環境中可用。

**匯出的 XAML 只適用於 WPF，還是也能用於其他 XAML 堆疊？**  
Aspose.Slides 透過其公用 API 匯出 WPF XAML。對於其他 XAML 堆疊（如 UWP 與 Xamarin.Forms）的相容性並未保證。請在目標環境中測試生成的標記。

**是否支援隱藏投影片，且預設如何防止匯出它們？**  
預設情況下不會包含隱藏投影片。您可以透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/) 的 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) 來控制此行為——若不需要匯出隱藏投影片，請保留此設定為停用。