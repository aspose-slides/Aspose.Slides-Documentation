---
title: Cấp phép
description: "Aspose.Slides cho Python qua Java cung cấp các gói mua khác nhau hoặc cung cấp Dùng thử Miễn phí và Giấy phép Tạm thời 30 ngày để đánh giá dựa trên các chính sách Cấp phép và Đăng ký."
type: docs
weight: 80
url: /vi/python-java/licensing/
---
Đôi khi, để đạt được kết quả đánh giá tốt nhất, có thể cần một cách tiếp cận thực tế. Vì lý do này, Aspose.Slides cung cấp các gói mua khác nhau và cũng cung cấp Dùng thử Miễn phí và Giấy phép Tạm thời 30 ngày để đánh giá.

{{% alert color="primary" %}}
Lưu ý rằng có một số chính sách và thực tiễn chung hướng dẫn bạn cách đánh giá, cấp phép đúng cách, và mua sản phẩm của chúng tôi. Bạn có thể tìm chúng trong phần [Chính sách Mua và Câu hỏi thường gặp](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Đánh giá Aspose.Slides**
Bạn có thể dễ dàng tải xuống Aspose.Slides để đánh giá. Gói đánh giá giống hệt gói đã mua. Phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn thêm một vài dòng mã để áp dụng giấy phép. 

## **Giới hạn Phiên bản Đánh giá**
Phiên bản đánh giá của Aspose.Slides (không chỉ định giấy phép) cung cấp đầy đủ chức năng của sản phẩm, nhưng nó chèn dấu mực đánh giá ở đầu tài liệu khi mở và lưu. Bạn cũng bị giới hạn chỉ một slide khi trích xuất văn bản từ các slide trình chiếu.

{{% alert color="primary" %}} 
Nếu bạn muốn thử Aspose.Slides mà không có các giới hạn của phiên bản đánh giá, bạn có thể yêu cầu **Giấy phép Tạm thời 30 Ngày**. Vui lòng tham khảo [Cách nhận Giấy phép Tạm thời?](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.
{{% /alert %}} 

## **Về Giấy phép**
Bạn có thể dễ dàng tải xuống phiên bản đánh giá của Aspose.Slides cho Python via Java từ [trang tải xuống](https://releases.aspose.com/slides/vi/python-java/). Phiên bản đánh giá cung cấp **các khả năng giống hệt** như phiên bản có giấy phép của Aspose.Slides. Hơn nữa, phiên bản đánh giá sẽ trở thành có giấy phép ngay sau khi bạn mua giấy phép và thêm một vài dòng mã để áp dụng giấy phép.

Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được cấp phép, ngày hết hạn thuê bao, v.v. Tệp được ký số, vì vậy không được chỉnh sửa tệp. Ngay cả việc vô tình thêm một dòng mới vào nội dung tệp cũng sẽ làm cho nó không hợp lệ.

Để tránh các giới hạn liên quan đến phiên bản đánh giá, bạn cần thiết lập giấy phép trước khi sử dụng **Aspose.Slides**. Bạn chỉ cần thiết lập giấy phép một lần cho mỗi ứng dụng hoặc quy trình.

## Giấy phép đã mua

Sau khi mua, bạn cần áp dụng tệp hoặc luồng giấy phép. 

{{% alert color="primary" %}}
Bạn cần thiết lập giấy phép:
* chỉ một lần cho mỗi miền ứng dụng
* trước khi sử dụng bất kỳ lớp Aspose.Slides nào khác
{{% /alert %}}

{{% alert color="primary" %}}
Bạn có thể tìm thông tin giá trên trang [“Thông tin Giá cả”](https://purchase.aspose.com/pricing/slides/vi/family).
{{% /alert %}}

### **Cài đặt Giấy phép trong Aspose.Slides cho Python via Java**

Giấy phép có thể được áp dụng từ các vị trí sau:

* Đường dẫn cụ thể
* Luồng
* Như một Giấy phép Đo lường – cơ chế cấp phép mới

{{% alert color="primary" %}}
Sử dụng phương thức **setLicense** để cấp phép cho một thành phần.
Mặc dù việc gọi **setLicense** nhiều lần không gây hại, nhưng chúng là sự lãng phí tài nguyên (bộ xử lý).
{{% /alert %}}

{{% alert color="warning" %}}
Giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản cũ hơn sử dụng hệ thống cấp phép khác và sẽ không nhận ra các giấy phép này.
{{% /alert %}}

#### **Áp dụng Giấy phép bằng Tệp**

Đoạn mã này được sử dụng để thiết lập tệp giấy phép:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

Khi gọi phương thức setLicense, tên giấy phép nên giống với tên tệp giấy phép của bạn. Ví dụ, bạn có thể đổi tên tệp giấy phép thành "Aspose.Slides.lic.xml". Sau đó, trong mã của bạn, bạn phải truyền tên giấy phép mới (Aspose.Slides.lic.xml) vào phương thức setLicense.

#### **Áp dụng Giấy phép từ Dòng Byte**

Đoạn mã này được sử dụng để áp dụng giấy phép từ dòng byte:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Áp dụng Giấy phép Đo lường

Aspose.Slides cho phép các nhà phát triển áp dụng khóa đo lường. Đây là một cơ chế cấp phép mới.

Cơ chế cấp phép mới sẽ được sử dụng cùng với phương pháp cấp phép hiện có. Những khách hàng muốn bị tính phí dựa trên việc sử dụng các tính năng API có thể sử dụng Giấy phép Đo lường.

Sau khi hoàn thành tất cả các bước cần thiết để nhận loại giấy phép này, bạn sẽ nhận được các khóa, không phải tệp giấy phép. Khóa đo lường này có thể được áp dụng bằng lớp **Metered** được giới thiệu đặc biệt cho mục đích này.

Ví dụ mã sau cho thấy cách thiết lập các khóa công khai và riêng tư của giấy phép đo lường:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Tạo một thể hiện của lớp CAD Metered
metered = Metered();

# Truy cập thuộc tính set_metered_key và truyền các khóa công khai và riêng tư làm tham số
metered.setMeteredKey("*****", "*****");

# Lấy lượng dữ liệu đo lường trước khi gọi API
amountbefore = Metered.getConsumptionQuantity()

# Hiển thị thông tin
print("Amount Consumed Before: \" + amountbefore + "\"" )

# Tải tài liệu từ đĩa.
pres = Presentation();

# Lấy số lượng trang của tài liệu
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# Lưu dưới dạng PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Lấy lượng dữ liệu đo lường sau khi gọi API
amountafter = Metered.getConsumptionQuantity()

# Hiển thị thông tin
print("Amount Consumed After: \" + amountafter + "\"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}
Vui lòng lưu ý rằng bạn phải có kết nối Internet ổn định để sử dụng giấy phép Đo lường một cách chính xác, vì cơ chế Đo lường yêu cầu tương tác liên tục với dịch vụ của chúng tôi để thực hiện các phép tính đúng đắn. Để biết thêm chi tiết, xem mục [“Câu hỏi thường gặp về Giấy phép Đo lường”](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}}