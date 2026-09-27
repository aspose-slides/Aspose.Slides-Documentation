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
- bài thuyết trình
- C++
- Aspose.Slides
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho C++. Đảm bảo truy cập không gián đoạn vào đầy đủ tính năng với hướng dẫn cấp phép từng bước của chúng tôi."
---
## **Tổng quan**

Aspose.Slides có thể được sử dụng ở chế độ đánh giá hoặc với giấy phép hợp lệ. Phiên bản đánh giá cung cấp cùng chức năng như phiên bản có giấy phép, nhưng nó thêm một dấu watermark đánh giá vào mọi slide của mỗi bài thuyết trình mà nó lưu và cắt ngắn văn bản mà mã của bạn đọc từ các bài thuyết trình.

Bài viết này giải thích cách giấy phép hoạt động trong Aspose.Slides và cách áp dụng giấy phép trước khi sử dụng thư viện. Một giấy phép có thể được tải từ tệp hoặc luồng bằng cách sử dụng lớp `License`. Bài viết cũng chỉ ra cách xác minh xem giấy phép đã được áp dụng đúng chưa.

## **Đánh giá Aspose.Slides**

{{% alert color="info" title="Note" %}}
Bạn có thể tải xuống phiên bản đánh giá của **Aspose.Slides for C++** từ [trang tải xuống NuGet của nó](https://www.nuget.org/packages/Aspose.Slides.Cpp/) hoặc, dưới dạng gói ZIP, từ [trang tải xuống](https://releases.aspose.com/slides/vi/cpp/). Phiên bản đánh giá cung cấp cùng chức năng như sản phẩm có giấy phép. Thực tế, gói đánh giá giống hệt với bản mua—chỉ cần thêm vài dòng mã để áp dụng giấy phép là nó sẽ hoạt động như bản có giấy phép.

Khi bạn đã hài lòng với quá trình đánh giá **Aspose.Slides**, bạn có thể [mua giấy phép](https://purchase.aspose.com/pricing/slides/vi/cpp/). Chúng tôi khuyến nghị xem xét các loại đăng ký có sẵn. Nếu bạn có bất kỳ câu hỏi nào, vui lòng liên hệ với đội ngũ bán hàng của Aspose.
Mỗi giấy phép Aspose bao gồm một năm đăng ký để nâng cấp miễn phí, bao gồm các phiên bản mới và bản sửa lỗi được phát hành trong khoảng thời gian đó. Dù bạn đang sử dụng phiên bản có giấy phép hay phiên bản đánh giá, bạn vẫn nhận được hỗ trợ kỹ thuật không giới hạn và miễn phí.
{{% /alert %}} 

**Giới hạn của Phiên bản Đánh giá**

* Phiên bản đánh giá (không chỉ định giấy phép) cung cấp đầy đủ chức năng sản phẩm, nhưng nó thêm một hộp văn bản watermark đánh giá vào mọi slide của mỗi bài thuyết trình mà nó lưu.
* Văn bản mà mã của bạn đọc từ một bài thuyết trình sẽ bị cắt ngắn tới một vài ký tự đầu, sau đó là thông báo về giới hạn đánh giá. Văn bản mà mã của bạn ghi sẽ được lưu đầy đủ.

{{% alert color="info" title="Note" %}}
Để thử Aspose.Slides mà không có giới hạn, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Để biết thêm thông tin, xem trang [Cách lấy Giấy phép tạm thời](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Giấy phép trong Aspose.Slides**

* Một phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn mua giấy phép và áp dụng nó bằng cách thêm một vài dòng mã.
* Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được cấp phép, ngày hết hạn đăng ký, v.v.
* Tệp giấy phép được ký kỹ thuật số, do đó không được phép chỉnh sửa. Ngay cả một thay đổi vô tình—như thêm dấu xuống dòng—cũng sẽ làm tệp không hợp lệ.
* Khi bạn truyền tên tệp mà không có thư mục, Aspose.Slides for C++ sẽ chỉ tìm tệp giấy phép trong thư mục làm việc hiện tại. Nó không tìm trong thư mục chứa file thực thi của bạn hoặc thư viện Aspose.Slides, vì vậy hãy truyền đường dẫn đầy đủ khi tệp giấy phép được lưu ở nơi khác.
* Để tránh các hạn chế của phiên bản đánh giá, bạn phải thiết lập giấy phép trước khi sử dụng Aspose.Slides. Một giấy phép chỉ cần được thiết lập một lần cho mỗi ứng dụng hoặc quy trình.

## **Áp dụng Giấy phép**

Giấy phép có thể được tải từ **tệp** hoặc **luồng**.

{{% alert color="info" title="Note" %}}
Aspose.Slides cung cấp lớp [License](https://reference.aspose.com/slides/vi/cpp/aspose.slides/license/) để thực hiện các thao tác liên quan đến giấy phép.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Các giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản cũ hơn sử dụng hệ thống cấp phép khác và sẽ không nhận diện được các giấy phép này.
{{% /alert %}}

### **Tệp**

Cách dễ nhất để thiết lập giấy phép là đặt tệp giấy phép vào thư mục làm việc của chương trình và chỉ định tên tệp, không cần đường dẫn. Nếu không, hãy chỉ định đường dẫn đầy đủ tới tệp.

Mã C++ sau áp dụng tệp giấy phép *Aspose.Slides.lic* từ thư mục làm việc của chương trình:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

Nếu giấy phép hợp lệ, [License::SetLicense](https://reference.aspose.com/slides/vi/cpp/aspose.slides/license/setlicense/) sẽ trả về và chương trình kết thúc mà không xuất ra gì; từ đó, Aspose.Slides hoạt động mà không có các hạn chế đánh giá. Nếu tệp không có trong thư mục làm việc, phương thức sẽ ném một [FileNotFoundException](https://reference.aspose.com/slides/vi/cpp/system.io/filenotfoundexception/) với thông điệp *License "Aspose.Slides.lic" doesn't exist or access is restricted*. Ví dụ không xử lý ngoại lệ, vì vậy chương trình dừng lại.

{{% alert color="warning" title="Warning" %}}
Nếu bạn đặt tệp giấy phép vào thư mục khác, khi gọi phương thức [License::SetLicense](https://reference.aspose.com/slides/vi/cpp/aspose.slides/license/setlicense/), tên tệp ở cuối đường dẫn đầy đủ phải khớp chính xác với tên tệp giấy phép của bạn.

Ví dụ, nếu bạn đổi tên tệp giấy phép thành *Aspose.Slides.lic.xml*, bạn phải truyền đường dẫn đầy đủ kết thúc bằng *Aspose.Slides.lic.xml* tới phương thức [License::SetLicense](https://reference.aspose.com/slides/vi/cpp/aspose.slides/license/setlicense/) trong mã của bạn.
{{% /alert %}}

### **Luồng**

Tải giấy phép từ một luồng khi chương trình của bạn không giữ giấy phép dưới dạng tệp có thể đặt tên, ví dụ, khi nó đọc giấy phép từ cơ sở dữ liệu. [License::SetLicense](https://reference.aspose.com/slides/vi/cpp/aspose.slides/license/setlicense/) chấp nhận bất kỳ [Stream](https://reference.aspose.com/slides/vi/cpp/system.io/stream/) nào chứa giấy phép. Để giữ ví dụ ngắn gọn, mã C++ sau mở *Aspose.Slides.lic* trong thư mục làm việc bằng [File::OpenRead](https://reference.aspose.com/slides/vi/cpp/system.io/file/openread/) và áp dụng giấy phép từ luồng đó:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Giấy phép hợp lệ cho kết quả giống như ví dụ tệp. Nếu tệp không tồn tại, [File::OpenRead](https://reference.aspose.com/slides/vi/cpp/system.io/file/openread/) sẽ ném một [FileNotFoundException](https://reference.aspose.com/slides/vi/cpp/system.io/filenotfoundexception/) trước khi giấy phép được áp dụng, và chương trình dừng lại.

## **Xác thực Giấy phép**

Để kiểm tra liệu giấy phép đã được thiết lập đúng chưa, gọi [License::IsLicensed](https://reference.aspose.com/slides/vi/cpp/aspose.slides/license/islicensed/). Nó sẽ trả về `true` chỉ sau khi một giấy phép hợp lệ đã được áp dụng, và `false` trước đó. Mã C++ sau áp dụng tệp giấy phép từ thư mục làm việc và sau đó kiểm tra nó:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

Với giấy phép hợp lệ, chương trình in *License is good!*. Nếu tệp bị thiếu hoặc không phải là tệp giấy phép, [License::SetLicense](https://reference.aspose.com/slides/vi/cpp/aspose.slides/license/setlicense/) sẽ ném ngoại lệ trước khi kiểm tra, và chương trình dừng lại mà không in gì. Nếu tệp là giấy phép nhưng chữ ký không khớp, ví dụ vì đã được chỉnh sửa, SetLicense sẽ trả về mà không có lỗi nhưng `IsLicensed` sẽ trả về `false`, vì vậy không có gì được in và Aspose.Slides vẫn ở chế độ đánh giá.

## **An toàn đa luồng**

{{% alert color="warning" title="Warning" %}}
Phương thức [License::SetLicense](https://reference.aspose.com/slides/vi/cpp/aspose.slides/license/setlicense/) **không an toàn đa luồng**. Nếu bạn cần gọi phương thức này từ nhiều luồng đồng thời, nên sử dụng các primitive đồng bộ (như lock) để ngăn ngừa các vấn đề tiềm ẩn.
{{% /alert %}}

## **Câu hỏi thường gặp**

### Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn offline (không có kết nối internet) không?

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không cần kết nối internet.

### Điều gì sẽ xảy ra sau khi đăng ký một năm hết hạn? Thư viện có ngừng hoạt động không?

Không. Giấy phép là vĩnh viễn: bạn có thể tiếp tục sử dụng các phiên bản được phát hành trước ngày kết thúc đăng ký; bạn chỉ không được phép sử dụng các bản phát hành mới hơn nếu không gia hạn.