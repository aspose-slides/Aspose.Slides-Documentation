---
title: 在 Android 上將 PowerPoint 簡報轉換為 XML
linktitle: PowerPoint 轉 XML
type: docs
weight: 145
url: /zh-hant/androidjava/convert-powerpoint-to-xml/
keywords:
- 將 PowerPoint 轉換為 XML
- 將簡報轉換為 XML
- PPT 轉 XML
- PPTX 轉 XML
- ODP 轉 XML
- PowerPoint XML 簡報
- SaveFormat.Xml
- 將簡報儲存為 XML
- 將簡報匯出為 XML
- XML 串流
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 將 PowerPoint 與 OpenDocument 簡報轉換為 PowerPoint XML 檔案或串流。"
---
## **概覽**

Aspose.Slides for Android via Java 可以將 PowerPoint 簡報轉換為 PowerPoint XML 簡報格式。XML 輸出在需要以文字方式檢視簡報結構、排除產生文件的問題、在自動化測試中比較輸出，或在需要 XML 而非簡報套件的工作流程中整合時，非常有用。

使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法搭配 [SaveFormat.Xml](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/#Xml)。您可以直接將結果寫入檔案或寫入串流。

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` 會建立 PowerPoint XML 簡報。它不會抽取存在 PPTX 套件中的各個 Office Open XML 部分。如果您需要精確的 PPTX 套件部件，例如 `ppt/presentation.xml` 或各個投影片的 XML 檔案，請直接檢查 PPTX 套件本身。

{{% /alert %}}

## **將簡報轉換為 XML 檔案**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別載入來源簡報，然後將輸出路徑和 [SaveFormat.Xml](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/#Xml) 傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)。來源可以是任何支援載入的簡報格式，例如 PPT、PPTX 或 ODP。

以下範例將 PPTX 簡報轉換為 XML 檔案：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **將 XML 輸出寫入串流**

在 XML 必須保留在記憶體中或傳遞給其他元件（例如 Web 服務、儲存供應商或 XML 處理管線）時，使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) 的串流覆寫方法。以下範例將結果寫入 [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) 並取得產生的 XML 位元組陣列：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // 將 xmlData 傳遞給工作流程中的下一個元件。
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **將 XML 與簡報及匯出格式比較**

依照結果的使用方式選擇輸出格式：

| 格式 | 輸出 | 典型用途 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 簡報 | 檢視結構、除錯、比較產生的輸出、以及基於 XML 的整合 |
| PPT (`.ppt`) | 舊版二進位簡報檔案 | 與舊版 PowerPoint 工作流程的相容性 |
| PPTX (`.pptx`) | 包含多個部件的 Office Open XML 套件 | 正常的 PowerPoint 編輯與簡報交換 |
| PDF 或 TIFF | 固定版面的頁面或多頁影像 | 檢視、列印與保存 |
| PNG、JPEG 或 SVG | 單一投影片的渲染圖像 | 縮圖、預覽與影像資產 |
| HTML 或 HTML5 | 針對網頁的簡報輸出 | 瀏覽器檢視與網站發布 |

與 PPT 與 PPTX 不同，XML 輸出主要用於檢視與資料導向的工作流程。與 PDF、TIFF、HTML 以及投影片影像格式不同，XML 代表的是簡報資料，而非將投影片渲染為頁面或視覺資產。[支援的檔案格式](/slides/zh-hant/androidjava/supported-file-formats/) 表格將 PowerPoint XML 簡報列為僅可儲存的格式，因此在工作流程必須將匯出的檔案重新載入 Aspose.Slides 以繼續編輯時，請不要使用此格式。

## **常見問答**

**`SaveFormat.Xml` 與儲存 PPTX 檔案相同嗎？**

不是。PPTX 是包含多個 Office Open XML 部件的套件，而 `SaveFormat.Xml` 只會建立 PowerPoint XML 簡報檔案。

**我可以在不建立磁碟檔案的情況下儲存 XML 輸出嗎？**

可以。將可寫入的串流傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-)。例如，可使用 [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) 進行記憶體內處理。

**Aspose.Slides 能再次載入匯出的 XML 檔案嗎？**

不能。PowerPoint XML 簡報目前僅支援儲存，不支援載入。若需要來回編輯，請使用 PPTX 或其他支援的簡報格式。

**XML 轉換會將每張投影片渲染為頁面或影像嗎？**

不會。XML 轉換只會寫入結構化的簡報資料。若需頁面導向的輸出，請使用 PDF 或 TIFF；若需單張投影片影像，請使用 PNG、JPEG 或 SVG。