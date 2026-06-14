---
title: Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bản trình chiếu bằng C++
linktitle: Thẻ và Dữ liệu Tùy chỉnh
type: docs
weight: 300
url: /vi/cpp/managing-tags-and-custom-data/
keywords:
- thuộc tính tài liệu
- thẻ
- dữ liệu tùy chỉnh
- thêm thẻ
- cặp giá trị
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách thêm, đọc, cập nhật và xóa thẻ & dữ liệu tùy chỉnh trong Aspose.Slides cho C++, với các ví dụ cho bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bản trình chiếu PowerPoint. Nó tóm tắt ngắn gọn cách dữ liệu được lưu trữ trong tệp PPTX, lưu ý rằng dữ liệu riêng của bản trình chiếu có thể tồn tại dưới dạng thẻ và các phần XML tùy chỉnh, và mô tả thẻ như các cặp chuỗi khóa‑giá trị.

Cũng cho thấy cách đọc giá trị thẻ và cách thêm thẻ vào một bản trình chiếu, một slide riêng lẻ, hoặc một hình dạng. Ngoài ra, bài viết đề cập đến các tác vụ quản lý thẻ thông thường như xóa tất cả thẻ, xóa thẻ theo tên, và lấy danh sách tên thẻ.

## **Lưu trữ dữ liệu trong tệp bản trình chiếu**

Tệp PPTX—các mục có phần mở rộng .pptx—được lưu trữ ở định dạng PresentationML, là một phần của tiêu chuẩn Office Open XML. Định dạng Office Open XML định nghĩa cấu trúc cho dữ liệu có trong các bản trình chiếu. 

Với một *slide* là một trong các thành phần của bản trình chiếu, một *slide part* chứa nội dung của một slide duy nhất. Một slide part có thể có các quan hệ rõ ràng tới nhiều phần—chẳng hạn như Thẻ do Người dùng Định nghĩa—được định nghĩa bởi ISO/IEC 29500. 

Dữ liệu tùy chỉnh (đặc thù cho một bản trình chiếu) hoặc người dùng có thể tồn tại dưới dạng thẻ ([ITagCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itagcollection/)) và CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 
Thẻ về cơ bản là các giá trị cặp khóa‑chuỗi. 
{{% /alert %}} 

## **Lấy Giá Trị Của Thẻ**

Trong slides, một thẻ tương ứng với thuộc tính IDocumentProperties.Keywords. Đoạn mã mẫu dưới đây cho bạn thấy cách lấy giá trị của thẻ bằng Aspose.Slides cho C++ cho [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Thêm Thẻ Vào Bản Trình Chiếu**

Aspose.Slides cho phép bạn thêm thẻ vào các bản trình chiếu. Một thẻ thường bao gồm hai mục: 

- tên của thuộc tính tùy chỉnh - `MyTag` 
- giá trị của thuộc tính tùy chỉnh - `My Tag Value`

Nếu bạn cần phân loại một số bản trình chiếu dựa trên quy tắc hoặc thuộc tính cụ thể, thì việc thêm thẻ vào các bản trình chiếu đó có thể hữu ích. Ví dụ, nếu bạn muốn nhóm hoặc phân loại tất cả các bản trình chiếu từ các quốc gia Bắc Mỹ lại với nhau, bạn có thể tạo một thẻ Bắc Mỹ và sau đó gán các quốc gia liên quan (Mỹ, Mexico và Canada) làm giá trị. 

Đoạn mã mẫu dưới đây cho bạn thấy cách thêm một thẻ vào [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) bằng Aspose.Slides cho C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Thẻ cũng có thể được đặt cho [Slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Hoặc bất kỳ [Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/) riêng lẻ nào:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Giới hạn**

Thẻ được thêm thông qua bộ sưu tập thẻ dữ liệu tùy chỉnh bằng `get_CustomData()->get_Tags()` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình chiếu được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán làm thẻ không thể được truy xuất từ PDF đã gắn thẻ.

**Giải pháp thay thế**: Bạn có thể lưu một định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape->set_AlternativeText(u"MyId")`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả thẻ khỏi một bản trình chiếu, slide hoặc shape trong một thao tác không?**

Đúng. Bộ sưu tập [tag](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/clear/) để xóa tất cả các cặp khóa‑giá trị cùng một lúc.

**Làm thế nào để xóa một thẻ duy nhất theo tên mà không phải lặp qua toàn bộ bộ sưu tập?**

Sử dụng thao tác [Remove(name)](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/remove/) trên [TagCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm sao tôi có thể lấy danh sách đầy đủ các tên thẻ để phân tích hoặc lọc?**

Sử dụng [GetNamesOfTags](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/getnamesoftags/) trên [tag collection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/tagcollection/); nó trả về một mảng chứa tất cả các tên thẻ.