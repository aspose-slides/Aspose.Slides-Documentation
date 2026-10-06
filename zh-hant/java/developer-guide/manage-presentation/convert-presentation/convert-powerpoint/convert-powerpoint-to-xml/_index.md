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
- 匯出簡報為 XML
- XML 串流
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java，在 Java 中將 PowerPoint 和 OpenDocument 簡報轉換為 PowerPoint XML 檔案或串流。"
---
## **概述**

Aspose.Slides for Java 可以將 PowerPoint 簡報轉換為 PowerPoint XML 簡報格式。當您需要以文字為基礎的表示方式來檢查簡報結構、除錯產生的文件、在自動化測試中比較輸出，或整合消耗 XML 而非簡報套件的工作流程時，XML 輸出非常有用。

使用帶有 `Xml` 值的 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法，該值來自 [SaveFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/) 類別。您可以將結果直接寫入檔案或寫入串流。

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` 會產生 PowerPoint XML 簡報。它不會提取存於 PPTX 套件內的個別 Office Open XML 部件。如果您需要精確的 PPTX 套件部件，例如 `ppt/presentation.xml` 或個別投影片的 XML 檔案，請檢查 PPTX 套件本身。
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

當 XML 必須保留在記憶體中或傳遞給其他元件（如 Web 服務、儲存供應商或 XML 處理管線）時，請使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) 的串流載入版。以下範例將結果寫入 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) 並取得產生的 XML 作為位元組陣列：

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

請根據結果的使用方式選擇輸出格式：

| 格式 | 輸出 | 典型用途 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 簡報 | 檢查結構、除錯、比較產生的輸出，以及基於 XML 的整合 |
| PPT (`.ppt`) | 舊版二進位簡報檔 | 與舊版 PowerPoint 工作流程相容 |
| PPTX (`.pptx`) | 包含多個部件的 Office Open XML 套件 | 一般的 PowerPoint 編輯與簡報交換 |
| PDF or TIFF | 固定版面的頁面或多頁圖像 | 檢視、列印與存檔 |
| PNG, JPEG, or SVG | 單一投影片的渲染圖像 | 縮圖、預覽與影像資產 |
| HTML or HTML5 | 面向網路的簡報輸出 | 瀏覽器檢視與網站發布 |

與 PPT 與 PPTX 不同，XML 輸出主要用於檢查與資料導向的工作流程。與 PDF、TIFF、HTML 以及投影片圖像格式不同，XML 代表的是簡報資料，而非將投影片渲染為頁面或視覺資產。[supported file formats](/slides/zh-hant/java/supported-file-formats/) 表格列出了 Aspose.Slides 能載入、匯入、儲存或渲染的所有格式。

## **常見問題**

**`SaveFormat.Xml` 是否等同於儲存為 PPTX 檔案？**

否。PPTX 是包含多個 Office Open XML 部件的套件，而 `SaveFormat.Xml` 會產生 PowerPoint XML 簡報檔案。

**我可以在不產生磁碟檔案的情況下儲存 XML 輸出嗎？**

可以。將可寫入的串流傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-)。例如，使用 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) 進行記憶體內處理。

**Aspose.Slides 能再次載入已匯出的 XML 檔案嗎？**

可以。將 XML 檔案或串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) 建構子。然後 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSourceFormat--) 會返回 `SourceFormat.Xml`。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 會報告此格式為 `LoadFormat.Unknown`，因此不要依此判斷 XML 檔案是否能開啟。

**XML 轉換是否會將每張投影片渲染為頁面或圖像？**

不會。XML 轉換會寫入結構化的簡報資料。若需頁面導向的輸出，請使用 PDF 或 TIFF；若需單張投影片圖像，請使用 PNG、JPEG 或 SVG。