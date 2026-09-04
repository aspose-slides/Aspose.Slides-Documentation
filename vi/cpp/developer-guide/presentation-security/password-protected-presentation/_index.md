---
title: Bảo vệ bằng mật khẩu cho bản trình chiếu trong C++
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/cpp/password-protected-presentation/
keywords:
- bản trình chiếu được bảo vệ mật khẩu
- mật khẩu mở đầu
- mã hoá PowerPoint
- giải mã PowerPoint
- xác thực mật khẩu bản trình chiếu
- kiểm tra mật khẩu bản trình chiếu
- mở bản trình chiếu đã mã hoá
- xóa mã hoá
- PowerPoint
- PPT
- PPTX
- bản trình chiếu
- C++
- Aspose.Slides
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bản trình chiếu PowerPoint PPT và PPTX được bảo vệ mật khẩu trong C++ với Aspose.Slides."
---
## **Tổng quan**

Mật khẩu mở đầu mã hoá một bản trình chiếu. Cần mật khẩu đúng để tải và xem nội dung bản trình chiếu, do đó bảo vệ này mang lại tính bảo mật.

Mật khẩu mở đầu khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc chỉnh sửa nhưng không mã hoá nội dung hoặc ngăn bản trình chiếu được tải. Để quản lý mật khẩu cho việc sửa đổi bản trình chiếu, xem [Write-Protect Presentations](/slides/vi/cpp/write-protected-presentation/).

Các quy trình dưới đây áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và luồng của chúng quan trọng.

## **Mã hoá bản trình chiếu bằng mật khẩu mở đầu**

Sử dụng [IProtectionManager::Encrypt](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprotectionmanager/encrypt/) để chỉ định một mật khẩu mở đầu. Sau đó sử dụng [IPresentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/save/) để lưu bản trình chiếu đã được mã hoá.

Ví dụ sau mã hoá một bản PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Giữ các thuộc tính tài liệu công khai**

Theo mặc định, Aspose.Slides bao gồm các thuộc tính tài liệu trong quá trình mã hoá bản trình chiếu. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) kiểm soát hành vi này một cách độc lập với việc mã hoá nội dung slide. Truyền `false` cho phương thức này trước khi gọi [IProtectionManager::Encrypt](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprotectionmanager/encrypt/) khi một hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu cần đọc siêu dữ liệu mà không cần mật khẩu mở đầu.

Ví dụ sau tạo một bản PPTX đã được mã hoá trong khi để lại các thuộc tính tài liệu tích hợp công khai:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Việc truyền `false` cho `set_EncryptDocumentProperties` không làm cho các slide, master, layout, shape, media hoặc nội dung bản trình chiếu khác trở thành công khai. Nó chỉ ảnh hưởng tới các thuộc tính tài liệu. Để đọc các thuộc tính này mà không tải nội dung đã mã hoá, xem [Manage Presentation Properties](/slides/vi/cpp/presentation-properties/).

## **Tải một bản trình chiếu đã mã hoá**

Đặt [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/) thành mật khẩu mở đầu và truyền các tùy chọn này cho [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi cần mật khẩu mở đầu nhưng mật khẩu đã cung cấp thiếu hoặc không đúng.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Làm việc với bản trình chiếu đã giải mã.
```

## **Xóa mã hoá khỏi một bản trình chiếu**

Tải bản trình chiếu với mật khẩu mở đầu, gọi [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprotectionmanager/removeencryption/), và lưu kết quả. Bản trình chiếu đã lưu sau đó có thể được tải mà không cần mật khẩu.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Xác thực mật khẩu mở đầu trước khi tải**

Sử dụng [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) để lấy [IPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/) mà không tạo một thể hiện đầy đủ của bản trình chiếu. Kiểm tra [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) trước khi yêu cầu hoặc xác thực mật khẩu. Khi có bảo vệ, xác thực giá trị đã cung cấp bằng [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Quy trình Đường dẫn Tệp**

Ví dụ sau xác thực mật khẩu mở đầu cho một tệp PPTX, truyền giá trị đã xác thực vào [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/), rồi tải đầy đủ bản trình chiếu:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Quy trình Luồng**

Phiên bản quá tải luồng của [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) cung cấp cùng quy trình. Đặt lại vị trí của luồng có thể tìm kiếm trước khi tải đầy đủ bản trình chiếu từ luồng đó.

Ví dụ sau sử dụng một tệp PPT:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Giá trị trả về của CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/checkpassword/) trả về `true` chỉ khi bản trình chiếu có mật khẩu mở đầu và mật khẩu đã cung cấp đúng. Nó trả về `false` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bản trình chiếu không có mật khẩu mở đầu.
- Mật khẩu đã cung cấp là null hoặc rỗng.

Hành vi này giống nhau cho các bản trình chiếu PPT và PPTX.

## **Kiểm tra liệu một bản trình chiếu đã tải có được mã hoá hay không**

Sau khi tải một bản trình chiếu bằng mật khẩu đúng, kiểm tra [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) để xác nhận rằng bản trình chiếu nguồn đã được mã hoá. Để phát hiện bảo vệ mật khẩu mở đầu trước khi tải, sử dụng `IPresentationInfo::get_IsPasswordProtected` như đã trình bày ở trên.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **Khuyến nghị Bảo mật**

{{% alert color="warning" title="Security" %}}
Không ghi nhật ký mật khẩu mở đầu hoặc bao gồm chúng trong các thông báo chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi tải bản trình chiếu ngay lập tức.

Các thuộc tính tài liệu công khai có thể tiết lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, bình luận và giá trị tùy chỉnh ngay cả khi nội dung bản trình chiếu đã được mã hoá. Hãy mã hoá siêu dữ liệu nhạy cảm cùng với bản trình chiếu. Việc để thuộc tính công khai nên là một quyết định rõ ràng, chỉ được thực hiện khi các hệ thống phải lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tệp mà không cần mật khẩu mở đầu.
{{% /alert %}}

## **Bảo vệ bản trình chiếu bằng mật khẩu trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
2. Chọn hoặc tải lên bản trình chiếu.
3. Nhập mật khẩu để bảo vệ chế độ xem.
4. Tùy chọn nhập một mật khẩu riêng cho bảo vệ chỉnh sửa.
5. Áp dụng bảo vệ và tải xuống tệp kết quả.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/vi/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/vi/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa mật khẩu mở đầu và mật khẩu bảo vệ ghi là gì?**

Mật khẩu mở đầu mã hoá bản trình chiếu và cần thiết để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc chỉnh sửa mà không mã hoá nội dung.

**Tôi có thể xác thực mật khẩu mở đầu mà không tải toàn bộ các slide không?**

Có. Lấy thông tin bản trình chiếu, kiểm tra xem có bảo vệ mật khẩu mở đầu không, và xác thực mật khẩu trước khi tạo một thể hiện đầy đủ của bản trình chiếu.

**Một ứng dụng có thể đọc siêu dữ liệu mà không có mật khẩu mở đầu không?**

Có, nhưng chỉ khi bản trình chiếu được mã hoá bằng `set_EncryptDocumentProperties(false)`. Ứng dụng sau đó phải sử dụng chế độ chỉ tải thuộc tính tài liệu như mô tả trong [Manage Presentation Properties](/slides/vi/cpp/presentation-properties/).

**Các quy trình kiểm tra mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và luồng hoạt động giống nhau cho các bản trình chiếu PPT và PPTX.