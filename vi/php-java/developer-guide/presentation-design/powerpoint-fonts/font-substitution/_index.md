---
title: Cấu hình Thay thế Phông chữ trong Bản trình chiếu bằng PHP
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/php-java/font-substitution/
keywords:
- phông chữ
- phông chữ thay thế
- thay thế phông chữ
- thay đổi phông chữ
- thay thế phông chữ
- quy tắc thay thế
- quy tắc thay thế
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Kích hoạt việc thay thế phông chữ tối ưu trong Aspose.Slides cho PHP thông qua Java khi chuyển đổi bản trình chiếu PowerPoint và OpenDocument sang các định dạng tệp khác."
---
## **Giới thiệu**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ khác khi phông chữ gốc của bản trình chiếu không khả dụng trong quá trình render hoặc chuyển đổi. Bạn có thể kiểm tra các phông chữ đã được thay thế bằng cách sử dụng phương thức `getSubstitutions` của lớp `FontsManager`.

Aspose.Slides cũng cho phép bạn định nghĩa các quy tắc thay thế phông chữ. Ví dụ, bạn có thể chỉ định rằng một phông chữ không truy cập được sẽ được thay bằng một phông chữ khả dụng khác và sau đó áp dụng các quy tắc đó thông qua font manager của bản trình chiếu.

## **Đặt quy tắc thay thế phông chữ**

Aspose.Slides cho phép bạn thiết lập các quy tắc cho phông chữ xác định những gì cần thực hiện trong các điều kiện nhất định (ví dụ, khi một phông chữ không thể truy cập) như sau:

1. Tải bản trình chiếu liên quan.  
2. Tải phông chữ sẽ được thay thế.  
3. Tải phông chữ mới.  
4. Thêm một quy tắc cho việc thay thế.  
5. Thêm quy tắc vào bộ sưu tập quy tắc thay thế phông chữ của bản trình chiếu.  
6. Tạo ảnh slide để quan sát hiệu ứng.  

Đoạn code PHP sau minh họa quy trình thay thế phông chữ:

```php
  # Tải một bản trình chiếu
  $pres = new Presentation("Fonts.pptx");
  try {
    # Tải phông chữ nguồn sẽ được thay thế
    $sourceFont = new FontData("SomeRareFont");
    # Tải phông chữ mới
    $destFont = new FontData("Arial");
    # Thêm một quy tắc phông chữ cho việc thay thế phông chữ
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Thêm quy tắc vào bộ sưu tập các quy tắc thay thế phông chữ
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Thêm một bộ sưu tập quy tắc phông chữ vào danh sách quy tắc
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Phông chữ Arial sẽ được sử dụng thay cho SomeRareFont khi phông chữ này không thể truy cập
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Lưu ảnh vào đĩa ở định dạng JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert title="NOTE"  color="warning"   %}} 
Bạn có thể muốn xem [**Thay thế phông chữ**](/slides/vi/php-java/font-replacement/).
{{% /alert %}}

## **Giới hạn đối với phông chữ công thức toán học**

Các quy tắc thay thế phông chữ tham gia vào quy trình lựa chọn phông chữ chuẩn được sử dụng trong quá trình render và chuyển đổi. Chúng phù hợp cho các trường hợp văn bản thường, nơi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng một phông chữ khả dụng khác theo quy tắc đã cấu hình.

Tuy nhiên, các công thức toán học của Office có một hạn chế quan trọng. Nếu một công thức được tạo bằng **Cambria Math**, Aspose.Slides vẫn có thể yêu cầu phông chữ **Cambria Math** gốc để tính toán và render bố cục công thức một cách chính xác. Do đó, việc thay thế **Cambria Math** bằng một phông chữ toán học khác, chẳng hạn như **STIX Two Math**, không được hỗ trợ cho việc render công thức và có thể vẫn dẫn đến ngoại lệ cho biết **Cambria Math** là bắt buộc.

Để chuyển đổi các bản trình chiếu như vậy một cách thành công, hãy chắc chắn rằng **Cambria Math** có sẵn cho Aspose.Slides ở thời điểm chạy. Bạn có thể cài đặt phông chữ này trong hệ điều hành hoặc cung cấp nó như một [phông chữ bên ngoài](/slides/vi/php-java/custom-font/) để nó có thể tham gia vào quy trình lựa chọn phông chữ bình thường trong quá trình render và chuyển đổi.

Giới hạn này chỉ áp dụng cho việc render công thức. Các quy tắc thay thế phông chữ chuẩn được mô tả ở trên vẫn áp dụng cho văn bản bản trình chiếu thông thường khi phông chữ gốc không khả dụng.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa thay thế phông chữ và thay thế (substitution) phông chữ là gì?**  
[Replacement](/slides/vi/php-java/font-replacement/) là việc ép buộc ghi đè một phông chữ bằng một phông chữ khác trên toàn bộ bản trình chiếu. Thay thế (substitution) là một quy tắc được kích hoạt trong một điều kiện cụ thể, ví dụ khi phông chữ gốc không khả dụng, và sau đó một phông chữ dự phòng được chỉ định sẽ được sử dụng.

**Khi nào các quy tắc thay thế (substitution) được áp dụng?**  
Các quy tắc tham gia vào chuỗi [lựa chọn phông chữ](/slides/vi/php-java/font-selection-sequence/) chuẩn được đánh giá trong quá trình tải, render và chuyển đổi; nếu phông chữ được chọn không khả dụng, việc thay thế hoặc thay thế (substitution) sẽ được áp dụng.

**Hành vi mặc định là gì nếu không có cả thay thế nor substitution nào được cấu hình và phông chữ không tồn tại trên hệ thống?**  
Thư viện sẽ cố gắng chọn phông chữ hệ thống khả dụng gần nhất, tương tự như cách PowerPoint hoạt động.

**Tôi có thể đính kèm các phông chữ bên ngoài tùy chỉnh tại thời điểm chạy để tránh việc thay thế không?**  
Có. Bạn có thể [thêm phông chữ bên ngoài](/slides/vi/php-java/custom-font/) tại thời điểm chạy để thư viện cân nhắc chúng trong việc lựa chọn và render, bao gồm cả các lần chuyển đổi tiếp theo.

**Aspose có phân phối bất kỳ phông chữ nào kèm theo thư viện không?**  
Không. Aspose không phân phối phông chữ trả phí hay miễn phí; bạn tự thêm và sử dụng phông chữ theo quyết định và trách nhiệm của mình.

**Có sự khác biệt nào trong hành vi thay thế trên Windows, Linux và macOS không?**  
Có. Quá trình khám phá phông chữ bắt đầu từ các thư mục phông chữ của hệ điều hành. Bộ phông chữ khả dụng mặc định và các đường dẫn tìm kiếm khác nhau giữa các nền tảng, điều này ảnh hưởng tới khả năng sẵn có và nhu cầu thay thế.

**Làm thế nào tôi nên chuẩn bị môi trường để giảm thiểu việc thay thế không mong muốn trong quá trình chuyển đổi hàng loạt?**  
Đồng bộ bộ phông chữ trên các máy hoặc container, [thêm các phông chữ bên ngoài](/slides/vi/php-java/custom-font/) cần thiết cho tài liệu đầu ra, và [nhúng phông chữ](/slides/vi/php-java/embedded-font/) vào bản trình chiếu khi có thể để các phông chữ đã chọn có sẵn trong quá trình render.