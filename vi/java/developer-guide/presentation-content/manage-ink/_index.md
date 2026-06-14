---
title: Quản lý Đối tượng Mực trong Bản trình chiếu bằng Java
linktitle: Quản lý Mực
type: docs
weight: 95
url: /vi/java/manage-ink/
keywords:
- mực
- đối tượng mực
- dấu vết mực
- quản lý mực
- vẽ mực
- vẽ
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Quản lý các đối tượng mực PowerPoint—tạo, chỉnh sửa và định dạng mực kỹ thuật số với Aspose.Slides cho Java. Nhận mẫu mã cho dấu vết, màu và kích thước brush."
---
## **Giới thiệu**

PowerPoint cung cấp tính năng mực để cho phép bạn vẽ các hình không chuẩn, có thể được sử dụng để làm nổi bật các đối tượng khác, hiển thị các kết nối và quy trình, và thu hút sự chú ý đến các mục cụ thể trên một slide. 

Aspose.Slides cung cấp tất cả các loại Ink (ví dụ lớp [Ink](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ink/)) mà bạn cần để tạo và quản lý các đối tượng mực. 

## **Sự khác nhau giữa Đối tượng Thông thường và Đối tượng Mực**

Các đối tượng trên một slide PowerPoint thường được biểu diễn bằng các đối tượng shape. Một đối tượng shape, ở dạng đơn giản nhất, là một container xác định vùng của chính đối tượng (khung của nó) cùng với các thuộc tính của nó. Các thuộc tính này bao gồm kích thước vùng container, hình dạng của container, nền của container, v.v. Để biết thêm thông tin, xem [Shape Layout Format](https://docs.aspose.com/slides/vi/java/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint xử lý một đối tượng mực, nó bỏ qua tất cả các thuộc tính của khung đối tượng (container) ngoại trừ kích thước của nó. Kích thước của vùng container được xác định bằng các giá trị tiêu chuẩn `width` và `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu Vết Inkshape**

Dấu vết là một thành phần cơ bản hoặc tiêu chuẩn được sử dụng để ghi lại quỹ đạo của bút khi người dùng viết mực kỹ thuật số. Các dấu vết là các bản ghi mô tả chuỗi các điểm nối nhau. 

Dạng mã hóa đơn giản nhất xác định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm nối nhau được dựng, chúng tạo ra một hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## **Thuộc tính Brush để Vẽ**

Bạn có thể sử dụng một brush để vẽ các đường nối các điểm của các phần tử dấu vết. Brush có màu và kích thước riêng, tương ứng với các thuộc tính `Brush.Color` và `Brush.Size`. 

### **Đặt Màu Brush Mực**

Đoạn mã Java này cho bạn thấy cách đặt màu cho một brush:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Đặt Kích Thước Brush Mực** 

Đoạn mã Java này cho bạn thấy cách đặt kích thước cho một brush:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

Thông thường, chiều rộng và chiều cao của brush không khớp, vì vậy PowerPoint không hiển thị kích thước của brush (phần dữ liệu được làm mờ). Nhưng khi chiều rộng và chiều cao của brush khớp, PowerPoint hiển thị kích thước của nó như sau:

![ink_powerpoint3](ink_powerpoint3.png)

Để làm rõ, hãy tăng chiều cao của đối tượng mực và xem lại các kích thước quan trọng: 

![ink_powerpoint4](ink_powerpoint4.png)

Container (khung) không tính đến kích thước của brush--nó luôn giả định độ dày của đường là zero (xem hình cuối). 

Do đó, để xác định khu vực hiển thị của toàn bộ đối tượng mực, chúng ta phải xem xét kích thước brush của các đối tượng dấu vết. Ở đây, đối tượng mục tiêu (đối tượng dấu vết văn bản viết tay) đã được mở rộng đến kích thước của container (khung). Khi kích thước của container (khung) thay đổi, kích thước brush vẫn không đổi và ngược lại. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint thể hiện cùng hành vi khi xử lý văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

**Đọc thêm**

* Để đọc về các shape nói chung, xem mục [PowerPoint Shapes](https://docs.aspose.com/slides/vi/java/powerpoint-shapes/). 
* Để biết thêm thông tin về các giá trị hiệu quả, xem [Shape Effective Properties](https://docs.aspose.com/slides/vi/java/shape-effective-properties/#getting-effective-font-height-value).