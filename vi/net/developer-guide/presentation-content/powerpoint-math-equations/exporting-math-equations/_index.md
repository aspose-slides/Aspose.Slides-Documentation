---
title: Xuất các phương trình toán học từ bản trình chiếu trong .NET
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/net/exporting-math-equations/
keywords:
- "xuất các phương trình toán học"
- "xuất công thức sang LaTeX"
- "PowerPoint sang LaTeX"
- MathML
- LaTeX
- PowerPoint
- "bản trình chiếu"
- .NET
- C#
- Aspose.Slides
description: "Xuất các phương trình toán học từ các bản trình chiếu PowerPoint sang LaTeX hoặc MathML trực tiếp bằng Aspose.Slides cho .NET."
---
## **Giới thiệu**

Aspose.Slides for .NET cho phép bạn xuất các phương trình toán học từ bản trình chiếu. Ví dụ, bạn có thể cần trích xuất các phương trình toán học trên các slide (từ một bản trình chiếu cụ thể) và sử dụng chúng trong một chương trình hoặc nền tảng khác. 

{{% alert color="primary" %}} 

Bạn có thể xuất các phương trình trực tiếp sang LaTeX hoặc MathML, một chuẩn phổ biến cho nội dung toán học được sử dụng trên web và trong nhiều ứng dụng.

{{% /alert %}}

## **Xuất các phương trình toán học sang LaTeX**

Aspose.Slides có thể chuyển đổi một phương trình toán học PowerPoint trực tiếp sang LaTeX; không cần tệp MathML trung gian hay bộ chuyển đổi bên ngoài. Một phương trình toán học được lưu trong một khung văn bản dưới dạng một [MathPortion](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathportion/). Sử dụng [MathPortion.MathParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathportion/mathparagraph/) để lấy một [IMathParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathparagraph/), sau đó gọi [IMathParagraph.ToLatex](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathparagraph/tolatex/). Phương thức trả về một chuỗi mà bạn có thể lưu, hiển thị, gửi tới ứng dụng khác, hoặc xử lý tiếp.

Ví dụ sau sẽ kiểm tra mọi khung văn bản trên mỗi slide, tìm tất cả các phần toán học, và ghi mỗi phương trình vào một tệp `.tex` riêng biệt:

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/getalltextboxes/) trả về tất cả các khung văn bản được tìm thấy trên một slide. Kiểm tra kiểu [MathPortion](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathportion/) tách các phương trình có thể chỉnh sửa thực sự khỏi văn bản và hình ảnh thông thường.

Các engine LaTeX và mẫu tài liệu không phải đều hỗ trợ cùng một lệnh, gói hoặc ký tự Unicode. Hãy kiểm tra chuỗi trả về bằng engine LaTeX mà ứng dụng của bạn sử dụng. Nếu một ký hiệu hoặc phần tử Office Math không có biểu diễn phù hợp trong môi trường đó, hãy thay thế nó trong chuỗi trả về bằng một lệnh riêng cho dự án hoặc bỏ qua phương trình và ghi lại vấn đề để xem xét.

## **Lưu các phương trình toán học dưới dạng MathML**

Mặc dù con người có thể dễ dàng viết mã cho một số định dạng phương trình như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này được tạo tự động bởi các ứng dụng. Các chương trình có thể đọc và phân tích MathML dễ dàng vì mã của nó ở dạng XML, do đó MathML thường được sử dụng làm định dạng xuất và in trong nhiều lĩnh vực. 

Mã mẫu này cho bạn thấy cách xuất một phương trình toán học từ bản trình chiếu sang MathML:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **Câu hỏi thường gặp**

**Thực tế, gì được xuất sang MathML—một đoạn văn hay một khối công thức riêng lẻ?**

Bạn có thể xuất cả một đoạn toán học toàn bộ ([MathParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathblock/)) sang MathML. Cả hai loại đều cung cấp một phương pháp để ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thường hoặc hình ảnh?**

Một công thức tồn tại trong một [MathPortion](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathparagraph/). Hình ảnh và các phần văn bản thường không có [MathParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathparagraph/) không phải là các công thức có thể xuất.

**MathML trong bản trình chiếu xuất phát từ đâu—có phải là đặc thù của PowerPoint hay là một chuẩn?**

Quá trình xuất nhắm tới MathML chuẩn (XML). Aspose sử dụng Presentation MathML—phần trình bày của chuẩn—được sử dụng rộng rãi trong các ứng dụng và trên web.

**Có hỗ trợ xuất các công thức nằm trong bảng, SmartArt, nhóm, v.v. không?**

Có, nếu các đối tượng đó chứa các phần văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathparagraph/) (tức là các công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu một công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Việc xuất sang MathML có làm thay đổi bản trình chiếu gốc không?**

Không. Ghi ra MathML là quá trình tuần tự hóa nội dung của công thức; nó không thay đổi tệp bản trình chiếu.