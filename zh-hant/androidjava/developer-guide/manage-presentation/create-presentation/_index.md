---
title: 在 Android 上建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 於 Java 中建立簡報——產生 PPT、PPTX 與 ODP 檔案，受益於 OpenDocument 支援，並以程式方式儲存以確保可靠的結果。"
---
## **概覽**

本文說明如何在 Aspose.Slides for Android（使用 Java）中建立簡報，向其第一張投影片新增文字方塊，並將結果儲存為應用程式的檔案。若要開啟現有簡報或以其他格式儲存，請參閱 [開啟簡報](/slides/zh-hant/androidjava/open-presentation/) 和 [儲存簡報](/slides/zh-hant/androidjava/save-presentation/)。最後的簡短 FAQ 針對格式、範本、投影片尺寸、單位、記憶體使用、執行緒、授權、數位簽章與 VBA 支援等常見問題提供說明。

開始之前，請從 Aspose 的 Maven 倉庫將 Aspose.Slides 加入 Android 專案。請參閱 [安裝](/slides/zh-hant/androidjava/install-aspose-slides-for-android-via-java/)。

## **建立 PowerPoint 簡報**

要建立簡報並在第一張投影片上放置文字方塊，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別的實例。新簡報已預設包含一張空白投影片。
1. 透過索引 0 從 [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) 取得該投影片。
1. 使用 [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) 方法於 [shape collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) 中新增矩形，並使用 [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) 方法設定其 [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) 的文字。
1. 使用 [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法將簡報以 PPTX 檔儲存，格式為 [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/)。

程式碼在 `Activity` 中執行，例如在其 `onCreate` 方法內。它會將檔案儲存至由 [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) 方法回傳的目錄：應用程式的私有儲存空間，無需任何權限即可寫入。

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

矩形左上角距投影片左邊緣及上邊緣各 50 點，矩形寬 400 點、高 100 點。儲存的檔案包含一張帶有該矩形及其文字的投影片。若未取得授權，Aspose.Slides 亦會在每張儲存的投影片上加上評估水印；請參閱 [授權](/slides/zh-hant/androidjava/licensing/)。

若要查看檔案，請開啟 Android Studio 的 [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer)，在 *data/data/* 下的 *files* 資料夾中找到 *hello.pptx*。在實際應用程式中，請在背景執行緒上處理簡報，以保持使用者介面回應。

## **常見問題**

### 可以將新簡報儲存為哪些格式？

您可以儲存為 [PPTX、PPT 與 ODP]，並可匯出為 [PDF]、[XPS]、[HTML]、[SVG] 以及 [圖片] 等格式。

### 我可以從範本 (POTX/POTM) 開始，並儲存為一般 PPTX 嗎？

可以。載入範本後儲存為所需格式；POTX/POTM/PPTM 及類似格式 [已支援](/slides/zh-hant/androidjava/supported-file-formats/)。

### 建立簡報時，如何控制投影片大小/長寬比？

設定 [投影片大小](/slides/zh-hant/androidjava/slide-size/)（包括 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

### 尺寸與座標以何種單位測量？

以點 (point) 為單位：1 英吋等於 72 點。

### 如何處理大型簡報（含大量媒體檔）以降低記憶體使用量？

使用 [BLOB 管理策略](/slides/zh-hant/androidjava/manage-blob/)，透過暫存檔限制記憶體中的儲存，並優先使用基於檔案的工作流程而非純記憶體串流。

### 我可以平行建立/儲存簡報嗎？

您無法在 [多執行緒](/slides/zh-hant/androidjava/multithreading/) 中操作相同的 [Presentation] 實例。請在每個執行緒或行程中使用獨立的實例。

### 如何移除試用水印與限制？

[套用授權](/slides/zh-hant/androidjava/licensing/) 每個行程執行一次。授權 XML 必須保持未修改，若有多個執行緒，授權設定需同步。

### 我可以為我建立的 PPTX 加上數位簽章嗎？

可以。[數位簽章](/slides/zh-hant/androidjava/digital-signature-in-powerpoint/)（新增與驗證）支援簡報。

### 已建立的簡報是否支援巨集 (VBA)？

可以。您可以 [建立/編輯 VBA 專案](/slides/zh-hant/androidjava/presentation-via-vba/)，並儲存支援巨集的檔案，例如 PPTM/PPSM。