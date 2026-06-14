---
title: Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bản trình chiếu với Python
linktitle: Thẻ và Dữ liệu Tùy chỉnh
type: docs
weight: 300
url: /vi/python-net/managing-tags-and-custom-data/
keywords:
- thuộc tính tài liệu
- thẻ
- dữ liệu tùy chỉnh
- thêm thẻ
- cặp giá trị
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách thêm, đọc, cập nhật và xóa thẻ & dữ liệu tùy chỉnh trong Aspose.Slides for Python via .NET, với các ví dụ cho bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bản trình chiếu PowerPoint. Nó tóm tắt ngắn gọn cách dữ liệu được lưu trữ trong tệp PPTX, lưu ý rằng dữ liệu đặc thù cho bản trình chiếu có thể tồn tại dưới dạng thẻ và các phần XML tùy chỉnh, và mô tả thẻ như các cặp chuỗi khóa‑giá trị.

Nó cũng cho thấy cách đọc giá trị của thẻ và cách thêm thẻ vào bản trình chiếu, một slide riêng lẻ hoặc một shape. Ngoài ra, bài viết bao phủ các tác vụ quản lý thẻ phổ biến như xóa toàn bộ thẻ, xóa một thẻ theo tên và truy xuất danh sách các tên thẻ.

## **Lưu trữ Dữ liệu trong Tệp Bản trình chiếu**

Các tệp PPTX—các mục có phần mở rộng .pptx—được lưu trong định dạng PresentationML, là một phần của tiêu chuẩn Office Open XML. Định dạng Office Open XML định nghĩa cấu trúc cho dữ liệu chứa trong các bản trình chiếu. 

Với một *slide* là một trong các yếu tố của bản trình chiếu, một *slide part* chứa nội dung của một slide duy nhất. Một slide part có thể có các quan hệ rõ ràng với nhiều phần—chẳng hạn như User Defined Tags—theo định nghĩa của ISO/IEC 29500. 

Dữ liệu tùy chỉnh (cụ thể cho một bản trình chiếu) hoặc người dùng có thể tồn tại dưới dạng thẻ ([ITagCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/itagcollection/)) và CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 
Thẻ về cơ bản là các cặp giá trị chuỗi khóa‑giá trị. 
{{% /alert %}} 

## **Lấy Giá trị của Thẻ**

Trong slides, một thẻ tương ứng với thuộc tính IDocumentProperties.Keywords. Đoạn mã mẫu này cho thấy cách lấy giá trị của thẻ bằng Aspose.Slides for Python via .NET cho [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Thêm Thẻ vào Bản trình chiếu**

Aspose.Slides cho phép bạn thêm thẻ vào các bản trình chiếu. Một thẻ thường gồm hai mục: 

- tên của thuộc tính tùy chỉnh - `MyTag` 
- giá trị của thuộc tính tùy chỉnh - `My Tag Value`

Nếu bạn cần phân loại một số bản trình chiếu dựa trên quy tắc hoặc thuộc tính cụ thể, việc thêm thẻ vào các bản trình chiếu đó có thể mang lại lợi ích. Ví dụ, nếu bạn muốn nhóm tất cả các bản trình chiếu từ các quốc gia Bắc Mỹ lại với nhau, bạn có thể tạo một thẻ North American và sau đó gán các quốc gia tương ứng (Mỹ, Mexico và Canada) làm giá trị. 

Đoạn mã mẫu này cho thấy cách thêm một thẻ vào [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) bằng Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Thẻ cũng có thể được đặt cho [Slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Hoặc cho bất kỳ [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) cá nhân nào:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Giới hạn**

Các thẻ được thêm thông qua bộ sưu tập `custom_data.tags` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình chiếu được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán dưới dạng thẻ không thể được truy xuất từ PDF đã gắn thẻ.

**Workaround**: Bạn có thể lưu một định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape.alternative_text = "MyId"`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả thẻ khỏi một bản trình chiếu, slide hoặc shape trong một thao tác không?**

Có. [tag collection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/clear/) để xóa đồng thời tất cả các cặp khóa‑giá trị.

**Làm thế nào để xóa một thẻ duy nhất theo tên mà không phải duyệt qua toàn bộ bộ sưu tập?**

Sử dụng thao tác [remove(name)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/remove/) trên [TagCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm sao để lấy danh sách đầy đủ các tên thẻ cho mục đích phân tích hoặc lọc?**

Sử dụng [get_names_of_tags](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/get_names_of_tags/) trên [tag collection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/); nó trả về một mảng chứa tất cả các tên thẻ.