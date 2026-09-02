---
title: 在 Java 中將 PowerPoint 簡報轉換為 XML
linktitle: PowerPoint 轉 XML
type: docs
weight: 145
url: /zh-hant/java/convert-powerpoint-to-xml/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 Java 中將 PowerPoint 及 OpenDocument 簡報轉換為 PowerPoint XML 檔案或串流。"
---
## **概述**

Aspose.Slides for Java 能將 PowerPoint 簡報轉換為 PowerPoint XML 簡報格式。當您需要以文字形式檢查簡報結構、排除產生文件的問題、在自動化測試中比較輸出，或在工作流程中使用 XML 而非簡報套件時，XML 輸出非常有用。

使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法，搭配 [SaveFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/) 類別中的 `Xml` 值。您可以將結果直接寫入檔案或串流。

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` 會建立 PowerPoint XML 簡報。它不會抽取 PPTX 套件內部的個別 Office Open XML 部分。若您需要精確的 PPTX 套件部件，例如 `ppt/presentation.xml` 或個別投影片的 XML 檔案，請直接檢查 PPTX 套件本身。
{{% /alert %}}

## **將簡報轉換為 XML 檔案**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別載入來源簡報，然後將輸出路徑與 `SaveFormat.Xml` 傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-)。來源可以是任何支援載入的簡報格式，例如 PPT、PPTX 或 ODP。

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

當 XML 必須保留在記憶體中或傳遞給其他元件（例如 Web 服務、儲存供應商或 XML 處理管線）時，請使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) 的串流重載。以下範例將結果寫入 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) 並取得 XML 的位元組陣列：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // 將 xmlData 傳遞給工作流程中的下一個元件。
} finally {
    presentation.dispose();
}
```

## **比較 XML 與簡報及匯出格式**

請依照結果的使用方式選擇輸出格式：

| 格式 | 輸出 | 典型用途 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 簡報 | 檢查結構、排除問題、比較產生的輸出，以及基於 XML 的整合 |
| PPT (`.ppt`) | 傳統二進位簡報檔案 | 與較舊的 PowerPoint 工作流程相容 |
| PPTX (`.pptx`) | 包含多個部件的 Office Open XML 套件 | 正常的 PowerPoint 編輯與簡報交換 |
| PDF 或 TIFF | 固定版面頁面或多頁影像 | 檢視、列印與保存 |
| PNG、JPEG 或 SVG | 個別投影片的渲染圖像 | 縮圖、預覽與圖像資產 |
| HTML 或 HTML5 | 網頁導向的簡報輸出 | 瀏覽器檢視與網路發佈 |

與 PPT 與 PPTX 不同，XML 輸出主要用於檢查與資料導向的工作流程。與 PDF、TIFF、HTML 及投影片圖像格式不同，XML 表示的是簡報資料，而非將投影片渲染為頁面或視覺資產。[supported file formats](/slides/zh-hant/java/supported-file-formats/) 表格將 PowerPoint XML 簡報列為僅能儲存的格式，因此在工作流程需要將匯出檔案重新載入 Aspose.Slides 進行後續編輯時，請勿使用此格式。

## **常見問題**

**`SaveFormat.Xml` 與儲存 PPTX 檔案相同嗎？**

不相同。PPTX 是包含多個 Office Open XML 部分的套件，而 `SaveFormat.Xml` 只會產生 PowerPoint XML 簡報檔案。

**我可以在不在磁碟上建立檔案的情況下儲存 XML 輸出嗎？**

可以。將可寫入的串流傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-)。例如，可使用 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) 進行記憶體內處理。

**Aspose.Slides 能再次載入匯出的 XML 檔案嗎？**

不能。PowerPoint XML 簡報目前僅支援儲存，不支援載入。若需要往返編輯，請使用 PPTX 或其他受支援的簡報格式。

**XML 轉換會將每張投影片渲染為頁面或圖像嗎？**

不會。XML 轉換會寫入結構化的簡報資料。若需要頁面導向的輸出，請使用 PDF 或 TIFF；若需要個別投影片圖像，請使用 PNG、JPEG 或 SVG。