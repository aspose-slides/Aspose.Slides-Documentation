---
title: Quản lý thẻ và dữ liệu tùy chỉnh trong các bản trình chiếu bằng .NET
linktitle: Thẻ và dữ liệu tùy chỉnh
type: docs
weight: 300
url: /vi/net/managing-tags-and-custom-data/
keywords:
- thuộc tính tài liệu
- thẻ
- dữ liệu tùy chỉnh
- thêm thẻ
- cặp giá trị
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thêm, đọc, cập nhật và xóa thẻ & dữ liệu tùy chỉnh trong Aspose.Slides cho .NET, với các ví dụ cho bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bài thuyết trình PowerPoint. Nó tóm tắt ngắn gọn cách dữ liệu được lưu trữ trong tệp PPTX, lưu ý rằng dữ liệu riêng của bài thuyết trình có thể tồn tại dưới dạng thẻ và các phần XML tùy chỉnh, và mô tả thẻ như các cặp chuỗi khóa‑giá trị.

Nó cũng chỉ ra cách đọc giá trị thẻ và cách thêm thẻ vào một bản trình chiếu, một slide riêng lẻ hoặc một shape. Ngoài ra, bài viết bao gồm các nhiệm vụ quản lý thẻ phổ biến như xóa tất cả thẻ, xoá thẻ theo tên và lấy danh sách các tên thẻ.

## **Lưu trữ dữ liệu trong tệp bản trình chiếu**

Các tệp PPTX — các mục có phần mở rộng .pptx — được lưu trong định dạng PresentationML, một phần của tiêu chuẩn Office Open XML. Định dạng Office Open XML định nghĩa cấu trúc cho dữ liệu chứa trong các bản trình chiếu. 

Với *slide* là một trong các thành phần của bản trình chiếu, một *slide part* chứa nội dung của một slide duy nhất. Một slide part được phép có các quan hệ rõ ràng với nhiều phần — chẳng hạn như User Defined Tags — được xác định bởi ISO/IEC 29500. 

Dữ liệu tùy chỉnh (cụ thể cho một bản trình chiếu) hoặc người dùng có thể tồn tại dưới dạng thẻ ([ITagCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/itagcollection)) và CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 
Thẻ về cơ bản là các cặp giá trị chuỗi khóa‑giá trị. 
{{% /alert %}} 

## **Lấy giá trị của thẻ**

Trong slides, một thẻ tương ứng với thuộc tính IDocumentProperties.Keywords. Đoạn mã mẫu sau cho thấy cách lấy giá trị của thẻ bằng Aspose.Slides for .NET cho [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Thêm thẻ vào bản trình chiếu**

Aspose.Slides cho phép bạn thêm thẻ vào bản trình chiếu. Một thẻ thường bao gồm hai mục:

- tên của thuộc tính tùy chỉnh - `MyTag` 
- giá trị của thuộc tính tùy chỉnh - `My Tag Value`

Nếu bạn cần phân loại một số bản trình chiếu dựa trên quy tắc hoặc thuộc tính cụ thể, bạn có thể hưởng lợi từ việc thêm thẻ vào các bản trình chiếu đó. Ví dụ, nếu muốn nhóm tất cả các bản trình chiếu từ các quốc gia Bắc Mỹ lại với nhau, bạn có thể tạo một thẻ North American và gán các quốc gia liên quan (Mỹ, Mexico và Canada) làm giá trị.

Đoạn mã mẫu sau cho thấy cách thêm thẻ vào một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) bằng Aspose.Slides for .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Thẻ cũng có thể được đặt cho [Slide](https://reference.aspose.com/slides/vi/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Hoặc cho bất kỳ [Shape](https://reference.aspose.com/slides/vi/net/aspose.slides/shape) nào riêng lẻ:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Giới hạn**

Các thẻ được thêm qua bộ sưu tập `CustomData.Tags` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình chiếu được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán làm thẻ không thể được truy xuất từ PDF đã gắn thẻ.

**Giải pháp thay thế**: Bạn có thể lưu một định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape.AlternativeText = "MyId"`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả thẻ khỏi một bản trình chiếu, slide hoặc shape trong một thao tác duy nhất không?**

Có. [tag collection](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/clear/) để xóa tất cả các cặp khóa‑giá trị một lúc.

**Làm sao tôi xóa một thẻ duy nhất theo tên mà không phải duyệt qua toàn bộ bộ sưu tập?**

Sử dụng thao tác [Remove(name)](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/remove/) trên [TagCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm thế nào tôi có thể lấy danh sách đầy đủ các tên thẻ để phân tích hoặc lọc?**

Sử dụng [GetNamesOfTags](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/getnamesoftags/) trên [tag collection](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/); nó sẽ trả về một mảng chứa tất cả các tên thẻ.