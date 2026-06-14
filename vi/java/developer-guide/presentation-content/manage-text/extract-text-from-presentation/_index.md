---
title: Trích xuất văn bản nâng cao từ các bài thuyết trình trong Java
linktitle: Trích xuất văn bản
type: docs
weight: 90
url: /vi/java/extract-text-from-presentation/
keywords:
- trích xuất văn bản
- trích xuất văn bản từ slide
- trích xuất văn bản từ bài thuyết trình
- trích xuất văn bản từ PowerPoint
- trích xuất văn bản từ OpenDocument
- trích xuất văn bản từ PPT
- trích xuất văn bản từ PPTX
- trích xuất văn bản từ ODP
- lấy văn bản
- lấy văn bản từ slide
- lấy văn bản từ bài thuyết trình
- lấy văn bản từ PowerPoint
- lấy văn bản từ OpenDocument
- lấy văn bản từ PPT
- lấy văn bản từ PPTX
- lấy văn bản từ ODP
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Nhanh chóng trích xuất văn bản từ các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Java. Thực hiện theo hướng dẫn đơn giản, từng bước của chúng tôi để tiết kiệm thời gian."
---
## **Tổng quan**

Việc trích xuất văn bản từ các bài thuyết trình là một nhiệm vụ phổ biến nhưng quan trọng đối với các nhà phát triển làm việc với nội dung slide. Cho dù bạn đang xử lý các tệp Microsoft PowerPoint ở định dạng PPT hoặc PPTX, hoặc các bài thuyết trình OpenDocument (ODP), việc truy cập và lấy dữ liệu văn bản có thể rất quan trọng cho việc phân tích, tự động hoá, lập chỉ mục hoặc di chuyển nội dung.

Bài viết này cung cấp hướng dẫn toàn diện về cách trích xuất văn bản hiệu quả từ các định dạng bài thuyết trình khác nhau, bao gồm PPT, PPTX và ODP, bằng Aspose.Slides for Java. Bạn sẽ học cách duyệt qua các thành phần của bài thuyết trình một cách có hệ thống để lấy chính xác nội dung văn bản cần thiết.

## **Trích xuất văn bản từ một slide**

Aspose.Slides for Java cung cấp lớp [SlideUtil](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideutil/). Lớp này cung cấp một số phương thức tĩnh nạp chồng để trích xuất toàn bộ văn bản từ một bài thuyết trình hoặc slide. Để trích xuất văn bản từ một slide trong bài thuyết trình, hãy sử dụng phương thức [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Phương thức này nhận một đối tượng kiểu [IBaseSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/) làm tham số. Khi được thực thi, phương thức sẽ quét toàn bộ slide để tìm văn bản và trả về một mảng các đối tượng kiểu [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/), giữ nguyên mọi định dạng văn bản.

Đoạn mã sau trích xuất toàn bộ văn bản từ slide đầu tiên của bài thuyết trình:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Trích xuất văn bản từ một bài thuyết trình**

Để quét văn bản từ toàn bộ bài thuyết trình, hãy sử dụng phương thức tĩnh [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) được cung cấp bởi lớp [SlideUtil](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideutil/). Phương thức này nhận hai tham số:

1. Đầu tiên, một đối tượng [IPresentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/) đại diện cho một bài thuyết trình PowerPoint hoặc OpenDocument mà từ đó sẽ trích xuất văn bản.
1. Thứ hai, một giá trị `boolean` chỉ định liệu các slide mẫu (master slides) có nên được bao gồm khi quét văn bản từ bài thuyết trình hay không.

Phương thức trả về một mảng các đối tượng kiểu [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/), bao gồm thông tin định dạng văn bản. Đoạn mã dưới đây quét văn bản và chi tiết định dạng từ một bài thuyết trình, bao gồm cả các slide mẫu.

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Trích xuất văn bản phân loại và nhanh chóng**

Lớp [PresentationFactory](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationfactory/) cũng cung cấp các phương thức để trích xuất toàn bộ văn bản từ các bài thuyết trình:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Tham số enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textextractionarrangingmode/) cho biết chế độ tổ chức kết quả trích xuất văn bản và có thể được đặt thành các giá trị sau:

- `Unarranged` – Văn bản thô mà không quan tâm tới vị trí của nó trên slide.
- `Arranged` – Văn bản được sắp xếp theo cùng thứ tự như trên slide.

Chế độ không sắp xếp (`Unarranged`) có thể được sử dụng khi tốc độ là yếu tố quan trọng; nó nhanh hơn so với chế độ sắp xếp (`Arranged`).

[IPresentationText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationtext/) đại diện cho văn bản thô được trích xuất từ bài thuyết trình. Phương thức `getSlidesText` của nó trả về một mảng các đối tượng kiểu [ISlideText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidetext/). Mỗi đối tượng đại diện cho văn bản trên slide tương ứng. Đối tượng kiểu [ISlideText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidetext/) có các phương thức sau:

- `getText` – Văn bản trong các hình dạng của slide.
- `getMasterText` – Văn bản trong các hình dạng của slide mẫu liên kết với slide này.
- `getLayoutText` – Văn bản trong các hình dạng của slide bố cục liên kết với slide này.
- `getNotesText` – Văn bản trong các hình dạng của slide ghi chú liên kết với slide này.
- `getCommentsText` – Văn bản trong các bình luận liên kết với slide này.

```java
String presentationPath = "presentation.ppt";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **Câu hỏi thường gặp**

**Aspose.Slides xử lý các bài thuyết trình lớn trong quá trình trích xuất văn bản nhanh như thế nào?**

Aspose.Slides được tối ưu hoá cho hiệu năng cao và có thể xử lý ngay cả [các bài thuyết trình lớn](/slides/vi/java/open-presentation/), phù hợp cho các kịch bản xử lý thời gian thực hoặc hàng loạt.

**Aspose.Slides có thể trích xuất văn bản từ bảng và biểu đồ trong bài thuyết trình không?**

Có. Aspose.Slides có thể trích xuất văn bản từ nhiều thành phần slide, bao gồm bảng và các đối tượng liên quan đến biểu đồ, cho phép bạn truy cập và phân tích nội dung văn bản trong các cấu trúc bài thuyết trình phổ biến.

**Tôi có cần giấy phép Aspose.Slides đặc biệt nào để trích xuất văn bản từ bài thuyết trình không?**

Bạn có thể trích xuất văn bản bằng phiên bản dùng thử miễn phí của Aspose.Slides, mặc dù nó sẽ có [một số hạn chế](/slides/vi/java/licensing/), chẳng hạn chỉ xử lý được số lượng slide có hạn. Để sử dụng không giới hạn và xử lý các bài thuyết trình lớn hơn, nên mua giấy phép đầy đủ.