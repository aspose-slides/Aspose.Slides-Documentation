---
title: Cấp phép
description: "Áp dụng tệp giấy phép cho Aspose.Slides cho Node.js qua .NET, xem những giới hạn của phiên bản dùng thử, và nhận giấy phép tạm thời miễn phí trong 30 ngày để thử nghiệm."
type: docs
weight: 80
url: /vi/nodejs-net/licensing/
---
## **Tổng quan**

Aspose.Slides for Node.js via .NET là một gói npm cho cả việc đánh giá và sản xuất. Nếu không có giấy phép, nó chạy ở chế độ dùng thử. Sau khi bạn mua giấy phép, hoặc nhận giấy phép tạm thời miễn phí trong 30 ngày, bạn áp dụng nó bằng vài dòng mã, và các hạn chế của phiên bản dùng thử sẽ không còn áp dụng.

{{% alert color="info" title="Note" %}}

Chính sách chung về cách đánh giá, cấp phép và mua sản phẩm Aspose được tổng hợp trong [Purchase Policies and FAQ](https://purchase.aspose.com/policies). Giá cả được liệt kê trên trang [Pricing Information](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

## **Các hạn chế của phiên bản dùng thử**

Phiên bản dùng thử cung cấp đầy đủ chức năng của sản phẩm, nhưng có hai hạn chế:

- **Dấu mờ.** Mỗi slide của mỗi bản trình chiếu mà bạn lưu sẽ có một dấu mờ dùng thử: một hộp văn bản khóa ở trung tâm slide có nội dung "Evaluation only." Dấu mờ này cũng được vẽ trên các xuất PDF, XPS và HTML và trên hình ảnh slide.
- **Văn bản bị cắt ngắn.** Văn bản mà mã của bạn đọc lại từ khung văn bản, đoạn văn hoặc phần sẽ bị cắt tới năm ký tự đầu tiên, tiếp theo là thông báo "... text has been truncated due to evaluation version limitation." Các xuất Markdown và HTML5 cũng bị cắt tương tự. Văn bản mà mã của bạn ghi sẽ được lưu đầy đủ.

[Evaluate Aspose.Slides](/slides/vi/nodejs-net/evaluate-aspose-slides/) mô tả chi tiết cả hai hạn chế và bao gồm một script hiển thị chúng.

{{% alert color="success" title="Tip" %}}

Để thử Aspose.Slides mà không gặp các hạn chế của phiên bản dùng thử, hãy yêu cầu giấy phép tạm thời miễn phí **30 ngày**. Xem [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) để biết chi tiết.

{{% /alert %}}

## **Về giấy phép**

Giấy phép là một tệp XML dạng văn bản thuần chứa các thông tin như tên sản phẩm, số lượng nhà phát triển được cấp phép, và ngày hết hạn thuê bao. Tệp này được ký số, vì vậy không được chỉnh sửa: ngay cả một dấu xuống dòng thừa do nhầm lẫn cũng làm tệp mất hiệu lực.

## **Áp dụng giấy phép**

Áp dụng giấy phép bằng phương thức `setLicense` của lớp `License`. Gọi một lần cho mỗi quá trình, trước khi bạn tạo bất kỳ đối tượng `Presentation` nào. Gọi lại không gây hại, nhưng sẽ lặp lại công việc đã thực hiện.

Script sau sẽ áp dụng giấy phép từ tệp có tên `Aspose.Slides.lic`. Thay tên này bằng tên hoặc đường dẫn đầy đủ của tệp giấy phép của bạn; tệp có thể có bất kỳ tên nào.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

Tên tệp hoặc đường dẫn tương đối sẽ được giải quyết dựa trên thư mục hiện tại, là thư mục bạn chạy `node` từ đó. Giữ tệp giấy phép trong thư mục dự án và chạy script từ đó, hoặc truyền đường dẫn đầy đủ.

Nếu tệp không tìm thấy, hoặc không phải là giấy phép hợp lệ, `setLicense` sẽ ném ra lỗi, và Aspose.Slides sẽ ở chế độ dùng thử. Script sẽ bắt lỗi và in thông báo của nó. Đối với tệp bị thiếu, thông báo bắt đầu bằng `License "Aspose.Slides.lic" doesn't exist or access is restricted.` và liệt kê mọi vị trí đã được tìm kiếm.

Trong gói này, giấy phép chỉ được áp dụng từ tệp. `License` không chấp nhận luồng, và gói không cung cấp giấy phép tính theo mức sử dụng. Đối với lớp mà gói đóng gói, xem [License](https://reference.aspose.com/slides/net/aspose.slides/license/) trong tài liệu API Aspose.Slides cho .NET.