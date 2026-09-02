---
title: Xuất các phương trình toán học từ bản trình chiếu trong C++
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/cpp/exporting-math-equations/
keywords:
- xuất các phương trình toán học
- xuất công thức sang LaTeX
- PowerPoint sang LaTeX
- MathML
- LaTeX
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Xuất các phương trình toán học từ bản trình chiếu PowerPoint sang LaTeX hoặc MathML trực tiếp bằng Aspose.Slides cho C++."
---
## **Giới thiệu**

Aspose.Slides cho C++ cho phép bạn xuất các phương trình toán học từ bản trình chiếu. Ví dụ, bạn có thể cần trích xuất các phương trình toán học trên các slide (từ một bản trình chiếu cụ thể) và sử dụng chúng trong một chương trình hoặc nền tảng khác. 

{{% alert color="primary" %}} 

Bạn có thể xuất các phương trình trực tiếp sang LaTeX hoặc MathML, một tiêu chuẩn phổ biến cho nội dung toán học được sử dụng trên web và trong nhiều ứng dụng.

{{% /alert %}}

## **Xuất các phương trình toán học sang LaTeX**

Aspose.Slides có thể chuyển đổi một phương trình toán học PowerPoint trực tiếp sang LaTeX; không cần tệp MathML trung gian hay bộ chuyển đổi bên ngoài. Một phương trình toán học được lưu trong một khung văn bản dưới dạng một [IMathPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathportion/). Sử dụng [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) để lấy một [IMathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathparagraph/), và sau đó gọi [IMathParagraph::ToLatex](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). Phương thức trả về một chuỗi mà bạn có thể lưu, hiển thị, gửi tới ứng dụng khác, hoặc xử lý tiếp.

Ví dụ sau kiểm tra mọi khung văn bản trên mỗi slide, tìm tất cả các math portion, và ghi mỗi phương trình vào một tệp `.tex` riêng biệt:

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/getalltextboxes/) trả về tất cả các khung văn bản được tìm thấy trên một slide. Kiểm tra kiểu [IMathPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathportion/) tách các phương trình có thể chỉnh sửa thực sự khỏi văn bản và hình ảnh thông thường.

Các bộ công cụ LaTeX và mẫu tài liệu không phải lúc nào cũng hỗ trợ cùng một lệnh, gói hoặc ký tự Unicode. Hãy kiểm tra chuỗi trả về bằng bộ LaTeX được sử dụng bởi ứng dụng của bạn. Nếu một ký hiệu hoặc yếu tố Office Math không có biểu diễn phù hợp trong môi trường đó, hãy thay thế nó trong chuỗi trả về bằng lệnh đặc thù của dự án hoặc bỏ qua phương trình và ghi lại vấn đề để xem xét.

## **Lưu các phương trình toán học dưới dạng MathML**

Trong khi con người có thể dễ dàng viết mã cho một số định dạng phương trình như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này được thiết kế để được tạo tự động bởi các ứng dụng. Các chương trình có thể đọc và phân tích MathML một cách dễ dàng vì mã của nó ở dạng XML, do đó MathML thường được dùng làm định dạng xuất và in trong nhiều lĩnh vực. 

Mã mẫu này cho bạn thấy cách xuất một phương trình toán học từ bản trình chiếu sang MathML:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **Câu hỏi thường gặp**

**Thực tế, gì được xuất ra MathML—một đoạn hay một khối công thức riêng lẻ?**

Bạn có thể xuất cả một đoạn toán học toàn bộ ([MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathblock/)) sang MathML. Cả hai loại đều cung cấp một phương thức để ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thường hoặc hình ảnh?**

Một công thức tồn tại trong một [MathPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/). Các hình ảnh và các đoạn văn bản thường không có [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/) không thể xuất thành công thức.

**MathML trong một bản trình chiếu xuất phát từ đâu—có phải là đặc thù của PowerPoint hay là một tiêu chuẩn?**

Quá trình xuất nhắm tới MathML tiêu chuẩn (XML). Aspose sử dụng Presentation MathML—phần trình bày của tiêu chuẩn—được sử dụng rộng rãi trong các ứng dụng và trên web.

**Có hỗ trợ xuất công thức trong bảng, SmartArt, nhóm, v.v. không?**

Có, nếu các đối tượng đó chứa các đoạn văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/) (tức là các công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu một công thức được chèn dưới dạng hình ảnh, nó sẽ không được xuất.

**Việc xuất sang MathML có làm thay đổi bản trình chiếu gốc không?**

Không. Việc ghi MathML là quá trình tuần tự hoá nội dung của công thức; nó không thay đổi tệp bản trình chiếu.