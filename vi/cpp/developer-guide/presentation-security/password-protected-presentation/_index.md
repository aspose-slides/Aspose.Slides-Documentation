---
title: Bảo mật bản thuyết trình bằng mật khẩu trong C++
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/cpp/password-protected-presentation/
keywords:
- khóa PowerPoint
- khóa bản thuyết trình
- mở khóa PowerPoint
- mở khóa bản thuyết trình
- bảo vệ PowerPoint
- bảo vệ bản thuyết trình
- đặt mật khẩu
- thêm mật khẩu
- mã hoá PowerPoint
- mã hoá bản thuyết trình
- giải mã PowerPoint
- giải mã bản thuyết trình
- bảo vệ ghi
- bảo mật PowerPoint
- bảo mật bản thuyết trình
- xóa mật khẩu
- xóa bảo vệ
- xóa mã hoá
- vô hiệu hoá mật khẩu
- vô hiệu hoá bảo vệ
- gỡ bỏ bảo vệ ghi
- PowerPoint
- OpenDocument
- bản thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng khóa và mở khóa các bản thuyết trình PowerPoint và OpenDocument được bảo mật bằng mật khẩu với Aspose.Slides cho C++. Bảo vệ các bản thuyết trình của bạn."
---
## **Giới thiệu**

Khi bạn bảo mật bằng mật khẩu cho một bản thuyết trình, nghĩa là bạn đặt một mật khẩu để thực thi các hạn chế nhất định trên bản thuyết trình. Để loại bỏ các hạn chế, phải nhập mật khẩu. Một bản thuyết trình được bảo mật bằng mật khẩu được coi là bản thuyết trình bị khóa.

Thông thường, bạn có thể đặt mật khẩu để thực thi các hạn chế này trên bản thuyết trình:

- **Modification**

  Nếu bạn muốn chỉ một số người dùng nhất định có thể chỉnh sửa bản thuyết trình, bạn có thể đặt hạn chế chỉnh sửa. Hạn chế này ngăn mọi người chỉnh sửa, thay đổi hoặc sao chép nội dung trong bản thuyết trình (trừ khi họ cung cấp mật khẩu).

  Tuy nhiên, trong trường hợp này, ngay cả khi không có mật khẩu, người dùng vẫn có thể truy cập tài liệu và mở nó. Ở chế độ chỉ đọc, người dùng có thể xem nội dung hoặc các yếu tố—liên kết, hoạt ảnh, hiệu ứng và các thứ khác—trong bản thuyết trình, nhưng họ không thể sao chép mục nào hoặc lưu bản thuyết trình.

- **Opening**

  Nếu bạn muốn chỉ một số người dùng nhất định có thể mở bản thuyết trình, bạn có thể đặt hạn chế mở. Hạn chế này ngăn mọi người thậm chí xem nội dung của bản thuyết trình (trừ khi họ cung cấp mật khẩu).

  Kỹ thuật적으로, hạn chế mở cũng ngăn người dùng chỉnh sửa bản thuyết trình: Khi người dùng không thể mở bản thuyết trình, họ cũng không thể thực hiện việc chỉnh sửa hay thay đổi.

  **Lưu ý** rằng khi bạn bảo mật bằng mật khẩu một bản thuyết trình để ngăn mở, tệp bản thuyết trình sẽ được mã hoá.

## **Cách bảo mật bằng mật khẩu cho bản thuyết trình trực tuyến**

1. Truy cập trang [**Aspose.Slides Lock**](https://products.aspose.app/slides/vi/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Nhấp **Drop or upload your files**.

3. Chọn tệp bạn muốn bảo mật bằng mật khẩu trên máy tính.

4. Nhập mật khẩu bạn muốn dùng cho bảo vệ chỉnh sửa; nhập mật khẩu bạn muốn dùng cho bảo vệ xem.

5. Nếu bạn muốn người dùng xem bản thuyết trình như bản sao cuối cùng, chọn hộp kiểm **Mark as final**.

6. Nhấp **PROTECT NOW.**  

7. Nhấp **DOWNLOAD NOW.**

## **Password Protection for Presentations in Aspose.Slides**
**Supported formats**

Aspose.Slides hỗ trợ bảo mật bằng mật khẩu, mã hoá và các thao tác tương tự cho các bản thuyết trình ở các định dạng sau:

- PPTX và PPT - Bản thuyết trình Microsoft PowerPoint  
- ODP - Bản thuyết trình OpenDocument  
- OTP - Mẫu bản thuyết trình OpenDocument  

**Supported operations**

Aspose.Slides cho phép bạn sử dụng bảo mật bằng mật khẩu trên bản thuyết trình để ngăn chỉnh sửa theo các cách sau:

- Mã hoá bản thuyết trình  
- Đặt bảo vệ ghi vào bản thuyết trình  

**Other operations**

Aspose.Slides cho phép bạn thực hiện các tác vụ khác liên quan đến bảo mật bằng mật khẩu và mã hoá như:

- Giải mã bản thuyết trình; mở một bản thuyết trình đã mã hoá  
- Gỡ bỏ mã hoá; tắt bảo mật bằng mật khẩu  
- Gỡ bỏ bảo vệ ghi khỏi bản thuyết trình  
- Lấy các thuộc tính của một bản thuyết trình đã mã hoá  
- Kiểm tra xem một bản thuyết trình có được mã hoá hay không  
- Kiểm tra xem một bản thuyết trình có được bảo mật bằng mật khẩu hay không.  

## **Encrypt a Presentation**

Bạn có thể mã hoá một bản thuyết trình bằng cách đặt mật khẩu. Khi đó, để sửa đổi bản thuyết trình đã khóa, người dùng phải cung cấp mật khẩu.

Để mã hoá hoặc bảo mật bằng mật khẩu một bản thuyết trình, bạn phải sử dụng phương thức encrypt (từ [ProtectionManager](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager)) để đặt mật khẩu cho bản thuyết trình. Bạn truyền mật khẩu vào phương thức encrypt và sử dụng phương thức save để lưu bản thuyết trình đã được mã hoá.

Mã mẫu sau cho thấy cách mã hoá một bản thuyết trình:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Set Write Protection to a Presentation**

Bạn có thể thêm một dấu “Không chỉnh sửa” vào bản thuyết trình. Như vậy, bạn thông báo cho người dùng rằng bạn không muốn họ thực hiện thay đổi trên bản thuyết trình.

**Lưu ý** rằng quá trình bảo vệ ghi không mã hoá bản thuyết trình. Do đó, người dùng—nếu họ muốn—có thể chỉnh sửa bản thuyết trình, nhưng để lưu các thay đổi, họ sẽ phải tạo một bản thuyết trình với tên khác.

Để đặt bảo vệ ghi, bạn phải sử dụng phương thức setWriteProtection. Mã mẫu sau cho thấy cách đặt bảo vệ ghi cho một bản thuyết trình:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Load an Encrypted Presentation**

Aspose.Slides cho phép bạn tải một tệp đã mã hoá bằng cách truyền mật khẩu của nó. Để giải mã một bản thuyết trình, bạn phải gọi phương thức [RemoveEncryption](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) không có tham số. Sau đó bạn sẽ phải nhập mật khẩu đúng để tải bản thuyết trình.

Mã mẫu sau cho thấy cách giải mã một bản thuyết trình:

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// làm việc với bản thuyết trình đã giải mã
```

## **Remove Encryption from a Presentation**

Bạn có thể gỡ bỏ mã hoá hoặc bảo mật bằng mật khẩu trên một bản thuyết trình. Như vậy, người dùng sẽ có thể truy cập hoặc chỉnh sửa bản thuyết trình mà không có hạn chế.

Để gỡ bỏ mã hoá hoặc bảo mật bằng mật khẩu, bạn phải gọi phương thức [RemoveEncryption](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Mã mẫu sau cho thấy cách gỡ bỏ mã hoá từ một bản thuyết trình:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Remove Write Protection from a Presentation**

Bạn có thể sử dụng Aspose.Slides để gỡ bỏ bảo vệ ghi được áp dụng trên một tệp bản thuyết trình. Như vậy, người dùng có thể chỉnh sửa tùy ý—và không nhận bất kỳ cảnh báo nào khi thực hiện các tác vụ đó.

Bạn có thể gỡ bỏ bảo vệ ghi khỏi một bản thuyết trình bằng cách sử dụng phương thức [RemoveWriteProtection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Mã mẫu sau cho thấy cách gỡ bỏ bảo vệ ghi khỏi một bản thuyết trình:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Get Properties of an Encrypted Presentation**

Thông thường, người dùng gặp khó khăn khi truy xuất các thuộc tính tài liệu của một bản thuyết trình đã được mã hoá hoặc bảo mật bằng mật khẩu. Tuy nhiên, Aspose.Slides cung cấp một cơ chế cho phép bạn bảo mật bằng mật khẩu một bản thuyết trình đồng thời vẫn cho phép truy cập các thuộc tính tài liệu của nó.

**Lưu ý:** Mặc định, khi Aspose.Slides mã hoá một bản thuyết trình, các thuộc tính tài liệu của bản thuyết trình cũng được bảo mật bằng mật khẩu. Nếu bạn cần cho phép truy cập các thuộc tính tài liệu ngay cả sau khi đã mã hoá, Aspose.Slides cho phép bạn làm điều đó.

Nếu bạn muốn người dùng vẫn có thể truy cập các thuộc tính của một bản thuyết trình đã mã hoá, truyền `false` vào phương thức `set_EncryptDocumentProperties` của [IProtectionManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprotectionmanager/). Mã mẫu sau cho thấy cách mã hoá một bản thuyết trình đồng thời vẫn cung cấp cho người dùng quyền truy cập các thuộc tính tài liệu:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Load Only Document Properties from an Encrypted Presentation**

Để kiểm tra siêu dữ liệu của một bản thuyết trình đã mã hoá mà không tải các slide hay nội dung khác, tạo một đối tượng [LoadOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/) và đặt `set_OnlyLoadDocumentProperties` thành `true`. Ở chế độ này, Aspose.Slides bỏ qua mật khẩu và chỉ tải các thuộc tính tài liệu công khai.

Đoạn mã sau đọc các thuộc tính tài liệu được tích hợp và tùy chỉnh thông qua [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Quy trình này chỉ hoạt động khi các thuộc tính tài liệu được để ở trạng thái không mã hoá (công khai) khi bản thuyết trình được mã hoá. Nếu các thuộc tính tài liệu bị mã hoá, việc đặt `LoadOptions::set_OnlyLoadDocumentProperties` thành `true` sẽ gây ra ngoại lệ vì mật khẩu bị bỏ qua trong chế độ này. Để truy cập các thuộc tính tài liệu đã mã hoá hoặc tải toàn bộ bản thuyết trình, bao gồm các slide và nội dung khác, cung cấp mật khẩu đúng bằng `LoadOptions::set_Password` trong [LoadOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/).

## **Check Whether a Presentation Is Password Protected**

Trước khi tải một bản thuyết trình, bạn có thể muốn kiểm tra và xác nhận rằng bản thuyết trình chưa được bảo mật bằng mật khẩu. Như vậy, bạn tránh được các lỗi và vấn đề tương tự phát sinh khi tải một bản thuyết trình được bảo mật mà không có mật khẩu.

Đoạn mã C++ sau cho thấy cách kiểm tra một bản thuyết trình có được bảo mật bằng mật khẩu hay không (không tải bản thuyết trình):

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Check Whether a Presentation Is Encrypted**

Aspose.Slides cho phép bạn kiểm tra xem một bản thuyết trình có bị mã hoá hay không. Để thực hiện việc này, bạn có thể dùng phương thức [get_IsEncrypted()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), trả về `true` nếu bản thuyết trình đã được mã hoá hoặc `false` nếu chưa được mã hoá.

Đoạn mã mẫu sau cho thấy cách kiểm tra xem một bản thuyết trình có bị mã hoá hay không:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Check Whether a Presentation Is Write Protected**

Aspose.Slides cho phép bạn kiểm tra xem một bản thuyết trình có được bảo vệ ghi hay không. Để thực hiện việc này, bạn có thể dùng phương thức [get_IsWriteProtected()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), trả về `true` nếu bản thuyết trình được bảo vệ ghi hoặc `false` nếu không.

Đoạn mã mẫu sau cho thấy cách kiểm tra xem một bản thuyết trình có được bảo vệ ghi hay không:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verify Presentation Password Usage**

Bạn có thể muốn kiểm tra và xác nhận rằng một mật khẩu cụ thể đã được sử dụng để bảo vệ tài liệu bản thuyết trình. Aspose.Slides cung cấp công cụ để xác thực mật khẩu.

Đoạn mã mẫu sau cho thấy cách xác thực một mật khẩu:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// kiểm tra xem "pass" có khớp với
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Nó trả về `true` nếu bản thuyết trình đã được mã hoá bằng mật khẩu đã chỉ định. Ngược lại, nó trả về `false`.

{{% alert color="info" title="Xem thêm" %}} 
- [Digital Signature in PowerPoint](/slides/vi/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides hỗ trợ những phương pháp mã hoá nào?**

Aspose.Slides hỗ trợ các phương pháp mã hoá hiện đại, bao gồm các thuật toán dựa trên AES, đảm bảo mức độ bảo mật dữ liệu cao cho các bản thuyết trình của bạn.

**Điều gì xảy ra nếu nhập mật khẩu sai khi cố gắng mở bản thuyết trình?**

Một ngoại lệ sẽ được ném ra nếu mật khẩu không đúng, thông báo rằng truy cập vào bản thuyết trình bị từ chối. Điều này giúp ngăn ngừa truy cập trái phép và bảo vệ nội dung bản thuyết trình.

**Có ảnh hưởng đến hiệu năng khi làm việc với các bản thuyết trình được bảo mật bằng mật khẩu không?**

Quá trình mã hoá và giải mã có thể tạo ra một chút chi phí khi mở và lưu. Trong hầu hết các trường hợp, tác động này là tối thiểu và không ảnh hưởng đáng kể tới thời gian xử lý tổng thể của các nhiệm vụ liên quan đến bản thuyết trình.