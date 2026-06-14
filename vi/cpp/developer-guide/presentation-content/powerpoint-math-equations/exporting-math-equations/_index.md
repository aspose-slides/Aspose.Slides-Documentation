---
title: Xuất các phương trình toán học từ bản trình chiếu trong С++
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/cpp/exporting-math-equations/
keywords:
- xuất phương trình toán học
- MathML
- LaTeX
- PowerPoint
- bản trình chiếu
- С++
- Aspose.Slides
description: "Mở khóa khả năng xuất liền mạch các phương trình toán học từ PowerPoint sang MathML bằng Aspose.Slides cho С++ — giữ nguyên định dạng và tăng khả năng tương thích."
---
## **Giới thiệu**

Aspose.Slides for C++ cho phép bạn xuất các phương trình toán học từ bản trình chiếu. Ví dụ, bạn có thể cần trích xuất các phương trình toán học trên các slide (từ một bản trình chiếu cụ thể) và sử dụng chúng trong chương trình hoặc nền tảng khác. 

{{% alert color="primary" %}} 

Bạn có thể xuất các phương trình sang MathML, một định dạng hoặc tiêu chuẩn phổ biến cho các phương trình toán học và nội dung tương tự được thấy trên web và trong nhiều ứng dụng. 

{{% /alert %}}

## **Lưu các Phương Trình Toán Học dưới dạng MathML**

Trong khi con người dễ dàng viết mã cho một số định dạng phương trình như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này được thiết kế để được các ứng dụng tạo ra tự động. Các chương trình có thể đọc và phân tích MathML một cách dễ dàng vì mã của nó ở dạng XML, do đó MathML thường được sử dụng như một định dạng xuất và in trong nhiều lĩnh vực. 

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

## **Câu Hỏi Thường Gặp**

**Thực tế, gì được xuất ra MathML—một đoạn văn toán học hay một khối công thức riêng lẻ?**

Bạn có thể xuất toàn bộ đoạn văn toán học ([MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathblock/)) sang MathML. Cả hai loại đều cung cấp một phương thức để ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thường hoặc hình ảnh?**

Một công thức tồn tại trong một [MathPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/). Các hình ảnh và các phần văn bản thường không có [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/) không thể xuất dưới dạng công thức.

**MathML trong bản trình chiếu xuất phát từ đâu—có phải là đặc thù của PowerPoint hay là một tiêu chuẩn?**

Quá trình xuất nhắm tới MathML tiêu chuẩn (XML). Aspose sử dụng Presentation MathML—phần phụ của tiêu chuẩn dành cho trình chiếu—được sử dụng rộng rãi trong các ứng dụng và trên web.

**Việc xuất công thức trong bảng, SmartArt, nhóm, v.v. có được hỗ trợ không?**

Có, nếu các đối tượng đó chứa các phần văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/) (tức là các công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Xuất sang MathML có làm thay đổi bản trình chiếu gốc không?**

Không. Việc ghi MathML là một quá trình tuần tự hoá nội dung của công thức; nó không làm thay đổi tệp bản trình chiếu.