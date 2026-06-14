---
title: Cấu hình Thay thế Phông chữ trong Bản trình chiếu bằng Python
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/python-net/font-substitution/
keywords:
- phông chữ
- phông chữ thay thế
- thay thế phông chữ
- thay đổi phông chữ
- thay thế phông chữ
- quy tắc thay thế
- quy tắc thay đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Kích hoạt việc thay thế phông chữ tối ưu trong Aspose.Slides cho Python thông qua .NET khi chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang các định dạng tệp khác."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ khác khi phông chữ gốc của bản trình chiếu không khả dụng trong quá trình hiển thị hoặc chuyển đổi. Bạn có thể kiểm tra các phông chữ đã được thay thế bằng cách sử dụng phương thức `get_substitutions` của lớp `FontsManager`.

Aspose.Slides cũng cho phép bạn định nghĩa các quy tắc thay thế phông chữ. Ví dụ, bạn có thể chỉ định rằng một phông chữ không thể truy cập sẽ được thay bằng một phông chữ khác có sẵn và sau đó áp dụng các quy tắc này thông qua font manager của bản trình chiếu.

## **Đặt Quy Tắc Thay Thế**

Aspose.Slides cho phép bạn đặt các quy tắc cho phông chữ để xác định những gì cần thực hiện trong các điều kiện nhất định (ví dụ, khi một phông chữ không thể truy cập) như sau:

1. Tải bản trình chiếu liên quan.
2. Tải phông chữ sẽ được thay thế.
3. Tải phông chữ mới.
4. Thêm một quy tắc cho việc thay thế.
5. Thêm quy tắc vào bộ sưu tập quy tắc thay thế phông chữ của bản trình chiếu.
6. Tạo ảnh slide để quan sát hiệu quả.

Đoạn mã Python này minh họa quy trình thay thế phông chữ:

```python
import aspose.slides as slides

# Tải một bản trình chiếu
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Tải phông chữ nguồn sẽ được thay thế
    sourceFont = slides.FontData("SomeRareFont")

    # Tải phông chữ mới
    destFont = slides.FontData("Arial")

    # Thêm một quy tắc phông chữ cho việc thay thế phông chữ
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Thêm quy tắc vào bộ sưu tập các quy tắc thay thế phông chữ
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Thêm bộ sưu tập quy tắc phông chữ vào danh sách quy tắc
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial phông chữ sẽ được sử dụng thay cho SomeRareFont khi phông chữ này không thể truy cập
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Lưu hình ảnh vào đĩa ở định dạng JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 
Bạn có thể muốn xem [**Thay Thế Font**](/slides/vi/python-net/font-replacement/). 
{{% /alert %}}

## **Hạn Chế Đối Với Phông Chữ Phương Trình Toán Học**

Các quy tắc thay thế phông chữ tham gia vào quá trình lựa chọn phông chữ tiêu chuẩn được sử dụng trong quá trình hiển thị và chuyển đổi. Chúng phù hợp cho các trường hợp văn bản thông thường, nơi Aspose.Slides có thể thay thế một phông chữ không thể truy cập bằng một phông chữ khả dụng khác theo quy tắc đã cấu hình.

Tuy nhiên, các phương trình toán học của Office có một giới hạn quan trọng. Nếu một phương trình được tạo bằng **Cambria Math**, Aspose.Slides vẫn có thể yêu cầu phông chữ **Cambria Math** gốc để tính toán và hiển thị bố cục phương trình một cách chính xác. Do đó, việc thay thế **Cambria Math** bằng một phông chữ toán học khác, chẳng hạn như **STIX Two Math**, không được hỗ trợ cho việc hiển thị phương trình và có thể vẫn gây ra ngoại lệ cho biết **Cambria Math** là bắt buộc.

Để chuyển đổi các bản trình chiếu như vậy thành công, hãy đảm bảo rằng **Cambria Math** có sẵn cho Aspose.Slides tại thời gian chạy. Bạn có thể cài đặt phông chữ này trong hệ điều hành hoặc cung cấp nó dưới dạng một [phông chữ bên ngoài](/slides/vi/python-net/custom-font/) để nó có thể tham gia vào quá trình lựa chọn phông chữ bình thường trong quá trình hiển thị và chuyển đổi.

Giới hạn này chỉ áp dụng cho việc hiển thị phương trình. Các quy tắc thay thế phông chữ tiêu chuẩn đã mô tả ở trên vẫn áp dụng cho văn bản bình thường của bản trình chiếu khi phông chữ gốc không khả dụng.

## **Câu Hỏi Thường Gặp**

**Sự khác biệt giữa việc **Replacement** và **Substitution** là gì?**

[Replacement](/slides/vi/python-net/font-replacement/) là việc ghi đè cưỡng chế một phông chữ bằng một phông chữ khác trên toàn bộ bản trình chiếu. Substitution là một quy tắc được kích hoạt trong một điều kiện cụ thể, ví dụ khi phông chữ gốc không khả dụng, và sau đó một phông chữ dự phòng được chỉ định sẽ được sử dụng.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào chuỗi [font selection](/slides/vi/python-net/font-selection-sequence/) tiêu chuẩn được đánh giá trong quá trình tải, hiển thị và chuyển đổi; nếu phông chữ được chọn không khả dụng, việc thay thế hoặc substitution sẽ được áp dụng.

**Hành vi mặc định là gì nếu không có cả việc thay thế hay substitution nào được cấu hình và phông chữ thiếu trên hệ thống?**

Thư viện sẽ cố gắng chọn phông chữ hệ thống gần nhất có sẵn, tương tự như cách PowerPoint hoạt động.

**Tôi có thể đính kèm phông chữ bên ngoài tùy chỉnh tại thời gian chạy để tránh việc thay thế không?**

Có. Bạn có thể [add external fonts](/slides/vi/python-net/custom-font/) tại thời gian chạy để thư viện cân nhắc chúng cho việc lựa chọn và hiển thị, bao gồm cả các chuyển đổi tiếp theo.

**Aspose có phân phối bất kỳ phông chữ nào kèm theo thư viện không?**

Không. Aspose không phân phối bất kỳ phông chữ trả phí hay miễn phí nào; bạn tự thêm và sử dụng phông chữ theo quyết định và trách nhiệm của mình.

**Có sự khác nhau nào trong hành vi thay thế trên Windows, Linux và macOS không?**

Có. Quá trình khám phá phông chữ bắt đầu từ các thư mục phông chữ của hệ điều hành. Bộ phông chữ mặc định có sẵn và các đường dẫn tìm kiếm khác nhau giữa các nền tảng, điều này ảnh hưởng đến tính khả dụng và nhu cầu thay thế.

**Làm thế nào để chuẩn bị môi trường nhằm giảm thiểu việc thay thế không mong muốn trong quá trình chuyển đổi hàng loạt?**

Đồng bộ bộ phông chữ trên các máy hoặc container, [add the external fonts](/slides/vi/python-net/custom-font/) cần thiết cho tài liệu đầu ra, và [embed fonts](/slides/vi/python-net/embedded-font/) trong bản trình chiếu khi có thể để các phông chữ đã chọn có sẵn trong quá trình hiển thị.