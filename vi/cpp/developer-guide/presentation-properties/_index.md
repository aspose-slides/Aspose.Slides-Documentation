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
- thuộc tính built-in
- thuộc tính tùy chỉnh
- thuộc tính nâng cao
- quản lý thuộc tính
- chỉnh sửa thuộc tính
- siêu dữ liệu tài liệu
- chỉnh sửa siêu dữ liệu
- ngôn ngữ kiểm tra
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Quản lý thuộc tính bản trình chiếu trong Aspose.Slides cho C++ và tối ưu hoá việc tìm kiếm, xây dựng thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides for C++ hỗ trợ các thuộc tính tài liệu **built-in** và **custom**. Sử dụng các thuộc tính này để đọc và cập nhật siêu dữ liệu của bản trình chiếu, chẳng hạn như tác giả, tiêu đề và các giá trị do người dùng định nghĩa.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua giao diện [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) . Một thể hiện của giao diện này được trả về bởi [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Các ví dụ sau cho thấy cách đọc, chỉnh sửa và quản lý các thuộc tính này.

{{% alert color="info" title="Note" %}}
Aspose.Slides quản lý siêu dữ liệu của ứng dụng và nhà sản xuất khi lưu bản trình chiếu; các trường này xác định phần mềm đã tạo ra kết quả.
{{% /alert %}}

## **Quản lý Thuộc tính Bản trình chiếu**

Các thuộc tính tài liệu lưu trữ thông tin mô tả cùng với nội dung bản trình chiếu. Chúng chia thành hai loại:

- **Built-in properties** chứa siêu dữ liệu tiêu chuẩn, chẳng hạn như tiêu đề, tác giả và thống kê tài liệu.
- **Custom properties** lưu trữ cặp tên/giá trị do người dùng định nghĩa.

Aspose.Slides for C++ cung cấp quyền truy cập vào cả hai loại. Trong PowerPoint, chọn **File → Info → Properties → Advanced Properties** để xem siêu dữ liệu tài liệu. Hộp thoại nhóm thông tin thành các tab như **Summary**, **Statistics**, **Contents**, và **Custom**. Sử dụng tab **Custom** để quản lý các thuộc tính do người dùng định nghĩa.

## **Đọc Thuộc tính Công khai từ Bản trình chiếu Được Mã hoá**

Mật khẩu mở thường bảo vệ cả nội dung bản trình chiếu và các thuộc tính tài liệu. Khi một bản trình chiếu được mã hoá bằng cách truyền `false` vào [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), các thuộc tính tài liệu của nó vẫn công khai. Ứng dụng sau đó có thể truyền `true` vào [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) và đọc siêu dữ liệu công khai mà không cần cung cấp mật khẩu mở.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) kiểm soát những gì Aspose.Slides tải; nó không giải mã bất kỳ thứ gì. Nếu các thuộc tính được bao gồm trong quá trình mã hoá, việc tải chúng mà không có mật khẩu sẽ thất bại. Nếu bản trình chiếu không được mã hoá, tùy chọn này sẽ bị bỏ qua và toàn bộ bản trình chiếu sẽ được tải.

Ví dụ yêu cầu một bản trình chiếu đã được mã hoá mà các thuộc tính tài liệu của nó được để công khai. Nó kiểm tra chế độ tải thông qua [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) và sau đó đọc các thuộc tính built-in qua [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Trong chế độ này, nội dung slide không được tải. Các slide, master, layout, hình dạng, phương tiện và các đối tượng trình chiếu khác không khả dụng. Ứng dụng luôn nên kiểm tra [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) trước khi thực hiện thao tác yêu cầu mô hình đối tượng bản trình chiếu đầy đủ.

{{% alert color="warning" title="Security" %}}
Siêu dữ liệu công khai có thể lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, bình luận và các giá trị tùy chỉnh. Hãy mã hoá các thuộc tính nhạy cảm cùng với bản trình chiếu. Chỉ để chúng công khai khi việc lập chỉ mục, phân loại, tìm kiếm hoặc các hệ thống quản lý tài liệu có yêu cầu cụ thể để truy cập mà không cần mật khẩu.
{{% /alert %}}

## **Cập nhật Thuộc tính của Bản trình chiếu Được Mã hoá**

Đối với tệp PPTX đã được mã hoá, một bản trình chiếu được tải bằng cách truyền `true` vào [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) nhằm mục đích đọc siêu dữ liệu công khai. Aspose.Slides không thể lưu các thuộc tính đã thay đổi từ đối tượng chỉ chứa siêu dữ liệu này vì các thuộc tính công khai phải giữ nhất quán với dữ liệu tương ứng bên trong bản trình chiếu đã mã hoá. Do đó, việc cập nhật chúng yêu cầu mật khẩu mở đúng và tải toàn bộ bản trình chiếu.

Ví dụ yêu cầu một bản trình chiếu PPTX đã được mã hoá có các thuộc tính tài liệu công khai và một mật khẩu mở đã biết. Nó mở toàn bộ bản trình chiếu bằng [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/), cập nhật các thuộc tính built-in công khai, và lưu kết quả. Sau đó sử dụng [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) để xác minh rằng việc mã hoá vẫn được duy trì và mở lại siêu dữ liệu công khai mà không cần mật khẩu để kiểm tra các giá trị mới:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Nếu một ứng dụng không được phép giải mã hoặc tải nội dung bản trình chiếu, nó phải xem các thuộc tính công khai của tệp PPTX đã mã hoá là chỉ đọc.

## **Truy cập Thuộc tính Built-in**

Giao diện [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) cung cấp siêu dữ liệu built-in thông qua các getter có kiểu, bao gồm [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/), và [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). Ví dụ này mở một bản trình chiếu hiện có và in siêu dữ liệu đã lưu ra console. Các giá trị phụ thuộc vào bản trình chiếu đầu vào; một số trường có thể trống.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

## **Chỉnh sửa Thuộc tính Built-in**

Để cập nhật siêu dữ liệu built-in, sử dụng các setter trên đối tượng trả về bởi [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Ví dụ này mở một bản trình chiếu hiện có, gọi [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/), và [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/), sau đó lưu bản trình chiếu đã cập nhật bằng [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Tệp PPTX đã lưu chứa siêu dữ liệu mới.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Quản lý Cơ sở Siêu liên kết**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) đọc cơ sở ở mức tài liệu cho các siêu liên kết tương đối. Điều này hữu ích khi di chuyển một bản trình chiếu và các tệp liên kết sang vị trí khác. Nó tách biệt với [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/): việc thay đổi cơ sở không ghi lại lại địa chỉ liên kết đã lưu hoặc thay đổi các đích tuyệt đối.

Ví dụ yêu cầu một bản trình chiếu chứa cả liên kết tương đối, chẳng hạn `target.html`, và liên kết tuyệt đối, chẳng hạn `https://example.org/absolute.html`. Nó đọc cơ sở hiện có, gán một địa chỉ cơ sở mới bằng [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/), sau đó lưu và mở lại bản trình chiếu để kiểm tra giá trị. Sau đó nó xóa cơ sở bằng `u""` và xác minh giá trị trống trong một tệp đã lưu riêng. Thay thế địa chỉ cơ sở ví dụ bằng vị trí các tệp liên kết của bạn.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

Hai thông báo xác thực nên in ra `True`. Xóa cơ sở để lại các địa chỉ siêu liên kết riêng lẻ không thay đổi.

Một liên kết tương đối tới `target.pptx` mở `old/target.pptx` khi cơ sở trỏ tới thư mục `old`. Sau khi thay đổi cơ sở thành thư mục `new`, lưu và mở lại bản trình chiếu, cùng một liên kết mở `new/target.pptx`. Liên kết tuyệt đối vẫn mở cùng một tệp. Hãy thử các liên kết tương đối của bạn trong PowerPoint trước và sau khi di chuyển bản trình chiếu hoặc thay đổi cơ sở.

## **Thêm Thuộc tính Tùy chỉnh cho Bản trình chiếu**

Các thuộc tính tùy chỉnh lưu trữ siêu dữ liệu không có trường built-in tương ứng. [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) cho phép bạn gán giá trị theo tên thuộc tính. Ví dụ này tạo một bản trình chiếu, thêm hai giá trị văn bản và một giá trị phiên bản kiểu nguyên, và lưu bản trình chiếu bằng [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Gán giá trị cho một tên đã tồn tại sẽ thay thế giá trị của thuộc tính đó.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Truy cập và Chỉnh sửa Các Thuộc tính Tùy chỉnh**

Ví dụ này mở một bản trình chiếu chứa các thuộc tính tùy chỉnh và sử dụng [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) để lặp qua chúng. [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) nhận một chỉ mục bắt đầu từ 0 và trả về tên được sử dụng bởi [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) và [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/). Ví dụ in mỗi tên và giá trị gốc, thay thế mọi giá trị bằng một chuỗi đánh số bất kể loại ban đầu, và lưu các thay đổi. Nếu không có thuộc tính tùy chỉnh, vòng lặp sẽ không thực hiện thay đổi nào.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **Ví dụ Trực tiếp**

Thử ứng dụng trực tuyến [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) để xem cách làm việc với các thuộc tính tài liệu bằng API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để tôi xóa một thuộc tính built-in khỏi bản trình chiếu?**

Các thuộc tính built-in là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì sẽ xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện có của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Có. Sử dụng [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) và sau đó [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) để đọc siêu dữ liệu tài liệu đã lưu mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) . Xem [Build a Lightweight Presentation Inventory](/slides/vi/cpp/examine-presentation/) để biết ví dụ báo cáo đầy đủ và các hạn chế theo định dạng.

**Tôi có thể đọc các thuộc tính công khai của một bản trình chiếu được mã hoá mà không cần mật khẩu mở không?**

Có. Bản trình chiếu phải được mã hoá bằng cách truyền `false` vào [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), và phải được tải bằng cách truyền `true` vào [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) .

**Tôi có thể cập nhật một tệp PPTX đã mã hoá ở chế độ chỉ tải thuộc tính tài liệu không?**

Không. Dữ liệu thuộc tính công khai và đã mã hoá phải giữ nhất quán, vì vậy việc cập nhật một tệp PPTX đã mã hoá yêu cầu tải toàn bộ bản trình chiếu với mật khẩu mở đúng.