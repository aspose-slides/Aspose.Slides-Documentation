---
title: Quản lý Đồ họa SmartArt trong Bản trình bày bằng JavaScript
linktitle: Đồ họa SmartArt
type: docs
weight: 20
url: /vi/nodejs-java/manage-smartart-shape/
keywords:
- Đối tượng SmartArt
- Đồ họa SmartArt
- Kiểu SmartArt
- Màu SmartArt
- Tạo SmartArt
- Thêm SmartArt
- Chỉnh sửa SmartArt
- Thay đổi SmartArt
- Truy cập SmartArt
- Loại bố cục SmartArt
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tự động tạo, chỉnh sửa và định dạng SmartArt trong PowerPoint bằng JavaScript sử dụng Aspose.Slides, cung cấp các ví dụ mã ngắn gọn và hướng dẫn tập trung vào hiệu năng."
---
## **Tổng quan**

Aspose.Slides cho phép bạn tạo và quản lý đồ họa SmartArt trong các bản trình bày PowerPoint một cách lập trình. Bài viết này giải thích cách thêm một hình SmartArt vào một slide, truy cập các hình SmartArt hiện có, tìm SmartArt theo một loại bố cục cụ thể, và cập nhật giao diện trực quan của nó bằng cách thay đổi style SmartArt hoặc color style.

Các ví dụ cho thấy cách làm việc với các hình SmartArt thông qua bộ sưu tập hình dạng của slide bản trình bày, kiểm tra một hình có phải là SmartArt hay không và sau đó sửa đổi hoặc kiểm tra các thuộc tính của nó.

## **Tạo Hình SmartArt**
Aspose.Slides for Node.js via Java đã cung cấp một API để tạo các hình SmartArt. Để tạo một hình SmartArt trong một slide, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục Index của nó.
3. [Thêm một hình SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) bằng cách thiết lập nó [LayoutType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtLayoutType) .
4. Lưu bản trình bày đã sửa đổi dưới dạng file PPTX.

```javascript
// Khởi tạo lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Thêm hình Smart Art
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Lưu bản trình bày
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Hình: Hình SmartArt được thêm vào slide**|

## **Truy cập Hình SmartArt trong Slide**
Mã sau sẽ được sử dụng để truy cập các hình SmartArt được thêm vào slide bản trình bày. Trong mã mẫu chúng ta sẽ duyệt qua mọi hình bên trong slide và kiểm tra xem nó có phải là hình [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) hay không. Nếu hình là loại SmartArt thì chúng ta sẽ ép kiểu nó thành thể hiện [**SmartArt**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) .

```javascript
// Tải bản trình bày mong muốn
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Duyệt qua mọi hình trong slide đầu tiên
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Kiểm tra xem hình có phải là loại SmartArt hay không
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Ép kiểu hình thành SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Truy cập Hình SmartArt với Loại Bố Cục Cụ Thể**
Mã mẫu dưới đây sẽ giúp truy cập hình [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) với LayoutType cụ thể. Lưu ý rằng bạn không thể thay đổi LayoutType của SmartArt vì nó chỉ đọc và chỉ được đặt khi hình [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) được thêm.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) và tải bản trình bày có chứa Hình SmartArt .
2. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục Index của nó.
3. Duyệt qua mọi hình bên trong slide đầu tiên.
4. Kiểm tra xem hình có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) hay không và ép kiểu hình đã chọn thành SmartArt nếu nó là SmartArt.
5. Kiểm tra hình SmartArt với LayoutType cụ thể và thực hiện những gì cần làm sau đó.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Duyệt qua mọi hình trong slide đầu tiên
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Kiểm tra xem hình có phải là loại SmartArt hay không
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Ép kiểu hình thành SmartArtEx
            var smart = shape;
            // Kiểm tra Layout SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thay đổi Style Hình SmartArt**
Trong ví dụ này, chúng ta sẽ học cách thay đổi style nhanh cho bất kỳ hình SmartArt nào.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) và tải bản trình bày có chứa Hình SmartArt .
2. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục Index của nó.
3. Duyệt qua mọi hình bên trong slide đầu tiên.
4. Kiểm tra xem hình có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) hay không và ép kiểu hình đã chọn thành SmartArt nếu nó là SmartArt.
5. Tìm hình SmartArt với Style cụ thể.
6. Đặt Style mới cho hình SmartArt.
7. Lưu bản trình bày.

```javascript
// Khởi tạo lớp Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Lấy slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Duyệt qua mọi hình trong slide đầu tiên
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Kiểm tra xem hình có phải là loại SmartArt hay không
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Ép kiểu hình thành SmartArtEx
            var smart = shape;
            // Kiểm tra style SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Thay đổi style SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Lưu bản trình bày
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Hình: Hình SmartArt với Style đã thay đổi**|

## **Thay đổi Color Style Hình SmartArt**
Trong ví dụ này, chúng ta sẽ học cách thay đổi style màu cho bất kỳ hình SmartArt nào. Trong mã mẫu dưới đây sẽ truy cập hình SmartArt với color style cụ thể và sẽ thay đổi style của nó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) và tải bản trình bày có chứa Hình SmartArt .
2. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục Index của nó.
3. Duyệt qua mọi hình bên trong slide đầu tiên.
4. Kiểm tra xem hình có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) hay không và ép kiểu hình đã chọn thành SmartArt nếu nó là SmartArt.
5. Tìm hình SmartArt với Color Style cụ thể.
6. Đặt Color Style mới cho hình SmartArt.
7. Lưu bản trình bày.

```javascript
// Khởi tạo lớp Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Lấy slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Duyệt qua mọi hình trong slide đầu tiên
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Kiểm tra xem hình có phải là loại SmartArt hay không
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Ép kiểu hình thành SmartArtEx
            var smart = shape;
            // Kiểm tra kiểu màu SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Thay đổi kiểu màu SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Lưu bản trình bày
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Hình: Hình SmartArt với Color Style đã thay đổi**|

## **Câu hỏi thường gặp**

**Tôi có thể hoạt hình SmartArt như một đối tượng duy nhất không?**

Có. SmartArt là một hình, vì vậy bạn có thể áp dụng [standard animations](/slides/vi/nodejs-java/powerpoint-animation/) thông qua API hoạt hình (entrance, exit, emphasis, motion paths) giống như với các hình khác.

**Làm sao tôi có thể tìm một SmartArt cụ thể trên slide nếu tôi không biết ID nội bộ của nó?**

Đặt và sử dụng Alternative Text (AltText) và tìm kiếm hình bằng giá trị đó — đây là cách được khuyên dùng để định vị hình mục tiêu.

**Tôi có thể nhóm SmartArt với các hình khác không?**

Có. Bạn có thể nhóm SmartArt với các hình khác (hình ảnh, bảng, v.v.) và sau đó [manipulate the group](/slides/vi/nodejs-java/group/) .

**Làm sao tôi lấy hình ảnh của một SmartArt cụ thể (ví dụ, để xem trước hoặc báo cáo)?**

Xuất thumbnail/hình ảnh của hình; thư viện có thể [render individual shapes](/slides/vi/nodejs-java/create-shape-thumbnails/) thành các tệp raster (PNG/JPG/TIFF).

**Giao diện SmartArt có được giữ nguyên khi chuyển đổi toàn bộ bản trình bày sang PDF không?**

Có. Động cơ render nhắm tới độ trung thực cao cho [PDF export](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/), với một loạt các tùy chọn về chất lượng và tính tương thích.