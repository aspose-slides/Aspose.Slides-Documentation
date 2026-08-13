---
title: Xuất các phương trình toán học từ bản trình bày trong Java
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/java/exporting-math-equations/
keywords:
- xuất phương trình toán học
- xuất công thức sang LaTeX
- PowerPoint sang LaTeX
- MathML
- LaTeX
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Xuất các phương trình toán học từ bản trình bày PowerPoint sang LaTeX hoặc MathML trực tiếp bằng Aspose.Slides cho Java."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn xuất các phương trình toán học từ bản trình bày. Ví dụ, bạn có thể cần trích xuất các phương trình toán học trên các slide (từ một bản trình bày cụ thể) và sử dụng chúng trong một chương trình hoặc nền tảng khác. 

{{% alert color="info" %}} 
Bạn có thể xuất các phương trình trực tiếp sang LaTeX hoặc sang MathML, một tiêu chuẩn phổ biến cho nội dung toán học được sử dụng trên web và trong nhiều ứng dụng.
{{% /alert %}}

## **Xuất các Phương Trình Toán Học sang LaTeX**

Aspose.Slides có thể chuyển đổi một phương trình toán học trong PowerPoint trực tiếp sang LaTeX; không cần tệp MathML trung gian hay bộ chuyển đổi bên ngoài. Một phương trình toán học được lưu trong một khung văn bản dưới dạng một [IMathPortion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathportion/). Sử dụng [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathportion/#getMathParagraph--) để lấy một [IMathParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathparagraph/), sau đó gọi [IMathParagraph.toLatex](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathparagraph/#toLatex--). Phương thức trả về một chuỗi mà bạn có thể lưu, hiển thị, gửi đến ứng dụng khác, hoặc xử lý tiếp.

Ví dụ sau sẽ kiểm tra mỗi khung văn bản trên mỗi slide, tìm tất cả các phần toán học, và ghi mỗi phương trình vào một tệp `.tex` riêng biệt:

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
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) trả về tất cả các khung văn bản được tìm thấy trên một slide. Kiểm tra loại [IMathPortion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathportion/) tách biệt các phương trình có thể chỉnh sửa thực sự khỏi văn bản và hình ảnh thông thường.

Các bộ máy LaTeX và mẫu tài liệu không phải đều hỗ trợ cùng một lệnh, gói hoặc ký tự Unicode. Hãy kiểm tra chuỗi trả về bằng bộ máy LaTeX mà ứng dụng của bạn sử dụng. Nếu một ký hiệu hoặc phần tử Office Math không có biểu diễn phù hợp trong môi trường đó, hãy thay thế nó trong chuỗi trả về bằng lệnh riêng của dự án hoặc bỏ qua phương trình và ghi lại vấn đề để xem xét.

## **Lưu Các Phương Trình Toán Học dưới dạng MathML**

Trong khi con người có thể viết mã cho một số định dạng phương trình như LaTeX một cách dễ dàng, họ gặp khó khăn khi viết mã cho MathML vì định dạng này được thiết kế để các ứng dụng tự động tạo ra. Các chương trình có thể đọc và phân tích MathML dễ dàng vì mã của nó nằm trong XML, vì vậy MathML thường được sử dụng làm định dạng xuất và in trong nhiều lĩnh vực. 

Mã mẫu sau cho bạn thấy cách xuất một phương trình toán học từ bản trình bày sang MathML:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

## **Câu Hỏi Thường Gặp**

**Thực tế, gì được xuất sang MathML—một đoạn hay một khối công thức riêng lẻ?**  
Bạn có thể xuất toàn bộ đoạn toán học ([MathParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathblock/)) sang MathML. Cả hai loại đều cung cấp một phương thức để ghi ra MathML.

**Làm thế nào để tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thường hoặc hình ảnh?**  
Một công thức tồn tại trong một [MathPortion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathparagraph/). Hình ảnh và các phần văn bản thông thường không có [MathParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathparagraph/) không phải là công thức có thể xuất.

**MathML trong bản trình bày xuất phát từ đâu—có phải đặc thù PowerPoint hay là một tiêu chuẩn?**  
Việc xuất hướng đến MathML chuẩn (XML). Aspose sử dụng Presentation MathML—phần phụ của tiêu chuẩn dành cho trình bày—được sử dụng rộng rãi trong các ứng dụng và trên web.

**Có hỗ trợ xuất công thức nằm trong bảng, SmartArt, nhóm, v.v. không?**  
Có, nếu các đối tượng đó chứa các phần văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathparagraph/) (tức là công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Việc xuất sang MathML có thay đổi bản trình bày gốc không?**  
Không. Việc ghi MathML chỉ là việc tuần tự hoá nội dung của công thức; nó không thay đổi tệp bản trình bày.