---
title: Xuất Phương Trình Toán Học từ Bản Trình Chiếu trong PHP
linktitle: Xuất Phương Trình
type: docs
weight: 30
url: /vi/php-java/exporting-math-equations/
keywords:
- xuất phương trình toán học
- xuất phương trình sang LaTeX
- PowerPoint sang LaTeX
- MathML
- LaTeX
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Xuất các phương trình toán học từ các bản trình chiếu PowerPoint sang LaTeX hoặc MathML một cách trực tiếp với Aspose.Slides cho PHP thông qua Java."
---
## **Giới thiệu**

Aspose.Slides cho PHP thông qua Java cho phép bạn xuất các phương trình toán học từ bản trình chiếu. Ví dụ, bạn có thể cần trích xuất các phương trình toán học trên các slide (từ một bản trình chiếu cụ thể) và sử dụng chúng trong một chương trình hoặc nền tảng khác.

{{% alert color="primary" %}} 
Bạn có thể xuất các phương trình trực tiếp sang LaTeX hoặc sang MathML, một tiêu chuẩn phổ biến cho nội dung toán học được sử dụng trên web và trong nhiều ứng dụng.
{{% /alert %}}

## **Xuất Phương Trình Toán Học sang LaTeX**

Aspose.Slides có thể chuyển đổi một phương trình toán học trong PowerPoint trực tiếp sang LaTeX; không cần tệp MathML trung gian và không cần bộ chuyển đổi bên ngoài. Một phương trình toán học được lưu trong một khung văn bản dưới dạng một [MathPortion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathportion/). Sử dụng [MathPortion::getMathParagraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathportion/#getMathParagraph) để lấy một [MathParagraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathparagraph/), sau đó gọi [MathParagraph::toLatex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathparagraph/#toLatex). Phương thức này trả về một chuỗi mà bạn có thể lưu, hiển thị, gửi tới ứng dụng khác, hoặc xử lý tiếp.

Ví dụ sau sẽ duyệt qua mọi khung văn bản trên mọi slide, tìm tất cả các math portion, và ghi mỗi phương trình vào một tệp `.tex` riêng:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideutil/#getAllTextBoxes) trả về tất cả các khung văn bản được tìm thấy trên một slide. Kiểm tra kiểu [MathPortion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathportion/) tách biệt các phương trình có thể chỉnh sửa thực sự khỏi văn bản và hình ảnh thông thường.

Các engine LaTeX và mẫu tài liệu không phải lúc nào cũng hỗ trợ cùng một lệnh, gói hoặc ký tự Unicode. Hãy kiểm tra chuỗi trả về bằng engine LaTeX mà ứng dụng của bạn sử dụng. Nếu một ký hiệu hoặc phần tử Office Math không có biểu diễn phù hợp trong môi trường đó, hãy thay thế nó trong chuỗi trả về bằng lệnh đặc thù của dự án hoặc bỏ qua phương trình và ghi lại vấn đề để xem xét.

## **Lưu Phương Trình Toán Học dưới dạng MathML**

Trong khi con người có thể dễ dàng viết mã cho một số định dạng phương trình như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này được thiết kế để được tạo tự động bởi các ứng dụng. Các chương trình có thể đọc và phân tích MathML một cách dễ dàng vì mã của nó dựa trên XML, do đó MathML thường được sử dụng làm định dạng xuất và in trong nhiều lĩnh vực.

Mã mẫu này cho bạn thấy cách xuất một phương trình toán học từ bản trình chiếu sang MathML:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Cụ thể, gì được xuất ra MathML—một đoạn hay một khối công thức riêng lẻ?**

Bạn có thể xuất toàn bộ đoạn toán học ([MathParagraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathblock/)) sang MathML. Cả hai kiểu đều cung cấp một phương thức để ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thường hoặc hình ảnh?**

Một công thức tồn tại trong một [MathPortion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathparagraph/). Hình ảnh và các đoạn văn bản thường không có [MathParagraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathparagraph/) không phải là công thức có thể xuất.

**MathML trong một bản trình chiếu xuất phát từ đâu—có phải là đặc thù của PowerPoint hay là một tiêu chuẩn?**

Quá trình xuất hướng tới MathML chuẩn (XML). Aspose sử dụng Presentation MathML—phần trình bày của tiêu chuẩn—được sử dụng rộng rãi trong các ứng dụng và trên web.

**Có hỗ trợ xuất công thức bên trong bảng, SmartArt, nhóm, v.v. không?**

Có, nếu các đối tượng đó chứa các đoạn văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathparagraph/) (tức là các công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu một công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Việc xuất sang MathML có thay đổi bản trình chiếu gốc không?**

Không. Việc ghi MathML chỉ là quá trình tuần tự hóa nội dung của công thức; nó không làm thay đổi tệp bản trình chiếu.