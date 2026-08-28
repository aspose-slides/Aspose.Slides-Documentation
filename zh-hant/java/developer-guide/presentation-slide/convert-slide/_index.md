---
title: 在 Java 中將簡報投影片轉換為影像
linktitle: 投影片轉影像
type: docs
weight: 35
url: /zh-hant/java/convert-slide/
keywords:
- 轉換投影片
- 匯出投影片
- 投影片轉影像
- 將投影片另存為影像
- 投影片轉 EMF
- 投影片轉 PNG
- 投影片轉 JPEG
- 投影片轉點陣圖
- 投影片轉 TIFF
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中將 PPT、PPTX 與 ODP 簡報的投影片轉換為 PNG、JPEG、GIF、TIFF、EMF 以及其他影像格式。"
---
## **簡介**

Aspose.Slides for Java 可以將 PowerPoint 與 OpenDocument 簡報的單張投影片渲染為 PNG、JPEG、GIF、TIFF 以及其他影像格式。

若要將投影片轉換為影像，請依照以下步驟：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別載入簡報。
2. 選取您要渲染的投影片。
3. 如有需要，可使用 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/) 類別進行渲染設定。
4. 呼叫 [ISlide.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#getImage--) 方法。它會返回一個 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 物件。
5. 呼叫 [IImage.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 方法，並使用 [ImageFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imageformat/) 值指定輸出格式。

## **將投影片轉換為 PNG 影像**

最簡單的轉換使用預設渲染設定。產生的 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 物件可在記憶體中處理或保存至檔案。

以下 Java 範例會渲染第一張投影片並將其保存為 PNG 影像：

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

## **使用自訂尺寸將投影片轉換為影像**

使用接受 [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) 參數的 [ISlide.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) 方法，以確切的像素尺寸渲染投影片。

以下範例會建立 1820 × 1040 的 JPEG 影像：

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

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

## **將含備註與評論的投影片轉換為影像**

預設情況下，投影片影像不會包含備註或評論。可將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notescommentslayoutingoptions/) 物件傳遞給 [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 方法，以控制備註與評論的顯示位置。

以下範例會將截斷的備註放在投影片下方，並將評論放在右側：

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

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
在投影片轉影像的轉換過程中，請勿將 [BottomFull](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notespositions/) 傳遞給 [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) 方法。備註的文字可能超過固定影像大小的容納範圍，請改用 [BottomTruncated](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notespositions/)。
{{% /alert %}}

## **使用 TIFF 選項將投影片轉換為影像**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/) 類別讓您控制渲染出的 TIFF 影像的尺寸、解析度以及其他屬性。

以下範例會將第一張投影片以 300 DPI 渲染為 2160 × 2880 的 TIFF 影像：

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

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

{{% alert title="Warning" color="warning" %}}
在 JDK 9 之前的 Java 版本中，無法保證支援 TIFF。
{{% /alert %}}

## **將所有投影片轉換為影像**

遍歷投影片集合，以將整個簡報轉換為一系列影像。除非明確跳過，否則會包含隱藏的投影片。

以下範例會將每張投影片以水平與垂直比例因子 2 渲染為 JPEG 影像：

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

## **建立增強型中介檔 (EMF) 輸出**

增強型中介檔 (EMF) 在必須將向量圖形與 Microsoft Office 或其他支援 Windows 中介檔的 Windows 應用程式交換時相當有用。與像素圖不同，EMF 能保留向量繪圖操作，放大縮小時不會產生相同的銳利度損失。然而，EMF 主要是針對具備 Windows 中介檔支援的應用程式之相容格式，並非通用的交換格式。此外，複雜的投影片內容，例如點陣圖與某些效果，可能會以光柵化元素儲存在向量中介檔容器內。

### **將投影片匯出為 EMF**

[ISlide.writeAsEmf](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) 方法會將 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/) 以 EMF 格式寫入目標串流。以下範例載入簡報、選取第一張投影片，並將其寫入 EMF 檔案串流：

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

呼叫端擁有傳遞給 [ISlide.writeAsEmf](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) 的串流，並負責在如上所示的情況下關閉它。

### **將 SVG 圖片轉換為 EMF 並加入簡報**

使用 [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) 可將 SVG 內容轉換為 EMF。產生的位元組可透過 [IImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) 加入簡報，並使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 置於投影片上。

以下範例會從 SVG 標記建立 [SvgImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgimage/)，將其轉換為記憶體中的 EMF，插入第一張投影片，並保存簡報：

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) 不會取得目標串流的所有權。[ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) 會將所有產生的資料儲存在記憶體中，因此在呼叫 `toByteArray` 前不需要重設位置。即使串流已關閉，回傳的位元組陣列仍然有效。

EMF 產生功能會依所選的 Aspose.Slides for Java 及 JDK 設定所支援的作業系統而提供，但若缺少字型或圖形相依性，跨平台的渲染結果可能會有所差異。請安裝來源內容所使用的字型或配置適當的替代方案，遵循 Aspose.Slides for Java 的[平台需求](/slides/zh-hant/java/system-requirements/)，並在目標 EMF 使用應用程式中驗證結果。Linux 與 macOS 應用程式通常對 Windows 中介檔的顯示與編輯支援有限或不一致。

## **彩色表情符號渲染**

{{% alert title="Note" color="info" %}}
在將簡報投影片轉換為影像時，要正確渲染彩色表情符號，必須在執行轉換的系統上安裝簡報中使用的表情符號字型。例如，若簡報使用 **Segoe UI Emoji** 但該字型缺失，表情符號可能會以單色顯示在輸出影像中。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援渲染含動畫的投影片？**

不支援。[ISlide.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#getImage--) 方法僅渲染投影片的靜態影像，且不會匯出動畫。

**可以將隱藏的投影片匯出為影像嗎？**

可以。隱藏的投影片可像一般投影片一樣渲染。請在處理迴圈中將它們納入，如上例所示。

**投影片影像會保留陰影及其他效果嗎？**

會。Aspose.Slides 會在投影片影像中渲染陰影、透明度以及其他受支援的圖形效果。