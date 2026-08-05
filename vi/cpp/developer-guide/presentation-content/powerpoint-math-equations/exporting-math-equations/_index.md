---
title: "Xuất các phương trình toán học từ bản trình chiếu trong C++"
linktitle: "Xuất các phương trình"
type: docs
weight: 30
url: /vi/cpp/exporting-math-equations/
keywords:
  - "xuất các phương trình toán học"
  - "MathML"
  - "LaTeX"
  - "PowerPoint"
  - "bản trình chiếu"
  - "C++"
  - "Aspose.Slides"
description: "Mở khóa việc xuất liền mạch các phương trình toán học từ PowerPoint sang MathML bằng Aspose.Slides cho C++ — giữ nguyên định dạng và tăng cường khả năng tương thích."
---
## **Giới thiệu**

Aspose.Slides for C++ cho phép bạn xuất các phương trình toán học từ bản trình chiếu. Ví dụ, bạn có thể cần trích xuất các phương trình toán học trên các slide (từ một bản trình chiếu cụ thể) và sử dụng chúng trong một chương trình hoặc nền tảng khác. 

{{% alert color="primary" %}} 

Bạn có thể xuất các phương trình sang MathML, một định dạng hoặc tiêu chuẩn phổ biến cho các phương trình toán học và nội dung tương tự được thấy trên web và trong nhiều ứng dụng. 

{{% /alert %}}

## **Lưu các Phương trình Toán học dưới dạng MathML**

Trong khi con người dễ dàng viết mã cho một số định dạng phương trình như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này được thiết kế để được các ứng dụng tạo ra tự động. Các chương trình có thể đọc và phân tích MathML một cách dễ dàng vì mã của nó nằm trong XML, do đó MathML thường được sử dụng làm định dạng đầu ra và in trong nhiều lĩnh vực. 

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

## **FAQ**

**Thực sự gì được xuất ra MathML—một đoạn văn hay một khối công thức riêng lẻ?**

Bạn có thể xuất toàn bộ đoạn toán ([MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathblock/)) sang MathML. Cả hai loại đều cung cấp phương thức để ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thường hoặc hình ảnh?**

Một công thức nằm trong một [MathPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/). Hình ảnh và các phần văn bản thường không có [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/) không thể xuất thành công thức.

**MathML trong bản trình chiếu đến từ đâu—có phải là đặc thù của PowerPoint hay là một tiêu chuẩn?**

Quá trình xuất nhắm tới MathML tiêu chuẩn (XML). Aspose sử dụng Presentation MathML—phần con của tiêu chuẩn dùng cho trình chiếu—điều này được sử dụng rộng rãi trong các ứng dụng và trên web.

**Có hỗ trợ xuất công thức nằm trong bảng, SmartArt, nhóm, v.v. không?**

Có, nếu các đối tượng đó chứa các phần văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/) (tức là các công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu một công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Việc xuất sang MathML có thay đổi bản trình chiếu gốc không?**

Không. Việc ghi MathML chỉ là quá trình tuần tự hoá nội dung của công thức; nó không làm thay đổi tệp bản trình chiếu.