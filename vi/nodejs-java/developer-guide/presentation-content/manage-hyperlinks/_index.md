---
title: Quản lý Liên kết Siêu văn bản trong Bản trình bày bằng JavaScript
linktitle: Quản lý Liên kết
type: docs
weight: 20
url: /vi/nodejs-java/manage-hyperlinks/
keywords:
- thêm URL
- thêm liên kết siêu văn bản
- tạo liên kết siêu văn bản
- định dạng liên kết siêu văn bản
- xóa liên kết siêu văn bản
- cập nhật liên kết siêu văn bản
- liên kết siêu văn bản trong văn bản
- liên kết siêu văn bản trong slide
- liên kết siêu văn bản trong hình dạng
- liên kết siêu văn bản trong hình ảnh
- liên kết siêu văn bản trong video
- liên kết siêu văn bản có thể thay đổi
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý liên kết siêu văn bản trong các bản trình bày PowerPoint và OpenDocument một cách dễ dàng với Aspose.Slides cho Node.js—nâng cao tính tương tác và quy trình làm việc trong vài phút."
---
## **Giới thiệu**

Liên kết siêu văn bản là một tham chiếu đến một đối tượng hoặc dữ liệu hoặc một vị trí trong một thứ gì đó. Đây là các liên kết siêu văn bản phổ biến trong các bản trình bày PowerPoint:

* Liên kết tới các trang web trong văn bản, hình dạng hoặc phương tiện
* Liên kết tới các slide

Aspose.Slides for Node.js via Java cho phép bạn thực hiện nhiều tác vụ liên quan đến liên kết siêu văn bản trong bản trình bày.

{{% alert color="primary" %}} 
Bạn có thể muốn thử Aspose đơn giản, [trình chỉnh sửa PowerPoint trực tuyến miễn phí.](https://products.aspose.app/slides/vi/editor)
{{% /alert %}} 

## **Thêm Liên kết URL**

### **Thêm Liên kết URL vào Văn bản**

Đoạn mã JavaScript này cho bạn thấy cách thêm một liên kết website vào văn bản:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Thêm Liên kết URL vào Hình dạng hoặc Khung**

Đoạn mã mẫu bằng JavaScript này cho bạn thấy cách thêm một liên kết website vào hình dạng:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Thêm Liên kết URL vào Phương tiện**

Aspose.Slides cho phép bạn thêm liên kết siêu văn bản vào hình ảnh, tệp âm thanh và video.

Đoạn mã mẫu này cho bạn thấy cách thêm một liên kết siêu văn bản vào **hình ảnh**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Thêm hình ảnh vào bản trình bày
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Tạo khung hình ảnh trên slide 1 dựa trên hình ảnh đã thêm trước đó
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Đoạn mã mẫu này cho bạn thấy cách thêm một liên kết siêu văn bản vào **tệp âm thanh**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Đoạn mã mẫu này cho bạn thấy cách thêm một liên kết siêu văn bản vào **video**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
Bạn có thể muốn xem *[Quản lý OLE](/slides/vi/nodejs-java/manage-ole/)*.
{{% /alert %}}

## **Sử dụng Liên kết để Tạo Mục lục**

Vì liên kết siêu văn bản cho phép bạn thêm tham chiếu đến các đối tượng hoặc vị trí, bạn có thể sử dụng chúng để tạo một mục lục.

Đoạn mã mẫu này cho bạn thấy cách tạo một mục lục với các liên kết siêu văn bản:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Định dạng Liên kết**

### **Màu**

Với phương thức [setColorSource](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) trong lớp [Hyperlink](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink), bạn có thể đặt màu cho các liên kết siêu văn bản và cũng có thể lấy thông tin màu từ các liên kết. Tính năng này lần đầu được giới thiệu trong PowerPoint 2019, vì vậy các thay đổi liên quan đến thuộc tính này không áp dụng cho các phiên bản PowerPoint cũ hơn.

Đoạn mã mẫu này minh họa một thao tác nơi các liên kết siêu văn bản với các màu khác nhau được thêm vào cùng một slide:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xóa Liên kết trong Bản trình bày**

### **Xóa Liên kết khỏi Văn bản**

Đoạn mã JavaScript này cho bạn thấy cách xóa liên kết siêu văn bản khỏi văn bản trong một slide của bản trình bày:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Kiểm tra xem hình dạng có hỗ trợ khung văn bản (IAutoShape) hay không.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Duyệt qua các đoạn trong khung văn bản
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Duyệt qua từng phần trong đoạn
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Thay đổi văn bản
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Thay đổi định dạng
                    }
                }
            }
        }
    }
    // Lưu bản trình bày đã sửa đổi
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Xóa Liên kết khỏi Hình dạng hoặc Khung**

Đoạn mã JavaScript này cho bạn thấy cách xóa liên kết siêu văn bản khỏi một hình dạng trong slide của bản trình bày:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Liên kết có thể thay đổi**

Lớp [Hyperlink](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink) có thể thay đổi. Với lớp này, bạn có thể thay đổi giá trị cho các thuộc tính sau:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

Đoạn mã mẫu cho bạn thấy cách thêm một liên kết siêu văn bản vào slide và chỉnh sửa tooltip của nó sau này:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Các Thuộc tính Được Hỗ trợ trong IHyperlinkQueries**

Bạn có thể truy cập [HyperlinkQueries](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries) từ một bản trình bày, slide hoặc văn bản mà trong đó liên kết siêu văn bản được định nghĩa.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

Lớp [HyperlinkQueries](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries) hỗ trợ các phương thức và thuộc tính sau:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể tạo điều hướng nội bộ không chỉ tới một slide, mà tới một “section” hoặc slide đầu tiên của một section?**

Các section trong PowerPoint là các nhóm slide; điều hướng về mặt kỹ thuật nhắm tới một slide cụ thể. Để “đi tới một section”, bạn thường liên kết tới slide đầu tiên của section đó.

**Tôi có thể gắn liên kết siêu văn bản vào các yếu tố slide master để nó hoạt động trên tất cả các slide không?**

Có. Các yếu tố slide master và layout hỗ trợ liên kết siêu văn bản. Các liên kết này xuất hiện trên các slide con và có thể nhấp được trong quá trình trình chiếu.

**Liên kết siêu văn bản có được giữ lại khi xuất sang PDF, HTML, hình ảnh hoặc video không?**

Trong [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/), có—liên kết thường được giữ lại. Khi xuất sang [hình ảnh](/slides/vi/nodejs-java/convert-powerpoint-to-png/) và [video](/slides/vi/nodejs-java/convert-powerpoint-to-video/), khả năng nhấp không được chuyển vì tính chất của các định dạng đó (khung raster/video không hỗ trợ liên kết siêu văn bản).