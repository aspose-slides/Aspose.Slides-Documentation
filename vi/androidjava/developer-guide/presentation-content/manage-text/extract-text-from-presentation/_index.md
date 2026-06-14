---
title: Trích xuất Văn bản Nâng cao từ Các Bản thuyết trình trên Android
linktitle: Trích xuất Văn bản
type: docs
weight: 90
url: /vi/androidjava/extract-text-from-presentation/
keywords:
- trích xuất văn bản
- trích xuất văn bản từ slide
- trích xuất văn bản từ bản thuyết trình
- trích xuất văn bản từ PowerPoint
- trích xuất văn bản từ OpenDocument
- trích xuất văn bản từ PPT
- trích xuất văn bản từ PPTX
- trích xuất văn bản từ ODP
- lấy văn bản
- lấy văn bản từ slide
- lấy văn bản từ bản thuyết trình
- lấy văn bản từ PowerPoint
- lấy văn bản từ OpenDocument
- lấy văn bản từ PPT
- lấy văn bản từ PPTX
- lấy văn bản từ ODP
- PowerPoint
- OpenDocument
- bản thuyết trình
- Android
- Java
- Aspose.Slides
description: "Nhanh chóng trích xuất văn bản từ các bản thuyết trình PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho Android qua Java. Thực hiện theo hướng dẫn đơn giản, từng bước của chúng tôi để tiết kiệm thời gian."
---
## **Tổng quan**

Việc trích xuất văn bản từ các bản thuyết trình là một nhiệm vụ phổ biến nhưng quan trọng đối với các nhà phát triển làm việc với nội dung slide. Cho dù bạn đang xử lý các tệp Microsoft PowerPoint ở định dạng PPT hoặc PPTX, hoặc các bản thuyết trình OpenDocument (ODP), việc truy cập và lấy dữ liệu văn bản có thể quan trọng đối với việc phân tích, tự động hoá, lập chỉ mục hoặc di chuyển nội dung.

Bài viết này cung cấp hướng dẫn toàn diện về cách trích xuất văn bản một cách hiệu quả từ các định dạng bản thuyết trình khác nhau, bao gồm PPT, PPTX và ODP, bằng cách sử dụng Aspose.Slides for Android via Java. Bạn sẽ học cách duyệt qua các yếu tố của bản thuyết trình một cách có hệ thống để lấy đúng nội dung văn bản mà bạn cần.

## **Trích xuất Văn bản từ một Slide**

Aspose.Slides for Android via Java cung cấp lớp [SlideUtil](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideutil/). Lớp này khai báo một số phương thức tĩnh nạp chồng để trích xuất toàn bộ văn bản từ một bản thuyết trình hoặc slide. Để trích xuất văn bản từ một slide trong bản thuyết trình, sử dụng phương thức [getAllTextBoxes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Phương thức này nhận một đối tượng kiểu [IBaseSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/) làm tham số. Khi thực thi, phương thức sẽ quét toàn bộ slide để tìm văn bản và trả về một mảng các đối tượng kiểu [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/), giữ nguyên mọi định dạng văn bản.

Đoạn mã sau trích xuất toàn bộ văn bản từ slide đầu tiên của bản thuyết trình:

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

## **Trích xuất Văn bản từ một Bản thuyết trình**

Để quét văn bản từ toàn bộ bản thuyết trình, sử dụng phương thức tĩnh [getAllTextFrames](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) được cung cấp bởi lớp [SlideUtil](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideutil/). Phương thức này nhận hai tham số:

1. Đầu tiên, một đối tượng [IPresentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/) đại diện cho một bản thuyết trình PowerPoint hoặc OpenDocument mà từ đó văn bản sẽ được trích xuất.  
1. Thứ hai, một giá trị `boolean` cho biết liệu các slide mẫu (master slides) có nên được bao gồm khi quét văn bản từ bản thuyết trình hay không.

Phương thức trả về một mảng các đối tượng kiểu [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/), bao gồm thông tin định dạng văn bản. Đoạn mã dưới đây quét văn bản và chi tiết định dạng từ một bản thuyết trình, bao gồm các slide mẫu.

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

## **Trích xuất Văn bản Phân Loại và Nhanh**

Lớp [PresentationFactory](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationfactory/) cũng cung cấp các phương thức để trích xuất toàn bộ văn bản từ các bản thuyết trình:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Tham số enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textextractionarrangingmode/) cho biết chế độ sắp xếp kết quả trích xuất văn bản và có thể được đặt thành các giá trị sau:
- `Unarranged` - Văn bản thô mà không quan tâm tới vị trí của nó trên slide.  
- `Arranged` - Văn bản được sắp xếp theo cùng thứ tự như trên slide.

Chế độ không sắp xếp có thể được sử dụng khi tốc độ là yếu tố quan trọng; nó nhanh hơn chế độ sắp xếp.

[IPresentationText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationtext/) đại diện cho văn bản thô được trích xuất từ bản thuyết trình. Phương thức `getSlidesText` của nó trả về một mảng các đối tượng kiểu [ISlideText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidetext/). Mỗi đối tượng đại diện cho văn bản trên slide tương ứng. Đối tượng kiểu [ISlideText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidetext/) có các phương thức sau:

- `getText` - Văn bản trong các hình dạng của slide.  
- `getMasterText` - Văn bản trong các hình dạng của slide mẫu (master slide) liên kết với slide này.  
- `getLayoutText` - Văn bản trong các hình dạng của slide bố cục (layout slide) liên kết với slide này.  
- `getNotesText` - Văn bản trong các hình dạng của slide ghi chú (notes slide) liên kết với slide này.  
- `getCommentsText` - Văn bản trong các bình luận liên kết với slide này.

```java
String presentationPath = "presentation.pptx";
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

**Aspose.Slides xử lý các bản thuyết trình lớn như thế nào khi trích xuất văn bản?**

Aspose.Slides được tối ưu hóa để đạt hiệu suất cao và có thể xử lý ngay cả [các bản thuyết trình lớn](/slides/vi/androidjava/open-presentation/), giúp nó thích hợp cho các kịch bản xử lý thời gian thực hoặc hàng loạt.

**Aspose.Slides có thể trích xuất văn bản từ bảng và biểu đồ trong bản thuyết trình không?**

Có. Aspose.Slides có thể trích xuất văn bản từ nhiều thành phần của slide, bao gồm bảng và các đối tượng liên quan đến biểu đồ, cho phép bạn truy cập và phân tích nội dung văn bản trong các cấu trúc bản thuyết trình phổ biến.

**Tôi có cần giấy phép đặc biệt của Aspose.Slides để trích xuất văn bản từ bản thuyết trình không?**

Bạn có thể trích xuất văn bản bằng phiên bản dùng thử miễn phí của Aspose.Slides, tuy nhiên nó sẽ có [một số hạn chế](/slides/vi/androidjava/licensing/), chẳng hạn chỉ xử lý được một số lượng slide giới hạn. Để sử dụng không giới hạn và xử lý các bản thuyết trình lớn hơn, nên mua giấy phép đầy đủ.