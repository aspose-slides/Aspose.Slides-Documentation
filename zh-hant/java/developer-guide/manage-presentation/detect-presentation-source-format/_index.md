---
title: 在 Java 中判斷原始簡報格式
linktitle: 來源格式
type: docs
weight: 35
url: /zh-hant/java/detect-presentation-source-format/
keywords:
- 來源格式
- 偵測簡報格式
- PowerPoint
- OpenDocument
- 簡報
- PPT
- PPTX
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides for Java 讀取已載入簡報的原始格式，比較偵測 API，並處理檔案、串流與舊版格式。"
---
## **概觀**

載入簡報後，呼叫 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSourceFormat--) 方法以判斷其原始格式。此方法也可透過 [IPresentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getSourceFormat--) 取得。當後續處理取決於目前實例載入的格式時，請使用它。

來源格式與用於輸出檔案的 [SaveFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/) 不同。將檔案另存為其他格式不會變更現有實例的來源格式。

## **讀取檔案的來源格式**

此範例需要一個現有的 `sample.pptx` 檔案。它會載入該檔案，並使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSourceFormat--) 來選擇應用程式的處理策略，而非依賴檔名。將輸入路徑改成其他格式即可測試。範例會印出選取的策略；您可以將訊息取代為自己的應用程式邏輯。

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

## **認識支援的值**

[SourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sourceformat/) 類別定義了整數常數，以區分以下簡報格式。下表的副檔名僅為慣用表示，並非原始檔名的重建。

| SourceFormat 值 | 副檔名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 簡報 |
| `Pptx` | `.pptx` | Office Open XML 簡報 |
| `Pptm` | `.pptm` | 含巨集的 Office Open XML 簡報 |
| `Pps` | `.pps` | PowerPoint 97–2003 投影片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 投影片放映 |
| `Ppsm` | `.ppsm` | 含巨集的 Office Open XML 投影片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 範本 |
| `Potx` | `.potx` | Office Open XML 範本 |
| `Potm` | `.potm` | 含巨集的 Office Open XML 範本 |
| `Odp` | `.odp` | OpenDocument 簡報 |
| `Otp` | `.otp` | OpenDocument 簡報範本 |
| `Fodp` | `.fodp` | 平面 XML ODF 簡報 |
| `Xml` | `.xml` | PowerPoint XML 簡報 |

## **讀取串流的來源格式**

此範例需要一個現有的 `sample.pps` 檔案。將其位元組讀入記憶體串流，可模擬沒有檔名的輸入（例如資料庫值或上傳的位元組陣列）。[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 建構式只接受串流。

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
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

PPT、PPS 與 POT 使用相同的底層二進位格式。以檔案路徑載入時，副檔名可協助辨識投影片放映或範本。若沒有檔名，舊版的 PPS 與 POT 內容可能會被報告為 `SourceFormat.Ppt`；上面的 PPS 範例會印出 `SourceFormat.Ppt` 的整數值。

如果您的應用程式必須保留此區別，請另行保留原始檔名或子類型中繼資料。副檔名對於這些舊版子類型是一個有用的提示，但不應成為辨識任意簡報內容的唯一依據。

## **比較載入前後的偵測結果**

當您需要在完整載入簡報物件模型之前檢查檔案時，請使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 搭配 [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--)。若實例已存在，則使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSourceFormat--)。

此範例需要 `sample.pptx`，會分別印出 `LoadFormat.Pptx` 與 `SourceFormat.Pptx` 的整數值。實務上請依處理階段選擇適當的 API；已載入的簡報不必再次檢查來取得來源格式。

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

結果使用不同類別的常數：[LoadFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadformat/) 與 [SourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sourceformat/)。請勿比較它們的數值或假設每種格式的偵測結果完全相同。PowerPoint XML 在載入前可能被報告為 `LoadFormat.Unknown`，載入後則為 `SourceFormat.Xml`。

## **保持來源與輸出格式分開**

此範例需要 `sample.pptx`，並寫入 `converted.odp`。它會在儲存原始實例前後皆印出 `SourceFormat.Pptx` 的整數值。只有從 ODP 輸出重新載入的新實例會報告 `Odp`。

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

使用 `new Presentation()` 從頭建立的簡報會報告 `SourceFormat.Pptx`。此時沒有輸入檔案：這是新建立實例的預設值，並不代表實際載入了 PPTX 檔案。如果您的應用程式需要區分「建立」或「載入」的情況，請自行追蹤此資訊。

## **將來源格式對映至副檔名**

以下範例需要 `sample.pptx`。它會將每個目前支援的 [SourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sourceformat/) 值對映到慣用的副檔名，且不必解析輸入檔名。若遇到未辨識的值，將回傳備援值，避免默默指派副檔名。

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

此對映不會轉換檔案或復原在串流載入期間遺失的舊版 PPS/POT 子類型。實際儲存時，請明確選擇 [SaveFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/)，或參考 [Save Presentations in Their Original Format](/slides/zh-hant/java/save-presentation/#save-presentations-in-their-original-format) 中的轉換示例。

## **透過儲存與重新開啟驗證格式**

此自包含範例會建立一個簡報，並在工作目錄寫入三個檔案，若同名檔案已存在會覆寫。它會分別以路徑和記憶體串流重新開啟每個輸出。對於 PPTX 與 ODP，兩條路徑都會回報已儲存的格式。對於 PPS，使用路徑載入會回報 `Pps`，而使用沒有檔名的相同位元組則回報 `Ppt`。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
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

下表彙總了具有相同副檔名的簡報之來源格式辨識。名稱代表常數；Java 範例會印出它們的整數值：

| 已儲存格式 | 依檔案路徑的 SourceFormat | 依無檔名串流的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX、PPTM | `Pptx`、`Pptm` 分別 | 同檔案路徑 |
| PPS | `Pps` | `Ppt` |
| PPSX、PPSM | `Ppsx`、`Ppsm` 分別 | 同檔案路徑 |
| POT | `Pot` | `Ppt` |
| POTX、POTM | `Potx`、`Potm` 分別 | 同檔案路徑 |
| ODP、OTP | `Odp`、`Otp` 分別 | 同檔案路徑 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT 內容在無檔名串流中會被辨識為 `Ppt`。此表格描述格式辨識結果，並非在轉換過程中保留每項簡報功能的保證。

## **FAQ**

**將簡報儲存為 ODP 會改變從 PPTX 載入的簡報的來源格式嗎？**

不會。現有實例仍會回報 `Pptx`。從已儲存的 ODP 檔案載入的實例則會回報 `Odp`。

**串流是否總能區分舊版簡報、投影片放映與範本？**

不能。PPT、PPS 與 POT 共享相同的二進位格式。若需要此區別，請另行保留檔名或子類型中繼資料。

**如果簡報已經載入，我應該使用哪個 API？**

請閱讀 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSourceFormat--)。在載入前的檢查則使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)。