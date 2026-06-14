---
title: Quản lý Đồ họa SmartArt trong Bản trình bày bằng Java
linktitle: Đồ họa SmartArt
type: docs
weight: 20
url: /vi/java/manage-smartart-shape/
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
- bản trình bày
- Java
- Aspose.Slides
description: "Tự động tạo, chỉnh sửa và tạo kiểu SmartArt trong PowerPoint bằng Java sử dụng Aspose.Slides, với các ví dụ mã ngắn gọn và hướng dẫn tập trung vào hiệu năng."
---
## **Tổng quan**

Aspose.Slides cho phép bạn tạo và quản lý đồ họa SmartArt trong các bản trình bày PowerPoint một cách lập trình. Bài viết này giải thích cách thêm một hình SmartArt vào slide, truy cập các hình SmartArt đã tồn tại, tìm SmartArt theo một loại bố cục cụ thể, và cập nhật giao diện hiển thị của nó bằng cách thay đổi kiểu SmartArt hoặc kiểu màu.

Các ví dụ minh họa cách làm việc với các hình SmartArt thông qua bộ sưu tập hình dạng của slide trong bản trình bày, kiểm tra xem một hình dạng có phải là SmartArt không và sau đó sửa đổi hoặc kiểm tra các thuộc tính của nó.

## **Tạo một hình SmartArt**

Aspose.Slides for Java đã cung cấp một API để tạo các hình SmartArt. Để tạo một hình SmartArt trong slide, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
3. [Thêm một hình SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) bằng cách đặt [LayoutType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArtLayoutType).
4. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Thêm hình Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Lưu bản trình bày
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Hình: Hình SmartArt được thêm vào slide**|

## **Truy cập một hình SmartArt trên slide**

Mã sau sẽ được sử dụng để truy cập các hình SmartArt đã được thêm vào slide trong bản trình bày. Trong mã mẫu, chúng ta sẽ duyệt qua từng hình trong slide và kiểm tra xem nó có phải là hình [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArt) hay không. Nếu hình là loại SmartArt thì chúng ta sẽ ép kiểu nó thành một thực thể [**SmartArt**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArt).

```java
// Tải bản trình bày mong muốn
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Duyệt qua mọi hình trong slide đầu tiên
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Kiểm tra xem hình có phải là loại SmartArt không
        if (shape instanceof ISmartArt)
        {
            // Ép kiểu hình thành SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập một hình SmartArt với loại Layout nhất định**

Mã mẫu sau sẽ giúp truy cập hình [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArt) với LayoutType cụ thể. Lưu ý rằng bạn không thể thay đổi LayoutType của SmartArt vì nó chỉ đọc được và chỉ được đặt khi hình [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArt) được thêm vào.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) và tải bản trình bày có hình SmartArt.
2. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
3. Duyệt qua từng hình trong slide đầu tiên.
4. Kiểm tra xem hình có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArt) không và ép kiểu hình được chọn thành SmartArt nếu đúng.
5. Kiểm tra hình SmartArt với LayoutType cụ thể và thực hiện những thao tác cần thiết sau đó.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Duyệt qua mọi hình trong slide đầu tiên
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Kiểm tra xem hình có phải là loại SmartArt không
        if (shape instanceof ISmartArt)
        {
            // Ép kiểu hình thành SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Kiểm tra bố cục SmartArt
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

## **Thay đổi Kiểu dáng Hình SmartArt**

Trong ví dụ này, chúng ta sẽ học cách thay đổi kiểu nhanh cho bất kỳ hình SmartArt nào.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) và tải bản trình bày có hình SmartArt.
2. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
3. Duyệt qua từng hình trong slide đầu tiên.
4. Kiểm tra xem hình có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArt) không và ép kiểu hình được chọn thành SmartArt nếu đúng.
5. Tìm hình SmartArt với Kiểu cụ thể.
6. Đặt Kiểu mới cho hình SmartArt.
7. Lưu bản trình bày.

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Lấy slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Duyệt qua mọi hình trong slide đầu tiên
    for (IShape shape : slide.getShapes()) 
    {
        // Kiểm tra xem hình có phải là loại SmartArt không
        if (shape instanceof ISmartArt) 
        {
            // Ép kiểu hình thành SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Kiểm tra kiểu SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Thay đổi kiểu SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Lưu bản trình bày
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Hình: Hình SmartArt với Kiểu đã thay đổi**|

## **Thay đổi Kiểu màu Hình SmartArt**

Trong ví dụ này, chúng ta sẽ học cách thay đổi kiểu màu cho bất kỳ hình SmartArt nào. Mã mẫu sau sẽ truy cập hình SmartArt với kiểu màu cụ thể và thay đổi kiểu của nó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) và tải bản trình bày có hình SmartArt.
2. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
3. Duyệt qua từng hình trong slide đầu tiên.
4. Kiểm tra xem hình có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArt) không và ép kiểu hình được chọn thành SmartArt nếu đúng.
5. Tìm hình SmartArt với Kiểu màu cụ thể.
6. Đặt Kiểu màu mới cho hình SmartArt.
7. Lưu bản trình bày.

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Lấy slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Duyệt qua mọi hình trong slide đầu tiên
    for (IShape shape : slide.getShapes()) 
    {
        // Kiểm tra xem hình có phải là loại SmartArt không
        if (shape instanceof ISmartArt) 
        {
            // Ép kiểu hình thành SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Kiểm tra loại màu SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Thay đổi loại màu SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Lưu bản trình bày
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Hình: Hình SmartArt với Kiểu màu đã thay đổi**|

## **Câu hỏi thường gặp**

**Tôi có thể hoạt hình SmartArt như một đối tượng duy nhất không?**

Có. SmartArt là một hình dạng, vì vậy bạn có thể áp dụng [standard animations](/slides/vi/java/powerpoint-animation/) thông qua API hoạt hình (đầu vào, thoát, nhấn mạnh, đường di chuyển) giống như với các hình dạng khác.

**Làm sao tôi có thể tìm một SmartArt cụ thể trên slide nếu tôi không biết ID nội bộ của nó?**

Đặt và sử dụng Văn bản thay thế (AltText) và tìm kiếm hình dạng bằng giá trị đó—đây là cách được khuyến nghị để xác định vị trí của hình mục tiêu.

**Tôi có thể nhóm SmartArt với các hình dạng khác không?**

Có. Bạn có thể nhóm SmartArt với các hình dạng khác (hình ảnh, bảng, v.v.) và sau đó [manipulate the group](/slides/vi/java/group/).

**Làm sao tôi lấy hình ảnh của một SmartArt cụ thể (ví dụ: để xem trước hoặc báo cáo)?**

Xuất ảnh thu nhỏ/hình ảnh của hình dạng; thư viện có thể [render individual shapes](/slides/vi/java/create-shape-thumbnails/) thành các tệp raster (PNG/JPG/TIFF).

**Giao diện SmartArt có được giữ nguyên khi chuyển đổi toàn bộ bản trình bày sang PDF không?**

Có. Engine render nhằm đạt độ trung thực cao cho [PDF export](/slides/vi/java/convert-powerpoint-to-pdf/), với nhiều tùy chọn về chất lượng và khả năng tương thích.