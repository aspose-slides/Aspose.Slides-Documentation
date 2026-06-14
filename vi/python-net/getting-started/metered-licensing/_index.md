---
title: "Giấy phép đo lường"
type: docs
weight: 90
url: /vi/python-net/metered-licensing/
keywords:
- "giấy phép"
- "giấy phép đo lường"
- "khóa giấy phép"
- "khóa công khai"
- "khóa riêng tư"
- "số lượng tiêu thụ"
- "Python"
- "Aspose.Slides"
description: "Tìm hiểu cách giấy phép đo lường Aspose.Slides cho Python thông qua .NET cho phép bạn xử lý các tệp PowerPoint và OpenDocument một cách linh hoạt, chỉ trả tiền cho những gì bạn sử dụng."
---
## **Giới thiệu**

Giấy phép đo lường là một cơ chế cấp phép có thể được sử dụng cùng với các phương pháp cấp phép hiện có. Nếu bạn muốn được tính phí dựa trên việc sử dụng các tính năng API của Aspose.Slides, bạn chọn giấy phép đo lường.

## **Áp dụng khóa đo lường**

{{% alert color="primary" %}} 

Giấy phép đo lường là một cơ chế cấp phép mới có thể được sử dụng cùng với các phương pháp cấp phép hiện có. Nếu bạn muốn được tính phí dựa trên việc sử dụng các tính năng API của Aspose.Slides, bạn chọn giấy phép đo lường.

Khi bạn mua giấy phép đo lường, bạn sẽ nhận được các khóa (không phải tệp giấy phép). Khóa đo lường này có thể được áp dụng bằng cách sử dụng lớp [Metered](https://reference.aspose.com/slides/vi/python-net/aspose.slides/metered/) do Aspose cung cấp cho các thao tác đo lường. Để biết thêm chi tiết, xem [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Tạo một thể hiện của lớp [Metered](https://reference.aspose.com/slides/vi/python-net/aspose.slides/metered/).
1. Gửi các khóa công khai và riêng tư của bạn đến phương thức [set_metered_key](https://reference.aspose.com/slides/vi/python-net/aspose.slides/metered/set_metered_key/#str-str).
1. Thực hiện một số xử lý (thực hiện các tác vụ).
1. Gọi phương thức [get_consumption_quantity](https://reference.aspose.com/slides/vi/python-net/aspose.slides/metered/get_consumption_quantity/#) của lớp `Metered`.

Bạn sẽ thấy số lượng/khối lượng các yêu cầu API mà bạn đã tiêu thụ cho đến hiện tại.

Mã mẫu này cho bạn thấy cách sử dụng giấy phép đo lường:

```python
import aspose.slides as slides

# Tạo một thể hiện của lớp Metered
metered = slides.Metered()

# Gửi khóa công khai và riêng tư tới đối tượng Metered
metered.set_metered_key("<valid public key>", "<valid private key>")

# Lấy giá trị số lượng đã tiêu thụ trước các lời gọi API
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Thực hiện một việc gì đó với API Aspose.Slides ở đây
# ...

# Lấy giá trị số lượng đã tiêu thụ sau các lời gọi API
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

Để sử dụng giấy phép đo lường, bạn cần một kết nối internet ổn định vì cơ chế cấp phép sử dụng internet để liên tục tương tác với dịch vụ của chúng tôi và thực hiện các tính toán.

{{% /alert %}} 

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng giấy phép đo lường cùng với giấy phép thường (vĩnh viễn hoặc tạm thời) trong cùng một ứng dụng không?**

Có. Giấy phép đo lường là một cơ chế cấp phép bổ sung có thể được sử dụng cùng với các [phương pháp cấp phép](/slides/vi/python-net/licensing/) hiện có. Bạn chọn cơ chế nào sẽ áp dụng khi ứng dụng khởi động.

**Cụ thể, việc tiêu thụ trong giấy phép đo lường được tính dựa trên gì: các thao tác hay tệp?**

Việc sử dụng API được tính, nghĩa là số lượng yêu cầu hoặc thao tác. Bạn có thể lấy mức tiêu thụ hiện tại qua [các phương pháp theo dõi tiêu thụ](https://reference.aspose.com/slides/vi/python-net/aspose.slides/metered/).

**Giấy phép đo lường có phù hợp cho môi trường microservices và serverless, nơi các instance thường khởi động lại không?**

Có. Vì việc tính toán được thực hiện ở mức gọi API, các kịch bản có khởi động lạnh thường xuyên vẫn tương thích, với điều kiện có kết nối mạng ổn định để thực hiện các tính toán đo lường.

**Chức năng của thư viện có khác nhau khi sử dụng giấy phép đo lường so với giấy phép vĩnh viễn không?**

Không. Điều này chỉ liên quan đến cơ chế cấp phép và thanh toán; khả năng của sản phẩm vẫn giống nhau.

**Giấy phép đo lường liên quan như thế nào tới phiên bản dùng thử và giấy phép tạm thời?**

Phiên bản dùng thử có các hạn chế và watermark, [giấy phép tạm thời](https://purchase.aspose.com/temporary-license/) loại bỏ các hạn chế trong 30 ngày, và giấy phép đo lường loại bỏ hạn chế và tính phí dựa trên việc sử dụng thực tế.

**Tôi có thể kiểm soát ngân sách bằng cách tự động phản hồi khi ngưỡng tiêu thụ bị vượt quá không?**

Có. Thực hành phổ biến là định kỳ đọc mức tiêu thụ hiện tại qua [các phương pháp theo dõi](https://reference.aspose.com/slides/vi/python-net/aspose.slides/metered/) và triển khai các giới hạn hoặc cảnh báo riêng ở mức ứng dụng hoặc giám sát.