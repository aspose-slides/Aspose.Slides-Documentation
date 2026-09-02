---
title: 在 Android 上將簡報投影片轉換為圖像
linktitle: 投影片轉圖像
type: docs
weight: 35
url: /zh-hant/androidjava/convert-slide/
keywords:
- 轉換投影片
- 匯出投影片
- 投影片轉圖像
- 將投影片儲存為圖像
- 投影片轉 EMF
- 投影片轉 PNG
- 投影片轉 JPEG
- 投影片轉點陣圖
- 投影片轉 TIFF
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Android 上將 PPT、PPTX 和 ODP 簡報的投影片轉換為 PNG、JPEG、GIF、TIFF、EMF 以及其他圖像格式。"
---
## **簡介**

Aspose.Slides for Android via Java 可以將 PowerPoint 和 OpenDocument 簡報中的單獨投影片渲染為 PNG、JPEG、GIF、TIFF 等圖像格式。

若要將投影片轉換為圖像，請按照以下步驟操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別載入簡報。
2. 選取您想要渲染的投影片。
3. 如有需要，可使用 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/) 類別設定渲染參數。
4. 呼叫 [ISlide.getImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getImage--) 方法。它會回傳一個 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 物件。
5. 呼叫 [IImage.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 方法，並使用 [ImageFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imageformat/) 參數指定輸出格式。

## **將投影片轉換為 PNG 圖像**

最簡單的轉換使用預設渲染設定。產生的 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 物件可在記憶體中處理或儲存為檔案。

以下 Java 範例會渲染第一張投影片並將其儲存為 PNG 圖像：

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **使用自訂尺寸將投影片轉換為圖像**

使用接受 [Size](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.android/size/) 參數的 [ISlide.getImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) 重載方法，以精確的像素尺寸渲染投影片。

以下範例會建立 1820 × 1040 的 JPEG 圖像：

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **將含備註與評論的投影片轉換為圖像**

預設情況下，投影片圖像不會包含備註或評論。將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 物件傳遞給 [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 方法，以控制備註和評論的顯示位置。

以下範例將截斷的備註放置在投影片下方，評論則顯示在右側：

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
在投影片轉圖像的過程中，請勿將 [BottomFull](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notespositions/) 傳遞給 [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) 方法。備註的文字可能超過固定圖像尺寸的容納範圍，請改用 [BottomTruncated](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notespositions/)。
{{% /alert %}}

## **使用 TIFF 選項將投影片轉換為圖像**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/) 類別讓您控制所渲染 TIFF 圖像的大小、解析度及其他屬性。

以下範例會將第一張投影片以 300 DPI 渲染為 2160 × 2880 的 TIFF 圖像：

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **將全部投影片轉換為圖像**

遍歷投影片集合以將整個簡報轉換為一系列圖像。除非明確跳過，否則隱藏投影片也會被包含。

以下範例會將每張投影片以水平與垂直比例因子 2 渲染為 JPEG 圖像：

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **產生增強型圖形檔案 (EMF) 輸出**

增強型圖形檔案 (EMF) 在需要將向量圖形與 Microsoft Office 或其他支援 Windows 中繪圖檔案的 Windows 應用程式交換時非常有用。與像素圖像不同，EMF 能保留向量繪製操作，縮放時不會有相同的清晰度損失。然而，EMF 主要是供支援 Windows 中繪圖檔案的應用程式使用的相容格式，並非通用的交換格式。另外，複雜的投影片內容，如點陣圖和某些效果，可能會以光柵化元素儲存在向量中繪圖檔案容器內。

### **將投影片匯出為 EMF**

[ISlide.writeAsEmf](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) 方法會將 [ISlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/) 以 EMF 格式寫入目標串流。以下範例載入簡報、選取第一張投影片，並將其寫入 EMF 檔案串流：

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

呼叫端負責管理傳遞給 [ISlide.writeAsEmf](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) 的串流，並在如上所示後關閉它。

### **將 SVG 圖像轉換為 EMF 並加入簡報**

使用 [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) 將 SVG 內容轉換為 EMF。產生的位元組可透過 [IImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) 加入簡報，並使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 放置於投影片上。

以下範例會從 SVG 標記建立 [SvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/svgimage/)，將其轉換為記憶體中的 EMF，插入第一張投影片，並儲存簡報：

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) 不會取得目的串流的所有權。[ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) 會將所有產生的資料儲存在記憶體中，因此在呼叫 `toByteArray` 前不需要重新定位。關閉串流後，返回的位元組陣列仍然有效。

EMF 產生在支援的 Android 版本與裝置組態上可用，但若缺少字型或圖形相依性，渲染結果可能會不同。請安裝來源內容使用的字型或設定適當的替代字型，依照 Aspose.Slides for Android via Java 的[安裝指南](/slides/zh-hant/androidjava/install-aspose-slides-for-android-via-java/)，並在目標 EMF 使用的應用程式中驗證結果。非 Windows 平台的應用程式通常對顯示與編輯 Windows 中繪圖檔案的支援有限或不一致。

## **彩色表情符號呈現**

{{% alert title="Note" color="info" %}}
在將簡報投影片轉換為圖像時，要正確呈現彩色表情符號，必須在執行轉換的系統上安裝並提供簡報中使用的表情符號字型。例如，若簡報使用 **Segoe UI Emoji** 而該字型缺失，表情符號在輸出圖像中可能會以單色顯示。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援渲染帶有動畫的投影片？**

不支援。[ISlide.getImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getImage--) 方法僅渲染投影片的靜態圖像，且不會匯出動畫。

**隱藏投影片可以匯出為圖像嗎？**

可以。隱藏投影片可像一般投影片一樣渲染。請在處理迴圈中包含它們，如上例所示。

**投影片圖像會保留陰影和其他效果嗎？**

會。Aspose.Slides 會在投影片圖像中渲染陰影、透明度及其他支援的圖形效果。