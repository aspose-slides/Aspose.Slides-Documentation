---
title: Cấu hình Thay thế Phông chữ trong Bản trình chiếu sử dụng Python qua Java
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/python-java/font-substitution/
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
- Java
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho Python qua Java khi render hoặc chuyển đổi các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập khi bản trình chiếu được render hoặc chuyển đổi. Việc thay thế ảnh hưởng đến đầu ra đã render; nó không thay đổi phông chữ được gán cho nội dung bản trình chiếu.

Bạn có thể định nghĩa phông chữ sẽ được sử dụng khi một phông chữ cụ thể không có sẵn, và bạn có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình render. Điều này giúp duy trì kết quả nhất quán trên các môi trường có các phông chữ được cài đặt khác nhau.

## **Lấy các phép Thay thế Phông chữ**

Sử dụng phương thức [FontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getSubstitutions) để xác định những phông chữ nào sẽ được thay thế khi bản trình chiếu được render. Phương thức này trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ được thay thế.

Ví dụ Python sau liệt kê tất cả các phép thay thế phông chữ cho một bản trình chiếu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Lấy các phép Thay thế Phông chữ cho các Slide đã Chọn**

Sử dụng overload của [FontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getSubstitutions) với đối số là mảng số nguyên Java để kiểm tra chỉ những phép thay thế cần thiết cho việc render các slide cụ thể. Điều này hữu ích khi bạn render hoặc xuất một phần của bản trình chiếu, kiểm tra tăng dần một bản trình chiếu lớn, xác định các slide phụ thuộc vào phông chữ không có sẵn, chuẩn bị gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác biệt trong render mà không xử lý các slide không liên quan.

Mảng `slides` chứa chỉ mục slide tính từ 1: `1` đại diện cho slide đầu tiên. Ngược lại, bộ truy cập collection [Presentation.getSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlides) sử dụng chỉ mục bắt đầu từ 0, vì vậy slide tương tự được truy cập bằng `presentation.getSlides().get_Item(0)`. Hãy ghi nhớ sự khác biệt này khi xây dựng mảng để tránh lỗi lệch một.

Gọi overload thông qua phương thức [Presentation.getFontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getFontsManager). Nó trả về chỉ các phép thay thế được xác định trong khi render các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc fallback đã cấu hình, các quy tắc thay thế được lưu trong một [FontSubstRuleCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsubstrulecollection/), và [phông chữ được tải ngoài](/slides/vi/python-java/custom-font/).

Cùng một phép thay thế có thể được yêu cầu bởi nhiều slide đã chọn. Hãy loại bỏ trùng lặp kết quả khi bạn tạo danh mục phông chữ hoặc báo cáo preflight. Ví dụ sau báo cáo mọi phép thay thế được trả về và sau đó tạo một danh sách đã sắp xếp các ánh xạ phông chữ duy nhất:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

Lớp [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/) cung cấp cả hai overload. Chọn một phương thức phù hợp với phạm vi của thao tác render:

| Phương thức | Sử dụng khi |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getSubstitutions) không có đối số | Bạn cần các phép thay thế cho toàn bộ bản trình chiếu. |
| [getSubstitutions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getSubstitutions) với mảng số nguyên Java | Bạn cần các phép thay thế cho một phạm vi đã chọn, kiểm tra tăng dần, hoặc xuất một phần. |

## **Đặt Quy tắc Thay thế Phông chữ**

Để chỉ định phông chữ mà Aspose.Slides nên sử dụng khi một phông chữ nguồn không có sẵn:

1. Tải bản trình chiếu.  
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.  
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).  
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsubstrulecollection/).  
5. Gán bộ sưu tập bằng cách sử dụng phương thức [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).  
6. Render hoặc chuyển đổi bản trình chiếu.

Ví dụ Python sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không có sẵn, sau đó render slide đầu tiên để xác minh kết quả. Phông chữ thay thế phải có sẵn đối với Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Đối với việc thay đổi phông chữ không có điều kiện trên toàn bộ bản trình chiếu, xem [Thay thế phông chữ](/slides/vi/python-java/font-replacement/).
{{% /alert %}}

## **Hạn chế cho Phông chữ Phương trình Toán học**

Các quy tắc thay thế phông chữ là một phần của quy trình lựa chọn phông chữ chuẩn được sử dụng trong quá trình render và chuyển đổi. Chúng hoạt động cho văn bản thường khi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng phông chữ khả dụng được quy tắc chỉ định.

Các phương trình Office Math có một yêu cầu bổ sung. Nếu một phương trình sử dụng **Cambria Math**, Aspose.Slides có thể cần chính phông chữ đó để tính toán và render bố cục phương trình. Quy tắc thay thế một phông chữ toán khác, như **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và quá trình render vẫn có thể báo rằng **Cambria Math** là bắt buộc.

Để render hoặc chuyển đổi bản trình chiếu như vậy, hãy đảm bảo **Cambria Math** có sẵn cho Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó dưới dạng một [phông chữ bên ngoài](/slides/vi/python-java/custom-font/).

Hạn chế này áp dụng cho bố cục phương trình. Các quy tắc thay thế mô tả ở trên vẫn áp dụng cho văn bản thông thường của bản trình chiếu.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa font replacement và font substitution là gì?**

[Font replacement](/slides/vi/python-java/font-replacement/) cố ý thay đổi một phông chữ thành phông chữ khác trên toàn bộ bản trình chiếu. Thay thế phông chữ chọn một phông chữ cho đầu ra đã render khi điều kiện đã cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không có sẵn.

**Khi nào quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [chuỗi lựa chọn phông chữ](/slides/vi/python-java/font-selection-sequence/) trong quá trình render và chuyển đổi. Với `WhenInaccessible`, một quy tắc chỉ được dùng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ bị thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides sẽ chọn phông chữ khả dụng gần nhất theo quy trình lựa chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường runtime.

**Tôi có thể tải phông chữ bên ngoài để tránh việc thay thế không?**

Có. Bạn có thể [tải phông chữ bên ngoài](/slides/vi/python-java/custom-font/) để Aspose.Slides sử dụng chúng trong quá trình render và chuyển đổi.

**Aspose có phân phối phông chữ cùng với thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**

Có. Các phông chữ đã cài đặt và vị trí tìm kiếm phông chữ khác nhau tùy theo hệ điều hành, vì vậy một phông chữ có sẵn trên máy này có thể cần được thay thế trên máy khác.

**Làm sao để làm cho việc lựa chọn phông chữ nhất quán trong các chuyển đổi hàng loạt?**

Sử dụng cùng các tệp và phiên bản phông chữ trên mọi máy hoặc container, [tải các phông chữ bên ngoài cần thiết](/slides/vi/python-java/custom-font/), và [nhúng phông chữ](/slides/vi/python-java/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [FontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getSubstitutions) trước khi xuất để xác định các phép thay thế bất ngờ.