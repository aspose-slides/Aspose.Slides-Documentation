---
title: Bảo Vệ Ghi Bản Trình Bày trong C++
linktitle: Bảo Vệ Ghi
type: docs
weight: 25
url: /vi/cpp/write-protected-presentation/
keywords:
- bảo vệ ghi
- bảo vệ ghi PowerPoint
- mật khẩu để sửa đổi
- hạn chế chỉnh sửa bản trình bày
- xóa bảo vệ ghi
- xác thực mật khẩu sửa đổi
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Đặt, phát hiện, xác thực và xóa mật khẩu bảo vệ ghi trong các bản trình bày PowerPoint PPT và PPTX bằng Aspose.Slides cho C++."
---
## **Giới thiệu**

Mật khẩu bảo vệ ghi (write-protection) hạn chế việc sửa đổi một bản trình bày nhưng không mã hoá nội dung của nó. Người dùng có thể tải và xem một bản trình bày được bảo vệ ghi mà không cần mật khẩu. Tùy vào ứng dụng, họ cũng có thể chỉnh sửa nội dung và lưu dưới một tên khác, vì vậy bảo vệ ghi không nên được coi là cơ chế bảo mật.

Mật khẩu mở (opening password) có mục đích khác: nó mã hoá bản trình bày và được yêu cầu để tải nội dung của nó. Để mã hoá một bản trình bày hoặc xác thực mật khẩu mở, xem [Password-Protect Presentations](/slides/vi/cpp/password-protected-presentation/).

Các quy trình trong bài viết này áp dụng cho cả bản trình bày PPT và PPTX. Các ví dụ sử dụng tệp PPTX; khi lưu dưới dạng PPT, hãy dùng phần mở rộng `.ppt` và định dạng lưu PPT tương ứng.

## **Đặt Bảo Vệ Ghi trên Bản Trình Bày**

Sử dụng [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) để gán một mật khẩu cho việc sửa đổi bản trình bày. Lưu bản trình bày sẽ lưu lại cài đặt bảo vệ.

Ví dụ sau đặt bảo vệ ghi cho một bản trình bày PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Tải Bản Trình Bày Được Bảo Vệ Ghi**

Vì bảo vệ ghi không mã hoá nội dung bản trình bày, không cần mật khẩu để tải bản trình bày. Mật khẩu chỉ liên quan khi xác thực quyền sửa đổi bản trình bày được bảo vệ.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Không truyền mật khẩu bảo vệ ghi cho [LoadOptions::set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/). Thuộc tính này nhận mật khẩu mở cho nội dung đã được mã hoá. Nếu một bản trình bày có cả hai loại bảo vệ, cung cấp mật khẩu mở để tải nó và xử lý mật khẩu bảo vệ ghi riêng biệt.

## **Xóa Bảo Vệ Ghi Khỏi Bản Trình Bày**

Sử dụng [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) để loại bỏ hạn chế sửa đổi, sau đó lưu bản trình bày.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Kiểm Tra Bản Trình Bày Có Được Bảo Vệ Ghi Hay Không**

Để kiểm tra một tệp mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) đầy đủ, gọi [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) và kiểm tra [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). Thuộc tính này sử dụng [NullableBool](https://reference.aspose.com/slides/vi/cpp/aspose.slides/nullablebool/) và trả về `NullableBool::True` khi phát hiện bảo vệ ghi.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

Phiên bản overload dạng stream của [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) cung cấp cùng thông tin cho một bản trình bày được cung cấp dưới dạng stream.

## **Xác Thực Mật Khẩu Bảo Vệ Ghi**

Sử dụng [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) để xác thực mật khẩu sửa đổi mà không tải toàn bộ bản trình bày. Đầu tiên kiểm tra [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) để ứng dụng chỉ yêu cầu hoặc xác thực mật khẩu khi có bảo vệ ghi.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) chỉ xác thực mật khẩu bảo vệ ghi. Nó không xác thực mật khẩu mở hoặc xác định liệu nội dung đã được mã hoá có thể được tải hay không. Ngược lại, [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationinfo/checkpassword/) chỉ xác thực mật khẩu mở. Nếu một bản trình bày đầy đủ đã được tải, [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) cung cấp kiểm tra bảo vệ ghi tương đương thông qua trình quản lý bảo vệ của nó.

Trong các ứng dụng sản xuất, không ghi lại mật khẩu hoặc đưa chúng vào các thông báo chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, và chỉ giữ mật khẩu trong bộ nhớ trong thời gian cần thiết.

{{% alert color="info" title="Xem thêm" %}}
- [Bảo Vệ Mật Khẩu Cho Bản Trình Bày](/slides/vi/cpp/password-protected-presentation/)
- [Bản Trình Bày Chỉ Đọc](/slides/vi/cpp/read-only-presentation/)
- [Chữ Ký Số trong PowerPoint](/slides/vi/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Does write protection encrypt a presentation?**  
Không. Nó hạn chế việc sửa đổi nhưng vẫn cho phép tải và xem nội dung bản trình bày.

**Is the write-protection password required to open a presentation?**  
Không. Chỉ cần mật khẩu mở để tải nội dung bản trình bày đã mã hoá.

**Can a presentation have both an opening password and a write-protection password?**  
Có. Cung cấp mật khẩu mở qua tùy chọn tải để mở bản trình bày đã mã hoá, và xác thực mật khẩu bảo vệ ghi riêng biệt khi cần quyền sửa đổi.