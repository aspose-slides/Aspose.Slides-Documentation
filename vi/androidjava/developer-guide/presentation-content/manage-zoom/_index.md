---
title: Quản lý Zoom cho Bản trình chiếu trên Android
linktitle: Quản lý Zoom
type: docs
weight: 60
url: /vi/androidjava/manage-zoom/
keywords:
- thu phóng
- khung zoom
- zoom slide
- zoom phần
- zoom tóm tắt
- thêm zoom
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh Zoom với Aspose.Slides cho Android qua Java — chuyển đổi giữa các phần, thêm ảnh thu nhỏ và chuyển tiếp trong các bản trình chiếu PPT, PPTX và ODP."
---
## **Giới thiệu**

Zoom trong PowerPoint cho phép bạn chuyển đến và quay lại các slide, phần và đoạn cụ thể của bản trình chiếu. Khi đang thuyết trình, khả năng điều hướng nhanh chóng qua nội dung này có thể rất hữu ích. 

![hình_đánh_giá_overview](overview.png)

* Để tóm tắt toàn bộ bản trình chiếu trên một slide duy nhất, sử dụng [Zoom Tóm Tắt](#Summary-Zoom).
* Để hiển thị chỉ các slide được chọn, sử dụng [Zoom Slide](#Slide-Zoom).
* Để hiển thị chỉ một phần cụ thể, sử dụng [Zoom Phần](#Section-Zoom).

## **Zoom Slide**
Zoom slide có thể làm cho bài thuyết trình của bạn năng động hơn, cho phép bạn điều hướng tự do giữa các slide theo bất kỳ thứ tự nào mà không làm gián đoạn luồng trình chiếu. Zoom slide rất phù hợp cho các bản thuyết trình ngắn không có nhiều phần, nhưng bạn vẫn có thể sử dụng chúng trong các kịch bản trình chiếu khác nhau.

Zoom slide giúp bạn đào sâu vào nhiều thông tin khác nhau trong khi vẫn cảm giác như đang ở trên một nền duy nhất. 

![hình_đánh_giá_slidezoomsel](slidezoomsel.png)

Đối với các đối tượng zoom slide, Aspose.Slides cung cấp enum [ZoomImageType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ZoomImageType), giao diện [IZoomFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IZoomFrame) và một số phương thức dưới giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection).

### **Tạo khung Zoom**

Bạn có thể thêm một khung zoom vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2.	Tạo các slide mới mà bạn dự định liên kết với các khung zoom. 
3.	Thêm văn bản nhận dạng và nền cho các slide đã tạo.
4.	Thêm các khung zoom (chứa các tham chiếu tới các slide đã tạo) vào slide đầu tiên.
5.	Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java này cho bạn thấy cách tạo một khung zoom trên slide:

``` java
Presentation pres = new Presentation();
try {
    //Thêm các slide mới vào bản trình chiếu
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Tạo nền cho slide thứ hai
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Tạo hộp văn bản cho slide thứ hai
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Tạo nền cho slide thứ ba
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Tạo hộp văn bản cho slide thứ ba
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Thêm các đối tượng ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Lưu bản trình chiếu
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Tạo khung Zoom với hình ảnh tùy chỉnh**
Với Aspose.Slides cho Android qua Java, bạn có thể tạo một khung zoom với hình ảnh xem trước slide khác nhau như sau:
1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2.	Tạo một slide mới mà bạn dự định liên kết với khung zoom. 
3.	Thêm văn bản nhận dạng và nền cho slide.
4.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPPImage) bằng cách thêm hình ảnh vào bộ sưu tập Images của đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) sẽ được dùng để lấp khung.
5.	Thêm các khung zoom (chứa tham chiếu tới slide đã tạo) vào slide đầu tiên.
6.	Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java này cho bạn thấy cách tạo một khung zoom với hình ảnh khác:

``` java
Presentation pres = new Presentation();
try {
    //Thêm một slide mới vào bản trình chiếu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Tạo nền cho slide thứ hai
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Tạo hộp văn bản cho slide thứ ba
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Tạo một hình ảnh mới cho đối tượng zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Thêm đối tượng ZoomFrame object
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Lưu bản trình chiếu
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Định dạng khung Zoom**
Trong các phần trước, chúng tôi đã cho bạn thấy cách tạo các khung zoom đơn giản. Để tạo các khung zoom phức tạp hơn, bạn cần thay đổi định dạng của một khung đơn giản. Có một số tùy chọn định dạng bạn có thể áp dụng cho một khung zoom. 

Bạn có thể kiểm soát định dạng của khung zoom trên slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2.	Tạo các slide mới để liên kết tới chúng mà bạn dự định liên kết khung zoom. 
3.	Thêm một số văn bản nhận dạng và nền cho các slide đã tạo.
4.	Thêm các khung zoom (chứa các tham chiếu tới các slide đã tạo) vào slide đầu tiên.
5.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPPImage) bằng cách thêm hình ảnh vào bộ sưu tập Images của đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) sẽ được dùng để lấp khung.
6.	Đặt hình ảnh tùy chỉnh cho đối tượng khung zoom đầu tiên.
7.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
8.	Xóa nền khỏi hình ảnh của đối tượng khung zoom thứ hai.
5.	Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java này cho bạn thấy cách thay đổi định dạng của khung zoom trên slide: 

``` java 
Presentation pres = new Presentation();
try {
    //Thêm các slide mới vào bản trình chiếu
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Tạo nền cho slide thứ hai
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Tạo hộp văn bản cho slide thứ hai
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Tạo nền cho slide thứ ba
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Tạo hộp văn bản cho slide thứ ba
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Thêm các đối tượng ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Tạo một hình ảnh mới cho đối tượng zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Đặt ảnh tùy chỉnh cho đối tượng zoomFrame1
    zoomFrame1.setImage(picture);

    // Đặt định dạng khung zoom cho đối tượng zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Cài đặt để không hiển thị nền cho đối tượng zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Lưu bản trình chiếu
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom Phần**

Zoom phần là một liên kết tới một phần trong bản trình chiếu của bạn. Bạn có thể sử dụng zoom phần để quay lại các phần bạn muốn nhấn mạnh. Hoặc bạn có thể dùng chúng để làm nổi bật cách các phần của bản trình chiếu kết nối với nhau. 

![hình_đánh_giá_seczoomsel](seczoomsel.png)

Đối với các đối tượng zoom phần, Aspose.Slides cung cấp giao diện [ISectionZoomFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISectionZoomFrame) và một số phương thức dưới giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection).

### **Tạo khung Zoom Phần**

Bạn có thể thêm một khung zoom phần vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2.	Tạo một slide mới. 
3.	Thêm nền nhận dạng cho slide đã tạo.
4.	Tạo một phần mới mà bạn dự định liên kết với khung zoom. 
5.	Thêm một khung zoom phần (chứa các tham chiếu tới phần đã tạo) vào slide đầu tiên.
6.	Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java này cho bạn thấy cách tạo một khung zoom trên slide:

``` java
Presentation pres = new Presentation();
try {
    //Thêm một slide mới vào bản trình chiếu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Thêm một Section mới vào bản trình chiếu
    pres.getSections().addSection("Section 1", slide);

    // Thêm một đối tượng SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Lưu bản trình chiếu
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Tạo khung Zoom Phần với hình ảnh tùy chỉnh**

Sử dụng Aspose.Slides cho Android qua Java, bạn có thể tạo một khung zoom phần với hình ảnh xem trước slide khác nhau như sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2.	Tạo một slide mới.
3.	Thêm nền nhận dạng cho slide đã tạo.
4.	Tạo một phần mới mà bạn dự định liên kết với khung zoom. 
5.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPPImage) bằng cách thêm hình ảnh vào bộ sưu tập Images của đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) sẽ được dùng để lấp khung.
5.	Thêm một khung zoom phần (chứa một tham chiếu tới phần đã tạo) vào slide đầu tiên.
6.	Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java này cho bạn thấy cách tạo một khung zoom với hình ảnh khác:

``` java 
Presentation pres = new Presentation();
try {
    //Thêm một slide mới vào bản trình chiếu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Thêm một Section mới vào bản trình chiếu
    pres.getSections().addSection("Section 1", slide);

    // Tạo một hình ảnh mới cho đối tượng zoom
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Thêm đối tượng SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Lưu bản trình chiếu
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Định dạng khung Zoom Phần**

Để tạo các khung zoom phần phức tạp hơn, bạn phải thay đổi định dạng của một khung đơn giản. Có một số tùy chọn định dạng bạn có thể áp dụng cho một khung zoom phần. 

Bạn có thể kiểm soát định dạng của khung zoom phần trên slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2.	Tạo một slide mới.
3.	Thêm nền nhận dạng cho slide đã tạo.
4.	Tạo một phần mới mà bạn dự định liên kết với khung zoom. 
5.	Thêm một khung zoom phần (chứa các tham chiếu tới phần đã tạo) vào slide đầu tiên.
6.	Thay đổi kích thước và vị trí cho đối tượng zoom phần đã tạo.
7.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPPImage) bằng cách thêm hình ảnh vào bộ sưu tập Images của đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) sẽ được dùng để lấp khung.
8.	Đặt hình ảnh tùy chỉnh cho đối tượng khung zoom phần đã tạo.
9.	Đặt khả năng *trở về slide gốc từ phần đã liên kết*. 
10.	Xóa nền khỏi hình ảnh của đối tượng khung zoom phần.
11.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
12.	Thay đổi thời gian chuyển đổi.
13.	Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java này cho bạn thấy cách thay đổi định dạng của khung zoom phần:

``` java
Presentation pres = new Presentation();
try {
    // Thêm một slide mới vào bản trình chiếu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Thêm một Section mới vào bản trình chiếu
    pres.getSections().addSection("Section 1", slide);

    // Thêm đối tượng SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Định dạng cho SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Lưu bản trình chiếu
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zoom Tóm Tắt**

Zoom tóm tắt giống như một trang đích nơi tất cả các phần của bản trình chiếu được hiển thị cùng lúc. Khi bạn đang thuyết trình, bạn có thể sử dụng zoom để chuyển từ một vị trí này sang vị trí khác trong bất kỳ thứ tự nào bạn muốn. Bạn có thể sáng tạo, bỏ qua hoặc quay lại các phần của slide mà không làm gián đoạn luồng trình chiếu.

![hình_đánh_giá_sumzoomsel](sumzoomsel.png)

Đối với các đối tượng zoom tóm tắt, Aspose.Slides cung cấp các giao diện [ISummaryZoomFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISummaryZoomSection) và [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) cùng một số phương thức dưới giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection).

### **Tạo Zoom Tóm Tắt**

Bạn có thể thêm một khung zoom tóm tắt vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm khung zoom tóm tắt vào slide đầu tiên.
4.	Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java này cho bạn thấy cách tạo một khung zoom tóm tắt trên slide:

``` java 
Presentation pres = new Presentation();
try {
    //Thêm một slide mới vào bản trình chiếu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Thêm một Section mới vào bản trình chiếu
    pres.getSections().addSection("Section 1", slide);

    //Thêm một slide mới vào bản trình chiếu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Thêm một Section mới vào bản trình chiếu
    pres.getSections().addSection("Section 2", slide);

    //Thêm một slide mới vào bản trình chiếu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Thêm một Section mới vào bản trình chiếu
    pres.getSections().addSection("Section 3", slide);

    //Thêm một slide mới vào bản trình chiếu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Thêm một Section mới vào bản trình chiếu
    pres.getSections().addSection("Section 4", slide);

    // Thêm một đối tượng SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Lưu bản trình chiếu
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Thêm và Xóa một Phần Zoom Tóm Tắt**

Tất cả các phần trong một khung zoom tóm tắt được biểu diễn bằng các đối tượng [ISummaryZoomSection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISummaryZoomSection), được lưu trong đối tượng [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). Bạn có thể thêm hoặc xóa một đối tượng phần zoom tóm tắt thông qua giao diện [ISummaryZoomSectionCollection] này:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm một khung zoom tóm tắt vào slide đầu tiên.
4.	Thêm một slide và một phần mới vào bản trình chiếu.
5.	Thêm phần đã tạo vào khung zoom tóm tắt.
6.	Xóa phần đầu tiên khỏi khung zoom tóm tắt.
7.	Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java này cho bạn thấy cách thêm và xóa các phần trong khung zoom tóm tắt:

``` java
Presentation pres = new Presentation();
try {
    //Thêm một slide mới vào bản trình chiếu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Thêm một section mới vào bản trình chiếu
    pres.getSections().addSection("Section 1", slide);

    //Thêm một slide mới vào bản trình chiếu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Thêm một section mới vào bản trình chiếu
    pres.getSections().addSection("Section 2", slide);

    // Thêm đối tượng SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Thêm một slide mới vào bản trình chiếu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Thêm một section mới vào bản trình chiếu
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Thêm một section vào Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Xóa section khỏi Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Lưu bản trình chiếu
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Định dạng các Phần Zoom Tóm Tắt**

Để tạo các đối tượng phần zoom tóm tắt phức tạp hơn, bạn phải thay đổi định dạng của một khung đơn giản. Có một số tùy chọn định dạng bạn có thể áp dụng cho một đối tượng phần zoom tóm tắt. 

Bạn có thể kiểm soát định dạng cho một đối tượng phần zoom tóm tắt trong khung zoom tóm tắt theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm một khung zoom tóm tắt vào slide đầu tiên.
4.	Lấy một đối tượng phần zoom tóm tắt cho đối tượng đầu tiên từ `ISummaryZoomSectionCollection`.
7.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPPImage) bằng cách thêm hình ảnh vào bộ sưu tập images của đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) sẽ được dùng để lấp khung.
8.	Đặt hình ảnh tùy chỉnh cho đối tượng khung zoom phần đã tạo.
9.	Đặt khả năng *trở về slide gốc từ phần đã liên kết*. 
11.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
12.	Thay đổi thời gian chuyển đổi.
13.	Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java này cho bạn thấy cách thay đổi định dạng cho một đối tượng phần zoom tóm tắt:

``` java
Presentation pres = new Presentation();
try {
    //Thêm một slide mới vào bản trình chiếu
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Thêm một section mới vào bản trình chiếu
    pres.getSections().addSection("Section 1", slide);

    //Thêm một slide mới vào bản trình chiếu
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Thêm một section mới vào bản trình chiếu
    pres.getSections().addSection("Section 2", slide);

    //Thêm một đối tượng SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Lấy đối tượng SummaryZoomSection đầu tiên
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    //Định dạng cho đối tượng SummaryZoomSection
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    //Lưu bản trình chiếu
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát việc quay lại slide “cha” sau khi hiển thị mục tiêu không?**

Có. [Khung Zoom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zoomframe/) hoặc [phần](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sectionzoomframe/) có hành vi quay lại cha mà khi được bật sẽ đưa người xem trở lại slide gốc sau khi họ truy cập nội dung đích.

**Tôi có thể điều chỉnh “tốc độ” hoặc thời gian của chuyển đổi Zoom không?**

Có. Zoom hỗ trợ thiết lập thời gian chuyển đổi để bạn có thể kiểm soát thời lượng của hoạt ảnh nhảy.

**Có giới hạn số lượng đối tượng Zoom mà một bản trình chiếu có thể chứa không?**

Không có giới hạn API cứng được tài liệu hoá. Giới hạn thực tế phụ thuộc vào độ phức tạp tổng thể của bản trình chiếu và hiệu năng của thiết bị người xem. Bạn có thể thêm nhiều khung Zoom, nhưng nên cân nhắc kích thước tệp và thời gian render.