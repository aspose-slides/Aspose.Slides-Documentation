---
title: 在 Android 上變更註記頁尺寸與方向
linktitle: 註記頁尺寸
type: docs
weight: 10
url: /zh-hant/androidjava/notes-size/
keywords:
- 註記頁尺寸
- 註記方向
- 橫向註記
- 直向註記
- 講義尺寸
- PowerPoint
- 簡報
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "透過 Java 在 Android 版的 Aspose.Slides 中讀取與變更註記頁尺寸，切換方向，驗證已儲存的尺寸，並將註記或講義匯出為 PDF 與影像。"
---
## **概述**

使用[Presentation.getNotesSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getNotesSize--)來存取簡報的註記頁設定。它會傳回一個[INotesSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/inotessize/)物件，其[setSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-)方法設定頁面的尺寸。雖然設定物件本身無法取代，但您可以透過此方法指派新尺寸。

寬度與高度以**點**為單位指定，每英吋 72 點。例如，900 × 600 點相當於 12.5 × 8⅓ 英吋。這些設定套用於整個簡報，而非單一投影片的註記。

| 設定 | 目的 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getNotesSize--) | 控制註記頁尺寸以及用於講義匯出的頁面尺寸。 |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlideSize--) | 透過[ISlideSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidesize/)控制一般簡報投影片的尺寸。 |

變更任一設定不會自動變更另一個。變更註記頁方向也不會旋轉一般投影片。請參閱[Slide Size](/slides/zh-hant/androidjava/slide-size/)以重新調整一般投影片的尺寸。

以下範例使用現有的 `sample.pptx`。對於匯出範例，請使用至少有一張包含講者備註的投影片的簡報。每個範例皆可獨立執行。

## **讀取註記頁大小與方向**

讀取寬度與高度並比較以判斷方向：較寬的頁面為橫向，較高的頁面為直向，尺寸相等則為方形頁面。此範例會以點為單位印出實際尺寸，並不假設標準紙張大小。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

## **切換至橫向而不更改紙張大小**

若只變更方向，交換現有的寬度與高度。此作法會保留兩邊的長度，包括自訂紙張大小的長度。下列條件可防止已是橫向的頁面被切回直向，並維持方形頁面不變。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對於直向，當 `size.getWidth() > size.getHeight()` 時使用相同的指派。除非您也想變更紙張大小，否則不要改用 A4 或 Letter 尺寸。

## **設定與驗證自訂註記頁大小**

一次指派兩個尺寸，然後使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)寫入簡報。此範例將 900 × 600 點的橫向頁面設定後儲存為 PPTX，然後再次開啟已儲存的檔案以檢查持久化的值。比較允許 0.01 點的容差以因應浮點數值；此容差並不保證每種檔案格式的精確度。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

預期結果為 `900.0 x 600.0 points` 與 `Size preserved: true`。檢查新開啟的簡報可驗證已儲存檔案，而非僅檢查記憶體中的設定。

## **匯出註記與講義**

頁面尺寸定義了註記或講義版面可使用的區域。僅此並不會啟用這些版面配置：仍需設定匯出選項。一般投影片的匯出仍使用投影片尺寸。

### **匯出註記至 PDF 與 PNG**

將[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notescommentslayoutingoptions/)指派給[PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)以在 PDF 中包含註記。此範例亦使用[Slide.getImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)與[RenderingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/renderingoptions/)將第一張帶註記的投影片轉換為 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notespositions/)模式會將註記固定於一頁；無法容納的註記會被截斷。PDF 使用 900 × 600 點的頁面。以下使用 1 × 1 的影像比例時，PNG 為 900 × 600 像素。點描述頁面幾何形狀；像素描述光柵輸出，其尺寸亦取決於渲染比例。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

若 PDF 匯出時註記過長，可使用[BottomFull](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notespositions/)允許根據需要產生額外頁面。請勿在上述單投影片影像呼叫中使用此模式，因為該呼叫不支援。調整尺寸後，請檢查輸出是否有被裁切的註記以及既有 notes‑master 物件的放置情形；僅變更頁面尺寸並不保證所有內容都能容納。更多註記匯出資訊請參閱[Convert PowerPoint to PDF with Notes](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf-with-notes/)。

### **匯出講義至 PDF**

使用[HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/handoutlayoutingoptions/)可在一頁上放置多張投影片縮圖。以下範例設定 900 × 600 點的頁面，並使用[HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/handouttype/)將每頁安排最多四張投影片。水平預設控制投影片排序；頁面方向則取決於其寬度與高度。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

變更頁面大小會改變講義格線可使用的區域，而不會改變來源投影片的尺寸。對於講義影像，請使用[Presentation.getImages](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-)搭配講義版面，而非單一投影片的影像方法。在 Aspose.Slides 中，簡報層級的講義渲染會使用註記頁尺寸，而個別投影片的影像呼叫不會產生講義頁面。請參閱[Handout Mode](/slides/zh-hant/androidjava/convert-powerpoint-in-handout-mode/)以了解版面配置選項。

## **觀閱器、匯出與列印中的頁面大小**

保持儲存的簡報尺寸、匯出頁面尺寸以及列印紙張尺寸彼此分離：

- **簡報檢視器：** 檢視器可使用自訂的版面規則顯示或列印註記。若其他應用程式儲存檔案，請重新開啟並再次檢查尺寸；該應用程式的格式轉換可能會將其正規化。
- **匯出格式：** 上述註記與講義 PDF 範例使用已設定的頁面尺寸。光柵影像使用整數像素尺寸與渲染比例，因此在影像輸出時可能會將小數點的點值四捨五入。匯出一般投影片不會套用註記頁尺寸。
- **印表機驅動程式：** 紙張選擇、自動旋轉與適合頁面設定可在不變更簡報或 PDF 中儲存的尺寸情況下改變實體輸出。對於特定紙張大小，請配合印表機設定並檢查列印預覽。

## **常見問題**

**我能只為單一投影片設定註記大小嗎？**

註記頁大小是簡報層級的設定。各投影片可以有不同的註記內容，但此屬性不提供每張投影片獨立的頁面大小。

**為何變更註記方向未影響我的投影片？**

註記頁與一般投影片的尺寸是獨立的。若要調整投影片本身的尺寸，請使用一般投影片尺寸設定。

**為何我的儲存或列印結果尺寸不同？**

請先重新開啟已儲存的簡報並比較其註記尺寸。若尺寸已變更，檢查是否在其他應用程式中儲存或轉換檔案時更改了頁面設定。若未變更，請檢查匯出版面、影像比例、檢視器設定，與印表機的紙張選擇。