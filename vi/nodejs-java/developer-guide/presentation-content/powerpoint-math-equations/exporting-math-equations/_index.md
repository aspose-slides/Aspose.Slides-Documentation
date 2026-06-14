---
title: Xuất công thức toán học từ bản trình bày bằng JavaScript
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/nodejs-java/exporting-math-equations/
keywords:
- xuất công thức toán học
- MathML
- LaTeX
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Mở khóa việc xuất công thức toán học từ PowerPoint sang MathML một cách liền mạch bằng JavaScript và Aspose.Slides cho Node.js — giữ nguyên định dạng và tăng cường khả năng tương thích."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn xuất các công thức toán học từ bản trình bày. Ví dụ, bạn có thể cần trích xuất các công thức toán học trên các slide (từ một bản trình bày cụ thể) và sử dụng chúng trong chương trình hoặc nền tảng khác. 

{{% alert color="primary" %}} 

Bạn có thể xuất công thức sang MathML, một định dạng hoặc chuẩn phổ biến cho các công thức toán học và nội dung tương tự được hiển thị trên web và trong nhiều ứng dụng. 

{{% /alert %}}

## **Lưu công thức toán học dưới dạng MathML**

Trong khi con người có thể dễ dàng viết mã cho một số định dạng công thức như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này được thiết kế để các ứng dụng tạo ra tự động. Các chương trình có thể đọc và phân tích MathML một cách dễ dàng vì mã của nó ở dạng XML, do đó MathML thường được sử dụng như một định dạng xuất và in trong nhiều lĩnh vực. 

Đoạn mã mẫu sau cho bạn thấy cách xuất một công thức toán học từ bản trình bày sang MathML:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Chính xác thì gì được xuất sang MathML — một đoạn văn hay một khối công thức riêng lẻ?**

Bạn có thể xuất toàn bộ đoạn văn toán học([MathParagraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/)) hoặc một khối riêng lẻ([MathBlock](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathblock/)) sang MathML. Cả hai loại đều cung cấp phương thức để ghi ra MathML.

**Làm sao tôi biết rằng một đối tượng trên slide là công thức toán học chứ không phải văn bản thường hoặc hình ảnh?**

Một công thức nằm trong một[MathPortion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathportion/) và có một[MathParagraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/). Hình ảnh và các phần văn bản thường không có[MathParagraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/) sẽ không thể xuất thành công thức.

**MathML trong bản trình bày đến từ đâu — nó đặc thù cho PowerPoint hay là một chuẩn?**

Quá trình xuất nhắm tới MathML tiêu chuẩn(XML). Aspose sử dụng Presentation MathML — tập con của chuẩn dành cho trình chiếu — được sử dụng rộng rãi trong các ứng dụng và trên web.

**Có hỗ trợ xuất công thức nằm trong bảng, SmartArt, nhóm, v.v.?**

Có, nếu các đối tượng đó chứa các phần văn bản có[MathParagraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/) (tức là các công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Việc xuất sang MathML có thay đổi bản trình bày gốc không?**

Không. Việc ghi MathML là quá trình tuần tự hoá nội dung của công thức; nó không thay đổi tệp bản trình bày.