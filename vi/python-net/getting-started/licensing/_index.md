---
title: Cấp phép
type: docs
weight: 80
url: /vi/python-net/licensing/
keywords:
- giấy phép
- giấy phép tạm thời
- đặt giấy phép
- sử dụng giấy phép
- xác thực giấy phép
- tệp giấy phép
- phiên bản đánh giá
- Python
- Aspose.Slides
description: "Tìm hiểu cách áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho Python via .NET. Đảm bảo truy cập liên tục vào đầy đủ tính năng với hướng dẫn cấp phép từng bước của chúng tôi."
---
## **Tổng quan**

Aspose.Slides có thể được sử dụng ở chế độ đánh giá hoặc với giấy phép hợp lệ. Phiên bản đánh giá cung cấp cùng chức năng với phiên bản có giấy phép, nhưng sẽ thêm dấu bản quyền đánh giá khi mở hoặc lưu bản trình chiếu và giới hạn việc trích xuất văn bản chỉ một slide.

## **Đánh giá Aspose.Slides**

Bạn có thể tải về phiên bản đánh giá của **Aspose.Slides for Python via .NET** từ [trang tải xuống](https://pypi.org/project/Aspose.Slides/). Phiên bản đánh giá cung cấp các tính năng giống như sản phẩm có giấy phép. Gói đánh giá giống hệt gói mua và sẽ trở thành giấy phép sau khi bạn thêm một vài dòng mã để áp dụng giấy phép.

Khi bạn hài lòng với quá trình đánh giá **Aspose.Slides**, bạn có thể [mua giấy phép](https://purchase.aspose.com/buy). Chúng tôi khuyên bạn nên xem xét các tùy chọn đăng ký có sẵn. Nếu có câu hỏi, hãy liên hệ với đội ngũ bán hàng của Aspose.

Mỗi giấy phép Aspose bao gồm một đăng ký một năm với việc nâng cấp miễn phí lên các phiên bản mới và các bản sửa lỗi trong thời gian đó. Cả người dùng có giấy phép và người dùng đánh giá đều nhận được hỗ trợ kỹ thuật không giới hạn và miễn phí.

**Giới hạn của Phiên bản Đánh giá**

* Mặc dù phiên bản đánh giá Aspose.Slides (khi chưa áp dụng giấy phép) cung cấp đầy đủ chức năng, nó sẽ thêm dấu bản quyền đánh giá ở đầu tài liệu mỗi khi bạn mở hoặc lưu nó.
* Khi trích xuất văn bản từ bản trình chiếu, bạn bị giới hạn chỉ một slide.

{{% alert color="primary" %}}

Để thử Aspose.Slides mà không có giới hạn, bạn có thể yêu cầu **Giấy phép Tạm thời 30 ngày**. Xem trang [Cách nhận Giấy phép Tạm thời](https://purchase.aspose.com/temporary-license) để biết chi tiết.

{{% /alert %}}

## **Giấy phép trong Aspose.Slides**

* Phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng mã để áp dụng.
* Giấy phép là một tệp XML dạng văn bản thuần chứa các thông tin như tên sản phẩm, số lượng nhà phát triển được bao phủ, ngày hết hạn đăng ký, v.v.
* Tệp giấy phép được ký số, vì vậy bạn không được chỉnh sửa nó. Ngay cả việc thêm một ký tự xuống dòng duy nhất cũng sẽ làm mất hiệu lực.
* Aspose.Slides for Python via .NET thường tìm kiếm giấy phép ở các vị trí sau:
  * Đường dẫn rõ ràng bạn cung cấp
  * Thư mục chứa script Python gọi Aspose.Slides for Python via .NET
* Để tránh các giới hạn đánh giá, hãy đặt giấy phép trước khi sử dụng Aspose.Slides. Bạn chỉ cần đặt một lần cho mỗi ứng dụng hoặc tiến trình.

{{% alert color="primary" %}}

Bạn cũng có thể muốn xem lại [Giấy phép Định mức](/slides/vi/python-net/metered-licensing/).

{{% /alert %}}

## **Áp dụng Giấy phép**

Giấy phép có thể được tải từ **tệp**, **luồng**, hoặc **tài nguyên nhúng**. 

{{% alert color="primary" %}}

Aspose.Slides cung cấp lớp [License](https://reference.aspose.com/slides/vi/python-net/aspose.slides/license/) để xử lý việc cấp phép.

{{% /alert %}}

{{% alert color="warning" %}}

Các giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản cũ hơn sử dụng hệ thống cấp phép khác và sẽ không nhận diện các giấy phép này.

{{% /alert %}}

### **Tệp**

Cách dễ nhất để đặt giấy phép là đặt tệp giấy phép cùng thư mục với DLL của thành phần và chỉ định tên tệp (không có đường dẫn).

Mã Python sau cho thấy cách đặt tệp giấy phép:

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp License. 
license = slides.License()

# Đặt đường dẫn tệp giấy phép.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}

Nếu bạn đặt tệp giấy phép ở thư mục khác, khi gọi [License.set_license()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/license/set_license/#str), tên tệp ở cuối đường dẫn rõ ràng phải khớp với tên tệp giấy phép của bạn.

Ví dụ, bạn có thể đổi tên tệp giấy phép thành *Aspose.Slides.lic.xml*. Sau đó, trong mã của bạn, truyền đường dẫn đầy đủ tới tệp đó (kết thúc bằng Aspose.Slides.lic.xml) vào phương thức [License.set_license()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/license/set_license/#str).

{{% /alert %}}

### **Luồng**

Bạn có thể tải giấy phép từ một luồng. Ví dụ Python sau cho thấy cách áp dụng giấy phép từ luồng:

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp License.
license = slides.License()

# Đặt giấy phép từ một luồng.
license.set_license(stream)
```

## **Xác thực Giấy phép**

Để kiểm tra rằng giấy phép đã được áp dụng đúng, bạn có thể xác thực nó. Mã Python sau minh họa cách xác thực giấy phép:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **An toàn đa luồng**

{{% alert title="Lưu ý" color="warning" %}}

Các phương pháp [License.set_license](https://reference.aspose.com/slides/vi/python-net/aspose.slides/license/) không an toàn đa luồng. Nếu cần gọi đồng thời từ nhiều luồng, hãy sử dụng các primitive đồng bộ (ví dụ, `threading.Lock`) để tránh vấn đề.

{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn offline (không có kết nối internet) không?**

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không cần kết nối internet.

**Điều gì sẽ xảy ra sau khi đăng ký một năm hết hạn? Thư viện có ngừng hoạt động không?**

Không. Giấy phép là vĩnh viễn: bạn có thể tiếp tục sử dụng các phiên bản được phát hành trước ngày kết thúc đăng ký; bạn chỉ không được phép dùng các bản phát hành mới hơn nếu không gia hạn.