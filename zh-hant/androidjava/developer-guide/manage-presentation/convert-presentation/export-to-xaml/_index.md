---
title: 在 Android 上將簡報匯出為 XAML
linktitle: 簡報至 XAML
type: docs
weight: 30
url: /zh-hant/androidjava/export-to-xaml/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出簡報
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換簡報
- PowerPoint 轉 XAML
- OpenDocument 轉 XAML
- 簡報轉 XAML
- PPT 轉 XAML
- PPTX 轉 XAML
- ODP 轉 XAML
- 將 PPT 儲存為 XAML
- 將 PPTX 儲存為 XAML
- 將 ODP 儲存為 XAML
- 匯出 PPT 為 XAML
- 匯出 PPTX 為 XAML
- 匯出 ODP 為 XAML
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中將 PowerPoint 與 OpenDocument 投影片轉換為 XAML——快速、無需 Office 的解決方案，並保留版面配置完整性。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Android 透過 Java 將 PowerPoint 簡報匯出為 XAML。內容包括 XAML 的簡要介紹、展示如何使用預設設定將簡報儲存為 XAML，以及說明如何透過[XamlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/)自訂匯出，包含匯出隱藏投影片。本文亦回答一些常見問題，涵蓋備援字型、XAML 堆疊相容性與隱藏投影片匯出行為。

## **關於 XAML**

XAML 是一種基於 XML 的標記語言，用於描述 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）以及 Xamarin.Forms 等框架中的使用者介面。

您可以在視覺化設計師中使用 XAML 檔案，或直接編寫與編輯標記。

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

預設情況下，匯出的投影片會儲存在處理程序目前工作目錄下的 `pres` 子資料夾中。該資料夾會自動建立，所有必要的影像也會儲存在其中。

輸出資料夾名稱取自來源檔案名稱（不含副檔名）。例如 `pres.pptx`，輸出檔案會命名為 `pres/Slide_1.xaml`、`pres/Slide_2.xaml`，依此類推。即使您傳入簡報的絕對路徑，輸出資料夾仍會相對於目前工作目錄建立，而不是與輸入檔案同層。

在 Android 上，請使用應用程式可存取的輸入檔案。目前工作目錄可能無法寫入；請使用自訂的輸出 saver，將匯出保留在記憶體中或寫入應用程式儲存空間，如下所示。產生的 WPF XAML 旨在供相容的消費者使用，並非 Android 版面配置資源。

## **使用自訂選項將簡報匯出為 XAML**

使用[IXamlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ixamloptions/)介面來控制 Aspose.Slides 如何將簡報匯出為 XAML。

若要將輸出儲存到自訂位置，請實作[IXamlOutputSaver](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ixamloutputsaver/)並將您的實作實例傳遞給[XamlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/)的[setOutputSaver](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-)方法。

若要在 XAML 輸出中包含隱藏投影片，請以`true`呼叫[setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-)，如下 Java 範例所示：

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

## **擷取所有產生的 XAML 工件**

XAML 匯出可能會為每個匯出的投影片產生一個 XAML 文件，外加獨立的影像與支援資源。將自訂的[IXamlOutputSaver](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ixamloutputsaver/)指派給[XamlOptions.setOutputSaver](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-)以接收這些工件，而不是使用預設的檔案系統 saver。使用接受 XAML 選項的特定[Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)重載開始匯出。

### **了解回呼生命週期**

匯出器會為每個產生的工件分別呼叫[IXamlOutputSaver.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-)：

- `path` 用於識別工件，可能包含相對目錄。請保留此資訊，因為 XAML 可能使用相對路徑引用資源。
- `data` 包含工件的位元組。影像與其他二進位資源不應被解碼為文字。
- Saver 必須在返回之前保留或持久化資料。範例會將每個位元組陣列複製到應用程式自有的記憶體中。
- 僅在簡報儲存操作返回且所有回呼皆成功完成時，才視匯出為成功。不要忽略儲存錯誤或啟動未觀察的背景寫入。如果持久化在之後發生，僅在該步驟成功後才報告整體成功。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) 亦適用於自訂 saver。預設設定 `false` 會排除隱藏投影片的 XAML 文件。傳入 `true` 則會包含它們以及匯出所需的任何資源。資源數量取決於簡報本身；不要假設每張投影片僅有一次回呼或回呼順序固定。

### **匯出至記憶體並檢查工件**

此完整範例載入 `pres.pptx`，將每個工件收集於[Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html)中，並列印其名稱、類型與位元組計數。它會完整保留提供的名稱。若出現重複名稱，會將集合標記為無效，而非靜默覆寫工件。範例在使用結果前會檢查此情況。

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

    // 僅在需要文字檢查時才解碼 XAML。
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

擴充檢查對於檢查很有幫助；保留所有工件，包括不熟悉的資源類型。儲存或傳輸時請保持位元組不變。僅在需要文字處理的 XAML 時，才使用帶 UTF-8 的[String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-)。

### **將收集的工件打包為 ZIP 壓縮檔**

此獨立範例收集匯出結果，驗證名稱，並將原始位元組寫入 ZIP 壓縮檔。請將`/path/to/app/files`替換為 Android Context的[getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir)方法回傳的路徑。唯一的壓縮檔名稱可區分同時的匯出工作。ZIP 條目使用正斜線並保留相對目錄。若名稱不安全或正規化後發生衝突，將在寫入前拒絕整個套件。

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
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

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // 在報告成功之前，透過關閉操作已完成 ZIP 目錄的最終化。
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

範例使用[ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html)寫入單一本機壓縮檔；匯出器本身不會寫入分散的 XAML 或影像檔。若使用遠端儲存，請將寫入壓縮檔的階段改為上傳收集的位元組陣列。可使用匯出工作識別碼加上完整相對工件名稱作為 Blob 金鑰，或將工作識別碼、相對名稱與二進位資料存於資料庫欄位。僅在所有上傳完成或資料庫交易提交後才發布工作。若持久化失敗，請清理部分輸出。

對於大型簡報，自訂 saver 可以直接將每個工件持久化至應用程式儲存空間，以避免在記憶體中保留整個匯出的額外副本。從匯出器的角度來看，保持每個回呼為同步：僅在目標接受位元組後返回，並允許失敗傳遞給呼叫端。

### **保留資源名稱並驗證參考**

- 當目的地需要時正規化路徑分隔符號，但保留相對目錄。除非所有產生的名稱已知唯一且資源參考仍有效，否則不要僅使用[File.getName](https://developer.android.com/reference/java/io/File#getName)。
- 套用目的地特定的名稱驗證。寫入分散檔案時，拒絕根路徑與跳階段，使用[File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath)解析目的地，並驗證其仍位於預期的匯出目錄之下，包含在包含性檢查中的目錄分隔符號。使用沒有符號連結的應用程式控制目錄，以免寫入被重新導向。
- 為每個匯出工作使用獨立的 saver 與儲存命名空間。於分隔符正規化後，並依目的地的大小寫敏感規則偵測衝突。
- 在發布之前，將每個 XAML 文件以 XML 解析，檢查其基於檔案的資源參考，例如影像的`Source`或`ImageSource`屬性。將每個相對 URI 以所在 XAML 工件的目錄為基礎解析，正規化得到的儲存名稱，並確認對應的 map 鍵、ZIP 條目或儲存物件是否存在。將外部 URI 與 XAML 標記表達式與相對檔名分開處理。

例如，若`pres/Slide_1.xaml`參考`images/image1.png`，則儲存的資源必須以`pres/images/image1.png`的形式存在。僅保留`image1.png`會破壞此關係。對於物件儲存，請在工作前綴下保持相同的目錄結構，並讓這些資源 URL 可供 XAML 消費者存取。重新開啟完成的 ZIP，驗證條目名稱與資源位元組，並在目標 XAML 環境中載入代表性投影片，以確認影像正確解析。

## **常見問題**

**如果原始字型在機器上不可用，如何確保字型的可預測性？**

在[XamlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/)中呼叫[setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) — 當原始字型缺失時，匯出會使用此字型作為備援字型。但此並不保證產生的 XAML 會引用備援字型，或該字型在目標機器上可用。請確保 XAML 所參考的字型在顯示環境中可取得。

**匯出的 XAML 僅供 WPF 使用，還是也能用於其他 XAML 堆疊？**

Aspose.Slides 透過其公共 API 匯出 WPF XAML。與其他 XAML 堆疊（例如 UWP 與 Xamarin.Forms）的相容性未得到保證。請在目標環境中測試產生的標記。

**是否支援隱藏投影片，且如何避免預設匯出它們？**

預設情況下，隱藏投影片不會被包含。您可以透過[XamlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/)中的[setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-)控制此行為——若不需要匯出隱藏投影片，請保持其停用。