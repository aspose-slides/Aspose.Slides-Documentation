---
title: Quản lý các đối tượng ink trong bản trình bày bằng PHP
linktitle: Quản lý Ink
type: docs
weight: 95
url: /vi/php-java/manage-ink/
keywords:
- mực
- đối tượng mực
- vết mực
- quản lý mực
- vẽ mực
- vẽ
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Quản lý các đối tượng ink trong PowerPoint — tạo, chỉnh sửa và định dạng mực kỹ thuật số bằng Aspose.Slides cho PHP qua Java. Nhận các mẫu mã cho vết mực, màu và kích thước brush."
---
## **Giới thiệu**

PowerPoint cung cấp chức năng bút vẽ để cho phép bạn vẽ các hình không chuẩn, có thể được sử dụng để làm nổi bật các đối tượng khác, hiển thị kết nối và quy trình, và thu hút sự chú ý đến các mục cụ thể trên một slide. 

Aspose.Slides cung cấp tất cả các loại Ink (ví dụ lớp [Ink](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ink/)) mà bạn cần để tạo và quản lý các đối tượng bút vẽ.

## **Sự khác biệt giữa Đối tượng Thông thường và Đối tượng Ink**

Các đối tượng trên một slide PowerPoint thường được biểu thị bằng các đối tượng shape. Một đối tượng shape, ở dạng đơn giản nhất, là một container định nghĩa khu vực của chính đối tượng (khung của nó) cùng với các thuộc tính của nó. Các thuộc tính này bao gồm kích thước khu vực container, hình dạng của container, nền của container, v.v. Để biết thêm thông tin, xem [Shape Layout Format](https://docs.aspose.com/slides/vi/php-java/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint làm việc với một đối tượng ink, nó bỏ qua tất cả các thuộc tính của khung đối tượng (container) ngoại trừ kích thước của nó. Kích thước khu vực container được xác định bởi các giá trị tiêu chuẩn `width` và `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu vết Inkshape**

Trace là một yếu tố cơ bản hoặc tiêu chuẩn được sử dụng để ghi lại quỹ đạo của bút khi người dùng viết bằng mực kỹ thuật số. Các trace là các bản ghi mô tả chuỗi các điểm được kết nối. 

Dạng mã hoá đơn giản nhất xác định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm được kết nối được hiển thị, chúng tạo thành hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## **Thuộc tính Brush để Vẽ**

Bạn có thể sử dụng brush để vẽ các đường nối các điểm của các phần tử trace. Brush có màu và kích thước riêng, tương ứng với các thuộc tính `Brush.Color` và `Brush.Size`. 

### **Đặt Màu Brush Ink**

Đoạn mã PHP này cho bạn thấy cách đặt màu cho một brush:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Đặt Kích thước Brush Ink** 

Đoạn mã PHP này cho bạn thấy cách đặt kích thước cho một brush:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Thông thường, chiều rộng và chiều cao của một brush không khớp, vì vậy PowerPoint không hiển thị kích thước của brush (phần dữ liệu được làm mờ). Nhưng khi chiều rộng và chiều cao của brush khớp, PowerPoint hiển thị kích thước của nó như sau:

![ink_powerpoint3](ink_powerpoint3.png)

Để rõ ràng hơn, hãy tăng chiều cao của đối tượng ink và xem lại các kích thước quan trọng: 

![ink_powerpoint4](ink_powerpoint4.png)

Container (khung) không xem xét kích thước của các brush — nó luôn giả định độ dày của đường là zero (xem hình cuối). 

Do đó, để xác định vùng hiển thị của toàn bộ đối tượng ink, chúng ta phải xét kích thước brush của các đối tượng trace. Ở đây, đối tượng mục tiêu (đối tượng trace văn bản viết tay) đã được thu phóng tới kích thước của container (khung). Khi kích thước của container (khung) thay đổi, kích thước brush vẫn giữ nguyên và ngược lại. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint cũng thể hiện hành vi tương tự khi làm việc với văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

**Đọc thêm**

* Để đọc về các shape nói chung, xem phần [PowerPoint Shapes](https://docs.aspose.com/slides/vi/php-java/powerpoint-shapes/).
* Để biết thêm thông tin về các giá trị hiệu quả, xem [Shape Effective Properties](https://docs.aspose.com/slides/vi/php-java/shape-effective-properties/#getting-effective-font-height-value).