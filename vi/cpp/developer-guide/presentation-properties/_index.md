---
title: Quản lý Thuộc tính Bản trình chiếu trong C++
linktitle: Thuộc tính Bản trình chiếu
type: docs
weight: 70
url: /vi/cpp/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- thuộc tính bản trình chiếu
- thuộc tính tài liệu
- thuộc tính tích hợp
- thuộc tính tùy chỉnh
- thuộc tính nâng cao
- quản lý thuộc tính
- sửa đổi thuộc tính
- siêu dữ liệu tài liệu
- chỉnh sửa siêu dữ liệu
- ngôn ngữ kiểm tra chính tả
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Quản lý toàn diện các thuộc tính bản trình chiếu trong Aspose.Slides cho C++ và tối ưu hoá tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể được truy cập và quản lý dễ dàng bằng API Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua giao diện [IDocumentProperties](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_document_properties). Một thể hiện của giao diện này được trả về bởi phương thức [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_documentproperties/). Các ví dụ sau minh họa cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Note" %}}
Lưu ý rằng bạn không thể đặt giá trị cho các trường **Application** và **Producer**, vì Aspose Ltd. và Aspose.Slides for C++ x.x.x sẽ được hiển thị trong các trường này.
{{% /alert %}} 

## **Quản lý Thuộc tính Bản trình chiếu**

Microsoft PowerPoint cung cấp tính năng thêm một số thuộc tính vào các tệp bản trình chiếu. Những thuộc tính tài liệu này cho phép lưu trữ một số thông tin hữu ích cùng với các tài liệu (tệp bản trình chiếu). Có hai loại thuộc tính tài liệu như sau

- Thuộc tính Định nghĩa Hệ thống (Built-in)
- Thuộc tính Định nghĩa Người dùng (Custom)

**Built-in** thuộc tính chứa thông tin chung về tài liệu như tiêu đề tài liệu, tên tác giả, thống kê tài liệu, v.v. **Custom** thuộc tính là những thuộc tính do người dùng định nghĩa dưới dạng cặp **Name/Value**, trong đó cả tên và giá trị đều do người dùng xác định. Sử dụng Aspose.Slides for C++, các nhà phát triển có thể truy cập và sửa đổi giá trị của các thuộc tính built-in cũng như custom. Microsoft PowerPoint 2007 cho phép quản lý các thuộc tính tài liệu của các tệp bản trình chiếu. Bạn chỉ cần nhấp vào biểu tượng Office và sau đó chọn mục **Prepare | Properties | Advanced Properties** trong Microsoft PowerPoint 2007. Khi bạn chọn mục **Advanced Properties**, một hộp thoại sẽ xuất hiện cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint. Trong **Properties Dialog**, bạn sẽ thấy nhiều tab như **General, Summary, Statistics, Contents và Custom**. Tất cả các tab này cho phép cấu hình các loại thông tin khác nhau liên quan đến tệp PowerPoint. Tab **Custom** được dùng để quản lý các thuộc tính tùy chỉnh của tệp PowerPoint.

## **Truy cập Thuộc tính Built-in**

Các thuộc tính được khai báo bởi đối tượng **IDocumentProperties** bao gồm: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** và **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Sửa đổi Thuộc tính Built-in**

Việc sửa đổi các thuộc tính built-in của tệp bản trình chiếu cũng đơn giản như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị thuộc tính sẽ được thay đổi. Trong ví dụ dưới đây, chúng tôi đã minh họa cách sửa đổi các thuộc tính tài liệu built-in của tệp bản trình chiếu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Thêm Thuộc tính Tùy chỉnh cho Bản trình chiếu**

Aspose.Slides for C++ cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho thuộc tính tài liệu của bản trình chiếu. Một ví dụ được đưa ra dưới đây cho thấy cách đặt các thuộc tính tùy chỉnh cho một bản trình chiếu.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Khởi tạo lớp Presentation
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

// Lưu bản trình chiếu
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Truy cập và Sửa đổi Thuộc tính Tùy chỉnh**

Aspose.Slides for C++ cũng cho phép các nhà phát triển truy cập các giá trị của thuộc tính tùy chỉnh. Một ví dụ được đưa ra dưới đây cho thấy cách bạn có thể truy cập và sửa đổi tất cả các thuộc tính tùy chỉnh này cho một bản trình chiếu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Đặt Ngôn ngữ Kiểm tra chính tả**

Aspose.Slides cung cấp thuộc tính [LanguageId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_languageid/) (được khai báo bởi lớp [PortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/portionformat/)) để cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho tài liệu PowerPoint. Ngôn ngữ kiểm tra chính tả là ngôn ngữ mà chính tả và ngữ pháp trong PowerPoint sẽ được kiểm tra.

Mã C++ dưới đây cho thấy cách đặt ngôn ngữ kiểm tra chính tả cho một PowerPoint:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
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
// đặt Id của ngôn ngữ kiểm tra chính tả

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Đặt Ngôn ngữ Mặc định**

Mã C++ dưới đây cho thấy cách đặt ngôn ngữ mặc định cho toàn bộ bản trình chiếu PowerPoint:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Thêm một hình chữ nhật mới với văn bản
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Kiểm tra ngôn ngữ của phần đầu tiên
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Ví dụ Trực tiếp**

Hãy thử ứng dụng trực tuyến [**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với các thuộc tính tài liệu qua API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để tôi có thể xóa một thuộc tính built-in khỏi bản trình chiếu?**

Thuộc tính built-in là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện tại của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Có. Sử dụng [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) và sau đó [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) để đọc siêu dữ liệu tài liệu được lưu mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/). Xem [Build a Lightweight Presentation Inventory](/slides/vi/cpp/examine-presentation/) để có ví dụ báo cáo đầy đủ và các hạn chế theo định dạng.