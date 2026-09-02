---
title: Cấu hình Thay thế Phông chữ trong Bản trình bày bằng Python
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
- bản trình bày
- Python
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho Python qua .NET khi kết xuất hoặc chuyển đổi các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Font substitution cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập khi một bản trình bày được kết xuất hoặc chuyển đổi. Việc thay thế ảnh hưởng đến đầu ra đã được kết xuất; nó không thay đổi phông chữ được gán cho nội dung bản trình bày.

Bạn có thể định nghĩa phông chữ sẽ sử dụng khi một phông chữ cụ thể không có sẵn, và bạn có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình kết xuất. Điều này giúp duy trì tính nhất quán của đầu ra trên các môi trường có các phông chữ đã cài đặt khác nhau.

## **Lấy các Phép Thay Thế Phông Chữ**

Sử dụng phương thức [FontsManager.get_substitutions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_substitutions/) để xác định những phông chữ nào sẽ được thay thế khi bản trình bày được kết xuất. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ đã được thay thế.

Ví dụ Python sau liệt kê tất cả các phép thay thế phông chữ cho một bản trình bày:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Lấy Các Phép Thay Thế Phông Chữ cho Các Slide Được Chọn**

Sử dụng [FontsManager.get_substitutions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_substitutions/) cùng với danh sách chỉ số slide để kiểm tra chỉ các phép thay thế cần thiết cho việc kết xuất các slide cụ thể. Điều này hữu ích khi bạn đang kết xuất hoặc xuất khẩu một phần của bản trình bày, kiểm tra dần dần một bản trình bày lớn, xác định các slide phụ thuộc vào phông chữ không có sẵn, chuẩn bị một gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác biệt trong việc kết xuất mà không xử lý các slide không liên quan.

Danh sách chứa các chỉ số slide tính từ một: `1` xác định slide đầu tiên. Ngược lại, bộ sưu tập [Presentation.slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slides/vi/) tính từ không, vì vậy slide đó được truy cập bằng `presentation.slides[0]`. Hãy nhớ sự khác biệt này khi xây dựng danh sách để tránh lỗi lệch một vị trí.

Gọi phương thức thông qua thuộc tính [Presentation.fonts_manager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/fonts_manager/). Nó chỉ trả về các phép thay thế được xác định trong quá trình kết xuất các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ đã được thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc dự phòng đã cấu hình, các quy tắc thay thế được lưu trong một [IFontSubstRuleCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ifontsubstrulecollection/), và [các phông chữ được tải từ bên ngoài](/slides/vi/python-net/custom-font/).

Cùng một phép thay thế có thể được yêu cầu bởi nhiều slide đã chọn. Hãy loại bỏ các bản sao khi bạn tạo danh mục phông chữ hoặc báo cáo kiểm tra trước. Ví dụ sau báo cáo mỗi phép thay thế được trả về và sau đó tạo một danh sách đã sắp xếp các ánh xạ phông chữ duy nhất:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

Lớp [FontsManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/) cung cấp cả hai dạng của phương thức. Chọn một trong số chúng tùy theo phạm vi của thao tác kết xuất:

| Lệnh gọi phương thức | Sử dụng khi |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_substitutions/) không có đối số | Bạn cần các phép thay thế cho toàn bộ bản trình bày. |
| [get_substitutions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_substitutions/) với danh sách chỉ số slide | Bạn cần các phép thay thế cho một phạm vi đã chọn, kiểm tra tăng dần, hoặc xuất khẩu một phần. |

## **Đặt Quy Tắc Thay Thế Phông Chữ**

Để chỉ định phông chữ mà Aspose.Slides sẽ sử dụng khi phông chữ nguồn không có sẵn:

1. Tải bản trình bày.
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsubstrule/) với điều kiện [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsubstrulecollection/).
5. Gán bộ sưu tập này cho thuộc tính [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
6. Kết xuất hoặc chuyển đổi bản trình bày.

Ví dụ Python sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không có sẵn, và sau đó kết xuất slide đầu tiên để xác minh kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
Để thay đổi không điều kiện các phông chữ được sử dụng trong toàn bộ bản trình bày, xem [Font Replacement](/slides/vi/python-net/font-replacement/).
{{% /alert %}}

## **Giới Hạn cho Phông Chữ Phương Trình Toán Học**

Các quy tắc thay thế phông chữ là một phần của quy trình lựa chọn phông chữ chuẩn được sử dụng trong quá trình kết xuất và chuyển đổi. Chúng hoạt động cho văn bản thông thường khi Aspose.Slides có thể thay thế một phông chữ không thể truy cập bằng phông chữ có sẵn được quy tắc chỉ định.

Các phương trình Office Math có một yêu cầu bổ sung. Nếu một phương trình sử dụng **Cambria Math**, Aspose.Slides có thể cần chính phông chữ đó để tính toán và kết xuất bố cục phương trình. Một quy tắc thay thế bằng một phông chữ toán học khác, như **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và việc kết xuất vẫn có thể báo cáo rằng **Cambria Math** là bắt buộc.

Để kết xuất hoặc chuyển đổi một bản trình bày như vậy, hãy đảm bảo **Cambria Math** có sẵn cho Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó như một [phông chữ bên ngoài](/slides/vi/python-net/custom-font/).

Giới hạn này áp dụng cho bố cục phương trình. Các quy tắc thay thế được mô tả ở trên vẫn áp dụng cho văn bản bình thường của bản trình bày.

## **Câu Hỏi Thường Gặp**

**Sự khác nhau giữa font replacement và font substitution là gì?**

[Font replacement](/slides/vi/python-net/font-replacement/) cố ý thay đổi một phông chữ thành phông chữ khác trên toàn bộ bản trình bày. Font substitution chọn một phông chữ cho đầu ra đã được kết xuất khi điều kiện cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không có sẵn.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [font selection sequence](/slides/vi/python-net/font-selection-sequence/) trong quá trình kết xuất và chuyển đổi. Với `WHEN_INACCESSIBLE`, một quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ bị thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides sẽ chọn phông chữ có sẵn gần nhất theo quy trình lựa chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có trong môi trường thời gian chạy.

**Tôi có thể tải phông chữ bên ngoài để tránh việc thay thế không?**

Có. Bạn có thể [tải phông chữ bên ngoài](/slides/vi/python-net/custom-font/) để Aspose.Slides có thể sử dụng chúng trong quá trình kết xuất và chuyển đổi.

**Aspose có phân phối phông chữ cùng với thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp các phông chữ và tuân thủ giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**

Có. Các phông chữ đã cài đặt và vị trí tìm kiếm phông chữ khác nhau theo hệ điều hành, vì vậy một phông chữ có sẵn trên một máy có thể cần được thay thế trên máy khác.

**Làm thế nào để làm cho việc lựa chọn phông chữ nhất quán trong các chuyển đổi hàng loạt?**

Sử dụng cùng một tệp phông chữ và các phiên bản trên mọi máy hoặc container, [tải các phông chữ bên ngoài cần thiết](/slides/vi/python-net/custom-font/), và [nhúng phông chữ](/slides/vi/python-net/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [FontsManager.get_substitutions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_substitutions/) trước khi xuất để xác định các phép thay thế không mong muốn.