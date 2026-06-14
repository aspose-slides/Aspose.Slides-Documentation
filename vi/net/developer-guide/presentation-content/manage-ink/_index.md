---
title: Quản lý các đối tượng mực trong bản trình chiếu bằng .NET
linktitle: Quản lý mực
type: docs
weight: 95
url: /vi/net/manage-ink/
keywords:
- mực
- đối tượng mực
- dấu vết mực
- quản lý mực
- vẽ mực
- vẽ
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Quản lý các đối tượng mực PowerPoint—tạo, chỉnh sửa và tạo kiểu mực kỹ thuật số với Aspose.Slides cho .NET. Nhận các mẫu mã cho dấu vết, màu và kích thước brush."
---
## **Giới thiệu**

PowerPoint cung cấp chức năng bút mực để cho phép bạn vẽ các hình không chuẩn, có thể được sử dụng để làm nổi bật các đối tượng khác, hiển thị kết nối và quy trình, và thu hút sự chú ý đến các mục cụ thể trên một slide. 

Aspose.Slides cung cấp giao diện [Aspose.Slides.Ink](https://reference.aspose.com/slides/vi/net/aspose.slides.ink/) chứa các kiểu bạn cần để tạo và quản lý các đối tượng bút mực. 

## **Sự khác biệt giữa Đối tượng Thông thường và Đối tượng Bút mực**

Các đối tượng trên một slide PowerPoint thường được biểu diễn bằng các đối tượng shape. Một đối tượng shape, ở dạng đơn giản nhất, là một container định nghĩa vùng của chính đối tượng (khung của nó) cùng với các thuộc tính của nó. Các thuộc tính này bao gồm kích thước vùng container, hình dạng của container, nền của container, v.v. Để biết thêm thông tin, xem [Shape Layout Format](https://docs.aspose.com/slides/vi/net/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint xử lý một đối tượng bút mực, nó bỏ qua tất cả các thuộc tính của khung đối tượng (container) ngoại trừ kích thước của nó. Kích thước của vùng container được xác định bởi các giá trị chuẩn `width` và `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu vết Inkshape**

Dấu vết là một yếu tố cơ bản hoặc tiêu chuẩn được sử dụng để ghi lại quỹ đạo của bút khi người dùng viết bằng mực kỹ thuật số. Dấu vết là các bản ghi mô tả chuỗi các điểm nối nhau. 

Dạng mã hoá đơn giản nhất xác định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm nối nhau được hiển thị, chúng tạo ra một hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## **Thuộc tính Brush để Vẽ**

Bạn có thể sử dụng brush để vẽ các đường nối các điểm của các phần tử dấu vết. Brush có màu và kích thước riêng, tương ứng với các thuộc tính `Brush.Color` và `Brush.Size`. 

### **Đặt Màu Brush Bút mực**

Mã C# này cho bạn thấy cách đặt màu cho một brush:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```

### **Đặt Kích thước Brush Bút mực** 

Mã C# này cho bạn thấy cách đặt kích thước cho một brush:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```

Thông thường, chiều rộng và chiều cao của brush không khớp, vì vậy PowerPoint không hiển thị kích thước của brush (phần dữ liệu bị mờ). Tuy nhiên khi chiều rộng và chiều cao của brush khớp nhau, PowerPoint hiển thị kích thước của nó như sau:

![ink_powerpoint3](ink_powerpoint3.png)

Để rõ ràng hơn, hãy tăng chiều cao của đối tượng bút mực và xem lại các kích thước quan trọng: 

![ink_powerpoint4](ink_powerpoint4.png)

Container (khung) không tính đến kích thước của brush--nó luôn giả định độ dày của đường là zero (xem hình cuối). 

Do đó, để xác định khu vực hiển thị của toàn bộ đối tượng bút mực, chúng ta phải xét kích thước brush của các đối tượng dấu vết. Ở đây, đối tượng mục tiêu (đối tượng dấu vết văn bản viết tay) đã được phóng to tới kích thước của container (khung). Khi kích thước của container (khung) thay đổi, kích thước brush vẫn cố định và ngược lại. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint thể hiện hành vi tương tự khi xử lý văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

**Đọc thêm**

* Để đọc về các shape nói chung, xem phần [PowerPoint Shapes](https://docs.aspose.com/slides/vi/net/powerpoint-shapes/). 
* Để biết thêm thông tin về các giá trị hiệu quả, xem [Shape Effective Properties](https://docs.aspose.com/slides/vi/net/shape-effective-properties/#get-effective-font-height-value).