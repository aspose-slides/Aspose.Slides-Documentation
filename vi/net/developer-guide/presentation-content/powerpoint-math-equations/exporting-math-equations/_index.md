---
title: Xuất công thức toán học từ bản trình bày trong .NET
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/net/exporting-math-equations/
keywords:
- xuất công thức toán học
- MathML
- LaTeX
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Mở khóa khả năng xuất liền mạch các công thức toán học từ PowerPoint sang MathML bằng Aspose.Slides cho .NET—giữ định dạng và tăng tính tương thích."
---
## **Giới thiệu**

Aspose.Slides for .NET cho phép bạn xuất các công thức toán học từ bản trình bày. Ví dụ, bạn có thể cần trích xuất các công thức toán học trên các slide (từ một bản trình bày cụ thể) và sử dụng chúng trong chương trình hoặc nền tảng khác. 

{{% alert color="primary" %}} 

Bạn có thể xuất các công thức sang MathML, một định dạng hoặc tiêu chuẩn phổ biến cho các công thức toán học và nội dung tương tự được hiển thị trên web và trong nhiều ứng dụng. 

{{% /alert %}}

## **Lưu công thức toán học dưới dạng MathML**

Trong khi con người có thể dễ dàng viết mã cho một số định dạng công thức như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này dự định được tạo tự động bởi các ứng dụng. Các chương trình có thể đọc và phân tích MathML một cách dễ dàng vì mã của nó nằm trong XML, do đó MathML thường được sử dụng làm định dạng xuất và in trong nhiều lĩnh vực. 

Đoạn mã mẫu này cho thấy cách xuất một công thức toán học từ bản trình bày sang MathML:

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

**Cụ thể, gì được xuất sang MathML — một đoạn văn toán học hay một khối công thức riêng lẻ?**

Bạn có thể xuất toàn bộ đoạn văn toán học ([MathParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathblock/)) sang MathML. Cả hai loại đều cung cấp phương thức ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thường hoặc hình ảnh?**

Một công thức nằm trong một [MathPortion](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathparagraph/). Các hình ảnh và đoạn văn bản thông thường không có [MathParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathparagraph/) không phải là công thức có thể xuất.

**MathML trong bản trình bày đến từ đâu — là đặc thù của PowerPoint hay là một tiêu chuẩn?**

Quá trình xuất nhắm tới MathML tiêu chuẩn (XML). Aspose sử dụng Presentation MathML — phần phụ của chuẩn dành cho trình chiếu — được sử dụng rộng rãi trong các ứng dụng và trên web.

**Có hỗ trợ xuất công thức trong bảng, SmartArt, nhóm, v.v.?**

Có, nếu các đối tượng đó chứa các đoạn văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathparagraph/) (tức là công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu công thức được nhúng dưới dạng hình ảnh, thì không.

**Xuất sang MathML có làm thay đổi bản trình bày gốc không?**

Không. Việc ghi MathML chỉ là quá trình tuần tự hoá nội dung công thức; nó không thay đổi tệp bản trình bày.