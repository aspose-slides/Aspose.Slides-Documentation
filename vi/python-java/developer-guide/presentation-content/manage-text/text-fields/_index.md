---
title: Quản lý Trường Văn bản trong Bản trình chiếu PowerPoint bằng Python thông qua Java
linktitle: Trường Văn bản
type: docs
weight: 52
url: /vi/python-java/text-fields/
keywords:
- trường văn bản
- văn bản tự động
- số slide
- ngày và giờ
- đầu trang
- chân trang
- phần văn bản
- PowerPoint
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Tạo, kiểm tra, sửa đổi và xóa các trường văn bản trong bản trình chiếu PowerPoint với Aspose.Slides cho Python thông qua Java. Bảo tồn định dạng và xác minh các tệp PPTX và PPT đã lưu."
---
## **Tổng quan**

Một đoạn văn bản bao gồm các phần. Một [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/) thông thường chứa văn bản nguyên bản; một phần trường (field) cũng có một [Field](https://reference.aspose.com/slides/vi/python-java/aspose.slides/field/) mà kiểu xác định giá trị tự động cập nhật, chẳng hạn như số slide hoặc ngày. Hai phần có thể hiển thị cùng các ký tự trong khi chỉ một phần chứa trường.

Sử dụng [Portion.getField](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#getField) để phân biệt chúng: giá trị sẽ là `None` đối với văn bản thông thường. [Portion.addField](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#addField) chuyển một phần hiện có thành trường. Giữ nhãn và giá trị động của nó trong các phần riêng biệt để việc chuyển đổi giá trị không đồng thời thay thế nhãn.

Hướng dẫn này đề cập đến các trường trong văn bản, cách định dạng chúng và cách lưu trong PPTX và PPT. Đối với khung văn bản và đoạn văn, xem [Manage Text](/slides/vi/python-java/manage-text/).

## **Tạo Trường Số Slide**

Ví dụ hoàn chỉnh dưới đây tạo một hộp văn bản chứa nhãn nguyên bản `Slide ` tiếp theo là một số tự động cập nhật. Nó thiết lập kích thước, độ đậm và màu sắc của số trước khi thêm trường, sau đó mở lại bản trình diễn đã lưu và kiểm tra kiểu trường, văn bản và định dạng. Không cần tệp đầu vào.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Bản trình diễn mới bắt đầu với số slide 1, vì vậy văn bản là `Slide 1`, và cả hai kiểm tra đều in `True`. Số vẫn là một trường sau khi mở lại; nó không phải là nguyên văn `1`. Các chỉ mục trong quá trình xác minh đề cập đến hình dạng và các phần được tạo bởi ví dụ này.

## **Chọn Kiểu Trường**

[FieldType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fieldtype/) cung cấp các phương thức sau để lấy các giá trị đã định sẵn. Truyền giá trị thích hợp vào [addField](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#addField).

| Phương thức | Mục đích |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fieldtype/#getSlideNumber) | Số slide hiện tại. |
| [getDateTime](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fieldtype/#getDateTime) | Ngày/giờ theo định dạng mặc định của ứng dụng render. |
| [getDateTime1](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fieldtype/#getDateTime9) | Các định dạng ngày hoặc ngày/giờ đã định sẵn. |
| [getDateTime10](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fieldtype/#getDateTime13) | Các định dạng thời gian đã định sẵn, có tùy chọn giây và đồng hồ 12 giờ. |
| [getHeader](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fieldtype/#getHeader) | Trường tiêu đề; xem các giới hạn về placeholder và định dạng bên dưới. |
| [getFooter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fieldtype/#getFooter) | Trường chân trang. |

Ví dụ, [getDateTime3](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fieldtype/#getDateTime3) đại diện cho ngày, tên tháng đầy đủ và năm bằng tiếng Anh. Đây là các định dạng trường đã định sẵn, không phải chuỗi định dạng ngày Python tùy ý. Ngôn ngữ được đặt bằng [setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setLanguageId) và ứng dụng xử lý bản trình diễn có thể ảnh hưởng đến kết quả hiển thị.

## **Tạo Trường từ Chuỗi Nội Bộ**

Phiên bản nhận chuỗi của [addField](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#addField) chấp nhận một định danh trường nội bộ. Sử dụng nó khi muốn giữ lại định danh được cung cấp bởi ứng dụng khác mà không có giá trị đã định sẵn. Bạn cũng có thể tạo một [FieldType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fieldtype/#FieldType) từ định danh này. [FieldType.getInternalString](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fieldtype/#getInternalString) cho phép xem định danh đó.

Ví dụ này lưu một trường `custom-report-id` riêng của ứng dụng với văn bản dự phòng `Report-042`. Định danh này không đăng ký phép tính: Aspose.Slides không tạo ID báo cáo cho kiểu không xác định. Ứng dụng hiểu định danh này phải cung cấp ý nghĩa và cập nhật giá trị của nó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Sau vòng quay PPTX này, kiểu là `custom-report-id` và văn bản là `Report-042`. Truyền một chuỗi như `yyyy-MM-dd` sẽ đặt tên cho một kiểu trường; nó sẽ không cấu hình định dạng ngày tùy chỉnh. Đối với ngày cố định ở định dạng tùy ý, sử dụng văn bản thông thường.

## **Kiểm Tra, Sửa Đổi và Xóa Trường Ngày/Giờ**

Thay đổi một trường hiện có bằng [Field.setType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/field/#setType). Kiểm tra trường tồn tại trước khi truy cập kiểu của nó. Để ngừng cập nhật tự động, gọi [Portion.removeField](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#removeField). Điều này giữ lại phần và văn bản hiện tại trong khi xóa liên kết trường. Nếu bạn cần một giá trị cố định cụ thể, gán văn bản đó sau khi xóa trường.

Đối với cài đặt API liên quan đến việc xử lý trường ngày/giờ, xem [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#setCurrentDateTime). Ví dụ dưới đây sử dụng ngày phê duyệt cụ thể khi chuyển trường thành văn bản thông thường.

Tải xuống [sample.pptx](sample.pptx) và đặt nó trong thư mục làm việc. Nó chứa hai hình dạng văn bản có tên, `UpdatedAt` và `ApprovedDate`, mỗi cái có một trường ngày/giờ, cùng với các nhãn văn bản thông thường. Ví dụ sau duyệt các hình dạng văn bản cấp đầu trên các slide thường. Nó chuyển các trường ngày/giờ sang định dạng ngày dài và làm chúng in nghiêng, đồng thời giữ các định dạng khác. Chỉ các trường trong `ApprovedDate` trở thành văn bản cố định.

Mẫu nhận diện các định danh nội bộ tích hợp sẵn `datetime` và `datetime1` tới `datetime13`. Các nhóm, bảng, ghi chú, bố cục và master yêu cầu duyệt các container văn bản riêng của chúng và nằm ngoài phạm vi của ví dụ này.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpbyte.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Sử dụng tên tháng tiếng Anh độc lập với ngôn ngữ hệ thống.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Sau khi mở lại, `UpdatedAt` có kiểu `datetime3` và vẫn động. `ApprovedDate` không có trường và chứa `05 April 2030`. Cả hai phần ngày đều in nghiêng, và kích thước phông chữ, thiết lập đậm và màu sắc gốc vẫn giữ nguyên. Các nhãn văn bản thông thường không thay đổi. Quá trình xác minh đọc phần đầu tiên của hai hình dạng đã biết trong mẫu cung cấp.

## **Bảo Vệ Định Dạng Văn Bản**

Làm việc với phần hiện có khi thêm trường, thay đổi kiểu của nó hoặc xóa nó. Các thao tác này giữ lại định dạng của phần đó. Sử dụng [Portion.getPortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#getPortionFormat) để thay đổi chỉ các thuộc tính cần thiết, như các ví dụ thực hiện cho màu hoặc in nghiêng.

Tránh xây dựng lại toàn bộ khung văn bản chỉ để cập nhật một trường: việc này có thể làm mất ranh giới phần gốc và định dạng riêng của chúng. Ngoài ra, phân biệt định dạng được đặt rõ ràng với định dạng kế thừa từ đoạn, bố cục hoặc chủ đề. Xem [Text Formatting](/slides/vi/python-java/text-formatting/) để biết các tùy chọn định dạng rộng hơn.

## **Trường và Placeholder Đầu/Chân Trang**

Một trường là một phần của một phần văn bản. Placeholder là một hình dạng có vai trò trong bản trình diễn, chẳng hạn như chân trang hoặc số slide. Thêm trường vào một hộp văn bản thông thường không chuyển hình dạng đó thành placeholder.

Các quản lý header/footer kiểm soát văn bản placeholder và khả năng hiển thị trên slide, bố cục và master, bao gồm việc lan truyền tới các slide phụ thuộc. Do đó, một trường số trong hộp văn bản tùy chỉnh có thể hữu ích ngay cả khi bạn không sử dụng placeholder số slide. Ngược lại, thay đổi khả năng hiển thị của placeholder không xóa trường khỏi một hộp văn bản không liên quan.

Các kiểu header và footer đã định sẵn không tạo ra các placeholder tương ứng hoặc cung cấp nội dung của chúng. Cụ thể, một slide PowerPoint thông thường không có placeholder header; header thuộc về trang ghi chú và tài liệu phát tay. Đừng cho rằng một trường header hoặc footer trong một hình dạng bất kỳ sẽ tự động nhận được văn bản được cấu hình qua trình quản lý placeholder. Đối với quy trình đó, xem [Presentation Headers and Footers](/slides/vi/python-java/presentation-header-and-footer/).

## **Giới Hạn của PPTX và PPT**

Kiểm tra cả kiểu trường và văn bản kết quả của nó sau khi lưu và mở lại. Giữ lại một định danh không chứng minh rằng một ứng dụng có thể tính toán hoặc hiển thị giá trị của nó.

| Định Dạng | Cách hành xử và giới hạn của Trường |
|---|---|
| PPTX | Lưu trữ các định danh trường nội bộ cùng với văn bản trường. Trong các kiểm tra vòng quay, các kiểu đã định sẵn và định danh tùy chỉnh ở trên vẫn tồn tại sau khi lưu và mở lại. Kiểu tùy chỉnh không biết giữ lại văn bản dự phòng; nó không có logic tính toán tự động. Ứng dụng khác có thể xử lý các định danh không hỗ trợ khác nhau. |
| PPT | Sử dụng các biểu diễn trường legacy và có khả năng tương thích hạn chế hơn. Trong các kiểm tra vòng quay, trường số slide và các trường ngày/giờ đã định sẵn vẫn tồn tại sau khi lưu và mở lại. Trường tùy chỉnh trong một hộp văn bản slide thường được mở lại với định danh nhưng với văn bản `*`; một trường header trong cùng ngữ cảnh cũng tạo ra `*`. Không nên dựa vào việc các trường tùy chỉnh hoặc ngữ cảnh trường không hỗ trợ giữ lại văn bản hiển thị của chúng. |

Đối với đầu ra cố định, di động, hãy chuyển các trường không hỗ trợ thành văn bản thông thường và gán rõ ràng giá trị mong muốn trước khi lưu. Điều này giữ lại văn bản đã chọn nhưng cố ý ngừng cập nhật tự động. Đồng thời kiểm tra ứng dụng đích khi việc tính lại trường của nó là một phần của quy trình làm việc của bạn.

## **Câu Hỏi Thường Gặp**

**Làm sao tôi biết một số hoặc ngày hiển thị là trường hay không?**

Kiểm tra [Portion.getField](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#getField). Giá trị khác `None` xác định là một trường; chỉ nhìn vào văn bản hiển thị không thể nói được.

**Việc xóa một trường có xóa văn bản hoặc định dạng của nó không?**

Không. [removeField](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#removeField) chuyển phần hiện có thành văn bản thông thường. Gán một giá trị cụ thể sau đó nếu bạn cần một ngày cố định hoặc giá trị dự phòng.

**Chuỗi nội bộ có thể định nghĩa một định dạng ngày mới hoặc công thức không?**

Không. Nó chỉ xác định một kiểu trường. Định danh không biết không cung cấp bộ đánh giá hoặc mẫu định dạng ngày Python. Hãy sử dụng một kiểu đã định sẵn được hỗ trợ hoặc tự định dạng giá trị dưới dạng văn bản thông thường.

**Tại sao cần kiểm tra lại bản trình diễn sau khi lưu?**

Các định danh trường, văn bản đã tính và định dạng là các yếu tố riêng biệt cần xác minh. Việc chuyển đổi định dạng có thể thay đổi kết quả hiển thị ngay cả khi định danh trường vẫn còn.