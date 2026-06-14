---
title: Bảo mật bản trình chiếu bằng mật khẩu trong C++
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/cpp/password-protected-presentation/
keywords:
- khóa PowerPoint
- khóa bản trình chiếu
- mở khóa PowerPoint
- mở khóa bản trình chiếu
- bảo vệ PowerPoint
- bảo vệ bản trình chiếu
- đặt mật khẩu
- thêm mật khẩu
- mã hoá PowerPoint
- mã hoá bản trình chiếu
- giải mã PowerPoint
- giải mã bản trình chiếu
- bảo vệ ghi
- bảo mật PowerPoint
- bảo mật bản trình chiếu
- xóa mật khẩu
- xóa bảo vệ
- xóa mã hoá
- vô hiệu hoá mật khẩu
- vô hiệu hoá bảo vệ
- xóa bảo vệ ghi
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa dễ dàng các bản trình chiếu PowerPoint và OpenDocument được bảo vệ bằng mật khẩu với Aspose.Slides cho C++. Bảo mật các bản trình chiếu của bạn."
---
## **Giới thiệu**

Khi bạn bảo vệ mật khẩu cho một bản trình chiếu, nghĩa là bạn đặt một mật khẩu để thực thi một số hạn chế trên bản trình chiếu. Để gỡ bỏ các hạn chế, cần nhập mật khẩu. Bản trình chiếu được bảo vệ mật khẩu được coi là bản trình chiếu bị khóa.

Thông thường, bạn có thể đặt mật khẩu để áp dụng các hạn chế sau trên một bản trình chiếu:

- **Sửa đổi**

  Nếu bạn muốn chỉ một số người dùng nhất định có thể sửa đổi bản trình chiếu của mình, bạn có thể đặt hạn chế sửa đổi. Hạn chế này ngăn người khác sửa đổi, thay đổi hoặc sao chép nội dung trong bản trình chiếu (trừ khi họ cung cấp mật khẩu).

  Tuy nhiên, trong trường hợp này, ngay cả khi không có mật khẩu, người dùng vẫn có thể truy cập tài liệu và mở nó. Ở chế độ chỉ đọc, người dùng có thể xem nội dung hoặc các thành phần—liên kết, hoạt ảnh, hiệu ứng và các thứ khác—trong bản trình chiếu, nhưng không thể sao chép mục nào hoặc lưu bản trình chiếu.

- **Mở**

  Nếu bạn muốn chỉ một số người dùng nhất định có thể mở bản trình chiếu, bạn có thể đặt hạn chế mở. Hạn chế này ngăn người khác thậm chí xem nội dung của bản trình chiếu (trừ khi họ cung cấp mật khẩu).

  Về mặt kỹ thuật, hạn chế mở cũng ngăn người dùng sửa đổi bản trình chiếu: Khi người dùng không thể mở bản trình chiếu, họ cũng không thể thực hiện bất kỳ thay đổi nào.

  **Lưu ý** rằng khi bạn bảo vệ mật khẩu một bản trình chiếu để ngăn mở, tệp bản trình chiếu sẽ được mã hoá.

## **Cách bảo vệ mật khẩu cho bản trình chiếu trực tuyến**

1. Truy cập trang [**Aspose.Slides Lock**](https://products.aspose.app/slides/vi/lock) của chúng tôi.

   ![todo:image_alt_text](slides-lock.png)

2. Nhấp **Drop or upload your files**.

3. Chọn tệp bạn muốn bảo vệ mật khẩu trên máy tính.

4. Nhập mật khẩu bạn muốn đặt cho việc bảo vệ chỉnh sửa; Nhập mật khẩu bạn muốn đặt cho việc bảo vệ xem.

5. Nếu bạn muốn người dùng xem bản trình chiếu như bản sao cuối cùng, đánh dấu chọn hộp **Mark as final**.

6. Nhấp **PROTECT NOW.**

7. Nhấp **DOWNLOAD NOW.**

## **Bảo vệ mật khẩu cho bản trình chiếu trong Aspose.Slides**
**Định dạng được hỗ trợ**

Aspose.Slides hỗ trợ bảo vệ mật khẩu, mã hoá và các thao tác tương tự cho các bản trình chiếu ở các định dạng sau:

- PPTX và PPT - Microsoft PowerPoint Presentation
- ODP - OpenDocument Presentation
- OTP - OpenDocument Presentation Template

**Các thao tác được hỗ trợ**

Aspose.Slides cho phép bạn sử dụng bảo vệ mật khẩu trên bản trình chiếu để ngăn sửa đổi theo các cách sau:

- Mã hoá một bản trình chiếu
- Đặt bảo vệ ghi trên một bản trình chiếu

**Các thao tác khác**

Aspose.Slides cho phép bạn thực hiện các nhiệm vụ khác liên quan tới bảo vệ mật khẩu và mã hoá như sau:

- Giải mã một bản trình chiếu; mở một bản trình chiếu đã mã hoá
- Gỡ bỏ mã hoá; tắt bảo vệ mật khẩu
- Gỡ bỏ bảo vệ ghi khỏi một bản trình chiếu
- Lấy các thuộc tính của một bản trình chiếu đã mã hoá
- Kiểm tra xem một bản trình chiếu có được mã hoá hay không
- Kiểm tra xem một bản trình chiếu có được bảo vệ mật khẩu hay không.

## **Mã hoá một bản trình chiếu**

Bạn có thể mã hoá một bản trình chiếu bằng cách đặt mật khẩu. Sau đó, để sửa đổi bản trình chiếu bị khóa, người dùng phải cung cấp mật khẩu.

Để mã hoá hoặc bảo vệ mật khẩu một bản trình chiếu, bạn phải sử dụng phương thức encrypt (từ [ProtectionManager](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager)) để đặt mật khẩu cho bản trình chiếu. Bạn truyền mật khẩu vào phương thức encrypt và sử dụng phương thức save để lưu bản trình chiếu đã được mã hoá.

Mã mẫu dưới đây cho thấy cách mã hoá một bản trình chiếu:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Đặt bảo vệ ghi cho một bản trình chiếu**

Bạn có thể thêm một ghi chú “Không sửa đổi” vào bản trình chiếu. Theo cách này, bạn thông báo cho người dùng rằng bạn không muốn họ thực hiện bất kỳ thay đổi nào trên bản trình chiếu.

**Lưu ý** rằng quá trình bảo vệ ghi không mã hoá bản trình chiếu. Do đó, người dùng—nếu họ thực sự muốn—có thể sửa đổi bản trình chiếu, nhưng để lưu các thay đổi, họ sẽ phải tạo một bản trình chiếu mới với tên khác.

Để đặt bảo vệ ghi, bạn phải sử dụng phương thức setWriteProtection. Mã mẫu dưới đây cho thấy cách đặt bảo vệ ghi cho một bản trình chiếu:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Tải một bản trình chiếu đã mã hoá**

Aspose.Slides cho phép bạn tải một tệp đã mã hoá bằng cách truyền mật khẩu. Để giải mã một bản trình chiếu, bạn phải gọi phương thức [RemoveEncryption](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) mà không có tham số. Sau đó bạn sẽ phải nhập mật khẩu đúng để tải bản trình chiếu.

Mã mẫu dưới đây cho thấy cách giải mã một bản trình chiếu:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// làm việc với bản trình chiếu đã giải mã
```

## **Gỡ bỏ mã hoá khỏi một bản trình chiếu**

Bạn có thể gỡ bỏ mã hoá hoặc bảo vệ mật khẩu trên một bản trình chiếu. Khi đó, người dùng có thể truy cập hoặc sửa đổi bản trình chiếu mà không bị hạn chế.

Để gỡ bỏ mã hoá hoặc bảo vệ mật khẩu, bạn phải gọi phương thức [RemoveEncryption](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Mã mẫu dưới đây cho thấy cách gỡ bỏ mã hoá khỏi một bản trình chiếu:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Gỡ bỏ bảo vệ ghi khỏi một bản trình chiếu**

Bạn có thể sử dụng Aspose.Slides để gỡ bỏ bảo vệ ghi đã được áp dụng trên tệp bản trình chiếu. Khi đó, người dùng có thể sửa đổi tùy ý—và họ không nhận được cảnh báo khi thực hiện các thao tác đó.

Bạn có thể gỡ bỏ bảo vệ ghi khỏi một bản trình chiếu bằng cách sử dụng phương thức [RemoveWriteProtection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Mã mẫu dưới đây cho thấy cách gỡ bỏ bảo vệ ghi khỏi một bản trình chiếu:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Lấy các thuộc tính của một bản trình chiếu đã mã hoá**

Thông thường, người dùng gặp khó khăn khi lấy các thuộc tính tài liệu của một bản trình chiếu đã được mã hoá hoặc bảo vệ mật khẩu. Tuy nhiên, Aspose.Slides cung cấp một cơ chế cho phép bạn bảo vệ mật khẩu một bản trình chiếu đồng thời cho phép người dùng truy cập các thuộc tính của bản trình chiếu đó.

**Lưu ý** rằng khi Aspose.Slides mã hoá một bản trình chiếu, các thuộc tính tài liệu của bản trình chiếu cũng sẽ được bảo vệ mật khẩu theo mặc định. Nhưng nếu bạn muốn các thuộc tính của bản trình chiếu vẫn có thể truy cập (ngay cả sau khi bản trình chiếu đã được mã hoá), Aspose.Slides cho phép bạn thực hiện điều đó.

Nếu bạn muốn người dùng vẫn có thể truy cập các thuộc tính của một bản trình chiếu đã được mã hoá, bạn có thể truyền `true` vào phương thức [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d). Mã mẫu dưới đây cho thấy cách mã hoá một bản trình chiếu đồng thời cung cấp khả năng cho người dùng truy cập các thuộc tính tài liệu của nó:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Kiểm tra xem một bản trình chiếu có được bảo vệ mật khẩu không**

Trước khi tải một bản trình chiếu, bạn có thể muốn kiểm tra và xác nhận rằng bản trình chiếu chưa bị bảo vệ bằng mật khẩu. Khi đó, bạn có thể tránh các lỗi và các vấn đề tương tự phát sinh khi một bản trình chiếu được bảo vệ mật khẩu được tải mà không có mật khẩu.

Mã C++ dưới đây cho thấy cách kiểm tra một bản trình chiếu xem nó có được bảo vệ mật khẩu hay không (không cần tải bản trình chiếu):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Kiểm tra xem một bản trình chiếu có được mã hoá không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình chiếu có được mã hoá hay không. Để thực hiện nhiệm vụ này, bạn có thể dùng phương thức [get_IsEncrypted()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), phương thức này trả về `true` nếu bản trình chiếu được mã hoá và `false` nếu không.

Mã mẫu dưới đây cho thấy cách kiểm tra xem một bản trình chiếu có được mã hoá không:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Kiểm tra xem một bản trình chiếu có được bảo vệ ghi không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình chiếu có được bảo vệ ghi hay không. Để thực hiện nhiệm vụ này, bạn có thể dùng phương thức [get_IsWriteProtected()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), phương thức này trả về `true` nếu bản trình chiếu được bảo vệ ghi và `false` nếu không.

Mã mẫu dưới đây cho thấy cách kiểm tra xem một bản trình chiếu có được bảo vệ ghi không:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Xác minh việc sử dụng mật khẩu trên bản trình chiếu**

Bạn có thể muốn kiểm tra và xác nhận rằng một mật khẩu cụ thể đã được sử dụng để bảo vệ tài liệu bản trình chiếu. Aspose.Slides cung cấp cách để bạn xác thực mật khẩu.

Mã mẫu dưới đây cho thấy cách xác thực mật khẩu:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// kiểm tra xem "pass" có khớp hay không
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Nó trả về `true` nếu bản trình chiếu đã được mã hoá bằng mật khẩu đã chỉ định. Ngược lại, nó trả về `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/vi/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides hỗ trợ những phương pháp mã hoá nào?**

Aspose.Slides hỗ trợ các phương pháp mã hoá hiện đại, bao gồm các thuật toán dựa trên AES, đảm bảo mức độ bảo mật dữ liệu cao cho các bản trình chiếu của bạn.

**Điều gì xảy ra nếu nhập sai mật khẩu khi cố gắng mở một bản trình chiếu?**

Một ngoại lệ sẽ được ném ra nếu mật khẩu không đúng, thông báo rằng truy cập vào bản trình chiếu bị từ chối. Điều này giúp ngăn chặn truy cập trái phép và bảo vệ nội dung bản trình chiếu.

**Có bất kỳ tác động nào đến hiệu suất khi làm việc với các bản trình chiếu được bảo vệ mật khẩu không?**

Quá trình mã hoá và giải mã có thể gây ra một ít overhead khi mở và lưu bản trình chiếu. Trong hầu hết các trường hợp, ảnh hưởng này là tối thiểu và không ảnh hưởng đáng kể đến thời gian xử lý tổng thể của các tác vụ liên quan tới bản trình chiếu.