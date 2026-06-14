---
title: Quản lý Đồ họa SmartArt trong Bản trình chiếu trên Android
linktitle: Đồ họa SmartArt
type: docs
weight: 20
url: /vi/androidjava/manage-smartart-shape/
keywords:
- đối tượng SmartArt
- đồ họa SmartArt
- kiểu SmartArt
- màu SmartArt
- tạo SmartArt
- thêm SmartArt
- chỉnh sửa SmartArt
- thay đổi SmartArt
- truy cập SmartArt
- loại bố cục SmartArt
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tự động tạo, chỉnh sửa và tạo kiểu SmartArt trong PowerPoint bằng Aspose.Slides cho Android, cung cấp các ví dụ mã Java ngắn gọn và hướng dẫn tập trung vào hiệu năng."
---
## **Tổng quan**

Aspose.Slides cho phép bạn tạo và quản lý đồ họa SmartArt trong các bản trình bày PowerPoint một cách lập trình. Bài viết này giải thích cách thêm một hình dạng SmartArt vào slide, truy cập các hình SmartArt hiện có, tìm SmartArt theo một loại bố cục cụ thể, và cập nhật giao diện hiển thị của nó bằng cách thay đổi style SmartArt hoặc color style.

Các ví dụ cho thấy cách làm việc với các hình SmartArt thông qua bộ sưu tập shape của slide trình chiếu, kiểm tra xem một shape có phải là SmartArt hay không và sau đó sửa đổi hoặc kiểm tra các thuộc tính của nó.

## **Tạo một hình SmartArt**
Aspose.Slides for Android via Java đã cung cấp API để tạo các hình SmartArt. Để tạo một hình SmartArt trong slide, vui lòng thực hiện các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
1. [Thêm một hình SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) bằng cách thiết lập nó [LayoutType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArtLayoutType).
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Thêm hình Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Lưu bản trình chiếu
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Hình: Hình SmartArt được thêm vào slide**|

## **Truy cập một hình SmartArt trên Slide**
Mã sau sẽ được sử dụng để truy cập các hình SmartArt đã được thêm vào slide trình chiếu. Trong mã mẫu, chúng ta sẽ duyệt qua mọi shape trong slide và kiểm tra xem nó có phải là một shape [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArt) hay không. Nếu shape là loại SmartArt thì chúng ta sẽ chuyển đổi kiểu nó thành một thể hiện [**SmartArt**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArt) .

```java
// Tải bản trình chiếu mong muốn
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Duyệt qua mọi shape trong slide đầu tiên
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Kiểm tra xem shape có phải là loại SmartArt không
        if (shape instanceof ISmartArt)
        {
            // Ép kiểu shape sang SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập một hình SmartArt với một LayoutType cụ thể**
Mã mẫu sau sẽ giúp truy cập shape [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArt) với LayoutType cụ thể. Lưu ý rằng bạn không thể thay đổi LayoutType của SmartArt vì nó chỉ đọc và chỉ được đặt khi shape [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArt) được thêm vào.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) và tải bản trình chiếu có chứa Shape SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
1. Duyệt qua mọi shape trong slide đầu tiên.
1. Kiểm tra xem shape có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArt) không và chuyển đổi kiểu shape đã chọn sang SmartArt nếu nó là SmartArt.
1. Kiểm tra shape SmartArt với LayoutType cụ thể và thực hiện các thao tác cần thiết sau đó.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Duyệt qua mọi shape trong slide đầu tiên
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Kiểm tra xem shape có phải là loại SmartArt không
        if (shape instanceof ISmartArt)
        {
            // Ép kiểu shape sang SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Kiểm tra Layout SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay đổi Style của hình SmartArt**
Trong ví dụ này, chúng ta sẽ học cách thay đổi style nhanh cho bất kỳ hình SmartArt nào.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) và tải bản trình chiếu có chứa Shape SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
1. Duyệt qua mọi shape trong slide đầu tiên.
1. Kiểm tra xem shape có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArt) không và chuyển đổi kiểu shape đã chọn sang SmartArt nếu nó là SmartArt.
1. Tìm shape SmartArt có Style cụ thể.
1. Đặt Style mới cho shape SmartArt.
1. Lưu bản trình chiếu.

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Lấy slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Duyệt qua mọi shape trong slide đầu tiên
    for (IShape shape : slide.getShapes()) 
    {
        // Kiểm tra xem shape có phải là loại SmartArt không
        if (shape instanceof ISmartArt) 
        {
            // Ép kiểu shape sang SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Kiểm tra style SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Thay đổi style SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Lưu bản trình chiếu
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Hình: Hình SmartArt với Style đã thay đổi**|

## **Thay đổi Color Style của hình SmartArt**
Trong ví dụ này, chúng ta sẽ học cách thay đổi color style cho bất kỳ hình SmartArt nào. Trong mã mẫu sau sẽ truy cập shape SmartArt với color style cụ thể và thay đổi style của nó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) và tải bản trình chiếu có chứa Shape SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
1. Duyệt qua mọi shape trong slide đầu tiên.
1. Kiểm tra xem shape có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArt) không và chuyển đổi kiểu shape đã chọn sang SmartArt nếu nó là SmartArt.
1. Tìm shape SmartArt có Color Style cụ thể.
1. Đặt Color Style mới cho shape SmartArt.
1. Lưu bản trình chiếu.

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Lấy slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Duyệt qua mọi shape trong slide đầu tiên
    for (IShape shape : slide.getShapes()) 
    {
        // Kiểm tra xem shape có phải là loại SmartArt không
        if (shape instanceof ISmartArt) 
        {
            // Ép kiểu shape sang SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Kiểm tra loại màu SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Thay đổi loại màu SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Lưu bản trình chiếu
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Hình: Hình SmartArt với Color Style đã thay đổi**|

## **Câu hỏi thường gặp**

**Tôi có thể tạo hoạt ảnh cho SmartArt như một đối tượng duy nhất không?**

Có. SmartArt là một shape, do đó bạn có thể áp dụng [standard animations](/slides/vi/androidjava/powerpoint-animation/) qua API hoạt ảnh (entrance, exit, emphasis, motion paths) giống như các shape khác.

**Làm thế nào tôi có thể tìm một SmartArt cụ thể trên slide nếu tôi không biết ID nội bộ của nó?**

Đặt và sử dụng Alternative Text (AltText) và tìm kiếm shape bằng giá trị đó — đây là cách được khuyến nghị để xác định shape mục tiêu.

**Tôi có thể nhóm SmartArt với các shape khác không?**

Có. Bạn có thể nhóm SmartArt với các shape khác (hình ảnh, bảng, v.v.) và sau đó [manipulate the group](/slides/vi/androidjava/group/).

**Làm sao tôi lấy hình ảnh của một SmartArt cụ thể (ví dụ, để xem trước hoặc báo cáo)?**

Xuất thumbnail/hình ảnh của shape; thư viện có thể [render individual shapes](/slides/vi/androidjava/create-shape-thumbnails/) thành các tệp raster (PNG/JPG/TIFF).

**Giao diện SmartArt có được giữ nguyên khi chuyển đổi toàn bộ bản trình chiếu sang PDF không?**

Có. Engine render nhắm tới độ trung thực cao cho [PDF export](/slides/vi/androidjava/convert-powerpoint-to-pdf/), với nhiều tùy chọn về chất lượng và khả năng tương thích.