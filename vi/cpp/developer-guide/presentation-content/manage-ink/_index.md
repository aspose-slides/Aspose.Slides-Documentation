---
title: Quản lý các đối tượng bút PowerPoint trong C++
linktitle: Quản lý bút
type: docs
weight: 95
url: /vi/cpp/manage-ink/
keywords:
- bút
- đối tượng bút
- dấu vết bút
- quản lý bút
- vẽ bút
- vẽ
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Quản lý các đối tượng bút PowerPoint — tạo, chỉnh sửa & định dạng mực kỹ thuật số với Aspose.Slides cho C++. Nhận mẫu mã cho dấu vết, màu cọ & kích thước cọ."
---
## **Giới thiệu**

PowerPoint cung cấp chức năng bút để cho phép bạn vẽ các hình không tiêu chuẩn, có thể được sử dụng để làm nổi bật các đối tượng khác, hiển thị kết nối và quy trình, và thu hút sự chú ý đến các mục cụ thể trên một slide.  

Aspose.Slides cung cấp giao diện [Aspose.Slides.Ink](https://reference.aspose.com/slides/vi/cpp/aspose.slides.ink/) chứa các kiểu bạn cần để tạo và quản lý các đối tượng bút.  

## **Sự khác nhau giữa Đối tượng Thông thường và Đối tượng Bút**

Các đối tượng trên một slide PowerPoint thường được biểu diễn bằng các đối tượng shape. Một đối tượng shape, ở dạng đơn giản nhất, là một container xác định vùng của chính đối tượng (khung) cùng với các thuộc tính của nó. Các thuộc tính này bao gồm kích thước vùng container, dạng hình của container, nền của container, v.v. Để biết thêm chi tiết, xem [Định dạng Bố cục Shape](https://docs.aspose.com/slides/vi/cpp/shape-manipulations/#access-layout-formats-for-shape).  

Tuy nhiên, khi PowerPoint xử lý một đối tượng bút, nó bỏ qua mọi thuộc tính của khung đối tượng (container) ngoại trừ kích thước của nó. Kích thước vùng container được xác định bằng các giá trị chuẩn `width` và `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu Vết Inkshape**

Dấu vết là yếu tố cơ bản hoặc chuẩn được sử dụng để ghi lại quỹ đạo của bút khi người dùng viết bằng mực kỹ thuật số. Dấu vết là các bản ghi mô tả chuỗi các điểm nối nhau.  

Dạng mã hóa đơn giản nhất chỉ xác định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm nối nhau được vẽ, chúng tạo ra một hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## **Thuộc tính Cọ cho Vẽ**

Bạn có thể sử dụng một cọ để vẽ các đường nối các điểm của các yếu tố dấu vết. Cọ có màu và kích thước riêng, tương ứng với các thuộc tính `Brush.Color` và `Brush.Size`.  

### **Đặt Màu Cọ Bút**

Mã C++ này cho thấy cách đặt màu cho một cọ:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Đặt Kích Thước Cọ Bút** 

Mã C++ này cho thấy cách đặt kích thước cho một cọ:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

Thông thường, chiều rộng và chiều cao của cọ không khớp nhau, vì vậy PowerPoint không hiển thị kích thước của cọ (phần dữ liệu bị làm mờ). Nhưng khi chiều rộng và chiều cao của cọ khớp nhau, PowerPoint hiển thị kích thước theo cách này:

![ink_powerpoint3](ink_powerpoint3.png)

Để làm rõ, hãy tăng chiều cao của đối tượng bút và xem lại các kích thước quan trọng:

![ink_powerpoint4](ink_powerpoint4.png)

Container (khung) không xét đến kích thước của các cọ — nó luôn giả định độ dày của đường bằng không (xem hình cuối).  

Do đó, để xác định vùng hiển thị của toàn bộ đối tượng bút, chúng ta phải tính đến kích thước cọ của các đối tượng dấu vết. Ở đây, đối tượng mục tiêu (đối tượng dấu vết văn bản viết tay) đã được thu phóng tới kích thước của container (khung). Khi kích thước của container (khung) thay đổi, kích thước cọ vẫn không đổi và ngược lại.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint thể hiện hành vi tương tự khi xử lý văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

**Đọc thêm**

* Để tìm hiểu về các shape nói chung, xem phần [Hình dạng PowerPoint](https://docs.aspose.com/slides/vi/cpp/powerpoint-shapes/).  
* Để biết thêm thông tin về các giá trị hiệu quả, xem [Thuộc tính Hiệu quả của Shape](https://docs.aspose.com/slides/vi/cpp/shape-effective-properties/#get-effective-font-height-value).