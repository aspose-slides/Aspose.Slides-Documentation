---
title: Quản lý Đối tượng Ink trong Bản trình chiếu bằng JavaScript
linktitle: Quản lý Ink
type: docs
weight: 95
url: /vi/nodejs-java/manage-ink/
keywords:
- mực
- đối tượng ink
- dấu vết ink
- quản lý ink
- vẽ ink
- vẽ
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các đối tượng ink trong PowerPoint—tạo, chỉnh sửa và tạo kiểu mực kỹ thuật số với Aspose.Slides cho Node.js. Nhận mẫu mã JavaScript cho dấu vết, màu brush và kích thước brush."
---
## **Giới thiệu**

PowerPoint cung cấp chức năng ink để cho phép bạn vẽ các hình không chuẩn, có thể được sử dụng để làm nổi bật các đối tượng khác, hiển thị kết nối và quy trình, và thu hút sự chú ý tới các mục cụ thể trên một slide.

Aspose.Slides cung cấp tất cả các kiểu Ink (ví dụ như lớp [Ink](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ink/)) bạn cần để tạo và quản lý các đối tượng ink.

## **Sự khác nhau giữa Đối tượng thường và Đối tượng Ink**

Các đối tượng trên một slide PowerPoint thường được biểu diễn bằng các đối tượng shape. Một đối tượng shape, ở dạng đơn giản nhất, là một container xác định vùng diện tích của chính đối tượng (khung) cùng với các thuộc tính của nó. Phần sau bao gồm kích thước vùng container, hình dạng của container, nền của container, v.v. Để biết thêm, xem [Shape Layout Format](https://docs.aspose.com/slides/vi/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint xử lý một đối tượng ink, nó bỏ qua tất cả các thuộc tính của khung đối tượng (container) ngoại trừ kích thước của nó. Kích thước của vùng container được xác định bởi các giá trị chuẩn `width` và `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu vết Inkshape**

Trace là một yếu tố cơ bản hoặc chuẩn được sử dụng để ghi lại quỹ đạo của bút khi người dùng viết bằng mực kỹ thuật số. Trace là các bản ghi mô tả chuỗi các điểm kết nối.

Dạng mã hoá đơn giản nhất xác định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm kết nối được hiển thị, chúng tạo thành một hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## Thuộc tính Brush để Vẽ

Bạn có thể sử dụng một brush để vẽ các đường nối các điểm của các phần tử trace. Brush có màu và kích thước riêng, tương ứng với các phương thức `Brush.setColor` và `Brush.setSize`.

### **Đặt màu Brush Ink**

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Đặt kích thước Brush Ink**

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Thông thường, chiều rộng và chiều cao của brush không khớp, vì vậy PowerPoint không hiển thị kích thước brush (phần dữ liệu được tô xám). Nhưng khi chiều rộng và chiều cao của brush khớp, PowerPoint hiển thị kích thước như sau:

![ink_powerpoint3](ink_powerpoint3.png)

Để minh bạch, hãy tăng chiều cao của đối tượng ink và xem lại các kích thước quan trọng:

![ink_powerpoint4](ink_powerpoint4.png)

Container (khung) không xét đến kích thước của brush—nó luôn giả định độ dày của đường là zero (xem hình cuối cùng).

Do đó, để xác định vùng hiển thị của toàn bộ đối tượng ink, chúng ta phải xem xét kích thước brush của các đối tượng trace. Ở đây, đối tượng mục tiêu (đối tượng trace văn bản viết tay) đã được mở rộng tới kích thước container (khung). Khi kích thước của container (khung) thay đổi, kích thước brush vẫn cố định và ngược lại.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint thể hiện hành vi tương tự khi xử lý văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

**Đọc thêm**

* Để đọc về các hình dạng nói chung, xem phần [PowerPoint Shapes](https://docs.aspose.com/slides/vi/nodejs-java/powerpoint-shapes/).
* Để biết thêm thông tin về các giá trị hiệu quả, xem [Shape Effective Properties](https://docs.aspose.com/slides/vi/nodejs-java/shape-effective-properties/#getting-effective-font-height-value).