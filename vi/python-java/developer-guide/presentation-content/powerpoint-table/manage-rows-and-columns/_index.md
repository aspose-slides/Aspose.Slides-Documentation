---
title: Quản lý hàng và cột trong bảng PowerPoint bằng Python
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/python-java/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- tiêu đề bảng
- sao chép hàng
- sao chép cột
- chép hàng
- chép cột
- xóa hàng
- xóa cột
- định dạng văn bản hàng
- định dạng văn bản cột
- kiểu bảng
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Quản lý các hàng và cột của bảng trong PowerPoint bằng Aspose.Slides for Python via Java và tăng tốc việc chỉnh sửa bài thuyết trình và cập nhật dữ liệu."
---
## **Giới thiệu**

Aspose.Slides for Python via Java cho phép bạn quản lý cấu trúc và định dạng bảng trong các bài thuyết trình PowerPoint thông qua lớp [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Bạn có thể chỉ định hàng tiêu đề, sao chép hoặc xóa các hàng và cột, và áp dụng định dạng văn bản cho toàn bộ một hàng hoặc một cột.

Bài viết này giải thích các thao tác này bằng các ví dụ Python. Nó cũng cho thấy cách lấy preset kiểu bảng để bạn có thể tái sử dụng. Chỉ số hàng và cột của bảng được tính từ 0.

## **Kiểm soát chiều cao hàng**

Sử dụng [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) để đặt chiều cao tối thiểu của một hàng tính bằng điểm. Đây là giới hạn dưới, không phải chiều cao cố định. [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) trả về chiều cao thực tế. Truy cập hàng qua [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows).

Ví dụ tải [row-height-input.pptx](row-height-input.pptx), trong đó có một bảng là hình dạng đầu tiên trên slide đầu tiên. Hàng đầu tiên bắt đầu ở 70 điểm. Các ô sử dụng văn bản Arial 18 điểm, có ngắt dòng và lề trên và dưới 6 điểm; văn bản dài hơn ở cột thứ hai sẽ ngắt thành nhiều dòng. Ví dụ tăng tối thiểu lên 100 điểm, sau đó giảm xuống 20 điểm, in chiều cao thực tế sau mỗi lần thay đổi và lưu cả hai kết quả.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Với bản trình bày được cung cấp, việc tăng tối thiểu sẽ thêm không gian cho hàng. Việc giảm sẽ loại bỏ không gian bổ sung đó, nhưng chiều cao thực tế vẫn lớn hơn 20 điểm vì văn bản và lề ô cần nhiều chỗ hơn. Chỉ giảm tối thiểu không thể ép hàng xuống dưới mức không gian cần thiết cho nội dung của nó.

Một số yếu tố ảnh hưởng đến chiều cao thực tế:

- **Văn bản và kích thước phông chữ:** văn bản dài hơn, ngắt dòng thủ công, hoặc phông chữ lớn hơn có thể yêu cầu nhiều không gian theo chiều dọc.
- **Ngắt dòng và độ rộng cột:** khi bật ngắt dòng, giảm độ rộng cột bằng [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) có thể tạo ra nhiều dòng hơn. Một cột rộng hơn có thể giảm không gian cần thiết theo chiều dọc.
- **Lề ô:** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) và [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) thêm không gian dọc. [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) và [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) giảm độ rộng khả dụng cho văn bản và có thể gây ngắt dòng bổ sung.

Đối với bảng này không có ô hợp nhất, ô cần nhiều không gian dọc nhất sẽ quyết định giới hạn dưới dựa trên nội dung cho toàn bộ hàng. Để làm ngắn hơn hàng, bạn cũng có thể cần rút ngắn văn bản, giảm kích thước phông chữ hoặc lề, hoặc làm rộng một cột.

Các hình ảnh dưới đây cho cùng một bảng ở cùng tầm phóng đại. Trong các kết quả minh họa, chiều cao thực tế lần lượt là 70, 100 và 55,2 điểm: hàng cuối cùng vẫn cao hơn mức tối thiểu 20 điểm. Các đo lường văn bản chính xác có thể thay đổi tùy vào phông chữ có trong môi trường của bạn. Tải kết quả đã lưu: [increased minimum](row-height-increased.pptx) và [decreased minimum](row-height-decreased.pptx).

| Gốc: tối thiểu 70 pt, thực tế 70 pt | Tăng: tối thiểu 100 pt, thực tế 100 pt | Giảm: tối thiểu 20 pt, thực tế 55.2 pt |
| --- | --- | --- |
| ![Bảng gốc với hàng đầu tiên 70 điểm.](row-height-before.png) | ![Bảng sau khi tăng tối thiểu hàng đầu tiên lên 100 điểm.](row-height-increased.png) | ![Bảng sau khi giảm tối thiểu hàng đầu tiên xuống 20 điểm; văn bản ngắt dòng khiến hàng vẫn cao hơn mức tối thiểu.](row-height-decreased.png) |

## **Đặt hàng đầu tiên làm tiêu đề**

Sử dụng phương thức [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow) để đánh dấu hàng đầu tiên cho định dạng tiêu đề. Hiển thị của nó phụ thuộc vào kiểu bảng được áp dụng cho bảng.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Truy cập bảng được lưu làm hình dạng đầu tiên trên slide.
4. Bật định dạng tiêu đề cho hàng đầu tiên.
5. Lưu bản trình bày đã sửa đổi.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên. Nó bật định dạng tiêu đề cho hàng đầu tiên và lưu thành `First_row_header.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sao chép một hàng hoặc cột bảng**

Sao chép các hàng hoặc cột để tái sử dụng nội dung và định dạng của chúng. Bạn có thể thêm một bản sao vào cuối bảng hoặc chèn nó vào vị trí cụ thể.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Xác định độ rộng cột và chiều cao hàng.
4. Thêm bảng bằng phương thức [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Sao chép các hàng cần thiết.
6. Sao chép các cột cần thiết.
7. Lưu bản trình bày đã sửa đổi.

Ví dụ yêu cầu `Test.pptx` có ít nhất một slide. Nó tạo một bảng có ba cột và năm hàng, với kích thước được chỉ định bằng điểm. Nó thêm các bản sao của hàng và cột đầu tiên, sau đó chèn các bản sao của hàng và cột thứ hai tại chỉ số 3 (vị trí thứ tư). Bảng kết quả có bảy hàng và năm cột. Tham số `False` vô hiệu hoá việc sao chép vào các hàng hoặc cột hợp nhất liền kề; bảng này không có ô hợp nhất.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)

    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)

    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Xóa một hàng hoặc cột khỏi bảng**

Xóa các hàng hoặc cột không còn cần thiết trong bảng. Khi xóa một mục, các chỉ số của các hàng hoặc cột phía sau nó sẽ được dịch chuyển.

1. Tạo một bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Xác định độ rộng cột và chiều cao hàng.
4. Thêm bảng bằng phương thức [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Xóa hàng thứ hai và cột thứ hai.
6. Lưu bản trình bày đã sửa đổi.

Ví dụ này tạo một bảng ba‑bằng‑ba và xóa hàng và cột tại chỉ số 1, để lại một bảng hai‑bằng‑hai trong `TestTable_out.pptx`. Các kích thước tính bằng điểm. Tham số `False` vô hiệu hoá việc xóa các hàng hoặc cột hợp nhất liền kề; bảng này không có ô hợp nhất.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt định dạng văn bản ở mức hàng bảng**

Áp dụng định dạng văn bản cho toàn bộ một hàng để giữ cho các ô trong hàng đồng nhất. Bạn có thể đặt thuộc tính phông chữ, định dạng đoạn văn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Sử dụng [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) cho hàng đầu tiên.
4. Sử dụng [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) và [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) cho hàng đầu tiên.
5. Sử dụng [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) cho hàng thứ hai.
6. Lưu bản trình bày đã sửa đổi.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên và ít nhất hai hàng. Nó áp dụng văn bản 25 điểm, căn phải và lề đoạn văn phải 20 điểm cho hàng đầu tiên, sau đó đặt văn bản dọc cho hàng thứ hai.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getRows().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getRows().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getRows().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt định dạng văn bản ở mức cột bảng**

Áp dụng định dạng văn bản cho toàn bộ một cột để giữ cho các ô trong cột đồng nhất. Bạn có thể đặt thuộc tính phông chữ, định dạng đoạn văn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Sử dụng [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) cho cột đầu tiên.
4. Sử dụng [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) và [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) cho cột đầu tiên.
5. Sử dụng [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) cho cột thứ hai.
6. Lưu bản trình bày đã sửa đổi.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên và ít nhất hai cột. Nó áp dụng văn bản 25 điểm, căn phải và lề đoạn văn phải 20 điểm cho cột đầu tiên, sau đó đặt văn bản dọc cho cột thứ hai.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getColumns().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getColumns().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getColumns().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lấy thuộc tính kiểu bảng**

Sử dụng phương thức [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) để lấy preset được áp dụng cho một bảng và tái sử dụng nó cho bảng khác. Điều này xác định preset thay vì các ghi đè định dạng ô riêng lẻ.

Ví dụ tạo một bảng, áp dụng [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1), và đọc lại preset. Nó in giá trị nguyên tương ứng với `DarkStyle1` và lưu bảng trong `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng chủ đề/kiểu PowerPoint cho một bảng đã được tạo chưa?**

Có. Bảng kế thừa chủ đề của slide/bố cục/máster, và bạn vẫn có thể ghi đè màu nền, viền và màu chữ trên nền chủ đề đó.

**Tôi có thể sắp xếp các hàng của bảng giống như trong Excel không?**

Không, các bảng Aspose.Slides không có tính năng sắp xếp hay bộ lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, sau đó điền lại các hàng bảng theo thứ tự đó.

**Tôi có thể có các cột kẻ sọc (banded) trong khi vẫn giữ màu tùy chỉnh cho các ô riêng lẻ không?**

Có. Bật cột kẻ sọc, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng ở cấp ô sẽ có ưu tiên hơn kiểu bảng.