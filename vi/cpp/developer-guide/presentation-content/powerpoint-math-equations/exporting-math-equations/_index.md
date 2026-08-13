---
title: Xuất các phương trình toán học từ bản trình bày trong C++
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/cpp/exporting-math-equations/
keywords:
- xuất phương trình toán học
- xuất phương trình sang LaTeX
- PowerPoint sang LaTeX
- MathML
- LaTeX
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Xuất các phương trình toán học từ bản trình bày PowerPoint sang LaTeX hoặc MathML một cách trực tiếp với Aspose.Slides cho C++."
---
## **Giới thiệu**

Aspose.Slides for C++ cho phép bạn xuất các phương trình toán học từ bản trình bày. Ví dụ, bạn có thể cần trích xuất các phương trình toán học trên các slide (từ một bản trình bày cụ thể) và sử dụng chúng trong một chương trình hoặc nền tảng khác. 

{{% alert color="info" %}} 
Bạn có thể xuất các phương trình trực tiếp sang LaTeX hoặc sang MathML, một tiêu chuẩn phổ biến cho nội dung toán học được sử dụng trên web và trong nhiều ứng dụng.
{{% /alert %}}

## **Xuất các Phương Trình Toán Học sang LaTeX**

Aspose.Slides có thể chuyển đổi một phương trình toán học PowerPoint trực tiếp sang LaTeX; không cần tệp MathML trung gian và không cần bộ chuyển đổi bên ngoài. Một phương trình toán học được lưu trong một khung văn bản dưới dạng một [IMathPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathportion/). Sử dụng [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) để lấy một [IMathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathparagraph/), sau đó gọi [IMathParagraph::ToLatex](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). Phương thức trả về một chuỗi mà bạn có thể lưu, hiển thị, gửi tới ứng dụng khác, hoặc xử lý tiếp.

Ví dụ sau sẽ kiểm tra mọi khung văn bản trên mỗi slide, tìm tất cả các phần toán học, và ghi mỗi phương trình vào một tệp `.tex` riêng biệt:

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/getalltextboxes/) trả về tất cả các khung văn bản được tìm thấy trên một slide. Kiểm tra kiểu [IMathPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathportion/) tách biệt các phương trình chỉnh sửa thực sự khỏi văn bản và hình ảnh thông thường.

Các bộ máy LaTeX và mẫu tài liệu không phải đều hỗ trợ cùng một lệnh, gói, hoặc ký tự Unicode. Hãy kiểm tra chuỗi trả về với bộ máy LaTeX mà ứng dụng của bạn sử dụng. Nếu một ký hiệu hoặc yếu tố Office Math không có biểu diễn thích hợp trong môi trường đó, hãy thay thế nó trong chuỗi trả về bằng một lệnh đặc thù cho dự án hoặc bỏ qua phương trình và ghi lại vấn đề để xem xét.

## **Lưu Các Phương Trình Toán Học dưới dạng MathML**

Mặc dù con người có thể dễ dàng viết mã cho một số định dạng phương trình như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này được thiết kế để các ứng dụng tạo ra tự động. Các chương trình có thể đọc và phân tích MathML một cách dễ dàng vì mã của nó ở dạng XML, do đó MathML thường được sử dụng làm định dạng đầu ra và in ấn trong nhiều lĩnh vực. 

Mã mẫu này cho bạn thấy cách xuất một phương trình toán học từ bản trình bày sang MathML:

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::MathText;
using namespace System;
using namespace System::IO;

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

**Cụ thể gì được xuất ra MathML—một đoạn hay một khối công thức riêng lẻ?**

Bạn có thể xuất toàn bộ đoạn toán học ([MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathblock/)) sang MathML. Cả hai loại đều cung cấp một phương thức để ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thông thường hoặc hình ảnh?**

Một công thức tồn tại trong một [MathPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/). Các hình ảnh và phần văn bản thông thường không có [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/) không thể xuất thành công thức.

**MathML trong bản trình bày xuất phát từ đâu—đó là đặc thù của PowerPoint hay là một tiêu chuẩn?**

Quá trình xuất nhằm vào MathML tiêu chuẩn (XML). Aspose sử dụng Presentation MathML—phần trình bày của tiêu chuẩn—một phần được sử dụng rộng rãi trong các ứng dụng và trên web.

**Việc xuất các công thức bên trong bảng, SmartArt, nhóm, v.v. có được hỗ trợ không?**

Có, nếu các đối tượng đó chứa các phần văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/) (tức là các công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu một công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Việc xuất sang MathML có thay đổi bản trình bày gốc không?**

Không. Việc ghi MathML là quá trình tuần tự hoá nội dung của công thức; nó không làm thay đổi tệp bản trình bày.