---
title: Xuất công thức toán học từ bản trình bày bằng JavaScript
linktitle: Xuất công thức
type: docs
weight: 30
url: /vi/nodejs-java/exporting-math-equations/
keywords:
- xuất công thức toán học
- xuất công thức sang LaTeX
- PowerPoint sang LaTeX
- MathML
- LaTeX
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Xuất công thức toán học từ bản trình bày PowerPoint sang LaTeX hoặc MathML trực tiếp bằng Aspose.Slides cho Node.js qua Java."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn xuất các công thức toán học từ bản trình bày. Ví dụ, bạn có thể cần trích xuất các công thức toán học trên các slide (từ một bản trình bày cụ thể) và sử dụng chúng trong một chương trình hoặc nền tảng khác. 

{{% alert color="primary" %}} 

Bạn có thể xuất các công thức trực tiếp sang LaTeX hoặc sang MathML, một chuẩn phổ biến cho nội dung toán học được sử dụng trên web và trong nhiều ứng dụng.

{{% /alert %}}

## **Xuất công thức toán học sang LaTeX**

Aspose.Slides có thể chuyển đổi trực tiếp công thức toán học trong PowerPoint sang LaTeX; không cần tệp trung gian MathML hay bộ chuyển đổi bên ngoài. Một công thức toán học được lưu trong khung văn bản dưới dạng một [MathPortion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathportion/). Sử dụng [MathPortion.getMathParagraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) để lấy một [MathParagraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/), sau đó gọi [MathParagraph.toLatex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/#toLatex--). Phương thức trả về một chuỗi mà bạn có thể lưu, hiển thị, gửi tới ứng dụng khác, hoặc xử lý tiếp.

Ví dụ sau duyệt qua mọi khung văn bản trên mọi slide, tìm tất cả các phần Math và ghi mỗi công thức vào một tệp `.tex` riêng:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) trả về tất cả các khung văn bản được tìm thấy trên một slide. Kiểm tra kiểu [MathPortion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathportion/) giúp tách các công thức có thể chỉnh sửa thực sự ra khỏi văn bản và hình ảnh thông thường.

Các engine LaTeX và mẫu tài liệu không phải đều hỗ trợ cùng một lệnh, gói hoặc ký tự Unicode. Hãy thử chuỗi trả về với engine LaTeX mà ứng dụng của bạn sử dụng. Nếu một ký hiệu hoặc phần tử Office Math không có biểu diễn phù hợp trong môi trường đó, hãy thay thế nó trong chuỗi trả về bằng một lệnh đặc thù của dự án hoặc bỏ qua công thức và ghi lại vấn đề để xem xét.

## **Lưu công thức toán học dưới dạng MathML**

Trong khi con người dễ viết mã cho một số định dạng công thức như LaTeX, họ gặp khó khăn khi viết mã cho MathML vì định dạng này thường được tạo tự động bởi các ứng dụng. Các chương trình đọc và phân tích MathML dễ dàng vì mã của nó là XML, do đó MathML thường được sử dụng làm định dạng xuất và in trong nhiều lĩnh vực. 

Mã mẫu này cho thấy cách xuất một công thức toán học từ bản trình bày sang MathML:

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

**Chính xác thì gì được xuất ra thành MathML—một đoạn văn hay một khối công thức riêng lẻ?**

Bạn có thể xuất toàn bộ đoạn toán học ([MathParagraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/)) hoặc một khối riêng lẻ ([MathBlock](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathblock/)) sang MathML. Cả hai kiểu đều cung cấp phương thức ghi ra MathML.

**Làm sao tôi biết một đối tượng trên slide là công thức toán học chứ không phải văn bản thường hoặc hình ảnh?**

Một công thức nằm trong một [MathPortion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathportion/) và có một [MathParagraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/). Hình ảnh và các phần văn bản thường không có [MathParagraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/) sẽ không được xuất dưới dạng công thức.

**MathML trong bản trình bày đến từ đâu—có phải là đặc thù của PowerPoint hay là một chuẩn?**

Quá trình xuất nhắm vào MathML chuẩn (XML). Aspose sử dụng Presentation MathML—phần phụ của chuẩn dành cho trình chiếu—được sử dụng rộng rãi trong các ứng dụng và trên web.

**Có hỗ trợ xuất công thức nằm trong bảng, SmartArt, nhóm, v.v. không?**

Có, nếu các đối tượng đó chứa các phần văn bản có [MathParagraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/) (tức là công thức PowerPoint thực sự), chúng sẽ được xuất. Nếu công thức được nhúng dưới dạng hình ảnh, nó sẽ không được xuất.

**Việc xuất sang MathML có thay đổi bản trình bày gốc không?**

Không. Việc ghi MathML là quá trình tuần tự hoá nội dung công thức; nó không làm thay đổi tệp bản trình bày.