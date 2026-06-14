---
title: Xuất các Phương Trình Toán học từ Bài thuyết trình trong Python
linktitle: Xuất Phương Trình
type: docs
weight: 30
url: /vi/python-net/exporting-math-equations/
keywords:
- xuất các phương trình toán học
- MathML
- LaTeX
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Mở khóa việc xuất liền mạch các phương trình toán học từ PowerPoint sang MathML bằng Aspose.Slides cho Python qua .NET—giữ định dạng và tăng tính tương thích."
---
## **Giới thiệu**

Aspose.Slides for Python via .NET cho phép bạn xuất các phương trình toán học từ bài thuyết trình. Ví dụ, bạn có thể cần trích xuất các phương trình từ các slide cụ thể và tái sử dụng chúng trong một chương trình hoặc nền tảng khác.

{{% alert color="primary" %}}
Bạn có thể xuất các phương trình sang MathML, một tiêu chuẩn được sử dụng rộng rãi để đại diện cho nội dung toán học trên web và trong nhiều ứng dụng.
{{% /alert %}}

## **Lưu các Phương Trình Toán Học dưới dạng MathML**

Mặc dù con người có thể dễ dàng viết LaTeX, MathML thường được tạo tự động bởi các ứng dụng. Vì MathML dựa trên XML, các chương trình có thể đọc và phân tích nó một cách đáng tin cậy, do đó nó thường được sử dụng như một định dạng xuất và in trong nhiều lĩnh vực.

Mã mẫu dưới đây cho thấy cách xuất một phương trình toán học từ bài thuyết trình sang MathML:
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **FAQ**

**Cụ thể, gì được xuất ra MathML—một đoạn hay một khối công thức riêng lẻ?**  
Bạn có thể xuất toàn bộ đoạn toán học ([MathParagraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathblock/)) sang MathML. Cả hai loại đều cung cấp phương pháp để ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản hoặc hình ảnh thông thường?**  
Một công thức tồn tại trong một [MathPortion](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathparagraph/). Hình ảnh và các phần văn bản thông thường không có [MathParagraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathparagraph/) không phải là công thức có thể xuất.

**MathML trong một bài thuyết trình xuất phát từ đâu—có phải là đặc thù của PowerPoint hay là một tiêu chuẩn?**  
Quá trình xuất nhắm tới MathML chuẩn (XML). Aspose sử dụng Presentation MathML — tập con trình bày của tiêu chuẩn — được sử dụng rộng rãi trong các ứng dụng và trên web.

**Có hỗ trợ xuất công thức trong bảng, SmartArt, nhóm, v.v. không?**  
Có, nếu các đối tượng đó chứa các phần văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathparagraph/) (tức là công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Việc xuất ra MathML có làm thay đổi bài thuyết trình gốc không?**  
Không. Việc ghi MathML là quá trình tuần tự hóa nội dung của công thức; nó không làm thay đổi tệp bài thuyết trình.