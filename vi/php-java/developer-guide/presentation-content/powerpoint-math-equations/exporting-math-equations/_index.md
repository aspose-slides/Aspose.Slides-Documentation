---
title: Xuất các phương trình toán học từ bài thuyết trình trong PHP
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/php-java/exporting-math-equations/
keywords:
- xuất các phương trình toán học
- MathML
- LaTeX
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Mở khóa việc xuất các phương trình toán học từ PowerPoint sang MathML một cách liền mạch bằng Aspose.Slides cho PHP qua Java — giữ nguyên định dạng và tăng tính tương thích."
---
## **Giới thiệu**

Aspose.Slides for PHP qua Java cho phép bạn xuất các phương trình toán học từ bài thuyết trình. Ví dụ, bạn có thể cần trích xuất các phương trình toán học trên các slide (từ một bài thuyết trình cụ thể) và sử dụng chúng trong một chương trình hoặc nền tảng khác.

{{% alert color="primary" %}} 
Bạn có thể xuất các phương trình sang MathML, một định dạng hoặc tiêu chuẩn phổ biến cho các phương trình toán học và nội dung tương tự được thấy trên web và trong nhiều ứng dụng. 
{{% /alert %}}

## **Lưu Phương Trình Toán Học dưới dạng MathML**

Trong khi con người có thể dễ dàng viết mã cho một số định dạng phương trình như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này được thiết kế để các ứng dụng tạo ra tự động. Các chương trình có thể đọc và phân tích MathML một cách dễ dàng vì mã của nó ở dạng XML, vì vậy MathML thường được sử dụng làm định dạng xuất và in trong nhiều lĩnh vực. 

Mã mẫu này cho thấy cách xuất một phương trình toán học từ bài thuyết trình sang MathML:

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

**Cái gì chính xác được xuất sang MathML—một đoạn toán hay một khối công thức riêng lẻ?**

Bạn có thể xuất toàn bộ đoạn toán ([MathParagraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathblock/)) sang MathML. Cả hai loại đều cung cấp phương thức ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thông thường hay hình ảnh?**

Một công thức tồn tại trong một [MathPortion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathparagraph/). Các hình ảnh và đoạn văn bản thông thường không có [MathParagraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathparagraph/) không phải là công thức có thể xuất.

**MathML trong một bài thuyết trình xuất phát từ đâu—có phải là đặc thù của PowerPoint hay là một tiêu chuẩn?**

Việc xuất hướng tới MathML tiêu chuẩn (XML). Aspose sử dụng Presentation MathML—phần trình diễn của chuẩn—được sử dụng rộng rãi trong các ứng dụng và trên web.

**Việc xuất công thức trong bảng, SmartArt, nhóm, v.v. có được hỗ trợ không?**

Có, nếu các đối tượng đó chứa các phần văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathparagraph/) (tức là các công thức PowerPoint thực tế), chúng sẽ được xuất. Nếu một công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Việc xuất sang MathML có làm thay đổi bài thuyết trình gốc không?**

Không. Việc ghi MathML là quá trình tuần tự hoá nội dung của công thức; nó không làm thay đổi tệp bài thuyết trình.