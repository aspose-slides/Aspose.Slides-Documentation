---
title: Quản lý Zoom cho Bản trình chiếu bằng JavaScript
linktitle: Quản lý Zoom
type: docs
weight: 60
url: /vi/nodejs-java/manage-zoom/
keywords:
- phóng to
- khung phóng to
- phóng to slide
- phóng to phần
- phóng to tổng kết
- thêm phóng to
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo và tùy chỉnh Zoom với Aspose.Slides cho Node.js — di chuyển giữa các phần, thêm hình thu nhỏ và chuyển đổi trong các bản thuyết trình PPT, PPTX và ODP."
---
## **Giới thiệu**

Zoom trong PowerPoint cho phép bạn chuyển tới và đi từ các slide, phần và đoạn cụ thể của bài thuyết trình. Khi bạn đang trình bày, khả năng điều hướng nhanh chóng qua nội dung này có thể rất hữu ích. 

![overview_image](overview.png)

* Để tóm tắt toàn bộ bài thuyết trình trên một slide duy nhất, sử dụng [Summary Zoom](#Summary-Zoom).
* Để chỉ hiển thị các slide đã chọn, sử dụng [Slide Zoom](#Slide-Zoom).
* Để chỉ hiển thị một phần duy nhất, sử dụng [Section Zoom](#Section-Zoom).

## **Zoom Slide**

Zoom slide giúp bạn đi sâu vào nhiều thông tin đồng thời cảm giác như đang làm việc trên một bức tranh duy nhất. 

![overview_image](slidezoomsel.png)

Aspose.Slides cung cấp enumeration [ZoomImageType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ZoomImageType), lớp [ZoomFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ZoomFrame), và một số phương thức trong lớp [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection).

### **Tạo Khung Zoom**

Bạn có thể thêm một khung zoom vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2.	Tạo các slide mới mà bạn dự định liên kết các khung zoom. 
3.	Thêm văn bản nhận dạng và nền cho các slide đã tạo.
4.	Thêm các khung zoom (chứa tham chiếu tới các slide đã tạo) vào slide đầu tiên.
5.	Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Thêm slide mới vào bản trình chiếu
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Tạo nền cho slide thứ hai
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Tạo hộp văn bản cho slide thứ hai
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Tạo nền cho slide thứ ba
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Tạo hộp văn bản cho slide thứ ba
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Thêm các đối tượng ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Lưu bản trình chiếu
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo Khung Zoom với Hình Ảnh Tùy Chỉnh**

Với Aspose.Slides for Node.js via Java, bạn có thể tạo một khung zoom với một hình ảnh xem trước slide khác nhau theo cách sau:
1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2.	Tạo một slide mới mà bạn dự định liên kết với khung zoom. 
3.	Thêm văn bản nhận dạng và nền cho slide.
4.	Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PPImage) bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) sẽ được dùng để lấp đầy khung.
5.	Thêm các khung zoom (chứa tham chiếu tới slide đã tạo) vào slide đầu tiên.
6.	Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Thêm một slide mới vào bản trình chiếu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Tạo nền cho slide thứ hai
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Tạo hộp văn bản cho slide thứ ba
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Tạo hình ảnh mới cho đối tượng zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Thêm đối tượng ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Lưu bản trình chiếu
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Định Dạng Khung Zoom**

Bạn có thể kiểm soát định dạng của một khung zoom trên slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2.	Tạo các slide mới để liên kết mà bạn dự định liên kết khung zoom. 
3.	Thêm một số văn bản nhận dạng và nền cho các slide đã tạo.
4.	Thêm các khung zoom (chứa tham chiếu tới các slide đã tạo) vào slide đầu tiên.
5.	Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PPImage) bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) sẽ được dùng để lấp đầy khung.
6.	Đặt hình ảnh tùy chỉnh cho đối tượng khung zoom đầu tiên.
7.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
8.	Xóa nền khỏi hình ảnh của đối tượng khung zoom thứ hai.
9.	Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Thêm các slide mới vào bản trình chiếu
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Tạo nền cho slide thứ hai
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Tạo hộp văn bản cho slide thứ hai
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Tạo nền cho slide thứ ba
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Tạo hộp văn bản cho slide thứ ba
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Thêm các đối tượng ZoomFrame
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Tạo hình ảnh mới cho đối tượng zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Đặt hình ảnh tùy chỉnh cho đối tượng zoomFrame1
    zoomFrame1.setImage(picture);
    // Đặt định dạng khung zoom cho đối tượng zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Cài đặt không hiển thị nền cho đối tượng zoomFrame2
    zoomFrame2.setShowBackground(false);
    // Lưu bản trình chiếu
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zoom Phần**

Zoom phần là một liên kết tới một phần trong bài thuyết trình của bạn. Bạn có thể sử dụng zoom phần để quay lại các phần mà bạn muốn nhấn mạnh thực sự. Hoặc bạn có thể dùng chúng để làm nổi bật cách các phần của bài thuyết trình kết nối với nhau. 

![overview_image](seczoomsel.png)

Aspose.Slides cung cấp lớp [SectionZoomFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SectionZoomFrame) và một số phương thức trong lớp [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection).

### **Tạo Khung Zoom Phần**

Bạn có thể thêm một khung zoom phần vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2.	Tạo một slide mới. 
3.	Thêm nền nhận dạng cho slide đã tạo.
4.	Tạo một phần mới mà bạn dự định liên kết khung zoom. 
5.	Thêm một khung zoom phần (chứa tham chiếu tới phần đã tạo) vào slide đầu tiên.
6.	Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Thêm một slide mới vào bản trình chiếu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Thêm một phần mới vào bản trình chiếu
    pres.getSections().addSection("Section 1", slide);
    // Thêm một đối tượng SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Lưu bản trình chiếu
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tạo Khung Zoom Phần với Hình Ảnh Tùy Chỉnh**

Sử dụng Aspose.Slides for Node.js via Java, bạn có thể tạo một khung zoom phần với một hình ảnh xem trước slide khác nhau theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2.	Tạo một slide mới.
3.	Thêm nền nhận dạng cho slide đã tạo.
4.	Tạo một phần mới mà bạn dự định liên kết khung zoom. 
5.	Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PPImage) bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) sẽ được dùng để lấp đầy khung.
6.	Thêm một khung zoom phần (chứa tham chiếu tới phần đã tạo) vào slide đầu tiên.
7.	Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Thêm slide mới vào bản trình chiếu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Thêm một phần mới vào bản trình chiếu
    pres.getSections().addSection("Section 1", slide);
    // Tạo hình ảnh mới cho đối tượng zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Thêm đối tượng SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Lưu bản trình chiếu
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Định Dạng Khung Zoom Phần**

Bạn có thể kiểm soát định dạng của một khung zoom phần trên slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2.	Tạo một slide mới.
3.	Thêm nền nhận dạng cho slide đã tạo.
4.	Tạo một phần mới mà bạn dự định liên kết khung zoom. 
5.	Thêm một khung zoom phần (chứa tham chiếu tới phần đã tạo) vào slide đầu tiên.
6.	Thay đổi kích thước và vị trí cho đối tượng zoom phần đã tạo.
7.	Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PPImage) bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) sẽ được dùng để lấp đầy khung.
8.	Đặt hình ảnh tùy chỉnh cho đối tượng khung zoom phần đã tạo.
9.	Đặt khả năng *trở lại slide gốc từ phần đã liên kết*.
10.	Xóa nền khỏi hình ảnh của đối tượng khung zoom phần.
11.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
12.	Thay đổi thời lượng chuyển đổi.
13.	Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Thêm một slide mới vào bản trình chiếu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Thêm một phần mới vào bản trình chiếu
    pres.getSections().addSection("Section 1", slide);
    // Thêm đối tượng SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Định dạng cho SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Lưu bản trình chiếu
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zoom Tổng Kết**

Zoom tổng kết giống như một trang đích nơi tất cả các phần của bài thuyết trình được hiển thị cùng lúc. Khi bạn đang trình bày, bạn có thể sử dụng zoom để đi từ một vị trí trong bài thuyết trình tới vị trí khác theo bất kỳ thứ tự nào bạn muốn. Bạn có thể sáng tạo, bỏ qua, hoặc quay lại các phần của slide show mà không làm gián đoạn luồng trình bày.

![overview_image](sumzoomsel.png)

Aspose.Slides cung cấp lớp [SummaryZoomFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SummaryZoomSection), và [SummaryZoomSectionCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SummaryZoomSectionCollection) và một số phương thức trong lớp [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection).

### **Tạo Zoom Tổng Kết**

Bạn có thể thêm một khung zoom tổng kết vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm khung zoom tổng kết vào slide đầu tiên.
4.	Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Thêm một slide mới vào bản trình chiếu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Thêm một phần mới vào bản trình chiếu
    pres.getSections().addSection("Section 1", slide);
    // Thêm một slide mới vào bản trình chiếu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Thêm một phần mới vào bản trình chiếu
    pres.getSections().addSection("Section 2", slide);
    // Thêm một slide mới vào bản trình chiếu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Thêm một phần mới vào bản trình chiếu
    pres.getSections().addSection("Section 3", slide);
    // Thêm một slide mới vào bản trình chiếu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Thêm một phần mới vào bản trình chiếu
    pres.getSections().addSection("Section 4", slide);
    // Thêm một đối tượng SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Lưu bản trình chiếu
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Thêm và Xóa Phần Zoom Tổng Kết**

Tất cả các phần trong một khung zoom tổng kết được biểu diễn bởi các đối tượng [SummaryZoomSection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SummaryZoomSection), được lưu trong đối tượng [SummaryZoomSectionCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SummaryZoomSectionCollection). Bạn có thể thêm hoặc xóa một đối tượng phần zoom tổng kết thông qua lớp [SummaryZoomSectionCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SummaryZoomSectionCollection) theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm khung zoom tổng kết vào slide đầu tiên.
4.	Thêm một slide và một phần mới vào bài thuyết trình.
5.	Thêm phần đã tạo vào khung zoom tổng kết.
6.	Xóa phần đầu tiên khỏi khung zoom tổng kết.
7.	Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Thêm một slide mới vào bản trình chiếu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Thêm một phần mới vào bản trình chiếu
    pres.getSections().addSection("Section 1", slide);
    // Thêm một slide mới vào bản trình chiếu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Thêm một phần mới vào bản trình chiếu
    pres.getSections().addSection("Section 2", slide);
    // Thêm một đối tượng SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Thêm một slide mới vào bản trình chiếu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Thêm một phần mới vào bản trình chiếu
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Thêm một phần vào Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Xóa phần khỏi Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Lưu bản trình chiếu
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Định Dạng Các Phần Zoom Tổng Kết**

Bạn có thể kiểm soát định dạng cho một đối tượng phần zoom tổng kết trong khung zoom tổng kết theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm khung zoom tổng kết vào slide đầu tiên.
4.	Lấy một đối tượng phần zoom tổng kết cho đối tượng đầu tiên từ `ISummaryZoomSectionCollection`.
5.	Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PPImage) bằng cách thêm một hình ảnh vào bộ sưu tập images liên kết với đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) sẽ được dùng để lấp đầy khung.
6.	Đặt hình ảnh tùy chỉnh cho đối tượng khung zoom phần đã tạo.
7.	Đặt khả năng *trở lại slide gốc từ phần đã liên kết*.
8.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
9.	Thay đổi thời lượng chuyển đổi.
10.	Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Thêm một slide mới vào bản trình chiếu
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Thêm một phần mới vào bản trình chiếu
    pres.getSections().addSection("Section 1", slide);
    // Thêm một slide mới vào bản trình chiếu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Thêm một phần mới vào bản trình chiếu
    pres.getSections().addSection("Section 2", slide);
    // Thêm một đối tượng SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Lấy đối tượng SummaryZoomSection đầu tiên
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Định dạng cho đối tượng SummaryZoomSection
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Lưu bản trình chiếu
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Tôi có thể kiểm soát việc quay lại slide 'cha' sau khi hiển thị mục tiêu không?**

Có. [Zoom frame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zoomframe/) hoặc [section](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sectionzoomframe/) có phương thức `setReturnToParent` mà khi được bật, sẽ đưa người xem trở lại slide gốc sau khi họ truy cập nội dung mục tiêu.

**Tôi có thể điều chỉnh 'tốc độ' hoặc thời lượng của chuyển đổi Zoom không?**

Có. Zoom cung cấp phương thức `setTransitionDuration` để bạn có thể kiểm soát thời gian của hiệu ứng chuyển đổi.

**Có giới hạn về số lượng đối tượng Zoom mà một bản thuyết trình có thể chứa không?**

Không có giới hạn API cứng nào được ghi chép. Giới hạn thực tế phụ thuộc vào độ phức tạp tổng thể của bản thuyết trình và hiệu năng của người xem. Bạn có thể thêm nhiều khung Zoom, nhưng nên cân nhắc kích thước tệp và thời gian render.