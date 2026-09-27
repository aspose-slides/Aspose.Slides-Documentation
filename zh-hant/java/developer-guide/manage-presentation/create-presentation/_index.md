---
title: 在 Java 中建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/java/create-presentation/
keywords:
- 建立簡報
- 新簡報
- 建立 PPT
- 新 PPT
- 建立 PPTX
- 新 PPTX
- 建立 ODP
- 新 ODP
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中建立簡報——產生 PPT、PPTX 與 ODP 檔案，受惠於 OpenDocument 支援，並以程式方式儲存以確保可靠的結果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中建立簡報，於第一張投影片加入含文字的圖形，並將結果儲存為 PPTX 檔案。若要開啟現有簡報並儲存為其他格式，請參閱 [Open Presentations](/slides/zh-hant/java/open-presentation/) 與 [Save Presentations](/slides/zh-hant/java/save-presentation/)。最後的簡短 FAQ 針對格式、範本、投影片大小、單位、記憶體使用、執行緒、授權、數位簽章與 VBA 支援等常見問題提供說明。

在開始之前，請從 Aspose 的 Maven 檔案庫將 Aspose.Slides for Java 加入您的專案。相關的 Maven 設定與 Linux 需求請參閱 [Installation](/slides/zh-hant/java/installation/)。

## **建立簡報**

在 Aspose.Slides for Java 中從頭建立 PowerPoint 檔案，首先需要建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。建構式會提供一個只有單一投影片的空白簡報，您可以在其中加入圖形、文字、圖表或任何其他需要的內容。修改該投影片或新增投影片後，即可將結果儲存為 PPTX、傳統 PPT 或 OpenDocument 格式。

欲建立簡報並在第一張投影片上放置帶文字的圖形，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。新簡報已預設包含一張空白投影片。  
1. 透過 [getSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSlides--) 回傳的集合，以索引 0 取得該投影片。  
1. 使用 [addAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) 方法新增一個 `Cloud` 類型的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)，並以 [setText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#setText-java.lang.String-) 設定其文字。  
1. 使用 [save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法將簡報儲存為 PPTX 檔案。

以下範例為完整程式碼。在 [Installation](/slides/zh-hant/java/installation/) 的 Maven 專案中，將其儲存為 *src/main/java/HelloSlides.java*，然後執行 `mvn compile exec:java`。

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // 建立簡報。它已包含一張空白投影片。
        Presentation presentation = new Presentation();
        try {
            // 取得第一張投影片。
            ISlide slide = presentation.getSlides().get_Item(0);

            // 新增雲形狀並放入文字。
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // 將簡報儲存為 PPTX 檔案。
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

雲圖形的左上角距離投影片左邊緣 20 點、上邊緣 20 點，寬度為 200 點、高度為 80 點。程式會將 *new_presentation.pptx* 儲存為僅含雲圖形與文字的一張投影片。若未提供授權，Aspose.Slides 仍會在每張儲存的投影片上加入評估水印；詳情請參閱 [Licensing](/slides/zh-hant/java/licensing/)。

結果：

![The new presentation](new_presentation.png)

## **FAQ**

### 可以儲存為哪些格式？

您可以儲存為 [PPTX, PPT, and ODP](/slides/zh-hant/java/save-presentation/)，並匯出為 [PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/java/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/java/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/java/render-a-slide-as-an-svg-image/)、以及 [images](/slides/zh-hant/java/convert-powerpoint-to-png/)，等多種格式。

### 我可以從範本 (POTX/POTM) 開始，然後儲存為一般 PPTX 嗎？

可以。載入範本後儲存為目標格式；POTX/POTM/PPTM 等類似格式 [are supported](/slides/zh-hant/java/supported-file-formats/)。

### 建立簡報時，如何控制投影片大小/長寬比？

設定 [slide size](/slides/zh-hant/java/slide-size/)（包括 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

### 尺寸與座標的單位是什麼？

使用點 (point)：1 吋等於 72 單位。

### 如何處理包含大量媒體檔案的巨型簡報以減少記憶體使用？

使用 [BLOB management strategies](/slides/zh-hant/java/manage-blob/)，透過暫存檔限制記憶體佔用，並優先採用檔案為基礎的工作流程而非純記憶體串流。

### 可以平行建立/儲存簡報嗎？

不可從 [multiple threads](/slides/zh-hant/java/multithreading/) 同時操作同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 實例。請在每個執行緒或行程中使用獨立的實例。

### 如何移除評估水印與限制？

在每個行程中 [Apply a license](/slides/zh-hant/java/licensing/)。授權 XML 必須保持原樣，且若有多執行緒使用，授權設定需同步。

### 可以為我建立的 PPTX 加上數位簽章嗎？

可以。支援 [Digital signatures](/slides/zh-hant/java/digital-signature-in-powerpoint/)（加入與驗證）於簡報。

### 在建立的簡報中是否支援宏 (VBA)？

支援。您可以 [create/edit VBA projects](/slides/zh-hant/java/presentation-via-vba/) 並儲存含宏的檔案，如 PPTM/PPSM。