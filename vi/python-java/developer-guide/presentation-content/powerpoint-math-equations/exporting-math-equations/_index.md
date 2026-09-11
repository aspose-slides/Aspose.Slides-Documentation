---
title: Xuất các phương trình toán học từ bản trình chiếu trong Python
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/python-java/exporting-math-equations/
keywords:
- xuất các phương trình toán học
- xuất công thức sang LaTeX
- PowerPoint sang LaTeX
- MathML
- LaTeX
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Xuất các phương trình toán học từ bản trình chiếu PowerPoint sang LaTeX hoặc MathML một cách trực tiếp bằng Aspose.Slides cho Python thông qua Java."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn xuất các phương trình toán học từ các bản trình chiếu. Ví dụ, bạn có thể cần trích xuất các phương trình toán học trên các slide (từ một bản trình chiếu cụ thể) và sử dụng chúng trong một chương trình hoặc nền tảng khác. 

{{% alert color="info" title="Note" %}} 
Bạn có thể xuất các phương trình trực tiếp sang LaTeX hoặc MathML, một chuẩn phổ biến cho nội dung toán học được sử dụng trên web và trong nhiều ứng dụng.
{{% /alert %}}

## **Xuất các Phương trình Toán học sang LaTeX**

Aspose.Slides có thể chuyển đổi một phương trình toán học trong PowerPoint trực tiếp sang LaTeX; không cần tệp MathML trung gian hay bộ chuyển đổi bên ngoài. Một phương trình toán học được lưu trong một khung văn bản dưới dạng một [MathPortion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mathportion/). Sử dụng [MathPortion.getMathParagraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mathportion/#getMathParagraph) để lấy một [MathParagraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mathparagraph/), sau đó gọi [MathParagraph.toLatex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mathparagraph/#toLatex). Phương thức này trả về một chuỗi mà bạn có thể lưu, hiển thị, gửi tới ứng dụng khác, hoặc xử lý tiếp.

Ví dụ dưới đây sẽ duyệt qua mọi khung văn bản trên mỗi slide, tìm tất cả các math portion, và ghi mỗi phương trình vào một tệp `.tex` riêng biệt:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideutil/#getAllTextBoxes) trả về tất cả các khung văn bản được tìm thấy trên một slide. Kiểm tra kiểu [MathPortion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mathportion/) tách biệt các phương trình có thể chỉnh sửa thực sự khỏi văn bản và hình ảnh thông thường.

Các công cụ LaTeX và mẫu tài liệu không phải đều hỗ trợ cùng các lệnh, gói hoặc ký tự Unicode. Hãy kiểm tra chuỗi trả về bằng công cụ LaTeX mà ứng dụng của bạn sử dụng. Nếu một ký hiệu hoặc yếu tố Office Math không có biểu diễn thích hợp trong môi trường đó, hãy thay thế nó trong chuỗi trả về bằng một lệnh đặc thù của dự án hoặc bỏ qua phương trình và ghi lại vấn đề để xem xét.

## **Lưu các Phương trình Toán học dưới dạng MathML**

Mặc dù người dùng có thể dễ dàng viết mã cho một số định dạng phương trình như LaTeX, MathML khó viết bằng tay vì nó được thiết kế để tự động tạo ra bởi các ứng dụng. Các chương trình có thể dễ dàng đọc và phân tích MathML vì nó dựa trên XML, do đó MathML thường được sử dụng làm định dạng xuất và in trong nhiều lĩnh vực. 

Mã mẫu này cho bạn thấy cách xuất một phương trình toán học từ bản trình chiếu sang MathML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Chính xác thì gì được xuất ra MathML—một đoạn hay một khối công thức riêng lẻ?**

Bạn có thể xuất toàn bộ đoạn toán học ([MathParagraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mathblock/)) ra MathML. Cả hai loại đều cung cấp phương thức để ghi ra MathML.

**Làm sao để biết một đối tượng trên slide là công thức toán học chứ không phải văn bản hoặc hình ảnh thông thường?**

Một công thức tồn tại trong một [MathPortion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mathparagraph/). Hình ảnh và các phần văn bản thông thường không có [MathParagraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mathparagraph/) không phải là công thức có thể xuất được.

**MathML trong bản trình chiếu được tạo ra từ đâu—có phải là đặc thù của PowerPoint hay là một chuẩn?**

Quá trình xuất nhắm tới MathML chuẩn (XML). Aspose sử dụng Presentation MathML—tập con trình bày của chuẩn—được sử dụng rộng rãi trong các ứng dụng và trên web.

**Có hỗ trợ xuất công thức nằm trong bảng, SmartArt, nhóm, v.v. không?**

Có, nếu những đối tượng đó chứa các phần văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mathparagraph/) (tức là các công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu công thức được nhúng dưới dạng hình ảnh, thì không.

**Việc xuất sang MathML có thay đổi bản trình chiếu gốc không?**

Không. Ghi MathML chỉ là việc tuần tự hoá nội dung của công thức; nó không thay đổi tệp bản trình chiếu.