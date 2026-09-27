---
title: Cấp phép
type: docs
weight: 80
url: /vi/python-net/licensing/
keywords:
- giấy phép
- giấy phép tạm thời
- cài đặt giấy phép
- sử dụng giấy phép
- xác thực giấy phép
- tệp giấy phép
- phiên bản đánh giá
- Python
- Aspose.Slides
description: "Tìm hiểu cách áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho Python qua .NET. Đảm bảo truy cập không gián đoạn vào tất cả tính năng với hướng dẫn cấp phép từng bước của chúng tôi."
---
## **Tổng quan**

Aspose.Slides có thể được sử dụng ở chế độ đánh giá hoặc với giấy phép hợp lệ. Phiên bản đánh giá cung cấp cùng chức năng như phiên bản có giấy phép, nhưng nó sẽ thêm một dấu watermark đánh giá vào mỗi slide của mọi bản trình chiếu mà nó lưu và cắt ngắn văn bản mà mã của bạn đọc từ các bản trình chiếu.

## **Đánh giá Aspose.Slides**

Bạn có thể tải phiên bản đánh giá của **Aspose.Slides for Python via .NET** từ [trang tải xuống](https://pypi.org/project/Aspose.Slides/). Phiên bản đánh giá cung cấp các tính năng giống như sản phẩm có giấy phép. Gói đánh giá giống hệt gói đã mua và sẽ được cấp phép sau khi bạn thêm một vài dòng mã để áp dụng giấy phép.

Khi bạn đã hài lòng với việc đánh giá **Aspose.Slides**, bạn có thể [mua giấy phép](https://purchase.aspose.com/pricing/slides/python-net/). Chúng tôi khuyên bạn nên xem xét các tùy chọn đăng ký có sẵn. Nếu có thắc mắc, hãy liên hệ với đội ngũ bán hàng của Aspose.

Mỗi giấy phép Aspose bao gồm một đăng ký một năm với các bản nâng cấp miễn phí đến các phiên bản mới và các bản sửa lỗi được phát hành trong khoảng thời gian đó. Cả người dùng có giấy phép và người dùng đánh giá đều nhận được hỗ trợ kỹ thuật miễn phí và không giới hạn.

**Các hạn chế của phiên bản đánh giá**

* Phiên bản đánh giá (khi chưa áp dụng giấy phép) cung cấp đầy đủ chức năng, nhưng nó sẽ thêm một hộp văn bản watermark đánh giá vào mỗi slide của mọi bản trình chiếu mà nó lưu.
* Văn bản mà mã của bạn đọc từ một bản trình chiếu sẽ bị cắt ngắn đến một vài ký tự đầu, kèm theo thông báo về hạn chế đánh giá. Văn bản mà mã của bạn ghi sẽ được lưu đầy đủ.

{{% alert color="info" title="Lưu ý" %}}

Để thử Aspose.Slides mà không gặp các hạn chế, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Xem trang [Cách lấy Giấy phép Tạm thời](https://purchase.aspose.com/temporary-license) để biết chi tiết.

{{% /alert %}}

## **Cấp phép trong Aspose.Slides**

* Phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng mã để áp dụng nó.
* Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được bao phủ, ngày hết hạn đăng ký, v.v.
* Tệp giấy phép được ký số, vì vậy bạn không được phép chỉnh sửa nó. Ngay cả khi thêm một dòng ngắt dòng duy nhất cũng sẽ làm cho giấy phép không còn hiệu lực.
* Aspose.Slides for Python via .NET sẽ tìm kiếm giấy phép tại đường dẫn bạn cung cấp. Đường dẫn tương đối, hoặc tên tệp không có đường dẫn, sẽ được giải quyết dựa trên thư mục làm việc hiện tại, không nhất thiết là thư mục chứa script Python của bạn.
* Để tránh các hạn chế đánh giá, hãy đặt giấy phép trước khi sử dụng Aspose.Slides. Bạn chỉ cần thiết lập một lần cho mỗi ứng dụng hoặc tiến trình.

{{% alert color="info" title="Lưu ý" %}}

Bạn cũng có thể muốn xem lại [Metered Licensing](/slides/vi/python-net/metered-licensing/).

{{% /alert %}}

## **Áp dụng Giấy phép**

Giấy phép có thể được tải từ **tệp** hoặc **luồng**.

{{% alert color="info" title="Lưu ý" %}}

Aspose.Slides cung cấp lớp [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) để xử lý việc cấp phép.

{{% /alert %}}

{{% alert color="warning" title="Cảnh báo" %}}

Giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản cũ hơn sử dụng hệ thống cấp phép khác và sẽ không nhận ra các giấy phép này.

{{% /alert %}}

### **Tệp**

Cách đơn giản nhất để thiết lập giấy phép là truyền đường dẫn của tệp giấy phép vào phương thức [set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/). Nếu bạn chỉ truyền tên tệp, như trong ví dụ bên dưới, Aspose.Slides sẽ tìm tệp trong thư mục làm việc hiện tại.

Đoạn mã Python sau cho thấy cách thiết lập tệp giấy phép:

```py
import aspose.slides as slides

# Khởi tạo lớp License. 
license = slides.License()

# Đặt đường dẫn tệp giấy phép.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Cảnh báo" %}}

Nếu bạn đặt tệp giấy phép trong một thư mục khác, khi gọi [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str), tên tệp ở cuối đường dẫn tuyệt đối phải trùng khớp với tên tệp giấy phép của bạn.

Ví dụ, bạn có thể đổi tên tệp giấy phép thành *Aspose.Slides.lic.xml*. Sau đó, trong mã của bạn, truyền đường dẫn đầy đủ tới tệp đó (kết thúc bằng Aspose.Slides.lic.xml) vào phương thức [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str).

{{% /alert %}}

### **Luồng**

Bạn có thể tải giấy phép từ một luồng. Ví dụ Python sau cho thấy cách áp dụng giấy phép từ luồng:

```py
import aspose.slides as slides

# Khởi tạo lớp License.
license = slides.License()

# Đặt giấy phép từ một luồng.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **Xác thực Giấy phép**

Để xác minh rằng giấy phép đã được áp dụng đúng, bạn có thể thực hiện xác thực. Đoạn mã Python sau minh họa cách xác thực giấy phép:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **An toàn đa luồng**

{{% alert color="warning" title="Cảnh báo" %}}

Phương thức [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) không an toàn đa luồng. Nếu bạn cần gọi nó đồng thời từ nhiều luồng, hãy sử dụng một primitive đồng bộ, chẳng hạn `threading.Lock`, để tránh các vấn đề.

{{% /alert %}}

## **Câu hỏi thường gặp**

### Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn offline (không có kết nối internet) không?

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không cần kết nối internet.

### Điều gì sẽ xảy ra sau khi đăng ký một năm hết hạn? Thư viện có ngừng hoạt động không?

Không. Giấy phép là vĩnh viễn: bạn vẫn có thể sử dụng các phiên bản được phát hành trước ngày kết thúc đăng ký; chỉ không đủ điều kiện sử dụng các bản phát hành mới hơn nếu không gia hạn.