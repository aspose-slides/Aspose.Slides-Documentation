---
title: Quản lý Thuộc tính Bài thuyết trình trong C++
linktitle: Thuộc tính Bài thuyết trình
type: docs
weight: 70
url: /vi/cpp/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- Thuộc tính bài thuyết trình
- Thuộc tính tài liệu
- Thuộc tính tích hợp
- Thuộc tính tùy chỉnh
- Thuộc tính nâng cao
- Quản lý thuộc tính
- Sửa đổi thuộc tính
- Siêu dữ liệu tài liệu
- Chỉnh sửa siêu dữ liệu
- Ngôn ngữ kiểm tra chính tả
- Ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- Bài thuyết trình
- C++
- Aspose.Slides
description: "Nắm vững quản lý thuộc tính bài thuyết trình trong Aspose.Slides cho C++ và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể được truy cập và quản lý một cách dễ dàng thông qua API của Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bài thuyết trình thông qua giao diện [IDocumentProperties](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_document_properties). Một thể hiện của giao diện này được trả về bởi phương thức [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_documentproperties/). Các ví dụ sau cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="primary" %}} 
Lưu ý rằng bạn không thể thiết lập giá trị cho các trường **Application** và **Producer**, vì Aspose Ltd. và Aspose.Slides for C++ x.x.x sẽ được hiển thị trong các trường này.
{{% /alert %}} 

## **Quản lý Thuộc tính Bài thuyết trình**

Microsoft PowerPoint cung cấp tính năng thêm một số thuộc tính vào tệp bài thuyết trình. Những thuộc tính tài liệu này cho phép lưu trữ một số thông tin hữu ích cùng với tài liệu (tệp bài thuyết trình). Có hai loại thuộc tính tài liệu như sau

- Thuộc tính Được Định Nghĩa Hệ Thống (Built-in)
- Thuộc tính Được Người Dùng Định Nghĩa (Custom)

**Built-in** chứa thông tin chung về tài liệu như tiêu đề tài liệu, tên tác giả, thống kê tài liệu, v.v. **Custom** là các thuộc tính do người dùng định nghĩa dưới dạng các cặp **Tên/Giá trị**, trong đó cả tên và giá trị đều do người dùng xác định. Sử dụng Aspose.Slides for C++, các nhà phát triển có thể truy cập và sửa đổi giá trị của cả thuộc tính built‑in và thuộc tính tùy chỉnh. Microsoft PowerPoint 2007 cho phép quản lý các thuộc tính tài liệu của các tệp bài thuyết trình. Bạn chỉ cần nhấp vào biểu tượng Office và tiếp tục mục **Prepare | Properties | Advanced Properties** trong Microsoft PowerPoint 2007. Sau khi chọn mục **Advanced Properties**, một hộp thoại sẽ xuất hiện cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint. Trong **Properties Dialog**, bạn sẽ thấy nhiều trang tab như **General, Summary, Statistics, Contents và Custom**. Tất cả các trang này cho phép cấu hình các loại thông tin khác nhau liên quan đến tệp PowerPoint. Tab **Custom** được dùng để quản lý các thuộc tính tùy chỉnh của tệp PowerPoint.

## **Truy cập Thuộc tính Built-in**

Các thuộc tính này được khai báo bởi đối tượng **IDocumentProperties** bao gồm: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** và **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Sửa đổi Thuộc tính Built-in**

Sửa đổi các thuộc tính built‑in của tệp bài thuyết trình đơn giản như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị thuộc tính sẽ được thay đổi. Trong ví dụ dưới đây, chúng tôi đã minh họa cách sửa đổi các thuộc tính tài liệu built‑in của tệp bài thuyết trình.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Thêm Thuộc tính Tùy chỉnh cho Bài thuyết trình**

Aspose.Slides for C++ cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho thuộc tính tài liệu của bài thuyết trình. Một ví dụ được đưa ra dưới đây để chỉ cách thiết lập các thuộc tính tùy chỉnh cho một bài thuyết trình.

``` cpp
// Tạo thể hiện lớp Presentation
auto presentation = System::MakeObject<Presentation>();

// Lấy các thuộc tính tài liệu
auto documentProperties = presentation->get_DocumentProperties();

// Thêm các thuộc tính tùy chỉnh
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Lấy tên thuộc tính tại chỉ mục cụ thể
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Xóa thuộc tính đã chọn
documentProperties->RemoveCustomProperty(getPropertyName);

// Lưu bài thuyết trình
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Truy cập và Sửa đổi Thuộc tính Tùy chỉnh**

Aspose.Slides for C++ cũng cho phép các nhà phát triển truy cập giá trị của các thuộc tính tùy chỉnh. Một ví dụ dưới đây cho thấy cách bạn có thể truy cập và sửa đổi tất cả các thuộc tính tùy chỉnh của một bài thuyết trình.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Đặt Ngôn ngữ Kiểm tra chính tả**

Aspose.Slides cung cấp thuộc tính [LanguageId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_languageid/) (được khai báo bởi lớp [PortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/portionformat/)) để bạn có thể đặt ngôn ngữ kiểm tra chính tả cho tài liệu PowerPoint. Ngôn ngữ kiểm tra chính tả là ngôn ngữ mà chính tả và ngữ pháp trong PowerPoint sẽ được kiểm tra.

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Đặt Ngôn ngữ Mặc định**

Đoạn mã C++ này cho thấy cách đặt ngôn ngữ mặc định cho toàn bộ bài thuyết trình PowerPoint:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Thêm một hình chữ nhật mới với văn bản
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Checks the first portion language
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Ví dụ Trực tiếp**

Hãy thử ứng dụng trực tuyến [**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với các thuộc tính tài liệu qua API Aspose.Slides:

[![Xem và Chỉnh sửa Siêu dữ liệu PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## ***Câu hỏi thường gặp**

**Làm thế nào để tôi xóa một thuộc tính built-in khỏi bản trình chiếu?**

Các thuộc tính built‑in là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì sẽ xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện có của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Có, bạn có thể truy cập các thuộc tính bản trình chiếu mà không cần tải toàn bộ bằng cách sử dụng phương thức `GetPresentationInfo` từ lớp [PresentationFactory](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentationfactory/). Sau đó, sử dụng phương thức `ReadDocumentProperties` được cung cấp bởi giao diện [IPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/) để đọc các thuộc tính một cách hiệu quả, tiết kiệm bộ nhớ và cải thiện hiệu năng.