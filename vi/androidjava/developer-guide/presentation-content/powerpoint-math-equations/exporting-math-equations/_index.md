---
title: Xuất công thức toán học từ bản trình bày trên Android
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/androidjava/exporting-math-equations/
keywords:
- xuất công thức toán học
- xuất công thức sang LaTeX
- PowerPoint sang LaTeX
- MathML
- LaTeX
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Xuất công thức toán học từ các bản trình bày PowerPoint sang LaTeX hoặc MathML trực tiếp bằng Aspose.Slides cho Android qua Java."
---
## **Giới thiệu**

Aspose.Slides for Android thông qua Java cho phép bạn xuất các công thức toán học từ bản trình bày. Ví dụ, bạn có thể cần trích xuất các công thức toán học trên các slide (từ một bản trình bày cụ thể) và sử dụng chúng trong một chương trình hoặc nền tảng khác.

{{% alert color="primary" %}} 

Bạn có thể xuất các công thức trực tiếp sang LaTeX hoặc sang MathML, một tiêu chuẩn phổ biến cho nội dung toán học được sử dụng trên web và trong nhiều ứng dụng.

{{% /alert %}}

## **Xuất công thức toán học sang LaTeX**

Aspose.Slides có thể chuyển đổi một công thức toán học PowerPoint trực tiếp sang LaTeX; không cần tệp MathML trung gian hay bộ chuyển đổi bên ngoài. Một công thức toán học được lưu trong một khung văn bản dưới dạng một [IMathPortion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imathportion/). Sử dụng [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) để lấy một [IMathParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imathparagraph/), sau đó gọi [IMathParagraph.toLatex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imathparagraph/#toLatex--). Phương thức này trả về một chuỗi mà bạn có thể lưu, hiển thị, gửi tới ứng dụng khác, hoặc tiếp tục xử lý.

Ví dụ sau sẽ kiểm tra mọi khung văn bản trên từng slide, tìm tất cả các phần toán học, và ghi mỗi công thức vào một tệp `.tex` riêng:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) trả về tất cả các khung văn bản được tìm thấy trên một slide. Kiểm tra kiểu [IMathPortion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imathportion/) tách biệt các công thức có thể chỉnh sửa thực sự khỏi văn bản và hình ảnh thông thường.

Các bộ máy LaTeX và mẫu tài liệu không phải đều hỗ trợ cùng một lệnh, gói hoặc ký tự Unicode. Hãy kiểm tra chuỗi trả về bằng bộ máy LaTeX mà ứng dụng của bạn sử dụng. Nếu một ký hiệu hoặc phần tử Office Math không có biểu diễn thích hợp trong môi trường đó, hãy thay thế nó trong chuỗi trả về bằng lệnh đặc thù cho dự án hoặc bỏ qua công thức và ghi lại vấn đề để xem xét.

## **Lưu công thức toán học dưới dạng MathML**

Trong khi con người có thể dễ dàng viết mã cho một số định dạng công thức như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này được thiết kế để được tạo tự động bởi các ứng dụng. Các chương trình có thể đọc và phân tích MathML dễ dàng vì mã của nó ở dạng XML, do đó MathML thường được sử dụng làm định dạng đầu ra và in ấn trong nhiều lĩnh vực. 

Đoạn mã mẫu này cho bạn thấy cách xuất một công thức toán học từ bản trình bày sang MathML:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Chính xác thì gì được xuất sang MathML—một đoạn hay một khối công thức riêng lẻ?**

Bạn có thể xuất toàn bộ đoạn toán học ([MathParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mathblock/)) sang MathML. Cả hai loại đều cung cấp phương thức để ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thông thường hay hình ảnh?**

Một công thức nằm trong một [MathPortion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mathparagraph/). Các hình ảnh và phần văn bản thông thường không có [MathParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mathparagraph/) không phải là công thức có thể xuất được.

**MathML trong bản trình bày xuất phát từ đâu—có phải là đặc thù PowerPoint hay là một tiêu chuẩn?**

Quá trình xuất hướng tới MathML tiêu chuẩn (XML). Aspose sử dụng Presentation MathML—phần trình bày của tiêu chuẩn—được sử dụng rộng rãi trong các ứng dụng và trên web.

**Việc xuất công thức trong bảng, SmartArt, nhóm, v.v. có được hỗ trợ không?**

Có, nếu các đối tượng đó chứa các phần văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mathparagraph/) (tức là các công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Xuất sang MathML có làm thay đổi bản trình bày gốc không?**

Không. Việc ghi MathML là quá trình tuần tự hóa nội dung của công thức; nó không làm thay đổi tệp bản trình bày.