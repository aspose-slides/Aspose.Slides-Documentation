---
title: Trích xuất Văn bản Nâng cao từ Các Bản trình bày trong JavaScript
linktitle: Trích xuất Văn bản
type: docs
weight: 90
url: /vi/nodejs-java/extract-text-from-presentation/
keywords:
- trích xuất văn bản
- trích xuất văn bản từ slide
- trích xuất văn bản từ bản trình bày
- trích xuất văn bản từ PowerPoint
- trích xuất văn bản từ OpenDocument
- trích xuất văn bản từ PPT
- trích xuất văn bản từ PPTX
- trích xuất văn bản từ ODP
- lấy văn bản
- lấy văn bản từ slide
- lấy văn bản từ bản trình bày
- lấy văn bản từ PowerPoint
- lấy văn bản từ OpenDocument
- lấy văn bản từ PPT
- lấy văn bản từ PPTX
- lấy văn bản từ ODP
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Nhanh chóng trích xuất văn bản từ các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js qua Java. Thực hiện theo hướng dẫn đơn giản, từng bước để tiết kiệm thời gian."
---
## **Tổng quan**

Trích xuất văn bản từ các bản trình bày là một nhiệm vụ phổ biến nhưng quan trọng đối với các nhà phát triển làm việc với nội dung slide. Cho dù bạn đang xử lý tệp Microsoft PowerPoint ở định dạng PPT hoặc PPTX, hay các bản trình bày OpenDocument (ODP), việc truy cập và lấy dữ liệu văn bản có thể là yếu tố then chốt cho việc phân tích, tự động hoá, lập chỉ mục hoặc di chuyển nội dung.

Bài viết này cung cấp hướng dẫn toàn diện về cách trích xuất văn bản một cách hiệu quả từ các định dạng bản trình bày khác nhau, bao gồm PPT, PPTX và ODP, bằng Aspose.Slides for Node.js via Java. Bạn sẽ học cách duyệt qua các yếu tố của bản trình bày một cách hệ thống để lấy chính xác nội dung văn bản mà bạn cần.

## **Trích xuất văn bản từ một slide**

Aspose.Slides for Node.js via Java cung cấp lớp [SlideUtil](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideutil/). Lớp này cung cấp một số phương thức tĩnh nạp chồng để trích xuất toàn bộ văn bản từ một bản trình bày hoặc slide. Để trích xuất văn bản từ một slide trong bản trình bày, sử dụng phương thức [getAllTextBoxes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-). Phương thức này nhận một đối tượng slide làm tham số. Khi thực thi, phương thức sẽ quét toàn bộ slide để tìm văn bản và trả về một mảng các đối tượng [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/), bảo toàn các định dạng văn bản.

Đoạn mã dưới đây trích xuất toàn bộ văn bản từ slide đầu tiên của bản trình bày:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Trích xuất văn bản từ một bản trình bày**

Để quét văn bản từ toàn bộ bản trình bày, sử dụng phương thức tĩnh [getAllTextFrames](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) được cung cấp bởi lớp [SlideUtil](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideutil/). Phương thức này nhận hai tham số:

1. Đầu tiên, một đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) đại diện cho bản trình bày PowerPoint hoặc OpenDocument mà từ đó văn bản sẽ được trích xuất.  
1. Thứ hai, một giá trị `boolean` cho biết liệu các slide master có được bao gồm khi quét văn bản từ bản trình bày hay không.

Phương thức trả về một mảng các đối tượng [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/), bao gồm thông tin định dạng văn bản. Đoạn mã dưới đây quét văn bản và chi tiết định dạng từ một bản trình bày, bao gồm các slide master.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Trích xuất văn bản có phân loại và nhanh**

Lớp [PresentationFactory](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/) cũng cung cấp các phương thức để trích xuất toàn bộ văn bản từ các bản trình bày:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

Tham số enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textextractionarrangingmode/) chỉ ra chế độ sắp xếp kết quả trích xuất văn bản và có thể được đặt thành các giá trị sau:
- `Unarranged` - Văn bản thô không quan tâm tới vị trí của nó trên slide.  
- `Arranged` - Văn bản được sắp xếp theo cùng thứ tự như trên slide.

Chế độ không sắp xếp có thể được sử dụng khi tốc độ là yếu tố quan trọng; nó nhanh hơn chế độ sắp xếp.

[PresentationText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationtext/) đại diện cho văn bản thô được trích xuất từ bản trình bày. Phương thức `getSlidesText` của nó trả về một mảng các đối tượng, mỗi đối tượng đại diện cho văn bản trên slide tương ứng. Mỗi đối tượng văn bản slide có các phương thức sau:

- Phương thức `getText` trả về văn bản trong các shape của slide.  
- Phương thức `getMasterText` trả về văn bản trong các shape của slide master liên quan tới slide này.  
- Phương thức `getLayoutText` trả về văn bản trong các shape của layout slide liên quan tới slide này.  
- Phương thức `getNotesText` trả về văn bản trong các shape của notes slide liên quan tới slide này.  
- Phương thức `getCommentsText` trả về văn bản trong các comment liên quan tới slide này.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **Câu hỏi thường gặp**

**Aspose.Slides xử lý các bản trình bày lớn như thế nào khi trích xuất văn bản?**

Aspose.Slides được tối ưu cho hiệu suất cao và có thể xử lý ngay cả [các bản trình bày lớn](/slides/vi/nodejs-java/open-presentation/), phù hợp với các kịch bản xử lý thời gian thực hoặc hàng loạt.

**Aspose.Slides có thể trích xuất văn bản từ bảng và biểu đồ trong bản trình bày không?**

Có. Aspose.Slides có thể trích xuất văn bản từ nhiều yếu tố slide, bao gồm bảng và các đối tượng liên quan tới biểu đồ, cho phép bạn truy cập và phân tích nội dung văn bản trong các cấu trúc bản trình bày phổ biến.

**Tôi có cần giấy phép Aspose.Slides đặc biệt để trích xuất văn bản từ bản trình bày không?**

Bạn có thể trích xuất văn bản bằng phiên bản dùng thử miễn phí của Aspose.Slides, tuy nhiên nó sẽ có [một số hạn chế](/slides/vi/nodejs-java/licensing/), chẳng hạn chỉ xử lý số lượng slide giới hạn. Để sử dụng không hạn chế và xử lý các bản trình bày lớn hơn, nên mua giấy phép đầy đủ.