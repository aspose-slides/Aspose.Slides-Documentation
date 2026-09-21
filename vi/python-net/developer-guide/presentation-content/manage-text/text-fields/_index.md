---
title: Quản lý các trường văn bản trong bài thuyết trình PowerPoint bằng Python
linktitle: Trường Văn Bản
type: docs
weight: 52
url: /vi/python-net/text-fields/
keywords:
- trường văn bản
- văn bản tự động
- số slide
- ngày và giờ
- tiêu đề
- chân trang
- phần văn bản
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Tạo, kiểm tra, sửa đổi và xóa các trường văn bản trong bài thuyết trình PowerPoint với Aspose.Slides cho Python thông qua .NET. Bảo tồn định dạng và xác minh các tệp PPTX và PPT đã lưu."
---
## **Tổng quan**

Một đoạn văn bản bao gồm các phần. Một [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/) thông thường chứa văn bản nguyên mẫu; một phần Field cũng có một [Field](https://reference.aspose.com/slides/vi/python-net/aspose.slides/field/) mà kiểu xác định một giá trị tự động cập nhật, chẳng hạn như số slide hoặc ngày. Hai phần có thể hiển thị cùng các ký tự trong khi chỉ một phần chứa trường.

Sử dụng [Portion.field](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/field/) để phân biệt chúng: giá trị sẽ là `None` đối với văn bản thông thường. [Portion.add_field](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/add_field/) chuyển một phần hiện có thành một trường. Giữ nhãn và giá trị động của nó trong các phần riêng biệt để việc chuyển đổi giá trị không đồng thời thay thế nhãn.

Hướng dẫn này bao gồm các trường trong văn bản, cách định dạng chúng và lưu chúng dưới dạng PPTX và PPT. Đối với khung văn bản và đoạn, xem [Manage Text](/slides/vi/python-net/manage-text/).

## **Tạo Trường Số Slide**

Ví dụ hoàn chỉnh sau đây tạo một hộp văn bản chứa nhãn nguyên mẫu `Slide ` tiếp theo là một số tự động cập nhật. Nó thiết lập kích thước, độ đậm và màu sắc của số trước khi thêm trường, sau đó mở lại bản trình bày đã lưu và kiểm tra kiểu trường, văn bản và định dạng. Không cần tệp đầu vào.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

Bản trình chiếu mới bắt đầu với số slide 1, vì vậy văn bản là `Slide 1`, và cả hai kiểm tra đều in ra `True`. Số vẫn là một trường sau khi mở lại; nó không phải là nguyên mẫu `1`. Các chỉ mục trong quá trình xác minh đề cập đến hình dạng và các phần được tạo bởi ví dụ này.

## **Chọn Kiểu Trường**

[FieldType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fieldtype/) cung cấp các giá trị được định nghĩa trước sau đây. Gửi giá trị phù hợp tới [add_field](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/add_field/).

| Giá trị | Mục đích |
|---|---|
| [slide_number](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fieldtype/slide_number/) | Số slide hiện tại. |
| [date_time](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fieldtype/date_time/) | Ngày/giờ ở định dạng mặc định của ứng dụng render. |
| [date_time1](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fieldtype/date_time9/) | Các định dạng ngày đã định nghĩa trước hoặc kết hợp ngày/giờ. |
| [date_time10](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fieldtype/date_time13/) | Các định dạng thời gian đã định nghĩa trước, với tùy chọn giây và đồng hồ 12 giờ. |
| [header](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fieldtype/header/) | Trường tiêu đề; xem các hạn chế về placeholder và định dạng bên dưới. |
| [footer](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fieldtype/footer/) | Trường chân trang. |

Ví dụ, [date_time3](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fieldtype/date_time3/) đại diện cho ngày, tên tháng đầy đủ và năm bằng tiếng Anh. Đây là các định dạng trường được định nghĩa trước, không phải chuỗi định dạng ngày Python tùy ý. [language_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/language_id/) của phần và ứng dụng xử lý bản trình bày có thể ảnh hưởng tới kết quả hiển thị.

## **Tạo Trường từ Chuỗi Nội Bộ**

Bản overload dạng chuỗi của [add_field](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/add_field/) chấp nhận một định danh trường nội bộ. Sử dụng nó khi muốn giữ lại một định danh do ứng dụng khác cung cấp mà không có giá trị được định nghĩa trước. Bạn cũng có thể tạo một [FieldType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fieldtype/__init__/) từ định danh đó. [FieldType.internal_string](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fieldtype/internal_string/) cung cấp định danh đó để kiểm tra.

Ví dụ này lưu một trường `custom-report-id` riêng của ứng dụng với văn bản dự phòng `Report-042`. Định danh không đăng ký tính toán: Aspose.Slides không tạo ID báo cáo cho kiểu không biết. Ứng dụng hiểu định danh này phải cung cấp ý nghĩa và cập nhật giá trị của nó.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

Sau lần duyệt vòng PPTX này, kiểu là `custom-report-id` và văn bản là `Report-042`. Truyền một chuỗi như `%Y-%m-%d` sẽ đặt tên cho một kiểu trường; nó sẽ không cấu hình định dạng ngày tùy chỉnh. Đối với một ngày cố định ở định dạng tùy ý, hãy sử dụng văn bản thông thường.

## **Kiểm Tra, Sửa Đổi và Xóa Trường Ngày/Giờ**

Đọc và thay đổi một trường hiện có qua [Field.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/field/type/). Kiểm tra trường tồn tại trước khi truy cập kiểu của nó. Để dừng cập nhật tự động, gọi [Portion.remove_field](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/remove_field/). Thao tác này giữ phần và văn bản hiện tại trong khi loại bỏ liên kết với trường. Nếu bạn cần một giá trị cố định cụ thể, gán văn bản đó sau khi đã xóa trường.

Đối với cài đặt API liên quan đến xử lý trường ngày/giờ, xem [Presentation.current_date_time](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/current_date_time/). Ví dụ dưới đây sử dụng ngày phê duyệt rõ ràng khi chuyển một trường thành văn bản thông thường. Một bộ tên tháng bằng tiếng Anh giữ ngày cố định độc lập với locale của hệ thống.

Tải về [sample.pptx](sample.pptx) và đặt nó trong thư mục làm việc. Tệp chứa hai hình dạng văn bản có tên, `UpdatedAt` và `ApprovedDate`, mỗi cái có một trường ngày/giờ, cộng với các nhãn văn bản thông thường. Ví dụ sau duyệt các hình dạng văn bản cấp cao trên các slide thường. Nó chuyển các trường ngày/giờ sang định dạng ngày dài và làm chúng in nghiêng, trong khi vẫn giữ các định dạng khác. Chỉ các trường trong `ApprovedDate` sẽ trở thành văn bản cố định.

Bản mẫu nhận ra các định danh nội bộ được tích hợp `datetime` và `datetime1` tới `datetime13`. Nhóm, bảng, ghi chú, bố cục và mẫu cần duyệt các container văn bản riêng của chúng và nằm ngoài phạm vi của ví dụ này.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

Sau khi mở lại, `UpdatedAt` có kiểu `datetime3` và vẫn động. `ApprovedDate` không có trường và chứa `05 April 2030`. Cả hai phần ngày đều in nghiêng, và kích thước phông chữ, thiết lập in đậm và màu sắc gốc vẫn giữ nguyên. Các nhãn văn bản thông thường không thay đổi. Quá trình xác minh đọc phần đầu tiên của hai hình dạng đã biết trong mẫu được cung cấp.

## **Bảo Vệ Định Dạng Văn Bản**

Làm việc với phần hiện có khi thêm trường, thay đổi kiểu của nó, hoặc xóa nó. Các thao tác này giữ nguyên định dạng của phần đó. Sử dụng [Portion.portion_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/portion_format/) để chỉ thay đổi các thuộc tính cần thiết, như các ví dụ làm cho màu sắc hoặc in nghiêng.

Tránh xây dựng lại toàn bộ khung văn bản chỉ để cập nhật một trường: việc này có thể làm mất ranh giới phần gốc và định dạng riêng của chúng. Ngoài ra, hãy phân biệt định dạng được đặt rõ ràng với định dạng kế thừa từ đoạn, bố cục hoặc chủ đề. Xem [Text Formatting](/slides/vi/python-net/text-formatting/) để biết các tùy chọn định dạng rộng hơn.

## **Trường và Placeholder Tiêu Đề/Chân Trang**

Một trường là một phần của phần văn bản. Placeholder là một hình dạng có vai trò trong bài thuyết trình, như chân trang hoặc số slide. Thêm một trường vào hộp văn bản thông thường không biến hình dạng đó thành placeholder.

Trình quản lý tiêu đề/chân trang kiểm soát văn bản placeholder và khả năng hiển thị trên các slide, bố cục và mẫu, bao gồm việc lan truyền tới các slide phụ thuộc. Vì vậy, một trường số trong hộp văn bản tùy chỉnh vẫn hữu ích ngay cả khi bạn không sử dụng placeholder số slide. Ngược lại, thay đổi khả năng hiển thị của placeholder không xóa trường khỏi một hộp văn bản không liên quan.

Các kiểu tiêu đề và chân trang được định nghĩa trước không tạo ra placeholder tương ứng hoặc cung cấp nội dung của chúng. Đặc biệt, một slide PowerPoint thông thường không có placeholder tiêu đề; tiêu đề thuộc về trang ghi chú và tài liệu phát tay. Đừng giả định rằng một trường tiêu đề hoặc chân trang trong một hình dạng tùy ý sẽ tự động nhận được văn bản được cấu hình qua trình quản lý placeholder. Đối với quy trình đó, xem [Presentation Headers and Footers](/slides/vi/python-net/presentation-header-and-footer/).

## **Giới Hạn của PPTX và PPT**

Kiểm tra cả kiểu trường và văn bản kết quả của nó sau khi lưu và mở lại. Giữ lại một định danh không chứng minh rằng một ứng dụng có thể tính toán hoặc hiển thị giá trị của nó.

| Định dạng | Hành vi và giới hạn của trường |
|---|---|
| PPTX | Lưu trữ các định danh trường nội bộ cùng với văn bản trường. Trong các kiểm tra vòng quay, các kiểu định nghĩa trước và định danh tùy chỉnh được sử dụng ở trên vẫn tồn tại sau khi lưu và mở lại. Kiểu tùy chỉnh không biết giữ lại văn bản dự phòng; nó không có logic tính toán tự động. Ứng dụng khác có thể xử lý các định danh không hỗ trợ khác nhau. |
| PPT | Sử dụng các biểu diễn trường legacy và có tính tương thích hạn chế hơn. Trong các kiểm tra vòng quay, trường số slide và trường ngày/giờ định nghĩa trước vẫn tồn tại sau khi lưu và mở lại. Một trường tùy chỉnh trong hộp văn bản slide thông thường mở lại với định danh của nó nhưng văn bản là `*`; một trường tiêu đề trong cùng ngữ cảnh cũng cho ra `*`. Đừng dựa vào các trường tùy chỉnh hoặc ngữ cảnh trường không hỗ trợ để giữ lại văn bản hiển thị. |

Để có đầu ra cố định, di động, chuyển các trường không hỗ trợ thành văn bản thông thường và gán rõ ràng giá trị mong muốn trước khi lưu. Điều này giữ lại văn bản đã chọn nhưng cố ý ngừng cập nhật tự động. Hãy kiểm tra ứng dụng đích khi việc tính lại trường của nó là một phần trong quy trình của bạn.

## **FAQ**

**Làm sao để biết một số hoặc ngày hiển thị là trường hay không?**

Kiểm tra [Portion.field](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/field/). Giá trị khác `None` xác định một trường; chỉ dựa vào văn bản hiển thị không thể cho bạn biết.

**Việc xóa một trường có xóa văn bản hoặc định dạng của nó không?**

Không. [remove_field](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/remove_field/) chuyển phần hiện có thành văn bản thông thường. Gán một giá trị cụ thể sau đó nếu bạn cần một ngày cố định hoặc giá trị dự phòng nhất định.

**Chuỗi nội bộ có thể định nghĩa định dạng ngày mới hoặc công thức không?**

Không. Nó chỉ xác định một kiểu trường. Định danh không biết không cung cấp bộ đánh giá hay mẫu định dạng ngày Python. Hãy sử dụng một kiểu được hỗ trợ đã định nghĩa trước hoặc tự định dạng giá trị thành văn bản thông thường.

**Tại sao phải kiểm tra lại bản trình bày sau khi lưu?**

Các định danh trường, văn bản đã tính toán và định dạng là các yếu tố riêng biệt cần xác minh. Việc chuyển đổi định dạng có thể thay đổi kết quả hiển thị ngay cả khi định danh trường vẫn còn tồn tại.