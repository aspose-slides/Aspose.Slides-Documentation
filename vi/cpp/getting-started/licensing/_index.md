---
title: Cấp phép
type: docs
weight: 120
url: /vi/cpp/licensing/
keywords:
- giấy phép
- giấy phép tạm thời
- cài đặt giấy phép
- sử dụng giấy phép
- xác thực giấy phép
- tệp giấy phép
- phiên bản đánh giá
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho C++. Đảm bảo truy cập liên tục vào đầy đủ tính năng với hướng dẫn cấp phép từng bước của chúng tôi."
---
## **Tổng quan**

Aspose.Slides có thể được sử dụng ở chế độ đánh giá hoặc với giấy phép hợp lệ. Phiên bản đánh giá cung cấp cùng chức năng như phiên bản có giấy phép, nhưng nó thêm một dấu nước đánh giá khi mở hoặc lưu bản trình bày và giới hạn việc trích xuất văn bản chỉ một slide.

Bài viết này giải thích cách hoạt động giấy phép trong Aspose.Slides và cách áp dụng giấy phép trước khi sử dụng thư viện. Giấy phép có thể được tải từ tệp, luồng hoặc tài nguyên nhúng bằng cách sử dụng lớp `License`. Bài viết cũng cho thấy cách kiểm tra xem giấy phép đã được áp dụng đúng chưa.

## **Đánh giá Aspose.Slides**

{{% alert color="primary" %}} 

Bạn có thể tải xuống phiên bản đánh giá của **Aspose.Slides for C++** từ [trang tải NuGet của nó](https://www.nuget.org/packages/Aspose.Slides.CPP/). Phiên bản đánh giá cung cấp cùng chức năng như sản phẩm có giấy phép. Thực tế, gói đánh giá giống hệt với gói đã mua—chỉ cần thêm một vài dòng mã để áp dụng giấy phép là nó sẽ trở thành có giấy phép.

Khi bạn hài lòng với việc đánh giá **Aspose.Slides**, bạn có thể [mua giấy phép](https://purchase.aspose.com/buy). Chúng tôi khuyến nghị xem xét các loại đăng ký có sẵn. Nếu có bất kỳ câu hỏi nào, vui lòng liên hệ với đội bán hàng của Aspose.

Mỗi giấy phép Aspose bao gồm một đăng ký một năm cho các bản nâng cấp miễn phí, bao gồm các phiên bản mới và bản sửa lỗi phát hành trong khoảng thời gian đó. Dù bạn sử dụng phiên bản có giấy phép hay phiên bản đánh giá, bạn vẫn nhận được hỗ trợ kỹ thuật miễn phí và không giới hạn.

{{% /alert %}} 

**Giới hạn của Phiên bản Đánh giá**

* Khi phiên bản Aspose.Slides đánh giá (không có giấy phép được áp dụng) cung cấp đầy đủ chức năng sản phẩm, nó sẽ chèn dấu nước đánh giá ở đầu tài liệu trong quá trình mở và lưu.
* Việc trích xuất văn bản chỉ được phép trên một slide khi sử dụng phiên bản đánh giá.

{{% alert color="primary" %}} 

Để thử Aspose.Slides mà không bị giới hạn, bạn có thể yêu cầu **Giấy phép Tạm thời 30 Ngày**. Để biết thêm thông tin, xem trang [Cách Nhận Giấy phép Tạm thời](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Giấy phép trong Aspose.Slides**

* Một phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn mua giấy phép và áp dụng nó bằng cách thêm một vài dòng mã.
* Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được cấp phép, ngày hết hạn đăng ký, và các thông tin khác.
* Tệp giấy phép được ký kỹ thuật số, vì vậy không được phép chỉnh sửa. Ngay cả một thay đổi vô tình—như thêm dấu xuống dòng—cũng làm tệp trở nên không hợp lệ.
* Aspose.Slides for C++ thường tìm kiếm tệp giấy phép ở các vị trí sau:
  * Đường dẫn được chỉ định rõ ràng trong mã của bạn
  * Thư mục chứa DLL của thành phần (được bao gồm trong Aspose.Slides)
  * Thư mục chứa assembly gọi DLL của thành phần
* Để tránh các giới hạn của phiên bản đánh giá, bạn phải đặt giấy phép trước khi sử dụng Aspose.Slides. Giấy phép chỉ cần được đặt một lần cho mỗi ứng dụng hoặc tiến trình.

## **Áp dụng Giấy phép**

Giấy phép có thể được tải từ **tệp**, **luồng**, hoặc **tài nguyên nhúng**.

{{% alert color="primary" %}}

Aspose.Slides cung cấp lớp [License](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.license/) cho các hoạt động liên quan đến giấy phép.

{{% /alert %}} 

{{% alert color="warning" %}}

Giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản cũ hơn sử dụng hệ thống giấy phép khác và sẽ không nhận diện được các giấy phép này.

{{% /alert %}}

### **Tệp**

Cách dễ nhất để thiết lập giấy phép là đặt tệp giấy phép vào cùng thư mục với DLL của thành phần (được bao gồm trong Aspose.Slides) và chỉ khai báo tên tệp, không cần đường dẫn.

Đoạn mã C++ sau cho thấy cách thiết lập tệp giấy phép:

```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

Nếu bạn đặt tệp giấy phép trong một thư mục khác, thì khi gọi phương thức [License::SetLicense](https://reference.aspose.com/slides/vi/cpp/aspose.slides/license/setlicense/), tên tệp ở cuối đường dẫn được chỉ định phải khớp chính xác với tên tệp giấy phép của bạn.

Ví dụ, nếu bạn đổi tên tệp giấy phép thành *Aspose.Slides.lic.xml*, bạn phải truyền đường dẫn đầy đủ kết thúc bằng *Aspose.Slides.lic.xml* cho phương thức [License::SetLicense](https://reference.aspose.com/slides/vi/cpp/aspose.slides/license/setlicense/) trong mã của bạn.

{{% /alert %}}

### **Luồng**

Bạn có thể tải giấy phép từ một luồng. Đoạn mã C++ sau cho thấy cách áp dụng giấy phép từ luồng:

```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Kiểm tra Giấy phép**

Để kiểm tra xem giấy phép đã được đặt đúng chưa, bạn có thể xác nhận nó. Đoạn mã C++ sau cho thấy cách kiểm tra giấy phép:

```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **An toàn đa luồng**

{{% alert title="Lưu ý" color="warning" %}} 

Phương thức [License::SetLicense](https://reference.aspose.com/slides/vi/cpp/aspose.slides/license/setlicense/) **không an toàn cho đa luồng**. Nếu bạn cần gọi phương thức này đồng thời từ nhiều luồng, nên sử dụng các primitive đồng bộ (như lock) để ngăn ngừa các vấn đề tiềm ẩn.

{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn offline (không có kết nối internet) không?**

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không yêu cầu kết nối internet.

**Điều gì sẽ xảy ra khi đăng ký một năm hết hạn? Thư viện có ngừng hoạt động không?**

Không. Giấy phép là vĩnh viễn: bạn vẫn có thể tiếp tục sử dụng các phiên bản được phát hành trước ngày kết thúc đăng ký; chỉ có bạn sẽ không được quyền sử dụng các bản mới hơn nếu không gia hạn.