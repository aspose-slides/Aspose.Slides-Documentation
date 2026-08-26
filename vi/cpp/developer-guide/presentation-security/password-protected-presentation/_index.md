---
title: Bảo vệ bản trình chiếu bằng mật khẩu trong C++
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/cpp/password-protected-presentation/
keywords:
- bản trình chiếu được bảo vệ bằng mật khẩu
- mật khẩu mở khóa
- mã hoá PowerPoint
- giải mã PowerPoint
- xác thực mật khẩu bản trình chiếu
- kiểm tra mật khẩu bản trình chiếu
- mở bản trình chiếu đã mã hoá
- gỡ bỏ mã hoá
- PowerPoint
- PPT
- PPTX
- bản trình chiếu
- C++
- Aspose.Slides
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bản trình chiếu PowerPoint PPT và PPTX được bảo vệ bằng mật khẩu trong C++ với Aspose.Slides."
---
## **Tổng quan**

Mật khẩu mở khóa mã hoá một bản trình chiếu. Cần mật khẩu đúng để tải và xem nội dung bản trình chiếu, vì vậy bảo vệ này cung cấp tính bảo mật.

Mật khẩu mở khóa khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc chỉnh sửa nhưng không mã hoá nội dung hay ngăn bản trình chiếu được tải. Để quản lý mật khẩu cho việc sửa đổi bản trình chiếu, xem [Bảo vệ ghi bản trình chiếu](/slides/vi/cpp/write-protected-presentation/).

Các quy trình làm việc dưới đây áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và dựa trên luồng của chúng quan trọng.

## **Mã hoá bản trình chiếu bằng mật khẩu mở khóa**

Sử dụng [IProtectionManager::Encrypt](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprotectionmanager/encrypt/) để chỉ định mật khẩu mở khóa. Sau đó sử dụng [IPresentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/save/) để lưu bản trình chiếu đã được mã hoá.

Ví dụ sau mã hoá một bản trình chiếu PPTX:

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

## **Tải một bản trình chiếu đã mã hoá**

Đặt [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/) thành mật khẩu mở khóa và truyền các tùy chọn này vào [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi yêu cầu mật khẩu mở khóa nhưng mật khẩu được cung cấp thiếu hoặc không đúng.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Làm việc với bản trình chiếu đã giải mã.
```

## **Gỡ bỏ mã hoá khỏi một bản trình chiếu**

Tải bản trình chiếu bằng mật khẩu mở khóa, gọi [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprotectionmanager/removeencryption/), và lưu kết quả. Bản trình chiếu đã lưu sau đó có thể được tải mà không cần mật khẩu.

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

## **Xác thực mật khẩu mở khóa trước khi tải**

Sử dụng [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) để lấy [IPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/) mà không tạo một thực thể bản trình chiếu đầy đủ. Kiểm tra [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) trước khi yêu cầu hoặc xác thực mật khẩu. Khi có bảo vệ, xác thực giá trị đã cung cấp bằng [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Quy trình làm việc theo đường dẫn tệp**

Ví dụ dưới đây xác thực mật khẩu mở khóa cho tệp PPTX, truyền giá trị đã xác thực cho [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/), và sau đó tải bản trình chiếu đầy đủ:

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

### **Quy trình làm việc luồng**

Phiên bản quá tải luồng của [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) cung cấp cùng quy trình làm việc. Đặt lại vị trí của luồng có thể tìm kiếm trước khi tải bản trình chiếu đầy đủ từ luồng đó.

Ví dụ dưới đây sử dụng tệp PPT:

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

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/checkpassword/) trả về `true` chỉ khi bản trình chiếu có mật khẩu mở khóa và mật khẩu được cung cấp là đúng. Nó trả về `false` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bản trình chiếu không có mật khẩu mở khóa.
- Mật khẩu được cung cấp là null hoặc rỗng.

Hành vi này giống nhau đối với bản trình chiếu PPT và PPTX.

## **Kiểm tra xem một bản trình chiếu đã tải có được mã hoá không**

Sau khi tải một bản trình chiếu bằng mật khẩu đúng, kiểm tra [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) để xác nhận rằng bản trình chiếu nguồn đã được mã hoá. Để phát hiện bảo vệ mật khẩu mở khóa trước khi tải, sử dụng `IPresentationInfo::get_IsPasswordProtected` như đã trình bày ở trên.

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

## **Khuyến nghị bảo mật**

{{% alert color="warning" title="Security" %}}
Không ghi lại mật khẩu mở khóa hoặc bao gồm chúng trong các thông điệp chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi ngay lập tức tải bản trình chiếu.
{{% /alert %}}

## **Bảo vệ mật khẩu cho bản trình chiếu trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
2. Chọn hoặc tải lên bản trình chiếu.
3. Nhập mật khẩu để bảo vệ chế độ xem.
4. Nếu muốn, nhập mật khẩu riêng để bảo vệ chỉnh sửa.
5. Áp dụng bảo vệ và tải xuống tệp kết quả.

{{% alert color="info" title="See also" %}}
- [Bảo vệ ghi bản trình chiếu](/slides/vi/cpp/write-protected-presentation/)
- [Chữ ký số trong PowerPoint](/slides/vi/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác biệt giữa mật khẩu mở khóa và mật khẩu bảo vệ ghi là gì?**

Mật khẩu mở khóa mã hoá bản trình chiếu và được yêu cầu để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc sửa đổi mà không mã hoá nội dung.

**Tôi có thể xác thực mật khẩu mở khóa mà không tải toàn bộ các slide không?**

Có. Lấy thông tin bản trình chiếu, kiểm tra xem có bảo vệ mật khẩu mở khóa hay không, và xác thực mật khẩu trước khi tạo một thực thể bản trình chiếu đầy đủ.

**Các quy trình kiểm tra mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và dựa trên luồng hoạt động giống nhau đối với bản trình chiếu PPT và PPTX.