---
title: Xuất công thức toán học từ bản trình chiếu trên Android
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/androidjava/exporting-math-equations/
keywords:
- xuất công thức toán học
- MathML
- LaTeX
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Mở khóa việc xuất công thức toán học từ PowerPoint sang MathML một cách liền mạch bằng Aspose.Slides cho Android qua Java—giữ định dạng và tăng cường khả năng tương thích."
---
## **Giới thiệu**

Aspose.Slides for Android thông qua Java cho phép bạn xuất các công thức toán học từ các bản trình chiếu. Ví dụ, bạn có thể cần trích xuất các công thức toán học trên các slide (từ một bản trình chiếu cụ thể) và sử dụng chúng trong một chương trình hoặc nền tảng khác.

{{% alert color="primary" %}} 
Bạn có thể xuất các công thức sang MathML, một định dạng hoặc tiêu chuẩn phổ biến cho các công thức toán học và nội dung tương tự được thấy trên web và trong nhiều ứng dụng. 
{{% /alert %}}

## **Xuất công thức toán học từ bản trình chiếu**

Trong khi con người có thể dễ dàng viết mã cho một số định dạng công thức như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này được thiết kế để các ứng dụng tự động tạo ra. Các chương trình có thể đọc và phân tích MathML một cách dễ dàng vì mã của nó ở dạng XML, do đó MathML thường được sử dụng như một định dạng xuất và in trong nhiều lĩnh vực. 

Mã mẫu này cho bạn thấy cách xuất một công thức toán học từ bản trình chiếu sang MathML:

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

**Chính xác những gì được xuất sang MathML—một đoạn hay một khối công thức riêng lẻ?**

Bạn có thể xuất toàn bộ đoạn công thức toán học ([MathParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mathblock/)) sang MathML. Cả hai loại đều cung cấp một phương thức để ghi ra MathML.

**Làm thế nào để tôi nhận biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thường hoặc hình ảnh?**

Một công thức nằm trong một [MathPortion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mathparagraph/). Hình ảnh và các phần văn bản thường không có [MathParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mathparagraph/) không phải là công thức có thể xuất.

**MathML trong bản trình chiếu xuất phát từ đâu—có phải là đặc thù của PowerPoint hay là một tiêu chuẩn?**

Việc xuất nhắm tới MathML tiêu chuẩn (XML). Aspose sử dụng Presentation MathML—phần phụ của tiêu chuẩn dành cho bản trình chiếu—được sử dụng rộng rãi trong các ứng dụng và trên web.

**Việc xuất công thức nằm trong bảng, SmartArt, nhóm, v.v. có được hỗ trợ không?**

Có, nếu các đối tượng đó chứa các phần văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mathparagraph/) (tức là công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu công thức được nhúng dưới dạng hình ảnh, sẽ không được xuất.

**Việc xuất sang MathML có làm thay đổi bản trình chiếu gốc không?**

Không. Việc ghi MathML là quá trình tuần tự hóa nội dung công thức; nó không thay đổi tệp bản trình chiếu.