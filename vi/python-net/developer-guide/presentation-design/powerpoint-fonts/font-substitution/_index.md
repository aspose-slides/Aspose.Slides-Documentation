---
title: "Cấu hình Thay thế Phông chữ trong Bản trình chiếu với Python"
linktitle: "Thay thế Phông chữ"
type: docs
weight: 70
url: /vi/python-net/font-substitution/
keywords:
- "phông chữ"
- "phông chữ thay thế"
- "thay thế phông chữ"
- "thay đổi phông chữ"
- "thay thế phông chữ"
- "quy tắc thay thế"
- "quy tắc thay đổi"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "Python"
- "Aspose.Slides"
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho Python qua .NET khi hiển thị hoặc chuyển đổi các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập được khi một bản trình chiếu được hiển thị hoặc chuyển đổi. Việc thay thế chỉ ảnh hưởng tới đầu ra đã được hiển thị; nó không thay đổi phông chữ được gán cho nội dung của bản trình chiếu.

Bạn có thể xác định phông chữ sẽ được sử dụng khi một phông chữ cụ thể không có sẵn, và có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình hiển thị. Điều này giúp duy trì tính nhất quán của đầu ra trên các môi trường có các phông chữ được cài đặt khác nhau.

Nếu một phông chữ có sẵn nhưng không có kiểu chữ đậm riêng, xem [Xử lý phông chữ không có kiểu chữ đậm riêng](/slides/vi/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Phần đó giải thích cách raster hoá văn bản bị ảnh hưởng trong quá trình xuất PDF và các hậu quả đối với việc chọn văn bản, tìm kiếm và phóng to/thu nhỏ.

## **Lấy các phép thay thế phông chữ**

Sử dụng phương thức [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) để xác định các phông chữ sẽ được thay thế khi bản trình chiếu được hiển thị. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ thay thế.

Ví dụ Python sau liệt kê tất cả các phép thay thế phông chữ cho một bản trình chiếu:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Lấy các phép thay thế phông chữ cho các slide đã chọn**

Sử dụng [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) cùng với danh sách chỉ số slide để chỉ kiểm tra các phép thay thế cần thiết cho việc hiển thị các slide cụ thể. Điều này hữu ích khi bạn đang hiển thị hoặc xuất một phần của bản trình chiếu, kiểm tra bản trình chiếu lớn một cách từ từ, xác định các slide phụ thuộc vào phông chữ không có sẵn, chuẩn bị một gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác biệt khi hiển thị mà không xử lý các slide không liên quan.

Danh sách chứa các chỉ số slide bắt đầu từ 1: `1` đại diện cho slide đầu tiên. Ngược lại, bộ sưu tập [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) được đánh số từ 0, do đó slide tương tự được truy cập bằng `presentation.slides[0]`. Hãy nhớ sự khác biệt này khi xây dựng danh sách để tránh lỗi lệch một vị trí.

Gọi phương thức qua thuộc tính [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/). Nó chỉ trả về các phép thay thế được xác định trong khi hiển thị các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc dự phòng đã cấu hình, các quy tắc thay thế lưu trong một [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/), và [các phông chữ được tải extern](/slides/vi/python-net/custom-font/).

Một phép thay thế có thể được yêu cầu bởi nhiều slide đã chọn. Hãy loại bỏ trùng lặp kết quả khi bạn tạo danh mục phông chữ hoặc báo cáo preflight. Ví dụ sau báo cáo mỗi phép thay thế trả về và sau đó tạo một danh sách đã sắp xếp các ánh xạ phông chữ duy nhất:

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

Lớp [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) cung cấp cả hai dạng của phương thức. Chọn một trong số chúng tùy theo phạm vi của thao tác hiển thị:

| Lời gọi phương thức | Dùng khi |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) không có đối số | Bạn cần các phép thay thế cho toàn bộ bản trình chiếu. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) với danh sách chỉ số slide | Bạn cần các phép thay thế cho một phạm vi đã chọn, kiểm tra tăng dần, hoặc xuất một phần. |

## **Đặt quy tắc thay thế phông chữ**

Để chỉ định phông chữ mà Aspose.Slides sẽ sử dụng khi một phông chữ nguồn không có sẵn:

1. Tải bản trình chiếu.
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) với điều kiện [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/).
5. Gán collection cho thuộc tính [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
6. Hiển thị hoặc chuyển đổi bản trình chiếu.

Ví dụ Python dưới đây thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không có sẵn, và sau đó hiển thị slide đầu tiên để xác minh kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

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

{{% alert color="info" title="Lưu ý" %}}
Để thay đổi không có điều kiện các phông chữ được sử dụng trên toàn bộ bản trình chiếu, xem [Thay thế phông chữ](/slides/vi/python-net/font-replacement/).
{{% /alert %}}

## **Hạn chế đối với phông chữ công thức toán học**

Các quy tắc thay thế phông chữ là một phần của quy trình chọn phông chữ chuẩn được sử dụng trong quá trình hiển thị và chuyển đổi. Chúng hoạt động với văn bản thông thường khi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng phông chữ có sẵn được chỉ định trong quy tắc.

Các công thức Office Math có yêu cầu bổ sung. Nếu một công thức sử dụng **Cambria Math**, Aspose.Slides có thể cần chính phông chữ đó để tính toán và hiển thị bố cục công thức. Một quy tắc thay thế bằng một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và việc hiển thị vẫn có thể báo cáo rằng **Cambria Math** là bắt buộc.

Để hiển thị hoặc chuyển đổi bản trình chiếu như vậy, hãy cung cấp **Cambria Math** cho Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó như một [phông chữ extern](/slides/vi/python-net/custom-font/).

Hạn chế này chỉ áp dụng cho bố cục công thức. Các quy tắc thay thế được mô tả ở trên vẫn áp dụng cho văn bản thông thường trong bản trình chiếu.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa thay thế phông chữ và thay đổi phông chữ là gì?**

[Font replacement](/slides/vi/python-net/font-replacement/) thay đổi có chủ đích một phông chữ thành phông chữ khác trên toàn bộ bản trình chiếu. Thay thế phông chữ chọn một phông chữ cho đầu ra đã hiển thị khi điều kiện cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không có sẵn.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [font selection sequence](/slides/vi/python-net/font-selection-sequence/) trong quá trình hiển thị và chuyển đổi. Với `WHEN_INACCESSIBLE`, quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi thiếu phông chữ và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides sẽ chọn phông chữ khả dụng gần nhất theo quy trình chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường chạy.

**Tôi có thể tải phông chữ extern để tránh việc thay thế không?**

Có. Bạn có thể [load external fonts](/slides/vi/python-net/custom-font/) để Aspose.Slides sử dụng chúng trong quá trình hiển thị và chuyển đổi.

**Aspose có phân phối phông chữ cùng với thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ các giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**

Có. Các phông chữ được cài đặt và vị trí tìm kiếm phông chữ khác nhau tùy hệ điều hành, do đó một phông chữ có sẵn trên máy này có thể cần thay thế trên máy khác.

**Làm sao để duy trì việc chọn phông chữ nhất quán trong các chuyển đổi hàng loạt?**

Sử dụng cùng các tệp phông chữ và phiên bản trên mọi máy hoặc container, [load required external fonts](/slides/vi/python-net/custom-font/), và [embed fonts](/slides/vi/python-net/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) trước khi xuất để xác định các phép thay thế không mong muốn.