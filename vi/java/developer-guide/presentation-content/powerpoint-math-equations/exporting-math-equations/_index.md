---
title: Xuất các công thức toán học từ bản trình chiếu trong Java
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/java/exporting-math-equations/
keywords:
- xuất công thức toán học
- MathML
- LaTeX
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Mở khóa khả năng xuất liền mạch các công thức toán học từ PowerPoint sang MathML bằng Aspose.Slides cho Java—giữ nguyên định dạng và tăng cường tính tương thích."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn xuất các công thức toán học từ bản trình chiếu. Ví dụ, bạn có thể cần trích xuất các công thức toán học trên các slide (từ một bản trình chiếu cụ thể) và sử dụng chúng trong một chương trình hoặc nền tảng khác. 

{{% alert color="primary" %}} 

Bạn có thể xuất công thức sang MathML, một định dạng hoặc chuẩn phổ biến cho các công thức toán học và nội dung tương tự được thấy trên web và trong nhiều ứng dụng. 

{{% /alert %}}

## **Lưu công thức toán học dưới dạng MathML**

Trong khi con người dễ dàng viết mã cho một số định dạng công thức như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này được thiết kế để được tạo tự động bởi các ứng dụng. Các chương trình có thể đọc và phân tích MathML dễ dàng vì mã của nó nằm trong XML, do đó MathML thường được sử dụng làm định dạng đầu ra và in trong nhiều lĩnh vực. 

Mã mẫu này cho thấy cách xuất một công thức toán học từ bản trình chiếu sang MathML:

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

**Điều gì chính xác được xuất sang MathML—một đoạn văn hay một khối công thức riêng lẻ?**

Bạn có thể xuất toàn bộ đoạn văn toán học([MathParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathparagraph/)) hoặc một khối riêng lẻ([MathBlock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathblock/)) sang MathML. Cả hai loại đều cung cấp phương thức để ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học thay vì văn bản thường hoặc hình ảnh?**

Một công thức nằm trong một[MathPortion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathportion/) và có một[MathParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathparagraph/). Hình ảnh và các phần văn bản thường không có[MathParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathparagraph/) không thể xuất thành công thức.

**MathML trong bản trình chiếu đến từ đâu—đặc thù của PowerPoint hay là một chuẩn?**

Quá trình xuất nhắm tới MathML chuẩn(XML). Aspose sử dụng Presentation MathML—phần con của chuẩn dành cho trình chiếu—được sử dụng rộng rãi trong các ứng dụng và trên web.

**Có hỗ trợ xuất công thức nằm trong bảng, SmartArt, nhóm, v.v. không?**

Có, nếu các đối tượng đó chứa các phần văn bản có[MathParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathparagraph/)(tức là các công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Việc xuất sang MathML có thay đổi bản trình chiếu gốc không?**

Không. Việc ghi MathML là quá trình tuần tự hóa nội dung của công thức; nó không thay đổi tệp bản trình chiếu.