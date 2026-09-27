---
title: Cấp phép
type: docs
weight: 80
url: /vi/nodejs-java/licensing/
keywords:
- giấy phép
- giấy phép tạm thời
- đặt giấy phép
- sử dụng giấy phép
- xác thực giấy phép
- tệp giấy phép
- phiên bản đánh giá
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho Node.js. Đảm bảo truy cập liên tục vào các tính năng đầy đủ với hướng dẫn cấp phép từng bước của chúng tôi."
---
## **Giới thiệu**

Đôi khi, để đạt được kết quả đánh giá tốt nhất, có thể cần một phương pháp thực hành. Vì lý do này, Aspose.Slides cung cấp các gói mua khác nhau và cũng cung cấp Dùng thử miễn phí và Giấy phép tạm thời 30 ngày để đánh giá.

{{% alert color="info" title="Note" %}}
Lưu ý rằng có một số chính sách và thực tiễn chung hướng dẫn bạn cách đánh giá, cấp phép đúng cách và mua sản phẩm của chúng tôi. Bạn có thể tìm thấy chúng trong phần ["Chính sách mua hàng và Câu hỏi thường gặp"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Đánh giá Aspose.Slides**
Bạn có thể dễ dàng tải xuống Aspose.Slides để đánh giá. Gói đánh giá giống hệt gói đã mua. Phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn thêm một vài dòng mã để áp dụng giấy phép.

## **Hạn chế của phiên bản Đánh giá**
Phiên bản đánh giá của Aspose.Slides (không có giấy phép được chỉ định) cung cấp đầy đủ chức năng của sản phẩm, với hai hạn chế:

* Nó thêm một hộp văn bản watermark đánh giá vào mỗi slide của mỗi bản trình chiếu khi lưu.
* Văn bản dài hơn năm ký tự mà mã của bạn đọc từ bản trình chiếu sẽ bị cắt còn năm ký tự đầu tiên, tiếp theo là `... text has been truncated due to evaluation version limitation.` Văn bản có năm ký tự hoặc ít hơn sẽ được trả về nguyên vẹn, và văn bản mà mã của bạn ghi sẽ được lưu đầy đủ.

{{% alert color="info" title="Note" %}}
Nếu bạn muốn thử Aspose.Slides mà không bị hạn chế của phiên bản đánh giá, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Vui lòng tham khảo [Cách lấy Giấy phép tạm thời?](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.
{{% /alert %}}

## **Về Giấy phép**
Bạn có thể dễ dàng tải xuống một phiên bản đánh giá của Aspose.Slides cho Node.js via Java từ [trang tải xuống](https://releases.aspose.com/slides/vi/nodejs-java/). Phiên bản đánh giá có cùng các tính năng như phiên bản có giấy phép, với các hạn chế đã mô tả ở trên. Hơn nữa, phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng mã để áp dụng giấy phép.

Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số nhà phát triển được cấp phép, ngày hết hạn đăng ký, v.v. Tệp được ký số, vì vậy không được chỉnh sửa tệp. Ngay cả một dấu ngắt dòng thừa trong nội dung tệp cũng sẽ làm mất hiệu lực của nó.

Để tránh các hạn chế liên quan đến phiên bản đánh giá, bạn cần thiết lập giấy phép trước khi sử dụng **Aspose.Slides**. Bạn chỉ cần thiết lập giấy phép một lần cho mỗi ứng dụng hoặc quá trình.

{{% alert color="info" title="Note" %}}
Bạn có thể muốn xem [Metered Licensing](/slides/vi/nodejs-java/metered-licensing/).
{{% /alert %}}

## **Giấy phép đã mua**

Sau khi mua, bạn cần áp dụng tệp hoặc luồng giấy phép.

{{% alert color="info" title="Note" %}}
Bạn cần thiết lập giấy phép:
* chỉ một lần cho mỗi quá trình
* trước khi sử dụng bất kỳ lớp Aspose.Slides nào khác
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Bạn có thể tìm thông tin giá cả trên trang ["Thông tin Giá cả"](https://purchase.aspose.com/pricing/slides/vi/family).
{{% /alert %}}

### **Thiết lập Giấy phép trong Aspose.Slides cho Node.js via Java**

Giấy phép có thể được áp dụng từ các vị trí sau:

* Đường dẫn rõ ràng
* Luồng
* Dưới dạng Giấy phép Định mức – một cơ chế cấp phép mới

{{% alert color="info" title="Note" %}}
Sử dụng phương thức **setLicense** để cấp phép cho một thành phần.

Mặc dù gọi **setLicense** nhiều lần không gây hại, nhưng chúng là lãng phí tài nguyên (bộ xử lý).
{{% /alert %}}

#### **Áp dụng Giấy phép bằng Tệp**

Đoạn mã này được sử dụng để thiết lập tệp giấy phép:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides chạy trong một máy ảo Java giữ Node.js hoạt động, vì vậy hãy kết thúc tiến trình một cách rõ ràng.
process.exit(0);
```

Khi gọi phương thức setLicense, tên giấy phép phải trùng với tên tệp giấy phép của bạn. Ví dụ, bạn có thể đổi tên tệp giấy phép thành "Aspose.Slides.lic.xml". Sau đó, trong mã của bạn, phải truyền tên giấy phép mới (Aspose.Slides.lic.xml) cho phương thức setLicense. Nếu tệp bị thiếu hoặc không chứa giấy phép hợp lệ, [setLicense](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/license/setlicense/) sẽ ném ngoại lệ, khiến script kết thúc với lỗi.

#### **Áp dụng Giấy phép từ Luồng**

Để áp dụng giấy phép từ một luồng, truyền đối tượng [License](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/license/) và một luồng đọc được cho phương thức tĩnh [setLicenseFromStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/license/setlicense/). Luồng được đọc bất đồng bộ, và callback sẽ nhận lỗi nếu luồng không chứa giấy phép hợp lệ:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides chạy trong một máy ảo Java giữ Node.js hoạt động, vì vậy hãy kết thúc tiến trình một cách rõ ràng.
    process.exit(0);
});
```

Giấy phép được áp dụng khi toàn bộ luồng đã được đọc, ngay trước khi callback chạy, vì vậy hãy bắt đầu công việc Aspose.Slides khác từ callback.

Cả hai mẫu đều gọi `process.exit(0)` khi hoàn thành, vì máy ảo Java chạy Aspose.Slides làm Node.js tiếp tục chạy. Trong một ứng dụng, hãy tiếp tục với mã Aspose.Slides của bạn thay vì kết thúc quá trình.

## **Câu hỏi thường gặp**

### Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn ngoại tuyến (không có kết nối internet) không?

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không cần kết nối internet.

### Điều gì sẽ xảy ra sau khi đăng ký một năm hết hạn? Thư viện có ngừng hoạt động không?

Không. Giấy phép là vĩnh viễn: bạn có thể tiếp tục sử dụng các phiên bản được phát hành trước ngày kết thúc đăng ký; bạn chỉ không đủ điều kiện sử dụng các phiên bản mới hơn nếu không gia hạn.