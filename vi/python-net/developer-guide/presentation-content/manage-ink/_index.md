---
title: Quản lý các đối tượng mực trong bản trình bày với Python
linktitle: Quản lý Mực
type: docs
weight: 95
url: /vi/python-net/manage-ink/
keywords:
- mực
- đối tượng mực
- dấu vết mực
- quản lý mực
- vẽ mực
- vẽ
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Quản lý các đối tượng mực PowerPoint—tạo, chỉnh sửa và tạo kiểu mực kỹ thuật số với Aspose.Slides cho Python thông qua .NET. Nhận mẫu code cho dấu vết, màu và kích thước brush."
---
## **Giới thiệu**

PowerPoint cung cấp chức năng bút mực cho phép bạn vẽ các hình không chuẩn, có thể được sử dụng để làm nổi bật các đối tượng khác, hiển thị các kết nối và quy trình, và thu hút sự chú ý đến các mục cụ thể trên một slide. 

Aspose.Slides cung cấp namespace [aspose.slides.ink](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ink/), chứa các kiểu mà bạn cần để tạo và quản lý các đối tượng mực. 

## **Khác biệt giữa Đối tượng Thông thường và Đối tượng Mực**

Các đối tượng trên một slide PowerPoint thường được biểu diễn bằng các đối tượng hình dạng. Một đối tượng hình dạng, ở dạng đơn giản nhất, là một vùng chứa định nghĩa khu vực của chính đối tượng (khung của nó) cùng với các thuộc tính của nó. Các thuộc tính này bao gồm kích thước khu vực chứa, hình dạng của vùng chứa, nền của vùng chứa, v.v. Để biết thêm thông tin, xem [Định dạng bố cục hình dạng](https://docs.aspose.com/slides/vi/python-net/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint xử lý một đối tượng mực, nó bỏ qua tất cả các thuộc tính của khung đối tượng (vùng chứa) ngoại trừ kích thước của nó. Kích thước của khu vực chứa được xác định bằng các giá trị tiêu chuẩn `width` và `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu vết Inkshape**

Dấu vết là một yếu tố cơ bản hoặc tiêu chuẩn được sử dụng để ghi lại quỹ đạo của bút khi người dùng viết mực kỹ thuật số. Dấu vết là các bản ghi mô tả chuỗi các điểm liên kết. 

Dạng mã hóa đơn giản nhất chỉ định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm liên kết được vẽ, chúng tạo ra một hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## Thuộc tính Brush để Vẽ 

Bạn có thể sử dụng một brush để vẽ các đường nối các điểm của phần tử dấu vết. Brush có màu và kích thước riêng, tương ứng với các thuộc tính `Brush.color` và `Brush.size`. 

### **Đặt Màu Brush Mực**

Đoạn mã Python này cho bạn thấy cách đặt màu cho một brush:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Đặt Kích Thước Brush Mực** 

Đoạn mã Python này cho bạn thấy cách đặt kích thước cho một brush:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

Thông thường, chiều rộng và chiều cao của một brush không khớp nhau, vì vậy PowerPoint không hiển thị kích thước brush (phần dữ liệu bị xám). Nhưng khi chiều rộng và chiều cao của brush khớp nhau, PowerPoint hiển thị kích thước của nó theo cách này:

![ink_powerpoint3](ink_powerpoint3.png)

Để rõ ràng hơn, hãy tăng chiều cao của đối tượng mực và xem lại các kích thước quan trọng: 

![ink_powerpoint4](ink_powerpoint4.png)

Vùng chứa (khung) không xem xét kích thước của các brush — nó luôn giả định độ dày của đường là zero (xem hình cuối). 

Do đó, để xác định khu vực hiển thị của toàn bộ đối tượng mực, chúng ta phải xem xét kích thước brush của các đối tượng dấu vết. Ở đây, đối tượng mục tiêu (đối tượng dấu vết văn bản viết tay) đã được phóng to/thu nhỏ tới kích thước của vùng chứa (khung). Khi kích thước của vùng chứa (khung) thay đổi, kích thước brush vẫn cố định và ngược lại. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint cũng có hành vi tương tự khi xử lý văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

**Đọc thêm**

* Để đọc về các hình dạng nói chung, xem phần [PowerPoint Shapes](https://docs.aspose.com/slides/vi/python-net/powerpoint-shapes/). 
* Để biết thêm thông tin về các giá trị hiệu quả, xem [Shape Effective Properties](https://docs.aspose.com/slides/vi/python-net/shape-effective-properties/#get-effective-font-height-value).