---
title: Xuất các phương trình toán học từ bản trình chiếu bằng Python
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/python-net/exporting-math-equations/
keywords:
- xuất các phương trình toán học
- xuất công thức sang LaTeX
- PowerPoint sang LaTeX
- MathML
- LaTeX
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Xuất các phương trình toán học từ bản trình chiếu PowerPoint sang LaTeX hoặc MathML trực tiếp bằng Aspose.Slides cho Python qua .NET."
---
## **Giới thiệu**

Aspose.Slides for Python via .NET cho phép bạn xuất các phương trình toán học từ bản trình chiếu. Ví dụ, bạn có thể cần trích xuất các phương trình từ các slide cụ thể và tái sử dụng chúng trong chương trình hoặc nền tảng khác.

{{% alert color="primary" %}}
Bạn có thể xuất các phương trình trực tiếp sang LaTeX hoặc sang MathML, một tiêu chuẩn phổ biến cho nội dung toán học được sử dụng trên web và trong nhiều ứng dụng.
{{% /alert %}}

## **Xuất các phương trình toán học sang LaTeX**

Aspose.Slides có thể chuyển đổi một phương trình toán học PowerPoint trực tiếp sang LaTeX; không cần tệp MathML trung gian hay bộ chuyển đổi bên ngoài. Một phương trình toán học được lưu trong một khung văn bản dưới dạng một [MathPortion](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathportion/). Sử dụng [MathPortion.math_paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) để lấy một [MathParagraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathparagraph/), sau đó gọi [MathParagraph.to_latex](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathparagraph/to_latex/). Phương thức trả về một chuỗi mà bạn có thể lưu, hiển thị, gửi tới ứng dụng khác, hoặc xử lý tiếp.

Ví dụ sau sẽ duyệt qua mọi khung văn bản trên mọi slide, tìm tất cả các math portion, và ghi mỗi phương trình vào một tệp `.tex` riêng biệt:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) trả về tất cả các khung văn bản được tìm thấy trên một slide. Kiểm tra kiểu [MathPortion](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathportion/) tách biệt các phương trình có thể chỉnh sửa thực sự khỏi văn bản và hình ảnh thông thường.

Các engine LaTeX và mẫu tài liệu không phải lúc nào cũng hỗ trợ cùng một lệnh, gói hoặc ký tự Unicode. Hãy kiểm tra chuỗi trả về bằng engine LaTeX mà ứng dụng của bạn sử dụng. Nếu một ký hiệu hoặc phần tử Office Math không có biểu diễn phù hợp trong môi trường đó, hãy thay thế nó trong chuỗi trả về bằng lệnh đặc thù của dự án hoặc bỏ qua phương trình và ghi lại vấn đề để xem xét.

## **Lưu các phương trình toán học dưới dạng MathML**

Mặc dù con người có thể dễ dàng viết LaTeX, MathML thường được tạo tự động bởi các ứng dụng. Vì MathML dựa trên XML, các chương trình có thể đọc và phân tích nó một cách đáng tin cậy, do đó nó thường được sử dụng như một định dạng xuất và in trong nhiều lĩnh vực.

Mã mẫu sau cho thấy cách xuất một phương trình toán học từ bản trình chiếu sang MathML:

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

## **Câu hỏi thường gặp**

**Thực tế, gì được xuất ra MathML—một đoạn hay một khối công thức riêng lẻ?**  
Bạn có thể xuất toàn bộ đoạn toán học ([MathParagraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathblock/)) sang MathML. Cả hai loại đều cung cấp một phương thức để ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thông thường hoặc hình ảnh?**  
Một công thức tồn tại trong một [MathPortion](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathparagraph/). Hình ảnh và các phần văn bản thông thường không có [MathParagraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathparagraph/) không phải là các công thức có thể xuất.

**MathML trong bản trình chiếu xuất phát từ đâu—có phải là đặc thù PowerPoint hay là một tiêu chuẩn?**  
Việc xuất nhắm tới MathML tiêu chuẩn (XML). Aspose sử dụng Presentation MathML—phần phụ trình bày của tiêu chuẩn—được sử dụng rộng rãi trong các ứng dụng và trên web.

**Có hỗ trợ xuất công thức nằm trong bảng, SmartArt, nhóm, v.v. không?**  
Có, nếu các đối tượng đó chứa các phần văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathparagraph/) (tức là các công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu một công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Việc xuất sang MathML có thay đổi bản trình chiếu gốc không?**  
Không. Việc ghi MathML là quá trình tuần tự hóa nội dung của công thức; nó không thay đổi tệp bản trình chiếu.