---
title: 變更 Java 中的備註頁尺寸與方向
linktitle: 備註頁尺寸
type: docs
weight: 10
url: /zh-hant/java/notes-size/
keywords:
- 備註頁尺寸
- 備註方向
- 橫向備註
- 直向備註
- 講義尺寸
- PowerPoint
- 簡報
- PPT
- PPTX
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中讀取與變更備註頁尺寸，切換方向，驗證已儲存的尺寸，並將備註或講義匯出為 PDF 與圖像。"
---
## **概觀**

使用 [Presentation.getNotesSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getNotesSize--) 來存取簡報的備註頁設定。它傳回一個 [INotesSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/inotessize/) 物件，其 [setSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) 方法用於設定頁面的尺寸。雖然設定物件本身無法被取代，但您可以透過此方法指派新的尺寸。

寬度和高度以 **點** 為單位指定，每英吋 72 點。例如，900 × 600 點等於 12.5 × 8⅓ 英吋。這些設定套用於整個簡報，而非單一投影片的備註。

| 設定 | 目的 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getNotesSize--) | 控制備註頁的尺寸以及用於講義匯出的頁面尺寸。 |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSlideSize--) | 透過 [ISlideSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidesize/) 控制一般簡報投影片的尺寸。 |

變更任一設定不會自動影響另一個設定。變更備註頁方向也不會旋轉一般投影片。請參閱 [Slide Size](/slides/zh-hant/java/slide-size/) 以調整一般投影片的尺寸。

以下範例使用現有的 `sample.pptx`。對於匯出範例，請使用至少包含一張具有講者備註的投影片的簡報。每個範例皆可獨立執行。

## **讀取備註頁尺寸與方向**

讀取寬度與高度並比較，以判斷方向：寬的頁面為橫向，長的頁面為直向，若尺寸相同則為方形頁面。此範例會以點為單位輸出實際尺寸，且不假設任何標準紙張大小。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **在不變更紙張尺寸的情況下切換為橫向**

若僅要變更方向，交換現有的寬度與高度即可。此作法會保留兩邊的長度，包括自訂紙張尺寸的長寬。下方的條件式可防止已為橫向的頁面被切回直向，且對方形頁面不會產生變更。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對於直向，當 `size.getWidth() > size.getHeight()` 時使用相同的指定。除非您同時想變更紙張尺寸，否則不要改用 A4 或 Letter 的尺寸。

## **設定並驗證自訂備註頁尺寸**

一次指派兩個尺寸，然後使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 儲存簡報。此範例設定 900 × 600 點的橫向頁面，將其儲存為 PPTX，並再次開啟已儲存的檔案以檢查持久化的值。比較時允許 0.01 點的浮點容差；但此容差並不保證所有檔案格式皆具精確度。

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

預期結果為 `900.0 x 600.0 points` 以及 `Size preserved: true`。檢查新開啟的簡報可驗證已儲存的檔案，而非僅檢查記憶體中的設定。

## **匯出備註與講義**

頁面尺寸決定備註或講義版面可用的區域。它們本身不會啟用這些版面配置，必須同時設定匯出選項。一般投影片的匯出仍使用投影片的尺寸。

### **匯出備註至 PDF 與 PNG**

將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notescommentslayoutingoptions/) 指派給 [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 以在 PDF 中包含備註。此範例亦使用 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) 與 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/renderingoptions/) 將第一張含備註的投影片渲染為 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notespositions/) 模式將備註保留在單一頁面；若備註超出則會被截斷。PDF 使用 900 × 600 點的頁面。以下使用 1 × 1 的影像比例時，PNG 為 900 × 600 像素。點描述頁面幾何形狀，像素描述點陣輸出，其尺寸亦受渲染比例影響。

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

若 PDF 匯出時備註過長，可使用 [BottomFull](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notespositions/) 依需求新增頁面。不要在上述單投影片影像呼叫中使用此模式，因為它不支援。調整尺寸後，請檢查輸出是否有被裁剪的備註以及現有 notes-master 物件的位置；僅變更頁面尺寸並不保證所有內容皆能容納。更多備註匯出資訊請參閱 [Convert PowerPoint to PDF with Notes](/slides/zh-hant/java/convert-powerpoint-to-pdf-with-notes/)。

### **匯出講義至 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handoutlayoutingoptions/) 於單頁顯示多張投影片縮圖。以下範例設定 900 × 600 點的頁面，並使用 [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handouttype/) 以在每頁排列最多四張投影片。水平預設控制投影片順序；頁面方向則取決於其寬度與高度。

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

變更頁面尺寸會調整講義格線的可用區域，但不會改變來源投影片的尺寸。對於講義影像，請使用搭配講義版面的 [Presentation.getImages](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-)，而非單張投影片的影像方法。在 Aspose.Slides 中，簡報層級的講義呈現使用備註頁尺寸，而單投影片影像呼叫不會產生講義頁面。請參閱 [Handout Mode](/slides/zh-hant/java/convert-powerpoint-in-handout-mode/) 以瞭解版面選項。

## **檢視器、匯出與列印中的頁面尺寸**

將儲存的簡報尺寸、匯出的頁面尺寸與列印的紙張尺寸保持分開：

- **Presentation viewers:** 檢視程式可以依其自身版面規則顯示或列印備註。若其他應用程式儲存檔案，請重新開啟並再次檢查尺寸；該應用程式的格式轉換可能會正規化尺寸。
- **Export formats:** 以上的備註與講義 PDF 範例使用已設定的頁面尺寸。點陣圖使用整數像素尺寸與渲染比例，因此浮點點值可能在影像輸出時被四捨五入。匯出一般投影片時不會套用備註頁尺寸。
- **Printer drivers:** 紙張選擇、自動旋轉與符合頁面設定可以改變實際輸出，而不會變更儲存在簡報或 PDF 中的尺寸。若需特定紙張尺寸，請配合印表機設定並檢查列印預覽。

## **常見問題**

**我可以僅為單一投影片設定備註尺寸嗎？**

備註頁尺寸是簡報層級的設定。個別投影片可以有不同的備註內容，但此屬性不提供每張投影片單獨的頁面尺寸。

**為什麼變更備註方向未影響我的投影片？**

備註頁與一般投影片的尺寸是獨立的。若想調整投影片本身的尺寸，請使用一般投影片尺寸設定。

**為什麼我的已儲存或列印的結果尺寸不同？**

首先重新開啟已儲存的簡報，並比較其備註尺寸。若尺寸已變更，請檢查是否在其他應用程式中儲存或轉換檔案時更改了頁面設定。若未變更，請檢查匯出版面、影像比例、檢視器設定與印表機紙張選擇。