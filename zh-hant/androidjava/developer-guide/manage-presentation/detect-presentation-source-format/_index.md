---
title: 在 Android 上判定原始簡報格式
linktitle: 來源格式
type: docs
weight: 35
url: /zh-hant/androidjava/detect-presentation-source-format/
keywords:
- 來源格式
- 偵測簡報格式
- PowerPoint
- OpenDocument
- 簡報
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides for Android 透過 Java 讀取已載入簡報的原始格式、比較偵測 API，並處理檔案、串流與舊版格式。"
---
## **概述**

載入簡報後，呼叫 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSourceFormat--) 方法以判斷其原始格式。該方法也可透過 [IPresentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) 取得。當後續處理依賴於目前實例載入的格式時，請使用它。

來源格式與為輸出檔案所選擇的 [SaveFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/) 不同。將檔案儲存為其他格式不會改變現有實例的來源格式。

範例採用 Java 與檔案路徑。在 Android 上，請將示範路徑替換為應用程式可存取的儲存路徑，例如應用程式的內部檔案目錄。

## **讀取檔案的來源格式**

此範例需要一個現有的 `sample.pptx` 檔案。它載入檔案並使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSourceFormat--) 來選擇應用程式的處理原則，而非依檔名。變更輸入路徑即可測試其他格式。範例會印出選取的原則；請將訊息替換為您的應用程式邏輯。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **辨識支援的值**

[SourceFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sourceformat/) 類別定義了區分以下簡報格式的整數常數。下列副檔名為慣用副檔名，並非重建原始檔名。

| SourceFormat 值 | 副檔名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 簡報 |
| `Pptx` | `.pptx` | Office Open XML 簡報 |
| `Pptm` | `.pptm` | 支援巨集的 Office Open XML 簡報 |
| `Pps` | `.pps` | PowerPoint 97–2003 投影片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 投影片放映 |
| `Ppsm` | `.ppsm` | 支援巨集的 Office Open XML 投影片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 範本 |
| `Potx` | `.potx` | Office Open XML 範本 |
| `Potm` | `.potm` | 支援巨集的 Office Open XML 範本 |
| `Odp` | `.odp` | OpenDocument 簡報 |
| `Otp` | `.otp` | OpenDocument 簡報範本 |
| `Fodp` | `.fodp` | Flat XML ODF 簡報 |
| `Xml` | `.xml` | PowerPoint XML 簡報 |

## **讀取串流的來源格式**

此範例需要一個現有的 `sample.pps` 檔案。將其位元組讀入記憶體串流，模擬未帶檔名的輸入，例如資料庫值或上傳的位元組陣列。[Presentation] 建構函式僅接受串流。

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT、PPS 與 POT 使用相同的底層二進位格式。以檔案路徑載入時，副檔名可協助區分投影片放映或範本。若無檔名，舊版的 PPS 與 POT 內容可能會被報告為 `SourceFormat.Ppt`；上述 PPS 範例會印出 `SourceFormat.Ppt` 的整數值。

若您的應用程式必須保留此區別，請另行保存原始檔名或子類型中繼資料。副檔名對於這些舊版子類型是一個有用的提示，但不應成為識別任意簡報內容的唯一依據。

## **比較載入前後的偵測**

當需要在**載入完整簡報物件模型**之前檢查檔案時，請使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 與 [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--)。若實例已存在，請使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSourceFormat--)。

此範例需要 `sample.pptx`，分別印出 `LoadFormat.Pptx` 與 `SourceFormat.Pptx` 的整數值。於正式環境中，請依處理階段選擇適當的 API；已載入的簡報不需要再次檢查以取得來源格式。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

結果使用來自不同類別的常數：[LoadFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadformat/) 與 [SourceFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sourceformat/)。請勿比較它們的數值，亦不要假設每種格式具有相同的偵測結果。PowerPoint XML 於載入前可能報告為 `LoadFormat.Unknown`，載入後則為 `SourceFormat.Xml`。

## **保持來源與輸出格式分離**

此範例需要 `sample.pptx`，並寫入 `converted.odp`。它在儲存原始實例前後皆印出 `SourceFormat.Pptx` 的整數值。只有從 ODP 輸出載入的新實例會報告 `Odp`。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

使用 `new Presentation()` 從頭建立的簡報會報告 `SourceFormat.Pptx`。它沒有輸入檔案：這是新建立實例的預設值，並不代表已載入 PPTX 檔案。若此區別重要，請自行追蹤您的應用程式是建立還是載入了實例。

## **將來源格式對映至副檔名**

以下範例需要 `sample.pptx`。它將每個目前支援的 [SourceFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sourceformat/) 值對映至慣用副檔名，且不解析輸入檔名。回退機制避免對未辨識的值默默指派副檔名。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

此對映不會轉換檔案或恢復在串流載入期間遺失的舊版 PPS/POT 子類型。實際儲存時，請明確選取 [SaveFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/)，或使用 [Save Presentations in Their Original Format](/slides/zh-hant/androidjava/save-presentation/#save-presentations-in-their-original-format) 中示範的轉換方式。

## **透過儲存與重新開啟驗證格式**

此獨立範例會建立一個簡報並在工作目錄寫入三個檔案，若同名檔案會被覆寫。它會以路徑以及記憶體串流兩種方式重新開啟每個輸出。對於 PPTX 與 ODP，兩種方式皆回報已儲存的格式。對於 PPS，透過路徑載入會回報 `Pps`，而以無檔名的相同位元組載入則回報 `Ppt`。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

以下表格總結了具有相同副檔名之簡報的來源格式辨識。名稱代表常數；Java 範例會印出其整數值：

| 已儲存格式 | 從檔案路徑取得的 SourceFormat | 從無檔名串流取得的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` | 與檔案路徑相同 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` | 與檔案路徑相同 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` | 與檔案路徑相同 |
| ODP, OTP | `Odp`, `Otp` | 與檔案路徑相同 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

對於無檔名串流，PPS/POT 內容會被辨識為 `Ppt`。此表說明格式辨識結果，並非轉換過程中保留每項簡報功能的情形。

## **常見問題**

**將簡報從 PPTX 儲存為 ODP 會改變其來源格式嗎？**

不會。現有的實例仍回報 `Pptx`。從已儲存的 ODP 檔案載入的實例則回報 `Odp`。

**串流能否永遠區分舊版簡報、投影片放映與範本嗎？**

不能。PPT、PPS 與 POT 共享相同的二進位格式。若需要此區別，請另行保留檔名或子類型中繼資料。

**如果簡報已載入，我該使用哪個 API？**

請參考 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSourceFormat--)。在載入之前檢查檔案時，使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)。